//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sc_msg_debug_cmd.proto
// Note: requires additional types generated from: msg_base.proto
namespace FunPlus.Common.Config
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBDebugCmd")]
  public partial class PBDebugCmd
  {
    public PBDebugCmd() {}
    
    // TYPE_INT32 : op_type
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"op_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
	public int op_type = default(int);
  
    // TYPE_STRING : parameters
    [global::ProtoBuf.ProtoMember(2, Name=@"parameters", DataFormat = global::ProtoBuf.DataFormat.Default)]
	public readonly global::System.Collections.Generic.List<string> parameters = new global::System.Collections.Generic.List<string>();
  
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBDebugCmdRequest")]
  public partial class PBDebugCmdRequest
  {
    public PBDebugCmdRequest() {}
    
    // TYPE_MESSAGE.FunPlus.Common.Config.PBDebugCmd : debug_cmds
    [global::ProtoBuf.ProtoMember(1, Name=@"debug_cmds", DataFormat = global::ProtoBuf.DataFormat.Default)]
	public readonly global::System.Collections.Generic.List<FunPlus.Common.Config.PBDebugCmd> debug_cmds = new global::System.Collections.Generic.List<FunPlus.Common.Config.PBDebugCmd>();
  
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBDebugCmdResponse")]
  public partial class PBDebugCmdResponse
  {
    public PBDebugCmdResponse() {}
    
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"ESDebugCmd")]
    public enum ESDebugCmd
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_Invalid", Value=0)]
      CDC_Invalid = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_AddDiamond", Value=1)]
      CDC_AddDiamond = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_AddGold", Value=2)]
      CDC_AddGold = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_AddStone", Value=3)]
      CDC_AddStone = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_GainHeroCard", Value=4)]
      CDC_GainHeroCard = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_GainAllHeroes", Value=5)]
      CDC_GainAllHeroes = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_UnlockDungeon", Value=6)]
      CDC_UnlockDungeon = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_AddItem", Value=7)]
      CDC_AddItem = 7,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_GetDropRewards", Value=8)]
      CDC_GetDropRewards = 8,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_RemoveItem", Value=9)]
      CDC_RemoveItem = 9,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_AddResource", Value=10)]
      CDC_AddResource = 10,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_UseItem", Value=11)]
      CDC_UseItem = 11,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_FillEnergy", Value=12)]
      CDC_FillEnergy = 12,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CDC_SetFakeTime", Value=1001)]
      CDC_SetFakeTime = 1001
    }
  
}