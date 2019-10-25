
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：XmlSheetSerializer.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 18;
	注	释：;
**************************************************************************************************/

using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using XSerializer = System.Xml.Serialization.XmlSerializer;

namespace FunPlus.Common.Config
{

    public class XmlSheetSerializer
    {

        public delegate void IdPreSerializeDelegate(uint id, Type type, ref object obj);
        public delegate void KeyPreSerializeDelegate(string key, Type type, ref object obj);

        /// <summary>
        /// 用于在将数据转成PB二进制流之前，对数据进行自定义处理
        /// </summary>
        public static IdPreSerializeDelegate OnIdPreSerialize;
        /// <summary>
        /// 用于在将数据转成PB二进制流之前，对数据进行自定义处理
        /// </summary>
        public static KeyPreSerializeDelegate OnKeyPreSerialize;

        /// <summary>
        /// 将指定的XmlSheetGroup数据序列化并生成二进制文件
        /// </summary>
        /// <param name="group">该组的所有信息</param>
        public static void GenerateGroupBinaryFile(XmlSheetGroupSettings group)
        {
            Exception exception = null;
            int num = group.sheetFiles.Length;
            byte[] bytesLen, bytesContent;
            MemoryStream tmpStream = new MemoryStream();
            FileStream stream = File.OpenWrite(group.group);
            try
            {
                //二进制文件的最前面是sheet组的名字;
                bytesContent = Encoding.UTF8.GetBytes(group.group);
                bytesLen = BitConverter.GetBytes((ushort)bytesContent.Length);
                stream.Write(bytesLen, 0, bytesLen.Length);
                stream.Write(bytesContent, 0, bytesContent.Length);

                //sheet的数量(ushort, 最多65535个);
                bytesLen = BitConverter.GetBytes((ushort)num);
                stream.Write(bytesLen, 0, bytesLen.Length);

                long offsetPos = stream.Position;
                long headPos = 4L * num + offsetPos;

                List<SheetDataIndex> indices = new List<SheetDataIndex>();
                List<long> allIndicesPos = new List<long>();
                List<SheetDataIndex> allIndices = new List<SheetDataIndex>();
                Dictionary<string, int> allTypes = new Dictionary<string, int>();

                for (int i = 0; i < num; i++)
                {
                    XmlSheetGroupSettings.XmlSheetData sheet = group.sheetFiles[i];
                    if (sheet == null) { continue; }
                    stream.Position = offsetPos;
                    bytesLen = BitConverter.GetBytes((uint)headPos);
                    stream.Write(bytesLen, 0, bytesLen.Length);
                    offsetPos += 4L;

                    stream.Position = headPos;
                    //写入头部信息。只有当生成数据之后才能得到头部信息;
                    //头部信息的起始是sheet名;
                    string sheetName = sheet.sheetName;
                    //Debug.LogError("sheet name : " + sheetName);
                    bytesContent = Encoding.UTF8.GetBytes(sheetName);
                    bytesLen = BitConverter.GetBytes((ushort)bytesContent.Length);
                    stream.Write(bytesLen, 0, bytesLen.Length);
                    stream.Write(bytesContent, 0, bytesContent.Length);

                    List<string> filePaths = new List<string>();
                    List<string> typeNames = new List<string>();
                    for (int j = 0, jmax = sheet.files.Length; j < jmax; j++)
                    {
                        filePaths.Add(sheet.files[j].filePath);
                        typeNames.Add(sheet.files[j].typeName);
                    }
                    bool strKey;
                    SerializeXmlSheet(filePaths.ToArray(), typeNames.ToArray(), indices, tmpStream, allTypes, out strKey);
                    //头部条目数量。首位表示键的类型是否为字符串（1:字符串，0:整型）;
                    uint count = (uint)indices.Count;
                    if (strKey) { count = 0x80000000 | count; }
                    bytesLen = BitConverter.GetBytes(count);
                    stream.Write(bytesLen, 0, bytesLen.Length);
                    for (int j = 0, jmax = indices.Count; j < jmax; j++)
                    {
                        SheetDataIndex idx = indices[j];
                        allIndicesPos.Add(stream.Position);
                        allIndices.Add(idx);
                        idx.Write(stream, 0L);
                    }
                    headPos = stream.Position;
                    indices.Clear();
                }
                string[] allTypeNames = new string[allTypes.Count];
                foreach (KeyValuePair<string, int> kv in allTypes)
                {
                    allTypeNames[kv.Value] = kv.Key;
                }
                bytesLen = BitConverter.GetBytes((ushort)allTypeNames.Length);
                stream.Write(bytesLen, 0, bytesLen.Length);
                for (int i = 0, imax = allTypeNames.Length; i < imax; i++)
                {
                    bytesContent = Encoding.UTF8.GetBytes(allTypeNames[i]);
                    if (bytesContent.Length > 255)
                    {
                        throw new Exception(string.Format("Type Name '{0}' is too long !", allTypeNames[i]));
                    }
                    stream.WriteByte((byte)bytesContent.Length);
                    stream.Write(bytesContent, 0, bytesContent.Length);
                }
                headPos = stream.Position;
                for (int i = 0, imax = allIndicesPos.Count; i < imax; i++)
                {
                    stream.Position = allIndicesPos[i];
                    allIndices[i].Write(stream, headPos);
                }
                stream.Position = headPos;
                byte[] buffer = new byte[4096];
                tmpStream.SetLength(tmpStream.Position);
                tmpStream.Position = 0;
                while (true)
                {
                    int len = tmpStream.Read(buffer, 0, buffer.Length);
                    if (len <= 0) { break; }
                    stream.Write(buffer, 0, len);
                }
                tmpStream.Close();
            }
            catch (Exception e)
            {
                exception = e;
            }

            stream.SetLength(stream.Position);
            stream.Flush();
            stream.Close();

            if (exception != null) { throw exception; }
        }

        private static void SerializeXmlSheet(string[] xmlPaths, string[] typeNames, IList<SheetDataIndex> indices,
            Stream stream, Dictionary<string, int> allTypes, out bool strKey)
        {
            strKey = false;
            List<Type> itemTypes = new List<Type>();
            List<int> typeIndices = new List<int>(); ;
            List<PropertyInfo> propIds = new List<PropertyInfo>();
            SortedList<uint, List<TypeAndObj>> objsInt = null;
            SortedList<string, List<TypeAndObj>> objsStr = null;
            for (int i = 0, imax = typeNames.Length; i < imax; i++)
            {
                string typeName = typeNames[i];
                Type itemType = Type.GetType(string.Format("{0},Assembly-CSharp", typeName));
                if (itemType == null)
                {
					itemType = Type.GetType(string.Format("{0},Assembly-CSharp-Editor", typeName));
					if (itemType == null)
					{
						throw new Exception(string.Format("Cannot find type '{0}' !", typeName));
					}						
                }
                int typeIndex;
                if (!allTypes.TryGetValue(typeName, out typeIndex))
                {
                    ProtoBufInheritSupport.AddType(itemType);
                    //UnityEngine.Debug.LogError(typeName);
                    typeIndex = allTypes.Count;
                    allTypes.Add(typeName, typeIndex);
                }

                PropertyInfo[] props = itemType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                PropertyInfo propId = null;

                Type protoMember = typeof(ProtoBuf.ProtoMemberAttribute);
                for (int j = 0, jmax = props.Length; j < jmax; j++)
                {
                    PropertyInfo prop = props[j];
                    ProtoBuf.ProtoMemberAttribute attr = Attribute.GetCustomAttribute(prop, protoMember) as ProtoBuf.ProtoMemberAttribute;
                    if (attr == null || attr.Tag != 1) { continue; }
                    propId = prop;
                    break;
                }
                if (propId == null)
                {
                    throw new Exception("'ProtoMember 1' is required as Id or Key property !");
                }
                if (propId.PropertyType.Equals(typeof(uint)) || propId.PropertyType.Equals(typeof(int)))
                {
                    if (objsStr != null)
                    {
                        throw new Exception("Id or Key should only be the same type in one sheet !: " + propId.Name + "  " + typeName);
                    }
                    strKey = false;
                    if (objsInt == null)
                    {
                        objsInt = new SortedList<uint, List<TypeAndObj>>();
                    }
                }
                else if (propId.PropertyType.Equals(typeof(string)))
                {
                    if (objsInt != null)
                    {
                        throw new Exception("Id or Key should only be the same type in one sheet !: " + propId.Name + "  " + typeName);
                    }
                    strKey = true;
                    if (objsStr == null)
                    {
                        objsStr = new SortedList<string, List<TypeAndObj>>();
                    }
                }
                else
                {
                    throw new Exception("Id or Key with 'ProtoMember=1' should only be int or string type !");
                }
                itemTypes.Add(itemType);
                propIds.Add(propId);
                typeIndices.Add(typeIndex);
            }

            Exception ex = null;

            for (int i = 0, imax = xmlPaths.Length; i < imax; i++)
            {
                if (ex != null) { break; }
                string xmlPath = xmlPaths[i];
                Type itemType = itemTypes[i];
                byte[] typeIndex = BitConverter.GetBytes((ushort)typeIndices[i]);
                FileStream fs = File.OpenRead(xmlPath);
                XmlReader reader = XmlReader.Create(fs);
                XSerializer x = new XSerializer(itemType);
                PropertyInfo propId = propIds[i];
                try
                {
                    while (reader.Read())
                    {
						if(reader.Name == "Root" || reader.Name == "ConfLangs" ||reader.Name == "ConfMsgCodeList")
						{
							continue;
						}
						else if (reader.Depth < 1 && reader.NodeType != XmlNodeType.Element) { continue; }


                        object obj;
                        try
                        {
                            obj = x.Deserialize(reader);
                        }
                        catch (Exception e)
                        {
                            string err = xmlPath + " (" + itemType + ") : Failed to parse \"" + reader.Name + "\"";
                            System.Xml.XmlTextReader xr = reader as System.Xml.XmlTextReader;
                            if (xr != null)
                            {
                                err += "  [" + xr.LineNumber + " row, " + xr.LinePosition + " column]";
                            }
                            UnityEngine.Debug.LogError(err + "\n" + e.ToString());
                            continue;
                        }

                        //UnityEngine.Debug.LogWarning(obj);
                        List<TypeAndObj> list;
                        if (objsInt != null)
                        {
                            uint ik = 0;
                            if (propId.PropertyType.Equals(typeof(uint)))
                            {
                                ik = (uint)propId.GetValue(obj, null);
                            }
                            else if (propId.PropertyType.Equals(typeof(int)))
                            {
                                int temp = (int)propId.GetValue(obj, null);
                                ik = (uint)temp;
                            }

                            if (objsInt.TryGetValue(ik, out list))
                            {
                                list.Add(new TypeAndObj(itemType, obj, typeIndex));
                            }
                            else
                            {
                                list = new List<TypeAndObj>();
                                list.Add(new TypeAndObj(itemType, obj, typeIndex));
                                objsInt.Add(ik, list);
                            }
                        }
                        if (objsStr != null)
                        {
                            string sk = (string)propId.GetValue(obj, null);
                            if (objsStr.TryGetValue(sk, out list))
                            {
                                list.Add(new TypeAndObj(itemType, obj, typeIndex));
                            }
                            else
                            {
                                list = new List<TypeAndObj>();
                                list.Add(new TypeAndObj(itemType, obj, typeIndex));
                                objsStr.Add(sk, list);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    objsInt = null;
                    objsStr = null;
                    ex = e;
                    if (reader is XmlTextReader)
                    {
                        XmlTextReader xr = reader as XmlTextReader;
                        string err = string.Format("Parse Xml Failed at '{0}':{1},{2}", xmlPath, xr.LineNumber, xr.LinePosition);
                        ex = new Exception(string.Concat(err, "\n\n", e.Message), e);
                    }
                }
                reader.Close();
                fs.Close();
				FunPlus.Util.CheckXML.GetInstance().Check(itemType, xmlPath, true, true);
                if (ex != null) { break; }
            }
            if (objsInt != null)
            {
                foreach (KeyValuePair<uint, List<TypeAndObj>> kv in objsInt)
                {
                    foreach (TypeAndObj to in kv.Value)
                    {
                        object obj = to.obj;
                        if (OnIdPreSerialize != null) { OnIdPreSerialize(kv.Key, to.type, ref obj); }
                        SheetDataIntIndex index = new SheetDataIntIndex(kv.Key, (int)stream.Position);
                        stream.Write(to.typeIndex, 0, to.typeIndex.Length);
                        RuntimeTypeModel.Default.SerializeWithLengthPrefix(stream, obj, to.type, ProtoBuf.PrefixStyle.Fixed32, 0);
                        indices.Add(index);
                    }
                }
            }
            if (objsStr != null)
            {
                foreach (KeyValuePair<string, List<TypeAndObj>> kv in objsStr)
                {
                    foreach (TypeAndObj to in kv.Value)
                    {
                        object obj = to.obj;
                        if (OnKeyPreSerialize != null) { OnKeyPreSerialize(kv.Key, to.type, ref obj); }
                        SheetDataStringIndex index = new SheetDataStringIndex(kv.Key, (int)stream.Position);
                        stream.Write(to.typeIndex, 0, to.typeIndex.Length);
                        RuntimeTypeModel.Default.SerializeWithLengthPrefix(stream, obj, to.type, ProtoBuf.PrefixStyle.Fixed32, 0);
                        indices.Add(index);
                    }
                }
            }
            if (ex != null) { throw ex; }
        }

        private struct TypeAndObj
        {
            public Type type;
            public object obj;
            public byte[] typeIndex;
            public TypeAndObj(Type type, object obj, byte[] typeIndex)
            {
                this.type = type;
                this.obj = obj;
                this.typeIndex = typeIndex;
            }
        }

        /// <summary>
        /// 用于暂存Sheet中条目的索引信息，并在确定了数据的偏移后，将索引信息写入流
        /// </summary>
        private abstract class SheetDataIndex
        {
            public readonly int offset;
            public SheetDataIndex(int offset)
            {
                this.offset = offset;
            }
            public void Write(Stream stream, long seg)
            {
                byte[] bytes = GetIdOrKeyBytes();
                stream.Write(bytes, 0, bytes.Length);
                bytes = BitConverter.GetBytes((int)seg + offset);
                stream.Write(bytes, 0, bytes.Length);
            }
            protected abstract byte[] GetIdOrKeyBytes();
        }

        private class SheetDataIntIndex : SheetDataIndex
        {
            public readonly uint id;
            public SheetDataIntIndex(uint id, int offset)
                : base(offset)
            {
                this.id = id;
            }
            protected override byte[] GetIdOrKeyBytes()
            {
                return BitConverter.GetBytes(id);
            }
        }

        private class SheetDataStringIndex : SheetDataIndex
        {
            public readonly string key;
            public SheetDataStringIndex(string key, int offset)
                : base(offset)
            {
                this.key = key;
            }
            protected override byte[] GetIdOrKeyBytes()
            {
                byte[] bytes = Encoding.UTF8.GetBytes(key);
                if (bytes.Length > 255)
                {
                    throw new Exception("The length of string key is limmited to 255 !");
                }
                byte[] ret = new byte[bytes.Length + 1];
                ret[0] = (byte)bytes.Length;
                Array.Copy(bytes, 0, ret, 1, bytes.Length);
                return ret;
            }
        }

    }

}
