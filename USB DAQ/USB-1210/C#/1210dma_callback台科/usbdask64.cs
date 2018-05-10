using System.Runtime.InteropServices;
using System;

public delegate void CallbackDelegate();

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct USBDAQ_DEVICE
{
	  [MarshalAs(UnmanagedType.U2)]
    public ushort wModuleType;
	  [MarshalAs(UnmanagedType.U2)]    
    public ushort wCardID;
}	

enum ADDI_INFO_TYPE
{
    //Device info
    ALL_nNumOfDevice = 0,
    ALL_nFlag = 1,
    ALL_bHaveSubType = 2,
    ALL_szDeviceName = 3,
    ALL_uDeviceStyle = 4,
    //AI channel table info
    AI_uChannelStyle = 50,
    AI_uNumOfChannels = 51,
    AI_bSyncRange = 52,
    AI_szRange = 53,
    AI_bSyncCurrentRange = 54,
    AI_szCurrentRange = 55,
    AI_bSyncTerminal = 56,
    AI_szRefGround = 57,
    AI_nResolution = 58,
    AI_nFIFOSize = 59,
    //AO channel table info
    AO_uChannelStyle = 100,
    AO_uNumOfChannels = 101,
    AO_bSyncRange = 102,
    AO_szRange = 103,
    AO_bSyncPolarity = 104,
    AO_bSyncCurrentRange = 105,
    AO_szCurrentRange = 106,
    AO_szPolarity = 107,
    AO_bSyncRefVoltage = 108,
    AO_szRefVoltage = 109,
    AO_nResolution = 110,
    AO_nFIFOSize = 111,
    //DI channel table info
    DI_uChannelStyle = 150,
    DI_uNumOfDIOChannels = 151,
    DI_lpszNoteString = 152,
    DI_dbMaxSamplingRate = 153,
    DI_dbMinSamplingRate = 154,
    DI_uNumOfPortChannels = 155,
    DI_nFIFOSize = 156,
    //DO channel table info
    DO_uChannelStyle = 200,
    DO_uNumOfDIOChannels = 201,
    DO_lpszNoteString = 202,
    DO_dbMaxUpdateRate = 203,
    DO_dbMinUpdateRate = 204,
    DO_uNumOfPortChannels = 205,
    DO_nFIFOSize = 206,
    //Timer-Counter channel table info
    TC_uChannelStyle = 250,
    TC_uNumOfChannels = 251,
    TC_szTCMode = 252,
    TC_uInterval = 253,
    TC_dbTimeBase = 254,
    TC_nInitialValue = 255,
    TC_szBinOrBcd = 256,
    TC_szUpOrDown = 257,
    TC_szClockSource = 258,
    TC_szGateSource = 259,
    TC_szUpDownSource = 260,
    TC_bDebounceSource = 261,
    TC_bD2KGptcPolarity = 262,
    //Timing table info
    AI_uTimingStyle = 300,
    AI_szClockSource = 301,
    AI_szConvertSource = 302,
    AI_dbMaxSamplingRate = 303,
    AI_dbMinSamplingRate = 304,
    AO_uTimingStyle = 350,
    AO_szClockSource = 351,
    AO_szDASource = 352,
    AO_dbMaxUpdateRate = 353,
    AO_dbMinUpdateRate = 354,
    DI_uTimingStyle = 400,
    DI_szClockSource = 401,
    DI_dbMaxTransferRate = 402,
    DI_dbMinTransferRate = 403,
    DO_uTimingStyle = 450,
    DO_szClockSource = 451,
    DO_dbMaxTransferRate = 452,
    DO_dbMinTransferRate = 453,
    //AI Trigger table info
    AI_uBasicTriggerStyle = 500,
    AI_szBasicTriggerSource = 501,
    AI_szBasicTriggerMode = 502,
    AI_szBasicDigTriggerPol = 503,
    AI_szBasicAnaTriggerPol = 504,
    AI_szBasicReTriggerMode = 505,
    AI_dbBasicTriggerVoltMax = 506,
    AI_dbBasicTriggerVoltMin = 507,
    //AO Trigger table info
    AO_uBasicTriggerStyle = 550,
    AO_szBasicTriggerSource = 551,
    AO_szBasicTriggerMode = 552,
    AO_szBasicDigTriggerPol = 553,
    AO_szBasicAnaTriggerPol = 554,
    AO_szBasicReTriggerMode = 555,
    AO_dbBasicTriggerVoltMax = 556,
    AO_dbBasicTriggerVoltMin = 557,
    //D2K AI Trigger table info
    AI_uD2KAITriggerStyle = 600,
    AI_szD2KTriggerSource = 601,
    AI_szD2KTriggerMode = 602,
    AI_dbD2KTriggerVoltMax = 603,
    AI_dbD2KTriggerVoltMin = 604,

    AI_szD2KDigTriggerPol = 605,
    AI_szD2KAnalogSource = 606,
    AI_szD2KAnalogPolarity = 607,
    AI_szD2KReTriggerMode = 608,
    AI_szD2KDelaySource = 609,
    AI_szD2KDelayCounterSource = 610,
    //D2K AO Trigger table info
    AO_uD2KAOTriggerStyle = 650,
    AO_szD2KTriggerSource = 651,
    AO_szD2KTriggerMode = 652,
    AO_dbD2KTriggerVoltMax = 653,
    AO_dbD2KTriggerVoltMin = 654,

    AO_szD2KDigTriggerPol = 655,
    AO_szDigAnalogSource = 656,
    AO_szD2KAnalogSource = 657,
    AO_szD2KAnalogPolarity = 658,
    AO_szD2KReTriggerMode = 659,
    AO_szD2KDelaySource = 660,
    AO_szD2KDelaySource2 = 661,
    AO_szD2KDelayCounterSource = 662,
    AO_szD2KBreakDelayCounterSource = 663,
}

enum USB_7250_7230_CTR              //robin@20120925 add
{
    UD_CTR_Filter_Disable,
    UD_CTR_Filter_Enable = 1,
    UD_CTR_Reset_Rising_Edge_Counter = 2,
    UD_CTR_Reset_Frequency_Counter = 4,
    UD_CTR_Polarity_Positive = 0,           //robin@20121015 add
    UD_CTR_Polarity_Negative = 8,           //robin@20121015 add
}

public class USBDASK
{
    
    //ADLink PCI Card Type
    public const ushort USB_1902                  = 1;
    public const ushort USB_1903                  = 2;        //robin@20110919 add
    public const ushort USB_1901                  = 3;        //robin@20110919 add
    public const ushort USB_2401                  = 4;
    public const ushort USB_7250                  = 5;
    public const ushort USB_7230                  = 6;
    public const ushort USB_2405                  = 7;
    public const ushort USB_1210                  = 8;    
    public const ushort USB_2401A3           	  = 9;
	public const ushort USB_101           		  = 10;
    public const ushort NUM_MODULE_TYPE           = 11;

    public const ushort MAX_USB_DEVICE            = 8;

    public const ushort INVALID_CARD_ID           = 0xFFFF;

    //Error Number
    public const short NoError = 0;
    public const short ErrorUnknownCardType = -1;
    public const short ErrorInvalidCardNumber = -2;
    public const short ErrorTooManyCardRegistered = -3;
    public const short ErrorCardNotRegistered = -4;
    public const short ErrorFuncNotSupport = -5;
    public const short ErrorInvalidIoChannel = -6;
    public const short ErrorInvalidAdRange = -7;
    public const short ErrorContIoNotAllowed = -8;
    public const short ErrorDiffRangeNotSupport = -9;
    public const short ErrorLastChannelNotZero = -10;
    public const short ErrorChannelNotDescending = -11;
    public const short ErrorChannelNotAscending = -12;
    public const short ErrorOpenDriverFailed = -13;
    public const short ErrorOpenEventFailed = -14;
    public const short ErrorTransferCountTooLarge = -15;
    public const short ErrorNotDoubleBufferMode = -16;
    public const short ErrorInvalidSampleRate = -17;
    public const short ErrorInvalidCounterMode = -18;
    public const short ErrorInvalidCounter = -19;
    public const short ErrorInvalidCounterState = -20;
    public const short ErrorInvalidBinBcdParam = -21;
    public const short ErrorBadCardType = -22;
    public const short ErrorInvalidDaRefVoltage = -23;
    public const short ErrorAdTimeOut = -24;
    public const short ErrorNoAsyncAI = -25;
    public const short ErrorNoAsyncAO = -26;
    public const short ErrorNoAsyncDI = -27;
    public const short ErrorNoAsyncDO = -28;
    public const short ErrorNotInputPort = -29;
    public const short ErrorNotOutputPort = -30;
    public const short ErrorInvalidDioPort = -31;
    public const short ErrorInvalidDioLine = -32;
    public const short ErrorContIoActive = -33;
    public const short ErrorDblBufModeNotAllowed = -34;
    public const short ErrorConfigFailed = -35;
    public const short ErrorInvalidPortDirection = -36;
    public const short ErrorBeginThreadError = -37;
    public const short ErrorInvalidPortWidth = -38;
    public const short ErrorInvalidCtrSource = -39;
    public const short ErrorOpenFile = -40;
    public const short ErrorAllocateMemory = -41;
    public const short ErrorDaVoltageOutOfRange = -42;
    public const short ErrorDaExtRefNotAllowed = -43;
    public const short ErrorDIODataWidthError = -44;
    public const short ErrorTaskCodeError = -45;
    public const short ErrortriggercountError = -46;
    public const short ErrorInvalidTriggerMode = -47;
    public const short ErrorInvalidTriggerType = -48;
    public const short ErrorInvalidCounterValue = -50;
    public const short ErrorInvalidEventHandle = -60;
    public const short ErrorNoMessageAvailable = -61;
    public const short ErrorEventMessgaeNotAdded = -62;
    public const short ErrorCalibrationTimeOut = -63;
    public const short ErrorUndefinedParameter = -64;
    public const short ErrorInvalidBufferID = -65;
    public const short ErrorInvalidSampledClock = -66;
    public const short ErrorInvalisOperationMode = -67;

    //Error number for driver API
    public const short ErrorConfigIoctl = -201;
    public const short ErrorAsyncSetIoctl = -202;
    public const short ErrorDBSetIoctl = -203;
    public const short ErrorDBHalfReadyIoctl = -204;
    public const short ErrorContOPIoctl = -205;
    public const short ErrorContStatusIoctl = -206;
    public const short ErrorPIOIoctl = -207;
    public const short ErrorDIntSetIoctl = -208;
    public const short ErrorWaitEvtIoctl = -209;
    public const short ErrorOpenEvtIoctl = -210;
    public const short ErrorCOSIntSetIoctl = -211;
    public const short ErrorMemMapIoctl = -212;
    public const short ErrorMemUMapSetIoctl = -213;
    public const short ErrorCTRIoctl = -214;
    public const short ErrorGetResloctl = -215;
    public const short ErrorCalloctl = -216;
    public const short ErrorPMIntSetIoctl = -217;

    //Error added for USBDASK
    public const short ErrorAccessViolationDataCopy = -301;
    public const short ErrorNoModuleFound = -302;
    public const short ErrorCardIDDuplicated = -303;
    public const short ErrorCardDisconnected = -304;
    public const short ErrorInvalidScannedIndex = -305;
    public const short ErrorUndefinedException = -306;
    public const short ErrorInvalidDioConfig = -307;
    public const short ErrorInvalidAOCfgCtrl = -308;
    public const short ErrorInvalidAOTrigCtrl = -309;
    public const short ErrorConflictWithSyncMode = -310;
    public const short ErrorConflictWithFifoMode = -311;
    public const short ErrorInvalidAOIteration = -312;
    public const short ErrorZeroChannelNumber = -313;
    public const short ErrorSystemCallFailed = -314;
    public const short ErrorTimeoutFromSyncMode = -315;
    public const short ErrorInvalidPulseCount = -316;
    public const short ErrorInvalidDelayCount = -317;
    public const short ErrorConflictWithDelay2 = -318;
    public const short ErrorAOFifoCountTooLarge = -319;
    public const short ErrorConflictWithWaveRepeat = -320;
    public const short ErrorConflictWithReTrig = -321;
    public const short ErrorInvalidTriggerChannel = -322;
    public const short ErrorInvalidRefVoltage = -323;
    public const short ErrorInvalidConversionSrc = -324;
    public const short ErrorInvalidInputSignal = -325;
    public const short ErrorCalibrateFailed = -326;
    public const short ErrorInvalidCalData = -327;
    public const short ErrorChanGainQueueTooLarge = -328;
    public const short ErrorInvalidCardType = -329;
    public const short ErrorInvlaidSyncMode = -330;
    public const short ErrorIICVersion = -331;
    public const short ErrorFX2UpgradeFailed = -332;
    public const short ErrorInvalidReadCount = -333;
    public const short ErrorTEDSInvalidSensorNo = -334;
    public const short ErroeTEDSAccessTimeout = -335;
    public const short ErrorTEDSChecksumFailed = -336;
    public const short ErrorTEDSNotIEEE1451_4 = -337;
    public const short ErrorTEDSInvalidTemplateID = -338;
    public const short ErrorTEDSInvalidPrecisionValue = -339;
    public const short ErrorTEDSUnsupportedTemplate = -340;
    public const short ErrorTEDSInvalidPropertyID = -341;
    public const short ErrorTEDSNoRawData = -342;  
        
    public const short ErrorInvalidChannel = -397;
    public const short ErrorNullPoint = -398;
    public const short ErrorInvalidParamSetting = -399;

    // -401 ~ -499 the Kernel error
    public const short ErrorAIStartFailed = -401;
    public const short ErrorAOStartFailed = -402;
    public const short ErrorConflictWithGPIOConfig = -403;
    public const short ErrorEepromReadback = -404;
    public const short ErrorConflictWithInfiniteOp = -405;
    public const short ErrorWaitingUSBHostResponse = -406;
    public const short ErrorAOFifoModeTimeout = -407;
    public const short ErrorInvalidModuleFunction = -408;
    public const short ErrorAdFifoFull = -409;
    public const short ErrorInvalidTransferCount = -410;
    public const short ErrorConflictWithAIConfig = -411;
    public const short ErrorDDSConfigFailed = -412;
    public const short ErrorFpgaAccessFailed = -413;
    public const short ErrorPLDBusy = -414;
    public const short ErrorPLDTimeout = -415;

    public const short ErrorUndefinedKernelError = -420;
    public const short ErrorSyncModeNotSupport = -501;

//UsbThermo Error Message
    public const short ErrorInvalidThermoType      = -601;
    public const short ErrorOutThermoRange         = -602;
    public const short ErrorThermoTable            = -603;

//AD Range
    public const ushort AD_B_10_V = 1;
    public const ushort AD_B_5_V = 2;
    public const ushort AD_B_2_5_V = 3;
    public const ushort AD_B_1_25_V = 4;
    public const ushort AD_B_0_625_V = 5;
    public const ushort AD_B_0_3125_V = 6;
    public const ushort AD_B_0_5_V = 7;
    public const ushort AD_B_0_05_V = 8;
    public const ushort AD_B_0_005_V = 9;
    public const ushort AD_B_1_V = 10;
    public const ushort AD_B_0_1_V = 11;
    public const ushort AD_B_0_01_V = 12;
    public const ushort AD_B_0_001_V = 13;
    public const ushort AD_U_20_V = 14;
    public const ushort AD_U_10_V = 15;
    public const ushort AD_U_5_V = 16;
    public const ushort AD_U_2_5_V = 17;
    public const ushort AD_U_1_25_V = 18;
    public const ushort AD_U_1_V = 19;
    public const ushort AD_U_0_1_V = 20;
    public const ushort AD_U_0_01_V = 21;
    public const ushort AD_U_0_001_V = 22;
    public const ushort AD_B_2_V = 23;
    public const ushort AD_B_0_25_V = 24;
    public const ushort AD_B_0_2_V = 25;
    public const ushort AD_U_4_V = 26;
    public const ushort AD_U_2_V = 27;
    public const ushort AD_U_0_5_V = 28;
    public const ushort AD_U_0_4_V = 29;
    public const ushort AD_B_1_5_V = 30;
    public const ushort AD_B_0_2125_V = 31;
    public const ushort AD_B_40_V = 32;
    public const ushort AD_B_3_16_V = 33;
    public const ushort AD_B_0_316_V = 34;
    public const ushort AD_B_25_V = 35;
    public const ushort AD_B_12_5_V = 36;

    //THERMO //kevinYM@20170504 modidy
    public const ushort THERMO_B_TYPE = 1;
    public const ushort THERMO_C_TYPE = 2;
    public const ushort THERMO_E_TYPE = 3;
    public const ushort THERMO_K_TYPE = 4;
    public const ushort THERMO_R_TYPE = 5;
    public const ushort THERMO_S_TYPE = 6;
    public const ushort THERMO_T_TYPE = 7;
    public const ushort THERMO_J_TYPE = 8;
    public const ushort THERMO_N_TYPE = 9;
    public const ushort RTD_PT100     = 10;
    public const ushort RTD_PT1000    = RTD_PT100;

    public const ushort THERMO_MAX_TYPE = RTD_PT100;

    //Synchronous Mode
    public const ushort SYNCH_OP  = 1;
    public const ushort ASYNCH_OP = 2;

// Input Type
    public const ushort UD_AI_NonRef_SingEnded    = 0x01;
    public const ushort UD_AI_SingEnded           = 0x02;
    public const ushort UD_AI_Differential        = 0x04;
    public const ushort UD_AI_PseudoDifferential  = 0x08;

// Input Coupling
    public const ushort UD_AI_EnableIEPE          = 0x10;
    public const ushort UD_AI_DisableIEPE         = 0x20;
    public const ushort UD_AI_Coupling_AC         = 0x40;
    public const ushort UD_AI_Coupling_None       = 0x80;



// Conversion Source
    public const ushort UD_AI_CONVSRC_INT         = 0x01;
    public const ushort UD_AI_CONVSRC_EXT         = 0x02;


// wTrigCtrl in UD_AI_Trigger_Config()

// Trigger Source (bit9:0)
    public const ushort UD_AI_TRGSRC_AI0          = 0x0200;
    public const ushort UD_AI_TRGSRC_AI1          = 0x0201;
    public const ushort UD_AI_TRGSRC_AI2          = 0x0202;
    public const ushort UD_AI_TRGSRC_AI3          = 0x0203;
    public const ushort UD_AI_TRGSRC_AI4          = 0x0204;
    public const ushort UD_AI_TRGSRC_AI5          = 0x0205;
    public const ushort UD_AI_TRGSRC_AI6          = 0x0206;
    public const ushort UD_AI_TRGSRC_AI7          = 0x0207;
    public const ushort UD_AI_TRGSRC_AI8          = 0x0208;
    public const ushort UD_AI_TRGSRC_AI9          = 0x0209;
    public const ushort UD_AI_TRGSRC_AI10         = 0x020A;
    public const ushort UD_AI_TRGSRC_AI11         = 0x020B;
    public const ushort UD_AI_TRGSRC_AI12         = 0x020C;
    public const ushort UD_AI_TRGSRC_AI13         = 0x020D;
    public const ushort UD_AI_TRGSRC_AI14         = 0x020E;
    public const ushort UD_AI_TRGSRC_AI15         = 0x020F;
    public const ushort UD_AI_TRGSRC_SOFT         = 0x0380;
    public const ushort UD_AI_TRGSRC_DTRIG        = 0x0388;


// Trigger Edge (bit14)
    public const ushort UD_AI_TrigPositive        = 0x4000;
    public const ushort UD_AI_TrigNegative        = 0x0000;

    public const ushort UD_AI_Gate_PauseLow       = 0x4000;
    public const ushort UD_AI_Gate_PauseHigh      = 0x0000;
    
// ReTrigger (bit13)
    public const ushort UD_AI_EnReTrigger        = 0x2000; // 0x02000000
    public const ushort UD_AI_DisReTrigger       = 0x0000; // 0x00000000

// AI Trigger Mode
    public const ushort UD_AI_TRGMOD_POST        = 0x0000; // 0x00000000
    public const ushort UD_AI_TRGMOD_DELAY       = 0x4000; // 0x40000000
    public const ushort UD_AI_TRGMOD_PRE         = 0x8000; // 0x80000000
    public const ushort UD_AI_TRGMOD_MIDDLE      = 0xC000; // 0xC0000000
    public const ushort UD_AI_TRGMOD_GATED       = 0x1000; // 0x10000000
	
// AO Trigger Source (bit9:0)
	public const ushort UD_AO_TRGSRC_SOFT		 = 0x0380;
	public const ushort UD_AO_TRGSRC_DTRIG		 = 0x0388;

// AO Trigger Mode
	public const ushort UD_AO_TRGMOD_POST		 = 0x0000;

// AO Trigger Edge (bit14)
	public const ushort UD_AO_TrigPositive		 = 0x4000;
	public const ushort UD_AO_TrigNegative       = 0x0000;

// AO Conversion Source
	public const ushort UD_AO_CONVSRC_INT		 = 0x01;
	public const ushort UD_AO_CONVSRC_EX		 = 0x02;

// DIO_Config
    public const ushort UD_DIO_DIGITAL_INPUT        = 0x30;
    public const ushort UD_DIO_COUNTER_INPUT        = 0x31;
    public const ushort UD_DIO_DIGITAL_OUTPUT       = 0x32;
    public const ushort UD_DIO_PULSE_OUTPUT         = 0x33;

// TEDS Property IDs
    public const ushort UD_TEDS_PROPERTY_TEMPLATE = 1;
    public const ushort UD_TEDS_PROPERTY_ElecSigType = 2;
    public const ushort UD_TEDS_PROPERTY_PhysMeasType = 3;
    public const ushort UD_TEDS_PROPERTY_MinPhysVal = 4;
    public const ushort UD_TEDS_PROPERTY_MaxPhysVal = 5;
    public const ushort UD_TEDS_PROPERTY_MinElecVal = 6;
    public const ushort UD_TEDS_PROPERTY_MaxElecVal = 7;
    public const ushort UD_TEDS_PROPERTY_MapMeth = 8;
    public const ushort UD_TEDS_PROPERTY_BridgeType = 9;
    public const ushort UD_TEDS_PROPERTY_SensorImped = 10;
    public const ushort UD_TEDS_PROPERTY_RespTime = 11;
    public const ushort UD_TEDS_PROPERTY_ExciteAmplNom = 12;
    public const ushort UD_TEDS_PROPERTY_ExciteAmplMin = 13;
    public const ushort UD_TEDS_PROPERTY_ExciteAmplMax = 14;
    public const ushort UD_TEDS_PROPERTY_CalDate = 15;
    public const ushort UD_TEDS_PROPERTY_CalInitials = 16;
    public const ushort UD_TEDS_PROPERTY_CalPeriod = 17;
    public const ushort UD_TEDS_PROPERTY_MeasID = 18;
        
//-------- Constants for USB-1902 --------------------

//Input Type
    public const ushort P1902_AI_NonRef_SingEnded  = 0x00;
    public const ushort P1902_AI_SingEnded         = 0x01;
    public const ushort P1902_AI_PseudoDifferential      = 0x02;
    public const ushort P1902_AI_Differential      = 0x02;    

//Conversion Source
    public const ushort P1902_AI_CONVSRC_INT       = 0x00;
    public const ushort P1902_AI_CONVSRC_EXT       = 0x80;


// wTrigCtrl in UD_AI_1902_Config()
// Trigger Source
    public const ushort P1902_AI_TRGSRC_AI0       = 0x020;
    public const ushort P1902_AI_TRGSRC_AI1       = 0x021;
    public const ushort P1902_AI_TRGSRC_AI2       = 0x022;
    public const ushort P1902_AI_TRGSRC_AI3       = 0x023;
    public const ushort P1902_AI_TRGSRC_AI4       = 0x024;
    public const ushort P1902_AI_TRGSRC_AI5       = 0x025;
    public const ushort P1902_AI_TRGSRC_AI6       = 0x026;
    public const ushort P1902_AI_TRGSRC_AI7       = 0x027;
    public const ushort P1902_AI_TRGSRC_AI8       = 0x028;
    public const ushort P1902_AI_TRGSRC_AI9       = 0x029;
    public const ushort P1902_AI_TRGSRC_AI10      = 0x02A;
    public const ushort P1902_AI_TRGSRC_AI11      = 0x02B;
    public const ushort P1902_AI_TRGSRC_AI12      = 0x02C;
    public const ushort P1902_AI_TRGSRC_AI13      = 0x02D;
    public const ushort P1902_AI_TRGSRC_AI14      = 0x02E;
    public const ushort P1902_AI_TRGSRC_AI15      = 0x02F;
    public const ushort P1902_AI_TRGSRC_SOFT      = 0x030;
    public const ushort P1902_AI_TRGSRC_DTRIG     = 0x031;


// Trigger Edge
    public const ushort P1902_AI_TrgPositive      = 0x040;
    public const ushort P1902_AI_TrgNegative      = 0x000;

// Gated Trigger Level
    public const ushort P1902_AI_Gate_PauseLow    = 0x000;
    public const ushort P1902_AI_Gate_PauseHigh   = 0x040;

// Trigger Mode
    public const ushort P1902_AI_TRGMOD_POST      = 0x000;
    public const ushort P1902_AI_TRGMOD_GATED     = 0x080;
    public const ushort P1902_AI_TRGMOD_DELAY     = 0x100;    

// ReTrigger
    public const ushort P1902_AI_EnReTigger       = 0x200;

//
// AO Constants
//

// Conversion Source
    public const ushort P1902_AO_CONVSRC_INT      = 0x00;

// Trigger Mode
    public const ushort P1902_AO_TRGMOD_POST      = 0x00;
    public const ushort P1902_AO_TRGMOD_DELAY     = 0x01;

// Trigger Source
    public const ushort P1902_AO_TRGSRC_SOFT      = 0x00;
    public const ushort P1902_AO_TRGSRC_DTRIG     = 0x10;

// Trigger Edge
    public const ushort P1902_AO_TrgPositive      = 0x100;
    public const ushort P1902_AO_TrgNegative      = 0x000;

// Enable Re-Trigger
    public const ushort P1902_AO_EnReTigger       = 0x200;
// Flag for AO Waveform Seperation Interval 
    public const ushort P1902_AO_EnDelay2         = 0x400;

    //-------- Constants for USB-2401 --------------------
    // wConfigCtrl in UD_AI_2401_Config()
    // Input Type, V >=2.5V, V<2.5, Current, RTD (4 wire), RTD (3-wire), RTD (2-wire), Resistor, Thermocouple, Full-Bridge, Half-Bridge
    public const ushort P2401_Voltage_2D5V_Above = 0x00;
    public const ushort P2401_Voltage_2D5V_Below = 0x01;
    public const ushort P2401_Current = 0x02;
    public const ushort P2401_RTD_4_Wire = 0x03;
    public const ushort P2401_RTD_3_Wire = 0x04;
    public const ushort P2401_RTD_2_Wrie = 0x05;
    public const ushort P2401_Resistor = 0x06;
    public const ushort P2401_ThermoCouple = 0x07;
    public const ushort P2401_Full_Bridge = 0x08;
    public const ushort P2401_Half_Bridge = 0x09;
    public const ushort P2401_ThermoCouple_Differential = 0x0A;
    public const ushort P2401_350Ohm_Full_Bridge = 0x0B;
    public const ushort P2401_350Ohm_Half_Bridge = 0x0C;
    public const ushort P2401_120Ohm_Full_Bridge = 0x0D;
    public const ushort P2401_120Ohm_Half_Bridge = 0x0E;

    // Conversion Source 
    public const ushort P2401_AI_CONVSRC_INT = 0x00;

    // wTrigCtrl in UD_AI_2401_Config()
    // Trigger Source, bit 8:3 in AI_ACQMCR
    public const ushort P2401_AI_TRGSRC_SOFT = 0x030;

    // Trigger Mode
    public const ushort P2401_AI_TRGMOD_POST = 0x000;


    // wMAvgStageCh1 ~ wMAvgStageCh4 in UD_AI_2401_PollConfig()
    public const ushort P2401_Polling_MAvg_Disable = 0x00;
    public const ushort P2401_Polling_MAvg_2_Sampes = 0x01;
    public const ushort P2401_Polling_MAvg_4_Sampes = 0x02;
    public const ushort P2401_Polling_MAvg_8_Sampes = 0x03;
    public const ushort P2401_Polling_MAvg_16_Sampes = 0x04;

    // wEnContPolling in UD_AI_2401_PollConfig()
    public const ushort P2401_Continue_Polling_Disable = 0x00;
    public const ushort P2401_Continue_Polling_Enable = 0x01;

    // wPollSpeed in UD_AI_2401_PollConfig()
    public const ushort P2401_ADC_2000_SPS = 0x09;
    public const ushort P2401_ADC_1000_SPS = 0x08;
    public const ushort P2401_ADC_640_SPS = 0x07;
    public const ushort P2401_ADC_320_SPS = 0x06;
    public const ushort P2401_ADC_160_SPS = 0x05;
    public const ushort P2401_ADC_80_SPS = 0x04;
    public const ushort P2401_ADC_40_SPS = 0x03;
    public const ushort P2401_ADC_20_SPS = 0x02;

    // AI Select Channel
    public const ushort P2405_AI_CH_0                   = 0;
    public const ushort P2405_AI_CH_1                   = 1;
    public const ushort P2405_AI_CH_2                   = 2;
    public const ushort P2405_AI_CH_3                   = 3;

    // UD_AI_2405_Chan_Config
    // Input Coupling
    public const ushort P2405_AI_EnableIEPE         	  = 0x0004;
    public const ushort P2405_AI_DisableIEPE         	  = 0x0008;
    public const ushort P2405_AI_Coupling_AC        	  = 0x0010;
    public const ushort P2405_AI_Coupling_None       	  = 0x0020;

    // Input Type
    public const ushort P2405_AI_Differential			      = 0x0000;
    public const ushort P2405_AI_PseudoDifferential		  = 0x0040;


    // UD_AI_2405_Trig_Config()
    // Conversion Source
    public const ushort P2405_AI_CONVSRC_INT            = 0x0000;
    public const ushort P2405_AI_CONVSRC_EXT            = 0x0200;

    // Trigger Source
    public const ushort P2405_AI_TRGSRC_AI0             = 0x0200;
    public const ushort P2405_AI_TRGSRC_AI1             = 0x0208;
    public const ushort P2405_AI_TRGSRC_AI2             = 0x0210;
    public const ushort P2405_AI_TRGSRC_AI3             = 0x0218;
    public const ushort P2405_AI_TRGSRC_SOFT            = 0x0380;
    public const ushort P2405_AI_TRGSRC_DTRIG           = 0x0388; // digital-trigger
                              
    // Trigger Edge
    public const ushort P2405_AI_TrgPositive            = 0x0004;
    public const ushort P2405_AI_TrgNegative            = 0x0000;

    // Gated Trigger Level  
    public const ushort P2405_AI_Gate_PauseLow           = 0x0004;
    public const ushort P2405_AI_Gate_PauseHigh          = 0x0000;
    
    // ReTrigger
    public const ushort P2405_AI_EnReTigger              = 0x2000;

    // AI Trigger Mode
    public const ushort P2405_AI_TRGMOD_POST             = 0x0000;
    public const ushort P2405_AI_TRGMOD_DELAY            = 0x4000;
    public const ushort P2405_AI_TRGMOD_PRE              = 0x8000;
    public const ushort P2405_AI_TRGMOD_MIDDLE           = 0xC000;
    public const ushort P2405_AI_TRGMOD_GATED            = 0x1000;

    // UD_DIO_2405_Config() 
    public const ushort P2405_DIGITAL_INPUT              = 0x30;
    public const ushort P2405_COUNTER_INPUT              = 0x31;
    public const ushort P2405_DIGITAL_OUTPUT             = 0x32; 
    public const ushort P2405_PULSE_OUTPUT               = 0x33;


//-------------------------------
// GPIO/GPTC Configuration       
//-------------------------------
    public const ushort IGNORE_CONFIG      = 0x00;
    public const ushort GPIO_IGNORE_CONFIG = 0x00;

    public const ushort GPTC0_GPO1         = 0x01;
    public const ushort GPTC0_ENABLE       = 0x01;
    public const ushort GPI0_3_GPO0_1      = 0x02;
//    public const ushort ENC0_GPO0          = 0x04;
    public const ushort GPTC0_TC1          = 0x08;

    public const ushort GPTC2_GPO3         = 0x10;
    public const ushort GPTC1_ENABLE       = 0x10;
    public const ushort GPI4_7_GPO2_3      = 0x20;
//    public const ushort ENC1_GPO1          = 0x40;
    public const ushort GPTC2_TC3          = 0x80;    
	
//	UD_DIO_Config for USB-101
	public const ushort GPO0			= 0x1100;
	public const ushort GPO1			= 0x1200;
	public const ushort GPO2			= 0x1400;
	public const ushort GPO3			= 0x1800;
	public const ushort GPI0_3			= 0x2000;

// GPIO Port
    public const ushort GPIO_PortA         = 0;
    public const ushort GPIO_PortB         = 1;

//Counter Mode
    public const ushort SimpleGatedEventCNT       = 0x01;
    public const ushort SinglePeriodMSR           = 0x02;
    public const ushort SinglePulseWidthMSR       = 0x03;
    public const ushort SingleGatedPulseGen       = 0x04;
    public const ushort SingleTrigPulseGen        = 0x05;
    public const ushort RetrigSinglePulseGen      = 0x06;
    public const ushort SingleTrigContPulseGen    = 0x07;
    public const ushort ContGatedPulseGen         = 0x08;
    public const ushort EdgeSeparationMSR         = 0x09;
    public const ushort SingleTrigContPulseGenPWM = 0x0a;
    public const ushort ContGatedPulseGenPWM      = 0x0b;
    public const ushort CW_CCW_Encoder            = 0x0c;
    public const ushort x1_AB_Phase_Encoder       = 0x0d;
    public const ushort x2_AB_Phase_Encoder       = 0x0e;
    public const ushort x4_AB_Phase_Encoder       = 0x0f;
    public const ushort Phase_Z                   = 0x10;
    public const ushort MultipleGatedPulseGen     = 0x11;

//GPTC clock source
    public const ushort GPTC_CLK_SRC_Ext          = 0x01;
    public const ushort GPTC_CLK_SRC_Int          = 0x00;
    public const ushort GPTC_GATE_SRC_Ext         = 0x02;
    public const ushort GPTC_GATE_SRC_Int         = 0x00;
    public const ushort GPTC_UPDOWN_Ext           = 0x04;
    public const ushort GPTC_UPDOWN_Int           = 0x00;

//GPTC clock polarity
    public const ushort GPTC_CLKSRC_LACTIVE       = 0x01;
    public const ushort GPTC_CLKSRC_HACTIVE       = 0x00;
    public const ushort GPTC_GATE_LACTIVE         = 0x02;
    public const ushort GPTC_GATE_HACTIVE         = 0x00;
    public const ushort GPTC_UPDOWN_LACTIVE       = 0x04;
    public const ushort GPTC_UPDOWN_HACTIVE       = 0x00;
    public const ushort GPTC_OUTPUT_LACTIVE       = 0x08;
    public const ushort GPTC_OUTPUT_HACTIVE       = 0x00;

    public const ushort IntGate                   = 0x0;
    public const ushort IntUpDnCTR                = 0x1;
    public const ushort IntENABLE                 = 0x2;
	
	// 20160516, Jeff added for on-fly change
	/*GPTC on-fly change*/ 
	// 1.7.3.0628
	public const ushort OnFlyChange_Mode          = 0x80;
	public const ushort OnFlyChange_PulseCounters = 0x81;

// DAQ Event type for the event message
    public const ushort AIEnd                     = 0;
    public const ushort AOEnd                     = 0;
    public const ushort DIEnd                     = 0;
    public const ushort DOEnd                     = 0;
    public const ushort DBEvent                   = 1;
    public const ushort TrigEvent                 = 2;
    
// CTR parameters
    public const ushort UD_CTR_Filter_Disable             = 0;
    public const ushort UD_CTR_Filter_Enable              = 1;
    public const ushort UD_CTR_Reset_Edge_Counter         = 2;
    public const ushort UD_CTR_Reset_Frequency_Counter    = 4;
    public const ushort UD_CTR_Polarity_Positive          = 0;           //robin@20121015 add
    public const ushort UD_CTR_Polarity_Negative          = 8;           //robin@20121015 add

// Calibration 
    public const ushort Cal_Op_Offset             = 0;
    public const ushort Cal_Op_Gain               = 1;

    public const ushort U1902_CalSrc_REF_5V       = 0;
    public const ushort U1902_CalSrc_REF_10V      = 1; 
    public const ushort U1902_CalSrc_REF_2V       = 2;
    public const ushort U1902_CalSrc_REF_1V       = 3;
    public const ushort U1902_CalSrc_REF_0_2V     = 4;
    public const ushort U1902_CalSrc_AO_0         = 5;
    public const ushort U1902_CalSrc_AO_1         = 6;

//ColdJuction
    public const ushort U2401_ColdJuction_Disable            = 1000;
    public const ushort U2401_ColdJuction_Enable             = 1001;
    public const ushort U2401_ColdJuction_User_define        = 1002;

    public const string UDDASK_DLL_FILE_NAME = "usb-dask64.dll";
    public const string UDDASK_THERMAL_DLL_FILE_NAME = "usbthermo64.dll";

/*----------------------------------------------------------------------------*/
/* USB-DASK Function prototype                                               */
/*----------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_Register_Card (ushort CardType, ushort card_num);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_Release_Card (ushort CardNumber);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_Device_Scan (out ushort pModuleNum, out USBDAQ_DEVICE pAvailModules );
	[DllImport(UDDASK_DLL_FILE_NAME)]
	public static extern short UD_Device_Scan (out ushort pModuleNum, [MarshalAsAttribute(UnmanagedType.LPArray)] [In, Out] USBDAQ_DEVICE[] pAvailModules);
/*----------------------------------------------------------------------------*/
/* AI Function */    
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short GetActualRate_9524 (ushort CardNumber, ushort Group, double SampleRate, out double ActualRate);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short EMGShutDownControl (ushort CardNumber, byte ctrl);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short EMGShutDownStatus (ushort CardNumber, out byte sts);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short HotResetHoldControl (ushort CardNumber, byte enable);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short HotResetHoldStatus (ushort CardNumber, out byte sts);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short GetInitPattern (ushort CardNumber, byte patID, out uint pattern);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short SetInitPattern (ushort CardNumber, byte patID, uint pattern);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short IdentifyLED_Control (ushort CardNumber, byte ctrl);
/*---------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_1902_Config(ushort CardNumber, ushort wConfigCtrl, ushort wTrigCtrl, uint dwTrgLevel, uint wReTriggerCnt, uint dwDelayCount);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_2401_Config(ushort CardNumber, ushort wChanCfg1, ushort wChanCfg2, ushort wChanCfg3, ushort wChanCfg4, ushort wTrigCtrl);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_2401_PollConfig(ushort CardNumber, ushort wPollSpeed, ushort wMAvgStageCh1, ushort wMAvgStageCh2, ushort wMAvgStageCh3, ushort wMAvgStageCh4);
    [DllImport(UDDASK_DLL_FILE_NAME)]    
    public static extern short UD_AI_1902_CounterInterval (ushort CardNumber, uint ScanIntrv, uint SampIntrv);
    [DllImport(UDDASK_DLL_FILE_NAME)]   
    public static extern short UD_AI_AsyncCheck(ushort CardNumber, out byte Stopped, out ulong AccessCnt);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncClear(ushort CardNumber, out ulong AccessCnt);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferHalfReady (ushort CardNumber, out byte HalfReady, out byte StopFlag);
	[DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_FIFOOverflow (ushort CardNumber, out bool Overflow);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferMode (ushort CardNumber, bool Enable);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferTransfer32(ushort CardNumber, IntPtr Buffer);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferTransfer (ushort CardNumber, IntPtr Buffer);               //robin@20111222 modify uint -> ushort     //robin@20111228 modify short[] => IntPtr
	[DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_AsyncDblBufferTransfer (ushort CardNumber, ushort wbufferId, IntPtr buffer);	//20170517 add by KevinYM
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short _AI_AsyncBufferTransfer(ushort CardNumber, out ulong count, IntPtr Buffer);     //robin@20120111 add
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferOverrun (ushort CardNumber, ushort op, out ushort overrunFlag);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferOverrun(ushort CardNumber, ushort op, IntPtr overrunFlag);    
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferHandled (ushort CardNumber);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferToFile (ushort CardNumber);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, IntPtr Buffer, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContReadMultiChannels (ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, IntPtr Buffer, uint ReadCount, double SampleRate, ushort SyncMode);     //robin@20111006 modify uint -> ushort (buffer)      //robin@20111228 modify ushort[] => IntPtr
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_2401_Scale32(ushort CardNumber, ushort AdRange, ushort inType, uint reading, out double voltage);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_2401_ContVScale32(ushort CardNumber, ushort AdRange, ushort inType, uint[] readingArray, double[] voltageArray, int count);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContReadChannelToFile (ushort CardNumber, ushort Channel, ushort AdRange, string FileName, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContReadMultiChannelsToFile (ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, string FileName, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_EventCallBack_x64 (ushort CardNumber, ushort mode, ushort EventType, MulticastDelegate callbackAddr);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_InitialMemoryAllocated (ushort CardNumber, out uint MemSize);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, out ushort Value);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ReadMultiChannels(ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, ushort[] Buffer);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ReadMultiChannels(ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, IntPtr Buffer);            //robin@20120323 add
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_VReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, out double voltage);        
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_VoltScale (ushort CardNumber, ushort AdRange, ushort reading, out double voltage);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AIVoltScale(ushort CardType, ushort AdRange, short reading, out double voltage);      //robin@20111004 add
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContVScale (ushort CardNumber, ushort adRange, ushort[] readingArray, double[] voltageArray, int count);
	[DllImport(UDDASK_DLL_FILE_NAME)]
	public static extern short UD_AI_ContMultiChanVScale (ushort CardNumber, ushort[] adRange, ushort[] inType, ushort wChannels, uint[] readingArray, double[] voltageArray, ushort[] rawArray, int count);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_SetTimeOut (ushort CardNumber, uint TimeOut);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncReTrigNextReady(ushort CardNumber, out byte Ready, out byte StopFlag, out uint RdyTrigCnt);    //robin@20111225 modify
    // 2012Oct18, Jeff added for USB-2405
    [DllImport(UDDASK_DLL_FILE_NAME)]   
    public static extern short UD_AI_2405_Chan_Config( ushort CardNumber, ushort wChanCfg1, ushort wChanCfg2, ushort wChanCfg3, ushort wChanCfg4 );
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_2405_Trig_Config( ushort CardNumber, ushort wConvSrc, ushort wTrigMode, ushort wTrigCtrl, uint wReTrigCnt, uint dwDLY1Cnt, uint dwDLY2Cnt, uint dwTrgLevel );
    [DllImport(UDDASK_DLL_FILE_NAME)]   
    public static extern short UD_AI_Channel_Config( ushort CardNumber, ushort wChanCfg1, ushort wChanCfg2, ushort wChanCfg3, ushort wChanCfg4 );
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_Trigger_Config( ushort CardNumber, ushort wConvSrc, ushort wTrigMode, ushort wTrigCtrl, uint wReTrigCnt, uint dwDLY1Cnt, uint dwDLY2Cnt, uint dwTrgLevel );    
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_VoltScale32( ushort CardNumber, ushort AdRange, ushort inType, uint reading, out double voltage );
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContVScale32( ushort CardNumber, ushort AdRange, ushort inType, uint[] readingArray, double[] voltageArray, int count); 
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_DDS_ActualRate_Get ( ushort CardNumber, double SampleRate, out double ActualRate);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_Monitor_Config(ushort CardNumber, short mode, ushort aiCh, ushort gpoCh, ushort adRange, double trgHigh, double trgLow, double deltaT /*ms*/);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_Monitor_AlarmClear(ushort CardNumber, ushort gpoCh);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_Monitor_AlarmClear(ushort CardNumber, ushort gpoCh, out ushort alarmStatus);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_Monitor_Reset(ushort CardNumber);
    /*---------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_1902_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTrgCnt, uint DLY1Cnt, uint DLY2Cnt);
	[DllImport(UDDASK_DLL_FILE_NAME)]
	public static extern short UD_AO_Trigger_Config(ushort CardNumber, ushort wConvSrc, ushort wTrigMode, ushort wTrigCtrl);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_AsyncCheck (ushort CardNumber, out byte Stopped, out uint AccessCnt);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    //public static extern short UD_AO_AsyncClear(ushort CardNumber, out uint AccessCnt);
    public static extern short UD_AO_AsyncClear (ushort CardNumber, out uint AccessCnt, ushort stop_mode);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_AsyncDblBufferMode (ushort CardNumber, bool Enable, bool bEnFifoMode);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_AsyncDblBufferHalfReady (ushort CardNumber, out byte bHalfReady);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_AsyncDblBufferTransfer(ushort CardNumber, ushort wbufferId, ushort[] buffer);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_ContBufferCompose (ushort CardNumber, ushort TotalChnCount, ushort ChnNum, uint UpdateCount, uint [] ConBuffer, uint [] Buffer);
	[DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_ContBufferCompose(ushort CardNumber, ushort TotalChnCount, ushort ChnNum, uint UpdateCount, IntPtr ConBuffer, IntPtr Buffer); //20170517 add by KevinYM
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_ContWriteChannel (ushort CardNumber, ushort Channel, ushort [] AOBuffer, uint WriteCount, uint Iterations, uint CHUI, ushort finite, ushort SyncMode);
	[DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_ContWriteChannel(ushort CardNumber, ushort Channel, IntPtr AOBuffer, uint WriteCount, uint Iterations, uint CHUI, ushort finite, ushort SyncMode); //20170517 add by KevinYM
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_ContWriteMultiChannels(ushort CardNumber, ushort NumChans, ushort[] Chans, short[] AOBuffer, uint WriteCount, uint Iterations, uint CHUI, ushort finite, ushort SyncMode);
	[DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_ContWriteMultiChannels(ushort CardNumber, ushort NumChans, ushort[] Chans, IntPtr AOBuffer, uint WriteCount, uint Iterations, uint CHUI, ushort finite, ushort SyncMode); //20170517 add by KevinYM
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_InitialMemoryAllocated (ushort CardNumber, out uint MemSize);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_SetTimeOut (ushort CardNumber, uint TimeOut);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_SimuVWriteChannel (ushort CardNumber, ushort Group, double[] VBuffer);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_SimuWriteChannel (ushort CardNumber, ushort Group, short[] Buffer);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_VWriteChannel (ushort CardNumber, ushort Channel, double Voltage);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_WriteChannel (ushort CardNumber, ushort Channel, short Value);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_EventCallBack_x64 (ushort CardNumber, ushort mode, ushort EventType, MulticastDelegate callbackAddr);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_VoltScale (ushort CardNumber, ushort Channel, double Voltage, out short binValue);
/*---------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DIO_1902_Config (ushort CardNumber, ushort wPart1Cfg, ushort wPart2Cfg);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DIO_2401_Config (ushort wCardNumber, ushort wPart1Cfg );    
    // 2012Oct18, Jeff added for USB-2405
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DIO_2405_Config(ushort wCardNumber, ushort wPart1Cfg, ushort wPart2Cfg);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DIO_Config(ushort wCardNumber, ushort wPart1Cfg, ushort wPart2Cfg);    
/*---------------------------------------------------------------------------*/    
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DI_ReadLine (ushort CardNumber, ushort Port, ushort Line, out ushort State);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DI_ReadPort (ushort CardNumber, ushort Port, out uint Value);
/*---------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DO_ReadLine (ushort CardNumber, ushort Port, ushort Line, out ushort Value);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DO_ReadPort (ushort CardNumber, ushort Port, out uint Value);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DO_WriteLine (ushort CardNumber, ushort Port, ushort Line, ushort Value);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DO_WritePort (ushort CardNumber, ushort Port, uint Value);
/*---------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GPTC_Clear (ushort CardNumber, ushort GCtr);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GPTC_Control (ushort CardNumber, ushort GCtr, ushort ParamID, ushort Value);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GPTC_Read (ushort CardNumber, ushort GCtr, out uint Value);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GPTC_Setup(ushort CardNumber, ushort GCtr, ushort Mode, ushort SrcCtrl, ushort PolCtrl, uint LReg1_Val, uint LReg2_Val, uint PulseCount);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GPTC_Setup_N(ushort CardNumber, ushort GCtr, ushort Mode, ushort SrcCtrl, ushort PolCtrl, uint LReg1_Val, uint LReg2_Val, uint PulseCount);    
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GPTC_Status(ushort CardNumber, ushort GCtr, out ushort Value);
/*---------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_GetEvent (ushort CardNumber, out IntPtr hEvent);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_GetEvent (ushort CardNumber, out IntPtr hEvent);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_GetView_x64 (ushort CardNumber, out UIntPtr View);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AO_GetView_x64 (ushort CardNumber, out UIntPtr View);
/*---------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GetActualRate (ushort CardNumber, double fSampleRate, out double fActualRate);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GetCardIndexFromID (ushort CardNumber, out ushort cardType, out ushort cardIndex);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GetCardType (ushort CardNumber, out ushort cardType);
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_IdentifyLED_Control (ushort CardNumber, byte ctrl);
/*---------------------------------------------------------------------------*/
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_GetFPGAVersion(ushort CardNumber, out uint pdwFPGAVersion);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_1902_Trimmer_Set(ushort CardNumber, byte bValue );
    
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short usbdaq_1902_RefVol_WriteEeprom( ushort CardNumber, double[] RefVol, ushort wTrimmer );

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short usbdaq_1902_RefVol_ReadEeprom( ushort CardNumber, double[] RefVol, out ushort wTrimmer );    
    
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short usbdaq_1902_CalSrc_Switch( ushort CardNumber, ushort wOperation, ushort wCalSrc );    
        
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short usbdaq_1902_Calibration_All( ushort CardNumber, out ushort pCalOp, out ushort pCalSrc );
  
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short usbdaq_1903_Calibration_All( ushort CardNumber, double RefVol_10V, out ushort pCalOp, out ushort pCalSrc );

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short usbdaq_1903_Current_Calibration( ushort CardNumber, ushort wOperation, ushort wCalChan, double fRefCur,  out uint pCalReg );
  
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short usbdaq_1903_WriteEeprom( ushort CardNumber, ushort wTrimmer, byte[] CALdata );
        
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short usbdaq_ReadPort( ushort CardNumber, ushort wPortAddr, out uint pdwData );

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_2401_Stop_Poll(ushort wCardNumber);       //robin@20120517 add

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_Read_ColdJunc_Thermo(ushort wCardNumber, out double pfValue);         //robin@20120405 add
 
    [DllImport(UDDASK_THERMAL_DLL_FILE_NAME)]
    public static extern short ADC_to_Thermo( ushort wThermoType, double fScaledADC, double fColdJuncTemp, out double pfTemp );

    //For USB-1900 Series
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncBufferTransfer(ushort wCardNumber, IntPtr pwBuffer, uint offset, uint count);     //robin@20120611 add

    // For USB-2405
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncBufferTransfer32(ushort CardNumber, IntPtr pwBuffer, uint offset, uint count);    
    
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncBufferTransfer32( ushort CardNumber, uint[] pdwBuffer, uint offset, uint count );      
    
    //For USB-7250, USB-7230
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_CTR_Control(ushort wCardNumber, ushort wCtr, uint dwCtrl);                  //robin@20120925 add begin

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_CTR_ReadFrequency(ushort wCardNumber, ushort wCtr, out double pfValue);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_CTR_ReadEdgeCounter(ushort wCardNumber, ushort wCtr, out uint dwValue);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_CTR_ReadRisingEdgeCounter(ushort wCardNumber, ushort wCtr, out uint dwValue);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_CTR_SetupMinPulseWidth (ushort wCardNumber, ushort wCtr, ushort Value );       //robin@20121016 double -> ushort

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DI_SetupMinPulseWidth(ushort wCardNumber, ushort Value);                     //robin@20121016 double -> ushort

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DI_Control (ushort wCardNumber, ushort wPort, uint dwCtrl );

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DI_SetCOSInterrupt32 (ushort wCardNumber, ushort wPort, uint dwCtrl, out IntPtr hEvent, bool ManualReset );

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DI_GetCOSLatchData32(ushort wCardNumber, ushort wPort, out uint pwCosLData);        //robin@20121001 add

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DO_GetInitPattern (ushort wCardNumber, ushort wPort, out uint pdwPattern);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DO_SetInitPattern(ushort wCardNumber, ushort wPort, out uint pdwPattern);           //robin@20120925 add End

    // override 
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, out uint Value);
        
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ReadMultiChannels(ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, uint[] Buffer);
        
    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncCheck(ushort CardNumber, out byte Stopped, out uint AccessCnt);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncClear(ushort CardNumber, out uint AccessCnt);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short _AI_AsyncBufferTransfer(ushort CardNumber, out uint count, IntPtr Buffer); 

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, ushort[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, uint[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContReadMultiChannels (ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, ushort[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode); 

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_ContReadMultiChannels (ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, uint[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_DIO_INT_EventMessage (ushort wCardNumber, int mode, IntPtr evt, IntPtr windowHandle, uint message, MulticastDelegate callbackAddr);

    [DllImport(UDDASK_DLL_FILE_NAME)]
    public static extern short UD_AI_AsyncDblBufferTransfer32(ushort CardNumber, uint[] Buffer);
    
}
