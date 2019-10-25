
/**************************************************************************************************
	Copyright (C) 2016 - All Rights Reserved.
--------------------------------------------------------------------------------------------------------
	当前版本：1.0;
	文	件：ProtoBufInheritSupport.cs;
	作	者：jiabin;
	时	间：2016 - 04 - 14;
	注	释：;
**************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProtoBuf.Meta {

	/// <summary>
	/// 使protobuf支持继承（父类中带有ProtoMember的属性的序列化与反序列化）
	/// </summary>
	public static class ProtoBufInheritSupport
	{

		static Type type_obj = typeof(object);
		static Type type_proto_contract = typeof(ProtoContractAttribute);
		static Dictionary<Type, byte> added_types = new Dictionary<Type, byte>();

		/// <summary>
		/// 增加一个类型，使protobuf支持该类型的父类（仅带有ProtoContract的父类）中所有需要序列化的属性
		/// </summary>
		/// <param name="type">需要被支持继承的类</param>
		public static void AddType(Type type)
		{
			if (type == null) { return; }
			if (!type.IsDefined(type_proto_contract, false)) { return; }
			if (added_types.ContainsKey(type)) { return; }
			added_types.Add(type, (byte)0);
			Type bt = type;
			RuntimeTypeModel model = RuntimeTypeModel.Default;
			MemberInfo[] ms = bt.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			for (int i = 0, imax = ms.Length; i < imax; i++)
			{
				MemberInfo mi = ms[i];
				if (!Attribute.IsDefined(mi, typeof(ProtoMemberAttribute))) { continue; }
				Type mt = null;
				switch (mi.MemberType)
				{
					case MemberTypes.Field:
						mt = (mi as FieldInfo).FieldType;
						break;
					case MemberTypes.Property:
						mt = (mi as PropertyInfo).PropertyType;
						break;
				}
				if (mt == null) { continue; }
				if (mt.IsGenericType)
				{
					Type[] gt = mt.GetGenericArguments();
					for (int j = 0, jmax = gt.Length; j < jmax; j++)
					{
						AddType(gt[j]);
					}
				}
				if (mt.IsArray)
				{
					AddType(mt.GetElementType());
				}
				AddType(mt);
			}
			while (true)
			{
				bt = bt.BaseType;
				if (bt == null || bt == type_obj) { break; }
				if (!bt.IsDefined(type_proto_contract, false)) { continue; }
				ms = bt.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
				for (int i = 0, imax = ms.Length; i < imax; i++)
				{
					MemberInfo mi = ms[i];
					//if (mi.DeclaringType != bt) { continue; }
					ProtoMemberAttribute pm = Attribute.GetCustomAttribute(mi, typeof(ProtoMemberAttribute)) as ProtoMemberAttribute;
					if (pm == null) { continue; }
					try
					{
						model[type].Add(pm.Tag, mi.Name);
					}
					catch { }
					//UnityEngine.Debug.LogWarning(type + "  " + pm.Tag + "  " +mi.Name);
				}
			}
		}

	}

}
