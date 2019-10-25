
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：DatabaseStreamReader.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 14;
	注	释：;
**************************************************************************************************/

using System.IO;
using System;


namespace FunPlus.Common.Config
{

	/// <summary>
	/// 用于从stream中读取指定数据类型的工具
	/// </summary>
	internal static class DatabaseStreamReader
	{

		private static byte[] reader_buffer = new byte[4];

		public static ushort ReadUShort(Stream stream)
		{
			stream.Read(reader_buffer, 0, 2);
			return BitConverter.ToUInt16(reader_buffer, 0);
		}

		public static int ReadInt(Stream stream)
		{
			stream.Read(reader_buffer, 0, 4);
			return BitConverter.ToInt32(reader_buffer, 0);
		}

		public static uint ReadUInt(Stream stream)
		{
			stream.Read(reader_buffer, 0, 4);
			return BitConverter.ToUInt32(reader_buffer, 0);
		}

	}

}