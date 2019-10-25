
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：CodeReader.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 14;
	注	释：;
**************************************************************************************************/

using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

namespace FunPlus.Common.Config
{

	/// <summary>
	/// 屏蔽注释，并实现逐个字符读取
	/// </summary>
	public class CodeReader
	{

		private const int MAX_PEEK_TIMES_PER_NEXT = 10000;			//为避免可能的死循环，限定同一个位置Peek的最大次数;
		private const int BUFFER_SIZE = 256;

		private TextReader mReader;
		private char[] mBuffer = new char[BUFFER_SIZE];
		private int mBufferIndex = -1;
		private int mBufferLength = 0;
		private int mLineCount = 1;
		private int mColumn = 0;
		private bool mCanPeek = false;
		private int mPeekCount = -1;

		private bool mIsEmptyLine = true;
		private StringBuilder mLastComments = new StringBuilder();

		/// <summary>
		/// CodeReader构造函数
		/// </summary>
		/// <param name="reader">输入的字符流（StreamReader or StringReader）</param>
		public CodeReader(TextReader reader)
		{
			mReader = reader;
		}

		/// <summary>
		/// 上一行的注释（独占一行的注释，非行尾注释）
		/// </summary>
		public string LastComment { get { return mLastComments.Length > 0 ? mLastComments.ToString() : null; } }

		/// <summary>
		/// 当前的字符所在的行
		/// </summary>
		public int LineCount { get { return mLineCount; } }

		/// <summary>
		/// 当前的字符所在的列
		/// </summary>
		public int Column { get { return mColumn; } }

		/// <summary>
		/// 将当前位置移到下一个非注释的字符处
		/// </summary>
		/// <returns>能否读取下一个字符</returns>
		public bool Next()
		{
			mPeekCount = MAX_PEEK_TIMES_PER_NEXT;
			if (!MoveToNext()) { return false; }
			char chr = Peek();
			switch (chr)
			{
				case '/':
					int nextChar = NextChar();
					if (nextChar >= 0)
					{
						char nc = (char)nextChar;
						if (nc == '/')
						{
							if (mIsEmptyLine && mLastComments.Length > 0) { mLastComments.Append('\n'); }
							MoveToNext();
							while (MoveToNext())
							{
								if (Peek() == '\n') { return true; }
								if (mIsEmptyLine) { mLastComments.Append(Peek()); }
							}
						}
						else if (nc == '*')
						{
							if (MoveToNext() && MoveToNext())
							{
								char lc = Peek();
								while (MoveToNext())
								{
									char cc = Peek();
									if (lc == '*' && cc == '/') { return MoveToNext(); }
									if (mIsEmptyLine) { mLastComments.Append(lc); }
									lc = cc;
								}
								return false;
							}
							else
							{
								return false;
							}
						}
					}
					break;
				case ' ':
				case '\t':
				case '\r':
					break;
				case '\n':
					if (!mIsEmptyLine)
					{
						mLastComments.Length = 0;
					}
					mIsEmptyLine = true;
					break;
				default:
					mIsEmptyLine = false;
					break;
			}
			return true;
		}

		/// <summary>
		/// 能否从当前位置读取字符，表示是否没有读取完所有字符
		/// </summary>
		/// <returns>能否从当前位置读取</returns>
		public bool CanPeek()
		{
			return mCanPeek;
		}

		/// <summary>
		/// 读取当前位置的字符
		/// </summary>
		/// <returns>当前位置的字符</returns>
		public char Peek()
		{
			if (mPeekCount > 0)
			{
				mPeekCount--;
				if (mPeekCount <= 0)
				{
					throw new Exception("Max Peek Count reached ! check infinite loop !");
				}
			}
			if (!mCanPeek)
			{
				throw new Exception("No char to peek !");
			}
			return mBuffer[mBufferIndex];
		}

		private bool MoveToNext()
		{
			mCanPeek = true;
			mBufferIndex++;
			if (mBufferIndex >= mBufferLength - 1)
			{
				if (mBufferLength > mBufferIndex)
				{
					mBuffer[0] = mBuffer[mBufferLength - 1];
					mBufferLength = mReader.Read(mBuffer, 1, BUFFER_SIZE - 1) + 1;
				}
				else
				{
					mBufferLength = mReader.Read(mBuffer, 0, BUFFER_SIZE);
				}
				mBufferIndex = 0;
				if (mBufferLength <= 0) { mCanPeek = false; }
			}
			if (mCanPeek)
			{
				char chr = mBuffer[mBufferIndex];
				mColumn++;
				if (chr == '\n')
				{
					mLineCount++;
					mColumn = 0;
				}
			}
			return mCanPeek;
		}

		private int NextChar()
		{
			if (mBufferIndex + 1 >= mBufferLength)
			{
				return -1;
			}
			return mBuffer[mBufferIndex + 1];
		}

	}

}
