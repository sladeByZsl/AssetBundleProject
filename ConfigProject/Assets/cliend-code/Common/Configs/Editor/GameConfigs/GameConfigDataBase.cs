/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：GameConfigDataBase.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 28;
	注	释：存储所有序列化xml配置的数据;
**************************************************************************************************/

using UnityEngine;
using UnityEditor;
using System;
using XSerializer = System.Xml.Serialization.XmlSerializer;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
namespace FunPlus.Common.GameConfig
{

	public enum DataType
	{
		XML = 1,
		XML_SHEET = 2,
        XML_LEVEL = 3,
	}

	public class GameConfigDataBase
	{
		private const string GameConfigPath = "config/all_config.xml";
		private GameConfig mGameConfig;

		private GameConfigGroups mGameXmlGroups;
		private GameConfigGroups mGameXmlSheetGroups;
        private GameConfigGroups mGameLevelGroups;

		private static GameConfigDataBase mInstance = null;

		private GameConfigDataBase()
		{
			//LoadConfig();
		}

		private void LoadConfig()
		{
            mGameConfig = GetConfigInfo<GameConfig>(GameConfigPath);
			
			string xmlPath = mGameConfig.gameConfigData.xmlPath;
			string xmlSheetPath = mGameConfig.gameConfigData.xmlSheetPath;
            string xmlLevelPath = mGameConfig.gameConfigData.xmlLevelPath;
			mGameXmlGroups = GetConfigInfo<GameConfigGroups>(xmlPath);
			mGameXmlSheetGroups = GetConfigInfo<GameConfigGroups>(xmlSheetPath);
            //mGameLevelGroups = GetConfigInfo<GameConfigGroups>(xmlLevelPath);
			//Debug.Log("config has loaded");
		}

		public static GameConfigDataBase GetInstance()
		{
			if (mInstance == null)
			{
				mInstance = new GameConfigDataBase();
			}
			return mInstance;
		}

		/// <summary>
		/// 获取指定路径的内容并返回指定的类
		/// </summary>
		/// <returns>The config info.</returns>
		/// <param name="path">Path.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		private static T GetConfigInfo<T>(string path)
		{
            path = string.Format("{0}/../conf/{1}", Application.dataPath, path);

            T res = default(T);
			XSerializer x = new XSerializer(typeof(T));
			StreamReader reader = null;
			try
			{
				reader = File.OpenText(path);
				res = (T)x.Deserialize(reader);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				EditorUtility.DisplayDialog("error", "xml serializer error : " + path, "OK");
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}
			}

			return res;
		}

		/// <summary>
		/// 将所有xml配置文件的详细信息写入文件;
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xmlData"></param>
		/// <param name="path"></param>
		public void DetailPathWriteToFile<T>(T xmlData, string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = null;
			XSerializer x = new XSerializer(typeof(T));
			try
			{
				writer = new StreamWriter(fs);
				x.Serialize(writer, xmlData);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				EditorUtility.DisplayDialog("error", "xml write error : " + path, "OK");
			}
			finally
			{
				if (writer != null)
				{
					writer.Close();
				}
			}
		}

		/// <summary>
		/// 获取所有配置数据;
		/// </summary>
		/// <param name="xmlGroups"></param>
		/// <param name="xmlSheetGroups"></param>
        /// <param name="xmlLevelGroups"></param>
        public void TryGetGroups(out GameConfigGroups xmlGroups, out GameConfigGroups xmlSheetGroups, out  GameConfigGroups  xmlLevelGroups)
		{
			xmlGroups = mGameXmlGroups;
            xmlSheetGroups = mGameXmlSheetGroups;
            xmlLevelGroups = mGameLevelGroups;
		}

		/// <summary>
		/// 获取某一类型的配置数据;
		/// </summary>
		/// <param name="type">枚举类型;</param>
		/// <returns></returns>
		public GameConfigGroups GetGroupData(DataType type)
		{
			switch (type)
			{
				case DataType.XML:
				    return mGameXmlGroups;
				case DataType.XML_SHEET:
				    return mGameXmlSheetGroups;
                case DataType.XML_LEVEL:
                    return mGameLevelGroups;
			}
			return null;
		}

		public List<GameConfigProto> GetGameConfigProtos()
		{
			if (mGameConfig == null || mGameConfig.gameConfigProtos == null)
			{
				return new List<GameConfigProto>();
			}
			return mGameConfig.gameConfigProtos.gameConfigProtos;
		}

		public GameConfigData GetGameConfigData()
		{
            LoadConfig(); // 每次调用时加载一遍，避免缓存原本加载的配置，导致新的修改无法被加载;
			if (mGameConfig == null)
			{
				return null;
			}
			return mGameConfig.gameConfigData;
		}

	}

	#region XMLSerializable
	[Serializable]
	[XmlType(@"GameConfigGroups")]
	public class GameConfigGroups
	{
		[XmlElement(@"GameXmlGroup")]
		public GameXmlGroup[] gameXmlGroups = new GameXmlGroup[] { };
		[XmlElement(@"GameXmlSheetGroup")]
		public GameXmlSheetGroup[] gameXmlSheetGroups = new GameXmlSheetGroup[] { };
        [XmlElement(@"GameLevelGroup")]
        public GameXmlGroup[] gameXmlLevelGroups = new GameXmlGroup[] { };
	}

	[Serializable]
	[XmlType(@"GameXmlGroup")]
	public class GameXmlGroup
	{
		[XmlAttribute(@"group")]
		public string Group;
		[XmlElement(@"GameXmlFile")]
		public GameXmlFile[] gameXmlFiles = new GameXmlFile[] { };
	}

	[Serializable]
	[XmlType(@"GameXmlFile")]
	public class GameXmlFile
	{
		[XmlAttribute(@"path")]
		public string Path;
		[XmlAttribute(@"type_name")]
		public string TypeName;
	}

	[Serializable]
	[XmlType(@"GameXmlSheetGroup")]
	public class GameXmlSheetGroup
	{
		[XmlAttribute(@"group")]
		public string Group;
		[XmlElement(@"GameXmlSheet")]
		public GameXmlSheet[] gameSheets = new GameXmlSheet[] { };
	}

	[Serializable]
	[XmlType(@"GameXmlSheet")]
	public class GameXmlSheet
	{
		[XmlAttribute(@"sheet_name")]
		public string SheetName;
		[XmlElement(@"GameXmlSheetFile")]
		public GameXmlSheetFile[] gameXmlSheetFile = new GameXmlSheetFile[] { };
	}

	[Serializable]
	[XmlType(@"GameXmlSheetFile")]
	public class GameXmlSheetFile
	{
		[XmlAttribute(@"dir")]
		public string Dir;
		[XmlAttribute(@"type_name")]
		public string TypeName;
	}

	//config.xml
	[Serializable]
	[XmlType(@"GameConfig")]
	public class GameConfig
	{
		[XmlElement(@"GameConfigProtos")]
		public GameConfigProtos gameConfigProtos = new GameConfigProtos();
		[XmlElement(@"GameConfigData")]
		public GameConfigData gameConfigData = new GameConfigData();
	}

	[Serializable]
	public class GameConfigProtos
	{
		[XmlElement(@"GameConfigProto")]
		public List<GameConfigProto> gameConfigProtos;
	}

	[Serializable]
	public class GameConfigProto
	{
		[XmlAttribute(@"protoPath")]
		public string protoPath;
		[XmlAttribute(@"codePath")]
		public string codePath;
	}

	[Serializable]
	public class GameConfigData
	{
		[XmlAttribute(@"gameConfigSettingPath")]
		public string gameConfigSettingPath;
		[XmlAttribute(@"xmlPath")]
		public string xmlPath;
		[XmlAttribute(@"xmlSheetPath")]
		public string xmlSheetPath;
        [XmlAttribute(@"xmlLevelPath")]
        public string xmlLevelPath;
		[XmlAttribute(@"detailGameConfigPath")]
		public string detailGameConfigPath;
		[XmlAttribute(@"datPath")]
		public string datPath;
        [XmlAttribute(@"dataLanguageDir")]
        public string dataLanguageDir;
    }

	#endregion
}