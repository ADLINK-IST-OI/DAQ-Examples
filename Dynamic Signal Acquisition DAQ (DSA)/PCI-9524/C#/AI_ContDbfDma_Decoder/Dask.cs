using System.Runtime.InteropServices;
using System;

public delegate void CallbackDelegate();

public class DASK
{
    //ADLink PCI Card Type
    public const ushort PCI_6208V      = 1;
    public const ushort PCI_6208A      = 2;
    public const ushort PCI_6308V      = 3;
    public const ushort PCI_6308A      = 4;
    public const ushort PCI_7200       = 5;
    public const ushort PCI_7230       = 6;
    public const ushort PCI_7233       = 7;
    public const ushort PCI_7234       = 8;
    public const ushort PCI_7248       = 9;
    public const ushort PCI_7249       = 10;
    public const ushort PCI_7250       = 11;
    public const ushort PCI_7252       = 12;
    public const ushort PCI_7296       = 13;
    public const ushort PCI_7300A_RevA = 14;
    public const ushort PCI_7300A_RevB = 15;
    public const ushort PCI_7432       = 16;
    public const ushort PCI_7433       = 17;
    public const ushort PCI_7434       = 18;
    public const ushort PCI_8554       = 19;
    public const ushort PCI_9111DG     = 20;
    public const ushort PCI_9111HR     = 21;
    public const ushort PCI_9112       = 22;
    public const ushort PCI_9113       = 23;
    public const ushort PCI_9114DG     = 24;
    public const ushort PCI_9114HG     = 25;
    public const ushort PCI_9118DG     = 26;
    public const ushort PCI_9118HG     = 27;
    public const ushort PCI_9118HR     = 28;
    public const ushort PCI_9810       = 29;
    public const ushort PCI_9812       = 30;
    public const ushort PCI_7396       = 31;
    public const ushort PCI_9116       = 32;
    public const ushort PCI_7256       = 33;
    public const ushort PCI_7258       = 34;
    public const ushort PCI_7260       = 35;
    public const ushort PCI_7452       = 36;
    public const ushort PCI_7442       = 37;
    public const ushort PCI_7443       = 38;
    public const ushort PCI_7444       = 39;
    public const ushort PCI_9221       = 40;
    public const ushort PCI_9524       = 41;
    public const ushort PCI_6202       = 42;
    public const ushort PCI_9222       = 43;
    public const ushort PCI_9223       = 44;
    public const ushort PCI_7433C      = 45;
    public const ushort PCI_7434C      = 46;
    public const ushort PCI_922A       = 47;
    public const ushort PCI_7350       = 48;
    public const ushort PCI_7360       = 49;

    public const ushort MAX_CARD       = 32;

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
    public const short ErrorInvalidCounterValue   = -50;
    public const short ErrorInvalidEventHandle    = -60;
    public const short ErrorNoMessageAvailable    = -61;
    public const short ErrorEventMessgaeNotAdded  = -62;
    public const short ErrorCalibrationTimeOut    = -63;
    public const short ErrorUndefinedParameter    = -64;
    public const short ErrorInvalidBufferID       = -65;
    public const short ErrorInvalidSampledClock   = -66;
    public const short ErrorInvalisOperationMode  = -67;

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

    //Synchronous Mode
    public const ushort SYNCH_OP  = 1;
    public const ushort ASYNCH_OP = 2;

    //AO Terminate Mode
    public const ushort DA_TerminateImmediate = 0;

   //Clock Mode
    public const ushort TRIG_SOFTWARE         = 0;
    public const ushort TRIG_INT_PACER        = 1;
    public const ushort TRIG_EXT_STROBE       = 2;
    public const ushort TRIG_HANDSHAKE        = 3;
    public const ushort TRIG_CLK_10MHZ        = 4;  //PCI-7300A
    public const ushort TRIG_CLK_20MHZ        = 5;  //PCI-7300A
    public const ushort TRIG_DO_CLK_TIMER_ACK = 6;  //PCI-7300A Rev. B
    public const ushort TRIG_DO_CLK_10M_ACK   = 7;  //PCI-7300A Rev. B
    public const ushort TRIG_DO_CLK_20M_ACK   = 8;  //PCI-7300A Rev. B

    /*DIO & AFI Voltage Level*/
    public const ushort VoltLevel_3R3         = 0;
    public const ushort VoltLevel_2R5         = 1;
    public const ushort VoltLevel_1R8         = 2;

//Virtual Sampling Rate for using external clock as the clock source
    public const double CLKSRC_EXT_SampRate   = 10000;

//-------- Constants for PCI-6208A/PCI-6308A/PCI-6308V -------------------
//Output Mode
    public const ushort P6208_CURRENT_0_20MA = 0;
    public const ushort P6208_CURRENT_4_20MA = 3;
    public const ushort P6208_CURRENT_5_25MA = 1;
    public const ushort P6308_CURRENT_0_20MA = 0;
    public const ushort P6308_CURRENT_4_20MA = 3;
    public const ushort P6308_CURRENT_5_25MA = 1;
//AO Setting
    public const ushort P6308V_AO_CH0_3      = 0;
    public const ushort P6308V_AO_CH4_7      = 1;
    public const ushort P6308V_AO_UNIPOLAR   = 0;
    public const ushort P6308V_AO_BIPOLAR    = 1;
//-------- Constants for PCI-7200 --------------------
//InputMode
    public const ushort DI_WAITING      = 0x02;
    public const ushort DI_NOWAITING    = 0x00;

    public const ushort DI_TRIG_RISING  = 0x04;
    public const ushort DI_TRIG_FALLING = 0x00;

    public const ushort IREQ_RISING     = 0x08;
    public const ushort IREQ_FALLING    = 0x00;

//Output Mode
    public const ushort OREQ_ENABLE     = 0x10;
    public const ushort OREQ_DISABLE    = 0x00;

    public const ushort OTRIG_HIGH      = 0x20;
    public const ushort OTRIG_LOW       = 0x00;

//-------- Constants for PCI-7248/7296/7396/7442 ---------------
//DIO Port Direction
    public const ushort INPUT_PORT  = 1;
    public const ushort OUTPUT_PORT = 2;
//DIO Line Direction
    public const ushort INPUT_LINE  = 1;
    public const ushort OUTPUT_LINE = 2;

//Channel & Port
    public const ushort Channel_P1A  = 0;
    public const ushort Channel_P1B  = 1;
    public const ushort Channel_P1C  = 2;
    public const ushort Channel_P1CL = 3;
    public const ushort Channel_P1CH = 4;
    public const ushort Channel_P1AE = 10;
    public const ushort Channel_P1BE = 11;
    public const ushort Channel_P1CE = 12;
    public const ushort Channel_P2A  = 5;
    public const ushort Channel_P2B  = 6;
    public const ushort Channel_P2C  = 7;
    public const ushort Channel_P2CL = 8;
    public const ushort Channel_P2CH = 9;
    public const ushort Channel_P2AE = 15;
    public const ushort Channel_P2BE = 16;
    public const ushort Channel_P2CE = 17;
    public const ushort Channel_P3A  = 10;
    public const ushort Channel_P3B  = 11;
    public const ushort Channel_P3C  = 12;
    public const ushort Channel_P3CL = 13;
    public const ushort Channel_P3CH = 14;
    public const ushort Channel_P4A  = 15;
    public const ushort Channel_P4B  = 16;
    public const ushort Channel_P4C  = 17;
    public const ushort Channel_P4CL = 18;
    public const ushort Channel_P4CH = 19;
    public const ushort Channel_P5A  = 20;
    public const ushort Channel_P5B  = 21;
    public const ushort Channel_P5C  = 22;
    public const ushort Channel_P5CL = 23;
    public const ushort Channel_P5CH = 24;
    public const ushort Channel_P6A  = 25;
    public const ushort Channel_P6B  = 26;
    public const ushort Channel_P6C  = 27;
    public const ushort Channel_P6CL = 28;
    public const ushort Channel_P6CH = 29;
//the following are used for PCI7396
    public const ushort Channel_P1   = 30;
    public const ushort Channel_P2   = 31;
    public const ushort Channel_P3   = 32;
    public const ushort Channel_P4   = 33;
    public const ushort Channel_P1E  = 34; //only used by DIO_PortConfig function
    public const ushort Channel_P2E  = 35; //only used by DIO_PortConfig function
    public const ushort Channel_P3E  = 36; //only used by DIO_PortConfig function
    public const ushort Channel_P4E  = 37; //only used by DIO_PortConfig function
//7442
    public const ushort P7442_CH0    = 0;
    public const ushort P7442_CH1    = 1;
    public const ushort P7442_TTL0   = 2;
    public const ushort P7442_TTL1   = 3;
// P7443
    public const ushort P7443_CH0    = 0;
    public const ushort P7443_CH1    = 1;
    public const ushort P7443_CH2    = 2;
    public const ushort P7443_CH3    = 3;
    public const ushort P7443_TTL0   = 4;
    public const ushort P7443_TTL1   = 5;
// P7444
    public const ushort P7444_CH0    = 0;
    public const ushort P7444_CH1    = 1;
    public const ushort P7444_CH2    = 2;
    public const ushort P7444_CH3    = 3;
    public const ushort P7444_TTL0   = 4;
    public const ushort P7444_TTL1   = 5;

    //-------- Constants for PCI-7300A -------------------
//Wait Status
    public const ushort P7300_WAIT_NO   = 0;
    public const ushort P7300_WAIT_TRG  = 1;
    public const ushort P7300_WAIT_FIFO = 2;
    public const ushort P7300_WAIT_BOTH = 3;

//Terminator control
    public const ushort P7300_TERM_OFF = 0;
    public const ushort P7300_TERM_ON  = 1;

//DI control signals polarity for PCI-7300A Rev. B
    public const ushort P7300_DIREQ_POS  = 0x00000000;
    public const ushort P7300_DIREQ_NEG  = 0x00000001;
    public const ushort P7300_DIACK_POS  = 0x00000000;
    public const ushort P7300_DIACK_NEG  = 0x00000002;
    public const ushort P7300_DITRIG_POS = 0x00000000;
    public const ushort P7300_DITRIG_NEG = 0x00000004;

//DO control signals polarity for PCI-7300A Rev. B
    public const ushort P7300_DOREQ_POS  = 0x00000000;
    public const ushort P7300_DOREQ_NEG  = 0x00000008;
    public const ushort P7300_DOACK_POS  = 0x00000000;
    public const ushort P7300_DOACK_NEG  = 0x00000010;
    public const ushort P7300_DOTRIG_POS = 0x00000000;
    public const ushort P7300_DOTRIG_NEG = 0x00000020;

//DO Disable mode in DO_AsyncClear
    public const ushort P7300_DODisableDOEnabled    = 0;
    public const ushort P7300_DONotDisableDOEnabled = 1;

//-------- Constants for PCI-7432/7433/7434/7433C/7434C ---------------
    public const ushort PORT_DI_LOW    = 0;
    public const ushort PORT_DI_HIGH   = 1;
    public const ushort PORT_DO_LOW    = 0;
    public const ushort PORT_DO_HIGH   = 1;
    public const ushort P7432R_DO_LED  = 1;
    public const ushort P7433R_DO_LED  = 0;
    public const ushort P7434R_DO_LED  = 2;
    public const ushort P7432R_DI_SLOT = 1;
    public const ushort P7433R_DI_SLOT = 2;
    public const ushort P7434R_DI_SLOT = 0;
//-- Dual-Interrupt Source control for PCI-7248/96 & 7432/33 & 7230 & 8554 & 7396 &7256 &7260 & 7433C ---
    public const short INT1_NC       = -2;   //INT1 Unchange
    public const short INT1_DISABLE       = -1;   //INT1 Disabled
    public const short INT1_COS           = 0;    //INT1 COS : only available for PCI-7396, PCI-7256, PCI-7260
    public const short INT1_FP1C0         = 1;    //INT1 by Falling edge of P1C0 : only available for PCI7248/96/7396
    public const short INT1_RP1C0_FP1C3   = 2;    //INT1 by P1C0 Rising or P1C3 Falling : only available for PCI7248/96/7396
    public const short INT1_EVENT_COUNTER = 3;    //INT1 by Event Counter down to zero : only available for PCI7248/96/7396
    public const short INT1_EXT_SIGNAL    = 1;    //INT1 by external signal : only available for PCI7432/7433/7230/8554
    public const short INT1_COUT12        = 1;    //INT1 COUT12 : only available for PCI8554
    public const short INT1_CH0           = 1;    //INT1 CH0 : only available for PCI7256, PCI7260
    public const short INT1_COS0          = 1;    //INT1 COS0 : only available for PCI-7452/PCI-7442
    public const short INT1_COS1          = 2;    //INT1 COS1 : only available for PCI-7452/PCI-7442
    public const short INT1_COS2          = 4;    //INT1 COS2 : only available for PCI-7452/PCI-7442
    public const short INT1_COS3          = 8;    //INT1 COS3 : only available for PCI-7452/PCI-7442
    public const short INT2_NC       = -2;   //INT1 Unchange
    public const short INT2_DISABLE       = -1;   //INT2 Disabled
    public const short INT2_COS           = 0;    //INT2 COS : only available for PCI-7396
    public const short INT2_FP2C0         = 1;    //INT2 by Falling edge of P2C0 : only available for PCI7248/96/7396
    public const short INT2_RP2C0_FP2C3   = 2;    //INT2 by P2C0 Rising or P2C3 Falling : only available for PCI7248/96/7396
    public const short INT2_TIMER_COUNTER = 3;    //INT2 by Timer Counter down to zero : only available for PCI7248/96/7396
    public const short INT2_EXT_SIGNAL    = 1;    //INT2 by external signal : only available for PCI7432/7433/7230/8554
    public const short INT2_CH1           = 2;   //INT2 CH1 : only available for PCI7256, PCI7260
    public const short INT2_WDT           = 4;   //INT2 by WDT

    public const ushort ManualResetIEvt       = 0x4000;//interrupt event is manually reset by user
    public const ushort WDT_OVRFLOW_SAFETYOUT = 0x8000;// enable safteyout while WDT overflow
//-------- Constants for PCI-8554 --------------------
//Clock Source of Cunter N
    public const ushort ECKN         = 0;
    public const ushort COUTN_1      = 1;
    public const ushort CK1          = 2;
    public const ushort COUT10       = 3;

//Clock Source of CK1
    public const ushort CK1_C8M      = 0;
    public const ushort CK1_COUT11   = 1;

//Debounce Clock
    public const ushort DBCLK_COUT11 = 0;
    public const ushort DBCLK_2MHZ   = 1;

//-------- Constants for PCI-9111 --------------------
//Dual Interrupt Mode
    public const ushort P9111_INT1_EOC     = 0;    //Ending of AD conversion
    public const ushort P9111_INT1_FIFO_HF = 1;    //FIFO Half Full
    public const ushort P9111_INT2_PACER   = 0;    //Every Timer tick
    public const ushort P9111_INT2_EXT_TRG = 1;    //ExtTrig High->Low

//Channel Count
    public const ushort P9111_CHANNEL_DO   = 0;
    public const ushort P9111_CHANNEL_EDO  = 1;
    public const ushort P9111_CHANNEL_DI   = 0;
    public const ushort P9111_CHANNEL_EDI  = 1;

//EDO function
    public const ushort P9111_EDO_INPUT    = 1;    //EDO port set as Input port
    public const ushort P9111_EDO_OUT_EDO  = 2;    //EDO port set as Output port
    public const ushort P9111_EDO_OUT_CHN  = 3;    //EDO port set as channel number ouput port

//Trigger Mode
    public const ushort P9111_TRGMOD_SOFT  = 0x00; //Software Trigger Mode
    public const ushort P9111_TRGMOD_PRE   = 0x01; //Pre-Trigger Mode
    public const ushort P9111_TRGMOD_POST  = 0x02; //Post Trigger Mode

//AO Setting
    public const ushort P9111_AO_UNIPOLAR  = 0;
    public const ushort P9111_AO_BIPOLAR   = 1;

//-------- Constants for PCI-9118 --------------------
    public const ushort P9118_AI_BiPolar      = 0x00;
    public const ushort P9118_AI_UniPolar     = 0x01;

    public const ushort P9118_AI_SingEnded    = 0x00;
    public const ushort P9118_AI_Differential = 0x02;

    public const ushort P9118_AI_ExtG         = 0x04;

    public const ushort P9118_AI_ExtTrig      = 0x08;

    public const ushort P9118_AI_DtrgNegative = 0x00;
    public const ushort P9118_AI_DtrgPositive = 0x10;

    public const ushort P9118_AI_EtrgNegative = 0x00;
    public const ushort P9118_AI_EtrgPositive = 0x20;

    public const ushort P9118_AI_BurstModeEn  = 0x40;
    public const ushort P9118_AI_SampleHold   = 0x80;
    public const ushort P9118_AI_PostTrgEn    = 0x100;
    public const ushort P9118_AI_AboutTrgEn   = 0x200;

//-------- Constants for PCI-9116 --------------------
    public const ushort P9116_AI_LocalGND      = 0x00;
    public const ushort P9116_AI_UserCMMD      = 0x01;
    public const ushort P9116_AI_SingEnded     = 0x00;
    public const ushort P9116_AI_Differential  = 0x02;
    public const ushort P9116_AI_BiPolar       = 0x00;
    public const ushort P9116_AI_UniPolar      = 0x04;

    public const ushort P9116_TRGMOD_SOFT      = 0x00;   //Software Trigger Mode
    public const ushort P9116_TRGMOD_POST      = 0x10;   //Post Trigger Mode
    public const ushort P9116_TRGMOD_DELAY     = 0x20;   //Delay Trigger Mode
    public const ushort P9116_TRGMOD_PRE       = 0x30;   //Pre-Trigger Mode
    public const ushort P9116_TRGMOD_MIDL      = 0x40;   //Middle Trigger Mode
    public const ushort P9116_AI_TrgPositive   = 0x00;
    public const ushort P9116_AI_TrgNegative   = 0x80;
    public const ushort P9116_AI_ExtTimeBase   = 0x100;
    public const ushort P9116_AI_IntTimeBase   = 0x000;
    public const ushort P9116_AI_DlyInSamples  = 0x200;
    public const ushort P9116_AI_DlyInTimebase = 0x000;
    public const ushort P9116_AI_ReTrigEn      = 0x400;
    public const ushort P9116_AI_MCounterEn    = 0x800;
    public const ushort P9116_AI_SoftPolling   = 0x0000;
    public const ushort P9116_AI_INT           = 0x1000;
    public const ushort P9116_AI_DMA           = 0x2000;

//-------- Constants for PCI-9812 --------------------
//Trigger Mode
    public const ushort P9812_TRGMOD_SOFT    = 0x00;   //Software Trigger Mode
    public const ushort P9812_TRGMOD_POST    = 0x01;   //Post Trigger Mode
    public const ushort P9812_TRGMOD_PRE     = 0x02;   //Pre-Trigger Mode
    public const ushort P9812_TRGMOD_DELAY   = 0x03;   //Delay Trigger Mode
    public const ushort P9812_TRGMOD_MIDL    = 0x04;   //Middle Trigger Mode

    public const ushort P9812_AIEvent_Manual = 0x08;   //Middle Trigger Mode

    //Trigger Source
    public const ushort P9812_TRGSRC_CH0     = 0x00;   //trigger source --CH0
    public const ushort P9812_TRGSRC_CH1     = 0x08;   //trigger source --CH1
    public const ushort P9812_TRGSRC_CH2     = 0x10;   //trigger source --CH2
    public const ushort P9812_TRGSRC_CH3     = 0x18;   //trigger source --CH3
    public const ushort P9812_TRGSRC_EXT_DIG = 0x20;   //External Digital Trigger

//Trigger Polarity
    public const ushort P9812_TRGSLP_POS     = 0x00;   //Positive slope trigger
    public const ushort P9812_TRGSLP_NEG     = 0x40;   //Negative slope trigger

//Frequency Selection
    public const ushort P9812_AD2_GT_PCI     = 0x80;   //Freq. of A/D clock > PCI clock freq.
    public const ushort P9812_AD2_LT_PCI     = 0x00;   //Freq. of A/D clock < PCI clock freq.

//Clock Source
    public const ushort P9812_CLKSRC_INT     = 0x000;  //Internal clock
    public const ushort P9812_CLKSRC_EXT_SIN = 0x100;  //External SIN wave clock
    public const ushort P9812_CLKSRC_EXT_DIG = 0x200;  //External Square wave clock

/*-------- Constants for PCI-9221 --------------------*/
//Input Type
    public const ushort P9221_AI_SingEnded        = 0x0;
    public const ushort P9221_AI_NonRef_SingEnded = 0x1;
    public const ushort P9221_AI_Differential     = 0x2;

//Trigger Mode
    public const ushort P9221_TRGMOD_SOFT = 0x00;
    public const ushort P9221_TRGMOD_ExtD = 0x08;
//Trigger Source
    public const ushort P9221_TRGSRC_GPI0 = 0x00;
    public const ushort P9221_TRGSRC_GPI1 = 0x01;
    public const ushort P9221_TRGSRC_GPI2 = 0x02;
    public const ushort P9221_TRGSRC_GPI3 = 0x03;
    public const ushort P9221_TRGSRC_GPI4 = 0x04;
    public const ushort P9221_TRGSRC_GPI5 = 0x05;
    public const ushort P9221_TRGSRC_GPI6 = 0x06;
    public const ushort P9221_TRGSRC_GPI7 = 0x07;

//Trigger Polarity
    public const ushort P9221_AI_TrgPositive = 0;
    public const ushort P9221_AI_TrgNegative = 0x10;

//TimeBase Mode
    public const ushort P9221_AI_IntTimeBase   = 0x00;
    public const ushort P9221_AI_ExtTimeBase   = 0x80;
//TimeBase Source
    public const ushort P9221_TimeBaseSRC_GPI0 = 0x00;
    public const ushort P9221_TimeBaseSRC_GPI1 = 0x10;
    public const ushort P9221_TimeBaseSRC_GPI2 = 0x20;
    public const ushort P9221_TimeBaseSRC_GPI3 = 0x30;
    public const ushort P9221_TimeBaseSRC_GPI4 = 0x40;
    public const ushort P9221_TimeBaseSRC_GPI5 = 0x50;
    public const ushort P9221_TimeBaseSRC_GPI6 = 0x60;
    public const ushort P9221_TimeBaseSRC_GPI7 = 0x70;

//DAQ Event type for the event message
    public const ushort AIEnd     = 0;
    public const ushort AOEnd     = 0;
    public const ushort DIEnd     = 0;
    public const ushort DOEnd     = 0;
    public const ushort DBEvent   = 1;
    public const ushort TrigEvent = 2;

//EMG shdn ctrl code
    public const ushort EMGSHDN_OFF      = 0; //off
    public const ushort EMGSHDN_ON       = 1; //on
    public const ushort EMGSHDN_RECOVERY = 2; //recovery

//Hot Reset Hold ctrl code
    public const ushort HRH_OFF = 0; //off
    public const ushort HRH_ON  = 1; //on

//COS Counter OP
    public const ushort COS_COUNTER_RESET = 0;
    public const ushort COS_COUNTER_SETUP = 1;
    public const ushort COS_COUNTER_START = 2;
    public const ushort COS_COUNTER_STOP  = 3;
    public const ushort COS_COUNTER_READ  = 4;

//-------- Timer/Counter -----------------------------
//Counter Mode (8254)
    public const ushort TOGGLE_OUTPUT          = 0; //Toggle output from low to high on terminal count
    public const ushort PROG_ONE_SHOT          = 1; //Programmable one-shot
    public const ushort RATE_GENERATOR         = 2; //Rate generator
    public const ushort SQ_WAVE_RATE_GENERATOR = 3; //Square wave rate generator
    public const ushort SOFT_TRIG              = 4; //Software-triggered strobe
    public const ushort HARD_TRIG              = 5; //Hardware-triggered strobe

//General Purpose Timer/Counter
//Counter Mode
    public const ushort General_Counter         = 0x00; //general counter
    public const ushort Pulse_Generation        = 0x01; //pulse generation
//GPTC clock source
    public const ushort GPTC_CLKSRC_EXT         = 0x08;
    public const ushort GPTC_CLKSRC_INT         = 0x00;
    public const ushort GPTC_GATESRC_EXT        = 0x10;
    public const ushort GPTC_GATESRC_INT        = 0x00;
    public const ushort GPTC_UPDOWN_SELECT_EXT  = 0x20;
    public const ushort GPTC_UPDOWN_SELECT_SOFT = 0x00;
    public const ushort GPTC_UP_CTR             = 0x40;
    public const ushort GPTC_DOWN_CTR           = 0x00;
    public const ushort GPTC_ENABLE             = 0x80;
    public const ushort GPTC_DISABLE            = 0x00;

//General Purpose Timer/Counter for 9221
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

    public const ushort GPTC_EZ0_ClearPhase0      = 0x0;
    public const ushort GPTC_EZ0_ClearPhase1      = 0x1;
    public const ushort GPTC_EZ0_ClearPhase2      = 0x2;
    public const ushort GPTC_EZ0_ClearPhase3      = 0x3;

    public const ushort GPTC_EZ0_ClearMode0       = 0x0;
    public const ushort GPTC_EZ0_ClearMode1       = 0x1;
    public const ushort GPTC_EZ0_ClearMode2       = 0x2;
    public const ushort GPTC_EZ0_clearMode3       = 0x3;

//Watchdog Timer
//Counter action
    public const ushort WDT_DISARM  = 0;
    public const ushort WDT_ARM     = 1;
    public const ushort WDT_RESTART = 2;

//Pattern ID
    public const ushort INIT_PTN    = 0;
    public const ushort EMGSHDN_PTN = 1;

//Pattern ID for 7442
    public const ushort INIT_PTN_CH0     = 0;
    public const ushort INIT_PTN_CH1     = 1;
    public const ushort INIT_PTN_CH2     = 2; //only for 7444
    public const ushort  INIT_PTN_CH3    = 3; //only for 7444
    public const ushort SAFTOUT_PTN_CH0  = 4;
    public const ushort SAFTOUT_PTN_CH1  = 5;
    public const ushort  SAFTOUT_PTN_CH2 = 6; //only for 7444
    public const ushort  SAFTOUT_PTN_CH3 = 7; //only for 7444

//16-bit binary or 4-decade BCD counter
    public const ushort BIN = 0;
    public const ushort BCD = 1;

/*EEPROM*/
    public const ushort EEPROM_DEFAULT_BANK = 0;
    public const ushort EEPROM_USER_BANK1   = 1;

//----------- 9524 Const -----------------
//AI Interrupt
    public const ushort P9524_INT_LC_EOC = 2;
    public const ushort P9524_INT_GP_EOC = 3;
//DSP Constants
    public const ushort P9524_SPIKE_REJ_DISABLE = 0;
    public const ushort P9524_SPIKE_REJ_ENABLE  = 1;
//AI Transfer Mode
    public const ushort P9524_AI_XFER_POLL = 0;
    public const ushort P9524_AI_XFER_DMA  = 1;
//AI Poll all channels
    public const ushort P9524_AI_POLL_ALLCHANNELS = 8;
    public const ushort P9524_AI_POLLSCANS_CH0_CH3 = 8;
    public const ushort P9524_AI_POLLSCANS_CH0_CH2 = 9;
    public const ushort P9524_AI_POLLSCANS_CH0_CH1 = 10;
//AI Transfer Speed
    public const ushort P9524_ADC_30K_SPS  = 0;
    public const ushort P9524_ADC_15K_SPS  = 1;
    public const ushort P9524_ADC_7K5_SPS  = 2;
    public const ushort P9524_ADC_3K75_SPS = 3;
    public const ushort P9524_ADC_2K_SPS   = 4;
    public const ushort P9524_ADC_1K_SPS   = 5;
    public const ushort P9524_ADC_500_SPS  = 6;
    public const ushort P9524_ADC_100_SPS  = 7;
    public const ushort P9524_ADC_60_SPS   = 8;
    public const ushort P9524_ADC_50_SPS   = 9;
    public const ushort P9524_ADC_30_SPS   = 10;
    public const ushort P9524_ADC_25_SPS   = 11;
    public const ushort P9524_ADC_15_SPS   = 12;
    public const ushort P9524_ADC_10_SPS   = 13;
    public const ushort P9524_ADC_5_SPS    = 14;
    public const ushort P9524_ADC_2R5_SPS  = 15;
//AI Configuration Mode
    public const ushort P9524_VEX_Range_2R5V   = 0x00;
    public const ushort P9524_VEX_Range_10V    = 0x01;
    public const ushort P9524_VEX_Sence_Local  = 0x00;
    public const ushort P9524_VEX_Sence_Remote = 0x02;
    public const ushort P9524_AI_AZMode        = 0x04;
    public const ushort P9524_AI_BufAutoReset  = 0x08;
    public const ushort P9524_AI_EnEOCInt      = 0x10;
//AI Trigger configuration
    public const ushort P9524_TRGMOD_POST    = 0;
    public const ushort P9524_TRGSRC_SOFT    = 0;
    public const ushort P9524_TRGSRC_ExtD    = 1;
    public const ushort P9524_TRGSRC_SSI     = 2;
    public const ushort P9524_TRGSRC_QD0     = 3;
    public const ushort P9524_TRGSRC_PG0     = 4;
    public const ushort P9524_AI_TrgPositive = 0;
    public const ushort P9524_AI_TrgNegative = 8;
//AI Group
    public const ushort P9524_AI_LC_Group = 0;
    public const ushort P9524_AI_GP_Group = 1;
//AI Channel
    public const ushort P9524_AI_LC_CH0 = 0;
    public const ushort P9524_AI_LC_CH1 = 1;
    public const ushort P9524_AI_LC_CH2 = 2;
    public const ushort P9524_AI_LC_CH3 = 3;
    public const ushort P9524_AI_GP_CH0 = 4;
    public const ushort P9524_AI_GP_CH1 = 5;
    public const ushort P9524_AI_GP_CH2 = 6;
    public const ushort P9524_AI_GP_CH3 = 7;

//Counter Number
    public const ushort P9524_CTR_PG0 = 0;
    public const ushort P9524_CTR_PG1 = 1;
    public const ushort P9524_CTR_PG2 = 2;
    public const ushort P9524_CTR_QD0 = 3;
    public const ushort P9524_CTR_QD1 = 4;
    public const ushort P9524_CTR_QD2 = 5;
    public const ushort P9524_CTR_INTCOUNTER = 6;
//Counter Mode
    public const ushort P9524_PulseGen_OUTDIR_N   = 0;
    public const ushort P9524_PulseGen_OUTDIR_R   = 1;
    public const ushort P9524_PulseGen_CW         = 0;
    public const ushort P9524_PulseGen_CCW        = 2;
    public const ushort P9524_x4_AB_Phase_Decoder = 3;
    public const ushort P9524_Timer               = 4;
//Counter Op
    public const ushort P9524_CTR_Enable = 0;
//Event Mode
    public const ushort P9524_Event_Timer = 0;

//AO
    public const ushort P9524_AO_CH0_1 = 0;


//------Constants for PCI-6202------
    public const ushort P6202_ISO0     = 0;
    public const ushort P6202_TTL0     = 1;
    public const ushort P6202_GPTC0    = 0;
    public const ushort P6202_GPTC1    = 1;
    public const ushort P6202_ENCODER0 = 2;
    public const ushort P6202_ENCODER1 = 3;
    public const ushort P6202_ENCODER2 = 4;

//DA control constant
    public const ushort P6202_DA_WRSRC_Int  = 0;
    public const ushort P6202_DA_WRSRC_AFI0 = 1;
    public const ushort P6202_DA_WRSRC_SSI  = 2;
    public const ushort P6202_DA_WRSRC_AFI1 = 3;

//DA trigger constant
    public const ushort P6202_DA_TRGSRC_SOFT  = 0x00;
    public const ushort P6202_DA_TRGSRC_AFI0  = 0x01;
    public const ushort P6202_DA_TRSRC_SSI    = 0x02;
    public const ushort P6202_DA_TRGSRC_AFI1  = 0x03;
    public const ushort P6202_DA_TRGMOD_POST  = 0x00;
    public const ushort P6202_DA_TRGMOD_DELAY = 0x04;
    public const ushort P6202_DA_ReTrigEn     = 0x20;
    public const ushort P6202_DA_DLY2En       = 0x100;

//SSI signal code
    public const ushort P6202_SSI_DA_CONV = 0x04;
    public const ushort P6202_SSI_DA_TRIG = 0x40;

//Encoder constant
    public const ushort P6202_EVT_TYPE_EPT0       = 0x00;
    public const ushort P6202_EVT_TYPE_EPT1       = 0x01;
    public const ushort P6202_EVT_TYPE_EPT2       = 0x02;
    public const ushort P6202_EVT_TYPE_EZC0       = 0x03;
    public const ushort P6202_EVT_TYPE_EZC1       = 0x04;
    public const ushort P6202_EVT_TYPE_EZC2       = 0x05;

    public const ushort P6202_EVT_MOD_EPT         = 0x00;

    public const ushort P6202_EPT_PULWIDTH_200us  = 0x00;
    public const ushort P6202_EPT_PULWIDTH_2ms    = 0x01;
    public const ushort P6202_EPT_PULWIDTH_20ms   = 0x02;
    public const ushort P6202_EPT_PULWIDTH_200ms  = 0x03;

    public const ushort P6202_EPT_TRGOUT_CALLBACK = 0x04;
    public const ushort P6202_EPT_TRGOUT_AFI      = 0x08;

    public const ushort P6202_ENCODER0_LDATA      = 0x05;
    public const ushort P6202_ENCODER1_LDATA      = 0x06;
    public const ushort P6202_ENCODER2_LDATA      = 0x07;

    /*------------------------------------*/
    /* Constants for PCI-922x             */
    /*------------------------------------*/
    /*------------------*/
    /* AI Constants     */
    /*------------------*/
    /*Input Type*/
    public const ushort P922x_AI_SingEnded        = 0x00;
    public const ushort P922x_AI_NonRef_SingEnded = 0x01;
    public const ushort P922x_AI_Differential     = 0x02;
    /*Conversion Source*/
    public const ushort P922x_AI_CONVSRC_INT      = 0x00;
    public const ushort P922x_AI_CONVSRC_GPI0     = 0x10;
    public const ushort P922x_AI_CONVSRC_GPI1     = 0x20;
    public const ushort P922x_AI_CONVSRC_GPI2     = 0x30;
    public const ushort P922x_AI_CONVSRC_GPI3     = 0x40;
    public const ushort P922x_AI_CONVSRC_GPI4     = 0x50;
    public const ushort P922x_AI_CONVSRC_GPI5     = 0x60;
    public const ushort P922x_AI_CONVSRC_GPI6     = 0x70;
    public const ushort P922x_AI_CONVSRC_GPI7     = 0x80;
    public const ushort P922x_AI_CONVSRC_SSI1     = 0x90;
    public const ushort P922x_AI_CONVSRC_SSI      = 0x90;
    /*Trigger Mode*/
    public const ushort P922x_AI_TRGMOD_POST      = 0x00;
    public const ushort P922x_AI_TRGMOD_GATED     = 0x01;
    /*Trigger Source*/
    public const ushort P922x_AI_TRGSRC_SOFT      = 0x00;
    public const ushort P922x_AI_TRGSRC_GPI0      = 0x10;
    public const ushort P922x_AI_TRGSRC_GPI1      = 0x20;
    public const ushort P922x_AI_TRGSRC_GPI2      = 0x30;
    public const ushort P922x_AI_TRGSRC_GPI3      = 0x40;
    public const ushort P922x_AI_TRGSRC_GPI4      = 0x50;
    public const ushort P922x_AI_TRGSRC_GPI5      = 0x60;
    public const ushort P922x_AI_TRGSRC_GPI6      = 0x70;
    public const ushort P922x_AI_TRGSRC_GPI7      = 0x80;
    public const ushort P922x_AI_TRGSRC_SSI5      = 0x90;
    public const ushort P922x_AI_TRGSRC_SSI       = 0x90;
    /*Trigger Polarity*/
    public const ushort P922x_AI_TrgPositive      = 0x000;
    public const ushort P922x_AI_TrgNegative      = 0x100;
    /*ReTrigger*/
    public const ushort P922x_AI_EnReTigger       = 0x200;

    /*------------------*/
    /* AO Constants     */
    /*------------------*/
    /*Conversion Source*/
    public const ushort P922x_AO_CONVSRC_INT  = 0x00;
    public const ushort P922x_AO_CONVSRC_GPI0 = 0x01;
    public const ushort P922x_AO_CONVSRC_GPI1 = 0x02;
    public const ushort P922x_AO_CONVSRC_GPI2 = 0x03;
    public const ushort P922x_AO_CONVSRC_GPI3 = 0x04;
    public const ushort P922x_AO_CONVSRC_GPI4 = 0x05;
    public const ushort P922x_AO_CONVSRC_GPI5 = 0x06;
    public const ushort P922x_AO_CONVSRC_GPI6 = 0x07;
    public const ushort P922x_AO_CONVSRC_GPI7 = 0x08;
    public const ushort P922x_AO_CONVSRC_SSI2 = 0x09;
    public const ushort P922x_AO_CONVSRC_SSI  = 0x09;
    /*Trigger Mode*/
    public const ushort P922x_AO_TRGMOD_POST  = 0x00;
    public const ushort P922x_AO_TRGMOD_DELAY = 0x01;
    /*Trigger Source*/
    public const ushort P922x_AO_TRGSRC_SOFT  = 0x00;
    public const ushort P922x_AO_TRGSRC_GPI0  = 0x10;
    public const ushort P922x_AO_TRGSRC_GPI1  = 0x20;
    public const ushort P922x_AO_TRGSRC_GPI2  = 0x30;
    public const ushort P922x_AO_TRGSRC_GPI3  = 0x40;
    public const ushort P922x_AO_TRGSRC_GPI4  = 0x50;
    public const ushort P922x_AO_TRGSRC_GPI5  = 0x60;
    public const ushort P922x_AO_TRGSRC_GPI6  = 0x70;
    public const ushort P922x_AO_TRGSRC_GPI7  = 0x80;
    public const ushort P922x_AO_TRGSRC_SSI6  = 0x90;
    public const ushort P922x_AO_TRGSRC_SSI   = 0x90;
    /*Trigger Polarity*/
    public const ushort P922x_AO_TrgPositive  = 0x000;
    public const ushort P922x_AO_TrgNegative  = 0x100;
    /*Retrigger*/
    public const ushort P922x_AO_EnReTigger   = 0x200;
    /*Delay 2*/
    public const ushort P922x_AO_EnDelay2     = 0x400;

    /*------------------*/
    /* DI Constants     */
    /*------------------*/
    /*Conversion Source*/
    public const ushort P922x_DI_CONVSRC_INT    = 0x00;
    public const ushort P922x_DI_CONVSRC_GPI0   = 0x01;
    public const ushort P922x_DI_CONVSRC_GPI1   = 0x02;
    public const ushort P922x_DI_CONVSRC_GPI2   = 0x03;
    public const ushort P922x_DI_CONVSRC_GPI3   = 0x04;
    public const ushort P922x_DI_CONVSRC_GPI4   = 0x05;
    public const ushort P922x_DI_CONVSRC_GPI5   = 0x06;
    public const ushort P922x_DI_CONVSRC_GPI6   = 0x07;
    public const ushort P922x_DI_CONVSRC_GPI7   = 0x08;
    public const ushort P922x_DI_CONVSRC_ADCONV = 0x09;
    public const ushort P922x_DI_CONVSRC_DACONV = 0x0A;
    /*Trigger Mode*/
    public const ushort P922x_DI_TRGMOD_POST    = 0x00;
    /*Trigger Source*/
    public const ushort P922x_DI_TRGSRC_SOFT    = 0x00;
    public const ushort P922x_DI_TRGSRC_GPI0    = 0x10;
    public const ushort P922x_DI_TRGSRC_GPI1    = 0x20;
    public const ushort P922x_DI_TRGSRC_GPI2    = 0x30;
    public const ushort P922x_DI_TRGSRC_GPI3    = 0x40;
    public const ushort P922x_DI_TRGSRC_GPI4    = 0x50;
    public const ushort P922x_DI_TRGSRC_GPI5    = 0x60;
    public const ushort P922x_DI_TRGSRC_GPI6    = 0x70;
    public const ushort P922x_DI_TRGSRC_GPI7    = 0x80;
    /*Trigger Polarity*/
    public const ushort P922x_DI_TrgPositive    = 0x000;
    public const ushort P922x_DI_TrgNegative    = 0x100;
    /*ReTrigger*/
    public const ushort P922x_DI_EnReTigger     = 0x200;

    /*------------------*/
    /* DO Constants     */
    /*------------------*/
    /*Conversion Source*/
    public const ushort P922x_DO_CONVSRC_INT    = 0x00;
    public const ushort P922x_DO_CONVSRC_GPI0   = 0x01;
    public const ushort P922x_DO_CONVSRC_GPI1   = 0x02;
    public const ushort P922x_DO_CONVSRC_GPI2   = 0x03;
    public const ushort P922x_DO_CONVSRC_GPI3   = 0x04;
    public const ushort P922x_DO_CONVSRC_GPI4   = 0x05;
    public const ushort P922x_DO_CONVSRC_GPI5   = 0x06;
    public const ushort P922x_DO_CONVSRC_GPI6   = 0x07;
    public const ushort P922x_DO_CONVSRC_GPI7   = 0x08;
    public const ushort P922x_DO_CONVSRC_ADCONV = 0x09;
    public const ushort P922x_DO_CONVSRC_DACONV = 0x0A;
    /*Trigger Mode*/
    public const ushort P922x_DO_TRGMOD_POST    = 0x00;
    public const ushort P922x_DO_TRGMOD_DELAY   = 0x01;
    /*Trigger Source*/
    public const ushort P922x_DO_TRGSRC_SOFT    = 0x00;
    public const ushort P922x_DO_TRGSRC_GPI0    = 0x10;
    public const ushort P922x_DO_TRGSRC_GPI1    = 0x20;
    public const ushort P922x_DO_TRGSRC_GPI2    = 0x30;
    public const ushort P922x_DO_TRGSRC_GPI3    = 0x40;
    public const ushort P922x_DO_TRGSRC_GPI4    = 0x50;
    public const ushort P922x_DO_TRGSRC_GPI5    = 0x60;
    public const ushort P922x_DO_TRGSRC_GPI6    = 0x70;
    public const ushort P922x_DO_TRGSRC_GPI7    = 0x80;
    /*Trigger Polarity*/
    public const ushort P922x_DO_TrgPositive    = 0x000;
    public const ushort P922x_DO_TrgNegative    = 0x100;
    /*Retrigger*/
    public const ushort P922x_DO_EnReTigger     = 0x200;

    /*--------------------------*/
    /* Encoder/GPTC Constants   */
    /*--------------------------*/
    public const ushort P922x_GPTC0               = 0x00;
    public const ushort P922x_GPTC1               = 0x01;
    public const ushort P922x_GPTC2               = 0x02;
    public const ushort P922x_GPTC3               = 0x03;
    public const ushort P922x_ENCODER0            = 0x04;
    public const ushort P922x_ENCODER1            = 0x05;
    /*Encoder Setting Event Mode*/
    public const ushort P922x_EVT_MOD_EPT         = 0x00;
    /*Encoder Setting Event Control*/
    public const ushort P922x_EPT_PULWIDTH_200us  = 0x00;
    public const ushort P922x_EPT_PULWIDTH_2ms    = 0x01;
    public const ushort P922x_EPT_PULWIDTH_20ms   = 0x02;
    public const ushort P922x_EPT_PULWIDTH_200ms  = 0x03;
    public const ushort P922x_EPT_TRGOUT_GPO      = 0x04;
    public const ushort P922x_EPT_TRGOUT_CALLBACK = 0x08;
    /*Event Type*/
    public const ushort P922x_EVT_TYPE_EPT0       = 0x00;
    public const ushort P922x_EVT_TYPE_EPT1       = 0x01;

    /*SSI signal code*/
    public const ushort P922x_SSI_AI_CONV         = 0x02;
    public const ushort P922x_SSI_AI_TRIG         = 0x20;
    public const ushort P922x_SSI_AO_CONV         = 0x04;
    public const ushort P922x_SSI_AO_TRIG         = 0x40;

    /*------------------------------------*/
    /* Constants for PCIe-7350            */
    /*------------------------------------*/
    public const ushort P7350_PortDIO         = 0;
    public const ushort P7350_PortAFI         = 1;
    /*DIO Port*/
    public const ushort P7350_DIO_A           = 0;
    public const ushort P7350_DIO_B           = 1;
    public const ushort P7350_DIO_C           = 2;
    public const ushort P7350_DIO_D           = 3;
    /*AFI Port*/
    public const ushort P7350_AFI_0           = 0;
    public const ushort P7350_AFI_1           = 1;
    public const ushort P7350_AFI_2           = 2;
    public const ushort P7350_AFI_3           = 3;
    public const ushort P7350_AFI_4           = 4;
    public const ushort P7350_AFI_5           = 5;
    public const ushort P7350_AFI_6           = 6;
    public const ushort P7350_AFI_7           = 7;
    /*AFI Mode*/
    public const ushort P7350_AFI_DIStartTrig = 0;
    public const ushort P7350_AFI_DOStartTrig = 1;
    public const ushort P7350_AFI_DIPauseTrig = 2;
    public const ushort P7350_AFI_DOPauseTrig = 3;
    public const ushort P7350_AFI_DISWTrigOut = 4;
    public const ushort P7350_AFI_DOSWTrigOut = 5;
    public const ushort P7350_AFI_COSTrigOut  = 6;
    public const ushort P7350_AFI_PMTrigOut   = 7;
    public const ushort P7350_AFI_HSDIREQ     = 8;
    public const ushort P7350_AFI_HSDIACK     = 9;
    public const ushort P7350_AFI_HSDITRIG    = 10;
    public const ushort P7350_AFI_HSDOREQ     = 11;
    public const ushort P7350_AFI_HSDOACK     = 12;
    public const ushort P7350_AFI_HSDOTRIG    = 13;
    public const ushort P7350_AFI_SPI         = 14;
    public const ushort P7350_AFI_I2C         = 15;
    public const ushort P7350_POLL_DI         = 16;
    public const ushort P7350_POLL_DO         = 17;
    /*Operation Mode*/
    public const ushort P7350_FreeRun         = 0;
    public const ushort P7350_HandShake       = 1;
    public const ushort P7350_BurstHandShake  = 2;
    /*Trigger Status*/
    public const ushort P7350_WAIT_NO         = 0;
    public const ushort P7350_WAIT_EXTTRG     = 1;
    public const ushort P7350_WAIT_SOFTTRG    = 2;
    /*Sampled Clock*/
    public const ushort P7350_IntSampledCLK   = 0x00;
    public const ushort P7350_ExtSampledCLK   = 0x01;
    /*Sampled Clock Edge*/
    public const ushort P7350_SampledCLK_R    = 0x00;
    public const ushort P7350_SampledCLK_F    = 0x02;
    /*Enable Export Sample Clock*/
    public const ushort P7350_EnExpSampledCLK = 0x04;
    /*Trigger Configuration*/
    public const ushort P7350_EnPauseTrig     = 0x01;
    public const ushort P7350_EnSoftTrigOut   = 0x02;
    /*HandShake & Trigger Polarity*/
    public const ushort P7350_DIREQ_POS       = 0x00;
    public const ushort P7350_DIREQ_NEG       = 0x01;
    public const ushort P7350_DIACK_POS       = 0x00;
    public const ushort P7350_DIACK_NEG       = 0x02;
    public const ushort P7350_DITRIG_POS      = 0x00;
    public const ushort P7350_DITRIG_NEG      = 0x04;
    public const ushort P7350_DIStartTrig_POS = 0x00;
    public const ushort P7350_DIStartTrig_NEG = 0x08;
    public const ushort P7350_DIPauseTrig_POS = 0x00;
    public const ushort P7350_DIPauseTrig_NEG = 0x10;
    public const ushort P7350_DOREQ_POS       = 0x00;
    public const ushort P7350_DOREQ_NEG       = 0x01;
    public const ushort P7350_DOACK_POS       = 0x00;
    public const ushort P7350_DOACK_NEG       = 0x02;
    public const ushort P7350_DOTRIG_POS      = 0x00;
    public const ushort P7350_DOTRIG_NEG      = 0x04;
    public const ushort P7350_DOStartTrig_POS = 0x00;
    public const ushort P7350_DOStartTrig_NEG = 0x08;
    public const ushort P7350_DOPauseTrig_POS = 0x00;
    public const ushort P7350_DOPauseTrig_NEG = 0x10;

    /*External Sampled Clock Source*/
    public const ushort P7350_ECLK_IN         = 8;
    /*Export Sampled Clock*/
    public const ushort P7350_ECLK_OUT        = 8;
    /*Enable Dynamic Delay Adjust*/
    public const ushort P7350_DisDDA          = 0x0;
    public const ushort P7350_EnDDA           = 0x1;
    /*Dynamic Delay Adjust Mode*/
    public const ushort P7350_DDA_Lag         = 0x0;
    public const ushort P7350_DDA_Lead        = 0x2;
    /*Dynamic Delay Adjust Step*/
    public const ushort P7350_DDA_130PS       = 0;
    public const ushort P7350_DDA_260PS       = 1;
    public const ushort P7350_DDA_390PS       = 2;
    public const ushort P7350_DDA_520PS       = 3;
    public const ushort P7350_DDA_650PS       = 4;
    public const ushort P7350_DDA_780PS       = 5;
    public const ushort P7350_DDA_910PS       = 6;
    public const ushort P7350_DDA_1R04NS      = 7;
    /*Enable Dynamic Phase Adjust*/
    public const ushort P7350_DisDPA          = 0x0;
    public const ushort P7350_EnDPA           = 0x1;
    /*Dynamic Delay Adjust Degree*/
    public const ushort P7350_DPA_0DG         = 0;
    public const ushort P7350_DPA_22R5DG      = 1;
    public const ushort P7350_DPA_45DG        = 2;
    public const ushort P7350_DPA_67R5DG      = 3;
    public const ushort P7350_DPA_90DG        = 4;
    public const ushort P7350_DPA_112R5DG     = 5;
    public const ushort P7350_DPA_135DG       = 6;
    public const ushort P7350_DPA_157R5DG     = 7;
    public const ushort P7350_DPA_180DG       = 8;
    public const ushort P7350_DPA_202R5DG     = 9;
    public const ushort P7350_DPA_225DG       = 10;
    public const ushort P7350_DPA_247R5DG     = 11;
    public const ushort P7350_DPA_270DG       = 12;
    public const ushort P7350_DPA_292R5DG     = 13;
    public const ushort P7350_DPA_315DG       = 14;
    public const ushort P7350_DPA_337R5DG     = 15;

    /*------------------------------------*/
    /* Constants for PCIe-7360            */
    /*------------------------------------*/
    public const ushort P7360_PortDIO         = 0;
    public const ushort P7360_PortAFI         = 1;
    public const ushort P7360_PortECLK        = 2;
    /*DIO Port*/
    public const ushort P7360_DIO_A           = 0;
    public const ushort P7360_DIO_B           = 1;
    public const ushort P7360_DIO_C           = 2;
    public const ushort P7360_DIO_D           = 3;
    /*AFI Port*/
    public const ushort P7360_AFI_0           = 0;
    public const ushort P7360_AFI_1           = 1;
    public const ushort P7360_AFI_2           = 2;
    public const ushort P7360_AFI_3           = 3;
    public const ushort P7360_AFI_4           = 4;
    public const ushort P7360_AFI_5           = 5;
    public const ushort P7360_AFI_6           = 6;
    public const ushort P7360_AFI_7           = 7;
    /*AFI Mode*/
    public const ushort P7360_AFI_DIStartTrig = 0;
    public const ushort P7360_AFI_DOStartTrig = 1;
    public const ushort P7360_AFI_DIPauseTrig = 2;
    public const ushort P7360_AFI_DOPauseTrig = 3;
    public const ushort P7360_AFI_DISWTrigOut = 4;
    public const ushort P7360_AFI_DOSWTrigOut = 5;
    public const ushort P7360_AFI_COSTrigOut  = 6;
    public const ushort P7360_AFI_PMTrigOut   = 7;
    public const ushort P7360_AFI_HSDIREQ     = 8;
    public const ushort P7360_AFI_HSDIACK     = 9;
    public const ushort P7360_AFI_HSDITRIG    = 10;
    public const ushort P7360_AFI_HSDOREQ     = 11;
    public const ushort P7360_AFI_HSDOACK     = 12;
    public const ushort P7360_AFI_HSDOTRIG    = 13;
    public const ushort P7360_AFI_SPI         = 14;
    public const ushort P7360_AFI_I2C         = 15;
    public const ushort P7360_POLL_DI         = 16;
    public const ushort P7360_POLL_DO         = 17;
    /*Operation Mode*/
    public const ushort P7360_FreeRun         = 0;
    public const ushort P7360_HandShake       = 1;
    public const ushort P7360_BurstHandShake  = 2;
    public const ushort P7360_BurstHandShake2  = 3;
    /*Trigger Status*/
    public const ushort P7360_WAIT_NO         = 0;
    public const ushort P7360_WAIT_EXTTRG     = 1;
    public const ushort P7360_WAIT_SOFTTRG    = 2;
    public const ushort P7360_WAIT_PATMATCH    = 3;
    /*Sampled Clock*/
    public const ushort P7360_IntSampledCLK   = 0x00;
    public const ushort P7360_ExtSampledCLK   = 0x01;
    /*Sampled Clock Edge*/
    public const ushort P7360_SampledCLK_R    = 0x00;
    public const ushort P7360_SampledCLK_F    = 0x02;
    /*Enable Export Sample Clock*/
    public const ushort P7360_EnExpSampledCLK = 0x04;
    /*Trigger Configuration*/
    public const ushort P7360_EnPauseTrig     = 0x01;
    public const ushort P7360_EnSoftTrigOut   = 0x02;
    /*HandShake & Trigger Polarity*/
    public const ushort P7360_DIREQ_POS       = 0x00;
    public const ushort P7360_DIREQ_NEG       = 0x01;
    public const ushort P7360_DIACK_POS       = 0x00;
    public const ushort P7360_DIACK_NEG       = 0x02;
    public const ushort P7360_DITRIG_POS      = 0x00;
    public const ushort P7360_DITRIG_NEG      = 0x04;
    public const ushort P7360_DIStartTrig_POS = 0x00;
    public const ushort P7360_DIStartTrig_NEG = 0x08;
    public const ushort P7360_DIPauseTrig_POS = 0x00;
    public const ushort P7360_DIPauseTrig_NEG = 0x10;
    public const ushort P7360_DOREQ_POS       = 0x00;
    public const ushort P7360_DOREQ_NEG       = 0x01;
    public const ushort P7360_DOACK_POS       = 0x00;
    public const ushort P7360_DOACK_NEG       = 0x02;
    public const ushort P7360_DOTRIG_POS      = 0x00;
    public const ushort P7360_DOTRIG_NEG      = 0x04;
    public const ushort P7360_DOStartTrig_POS = 0x00;
    public const ushort P7360_DOStartTrig_NEG = 0x08;
    public const ushort P7360_DOPauseTrig_POS = 0x00;
    public const ushort P7360_DOPauseTrig_NEG = 0x10;

    /*External Sampled Clock Source*/
    public const ushort P7360_ECLK_IN         = 8;
    /*Export Sampled Clock*/
    public const ushort P7360_ECLK_OUT        = 8;
    /*Enable Dynamic Delay Adjust*/
    public const ushort P7360_DisDDA          = 0x0;
    public const ushort P7360_EnDDA           = 0x1;
    /*Dynamic Delay Adjust Mode*/
    public const ushort P7360_DDA_Lag         = 0x0;
    public const ushort P7360_DDA_Lead        = 0x2;
    /*Enable Dynamic Phase Adjust*/
    public const ushort P7360_DisDPA          = 0x0;
    public const ushort P7360_EnDPA           = 0x1;
    /*ECLK output type control*/
    public const ushort P7360_ECLKAligned	  = 0x0;
    public const ushort P7360_ECLKAlwaysOn	  = 0x1;

    /*------------------------------------*/
    /* Constants for I Squared C (I2C)    */
    /*------------------------------------*/
    /*I2C Port*/
    public const ushort I2C_Port_A = 0;
    /*I2C Control Operation*/
    public const ushort I2C_ENABLE = 0;
    public const ushort I2C_STOP   = 1;

    /*-------------------------------------------*/
    /* Constants for Serial Peripheral Interface */
    /*-------------------------------------------*/
    /*SPI Port*/
    public const ushort SPI_Port_A = 0;
    /*SPI Clock Mode*/
    public const ushort SPI_CLK_L  = 0x00;
    public const ushort SPI_CLK_H  = 0x01;
    /*SPI TX Polarity*/
    public const ushort SPI_TX_POS = 0x00;
    public const ushort SPI_TX_NEG = 0x02;
    /*SPI RX Polarity*/
    public const ushort SPI_RX_POS = 0x00;
    public const ushort SPI_RX_NEG = 0x04;
    /*SPI Transferred Order*/
    public const ushort SPI_MSB    = 0x00;
    public const ushort SPI_LSB    = 0x08;
    /*SPI Control Operation*/
    public const ushort SPI_ENABLE = 0;

    /*------------------------------------*/
    /* Constants for Pattern Match        */
    /*------------------------------------*/
    /*Pattern Match Channel Mode*/
    public const ushort PATMATCH_CHNDisable = 0;
    public const ushort PATMATCH_CHNEnable  = 1;
    /*Pattern Match Channel Type*/
    public const ushort PATMATCH_Level_L = 0;
    public const ushort PATMATCH_Level_H = 1;
    public const ushort PATMATCH_Edge_R  = 2;
    public const ushort PATMATCH_Edge_F  = 3;
    /*Pattern Match Operation*/
    public const ushort PATMATCH_STOP    = 0;
    public const ushort PATMATCH_START   = 1;
    public const ushort PATMATCH_RESTART = 2;

    public const ushort RegBySlot = 0x8000;

	/*---------------------------------*/
	/* Constants for Access EEPROM 	   */
	/*---------------------------------*/
	/*for PCI-7230/PCMe-7230*/
	public const ushort P7230_EEP_BLK_0	= 0;
    public const ushort P7230_EEP_BLK_1 = 1;

/*----------------------------------------------------------------------------*/
/* PCIS-DASK Function prototype                                               */
/*----------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short Register_Card (ushort CardType, ushort card_num);
    [DllImport("PCI-Dask.dll")]
    public static extern short Release_Card (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short GetActualRate (ushort CardNumber, double fSampleRate, out double fActualRate);
    [DllImport("PCI-Dask.dll")]
    public static extern short GetActualRate_9524 (ushort CardNumber, ushort Group, double SampleRate, out double ActualRate);
    [DllImport("PCI-Dask.dll")]
    public static extern short EMGShutDownControl (ushort CardNumber, byte ctrl);
    [DllImport("PCI-Dask.dll")]
    public static extern short EMGShutDownStatus (ushort CardNumber, out byte sts);
    [DllImport("PCI-Dask.dll")]
    public static extern short HotResetHoldControl (ushort CardNumber, byte enable);
    [DllImport("PCI-Dask.dll")]
    public static extern short HotResetHoldStatus (ushort CardNumber, out byte sts);
    [DllImport("PCI-Dask.dll")]
    public static extern short GetInitPattern (ushort CardNumber, byte patID, out uint pattern);
    [DllImport("PCI-Dask.dll")]
    public static extern short SetInitPattern (ushort CardNumber, byte patID, uint pattern);
    [DllImport("PCI-Dask.dll")]
    public static extern short IdentifyLED_Control (ushort CardNumber, byte ctrl);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9111_Config (ushort CardNumber, ushort TrigSource, ushort TrgMode, ushort TraceCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9112_Config (ushort CardNumber, ushort TrigSource);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9113_Config (ushort CardNumber, ushort TrigSource);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9114_Config (ushort CardNumber, ushort TrigSource);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9114_PreTrigConfig (ushort CardNumber, ushort PreTrgEn, ushort TraceCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9116_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, ushort PostCnt, ushort MCnt, ushort ReTrgCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9116_CounterInterval (ushort CardNumber, uint ScanIntrv, uint SampIntrv);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9118_Config (ushort CardNumber, ushort ModeCtrl, ushort FunCtrl, ushort BurstCnt, ushort PostCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9221_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9221_CounterInterval (ushort CardNumber, uint ScanIntrv, uint SampIntrv);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9812_Config (ushort CardNumber, ushort TrgMode, ushort TrgSrc, ushort TrgPol, ushort ClkSel, ushort TrgLevel, ushort PostCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9812_SetDiv (ushort CardNumber, uint PacerVal);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9524_Config (ushort CardNumber, ushort Group, ushort XMode, ushort ConfigCtrl, ushort TrigCtrl, ushort TrigValue);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9524_PollConfig (ushort CardNumber, ushort Groupt, ushort PollChannel, ushort PollRange, ushort PollSpeed);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9524_SetDSP (ushort CardNumber, ushort Channel, ushort Mode, ushort DFStage, ushort SPKRejThreshold);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9524_GetEOCEvent (ushort CardNumber, ushort Group, out uint hEvent);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9222_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTriggerCnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9222_CounterInterval (ushort CardNumber, uint ScanIntrv, uint SampIntrv);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9223_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTriggerCnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_9223_CounterInterval (ushort CardNumber, uint ScanIntrv, uint SampIntrv);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_922A_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTriggerCnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_922A_CounterInterval (ushort CardNumber, uint ScanIntrv, uint SampIntrv);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncCheck (ushort CardNumber, out byte Stopped, out uint AccessCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncClear (ushort CardNumber, out uint AccessCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncDblBufferHalfReady (ushort CardNumber, out byte HalfReady, out byte StopFlag);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncDblBufferMode (ushort CardNumber, bool Enable);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncDblBufferTransfer (ushort CardNumber, ushort[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncDblBufferOverrun (ushort CardNumber, ushort op, out ushort overrunFlag);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncDblBufferHandled (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncDblBufferToFile (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_AsyncReTrigNextReady (ushort CardNumber, out bool Ready, out bool StopFlag, out ushort RdyTrigCnt);
    [DllImport("PCI-Dask.dll")]
    //public static extern short AI_ContBufferSetup (ushort CardNumber, ushort[] Buffer, uint ReadCount, out ushort BufferId);
    public static extern short AI_ContBufferSetup(ushort CardNumber, IntPtr Buffer, uint ReadCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ContBufferReset (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ContReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, ushort[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ContReadMultiChannels (ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, ushort[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ContReadChannelToFile (ushort CardNumber, ushort Channel, ushort AdRange, string FileName, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ContReadMultiChannelsToFile (ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, string[] FileName, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ContScanChannels (ushort CardNumber, ushort Channel, ushort AdRange, ushort[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ContScanChannelsToFile (ushort CardNumber, ushort Channel, ushort AdRange, string FileName, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ContStatus (ushort CardNumber, out ushort Status);
    [DllImport("PCI-Dask.dll")]
    //public static extern short AI_ContVScale (ushort CardNumber, ushort adRange, ushort[] readingArray, double[] voltageArray, int count);
    public static extern short AI_ContVScale(ushort CardNumber, ushort adRange, IntPtr readingArray, double[] voltageArray, int count);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_EventCallBack (ushort CardNumber, ushort mode, ushort EventType, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_InitialMemoryAllocated (ushort CardNumber, out uint MemSize);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, out ushort Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ReadChannel32 (ushort CardNumber, ushort Channel, ushort AdRange, out uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ReadMultiChannels (ushort CardNumber, ushort NumChans, ushort[] Chans, ushort[] AdRanges, ushort[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ScanReadChannels (ushort CardNumber, ushort NumChans, ushort AdRanges, ushort[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_ScanReadChannels32 (ushort CardNumber, ushort Channel, ushort AdRange, uint[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_SetTimeOut (ushort CardNumber, uint TimeOut);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_VoltScale (ushort CardNumber, ushort AdRange, ushort reading, out double voltage);
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_VReadChannel (ushort CardNumber, ushort Channel, ushort AdRange, out double voltage);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_6202_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTrgCnt, uint DLY1Cnt, uint DLY2Cnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_6208A_Config (ushort CardNumber, ushort V2AMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_6308A_Config (ushort CardNumber, ushort V2AMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_6308V_Config (ushort CardNumber, ushort Channel, ushort OutputPolarity, double refVoltage);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_9111_Config (ushort CardNumber, ushort OutputPolarity);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_9112_Config (ushort CardNumber, ushort Channel, double refVoltage);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_9222_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTrgCnt, uint DLY1Cnt, uint DLY2Cnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_9223_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTrgCnt, uint DLY1Cnt, uint DLY2Cnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_InitialMemoryAllocated (ushort CardNumber, out uint MemSize);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_AsyncCheck (ushort CardNumber, out bool Stopped, out uint AccessCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_AsyncClear (ushort CardNumber, out uint AccessCnt, ushort stop_mode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_AsyncDblBufferMode (ushort CardNumber, bool Enable);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_AsyncDblBufferHalfReady (ushort CardNumber, out bool bHalfReady);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_ContBufferCompose (ushort CardNumber, ushort TotalChnCount, ushort ChnNum, uint UpdateCount, uint [] ConBuffer, uint [] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_ContBufferReset (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_ContBufferSetup (ushort CardNumber, uint[] Buffer, uint WriteCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_ContStatus (ushort CardNumber, out ushort Status);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_ContWriteChannel (ushort CardNumber, ushort Channel, ushort BufId, uint WriteCount, uint Iterations, uint CHUI, ushort definite, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_ContWriteMultiChannels(ushort CardNumber, ushort NumChans, ushort[] Chans, ushort BufId, uint WriteCount, uint Iterations, uint CHUI, ushort definite, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_EventCallBack (ushort CardNumber, ushort mode, ushort EventType, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_SetTimeOut (ushort CardNumber, uint TimeOut);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_WriteChannel (ushort CardNumber, ushort Channel, short Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_VWriteChannel (ushort CardNumber, ushort Channel, double Voltage);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_VoltScale (ushort CardNumber, ushort Channel, double Voltage, out short binValue);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_SimuWriteChannel (ushort CardNumber, ushort Group, short[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_SimuVWriteChannel (ushort CardNumber, ushort Group, double[] VBuffer);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7200_Config (ushort CardNumber, ushort TrigSource, ushort ExtTrigEn, ushort TrigPol, ushort I_REQ_Pol);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7233_ForceLogic (ushort CardNumber, ushort ConfigCtrl);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7300A_Config (ushort CardNumber, ushort PortWidth, ushort TrigSource, ushort WaitStatus, ushort Terminator, ushort I_REQ_Pol, bool clear_fifo, bool disable_di);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7300B_Config (ushort CardNumber, ushort PortWidth, ushort TrigSource, ushort WaitStatus, ushort Terminator, ushort I_Cntrl_Pol, bool clear_fifo, bool disable_di);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7350_Config (ushort CardNumber, ushort DIPortWidth, ushort DIMode, ushort DIWaitStatus, ushort DIClkConfig);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7350_ExportSampCLKConfig (ushort CardNumber, ushort CLK_Src, ushort CLK_DPAMode, ushort CLK_DPAVlaue);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7350_ExtSampCLKConfig (ushort CardNumber, ushort CLK_Src, ushort CLK_DDAMode, ushort CLK_DPAMode, ushort CLK_DDAVlaue, ushort CLK_DPAVlaue);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7350_SoftTriggerGen (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7350_TrigHSConfig (ushort CardNumber, ushort TrigConfig, ushort DI_IPOL, ushort DI_REQSrc, ushort DI_ACKSrc, ushort DI_TRIGSrc, ushort StartTrigSrc, ushort PauseTrigSrc,  ushort SoftTrigOutSrc, uint SoftTrigOutLength, uint TrigCount);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7350_BurstHandShakeDelay (ushort CardNumber, byte Delay);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7360_Config (ushort CardNumber, ushort DIPortWidth, ushort DIMode, ushort DIWaitStatus, ushort DIClkConfig);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7360_ExportSampCLKConfig (ushort CardNumber, ushort CLK_Src, ushort CLK_DPAMode, ushort CLK_DPAVlaue);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7360_ExtSampCLKConfig (ushort CardNumber, ushort CLK_Src, ushort CLK_DDAMode, ushort CLK_DPAMode, ushort CLK_DDAVlaue, ushort CLK_DPAVlaue);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7360_SoftTriggerGen (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7360_TrigHSConfig (ushort CardNumber, ushort TrigConfig, ushort DI_IPOL, ushort DI_REQSrc, ushort DI_ACKSrc, ushort DI_TRIGSrc, ushort StartTrigSrc, ushort PauseTrigSrc,  ushort SoftTrigOutSrc, uint SoftTrigOutLength, uint TrigCount);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_7360_BurstHandShakeDelay (ushort CardNumber, byte Delay);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_9222_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTriggerCnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_9223_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTriggerCnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_InitialMemoryAllocated (ushort CardNumber, out uint DmaSize);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ReadLine (ushort CardNumber, ushort Port, ushort Line, out ushort State);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ReadPort (ushort CardNumber, ushort Port, out uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContReadPort (ushort CardNumber, ushort Port, byte[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContReadPort (ushort CardNumber, ushort Port, ushort[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContReadPort(ushort CardNumber, ushort Port, uint[] Buffer, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContReadPortToFile (ushort CardNumber, ushort Port, string FileName, uint ReadCount, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContStatus (ushort CardNumber, out ushort Status);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncCheck (ushort CardNumber, out byte Stopped, out uint AccessCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncClear (ushort CardNumber, out uint AccessCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncDblBufferHalfReady (ushort CardNumber, out byte HalfReady);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncDblBufferMode (ushort CardNumber, bool Enable);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncDblBufferTransfer (ushort CardNumber, byte[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncDblBufferTransfer (ushort CardNumber, short[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncDblBufferTransfer(ushort CardNumber, uint[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncDblBufferOverrun (ushort CardNumber, ushort op, out ushort overrunFlag);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncDblBufferHandled (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncDblBufferToFile (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncMultiBuffersHandled (ushort CardNumber, ushort bufcnt, ushort[] bufs);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncMultiBufferNextReady (ushort CardNumber, out byte bNextReady, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_AsyncReTrigNextReady (ushort CardNumber, out bool Ready, out bool StopFlag, out ushort RdyTrigCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContBufferSetup (ushort CardNumber, ushort[] Buffer, uint ReadCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContBufferSetup (ushort CardNumber, uint[] Buffer, uint ReadCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContBufferReset (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContMultiBufferSetup (ushort CardNumber, byte[] Buffer, uint ReadCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContMultiBufferSetup (ushort CardNumber, short[] Buffer, uint ReadCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContMultiBufferSetup(ushort CardNumber, uint[] Buffer, uint ReadCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_ContMultiBufferStart (ushort CardNumber, ushort Port, double fSampleRate);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_EventCallBack (ushort CardNumber, short mode, short EventType, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_SetTimeOut (ushort CardNumber, uint TimeOut);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7200_Config (ushort CardNumber, ushort TrigSource, ushort OutReqEn, ushort OutTrigSig);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7300A_Config (ushort CardNumber, ushort PortWidth, ushort TrigSource, ushort WaitStatus, ushort Terminator, ushort O_REQ_Pol);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7300B_Config (ushort CardNumber, ushort PortWidth, ushort TrigSource, ushort WaitStatus, ushort Terminator, ushort O_Cntrl_Pol, uint FifoThreshold);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7300B_SetDODisableMode (ushort CardNumber, ushort Mode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7350_Config (ushort CardNumber, ushort DOPortWidth, ushort DOMode, ushort DOWaitStatus, ushort DOClkConfig);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7350_ExportSampCLKConfig (ushort CardNumber, ushort CLK_Src, ushort CLK_DPAMode, ushort CLK_DPAVlaue);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7350_ExtSampCLKConfig (ushort CardNumber, ushort CLK_Src, ushort CLK_DDAMode, ushort CLK_DPAMode, ushort CLK_DDAVlaue, ushort CLK_DPAVlaue);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7350_SoftTriggerGen (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7350_TrigHSConfig (ushort CardNumber, ushort TrigConfig, ushort DO_IPOL, ushort DO_REQSrc, ushort DO_ACKSrc, ushort DO_TRIGSrc, ushort StartTrigSrc, ushort PauseTrigSrc,  ushort SoftTrigOutSrc, uint SoftTrigOutLength, uint TrigCount);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7350_BurstHandShakeDelay (ushort CardNumber, byte Delay);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7360_Config (ushort CardNumber, ushort DOPortWidth, ushort DOMode, ushort DOWaitStatus, ushort DOClkConfig);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7360_ExportSampCLKConfig (ushort CardNumber, ushort CLK_Src, ushort CLK_Mode, ushort CLK_DPAMode, ushort CLK_DPAVlaue);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7360_ExtSampCLKConfig (ushort CardNumber, ushort CLK_Src, ushort CLK_DDAMode, ushort CLK_DPAMode, ushort CLK_DDAVlaue, ushort CLK_DPAVlaue);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7360_SoftTriggerGen (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7360_TrigHSConfig (ushort CardNumber, ushort TrigConfig, ushort DO_IPOL, ushort DO_REQSrc, ushort DO_ACKSrc, ushort DO_TRIGSrc, ushort StartTrigSrc, ushort PauseTrigSrc,  ushort SoftTrigOutSrc, uint SoftTrigOutLength, uint TrigCount);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_7360_BurstHandShakeDelay (ushort CardNumber, byte Delay);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_9222_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTrgCnt, uint DLY1Cnt, uint DLY2Cnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_9223_Config (ushort CardNumber, ushort ConfigCtrl, ushort TrigCtrl, uint ReTrgCnt, uint DLY1Cnt, uint DLY2Cnt, bool AutoResetBuf);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_InitialMemoryAllocated (ushort CardNumber, out uint MemSize);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_WriteLine (ushort CardNumber, ushort Port, ushort Line, ushort Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_WritePort (ushort CardNumber, byte Port, uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_WritePort (ushort CardNumber, ushort Port, uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_WritePort(ushort CardNumber, uint Port, uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContWritePortEx (ushort CardNumber, ushort Port, byte[] Buffer, uint WriteCount, ushort Iterations, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContWritePortEx (ushort CardNumber, ushort Port, ushort[] Buffer, uint WriteCount, ushort Iterations, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContWritePortEx (ushort CardNumber, ushort Port, uint[] Buffer, uint WriteCount, ushort Iterations, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_SimuWritePort(ushort CardNumber, ushort NumChans, uint[] Buffer);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_WriteExtTrigLine (ushort CardNumber, ushort Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ReadLine (ushort CardNumber, ushort Port, ushort Line, out ushort Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ReadPort (ushort CardNumber, ushort Port, out uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContWritePort (ushort CardNumber, ushort Port, byte[] Buffer, uint WriteCount, ushort Iterations, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContWritePort (ushort CardNumber, ushort Port, ushort[] Buffer, uint WriteCount, ushort Iterations, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContWritePort (ushort CardNumber, ushort Port, uint[] Buffer, uint WriteCount, ushort Iterations, double SampleRate, ushort SyncMode);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_PGStart (ushort CardNumber, byte[] Buffer, uint WriteCount, double SampleRate);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_PGStart (ushort CardNumber, short[] Buffer, uint WriteCount, double SampleRate);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_PGStart (ushort CardNumber, uint[] Buffer, uint WriteCount, double SampleRate);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_PGStop (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContStatus (ushort CardNumber, out ushort Status);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_AsyncCheck (ushort CardNumber, out byte Stopped, out uint AccessCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_AsyncClear (ushort CardNumber, out uint AccessCnt);
    [DllImport("PCI-Dask.dll")]
    public static extern short EDO_9111_Config (ushort CardNumber, ushort EDO_Fun);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContMultiBufferSetup (ushort CardNumber, byte[] Buffer, uint WriteCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContMultiBufferSetup (ushort CardNumber, short[] Buffer, uint WriteCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContMultiBufferSetup (ushort CardNumber, uint[] Buffer, uint WriteCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_AsyncMultiBufferNextReady (ushort CardNumber, out byte bNextReady, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContMultiBufferStart (ushort CardNumber, ushort Port, double fSampleRate);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_EventCallBack (ushort CardNumber, short mode, short EventType, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_SetTimeOut (ushort CardNumber, uint TimeOut);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContBufferSetup (ushort CardNumber, ushort[] Buffer, uint WriteCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContBufferSetup (ushort CardNumber, uint[] Buffer, uint WriteCount, out ushort BufferId);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_ContBufferReset (ushort CardNumber);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_PortConfig (ushort CardNumber, ushort Port, ushort Direction);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_LinesConfig (ushort CardNumber, ushort Port, ushort Linesdirmap);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_LineConfig (ushort CardNumber, ushort Port, ushort Line, ushort Direction);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_SetDualInterrupt (ushort CardNumber, short Int1Mode, short Int2Mode, uint hEvent);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_SetCOSInterrupt (ushort CardNumber, ushort Port, ushort ctlA, ushort ctlB, ushort ctlC);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_INT1_EventMessage (ushort CardNumber, short Int1Mode, uint windowHandle, uint message, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_INT2_EventMessage (ushort CardNumber, short Int2Mode, uint windowHandle, uint message, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_7300SetInterrupt (ushort CardNumber, short AuxDIEn, short T2En, uint hEvent);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_AUXDI_EventMessage (ushort CardNumber, short AuxDIEn, uint windowHandle, uint message, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_T2_EventMessage (ushort CardNumber, short T2En, uint windowHandle, uint message, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_GetCOSLatchData (ushort CardNumber, out ushort CosLData);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_SetCOSInterrupt32 (ushort CardNumber, byte Port, uint ctl, out uint hEvent, bool ManualReset);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_GetCOSLatchData32 (ushort CardNumber, byte Port, out uint CosLData);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_GetCOSLatchDataInt32 (ushort CardNumber, byte Port, out uint CosLData);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_COSInterruptCounter (ushort CardNumber, ushort Counter_Num, ushort Counter_Mode, ushort DI_Port, ushort DI_Line, out uint Counter_Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_VoltLevelConfig (ushort CardNumber, ushort PortType, ushort VoltLevel);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_7350_AFIConfig (ushort CardNumber, ushort AFI_Port, ushort AFI_Enable, ushort AFI_Mode, uint AFI_TrigOutLen);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_7360_AFIConfig (ushort CardNumber, ushort AFI_Port, ushort AFI_Enable, ushort AFI_Mode, uint AFI_TrigOutLen);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_PMConfig (ushort CardNumber, ushort Channel, ushort PM_ChnEn, ushort PM_ChnType);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_PMControl (ushort CardNumber, ushort Port, ushort PM_Start, out uint hEvent, bool ManualReset);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_SetPMInterrupt32 (ushort CardNumber, ushort Port, uint Ctrl, uint Pattern1, uint Pattern2, out uint hEvent, bool ManualReset);
    [DllImport("PCI-Dask.dll")]
    public static extern short DIO_GetPMLatchData32 (ushort CardNumber, ushort Port, out uint PMLData);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_Setup (ushort CardNumber, ushort Ctr, ushort Mode, uint Count, ushort BinBcd);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_Setup_All (ushort CardNumber, ushort CtrCnt, ushort[] Ctr, ushort[] Mode, uint[] Count, ushort[] BinBcd);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_Clear (ushort CardNumber, ushort Ctr, ushort State);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_Read (ushort CardNumber, ushort Ctr, out uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_Read_All (ushort CardNumber, ushort CtrCnt, ushort[] Ctr, uint[] Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_Status (ushort CardNumber, ushort Ctr, out uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_Update (ushort CardNumber, ushort Ctr, uint Count);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_8554_ClkSrc_Config (ushort CardNumber, ushort Ctr, ushort ClockSource);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_8554_CK1_Config (ushort CardNumber, ushort ClockSource);
    [DllImport("PCI-Dask.dll")]
    public static extern short CTR_8554_Debounce_Config (ushort CardNumber, ushort DebounceClock);
    [DllImport("PCI-Dask.dll")]
    public static extern short GCTR_Setup (ushort CardNumber, ushort GCtr, ushort GCtrCtrl, uint Count);
    [DllImport("PCI-Dask.dll")]
    public static extern short GCTR_Clear (ushort CardNumber, ushort GCtr);
    [DllImport("PCI-Dask.dll")]
    public static extern short GCTR_Read (ushort CardNumber, ushort GCtr, out uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_Clear (ushort CardNumber, ushort GCtr);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_Control (ushort CardNumber, ushort GCtr, ushort ParamID, ushort Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_EventCallBack (ushort CardNumber, ushort Enabled, ushort EventType, MulticastDelegate callbackAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_EventSetup (ushort CardNumber, ushort GCtr, ushort Mode, ushort Ctrl, uint LVal_1, uint LVal_2);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_Read (ushort CardNumber, ushort GCtr, out uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_Setup (ushort CardNumber, ushort GCtr, ushort Mode, ushort SrcCtrl, ushort PolCtrl, uint LReg1_Val, uint LReg2_Val);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_Status(ushort CardNumber, ushort GCtr, out ushort Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_9524_PG_Config (ushort CardNumber, ushort GCtr, uint PulseGenNum);
    [DllImport("PCI-Dask.dll")]
    public static extern short GPTC_9524_GetTimerEvent (ushort CardNumber, ushort GCtr, out uint hEvent);
    [DllImport("PCI-Dask.dll")]
    public static extern short WDT_Setup (ushort CardNumber, ushort Ctr, float ovflowSec, out float actualSec, out uint hEvent);
    [DllImport("PCI-Dask.dll")]
    public static extern short WDT_Control (ushort CardNumber, ushort Ctr, ushort action);
    [DllImport("PCI-Dask.dll")]
    public static extern short WDT_Status (ushort CardNumber, ushort Ctr, out uint Value);
    [DllImport("PCI-Dask.dll")]
    public static extern short WDT_Reload (ushort CardNumber, float ovflowSec, out float actualSec);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_GetEvent (ushort CardNumber, out uint hEvent);
    [DllImport("PCI-Dask.dll")]
    public static extern short AO_GetEvent (ushort CardNumber, out uint hEvent);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_GetEvent (ushort CardNumber, out uint hEvent);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_GetEvent (ushort CardNumber, out uint hEvent);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short AI_GetView (ushort CardNumber, uint[] View);
    [DllImport("PCI-Dask.dll")]
    public static extern short DI_GetView (ushort CardNumber, uint[] View);
    [DllImport("PCI-Dask.dll")]
    public static extern short DO_GetView (ushort CardNumber, uint[] View);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short GetCardType (ushort CardNumber, out ushort cardType);
    [DllImport("PCI-Dask.dll")]
    public static extern short GetCardIndexFromID (ushort CardNumber, out ushort cardType, out ushort cardIndex);
    [DllImport("PCI-Dask.dll")]
    public static extern short GetBaseAddr (ushort CardNumber, uint[] BaseAddr, uint[] BaseAddr2);
    [DllImport("PCI-Dask.dll")]
    public static extern short GetLCRAddr (ushort CardNumber, uint[] LcrAddr);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI_EEPROM_LoadData (ushort CardNumber, ushort block, out ushort data);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI_EEPROM_SaveData (ushort CardNumber, ushort block, ushort data);
/*---------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI_DB_Auto_Calibration_ALL (ushort CardNumber);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI_Load_CAL_Data (ushort CardNumber, ushort bank);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI_EEPROM_CAL_Constant_Update (ushort CardNumber, ushort bank);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI9524_Acquire_AD_CalConst (ushort CardNumber, ushort Group, ushort ADC_Range, ushort ADC_Speed, out uint CalDate, out float CalTemp, out uint ADC_offset, out uint ADC_gain, out double Residual_offset, out double Residual_scaling);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI9524_Acquire_DA_CalConst (ushort CardNumber, ushort Channel, out uint CalDate, out float CalTemp, out byte DAC_offset, out byte DAC_linearity, out float Gain_factor);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI9524_Read_EEProm (ushort CardNumber, ushort ReadAddr, byte[] ReadData);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI9524_Read_RemoteSPI (ushort CardNumber, ushort Addr, byte[] RdData);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI9524_Write_EEProm (ushort CardNumber, ushort WriteAddr, byte[] WriteData);
    [DllImport("PCI-Dask.dll")]
    public static extern short PCI9524_Write_RemoteSPI (ushort CardNumber, ushort Addr, byte WrtData);

/*----------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short SSI_SourceConn (ushort CardNumber, ushort sigCode);
    [DllImport("PCI-Dask.dll")]
    public static extern short SSI_SourceDisConn (ushort CardNumber, ushort sigCode);
    [DllImport("PCI-Dask.dll")]
    public static extern short SSI_SourceClear (ushort CardNumber);
/*----------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short PWM_Output (ushort CardNumber, ushort Channel, uint high_interval, uint low_interval);
    [DllImport("PCI-Dask.dll")]
    public static extern short PWM_Stop (ushort CardNumber, ushort Channel);
/*----------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short I2C_Setup (ushort CardNumber, ushort I2C_Port, ushort I2C_Config, uint I2C_SetupValue1, uint I2C_SetupValue2);
    [DllImport("PCI-Dask.dll")]
    public static extern short I2C_Control (ushort CardNumber, ushort I2C_Port, ushort I2C_CtrlParam, uint I2C_CtrlValue);
    [DllImport("PCI-Dask.dll")]
    public static extern short I2C_Status (ushort CardNumber, ushort I2C_Port, out uint I2C_Status);
    [DllImport("PCI-Dask.dll")]
    public static extern short I2C_Read (ushort CardNumber, ushort I2C_Port, ushort I2C_SlaveAddr, ushort I2C_CmdAddrBytes, ushort I2C_DataBytes, uint I2C_CmdAddr, out uint I2C_Data);
    [DllImport("PCI-Dask.dll")]
    public static extern short I2C_Write (ushort CardNumber, ushort I2C_Port, ushort I2C_SlaveAddr, ushort I2C_CmdAddrBytes, ushort I2C_DataBytes, uint I2C_CmdAddr, uint I2C_Data);
/*----------------------------------------------------------------------------*/
    [DllImport("PCI-Dask.dll")]
    public static extern short SPI_Setup (ushort CardNumber, ushort SPI_Port, ushort SPI_Config, uint SPI_SetupValue1, uint SPI_SetupValue2);
    [DllImport("PCI-Dask.dll")]
    public static extern short SPI_Control (ushort CardNumber, ushort SPI_Port, ushort SPI_CtrlParam, uint SPI_CtrlValue);
    [DllImport("PCI-Dask.dll")]
    public static extern short SPI_Status (ushort CardNumber, ushort SPI_Port, out uint SPI_Status);
    [DllImport("PCI-Dask.dll")]
    public static extern short SPI_Read (ushort CardNumber, ushort SPI_Port, ushort SPI_SlaveAddr, ushort SPI_CmdAddrBits, ushort SPI_DataBits, ushort SPI_FrontDummyBits, uint SPI_CmdAddr, out uint SPI_Data);
    [DllImport("PCI-Dask.dll")]
    public static extern short SPI_Write (ushort CardNumber, ushort SPI_Port, ushort SPI_SlaveAddr, ushort SPI_CmdAddrBits, ushort SPI_DataBits, ushort SPI_FrontDummyBits, ushort SPI_TailDummyBits, uint SPI_CmdAddr, uint SPI_Data);
/*----------------------------------------------------------------------------*/
}
