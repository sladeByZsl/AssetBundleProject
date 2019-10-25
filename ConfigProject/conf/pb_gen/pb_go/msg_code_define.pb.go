// Code generated by protoc-gen-go. DO NOT EDIT.
// source: msg_code_define.proto

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

type EMessageCode int32

const (
	// from -32768 to 32767
	EMessageCode_CODE_Success                  EMessageCode = 0
	EMessageCode_CODE_ErrPasswd                EMessageCode = -1
	EMessageCode_CODE_ErrTokenErr              EMessageCode = -2
	EMessageCode_CODE_ErrPermisson             EMessageCode = -3
	EMessageCode_CODE_ErrEditorCreate          EMessageCode = -102
	EMessageCode_CODE_ErrEditorMoveTarget      EMessageCode = -103
	EMessageCode_CODE_ErrEditorMoveTo          EMessageCode = -104
	EMessageCode_CODE_ErrEditorCopyTo          EMessageCode = -105
	EMessageCode_CODE_ErrOtherLocked           EMessageCode = -106
	EMessageCode_CODE_ErrLockFirst             EMessageCode = -107
	EMessageCode_CODE_ErrParamMiss             EMessageCode = -821
	EMessageCode_CODE_ErrTokenInvalid          EMessageCode = -822
	EMessageCode_CODE_ErrTokenTimeout          EMessageCode = -823
	EMessageCode_CODE_ErrAppIdMismatch         EMessageCode = -824
	EMessageCode_CODE_ErrCharIdNotExist        EMessageCode = -871
	EMessageCode_CODE_UserAlreadyOffline       EMessageCode = -870
	EMessageCode_CODE_UserLoginFromOtherDevice EMessageCode = -872
	EMessageCode_CODE_CharAlreadyCreated       EMessageCode = -900
	// 服务器内部
	EMessageCode_CODE_UserDataMiss       EMessageCode = -1001
	EMessageCode_CODE_UserDataLoadFailed EMessageCode = -1002
	EMessageCode_CODE_UserDataSaveFailed EMessageCode = -1003
	EMessageCode_CODE_UserIdNotExist     EMessageCode = -1004
	//700 - 800 Google登录 / 关卡管理相关
	EMessageCode_CODE_GooglePermissionsError EMessageCode = 701
	EMessageCode_CODE_AuthError              EMessageCode = 702
	EMessageCode_CODE_UserIdUnequalError     EMessageCode = 703
	EMessageCode_CODE_GoodsIdNotExist        EMessageCode = -1201
	EMessageCode_CODE_ScoreNotEnough         EMessageCode = -1202
	EMessageCode_CODE_DiamondNotEnough       EMessageCode = -1203
	EMessageCode_CODE_GoldBeanNotEnough      EMessageCode = -1204
	EMessageCode_CODE_RoomCardNotEnough      EMessageCode = -1205
	EMessageCode_CODE_CashNotEnough          EMessageCode = -1206
	EMessageCode_CODE_MoneyTypeMismatch      EMessageCode = -1207
	EMessageCode_CODE_OrderIdRepeated        EMessageCode = -1208
	EMessageCode_CODE_OrderStateError        EMessageCode = -1209
	EMessageCode_CODE_InvalidMoneyNumber     EMessageCode = -1210
	EMessageCode_CODE_MailIdNotExist         EMessageCode = -1301
	EMessageCode_CODE_MailStateMismatch      EMessageCode = -1302
	EMessageCode_CODE_AlreadyFriend          EMessageCode = -1501
	EMessageCode_CODE_IsNotMyFriend          EMessageCode = -1502
	EMessageCode_CODE_ActvNotOpenToUser      EMessageCode = -2001
	EMessageCode_CODE_ActvIdNotExist         EMessageCode = -2002
	EMessageCode_CODE_ActvExceedTimes        EMessageCode = -2003
	EMessageCode_CODE_ActvHasBindInviter     EMessageCode = -2004
	EMessageCode_CODE_ActvInvalidInviteCode  EMessageCode = -2005
	EMessageCode_CODE_ActvForbidBindInvitee  EMessageCode = -2006
	EMessageCode_CODE_TaskIdNotExist         EMessageCode = -2101
	EMessageCode_CODE_TaskRewardMiss         EMessageCode = -2102
	EMessageCode_CODE_ErrInnerLogic          EMessageCode = -200
)

var EMessageCode_name = map[int32]string{
	0:     "CODE_Success",
	-1:    "CODE_ErrPasswd",
	-2:    "CODE_ErrTokenErr",
	-3:    "CODE_ErrPermisson",
	-102:  "CODE_ErrEditorCreate",
	-103:  "CODE_ErrEditorMoveTarget",
	-104:  "CODE_ErrEditorMoveTo",
	-105:  "CODE_ErrEditorCopyTo",
	-106:  "CODE_ErrOtherLocked",
	-107:  "CODE_ErrLockFirst",
	-821:  "CODE_ErrParamMiss",
	-822:  "CODE_ErrTokenInvalid",
	-823:  "CODE_ErrTokenTimeout",
	-824:  "CODE_ErrAppIdMismatch",
	-871:  "CODE_ErrCharIdNotExist",
	-870:  "CODE_UserAlreadyOffline",
	-872:  "CODE_UserLoginFromOtherDevice",
	-900:  "CODE_CharAlreadyCreated",
	-1001: "CODE_UserDataMiss",
	-1002: "CODE_UserDataLoadFailed",
	-1003: "CODE_UserDataSaveFailed",
	-1004: "CODE_UserIdNotExist",
	701:   "CODE_GooglePermissionsError",
	702:   "CODE_AuthError",
	703:   "CODE_UserIdUnequalError",
	-1201: "CODE_GoodsIdNotExist",
	-1202: "CODE_ScoreNotEnough",
	-1203: "CODE_DiamondNotEnough",
	-1204: "CODE_GoldBeanNotEnough",
	-1205: "CODE_RoomCardNotEnough",
	-1206: "CODE_CashNotEnough",
	-1207: "CODE_MoneyTypeMismatch",
	-1208: "CODE_OrderIdRepeated",
	-1209: "CODE_OrderStateError",
	-1210: "CODE_InvalidMoneyNumber",
	-1301: "CODE_MailIdNotExist",
	-1302: "CODE_MailStateMismatch",
	-1501: "CODE_AlreadyFriend",
	-1502: "CODE_IsNotMyFriend",
	-2001: "CODE_ActvNotOpenToUser",
	-2002: "CODE_ActvIdNotExist",
	-2003: "CODE_ActvExceedTimes",
	-2004: "CODE_ActvHasBindInviter",
	-2005: "CODE_ActvInvalidInviteCode",
	-2006: "CODE_ActvForbidBindInvitee",
	-2101: "CODE_TaskIdNotExist",
	-2102: "CODE_TaskRewardMiss",
	-200:  "CODE_ErrInnerLogic",
}

var EMessageCode_value = map[string]int32{
	"CODE_Success":                  0,
	"CODE_ErrPasswd":                -1,
	"CODE_ErrTokenErr":              -2,
	"CODE_ErrPermisson":             -3,
	"CODE_ErrEditorCreate":          -102,
	"CODE_ErrEditorMoveTarget":      -103,
	"CODE_ErrEditorMoveTo":          -104,
	"CODE_ErrEditorCopyTo":          -105,
	"CODE_ErrOtherLocked":           -106,
	"CODE_ErrLockFirst":             -107,
	"CODE_ErrParamMiss":             -821,
	"CODE_ErrTokenInvalid":          -822,
	"CODE_ErrTokenTimeout":          -823,
	"CODE_ErrAppIdMismatch":         -824,
	"CODE_ErrCharIdNotExist":        -871,
	"CODE_UserAlreadyOffline":       -870,
	"CODE_UserLoginFromOtherDevice": -872,
	"CODE_CharAlreadyCreated":       -900,
	"CODE_UserDataMiss":             -1001,
	"CODE_UserDataLoadFailed":       -1002,
	"CODE_UserDataSaveFailed":       -1003,
	"CODE_UserIdNotExist":           -1004,
	"CODE_GooglePermissionsError":   701,
	"CODE_AuthError":                702,
	"CODE_UserIdUnequalError":       703,
	"CODE_GoodsIdNotExist":          -1201,
	"CODE_ScoreNotEnough":           -1202,
	"CODE_DiamondNotEnough":         -1203,
	"CODE_GoldBeanNotEnough":        -1204,
	"CODE_RoomCardNotEnough":        -1205,
	"CODE_CashNotEnough":            -1206,
	"CODE_MoneyTypeMismatch":        -1207,
	"CODE_OrderIdRepeated":          -1208,
	"CODE_OrderStateError":          -1209,
	"CODE_InvalidMoneyNumber":       -1210,
	"CODE_MailIdNotExist":           -1301,
	"CODE_MailStateMismatch":        -1302,
	"CODE_AlreadyFriend":            -1501,
	"CODE_IsNotMyFriend":            -1502,
	"CODE_ActvNotOpenToUser":        -2001,
	"CODE_ActvIdNotExist":           -2002,
	"CODE_ActvExceedTimes":          -2003,
	"CODE_ActvHasBindInviter":       -2004,
	"CODE_ActvInvalidInviteCode":    -2005,
	"CODE_ActvForbidBindInvitee":    -2006,
	"CODE_TaskIdNotExist":           -2101,
	"CODE_TaskRewardMiss":           -2102,
	"CODE_ErrInnerLogic":            -200,
}

func (x EMessageCode) Enum() *EMessageCode {
	p := new(EMessageCode)
	*p = x
	return p
}

func (x EMessageCode) String() string {
	return proto.EnumName(EMessageCode_name, int32(x))
}

func (x *EMessageCode) UnmarshalJSON(data []byte) error {
	value, err := proto.UnmarshalJSONEnum(EMessageCode_value, data, "EMessageCode")
	if err != nil {
		return err
	}
	*x = EMessageCode(value)
	return nil
}

func (EMessageCode) EnumDescriptor() ([]byte, []int) {
	return fileDescriptor_6502ba55eea84b87, []int{0}
}

func init() {
	proto.RegisterEnum("FunPlus.Common.Config.EMessageCode", EMessageCode_name, EMessageCode_value)
}

func init() { proto.RegisterFile("msg_code_define.proto", fileDescriptor_6502ba55eea84b87) }

var fileDescriptor_6502ba55eea84b87 = []byte{
	// 750 bytes of a gzipped FileDescriptorProto
	0x1f, 0x8b, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0xff, 0x7c, 0x95, 0xcb, 0x4e, 0x1b, 0x49,
	0x14, 0x86, 0x87, 0x05, 0x9b, 0x12, 0x33, 0xaa, 0x31, 0xc3, 0xcc, 0x68, 0x18, 0xe6, 0x9a, 0x28,
	0x12, 0x0b, 0xde, 0xc1, 0xd8, 0x6d, 0x62, 0x09, 0xdb, 0x08, 0x9b, 0x4d, 0x36, 0xa8, 0xe8, 0x3a,
	0xb6, 0x4b, 0x74, 0xd7, 0x71, 0xaa, 0xaa, 0x0d, 0x7e, 0x88, 0xec, 0x42, 0xb8, 0x2c, 0x93, 0x5d,
	0xae, 0xdb, 0x6c, 0x92, 0xec, 0x12, 0x2e, 0xb9, 0xbc, 0x47, 0xb2, 0x80, 0x05, 0x58, 0x44, 0xca,
	0x4d, 0xdd, 0xed, 0x76, 0x77, 0x54, 0x06, 0x2f, 0xfb, 0x7c, 0x3e, 0xe7, 0xaf, 0xff, 0x3f, 0xd5,
	0x4d, 0xa6, 0x7c, 0xdd, 0x5a, 0x75, 0x91, 0xc3, 0x2a, 0x87, 0xa6, 0x90, 0x30, 0xd7, 0x51, 0x68,
	0x30, 0x37, 0x55, 0x0a, 0xe4, 0x92, 0x17, 0xe8, 0xb9, 0x02, 0xfa, 0x3e, 0xca, 0xb9, 0x02, 0xca,
	0xa6, 0x68, 0xcd, 0xde, 0xfa, 0x91, 0x4c, 0x38, 0x15, 0xd0, 0x9a, 0xb5, 0xa0, 0x80, 0x1c, 0x72,
	0x94, 0x4c, 0x14, 0x6a, 0x45, 0x67, 0xb5, 0x1e, 0xb8, 0x2e, 0x68, 0x4d, 0x7f, 0xc8, 0x4d, 0x93,
	0x9f, 0xa2, 0x27, 0x8e, 0x52, 0x4b, 0x4c, 0xeb, 0x0d, 0x4e, 0xbf, 0x26, 0xbf, 0xb1, 0xdc, 0x0c,
	0xa1, 0x49, 0xb1, 0x81, 0xeb, 0x20, 0x1d, 0xa5, 0xe8, 0x97, 0xb4, 0xfc, 0x17, 0xf9, 0x79, 0xf8,
	0x5f, 0x50, 0xbe, 0xd0, 0x1a, 0x25, 0xfd, 0x9c, 0xd6, 0xff, 0x25, 0xbf, 0x24, 0x75, 0x87, 0x0b,
	0x83, 0xaa, 0xa0, 0x80, 0x19, 0xa0, 0x7b, 0x29, 0x72, 0x95, 0xfc, 0xfe, 0x3d, 0x52, 0xc1, 0x2e,
	0x34, 0x98, 0x6a, 0x81, 0xa1, 0xbb, 0x97, 0x74, 0x8a, 0x30, 0xa4, 0x3b, 0x97, 0x0d, 0xc3, 0x4e,
	0xaf, 0x81, 0x74, 0x3b, 0x45, 0xfe, 0x21, 0x93, 0x09, 0x52, 0x33, 0x6d, 0x50, 0x8b, 0xe8, 0xae,
	0x03, 0xa7, 0x77, 0x46, 0x9e, 0x28, 0x2c, 0x96, 0x84, 0xd2, 0x86, 0x6e, 0x8d, 0x3e, 0x31, 0x53,
	0xcc, 0xaf, 0x08, 0xad, 0xe9, 0xd1, 0xc7, 0x51, 0x22, 0x22, 0xc3, 0xca, 0xb2, 0xcb, 0x3c, 0xc1,
	0xe9, 0xe1, 0xc5, 0x48, 0x43, 0xf8, 0x80, 0x81, 0xa1, 0x07, 0x29, 0xf2, 0x1f, 0x99, 0x4a, 0x90,
	0x7c, 0xa7, 0x53, 0xe6, 0x15, 0xa1, 0x7d, 0x66, 0xdc, 0x36, 0xdd, 0x4f, 0x99, 0xff, 0xc9, 0xaf,
	0x09, 0x53, 0x68, 0x33, 0x55, 0xe6, 0x55, 0x34, 0xce, 0xa6, 0xd0, 0x86, 0xee, 0xa6, 0xd0, 0x15,
	0xf2, 0x5b, 0x04, 0xad, 0x68, 0x50, 0x79, 0x4f, 0x01, 0xe3, 0xbd, 0x5a, 0xb3, 0xe9, 0x09, 0x09,
	0x74, 0x2f, 0xa5, 0x66, 0xc9, 0xcc, 0x90, 0x5a, 0xc4, 0x96, 0x90, 0x25, 0x85, 0x7e, 0x64, 0x50,
	0x11, 0xba, 0xc2, 0x05, 0xba, 0x63, 0x77, 0x0c, 0x67, 0x0e, 0x3a, 0xc6, 0xa1, 0x72, 0xfa, 0xe9,
	0xdc, 0xb2, 0x29, 0xec, 0x58, 0x64, 0x86, 0x45, 0x36, 0x6d, 0x9f, 0x8f, 0xd4, 0x15, 0xd6, 0x17,
	0x91, 0xf1, 0x12, 0x13, 0x5e, 0x18, 0xc6, 0xc5, 0x54, 0x9d, 0x75, 0x61, 0x40, 0x6d, 0x9d, 0x5b,
	0xa1, 0x86, 0x54, 0xc6, 0x85, 0xdb, 0x59, 0x62, 0x3a, 0x22, 0x16, 0x10, 0x5b, 0x1e, 0x0c, 0x36,
	0x55, 0xa0, 0xd4, 0x8e, 0x52, 0xa8, 0xe8, 0xb3, 0xf1, 0xdc, 0xe4, 0xe0, 0x12, 0xe4, 0x03, 0xd3,
	0x8e, 0x1f, 0x3e, 0x1f, 0xcf, 0xfd, 0x99, 0x19, 0x5f, 0xe6, 0x2b, 0x12, 0x6e, 0x06, 0xcc, 0x8b,
	0xab, 0x2f, 0xc6, 0x87, 0x31, 0x2e, 0x20, 0x72, 0x9d, 0x99, 0xfb, 0xae, 0x6f, 0x29, 0xab, 0xbb,
	0xa8, 0x20, 0x04, 0x24, 0x06, 0xad, 0x36, 0x7d, 0xdb, 0xb7, 0x82, 0x2e, 0x0a, 0xe6, 0xa3, 0xe4,
	0x29, 0xf3, 0xa6, 0x6f, 0x05, 0xbd, 0x80, 0x1e, 0x9f, 0x07, 0x26, 0x53, 0xe8, 0xb5, 0x0d, 0x2d,
	0x23, 0xfa, 0x05, 0xa6, 0x32, 0x9d, 0x8e, 0x52, 0xe8, 0x6f, 0x92, 0x8b, 0xb3, 0x63, 0xba, 0x9d,
	0x02, 0x87, 0x76, 0x97, 0x0a, 0x4a, 0xe8, 0x35, 0x7a, 0x1d, 0x18, 0x2e, 0xde, 0x41, 0xdf, 0xda,
	0xdf, 0x9a, 0xe2, 0xa1, 0x2f, 0xcb, 0xd0, 0x89, 0xe3, 0xdf, 0xbf, 0x00, 0xa9, 0x1b, 0x66, 0x20,
	0xb6, 0xed, 0x55, 0xdf, 0xca, 0x76, 0x70, 0x41, 0xa2, 0x89, 0xd5, 0xc0, 0x5f, 0x03, 0x45, 0x5f,
	0xda, 0x0e, 0x56, 0x98, 0xf0, 0x32, 0x1e, 0x7f, 0x38, 0xb3, 0x25, 0x33, 0xe1, 0x45, 0x93, 0x86,
	0x92, 0xdf, 0x9f, 0x59, 0x07, 0x1f, 0x2c, 0x6c, 0x49, 0x09, 0x90, 0x9c, 0xde, 0x3b, 0xb5, 0x80,
	0xb2, 0xae, 0xa2, 0xa9, 0x24, 0xc0, 0xdd, 0x53, 0x6b, 0x4c, 0xde, 0x35, 0xdd, 0x2a, 0x9a, 0x5a,
	0x07, 0x64, 0x03, 0xc3, 0xc5, 0xa0, 0x4f, 0x4e, 0x2c, 0xb5, 0x21, 0x94, 0x51, 0xfb, 0xf8, 0xc4,
	0x32, 0x26, 0x24, 0x9c, 0x4d, 0x17, 0x80, 0x87, 0xb7, 0x5f, 0xd3, 0x47, 0x27, 0x96, 0x31, 0x21,
	0x72, 0x9d, 0xe9, 0x79, 0x21, 0x79, 0x59, 0x76, 0x85, 0x01, 0x45, 0x1f, 0xa6, 0xd4, 0x35, 0xf2,
	0x47, 0x3a, 0x2a, 0xb6, 0x30, 0xa6, 0xc2, 0xb7, 0x3c, 0x7d, 0x30, 0x1a, 0x2c, 0xa1, 0x5a, 0x13,
	0x3c, 0xed, 0x08, 0xf4, 0xbe, 0x2d, 0xbe, 0xc1, 0xf4, 0x7a, 0x46, 0xfc, 0xd1, 0xf1, 0x48, 0x62,
	0x19, 0x36, 0x98, 0xe2, 0xd1, 0xb5, 0x3e, 0x3c, 0xb6, 0x6c, 0x74, 0x94, 0x2a, 0x4b, 0x19, 0xbf,
	0x4c, 0x5c, 0xfa, 0x34, 0xf9, 0x62, 0x8c, 0xcd, 0x4f, 0xdc, 0x20, 0x51, 0x38, 0xd1, 0x47, 0xeb,
	0x5b, 0x00, 0x00, 0x00, 0xff, 0xff, 0x61, 0x9a, 0x57, 0xd7, 0xcc, 0x06, 0x00, 0x00,
}
