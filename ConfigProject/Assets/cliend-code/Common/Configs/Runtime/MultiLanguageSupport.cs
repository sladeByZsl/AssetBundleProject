
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：MultiLanguageSupport.cs;
	作	者：jiabin;
	时	间：2016 - 05 - 09;
	注	释：;
**************************************************************************************************/

using System.Collections;

namespace FunPlus.Common.Config
{

	/// <summary>
	/// 用于实现配置内文本的多语言支持
	/// </summary>
	public static class MultiLanguageSupport
	{

		/// <summary>
		/// 定义多语言转换的方法委托
		/// </summary>
		/// <param name="key">字符串的键</param>
		/// <param name="cache">该字符串可否被暂存（若读取到的字符串有动态成分，需要将该值设置为true）</param>
		/// <returns></returns>
		public delegate string GetStringDelegate(string key, out bool cache);

        public static GetStringDelegate sGetString = null;
		private static bool sLockDelegate = false;
		
		/// <summary>
		/// 设置多语音转换方法，需要在使用多语言前调用
		/// </summary>
		/// <param name="func">多语音转换方法</param>
		/// <param name="noLongerChanged">是否标记转换方法不再被修改</param>
		/// <returns>经过转换的多语言字符串</returns>
		public static bool SetGetString(GetStringDelegate func, bool noLongerChanged)
		{
			if (sLockDelegate) { return false; }
			sGetString = func;
			sLockDelegate = noLongerChanged;
			return true;
		}

		internal static string GetString(string key, out bool cache)
		{
            if(string.IsNullOrEmpty(key) || key[0] != '#')
            {
                cache = false;
                return key;
            }
			if (sGetString != null)
			{
				return sGetString(key, out cache);
			}
			cache = false;
			return key;
		}

	}

#if UNITY_EDITOR
	public class MultiLanguageAttribute : System.Attribute { }
#endif

}