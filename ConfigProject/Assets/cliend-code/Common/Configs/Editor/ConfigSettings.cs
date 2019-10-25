
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：ConfigSettings.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 18;
	注	释：;
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using XSerializer = System.Xml.Serialization.XmlSerializer;

namespace FunPlus.Common.Config
{

	/// <summary>
	/// 用于存取XmlSerializerUI和XmlSheetSerializerUI中的配置，即组信息
	/// </summary>
	public static class ConfigSettings
	{

		private const string SETTINGS_FILE_PATH = "ProjectSettings/ConfigSettings.asset";

		private static ConfigGroupsSettings config_settings;
		private static ConfigGroupsSettings GetConfigSettings()
		{
			if (config_settings == null || config_settings.xmlGroups == null || config_settings.xmlSheetGroups == null ||
				(config_settings.xmlGroups.Length <= 0 && config_settings.xmlSheetGroups.Length <= 0))
			{
				config_settings = null;
				if (File.Exists(SETTINGS_FILE_PATH))
				{
					XSerializer x = new XSerializer(typeof(ConfigGroupsSettings));
					StreamReader reader = File.OpenText(SETTINGS_FILE_PATH);
					try
					{
						config_settings = (ConfigGroupsSettings)x.Deserialize(reader);
						if (config_settings.xmlGroups == null) { config_settings.xmlGroups = new XmlGroupSettings[0]; }
						if (config_settings.xmlSheetGroups == null) { config_settings.xmlSheetGroups = new XmlSheetGroupSettings[0]; }
					}
					catch { }
					reader.Close();
				}
				if (config_settings == null)
				{
					config_settings = new ConfigGroupsSettings();
					config_settings.xmlGroups = new XmlGroupSettings[0];
					config_settings.xmlSheetGroups = new XmlSheetGroupSettings[0];
				}
			}
			return config_settings;
		}

		private static void WriteConfigSettings()
		{
			XSerializer x = new XSerializer(typeof(ConfigGroupsSettings));
			StreamWriter writer = File.CreateText(SETTINGS_FILE_PATH);
			try
			{
				x.Serialize(writer, GetConfigSettings());
				writer.Flush();
			}
			catch { }
			writer.Close();
		}

		public static List<XmlGroupSettings> ReadXmlGroupSettings()
		{
			List<XmlGroupSettings> settings = new List<XmlGroupSettings>();
			if (GetConfigSettings().xmlGroups != null)
			{
				settings.AddRange(GetConfigSettings().xmlGroups);
			}
			return settings;
		}

		public static void WriteXmlGroupSettings(List<XmlGroupSettings> settings)
		{
			if (settings == null) { return; }
			ConfigGroupsSettings groups = GetConfigSettings();
			groups.xmlGroups = settings.ToArray();
			WriteConfigSettings();
		}

		public static List<XmlSheetGroupSettings> ReadXmlSheetGroupSettings()
		{
			List<XmlSheetGroupSettings> settings = new List<XmlSheetGroupSettings>();
			if (GetConfigSettings().xmlSheetGroups != null)
			{
				settings.AddRange(GetConfigSettings().xmlSheetGroups);
			}
			return settings;
		}

		public static void WriteXmlSheetGroupSettings(List<XmlSheetGroupSettings> settings)
		{
			if (settings == null) { return; }
			ConfigGroupsSettings groups = GetConfigSettings();
			groups.xmlSheetGroups = settings.ToArray();
			WriteConfigSettings();
		}

	}

	[Serializable]
	[XmlType(@"ConfigGroups")]
	public class ConfigGroupsSettings
	{
		[XmlElement(@"XmlGroup")]
		public XmlGroupSettings[] xmlGroups;
		[XmlElement(@"XmlSheetGroup")]
		public XmlSheetGroupSettings[] xmlSheetGroups;
        [XmlElement(@"XmlLevelGroup")]
        public XmlGroupSettings[] xmlLevelGroups;
	}

}
