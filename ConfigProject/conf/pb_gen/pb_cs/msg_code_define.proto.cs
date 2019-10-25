//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: msg_code_define.proto
namespace FunPlus.Common.Config
{
    [global::ProtoBuf.ProtoContract(Name=@"EMessageCode")]
    public enum EMessageCode
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_Success", Value=0)]
      CODE_Success = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_UNKNOWN", Value=1)]
      CODE_UNKNOWN = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrorCode_NotImplement", Value=2)]
      CODE_ErrorCode_NotImplement = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_TIMEOUT", Value=3)]
      CODE_TIMEOUT = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_REQUEST_MSG_CAST_ERROR", Value=4)]
      CODE_REQUEST_MSG_CAST_ERROR = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrorCode_Canceled", Value=5)]
      CODE_ErrorCode_Canceled = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrorCode_SemverCheckError", Value=6)]
      CODE_ErrorCode_SemverCheckError = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrorCode_TokenCheckError", Value=8)]
      CODE_ErrorCode_TokenCheckError = 8,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrorCode_PacketTooLarge", Value=9)]
      CODE_ErrorCode_PacketTooLarge = 9,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrPasswd", Value=2001)]
      CODE_ErrPasswd = 2001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrTokenErr", Value=2002)]
      CODE_ErrTokenErr = 2002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrPermisson", Value=2003)]
      CODE_ErrPermisson = 2003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrEditorCreate", Value=2004)]
      CODE_ErrEditorCreate = 2004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrEditorMoveTarget", Value=2005)]
      CODE_ErrEditorMoveTarget = 2005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrEditorMoveTo", Value=2006)]
      CODE_ErrEditorMoveTo = 2006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrEditorCopyTo", Value=2007)]
      CODE_ErrEditorCopyTo = 2007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrOtherLocked", Value=2008)]
      CODE_ErrOtherLocked = 2008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrLockFirst", Value=2009)]
      CODE_ErrLockFirst = 2009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrParamMiss", Value=2010)]
      CODE_ErrParamMiss = 2010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrTokenInvalid", Value=2011)]
      CODE_ErrTokenInvalid = 2011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrTokenTimeout", Value=2012)]
      CODE_ErrTokenTimeout = 2012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrAppIdMismatch", Value=2013)]
      CODE_ErrAppIdMismatch = 2013,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_ErrCharIdNotExist", Value=2014)]
      CODE_ErrCharIdNotExist = 2014,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_UserAlreadyOffline", Value=2015)]
      CODE_UserAlreadyOffline = 2015,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_UserLoginFromOtherDevice", Value=2016)]
      CODE_UserLoginFromOtherDevice = 2016,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_CharAlreadyCreated", Value=2017)]
      CODE_CharAlreadyCreated = 2017,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_InternalUnknownErr", Value=-10001)]
      SC_InternalUnknownErr = -10001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_DataBaseOperationErr", Value=-10002)]
      SC_DataBaseOperationErr = -10002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_NotFoundInConf", Value=-10003)]
      SC_NotFoundInConf = -10003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrParameters", Value=-10004)]
      SC_ErrParameters = -10004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDebugModeFeature", Value=-10005)]
      SC_ErrDebugModeFeature = -10005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrInnerLogic", Value=-10006)]
      SC_ErrInnerLogic = -10006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrSessionErr", Value=-10007)]
      SC_ErrSessionErr = -10007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrRequestHandleTimeout", Value=-10008)]
      SC_ErrRequestHandleTimeout = -10008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrSdkSessionKeyErr", Value=-10009)]
      SC_ErrSdkSessionKeyErr = -10009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDiamondNotEnough", Value=-10101)]
      SC_ErrDiamondNotEnough = -10101,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrGoldNotEnough", Value=-10102)]
      SC_ErrGoldNotEnough = -10102,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrStoneNotEnough", Value=-10103)]
      SC_ErrStoneNotEnough = -10103,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrLoginCreateRole", Value=-10201)]
      SC_ErrLoginCreateRole = -10201,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrSaveNewRole", Value=-10202)]
      SC_ErrSaveNewRole = -10202,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrRecreateRole", Value=-10203)]
      SC_ErrRecreateRole = -10203,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrMustLogin", Value=-10204)]
      SC_ErrMustLogin = -10204,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrGetRole", Value=-10205)]
      SC_ErrGetRole = -10205,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrGetAllBuildingsFromDB", Value=-10301)]
      SC_ErrGetAllBuildingsFromDB = -10301,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrBuildingNotFound", Value=-10302)]
      SC_ErrBuildingNotFound = -10302,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrPosHasBuild", Value=-10303)]
      SC_ErrPosHasBuild = -10303,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrBidNotFoundInConf", Value=-10304)]
      SC_ErrBidNotFoundInConf = -10304,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrRequireBuilding", Value=-10305)]
      SC_ErrRequireBuilding = -10305,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrBuildingInnerLogic", Value=-10306)]
      SC_ErrBuildingInnerLogic = -10306,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrOverMainCityLevel", Value=-10307)]
      SC_ErrOverMainCityLevel = -10307,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrBuildingStateCanNotOP", Value=-10308)]
      SC_ErrBuildingStateCanNotOP = -10308,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrUpgradeBuildingId", Value=-10309)]
      SC_ErrUpgradeBuildingId = -10309,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrBuildingDataNotMatch", Value=-10310)]
      SC_ErrBuildingDataNotMatch = -10310,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrCampProductResearched", Value=-10311)]
      SC_ErrCampProductResearched = -10311,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrAreaHasUnlocked", Value=-10312)]
      SC_ErrAreaHasUnlocked = -10312,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrCampProductNotResearch", Value=-10313)]
      SC_ErrCampProductNotResearch = -10313,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrOverUpgradeQueueLimit", Value=-10314)]
      SC_ErrOverUpgradeQueueLimit = -10314,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrAreaHasNotUnlocked", Value=-10315)]
      SC_ErrAreaHasNotUnlocked = -10315,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrOverBuildingCountLimit", Value=-10316)]
      SC_ErrOverBuildingCountLimit = -10316,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrOverBuildingLevel", Value=-10317)]
      SC_ErrOverBuildingLevel = -10317,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrGetAllHeroesFromDB", Value=-10401)]
      SC_ErrGetAllHeroesFromDB = -10401,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrHidNotFoundInConf", Value=-10402)]
      SC_ErrHidNotFoundInConf = -10402,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrLevelIdNotFoundInConf", Value=-10403)]
      SC_ErrLevelIdNotFoundInConf = -10403,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrCostIdNotFoundInConf", Value=-10404)]
      SC_ErrCostIdNotFoundInConf = -10404,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrHeroInnerLogic", Value=-10405)]
      SC_ErrHeroInnerLogic = -10405,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrGetAllHeroTeamsFromDB", Value=-10406)]
      SC_ErrGetAllHeroTeamsFromDB = -10406,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrHeroPackageIsFull", Value=-10407)]
      SC_ErrHeroPackageIsFull = -10407,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDungeonInnerLogic", Value=-10501)]
      SC_ErrDungeonInnerLogic = -10501,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDungeonGetDataFromDB", Value=-10502)]
      SC_ErrDungeonGetDataFromDB = -10502,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDungeonIdNotFoundInConf", Value=-10503)]
      SC_ErrDungeonIdNotFoundInConf = -10503,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDungeonIdNotFoundInDB", Value=-10504)]
      SC_ErrDungeonIdNotFoundInDB = -10504,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDungeonIdNotUnLocked", Value=-10505)]
      SC_ErrDungeonIdNotUnLocked = -10505,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDungeonNotRepeated", Value=-10506)]
      SC_ErrDungeonNotRepeated = -10506,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrDungeonEnergyNotEnough", Value=-10507)]
      SC_ErrDungeonEnergyNotEnough = -10507,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrLotteryIdNotFoundInConf", Value=-10551)]
      SC_ErrLotteryIdNotFoundInConf = -10551,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrLotteryIdNotFoundInDB", Value=-10552)]
      SC_ErrLotteryIdNotFoundInDB = -10552,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrItemIdNotFoundInConf", Value=-10601)]
      SC_ErrItemIdNotFoundInConf = -10601,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrItemIdNotFoundInDB", Value=-10602)]
      SC_ErrItemIdNotFoundInDB = -10602,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrItemCountNotEnough", Value=-10603)]
      SC_ErrItemCountNotEnough = -10603,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrItemCantUse", Value=-10604)]
      SC_ErrItemCantUse = -10604,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrItemHoldMaxCountLimit", Value=-10605)]
      SC_ErrItemHoldMaxCountLimit = -10605,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrItemNotFound", Value=-10606)]
      SC_ErrItemNotFound = -10606,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrItemConfInvalidCumulate", Value=-10607)]
      SC_ErrItemConfInvalidCumulate = -10607,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopIdNotFoundInConf", Value=-10651)]
      SC_ErrShopIdNotFoundInConf = -10651,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopIdNotFoundInDB", Value=-10652)]
      SC_ErrShopIdNotFoundInDB = -10652,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopProductIdNotFoundInConf", Value=-10653)]
      SC_ErrShopProductIdNotFoundInConf = -10653,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopProductIdNotFoundInShop", Value=-10654)]
      SC_ErrShopProductIdNotFoundInShop = -10654,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopProductMaxCountLimit", Value=-10655)]
      SC_ErrShopProductMaxCountLimit = -10655,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopProductInvalidParams", Value=-10656)]
      SC_ErrShopProductInvalidParams = -10656,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopRefresh", Value=-10657)]
      SC_ErrShopRefresh = -10657,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopGetCandidateConfNotFound", Value=-10658)]
      SC_ErrShopGetCandidateConfNotFound = -10658,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrShopTimeExpired", Value=-10659)]
      SC_ErrShopTimeExpired = -10659,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrESResourceNotEnough", Value=-10701)]
      SC_ErrESResourceNotEnough = -10701,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrEnergyNotEnough", Value=-10702)]
      SC_ErrEnergyNotEnough = -10702,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrRecruitNotEnough", Value=-10703)]
      SC_ErrRecruitNotEnough = -10703,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrOverResourceMaxValue", Value=-10704)]
      SC_ErrOverResourceMaxValue = -10704,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrGetAllAchievementFromDb", Value=-10751)]
      SC_ErrGetAllAchievementFromDb = -10751,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrAchievementInnerErr", Value=-10752)]
      SC_ErrAchievementInnerErr = -10752,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrTitleIdNotFoundInConf", Value=-10780)]
      SC_ErrTitleIdNotFoundInConf = -10780,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrTitleInnerErr", Value=-10781)]
      SC_ErrTitleInnerErr = -10781,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrTitleTaskNotFinished", Value=-10782)]
      SC_ErrTitleTaskNotFinished = -10782,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrConditionNotMatch", Value=-10800)]
      SC_ErrConditionNotMatch = -10800,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrTaskDataNotMatch", Value=-10801)]
      SC_ErrTaskDataNotMatch = -10801,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrTaskHasFinished", Value=-10802)]
      SC_ErrTaskHasFinished = -10802,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SC_ErrPlayerLevelNotMatch", Value=-10803)]
      SC_ErrPlayerLevelNotMatch = -10803
    }
  
}