//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sc_msg_item.proto
// Note: requires additional types generated from: msg_base.proto
// Note: requires additional types generated from: msg_common.proto
namespace FunPlus.Common.Config
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBAllItemDataRequest")]
  public partial class PBAllItemDataRequest
  {
    public PBAllItemDataRequest() {}
    
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBAllItemDataResponse")]
  public partial class PBAllItemDataResponse
  {
    public PBAllItemDataResponse() {}
    
    // TYPE_MESSAGE.FunPlus.Common.Config.PBItemData : datas
    [global::ProtoBuf.ProtoMember(1, Name=@"datas", DataFormat = global::ProtoBuf.DataFormat.Default)]
	public readonly global::System.Collections.Generic.List<FunPlus.Common.Config.PBItemData> datas = new global::System.Collections.Generic.List<FunPlus.Common.Config.PBItemData>();
  
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBItemUseRequest")]
  public partial class PBItemUseRequest
  {
    public PBItemUseRequest() {}
    
    // TYPE_UINT32 : id
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
	public uint id = default(uint);
  
    // TYPE_UINT32 : count
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
	public uint count = default(uint);
  
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBItemUseResponse")]
  public partial class PBItemUseResponse
  {
    public PBItemUseResponse() {}
    
    // TYPE_UINT32 : id
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
	public uint id = default(uint);
  
    // TYPE_MESSAGE.FunPlus.Common.Config.PBItemValue : data
    [global::ProtoBuf.ProtoMember(2, Name=@"data", DataFormat = global::ProtoBuf.DataFormat.Default)]
	public readonly global::System.Collections.Generic.List<FunPlus.Common.Config.PBItemValue> data = new global::System.Collections.Generic.List<FunPlus.Common.Config.PBItemValue>();
  
  }
  
}