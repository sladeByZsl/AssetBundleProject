
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：XmlSheetSerializerUI.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 18;
	注	释：;
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace FunPlus.Common.Config
{

	public class XmlSheetSerializerUI : EditorWindow
	{

		//[MenuItem("FunPlus/Configs/XmlSheet Serializer", false, 4)]
		static void OpenSettings()
		{
			XmlSheetSerializerUI window = GetWindow<XmlSheetSerializerUI>("XmlSheetSerializer");
			window.minSize = new Vector2(400f, 300f);
		}

		//[MenuItem("FunPlus/Configs/Serialize All XmlSheets", false, 4)]
		static void SerializeAllXmls()
		{
			List<XmlSheetGroupSettings> groups = ConfigSettings.ReadXmlSheetGroupSettings();
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
				EditorUtility.DisplayDialog("XmlSheet Serializer", "Xmls Serializer !\n" + string.Join("\n", gs.ToArray()), "OK");
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				EditorUtility.DisplayDialog("XmlSheet Serialize Failed !", "See console for more details.\n\n" + e.Message, "OK");
			}
		}

		private static string project_path;
		private static string projectPath
		{
			get
			{
				if (string.IsNullOrEmpty(project_path))
				{
					project_path = Application.dataPath;
					project_path = project_path.Substring(0, project_path.Length - 6);
				}
				return project_path;
			}
		}

		List<XmlSheetGroupSettings> mSettingsList;

		Vector2 mScrollPos = Vector2.zero;

		XmlSheetGroupSettings mCurGroup;
		HashSet<string> mInvalidFiles = new HashSet<string>();

		int mSelectedGroupId;
		string[] mGroupNames;
		int[] mGroupIds;

		void OnGUI()
		{
			EditorGUI.BeginDisabledGroup(EditorApplication.isCompiling);
			Color cachedBgColor;
			bool dirty = false;
			bool isValid = true;

			GUILayout.Space(12f);
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("XmlSheet Group", GUILayout.Width(100f));
			int selectedGroupId = EditorGUILayout.Popup(mSelectedGroupId, mGroupNames);
			if (selectedGroupId == 0)
			{
				string groupName = EditorUtilityFix.SaveFilePanel("Set Binary Data Path", ".", "new_xmlsheet_group", "dat");
				if (!string.IsNullOrEmpty(groupName))
				{
					if (IsGroupNameValid(groupName))
					{
						mCurGroup = new XmlSheetGroupSettings();
						mCurGroup.group = groupName;
						mCurGroup.comments = groupName;
						mSettingsList.Add(mCurGroup);
						mSelectedGroupId = InitGroupOptions();
						dirty = true;
					}
					else
					{
						EditorUtility.DisplayDialog("Create New Xmls Group Failed",
							"A binary file with the same filename has already been set here!", "Got it");
					}
				}
			}
			else if (selectedGroupId > 0)
			{
				mSelectedGroupId = selectedGroupId;
				mCurGroup = mSettingsList[mSelectedGroupId - 1];
			}
			EditorGUI.BeginDisabledGroup(mSelectedGroupId <= 0);
			cachedBgColor = GUI.backgroundColor;
			GUI.backgroundColor = Color.red;
			if (GUILayout.Button("Delete", GUILayout.Width(60f)))
			{
				mSelectedGroupId = DeleteGroup(mSelectedGroupId);
				mCurGroup = mSelectedGroupId > 0 ? mSettingsList[mSelectedGroupId - 1] : null;
				dirty = true;
			}
			GUI.backgroundColor = cachedBgColor;
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();

			if (mCurGroup != null)
			{
				GUILayout.Space(8f);

				EditorGUILayout.BeginHorizontal(GUILayout.Height(20f));
				GUILayout.Space(4f);
				EditorGUILayout.LabelField("Comment", GUILayout.Width(100f));
				EditorGUI.BeginChangeCheck();
				mCurGroup.comments = EditorGUILayout.TextField(mCurGroup.comments);
				if (EditorGUI.EndChangeCheck())
				{
					dirty = true;
				}
				GUILayout.Space(68f);
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.BeginHorizontal(GUILayout.Height(20f));
				GUILayout.Space(4f);
				EditorGUILayout.LabelField("Binary File Path", GUILayout.Width(100f));
				EditorGUILayout.LabelField(mCurGroup.group, (GUIStyle)"AS TextArea", GUILayout.Height(20f));
				if (GUILayout.Button("Browse", GUILayout.Width(60f)))
				{
					string groupPath = EditorUtilityFix.SaveFilePanel("Change Binary Data Path",
						Path.GetDirectoryName(mCurGroup.group), Path.GetFileNameWithoutExtension(mCurGroup.group), Path.GetExtension(mCurGroup.group).Replace(".", ""));
					if (!string.IsNullOrEmpty(groupPath) && groupPath != mCurGroup.group)
					{
						if (IsGroupNameValid(groupPath))
						{
							if (mCurGroup.comments == mCurGroup.group)
							{
								mCurGroup.comments = groupPath;
							}
							mCurGroup.group = groupPath;
							dirty = true;
							InitGroupOptions();
						}
						else
						{
							EditorUtility.DisplayDialog("Change Binary File Path Failed",
								"A binary file with the same filename has already been set here!", "Got it");
						}
					}
				}
				GUILayout.Space(4f);
				EditorGUILayout.EndHorizontal();
				GUILayout.Space(2f);

				mScrollPos = EditorGUILayout.BeginScrollView(mScrollPos, false, false);
				EditorGUILayout.LabelField("Xml Sheets:");
				int removeAt = -1;
				for (int i = 0, imax = mCurGroup.sheetFiles.Length; i < imax; i++)
				{
					XmlSheetGroupSettings.XmlSheetData xmlSheetData = mCurGroup.sheetFiles[i];
					EditorGUILayout.BeginHorizontal(GUILayout.MinHeight(20f));
					GUILayout.Space(12f);
					//start content
					cachedBgColor = GUI.backgroundColor;
					GUI.backgroundColor = (i & 1) == 0 ? new Color(0.6f, 0.6f, 0.7f) : new Color(0.8f, 0.8f, 0.8f);
					EditorGUILayout.BeginVertical((GUIStyle)"AS TextArea", GUILayout.MinHeight(20f));
					GUI.backgroundColor = cachedBgColor;
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField("Sheet Name", GUILayout.Width(76f));
					string sheetName = EditorGUILayout.TextField(xmlSheetData.sheetName);
					if (sheetName != xmlSheetData.sheetName)
					{
						xmlSheetData.sheetName = sheetName;
						dirty = true;
					}
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField("Comments", GUILayout.Width(76f));
					string comments = EditorGUILayout.TextField(xmlSheetData.comments);
					if (comments != xmlSheetData.comments)
					{
						xmlSheetData.comments = comments;
						dirty = true;
					}
					EditorGUILayout.EndHorizontal();
					int removeXmlAt = -1;
					for (int j = 0, jmax = xmlSheetData.files.Length; j < jmax; j++)
					{
						XmlSheetGroupSettings.XmlSheetFile sheetFile = xmlSheetData.files[j];
						if (sheetFile == null) { continue; }
						GUILayout.Space(4f);
						EditorGUILayout.BeginHorizontal();
						GUILayout.Space(10f);
						EditorGUILayout.LabelField(string.Format("Xml File {0} : ", (j + 1)));
						cachedBgColor = GUI.backgroundColor;
						GUI.backgroundColor = Color.red;
						if (GUILayout.Button("Delete", GUILayout.Width(64f)))
						{
							removeXmlAt = j;
						}
						GUI.backgroundColor = cachedBgColor;
						EditorGUILayout.EndHorizontal();
						EditorGUILayout.BeginHorizontal(GUILayout.MinHeight(20f));
						GUILayout.Space(20f);
						EditorGUILayout.LabelField("Path", GUILayout.Width(40f));
						GUILayout.Space(2f);
						bool invalid = mInvalidFiles.Contains(sheetFile.filePath);
						cachedBgColor = GUI.backgroundColor;
						if (invalid)
						{
							GUI.backgroundColor = Color.red;
						}
						EditorGUILayout.LabelField(new GUIContent(sheetFile.filePath, invalid ? "File Not Found" : null),
							(GUIStyle)"AS TextArea", GUILayout.Height(20f));
						GUI.backgroundColor = cachedBgColor;
						if (GUILayout.Button("Browse", GUILayout.Width(64)))
						{
							string xmlPath = browseXmlFile("Fail to Change Xml File", sheetFile);
							if (!string.IsNullOrEmpty(xmlPath))
							{
								sheetFile.filePath = xmlPath;
								dirty = true;
							}
						}
						GUILayout.Space(2f);
						EditorGUILayout.EndHorizontal();

						EditorGUI.BeginChangeCheck();
						EditorGUILayout.BeginHorizontal();
						GUILayout.Space(20f);
						EditorGUILayout.LabelField("Type", GUILayout.Width(40f));
						GUILayout.Space(2f);
						sheetFile.typeName = EditorGUILayout.TextField(sheetFile.typeName);
						if (GUILayout.Button("ProtoGen", GUILayout.Width(64)))
						{
							string codePath;
							string dir = string.IsNullOrEmpty(sheetFile.codePath) ? null : Path.GetDirectoryName(sheetFile.codePath);
							string typeName = ProtoGen.GenerateProto(dir, out codePath);
							if (!string.IsNullOrEmpty(typeName))
							{
								sheetFile.typeName = typeName;
								sheetFile.codePath = codePath;
								dirty = true;
								AssetDatabase.Refresh();
							}
						}
						EditorGUILayout.EndHorizontal();
						if (EditorGUI.EndChangeCheck()) { dirty = true; }
					}
					if (removeXmlAt >= 0)
					{
						if (xmlSheetData.files.Length == 1)
						{
							EditorUtility.DisplayDialog("Delete Xml File in Sheet",
								"Cannot delete xml file because a sheet should contains at least one xml file !", "OK");
						}
						else
						{
							XmlSheetGroupSettings.XmlSheetFile[] newSheetFiles = new XmlSheetGroupSettings.XmlSheetFile[xmlSheetData.files.Length - 1];
							Array.Copy(xmlSheetData.files, 0, newSheetFiles, 0, removeXmlAt);
							Array.Copy(xmlSheetData.files, removeXmlAt + 1, newSheetFiles, removeXmlAt, newSheetFiles.Length - removeXmlAt);
							xmlSheetData.files = newSheetFiles;
							dirty = true;
						}
					}
					if (GUILayout.Button("Add Xml File"))
					{
						string xmlPath = browseXmlFile("Fail to Add Xml File", null);
						if (!string.IsNullOrEmpty(xmlPath))
						{
							XmlSheetGroupSettings.XmlSheetFile[] newSheetFiles = new XmlSheetGroupSettings.XmlSheetFile[xmlSheetData.files.Length + 1];
							Array.Copy(xmlSheetData.files, 0, newSheetFiles, 0, xmlSheetData.files.Length);
							XmlSheetGroupSettings.XmlSheetFile newFile = new XmlSheetGroupSettings.XmlSheetFile();
							newFile.filePath = xmlPath;
							newSheetFiles[xmlSheetData.files.Length] = newFile;
							xmlSheetData.files = newSheetFiles;
							dirty = true;
						}
					}
					//end content
					EditorGUILayout.EndVertical();
					cachedBgColor = GUI.backgroundColor;
					GUI.backgroundColor = Color.red;
					if (GUILayout.Button("Delete", GUILayout.Width(60f)))
					{
						removeAt = i;
					}
					GUI.backgroundColor = cachedBgColor;
					GUILayout.Space(4f);
					EditorGUILayout.EndHorizontal();
					GUILayout.Space(2f);
				}
				GUILayout.BeginHorizontal();
				GUILayout.Space(12f);
				cachedBgColor = GUI.backgroundColor;
				GUI.backgroundColor = Color.green;
				if (GUILayout.Button("Add New Sheet"))
				{

					XmlSheetGroupSettings.XmlSheetData[] xmlFiles = new XmlSheetGroupSettings.XmlSheetData[mCurGroup.sheetFiles.Length + 1];
					Array.Copy(mCurGroup.sheetFiles, 0, xmlFiles, 0, mCurGroup.sheetFiles.Length);
					XmlSheetGroupSettings.XmlSheetData newXml = new XmlSheetGroupSettings.XmlSheetData();
					newXml.sheetName = "new_sheet";
					newXml.comments = "new_sheet";
					newXml.files = new XmlSheetGroupSettings.XmlSheetFile[] { new XmlSheetGroupSettings.XmlSheetFile() };
					xmlFiles[mCurGroup.sheetFiles.Length] = newXml;
					mCurGroup.sheetFiles = xmlFiles;
					dirty = true;
				}
				GUILayout.EndHorizontal();
				if (removeAt >= 0)
				{
					XmlSheetGroupSettings.XmlSheetData[] xmlFiles = new XmlSheetGroupSettings.XmlSheetData[mCurGroup.sheetFiles.Length - 1];
					Array.Copy(mCurGroup.sheetFiles, 0, xmlFiles, 0, removeAt);
					Array.Copy(mCurGroup.sheetFiles, removeAt + 1, xmlFiles, removeAt, xmlFiles.Length - removeAt);
					mCurGroup.sheetFiles = xmlFiles;
					dirty = true;
				}
				GUI.backgroundColor = cachedBgColor;

				EditorGUILayout.EndScrollView();
				GUILayout.Space(8f);

				EditorGUI.BeginDisabledGroup(!isValid);
				if (GUILayout.Button("Generate Binary File", GUILayout.Height(32f)))
				{
					Generate();
				}
				EditorGUI.EndDisabledGroup();
			}
			GUILayout.Space(4f);
			if (dirty)
			{
				ConfigSettings.WriteXmlSheetGroupSettings(mSettingsList);
			}
			EditorGUI.EndDisabledGroup();
		}

		void Generate()
		{
			try
			{
				XmlSheetSerializer.GenerateGroupBinaryFile(mCurGroup);
				AssetDatabase.Refresh();
				EditorUtility.DisplayDialog("XmlSheet Serializer", string.Format("'{0}' finished !", mCurGroup.group), "OK");
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				EditorUtility.DisplayDialog("Xml Serialize Failed !", "See console for more details.\n\n" + e.Message, "OK");
			}
		}

		private string browseXmlFile(string errorTitle, XmlSheetGroupSettings.XmlSheetFile ignoredFile)
		{
			bool showDialog = !string.IsNullOrEmpty(errorTitle);
			string xmlPath = EditorUtility.OpenFilePanel("Select Xml File", ".", "xml");
			if (string.IsNullOrEmpty(xmlPath)) { return null; }
			string filename = Path.GetFileNameWithoutExtension(xmlPath);
			for (int i = 0, imax = mCurGroup.sheetFiles.Length; i < imax; i++)
			{
				XmlSheetGroupSettings.XmlSheetFile[] files = mCurGroup.sheetFiles[i].files;
				for (int j = 0, jmax = files.Length; j < jmax; j++)
				{
					XmlSheetGroupSettings.XmlSheetFile file = files[j];
					if (file == null) { continue; }
					if (ignoredFile != null && ignoredFile == file) { continue; }
					if (filename == Path.GetFileNameWithoutExtension(file.filePath))
					{
						if (showDialog)
						{
							EditorUtility.DisplayDialog(errorTitle, "An Xml file with the same file names is already existed!", "Got it");
						}
						return null;
					}
				}
			}
			if (!xmlPath.StartsWith(projectPath))
			{
				return xmlPath;
			}
			return xmlPath.Substring(projectPath.Length);
		}

		void OnFocus()
		{
			if (mSettingsList == null)
			{
				mSettingsList = ConfigSettings.ReadXmlSheetGroupSettings();
				mSelectedGroupId = -1;
				if (mSettingsList.Count > 0)
				{
					mCurGroup = mSettingsList[0];
					mSelectedGroupId = 1;
				}
				InitGroupOptions();
			}
			mInvalidFiles.Clear();
			if (mCurGroup != null)
			{
				for (int i = 0, imax = mCurGroup.sheetFiles.Length; i < imax; i++)
				{
					XmlSheetGroupSettings.XmlSheetFile[] files = mCurGroup.sheetFiles[i].files;
					for (int j = 0, jmax = files.Length; j < jmax; j++)
					{
						XmlSheetGroupSettings.XmlSheetFile file = files[j];
						if (file == null) { continue; }
						string xmlFile = file.filePath;
						if (!File.Exists(xmlFile))
						{
							mInvalidFiles.Add(xmlFile);
						}
					}
				}
			}
		}

		bool IsGroupNameValid(string group)
		{
			int count = 0;
			for (int i = 0, imax = mSettingsList.Count; i < imax; i++)
			{
				if (mSettingsList[i].group == group) { count++; }
			}
			return count < 1;
		}

		int InitGroupOptions()
		{
			mGroupIds = new int[mSettingsList.Count + 1];
			mGroupNames = new string[mSettingsList.Count + 1];
			mGroupIds[0] = 0;
			mGroupNames[0] = "Create New Xml Group";
			for (int i = 1, imax = mSettingsList.Count; i <= imax; i++)
			{
				mGroupIds[i] = i;
				mGroupNames[i] = mSettingsList[i - 1].group;
			}
			return mSettingsList.Count;
		}

		int DeleteGroup(int groupId)
		{
			mSettingsList.RemoveAt(groupId - 1);
			int ret = Mathf.Min(InitGroupOptions(), groupId);
			return ret <= 0 ? -1 : ret;
		}

		private static bool toggle_left_inited = false;
		private static MethodInfo toggle_left = null;
		static bool DrawToggle(string label, bool value)
		{
			//return EditorGUILayout.ToggleLeft(label, value);
			if (!toggle_left_inited)
			{
				toggle_left = typeof(EditorGUILayout).GetMethod("ToggleLeft",
					new System.Type[] { typeof(string), typeof(bool), typeof(GUILayoutOption[]) });
				toggle_left_inited = true;
			}
			if (toggle_left != null)
			{
				return (bool)toggle_left.Invoke(null, new object[] { label, value, new GUILayoutOption[0] });
			}
			EditorGUILayout.BeginHorizontal();
			value = EditorGUILayout.Toggle(value, GUILayout.Width(16f));
			EditorGUILayout.LabelField(label);
			EditorGUILayout.EndHorizontal();
			return value;
		}
	}

}
