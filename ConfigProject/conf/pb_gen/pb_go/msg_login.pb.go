// Code generated by protoc-gen-go. DO NOT EDIT.
// source: msg_login.proto

package matchproto

import (
	fmt "fmt"
	proto "github.com/golang/protobuf/proto"
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

//------------------------------------------------------------
// 编辑器登录请求
type PBEditorLoginRequest struct {
	Account              *string  `protobuf:"bytes,1,opt,name=account" json:"account,omitempty"`
	Passwd               *string  `protobuf:"bytes,2,opt,name=passwd" json:"passwd,omitempty"`
	XXX_NoUnkeyedLiteral struct{} `json:"-"`
	XXX_unrecognized     []byte   `json:"-"`
	XXX_sizecache        int32    `json:"-"`
}

func (m *PBEditorLoginRequest) Reset()         { *m = PBEditorLoginRequest{} }
func (m *PBEditorLoginRequest) String() string { return proto.CompactTextString(m) }
func (*PBEditorLoginRequest) ProtoMessage()    {}
func (*PBEditorLoginRequest) Descriptor() ([]byte, []int) {
	return fileDescriptor_870c8f5c36664a7c, []int{0}
}

func (m *PBEditorLoginRequest) XXX_Unmarshal(b []byte) error {
	return xxx_messageInfo_PBEditorLoginRequest.Unmarshal(m, b)
}
func (m *PBEditorLoginRequest) XXX_Marshal(b []byte, deterministic bool) ([]byte, error) {
	return xxx_messageInfo_PBEditorLoginRequest.Marshal(b, m, deterministic)
}
func (m *PBEditorLoginRequest) XXX_Merge(src proto.Message) {
	xxx_messageInfo_PBEditorLoginRequest.Merge(m, src)
}
func (m *PBEditorLoginRequest) XXX_Size() int {
	return xxx_messageInfo_PBEditorLoginRequest.Size(m)
}
func (m *PBEditorLoginRequest) XXX_DiscardUnknown() {
	xxx_messageInfo_PBEditorLoginRequest.DiscardUnknown(m)
}

var xxx_messageInfo_PBEditorLoginRequest proto.InternalMessageInfo

func (m *PBEditorLoginRequest) GetAccount() string {
	if m != nil && m.Account != nil {
		return *m.Account
	}
	return ""
}

func (m *PBEditorLoginRequest) GetPasswd() string {
	if m != nil && m.Passwd != nil {
		return *m.Passwd
	}
	return ""
}

// 编辑器登录回复
type PBEditorLoginResponse struct {
	Token                *string  `protobuf:"bytes,1,opt,name=token" json:"token,omitempty"`
	Role                 *ERole   `protobuf:"varint,2,opt,name=role,enum=FunPlus.Common.Config.ERole,def=0" json:"role,omitempty"`
	IdPrefix             *string  `protobuf:"bytes,3,opt,name=id_prefix,json=idPrefix" json:"id_prefix,omitempty"`
	Account              *string  `protobuf:"bytes,4,opt,name=account" json:"account,omitempty"`
	XXX_NoUnkeyedLiteral struct{} `json:"-"`
	XXX_unrecognized     []byte   `json:"-"`
	XXX_sizecache        int32    `json:"-"`
}

func (m *PBEditorLoginResponse) Reset()         { *m = PBEditorLoginResponse{} }
func (m *PBEditorLoginResponse) String() string { return proto.CompactTextString(m) }
func (*PBEditorLoginResponse) ProtoMessage()    {}
func (*PBEditorLoginResponse) Descriptor() ([]byte, []int) {
	return fileDescriptor_870c8f5c36664a7c, []int{1}
}

func (m *PBEditorLoginResponse) XXX_Unmarshal(b []byte) error {
	return xxx_messageInfo_PBEditorLoginResponse.Unmarshal(m, b)
}
func (m *PBEditorLoginResponse) XXX_Marshal(b []byte, deterministic bool) ([]byte, error) {
	return xxx_messageInfo_PBEditorLoginResponse.Marshal(b, m, deterministic)
}
func (m *PBEditorLoginResponse) XXX_Merge(src proto.Message) {
	xxx_messageInfo_PBEditorLoginResponse.Merge(m, src)
}
func (m *PBEditorLoginResponse) XXX_Size() int {
	return xxx_messageInfo_PBEditorLoginResponse.Size(m)
}
func (m *PBEditorLoginResponse) XXX_DiscardUnknown() {
	xxx_messageInfo_PBEditorLoginResponse.DiscardUnknown(m)
}

var xxx_messageInfo_PBEditorLoginResponse proto.InternalMessageInfo

const Default_PBEditorLoginResponse_Role ERole = ERole_Guest

func (m *PBEditorLoginResponse) GetToken() string {
	if m != nil && m.Token != nil {
		return *m.Token
	}
	return ""
}

func (m *PBEditorLoginResponse) GetRole() ERole {
	if m != nil && m.Role != nil {
		return *m.Role
	}
	return Default_PBEditorLoginResponse_Role
}

func (m *PBEditorLoginResponse) GetIdPrefix() string {
	if m != nil && m.IdPrefix != nil {
		return *m.IdPrefix
	}
	return ""
}

func (m *PBEditorLoginResponse) GetAccount() string {
	if m != nil && m.Account != nil {
		return *m.Account
	}
	return ""
}

type PBPingMessage struct {
	SendTime             *int32   `protobuf:"varint,1,opt,name=send_time,json=sendTime" json:"send_time,omitempty"`
	RecvTime             *int32   `protobuf:"varint,2,opt,name=recv_time,json=recvTime" json:"recv_time,omitempty"`
	XXX_NoUnkeyedLiteral struct{} `json:"-"`
	XXX_unrecognized     []byte   `json:"-"`
	XXX_sizecache        int32    `json:"-"`
}

func (m *PBPingMessage) Reset()         { *m = PBPingMessage{} }
func (m *PBPingMessage) String() string { return proto.CompactTextString(m) }
func (*PBPingMessage) ProtoMessage()    {}
func (*PBPingMessage) Descriptor() ([]byte, []int) {
	return fileDescriptor_870c8f5c36664a7c, []int{2}
}

func (m *PBPingMessage) XXX_Unmarshal(b []byte) error {
	return xxx_messageInfo_PBPingMessage.Unmarshal(m, b)
}
func (m *PBPingMessage) XXX_Marshal(b []byte, deterministic bool) ([]byte, error) {
	return xxx_messageInfo_PBPingMessage.Marshal(b, m, deterministic)
}
func (m *PBPingMessage) XXX_Merge(src proto.Message) {
	xxx_messageInfo_PBPingMessage.Merge(m, src)
}
func (m *PBPingMessage) XXX_Size() int {
	return xxx_messageInfo_PBPingMessage.Size(m)
}
func (m *PBPingMessage) XXX_DiscardUnknown() {
	xxx_messageInfo_PBPingMessage.DiscardUnknown(m)
}

var xxx_messageInfo_PBPingMessage proto.InternalMessageInfo

func (m *PBPingMessage) GetSendTime() int32 {
	if m != nil && m.SendTime != nil {
		return *m.SendTime
	}
	return 0
}

func (m *PBPingMessage) GetRecvTime() int32 {
	if m != nil && m.RecvTime != nil {
		return *m.RecvTime
	}
	return 0
}

func init() {
	proto.RegisterType((*PBEditorLoginRequest)(nil), "FunPlus.Common.Config.PBEditorLoginRequest")
	proto.RegisterType((*PBEditorLoginResponse)(nil), "FunPlus.Common.Config.PBEditorLoginResponse")
	proto.RegisterType((*PBPingMessage)(nil), "FunPlus.Common.Config.PBPingMessage")
}

func init() { proto.RegisterFile("msg_login.proto", fileDescriptor_870c8f5c36664a7c) }

var fileDescriptor_870c8f5c36664a7c = []byte{
	// 294 bytes of a gzipped FileDescriptorProto
	0x1f, 0x8b, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0xff, 0x6c, 0x90, 0xc1, 0x4a, 0xf3, 0x40,
	0x14, 0x85, 0x69, 0xff, 0xe4, 0xb7, 0x1d, 0xb4, 0xca, 0xd0, 0x4a, 0xa8, 0x2e, 0x24, 0x2b, 0x57,
	0x59, 0xb8, 0x11, 0xba, 0x4c, 0xa9, 0x22, 0x28, 0x86, 0xe0, 0xca, 0x4d, 0x88, 0xc9, 0x6d, 0x1c,
	0x9c, 0x99, 0x1b, 0x73, 0x27, 0xd5, 0x8d, 0x90, 0x47, 0x71, 0xe1, 0x83, 0xca, 0x4c, 0x2a, 0xa8,
	0xb8, 0x3c, 0xe7, 0xdc, 0x7c, 0x7c, 0x19, 0xb6, 0xaf, 0xa8, 0xca, 0x24, 0x56, 0x42, 0x47, 0x75,
	0x83, 0x06, 0xf9, 0xec, 0xa2, 0xd5, 0x89, 0x6c, 0x29, 0x5a, 0xa2, 0x52, 0xa8, 0xa3, 0x25, 0xea,
	0xb5, 0xa8, 0xe6, 0x13, 0x7b, 0xf7, 0x90, 0x13, 0xf4, 0x67, 0xf3, 0x03, 0x09, 0x1b, 0x90, 0x99,
	0x14, 0x64, 0xfa, 0x26, 0xbc, 0x65, 0xd3, 0x24, 0x5e, 0x95, 0xc2, 0x60, 0x73, 0x6d, 0x79, 0x29,
	0x3c, 0xb7, 0x40, 0x86, 0x07, 0x6c, 0x27, 0x2f, 0x0a, 0x6c, 0xb5, 0x09, 0x06, 0x27, 0x83, 0xd3,
	0x71, 0xfa, 0x15, 0xf9, 0x21, 0xfb, 0x5f, 0xe7, 0x44, 0x2f, 0x65, 0x30, 0x74, 0xc3, 0x36, 0x2d,
	0xfc, 0xee, 0xad, 0xeb, 0xbc, 0xf0, 0x63, 0xc0, 0x66, 0xbf, 0x88, 0x54, 0xa3, 0x26, 0xe0, 0x53,
	0xe6, 0x1b, 0x7c, 0x02, 0xbd, 0x05, 0xf6, 0x81, 0x9f, 0x33, 0xaf, 0x41, 0x09, 0x0e, 0x36, 0x39,
	0x3b, 0x8e, 0xfe, 0xfc, 0x91, 0x68, 0x95, 0xa2, 0x84, 0x85, 0x7f, 0x69, 0xdd, 0x52, 0xf7, 0x01,
	0x3f, 0x62, 0x63, 0x51, 0x66, 0x75, 0x03, 0x6b, 0xf1, 0x1a, 0xfc, 0x73, 0xc8, 0x91, 0x28, 0x13,
	0x97, 0xbf, 0xeb, 0x7b, 0x3f, 0xf4, 0x9d, 0xe6, 0xbb, 0x17, 0x5e, 0xb1, 0xbd, 0x24, 0x4e, 0x84,
	0xae, 0x6e, 0x80, 0x28, 0xaf, 0x1c, 0x8e, 0x40, 0x97, 0x99, 0x11, 0x0a, 0x9c, 0xa1, 0x9f, 0x8e,
	0x6c, 0x71, 0x27, 0x94, 0x1b, 0x1b, 0x28, 0x36, 0xfd, 0x38, 0xec, 0x47, 0x5b, 0xd8, 0x31, 0xde,
	0xbd, 0x67, 0x2a, 0x37, 0xc5, 0xa3, 0x7b, 0xd0, 0xcf, 0x00, 0x00, 0x00, 0xff, 0xff, 0x34, 0xad,
	0x6d, 0x37, 0x9b, 0x01, 0x00, 0x00,
}
