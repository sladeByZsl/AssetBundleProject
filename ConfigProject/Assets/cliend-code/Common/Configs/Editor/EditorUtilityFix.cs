
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：EditorUtilityFix.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 27;
	注	释：;
**************************************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Reflection;

namespace FunPlus.Common.Config
{

	public static class EditorUtilityFix
	{

		/// <summary>
		/// 打开存储文件窗口，获取目标路径。若在工程内部，则返回相对路径。
		/// </summary>
		/// <param name="title">提示框标题</param>
		/// <param name="directory">默认文件夹路径</param>
		/// <param name="defaultName">默认文件名</param>
		/// <param name="extension">文件扩展名</param>
		/// <returns></returns>
		public static string SaveFilePanel(string title, string directory, string defaultName, string extension)
		{
			string path = EditorUtility.SaveFilePanel(title, directory, defaultName, extension);
			if (string.IsNullOrEmpty(path)) { return path; }
			string projPath = Application.dataPath;
			projPath = projPath.Substring(0, projPath.Length - 6);
			if (path.StartsWith(projPath))
			{
				return path.Substring(projPath.Length);
			}
			return path;
		}

	}

}