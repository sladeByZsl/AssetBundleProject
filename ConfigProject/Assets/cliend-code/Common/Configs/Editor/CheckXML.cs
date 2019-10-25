/**************************************************************************************************
	作	者：jiabin;
	时	间：2017 - 2 - 23;
    注	释：检查xml文件是否缺失字段
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace FunPlus.Util
{
    public class CheckXML
    {
        class XmlType
        {
            public string name = string.Empty;
            public Type type;
            public Dictionary<string, XmlType> dicMembers = new Dictionary<string, XmlType>();
            public XmlType arrayElement = null;
            public XmlType parent = null;

            public XmlType()
            {

            }

            public XmlType(Type src)
            {
                Init(src);
            }

            public void Init(Type src)
            {
                Clear();
                type = src;
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    SetArrayItem(new XmlType(type.GetGenericArguments()[0]));
                }
                else
                {
                    PropertyInfo[] allProperties = type.GetProperties();
                    if (allProperties != null)
                    {
                        foreach (PropertyInfo p in allProperties)
                        {
                            Attribute[] attributes = System.Attribute.GetCustomAttributes(p);
                            if (attributes == null || attributes.Length <= 0)
                            {
                                continue;
                            }
                            string attributeName = null;
                            foreach (Attribute a in attributes)
                            {
                                if (a.GetType() == typeof(System.Xml.Serialization.XmlElementAttribute))
                                {
                                    attributeName = (a as XmlElementAttribute).ElementName;
                                    break;
                                }
                                if (a.GetType() == typeof(System.Xml.Serialization.XmlAttributeAttribute))
                                {
                                    attributeName = (a as XmlAttributeAttribute).AttributeName;
                                    break;
                                }
                                if (a.GetType() == typeof(System.Xml.Serialization.XmlEnumAttribute))
                                {
                                    attributeName = (a as XmlEnumAttribute).Name;
                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(attributeName))
                            {
                                AddMember(attributeName, new XmlType(p.PropertyType));
                            }
                        }
                    }
                }
            }

            void Clear()
            {
                name = string.Empty;
                type = typeof(XmlType);
                dicMembers.Clear();
                arrayElement = null;
                parent = null;
            }

            public string GetText()
            {
                string pre = string.Empty;
                XmlType next_parent = parent;
                while (next_parent != null)
                {
                    pre += "  ";
                    next_parent = next_parent.parent;
                }
                string text = string.Empty;
                if (!string.IsNullOrEmpty(name))
                {
                    text = pre + name + (arrayElement != null ? "[]" : "") + "\n";
                }
                if (arrayElement != null)
                {
                    return text + arrayElement.GetText();
                }
                foreach (KeyValuePair<string, XmlType> temp in dicMembers)
                {
                    if (temp.Value == null)
                    {
                        text += pre + "  null\n";
                    }
                    else
                    {
                        text += temp.Value.GetText();
                    }
                }
                return text;
            }

            public void SetArrayItem(XmlType xmlType)
            {
                if (xmlType == null)
                {
                    Debug.LogError("Error: CheckXML.SetArray() " + GetLogName() + " xmlType is null");
                    return;
                }
                if (arrayElement != null)
                {
                    Debug.LogError("Error: CheckXML.SetArray() " + GetLogName() + " already has arrayElement: " + arrayElement);
                    return;
                }
                if (dicMembers.Count > 0)
                {
                    Debug.LogError("Error: CheckXML.SetArray() " + GetLogName() + " dicMembers is not empty: " + dicMembers.Count);
                    dicMembers.Clear();
                }
                arrayElement = xmlType;
                arrayElement.parent = this;
            }

            string GetLogName()
            {
                string name = GetPathName();
                if (string.IsNullOrEmpty(name))
                {
                    name = type.ToString();
                }
                return name;
            }

            public void AddMember(string name, XmlType xmlType)
            {
                if (string.IsNullOrEmpty(name))
                {
                    Debug.LogError("Error: CheckXML.AddMember() " + GetLogName() + " name is null");
                    return;
                }
                if (xmlType == null)
                {
                    Debug.LogError("Error: CheckXML.AddMember() " + GetLogName() + " xmlType is null");
                    return;
                }
                if (dicMembers.ContainsKey(name))
                {
                    Debug.LogError("Error: CheckXML.AddMember() " + GetLogName() + " already has key: " + name);
                    return;
                }
                if (arrayElement != null)
                {
                    Debug.LogError("Error: CheckXML.AddMember() " + GetLogName() + " arrayItem is not null: " + arrayElement);
                    arrayElement = null;
                }
                dicMembers[name] = xmlType;
                xmlType.name = name;
                xmlType.parent = this;
            }

            public XmlType GetMember(string name)
            {
                if (arrayElement != null)
                {
                    return arrayElement.GetMember(name);
                }
                XmlType value = null;
                if (dicMembers.TryGetValue(name, out value))
                {
                    return value;
                }
                return null;
            }

            public XmlType RemoveMember(string name)
            {
                if (arrayElement != null)
                {
                    return arrayElement.RemoveMember(name);
                }
                XmlType type = null;
                if (dicMembers.TryGetValue(name, out type))
                {
                    dicMembers.Remove(name);
                }
                return type;
            }

            public void GetAllMembers(Dictionary<string, XmlType> allMembers)
            {
                if (arrayElement != null)
                {
                    arrayElement.GetAllMembers(allMembers);
                    return;
                }
                if (allMembers == null)
                {
                    return;
                }
                allMembers.Clear();
                foreach (KeyValuePair<string, XmlType> temp in dicMembers)
                {
                    allMembers[temp.Key] = temp.Value;
                }
            }

            public bool IsArrayElement()
            {
                if (parent != null && parent.arrayElement == this)
                {
                    return true;
                }
                return false;
            }

            public bool IsArray()
            {
                return (arrayElement != null);
            }

            public string GetPathName()
            {
                string text = name;
                XmlType nextParent = parent;
                while (nextParent != null)
                {
                    if (!nextParent.IsArrayElement())
                    {
                        text = nextParent.name + "/" + text;
                    }
                    nextParent = nextParent.parent;
                }
                return text;
            }

            public int GetDepth()
            {
                XmlType temp = parent;
                int depth = 0;
                while (temp != null)
                {
                    if (!temp.IsArrayElement())
                    {
                        ++depth;
                    }
                    temp = temp.parent;
                }
                return depth;
            }
        }

        class Node
        {
            public string name = string.Empty;
            public string value = string.Empty;
            public int LineNumber = 0;
            public int LinePosition = 0;
            public Node parent = null;
            public List<Node> listChildren = new List<Node>();

            public Node AddChild(XmlReader reader)
            {
                if (reader == null)
                {
                    Debug.LogError("reader is null");
                    return null;
                }

                Node child = new Node();
                child.Init(reader);
                child.parent = this;
                listChildren.Add(child);
                return child;
            }

            public void Init(XmlReader reader)
            {
                if (reader == null)
                {
                    Debug.LogError("reader is null");
                    return;
                }
                name = reader.Name;
                value = reader.Value;
                if (reader is XmlTextReader)
                {
                    XmlTextReader xr = reader as XmlTextReader;
                    LineNumber = xr.LineNumber;
                    LinePosition = xr.LinePosition;
                }
                else
                {
                    LineNumber = 0;
                    LinePosition = 0;
                }
            }

            string GetPosition()
            {
                string text = "  (" + LineNumber + "," + LinePosition + ")";
                return text;
            }

            public int GetDepth()
            {
                int depth = 0;
                Node temp = parent;
                while (temp != null)
                {
                    ++depth;
                    temp = temp.parent;
                }
                return depth;
            }

            public string GetText()
            {
                int depth = GetDepth();
                string pre = "";
                for (int i = 0; i < depth; ++i)
                {
                    pre += "  ";
                }
                string text = pre + name + ": " + value + GetPosition() + "\n";
                for (int i = 0; i < listChildren.Count; ++i)
                {
                    text += listChildren[i].GetText(); ;
                }
                return text;
            }

            public string GetPathName()
            {
                string text = name;
                Node temp = parent;
                while (temp != null)
                {
                    text = temp.name + "/" + text;
                    temp = temp.parent;
                }
                return text;
            }

            public string Check(XmlType xmlType, IgnoreNode ignoreNodeRoot, bool checkExtraField = false)
            {
                if (xmlType == null || ignoreNodeRoot==null)
                {
                    return string.Empty;
                }
                string error = string.Empty;
                if (xmlType.name != name)
                {
                    if (checkExtraField && !ignoreNodeRoot.IsIgnored(xmlType))
                    {
                        error += "<color=yellow>  XML多填了:  " + GetPathName() + GetPosition() + "</color>\n";
                    }
                }
                else
                {
                    Dictionary<string, XmlType> dicChildren = new Dictionary<string, XmlType>();
                    xmlType.GetAllMembers(dicChildren);
                    for (int i = 0; i < listChildren.Count; ++i)
                    {
                        Node child = listChildren[i];
                        XmlType childXmlType = xmlType.GetMember(child.name);
                        if (childXmlType == null)
                        {
                            if (checkExtraField && !ignoreNodeRoot.IsIgnored(xmlType, child.name))
                            {
                                error += "<color=yellow>  XML多填了:   " + child.GetPathName() + child.GetPosition() + "</color>\n";
                            }
                            continue;
                        }
                        dicChildren.Remove(child.name);
                        error += child.Check(childXmlType, ignoreNodeRoot, checkExtraField);
                    }
                    foreach (KeyValuePair<string, XmlType> temp in dicChildren)
                    {
                        if (!temp.Value.IsArray() && !ignoreNodeRoot.IsIgnored(temp.Value))
                        {
                            error += "<color=red>  XML少填了:   " + GetPathName() + "/" + temp.Value.name + GetPosition() + "</color>\n";
                        }
                    }
                }
                return error;
            }
        }

        class IgnoreNode
        {
            public string name;
            public IgnoreNode parent = null;
            public Dictionary<string, IgnoreNode> dicChildren = new Dictionary<string, IgnoreNode>();

            public IgnoreNode GetChild(string name, bool createIfNotExist= false)
            {
                IgnoreNode node = null;
                if (dicChildren.TryGetValue(name, out node) && node!=null)
                {
                    return node;
                }
                if(createIfNotExist)
                {
                    node = new IgnoreNode();
                    node.name = name;
                    node.parent = this;
                    dicChildren[node.name] = node;
                }
                return node;
            }
            public void Clear()
            {
                name = string.Empty;
                parent = null;
                dicChildren.Clear();
            }

            public bool Load(string fileName)
            {
                Clear();
                string text = string.Empty;
                try
                {
                    text = File.ReadAllText(fileName, System.Text.Encoding.UTF8);
                }catch(Exception)
                {
                    return false;
                }
                if (string.IsNullOrEmpty(text))
                {
                    return true;
                }
                string[] lines = text.Split(new char[] { '\r', '\n' });
                if (lines == null || lines.Length<=0)
                {
                    return true;
                }
                List<string> listLines = new List<string>();
                for (int i = 0; i < lines.Length; ++i)
                {
                    string line = lines[i].Trim(new char[] { '\r', '\n', '\t', ' ' });
                    if (string.IsNullOrEmpty(line) || line.StartsWith("//")|| line.StartsWith("--"))
                    {
                        continue;
                    }
                    listLines.Add(line);
                }
                for (int i = 0; i < listLines.Count; ++i)
                {
                    string[] nameArray = listLines[i].Split(new char[] {'\\', '/' });
                    if(nameArray==null || nameArray.Length<=0)
                    {
                        continue;
                    }
                    IgnoreNode parent = this;
                    for (int j=0; j< nameArray.Length; ++j)
                    {
                        string curName = nameArray[j].Trim(new char[] { '\r', '\n', '\t', ' ' });
                        if(string.IsNullOrEmpty(curName))
                        {
                            continue;
                        }
                        parent = parent.GetChild(curName, true);
                    }
                }
                return true;
            }

            public bool IsIgnored(XmlType type, string childName = null)
            {
                if (type == null)
                {
                    return false;
                }
                if(dicChildren.Count <= 0)
                {
                    return false;
                }
                if (GetChild("*") != null)
                {
                    return true;
                }
                List<XmlType> listXmlType = new List<XmlType>();
                XmlType cur = type;
                while (cur != null)
                {
                    if(!cur.IsArrayElement())
                    {
                        listXmlType.Insert(0, cur);
                    }
                    cur = cur.parent;
                }
                IgnoreNode parentNode = this;
                for (int i = 0; i < listXmlType.Count; ++i)
                {
                    IgnoreNode child = parentNode.GetChild(listXmlType[i].name);
                    if (child == null)
                    {
                        break;
                    }
                    parentNode = child;
                }
                if (parentNode.dicChildren.Count <= 0)
                {
                    return true;
                }
                if(!string.IsNullOrEmpty(childName))
                {
                    IgnoreNode child = parentNode.GetChild(childName);
                    if(child!=null && child.dicChildren.Count<=0)
                    {
                        //Debug.Log(type.GetPathName()+"/"+childName);
                        return true;
                    }
                }
                return false;
            }
        };

        IgnoreNode mIgnoreNodeRoot = null;

        static public CheckXML GetInstance()
        {
            if (sInstance == null)
            {
                sInstance = new CheckXML();
            }
            return sInstance;
        }
        static CheckXML sInstance = null;

        string mFileName = string.Empty;
        double mStartTime = 0.0f;

        void Clear()
        {
            mFileName = string.Empty;
            mStartTime = 0.0f;
        }

        void LogTime(string msg)
        {
#if UNITY_EDITOR
            Debug.LogError((UnityEditor.EditorApplication.timeSinceStartup - mStartTime) + " : " + msg);
#endif
        }

        public void LoadIgnoreFile()
        {
            if (mIgnoreNodeRoot == null)
            {
                mIgnoreNodeRoot = new IgnoreNode();
            }
            if (!mIgnoreNodeRoot.Load(string.Format("{0}/../config/check_xml_ignore.txt", Application.dataPath)))
            {
                mIgnoreNodeRoot = null;
            }
        }

        public void Check(Type type, string xmlPath, bool fakeRoot = false, bool checkExtraField = false)
        {
            Clear();
            if (string.IsNullOrEmpty(xmlPath) || mIgnoreNodeRoot == null)
            {
                return;
            }
#if UNITY_EDITOR
            mStartTime = UnityEditor.EditorApplication.timeSinceStartup;
#endif
            mFileName = xmlPath;
            XmlType xmlType = new XmlType(type);
            xmlType.name = type.Name;
            //if (xmlType != null)
            //{
            //    Debug.LogError(xmlType.GetText());
            //}
            //LogTime("XmlType");


            Node root = new Node();
            using (FileStream fs = File.OpenRead(xmlPath))
            {
                using (XmlReader reader = XmlReader.Create(fs))
                {
                    //LogTime("XmlReader");
                    try
                    {
                        Node currentNode = null;
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Text)
                            {
                                currentNode.value = reader.Value;
                                continue;
                            }
                            if (reader.NodeType != XmlNodeType.Element)
                            {
                                continue;
                            }
                            if (currentNode == null)
                            {
                                currentNode = root;
                                currentNode.name = reader.Name;
                                currentNode.value = reader.Value;
                            }
                            else if (reader.Depth > currentNode.GetDepth())
                            {
                                currentNode = currentNode.AddChild(reader);
                            }
                            else if (reader.Depth == currentNode.GetDepth())
                            {
                                if (currentNode.parent != null)
                                {
                                    currentNode = currentNode.parent.AddChild(reader);
                                }
                                else
                                {
                                    Debug.LogError(xmlPath + " currentNode.parent is null");
                                    break;
                                }
                            }
                            else if (reader.Depth < currentNode.GetDepth())
                            {
                                while (currentNode != null && reader.Depth <= currentNode.GetDepth())
                                {
                                    currentNode = currentNode.parent;
                                }
                                if (currentNode != null)
                                {
                                    currentNode = currentNode.AddChild(reader);
                                }
                                else
                                {
                                    Debug.LogError(xmlPath + ": currentNode.parent is null");
                                    break;
                                }
                            }
                            for (int i = 0; i < reader.AttributeCount; ++i)
                            {
                                reader.MoveToAttribute(i);
                                currentNode.AddChild(reader);
                            }
                            if (reader.AttributeCount > 0)
                            {
                                reader.MoveToElement();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string err = "Failed to parse " + xmlPath + GetPosition(reader);
                        Debug.LogException(new Exception(string.Concat(err, "\n\n", e.Message), e));
                    }
                }
            }
            //Debug.LogError(root.GetText());


            string error = string.Empty;
            if (fakeRoot)
            {
                XmlType rootXmlType = new XmlType();
                rootXmlType.name = root.name;
                rootXmlType.AddMember(xmlType.name, xmlType);
                error += root.Check(rootXmlType, mIgnoreNodeRoot, checkExtraField);
            }
            else
            {
                error += root.Check(xmlType, mIgnoreNodeRoot, checkExtraField);
            }


            if (!string.IsNullOrEmpty(error))
            {
                Debug.LogError(mFileName + " :\n" + error);
            }
            //LogTime("Finish");
        }

        string GetPosition(XmlReader reader)
        {
            if (reader is XmlTextReader)
            {
                XmlTextReader xr = reader as XmlTextReader;
                string text = "  [" + xr.LineNumber + " row, " + xr.LinePosition + " column]";
                return text;
            }
            return string.Empty;
        }
    }
}
