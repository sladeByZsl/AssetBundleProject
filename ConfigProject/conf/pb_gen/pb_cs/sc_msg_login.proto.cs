//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: sc_msg_login.proto
// Note: requires additional types generated from: msg_base.proto
// Note: requires additional types generated from: msg_bi_data.proto
// Note: requires additional types generated from: enum_define.proto
namespace FunPlus.Common.Config
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBLoginRequest")]
  public partial class PBLoginRequest
  {
    public PBLoginRequest() {}
    
    // TYPE_STRING : fpid
    public string _fpid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"fpid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string fpid
    {
      get { return _fpid; }
      set { _fpid = value; }
    }
    // TYPE_INT32 : serverid
    public int _serverid;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"serverid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int serverid
    {
      get { return _serverid; }
      set { _serverid = value; }
    }
    // TYPE_STRING : app_version
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"app_version", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
	public string app_version = "";
  
    // TYPE_INT32 : res_version
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"res_version", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
	public int res_version = default(int);
  
    // TYPE_STRING : session_key
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"session_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
	public string session_key = "";
  
    // TYPE_MESSAGE.FunPlus.Common.Config.PBBIPlayerLogin : bi_data
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"bi_data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
	public FunPlus.Common.Config.PBBIPlayerLogin bi_data = null;
  
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBLoginResponse")]
  public partial class PBLoginResponse
  {
    public PBLoginResponse() {}
    
    // TYPE_STRING : fpid
    public string _fpid;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"fpid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string fpid
    {
      get { return _fpid; }
      set { _fpid = value; }
    }
    // TYPE_INT32 : serverid
    public int _serverid;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"serverid", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int serverid
    {
      get { return _serverid; }
      set { _serverid = value; }
    }
    // TYPE_STRING : roleid
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"roleid", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
	public string roleid = "";
  
    //  : servertime
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"servertime", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(double))]
	public double servertime = default(double);
  
    // TYPE_BOOL : new_role
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"new_role", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
	public bool new_role = default(bool);
  
    // TYPE_BOOL : prologue_passed
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"prologue_passed", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
	public bool prologue_passed = default(bool);
  
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBPlayerDataRequest")]
  public partial class PBPlayerDataRequest
  {
    public PBPlayerDataRequest() {}
    
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBPlayerDataResponse")]
  public partial class PBPlayerDataResponse
  {
    public PBPlayerDataResponse() {}
    
    // TYPE_MESSAGE.FunPlus.Common.Config.PBResourceValue : balance
    [global::ProtoBuf.ProtoMember(1, Name=@"balance", DataFormat = global::ProtoBuf.DataFormat.Default)]
	public readonly global::System.Collections.Generic.List<FunPlus.Common.Config.PBResourceValue> balance = new global::System.Collections.Generic.List<FunPlus.Common.Config.PBResourceValue>();
  
    // TYPE_UINT32 : titleLevel
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"titleLevel", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
	public uint titleLevel = default(uint);
  
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBPrologueFinishRequest")]
  public partial class PBPrologueFinishRequest
  {
    public PBPrologueFinishRequest() {}
    
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PBPrologueFinishResponse")]
  public partial class PBPrologueFinishResponse
  {
    public PBPrologueFinishResponse() {}
    
  }
  
}