
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：XmlSerializerUI.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 14;
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

	public class XmlSerializerUI : EditorWindow
	{

		//[MenuItem("FunPlus/Configs/Xml Serializer", false, 3)]
		static void OpenSettings()
		{
			XmlSerializerUI window = GetWindow<XmlSerializerUI>("XmlSerializer");
			window.minSize = new Vector2(400f, 300f);
		}

		//[MenuItem("FunPlus/Configs/Serialize All Xmls", false, 3)]
		static void SerializeAllXmls()
		{
			List<XmlGroupSettings> groups = ConfigSettings.ReadXmlGroupSettings();
			try
			{
				List<string> gs = new List<string>();
				for (int i = 0, imax = groups.Count; i < imax; i++)
				{
					XmlGroupSettings group = groups[i];
					XmlSerializer.SerializeXmls(group);
					gs.Add(group.group);
				}
				AssetDatabase.Refresh();
				EditorUtility.DisplayDialog("Xml Serializer", "Xmls Serializer !\n" + string.Join("\n", gs.ToArray()), "OK");
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				EditorUtility.DisplayDialog("Xml Serialize Failed !", "See console for more details.\n\n" + e.Message, "OK");
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

		List<XmlGroupSettings> mSettingsList;

		Vector2 mScrollPos = Vector2.zero;

		XmlGroupSettings mCurGroup;
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
			EditorGUILayout.LabelField("Xml Group", GUILayout.Width(100f));
			int selectedGroupId = EditorGUILayout.Popup(mSelectedGroupId, mGroupNames);
			if (selectedGroupId == 0)
			{
				string groupName = EditorUtilityFix.SaveFilePanel("Set Binary Data Path", ".", "new_xml_group", "dat");
				if (!string.IsNullOrEmpty(groupName))
				{
					if (IsGroupNameValid(groupName))
					{
						mCurGroup = new XmlGroupSettings();
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
				EditorGUILayout.LabelField("Xml Files:");
				int removeAt = -1;
				for (int i = 0, imax = mCurGroup.xmlFiles.Length; i < imax; i++)
				{
					XmlGroupSettings.XmlData xmlData = mCurGroup.xmlFiles[i];
					EditorGUILayout.BeginHorizontal(GUILayout.MinHeight(20f));
					GUILayout.Space(12f);
					//start content
					cachedBgColor = GUI.backgroundColor;
					GUI.backgroundColor = (i & 1) == 0 ? new Color(0.6f, 0.6f, 0.7f) : new Color(0.8f, 0.8f, 0.8f);
					EditorGUILayout.BeginVertical((GUIStyle)"AS TextArea", GUILayout.MinHeight(20f));
					GUI.backgroundColor = cachedBgColor;
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField("Comment", GUILayout.Width(60f));
					string comments = EditorGUILayout.TextField(xmlData.comments);
					if (comments != xmlData.comments)
					{
						xmlData.comments = comments;
						dirty = true;
					}
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.BeginHorizontal(GUILayout.MinHeight(20f));
					GUILayout.Space(2f);
					bool invalid = mInvalidFiles.Contains(xmlData.path);
					cachedBgColor = GUI.backgroundColor;
					if (invalid)
					{
						GUI.backgroundColor = Color.red;
					}
					EditorGUILayout.LabelField(new GUIContent(xmlData.path, invalid ? "File Not Found" : null),
						(GUIStyle)"AS TextArea", GUILayout.Height(20f));
					GUI.backgroundColor = cachedBgColor;
					if (GUILayout.Button("Browse", GUILayout.Width(64)))
					{
						string xmlPath = browseXmlFile("Fail to Change Xml File", i);
						if (!string.IsNullOrEmpty(xmlPath))
						{
							if (xmlData.comments == xmlData.path)
							{
								xmlData.comments = xmlPath;
							}
							xmlData.path = xmlPath;
							dirty = true;
						}
					}
					GUILayout.Space(2f);
					EditorGUILayout.EndHorizontal();
					EditorGUI.BeginChangeCheck();
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField("Type", GUILayout.Width(60f));
					xmlData.typeName = EditorGUILayout.TextField(xmlData.typeName);
					if (GUILayout.Button("ProtoGen", GUILayout.Width(64)))
					{
						string codePath;
						string typeName = ProtoGen.GenerateProto(Path.GetDirectoryName(xmlData.codePath), out codePath);
						if (!string.IsNullOrEmpty(typeName))
						{
							xmlData.typeName = typeName;
							xmlData.codePath = codePath;
							dirty = true;
							AssetDatabase.Refresh();
						}
					}
					EditorGUILayout.EndHorizontal();
					if (EditorGUI.EndChangeCheck()) { dirty = true; }
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
				if (GUILayout.Button("Add Xml File"))
				{
					string xmlPath = browseXmlFile("Fail to Add Xml File", -1);
					if (!string.IsNullOrEmpty(xmlPath))
					{
						XmlGroupSettings.XmlData[] xmlFiles = new XmlGroupSettings.XmlData[mCurGroup.xmlFiles.Length + 1];
						System.Array.Copy(mCurGroup.xmlFiles, 0, xmlFiles, 0, mCurGroup.xmlFiles.Length);
						XmlGroupSettings.XmlData newXml = new XmlGroupSettings.XmlData();
						newXml.comments = xmlPath;
						newXml.path = xmlPath;
						xmlFiles[mCurGroup.xmlFiles.Length] = newXml;
						mCurGroup.xmlFiles = xmlFiles;
						dirty = true;
					}
				}
				GUILayout.EndHorizontal();
				if (removeAt >= 0)
				{
					XmlGroupSettings.XmlData[] xmlFiles = new XmlGroupSettings.XmlData[mCurGroup.xmlFiles.Length - 1];
					System.Array.Copy(mCurGroup.xmlFiles, 0, xmlFiles, 0, removeAt);
					System.Array.Copy(mCurGroup.xmlFiles, removeAt + 1, xmlFiles, removeAt, xmlFiles.Length - removeAt);
					mCurGroup.xmlFiles = xmlFiles;
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
				ConfigSettings.WriteXmlGroupSettings(mSettingsList);
			}
			EditorGUI.EndDisabledGroup();
		}

		void Generate()
		{
			try
			{
				XmlSerializer.SerializeXmls(mCurGroup);
				AssetDatabase.Refresh();
				EditorUtility.DisplayDialog("Xml Serializer", string.Format("'{0}' finished !", mCurGroup.group), "OK");
			}
			catch (Exception e)
			{
				Debug.LogException(e);
				EditorUtility.DisplayDialog("Xml Serialize Failed !", "See console for more details.\n\n" + e.Message, "OK");
			}
		}

		private string browseXmlFile(string errorTitle, int ignoreIndex)
		{
			bool showDialog = !string.IsNullOrEmpty(errorTitle);
			string xmlPath = EditorUtility.OpenFilePanel("Select Xml File", ".", "xml");
			if (string.IsNullOrEmpty(xmlPath)) { return null; }
			string filename = Path.GetFileNameWithoutExtension(xmlPath);
			for (int i = 0, imax = mCurGroup.xmlFiles.Length; i < imax; i++)
			{
				if (ignoreIndex == i) { continue; }
				if (filename == Path.GetFileNameWithoutExtension(mCurGroup.xmlFiles[i].path))
				{
					if (showDialog)
					{
						EditorUtility.DisplayDialog(errorTitle, "An Xml file with the same file names is already existed!", "Got it");
					}
					return null;
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
				mSettingsList = ConfigSettings.ReadXmlGroupSettings();
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
				for (int i = 0, imax = mCurGroup.xmlFiles.Length; i < imax; i++)
				{
					string xmlFile = mCurGroup.xmlFiles[i].path;
					if (!File.Exists(xmlFile))
					{
						mInvalidFiles.Add(xmlFile);
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
