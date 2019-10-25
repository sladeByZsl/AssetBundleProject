
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：XmlSerializer.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 14;
	注	释：;
**************************************************************************************************/

using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using XSerializer = System.Xml.Serialization.XmlSerializer;

namespace FunPlus.Common.Config
{

	public static class XmlSerializer
	{

		public delegate void PreSerializeDelegate(string name, Type type, ref object obj);

		/// <summary>
		/// 用于在将数据转成PB二进制流之前，对数据进行自定义处理
		/// </summary>
		public static PreSerializeDelegate OnPreSerialize;

		/// <summary>
		/// 将指定的XmlGroup数据序列化并生成二进制文件
		/// </summary>
		/// <param name="group">该组的所有信息</param>
		public static void SerializeXmls(XmlGroupSettings group)
		{
			FileStream fs = File.OpenWrite(group.group);
			MemoryStream dataStream = new MemoryStream();
			Exception e = null;
			try
			{
				Dictionary<string, int> allTypes = new Dictionary<string, int>();
				byte[] bytesContent = Encoding.UTF8.GetBytes(group.group);
				byte[] bytesLength = BitConverter.GetBytes((ushort)bytesContent.Length);
				fs.Write(bytesLength, 0, bytesLength.Length);
				fs.Write(bytesContent, 0, bytesContent.Length);
				int count = group.xmlFiles.Length;
				byte[] bytesCount = BitConverter.GetBytes((ushort)count);
				fs.Write(bytesCount, 0, bytesCount.Length);
				int[] offsets = new int[count];
				long[] offsetsPos = new long[count];
				for (int i = 0; i < count; i++)
				{
					XmlGroupSettings.XmlData data = group.xmlFiles[i];
					string name = Path.GetFileNameWithoutExtension(data.path);
					byte[] bytes = Encoding.UTF8.GetBytes(name);
					byte[] bytesLen = BitConverter.GetBytes((ushort)bytes.Length);
					byte[] bytesOffset = BitConverter.GetBytes((int)dataStream.Position);
					fs.Write(bytesLen, 0, bytesLen.Length);
					fs.Write(bytes, 0, bytes.Length);
					offsets[i] = (int)dataStream.Position;
					offsetsPos[i] = fs.Position;
					fs.Write(bytesOffset, 0, bytesOffset.Length);
					SerializeXml(name, dataStream, data.path, data.typeName, allTypes);
				}
				string[] allTypeNames = new string[allTypes.Count];
				foreach (KeyValuePair<string, int> kv in allTypes)
				{
					allTypeNames[kv.Value] = kv.Key;
				}
				byte[] bl = BitConverter.GetBytes((ushort)allTypeNames.Length);
				fs.Write(bl, 0, bl.Length);
				for (int i = 0, imax = allTypeNames.Length; i < imax; i++)
				{
					bytesContent = Encoding.UTF8.GetBytes(allTypeNames[i]);
					if (bytesContent.Length > 255)
					{
						throw new Exception(string.Format("Type Name '{0}' is too long !", allTypeNames[i]));
					}
					fs.WriteByte((byte)bytesContent.Length);
					fs.Write(bytesContent, 0, bytesContent.Length);
				}
				int seg = (int)fs.Position;
				for (int i = 0; i < count; i++)
				{
					byte[] bytesOffset = BitConverter.GetBytes(seg + offsets[i]);
					fs.Position = offsetsPos[i];
					fs.Write(bytesOffset, 0, bytesOffset.Length);
				}
				fs.Position = (long)seg;
				dataStream.SetLength(dataStream.Position);
				dataStream.Position = 0L;
				byte[] buffer = new byte[256];
				while (true)
				{
					int len = dataStream.Read(buffer, 0, buffer.Length);
					if (len <= 0) { break; }
					fs.Write(buffer, 0, len);
				}
			}
			catch (Exception ex)
			{
				e = ex;
			}
			dataStream.Close();
			fs.SetLength(fs.Position);
			fs.Flush();
			fs.Close();
			if (e != null) { throw e; }
		}

		static void SerializeXml(string name, Stream streamData, string xmlPath, string typeName, Dictionary<string, int> allTypes)
		{
			Type type = Type.GetType(string.Format("{0},Assembly-CSharp", typeName));
			if (type == null)
			{
				type = Type.GetType(string.Format("{0},Assembly-CSharp-Editor", typeName));
				if(type == null)
				{
					throw new Exception(string.Format("Type '{0}' not found !", typeName));
				}
			}
			FileStream fs = File.OpenRead(xmlPath);
			XmlReader reader = XmlReader.Create(fs);
			try
			{
				int typeIndex;
				if (!allTypes.TryGetValue(typeName, out typeIndex))
				{
					ProtoBufInheritSupport.AddType(type);
					//UnityEngine.Debug.LogError(typeName);
					typeIndex = allTypes.Count;
					allTypes.Add(typeName, typeIndex);
				}
				byte[] bytesType = BitConverter.GetBytes((ushort)typeIndex);
				streamData.Write(bytesType, 0, bytesType.Length);
				XSerializer serializer = new XSerializer(type);
				object obj = serializer.Deserialize(reader);
				if (OnPreSerialize != null) { OnPreSerialize(name, type, ref obj); }
				RuntimeTypeModel.Default.SerializeWithLengthPrefix(streamData, obj, type, ProtoBuf.PrefixStyle.Fixed32, 0);
				fs.Close();
			}
			catch (Exception e)
			{
				if (reader is XmlTextReader)
				{
					XmlTextReader xr = reader as XmlTextReader;
					string err = string.Format("Parse Xml Failed at '{0}':{1},{2}", xmlPath, xr.LineNumber, xr.LinePosition);
					e = new Exception(string.Concat(err, "\n\n", e.Message), e);
				}
				reader.Close();
				fs.Close();
				throw e;
			}
			FunPlus.Util.CheckXML.GetInstance().Check(type, xmlPath, false, true);
		}

	}

}
