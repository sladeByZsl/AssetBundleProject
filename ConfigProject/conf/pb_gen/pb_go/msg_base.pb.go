// Code generated by protoc-gen-go. DO NOT EDIT.
// source: msg_base.proto

package matchproto

import (
	fmt "fmt"
	proto "github.com/golang/protobuf/proto"
	descriptor "github.com/golang/protobuf/protoc-gen-go/descriptor"
	math "math"
)

// Reference imports to suppress errors if they are not otherwise used.
var _ = proto.Marshal
var _ = fmt.Errorf
var _ = math.Inf

// This is a compile-time assertion to ensure that this generated file
// is compatible with the proto package it is being compiled against.
// A compilation error at this line likely means your copy of the
// proto package needs to be updated.
const _ = proto.ProtoPackageIsVersion3 // please upgrade the proto package

// Http通信的消息头
type PBHttpMessage struct {
	MsgId                *int32   `protobuf:"varint,1,opt,name=msg_id,json=msgId" json:"msg_id,omitempty"`
	UserId               *int32   `protobuf:"varint,2,opt,name=user_id,json=userId" json:"user_id,omitempty"`
	SessionId            *int32   `protobuf:"varint,3,opt,name=session_id,json=sessionId" json:"session_id,omitempty"`
	RetCode              *int32   `protobuf:"varint,4,opt,name=ret_code,json=retCode,def=0" json:"ret_code,omitempty"`
	RetMsg               *string  `protobuf:"bytes,5,opt,name=ret_msg,json=retMsg" json:"ret_msg,omitempty"`
	Body                 []byte   `protobuf:"bytes,6,opt,name=body" json:"body,omitempty"`
	XXX_NoUnkeyedLiteral struct{} `json:"-"`
	XXX_unrecognized     []byte   `json:"-"`
	XXX_sizecache        int32    `json:"-"`
}

func (m *PBHttpMessage) Reset()         { *m = PBHttpMessage{} }
func (m *PBHttpMessage) String() string { return proto.CompactTextString(m) }
func (*PBHttpMessage) ProtoMessage()    {}
func (*PBHttpMessage) Descriptor() ([]byte, []int) {
	return fileDescriptor_d24cbed65e9f2591, []int{0}
}

func (m *PBHttpMessage) XXX_Unmarshal(b []byte) error {
	return xxx_messageInfo_PBHttpMessage.Unmarshal(m, b)
}
func (m *PBHttpMessage) XXX_Marshal(b []byte, deterministic bool) ([]byte, error) {
	return xxx_messageInfo_PBHttpMessage.Marshal(b, m, deterministic)
}
func (m *PBHttpMessage) XXX_Merge(src proto.Message) {
	xxx_messageInfo_PBHttpMessage.Merge(m, src)
}
func (m *PBHttpMessage) XXX_Size() int {
	return xxx_messageInfo_PBHttpMessage.Size(m)
}
func (m *PBHttpMessage) XXX_DiscardUnknown() {
	xxx_messageInfo_PBHttpMessage.DiscardUnknown(m)
}

var xxx_messageInfo_PBHttpMessage proto.InternalMessageInfo

const Default_PBHttpMessage_RetCode int32 = 0

func (m *PBHttpMessage) GetMsgId() int32 {
	if m != nil && m.MsgId != nil {
		return *m.MsgId
	}
	return 0
}

func (m *PBHttpMessage) GetUserId() int32 {
	if m != nil && m.UserId != nil {
		return *m.UserId
	}
	return 0
}

func (m *PBHttpMessage) GetSessionId() int32 {
	if m != nil && m.SessionId != nil {
		return *m.SessionId
	}
	return 0
}

func (m *PBHttpMessage) GetRetCode() int32 {
	if m != nil && m.RetCode != nil {
		return *m.RetCode
	}
	return Default_PBHttpMessage_RetCode
}

func (m *PBHttpMessage) GetRetMsg() string {
	if m != nil && m.RetMsg != nil {
		return *m.RetMsg
	}
	return ""
}

func (m *PBHttpMessage) GetBody() []byte {
	if m != nil {
		return m.Body
	}
	return nil
}

var E_OptionModuleType = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.EnumOptions)(nil),
	ExtensionType: (*EModuleTypeIndex)(nil),
	Field:         2000,
	Name:          "FunPlus.Common.Config.OptionModuleType",
	Tag:           "varint,2000,opt,name=OptionModuleType,enum=FunPlus.Common.Config.EModuleTypeIndex",
	Filename:      "msg_base.proto",
}

var E_OptionModuleIndex = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.EnumOptions)(nil),
	ExtensionType: (*uint32)(nil),
	Field:         2001,
	Name:          "FunPlus.Common.Config.OptionModuleIndex",
	Tag:           "varint,2001,opt,name=OptionModuleIndex",
	Filename:      "msg_base.proto",
}

var E_OptionMessageId = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.MessageOptions)(nil),
	ExtensionType: (*EMessageId)(nil),
	Field:         2000,
	Name:          "FunPlus.Common.Config.OptionMessageId",
	Tag:           "varint,2000,opt,name=OptionMessageId,enum=FunPlus.Common.Config.EMessageId",
	Filename:      "msg_base.proto",
}

var E_OptionXmlFile = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.MessageOptions)(nil),
	ExtensionType: (*string)(nil),
	Field:         3000,
	Name:          "FunPlus.Common.Config.OptionXmlFile",
	Tag:           "bytes,3000,opt,name=OptionXmlFile",
	Filename:      "msg_base.proto",
}

var E_OptionXmlOnly = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.MessageOptions)(nil),
	ExtensionType: (*bool)(nil),
	Field:         3001,
	Name:          "FunPlus.Common.Config.OptionXmlOnly",
	Tag:           "varint,3001,opt,name=OptionXmlOnly",
	Filename:      "msg_base.proto",
}

var E_OptionXmlMessageAlias = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.MessageOptions)(nil),
	ExtensionType: (*string)(nil),
	Field:         3002,
	Name:          "FunPlus.Common.Config.OptionXmlMessageAlias",
	Tag:           "bytes,3002,opt,name=OptionXmlMessageAlias",
	Filename:      "msg_base.proto",
}

var E_OptionServerOnly = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.FieldOptions)(nil),
	ExtensionType: (*bool)(nil),
	Field:         3000,
	Name:          "FunPlus.Common.Config.OptionServerOnly",
	Tag:           "varint,3000,opt,name=OptionServerOnly",
	Filename:      "msg_base.proto",
}

var E_OptionXmlFieldAlias = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.FieldOptions)(nil),
	ExtensionType: (*string)(nil),
	Field:         3001,
	Name:          "FunPlus.Common.Config.OptionXmlFieldAlias",
	Tag:           "bytes,3001,opt,name=OptionXmlFieldAlias",
	Filename:      "msg_base.proto",
}

var E_OptionIpv4Field = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.FieldOptions)(nil),
	ExtensionType: (*bool)(nil),
	Field:         3002,
	Name:          "FunPlus.Common.Config.OptionIpv4Field",
	Tag:           "varint,3002,opt,name=OptionIpv4Field",
	Filename:      "msg_base.proto",
}

var E_OptionDateTimeField = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.FieldOptions)(nil),
	ExtensionType: (*bool)(nil),
	Field:         3003,
	Name:          "FunPlus.Common.Config.OptionDateTimeField",
	Tag:           "varint,3003,opt,name=OptionDateTimeField",
	Filename:      "msg_base.proto",
}

var E_OptionHint = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.EnumValueOptions)(nil),
	ExtensionType: (*string)(nil),
	Field:         3000,
	Name:          "FunPlus.Common.Config.OptionHint",
	Tag:           "bytes,3000,opt,name=OptionHint",
	Filename:      "msg_base.proto",
}

var E_OptionXmlValueAlias = &proto.ExtensionDesc{
	ExtendedType:  (*descriptor.EnumValueOptions)(nil),
	ExtensionType: (*string)(nil),
	Field:         3001,
	Name:          "FunPlus.Common.Config.OptionXmlValueAlias",
	Tag:           "bytes,3001,opt,name=OptionXmlValueAlias",
	Filename:      "msg_base.proto",
}

func init() {
	proto.RegisterType((*PBHttpMessage)(nil), "FunPlus.Common.Config.PBHttpMessage")
	proto.RegisterExtension(E_OptionModuleType)
	proto.RegisterExtension(E_OptionModuleIndex)
	proto.RegisterExtension(E_OptionMessageId)
	proto.RegisterExtension(E_OptionXmlFile)
	proto.RegisterExtension(E_OptionXmlOnly)
	proto.RegisterExtension(E_OptionXmlMessageAlias)
	proto.RegisterExtension(E_OptionServerOnly)
	proto.RegisterExtension(E_OptionXmlFieldAlias)
	proto.RegisterExtension(E_OptionIpv4Field)
	proto.RegisterExtension(E_OptionDateTimeField)
	proto.RegisterExtension(E_OptionHint)
	proto.RegisterExtension(E_OptionXmlValueAlias)
}

func init() { proto.RegisterFile("msg_base.proto", fileDescriptor_d24cbed65e9f2591) }

var fileDescriptor_d24cbed65e9f2591 = []byte{
	// 524 bytes of a gzipped FileDescriptorProto
	0x1f, 0x8b, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0xff, 0x8c, 0x92, 0xcf, 0x6e, 0xd3, 0x40,
	0x10, 0xc6, 0x65, 0x68, 0xd2, 0x74, 0xd5, 0x34, 0xad, 0xa3, 0xa8, 0x51, 0xd5, 0x8a, 0x94, 0x0b,
	0x39, 0xb9, 0x08, 0x71, 0xda, 0x1b, 0x09, 0x8d, 0x62, 0x50, 0xd4, 0xc8, 0x44, 0x15, 0xe2, 0x12,
	0x39, 0xd9, 0x89, 0x59, 0xc9, 0xf6, 0x58, 0xde, 0x75, 0x45, 0x1e, 0x89, 0x37, 0xa0, 0xe5, 0x25,
	0xe0, 0x8d, 0xd0, 0xee, 0x3a, 0xff, 0x83, 0xdc, 0x9b, 0x3d, 0x33, 0xdf, 0x6f, 0xbe, 0x99, 0x59,
	0x72, 0x12, 0x89, 0x60, 0x3c, 0xf1, 0x05, 0x38, 0x49, 0x8a, 0x12, 0xed, 0x46, 0x2f, 0x8b, 0x87,
	0x61, 0x26, 0x9c, 0x2e, 0x46, 0x11, 0xc6, 0x4e, 0x17, 0xe3, 0x19, 0x0f, 0x2e, 0x5a, 0x01, 0x62,
	0x10, 0xc2, 0x8d, 0x2e, 0x9a, 0x64, 0xb3, 0x1b, 0x06, 0x62, 0x9a, 0xf2, 0x44, 0x62, 0x6a, 0x84,
	0x17, 0x75, 0x05, 0xe2, 0x6c, 0xcc, 0x60, 0xc6, 0xe3, 0x9c, 0xf6, 0xfa, 0xa7, 0x45, 0xaa, 0xc3,
	0x4e, 0x5f, 0xca, 0x64, 0x00, 0x42, 0xf8, 0x01, 0xd8, 0x0d, 0x52, 0x36, 0x85, 0x4d, 0xab, 0x65,
	0xb5, 0x4b, 0x5e, 0x29, 0x12, 0x81, 0xcb, 0xec, 0x73, 0x72, 0x98, 0x09, 0x48, 0x55, 0xfc, 0x85,
	0x8e, 0x97, 0xd5, 0xaf, 0xcb, 0xec, 0x2b, 0x42, 0x04, 0x08, 0xc1, 0x31, 0x56, 0xb9, 0x97, 0x3a,
	0x77, 0x94, 0x47, 0x5c, 0x66, 0x5f, 0x92, 0x4a, 0x0a, 0x72, 0x3c, 0x45, 0x06, 0xcd, 0x03, 0x95,
	0xa4, 0xd6, 0x5b, 0xef, 0x30, 0x05, 0xd9, 0x45, 0x06, 0x8a, 0xaa, 0xb2, 0x91, 0x08, 0x9a, 0xa5,
	0x96, 0xd5, 0x3e, 0xf2, 0xca, 0x29, 0xc8, 0x81, 0x08, 0x6c, 0x9b, 0x1c, 0x4c, 0x90, 0xcd, 0x9b,
	0xe5, 0x96, 0xd5, 0x3e, 0xf6, 0xf4, 0x37, 0x4d, 0xc9, 0xe9, 0x5d, 0x22, 0x39, 0xc6, 0x03, 0x64,
	0x59, 0x08, 0xa3, 0x79, 0x02, 0xf6, 0xa5, 0x63, 0xe6, 0x76, 0x16, 0x73, 0x3b, 0xb7, 0x71, 0x16,
	0x99, 0x32, 0xd1, 0xfc, 0x53, 0x6b, 0x59, 0xed, 0x93, 0x77, 0x6f, 0x9c, 0xbd, 0x3b, 0x73, 0x6e,
	0x57, 0x20, 0x37, 0x66, 0xf0, 0xc3, 0x3b, 0xc5, 0x2d, 0x3e, 0xfd, 0x4c, 0xce, 0xd6, 0x7b, 0xea,
	0xb2, 0x82, 0xa6, 0x7f, 0x55, 0xd3, 0xaa, 0x77, 0x86, 0xdb, 0x3a, 0x1a, 0x91, 0x5a, 0x0e, 0x33,
	0xbb, 0x76, 0x99, 0xfd, 0x6a, 0x07, 0x95, 0xe7, 0xb6, 0x46, 0xb8, 0xfe, 0xef, 0x08, 0x0b, 0x94,
	0x57, 0xc3, 0x4d, 0x36, 0xed, 0x91, 0xaa, 0xa1, 0x7c, 0x8d, 0xc2, 0x1e, 0x0f, 0xa1, 0xb8, 0xd9,
	0xaf, 0x73, 0x7d, 0x84, 0x2a, 0xae, 0xcb, 0x36, 0x38, 0x77, 0x71, 0x38, 0x2f, 0xe6, 0x3c, 0x2a,
	0x4e, 0x65, 0x8d, 0xa3, 0x64, 0xf4, 0x9e, 0x34, 0x96, 0x9c, 0x5c, 0xf0, 0x21, 0xe4, 0xbe, 0x28,
	0xe6, 0x3d, 0x19, 0x5f, 0x0d, 0xdc, 0x27, 0xa7, 0x9f, 0x16, 0xef, 0xe2, 0x0b, 0xa4, 0x0f, 0x90,
	0x6a, 0x8b, 0x57, 0x3b, 0xc8, 0x1e, 0x87, 0x90, 0x6d, 0x0c, 0x5a, 0x59, 0xdc, 0x7b, 0xa5, 0xa3,
	0x43, 0x52, 0x5f, 0xdb, 0x19, 0x84, 0xcc, 0x38, 0x2c, 0xc0, 0x3d, 0x1a, 0x7f, 0x75, 0xdc, 0x95,
	0xd2, 0xfe, 0xe2, 0xe8, 0x6e, 0xf2, 0xf0, 0x5e, 0xc7, 0x8b, 0x68, 0x4f, 0xc6, 0x5c, 0x7e, 0xcf,
	0xa5, 0x6c, 0xe5, 0xed, 0xa3, 0x2f, 0x61, 0xc4, 0x23, 0x78, 0x16, 0xed, 0xb7, 0xa1, 0xe5, 0xde,
	0x36, 0xa4, 0xb4, 0x43, 0x88, 0x29, 0xeb, 0xf3, 0x58, 0xda, 0xd7, 0x7b, 0x9f, 0xf5, 0xbd, 0x1f,
	0x66, 0xdb, 0x0f, 0x84, 0xe0, 0x52, 0x45, 0x47, 0x6b, 0x1b, 0xd3, 0xb5, 0x66, 0x63, 0xcf, 0x80,
	0xed, 0x6c, 0x6d, 0x25, 0xef, 0x1c, 0x7f, 0x23, 0x91, 0x2f, 0xa7, 0xdf, 0xb5, 0xfa, 0x5f, 0x00,
	0x00, 0x00, 0xff, 0xff, 0x9b, 0xa1, 0x4d, 0x38, 0x04, 0x05, 0x00, 0x00,
}
