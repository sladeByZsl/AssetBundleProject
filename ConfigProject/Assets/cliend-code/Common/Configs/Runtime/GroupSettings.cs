
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：GroupSettings.cs;
	作	者：jiabin;
	时	间：2016 - 05 - 04;
	注	释：此文件中的接口仅在Editor时可以使用;
**************************************************************************************************/

#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace FunPlus.Common.Config
{
	public static class GroupSettings
	{
		public static List<XmlGroupSettings> ReadXmlGroupSettings()
		{
			Type typeConfig = Type.GetType("FunPlus.Common.Config.ConfigSettings,Assembly-CSharp-Editor");
			if (typeConfig == null) { return null; }
			MethodInfo methodXmlGroup = typeConfig.GetMethod("ReadXmlGroupSettings", BindingFlags.Static | BindingFlags.Public);
			if (methodXmlGroup == null) { return null; }
			return (List<XmlGroupSettings>)methodXmlGroup.Invoke(null, new object[0]);
		}

		public static List<XmlSheetGroupSettings> ReadXmlSheetGroupSettings()
		{
			Type typeConfig = Type.GetType("FunPlus.Common.Config.ConfigSettings,Assembly-CSharp-Editor");
			if (typeConfig == null) { return null; }
			MethodInfo methodXmlGroup = typeConfig.GetMethod("ReadXmlSheetGroupSettings", BindingFlags.Static | BindingFlags.Public);
			if (methodXmlGroup == null) { return null; }
			return (List<XmlSheetGroupSettings>)methodXmlGroup.Invoke(null, new object[0]);
		}
	}

    [Serializable]
	[XmlType(@"XmlGroups")]
	public class XmlGroupSettings
	{
		[XmlAttribute(@"comments")]
		public string comments;
		[XmlAttribute(@"group")]
		public string group;
		[XmlElement(@"XmlFile")]
		public XmlData[] xmlFiles = new XmlData[] { };

		[Serializable]
		[XmlType("XmlData")]
		public class XmlData
		{
			[XmlAttribute(@"comments")]
			public string comments;
			[XmlAttribute(@"path")]
			public string path;
			[XmlAttribute(@"type_name")]
			public string typeName;
			[XmlAttribute(@"code_path")]
			public string codePath;
		}
	}

	[Serializable]
	[XmlType(@"XmlSheetGroups")]
	public class XmlSheetGroupSettings
	{
		[XmlAttribute(@"comments")]
		public string comments;
		[XmlAttribute(@"group")]
		public string group;
		[XmlElement("Sheet")]
		public XmlSheetData[] sheetFiles = new XmlSheetData[] { };

		[Serializable]
		public class XmlSheetData
		{
			[XmlAttribute(@"comments")]
			public string comments;
			[XmlAttribute(@"sheet_name")]
			public string sheetName;
			[XmlElement(@"SheetFile")]
			public XmlSheetFile[] files = new XmlSheetFile[] { };
		}

		[Serializable]
		[XmlType(@"XmlSheetFile")]
		public class XmlSheetFile
		{
			[XmlAttribute(@"file_path")]
			public string filePath;
			[XmlAttribute(@"type_name")]
			public string typeName;
			[XmlAttribute(@"code_path")]
			public string codePath;
		}

	}
}
#endif