using System.Runtime.InteropServices;
using System;

public delegate void CallbackDelegate();

public class DSA_DASK
{
    //ADLink DSA Card Type
    public const ushort PCI_9527 = 1;
    public const ushort PXI_9529 = 2;
    public const ushort PCI_9529 = 2;

    public const ushort MAX_CARD = 32;

    //Error Number
    public const short NoError                    = 0;
    public const short ErrorUnknownCardType       = -1;
    public const short ErrorInvalidCardNumber     = -2;
    public const short ErrorTooManyCardRegistered = -3;
    public const short ErrorCardNotRegistered     = -4;
    public const short ErrorFuncNotSupport        = -5;
    public const short ErrorInvalidIoChannel      = -6;
    public const short ErrorInvalidAdRange        = -7;
    public const short ErrorContIoNotAllowed      = -8;
    public const short ErrorDiffRangeNotSupport   = -9;
    public const short ErrorLastChannelNotZero    = -10;
    public const short ErrorChannelNotDescending  = -11;
    public const short ErrorChannelNotAscending   = -12;
    public const short ErrorOpenDriverFailed      = -13;
    public const short ErrorOpenEventFailed       = -14;
    public const short ErrorTransferCountTooLarge = -15;
    public const short ErrorNotDoubleBufferMode   = -16;
    public const short ErrorInvalidSampleRate     = -17;
    public const short ErrorInvalidCounterMode    = -18;
    public const short ErrorInvalidCounter        = -19;
    public const short ErrorInvalidCounterState   = -20;
    public const short ErrorInvalidBinBcdParam    = -21;
    public const short ErrorBadCardType           = -22;
    public const short ErrorInvalidDaRefVoltage   = -23;
    public const short ErrorAdTimeOut             = -24;
    public const short ErrorNoAsyncAI             = -25;
    public const short ErrorNoAsyncAO             = -26;
    public const short ErrorNoAsyncDI             = -27;
    public const short ErrorNoAsyncDO             = -28;
    public const short ErrorNotInputPort          = -29;
    public const short ErrorNotOutputPort         = -30;
    public const short ErrorInvalidDioPort        = -31;
    public const short ErrorInvalidDioLine        = -32;
    public const short ErrorContIoActive          = -33;
    public const short ErrorDblBufModeNotAllowed  = -34;
    public const short ErrorConfigFailed          = -35;
    public const short ErrorInvalidPortDirection  = -36;
    public const short ErrorBeginThreadError      = -37;
    public const short ErrorInvalidPortWidth      = -38;
    public const short ErrorInvalidCtrSource      = -39;
    public const short ErrorOpenFile              = -40;
    public const short ErrorAllocateMemory        = -41;
    public const short ErrorDaVoltageOutOfRange   = -42;
    public const short ErrorDaExtRefNotAllowed    = -43;
    public const short ErrorDIODataWidthError     = -44;
    public const short ErrorTaskCodeError         = -45;
    public const short ErrortriggercountError     = -46;
    public const short ErrorInvalidTriggerMode    = -47;
    public const short ErrorInvalidTriggerType    = -48;
    public const short ErrorInvalidTriggerParam   = -49;
    public const short ErrorInvalidCounterValue   = -50;
    public const short ErrorInvalidConfig         = -51;
    public const short ErrorIncompatibleOperation = -52;
    public const short ErrorInvalidEventHandle    = -60;
    public const short ErrorNoMessageAvailable    = -61;
    public const short ErrorEventMessgaeNotAdded  = -62;
    public const short ErrorCalibrationTimeOut    = -63;
    public const short ErrorUndefinedParameter    = -64;
    public const short ErrorInvalidBufferID       = -65;
    public const short ErrorInvalidSampledClock   = -66;
    public const short ErrorInvalisOperationMode  = -67;
    public const short ErrorOptionOutOfRanged     = -70;
    public const short ErrorInvalidDDSFrequency   = -80;
    public const short ErrorInvalidDDSPhase       = -81;
    public const short ErrorInvalidSPDMode        = -82;
    public const short ErrorInvalidPGAGain        = -83;
    public const short ErrorInvalidParmPointer    = -84;
    public const short ErrorIoChannelNotCreated   = -85;
    public const short ErrorInvalidAOParameter    = -86;
    public const short ErrorIntClkFailed          = -87;
    public const short ErrorBadSyncSetting        = -88;
    public const short ErrorAICalibrationFailed   = -91;
    public const short ErrorAOCalibrationFailed   = -92;
    public const short ErrorRefVolOutOfRanged     = -93;

    //Error number for driver API
    public const short ErrorConfigIoctl           = -201;
    public const short ErrorAsyncSetIoctl         = -202;
    public const short ErrorDBSetIoctl            = -203;
    public const short ErrorDBHalfReadyIoctl      = -204;
    public const short ErrorContOPIoctl           = -205;
    public const short ErrorContStatusIoctl       = -206;
    public const short ErrorPIOIoctl              = -207;
    public const short ErrorDIntSetIoctl          = -208;
    public const short ErrorWaitEvtIoctl          = -209;
    public const short ErrorOpenEvtIoctl          = -210;
    public const short ErrorCOSIntSetIoctl        = -211;
    public const short ErrorMemMapIoctl           = -212;
    public const short ErrorMemUMapSetIoctl       = -213;
    public const short ErrorCTRIoctl              = -214;
    public const short ErrorGetResIoctl           = -215;
    public const short ErrorCalIoctl              = -216;
    public const short ErrorPMIntSetIoctl         = -217;

    //AD Range
    public const ushort AD_B_10_V     = 1;
    public const ushort AD_B_5_V      = 2;
    public const ushort AD_B_2_5_V    = 3;
    public const ushort AD_B_1_25_V   = 4;
    public const ushort AD_B_0_625_V  = 5;
    public const ushort AD_B_0_3125_V = 6;
    public const ushort AD_B_0_5_V    = 7;
    public const ushort AD_B_0_05_V   = 8;
    public const ushort AD_B_0_005_V  = 9;
    public const ushort AD_B_1_V      = 10;
    public const ushort AD_B_0_1_V    = 11;
    public const ushort AD_B_0_01_V   = 12;
    public const ushort AD_B_0_001_V  = 13;
    public const ushort AD_U_20_V     = 14;
    public const ushort AD_U_10_V     = 15;
    public const ushort AD_U_5_V      = 16;
    public const ushort AD_U_2_5_V    = 17;
    public const ushort AD_U_1_25_V   = 18;
    public const ushort AD_U_1_V      = 19;
    public const ushort AD_U_0_1_V    = 20;
    public const ushort AD_U_0_01_V   = 21;
    public const ushort AD_U_0_001_V  = 22;
    public const ushort AD_B_2_V      = 23;
    public const ushort AD_B_0_25_V   = 24;
    public const ushort AD_B_0_2_V    = 25;
    public const ushort AD_U_4_V      = 26;
    public const ushort AD_U_2_V      = 27;
    public const ushort AD_U_0_5_V    = 28;
    public const ushort AD_U_0_4_V    = 29;
    public const ushort AD_B_1_5_V    = 30;
    public const ushort AD_B_0_2125_V = 31;
    public const ushort AD_B_40_V     = 32;
    public const ushort AD_B_3_16_V   = 33;
    public const ushort AD_B_0_316_V  = 34;

    //T or F
    public const ushort TRUE  = 1;
    public const ushort FALSE = 0;

    //Synchronous Mode
    public const ushort SYNCH_OP  = 1;
    public const ushort ASYNCH_OP = 2;

    //Clock Mode
    public const ushort TRIG_INTERNAL = 0;
    public const ushort TRIG_PXI_CLK  = 1;

    //DAQ Event type for the event message
    public const ushort AIEnd     = 0;
    public const ushort AOEnd     = 0;
    public const ushort DIEnd     = 0;
    public const ushort DOEnd     = 0;
    public const ushort DBEvent   = 1;
    public const ushort TrigEvent = 2;

    //Type Constants
    public const ushort DAQ_AI = 0;
    public const ushort DAQ_AO = 1;
    public const ushort DAQ_DI = 2;
    public const ushort DAQ_DO = 3;

    //EEPROM
    public const ushort EEPROM_DEFAULT_BANK = 0;
    public const ushort EEPROM_USER_BANK1   = 1;
    public const ushort EEPROM_USER_BANK2   = 2;
    public const ushort EEPROM_USER_BANK3   = 3;

    /*------------------------*/
    /* Constants for PCI-9527 */
    /*------------------------*/
    //DDS Constants
    public const uint P9527_AI_MaxDDSFreq = 432000;
    public const uint P9527_AI_MinDDSFreq = 2000;
    public const uint P9527_AO_MaxDDSFreq = 216000;
    public const uint P9527_AO_MinDDSFreq = 1000;
    //DDS Phase
    public const ushort P9527_DDSPhase_0D      = 0x00;
    public const ushort P9527_DDSPhase_11R25D  = 0x01;
    public const ushort P9527_DDSPhase_22R5D   = 0x02;
    public const ushort P9527_DDSPhase_33R75D  = 0x03;
    public const ushort P9527_DDSPhase_45D     = 0x04;
    public const ushort P9527_DDSPhase_56R25D  = 0x05;
    public const ushort P9527_DDSPhase_67R5D   = 0x08;
    public const ushort P9527_DDSPhase_78R75D  = 0x07;
    public const ushort P9527_DDSPhase_90D     = 0x08;
    public const ushort P9527_DDSPhase_101R25D = 0x09;
    public const ushort P9527_DDSPhase_112R5D  = 0x0a;
    public const ushort P9527_DDSPhase_123R75D = 0x0b;
    public const ushort P9527_DDSPhase_135D    = 0x0c;
    public const ushort P9527_DDSPhase_146R25D = 0x0d;
    public const ushort P9527_DDSPhase_157R5D  = 0x0e;
    public const ushort P9527_DDSPhase_168R75D = 0x0f;
    public const ushort P9527_DDSPhase_180D    = 0x10;
    public const ushort P9527_DDSPhase_191R25D = 0x11;
    public const ushort P9527_DDSPhase_202R5D  = 0x12;
    public const ushort P9527_DDSPhase_213R75D = 0x13;
    public const ushort P9527_DDSPhase_225D    = 0x14;
    public const ushort P9527_DDSPhase_236R25D = 0x15;
    public const ushort P9527_DDSPhase_247R5D  = 0x16;
    public const ushort P9527_DDSPhase_258R75D = 0x17;
    public const ushort P9527_DDSPhase_270D    = 0x18;
    public const ushort P9527_DDSPhase_281R25D = 0x19;
    public const ushort P9527_DDSPhase_292R5D  = 0x1a;
    public const ushort P9527_DDSPhase_303R75D = 0x1b;
    public const ushort P9527_DDSPhase_315D    = 0x1c;
    public const ushort P9527_DDSPhase_326R25D = 0x1d;
    public const ushort P9527_DDSPhase_337R5D  = 0x1e;
    public const ushort P9527_DDSPhase_348R75D = 0x1f;

    //AI Constants
    //AI Select Channel
    public const ushort P9527_AI_CH_0    = 0;
    public const ushort P9527_AI_CH_1    = 1;
    public const ushort P9527_AI_CH_DUAL = 2;
    //Input Type
    public const ushort P9527_AI_Differential       = 0x00;
    public const ushort P9527_AI_PseudoDifferential = 0x01;
    //Input Coupling
    public const ushort P9527_AI_Coupling_DC = 0x00;
    public const ushort P9527_AI_Coupling_AC = 0x10;
    public const ushort P9527_AI_EnableIEPE  = 0x20;

    //AO Constants
    //AO Select Channel
    public const ushort P9527_AO_CH_0    = 0;
    public const ushort P9527_AO_CH_1    = 1;
    public const ushort P9527_AO_CH_DUAL = 2;
    //Output Type
    public const ushort P9527_AO_Differential       = 0x00;
    public const ushort P9527_AO_PseudoDifferential = 0x01;
    public const ushort P9527_AO_BalancedOutput     = 0x02;

    //Trigger Constants
    //Trigger Mode
    public const ushort P9527_TRG_MODE_POST  = 0x00;
    public const ushort P9527_TRG_MODE_DELAY = 0x01;
    //Trigger Target
    public const ushort P9527_TRG_NONE = 0x0;
    public const ushort P9527_TRG_AI   = 0x1;
    public const ushort P9527_TRG_AO   = 0x2;
    public const ushort P9527_TRG_ALL  = 0x3;
    //Trigger Source
    public const ushort P9527_TRG_SRC_SOFT        = 0x00;
    public const ushort P9527_TRG_SRC_EXTD        = 0x10;
    public const ushort P9527_TRG_SRC_ANALOG      = 0x20;
    public const ushort P9527_TRG_SRC_SSI9        = 0x30;
    public const ushort P9527_TRG_SRC_NOWAIT      = 0x40;
    public const ushort P9527_TRG_SRC_PXI_STARTIN = 0x70;
    public const ushort P9527_TRG_SRC_PXI_BUS0    = 0x80;
    public const ushort P9527_TRG_SRC_PXI_BUS1    = 0x90;
    public const ushort P9527_TRG_SRC_PXI_BUS2    = 0xA0;
    public const ushort P9527_TRG_SRC_PXI_BUS3    = 0xB0;
    public const ushort P9527_TRG_SRC_PXI_BUS4    = 0xC0;
    public const ushort P9527_TRG_SRC_PXI_BUS5    = 0xD0;
    public const ushort P9527_TRG_SRC_PXI_BUS6    = 0xE0;
    public const ushort P9527_TRG_SRC_PXI_BUS7    = 0xF0;
    //Trigger Polarity
    public const ushort P9527_TRG_Negative = 0x000;
    public const ushort P9527_TRG_Positive = 0x100;
    //ReTrigger
    public const ushort P9527_TRG_EnReTigger = 0x200;
    //Analog Trigger Source
    public const ushort P9527_TRG_Analog_CH0 = 0;
    public const ushort P9527_TRG_Analog_CH1 = 1;
    //Analog Trigger Mode
    public const ushort P9527_TRG_Analog_Above_threshold = 0;
    public const ushort P9527_TRG_Analog_Below_threshold = 1;

    //Trigger out
    public const ushort P9527_TRG_OUT_SSI9     = 0x40;
    public const ushort P9527_TRG_OUT_PXI_BUS0 = 0x40;
    public const ushort P9527_TRG_OUT_PXI_BUS1 = 0x41;
    public const ushort P9527_TRG_OUT_PXI_BUS2 = 0x42;
    public const ushort P9527_TRG_OUT_PXI_BUS3 = 0x43;
    public const ushort P9527_TRG_OUT_PXI_BUS4 = 0x44;
    public const ushort P9527_TRG_OUT_PXI_BUS5 = 0x45;
    public const ushort P9527_TRG_OUT_PXI_BUS6 = 0x46;
    public const ushort P9527_TRG_OUT_PXI_BUS7 = 0x47;

    /*------------------------*/
    /* Constants for PXI-9529 */
    /*------------------------*/
    //AI Constants
    //AI Select Channel
    public const ushort P9529_AI_CH_0 = 0x00;
    public const ushort P9529_AI_CH_1 = 0x01;
    public const ushort P9529_AI_CH_2 = 0x02;
    public const ushort P9529_AI_CH_3 = 0x03;
    public const ushort P9529_AI_CH_4 = 0x04;
    public const ushort P9529_AI_CH_5 = 0x05;
    public const ushort P9529_AI_CH_6 = 0x06;
    public const ushort P9529_AI_CH_7 = 0x07;
    //Input Type
    public const ushort P9529_AI_Diff    = 0x00;
    public const ushort P9529_AI_PseDiff = 0x01;
    //Input Coupling
    public const ushort P9529_AI_Coupling_DC = 0x00;
    public const ushort P9529_AI_Coupling_AC = 0x04;
    public const ushort P9529_AI_EnableIEPE  = 0x06;

    //Timebase Constants
    //Timebase Source
    public const ushort P9529_Internal     = 0x0;
    public const ushort P9529_PXI10M       = 0x1;
    public const ushort P9529_PXIE100M     = 0x2;
    public const ushort P9529_PXITRIGBus   = 0x3;
	public const ushort P9529_TimeBase_SSI = 0x4;
    //Timebase Output Control
    public const ushort P9529_CLKOut_Disable = 0x00;
    public const ushort P9529_CLKOut_Enable  = 0x10;
    //Timebase from/to TRIGBUS
    public const ushort P9529_ExtCLK_TrgBus0 = 0x000;
    public const ushort P9529_ExtCLK_TrgBus1 = 0x100;
    public const ushort P9529_ExtCLK_TrgBus2 = 0x200;
    public const ushort P9529_ExtCLK_TrgBus3 = 0x300;
    public const ushort P9529_ExtCLK_TrgBus4 = 0x400;
    public const ushort P9529_ExtCLK_TrgBus5 = 0x500;
    public const ushort P9529_ExtCLK_TrgBus6 = 0x600;
    public const ushort P9529_ExtCLK_TrgBus7 = 0x700;
    public const ushort P9529_ExtCLK_SSI	 = 0x800;

    //Trigger Constants
    //Trigger Target
    public const ushort P9529_TRG_NONE = 0x0;
    public const ushort P9529_TRG_AI   = 0x1;
    //Trigger Mode
    public const ushort P9529_TRG_MODE_POST  = 0x00;
    public const ushort P9529_TRG_MODE_DELAY = 0x01;
    //Trigger Source
    public const ushort P9529_TRG_SRC_SOFT         = 0x00;
    public const ushort P9529_TRG_SRC_EXTD         = 0x10;
    public const ushort P9529_TRG_SRC_ANALOG       = 0x20;
    public const ushort P9529_TRG_SRC_SSI          = 0xD0;
    public const ushort P9529_TRG_SRC_NOWAIT       = 0x40;
    public const ushort P9529_TRG_SRC_PXIE_STARTIN = 0x60;
    public const ushort P9529_TRG_SRC_PXI_STARTIN  = 0x70;
    public const ushort P9529_TRG_SRC_PXI_BUS0     = 0x80;
    public const ushort P9529_TRG_SRC_PXI_BUS1     = 0x90;
    public const ushort P9529_TRG_SRC_PXI_BUS2     = 0xA0;
    public const ushort P9529_TRG_SRC_PXI_BUS3     = 0xB0;
    public const ushort P9529_TRG_SRC_PXI_BUS4     = 0xC0;
    public const ushort P9529_TRG_SRC_PXI_BUS5     = 0xD0;
    public const ushort P9529_TRG_SRC_PXI_BUS6     = 0xE0;
    public const ushort P9529_TRG_SRC_PXI_BUS7     = 0xF0;
    //Trigger Polarity
    public const ushort P9529_TRG_Negative = 0x000;
    public const ushort P9529_TRG_Positive = 0x100;
    //ReTrigger
    public const ushort P9529_TRG_EnReTigger = 0x200;
    //Analog Trigger Source
    public const ushort P9529_TRG_Analog_CH0 = 0;
    public const ushort P9529_TRG_Analog_CH1 = 1;
    public const ushort P9529_TRG_Analog_CH2 = 2;
    public const ushort P9529_TRG_Analog_CH3 = 3;
    public const ushort P9529_TRG_Analog_CH4 = 4;
    public const ushort P9529_TRG_Analog_CH5 = 5;
    public const ushort P9529_TRG_Analog_CH6 = 6;
    public const ushort P9529_TRG_Analog_CH7 = 7;
    //Analog Trigger Source
    public const ushort P9529_TRG_Analog_Above = 0;
    public const ushort P9529_TRG_Analog_Below = 1;

    //Trigger out
    public const ushort P9529_TRG_OUT_PXI_BUS0 = 0x40;
    public const ushort P9529_TRG_OUT_PXI_BUS1 = 0x41;
    public const ushort P9529_TRG_OUT_PXI_BUS2 = 0x42;
    public const ushort P9529_TRG_OUT_PXI_BUS3 = 0x43;
    public const ushort P9529_TRG_OUT_PXI_BUS4 = 0x44;
    public const ushort P9529_TRG_OUT_PXI_BUS5 = 0x45;
    public const ushort P9529_TRG_OUT_PXI_BUS6 = 0x46;
    public const ushort P9529_TRG_OUT_PXI_BUS7 = 0x47;
	public const ushort P9529_TRG_OUT_SSI      = 0x45;

    //Multi-Card Sync Constants
    //Multi-Card setting
    public const ushort P9529_SYN_Disable    = 0x0;
    public const ushort P9529_SYN_MasterCard = 0x1;
    public const ushort P9529_SYN_SlaveCard  = 0x2;
    //Multi-Card PDN via specific source
    public const ushort P9529_SYN_PXI_BUS0      = 0x0;
    public const ushort P9529_SYN_PXI_BUS1      = 0x1;
    public const ushort P9529_SYN_PXI_BUS2      = 0x2;
    public const ushort P9529_SYN_PXI_BUS3      = 0x3;
    public const ushort P9529_SYN_PXI_BUS4      = 0x4;
    public const ushort P9529_SYN_PXI_BUS5      = 0x5;
    public const ushort P9529_SYN_PXI_BUS6      = 0x6;
    public const ushort P9529_SYN_PXI_BUS7      = 0x7;
    public const ushort P9529_SYN_PXI_STARTRIG  = 0x8;
    public const ushort P9529_SYN_PXIE_STARTRIG = 0x9;
    public const ushort P9529_SYN_FRONT_SMB     = 0xA;
	public const ushort P9529_SYN_SSI	        = 0x1;
    //Status Mask
    public const ushort P9529_SYN_IsMultiCard    = 0x1;
    public const ushort P9529_SYN_IsMasterCard   = 0x2;
    public const ushort P9529_SYN_IsPDNSyncReady = 0x4;

    /*----------------------------------------------------------------------------*/
    /* DSA-DASK Function prototype                                                */
    /*----------------------------------------------------------------------------*/
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_Register_Card (ushort CardType, ushort card_num);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_Release_Card (ushort CardNumber);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_SetTimebase (ushort CardNumber, uint ClockSrc);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_ConfigSpeedRate (ushort CardNumber, ushort Func, ushort Setting, double SetDemandRate, out double GetActualRate);
    /*---------------------------------------------------------------------------*/
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_9527_ConfigChannel (ushort CardNumber, ushort Channel, ushort AdRange, ushort ConfigCtrl, bool AutoResetBuf);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_9529_ConfigChannel (ushort CardNumber, ushort Channel, bool Enable, ushort AdRange, ushort ConfigCtrl);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_9527_ConfigSampleRate (ushort CardNumber, double SetDemandRate, out double GetActualRate);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_AsyncCheck (ushort CardNumber, out bool Stopped, out uint AccessCnt);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_AsyncClear (ushort CardNumber, out uint AccessCnt);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_AsyncDblBufferHalfReady (ushort CardNumber, out bool HalfReady, out bool StopFlag);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_AsyncDblBufferHandled (ushort CardNumber);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_AsyncDblBufferMode (ushort CardNumber, bool Enable);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_AsyncDblBufferOverrun (ushort CardNumber, ushort op, out ushort overrunFlag);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_AsyncDblBufferToFile (ushort CardNumber);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_AsyncReTrigNextReady (ushort CardNumber, out bool Ready, out bool StopFlag, out ushort RdyTrigCnt);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_ContBufferReset (ushort CardNumber);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_ContBufferSetup (ushort CardNumber, IntPtr Buffer, uint ReadCount, out ushort BufferId);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_ContReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, uint[] BufferId, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_ContReadChannelToFile (ushort CardNumber, ushort Channel, ushort AdRange, string FileName, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_ContStatus (ushort CardNumber, out ushort Status);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_ContVScale (ushort CardNumber, ushort adRange, IntPtr readingArray, double[] voltageArray, int count);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_DataScaler (ushort cardType, ushort adRange, IntPtr readingArray, double[] voltageArray, int count);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_EventCallBack (ushort CardNumber, ushort mode, ushort EventType, CallbackDelegate callbackAddr);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_InitialMemoryAllocated (ushort CardNumber, out uint MemSize);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_SetTimeOut (ushort CardNumber, uint TimeOut);
    /*---------------------------------------------------------------------------*/
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_9527_ConfigChannel (ushort CardNumber, ushort Channel, ushort AdRange, ushort ConfigCtrl, bool AutoResetBuf);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_9527_ConfigSampleRate (ushort CardNumber, double SetDemandRate, out double GetActualRate);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_AsyncCheck (ushort CardNumber, out bool Stopped, out uint AccessCnt);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_AsyncClear (ushort CardNumber, out uint AccessCnt, ushort stop_mode);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_AsyncDblBufferHalfReady (ushort CardNumber, out bool bHalfReady);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_AsyncDblBufferMode (ushort CardNumber, bool Enable);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_ContBufferReset (ushort CardNumber);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_ContBufferSetup (ushort CardNumber, IntPtr Buffer, uint WriteCount, out ushort BufferId);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_ContStatus (ushort CardNumber, out ushort Status);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_ContWriteChannel (ushort CardNumber, ushort Channel, ushort BufId, uint WriteCount, uint Iterations, uint dwInterval, ushort definite, ushort SyncMode);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_EventCallBack (ushort CardNumber, ushort mode, ushort EventType, CallbackDelegate callbackAddr);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_InitialMemoryAllocated (ushort CardNumber, out uint MemSize);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_SetTimeOut (ushort CardNumber, uint TimeOut);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_VoltScale (ushort CardNumber, ushort Channel, double Voltage, out uint binValue);
    /*---------------------------------------------------------------------------*/
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_TRG_Config (ushort CardNumber, ushort FuncSel, ushort TrigCtrl, uint ReTriggerCnt, uint TriggerDelay);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_TRG_ConfigAnalogTrigger (ushort CardNumber, uint ATrigSrc, uint ATrigMode, double Threshold);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_TRG_SoftTriggerGen (ushort CardNumber);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_TRG_SourceConn (ushort CardNumber, ushort sigCode);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_TRG_SourceDisConn (ushort CardNumber, ushort sigCode);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_TRG_SourceClear (ushort CardNumber);
    /*---------------------------------------------------------------------------*/
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_SYN_ConfigMultiCard (ushort CardNumber, ushort Func, uint Parameter);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_SYN_CheckMultiCardStatus (ushort CardNumber, out ushort Status);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_SYN_SyncStart (ushort CardNumber);
    /*---------------------------------------------------------------------------*/
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AI_GetEvent (ushort CardNumber, out uint hEvent);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_AO_GetEvent (ushort CardNumber, out uint hEvent);
    /*---------------------------------------------------------------------------*/
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_GetActualRate (ushort CardNumber, double fSampleRate, out double fActualRate);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_GetBaseAddr (ushort CardNumber, out uint BaseAddr, out uint BaseAddr2);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_GetLCRAddr (ushort CardNumber, out uint LcrAddr);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_GetFPGAVersion (ushort CardNumber, out uint FPGAVersion);
    /*---------------------------------------------------------------------------*/
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_Auto_Calibration_ALL (ushort CardNumber);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_CAL_LoadFromBank (ushort CardNumber, ushort bank);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_CAL_SaveToUserBank (ushort CardNumber, ushort bank);
    [DllImport("DSA-Dask.dll")]
    public static extern short DSA_CAL_SetDefaultBank (ushort CardNumber, ushort bank);
    /*----------------------------------------------------------------------------*/
}
