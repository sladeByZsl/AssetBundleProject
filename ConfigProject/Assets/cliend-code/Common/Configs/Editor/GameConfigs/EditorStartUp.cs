
/**************************************************************************************************
    Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
    当前版本：1.0;
    文   件：EditorStartUp.cs;
    作   者：xiaonan;
    时   间：
    注   释：主要用于有代码改变后自动执行的代码
**************************************************************************************************/

using UnityEditor;
[InitializeOnLoad]
public class EditorStartUp
{

   static EditorStartUp()
    {
        //GameConfigEditor.SerializerConfig();
       // Debug.LogError("=======SerializerConfig On Editor Begin run=======");
    }
}

