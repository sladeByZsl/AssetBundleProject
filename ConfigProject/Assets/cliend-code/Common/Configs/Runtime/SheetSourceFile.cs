
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
---------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：SheetSourceFile.cs;
	作	者：jiabin;
	时	间：2017 - 04 - 20;
	注	释：直接读取源文件（Xml）获取sheet配置信息;
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
	/// 用于解析、读取所有sheet及其中的条目
	/// </summary>
	public sealed class SheetSourceFile
    {

		private static SheetSourceFile singleton_instance = null;

		public static SheetSourceFile Instance
		{
			get
			{
				if (singleton_instance == null)
				{
					singleton_instance = new SheetSourceFile();
				}
				return singleton_instance;
			}
		}

		private Dictionary<string, string[]> mGroupSheets = new Dictionary<string, string[]>();
		private Dictionary<string, SheetDatas> mRawSheets = new Dictionary<string, SheetDatas>();

        public void Reset()
        {
            mGroupSheets.Clear();
            mRawSheets.Clear();
        }
        private SheetSourceFile() { }

		/// <summary>
		/// 将一个组中所有的sheet加到数据库中，运行时将读取原始数据
		/// </summary>
		/// <param name="group">该组的所有信息</param>
		/// <returns>组名称，若添加失败或该组已存在，则返回null</returns>
		public string AddToDatabase(XmlSheetGroupSettings group)
		{
			return AddToDatabase(group, null);
		}

		/// <summary>
		/// 将一个组中所有的sheet加到数据库中，运行时将读取原始数据
		/// </summary>
		/// <param name="group">该组的所有信息</param>
		/// <param name="addedSheets">从组中加到数据库中的所有sheet名称</param>
		/// <returns>组名称，若添加失败或该组已存在，则返回null</returns>
		public string AddToDatabase(XmlSheetGroupSettings group, IList<string> addedSheets)
		{
			if (group == null) { return null; }
			if (mGroupSheets.ContainsKey(group.group)) { return null; }
			int sheetCount = group.sheetFiles.Length;
			string[] sheets = new string[sheetCount];
			for (int i = 0; i < sheetCount; i++)
			{
				XmlSheetGroupSettings.XmlSheetData sheetData = group.sheetFiles[i];
				List<string> files = new List<string>();
				List<Type> types = new List<Type>();
				if (mRawSheets.ContainsKey(sheetData.sheetName))
				{
					Debug.LogError(string.Format("Sheet '{0}' is already existed !", sheetData.sheetName));
					continue;
				}
				sheets[i] = sheetData.sheetName;
				for (int j = 0, jmax = sheetData.files.Length; j < jmax; j++)
				{
					XmlSheetGroupSettings.XmlSheetFile file = sheetData.files[j];
					Type type = Type.GetType(string.Format("{0},Assembly-CSharp", file.typeName));
					if (type == null)
					{
                        type = Type.GetType(string.Format("{0},Assembly-CSharp-Editor", file.typeName));
                        if (type == null)
                        {
                            throw new Exception(string.Format("Type '{0}' not found !", file.typeName));
                        }
					}
					files.Add(file.filePath);
					types.Add(type);
					if (addedSheets != null) { addedSheets.Add(sheetData.sheetName); }
				}
				mRawSheets.Add(sheetData.sheetName, new SheetDatas(files, types));
			}
			mGroupSheets.Add(group.group, sheets);
			return group.group;
		}

		/// <summary>
		/// 将指定的组从数据库中移除
		/// </summary>
		/// <param name="groupKey">要移除组名称</param>
		/// <returns>该组对应的数据流（若存在）</returns>
		public Stream RemoveFromDatabase(string groupKey)
		{
			string[] sheets;
			if (mGroupSheets.TryGetValue(groupKey, out sheets))
			{
				Stream stream = null;
				for (int i = 0, imax = sheets.Length; i < imax; i++)
				{
					string sheet = sheets[i];
					if (string.IsNullOrEmpty(sheet)) { continue; }

					SheetDatas sheetDatas;
					if (mRawSheets.TryGetValue(sheet, out sheetDatas))
					{
						sheetDatas.Close();
						mRawSheets.Remove(groupKey);
					}
				}
				mGroupSheets.Remove(groupKey);
				return stream;
			}
			return null;
		}

        #region GetSheetBytes Methods

        /// <summary>
        /// 在指定的sheet中读取id对应数据
        /// </summary>
        /// <typeparam name="T">条目的类型或该类型的基类</typeparam>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <param name="id">要获取的条目的id</param>
        /// <returns>id对应的条目</returns>
        public byte[] GetSheetBytes(string sheetName, int id, out string sheetType)
        {
            sheetType = "";
            SheetDatas sheetDatas;
            if (mRawSheets.TryGetValue(sheetName, out sheetDatas) && !sheetDatas.isStrKey)
            {
                return sheetDatas.GetItemBytes(id, out sheetType);
            }

            return null;
        }

        /// <summary>
        /// 在指定的sheet中读取key对应条目
        /// </summary>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <param name="key">要获取的条目的键</param>
        /// <returns>键对应的条目</returns>
        public byte[] GetSheetBytes(string sheetName, string key, out string sheetType)
        {
            sheetType = "";
            SheetDatas sheetDatas;
            if (mRawSheets.TryGetValue(sheetName, out sheetDatas) && sheetDatas.isStrKey)
            {
                return sheetDatas.GetItemBytes(key, out sheetType);
            }

            return null;
        }

        #endregion

        /// <summary>
        /// 在指定的sheet中读取id对应条目
        /// </summary>
        /// <typeparam name="T">条目的类型或该类型的基类</typeparam>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <param name="id">要获取的条目的id</param>
        /// <returns>id对应的条目</returns>
        public T GetSheetItem<T>(string sheetName, int id)
        {
            SheetDatas sheetDatas;
            if (mRawSheets.TryGetValue(sheetName, out sheetDatas) && !sheetDatas.isStrKey)
            {
                return sheetDatas.GetItem<T>(id);
            }
            return default(T);
        }

        /// <summary>
        /// 在指定的sheet中读取id对应的所有条目
        /// </summary>
        /// <typeparam name="T">条目的类型或该类型的基类</typeparam>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <param name="id">要获取的条目的id</param>
        /// <returns>id对应的所有条目</returns>
        public List<T> GetSheetItems<T>(string sheetName, int id)
        {
            List<T> items = new List<T>();
            SheetDatas sheetDatas;
            if (mRawSheets.TryGetValue(sheetName, out sheetDatas) && !sheetDatas.isStrKey)
            {
                items.AddRange(sheetDatas.GetItems<T>(id));
            }

            return items;
        }

        /// <summary>
        /// 在指定的sheet中读取key对应条目
        /// </summary>
        /// <typeparam name="T">条目的类型或该类型的基类</typeparam>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <param name="key">要获取的条目的键</param>
        /// <returns>键对应的条目</returns>
        public T GetSheetItem<T>(string sheetName, string key)
        {
            SheetDatas sheetDatas;
            if (mRawSheets.TryGetValue(sheetName, out sheetDatas) && sheetDatas.isStrKey)
            {
                return sheetDatas.GetItem<T>(key);
            }
            return default(T);
        }

        /// <summary>
        /// 在指定的sheet中读取key对应的所有条目
        /// </summary>
        /// <typeparam name="T">条目的类型或该类型的基类</typeparam>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <param name="key">要获取的条目的键</param>
        /// <returns>键对应的所有条目</returns>
        public List<T> GetSheetItems<T>(string sheetName, string key)
        {
            List<T> items = new List<T>();
            SheetDatas sheetDatas;
            if (mRawSheets.TryGetValue(sheetName, out sheetDatas) && sheetDatas.isStrKey)
            {
                items.AddRange(sheetDatas.GetItems<T>(key));
            }
            return items;
        }

		/// <summary>
		/// 获取当前数据库中所有sheet的名称
		/// </summary>
		/// <param name="sheets">所有sheet名称将写入的数组</param>
		public void GetAllSheets(List<string> sheets)
		{
			if (sheets == null) { return; }
			sheets.AddRange(mRawSheets.Keys);
		}

        /// <summary>
        /// 获取指定sheet中所有条目的id（采用迭代器方式，保证数据安全并减少内存开销）
        /// </summary>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <returns>该sheet中所有id的迭代器</returns>
        public IEnumerator<int> GetSheetItemIds(string sheetName)
        {
            SheetDatas sheetDatas;
            if (mRawSheets.TryGetValue(sheetName, out sheetDatas))
            {
                List<int> itemIds = sheetDatas.GetIds();
                for (int i = 0, imax = itemIds.Count; i < imax; i++)
                {
                    yield return itemIds[i];
                }
            }
            yield break;
        }

        /// <summary>
        /// 获取指定sheet中所有条目的键（采用迭代器方式，保证数据安全并减少内存开销）
        /// </summary>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <returns>该sheet中所有键的迭代器</returns>
        public IEnumerator<string> GetSheetItemKeys(string sheetName)
        {
            SheetDatas sheetDatas;
            if (mRawSheets.TryGetValue(sheetName, out sheetDatas))
            {
                List<string> itemKeys = sheetDatas.GetKeys();
                for (int i = 0, imax = itemKeys.Count; i < imax; i++)
                {
                    yield return itemKeys[i];
                }
            }
            yield break;
        }

		private class SheetDatas
		{
            struct ItemData
            {
                public object obj;
                public Type type;
            }

            private SortedList<int, List<ItemData>> mIdDatas = new SortedList<int, List<ItemData>>();
            private SortedList<string, List<ItemData>> mKeyDatas = new SortedList<string, List<ItemData>>();
            private List<XmlIdReader> mActiveIdReaders = new List<XmlIdReader>();
			private List<XmlIdReader> mActiveKeyReaders = new List<XmlIdReader>();
			private List<int> mCachedInts = new List<int>();
			private bool mStrKey;

			public SheetDatas(List<string> files, List<Type> itemTypes)
			{
				for (int i = 0, imax = files.Count; i < imax; i++)
				{
                    try
					{
                        string path = string.Format("{0}/../{1}", Application.dataPath, files[i]);
                        XmlIdReader r = new XmlIdReader(path, itemTypes[i]);
						if (i == 0)
						{
							mStrKey = r.isStrKey;
						}
						else if (r.isStrKey != mStrKey)
						{
							throw new Exception("Multi key types in one sheet !\n" + string.Join("\n", files.ToArray()));
						}
						if (mStrKey)
						{
							mActiveKeyReaders.Add(r);
						}
						else
						{
							mActiveIdReaders.Add(r);
						}
					}
					catch (System.Exception ex)
					{
						Debug.LogError(ex.ToString());
					}
				}
			}

			public bool isStrKey { get { return mStrKey; } }

			public void Close()
			{
				for (int i = 0, imax = mActiveIdReaders.Count; i < imax; i++)
				{
					mActiveIdReaders[i].Close();
				}
				for (int i = 0, imax = mActiveKeyReaders.Count; i < imax; i++)
				{
					mActiveKeyReaders[i].Close();
				}
				mActiveIdReaders.Clear();
				mActiveKeyReaders.Clear();
			}

			public List<int> GetIds()
			{
				List<int> ret = new List<int>();
				if (!mStrKey)
				{
					ReadAllIdItems();
					ret.AddRange(mIdDatas.Keys);
				}
				return ret;
			}

			public List<string> GetKeys()
			{
				List<string> ret = new List<string>();
				if (mStrKey)
				{
					ReadAllKeyItems();
					ret.AddRange(mKeyDatas.Keys);
				}
				return ret;
			}

            // 根据int型id直接返回数据流，Lua层使用;
            public byte[] GetItemBytes(int id, out string sheetType)
            {
                sheetType = "";
                if (mStrKey) { return null; }

                object obj = null;
                Type type = null;
                List<ItemData> itemDatas = null;
                if (mIdDatas.TryGetValue(id, out itemDatas))
                {
                    for (int i = 0, imax = itemDatas.Count; i < imax; i++)
                    {
                        obj = itemDatas[i].obj;
                        if (obj != null)
                        {
                            type = itemDatas[i].type;
                            break;
                        }
                    }
                }

                while (obj == null && mActiveIdReaders.Count > 0)
                {
                    for (int i = 0, imax = mActiveIdReaders.Count; i < imax; i++)
                    {
                        XmlIdReader r = mActiveIdReaders[i];
                        bool canRead = false;
                        while (canRead = r.MoveNext())
                        {
                            int itemId = r.CurrentIdItem.Key;
                            ItemData itemData;
                            itemData.obj = r.CurrentIdItem.Value;
                            itemData.type = r.type;
                            if (mIdDatas.TryGetValue(itemId, out itemDatas))
                            {
                                itemDatas.Add(itemData);
                            }
                            else
                            {
                                itemDatas = new List<ItemData>();
                                itemDatas.Add(itemData);
                                mIdDatas.Add(itemId, itemDatas);
                            }
                            if (itemId == id)
                            {
                                obj = itemData.obj;
                                type = itemData.type;
                                break;
                            }
                            if (itemId > id) { break; }
                        }
                        if (!canRead) { mCachedInts.Add(i); }
                        if (obj != null) { break; }
                    }
                    for (int i = mCachedInts.Count - 1; i >= 0; i--)
                    {
                        mActiveIdReaders.RemoveAt(mCachedInts[i]);
                    }
                    mCachedInts.Clear();
                }
                if (obj != null && type != null)
                {
                    sheetType = type.ToString();
                    MemoryStream dataStream = new MemoryStream();
                    RuntimeTypeModel.Default.SerializeWithLengthPrefix(dataStream, obj, type, ProtoBuf.PrefixStyle.Fixed32, 0);

                    dataStream.Position = 0;
                    int length = DatabaseStreamReader.ReadInt(dataStream);
                    byte[] bytes = new byte[length];
                    dataStream.Read(bytes, 0, length);
                    dataStream.Close();
                    return bytes;
                }
                return null;
            }

            // 根据string型id直接返回数据流，Lua层使用;
            public byte[] GetItemBytes(string key, out string sheetType)
            {
                sheetType = "";
                if (!mStrKey) { return null; }
                
                object obj = null;
                Type type = null;
                List<ItemData> itemDatas = null;
                if (mKeyDatas.TryGetValue(key, out itemDatas))
                {
                    for (int i = 0, imax = itemDatas.Count; i < imax; i++)
                    {
                        obj = itemDatas[i].obj;
                        if (obj != null)
                        {
                            type = itemDatas[i].type;
                            break;
                        }
                    }
                }

                while (obj == null && mActiveKeyReaders.Count > 0)
                {
                    for (int i = 0, imax = mActiveKeyReaders.Count; i < imax; i++)
                    {
                        XmlIdReader r = mActiveKeyReaders[i];
                        bool canRead = false;
                        while (canRead = r.MoveNext())
                        {
                            string itemKey = r.CurrentKeyItem.Key;
                            ItemData itemData;
                            itemData.obj = r.CurrentKeyItem.Value;
                            itemData.type = r.type;
                            if (mKeyDatas.TryGetValue(itemKey, out itemDatas))
                            {
                                itemDatas.Add(itemData);
                            }
                            else
                            {
                                itemDatas = new List<ItemData>();
                                itemDatas.Add(itemData);
                                mKeyDatas.Add(itemKey, itemDatas);
                            }
                            if (itemKey == key)
                            {
                                obj = itemData.obj;
                                type = itemData.type;
                                break;
                            }
                            if (string.Compare(itemKey, key) > 0) { break; }
                        }
                        if (!canRead) { mCachedInts.Add(i); }
                        if (obj != null) { break; }
                    }
                    for (int i = mCachedInts.Count - 1; i >= 0; i--)
                    {
                        mActiveKeyReaders.RemoveAt(mCachedInts[i]);
                    }
                    mCachedInts.Clear();
                }
                if (obj != null && type != null)
                {
                    sheetType = type.ToString();
                    MemoryStream dataStream = new MemoryStream();
                    RuntimeTypeModel.Default.SerializeWithLengthPrefix(dataStream, obj, type, ProtoBuf.PrefixStyle.Fixed32, 0);

                    dataStream.Position = 0;
                    int length = DatabaseStreamReader.ReadInt(dataStream);
                    byte[] bytes = new byte[length];
                    dataStream.Read(bytes, 0, length);
                    dataStream.Close();
                    return bytes;
                }
                return null;
            }

            public T GetItem<T>(int id)
			{
				if (mStrKey) { return default(T); }
				ReadAllIdItems();
                List<ItemData> itemDatas = null;
                if (mIdDatas.TryGetValue(id, out itemDatas))
				{
					for (int i = 0, imax = itemDatas.Count; i < imax; i++)
					{
						if (itemDatas[i].obj is T) { return (T)itemDatas[i].obj; }
					}
				}
				object obj = null;
				while (obj == null && mActiveIdReaders.Count > 0)
				{
					for (int i = 0, imax = mActiveIdReaders.Count; i < imax; i++)
					{
						XmlIdReader r = mActiveIdReaders[i];
						bool canRead = false;
						while (canRead = r.MoveNext())
						{
							int itemId = r.CurrentIdItem.Key;
                            ItemData itemData;
                            itemData.obj = r.CurrentIdItem.Value;
                            itemData.type = r.type;
                            if (mIdDatas.TryGetValue(itemId, out itemDatas))
                            {
                                itemDatas.Add(itemData);
                            }
                            else
                            {
                                itemDatas = new List<ItemData>();
                                itemDatas.Add(itemData);
                                mIdDatas.Add(itemId, itemDatas);
                            }
                            if (itemId == id && (itemData.obj is T))
                            {
                                obj = itemData.obj;
                                break;
                            }
                            if (itemId > id) { break; }
						}
						if (!canRead) { mCachedInts.Add(i); }
						if (obj != null) { break; }
					}
					for (int i = mCachedInts.Count - 1; i >= 0; i--)
					{
						mActiveIdReaders.RemoveAt(mCachedInts[i]);
					}
					mCachedInts.Clear();
				}
				if (obj != null && (obj is T)) { return (T)obj; }
				return default(T);
			}

			public List<T> GetItems<T>(int id)
			{
				List<T> ret = new List<T>();
				if (mStrKey) { return ret; }
				ReadAllIdItems();
                List<ItemData> itemDatas = null;
                if (mIdDatas.TryGetValue(id, out itemDatas))
				{
					for (int i = 0, imax = itemDatas.Count; i < imax; i++)
					{
						object obj = itemDatas[i].obj;
						if (obj is T) { ret.Add((T)obj); }
					}
				}
				return ret;
			}

			public T GetItem<T>(string key)
			{
				if (!mStrKey) { return default(T); }
				ReadAllKeyItems();
                List<ItemData> itemDatas = null;
                if (mKeyDatas.TryGetValue(key, out itemDatas) && itemDatas.Count > 0)
				{
					for (int i = 0, imax = itemDatas.Count; i < imax; i++)
					{
						if (itemDatas[i].obj is T) { return (T)itemDatas[i].obj; }
					}
				}
				object obj = null;
				while (obj == null && mActiveKeyReaders.Count > 0)
				{
					for (int i = 0, imax = mActiveKeyReaders.Count; i < imax; i++)
					{
						XmlIdReader r = mActiveKeyReaders[i];
						bool canRead = false;
						while (canRead = r.MoveNext())
						{
							string itemKey = r.CurrentKeyItem.Key;
                            ItemData itemData;
                            itemData.obj = r.CurrentKeyItem.Value;
                            itemData.type = r.type;
                            if (mKeyDatas.TryGetValue(itemKey, out itemDatas))
                            {
                                itemDatas.Add(itemData);
                            }
                            else
                            {
                                itemDatas = new List<ItemData>();
                                itemDatas.Add(itemData);
                                mKeyDatas.Add(itemKey, itemDatas);
                            }
                            if (itemKey == key && (itemData.obj is T))
                            {
                                obj = itemData.obj;
                                break;
                            }
                            if (string.Compare(itemKey, key) > 0) { break; }
						}
						if (!canRead) { mCachedInts.Add(i); }
						if (obj != null) { break; }
					}
					for (int i = mCachedInts.Count - 1; i >= 0; i--)
					{
						mActiveKeyReaders.RemoveAt(mCachedInts[i]);
					}
					mCachedInts.Clear();
				}
				if (obj != null && (obj is T)) { return (T)obj; }
				return default(T);
			}

			public List<T> GetItems<T>(string key)
			{
				List<T> ret = new List<T>();
				if (!mStrKey) { return ret; }
				ReadAllKeyItems();
                List<ItemData> itemDatas = null;
                if (mKeyDatas.TryGetValue(key, out itemDatas))
				{
					for (int i = 0, imax = itemDatas.Count; i < imax; i++)
					{
						object obj = itemDatas[i].obj;
						if (obj is T) { ret.Add((T)obj); }
					}
				}
				return ret;
			}

            private void ReadAllIdItems()
            {
                List<ItemData> itemDatas = null;
                for (int i = 0, imax = mActiveIdReaders.Count; i < imax; i++)
                {
                    XmlIdReader r = mActiveIdReaders[i];
                    while (r.MoveNext())
                    {
                        int itemId = r.CurrentIdItem.Key;
                        ItemData itemData;
                        itemData.obj = r.CurrentIdItem.Value;
                        itemData.type = r.type;
                        if (mIdDatas.TryGetValue(itemId, out itemDatas))
                        {
                            itemDatas.Add(itemData);
                        }
                        else
                        {
                            itemDatas = new List<ItemData>();
                            itemDatas.Add(itemData);
                            mIdDatas.Add(itemId, itemDatas);
                        }
                    }
                }
                mActiveIdReaders.Clear();
            }

            private void ReadAllKeyItems()
			{
                List<ItemData> itemDatas = null;
                for (int i = 0, imax = mActiveKeyReaders.Count; i < imax; i++)
				{
					XmlIdReader r = mActiveKeyReaders[i];
					while (r.MoveNext())
					{
						string itemKey = r.CurrentKeyItem.Key;
                        ItemData itemData;
                        itemData.obj = r.CurrentKeyItem.Value;
                        itemData.type = r.type;
						if (mKeyDatas.TryGetValue(itemKey, out itemDatas))
						{
                            itemDatas.Add(itemData);
						}
						else
						{
                            itemDatas = new List<ItemData>();
                            itemDatas.Add(itemData);
							mKeyDatas.Add(itemKey, itemDatas);
						}
					}
				}
				mActiveKeyReaders.Clear();
			}

			private class XmlIdReader
			{

				private StreamReader mFile;
				private System.Xml.XmlReader mReader;
				private System.Reflection.PropertyInfo mPropId;
				private bool mStrKey;
				private System.Xml.Serialization.XmlSerializer mXS;
				private KeyValuePair<int, object> mCurrentIdItem;
				private KeyValuePair<string, object> mCurrentKeyItem;
                private string mPath = string.Empty;
                private Type mType;

                public XmlIdReader(string path, Type itemType)
				{
                    mPath = path;
                    mType = itemType;
                    mFile = File.OpenText(path);
					mReader = System.Xml.XmlReader.Create(mFile);
                    mXS = new System.Xml.Serialization.XmlSerializer(itemType);
					System.Reflection.PropertyInfo[] props = itemType.GetProperties(
						System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
					System.Reflection.PropertyInfo propId = null;
					Type protoMember = typeof(ProtoBuf.ProtoMemberAttribute);
					for (int j = 0, jmax = props.Length; j < jmax; j++)
					{
						System.Reflection.PropertyInfo prop = props[j];
						ProtoBuf.ProtoMemberAttribute attr = Attribute.GetCustomAttribute(prop, protoMember) as ProtoBuf.ProtoMemberAttribute;
						if (attr == null || attr.Tag != 1) { continue; }
						propId = prop;
						break;
					}
					if (propId == null)
					{
						throw new Exception("'ProtoMember 1' is required as Id or Key property !");
					}
					mPropId = propId;
					mStrKey = mPropId.PropertyType.Equals(typeof(string));
				}

				~XmlIdReader()
				{
					if (mReader != null) { mReader.Close(); }
					if (mFile != null) { mFile.Close(); }
                    mPath = string.Empty;
                }

				public bool isStrKey { get { return mStrKey; } }

                public Type type { get { return mType; } }

                public void Close()
				{
					if (mReader != null) { mReader.Close(); }
					if (mFile != null) { mFile.Close(); }
					mReader = null;
					mFile = null;
                    mPath = string.Empty;
                }

				public bool MoveNext()
				{
					if (mReader == null) { return false; }
					while (mReader.Read())
					{
                        if (mReader.Depth < 1 || mReader.NodeType != System.Xml.XmlNodeType.Element)
                        {
                            continue;
                        }
                        if (mStrKey)
						{
                            try
                            {
                                object obj = mXS.Deserialize(mReader);
                                string key = (string)mPropId.GetValue(obj, null);
                                mCurrentKeyItem = new KeyValuePair<string, object>(key, obj);
                            }
                            catch (System.Exception e)
                            {
                                string err = mPath + " (" + mType + ") : Failed to parse \"" + mReader.Name + "\"";
                                System.Xml.XmlTextReader xr = mReader as System.Xml.XmlTextReader;
                                if (xr != null)
                                {
                                    err += "  [" + xr.LineNumber + " row, " + xr.LinePosition + " column]";
                                }
                                UnityEngine.Debug.LogError(err + "\n" + e.ToString());
                                return false;
                            }
                        }
						else
						{
                            object obj;
                            try
							{
                                obj = mXS.Deserialize(mReader);
                            }
							catch (System.Exception e)
                            {
                                string err = mPath + " ("+mType + ") : Failed to parse \"" + mReader.Name + "\"";
                                System.Xml.XmlTextReader xr = mReader as System.Xml.XmlTextReader;
                                if (xr != null)
                                {
                                    err += "  [" + xr.LineNumber + " row, " + xr.LinePosition + " column]";
                                }
                                UnityEngine.Debug.LogError(err + "\n" + e.ToString());
                                return false;
							}
                            int id = (int)mPropId.GetValue(obj, null);
                            mCurrentIdItem = new KeyValuePair<int, object>(id, obj);
                        }
                        return true;
					}
                    Close();
                    return false;
				}

				public KeyValuePair<int, object> CurrentIdItem
				{
					get
					{
						if (mStrKey) { throw new Exception("Invalid key type ! 'string' key is used !"); }
						return mCurrentIdItem;
					}
				}

				public KeyValuePair<string, object> CurrentKeyItem
				{
					get
					{
						if (!mStrKey) { throw new Exception("Invalid key type ! 'int' key is used !"); }
						return mCurrentKeyItem;
					}
				}
            }
		}
	}
}

#endif