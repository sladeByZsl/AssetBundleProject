/**************************************************************************************************
                                   自动生成代码  请勿手动修改
**************************************************************************************************/

namespace FunPlus.Common.Config
{

	/// <summary>
	/// 技能目标类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESTargetType")]
	public enum ESTargetType
	{
		[ProtoBuf.ProtoEnum(Name = @"Target_None", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"Target_None")]
		Target_None = 0,

		[ProtoBuf.ProtoEnum(Name = @"Target_Me", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"Target_Me")]
		Target_Me = 1,

		[ProtoBuf.ProtoEnum(Name = @"Target_MeAround", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"Target_MeAround")]
		Target_MeAround = 2,

		[ProtoBuf.ProtoEnum(Name = @"Target_MeALL", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"Target_MeALL")]
		Target_MeALL = 3,

		[ProtoBuf.ProtoEnum(Name = @"Target_Enemy", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"Target_Enemy")]
		Target_Enemy = 4,

		[ProtoBuf.ProtoEnum(Name = @"Target_EnemyAround", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"Target_EnemyAround")]
		Target_EnemyAround = 5,

		[ProtoBuf.ProtoEnum(Name = @"Target_EnemyAll", Value = 6)]
		[System.Xml.Serialization.XmlEnum(@"Target_EnemyAll")]
		Target_EnemyAll = 6,

		[ProtoBuf.ProtoEnum(Name = @"Next_Enemy", Value = 7)]
		[System.Xml.Serialization.XmlEnum(@"Next_Enemy")]
		Next_Enemy = 7,

		[ProtoBuf.ProtoEnum(Name = @"Chessboard", Value = 8)]
		[System.Xml.Serialization.XmlEnum(@"Chessboard")]
		Chessboard = 8,

		[ProtoBuf.ProtoEnum(Name = @"Target_EnemySide", Value = 9)]
		[System.Xml.Serialization.XmlEnum(@"Target_EnemySide")]
		Target_EnemySide = 9,

		[ProtoBuf.ProtoEnum(Name = @"Target_MeSide", Value = 10)]
		[System.Xml.Serialization.XmlEnum(@"Target_MeSide")]
		Target_MeSide = 10,

		[ProtoBuf.ProtoEnum(Name = @"Target_EnemyRandom", Value = 11)]
		[System.Xml.Serialization.XmlEnum(@"Target_EnemyRandom")]
		Target_EnemyRandom = 11,

		[ProtoBuf.ProtoEnum(Name = @"Target_EnemyRandomExclusive", Value = 12)]
		[System.Xml.Serialization.XmlEnum(@"Target_EnemyRandomExclusive")]
		Target_EnemyRandomExclusive = 12,

		[ProtoBuf.ProtoEnum(Name = @"Target_MeOthers", Value = 13)]
		[System.Xml.Serialization.XmlEnum(@"Target_MeOthers")]
		Target_MeOthers = 13,

		[ProtoBuf.ProtoEnum(Name = @"Target_EnemyOthers", Value = 14)]
		[System.Xml.Serialization.XmlEnum(@"Target_EnemyOthers")]
		Target_EnemyOthers = 14,

		[ProtoBuf.ProtoEnum(Name = @"Target_HeroPos1", Value = 15)]
		[System.Xml.Serialization.XmlEnum(@"Target_HeroPos1")]
		Target_HeroPos1 = 15,

		[ProtoBuf.ProtoEnum(Name = @"Target_HeroPos2", Value = 16)]
		[System.Xml.Serialization.XmlEnum(@"Target_HeroPos2")]
		Target_HeroPos2 = 16,

		[ProtoBuf.ProtoEnum(Name = @"Target_HeroPos3", Value = 17)]
		[System.Xml.Serialization.XmlEnum(@"Target_HeroPos3")]
		Target_HeroPos3 = 17,

		[ProtoBuf.ProtoEnum(Name = @"Target_HeroPos4", Value = 18)]
		[System.Xml.Serialization.XmlEnum(@"Target_HeroPos4")]
		Target_HeroPos4 = 18,

		[ProtoBuf.ProtoEnum(Name = @"Target_HeroPos5", Value = 19)]
		[System.Xml.Serialization.XmlEnum(@"Target_HeroPos5")]
		Target_HeroPos5 = 19,

		[ProtoBuf.ProtoEnum(Name = @"Target_Middle", Value = 20)]
		[System.Xml.Serialization.XmlEnum(@"Target_Middle")]
		Target_Middle = 20,

		[ProtoBuf.ProtoEnum(Name = @"Target_Hit", Value = 21)]
		[System.Xml.Serialization.XmlEnum(@"Target_Hit")]
		Target_Hit = 21,

		[ProtoBuf.ProtoEnum(Name = @"Target_HitAround", Value = 22)]
		[System.Xml.Serialization.XmlEnum(@"Target_HitAround")]
		Target_HitAround = 22,

		[ProtoBuf.ProtoEnum(Name = @"Target_HitAll", Value = 23)]
		[System.Xml.Serialization.XmlEnum(@"Target_HitAll")]
		Target_HitAll = 23
	}

	/// <summary>
	/// buff触发类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESkillTriggerType")]
	public enum ESkillTriggerType
	{
		[ProtoBuf.ProtoEnum(Name = @"none_round", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"none_round")]
		none_round = 0,

		[ProtoBuf.ProtoEnum(Name = @"before_round", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"before_round")]
		before_round = 1,

		[ProtoBuf.ProtoEnum(Name = @"after_round", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"after_round")]
		after_round = 2
	}

	/// <summary>
	/// 技能单元类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESkillUnitType")]
	public enum ESkillUnitType
	{
		[ProtoBuf.ProtoEnum(Name = @"skill_None", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"skill_None")]
		skill_None = 0,

		[ProtoBuf.ProtoEnum(Name = @"performace", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"performace")]
		performace = 1,

		[ProtoBuf.ProtoEnum(Name = @"effect", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"effect")]
		effect = 2,

		[ProtoBuf.ProtoEnum(Name = @"fly", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"fly")]
		fly = 3,

		[ProtoBuf.ProtoEnum(Name = @"audio", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"audio")]
		audio = 4,

		[ProtoBuf.ProtoEnum(Name = @"logic", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"logic")]
		logic = 5,

		[ProtoBuf.ProtoEnum(Name = @"actor", Value = 6)]
		[System.Xml.Serialization.XmlEnum(@"actor")]
		actor = 6,

		[ProtoBuf.ProtoEnum(Name = @"end", Value = 7)]
		[System.Xml.Serialization.XmlEnum(@"end")]
		end = 7
	}

	/// <summary>
	/// 技能被击类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESHitType")]
	public enum ESHitType
	{
		[ProtoBuf.ProtoEnum(Name = @"ES_Normal", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"ES_Normal")]
		ES_Normal = 0,

		[ProtoBuf.ProtoEnum(Name = @"ES_Crit", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"ES_Crit")]
		ES_Crit = 1,

		[ProtoBuf.ProtoEnum(Name = @"ES_MISS", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"ES_MISS")]
		ES_MISS = 2,

		[ProtoBuf.ProtoEnum(Name = @"ES_MISSING", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"ES_MISSING")]
		ES_MISSING = 3
	}

	/// <summary>
	/// 技能效果类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESEffectType")]
	public enum ESEffectType
	{
		[ProtoBuf.ProtoEnum(Name = @"ESE_None", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"ESE_None")]
		ESE_None = 0,

		[ProtoBuf.ProtoEnum(Name = @"ESE_Atk", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"ESE_Atk")]
		ESE_Atk = 1,

		[ProtoBuf.ProtoEnum(Name = @"ESE_Buff", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"ESE_Buff")]
		ESE_Buff = 2,

		[ProtoBuf.ProtoEnum(Name = @"ESE_Cure", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"ESE_Cure")]
		ESE_Cure = 3
	}

	/// <summary>
	/// 技能逻辑
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESPriorityType")]
	public enum ESPriorityType
	{
		[ProtoBuf.ProtoEnum(Name = @"ESP_Random", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"ESP_Random")]
		ESP_Random = 0,

		[ProtoBuf.ProtoEnum(Name = @"ESP_LowLife", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"ESP_LowLife")]
		ESP_LowLife = 1,

		[ProtoBuf.ProtoEnum(Name = @"ESP_Full", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"ESP_Full")]
		ESP_Full = 2,

		[ProtoBuf.ProtoEnum(Name = @"ESP_Death", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"ESP_Death")]
		ESP_Death = 3
	}

	/// <summary>
	///  单个任务总流程
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBSkill")]
	public partial class PBSkill
	{

		private int _s_id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"s_id")]
		public int s_id
		{
			get { return _s_id; }
			set { _s_id = value; }
		}

		private string _s_name = default(string);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"s_name")]
		public string s_name
		{
			get { return _s_name; }
			set { _s_name = value; }
		}

		private System.Collections.Generic.List<string> _s_desc = new System.Collections.Generic.List<string>();
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlElement(@"s_desc")]
		public System.Collections.Generic.List<string> s_desc
		{
			get { return _s_desc; }
			set { _s_desc = value; }
		}

		private ESTargetType _s_target = ESTargetType.Target_None;
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"s_target")]
		public ESTargetType s_target
		{
			get { return _s_target; }
			set { _s_target = value; }
		}

		private int _s_timeline_id = default(int);
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"s_timeline_id")]
		public int s_timeline_id
		{
			get { return _s_timeline_id; }
			set { _s_timeline_id = value; }
		}

		private bool _is_attack = default(bool);
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"is_attack")]
		public bool is_attack
		{
			get { return _is_attack; }
			set { _is_attack = value; }
		}

		private string _s_icon = default(string);
		[ProtoBuf.ProtoMember(7)]
		[System.Xml.Serialization.XmlAttribute(@"s_icon")]
		public string s_icon
		{
			get { return _s_icon; }
			set { _s_icon = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBSkill]{{s_id:{0}, s_name:{1}, s_desc:{2}, s_target:{3}, s_timeline_id:{4}, is_attack:{5}, s_icon:{6}}}",
				s_id, s_name, list2string(s_desc), s_target, s_timeline_id, is_attack, s_icon);
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
	[System.Xml.Serialization.XmlType(@"PBSkillTimeline")]
	public partial class PBSkillTimeline
	{

		private int _id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"id")]
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private System.Collections.Generic.List<PBSkillTimelineUnit> _timelines = new System.Collections.Generic.List<PBSkillTimelineUnit>();
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlElement(@"timelines")]
		public System.Collections.Generic.List<PBSkillTimelineUnit> timelines
		{
			get { return _timelines; }
			set { _timelines = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBSkillTimeline]{{id:{0}, timelines:{1}}}",
				id, list2string(timelines));
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
	[System.Xml.Serialization.XmlType(@"PBSkillTimelineUnit")]
	public partial class PBSkillTimelineUnit
	{

		private int _delayTime = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"delayTime")]
		public int delayTime
		{
			get { return _delayTime; }
			set { _delayTime = value; }
		}

		private ESkillUnitType _skillUnitType = ESkillUnitType.skill_None;
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"skillUnitType")]
		public ESkillUnitType skillUnitType
		{
			get { return _skillUnitType; }
			set { _skillUnitType = value; }
		}

		private int _skillUnitID = default(int);
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"skillUnitID")]
		public int skillUnitID
		{
			get { return _skillUnitID; }
			set { _skillUnitID = value; }
		}

		private int _group = default(int);
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"group")]
		public int group
		{
			get { return _group; }
			set { _group = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBSkillTimelineUnit]{{delayTime:{0}, skillUnitType:{1}, skillUnitID:{2}, group:{3}}}",
				delayTime, skillUnitType, skillUnitID, group);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBBuffProp")]
	public partial class PBBuffProp
	{

		private int _buff_id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"buff_id")]
		public int buff_id
		{
			get { return _buff_id; }
			set { _buff_id = value; }
		}

		private int _prop = default(int);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"prop")]
		public int prop
		{
			get { return _prop; }
			set { _prop = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBBuffProp]{{buff_id:{0}, prop:{1}}}",
				buff_id, prop);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBSkillLogic")]
	public partial class PBSkillLogic
	{

		private int _skilllogic_id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"skilllogic_id")]
		public int skilllogic_id
		{
			get { return _skilllogic_id; }
			set { _skilllogic_id = value; }
		}

		private int _timeline_id = default(int);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"timeline_id")]
		public int timeline_id
		{
			get { return _timeline_id; }
			set { _timeline_id = value; }
		}

		private int _level = default(int);
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"level")]
		public int level
		{
			get { return _level; }
			set { _level = value; }
		}

		private string _desc = default(string);
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"desc")]
		public string desc
		{
			get { return _desc; }
			set { _desc = value; }
		}

		private System.Collections.Generic.List<PBBuffProp> _buff_prop = new System.Collections.Generic.List<PBBuffProp>();
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlElement(@"buff_prop")]
		public System.Collections.Generic.List<PBBuffProp> buff_prop
		{
			get { return _buff_prop; }
			set { _buff_prop = value; }
		}

		private ESTargetType _target = ESTargetType.Target_None;
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"target")]
		public ESTargetType target
		{
			get { return _target; }
			set { _target = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBSkillLogic]{{skilllogic_id:{0}, timeline_id:{1}, level:{2}, desc:{3}, buff_prop:{4}, target:{5}}}",
				skilllogic_id, timeline_id, level, desc, list2string(buff_prop), target);
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
	[System.Xml.Serialization.XmlType(@"PBSkillPerformance")]
	public partial class PBSkillPerformance
	{

		private int _id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"id")]
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private int _action_delayTime = default(int);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"action_delayTime")]
		public int action_delayTime
		{
			get { return _action_delayTime; }
			set { _action_delayTime = value; }
		}

		private string _action_name = default(string);
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"action_name")]
		public string action_name
		{
			get { return _action_name; }
			set { _action_name = value; }
		}

		private int _effect_delayTime = default(int);
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"effect_delayTime")]
		public int effect_delayTime
		{
			get { return _effect_delayTime; }
			set { _effect_delayTime = value; }
		}

		private string _effect_name = default(string);
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"effect_name")]
		public string effect_name
		{
			get { return _effect_name; }
			set { _effect_name = value; }
		}

		private int _audio_delayTime = default(int);
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"audio_delayTime")]
		public int audio_delayTime
		{
			get { return _audio_delayTime; }
			set { _audio_delayTime = value; }
		}

		private string _audio_name = default(string);
		[ProtoBuf.ProtoMember(7)]
		[System.Xml.Serialization.XmlAttribute(@"audio_name")]
		public string audio_name
		{
			get { return _audio_name; }
			set { _audio_name = value; }
		}

		private int _duration_time = default(int);
		[ProtoBuf.ProtoMember(8)]
		[System.Xml.Serialization.XmlAttribute(@"duration_time")]
		public int duration_time
		{
			get { return _duration_time; }
			set { _duration_time = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBSkillPerformance]{{id:{0}, action_delayTime:{1}, action_name:{2}, effect_delayTime:{3}, effect_name:{4}, audio_delayTime:{5}, audio_name:{6}, duration_time:{7}}}",
				id, action_delayTime, action_name, effect_delayTime, effect_name, audio_delayTime, audio_name, duration_time);
		}

	}

	/// <summary>
	/// 技能效果类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESkillActionType")]
	public enum ESkillActionType
	{
		[ProtoBuf.ProtoEnum(Name = @"none", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"none")]
		none = 0,

		[ProtoBuf.ProtoEnum(Name = @"hurt", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"hurt")]
		hurt = 1,

		[ProtoBuf.ProtoEnum(Name = @"heal", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"heal")]
		heal = 2,

		[ProtoBuf.ProtoEnum(Name = @"dispel", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"dispel")]
		dispel = 3,

		[ProtoBuf.ProtoEnum(Name = @"chess_into_bomb", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"chess_into_bomb")]
		chess_into_bomb = 4,

		[ProtoBuf.ProtoEnum(Name = @"shield", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"shield")]
		shield = 5,

		[ProtoBuf.ProtoEnum(Name = @"return_damage", Value = 6)]
		[System.Xml.Serialization.XmlEnum(@"return_damage")]
		return_damage = 6,

		[ProtoBuf.ProtoEnum(Name = @"hide", Value = 7)]
		[System.Xml.Serialization.XmlEnum(@"hide")]
		hide = 7,

		[ProtoBuf.ProtoEnum(Name = @"stun", Value = 8)]
		[System.Xml.Serialization.XmlEnum(@"stun")]
		stun = 8,

		[ProtoBuf.ProtoEnum(Name = @"unconscious", Value = 9)]
		[System.Xml.Serialization.XmlEnum(@"unconscious")]
		unconscious = 9,

		[ProtoBuf.ProtoEnum(Name = @"taunt", Value = 10)]
		[System.Xml.Serialization.XmlEnum(@"taunt")]
		taunt = 10,

		[ProtoBuf.ProtoEnum(Name = @"trigger_buff", Value = 11)]
		[System.Xml.Serialization.XmlEnum(@"trigger_buff")]
		trigger_buff = 11,

		[ProtoBuf.ProtoEnum(Name = @"damage_share", Value = 12)]
		[System.Xml.Serialization.XmlEnum(@"damage_share")]
		damage_share = 12,

		[ProtoBuf.ProtoEnum(Name = @"add_attack", Value = 13)]
		[System.Xml.Serialization.XmlEnum(@"add_attack")]
		add_attack = 13,

		[ProtoBuf.ProtoEnum(Name = @"add_defence", Value = 14)]
		[System.Xml.Serialization.XmlEnum(@"add_defence")]
		add_defence = 14,

		[ProtoBuf.ProtoEnum(Name = @"add_hit_rate", Value = 15)]
		[System.Xml.Serialization.XmlEnum(@"add_hit_rate")]
		add_hit_rate = 15,

		[ProtoBuf.ProtoEnum(Name = @"add_mana_gain_rate", Value = 16)]
		[System.Xml.Serialization.XmlEnum(@"add_mana_gain_rate")]
		add_mana_gain_rate = 16,

		[ProtoBuf.ProtoEnum(Name = @"health_steal", Value = 17)]
		[System.Xml.Serialization.XmlEnum(@"health_steal")]
		health_steal = 17,

		[ProtoBuf.ProtoEnum(Name = @"add_normal_attack", Value = 18)]
		[System.Xml.Serialization.XmlEnum(@"add_normal_attack")]
		add_normal_attack = 18,

		[ProtoBuf.ProtoEnum(Name = @"steal_buff", Value = 19)]
		[System.Xml.Serialization.XmlEnum(@"steal_buff")]
		steal_buff = 19,

		[ProtoBuf.ProtoEnum(Name = @"add_mana", Value = 20)]
		[System.Xml.Serialization.XmlEnum(@"add_mana")]
		add_mana = 20,

		[ProtoBuf.ProtoEnum(Name = @"transform", Value = 21)]
		[System.Xml.Serialization.XmlEnum(@"transform")]
		transform = 21,

		[ProtoBuf.ProtoEnum(Name = @"conditional_trigger_buff", Value = 22)]
		[System.Xml.Serialization.XmlEnum(@"conditional_trigger_buff")]
		conditional_trigger_buff = 22
	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"EEaseType")]
	public enum EEaseType
	{
		[ProtoBuf.ProtoEnum(Name = @"Unset", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"Unset")]
		Unset = 0,

		[ProtoBuf.ProtoEnum(Name = @"Linear", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"Linear")]
		Linear = 1,

		[ProtoBuf.ProtoEnum(Name = @"InSine", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"InSine")]
		InSine = 2,

		[ProtoBuf.ProtoEnum(Name = @"OutSine", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"OutSine")]
		OutSine = 3,

		[ProtoBuf.ProtoEnum(Name = @"InOutSine", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"InOutSine")]
		InOutSine = 4,

		[ProtoBuf.ProtoEnum(Name = @"InQuad", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"InQuad")]
		InQuad = 5,

		[ProtoBuf.ProtoEnum(Name = @"OutQuad", Value = 6)]
		[System.Xml.Serialization.XmlEnum(@"OutQuad")]
		OutQuad = 6,

		[ProtoBuf.ProtoEnum(Name = @"InOutQuad", Value = 7)]
		[System.Xml.Serialization.XmlEnum(@"InOutQuad")]
		InOutQuad = 7,

		[ProtoBuf.ProtoEnum(Name = @"InCubic", Value = 8)]
		[System.Xml.Serialization.XmlEnum(@"InCubic")]
		InCubic = 8,

		[ProtoBuf.ProtoEnum(Name = @"OutCubic", Value = 9)]
		[System.Xml.Serialization.XmlEnum(@"OutCubic")]
		OutCubic = 9,

		[ProtoBuf.ProtoEnum(Name = @"InOutCubic", Value = 10)]
		[System.Xml.Serialization.XmlEnum(@"InOutCubic")]
		InOutCubic = 10,

		[ProtoBuf.ProtoEnum(Name = @"InQuart", Value = 11)]
		[System.Xml.Serialization.XmlEnum(@"InQuart")]
		InQuart = 11,

		[ProtoBuf.ProtoEnum(Name = @"OutQuart", Value = 12)]
		[System.Xml.Serialization.XmlEnum(@"OutQuart")]
		OutQuart = 12,

		[ProtoBuf.ProtoEnum(Name = @"InOutQuart", Value = 13)]
		[System.Xml.Serialization.XmlEnum(@"InOutQuart")]
		InOutQuart = 13,

		[ProtoBuf.ProtoEnum(Name = @"InQuint", Value = 14)]
		[System.Xml.Serialization.XmlEnum(@"InQuint")]
		InQuint = 14,

		[ProtoBuf.ProtoEnum(Name = @"OutQuint", Value = 15)]
		[System.Xml.Serialization.XmlEnum(@"OutQuint")]
		OutQuint = 15,

		[ProtoBuf.ProtoEnum(Name = @"InOutQuint", Value = 16)]
		[System.Xml.Serialization.XmlEnum(@"InOutQuint")]
		InOutQuint = 16,

		[ProtoBuf.ProtoEnum(Name = @"InExpo", Value = 17)]
		[System.Xml.Serialization.XmlEnum(@"InExpo")]
		InExpo = 17,

		[ProtoBuf.ProtoEnum(Name = @"OutExpo", Value = 18)]
		[System.Xml.Serialization.XmlEnum(@"OutExpo")]
		OutExpo = 18,

		[ProtoBuf.ProtoEnum(Name = @"InOutExpo", Value = 19)]
		[System.Xml.Serialization.XmlEnum(@"InOutExpo")]
		InOutExpo = 19,

		[ProtoBuf.ProtoEnum(Name = @"InCirc", Value = 20)]
		[System.Xml.Serialization.XmlEnum(@"InCirc")]
		InCirc = 20,

		[ProtoBuf.ProtoEnum(Name = @"OutCirc", Value = 21)]
		[System.Xml.Serialization.XmlEnum(@"OutCirc")]
		OutCirc = 21,

		[ProtoBuf.ProtoEnum(Name = @"InOutCirc", Value = 22)]
		[System.Xml.Serialization.XmlEnum(@"InOutCirc")]
		InOutCirc = 22,

		[ProtoBuf.ProtoEnum(Name = @"InElastic", Value = 23)]
		[System.Xml.Serialization.XmlEnum(@"InElastic")]
		InElastic = 23,

		[ProtoBuf.ProtoEnum(Name = @"OutElastic", Value = 24)]
		[System.Xml.Serialization.XmlEnum(@"OutElastic")]
		OutElastic = 24,

		[ProtoBuf.ProtoEnum(Name = @"InOutElastic", Value = 25)]
		[System.Xml.Serialization.XmlEnum(@"InOutElastic")]
		InOutElastic = 25,

		[ProtoBuf.ProtoEnum(Name = @"InBack", Value = 26)]
		[System.Xml.Serialization.XmlEnum(@"InBack")]
		InBack = 26,

		[ProtoBuf.ProtoEnum(Name = @"OutBack", Value = 27)]
		[System.Xml.Serialization.XmlEnum(@"OutBack")]
		OutBack = 27,

		[ProtoBuf.ProtoEnum(Name = @"InOutBack", Value = 28)]
		[System.Xml.Serialization.XmlEnum(@"InOutBack")]
		InOutBack = 28,

		[ProtoBuf.ProtoEnum(Name = @"InBounce", Value = 29)]
		[System.Xml.Serialization.XmlEnum(@"InBounce")]
		InBounce = 29,

		[ProtoBuf.ProtoEnum(Name = @"OutBounce", Value = 30)]
		[System.Xml.Serialization.XmlEnum(@"OutBounce")]
		OutBounce = 30,

		[ProtoBuf.ProtoEnum(Name = @"InOutBounce", Value = 31)]
		[System.Xml.Serialization.XmlEnum(@"InOutBounce")]
		InOutBounce = 31,

		[ProtoBuf.ProtoEnum(Name = @"Flash", Value = 32)]
		[System.Xml.Serialization.XmlEnum(@"Flash")]
		Flash = 32,

		[ProtoBuf.ProtoEnum(Name = @"InFlash", Value = 33)]
		[System.Xml.Serialization.XmlEnum(@"InFlash")]
		InFlash = 33,

		[ProtoBuf.ProtoEnum(Name = @"OutFlash", Value = 34)]
		[System.Xml.Serialization.XmlEnum(@"OutFlash")]
		OutFlash = 34,

		[ProtoBuf.ProtoEnum(Name = @"InOutFlash", Value = 35)]
		[System.Xml.Serialization.XmlEnum(@"InOutFlash")]
		InOutFlash = 35,

		[ProtoBuf.ProtoEnum(Name = @"INTERNAL_Zero", Value = 36)]
		[System.Xml.Serialization.XmlEnum(@"INTERNAL_Zero")]
		INTERNAL_Zero = 36,

		[ProtoBuf.ProtoEnum(Name = @"INTERNAL_Custom", Value = 37)]
		[System.Xml.Serialization.XmlEnum(@"INTERNAL_Custom")]
		INTERNAL_Custom = 37
	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBBuffData")]
	public partial class PBBuffData
	{

		private int _b_id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"b_id")]
		public int b_id
		{
			get { return _b_id; }
			set { _b_id = value; }
		}

		private int _b_level = default(int);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"b_level")]
		public int b_level
		{
			get { return _b_level; }
			set { _b_level = value; }
		}

		private int _b_typeID = default(int);
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"b_typeID")]
		public int b_typeID
		{
			get { return _b_typeID; }
			set { _b_typeID = value; }
		}

		private int _b_remainTime = default(int);
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"b_remainTime")]
		public int b_remainTime
		{
			get { return _b_remainTime; }
			set { _b_remainTime = value; }
		}

		private string _b_desc = default(string);
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"b_desc")]
		public string b_desc
		{
			get { return _b_desc; }
			set { _b_desc = value; }
		}

		private int _param_1 = default(int);
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"param_1")]
		public int param_1
		{
			get { return _param_1; }
			set { _param_1 = value; }
		}

		private int _param_2 = default(int);
		[ProtoBuf.ProtoMember(7)]
		[System.Xml.Serialization.XmlAttribute(@"param_2")]
		public int param_2
		{
			get { return _param_2; }
			set { _param_2 = value; }
		}

		private int _param_3 = default(int);
		[ProtoBuf.ProtoMember(8)]
		[System.Xml.Serialization.XmlAttribute(@"param_3")]
		public int param_3
		{
			get { return _param_3; }
			set { _param_3 = value; }
		}

		private int _param_4 = default(int);
		[ProtoBuf.ProtoMember(9)]
		[System.Xml.Serialization.XmlAttribute(@"param_4")]
		public int param_4
		{
			get { return _param_4; }
			set { _param_4 = value; }
		}

		private int _param_5 = default(int);
		[ProtoBuf.ProtoMember(10)]
		[System.Xml.Serialization.XmlAttribute(@"param_5")]
		public int param_5
		{
			get { return _param_5; }
			set { _param_5 = value; }
		}

		private int _param_6 = default(int);
		[ProtoBuf.ProtoMember(11)]
		[System.Xml.Serialization.XmlAttribute(@"param_6")]
		public int param_6
		{
			get { return _param_6; }
			set { _param_6 = value; }
		}

		private int _param_7 = default(int);
		[ProtoBuf.ProtoMember(12)]
		[System.Xml.Serialization.XmlAttribute(@"param_7")]
		public int param_7
		{
			get { return _param_7; }
			set { _param_7 = value; }
		}

		private int _param_8 = default(int);
		[ProtoBuf.ProtoMember(13)]
		[System.Xml.Serialization.XmlAttribute(@"param_8")]
		public int param_8
		{
			get { return _param_8; }
			set { _param_8 = value; }
		}

		private int _param_9 = default(int);
		[ProtoBuf.ProtoMember(14)]
		[System.Xml.Serialization.XmlAttribute(@"param_9")]
		public int param_9
		{
			get { return _param_9; }
			set { _param_9 = value; }
		}

		private int _param_10 = default(int);
		[ProtoBuf.ProtoMember(15)]
		[System.Xml.Serialization.XmlAttribute(@"param_10")]
		public int param_10
		{
			get { return _param_10; }
			set { _param_10 = value; }
		}

		private int _trigger_actor_id = default(int);
		[ProtoBuf.ProtoMember(16)]
		[System.Xml.Serialization.XmlAttribute(@"trigger_actor_id")]
		public int trigger_actor_id
		{
			get { return _trigger_actor_id; }
			set { _trigger_actor_id = value; }
		}

		private int _trigger_effect_id = default(int);
		[ProtoBuf.ProtoMember(17)]
		[System.Xml.Serialization.XmlAttribute(@"trigger_effect_id")]
		public int trigger_effect_id
		{
			get { return _trigger_effect_id; }
			set { _trigger_effect_id = value; }
		}

		private int _loop_actor_id = default(int);
		[ProtoBuf.ProtoMember(18)]
		[System.Xml.Serialization.XmlAttribute(@"loop_actor_id")]
		public int loop_actor_id
		{
			get { return _loop_actor_id; }
			set { _loop_actor_id = value; }
		}

		private int _loop_effect_id = default(int);
		[ProtoBuf.ProtoMember(19)]
		[System.Xml.Serialization.XmlAttribute(@"loop_effect_id")]
		public int loop_effect_id
		{
			get { return _loop_effect_id; }
			set { _loop_effect_id = value; }
		}

		private int _shock_id = default(int);
		[ProtoBuf.ProtoMember(20)]
		[System.Xml.Serialization.XmlAttribute(@"shock_id")]
		public int shock_id
		{
			get { return _shock_id; }
			set { _shock_id = value; }
		}

		private int _b_delayTime = default(int);
		[ProtoBuf.ProtoMember(21)]
		[System.Xml.Serialization.XmlAttribute(@"b_delayTime")]
		public int b_delayTime
		{
			get { return _b_delayTime; }
			set { _b_delayTime = value; }
		}

		private int _b_type = default(int);
		[ProtoBuf.ProtoMember(22)]
		[System.Xml.Serialization.XmlAttribute(@"b_type")]
		public int b_type
		{
			get { return _b_type; }
			set { _b_type = value; }
		}

		private bool _b_is_dispelled = default(bool);
		[ProtoBuf.ProtoMember(23)]
		[System.Xml.Serialization.XmlAttribute(@"b_is_dispelled")]
		public bool b_is_dispelled
		{
			get { return _b_is_dispelled; }
			set { _b_is_dispelled = value; }
		}

		private ESkillTriggerType _b_triggerType = ESkillTriggerType.none_round;
		[ProtoBuf.ProtoMember(24)]
		[System.Xml.Serialization.XmlAttribute(@"b_triggerType")]
		public ESkillTriggerType b_triggerType
		{
			get { return _b_triggerType; }
			set { _b_triggerType = value; }
		}

		private int _b_trigger_prob = default(int);
		[ProtoBuf.ProtoMember(25)]
		[System.Xml.Serialization.XmlAttribute(@"b_trigger_prob")]
		public int b_trigger_prob
		{
			get { return _b_trigger_prob; }
			set { _b_trigger_prob = value; }
		}

		private string _b_icon = default(string);
		[ProtoBuf.ProtoMember(26)]
		[System.Xml.Serialization.XmlAttribute(@"b_icon")]
		public string b_icon
		{
			get { return _b_icon; }
			set { _b_icon = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBBuffData]{{b_id:{0}, b_level:{1}, b_typeID:{2}, b_remainTime:{3}, b_desc:{4}, param_1:{5}, param_2:{6}, param_3:{7}, param_4:{8}, param_5:{9}, param_6:{10}, param_7:{11}, param_8:{12}, param_9:{13}, param_10:{14}, trigger_actor_id:{15}, trigger_effect_id:{16}, loop_actor_id:{17}, loop_effect_id:{18}, shock_id:{19}, b_delayTime:{20}, b_type:{21}, b_is_dispelled:{22}, b_triggerType:{23}, b_trigger_prob:{24}, b_icon:{25}}}",
				b_id, b_level, b_typeID, b_remainTime, b_desc, param_1, param_2, param_3, param_4, param_5, param_6, param_7, param_8, param_9, param_10, trigger_actor_id, trigger_effect_id, loop_actor_id, loop_effect_id, shock_id, b_delayTime, b_type, b_is_dispelled, b_triggerType, b_trigger_prob, b_icon);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBBuffAction")]
	public partial class PBBuffAction
	{

		private int _action_id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"action_id")]
		public int action_id
		{
			get { return _action_id; }
			set { _action_id = value; }
		}

		private ESkillActionType _action_type = ESkillActionType.none;
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"action_type")]
		public ESkillActionType action_type
		{
			get { return _action_type; }
			set { _action_type = value; }
		}

		private int _b_remark = default(int);
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"b_remark")]
		public int b_remark
		{
			get { return _b_remark; }
			set { _b_remark = value; }
		}

		private int _b_group = default(int);
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"b_group")]
		public int b_group
		{
			get { return _b_group; }
			set { _b_group = value; }
		}

		private bool _b_is_superposed = default(bool);
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"b_is_superposed")]
		public bool b_is_superposed
		{
			get { return _b_is_superposed; }
			set { _b_is_superposed = value; }
		}

		private int _b_superpose_rule = default(int);
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"b_superpose_rule")]
		public int b_superpose_rule
		{
			get { return _b_superpose_rule; }
			set { _b_superpose_rule = value; }
		}

		private bool _b_exist_overstage = default(bool);
		[ProtoBuf.ProtoMember(7)]
		[System.Xml.Serialization.XmlAttribute(@"b_exist_overstage")]
		public bool b_exist_overstage
		{
			get { return _b_exist_overstage; }
			set { _b_exist_overstage = value; }
		}

		private bool _b_is_display = default(bool);
		[ProtoBuf.ProtoMember(8)]
		[System.Xml.Serialization.XmlAttribute(@"b_is_display")]
		public bool b_is_display
		{
			get { return _b_is_display; }
			set { _b_is_display = value; }
		}

		private string _b_icon = default(string);
		[ProtoBuf.ProtoMember(9)]
		[System.Xml.Serialization.XmlAttribute(@"b_icon")]
		public string b_icon
		{
			get { return _b_icon; }
			set { _b_icon = value; }
		}

		private int _b_performance_id = default(int);
		[ProtoBuf.ProtoMember(10)]
		[System.Xml.Serialization.XmlAttribute(@"b_performance_id")]
		public int b_performance_id
		{
			get { return _b_performance_id; }
			set { _b_performance_id = value; }
		}

		private int _param_1 = default(int);
		[ProtoBuf.ProtoMember(11)]
		[System.Xml.Serialization.XmlAttribute(@"param_1")]
		public int param_1
		{
			get { return _param_1; }
			set { _param_1 = value; }
		}

		private int _param_2 = default(int);
		[ProtoBuf.ProtoMember(12)]
		[System.Xml.Serialization.XmlAttribute(@"param_2")]
		public int param_2
		{
			get { return _param_2; }
			set { _param_2 = value; }
		}

		private int _param_3 = default(int);
		[ProtoBuf.ProtoMember(13)]
		[System.Xml.Serialization.XmlAttribute(@"param_3")]
		public int param_3
		{
			get { return _param_3; }
			set { _param_3 = value; }
		}

		private int _param_4 = default(int);
		[ProtoBuf.ProtoMember(14)]
		[System.Xml.Serialization.XmlAttribute(@"param_4")]
		public int param_4
		{
			get { return _param_4; }
			set { _param_4 = value; }
		}

		private int _param_5 = default(int);
		[ProtoBuf.ProtoMember(15)]
		[System.Xml.Serialization.XmlAttribute(@"param_5")]
		public int param_5
		{
			get { return _param_5; }
			set { _param_5 = value; }
		}

		private int _param_6 = default(int);
		[ProtoBuf.ProtoMember(16)]
		[System.Xml.Serialization.XmlAttribute(@"param_6")]
		public int param_6
		{
			get { return _param_6; }
			set { _param_6 = value; }
		}

		private int _param_7 = default(int);
		[ProtoBuf.ProtoMember(17)]
		[System.Xml.Serialization.XmlAttribute(@"param_7")]
		public int param_7
		{
			get { return _param_7; }
			set { _param_7 = value; }
		}

		private int _param_8 = default(int);
		[ProtoBuf.ProtoMember(18)]
		[System.Xml.Serialization.XmlAttribute(@"param_8")]
		public int param_8
		{
			get { return _param_8; }
			set { _param_8 = value; }
		}

		private int _param_9 = default(int);
		[ProtoBuf.ProtoMember(19)]
		[System.Xml.Serialization.XmlAttribute(@"param_9")]
		public int param_9
		{
			get { return _param_9; }
			set { _param_9 = value; }
		}

		private int _param_10 = default(int);
		[ProtoBuf.ProtoMember(20)]
		[System.Xml.Serialization.XmlAttribute(@"param_10")]
		public int param_10
		{
			get { return _param_10; }
			set { _param_10 = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBBuffAction]{{action_id:{0}, action_type:{1}, b_remark:{2}, b_group:{3}, b_is_superposed:{4}, b_superpose_rule:{5}, b_exist_overstage:{6}, b_is_display:{7}, b_icon:{8}, b_performance_id:{9}, param_1:{10}, param_2:{11}, param_3:{12}, param_4:{13}, param_5:{14}, param_6:{15}, param_7:{16}, param_8:{17}, param_9:{18}, param_10:{19}}}",
				action_id, action_type, b_remark, b_group, b_is_superposed, b_superpose_rule, b_exist_overstage, b_is_display, b_icon, b_performance_id, param_1, param_2, param_3, param_4, param_5, param_6, param_7, param_8, param_9, param_10);
		}

	}

	/// <summary>
	/// 技能特效挂接类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESkillEffectType")]
	public enum ESkillEffectType
	{
		[ProtoBuf.ProtoEnum(Name = @"Screen", Value = 0)]
		[System.Xml.Serialization.XmlEnum(@"Screen")]
		Screen = 0,

		[ProtoBuf.ProtoEnum(Name = @"Spine", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"Spine")]
		Spine = 1,

		[ProtoBuf.ProtoEnum(Name = @"UI", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"UI")]
		UI = 2,

		[ProtoBuf.ProtoEnum(Name = @"Scene", Value = 3)]
		[System.Xml.Serialization.XmlEnum(@"Scene")]
		Scene = 3,

		[ProtoBuf.ProtoEnum(Name = @"UI_Bar", Value = 4)]
		[System.Xml.Serialization.XmlEnum(@"UI_Bar")]
		UI_Bar = 4,

		[ProtoBuf.ProtoEnum(Name = @"UI_Chessboard", Value = 5)]
		[System.Xml.Serialization.XmlEnum(@"UI_Chessboard")]
		UI_Chessboard = 5
	}

	/// <summary>
	/// 技能特效
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBSkillEffectUnit")]
	public partial class PBSkillEffectUnit
	{

		private int _id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"id")]
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private int _play_time = default(int);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"play_time")]
		public int play_time
		{
			get { return _play_time; }
			set { _play_time = value; }
		}

		private EStickBone _spine_socket_name = EStickBone.Hit01_UI;
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"spine_socket_name")]
		public EStickBone spine_socket_name
		{
			get { return _spine_socket_name; }
			set { _spine_socket_name = value; }
		}

		private ESkillEffectType _skillEffectType = ESkillEffectType.Screen;
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"skillEffectType")]
		public ESkillEffectType skillEffectType
		{
			get { return _skillEffectType; }
			set { _skillEffectType = value; }
		}

		private ESTargetType _targetType = ESTargetType.Target_None;
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"targetType")]
		public ESTargetType targetType
		{
			get { return _targetType; }
			set { _targetType = value; }
		}

		private string _effect_name = default(string);
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"effect_name")]
		public string effect_name
		{
			get { return _effect_name; }
			set { _effect_name = value; }
		}

		private int _param_1 = default(int);
		[ProtoBuf.ProtoMember(7)]
		[System.Xml.Serialization.XmlAttribute(@"param_1")]
		public int param_1
		{
			get { return _param_1; }
			set { _param_1 = value; }
		}

		private int _param_2 = default(int);
		[ProtoBuf.ProtoMember(8)]
		[System.Xml.Serialization.XmlAttribute(@"param_2")]
		public int param_2
		{
			get { return _param_2; }
			set { _param_2 = value; }
		}

		private int _param_3 = default(int);
		[ProtoBuf.ProtoMember(9)]
		[System.Xml.Serialization.XmlAttribute(@"param_3")]
		public int param_3
		{
			get { return _param_3; }
			set { _param_3 = value; }
		}

		private int _param_4 = default(int);
		[ProtoBuf.ProtoMember(10)]
		[System.Xml.Serialization.XmlAttribute(@"param_4")]
		public int param_4
		{
			get { return _param_4; }
			set { _param_4 = value; }
		}

		private bool _is_zoom_with_lattice = default(bool);
		[ProtoBuf.ProtoMember(11)]
		[System.Xml.Serialization.XmlAttribute(@"is_zoom_with_lattice")]
		public bool is_zoom_with_lattice
		{
			get { return _is_zoom_with_lattice; }
			set { _is_zoom_with_lattice = value; }
		}

		private bool _is_attach = default(bool);
		[ProtoBuf.ProtoMember(12)]
		[System.Xml.Serialization.XmlAttribute(@"is_attach")]
		public bool is_attach
		{
			get { return _is_attach; }
			set { _is_attach = value; }
		}

		private int _effect_camera = default(int);
		[ProtoBuf.ProtoMember(13)]
		[System.Xml.Serialization.XmlAttribute(@"effect_camera")]
		public int effect_camera
		{
			get { return _effect_camera; }
			set { _effect_camera = value; }
		}

		private bool _rotation_hasTarget = default(bool);
		[ProtoBuf.ProtoMember(14)]
		[System.Xml.Serialization.XmlAttribute(@"rotation_hasTarget")]
		public bool rotation_hasTarget
		{
			get { return _rotation_hasTarget; }
			set { _rotation_hasTarget = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBSkillEffectUnit]{{id:{0}, play_time:{1}, spine_socket_name:{2}, skillEffectType:{3}, targetType:{4}, effect_name:{5}, param_1:{6}, param_2:{7}, param_3:{8}, param_4:{9}, is_zoom_with_lattice:{10}, is_attach:{11}, effect_camera:{12}, rotation_hasTarget:{13}}}",
				id, play_time, spine_socket_name, skillEffectType, targetType, effect_name, param_1, param_2, param_3, param_4, is_zoom_with_lattice, is_attach, effect_camera, rotation_hasTarget);
		}

	}

	/// <summary>
	/// 技能动作类型
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"ESkillActorType")]
	public enum ESkillActorType
	{
		[ProtoBuf.ProtoEnum(Name = @"Actor_Spine", Value = 1)]
		[System.Xml.Serialization.XmlEnum(@"Actor_Spine")]
		Actor_Spine = 1,

		[ProtoBuf.ProtoEnum(Name = @"Actor_UI", Value = 2)]
		[System.Xml.Serialization.XmlEnum(@"Actor_UI")]
		Actor_UI = 2
	}

	/// <summary>
	/// 技能动作
	/// </summary>
	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBSkillActorUnit")]
	public partial class PBSkillActorUnit
	{

		private int _id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"id")]
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private ESkillActorType _action_type = ESkillActorType.Actor_Spine;
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"action_type")]
		public ESkillActorType action_type
		{
			get { return _action_type; }
			set { _action_type = value; }
		}

		private bool _repeat = default(bool);
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"repeat")]
		public bool repeat
		{
			get { return _repeat; }
			set { _repeat = value; }
		}

		private string _name = default(string);
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"name")]
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		private int _audio_delayTime = default(int);
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"audio_delayTime")]
		public int audio_delayTime
		{
			get { return _audio_delayTime; }
			set { _audio_delayTime = value; }
		}

		private string _audio_name = default(string);
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"audio_name")]
		public string audio_name
		{
			get { return _audio_name; }
			set { _audio_name = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBSkillActorUnit]{{id:{0}, action_type:{1}, repeat:{2}, name:{3}, audio_delayTime:{4}, audio_name:{5}}}",
				id, action_type, repeat, name, audio_delayTime, audio_name);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBSkillFlyTargetUnit")]
	public partial class PBSkillFlyTargetUnit
	{

		private int _id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"id")]
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _effect_name = default(string);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"effect_name")]
		public string effect_name
		{
			get { return _effect_name; }
			set { _effect_name = value; }
		}

		private int _trigger_id = default(int);
		[ProtoBuf.ProtoMember(3)]
		[System.Xml.Serialization.XmlAttribute(@"trigger_id")]
		public int trigger_id
		{
			get { return _trigger_id; }
			set { _trigger_id = value; }
		}

		private ESkillEffectType _fly_start_slotType = ESkillEffectType.Screen;
		[ProtoBuf.ProtoMember(4)]
		[System.Xml.Serialization.XmlAttribute(@"fly_start_slotType")]
		public ESkillEffectType fly_start_slotType
		{
			get { return _fly_start_slotType; }
			set { _fly_start_slotType = value; }
		}

		private ESTargetType _start_socket = ESTargetType.Target_None;
		[ProtoBuf.ProtoMember(5)]
		[System.Xml.Serialization.XmlAttribute(@"start_socket")]
		public ESTargetType start_socket
		{
			get { return _start_socket; }
			set { _start_socket = value; }
		}

		private EStickBone _fly_start_spine_socket_name = EStickBone.Hit01_UI;
		[ProtoBuf.ProtoMember(6)]
		[System.Xml.Serialization.XmlAttribute(@"fly_start_spine_socket_name")]
		public EStickBone fly_start_spine_socket_name
		{
			get { return _fly_start_spine_socket_name; }
			set { _fly_start_spine_socket_name = value; }
		}

		private ESkillEffectType _fly_end_slot_type = ESkillEffectType.Screen;
		[ProtoBuf.ProtoMember(7)]
		[System.Xml.Serialization.XmlAttribute(@"fly_end_slot_type")]
		public ESkillEffectType fly_end_slot_type
		{
			get { return _fly_end_slot_type; }
			set { _fly_end_slot_type = value; }
		}

		private ESTargetType _end_socket = ESTargetType.Target_None;
		[ProtoBuf.ProtoMember(8)]
		[System.Xml.Serialization.XmlAttribute(@"end_socket")]
		public ESTargetType end_socket
		{
			get { return _end_socket; }
			set { _end_socket = value; }
		}

		private EStickBone _fly_end_spine_socket_name = EStickBone.Hit01_UI;
		[ProtoBuf.ProtoMember(9)]
		[System.Xml.Serialization.XmlAttribute(@"fly_end_spine_socket_name")]
		public EStickBone fly_end_spine_socket_name
		{
			get { return _fly_end_spine_socket_name; }
			set { _fly_end_spine_socket_name = value; }
		}

		private float _fly_speed = default(float);
		[ProtoBuf.ProtoMember(10)]
		[System.Xml.Serialization.XmlAttribute(@"fly_speed")]
		public float fly_speed
		{
			get { return _fly_speed; }
			set { _fly_speed = value; }
		}

		private int _fly_start_param1 = default(int);
		[ProtoBuf.ProtoMember(11)]
		[System.Xml.Serialization.XmlAttribute(@"fly_start_param1")]
		public int fly_start_param1
		{
			get { return _fly_start_param1; }
			set { _fly_start_param1 = value; }
		}

		private int _fly_start_param2 = default(int);
		[ProtoBuf.ProtoMember(12)]
		[System.Xml.Serialization.XmlAttribute(@"fly_start_param2")]
		public int fly_start_param2
		{
			get { return _fly_start_param2; }
			set { _fly_start_param2 = value; }
		}

		private int _fly_start_param3 = default(int);
		[ProtoBuf.ProtoMember(13)]
		[System.Xml.Serialization.XmlAttribute(@"fly_start_param3")]
		public int fly_start_param3
		{
			get { return _fly_start_param3; }
			set { _fly_start_param3 = value; }
		}

		private int _fly_start_param4 = default(int);
		[ProtoBuf.ProtoMember(14)]
		[System.Xml.Serialization.XmlAttribute(@"fly_start_param4")]
		public int fly_start_param4
		{
			get { return _fly_start_param4; }
			set { _fly_start_param4 = value; }
		}

		private int _fly_start_param5 = default(int);
		[ProtoBuf.ProtoMember(15)]
		[System.Xml.Serialization.XmlAttribute(@"fly_start_param5")]
		public int fly_start_param5
		{
			get { return _fly_start_param5; }
			set { _fly_start_param5 = value; }
		}

		private int _fly_end_param1 = default(int);
		[ProtoBuf.ProtoMember(16)]
		[System.Xml.Serialization.XmlAttribute(@"fly_end_param1")]
		public int fly_end_param1
		{
			get { return _fly_end_param1; }
			set { _fly_end_param1 = value; }
		}

		private int _fly_end_param2 = default(int);
		[ProtoBuf.ProtoMember(17)]
		[System.Xml.Serialization.XmlAttribute(@"fly_end_param2")]
		public int fly_end_param2
		{
			get { return _fly_end_param2; }
			set { _fly_end_param2 = value; }
		}

		private int _fly_end_param3 = default(int);
		[ProtoBuf.ProtoMember(18)]
		[System.Xml.Serialization.XmlAttribute(@"fly_end_param3")]
		public int fly_end_param3
		{
			get { return _fly_end_param3; }
			set { _fly_end_param3 = value; }
		}

		private int _fly_end_param4 = default(int);
		[ProtoBuf.ProtoMember(19)]
		[System.Xml.Serialization.XmlAttribute(@"fly_end_param4")]
		public int fly_end_param4
		{
			get { return _fly_end_param4; }
			set { _fly_end_param4 = value; }
		}

		private int _fly_end_param5 = default(int);
		[ProtoBuf.ProtoMember(20)]
		[System.Xml.Serialization.XmlAttribute(@"fly_end_param5")]
		public int fly_end_param5
		{
			get { return _fly_end_param5; }
			set { _fly_end_param5 = value; }
		}

		private string _fly_routinetype = default(string);
		[ProtoBuf.ProtoMember(21)]
		[System.Xml.Serialization.XmlAttribute(@"fly_routinetype")]
		public string fly_routinetype
		{
			get { return _fly_routinetype; }
			set { _fly_routinetype = value; }
		}

		private EEaseType _fly_easetype = EEaseType.Linear;
		[ProtoBuf.ProtoMember(22)]
		[System.Xml.Serialization.XmlAttribute(@"fly_easetype")]
		public EEaseType fly_easetype
		{
			get { return _fly_easetype; }
			set { _fly_easetype = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBSkillFlyTargetUnit]{{id:{0}, effect_name:{1}, trigger_id:{2}, fly_start_slotType:{3}, start_socket:{4}, fly_start_spine_socket_name:{5}, fly_end_slot_type:{6}, end_socket:{7}, fly_end_spine_socket_name:{8}, fly_speed:{9}, fly_start_param1:{10}, fly_start_param2:{11}, fly_start_param3:{12}, fly_start_param4:{13}, fly_start_param5:{14}, fly_end_param1:{15}, fly_end_param2:{16}, fly_end_param3:{17}, fly_end_param4:{18}, fly_end_param5:{19}, fly_routinetype:{20}, fly_easetype:{21}}}",
				id, effect_name, trigger_id, fly_start_slotType, start_socket, fly_start_spine_socket_name, fly_end_slot_type, end_socket, fly_end_spine_socket_name, fly_speed, fly_start_param1, fly_start_param2, fly_start_param3, fly_start_param4, fly_start_param5, fly_end_param1, fly_end_param2, fly_end_param3, fly_end_param4, fly_end_param5, fly_routinetype, fly_easetype);
		}

	}

	[ProtoBuf.ProtoContract]
	[System.Xml.Serialization.XmlType(@"PBShockUnit")]
	public partial class PBShockUnit
	{

		private int _id = default(int);
		[ProtoBuf.ProtoMember(1)]
		[System.Xml.Serialization.XmlAttribute(@"id")]
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _shock_name = default(string);
		[ProtoBuf.ProtoMember(2)]
		[System.Xml.Serialization.XmlAttribute(@"shock_name")]
		public string shock_name
		{
			get { return _shock_name; }
			set { _shock_name = value; }
		}

		public override string ToString()
		{
			return string.Format("[PBShockUnit]{{id:{0}, shock_name:{1}}}",
				id, shock_name);
		}

	}

}
