
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：SheetDatabase.cs;
	作	者：jiabin;
	时	间：2016 - 03 - 29;
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
	/// 用于解析、读取所有sheet及其中的条目
	/// </summary>
	public sealed class SheetDatabase
	{

		private static SheetDatabase singleton_instance = null;

		public static SheetDatabase Instance
		{
			get
			{
				if (singleton_instance == null)
				{
					singleton_instance = new SheetDatabase();
				}
				return singleton_instance;
			}
		}

		private Dictionary<string, string[]> mGroupSheets = new Dictionary<string, string[]>();
		private Dictionary<string, IdSheetData> mIdSheets = new Dictionary<string, IdSheetData>();
		private Dictionary<string, KeySheetData> mKeySheets = new Dictionary<string, KeySheetData>();

		private List<int> mCachedOffsets = new List<int>();

        public void Reset()
        {

            mGroupSheets.Clear();
            mIdSheets.Clear();
            mKeySheets.Clear();
            mCachedOffsets.Clear();
        }
        private SheetDatabase() { }

		/// <summary>
		/// 将一个组中所有的sheet加到数据库中
		/// </summary>
		/// <param name="stream">该组的数据流</param>
		/// <returns>组名称，若添加失败或该组已存在，则返回null</returns>
		public string AddToDatabase(Stream stream)
		{
			return AddToDatabase(stream, null);
		}

		/// <summary>
		/// 将一个组中所有的sheet加到数据库中
		/// </summary>
		/// <param name="stream">该组的数据流</param>
		/// <param name="addedSheets">从组中加到数据库中的所有sheet名称</param>
		/// <returns>组名称，若添加失败或该组已存在，则返回null</returns>
		public string AddToDatabase(Stream stream, IList<string> addedSheets)
		{
			stream.Position = 0L;
			byte[] buffer = new byte[1024];
			ushort groupKeyLen = DatabaseStreamReader.ReadUShort(stream);
			stream.Read(buffer, 0, groupKeyLen);
			string groupKey = Encoding.UTF8.GetString(buffer, 0, groupKeyLen);
			if (mGroupSheets.ContainsKey(groupKey)) { return null; }

			ushort sheetCount = DatabaseStreamReader.ReadUShort(stream);

			int[] sheetOffsets = new int[sheetCount];
			for (ushort i = 0; i < sheetCount; i++)
			{
				sheetOffsets[i] = DatabaseStreamReader.ReadInt(stream);
			}
			string[] sheets = new string[sheetCount];
			GroupTypeFinder typeFinder = new GroupTypeFinder("Assembly-CSharp", groupKey);
			for (ushort i = 0; i < sheetCount; i++)
			{
				stream.Position = sheetOffsets[i];
				ushort nameLen = DatabaseStreamReader.ReadUShort(stream);
				stream.Read(buffer, 0, nameLen);
				string sheetName = Encoding.UTF8.GetString(buffer, 0, nameLen);

				uint sheetItemCount = DatabaseStreamReader.ReadUInt(stream);
				//UnityEngine.Debug.LogError("sheet name : " + sheetName + "   item count : " + sheetItemCount);
				bool strKey = (sheetItemCount & 0x80000000) != 0u;
				sheetItemCount = sheetItemCount & 0x7fffffff;

				//UnityEngine.Debug.LogError("sheet item count : " + sheetItemCount);
				//UnityEngine.Debug.LogError("str key ? " + strKey);

				bool existed = mKeySheets.ContainsKey(sheetName) || mIdSheets.ContainsKey(sheetName);
				if (strKey)
				{
					string[] keys = new string[sheetItemCount];
					int[] offsets = new int[sheetItemCount];
					for (int j = 0; j < sheetItemCount; j++)
					{
						int keyLen = stream.ReadByte();
						//UnityEngine.Debug.Log(keyLen);
						stream.Read(buffer, 0, keyLen);
						keys[j] = Encoding.UTF8.GetString(buffer, 0, keyLen);
						offsets[j] = DatabaseStreamReader.ReadInt(stream);
						//UnityEngine.Debug.LogWarning(string.Format("key : {0}    offset : {1}", keys[j], offsets[j]));
					}
					if (!existed)
					{
						KeySheetData sheet = new KeySheetData(stream, typeFinder, (int)sheetItemCount, keys, offsets);
						mKeySheets.Add(sheetName, sheet);
					}
				}
				else
				{
					uint[] ids = new uint[sheetItemCount];
					int[] offsets = new int[sheetItemCount];
					for (int j = 0; j < sheetItemCount; j++)
					{
						ids[j] = (uint)DatabaseStreamReader.ReadInt(stream);
						offsets[j] = DatabaseStreamReader.ReadInt(stream);
						//UnityEngine.Debug.LogWarning(string.Format("id : {0}    offset : {1}", ids[j], offsets[j]));
					}
					if (!existed)
					{
						IdSheetData sheet = new IdSheetData(stream, typeFinder, (int)sheetItemCount, ids, offsets);
						mIdSheets.Add(sheetName, sheet);
					}
				}
				if (existed)
				{
					Debug.LogError(string.Format("Sheet '{0}' is already existed !", sheetName));
				}
				else
				{
					sheets[i] = sheetName;
					if (addedSheets != null) { addedSheets.Add(sheetName); }
					//Debug.Log("sheet : " + sheetName);
				}
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
			mGroupSheets.Add(groupKey, sheets);
			return groupKey;
		}

        public void RemoveBlockFormDatabase(string groupKey, string block_name)
        {
            string[] sheets;
            if (mGroupSheets.TryGetValue(groupKey, out sheets))
            {
                for (int i = 0, imax = sheets.Length; i < imax; i++)
                {
                    if (string.IsNullOrEmpty(sheets[i])) { continue; }
                    if(sheets[i] == block_name)
                    {
                        Stream s = null;
                        IdSheetData idData;
                        if (mIdSheets.TryGetValue(sheets[i], out idData))
                        {
                            s = idData.stream;
                            mIdSheets.Remove(sheets[i]);
                        }
                        KeySheetData keyData;
                        if (mKeySheets.TryGetValue(sheets[i], out keyData))
                        {
                            s = keyData.stream;
                            mKeySheets.Remove(sheets[i]);
                        }
                       
                        mKeySheets.Remove(sheets[i]);
                    }
                }
            }
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
                   // Debug.LogError("Remove:"+sheet);
					if (string.IsNullOrEmpty(sheet)) { continue; }

					Stream s = null;
					IdSheetData idData;
					if (mIdSheets.TryGetValue(sheet, out idData))
					{
						s = idData.stream;
						mIdSheets.Remove(sheet);
					}
					KeySheetData keyData;
					if (mKeySheets.TryGetValue(sheet, out keyData))
					{
						s = keyData.stream;
						mKeySheets.Remove(sheet);
					}
					if (stream == null)
					{
						stream = s;
					}
					else if (stream != s)
					{
						Debug.LogError(string.Format("Multi group files contains the same group key '{0}' !", groupKey));
					}
					mKeySheets.Remove(sheet);
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
            IdSheetData data;
            if (mIdSheets.TryGetValue(sheetName, out data))
            {
                mCachedOffsets.Clear();
                if (data.GetItemOffsets(id, mCachedOffsets))
                {
                    Stream s = data.stream;
                    if(mCachedOffsets.Count > 0)
                    {
                        s.Position = (long)mCachedOffsets[0];
                        ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
                        sheetType = data.typeFinder.GetTypeName(typeIndex);
                        int length = DatabaseStreamReader.ReadInt(s);
                        byte[] bytes = new byte[length];
                        s.Read(bytes, 0, length);
                        return bytes;
                    }
                }
            }
            return null;
        }
        public byte[] GetSheetBytes(string sheetName, uint id, out string sheetType)
        {
            sheetType = "";
            IdSheetData data;
            if (mIdSheets.TryGetValue(sheetName, out data))
            {
                mCachedOffsets.Clear();
                if (data.GetItemOffsets(id, mCachedOffsets))
                {
                    Stream s = data.stream;
                    if (mCachedOffsets.Count > 0)
                    {
                        s.Position = (long)mCachedOffsets[0];
                        ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
                        sheetType = data.typeFinder.GetTypeName(typeIndex);
                        int length = DatabaseStreamReader.ReadInt(s);
                        byte[] bytes = new byte[length];
                        s.Read(bytes, 0, length);
                        return bytes;
                    }
                }
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
            KeySheetData data;
            if (mKeySheets.TryGetValue(sheetName, out data))
            {
                mCachedOffsets.Clear();
                if (data.GetItemOffsets(key, mCachedOffsets))
                {
                    Stream s = data.stream;
                    if (mCachedOffsets.Count > 0)
                    {
                        s.Position = (long)mCachedOffsets[0];
                        ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
                        sheetType = data.typeFinder.GetTypeName(typeIndex);
                        int length = DatabaseStreamReader.ReadInt(s);
                        byte[] bytes = new byte[length];
                        s.Read(bytes, 0, length);
                        return bytes;
                    }
                }
            }
            return null;
        }

        #endregion
        public T GetSheetItem<T>(string sheetName, uint id)
        {
            IdSheetData data;
            if (mIdSheets.TryGetValue(sheetName, out data))
            {
                mCachedOffsets.Clear();
                if (data.GetItemOffsets(id, mCachedOffsets))
                {
                    Type t = typeof(T);
                    Stream s = data.stream;
                    for (int i = 0, imax = mCachedOffsets.Count; i < imax; i++)
                    {
                        s.Position = (long)mCachedOffsets[i];
                        ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
                        Type type = data.typeFinder.GetType(typeIndex);
                        if (type == null)
                        {
                            return Serializer.DeserializeWithLengthPrefix<T>(s, PrefixStyle.Fixed32);
                        }
                        if (t == type || type.IsSubclassOf(t))
                        {
                            return (T)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(s, null, type, PrefixStyle.Fixed32, 0);
                        }
                    }
                }
            }
            return default(T);
        }
        /// <summary>
        /// 在指定的sheet中读取id对应条目
        /// </summary>
        /// <typeparam name="T">条目的类型或该类型的基类</typeparam>
        /// <param name="sheetName">指定的sheet名称</param>
        /// <param name="id">要获取的条目的id</param>
        /// <returns>id对应的条目</returns>
        public T GetSheetItem<T>(string sheetName, int id)
		{
			IdSheetData data;
			if (mIdSheets.TryGetValue(sheetName, out data))
			{
				mCachedOffsets.Clear();
				if (data.GetItemOffsets(id, mCachedOffsets))
				{
					Type t = typeof(T);
					Stream s = data.stream;
					for (int i = 0, imax = mCachedOffsets.Count; i < imax; i++)
					{
						s.Position = (long)mCachedOffsets[i];
						ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
						Type type = data.typeFinder.GetType(typeIndex);
						if (type == null)
						{
							return Serializer.DeserializeWithLengthPrefix<T>(s, PrefixStyle.Fixed32);
						}
						if (t == type || type.IsSubclassOf(t))
						{
							return (T)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(s, null, type, PrefixStyle.Fixed32, 0);
						}
					}
				}
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
			IdSheetData data;
			if (mIdSheets.TryGetValue(sheetName, out data))
			{
				mCachedOffsets.Clear();
				if (data.GetItemOffsets(id, mCachedOffsets))
				{
					Type t = typeof(T);
					Stream s = data.stream;
					for (int i = 0, imax = mCachedOffsets.Count; i < imax; i++)
					{
						s.Position = (long)mCachedOffsets[i];
						ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
						Type type = data.typeFinder.GetType(typeIndex);
						if (type == null)
						{
							items.Add(Serializer.DeserializeWithLengthPrefix<T>(s, PrefixStyle.Fixed32));
						}
						if (t == type || type.IsSubclassOf(t))
						{
							items.Add((T)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(s, null, type, PrefixStyle.Fixed32, 0));
						}
					}
				}
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
			KeySheetData data;
			if (mKeySheets.TryGetValue(sheetName, out data))
			{
				mCachedOffsets.Clear();
				if (data.GetItemOffsets(key, mCachedOffsets))
				{
					Type t = typeof(T);
					Stream s = data.stream;
					for (int i = 0, imax = mCachedOffsets.Count; i < imax; i++)
					{
						s.Position = (long)mCachedOffsets[i];
						ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
						Type type = data.typeFinder.GetType(typeIndex);
						if (type == null)
						{
							return Serializer.DeserializeWithLengthPrefix<T>(s, PrefixStyle.Fixed32);
						}
						if (t == type || type.IsSubclassOf(t))
						{
							return (T)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(s, null, type, PrefixStyle.Fixed32, 0);
						}
					}
				}
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
			KeySheetData data;
			if (mKeySheets.TryGetValue(sheetName, out data))
			{
				mCachedOffsets.Clear();
				if (data.GetItemOffsets(key, mCachedOffsets))
				{
					Type t = typeof(T);
					Stream s = data.stream;
					for (int i = 0, imax = mCachedOffsets.Count; i < imax; i++)
					{
						s.Position = (long)mCachedOffsets[i];
						ushort typeIndex = DatabaseStreamReader.ReadUShort(s);
						Type type = data.typeFinder.GetType(typeIndex);
						if (type == null)
						{
							items.Add(Serializer.DeserializeWithLengthPrefix<T>(s, PrefixStyle.Fixed32));
						}
						if (t == type || type.IsSubclassOf(t))
						{
							items.Add((T)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(s, null, type, PrefixStyle.Fixed32, 0));
						}
					}
				}
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
			sheets.AddRange(mIdSheets.Keys);
			sheets.AddRange(mKeySheets.Keys);
		}

		/// <summary>
		/// 获取指定sheet中所有条目的id（采用迭代器方式，保证数据安全并减少内存开销）
		/// </summary>
		/// <param name="sheetName">指定的sheet名称</param>
		/// <returns>该sheet中所有id的迭代器</returns>
		public IEnumerator<uint> GetSheetItemIds(string sheetName)
		{
			IdSheetData data;
			if (!mIdSheets.TryGetValue(sheetName, out data))
			{
				yield break;
			}
			uint[] ids = data.GetItemIds();
			for (int i = 0, imax = ids.Length; i < imax; i++)
			{
				yield return ids[i];
			}
		}

		/// <summary>
		/// 获取指定sheet中所有条目的键（采用迭代器方式，保证数据安全并减少内存开销）
		/// </summary>
		/// <param name="sheetName">指定的sheet名称</param>
		/// <returns>该sheet中所有键的迭代器</returns>
		public IEnumerator<string> GetSheetItemKeys(string sheetName)
		{
			KeySheetData data;
			if (!mKeySheets.TryGetValue(sheetName, out data))
			{
				yield break;
			}
			string[] keys = data.GetItemKeys();
			for (int i = 0, imax = keys.Length; i < imax; i++)
			{
				yield return keys[i];
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

            // 某些sheet类型是lua层进行解析的，所以c#层没有此sheet类的定义，此时也不需要获取Type进行反序列化，只需对应的类型名称即可;
            public string GetTypeName(ushort index)
            {
                if (index >= mTypeNames.Length)
                {
                    return "";
                }
                return mTypeNames[index];
            }

        }

		private sealed class KeySheetData
		{

			public readonly Stream stream;
			public readonly GroupTypeFinder typeFinder;
			private int mItemCount;
			private string[] mKeys;
			private int[] mOffsets;

			public KeySheetData(Stream stream, GroupTypeFinder typeFinder, int itemCount, string[] keys, int[] offsets)
			{
				this.stream = stream;
				this.typeFinder = typeFinder;
				mItemCount = itemCount;
				mKeys = keys;
				mOffsets = offsets;
			}

			public bool GetItemOffset(string key, out int offset)
			{
				int min = 0;
				int max = mItemCount;
				while (min < max)
				{
					int index = (min + max) >> 1;
					string curKey = mKeys[index];
					int cmp = string.Compare(key, curKey);
					if (cmp == 0)
					{
						offset = mOffsets[index];
						return true;
					}
					if (cmp < 0)
					{
						max = index;
					}
					else
					{
						min = index + 1;
					}
				}
				offset = 0;
				return false;
			}

			public bool GetItemOffsets(string key, List<int> offsets)
			{
				int min = 0;
				int len = mKeys.Length;
				int max = len;
				int index = -1;
				while (min < max)
				{
					int i = (min + max) >> 1;
					string curKey = mKeys[i];
					int cmp = string.Compare(key, curKey);
					if (cmp == 0)
					{
						index = i;
						break;
					}
					if (cmp < 0)
					{
						max = i;
					}
					else
					{
						min = i + 1;
					}
				}
				if (index < 0) { return false; }
				int l = index;
				while (l - 1 >= 0 && mKeys[l - 1] == key) { l--; }
				int r = index;
				while (r + 1 < len && mKeys[r + 1] == key) { r++; }
				for (int i = l; i <= r; i++)
				{
					offsets.Add(mOffsets[i]);
				}
				return true;
			}

			public string[] GetItemKeys() { return mKeys; }

		}

		private sealed class IdSheetData
		{

			public readonly Stream stream;
			public readonly GroupTypeFinder typeFinder;
			//private int mItemCount;
			private uint[] mIds;
			private int[] mOffsets;

			public IdSheetData(Stream stream, GroupTypeFinder typeFinder, int itemCount, uint[] ids, int[] offsets)
			{
				this.stream = stream;
				this.typeFinder = typeFinder;
				//mItemCount = itemCount;
				mIds = ids;
				mOffsets = offsets;
			}

			/*public bool GetItemOffset(int id, out int offset)
			{
				int min = 0;
				int max = mItemCount;
				while (min < max)
				{
					int index = (min + max) >> 1;
					int curId = mIds[index];
					if (curId == id)
					{
						offset = mOffsets[index];
						return true;
					}
					if (id < curId)
					{
						max = index;
					}
					else
					{
						min = index + 1;
					}
				}
				offset = 0;
				return false;
			}*/

			public bool GetItemOffsets(uint id, List<int> offsets)
			{
				int min = 0;
				int len = mIds.Length;
				int max = len;
				int index = -1;
				while (min < max)
				{
					int i = (min + max) >> 1;
					uint curId = mIds[i];
					if (curId == id)
					{
						index = i;
						break;
					}
					if (id < curId)
					{
						max = i;
					}
					else
					{
						min = i + 1;
					}
				}
				if (index < 0) { return false; }
				int l = index;
				while (l - 1 >= 0 && mIds[l - 1] == id) { l--; }
				int r = index;
				while (r + 1 < len && mIds[r + 1] == id) { r++; }
				for (int i = l; i <= r; i++)
				{
					offsets.Add(mOffsets[i]);
				}
				return true;
			}
            public bool GetItemOffsets(int id, List<int> offsets)
            {
                int min = 0;
                int len = mIds.Length;
                int max = len;
                int index = -1;
                while (min < max)
                {
                    int i = (min + max) >> 1;
                    int curId = (int)mIds[i];
                    if (curId == id)
                    {
                        index = i;
                        break;
                    }
                    if (id < curId)
                    {
                        max = i;
                    }
                    else
                    {
                        min = i + 1;
                    }
                }
                if (index < 0) { return false; }
                int l = index;
                while (l - 1 >= 0 && mIds[l - 1] == id) { l--; }
                int r = index;
                while (r + 1 < len && mIds[r + 1] == id) { r++; }
                for (int i = l; i <= r; i++)
                {
                    offsets.Add(mOffsets[i]);
                }
                return true;
            }

            public uint[] GetItemIds() { return mIds; }

		}
	}
}
