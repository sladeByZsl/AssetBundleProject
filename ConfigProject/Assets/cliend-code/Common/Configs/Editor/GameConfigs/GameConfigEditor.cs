/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
---------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：GameConfigEditor.cs;
	作	者：jiabin;
	时	间：2017 - 04 - 07;
	注	释：此工具用于一键序列化所有xml xmlsheet 配置文件;
**************************************************************************************************/

using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;
using FunPlus.Common.Config;
using FunPlus.Common.GameConfig;

public class GameConfigEditor : EditorWindow
{
    private static List<XmlSheetGroupSettings> mXmlSheetGroups = new List<XmlSheetGroupSettings>();
    private static List<XmlGroupSettings> mXmlGroups = new List<XmlGroupSettings>();
    private static List<XmlGroupSettings> mXmlLevelGroups = new List<XmlGroupSettings>();

    private static List<string> mOldFilePath = new List<string>();

    // 通过配置proto生成对应类;
	[MenuItem("FunPlus/GameConfigs/ProtoGen", false, 0)]
    static void ProtoGenerate()
    {
        // 通过配置proto生成对应lua解析xml类，此类作用只是Editor模式下用于生成二进制文件;
        string codePath;
        if (!string.IsNullOrEmpty(ProtoGen.GenerateProto(null, out codePath)))
        {
            Debug.Log("Code generated at " + codePath);
            AssetDatabase.Refresh();
        }
    }

	

	[MenuItem("FunPlus/GameConfigs/Serializer Config")]
    public static void SerializerConfig()
    {
        GameConfigData gameConfigData = GameConfigDataBase.GetInstance().GetGameConfigData();
        if (gameConfigData == null)
        {
            Debug.Log("gameConfigData is null");
            return;
        }
        string detailGameConfigPath = string.Format("{0}/../conf/{1}", Application.dataPath, gameConfigData.detailGameConfigPath);
        string datPath = string.Format("{0}/../conf/{1}", Application.dataPath, gameConfigData.datPath);
        GetTargetDirAllFilePath(datPath);

		FunPlus.Util.CheckXML.GetInstance().LoadIgnoreFile();

        GameConfigGroups gameXmlGroups;
        GameConfigGroups gameXmlSheetGroups;
        GameConfigGroups gameXmlLevelGroups;
        GameConfigDataBase.GetInstance().TryGetGroups(out gameXmlGroups, out gameXmlSheetGroups, out gameXmlLevelGroups);

		GetAllFileByXmlGroup(gameXmlGroups);
        SerializeAllXml(mXmlGroups);

        //GetAllFileByXmlLevelGroup(gameXmlLevelGroups);
        //SerializeAllXml(mXmlLevelGroups);

		GetAllFileBySheetGroup(gameXmlSheetGroups);
        SerializeAllXmlSheet(mXmlSheetGroups);

        ConfigGroupsSettings conf = new ConfigGroupsSettings();
        conf.xmlGroups = mXmlGroups.ToArray();
        conf.xmlSheetGroups = mXmlSheetGroups.ToArray();
        conf.xmlLevelGroups = mXmlLevelGroups.ToArray();
		//删除这次生成之外的文件
        DeleteNotChangePath(conf);

        ReplaceRelativePath(ref conf);
        GameConfigDataBase.GetInstance().DetailPathWriteToFile<ConfigGroupsSettings>(conf, detailGameConfigPath);
    }
	private static void GetAllFileByXmlLevelGroup(GameConfigGroups groups)
	{
		if (!CheckGroup (groups)) 
		{
			return;
		}
		GameXmlGroup[] gameXmlGroups = groups.gameXmlGroups;
		//获取序列化xmlgroups所需要的数据;
		if (gameXmlGroups != null && gameXmlGroups.Length > 0)
		{
			XmlGroupSettings tempXmlGroups = null;//detail config
			mXmlLevelGroups.Clear();

			for (int i = 0; i < gameXmlGroups.Length; i++)
			{
				tempXmlGroups = new XmlGroupSettings();

				List<GameXmlFile> t_files = new List<GameXmlFile> (gameXmlGroups[i].gameXmlFiles);
				for(int j=0; j<t_files.Count; j++)
				{
					
					string t_name = Path.GetFileNameWithoutExtension(t_files[j].Path);
					if (string.IsNullOrEmpty (t_name)) 
					{
						GameXmlFile temp = t_files [j];
						t_files.Remove (temp);
						string dirPath = string.Format("{0}/../conf/{1}", Application.dataPath, temp.Path);
						if (!Directory.Exists(dirPath))
						{
							Debug.LogError("dir is not exists :  " + dirPath);
							continue;
						}
						string[] allPath = Directory.GetFiles(dirPath, "*.xml", SearchOption.AllDirectories);
						for (int t = 0; t < allPath.Length; t++)
						{
							GameXmlFile xFile = new GameXmlFile();
							xFile.Path = allPath[t].Replace('\\', '/');
							string t_Path = string.Format("{0}/../conf/", Application.dataPath);
							xFile.Path = xFile.Path.Replace (t_Path, "");
							xFile.TypeName = temp.TypeName;
							t_files.Insert(j,xFile);
						}
					}
				}


				GameXmlFile[] files = t_files.ToArray();	
				tempXmlGroups.group = string.Format("{0}/../conf/{1}", Application.dataPath, gameXmlGroups[i].Group);
				if (files == null)
				{
					Debug.LogError("xmlgroup config error!");
					return;
				}
				tempXmlGroups.xmlFiles = new XmlGroupSettings.XmlData[files.Length];

				for (int j = 0; j < files.Length; j++)
				{
					tempXmlGroups.xmlFiles[j] = new XmlGroupSettings.XmlData();
					tempXmlGroups.xmlFiles[j].path = string.Format("{0}/../conf/{1}", Application.dataPath, files[j].Path.Replace('\\', '/'));
					tempXmlGroups.xmlFiles[j].typeName = files[j].TypeName;
				}

				mXmlLevelGroups.Add(tempXmlGroups);
				tempXmlGroups = null;
			}
		}
	}
	private static void GetAllFileByXmlGroup(GameConfigGroups groups)
	{
		if (!CheckGroup (groups)) 
		{
			return;
		}
		GameXmlGroup[] gameXmlGroups = groups.gameXmlGroups;
		//获取序列化xmlgroups所需要的数据;
		if (gameXmlGroups != null && gameXmlGroups.Length > 0)
		{
			XmlGroupSettings tempXmlGroups = null;//detail config
			mXmlGroups.Clear();

			for (int i = 0; i < gameXmlGroups.Length; i++)
			{
				tempXmlGroups = new XmlGroupSettings();

				List<GameXmlFile> t_files = new List<GameXmlFile> (gameXmlGroups[i].gameXmlFiles);
				for(int j=0; j<t_files.Count; j++)
				{
					
					string t_name = Path.GetFileNameWithoutExtension(t_files[j].Path);
					if (string.IsNullOrEmpty (t_name)) 
					{
						GameXmlFile temp = t_files [j];
						t_files.Remove (temp);
						string dirPath = string.Format("{0}/../conf/{1}", Application.dataPath, temp.Path);
						if (!Directory.Exists(dirPath))
						{
							Debug.LogError("dir is not exists :  " + dirPath);
							continue;
						}
						string[] allPath = Directory.GetFiles(dirPath, "*.xml", SearchOption.AllDirectories);
						for (int t = 0; t < allPath.Length; t++)
						{
							GameXmlFile xFile = new GameXmlFile();
							xFile.Path = allPath[t].Replace('\\', '/');
							string t_Path = string.Format("{0}/../conf/", Application.dataPath);
							xFile.Path = xFile.Path.Replace (t_Path, "");
							xFile.TypeName = temp.TypeName;
							t_files.Insert(j,xFile);
						}
					}
				}


				GameXmlFile[] files = t_files.ToArray();	
				tempXmlGroups.group = string.Format("{0}/../conf/{1}", Application.dataPath, gameXmlGroups[i].Group);
				if (files == null)
				{
					Debug.LogError("xmlgroup config error!");
					return;
				}
				tempXmlGroups.xmlFiles = new XmlGroupSettings.XmlData[files.Length];

				for (int j = 0; j < files.Length; j++)
				{
					tempXmlGroups.xmlFiles[j] = new XmlGroupSettings.XmlData();
					tempXmlGroups.xmlFiles[j].path = string.Format("{0}/../conf/{1}", Application.dataPath, files[j].Path.Replace('\\', '/'));
					tempXmlGroups.xmlFiles[j].typeName = files[j].TypeName;
				}

				mXmlGroups.Add(tempXmlGroups);
				tempXmlGroups = null;
			}
		}
	}

	private static void GetAllFileBySheetGroup(GameConfigGroups groups)
	{
		if (!CheckGroup (groups)) 
		{
			return;
		}
		GameXmlSheetGroup[] gameXmlSheetGroups = groups.gameXmlSheetGroups;

		//获取序列化xmlsheetgroups所需要的数据;
		if (gameXmlSheetGroups != null && gameXmlSheetGroups.Length > 0)
		{
			XmlSheetGroupSettings tempGroups = null;//detail config
			List<XmlSheetGroupSettings.XmlSheetFile> mXmlSheetFileList = new List<XmlSheetGroupSettings.XmlSheetFile>();
			mXmlSheetGroups.Clear();
			for (int i = 0; i < gameXmlSheetGroups.Length; i++)
			{
				tempGroups = new XmlSheetGroupSettings();
				GameXmlSheet[] sheet = gameXmlSheetGroups[i].gameSheets;
				tempGroups.group = string.Format("{0}/../conf/{1}", Application.dataPath, gameXmlSheetGroups[i].Group);
				if (sheet == null)
				{
					Debug.LogError("xmlsheetgroups config error!");
					return;
				}
				tempGroups.sheetFiles = new XmlSheetGroupSettings.XmlSheetData[sheet.Length];

				for (int k = 0; k < sheet.Length; k++)
				{
					tempGroups.sheetFiles[k] = new XmlSheetGroupSettings.XmlSheetData();
					tempGroups.sheetFiles[k].sheetName = sheet[k].SheetName;
					mXmlSheetFileList.Clear();

					if (sheet[k].gameXmlSheetFile == null)
					{
						continue;
					}

					for (int j = 0; j < sheet[k].gameXmlSheetFile.Length; j++)
					{
						string dirPath = string.Format("{0}/../conf/{1}", Application.dataPath, sheet[k].gameXmlSheetFile[j].Dir);
						if (!Directory.Exists(dirPath))
						{
							Debug.LogError("dir is not exists :  " + dirPath);
							continue;
						}
						string[] allPath = Directory.GetFiles(dirPath, "*.xml", SearchOption.AllDirectories);
						for (int t = 0; t < allPath.Length; t++)
						{
							XmlSheetGroupSettings.XmlSheetFile xFile = new XmlSheetGroupSettings.XmlSheetFile();
							xFile.filePath = allPath[t].Replace('\\', '/');
							xFile.typeName = sheet[k].gameXmlSheetFile[j].TypeName;
							mXmlSheetFileList.Add(xFile);
						}
					}

					tempGroups.sheetFiles[k].files = mXmlSheetFileList.ToArray();
					mXmlSheetFileList.Clear();
				}

				mXmlSheetGroups.Add(tempGroups);
				tempGroups = null;
			}
		}
	}

	private static bool CheckGroup(GameConfigGroups groups)
	{
		if (groups == null)
		{
			Debug.LogError("config data is null!");
			return false;
		}
		return true;
	}

    /// <summary>
    /// 序列化所有xml配置文件;
    /// </summary>
    private static void SerializeAllXml(List<XmlGroupSettings> groups)
    {
        try
        {
            List<string> gs = new List<string>();
            for (int i = 0, imax = groups.Count; i < imax; i++)
            {
                XmlGroupSettings group = groups[i];
				FunPlus.Common.Config.XmlSerializer.SerializeXmls(group);
                gs.Add(group.group);
            }
            AssetDatabase.Refresh();
            Debug.Log("xml serialize");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            EditorUtility.DisplayDialog("Xml Serialize Failed !", "See console for more details.\n\n" + e.Message, "OK");
        }
    }

    /// <summary>
    /// 序列化所有xmlsheet文件;
    /// </summary>
    private static void SerializeAllXmlSheet(List<XmlSheetGroupSettings> groups)
    {
        try
        {
            List<string> gs = new List<string>();
            for (int i = 0, imax = groups.Count; i < imax; i++)
            {
                XmlSheetGroupSettings group = groups[i];
                XmlSheetSerializer.GenerateGroupBinaryFile(group);
                gs.Add(group.group);
            }
            AssetDatabase.Refresh();
            Debug.Log("xmlsheet serialize");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            EditorUtility.DisplayDialog("XmlSheet Serialize Failed !", "See console for more details.\n\n" + e.Message, "OK");
        }
    }

	/// <summary>
	/// 获取指定目录下的所有.dat文件
	/// </summary>
	/// <param name="dirPath">Dir path.</param>
    private static void GetTargetDirAllFilePath(string dirPath)
    {
        if (!Directory.Exists(dirPath))
        {
            return;
        }
        string[] allFiles = Directory.GetFiles(dirPath, "*.dat", SearchOption.AllDirectories);
        mOldFilePath.Clear();
        mOldFilePath.AddRange(allFiles);
        for (int i = 0; i < mOldFilePath.Count; i++)
        {
            mOldFilePath[i] = mOldFilePath[i].Replace("\\", "/");
        }
    }

    /// <summary>
    /// 从旧的路径list中移除未改变的路径  删除剩余的文件;
    /// </summary>
    /// <param name="cfg"></param>
    private static void DeleteNotChangePath(ConfigGroupsSettings cfg)
    {
        for (int i = 0; i < cfg.xmlGroups.Length; i++)
        {
            if (mOldFilePath.Contains(cfg.xmlGroups[i].group))
            {
                mOldFilePath.Remove(cfg.xmlGroups[i].group);
            }
        }
        for (int i = 0; i < cfg.xmlLevelGroups.Length; i++)
        {
            if (mOldFilePath.Contains(cfg.xmlLevelGroups[i].group))
            {
                mOldFilePath.Remove(cfg.xmlLevelGroups[i].group);
            }
        }

        for (int i = 0; i < cfg.xmlSheetGroups.Length; i++)
        {
            if (mOldFilePath.Contains(cfg.xmlSheetGroups[i].group))
            {
                mOldFilePath.Remove(cfg.xmlSheetGroups[i].group);
            }
        }

        DeleteFile();
    }

    private static void DeleteFile()
    {
        for (int i = 0; i < mOldFilePath.Count; i++)
        {
            File.Delete(mOldFilePath[i]);
        }
        mOldFilePath.Clear();
    }

    // 替换为相对路径;
    private static void ReplaceRelativePath(ref ConfigGroupsSettings conf)
    {
        if(conf == null)
        {
            return;
        }

        string rootPath = Application.dataPath + "/../";
        if (conf.xmlGroups != null)
        {
            for (int i = 0; i < conf.xmlGroups.Length; i++)
            {
                XmlGroupSettings xmlGroupSettings = conf.xmlGroups[i];
                if(xmlGroupSettings == null)
                {
                    continue;
                }
                xmlGroupSettings.group = xmlGroupSettings.group.Replace(rootPath, "");

                if (xmlGroupSettings.xmlFiles == null)
                {
                    continue;
                }
                for (int j = 0, jmax = xmlGroupSettings.xmlFiles.Length; j < jmax; j++)
                {
                    XmlGroupSettings.XmlData xmlData = xmlGroupSettings.xmlFiles[j];
                    if(xmlData == null)
                    {
                        continue;
                    }
                    xmlData.path = xmlData.path.Replace(rootPath, "");
                }
            }
        }

        if (conf.xmlSheetGroups != null)
        {
            for (int i = 0; i < conf.xmlSheetGroups.Length; i++)
            {
                XmlSheetGroupSettings xmlSheetGroupSettings = conf.xmlSheetGroups[i];
                if (xmlSheetGroupSettings == null)
                {
                    continue;
                }
                xmlSheetGroupSettings.group = xmlSheetGroupSettings.group.Replace(rootPath, "");

                if (xmlSheetGroupSettings.sheetFiles == null)
                {
                    continue;
                }
                for (int j = 0, jmax = xmlSheetGroupSettings.sheetFiles.Length; j < jmax; j++)
                {
                    XmlSheetGroupSettings.XmlSheetData xmlSheetData = xmlSheetGroupSettings.sheetFiles[j];
                    if (xmlSheetData == null || xmlSheetData.files == null)
                    {
                        continue;
                    }
                    for (int k = 0, kmax = xmlSheetData.files.Length; k < kmax; k++)
                    {
                        XmlSheetGroupSettings.XmlSheetFile xmlSheetFile = xmlSheetData.files[k];
                        if (xmlSheetFile == null)
                        {
                            continue;
                        }
                        xmlSheetFile.filePath = xmlSheetFile.filePath.Replace(rootPath, "");
                    }
                }
            }
        }
    }
	static string last_proto_dir
	{
		get
		{
			return EditorPrefs.GetString("protogen_last_proto_dir", ".");
		}
		set
		{
			EditorPrefs.SetString("protogen_last_proto_dir", value);
		}
	}
	static string last_code_dir
	{
		get
		{
			return EditorPrefs.GetString("protogen_last_code_dir", "");
		}
		set
		{
			EditorPrefs.SetString("protogen_last_code_dir", value);
		}
	}
	
	public static string ProtoGenLua()
	{
		// 获取输入和输出文件;
		string protoPath = EditorUtility.OpenFilePanel("Select Proto File", last_proto_dir, "proto");
		if ( string.IsNullOrEmpty(protoPath) )
		{
			return "";
		}
		last_proto_dir = Path.GetDirectoryName(protoPath);
		string codePath = EditorUtility.SaveFilePanelInProject("Select Code Path", "", "cs", "", last_code_dir);
		if ( string.IsNullOrEmpty(codePath) )
		{
			return "";
		}
		last_code_dir = Path.GetDirectoryName(codePath);

		string protoRootPath = Path.GetFullPath(string.Format("{0}/../conf/pb_gen/pb_proto/", Application.dataPath));
		string protoFileName = Path.GetFileName(protoPath);
		string newProtoFile = string.Format("{0}{1}", protoRootPath, protoFileName);

		// 将选中的文件拷贝到新目录下;
		if (File.Exists(newProtoFile))
		{
			File.Delete(newProtoFile);
		}
		File.Copy(protoPath, newProtoFile);

		protoPath = "-i:" + protoFileName;
		
		System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
		info.FileName = string.Format("{0}/../conf/pb_gen/pb_net/protogen.exe", Application.dataPath);
		info.Arguments = protoPath + " -o:" + string.Format("{0}/../{1}", Application.dataPath, codePath) + " -p:import=PBProto -p:xml";
		info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
		info.ErrorDialog = true;
		info.UseShellExecute = false;
		info.WorkingDirectory = protoRootPath;
		info.RedirectStandardInput = true;
		info.RedirectStandardOutput = true;
		info.RedirectStandardError = true;

		try
		{
			System.Diagnostics.Process pro = new System.Diagnostics.Process();
			pro.StartInfo = info;
			pro.Start();
			string strError = pro.StandardError.ReadToEnd();
			if ( !string.IsNullOrEmpty(strError) )
			{
				EditorUtility.DisplayDialog("ProtoGen Error", strError, "OK");
                Debug.LogError(strError);
			}
			pro.WaitForExit();
		}
		catch (System.Exception ex)
		{
			Debug.LogError(ex.ToString());
		}

		if (File.Exists(newProtoFile))
		{
			File.Delete(newProtoFile);
		}

		return codePath;
	}

}
