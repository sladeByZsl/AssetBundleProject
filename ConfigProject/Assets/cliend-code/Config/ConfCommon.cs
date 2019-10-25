using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FunPlus.Common.Config
{

    /// <summary>
    /// 角色骨点类型
    /// </summary>
    [ProtoBuf.ProtoContract]
    [System.Xml.Serialization.XmlType(@"EStickBone")]
    public enum EStickBone
    {
        [ProtoBuf.ProtoEnum(Name = @"Head", Value = 0)]
        [System.Xml.Serialization.XmlEnum(@"Head")]
        Head = 0,

        [ProtoBuf.ProtoEnum(Name = @"Chest", Value = 1)]
        [System.Xml.Serialization.XmlEnum(@"Chest")]
        Chest = 1,

        [ProtoBuf.ProtoEnum(Name = @"LeftHand", Value = 2)]
        [System.Xml.Serialization.XmlEnum(@"LeftHand")]
        LeftHand = 2,

        [ProtoBuf.ProtoEnum(Name = @"RightHand", Value = 3)]
        [System.Xml.Serialization.XmlEnum(@"RightHand")]
        RightHand = 3,

        [ProtoBuf.ProtoEnum(Name = @"LeftArm", Value = 4)]
        [System.Xml.Serialization.XmlEnum(@"LeftArm")]
        LeftArm = 4,

        [ProtoBuf.ProtoEnum(Name = @"RightArm", Value = 5)]
        [System.Xml.Serialization.XmlEnum(@"RightArm")]
        RightArm = 5,

        [ProtoBuf.ProtoEnum(Name = @"LeftLeg", Value = 6)]
        [System.Xml.Serialization.XmlEnum(@"LeftLeg")]
        LeftLeg = 6,

        [ProtoBuf.ProtoEnum(Name = @"RightLeg", Value = 7)]
        [System.Xml.Serialization.XmlEnum(@"RightLeg")]
        RightLeg = 7,

        [ProtoBuf.ProtoEnum(Name = @"LeftFoot", Value = 8)]
        [System.Xml.Serialization.XmlEnum(@"LeftFoot")]
        LeftFoot = 8,

        [ProtoBuf.ProtoEnum(Name = @"RightFoot", Value = 9)]
        [System.Xml.Serialization.XmlEnum(@"RightFoot")]
        RightFoot = 9,

        [ProtoBuf.ProtoEnum(Name = @"LeftHorm", Value = 10)]
        [System.Xml.Serialization.XmlEnum(@"LeftHorm")]
        LeftHorm = 10,

        [ProtoBuf.ProtoEnum(Name = @"RightHorm", Value = 11)]
        [System.Xml.Serialization.XmlEnum(@"RightHorm")]
        RightHorm = 11,

        [ProtoBuf.ProtoEnum(Name = @"LeftEye", Value = 12)]
        [System.Xml.Serialization.XmlEnum(@"LeftEye")]
        LeftEye = 12,

        [ProtoBuf.ProtoEnum(Name = @"RightEye", Value = 13)]
        [System.Xml.Serialization.XmlEnum(@"RightEye")]
        RightEye = 13,

        [ProtoBuf.ProtoEnum(Name = @"Tail", Value = 14)]
        [System.Xml.Serialization.XmlEnum(@"Tail")]
        Tail = 14,

        [ProtoBuf.ProtoEnum(Name = @"NB_StickBone", Value = 15)]
        [System.Xml.Serialization.XmlEnum(@"NB_StickBone")]
        NB_StickBone = 15,

        /// <summary>
        ///  这两个加的比较急,先如此吧;
        /// --------------------------------------------------------
        /// </summary>
        [ProtoBuf.ProtoEnum(Name = @"Foot", Value = 16)]
        [System.Xml.Serialization.XmlEnum(@"Foot")]
        Foot = 16,

        /// <summary>
        ///  这两个加的比较急,先如此吧;
        /// --------------------------------------------------------
        /// </summary>
        [ProtoBuf.ProtoEnum(Name = @"FootBip", Value = 17)]
        [System.Xml.Serialization.XmlEnum(@"FootBip")]
        FootBip = 17,

        [ProtoBuf.ProtoEnum(Name = @"Damage01_UI", Value = 18)]
        [System.Xml.Serialization.XmlEnum(@"Damage01_UI")]
        Damage01_UI = 18,

        [ProtoBuf.ProtoEnum(Name = @"Head01_UI", Value = 19)]
        [System.Xml.Serialization.XmlEnum(@"Head01_UI")]
        Head01_UI = 19,

        [ProtoBuf.ProtoEnum(Name = @"Hit01_UI", Value = 20)]
        [System.Xml.Serialization.XmlEnum(@"Hit01_UI")]
        Hit01_UI = 20,

        [ProtoBuf.ProtoEnum(Name = @"DropPoint", Value = 21)]
        [System.Xml.Serialization.XmlEnum(@"DropPoint")]
        DropPoint = 21,

        [ProtoBuf.ProtoEnum(Name = @"Wing", Value = 22)]
        [System.Xml.Serialization.XmlEnum(@"Wing")]
        Wing = 22,

        [ProtoBuf.ProtoEnum(Name = @"ExtraHair", Value = 23)]
        [System.Xml.Serialization.XmlEnum(@"ExtraHair")]
        ExtraHair = 23,

        [ProtoBuf.ProtoEnum(Name = @"ExtraLeftShoulder", Value = 24)]
        [System.Xml.Serialization.XmlEnum(@"ExtraLeftShoulder")]
        ExtraLeftShoulder = 24,

        [ProtoBuf.ProtoEnum(Name = @"ExtraRightShoulder", Value = 25)]
        [System.Xml.Serialization.XmlEnum(@"ExtraRightShoulder")]
        ExtraRightShoulder = 25,

        [ProtoBuf.ProtoEnum(Name = @"ExtraLeftWaist", Value = 26)]
        [System.Xml.Serialization.XmlEnum(@"ExtraLeftWaist")]
        ExtraLeftWaist = 26,

        [ProtoBuf.ProtoEnum(Name = @"ExtraRightWaist", Value = 27)]
        [System.Xml.Serialization.XmlEnum(@"ExtraRightWaist")]
        ExtraRightWaist = 27,

        [ProtoBuf.ProtoEnum(Name = @"ExtraCentreBack", Value = 28)]
        [System.Xml.Serialization.XmlEnum(@"ExtraCentreBack")]
        ExtraCentreBack = 28,

        [ProtoBuf.ProtoEnum(Name = @"ExtraLeftBack", Value = 29)]
        [System.Xml.Serialization.XmlEnum(@"ExtraLeftBack")]
        ExtraLeftBack = 29,

        [ProtoBuf.ProtoEnum(Name = @"ExtraRightBack", Value = 30)]
        [System.Xml.Serialization.XmlEnum(@"ExtraRightBack")]
        ExtraRightBack = 30,

        [ProtoBuf.ProtoEnum(Name = @"ExtraCentreWaistBack", Value = 31)]
        [System.Xml.Serialization.XmlEnum(@"ExtraCentreWaistBack")]
        ExtraCentreWaistBack = 31,

        [ProtoBuf.ProtoEnum(Name = @"ExtraLeftWaistBack", Value = 32)]
        [System.Xml.Serialization.XmlEnum(@"ExtraLeftWaistBack")]
        ExtraLeftWaistBack = 32,

        [ProtoBuf.ProtoEnum(Name = @"ExtraRightWaistBack", Value = 33)]
        [System.Xml.Serialization.XmlEnum(@"ExtraRightWaistBack")]
        ExtraRightWaistBack = 33,

        [ProtoBuf.ProtoEnum(Name = @"fx_WeaponL01", Value = 34)]
        [System.Xml.Serialization.XmlEnum(@"fx_WeaponL01")]
        fx_WeaponL01 = 34,

        [ProtoBuf.ProtoEnum(Name = @"fx_WeaponR01", Value = 35)]
        [System.Xml.Serialization.XmlEnum(@"fx_WeaponR01")]
        fx_WeaponR01 = 35,

        [ProtoBuf.ProtoEnum(Name = @"Foot01_UI", Value = 36)]
        [System.Xml.Serialization.XmlEnum(@"Foot01_UI")]
        Foot01_UI = 36,

        [ProtoBuf.ProtoEnum(Name = @"Blood_UI", Value = 37)]
        [System.Xml.Serialization.XmlEnum(@"Blood_UI")]
        Blood_UI = 37,

        [ProtoBuf.ProtoEnum(Name = @"MaxCount", Value = 38)]
        [System.Xml.Serialization.XmlEnum(@"MaxCount")]
        MaxCount = 38
    }

    /// <summary>
	///  角色属性
	/// </summary>
	[ProtoBuf.ProtoContract]
    [System.Xml.Serialization.XmlType(@"EColor")]
    public enum EColor
    {
        [ProtoBuf.ProtoEnum(Name = @"Color_None", Value = 0)]
        [System.Xml.Serialization.XmlEnum(@"Color_None")]
        Color_None = 0,

        [ProtoBuf.ProtoEnum(Name = @"Color_Yellow", Value = 1)]
        [System.Xml.Serialization.XmlEnum(@"Color_Yellow")]
        Color_Yellow = 1,

        [ProtoBuf.ProtoEnum(Name = @"Color_Red", Value = 2)]
        [System.Xml.Serialization.XmlEnum(@"Color_Red")]
        Color_Red = 2,

        [ProtoBuf.ProtoEnum(Name = @"Color_Purple", Value = 3)]
        [System.Xml.Serialization.XmlEnum(@"Color_Purple")]
        Color_Purple = 3,

        [ProtoBuf.ProtoEnum(Name = @"Color_Green", Value = 4)]
        [System.Xml.Serialization.XmlEnum(@"Color_Green")]
        Color_Green = 4,

        [ProtoBuf.ProtoEnum(Name = @"Color_Blue", Value = 5)]
        [System.Xml.Serialization.XmlEnum(@"Color_Blue")]
        Color_Blue = 5
    }

    [ProtoBuf.ProtoContract]
    [System.Xml.Serialization.XmlType(@"ELanguage")]
    public enum ELanguage
    {
        [ProtoBuf.ProtoEnum(Name = @"Unknown", Value = 0)]
        [System.Xml.Serialization.XmlEnum(@"Unknown")]
        Unknown = 0,

        [ProtoBuf.ProtoEnum(Name = @"Chinese", Value = 1)]
        [System.Xml.Serialization.XmlEnum(@"Chinese")]
        Chinese = 1,

        [ProtoBuf.ProtoEnum(Name = @"English", Value = 2)]
        [System.Xml.Serialization.XmlEnum(@"English")]
        English = 2
    }

    public enum AssetPathType
    {
        Type_Default,   // 只有使用Default时，才有可能使用Resources加载;

        Type_StreamingAssets,   // StreamingAssets文件夹;		
        Type_StreamingAssetsBundle, // StreamingAssets文件夹下存放Bundle的根目录;	
        Type_Local, // 本地路径;
        Type_LocalBundle,   // 本地路径存放Bundle的根目录;

        Type_RunAssets, // 为了以后可能存在的优化使用（优先使用local，没有则使用streamingassets）;
    }

}
