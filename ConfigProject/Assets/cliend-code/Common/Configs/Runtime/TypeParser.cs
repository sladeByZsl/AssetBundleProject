
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：TypeParser.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 12;
	注	释：;
**************************************************************************************************/

using System.Text.RegularExpressions;
using UnityEngine;

namespace FunPlus.Common.Config
{

	/// <summary>
	/// 为protobuf提供对Unity类型的支持
	/// </summary>
	public static class TypeParser
	{

		private static Regex reg_color32 = new Regex(@"^[A-Fa-f0-9]{8}$");
		private static Regex reg_color24 = new Regex(@"^[A-Fa-f0-9]{6}$");

		/// <summary>
		/// 去掉字符串前后的中括号（如果存在），一般用于解析定义在中括号中的数组
		/// </summary>
		/// <param name="str">可能以中括号为首尾的字符串</param>
		/// <returns>去掉中括号之后的字符串</returns>
		public static string trimBracket(string str)
		{
			if (str.StartsWith("[") && str.EndsWith("]"))
			{
				return str.Substring(1, str.Length - 2);
			}
			return str.Trim();
		}

		/// <summary>
		/// 将表示颜色的字符串解析为颜色值（RGBA8888表示的int）。支持FF0000, 00FF00FF, [0,0,255], [0,128,255,192]等形式
		/// </summary>
		/// <param name="str">表示颜色的字符串</param>
		/// <returns>颜色值（RGBA8888表示的int）</returns>
		public static int getColorFromString(string str)
		{
			int color;
			ParseColorToInt(str, out color);
			return color;
		}

		/// <summary>
		/// 将表示颜色的字符串解析为颜色值。支持FF0000, 00FF00FF, [0,0,255], [0,128,255,192]等形式
		/// </summary>
		/// <param name="str">表示颜色的字符串</param>
		/// <param name="color">颜色值</param>
		/// <returns>是否成功解析</returns>
		public static bool ParseColor(string str, out Color32 color)
		{
			int val;
			if (!ParseColorToInt(str, out val))
			{
				color = Color.clear;
				return false;
			}
			color = new Color32((byte)(val >> 24), (byte)(val >> 16), (byte)(val >> 8), (byte)val);
			return true;
		}

		/// <summary>
		/// 将表示颜色的字符串解析为颜色值（RGBA8888表示的int）。支持FF0000, 00FF00FF, [0,0,255], [0,128,255,192]等形式
		/// </summary>
		/// <param name="str">表示颜色的字符串</param>
		/// <param name="color">颜色值（RGBA8888表示的int）</param>
		/// <returns>是否成功解析</returns>
		public static bool ParseColorToInt(string str, out int color)
		{
			color = 0;
			if (string.IsNullOrEmpty(str)) { return false; }
			if (reg_color32.IsMatch(str))
			{
				color = System.Convert.ToInt32(str, 16);
				return true;
			}
			if (reg_color24.IsMatch(str))
			{
				color = (System.Convert.ToInt32(str, 16) << 8) | 0xff;
				return true;
			}
			str = trimBracket(str);
			string[] splits = str.Split(',');
			if (splits.Length == 4)
			{
				int r, g, b, a;
				if (int.TryParse(splits[0].Trim(), out r) && int.TryParse(splits[1].Trim(), out g) &&
					int.TryParse(splits[2].Trim(), out b) && int.TryParse(splits[3].Trim(), out a))
				{
					color = ((r & 0xff) << 24) | ((g & 0xff) << 16) | ((b & 0xff) << 8) | (a & 0xff);
					return true;
				}
			}
			else if (splits.Length == 3)
			{
				int r, g, b;
				if (int.TryParse(splits[0].Trim(), out r) && int.TryParse(splits[1].Trim(), out g) &&
					int.TryParse(splits[2].Trim(), out b))
				{
					color = ((r & 0xff) << 24) | ((g & 0xff) << 16) | ((b & 0xff) << 8) | 0xff;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 将表示二维向量的字符串解析为Vector2
		/// </summary>
		/// <param name="str">表示二维向量的字符串</param>
		/// <param name="value">解析后的Vector2</param>
		/// <returns>是否成功解析</returns>
		public static bool ParseVector2(string str, out Vector2 value)
		{
			if (string.IsNullOrEmpty(str))
			{
				value = Vector2.zero;
				return false;
			}
			string[] splits = TypeParser.trimBracket(str).Split(',');
			if (splits.Length != 2)
			{
				value = Vector2.zero;
				return false;
			}
			float x, y;
			if (float.TryParse(splits[0], out x) && float.TryParse(splits[1], out y))
			{
				value = new Vector2(x, y);
				return true;
			}
			value = Vector2.zero;
			return false;
		}

		/// <summary>
		/// 将表示三维向量的字符串解析为Vector3
		/// </summary>
		/// <param name="str">表示三维向量的字符串</param>
		/// <param name="value">解析后的Vector3</param>
		/// <returns>是否成功解析</returns>
		public static bool ParseVector3(string str, out Vector3 value)
		{
			if (string.IsNullOrEmpty(str))
			{
				value = Vector3.zero;
				return false;
			}
			string[] splits = TypeParser.trimBracket(str).Split(',');
			if (splits.Length != 3)
			{
				value = Vector3.zero;
				return false;
			}
			float x, y, z;
			if (float.TryParse(splits[0], out x) && float.TryParse(splits[1], out y) && float.TryParse(splits[2], out z))
			{
				value = new Vector3(x, y, z);
				return true;
			}
			value = Vector3.zero;
			return false;
		}

		/// <summary>
		/// 将表示四维向量的字符串解析为Vector4
		/// </summary>
		/// <param name="str">表示四维向量的字符串</param>
		/// <param name="value">解析后的Vector4</param>
		/// <returns>是否成功解析</returns>
		public static bool ParseVector4(string str, out Vector4 value)
		{
			if (string.IsNullOrEmpty(str))
			{
				value = Vector4.zero;
				return false;
			}
			string[] splits = TypeParser.trimBracket(str).Split(',');
			if (splits.Length != 4)
			{
				value = Vector4.zero;
				return false;
			}
			float x, y, z, w;
			if (float.TryParse(splits[0], out x) && float.TryParse(splits[1], out y) &&
				float.TryParse(splits[2], out z) && float.TryParse(splits[3], out w))
			{
				value = new Vector4(x, y, z, w);
				return true;
			}
			value = Vector4.zero;
			return false;
		}

		/// <summary>
		/// 将表示矩形（x,y,width,height）的字符串解析为Rect
		/// </summary>
		/// <param name="str">表示矩形的字符串</param>
		/// <param name="value">解析后的Rect</param>
		/// <returns>是否成功解析</returns>
		public static bool ParseRect(string str, out Rect value)
		{
			if (string.IsNullOrEmpty(str))
			{
				value = new Rect();
				return false;
			}
			string[] splits = TypeParser.trimBracket(str).Split(',');
			if (splits.Length != 4)
			{
				value = new Rect();
				return false;
			}
			float x, y, w, h;
			if (float.TryParse(splits[0], out x) && float.TryParse(splits[1], out y) &&
				float.TryParse(splits[2], out w) && float.TryParse(splits[3], out h))
			{
				value = new Rect(x, y, w, h);
				return true;
			}
			value = new Rect();
			return false;
		}

	}

}