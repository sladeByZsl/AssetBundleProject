
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
---------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：XmlSourceFile.cs;
	作	者：jiabin;
	时	间：2017 - 04 - 20;
	注	释：直接读取源文件（Xml）获取配置信息;
**************************************************************************************************/

#if UNITY_EDITOR

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
	public class XmlSourceFile
    {

		private class DataInfo
		{
			public readonly GroupTypeFinder typeFinder;
			public int usedTimes = 0;

			public readonly string path;
			public readonly int typeIndex;

			public DataInfo(string path, GroupTypeFinder typeFinder, int typeIndex)
			{
				this.path = path;
				this.typeFinder = typeFinder;
				this.typeIndex = typeIndex;
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
                if(type == null)
                {
                    type = Type.GetType(string.Format("{0},Assembly-CSharp-Editor", mTypeNames[index]));
                }
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

        private static XmlSourceFile singleton_instance = null;

        public static XmlSourceFile Instance
        {
            get
            {
                if (singleton_instance == null)
                {
                    singleton_instance = new XmlSourceFile();
                }
                return singleton_instance;
            }
        }

        private Dictionary<string, DataInfo> mDataInfos = new Dictionary<string, DataInfo>();

		private Dictionary<string, string[]> mGroupXmls = new Dictionary<string, string[]>();

		private XmlSourceFile() { }

        public void Reset() {
            mDataInfos.Clear();
            mGroupXmls.Clear();
        }

		/// <summary>
		/// 将一个组中所有的xml数据加到数据库中，运行时将读取原始数据
		/// </summary>
		/// <param name="group">该组的所有信息</param>
		/// <returns>组名称，若添加失败或该组已存在，则返回null</returns>
		public string AddToDatabase(XmlGroupSettings group)
		{
			return AddToDatabase(group, null);
		}

		/// <summary>
		/// 将一个组中所有的xml数据加到数据库中，运行时将读取原始数据
		/// </summary>
		/// <param name="group">该组的所有信息</param>
		/// <param name="addedXmls">从组中加到数据库中的所有xml名称</param>
		/// <returns>组名称，若添加失败或该组已存在，则返回null</returns>
		public string AddToDatabase(XmlGroupSettings group, IList<string> addedXmls)
		{
			if (group == null) { return null; }
			if (mGroupXmls.ContainsKey(group.group)) { return null; }
			GroupTypeFinder typeFinder = new GroupTypeFinder("Assembly-CSharp", group.group);
			List<string> typeNames = new List<string>();
			int count = group.xmlFiles.Length;
			string[] xmls = new string[count];
			for (int i = 0; i < count; i++)
			{
				XmlGroupSettings.XmlData data = group.xmlFiles[i];
				string xmlName = Path.GetFileNameWithoutExtension(data.path);
				if (mDataInfos.ContainsKey(xmlName))
				{
					Debug.LogError(string.Format("Xml '{0}' is already existed !", xmlName));
					continue;
				}
				int typeIndex = typeNames.IndexOf(data.typeName);
				if (typeIndex < 0)
				{
					typeIndex = typeNames.Count;
					typeNames.Add(data.typeName);
				}
				mDataInfos.Add(xmlName, new DataInfo(data.path, typeFinder, typeIndex));
				xmls[i] = xmlName;
				if (addedXmls != null) { addedXmls.Add(xmlName); }
			}
			typeFinder.SetTypes(typeNames.ToArray());
			mGroupXmls.Add(group.group, xmls);
			return group.group;
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

            byte[] xmlBytes = null;
            StreamReader sr = null;
            System.Xml.XmlReader xr = null;
            MemoryStream dataStream = new MemoryStream();
            string path = string.Format("{0}/../{1}", Application.dataPath, info.path);
            try
            {
                sr = File.OpenText(path);
                xr = System.Xml.XmlReader.Create(sr);
                Type type = info.typeFinder.GetType((ushort)info.typeIndex);
                if (type == null) { return null; }

                xmlType = info.typeFinder.GetTypeName((ushort)info.typeIndex);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
                object obj = serializer.Deserialize(xr);
                RuntimeTypeModel.Default.SerializeWithLengthPrefix(dataStream, obj, type, ProtoBuf.PrefixStyle.Fixed32, 0);

                dataStream.Position = 0;
                int xmlLength = DatabaseStreamReader.ReadInt(dataStream);
                xmlBytes = new byte[xmlLength];
                dataStream.Read(xmlBytes, 0, xmlLength);
            }
            catch (Exception e)
            {
                System.Xml.XmlTextReader xtr = xr as System.Xml.XmlTextReader;
                if (xtr != null)
                {
                    Debug.LogError(string.Format("Xml Parse Error At '{0}:{1},{2}'", path, xtr.LineNumber, xtr.LinePosition));
                }
                Debug.LogException(e);
            }
            if (dataStream != null) { dataStream.Close(); }
            if (xr != null) { xr.Close(); }
            if (sr != null) { sr.Close(); }

            return xmlBytes;
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

            T ret = null;
            StreamReader sr = null;
            System.Xml.XmlReader xr = null;
            string path = string.Format("{0}/../{1}", Application.dataPath, info.path);
            try
            {
                sr = File.OpenText(path);
                xr = System.Xml.XmlReader.Create(sr);
                type = info.typeFinder.GetType((ushort)info.typeIndex);
                if (type == null) { type = typeof(T); }
                if (typeof(T) == type || type.IsSubclassOf(typeof(T)))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(type);
                    ret = (T)xs.Deserialize(xr);
                }
            }
            catch (Exception e)
            {
                System.Xml.XmlTextReader xtr = xr as System.Xml.XmlTextReader;
                if (xtr != null)
                {
                    Debug.LogError(string.Format("Xml Parse Error At '{0}:{1},{2}'", path, xtr.LineNumber, xtr.LinePosition));
                }
                Debug.LogException(e);
            }
            if (xr != null) { xr.Close(); }
            if (sr != null) { sr.Close(); }
            return ret;
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

#endif