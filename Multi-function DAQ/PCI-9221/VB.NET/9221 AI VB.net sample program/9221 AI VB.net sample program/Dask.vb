Option Strict Off
Option Explicit On
Module DASK

    'ADLink PCI Card Type
    Public Const PCI_6208V As Short = 1
    Public Const PCI_6208A As Short = 2
    Public Const PCI_6308V As Short = 3
    Public Const PCI_6308A As Short = 4
    Public Const PCI_7200 As Short = 5
    Public Const PCI_7230 As Short = 6
    Public Const PCI_7233 As Short = 7
    Public Const PCI_7234 As Short = 8
    Public Const PCI_7248 As Short = 9
    Public Const PCI_7249 As Short = 10
    Public Const PCI_7250 As Short = 11
    Public Const PCI_7252 As Short = 12
    Public Const PCI_7296 As Short = 13
    Public Const PCI_7300A_RevA As Short = 14
    Public Const PCI_7300A_RevB As Short = 15
    Public Const PCI_7432 As Short = 16
    Public Const PCI_7433 As Short = 17
    Public Const PCI_7434 As Short = 18
    Public Const PCI_8554 As Short = 19
    Public Const PCI_9111DG As Short = 20
    Public Const PCI_9111HR As Short = 21
    Public Const PCI_9112 As Short = 22
    Public Const PCI_9113 As Short = 23
    Public Const PCI_9114DG As Short = 24
    Public Const PCI_9114HG As Short = 25
    Public Const PCI_9118DG As Short = 26
    Public Const PCI_9118HG As Short = 27
    Public Const PCI_9118HR As Short = 28
    Public Const PCI_9810 As Short = 29
    Public Const PCI_9812 As Short = 30
    Public Const PCI_7396 As Short = 31
    Public Const PCI_9116 As Short = 32
    Public Const PCI_7256 As Short = 33
    Public Const PCI_7258 As Short = 34
    Public Const PCI_7260 As Short = 35
    Public Const PCI_7452 As Short = 36
    Public Const PCI_7442 As Short = 37
    Public Const PCI_7443 As Short = 38
    Public Const PCI_7444 As Short = 39
    Public Const PCI_9221 As Short = 40
    Public Const PCI_9524 As Short = 41
    Public Const PCI_6202 As Short = 42
    Public Const PCI_9222 As Short = 43
    Public Const PCI_9223 As Short = 44
    Public Const PCI_7433C As Short = 45
    Public Const PCI_7434C As Short = 46
    Public Const PCI_922A As Short = 47
    Public Const PCI_7350 As Short = 48

    Public Const MAX_CARD As Short = 32

    'Error Code
    Public Const NoError As Short = 0
    Public Const ErrorUnknownCardType As Short = -1
    Public Const ErrorInvalidCardNumber As Short = -2
    Public Const ErrorTooManyCardRegistered As Short = -3
    Public Const ErrorCardNotRegistered As Short = -4
    Public Const ErrorFuncNotSupport As Short = -5
    Public Const ErrorInvalidIoChannel As Short = -6
    Public Const ErrorInvalidAdRange As Short = -7
    Public Const ErrorContIoNotAllowed As Short = -8
    Public Const ErrorDiffRangeNotSupport As Short = -9
    Public Const ErrorLastChannelNotZero As Short = -10
    Public Const ErrorChannelNotDescending As Short = -11
    Public Const ErrorChannelNotAscending As Short = -12
    Public Const ErrorOpenDriverFailed As Short = -13
    Public Const ErrorOpenEventFailed As Short = -14
    Public Const ErrorTransferCountTooLarge As Short = -15
    Public Const ErrorNotDoubleBufferMode As Short = -16
    Public Const ErrorInvalidSampleRate As Short = -17
    Public Const ErrorInvalidCounterMode As Short = -18
    Public Const ErrorInvalidCounter As Short = -19
    Public Const ErrorInvalidCounterState As Short = -20
    Public Const ErrorInvalidBinBcdParam As Short = -21
    Public Const ErrorBadCardType As Short = -22
    Public Const ErrorInvalidDaRange As Short = -23
    Public Const ErrorAdTimeOut As Short = -24
    Public Const ErrorNoAsyncAI As Short = -25
    Public Const ErrorNoAsyncAO As Short = -26
    Public Const ErrorNoAsyncDI As Short = -27
    Public Const ErrorNoAsyncDO As Short = -28
    Public Const ErrorNotInputPort As Short = -29
    Public Const ErrorNotOutputPort As Short = -30
    Public Const ErrorInvalidDioPort As Short = -31
    Public Const ErrorInvalidDioLine As Short = -32
    Public Const ErrorContIoActive As Short = -33
    Public Const ErrorDblBufModeNotAllowed As Short = -34
    Public Const ErrorConfigFailed As Short = -35
    Public Const ErrorInvalidPortDirection As Short = -36
    Public Const ErrorBeginThreadError As Short = -37
    Public Const ErrorInvalidPortWidth As Short = -38
    Public Const ErrorInvalidCtrSource As Short = -39
    Public Const ErrorOpenFile As Short = -40
    Public Const ErrorAllocateMemory As Short = -41
    Public Const ErrorDaVoltageOutOfRange As Short = -42
    Public Const ErrorDaExtRefNotAllowed As Short = -43
    Public Const ErrorDIODataWidthError As Short = -44
    Public Const ErrorTaskCodeError As Short = -45
    Public Const ErrortriggercountError As Short = -46
    Public Const ErrorInvalidTriggerMode As Short = -47
    Public Const ErrorInvalidTriggerType As Short = -48
    Public Const ErrorInvalidCounterValue As Short = -50
    Public Const ErrorInvalidEventHandle As Short = -60
    Public Const ErrorNoMessageAvailable As Short = -61
    Public Const ErrorEventMessgaeNotAdded As Short = -62
    Public Const ErrorCalibrationTimeOut = -63
    Public Const ErrorUndefinedParameter = -64
    Public Const ErrorInvalidBufferID = -65
    Public Const ErrorInvalidSampledClock = -66
    Public Const ErrorInvalisOperationMode = -67

    'Error code for driver API
    Public Const ErrorConfigIoctl As Short = -201
    Public Const ErrorAsyncSetIoctl As Short = -202
    Public Const ErrorDBSetIoctl As Short = -203
    Public Const ErrorDBHalfReadyIoctl As Short = -204
    Public Const ErrorContOPIoctl As Short = -205
    Public Const ErrorContStatusIoctl As Short = -206
    Public Const ErrorPIOIoctl As Short = -207
    Public Const ErrorDIntSetIoctl As Short = -208
    Public Const ErrorWaitEvtIoctl As Short = -209
    Public Const ErrorOpenEvtIoctl As Short = -210
    Public Const ErrorCOSIntSetIoctl As Short = -211
    Public Const ErrorMemMapIoctl As Short = -212
    Public Const ErrorMemUMapSetIoctl As Short = -213
    Public Const ErrorCTRIoctl As Short = -214
    Public Const ErrorGetResIoctl As Short = -215
    Public Const ErrorCalIoctl = -216
    Public Const ErrorPMIntSetIoctl = -217

    'AD Range
    Public Const AD_B_10_V As Short = 1
    Public Const AD_B_5_V As Short = 2
    Public Const AD_B_2_5_V As Short = 3
    Public Const AD_B_1_25_V As Short = 4
    Public Const AD_B_0_625_V As Short = 5
    Public Const AD_B_0_3125_V As Short = 6
    Public Const AD_B_0_5_V As Short = 7
    Public Const AD_B_0_05_V As Short = 8
    Public Const AD_B_0_005_V As Short = 9
    Public Const AD_B_1_V As Short = 10
    Public Const AD_B_0_1_V As Short = 11
    Public Const AD_B_0_01_V As Short = 12
    Public Const AD_B_0_001_V As Short = 13
    Public Const AD_U_20_V As Short = 14
    Public Const AD_U_10_V As Short = 15
    Public Const AD_U_5_V As Short = 16
    Public Const AD_U_2_5_V As Short = 17
    Public Const AD_U_1_25_V As Short = 18
    Public Const AD_U_1_V As Short = 19
    Public Const AD_U_0_1_V As Short = 20
    Public Const AD_U_0_01_V As Short = 21
    Public Const AD_U_0_001_V As Short = 22
    Public Const AD_B_2_V As Short = 23
    Public Const AD_B_0_25_V As Short = 24
    Public Const AD_B_0_2_V As Short = 25
    Public Const AD_U_4_V As Short = 26
    Public Const AD_U_2_V As Short = 27
    Public Const AD_U_0_5_V As Short = 28
    Public Const AD_U_0_4_V As Short = 29

    'Synchronous Mode
    Public Const SYNCH_OP As Short = 1
    Public Const ASYNCH_OP As Short = 2

    'AO Terminate Mode
    Public Const DA_TerminateImmediate = 0

    'Trigger Source
    Public Const TRIG_SOFTWARE As Short = 0
    Public Const TRIG_INT_PACER As Short = 1
    Public Const TRIG_EXT_STROBE As Short = 2
    Public Const TRIG_HANDSHAKE As Short = 3
    Public Const TRIG_CLK_10MHZ As Short = 4 'PCI-7300A
    Public Const TRIG_CLK_20MHZ As Short = 5 'PCI-7300A
    Public Const TRIG_DO_CLK_TIMER_ACK As Short = 6 'PCI-7300A Rev. B
    Public Const TRIG_DO_CLK_10M_ACK As Short = 7 'PCI-7300A Rev. B
    Public Const TRIG_DO_CLK_20M_ACK As Short = 8 'PCI-7300A Rev. B

    'Virtual sampling rate for using external clock as the clock source
    Public Const CLKSRC_EXT_SampRate As Short = 10000

    '--------- Constants for PCI-6208A --------------
    'Output Mode
    Public Const P6208_CURRENT_0_20MA As Short = 0
    Public Const P6208_CURRENT_5_25MA As Short = 1
    Public Const P6208_CURRENT_4_20MA As Short = 3

    '--------- Constants for PCI-6308A/PCI-6308V --------------
    'Output Mode
    Public Const P6308_CURRENT_0_20MA As Short = 0
    Public Const P6308_CURRENT_5_25MA As Short = 1
    Public Const P6308_CURRENT_4_20MA As Short = 3
    'AO Setting
    Public Const P6308V_AO_CH0_3 As Short = 0
    Public Const P6308V_AO_CH4_7 As Short = 1
    Public Const P6308V_AO_UNIPOLAR As Short = 0
    Public Const P6308V_AO_BIPOLAR As Short = 1

    '--------- Constants for PCI-7200 --------------
    'InputMode
    Public Const DI_WAITING As Short = &H2S
    Public Const DI_NOWAITING As Short = &H0S

    Public Const DI_TRIG_RISING As Short = &H4S
    Public Const DI_TRIG_FALLING As Short = &H0S

    Public Const IREQ_RISING As Short = &H8S
    Public Const IREQ_FALLING As Short = &H0S

    'Output Mode
    Public Const OREQ_ENABLE As Short = &H10S
    Public Const OREQ_DISABLE As Short = &H0S

    Public Const OTRIG_HIGH As Short = &H20S
    Public Const OTRIG_LOW As Short = &H0S

    '--------- Constants for PCI-7248/7296/7442 --------------
    'DIO Port Direction
    Public Const INPUT_PORT As Short = 1
    Public Const OUTPUT_PORT As Short = 2
    'DIO Line Direction
    Public Const INPUT_LINE As Short = 1
    Public Const OUTPUT_LINE As Short = 2

    'Channel&Port
    Public Const Channel_P1A As Short = 0
    Public Const Channel_P1B As Short = 1
    Public Const Channel_P1C As Short = 2
    Public Const Channel_P1CL As Short = 3
    Public Const Channel_P1CH As Short = 4
    Public Const Channel_P1AE As Short = 10
    Public Const Channel_P1BE As Short = 11
    Public Const Channel_P1CE As Short = 12
    Public Const Channel_P2A As Short = 5
    Public Const Channel_P2B As Short = 6
    Public Const Channel_P2C As Short = 7
    Public Const Channel_P2CL As Short = 8
    Public Const Channel_P2CH As Short = 9
    Public Const Channel_P2AE As Short = 15
    Public Const Channel_P2BE As Short = 16
    Public Const Channel_P2CE As Short = 17
    Public Const Channel_P3A As Short = 10
    Public Const Channel_P3B As Short = 11
    Public Const Channel_P3C As Short = 12
    Public Const Channel_P3CL As Short = 13
    Public Const Channel_P3CH As Short = 14
    Public Const Channel_P4A As Short = 15
    Public Const Channel_P4B As Short = 16
    Public Const Channel_P4C As Short = 17
    Public Const Channel_P4CL As Short = 18
    Public Const Channel_P4CH As Short = 19
    Public Const Channel_P5A As Short = 20
    Public Const Channel_P5B As Short = 21
    Public Const Channel_P5C As Short = 22
    Public Const Channel_P5CL As Short = 23
    Public Const Channel_P5CH As Short = 24
    Public Const Channel_P6A As Short = 25
    Public Const Channel_P6B As Short = 26
    Public Const Channel_P6C As Short = 27
    Public Const Channel_P6CL As Short = 28
    Public Const Channel_P6CH As Short = 29
    Public Const Channel_P1 As Short = 30
    Public Const Channel_P2 As Short = 31
    Public Const Channel_P3 As Short = 32
    Public Const Channel_P4 As Short = 33
    Public Const Channel_P1E As Short = 34
    Public Const Channel_P2E As Short = 35
    Public Const Channel_P3E As Short = 36
    Public Const Channel_P4E As Short = 37
    ' 7442
    Public Const P7442_CH0 As Short = 0
    Public Const P7442_CH1 As Short = 1
    Public Const P7442_TTL0 As Short = 2
    Public Const P7442_TTL1 As Short = 3
    ' P7443
    Public Const P7443_CH0 = 0
    Public Const P7443_CH1 = 1
    Public Const P7443_CH2 = 2
    Public Const P7443_CH3 = 3
    Public Const P7443_TTL0 = 4
    Public Const P7443_TTL1 = 5
    ' P7444
    Public Const P7444_CH0 = 0
    Public Const P7444_CH1 = 1
    Public Const P7444_CH2 = 2
    Public Const P7444_CH3 = 3
    Public Const P7444_TTL0 = 4
    Public Const P7444_TTL1 = 5
    '--------- Constants for PCI-7300A --------------
    'Wait Status
    Public Const P7300_WAIT_NO As Short = 0
    Public Const P7300_WAIT_TRG As Short = 1
    Public Const P7300_WAIT_FIFO As Short = 2
    Public Const P7300_WAIT_BOTH As Short = 3

    'Terminator control
    Public Const P7300_TERM_OFF As Short = 0
    Public Const P7300_TERM_ON As Short = 1

    'DI control signals polarity for PCI-7300A Rev. B
    Public Const P7300_DIREQ_POS As Short = &H0S
    Public Const P7300_DIREQ_NEG As Short = &H1S
    Public Const P7300_DIACK_POS As Short = &H0S
    Public Const P7300_DIACK_NEG As Short = &H2S
    Public Const P7300_DITRIG_POS As Short = &H0S
    Public Const P7300_DITRIG_NEG As Short = &H4S

    'DO control signals polarity for PCI-7300A Rev. B
    Public Const P7300_DOREQ_POS As Short = &H0S
    Public Const P7300_DOREQ_NEG As Short = &H8S
    Public Const P7300_DOACK_POS As Short = &H0S
    Public Const P7300_DOACK_NEG As Short = &H10S
    Public Const P7300_DOTRIG_POS As Short = &H0S
    Public Const P7300_DOTRIG_NEG As Short = &H20S

    'DO Disable mode in DO_AsyncClear
    Public Const P7300_DODisableDOEnabled As Short = 0
    Public Const P7300_DONotDisableDOEnabled As Short = 1

    '--------- Constants for PCI-7432/7433/7434/7433C/7434C --------------
    Public Const CHANNEL_DI_LOW As Short = 0
    Public Const CHANNEL_DI_HIGH As Short = 1
    Public Const CHANNEL_DO_LOW As Short = 0
    Public Const CHANNEL_DO_HIGH As Short = 1
    Public Const P7432R_DO_LED As Short = 1
    Public Const P7433R_DO_LED As Short = 0
    Public Const P7434R_DO_LED As Short = 2
    Public Const P7432R_DI_SLOT As Short = 1
    Public Const P7433R_DI_SLOT As Short = 2
    Public Const P7434R_DI_SLOT As Short = 0

    '----- Dual-Interrupt Source control for PCI-7248/49/96 & 7230 & 8554 & 7396 &7256/58 & 7260 & 7433C -----
    Public Const INT1_NC As Short = -2 'INT1 Unchanged
    Public Const INT1_DISABLE As Short = -1 'INT1 Disabled
    Public Const INT1_COS As Short = 0 'INT1 COS : only available for PCI-7396, PCI-7256/58 & PCI-7260
    Public Const INT1_FP1C0 As Short = 1 'INT1 by Falling edge of P1C0
    Public Const INT1_RP1C0_FP1C3 As Short = 2 'INT1 by P1C0 Rising or P1C3 Falling
    Public Const INT1_EVENT_COUNTER As Short = 3 'INT1 by Event Counter down to zero
    Public Const INT1_EXT_SIGNAL As Short = 1 'INT1 by external signal : only available for PCI7432/PCI7433/PCI7230
    Public Const INT1_COUT12 As Short = 1 'INT1 COUT12 : only available for PCI8554
    Public Const INT1_CH0 As Short = 1 'INT1 CH0 : only available for PCI7256/58/60
    Public Const INT1_COS0 As Short = 1 'INT1 COS0 : only available for PCI-7452/PCI-7443
    Public Const INT1_COS1 As Short = 2 'INT1 COS1 : only available for PCI-7452/PCI-7443
    Public Const INT1_COS2 As Short = 3 'INT1 COS2 : only available for PCI-7452/PCI-7443
    Public Const INT1_COS3 As Short = 8 'INT1 COS3 : only available for PCI-7452/PCI-7443
    Public Const INT2_NC As Short = -2 'INT2 Unchanged
    Public Const INT2_DISABLE As Short = -1 'INT2 Disabled
    Public Const INT2_COS As Short = 0 'INT2 COS : only available for PCI-7396
    Public Const INT2_FP2C0 As Short = 1 'INT2 by Falling edge of P2C0
    Public Const INT2_RP2C0_FP2C3 As Short = 2 'INT2 by P2C0 Rising or P2C3 Falling
    Public Const INT2_TIMER_COUNTER As Short = 3 'INT2 by Timer Counter down to zero
    Public Const INT2_EXT_SIGNAL As Short = 1 'INT2 by external signal : only available for PCI7432/PCI7433/PCI7230
    Public Const INT2_CH1 As Short = 2 'INT2 CH1 : only available for PCI7256/58/60
    Public Const INT2_WDT As Short = 4 'INT2 by WDT

    Public Const WDT_OVRFLOW_SAFETYOUT As Short = &H8000S 'enable safteyout while WDT overflow
    '-------- Constants for PCI-8554 --------------------
    'Clock Source of Cunter N
    Public Const ECKN As Short = 0
    Public Const COUTN_1 As Short = 1
    Public Const CK1 As Short = 2
    Public Const COUT10 As Short = 3

    'Clock Source of CK1
    Public Const CK1_C8M As Short = 0
    Public Const CK1_COUT11 As Short = 1

    'Debounce Clock
    Public Const DBCLK_COUT11 As Short = 0
    Public Const DBCLK_2MHZ As Short = 1

    '--------- Constants for PCI-9111 --------------
    'Dual Interrupt Mode
    Public Const P9111_INT1_EOC As Short = 0 'Ending of AD conversion
    Public Const P9111_INT1_FIFO_HF As Short = 1 'FIFO Half Full
    Public Const P9111_INT2_PACER As Short = 0 'Every Timer tick
    Public Const P9111_INT2_EXT_TRG As Short = 1 'ExtTrig High->Low

    'Channel Count
    Public Const P9111_CHANNEL_DO As Short = 0
    Public Const P9111_CHANNEL_EDO As Short = 1
    Public Const P9111_CHANNEL_DI As Short = 0
    Public Const P9111_CHANNEL_EDI As Short = 1

    'Trigger Mode
    Public Const P9111_TRGMOD_SOFT As Short = 0 'Software Trigger Mode
    Public Const P9111_TRGMOD_PRE As Short = 1 'Pre-Trigger Mode
    Public Const P9111_TRGMOD_POST As Short = 2 'Post Trigger Mode

    'EDO function
    Public Const P9111_EDO_INPUT As Short = 1 'EDO port set as Input port
    Public Const P9111_EDO_OUT_EDO As Short = 2 'EDO port set as Output port
    Public Const P9111_EDO_OUT_CHN As Short = 3 'EDO port set as channel number ouput port

    'AO Setting
    Public Const P9111_AO_UNIPOLAR As Short = 0
    Public Const P9111_AO_BIPOLAR As Short = 1

    '--------- Constants for PCI-9118 --------------
    Public Const P9118_AI_BiPolar As Short = &H0S
    Public Const P9118_AI_UniPolar As Short = &H1S

    Public Const P9118_AI_SingEnded As Short = &H0S
    Public Const P9118_AI_Differential As Short = &H2S

    Public Const P9118_AI_ExtG As Short = &H4S

    Public Const P9118_AI_ExtTrig As Short = &H8S

    Public Const P9118_AI_DtrgNegative As Short = &H0S
    Public Const P9118_AI_DtrgPositive As Short = &H10S

    Public Const P9118_AI_EtrgNegative As Short = &H0S
    Public Const P9118_AI_EtrgPositive As Short = &H20S

    Public Const P9118_AI_BurstModeEn As Short = &H40S
    Public Const P9118_AI_SampleHold As Short = &H80S
    Public Const P9118_AI_PostTrgEn As Short = &H100S
    Public Const P9118_AI_AboutTrgEn As Short = &H200S

    '--------- Constants for PCI-9812/9810 --------------
    'Channel Count
    Public Const P9116_AI_LocalGND As Short = &H0S
    Public Const P9116_AI_UserCMMD As Short = &H1S
    Public Const P9116_AI_SingEnded As Short = &H0S
    Public Const P9116_AI_Differential As Short = &H2S
    Public Const P9116_AI_BiPolar As Short = &H0S
    Public Const P9116_AI_UniPolar As Short = &H4S

    Public Const P9116_TRGMOD_SOFT As Short = &H0S 'Software Trigger Mode
    Public Const P9116_TRGMOD_POST As Short = &H10S 'Post Trigger Mode
    Public Const P9116_TRGMOD_DELAY As Short = &H20S 'Delay Trigger Mode
    Public Const P9116_TRGMOD_PRE As Short = &H30S 'Pre-Trigger Mode
    Public Const P9116_TRGMOD_MIDL As Short = &H40S 'Middle Trigger Mode
    Public Const P9116_AI_TrgPositive As Short = &H0S
    Public Const P9116_AI_TrgNegative As Short = &H80S
    Public Const P9116_AI_IntTimeBase As Short = &H0S
    Public Const P9116_AI_ExtTimeBase As Short = &H100S
    Public Const P9116_AI_DlyInSamples As Short = &H200S
    Public Const P9116_AI_DlyInTimebase As Short = &H0S
    Public Const P9116_AI_ReTrigEn As Short = &H400S
    Public Const P9116_AI_MCounterEn As Short = &H800S
    Public Const P9116_AI_SoftPolling As Short = &H0S
    Public Const P9116_AI_INT As Short = &H1000S
    Public Const P9116_AI_DMA As Short = &H2000S

    '--------- Constants for PCI-9812/9810 --------------
    'Channel Count
    Public Const P9812_CHANNEL_CNT1 As Short = 1
    Public Const P9812_CHANNEL_CNT2 As Short = 2
    Public Const P9812_CHANNEL_CNT4 As Short = 4

    'Trigger Mode
    Public Const P9812_TRGMOD_SOFT As Short = 0 'Software Trigger Mode
    Public Const P9812_TRGMOD_POST As Short = 1 'Post Trigger Mode
    Public Const P9812_TRGMOD_PRE As Short = 2 'Pre-Trigger Mode
    Public Const P9812_TRGMOD_DELAY As Short = 3 'Delay Trigger Mode
    Public Const P9812_TRGMOD_MIDL As Short = 4 'Middle Trigger Mode

    'Trigger Source
    Public Const P9812_TRGSRC_CH0 As Short = &H0S 'trigger source --CH0
    Public Const P9812_TRGSRC_CH1 As Short = &H8S 'trigger source --CH1
    Public Const P9812_TRGSRC_CH2 As Short = &H10S 'trigger source --CH2
    Public Const P9812_TRGSRC_CH3 As Short = &H18S 'trigger source --CH3
    Public Const P9812_TRGSRC_EXT_DIG As Short = &H20S 'External Digital Trigger

    'Trigger Polarity
    Public Const P9812_TRGSLP_POS As Short = &H0S 'Positive slope trigger
    Public Const P9812_TRGSLP_NEG As Short = &H40S 'Negative slope trigger

    'Frequency Selection
    Public Const P9812_AD2_GT_PCI As Short = &H80S 'Freq. of A/D clock > PCI clock freq.
    Public Const P9812_AD2_LT_PCI As Short = &H0S 'Freq. of A/D clock < PCI clock freq.

    'Clock Source
    Public Const P9812_CLKSRC_INT As Short = &H0S 'Internal clock
    Public Const P9812_CLKSRC_EXT_SIN As Short = &H100S 'External SIN wave clock
    Public Const P9812_CLKSRC_EXT_DIG As Short = &H200S 'External Square wave clock

    '-------- Constants for PCI-9221 --------------------
    'Input Type
    Public Const P9221_AI_SingEnded As Short = &H0S
    Public Const P9221_AI_NonRef_SingEnded As Short = &H1S
    Public Const P9221_AI_Differential As Short = &H2S

    'Trigger Mode
    Public Const P9221_TRGMOD_SOFT As Short = &H0S
    Public Const P9221_TRGMOD_ExtD As Short = &H8S
    'Trigger Source
    Public Const P9221_TRGSRC_GPI0 As Short = &H0S
    Public Const P9221_TRGSRC_GPI1 As Short = &H1S
    Public Const P9221_TRGSRC_GPI2 As Short = &H2S
    Public Const P9221_TRGSRC_GPI3 As Short = &H3S
    Public Const P9221_TRGSRC_GPI4 As Short = &H4S
    Public Const P9221_TRGSRC_GPI5 As Short = &H5S
    Public Const P9221_TRGSRC_GPI6 As Short = &H6S
    Public Const P9221_TRGSRC_GPI7 As Short = &H7S

    'Trigger Polarity
    Public Const P9221_AI_TrgPositive As Short = &H00S
    Public Const P9221_AI_TrgNegative As Short = &H10S

    'TimeBase Mode
    Public Const P9221_AI_IntTimeBase As Short = &H0S
    Public Const P9221_AI_ExtTimeBase As Short = &H80S

    'TimeBase Source
    Public Const P9221_TimeBaseSRC_GPI0 As Short = &H0S
    Public Const P9221_TimeBaseSRC_GPI1 As Short = &H10S
    Public Const P9221_TimeBaseSRC_GPI2 As Short = &H20S
    Public Const P9221_TimeBaseSRC_GPI3 As Short = &H30S
    Public Const P9221_TimeBaseSRC_GPI4 As Short = &H40S
    Public Const P9221_TimeBaseSRC_GPI5 As Short = &H50S
    Public Const P9221_TimeBaseSRC_GPI6 As Short = &H60S
    Public Const P9221_TimeBaseSRC_GPI7 As Short = &H70S

    'DAQ Event type for the event message
    Public Const AIEnd As Short = 0
    Public Const A0End As Short = 0
    Public Const DIEnd As Short = 0
    Public Const DOEnd As Short = 0
    Public Const DBEvent As Short = 1
    Public Const TrigEvent As Short = 2

    'EMG shdn ctrl code
    Public Const EMGSHDN_OFF As Short = 0 'off
    Public Const EMGSHDN_ON As Short = 1 'on
    Public Const EMGSHDN_RECOVERY As Short = 2 'recovery

    'Hot Reset Hold ctrl code
    Public Const HRH_OFF As Short = 0 'off
    Public Const HRH_ON As Short = 1 'on

    'COS Counter OP
    Public Const COS_COUNTER_RESET As Short = 0
    Public Const COS_COUNTER_SETUP As Short = 1
    Public Const COS_COUNTER_START As Short = 2
    Public Const COS_COUNTER_STOP As Short = 3
    Public Const COS_COUNTER_READ As Short = 4

    '--------- Constants for Timer/Counter --------------
    'Counter Mode (8254)
    Public Const TOGGLE_OUTPUT As Short = 0 'Toggle output from low to high on terminal count
    Public Const PROG_ONE_SHOT As Short = 1 'Programmable one-shot
    Public Const RATE_GENERATOR As Short = 2 'Rate generator
    Public Const SQ_WAVE_RATE_GENERATOR As Short = 3 'Square wave rate generator
    Public Const SOFT_TRIG As Short = 4 'Software-triggered strobe
    Public Const HARD_TRIG As Short = 5 'Hardware-triggered strobe

    '------- General Purpose Timer/Counter -----------------
    'Counter Mode
    Public Const General_Counter As Short = &H0S 'general counter
    Public Const Pulse_Generation As Short = &H1S 'pulse generation
    'GPTC clock source
    Public Const GPTC_CLKSRC_EXT As Short = &H8S
    Public Const GPTC_CLKSRC_INT As Short = &H0S
    Public Const GPTC_GATESRC_EXT As Short = &H10S
    Public Const GPTC_GATESRC_INT As Short = &H0S
    Public Const GPTC_UPDOWN_SELECT_EXT As Short = &H20S
    Public Const GPTC_UPDOWN_SELECT_SOFT As Short = &H0S
    Public Const GPTC_UP_CTR As Short = &H40S
    Public Const GPTC_DOWN_CTR As Short = &H0S
    Public Const GPTC_ENABLE As Short = &H80S
    Public Const GPTC_DISABLE As Short = &H0S

    'General Purpose Timer/Counter for 9221
    'Counter Mode
    Public Const SimpleGatedEventCNT As Short = &H01S
    Public Const SinglePeriodMSR As Short = &H02S
    Public Const SinglePulseWidthMSR As Short = &H03S
    Public Const SingleGatedPulseGen As Short = &H04S
    Public Const SingleTrigPulseGen As Short = &H05S
    Public Const RetrigSinglePulseGen As Short = &H06S
    Public Const SingleTrigContPulseGen As Short = &H07S
    Public Const ContGatedPulseGen As Short = &H08S
    Public Const EdgeSeparationMSR As Short = &H09S
    Public Const SingleTrigContPulseGenPWM As Short = &H0AS
    Public Const ContGatedPulseGenPWM As Short = &H0BS
    Public Const CW_CCW_Encoder As Short = &H0CS
    Public Const x1_AB_Phase_Encoder As Short = &H0DS
    Public Const x2_AB_Phase_Encoder As Short = &H0ES
    Public Const x4_AB_Phase_Encoder As Short = &H0FS
    Public Const Phase_Z As Short = &H10S

    'GPTC clock source
    Public Const GPTC_CLK_SRC_Ext As Short = &H01S
    Public Const GPTC_CLK_SRC_Int As Short = &H00S
    Public Const GPTC_GATE_SRC_Ext As Short = &H02S
    Public Const GPTC_GATE_SRC_Int As Short = &H00S
    Public Const GPTC_UPDOWN_Ext As Short = &H04S
    Public Const GPTC_UPDOWN_Int As Short = &H00S

    'GPTC clock polarity
    Public Const GPTC_CLKSRC_LACTIVE As Short = &H01S
    Public Const GPTC_CLKSRC_HACTIVE As Short = &H00S
    Public Const GPTC_GATE_LACTIVE As Short = &H02S
    Public Const GPTC_GATE_HACTIVE As Short = &H00S
    Public Const GPTC_UPDOWN_LACTIVE As Short = &H04S
    Public Const GPTC_UPDOWN_HACTIVE As Short = &H00S
    Public Const GPTC_OUTPUT_LACTIVE As Short = &H08S
    Public Const GPTC_OUTPUT_HACTIVE As Short = &H00S

    Public Const IntGate As Short = &H00S
    Public Const IntUpDnCTR As Short = &H01S
    Public Const IntENABLE As Short = &H02S

    Public Const GPTC_EZ0_ClearPhase0 As Short = &H00S
    Public Const GPTC_EZ0_ClearPhase1 As Short = &H01S
    Public Const GPTC_EZ0_ClearPhase2 As Short = &H02S
    Public Const GPTC_EZ0_ClearPhase3 As Short = &H03S

    Public Const GPTC_EZ0_ClearMode0 As Short = &H00S
    Public Const GPTC_EZ0_ClearMode1 As Short = &H01S
    Public Const GPTC_EZ0_ClearMode2 As Short = &H02S
    Public Const GPTC_EZ0_ClearMode3 As Short = &H03S

    'Watchdog Timer
    'Counter action
    Public Const WDT_DISARM As Short = 0
    Public Const WDT_ARM As Short = 1
    Public Const WDT_RESTART As Short = 2

    'Pattern ID
    Public Const INIT_PTN As Short = 0
    Public Const EMGSHDN_PTN As Short = 1

    'Pattern ID for 7442/7444
    Public Const INIT_PTN_CH0 As Short = 0
    Public Const INIT_PTN_CH1 As Short = 1
    Public Const INIT_PTN_CH2 As Short = 2 'only for 7444
    Public Const INIT_PTN_CH3 As Short = 3 'only for 7444
    Public Const SAFTOUT_PTN_CH0 As Short = 4
    Public Const SAFTOUT_PTN_CH1 As Short = 5
    Public Const SAFTOUT_PTN_CH2 As Short = 6 'only for 7444
    Public Const SAFTOUT_PTN_CH3 As Short = 7 'only for 7444

    '16-bit binary or 4-decade BCD counter
    Public Const BIN As Short = 0
    Public Const BCD As Short = 1

    'EEPROM
    Public Const EEPROM_DEFAULT_BANK As Short = 0
    Public Const EEPROM_USER_BANK1 As Short = 1

    '----------- 9524 Const -----------------
    'AI Interrupt
    Public Const P9524_INT_LC_EOC As Short = 2
    Public Const P9524_INT_GP_EOC As Short = 3
    'DSP Constants
    Public Const P9524_SPIKE_REJ_DISABLE As Short = 0
    Public Const P9524_SPIKE_REJ_ENABLE As Short = 1
    'AI Transfer Mode
    Public Const P9524_AI_XFER_POLL As Short = 0
    Public Const P9524_AI_XFER_DMA As Short = 1
    'AI Poll all channels
    Public Const P9524_AI_POLL_ALLCHANNELS As Short = 8
    Public Const P9524_AI_POLLSCANS_CH0_CH3 As Short = 8
    Public Const P9524_AI_POLLSCANS_CH0_CH2 As Short = 9
    Public Const P9524_AI_POLLSCANS_CH0_CH1 As Short = 10
    'AI Transfer Speed
    Public Const P9524_ADC_30K_SPS As Short = 0
    Public Const P9524_ADC_15K_SPS As Short = 1
    Public Const P9524_ADC_7K5_SPS As Short = 2
    Public Const P9524_ADC_3K75_SPS As Short = 3
    Public Const P9524_ADC_2K_SPS As Short = 4
    Public Const P9524_ADC_1K_SPS As Short = 5
    Public Const P9524_ADC_500_SPS As Short = 6
    Public Const P9524_ADC_100_SPS As Short = 7
    Public Const P9524_ADC_60_SPS As Short = 8
    Public Const P9524_ADC_50_SPS As Short = 9
    Public Const P9524_ADC_30_SPS As Short = 10
    Public Const P9524_ADC_25_SPS As Short = 11
    Public Const P9524_ADC_15_SPS As Short = 12
    Public Const P9524_ADC_10_SPS As Short = 13
    Public Const P9524_ADC_5_SPS As Short = 14
    Public Const P9524_ADC_2R5_SPS As Short = 15
    'AI Configuration Mode
    Public Const P9524_VEX_Range_2R5V As Short = &H00S
    Public Const P9524_VEX_Range_10V As Short = &H01S
    Public Const P9524_VEX_Sence_Local As Short = &H00S
    Public Const P9524_VEX_Sence_Remote As Short = &H02S
    Public Const P9524_AI_AZMode As Short = &H04S
    Public Const P9524_AI_BufAutoReset As Short = &H08S
    Public Const P9524_AI_EnEOCInt As Short = &H10S
    'AI Trigger configuration
    Public Const P9524_TRGMOD_POST As Short = 0
    Public Const P9524_TRGSRC_SOFT As Short = 0
    Public Const P9524_TRGSRC_ExtD As Short = 1
    Public Const P9524_TRGSRC_SSI As Short = 2
    Public Const P9524_TRGSRC_QD0 As Short = 3
    Public Const P9524_TRGSRC_PG0 As Short = 4
    Public Const P9524_AI_TrgPositive As Short = 0
    Public Const P9524_AI_TrgNegative As Short = 8
    'AI Group
    Public Const P9524_AI_LC_Group As Short = 0
    Public Const P9524_AI_GP_Group As Short = 1
    'AI Channel
    Public Const P9524_AI_LC_CH0 As Short = 0
    Public Const P9524_AI_LC_CH1 As Short = 1
    Public Const P9524_AI_LC_CH2 As Short = 2
    Public Const P9524_AI_LC_CH3 As Short = 3
    Public Const P9524_AI_GP_CH0 As Short = 4
    Public Const P9524_AI_GP_CH1 As Short = 5
    Public Const P9524_AI_GP_CH2 As Short = 6
    Public Const P9524_AI_GP_CH3 As Short = 7

    'Counter Number
    Public Const P9524_CTR_PG0 As Short = 0
    Public Const P9524_CTR_PG1 As Short = 1
    Public Const P9524_CTR_PG2 As Short = 2
    Public Const P9524_CTR_QD0 As Short = 3
    Public Const P9524_CTR_QD1 As Short = 4
    Public Const P9524_CTR_QD2 As Short = 5
    Public Const P9524_CTR_INTCOUNTER As Short = 6
    'Counter Mode
    Public Const P9524_PulseGen_OUTDIR_N As Short = 0
    Public Const P9524_PulseGen_OUTDIR_R As Short = 1
    Public Const P9524_PulseGen_CW As Short = 0
    Public Const P9524_PulseGen_CCW As Short = 2
    Public Const P9524_x4_AB_Phase_Decoder As Short = 3
    Public Const P9524_Timer As Short = 4
    'Counter Op
    Public Const P9524_CTR_Enable As Short = 0
    'Event Mode
    Public Const P9524_Event_Timer As Short = 0

    'AO
    Public Const P9524_AO_CH0_1 As Short = 0


    '------Constants for PCI-6202------
    Public Const P6202_ISO0 As Short = 0
    Public Const P6202_TTL0 As Short = 1

    Public Const P6202_GPTC0 As Short = 0
    Public Const P6202_GPTC1 As Short = 1
    Public Const P6202_ENCODER0 As Short = 2
    Public Const P6202_ENCODER1 As Short = 3
    Public Const P6202_ENCODER2 As Short = 4

    'DA control constant
    Public Const P6202_DA_WRSRC_Int As Short = 0
    Public Const P6202_DA_WRSRC_AFI0 As Short = 1
    Public Const P6202_DA_WRSRC_SSI As Short = 2
    Public Const P6202_DA_WRSRC_AFI1 As Short = 3

    'DA trigger constant
    Public Const P6202_DA_TRGSRC_SOFT As Short = &H00S
    Public Const P6202_DA_TRGSRC_AFI0 As Short = &H01S
    Public Const P6202_DA_TRSRC_SSI As Short = &H02S
    Public Const P6202_DA_TRGSRC_AFI1 As Short = &H03S
    Public Const P6202_DA_TRGMOD_POST As Short = &H00S
    Public Const P6202_DA_TRGMOD_DELAY As Short = &H04S
    Public Const P6202_DA_ReTrigEn As Short = &H20S
    Public Const P6202_DA_DLY2En As Short = &H100S

    'SSI signal code
    Public Const P6202_SSI_DA_CONV As Short = &H04S
    Public Const P6202_SSI_DA_TRIG As Short = &H40S

    'Encoder constant
    Public Const P6202_EVT_TYPE_EPT0 As Short = &H00S
    Public Const P6202_EVT_TYPE_EPT1 As Short = &H01S
    Public Const P6202_EVT_TYPE_EPT2 As Short = &H02S
    Public Const P6202_EVT_TYPE_EZC0 As Short = &H03S
    Public Const P6202_EVT_TYPE_EZC1 As Short = &H04S
    Public Const P6202_EVT_TYPE_EZC2 As Short = &H05S

    Public Const P6202_EVT_MOD_EPT As Short = &H00S

    Public Const P6202_EPT_PULWIDTH_200us As Short = &H00S
    Public Const P6202_EPT_PULWIDTH_2ms As Short = &H01S
    Public Const P6202_EPT_PULWIDTH_20ms As Short = &H02S
    Public Const P6202_EPT_PULWIDTH_200ms As Short = &H03S

    Public Const P6202_EPT_TRGOUT_CALLBACK As Short = &H04S
    Public Const P6202_EPT_TRGOUT_AFI As Short = &H08S

    Public Const P6202_ENCODER0_LDATA As Short = &H05S
    Public Const P6202_ENCODER1_LDATA As Short = &H06S
    Public Const P6202_ENCODER2_LDATA As Short = &H07S

    '------------------------'
    ' Constants for PCI-922x '
    '------------------------'
    ' -- AI Constants -- '
    'Input Type
    Public Const P922x_AI_SingEnded As Short = &H00S
    Public Const P922x_AI_NonRef_SingEnded As Short = &H01S
    Public Const P922x_AI_Differential As Short = &H02S

    'Conversion Source
    Public Const  P922x_AI_CONVSRC_INT As Short = &H00S
    Public Const P922x_AI_CONVSRC_GPI0 As Short = &H10S
    Public Const P922x_AI_CONVSRC_GPI1 As Short = &H20S
    Public Const P922x_AI_CONVSRC_GPI2 As Short = &H30S
    Public Const P922x_AI_CONVSRC_GPI3 As Short = &H40S
    Public Const P922x_AI_CONVSRC_GPI4 As Short = &H50S
    Public Const P922x_AI_CONVSRC_GPI5 As Short = &H60S
    Public Const P922x_AI_CONVSRC_GPI6 As Short = &H70S
    Public Const P922x_AI_CONVSRC_GPI7 As Short = &H80S
    Public Const P922x_AI_CONVSRC_SSI1 As Short = &H90S
    Public Const P922x_AI_CONVSRC_SSI As Short = &H90S

    'Trigger Mode
    Public Const P922x_AI_TRGMOD_POST As Short = &H00S
    Public Const P922x_AI_TRGMOD_GATED As Short = &H01S

    'Trigger Source
    Public Const P922x_AI_TRGSRC_SOFT As Short = &H00S
    Public Const P922x_AI_TRGSRC_GPI0 As Short = &H10S
    Public Const P922x_AI_TRGSRC_GPI1 As Short = &H20S
    Public Const P922x_AI_TRGSRC_GPI2 As Short = &H30S
    Public Const P922x_AI_TRGSRC_GPI3 As Short = &H40S
    Public Const P922x_AI_TRGSRC_GPI4 As Short = &H50S
    Public Const P922x_AI_TRGSRC_GPI5 As Short = &H60S
    Public Const P922x_AI_TRGSRC_GPI6 As Short = &H70S
    Public Const P922x_AI_TRGSRC_GPI7 As Short = &H80S
    Public Const P922x_AI_TRGSRC_SSI5 As Short = &H90S
    Public Const P922x_AI_TRGSRC_SSI As Short = &H90S

    'Trigger Polarity
    Public Const P922x_AI_TrgPositive As Short = &H000S
    Public Const P922x_AI_TrgNegative As Short = &H100S

    'ReTrigger
    Public Const P922x_AI_EnReTigger As Short = &H200S

    ' -- AO Constants -- '
    'Conversion Source
    Public Const P922x_AO_CONVSRC_INT As Short = &H00S
    Public Const P922x_AO_CONVSRC_GPI0 As Short = &H01S
    Public Const P922x_AO_CONVSRC_GPI1 As Short = &H02S
    Public Const P922x_AO_CONVSRC_GPI2 As Short = &H03S
    Public Const P922x_AO_CONVSRC_GPI3 As Short = &H04S
    Public Const P922x_AO_CONVSRC_GPI4 As Short = &H05S
    Public Const P922x_AO_CONVSRC_GPI5 As Short = &H06S
    Public Const P922x_AO_CONVSRC_GPI6 As Short = &H07S
    Public Const P922x_AO_CONVSRC_GPI7 As Short = &H08S
    Public Const P922x_AO_CONVSRC_SSI2 As Short = &H09S
    Public Const P922x_AO_CONVSRC_SSI As Short = &H09S

    'Trigger Mode
    Public Const P922x_AO_TRGMOD_POST As Short = &H00S
    Public Const P922x_AO_TRGMOD_DELAY As Short = &H01S

    'Trigger Source
    Public Const P922x_AO_TRGSRC_SOFT As Short = &H00S
    Public Const P922x_AO_TRGSRC_GPI0 As Short = &H10S
    Public Const P922x_AO_TRGSRC_GPI1 As Short = &H20S
    Public Const P922x_AO_TRGSRC_GPI2 As Short = &H30S
    Public Const P922x_AO_TRGSRC_GPI3 As Short = &H40S
    Public Const P922x_AO_TRGSRC_GPI4 As Short = &H50S
    Public Const P922x_AO_TRGSRC_GPI5 As Short = &H60S
    Public Const P922x_AO_TRGSRC_GPI6 As Short = &H70S
    Public Const P922x_AO_TRGSRC_GPI7 As Short = &H80S
    Public Const P922x_AO_TRGSRC_SSI6 As Short = &H90S
    Public Const P922x_AO_TRGSRC_SSI As Short = &H90S

    'Trigger Polarity
    Public Const P922x_AO_TrgPositive As Short = &H000S
    Public Const P922x_AO_TrgNegative As Short = &H100S

    'Retrigger
    Public Const P922x_AO_EnReTigger As Short = &H200S

    'Trigger Delay 2
    Public Const P922x_AO_EnDelay2 As Short = &H400S

    ' -- DI Constants -- '
    'Conversion Source
    Public Const P922x_DI_CONVSRC_INT As Short = &H00S
    Public Const P922x_DI_CONVSRC_GPI0 As Short = &H01S
    Public Const P922x_DI_CONVSRC_GPI1 As Short = &H02S
    Public Const P922x_DI_CONVSRC_GPI2 As Short = &H03S
    Public Const P922x_DI_CONVSRC_GPI3 As Short = &H04S
    Public Const P922x_DI_CONVSRC_GPI4 As Short = &H05S
    Public Const P922x_DI_CONVSRC_GPI5 As Short = &H06S
    Public Const P922x_DI_CONVSRC_GPI6 As Short = &H07S
    Public Const P922x_DI_CONVSRC_GPI7 As Short = &H08S
    Public Const P922x_DI_CONVSRC_ADCONV As Short = &H09S
    Public Const P922x_DI_CONVSRC_DACONV As Short = &H0AS

    'Trigger Mode
    Public Const P922x_DI_TRGMOD_POST As Short = &H00S

    'Trigger Source
    Public Const P922x_DI_TRGSRC_SOFT As Short = &H00S
    Public Const P922x_DI_TRGSRC_GPI0 As Short = &H10S
    Public Const P922x_DI_TRGSRC_GPI1 As Short = &H20S
    Public Const P922x_DI_TRGSRC_GPI2 As Short = &H30S
    Public Const P922x_DI_TRGSRC_GPI3 As Short = &H40S
    Public Const P922x_DI_TRGSRC_GPI4 As Short = &H50S
    Public Const P922x_DI_TRGSRC_GPI5 As Short = &H60S
    Public Const P922x_DI_TRGSRC_GPI6 As Short = &H70S
    Public Const P922x_DI_TRGSRC_GPI7 As Short = &H80S

    'Trigger Polarity
    Public Const P922x_DI_TrgPositive As Short = &H000S
    Public Const P922x_DI_TrgNegative As Short = &H100S

    'ReTrigger
    Public Const P922x_DI_EnReTigger As Short = &H200S

    ' -- DO Constants -- '
    'Conversion Source
    Public Const P922x_DO_CONVSRC_INT As Short = &H00S
    Public Const P922x_DO_CONVSRC_GPI0 As Short = &H01S
    Public Const P922x_DO_CONVSRC_GPI1 As Short = &H02S
    Public Const P922x_DO_CONVSRC_GPI2 As Short = &H03S
    Public Const P922x_DO_CONVSRC_GPI3 As Short = &H04S
    Public Const P922x_DO_CONVSRC_GPI4 As Short = &H05S
    Public Const P922x_DO_CONVSRC_GPI5 As Short = &H06S
    Public Const P922x_DO_CONVSRC_GPI6 As Short = &H07S
    Public Const P922x_DO_CONVSRC_GPI7 As Short = &H08S
    Public Const P922x_DO_CONVSRC_ADCONV As Short = &H09S
    Public Const P922x_DO_CONVSRC_DACONV As Short = &H0AS

    'Trigger Mode
    Public Const P922x_DO_TRGMOD_POST As Short = &H00S
    Public Const P922x_DO_TRGMOD_DELAY As Short = &H01S

    'Trigger Source
    Public Const P922x_DO_TRGSRC_SOFT As Short = &H00S
    Public Const P922x_DO_TRGSRC_GPI0 As Short = &H10S
    Public Const P922x_DO_TRGSRC_GPI1 As Short = &H20S
    Public Const P922x_DO_TRGSRC_GPI2 As Short = &H30S
    Public Const P922x_DO_TRGSRC_GPI3 As Short = &H40S
    Public Const P922x_DO_TRGSRC_GPI4 As Short = &H50S
    Public Const P922x_DO_TRGSRC_GPI5 As Short = &H60S
    Public Const P922x_DO_TRGSRC_GPI6 As Short = &H70S
    Public Const P922x_DO_TRGSRC_GPI7 As Short = &H80S

    'Trigger Polarity
    Public Const P922x_DO_TrgPositive As Short = &H000S
    Public Const P922x_DO_TrgNegative As Short = &H100S

    'Retrigger
    Public Const P922x_DO_EnReTigger As Short = &H200S

    ' -- Encoder/GPTC Constants -- '
    Public Const P922x_GPTC0 As Short = &H00S
    Public Const P922x_GPTC1 As Short = &H01S
    Public Const P922x_GPTC2 As Short = &H02S
    Public Const P922x_GPTC3 As Short = &H03S
    Public Const P922x_ENCODER0 As Short = &H04S
    Public Const P922x_ENCODER1 As Short = &H05S

    'Encoder Setting Event Mode
    Public Const P922x_EVT_MOD_EPT As Short = &H00S

    'Encoder Setting Event Control
    Public Const P922x_EPT_PULWIDTH_200us As Short = &H00S
    Public Const P922x_EPT_PULWIDTH_2ms As Short = &H01S
    Public Const P922x_EPT_PULWIDTH_20ms As Short = &H02S
    Public Const P922x_EPT_PULWIDTH_200ms As Short = &H03S
    Public Const P922x_EPT_TRGOUT_GPO As Short = &H04S
    Public Const P922x_EPT_TRGOUT_CALLBACK As Short = &H08S

    'Event Type
    Public Const P922x_EVT_TYPE_EPT0 As Short = &H00S
    Public Const P922x_EVT_TYPE_EPT1 As Short = &H01S

    'SSI signal code
    Public Const P922x_SSI_AI_CONV As Short = &H02S
    Public Const P922x_SSI_AI_TRIG As Short = &H20S
    Public Const P922x_SSI_AO_CONV As Short = &H04S
    Public Const P922x_SSI_AO_TRIG As Short = &H40S

    '------------------------'
    'Constants for PCIe-7350 '
    '------------------------'
    Public Const P7350_PortDIO As Short = 0
    Public Const P7350_PortAFI As Short = 1
    'DIO Port
    Public Const P7350_DIO_A As Short = 0
    Public Const P7350_DIO_B As Short = 1
    Public Const P7350_DIO_C As Short = 2
    Public Const P7350_DIO_D As Short = 3
    'AFI Port
    Public Const P7350_AFI_0 As Short = 0
    Public Const P7350_AFI_1 As Short = 1
    Public Const P7350_AFI_2 As Short = 2
    Public Const P7350_AFI_3 As Short = 3
    Public Const P7350_AFI_4 As Short = 4
    Public Const P7350_AFI_5 As Short = 5
    Public Const P7350_AFI_6 As Short = 6
    Public Const P7350_AFI_7 As Short = 7
    'AFI Mode
    Public Const P7350_AFI_DIStartTrig As Short = 0
    Public Const P7350_AFI_DOStartTrig As Short = 1
    Public Const P7350_AFI_DIPauseTrig As Short = 2
    Public Const P7350_AFI_DOPauseTri As Short = 3
    Public Const P7350_AFI_DISWTrigOut As Short = 4
    Public Const P7350_AFI_DOSWTrigOut As Short =5
    Public Const P7350_AFI_COSTrigOut As Short = 6
    Public Const P7350_AFI_PMTrigOut As Short = 7
    Public Const P7350_AFI_HSDIREQ As Short = 8
    Public Const P7350_AFI_HSDIACK As Short = 9
    Public Const P7350_AFI_HSDITRIG As Short = 10
    Public Const P7350_AFI_HSDOREQ As Short = 11
    Public Const P7350_AFI_HSDOACK As Short = 12
    Public Const P7350_AFI_HSDOTRIG As Short = 13
    Public Const P7350_AFI_SPI As Short = 14
    Public Const P7350_AFI_I2C As Short = 15
    Public Const P7350_POLL_DI As Short = 16
    Public Const P7350_POLL_DO As Short = 17
    'Operation Mode
    Public Const P7350_FreeRun As Short = 0
    Public Const P7350_HandShake As Short = 1
    Public Const P7350_BurstHandShake As Short = 2
    'Trigger Status
    Public Const P7350_WAIT_NO As Short = 0
    Public Const P7350_WAIT_EXTTRG As Short = 1
    Public Const P7350_WAIT_SOFTTRG As Short = 2
    'Sampled Clock
    Public Const P7350_IntSampledCLK As Short = &H00S
    Public Const P7350_ExtSampledCLK As Short = &H01S
    'Sampled Clock Edge
    Public Const P7350_SampledCLK_R As Short = &H00S
    Public Const P7350_SampledCLK_F As Short = &H02S
    'Enable Export Sample Clock*/
    Public Const P7350_EnExpSampledCLK As Short = &H04S
    'Trigger Configuration
    Public Const P7350_EnPauseTrig As Short = &H01S
    Public Const P7350_EnSoftTrigOut As Short = &H02S
    'HandShake & Trigger Polarity
    Public Const P7350_DIREQ_POS As Short = &H00S
    Public Const P7350_DIREQ_NEG As Short = &H01S
    Public Const P7350_DIACK_POS As Short = &H00S
    Public Const P7350_DIACK_NEG As Short = &H02S
    Public Const P7350_DITRIG_POS As Short = &H00S
    Public Const P7350_DITRIG_NEG As Short = &H04S
    Public Const P7350_DIStartTrig_POS As Short = &H00S
    Public Const P7350_DIStartTrig_NEG As Short = &H08S
    Public Const P7350_DIPauseTrig_POS As Short = &H00S
    Public Const P7350_DIPauseTrig_NEG As Short = &H10S
    Public Const P7350_DOREQ_POS As Short = &H00S
    Public Const P7350_DOREQ_NEG As Short = &H01S
    Public Const P7350_DOACK_POS As Short = &H00S
    Public Const P7350_DOACK_NEG As Short = &H02S
    Public Const P7350_DOTRIG_POS As Short = &H00S
    Public Const P7350_DOTRIG_NEG As Short = &H04S
    Public Const P7350_DOStartTrig_POS As Short = &H00S
    Public Const P7350_DOStartTrig_NEG As Short = &H08S
    Public Const P7350_DOPauseTrig_POS As Short = &H00S
    Public Const P7350_DOPauseTrig_NEG As Short = &H10S
    'External Sampled Clock Source
    Public Const P7350_ECLK_IN As Short = 8
    'Export Sampled Clock
    Public Const P7350_ECLK_OUT As Short = 8
    'Enable Dynamic Delay Adjust
    Public Const P7350_DisDDA As Short = &H00S
    Public Const P7350_EnDDA As Short = &H01S
    'Dynamic Delay Adjust Mode
    Public Const P7350_DDA_Lag As Short = &H00S
    Public Const P7350_DDA_Lead As Short = &H02S
    'Dynamic Delay Adjust Step
    Public Const P7350_DDA_130PS As Short = 0
    Public Const P7350_DDA_260PS As Short = 1
    Public Const P7350_DDA_390PS As Short = 2
    Public Const P7350_DDA_520PS As Short = 3
    Public Const P7350_DDA_650PS As Short = 4
    Public Const P7350_DDA_780PS As Short = 5
    Public Const P7350_DDA_910PS As Short = 6
    Public Const P7350_DDA_1R04NS As Short = 7
    'Enable Dynamic Phase Adjust
    Public Const P7350_DisDPA As Short = &H00S
    Public Const P7350_EnDPA As Short = &H01S
    'Dynamic Delay Adjust Degree
    Public Const P7350_DPA_0DG As Short = 0
    Public Const P7350_DPA_22R5DG As Short = 1
    Public Const P7350_DPA_45DG As Short = 2
    Public Const P7350_DPA_67R5DG As Short = 3
    Public Const P7350_DPA_90DG As Short = 4
    Public Const P7350_DPA_112R5DG As Short = 5
    Public Const P7350_DPA_135DG As Short = 6
    Public Const P7350_DPA_157R5DG As Short = 7
    Public Const P7350_DPA_180DG As Short = 8
    Public Const P7350_DPA_202R5DG As Short = 9
    Public Const P7350_DPA_225DG As Short = 10
    Public Const P7350_DPA_247R5DG As Short = 11
    Public Const P7350_DPA_270DG As Short = 12
    Public Const P7350_DPA_292R5DG As Short = 13
    Public Const P7350_DPA_315DG As Short = 14
    Public Const P7350_DPA_337R5DG As Short = 15

    'DIO & AFI Voltage Level
    Public Const VoltLevel_3R3 As Short = 0
    Public Const VoltLevel_2R5 As Short = 1
    Public Const VoltLevel_1R8 As Short = 2

    'Constants for I Squared C (I2C)
    'I2C Port
    Public Const I2C_Port_A As Short = 0
    'I2C Control Operation
    Public Const I2C_ENABLE As Short = 0
    Public Const I2C_STOP As Short = 1

    'Constants for Serial Peripheral Interface
    'SPI Port*/
    Public Const SPI_Port_A As Short = 0
    'SPI Clock Mode
    Public Const SPI_CLK_L As Short = &H00S
    Public Const SPI_CLK_H As Short = &H01S
    'SPI TX Polarity
    Public Const SPI_TX_POS As Short = &H00S
    Public Const SPI_TX_NEG As Short = &H02S
    'SPI RX Polarity
    Public Const SPI_RX_POS As Short = &H00S
    Public Const SPI_RX_NEG As Short = &H04S
    'SPI Transferred Order
    Public Const SPI_MSB As Short = &H00S
    Public Const SPI_LSB As Short = &H08S
    'SPI Control Operation
    Public Const SPI_ENABLE As Short = 0

    'Constants for Pattern Match
    'Pattern Match Channel Mode
    Public Const PATMATCH_CHNDisable As Short = 0
    Public Const PATMATCH_CHNEnable As Short = 1
    'Pattern Match Channel Type
    Public Const PATMATCH_Level_L As Short = 0
    Public Const PATMATCH_Level_H As Short = 1
    Public Const PATMATCH_Edge_R As Short = 2
    Public Const PATMATCH_Edge_F As Short = 3
    'Pattern Match Operation
    Public Const PATMATCH_STOP As Short = 0
    Public Const PATMATCH_START As Short = 1
    Public Const PATMATCH_RESTART As Short = 2

    'System Function
    Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
    Public Delegate Sub CallbackDelegate()

	'Constants for Access EEPROM
	'for PCI-7230/PCMe-7230
	Public Const P7230_EEP_BLK_0 As Short = 0
	Public Const P7230_EEP_BLK_1 As Short = 1

    '-------------------------------------------------------------------
    '  PCIS-DASK Function prototype
    '-----------------------------------------------------------------*/
    Declare Function Register_Card Lib "Pci-Dask.dll" (ByVal cardType As Short, ByVal card_num As Short) As Short
    Declare Function Release_Card Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function GetActualRate Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal SampleRate As Double, ByRef ActualRate As Double) As Short
    Declare Function GetActualRate_9524 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Group As Short, ByVal SampleRate As Double, ByRef ActualRate As Double) As Short
    Declare Function GetCardType Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef cardType As Short) As Short
    Declare Function GetBaseAddr Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef BaseAddr As Integer, ByRef BaseAddr2 As Integer) As Short
    Declare Function GetLCRAddr Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef LcrAddr As Integer) As Short
    Declare Function GetCardIndexFromID Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef cardType As Short, ByRef cardIndex As Short) As Short
    Declare Function EMGShutDownControl Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ctrl As Byte) As Short
    Declare Function EMGShutDownStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef ctrl As Byte) As Short
    Declare Function HotResetHoldControl Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Enable As Byte) As Short
    Declare Function HotResetHoldStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef sts As Byte) As Short
    Declare Function SetInitPattern Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal patID As Byte, ByVal pattern As Integer) As Short
    Declare Function GetInitPattern Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal patID As Byte, ByRef pattern As Integer) As Short
    Declare Function IdentifyLED_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ctrl As Byte) As Short
	Declare Function PCI_EEPROM_LoadData Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal block As Short, ByRef data As Short) As Short
	Declare Function PCI_EEPROM_SaveData Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal block As Short, ByVal data As Short) As Short

    'AI Functions
    Declare Function AI_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short, ByVal TrgMode As Short, ByVal TraceCnt As Short) As Short
    Declare Function AI_9112_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short) As Short
    Declare Function AI_9113_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short) As Short
    Declare Function AI_9114_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short) As Short
    Declare Function AI_9114_PreTrigConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PreTrgEn As Short, ByVal TraceCnt As Short) As Short
    Declare Function AI_9116_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal PostCnt As Short, ByVal MCnt As Short, ByVal ReTrgCnt As Short) As Short
    Declare Function AI_9118_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ModeCtrl As Short, ByVal FunCtrl As Short, ByVal BurstCnt As Short, ByVal PostCnt As Short) As Short
    Declare Function AI_9221_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal AutoResetBuf As Byte) As Short
    Declare Function AI_9812_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrgMode As Short, ByVal TrgSrc As Short, ByVal TrgPol As Short, ByVal ClkSel As Short, ByVal TrgLevel As Short, ByVal PostCnt As Short) As Short
    Declare Function AI_9116_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer) As Short
    Declare Function AI_9221_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer) As Short
    Declare Function AI_9812_SetDiv Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal pacerVal As Integer) As Short
    Declare Function AI_9524_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Group As Short, ByVal XMode As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal TrigValue As Integer) As Short
    Declare Function AI_9524_PollConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Group As Short, ByVal PollChannel As Short, ByVal PollRange As Short, ByVal PollSpeed As Short) As Short
    Declare Function AI_9524_SetDSP Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal Mode As Short, ByVal DFStage As Short, ByVal SPKRejThreshold As Integer) As Short
    Declare Function AI_9524_GetEOCEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Group As Short, ByRef hEvent As Integer) As Short
    Declare Function AI_9222_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTriggerCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function AI_9222_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer) As Short
    Declare Function AI_9223_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTriggerCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function AI_9223_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer) As Short
    Declare Function AI_922A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTriggerCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function AI_922A_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer) As Short
    Declare Function AI_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
    Declare Function AI_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef AccessCnt As Integer) As Short
    Declare Function AI_AsyncDblBufferHalfReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte, ByRef StopFlag As Byte) As Short
    Declare Function AI_AsyncDblBufferMode Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Enable As Byte) As Short
    Declare Function AI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short) As Short
    Declare Function AI_AsyncDblBufferHandled Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function AI_AsyncDblBufferToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function AI_ContReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Buffer As Short, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function AI_ContScanChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Buffer As Short, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function AI_ContReadMultiChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByRef AdRanges As Short, ByRef Buffer As Short, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function AI_ContReadChannelToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByVal FileName As String, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function AI_ContScanChannelsToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByVal FileName As String, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function AI_ContReadMultiChannelsToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByRef AdRanges As Short, ByVal FileName As String, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function AI_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Status As Short) As Short
    Declare Function AI_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
    Declare Function AI_ReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Value As Short) As Short
    Declare Function AI_ReadChannel32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Value As Integer) As Short
    Declare Function AI_VReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Voltage As Double) As Short
    Declare Function AI_ScanReadChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Buffer As Short) As Short
    Declare Function AI_ScanReadChannels32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Buffer As Integer) As Short
    Declare Function AI_ReadMultiChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef Chans As Short, ByRef AdRanges As Short, ByRef Buffer As Short) As Short
    Declare Function AI_VoltScale Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByRef reading As Short, ByRef Voltage As Double) As Short
    Declare Function AI_VoltScale32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByRef reading As Integer, ByRef Voltage As Double) As Short
    Declare Function AI_ContVScale Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByRef readingArray As Short, ByRef voltageArray As Double, ByVal CCount As Integer) As Short
    Declare Function AI_ContVScale Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByRef readingArray As Integer, ByRef voltageArray As Double, ByVal CCount As Integer) As Short
    Declare Function AI_AsyncDblBufferOverrun Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal op As Short, ByRef overrunFlag As Short) As Short
    Declare Function AI_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function AI_SetTimeOut Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TimeOut As Integer) As Short
    Declare Function AI_ContBufferReset Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function AI_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function AI_AsyncReTrigNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Ready As Byte, ByRef StopFlag As Byte, ByRef RdyTrigCnt As Short) As Short

    'AO Functions
    Declare Function AO_6202_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTrgCnt As Integer, ByVal DLY1Cnt As Integer, ByVal DLY2Cnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function AO_6208A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal V2AMode As Short) As Short
    Declare Function AO_6308A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal V2AMode As Short) As Short
    Declare Function AO_6308V_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal OutputPolarity As Short, ByVal refVoltage As Double) As Short
    Declare Function AO_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal OutputPolarity As Short) As Short
    Declare Function AO_9112_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal refVoltage As Double) As Short
    Declare Function AO_9222_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTrgCnt As Integer, ByVal DLY1Cnt As Integer, ByVal DLY2Cnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function AO_9223_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTrgCnt As Integer, ByVal DLY1Cnt As Integer, ByVal DLY2Cnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function AO_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
    Declare Function AO_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
    Declare Function AO_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef AccessCnt As Integer, ByVal stop_mode As Short) As Short
    Declare Function AO_AsyncDblBufferHalfReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte) As Short
    Declare Function AO_AsyncDblBufferMode Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Enable As Byte) As Short
    Declare Function AO_ContBufferCompose Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TotalChnCount As Short, ByVal ChnNum As Short, ByVal UpdateCount As Integer, ByRef ConBuffer As Integer, ByRef Buffer As Integer) As Short
    Declare Function AO_ContBufferReset Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function AO_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Buffer As Short, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function AO_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Buffer As Integer, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function AO_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Status As Short) As Short
    Declare Function AO_ContWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal BufId As Short, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short, ByVal SyncMode As Short) As Short
    Declare Function AO_ContWriteMultiChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal Chans As Short, ByVal BufId As Short, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short, ByVal SyncMode As Short) As Short
    Declare Function AO_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function AO_SetTimeOut Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TimeOut As Integer) As Short
    Declare Function AO_SimuWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Group As Short, ByRef valueArray As Short) As Short
    Declare Function AO_SimuVWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Group As Short, ByRef voltageArray As Double) As Short
    Declare Function AO_WriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal Value As Short) As Short
    Declare Function AO_VWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal Voltage As Double) As Short
    Declare Function AO_VoltScale Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal Voltage As Double, ByRef binValue As Short) As Short

    'DI Functions
    Declare Function DI_7200_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short, ByVal ExtTrigEn As Short, ByVal TrigPol As Short, ByVal I_REQ_Pol As Short) As Short
    Declare Function DI_7233_ForceLogic Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short) As Short
    Declare Function DI_7300A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortWidth As Short, ByVal TrigSource As Short, ByVal WaitStatus As Short, ByVal Terminaor As Short, ByVal I_REQ_Pol As Short, ByVal clear_fifo As Byte, ByVal disable_di As Byte) As Short
    Declare Function DI_7300B_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortWidth As Short, ByVal TrigSource As Short, ByVal WaitStatus As Short, ByVal Terminator As Short, ByVal I_Cntrl_Pol As Short, ByVal clear_fifo As Byte, ByVal disable_di As Byte) As Short
    Declare Function DI_7350_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal DIPortWidth As Short, ByVal DIMode As Short, ByVal DIWaitStatus As Short, ByVal DIClkConfig As Short) As Short
    Declare Function DI_7350_TrigHSConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigConfig As Short, ByVal DI_IPOL As Short, ByVal DI_REQSrc As Short, ByVal DI_ACKSrc As Short, ByVal DI_TRIGSrc As Short, ByVal StartTrigSrc As Short, ByVal PauseTrigSrc As Short,  ByVal SoftTrigOutSrc As Short, ByVal SoftTrigOutLength As Integer, ByVal TrigCount As Integer) As Short
    Declare Function DI_7350_ExtSampCLKConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal CLK_Src As Short, ByVal CLK_DDAMode As Short, ByVal CLK_DPAMode As Short, ByVal CLK_DDAVlaue As Short, ByVal CLK_DPAVlaue As Short) As Short
    Declare Function DI_7350_ExportSampCLKConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal CLK_Src As Short, ByVal CLK_DPAMode As Short, ByVal CLK_DPAVlaue As Short) As Short
    Declare Function DI_7350_SoftTriggerGen Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function DI_7350_BurstHandShakeDelay Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Delay As Byte) As Short
    Declare Function DI_9222_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTriggerCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function DI_9223_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTriggerCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function DI_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
    Declare Function DI_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef AccessCnt As Integer) As Short
    Declare Function DI_AsyncDblBufferHalfReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte) As Short
    Declare Function DI_AsyncDblBufferMode Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Enable As Byte) As Short
    Declare Function DI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Byte) As Short
    Declare Function DI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short) As Short
    Declare Function DI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Integer) As Short
    Declare Function DI_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Byte, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DI_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DI_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Integer, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DI_ContMultiBufferStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal SampleRate As Double) As Short
    Declare Function DI_AsyncMultiBufferNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef NextReady As Byte, ByRef BufferId As Short) As Short
    Declare Function DI_ContReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Buffer As Byte, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DI_ContReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Buffer As UShort, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DI_ContReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Buffer As Integer, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DI_ContReadPortToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal FileName As String, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DI_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Status As Short) As Short
    Declare Function DI_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
    Declare Function DI_ReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Value As Integer) As Short
    Declare Function DI_ReadLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal LLine As Short, ByRef Value As Short) As Short
    Declare Function DI_AsyncDblBufferOverrun Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal op As Short, ByRef overrunFlag As Short) As Short
    Declare Function DI_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DI_AsyncDblBufferHandled Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function DI_AsyncDblBufferToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function DI_SetTimeOut Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TimeOut As Integer) As Short
    Declare Function DI_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DI_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Integer, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DI_ContBufferReset Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function DI_AsyncReTrigNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Ready As Byte, ByRef StopFlag As Byte, ByRef RdyTrigCnt As Short) As Short

    'DO Functions
    Declare Function DO_7200_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short, ByVal OutReqEn As Short, ByVal OutTrigSig As Short) As Short
    Declare Function DO_7300A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortWidth As Short, ByVal TrigSource As Short, ByVal WaitStatus As Short, ByVal Terminaor As Short, ByVal O_REQ_Pol As Short) As Short
    Declare Function DO_7300B_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortWidth As Short, ByVal TrigSource As Short, ByVal WaitStatus As Short, ByVal Terminator As Short, ByVal O_Cntrl_Pol As Short, ByVal FifoThreshold As Integer) As Short
    Declare Function DO_7300B_SetDODisableMode Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short) As Short
    Declare Function DO_7350_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal DOPortWidth As Short, ByVal DOMode As Short, ByVal DOWaitStatus As Short, ByVal DOClkConfig As Short) As Short
    Declare Function DO_7350_TrigHSConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigConfig As Short, ByVal DO_IPOL As Short, ByVal DO_REQSrc As Short, ByVal DO_ACKSrc As Short, ByVal DO_TRIGSrc As Short, ByVal StartTrigSrc As Short, ByVal PauseTrigSrc As Short,  ByVal SoftTrigOutSrc As Short, ByVal SoftTrigOutLength As Integer, ByVal TrigCount As Integer) As Short
    Declare Function DO_7350_ExtSampCLKConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal CLK_Src As Short, ByVal CLK_DDAMode As Short, ByVal CLK_DPAMode As Short, ByVal CLK_DDAVlaue As Short, ByVal CLK_DPAVlaue As Short) As Short
    Declare Function DO_7350_ExportSampCLKConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal CLK_Src As Short, ByVal CLK_DPAMode As Short, ByVal CLK_DPAVlaue As Short) As Short
    Declare Function DO_7350_SoftTriggerGen Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function DO_7350_BurstHandShakeDelay Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Delay As Byte) As Short
    Declare Function DO_9222_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTrgCnt As Integer, ByVal DLY1Cnt As Integer, ByVal DLY2Cnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function DO_9223_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTrgCnt As Integer, ByVal DLY1Cnt As Integer, ByVal DLY2Cnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Declare Function DO_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
    Declare Function DO_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef AccessCnt As Integer) As Short
    Declare Function DO_ContWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As Byte, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As UShort, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As UInt32, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContWritePortEx Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As Byte, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContWritePortEx Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As UShort, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContWritePortEx Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As UInt32, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Status As Short) As Short
    Declare Function DO_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
    Declare Function DO_PGStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Byte, ByVal WriteCount As Integer, ByVal SampleRate As Double) As Short
    Declare Function DO_PGStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal WriteCount As Integer, ByVal SampleRate As Double) As Short
    Declare Function DO_PGStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As UInt32, ByVal WriteCount As Integer, ByVal SampleRate As Double) As Short
    Declare Function DO_PGStop Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function DO_WritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Value As Integer) As Short
    Declare Function DO_WriteLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal LLine As Short, ByVal Value As Short) As Short
    Declare Function DO_SimuWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef Buffer As Integer) As Short
    Declare Function DO_ReadLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal LLine As Short, ByRef Value As Short) As Short
    Declare Function DO_ReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Value As Integer) As Short
    Declare Function EDO_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal EDO_Fun As Short) As Short
    Declare Function DO_WriteExtTrigLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Value As Short) As Short
    Declare Function DO_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Byte, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DO_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DO_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Integer, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DO_ContMultiBufferStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal SampleRate As Double) As Short
    Declare Function DO_AsyncMultiBufferNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef NextReady As Byte, ByRef BufferId As Short) As Short
    Declare Function DO_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As Integer) As Short
    Declare Function DO_SetTimeOut Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TimeOut As Integer) As Short
    Declare Function DO_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DO_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Integer, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DO_ContBufferReset Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short

    'DIO Functions
    Declare Function DIO_PortConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Direction As Short) As Short
    Declare Function DIO_LinesConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Linesdirmap As Short) As Short
    Declare Function DIO_LineConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal wLine As Short, ByVal Direction As Short) As Short
    Declare Function DIO_SetDualInterrupt Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Int1Mode As Short, ByVal Int2Mode As Short, ByRef hEvent As Integer) As Short
    Declare Function DIO_SetCOSInterrupt Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal ctlA As Short, ByVal ctlB As Short, ByVal ctlC As Short) As Short
    Declare Function DIO_GetCOSLatchData Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef CosLData As Short) As Short
    Declare Function DIO_SetCOSInterrupt32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Byte, ByVal ctl As Integer, ByRef hEvent As Integer, ByVal ManualReset As Byte) As Short
    Declare Function DIO_GetCOSLatchData32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Byte, ByRef CosLData As Integer) As Short
    Declare Function DIO_GetCOSLatchDataInt32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Byte, ByRef CosLData As Integer) As Short
    Declare Function DIO_INT_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal hEvent As Integer, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DIO_INT1_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Int1Mode As Short, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DIO_INT2_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Int2Mode As Short, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DIO_7300SetInterrupt Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AuxDIEn As Short, ByVal T2En As Short, ByRef hEvent As Integer) As Short
    Declare Function DIO_AUXDI_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AuxDIEn As Short, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DIO_T2_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal T2En As Short, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DIO_COSInterruptCounter Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Counter_Num As Short, ByVal Counter_Mode As Short, ByVal DI_Port As Short, ByVal DI_Line As Short, ByRef Counter_Value As Integer) As Short
    Declare Function DIO_VoltLevelConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortType As Short, ByVal VoltLevel As Short) As Short
    Declare Function DIO_7350_AFIConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AFI_Port As Short, ByVal AFI_Enable As Short, ByVal AFI_Mode As Short, ByVal AFI_TrigOutLen As Integer) As Short
    Declare Function DIO_PMConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal PM_ChnEn As Short, ByVal PM_ChnType As Short) As Short
    Declare Function DIO_PMControl Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal PM_Start As Short, ByRef hEvent As Integer, ByVal ManualReset As Byte) As Short
    Declare Function DIO_SetPMInterrupt32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Ctrl As Integer, ByVal Pattern1 As Integer, ByVal Pattern2 As Integer,ByRef hEvent As Integer, ByVal ManualReset As Byte) As Short
    Declare Function DIO_GetPMLatchData32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef PMLData As Integer) As Short

    'Counter Functions
    Declare Function CTR_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal Mode As Short, ByVal CCount As Integer, ByVal BinBcd As Short) As Short
    Declare Function CTR_Setup_All "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal CtrCnt As Short, ByRef Ctr As Short, ByRef Mode As Short, ByRef CCount As Integer, ByRef BinBcd As Short) As Short
    Declare Function CTR_Clear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal State As Short) As Short
    Declare Function CTR_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByRef Value As Integer) As Short
    Declare Function CTR_Read_All "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal CtrCnt As Short, ByRef Ctr As Short, ByRef Value As Integer) As Short
    Declare Function CTR_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByRef Value As Integer) As Short
    Declare Function CTR_Update Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal CCount As Integer) As Short
    Declare Function CTR_8554_ClkSrc_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal ClockSource As Short) As Short
    Declare Function CTR_8554_CK1_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ClockSource As Short) As Short
    Declare Function CTR_8554_Debounce_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal DebounceClock As Short) As Short
    Declare Function GCTR_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByVal GCtrCtrl As Short, ByVal CCount As Integer) As Short
    Declare Function GCTR_Clear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short) As Short
    Declare Function GCTR_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByRef Value As Integer) As Short
    Declare Function GPTC_Clear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short) As Short
    Declare Function GPTC_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByVal ParamID As Short, ByVal Value As Short) As Short
    Declare Function GPTC_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Enabled As Short, ByVal EventType As Short, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function GPTC_EventSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByVal Mode As Short, ByVal Ctrl As Short, ByVal LVal_1 As Integer, ByVal LVal_2 As Integer) As Short
    Declare Function GPTC_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByRef Value As Integer) As Short
    Declare Function GPTC_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByVal Mode As Short, ByVal SrcCtrl As Short, ByVal PolCtrl As Short, ByVal LReg1_Val As Integer, ByVal LReg2_Val As Integer) As Short
    Declare Function GPTC_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByRef Value As Short) As Short
    Declare Function GPTC_9524_PG_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByVal PulseGenNum As Integer) As Short
    Declare Function GPTC_9524_GetTimerEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal GCtr As Short, ByRef hEvent As Integer) As Short
    Declare Function WDT_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal ovflowSec As Single, ByRef actualSec As Single, ByRef hEvent As Integer) As Short
    Declare Function WDT_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal action As Short) As Short
    Declare Function WDT_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByRef Value As Integer) As Short
    Declare Function WDT_Reload Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ovflowSec As Single, ByRef actualSec As Single) As Short
    Declare Function AI_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef hEvent As Integer) As Short
    Declare Function AO_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef hEvent As Integer) As Short
    Declare Function DI_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef hEvent As Integer) As Short
    Declare Function DO_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef hEvent As Integer) As Short

    'Cal Function
    Declare Function PCI_DB_Auto_Calibration_ALL Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function PCI_Load_CAL_Data Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal bank As Short) As Short
    Declare Function PCI_EEPROM_CAL_Constant_Update Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal bank As Short) As Short
    Declare Function PCI9524_Acquire_AD_CalConst Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Group As Short, ByVal ADC_Range As Short, ByVal ADC_Speed As Short, ByRef CalDate As Integer, ByRef CalTemp As Single, ByRef ADC_offset As Integer, ByRef ADC_gain As Integer, ByRef Residual_offset As Double, ByRef Residual_scaling As Double) As Short
    Declare Function PCI9524_Acquire_DA_CalConst Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByRef CalDate As Integer, ByRef CalTemp As Single, ByRef DAC_offset As Byte, ByRef DAC_linearity As Byte, ByRef Gain_factor As Single) As Short
    Declare Function PCI9524_Read_EEProm Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ReadAddr As Short, ByRef ReadData As Byte) As Short
    Declare Function PCI9524_Read_RemoteSPI Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Addr As Short, ByRef RdData As Byte) As Short
    Declare Function PCI9524_Write_EEProm Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal WriteAddr As Short, ByRef WriteData As Byte) As Short
    Declare Function PCI9524_Write_RemoteSPI Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Addr As Short, ByVal WrtData As Byte) As Short

    'SSI Function
    Declare Function SSI_SourceConn Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal sigCode As Short) As Short
    Declare Function SSI_SourceDisConn Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal sigCode As Short) As Short
    Declare Function SSI_SourceClear Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short

    'PWM Function
    Declare Function PWM_Output Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal high_interval As Integer, ByVal low_interval As Integer) As Short
    Declare Function PWM_Stop Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short) As Short

    'I2C Function
    Declare Function I2C_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal I2C_Port As Short, ByVal I2C_Config As Short, ByVal I2C_SetupValue1 As Integer, ByVal I2C_SetupValue2 As Integer) As Short
    Declare Function I2C_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal I2C_Port As Short, ByVal I2C_CtrlParam As Short, ByVal I2C_CtrlValue As Integer) As Short
    Declare Function I2C_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal I2C_Port As Short, ByRef I2C_Status As Integer) As Short
    Declare Function I2C_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal I2C_Port As Short, ByVal I2C_SlaveAddr As Short, ByVal I2C_CmdAddrBytes As Short, ByVal I2C_DataBytes As Short, ByVal I2C_CmdAddr As Integer, ByRef I2C_Data As Integer) As Short
    Declare Function I2C_Write Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal I2C_Port As Short, ByVal I2C_SlaveAddr As Short, ByVal I2C_CmdAddrBytes As Short, ByVal I2C_DataBytes As Short, ByVal I2C_CmdAddr As Integer, ByVal I2C_Data As Integer) As Short

    'SPI Function
    Declare Function SPI_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal SPI_Port As Short, ByVal SPI_Config As Short, ByVal SPI_SetupValue1 As Integer, ByVal SPI_SetupValue2 As Integer) As Short
    Declare Function SPI_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal SPI_Port As Short, ByVal SPI_CtrlParam As Short, ByVal SPI_CtrlValue As Integer) As Short
    Declare Function SPI_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal SPI_Port As Short, ByRef SPI_Status As Integer) As Short
    Declare Function SPI_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal SPI_Port As Short, ByVal SPI_SlaveAddr As Short, ByVal SPI_CmdAddrBits As Short, ByVal SPI_DataBits As Short, ByVal SPI_FrontDummyBits As Short, ByVal SPI_CmdAddr As Integer, ByRef SPI_Data As Integer) As Short
    Declare Function SPI_Write Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal SPI_Port As Short, ByVal SPI_SlaveAddr As Short, ByVal SPI_CmdAddrBits As Short, ByVal SPI_DataBits As Short, ByVal SPI_FrontDummyBits As Short, ByVal SPI_TailDummyBits As Short, ByVal SPI_CmdAddr As Integer, ByVal SPI_Data As Integer) As Short

End Module
