
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：XmlDatabase.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 14;
	注	释：;
**************************************************************************************************/

using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace FunPlus.Common.Config
{

	/// <summary>
	/// 用于解析、读取所有Xml定义的数据
	/// </summary>
	public class XmlDatabase
	{

		private class DataInfo
		{

			public readonly Stream stream;
			public readonly GroupTypeFinder typeFinder;
			public readonly int offset;
			public int usedTimes = 0;

			public DataInfo(Stream stream, GroupTypeFinder typeFinder, int offset)
			{
				this.stream = stream;
				this.typeFinder = typeFinder;
				this.offset = offset;
			}
		}

		private sealed class GroupTypeFinder
		{

			public readonly string group;
			private string mNameSpace;
			private string[] mTypeNames;
			private Type[] mTypes;

			public GroupTypeFinder(string ns, string group)
			{
				mNameSpace = ns;
				this.group = group;
			}

			public void SetTypes(string[] typeNames)
			{
				mTypeNames = typeNames;
				mTypes = new Type[typeNames.Length];
			}

			public Type GetType(ushort index)
			{
				Type type = mTypes[index];
				if (type != null) { return type; }
				type = Type.GetType(string.Format("{0},{1}", mTypeNames[index], mNameSpace));
				mTypes[index] = type;
				ProtoBufInheritSupport.AddType(type);
				return type;
			}

            // 某些xml类型是lua层进行解析的，所以c#层没有此xml类的定义，此时也不需要获取Type进行反序列化，只需对应的类型名称即可;
            public string GetTypeName(ushort index)
            {
                if(index >= mTypeNames.Length)
                {
                    return "";
                }
                return mTypeNames[index];
            }
        }

		private static XmlDatabase singleton_instance = null;

		public static XmlDatabase Instance
		{
			get
			{
				if (singleton_instance == null)
				{
					singleton_instance = new XmlDatabase();
				}
				return singleton_instance;
			}
		}

		private Dictionary<string, DataInfo> mDataInfos = new Dictionary<string, DataInfo>();

		private Dictionary<string, string[]> mGroupXmls = new Dictionary<string, string[]>();

		private XmlDatabase() { }

        public void Reset() {
            mDataInfos.Clear();
            mGroupXmls.Clear();
        }
		/// <summary>
		/// 将一个组中所有的xml数据加到数据库中
		/// </summary>
		/// <param name="stream">该组的数据流</param>
		/// <returns>组名称，若添加失败或该组已存在，则返回null</returns>
		public string AddToDatabase(Stream stream)
		{
			return AddToDatabase(stream, null);
		}

		/// <summary>
		/// 将一个组中所有的xml数据加到数据库中
		/// </summary>
		/// <param name="stream">该组的数据流</param>
		/// <param name="addedXmls">从组中加到数据库中的所有xml名称</param>
		/// <returns>组名称，若添加失败或该组已存在，则返回null</returns>
		public string AddToDatabase(Stream stream, IList<string> addedXmls)
		{
			stream.Position = 0L;
			byte[] buffer = new byte[1024];
			ushort groupLen = DatabaseStreamReader.ReadUShort(stream);
			stream.Read(buffer, 0, groupLen);
			string groupKey = Encoding.UTF8.GetString(buffer, 0, groupLen);
			if (mGroupXmls.ContainsKey(groupKey)) { return null; }
			ushort count = DatabaseStreamReader.ReadUShort(stream);
			string[] xmls = new string[count];
			GroupTypeFinder typeFinder = new GroupTypeFinder("Assembly-CSharp", groupKey);
			for (ushort i = 0; i < count; i++)
			{
				ushort nameLen = DatabaseStreamReader.ReadUShort(stream);
				//Debug.LogWarning(nameLen);
				stream.Read(buffer, 0, nameLen);
				string xmlName = Encoding.UTF8.GetString(buffer, 0, nameLen);
				int offset = DatabaseStreamReader.ReadInt(stream);
				if (mDataInfos.ContainsKey(xmlName))
				{
					Debug.LogError(string.Format("Xml '{0}' is already existed !", xmlName));
					continue;
				}
				mDataInfos.Add(xmlName, new DataInfo(stream, typeFinder, offset));
				xmls[i] = xmlName;
				if (addedXmls != null) { addedXmls.Add(xmlName); }
			}
			ushort typeCount = DatabaseStreamReader.ReadUShort(stream);
			string[] typeNames = new string[typeCount];
			for (uint i = 0; i < typeCount; i++)
			{
				int len = stream.ReadByte();
				stream.Read(buffer, 0, len);
				typeNames[i] = Encoding.UTF8.GetString(buffer, 0, len);
			}
			typeFinder.SetTypes(typeNames);
			mGroupXmls.Add(groupKey, xmls);
			return groupKey;
		}

		/// <summary>
		/// 将指定的组从数据库中移除
		/// </summary>
		/// <param name="groupKey">要移除组名称</param>
		/// <returns>该组对应的数据流（若存在）</returns>
		public Stream RemoveFromDatabase(string groupKey)
		{
			return RemoveFromDatabase(groupKey, null, null);
		}

		/// <summary>
		/// 将指定的组从数据库中移除
		/// </summary>
		/// <param name="groupKey">要移除组名称</param>
		/// <param name="removedXmls">从数据库中移除的xml名称</param>
		/// <returns>该组对应的数据流（若存在）</returns>
		public Stream RemoveFromDatabase(string groupKey, IList<string> removedXmls)
		{
			return RemoveFromDatabase(groupKey, removedXmls, null);
		}

		/// <summary>
		/// 将指定的组从数据库中移除
		/// </summary>
		/// <param name="groupKey">要移除组名称</param>
		/// <param name="removedXmls">从数据库中移除的xml名称</param>
		/// <param name="neverUsedXmls">移除的xml中，从未使用过的xml名称</param>
		/// <returns>该组对应的数据流（若存在）</returns>
		public Stream RemoveFromDatabase(string groupKey, IList<string> removedXmls, IList<string> neverUsedXmls)
		{
			string[] xmls;
			if (!mGroupXmls.TryGetValue(groupKey, out xmls)) { return null; }
			mGroupXmls.Remove(groupKey);
			Stream stream = null;
			for (int i = 0, imax = xmls.Length; i < imax; i++)
			{
				string xml = xmls[i];
				if (string.IsNullOrEmpty(xml)) { continue; }
				DataInfo info;
				if (!mDataInfos.TryGetValue(xml, out info)) { continue; }
				if (stream == null)
				{
					stream = info.stream;
				}
				else if (stream != info.stream)
				{
					Debug.LogError(string.Format("Multi group files contains the same group key '{0}' !", groupKey));
				}
				if (removedXmls != null) { removedXmls.Add(xml); }
				if (neverUsedXmls != null && info.usedTimes <= 0) { neverUsedXmls.Add(xml); }
				mDataInfos.Remove(xml);
			}
			return stream;
		}

        /// <summary>
		/// 根据xml名称从数据库中获取该xml定义的数据
		/// </summary>
		/// <param name="xmlName">xml名称</param>
		/// <returns>该xml中的二进制数据</returns>
		public byte[] GetXMLBytes(string xmlName, out string xmlType)
        {
            xmlType = "";
            if (string.IsNullOrEmpty(xmlName)) { return null; }
            DataInfo info;
            if (!mDataInfos.TryGetValue(xmlName, out info)) { return null; }
            info.usedTimes++;
            Stream s = info.stream;
            if (s == null)
            {
				return null;
            }
            s.Position = (long)info.offset;
            ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
            xmlType = info.typeFinder.GetTypeName(typeIndex);
            int length = DatabaseStreamReader.ReadInt(s);
            byte[] bytes = new byte[length];
            s.Read(bytes, 0, length);
            return bytes;
        }

        /// <summary>
        /// 根据xml名称从数据库中获取该xml定义的数据
        /// </summary>
        /// <typeparam name="T">数据类型或该类型的基类</typeparam>
        /// <param name="xmlName">xml名称</param>
        /// <returns>该xml中的数据</returns>
        public T Get<T>(string xmlName) where T : class
		{
			if (string.IsNullOrEmpty(xmlName)) { return null; }
			Type type;
			DataInfo info;
			if (!mDataInfos.TryGetValue(xmlName, out info)) { return null; }
			info.usedTimes++;
			Stream s = info.stream;
			if (s == null)
			{
				return null;
			}
			s.Position = (long)info.offset;
			ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
			type = info.typeFinder.GetType(typeIndex);
			if (type == null)
			{
				return Serializer.DeserializeWithLengthPrefix<T>(s, PrefixStyle.Fixed32);
			}
			if (typeof(T) == type || type.IsSubclassOf(typeof(T)))
			{
				return (T)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(s, null, type, PrefixStyle.Fixed32, 0);
			}
			return null;
		}

		/// <summary>
		/// 获取指定的组中所有的xml的名称
		/// </summary>
		/// <param name="groupKey">组的名称</param>
		/// <param name="xmls">组中所有xml名称要写入的数组</param>
		/// <returns>是否成功获取</returns>
		public bool GetGroupXmls(string groupKey, List<string> xmls)
		{
			string[] xs;
			if (!mGroupXmls.TryGetValue(groupKey, out xs)) { return false; }
			if (xmls != null)
			{
				xmls.AddRange(xs);
			}
			return true;
		}

		/// <summary>
		/// 获取当前数据库中所有的xml名称
		/// </summary>
		/// <param name="xmls">所有xml名称要写入的数组</param>
		public void GetAllXmls(List<string> xmls)
		{
			if (xmls == null) { return; }
			xmls.AddRange(mDataInfos.Keys);
		}

	}

}
