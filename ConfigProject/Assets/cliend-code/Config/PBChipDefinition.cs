/**************************************************************************************************
                                   自动生成代码  请勿手动修改
**************************************************************************************************/

namespace FunPlus.Common.Config
{

	/// <summary>
	/// 数据字典
	/// chip 棋子
	/// cell 单元格
	/// level 关卡
	/// weight 权重
	/// grade 等级，如棋子等级
	///  棋子定义表
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipDefinition")]
	public partial class PBChipDefinition
	{

		private System.Collections.Generic.List<PBChip> _chips = new System.Collections.Generic.List<PBChip>();
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlElement(@"chips")]
		public System.Collections.Generic.List<PBChip> chips
		{
			get { return _chips; }
			set { _chips = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChipDefinition]{{chips:{0}}}",
				list2string(chips));
		}

		private string list2string(System.Collections.IList list)
		{
			int len = list.Count;
			string[] items = new string[len];
			for (int i = 0; i < len; i++)
			{
				items[i] = string.Format("{0}", list[i]);
			}
			return string.Concat("[", string.Join(", ", items), "]");
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipPropertyDefinition")]
	public partial class PBChipPropertyDefinition
	{

		private System.Collections.Generic.List<PBChipProperties> _properties = new System.Collections.Generic.List<PBChipProperties>();
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlElement(@"properties")]
		public System.Collections.Generic.List<PBChipProperties> properties
		{
			get { return _properties; }
			set { _properties = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChipPropertyDefinition]{{properties:{0}}}",
				list2string(properties));
		}

		private string list2string(System.Collections.IList list)
		{
			int len = list.Count;
			string[] items = new string[len];
			for (int i = 0; i < len; i++)
			{
				items[i] = string.Format("{0}", list[i]);
			}
			return string.Concat("[", string.Join(", ", items), "]");
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipDestroyPrioritys")]
	public partial class PBChipDestroyPrioritys
	{

		private System.Collections.Generic.List<PBChipDestroyPriority> _prioritys = new System.Collections.Generic.List<PBChipDestroyPriority>();
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlElement(@"prioritys")]
		public System.Collections.Generic.List<PBChipDestroyPriority> prioritys
		{
			get { return _prioritys; }
			set { _prioritys = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChipDestroyPrioritys]{{prioritys:{0}}}",
				list2string(prioritys));
		}

		private string list2string(System.Collections.IList list)
		{
			int len = list.Count;
			string[] items = new string[len];
			for (int i = 0; i < len; i++)
			{
				items[i] = string.Format("{0}", list[i]);
			}
			return string.Concat("[", string.Join(", ", items), "]");
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipShowLayers")]
	public partial class PBChipShowLayers
	{

		private System.Collections.Generic.List<PBChipShowLayer> _layers = new System.Collections.Generic.List<PBChipShowLayer>();
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlElement(@"layers")]
		public System.Collections.Generic.List<PBChipShowLayer> layers
		{
			get { return _layers; }
			set { _layers = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChipShowLayers]{{layers:{0}}}",
				list2string(layers));
		}

		private string list2string(System.Collections.IList list)
		{
			int len = list.Count;
			string[] items = new string[len];
			for (int i = 0; i < len; i++)
			{
				items[i] = string.Format("{0}", list[i]);
			}
			return string.Concat("[", string.Join(", ", items), "]");
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipGroupMap")]
	public partial class PBChipGroupMap
	{

		private System.Collections.Generic.List<string> _map = new System.Collections.Generic.List<string>();
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlElement(@"map")]
		public System.Collections.Generic.List<string> map
		{
			get { return _map; }
			set { _map = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChipGroupMap]{{map:{0}}}",
				list2string(map));
		}

		private string list2string(System.Collections.IList list)
		{
			int len = list.Count;
			string[] items = new string[len];
			for (int i = 0; i < len; i++)
			{
				items[i] = string.Format("{0}", list[i]);
			}
			return string.Concat("[", string.Join(", ", items), "]");
		}

	}

	/// <summary>
	/// 技能对应数值类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESValeType")]
	public enum ESValeType
	{
		[ProtoBuf.ProtoEnum(Name = @"ES_None", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"ES_None")]
		ES_None = 0,

		[ProtoBuf.ProtoEnum(Name = @"ES_ATK", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"ES_ATK")]
		ES_ATK = 1,

		[ProtoBuf.ProtoEnum(Name = @"ES_DEFEND", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"ES_DEFEND")]
		ES_DEFEND = 2
	}

	/// <summary>
	/// 棋子信息
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChip")]
	public partial class PBChip
	{

		private uint _chip_id = default(uint);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"chip_id")]
		public uint chip_id
		{
			get { return _chip_id; }
			set { _chip_id = value; }
		}

		private EChipType _chip_type = EChipType.CT_None;
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"chip_type")]
		public EChipType chip_type
		{
			get { return _chip_type; }
			set { _chip_type = value; }
		}

		private EColor _color = EColor.Color_None;
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"color")]
		public EColor color
		{
			get { return _color; }
			set { _color = value; }
		}

		private EBonusType _bonus_type = EBonusType.Bonus_None;
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"bonus_type")]
		public EBonusType bonus_type
		{
			get { return _bonus_type; }
			set { _bonus_type = value; }
		}

		private string _name = default(string);
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"name")]
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		private uint _block_grade = default(uint);
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"block_grade")]
		public uint block_grade
		{
			get { return _block_grade; }
			set { _block_grade = value; }
		}

		private System.Collections.Generic.List<string> _grade_resource = new System.Collections.Generic.List<string>();
		[ProtoBuf.ProtoMember(10)]
		[System.Xml.Serialization.XmlElement(@"grade_resource")]
		public System.Collections.Generic.List<string> grade_resource
		{
			get { return _grade_resource; }
			set { _grade_resource = value; }
		}

		private uint _group_index = default(uint);
		[ProtoBuf.ProtoMember(7)]
		[System.Xml.Serialization.XmlAttribute(@"group_index")]
		public uint group_index
		{
			get { return _group_index; }
			set { _group_index = value; }
		}

		private PBChipProperties _properties = null;
		[ProtoBuf.ProtoMember(9)]
		[System.Xml.Serialization.XmlElement(@"properties")]
		public PBChipProperties properties
		{
			get { return _properties; }
			set { _properties = value; }
		}

		private uint _show_layer = default(uint);
		[ProtoBuf.ProtoMember(11)]
		[System.Xml.Serialization.XmlAttribute(@"show_layer")]
		public uint show_layer
		{
			get { return _show_layer; }
			set { _show_layer = value; }
		}

		private uint _destroy_priority = default(uint);
		[ProtoBuf.ProtoMember(12)]
		[System.Xml.Serialization.XmlAttribute(@"destroy_priority")]
		public uint destroy_priority
		{
			get { return _destroy_priority; }
			set { _destroy_priority = value; }
		}

		private uint _downgrade_chip_id = default(uint);
		[ProtoBuf.ProtoMember(13)]
		[System.Xml.Serialization.XmlAttribute(@"downgrade_chip_id")]
		public uint downgrade_chip_id
		{
			get { return _downgrade_chip_id; }
			set { _downgrade_chip_id = value; }
		}

		private uint _collapsed_chip_id = default(uint);
		[ProtoBuf.ProtoMember(14)]
		[System.Xml.Serialization.XmlAttribute(@"collapsed_chip_id")]
		public uint collapsed_chip_id
		{
			get { return _collapsed_chip_id; }
			set { _collapsed_chip_id = value; }
		}

		private bool _collect_anim = default(bool);
		[ProtoBuf.ProtoMember(15)]
		[System.Xml.Serialization.XmlAttribute(@"collect_anim")]
		public bool collect_anim
		{
			get { return _collect_anim; }
			set { _collect_anim = value; }
		}

		private PBChipGrid _Echipgrid = PBChipGrid.e_None;
		[ProtoBuf.ProtoMember(16)]
		[System.Xml.Serialization.XmlAttribute(@"Echipgrid")]
		public PBChipGrid Echipgrid
		{
			get { return _Echipgrid; }
			set { _Echipgrid = value; }
		}

		private string _destroy_event_id = default(string);
		[ProtoBuf.ProtoMember(17)]
		[System.Xml.Serialization.XmlAttribute(@"destroy_event_id")]
		public string destroy_event_id
		{
			get { return _destroy_event_id; }
			set { _destroy_event_id = value; }
		}

		private string _skin = default(string);
		[ProtoBuf.ProtoMember(18)]
		[System.Xml.Serialization.XmlAttribute(@"skin")]
		public string skin
		{
			get { return _skin; }
			set { _skin = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChip]{{chip_id:{0}, chip_type:{1}, color:{2}, bonus_type:{3}, name:{4}, block_grade:{5}, grade_resource:{6}, group_index:{7}, properties:{8}, show_layer:{9}, destroy_priority:{10}, downgrade_chip_id:{11}, collapsed_chip_id:{12}, collect_anim:{13}, Echipgrid:{14}, destroy_event_id:{15}, skin:{16}}}",
				chip_id, chip_type, color, bonus_type, name, block_grade, list2string(grade_resource), group_index, properties, show_layer, destroy_priority, downgrade_chip_id, collapsed_chip_id, collect_anim, Echipgrid, destroy_event_id, skin);
		}

		private string list2string(System.Collections.IList list)
		{
			int len = list.Count;
			string[] items = new string[len];
			for (int i = 0; i < len; i++)
			{
				items[i] = string.Format("{0}", list[i]);
			}
			return string.Concat("[", string.Join(", ", items), "]");
		}

	}

	/// <summary>
	/// 棋子类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"EChipType")]
	public enum EChipType
	{
		[ProtoBuf.ProtoEnum(Name = @"CT_None", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"CT_None")]
		CT_None = 0,

		[ProtoBuf.ProtoEnum(Name = @"CT_Color", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"CT_Color")]
		CT_Color = 1,

		[ProtoBuf.ProtoEnum(Name = @"CT_Bonus", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"CT_Bonus")]
		CT_Bonus = 2,

		[ProtoBuf.ProtoEnum(Name = @"CT_Block", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"CT_Block")]
		CT_Block = 3,

		[ProtoBuf.ProtoEnum(Name = @"CT_Wall", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"CT_Wall")]
		CT_Wall = 4,

		[ProtoBuf.ProtoEnum(Name = @"CT_Portal", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"CT_Portal")]
		CT_Portal = 5,

		[ProtoBuf.ProtoEnum(Name = @"CT_PortalIn", Value = 6)]
		[System.Xml.Serialization.XmlEnum(@"CT_PortalIn")]
		CT_PortalIn = 6,

		[ProtoBuf.ProtoEnum(Name = @"CT_PortalOut", Value = 7)]
		[System.Xml.Serialization.XmlEnum(@"CT_PortalOut")]
		CT_PortalOut = 7,

		[ProtoBuf.ProtoEnum(Name = @"CT_Gravity", Value = 8)]
		[System.Xml.Serialization.XmlEnum(@"CT_Gravity")]
		CT_Gravity = 8,

		[ProtoBuf.ProtoEnum(Name = @"CT_TargetOnly", Value = 9)]
		[System.Xml.Serialization.XmlEnum(@"CT_TargetOnly")]
		CT_TargetOnly = 9,

		[ProtoBuf.ProtoEnum(Name = @"CT_BirthPoint", Value = 10)]
		[System.Xml.Serialization.XmlEnum(@"CT_BirthPoint")]
		CT_BirthPoint = 10,

		[ProtoBuf.ProtoEnum(Name = @"CT_BirthPointWeight", Value = 11)]
		[System.Xml.Serialization.XmlEnum(@"CT_BirthPointWeight")]
		CT_BirthPointWeight = 11,

		[ProtoBuf.ProtoEnum(Name = @"CT_BirthPointLoop", Value = 12)]
		[System.Xml.Serialization.XmlEnum(@"CT_BirthPointLoop")]
		CT_BirthPointLoop = 12,

		[ProtoBuf.ProtoEnum(Name = @"CT_Background", Value = 13)]
		[System.Xml.Serialization.XmlEnum(@"CT_Background")]
		CT_Background = 13,

		[ProtoBuf.ProtoEnum(Name = @"CT_Collection", Value = 14)]
		[System.Xml.Serialization.XmlEnum(@"CT_Collection")]
		CT_Collection = 14,

		[ProtoBuf.ProtoEnum(Name = @"CT_Case2x2", Value = 15)]
		[System.Xml.Serialization.XmlEnum(@"CT_Case2x2")]
		CT_Case2x2 = 15,

		[ProtoBuf.ProtoEnum(Name = @"CT_CollectionEntry", Value = 16)]
		[System.Xml.Serialization.XmlEnum(@"CT_CollectionEntry")]
		CT_CollectionEntry = 16,

		[ProtoBuf.ProtoEnum(Name = @"CT_Camera", Value = 17)]
		[System.Xml.Serialization.XmlEnum(@"CT_Camera")]
		CT_Camera = 17,

		[ProtoBuf.ProtoEnum(Name = @"CT_Area", Value = 18)]
		[System.Xml.Serialization.XmlEnum(@"CT_Area")]
		CT_Area = 18,

		[ProtoBuf.ProtoEnum(Name = @"CT_NoReshuffle", Value = 19)]
		[System.Xml.Serialization.XmlEnum(@"CT_NoReshuffle")]
		CT_NoReshuffle = 19,

		[ProtoBuf.ProtoEnum(Name = @"CT_NoMatch", Value = 20)]
		[System.Xml.Serialization.XmlEnum(@"CT_NoMatch")]
		CT_NoMatch = 20,

		[ProtoBuf.ProtoEnum(Name = @"CT_NoBoosters", Value = 21)]
		[System.Xml.Serialization.XmlEnum(@"CT_NoBoosters")]
		CT_NoBoosters = 21,

		[ProtoBuf.ProtoEnum(Name = @"CT_InitRandom", Value = 22)]
		[System.Xml.Serialization.XmlEnum(@"CT_InitRandom")]
		CT_InitRandom = 22,

		[ProtoBuf.ProtoEnum(Name = @"CT_InitGroup", Value = 23)]
		[System.Xml.Serialization.XmlEnum(@"CT_InitGroup")]
		CT_InitGroup = 23,

		[ProtoBuf.ProtoEnum(Name = @"CT_Pipe", Value = 24)]
		[System.Xml.Serialization.XmlEnum(@"CT_Pipe")]
		CT_Pipe = 24,

		[ProtoBuf.ProtoEnum(Name = @"CT_Case1x2", Value = 25)]
		[System.Xml.Serialization.XmlEnum(@"CT_Case1x2")]
		CT_Case1x2 = 25,

		[ProtoBuf.ProtoEnum(Name = @"CT_Case2x1", Value = 26)]
		[System.Xml.Serialization.XmlEnum(@"CT_Case2x1")]
		CT_Case2x1 = 26,

		[ProtoBuf.ProtoEnum(Name = @"CT_Mailbox", Value = 27)]
		[System.Xml.Serialization.XmlEnum(@"CT_Mailbox")]
		CT_Mailbox = 27,

		[ProtoBuf.ProtoEnum(Name = @"CT_RedCarpet", Value = 29)]
		[System.Xml.Serialization.XmlEnum(@"CT_RedCarpet")]
		CT_RedCarpet = 29,

		[ProtoBuf.ProtoEnum(Name = @"CT_RedCarpetPath", Value = 30)]
		[System.Xml.Serialization.XmlEnum(@"CT_RedCarpetPath")]
		CT_RedCarpetPath = 30,

		[ProtoBuf.ProtoEnum(Name = @"CT_RedCarpetEnd", Value = 62)]
		[System.Xml.Serialization.XmlEnum(@"CT_RedCarpetEnd")]
		CT_RedCarpetEnd = 62,

		[ProtoBuf.ProtoEnum(Name = @"CT_Leaves", Value = 31)]
		[System.Xml.Serialization.XmlEnum(@"CT_Leaves")]
		CT_Leaves = 31,

		[ProtoBuf.ProtoEnum(Name = @"CT_Gnomes", Value = 32)]
		[System.Xml.Serialization.XmlEnum(@"CT_Gnomes")]
		CT_Gnomes = 32,

		[ProtoBuf.ProtoEnum(Name = @"CT_Recycle", Value = 33)]
		[System.Xml.Serialization.XmlEnum(@"CT_Recycle")]
		CT_Recycle = 33,

		[ProtoBuf.ProtoEnum(Name = @"CT_Cookie", Value = 34)]
		[System.Xml.Serialization.XmlEnum(@"CT_Cookie")]
		CT_Cookie = 34,

		[ProtoBuf.ProtoEnum(Name = @"CT_Foam", Value = 35)]
		[System.Xml.Serialization.XmlEnum(@"CT_Foam")]
		CT_Foam = 35,

		[ProtoBuf.ProtoEnum(Name = @"CT_Copy", Value = 36)]
		[System.Xml.Serialization.XmlEnum(@"CT_Copy")]
		CT_Copy = 36,

		[ProtoBuf.ProtoEnum(Name = @"CT_ConveyorBelt", Value = 37)]
		[System.Xml.Serialization.XmlEnum(@"CT_ConveyorBelt")]
		CT_ConveyorBelt = 37,

		[ProtoBuf.ProtoEnum(Name = @"CT_ConveyorBeltLink", Value = 38)]
		[System.Xml.Serialization.XmlEnum(@"CT_ConveyorBeltLink")]
		CT_ConveyorBeltLink = 38,

		[ProtoBuf.ProtoEnum(Name = @"CT_Jelly", Value = 39)]
		[System.Xml.Serialization.XmlEnum(@"CT_Jelly")]
		CT_Jelly = 39,

		[ProtoBuf.ProtoEnum(Name = @"CT_Cherries", Value = 40)]
		[System.Xml.Serialization.XmlEnum(@"CT_Cherries")]
		CT_Cherries = 40,

		[ProtoBuf.ProtoEnum(Name = @"CT_Henhouse", Value = 41)]
		[System.Xml.Serialization.XmlEnum(@"CT_Henhouse")]
		CT_Henhouse = 41,

		[ProtoBuf.ProtoEnum(Name = @"CT_HairBall", Value = 42)]
		[System.Xml.Serialization.XmlEnum(@"CT_HairBall")]
		CT_HairBall = 42,

		[ProtoBuf.ProtoEnum(Name = @"CT_Letter", Value = 43)]
		[System.Xml.Serialization.XmlEnum(@"CT_Letter")]
		CT_Letter = 43,

		[ProtoBuf.ProtoEnum(Name = @"CT_Fox", Value = 44)]
		[System.Xml.Serialization.XmlEnum(@"CT_Fox")]
		CT_Fox = 44
	}

	/// <summary>
	/// //颜色
	/// enum EColor
	/// {
	/// 	Color_None	= 0;
	/// 	Color_Red	= 1;//红
	/// 	Color_Green	= 2;//绿
	/// 	Color_Yellow= 3;//黄
	/// 	Color_Blue	= 4;//蓝
	/// 	Color_Purple= 5;//紫
	/// 	Color_Pink  = 6;//粉色
	/// 	Color_Orange= 7;//橘色
	/// }
	/// 奖励类型，为统一名称，以后替换炸弹类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"EBonusType")]
	public enum EBonusType
	{
		[ProtoBuf.ProtoEnum(Name = @"Bonus_None", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"Bonus_None")]
		Bonus_None = 0,

		[ProtoBuf.ProtoEnum(Name = @"Bonus_Kite", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"Bonus_Kite")]
		Bonus_Kite = 1,

		[ProtoBuf.ProtoEnum(Name = @"Bonus_Rainbow", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"Bonus_Rainbow")]
		Bonus_Rainbow = 2
	}

	/// <summary>
	///  方向
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESide")]
	public enum ESide
	{
		[ProtoBuf.ProtoEnum(Name = @"Side_None", Value = 8)]
		[System.Xml.Serialization.XmlEnum(@"Side_None")]
		Side_None = 8,

		[ProtoBuf.ProtoEnum(Name = @"Side_Bottom", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"Side_Bottom")]
		Side_Bottom = 0,

		[ProtoBuf.ProtoEnum(Name = @"Side_TopRight", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"Side_TopRight")]
		Side_TopRight = 1,

		[ProtoBuf.ProtoEnum(Name = @"Side_Right", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"Side_Right")]
		Side_Right = 2,

		[ProtoBuf.ProtoEnum(Name = @"Side_BottomRight", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"Side_BottomRight")]
		Side_BottomRight = 3,

		[ProtoBuf.ProtoEnum(Name = @"Side_Top", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"Side_Top")]
		Side_Top = 4,

		[ProtoBuf.ProtoEnum(Name = @"Side_BottomLeft", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"Side_BottomLeft")]
		Side_BottomLeft = 5,

		[ProtoBuf.ProtoEnum(Name = @"Side_Left", Value = 6)]
		[System.Xml.Serialization.XmlEnum(@"Side_Left")]
		Side_Left = 6,

		[ProtoBuf.ProtoEnum(Name = @"Side_TopLeft", Value = 7)]
		[System.Xml.Serialization.XmlEnum(@"Side_TopLeft")]
		Side_TopLeft = 7
	}

	/// <summary>
	///  阻挡类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"EBlockType")]
	public enum EBlockType
	{
		[ProtoBuf.ProtoEnum(Name = @"BT_None", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"BT_None")]
		BT_None = 0,

		[ProtoBuf.ProtoEnum(Name = @"BT_Block", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"BT_Block")]
		BT_Block = 1,

		[ProtoBuf.ProtoEnum(Name = @"BT_Branch", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"BT_Branch")]
		BT_Branch = 2,

		[ProtoBuf.ProtoEnum(Name = @"BT_Weed", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"BT_Weed")]
		BT_Weed = 3,

		[ProtoBuf.ProtoEnum(Name = @"BT_BrushWood", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"BT_BrushWood")]
		BT_BrushWood = 4,

		[ProtoBuf.ProtoEnum(Name = @"BT_Carton", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"BT_Carton")]
		BT_Carton = 5
	}

	/// <summary>
	///  Cell位置信息
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBCellPos")]
	public partial class PBCellPos
	{

		private int _x = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"x")]
		public int x
		{
			get { return _x; }
			set { _x = value; }
		}

		private int _y = default(int);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"y")]
		public int y
		{
			get { return _y; }
			set { _y = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBCellPos]{{x:{0}, y:{1}}}",
				x, y);
		}

	}

	/// <summary>
	/// 棋子基础属性
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipProperties")]
	public partial class PBChipProperties
	{

		private bool _interactive = false;
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"interactive")]
		public bool interactive
		{
			get { return _interactive; }
			set { _interactive = value; }
		}

		private bool _falling = false;
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"falling")]
		public bool falling
		{
			get { return _falling; }
			set { _falling = value; }
		}

		private bool _block_move = false;
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"block_move")]
		public bool block_move
		{
			get { return _block_move; }
			set { _block_move = value; }
		}

		private bool _block_swap = false;
		[ProtoBuf.ProtoMember(18)]
		[System.Xml.Serialization.XmlAttribute(@"block_swap")]
		public bool block_swap
		{
			get { return _block_swap; }
			set { _block_swap = value; }
		}

		private bool _block_damage_u = false;
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"block_damage_u")]
		public bool block_damage_u
		{
			get { return _block_damage_u; }
			set { _block_damage_u = value; }
		}

		private bool _block_damage_t = false;
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"block_damage_t")]
		public bool block_damage_t
		{
			get { return _block_damage_t; }
			set { _block_damage_t = value; }
		}

		private bool _active = false;
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"active")]
		public bool active
		{
			get { return _active; }
			set { _active = value; }
		}

		private bool _growing = false;
		[ProtoBuf.ProtoMember(16)]
		[System.Xml.Serialization.XmlAttribute(@"growing")]
		public bool growing
		{
			get { return _growing; }
			set { _growing = value; }
		}

		private bool _colored = false;
		[ProtoBuf.ProtoMember(7)]
		[System.Xml.Serialization.XmlAttribute(@"colored")]
		public bool colored
		{
			get { return _colored; }
			set { _colored = value; }
		}

		private bool _visible = false;
		[ProtoBuf.ProtoMember(8)]
		[System.Xml.Serialization.XmlAttribute(@"visible")]
		public bool visible
		{
			get { return _visible; }
			set { _visible = value; }
		}

		private bool _target = false;
		[ProtoBuf.ProtoMember(9)]
		[System.Xml.Serialization.XmlAttribute(@"target")]
		public bool target
		{
			get { return _target; }
			set { _target = value; }
		}

		private bool _match_damage = false;
		[ProtoBuf.ProtoMember(10)]
		[System.Xml.Serialization.XmlAttribute(@"match_damage")]
		public bool match_damage
		{
			get { return _match_damage; }
			set { _match_damage = value; }
		}

		private bool _wind_damage = false;
		[ProtoBuf.ProtoMember(11)]
		[System.Xml.Serialization.XmlAttribute(@"wind_damage")]
		public bool wind_damage
		{
			get { return _wind_damage; }
			set { _wind_damage = value; }
		}

		private bool _explosion_damage = false;
		[ProtoBuf.ProtoMember(12)]
		[System.Xml.Serialization.XmlAttribute(@"explosion_damage")]
		public bool explosion_damage
		{
			get { return _explosion_damage; }
			set { _explosion_damage = value; }
		}

		private bool _hummer_damage = false;
		[ProtoBuf.ProtoMember(13)]
		[System.Xml.Serialization.XmlAttribute(@"hummer_damage")]
		public bool hummer_damage
		{
			get { return _hummer_damage; }
			set { _hummer_damage = value; }
		}

		private bool _reshulffle = false;
		[ProtoBuf.ProtoMember(14)]
		[System.Xml.Serialization.XmlAttribute(@"reshulffle")]
		public bool reshulffle
		{
			get { return _reshulffle; }
			set { _reshulffle = value; }
		}

		private bool _multigrades = false;
		[ProtoBuf.ProtoMember(15)]
		[System.Xml.Serialization.XmlAttribute(@"multigrades")]
		public bool multigrades
		{
			get { return _multigrades; }
			set { _multigrades = value; }
		}

		private bool _block_match = false;
		[ProtoBuf.ProtoMember(17)]
		[System.Xml.Serialization.XmlAttribute(@"block_match")]
		public bool block_match
		{
			get { return _block_match; }
			set { _block_match = value; }
		}

		private bool _auto_filling = false;
		[ProtoBuf.ProtoMember(19)]
		[System.Xml.Serialization.XmlAttribute(@"auto_filling")]
		public bool auto_filling
		{
			get { return _auto_filling; }
			set { _auto_filling = value; }
		}

		private bool _block_rainbow_select = false;
		[ProtoBuf.ProtoMember(22)]
		[System.Xml.Serialization.XmlAttribute(@"block_rainbow_select")]
		public bool block_rainbow_select
		{
			get { return _block_rainbow_select; }
			set { _block_rainbow_select = value; }
		}

		private bool _minus_grade = false;
		[ProtoBuf.ProtoMember(23)]
		[System.Xml.Serialization.XmlAttribute(@"minus_grade")]
		public bool minus_grade
		{
			get { return _minus_grade; }
			set { _minus_grade = value; }
		}

		private EChipType _chip_type = EChipType.CT_None;
		[ProtoBuf.ProtoMember(20)]
		[System.Xml.Serialization.XmlAttribute(@"chip_type")]
		public EChipType chip_type
		{
			get { return _chip_type; }
			set { _chip_type = value; }
		}

		private uint _chip_id = default(uint);
		[ProtoBuf.ProtoMember(21)]
		[System.Xml.Serialization.XmlAttribute(@"chip_id")]
		public uint chip_id
		{
			get { return _chip_id; }
			set { _chip_id = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChipProperties]{{interactive:{0}, falling:{1}, block_move:{2}, block_swap:{3}, block_damage_u:{4}, block_damage_t:{5}, active:{6}, growing:{7}, colored:{8}, visible:{9}, target:{10}, match_damage:{11}, wind_damage:{12}, explosion_damage:{13}, hummer_damage:{14}, reshulffle:{15}, multigrades:{16}, block_match:{17}, auto_filling:{18}, block_rainbow_select:{19}, minus_grade:{20}, chip_type:{21}, chip_id:{22}}}",
				interactive, falling, block_move, block_swap, block_damage_u, block_damage_t, active, growing, colored, visible, target, match_damage, wind_damage, explosion_damage, hummer_damage, reshulffle, multigrades, block_match, auto_filling, block_rainbow_select, minus_grade, chip_type, chip_id);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBUserAccount")]
	public partial class PBUserAccount
	{

		private uint _user_id = default(uint);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"user_id")]
		public uint user_id
		{
			get { return _user_id; }
			set { _user_id = value; }
		}

		private string _sdk_user_id = default(string);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"sdk_user_id")]
		public string sdk_user_id
		{
			get { return _sdk_user_id; }
			set { _sdk_user_id = value; }
		}

		private string _user_name = default(string);
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"user_name")]
		public string user_name
		{
			get { return _user_name; }
			set { _user_name = value; }
		}

		private string _sdk_user_name = default(string);
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"sdk_user_name")]
		public string sdk_user_name
		{
			get { return _sdk_user_name; }
			set { _sdk_user_name = value; }
		}

		private string _head_icon = default(string);
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"head_icon")]
		public string head_icon
		{
			get { return _head_icon; }
			set { _head_icon = value; }
		}

		private string _token = default(string);
		[ProtoBuf.ProtoMember(8)]
		[System.Xml.Serialization.XmlAttribute(@"token")]
		public string token
		{
			get { return _token; }
			set { _token = value; }
		}

		private long _timestamp = default(long);
		[ProtoBuf.ProtoMember(9)]
		[System.Xml.Serialization.XmlAttribute(@"timestamp")]
		public long timestamp
		{
			get { return _timestamp; }
			set { _timestamp = value; }
		}

		private string _device_token = default(string);
		[ProtoBuf.ProtoMember(10)]
		[System.Xml.Serialization.XmlAttribute(@"device_token")]
		public string device_token
		{
			get { return _device_token; }
			set { _device_token = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBUserAccount]{{user_id:{0}, sdk_user_id:{1}, user_name:{2}, sdk_user_name:{3}, head_icon:{4}, token:{5}, timestamp:{6}, device_token:{7}}}",
				user_id, sdk_user_id, user_name, sdk_user_name, head_icon, token, timestamp, device_token);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipShowLayer")]
	public partial class PBChipShowLayer
	{

		private uint _chip_id = default(uint);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"chip_id")]
		public uint chip_id
		{
			get { return _chip_id; }
			set { _chip_id = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChipShowLayer]{{chip_id:{0}}}",
				chip_id);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipDestroyPriority")]
	public partial class PBChipDestroyPriority
	{

		private uint _chip_id = default(uint);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"chip_id")]
		public uint chip_id
		{
			get { return _chip_id; }
			set { _chip_id = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBChipDestroyPriority]{{chip_id:{0}}}",
				chip_id);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBChipGrid")]
	public enum PBChipGrid
	{
		[ProtoBuf.ProtoEnum(Name = @"e_None", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"e_None")]
		e_None = 0,

		[ProtoBuf.ProtoEnum(Name = @"e_1x2", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"e_1x2")]
		e_1x2 = 1,

		[ProtoBuf.ProtoEnum(Name = @"e_2x1", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"e_2x1")]
		e_2x1 = 2,

		[ProtoBuf.ProtoEnum(Name = @"e_2x2", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"e_2x2")]
		e_2x2 = 3,

		[ProtoBuf.ProtoEnum(Name = @"e_2x3", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"e_2x3")]
		e_2x3 = 4,

		[ProtoBuf.ProtoEnum(Name = @"e_3x2", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"e_3x2")]
		e_3x2 = 5,

		[ProtoBuf.ProtoEnum(Name = @"e_3x3", Value = 6)]
		[System.Xml.Serialization.XmlEnum(@"e_3x3")]
		e_3x3 = 6
	}

}
