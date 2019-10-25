/**************************************************************************************************
	Copyright (C) 2017 - All Rights Reserved.
---------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：UIConfigManager.cs;
	作	者：jiabin;
	时	间：2017 - 04 - 10;
	注	释：配置管理模块;
**************************************************************************************************/

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using FunPlus.Common.Config;
using UnityEngine;
using XmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace FunPlus.Common.GameConfig
{
    public class GameConfigManager : MonoBehaviour
    {
        private const string TplSheetNameInt = "sheet_name_default_key_int";
        private const string TplSheetNameString = "sheet_name_{0}_key_string";
        private const string MsgCodeSheetNameString = "sheet_name_message_code";

        //public bool useOldPath = false;
        protected List<string> xmlList = new List<string> { "xml_group.dat"};
        //protected List<string> xmlLevelList = new List<string> { "xml_level.dat" };
        protected List<string> xmlSheetList = new List<string> { "xmlsheet_group.dat" };

        void Awake()
        {
            Init();
        }

        void Init()
        {
            RegisterToDatabase();
        }

        void OnDestroy()
        {
            UnRegisterData();
        }

		/// <summary>
		/// 获取配置路径
		/// </summary>
		/// <returns>The conf path.</returns>
		/// <param name="name">Name.</param>
        string GetConfPath(string name)
        {
            string path = "";
            switch (ResourcesSetting.TempLoaderType)
            {
                case ELoaderType.LoaderType_Local:
                    path = string.Format("{0}/../{1}/{2}", Application.dataPath, ResourcesSetting.ConfFolder, name);
                    break;
                case ELoaderType.LoaderType_AssetBundle:
                    path = string.Format("{0}{1}/{2}", ResourcesPath.localBundlePath, ResourcesSetting.BundleConfFolder, name);
                    break;
            }
            return path;
        }

        /// <summary>
        /// 注册配置group;
        /// </summary>
        /// <returns></returns>
        void RegisterToDatabase()
        {
            mGroups.Clear();
            XmlDatabase.Instance.Reset();
            SheetDatabase.Instance.Reset();
            RegisterToDatabaseFromDat();
        }

        void UnRegisterData()
        {
            UnRegisterFromDatabase();
        }

        #region Lua Methods

        private byte[] GetXMLBytes(string xmlName, out string xmlType)
        {
            return XmlDatabase.Instance.GetXMLBytes(xmlName, out xmlType);
        }

        private byte[] GetSheetBytes(string sheetName, uint sheetId, out string sheetType)
        {
            return SheetDatabase.Instance.GetSheetBytes(sheetName, sheetId, out sheetType);
        }
        private byte[] GetSheetBytes(string sheetName, int sheetId, out string sheetType)
        {
            return SheetDatabase.Instance.GetSheetBytes(sheetName, sheetId, out sheetType);
        }
        private byte[] GetSheetBytes(string sheetName, string sheetKey, out string sheetType)
        {
            //Debug.LogError(sheetName);
            return SheetDatabase.Instance.GetSheetBytes(sheetName, sheetKey, out sheetType);
        }

        #endregion

        #region Group

        private enum GameConfigType
        {
            GameConfig_Xml = 0,
            GameConfig_XmlSheet = 1
        }

        private class GameConfigTypeStreamData
        {
            private GameConfigType mGameConfigType;
            private FileStream mFileStream;

            public GameConfigTypeStreamData(GameConfigType type, FileStream fs)
            {
                this.mGameConfigType = type;
                this.mFileStream = fs;
            }

            public GameConfigType GetGameConfigType()
            {
                return mGameConfigType;
            }

            public FileStream GetFileStream()
            {
                return mFileStream;
            }
        }

        private Dictionary<string, GameConfigTypeStreamData> mGroups = new Dictionary<string, GameConfigTypeStreamData>(); // 缓存信息，清除时使用;

        /// <summary>
        /// 通过groupName释放流;
        /// </summary>
        /// <param name="groupName">group名称</param>
        private void UnRegisterFromDatabaseByGroupName(string groupName)
        {
            GameConfigTypeStreamData data = null;
            if (!mGroups.TryGetValue(groupName, out data))
            {
                return;
            }
            Stream fs = null;
            switch (data.GetGameConfigType())
            {
                case GameConfigType.GameConfig_Xml:
                    fs = XmlDatabase.Instance.RemoveFromDatabase(groupName);
                    break;
                case GameConfigType.GameConfig_XmlSheet:
                    fs = SheetDatabase.Instance.RemoveFromDatabase(groupName);
                    break;
            }
            if (fs != null)
            {
                fs.Close();
            }
            mGroups.Remove(groupName);
        }

        public void RestSheetDataByBlockName(string block_name)
        {
            string t_groupName = "";
            List<string> keys = new List<string>(mGroups.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                if(keys[i].Contains(xmlSheetList[0]))
                {
                    t_groupName = keys[i];
                    break;
                }
            }
            if (string.IsNullOrEmpty(block_name) && string.IsNullOrEmpty(t_groupName))
            {
                SheetDatabase.Instance.RemoveBlockFormDatabase(t_groupName, block_name);
            }
                
        }

        // 从.dat文件中读取配置数据;
        private void RegisterToDatabaseFromDat()
        {
            GameConfigTypeStreamData data = null;
            if (xmlList != null && xmlList.Count > 0)
            {
                for (int i = 0; i < xmlList.Count; i++)
                {
                    string path = GetConfPath(xmlList[i]);

                    FileStream fs = File.OpenRead(path);
                    data = new GameConfigTypeStreamData(GameConfigType.GameConfig_Xml, fs);
                    string temp = XmlDatabase.Instance.AddToDatabase(fs);
                   // Debug.LogError("xml temp:"+temp);
                    if (!mGroups.ContainsKey(temp))
                    {
                        mGroups.Add(temp, data);
                    }
                    else
                    {
                        Debug.LogError("fail to add same path >>" + temp);
                    }
                }
            }

            if (xmlSheetList != null && xmlSheetList.Count > 0)
            {
                for (int i = 0; i < xmlSheetList.Count; i++)
                {
                    string path = GetConfPath(xmlSheetList[i]);
                    FileStream fs = File.OpenRead(path);
                    data = new GameConfigTypeStreamData(GameConfigType.GameConfig_XmlSheet, fs);
                    string temp = SheetDatabase.Instance.AddToDatabase(fs);
                  // Debug.LogError("sheet temp:" + temp);
                    if (!mGroups.ContainsKey(temp))
                    {
                        mGroups.Add(temp, data);
                    }
                    else
                    {
                        Debug.LogError("fail to add same path >>" + temp);
                    }
                }
            }
        }

        /// <summary>
        /// 释放所有注册的group,关闭流;
        /// </summary>
        /// <returns></returns>
        private void UnRegisterFromDatabase()
        {
            if (mGroups.Keys.Count == 0)
            {
                return;
            }
            List<string> keys = new List<string>(mGroups.Keys);
            GameConfigTypeStreamData data = null;
            for (int i = 0, imax = keys.Count; i < imax; i++)
            {
                data = null;
                if (!mGroups.TryGetValue(keys[i], out data))
                {
                    continue;
                }
                Stream fs = null;
                switch (data.GetGameConfigType())
                {
                    case GameConfigType.GameConfig_Xml:
                        fs = XmlDatabase.Instance.RemoveFromDatabase(keys[i]);
                        break;
                    case GameConfigType.GameConfig_XmlSheet:
                        fs = SheetDatabase.Instance.RemoveFromDatabase(keys[i]);
                        break;
                }
                if (fs != null)
                {
                    fs.Close();
                }
                mGroups.Remove(keys[i]);
            }
        }

        #endregion

        #region XML

        private Dictionary<string, System.Object> mCachedXmlObjects = new Dictionary<string, System.Object>();

        public T GetXmlByName<T>(string xmlName) where T : class
        {
            System.Object result = null;
            if (mCachedXmlObjects.TryGetValue(xmlName, out result))
            {
                return result as T;
            }

            result = XmlDatabase.Instance.Get<T>(xmlName);
            if (result == null)
            {
                return null;
            }
            mCachedXmlObjects.Add(xmlName, result);
            return result as T;
        }

        public T GetXmlByStringText<T>(string text) where T : class
        {
            XmlSerializer x = new XmlSerializer(typeof(T));
            StringReader r = new StringReader(text);
            T ret = x.Deserialize(r) as T;
            r.Close();
            return ret;
        }

        #endregion

        #region XMLSheet

        private Dictionary<uint, System.Object>    mCachedISheets      = new Dictionary<uint, System.Object>();
        private Dictionary<string, System.Object> mCachedSSheets      = new Dictionary<string, System.Object>();
        private Dictionary<int, System.Object>    mCachedMessageCodes = new Dictionary<int, System.Object>();

        /// <summary>
        /// 通过id获取Sheet;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetISheetById<T>(uint id) where T : class
        {
            System.Object result = null;
            if (mCachedISheets.TryGetValue(id, out result))
            {
                return result as T;
            }

            result = SheetDatabase.Instance.GetSheetItem<T>(TplSheetNameInt, id);
            if (result == null)
            {
#if UNITY_EDITOR
                Debug.LogError("Miss id : " + id + "  " + typeof(T));
#endif
                return null;
            }
            mCachedISheets.Add(id, result);

            return result as T;
        }

        public T GetISheetById<T>(int id) where T : class
        {
            uint t_id = (uint)id;
            System.Object result = null;
            if (mCachedISheets.TryGetValue(t_id, out result))
            {
                return result as T;
            }

            result = SheetDatabase.Instance.GetSheetItem<T>(TplSheetNameInt, t_id);
            if (result == null)
            {
#if UNITY_EDITOR
                Debug.LogError("Miss id : " + t_id + "  " + typeof(T));
#endif
                return null;
            }
            mCachedISheets.Add(t_id, result);

            return result as T;
        }

        /// <summary>
        /// 通过id获取Sheet;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public T GetSSheetById<T>(string id) where T : class
        {
            System.Object result = null;
            if (mCachedSSheets.TryGetValue(id, out result))
            {
                return result as T;
            }

            result = SheetDatabase.Instance.GetSheetItem<T>(string.Format(TplSheetNameString, ELanguage.Chinese.ToString()), id);

            if (result == null)
            {
#if UNITY_EDITOR
                Debug.LogWarning("Miss id : " + id + "  " + typeof(T));
#endif
                return null;
            }
            mCachedSSheets.Add(id, result);

            return result as T;
        }

        
        public T GetKSheetById<T>(string id) where T : class
        {
            System.Object result = null;
            if (mCachedSSheets.TryGetValue(id, out result))
            {
                return result as T;
            }

            result = SheetDatabase.Instance.GetSheetItems<T>(string.Format(TplSheetNameString, ELanguage.Chinese.ToString()), id);

            if (result == null)
            {
#if UNITY_EDITOR
                Debug.LogWarning("Miss id : " + id + "  " + typeof(T));
#endif
                return null;
            }
            mCachedSSheets.Add(id, result);

            return result as T;
        }

        // 通过id获取消息码Sheet;
        
        public T GetMessageCodeById<T>(int code) where T : class
        {
            System.Object result = null;
            if (mCachedMessageCodes.TryGetValue(code, out result))
            {
                return result as T;
            }
				
            result = SheetDatabase.Instance.GetSheetItem<T>(MsgCodeSheetNameString, code);
            if (result == null)
            {
#if UNITY_EDITOR
                Debug.LogError("Miss MessageCode : " + code + "  " + typeof(T));
#endif
                return null;
            }
            mCachedMessageCodes.Add(code, result);

            return result as T;
        }

#endregion

    }

}
