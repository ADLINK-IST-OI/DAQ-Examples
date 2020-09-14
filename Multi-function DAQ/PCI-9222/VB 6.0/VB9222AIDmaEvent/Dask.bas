Attribute VB_Name = "DASK"
Option Explicit

'ADLink PCI Card Type
Global Const PCI_6208V = 1
Global Const PCI_6208A = 2
Global Const PCI_6308V = 3
Global Const PCI_6308A = 4
Global Const PCI_7200 = 5
Global Const PCI_7230 = 6
Global Const PCI_7233 = 7
Global Const PCI_7234 = 8
Global Const PCI_7248 = 9
Global Const PCI_7249 = 10
Global Const PCI_7250 = 11
Global Const PCI_7252 = 12
Global Const PCI_7296 = 13
Global Const PCI_7300A_RevA = 14
Global Const PCI_7300A_RevB = 15
Global Const PCI_7432 = 16
Global Const PCI_7433 = 17
Global Const PCI_7434 = 18
Global Const PCI_8554 = 19
Global Const PCI_9111DG = 20
Global Const PCI_9111HR = 21
Global Const PCI_9112 = 22
Global Const PCI_9113 = 23
Global Const PCI_9114DG = 24
Global Const PCI_9114HG = 25
Global Const PCI_9118DG = 26
Global Const PCI_9118HG = 27
Global Const PCI_9118HR = 28
Global Const PCI_9810 = 29
Global Const PCI_9812 = 30
Global Const PCI_7396 = 31
Global Const PCI_9116 = 32
Global Const PCI_7256 = 33
Global Const PCI_7258 = 34
Global Const PCI_7260 = 35
Global Const PCI_7452 = 36
Global Const PCI_7442 = 37
Global Const PCI_7443 = 38
Global Const PCI_7444 = 39
Global Const PCI_9221 = 40
Global Const PCI_9524 = 41
Global Const PCI_6202 = 42
Global Const PCI_9222 = 43
Global Const PCI_9223 = 44
Global Const PCI_7433C = 45
Global Const PCI_7434C = 46
Global Const PCI_922A = 47
Global Const PCI_7350 = 48

Global Const MAX_CARD = 32

'Error Code
Global Const NoError = 0
Global Const ErrorUnknownCardType = -1
Global Const ErrorInvalidCardNumber = -2
Global Const ErrorTooManyCardRegistered = -3
Global Const ErrorCardNotRegistered = -4
Global Const ErrorFuncNotSupport = -5
Global Const ErrorInvalidIoChannel = -6
Global Const ErrorInvalidAdRange = -7
Global Const ErrorContIoNotAllowed = -8
Global Const ErrorDiffRangeNotSupport = -9
Global Const ErrorLastChannelNotZero = -10
Global Const ErrorChannelNotDescending = -11
Global Const ErrorChannelNotAscending = -12
Global Const ErrorOpenDriverFailed = -13
Global Const ErrorOpenEventFailed = -14
Global Const ErrorTransferCountTooLarge = -15
Global Const ErrorNotDoubleBufferMode = -16
Global Const ErrorInvalidSampleRate = -17
Global Const ErrorInvalidCounterMode = -18
Global Const ErrorInvalidCounter = -19
Global Const ErrorInvalidCounterState = -20
Global Const ErrorInvalidBinBcdParam = -21
Global Const ErrorBadCardType = -22
Global Const ErrorInvalidDaRange = -23
Global Const ErrorAdTimeOut = -24
Global Const ErrorNoAsyncAI = -25
Global Const ErrorNoAsyncAO = -26
Global Const ErrorNoAsyncDI = -27
Global Const ErrorNoAsyncDO = -28
Global Const ErrorNotInputPort = -29
Global Const ErrorNotOutputPort = -30
Global Const ErrorInvalidDioPort = -31
Global Const ErrorInvalidDioLine = -32
Global Const ErrorContIoActive = -33
Global Const ErrorDblBufModeNotAllowed = -34
Global Const ErrorConfigFailed = -35
Global Const ErrorInvalidPortDirection = -36
Global Const ErrorBeginThreadError = -37
Global Const ErrorInvalidPortWidth = -38
Global Const ErrorInvalidCtrSource = -39
Global Const ErrorOpenFile = -40
Global Const ErrorAllocateMemory = -41
Global Const ErrorDaVoltageOutOfRange = -42
Global Const ErrorDaExtRefNotAllowed = -43
Global Const ErrorDIODataWidthError = -44
Global Const ErrorTaskCodeError = -45
Global Const ErrortriggercountError = -46
Global Const ErrorInvalidTriggerMode = -47
Global Const ErrorInvalidTriggerType = -48
Global Const ErrorInvalidCounterValue = -50
Global Const ErrorInvalidEventHandle = -60
Global Const ErrorNoMessageAvailable = -61
Global Const ErrorEventMessgaeNotAdded = -62
Global Const ErrorCalibrationTimeOut = -63
Global Const ErrorUndefinedParameter = -64
Global Const ErrorInvalidBufferID = -65
Global Const ErrorInvalidSampledClock = -66
Global Const ErrorInvalisOperationMode = -67

'Error code for driver API
Global Const ErrorConfigIoctl = -201
Global Const ErrorAsyncSetIoctl = -202
Global Const ErrorDBSetIoctl = -203
Global Const ErrorDBHalfReadyIoctl = -204
Global Const ErrorContOPIoctl = -205
Global Const ErrorContStatusIoctl = -206
Global Const ErrorPIOIoctl = -207
Global Const ErrorDIntSetIoctl = -208
Global Const ErrorWaitEvtIoctl = -209
Global Const ErrorOpenEvtIoctl = -210
Global Const ErrorCOSIntSetIoctl = -211
Global Const ErrorMemMapIoctl = -212
Global Const ErrorMemUMapSetIoctl = -213
Global Const ErrorCTRIoctl = -214
Global Const ErrorGetResIoctl = -215
Global Const ErrorCalIoctl = -216
Global Const ErrorPMIntSetIoctl = -217

'AD Range
Global Const AD_B_10_V = 1
Global Const AD_B_5_V = 2
Global Const AD_B_2_5_V = 3
Global Const AD_B_1_25_V = 4
Global Const AD_B_0_625_V = 5
Global Const AD_B_0_3125_V = 6
Global Const AD_B_0_5_V = 7
Global Const AD_B_0_05_V = 8
Global Const AD_B_0_005_V = 9
Global Const AD_B_1_V = 10
Global Const AD_B_0_1_V = 11
Global Const AD_B_0_01_V = 12
Global Const AD_B_0_001_V = 13
Global Const AD_U_20_V = 14
Global Const AD_U_10_V = 15
Global Const AD_U_5_V = 16
Global Const AD_U_2_5_V = 17
Global Const AD_U_1_25_V = 18
Global Const AD_U_1_V = 19
Global Const AD_U_0_1_V = 20
Global Const AD_U_0_01_V = 21
Global Const AD_U_0_001_V = 22
Global Const AD_B_2_V = 23
Global Const AD_B_0_25_V = 24
Global Const AD_B_0_2_V = 25
Global Const AD_U_4_V = 26
Global Const AD_U_2_V = 27
Global Const AD_U_0_5_V = 28
Global Const AD_U_0_4_V = 29

'Synchronous Mode
Global Const SYNCH_OP = 1
Global Const ASYNCH_OP = 2

'AO Terminate Mode
Global Const DA_TerminateImmediate = 0

'Trigger Source
Global Const TRIG_SOFTWARE = 0
Global Const TRIG_INT_PACER = 1
Global Const TRIG_EXT_STROBE = 2
Global Const TRIG_HANDSHAKE = 3
Global Const TRIG_CLK_10MHZ = 4        'PCI-7300A
Global Const TRIG_CLK_20MHZ = 5        'PCI-7300A
Global Const TRIG_DO_CLK_TIMER_ACK = 6 'PCI-7300A Rev. B
Global Const TRIG_DO_CLK_10M_ACK = 7   'PCI-7300A Rev. B
Global Const TRIG_DO_CLK_20M_ACK = 8   'PCI-7300A Rev. B

'Virtual sampling rate for using external clock as the clock source
Global Const CLKSRC_EXT_SampRate = 10000

'--------- Constants for PCI-6208A --------------
'Output Mode
Global Const P6208_CURRENT_0_20MA = 0
Global Const P6208_CURRENT_5_25MA = 1
Global Const P6208_CURRENT_4_20MA = 3

'--------- Constants for PCI-6308A/PCI-6308V --------------
'Output Mode
Global Const P6308_CURRENT_0_20MA = 0
Global Const P6308_CURRENT_5_25MA = 1
Global Const P6308_CURRENT_4_20MA = 3
'AO Setting
Global Const P6308V_AO_CH0_3 = 0
Global Const P6308V_AO_CH4_7 = 1
Global Const P6308V_AO_UNIPOLAR = 0
Global Const P6308V_AO_BIPOLAR = 1

'--------- Constants for PCI-7200 --------------
'InputMode
Global Const DI_WAITING = &H2
Global Const DI_NOWAITING = &H0

Global Const DI_TRIG_RISING = &H4
Global Const DI_TRIG_FALLING = &H0

Global Const IREQ_RISING = &H8
Global Const IREQ_FALLING = &H0

'Output Mode
Global Const OREQ_ENABLE = &H10
Global Const OREQ_DISABLE = &H0

Global Const OTRIG_HIGH = &H20
Global Const OTRIG_LOW = &H0

'--------- Constants for PCI-7248/7296/7442 --------------
'DIO Port Direction
Global Const INPUT_PORT = 1
Global Const OUTPUT_PORT = 2
'DIO Line Direction
Global Const INPUT_LINE = 1
Global Const OUTPUT_LINE = 2

'Channel&Port
Global Const Channel_P1A = 0
Global Const Channel_P1B = 1
Global Const Channel_P1C = 2
Global Const Channel_P1CL = 3
Global Const Channel_P1CH = 4
Global Const Channel_P1AE = 10
Global Const Channel_P1BE = 11
Global Const Channel_P1CE = 12
Global Const Channel_P2A = 5
Global Const Channel_P2B = 6
Global Const Channel_P2C = 7
Global Const Channel_P2CL = 8
Global Const Channel_P2CH = 9
Global Const Channel_P2AE = 15
Global Const Channel_P2BE = 16
Global Const Channel_P2CE = 17
Global Const Channel_P3A = 10
Global Const Channel_P3B = 11
Global Const Channel_P3C = 12
Global Const Channel_P3CL = 13
Global Const Channel_P3CH = 14
Global Const Channel_P4A = 15
Global Const Channel_P4B = 16
Global Const Channel_P4C = 17
Global Const Channel_P4CL = 18
Global Const Channel_P4CH = 19
Global Const Channel_P5A = 20
Global Const Channel_P5B = 21
Global Const Channel_P5C = 22
Global Const Channel_P5CL = 23
Global Const Channel_P5CH = 24
Global Const Channel_P6A = 25
Global Const Channel_P6B = 26
Global Const Channel_P6C = 27
Global Const Channel_P6CL = 28
Global Const Channel_P6CH = 29
Global Const Channel_P1 = 30
Global Const Channel_P2 = 31
Global Const Channel_P3 = 32
Global Const Channel_P4 = 33
Global Const Channel_P1E = 34
Global Const Channel_P2E = 35
Global Const Channel_P3E = 36
Global Const Channel_P4E = 37

Global Const P7442_CH0 = 0
Global Const P7442_CH1 = 1
Global Const P7442_TTL0 = 2
Global Const P7442_TTL1 = 3

Global Const P7443_CH0 = 0
Global Const P7443_CH1 = 1
Global Const P7443_CH2 = 2
Global Const P7443_CH3 = 3
Global Const P7443_TTL0 = 4
Global Const P7443_TTL1 = 5

Global Const P7444_CH0 = 0
Global Const P7444_CH1 = 1
Global Const P7444_CH2 = 2
Global Const P7444_CH3 = 3
Global Const P7444_TTL0 = 4
Global Const P7444_TTL1 = 5

'--------- Constants for PCI-7300A --------------
'Wait Status
Global Const P7300_WAIT_NO = 0
Global Const P7300_WAIT_TRG = 1
Global Const P7300_WAIT_FIFO = 2
Global Const P7300_WAIT_BOTH = 3

'Terminator control
Global Const P7300_TERM_OFF = 0
Global Const P7300_TERM_ON = 1

'DI control signals polarity for PCI-7300A Rev. B
Global Const P7300_DIREQ_POS = &H0
Global Const P7300_DIREQ_NEG = &H1
Global Const P7300_DIACK_POS = &H0
Global Const P7300_DIACK_NEG = &H2
Global Const P7300_DITRIG_POS = &H0
Global Const P7300_DITRIG_NEG = &H4

'DO control signals polarity for PCI-7300A Rev. B
Global Const P7300_DOREQ_POS = &H0
Global Const P7300_DOREQ_NEG = &H8
Global Const P7300_DOACK_POS = &H0
Global Const P7300_DOACK_NEG = &H10
Global Const P7300_DOTRIG_POS = &H0
Global Const P7300_DOTRIG_NEG = &H20

'DO Disable mode in DO_AsyncClear
Global Const P7300_DODisableDOEnabled = 0
Global Const P7300_DONotDisableDOEnabled = 1

'--------- Constants for PCI-7432/7433/7434/7433C/7434C --------------
Global Const CHANNEL_DI_LOW = 0
Global Const CHANNEL_DI_HIGH = 1
Global Const CHANNEL_DO_LOW = 0
Global Const CHANNEL_DO_HIGH = 1
Global Const P7432R_DO_LED = 1
Global Const P7433R_DO_LED = 0
Global Const P7434R_DO_LED = 2
Global Const P7432R_DI_SLOT = 1
Global Const P7433R_DI_SLOT = 2
Global Const P7434R_DI_SLOT = 0

'----- Dual-Interrupt Source control for PCI-7248/49/96 & 7230 & 8554 & 7396 &7256/58 & 7260 & 7433C -----
Global Const INT1_NC = -1               'INT1 Unchanged
Global Const INT1_DISABLE = -1          'INT1 Disabled
Global Const INT1_COS = 0               'INT1 COS : only available for PCI-7396, PCI-7256/58 & PCI-7260
Global Const INT1_FP1C0 = 1             'INT1 by Falling edge of P1C0
Global Const INT1_RP1C0_FP1C3 = 2       'INT1 by P1C0 Rising or P1C3 Falling
Global Const INT1_EVENT_COUNTER = 3     'INT1 by Event Counter down to zero
Global Const INT1_EXT_SIGNAL = 1        'INT1 by external signal : only available for PCI7432/PCI7433/PCI7230
Global Const INT1_COUT12 = 1            'INT1 COUT12 : only available for PCI8554
Global Const INT1_CH0 = 1               'INT1 CH0 : only available for PCI7256/58/60
Global Const INT1_COS0 = 1              'INT1 COS0 : only available for PCI-7452
Global Const INT1_COS1 = 2              'INT1 COS1 : only available for PCI-7452
Global Const INT1_COS2 = 3              'INT1 COS2 : only available for PCI-7452
Global Const INT1_COS3 = 8              'INT1 COS3 : only available for PCI-7452
Global Const INT2_NC = -1               'INT2 Unchanged
Global Const INT2_DISABLE = -1          'INT2 Disabled
Global Const INT2_COS = 0               'INT2 COS : only available for PCI-7396
Global Const INT2_FP2C0 = 1             'INT2 by Falling edge of P2C0
Global Const INT2_RP2C0_FP2C3 = 2       'INT2 by P2C0 Rising or P2C3 Falling
Global Const INT2_TIMER_COUNTER = 3     'INT2 by Timer Counter down to zero
Global Const INT2_EXT_SIGNAL = 1        'INT2 by external signal : only available for PCI7432/PCI7433/PCI7230
Global Const INT2_CH1 = 2               'INT2 CH1 : only available for PCI7256/58/60
Global Const INT2_WDT = 4               'INT2 by WDT

Global Const WDT_OVRFLOW_SAFETYOUT = &H8000 'enable safteyout while WDT overflow
'-------- Constants for PCI-8554 --------------------
'Clock Source of Cunter N
Global Const ECKN = 0
Global Const COUTN_1 = 1
Global Const CK1 = 2
Global Const COUT10 = 3

'Clock Source of CK1
Global Const CK1_C8M = 0
Global Const CK1_COUT11 = 1

'Debounce Clock
Global Const DBCLK_COUT11 = 0
Global Const DBCLK_2MHZ = 1

'--------- Constants for PCI-9111 --------------
'Dual Interrupt Mode
Global Const P9111_INT1_EOC = 0     'Ending of AD conversion
Global Const P9111_INT1_FIFO_HF = 1 'FIFO Half Full
Global Const P9111_INT2_PACER = 0   'Every Timer tick
Global Const P9111_INT2_EXT_TRG = 1 'ExtTrig High->Low

'Channel Count
Global Const P9111_CHANNEL_DO = 0
Global Const P9111_CHANNEL_EDO = 1
Global Const P9111_CHANNEL_DI = 0
Global Const P9111_CHANNEL_EDI = 1

'Trigger Mode
Global Const P9111_TRGMOD_SOFT = 0 'Software Trigger Mode
Global Const P9111_TRGMOD_PRE = 1  'Pre-Trigger Mode
Global Const P9111_TRGMOD_POST = 2 'Post Trigger Mode

'EDO function
Global Const P9111_EDO_INPUT = 1   'EDO port set as Input port
Global Const P9111_EDO_OUT_EDO = 2 'EDO port set as Output port
Global Const P9111_EDO_OUT_CHN = 3 'EDO port set as channel number ouput port

'AO Setting
Global Const P9111_AO_UNIPOLAR = 0
Global Const P9111_AO_BIPOLAR = 1

'--------- Constants for PCI-9118 --------------
Global Const P9118_AI_BiPolar = &H0
Global Const P9118_AI_UniPolar = &H1

Global Const P9118_AI_SingEnded = &H0
Global Const P9118_AI_Differential = &H2

Global Const P9118_AI_ExtG = &H4

Global Const P9118_AI_ExtTrig = &H8

Global Const P9118_AI_DtrgNegative = &H0
Global Const P9118_AI_DtrgPositive = &H10

Global Const P9118_AI_EtrgNegative = &H0
Global Const P9118_AI_EtrgPositive = &H20

Global Const P9118_AI_BurstModeEn = &H40
Global Const P9118_AI_SampleHold = &H80
Global Const P9118_AI_PostTrgEn = &H100
Global Const P9118_AI_AboutTrgEn = &H200

'--------- Constants for PCI-9812/9810 --------------
'Channel Count
Global Const P9116_AI_LocalGND = &H0
Global Const P9116_AI_UserCMMD = &H1
Global Const P9116_AI_SingEnded = &H0
Global Const P9116_AI_Differential = &H2
Global Const P9116_AI_BiPolar = &H0
Global Const P9116_AI_UniPolar = &H4

Global Const P9116_TRGMOD_SOFT = &H0   'Software Trigger Mode
Global Const P9116_TRGMOD_POST = &H10  'Post Trigger Mode
Global Const P9116_TRGMOD_DELAY = &H20 'Delay Trigger Mode
Global Const P9116_TRGMOD_PRE = &H30   'Pre-Trigger Mode
Global Const P9116_TRGMOD_MIDL = &H40  'Middle Trigger Mode
Global Const P9116_AI_TrgPositive = &H0
Global Const P9116_AI_TrgNegative = &H80
Global Const P9116_AI_IntTimeBase = &H0
Global Const P9116_AI_ExtTimeBase = &H100
Global Const P9116_AI_DlyInSamples = &H200
Global Const P9116_AI_DlyInTimebase = &H0
Global Const P9116_AI_ReTrigEn = &H400
Global Const P9116_AI_MCounterEn = &H800
Global Const P9116_AI_SoftPolling = &H0
Global Const P9116_AI_INT = &H1000
Global Const P9116_AI_DMA = &H2000

'--------- Constants for PCI-9812/9810 --------------
'Channel Count
Global Const P9812_CHANNEL_CNT1 = 1
Global Const P9812_CHANNEL_CNT2 = 2
Global Const P9812_CHANNEL_CNT4 = 4

'Trigger Mode
Global Const P9812_TRGMOD_SOFT = 0        'Software Trigger Mode
Global Const P9812_TRGMOD_POST = 1        'Post Trigger Mode
Global Const P9812_TRGMOD_PRE = 2         'Pre-Trigger Mode
Global Const P9812_TRGMOD_DELAY = 3       'Delay Trigger Mode
Global Const P9812_TRGMOD_MIDL = 4        'Middle Trigger Mode

'Trigger Source
Global Const P9812_TRGSRC_CH0 = 0         'trigger source --CH0
Global Const P9812_TRGSRC_CH1 = 8         'trigger source --CH1
Global Const P9812_TRGSRC_CH2 = &H10      'trigger source --CH2
Global Const P9812_TRGSRC_CH3 = &H18      'trigger source --CH3
Global Const P9812_TRGSRC_EXT_DIG = &H20  'External Digital Trigger

'Trigger Polarity
Global Const P9812_TRGSLP_POS = 0         'Positive slope trigger
Global Const P9812_TRGSLP_NEG = &H40      'Negative slope trigger

'Frequency Selection
Global Const P9812_AD2_GT_PCI = &H80      'Freq. of A/D clock > PCI clock freq.
Global Const P9812_AD2_LT_PCI = &H0       'Freq. of A/D clock < PCI clock freq.

'Clock Source
Global Const P9812_CLKSRC_INT = &H0       'Internal clock
Global Const P9812_CLKSRC_EXT_SIN = &H100 'External SIN wave clock
Global Const P9812_CLKSRC_EXT_DIG = &H200 'External Square wave clock

'-------- Constants for PCI-9221 --------------------
Global Const P9221_AI_SingEnded = 0
Global Const P9221_AI_NonRef_SingEnded = 1
Global Const P9221_AI_Differential = 2

'Trigger Mode
Global Const P9221_TRGMOD_SOFT = 0
Global Const P9221_TRGMOD_ExtD = 8

'Trigger Source
Global Const P9221_TRGSRC_GPI0 = 0
Global Const P9221_TRGSRC_GPI1 = 1
Global Const P9221_TRGSRC_GPI2 = 2
Global Const P9221_TRGSRC_GPI3 = 3
Global Const P9221_TRGSRC_GPI4 = 4
Global Const P9221_TRGSRC_GPI5 = 5
Global Const P9221_TRGSRC_GPI6 = 6
Global Const P9221_TRGSRC_GPI7 = 7

'Trigger Polarity
Global Const P9221_AI_TrgPositive = 0
Global Const P9221_AI_TrgNegative = &H10

'TimeBase Mode
Global Const P9221_AI_IntTimeBase = 0
Global Const P9221_AI_ExtTimeBase = &H80

'TimeBase Source
Global Const P9221_TimeBaseSRC_GPI0 = 0
Global Const P9221_TimeBaseSRC_GPI1 = &H10
Global Const P9221_TimeBaseSRC_GPI2 = &H20
Global Const P9221_TimeBaseSRC_GPI3 = &H30
Global Const P9221_TimeBaseSRC_GPI4 = &H40
Global Const P9221_TimeBaseSRC_GPI5 = &H50
Global Const P9221_TimeBaseSRC_GPI6 = &H60
Global Const P9221_TimeBaseSRC_GPI7 = &H70


'DAQ Event type for the event message
Global Const AIEnd = 0
Global Const AOEnd = 0
Global Const DIEnd = 0
Global Const DOEnd = 0
Global Const DBEvent = 1
Global Const TrigEvent = 2

'EMG shdn ctrl code
Global Const EMGSHDN_OFF = 0      'off
Global Const EMGSHDN_ON = 1       'on
Global Const EMGSHDN_RECOVERY = 2 'recovery

'Hot Reset Hold ctrl code
Global Const HRH_OFF = 0 'off
Global Const HRH_ON = 1 'on

'COS Counter OP
Global Const COS_COUNTER_RESET = 0
Global Const COS_COUNTER_SETUP = 1
Global Const COS_COUNTER_START = 2
Global Const COS_COUNTER_STOP = 3
Global Const COS_COUNTER_READ = 4

'--------- Constants for Timer/Counter --------------
'Counter Mode (8254)
Global Const TOGGLE_OUTPUT = 0             'Toggle output from low to high on terminal count
Global Const PROG_ONE_SHOT = 1             'Programmable one-shot
Global Const RATE_GENERATOR = 2            'Rate generator
Global Const SQ_WAVE_RATE_GENERATOR = 3    'Square wave rate generator
Global Const SOFT_TRIG = 4                 'Software-triggered strobe
Global Const HARD_TRIG = 5                 'Hardware-triggered strobe

'------- General Purpose Timer/Counter -----------------
'Counter Mode
Global Const General_Counter = &H0  'general counter
Global Const Pulse_Generation = &H1 'pulse generation
'GPTC clock source
Global Const GPTC_CLKSRC_Ext = &H8
Global Const GPTC_CLKSRC_Int = &H0
Global Const GPTC_GATESRC_Ext = &H10
Global Const GPTC_GATESRC_Int = &H0
Global Const GPTC_UPDOWN_SELECT_EXT = &H20
Global Const GPTC_UPDOWN_SELECT_SOFT = &H0
Global Const GPTC_UP_CTR = &H40
Global Const GPTC_DOWN_CTR = &H0
Global Const GPTC_ENABLE = &H80
Global Const GPTC_DISABLE = &H0

'General Purpose Timer/Counter for 9221
'Counter Mode
Global Const SimpleGatedEventCNT = 1
Global Const SinglePeriodMSR = 2
Global Const SinglePulseWidthMSR = 3
Global Const SingleGatedPulseGen = 4
Global Const SingleTrigPulseGen = 5
Global Const RetrigSinglePulseGen = 6
Global Const SingleTrigContPulseGen = 7
Global Const ContGatedPulseGen = 8
Global Const EdgeSeparationMSR = 9
Global Const SingleTrigContPulseGenPWM = 10
Global Const ContGatedPulseGenPWM = 11
Global Const CW_CCW_Encoder = 12
Global Const x1_AB_Phase_Encoder = 13
Global Const x2_AB_Phase_Encoder = 14
Global Const x4_AB_Phase_Encoder = 15
Global Const Phase_Z = 16

'GPTC clock source
Global Const GPTC_CLK_SRC_Ext = 1
Global Const GPTC_CLK_SRC_Int = 0
Global Const GPTC_GATE_SRC_Ext = 2
Global Const GPTC_GATE_SRC_Int = 0
Global Const GPTC_UPDOWN_Ext = 4
Global Const GPTC_UPDOWN_Int = 0

'GPTC clock polarity
Global Const GPTC_CLKSRC_LACTIVE = 1
Global Const GPTC_CLKSRC_HACTIVE = 0
Global Const GPTC_GATE_LACTIVE = 2
Global Const GPTC_GATE_HACTIVE = 0
Global Const GPTC_UPDOWN_LACTIVE = 4
Global Const GPTC_UPDOWN_HACTIVE = 0
Global Const GPTC_OUTPUT_LACTIVE = 8
Global Const GPTC_OUTPUT_HACTIVE = 0

Global Const IntGate = 0
Global Const IntUpDnCTR = 1
Global Const IntENABLE = 2

Global Const GPTC_EZ0_ClearPhase0 = 0
Global Const GPTC_EZ0_ClearPhase1 = 1
Global Const GPTC_EZ0_ClearPhase2 = 2
Global Const GPTC_EZ0_ClearPhase3 = 3

Global Const GPTC_EZ0_ClearMode0 = 0
Global Const GPTC_EZ0_ClearMode1 = 1
Global Const GPTC_EZ0_ClearMode2 = 2
Global Const GPTC_EZ0_clearMode3 = 3

'Watchdog Timer
'Counter action
Global Const WDT_DISARM = 0
Global Const WDT_ARM = 1
Global Const WDT_RESTART = 2

'Pattern ID
Global Const INIT_PTN = 0
Global Const EMGSHDN_PTN = 1

'Pattern ID for 7442
Global Const INIT_PTN_CH0 = 0
Global Const INIT_PTN_CH1 = 1
Global Const INIT_PTN_CH2 = 2
Global Const INIT_PTN_CH3 = 3
Global Const SAFTOUT_PTN_CH0 = 4
Global Const SAFTOUT_PTN_CH1 = 5
Global Const SAFTOUT_PTN_CH2 = 6
Global Const SAFTOUT_PTN_CH3 = 7

'16-bit binary or 4-decade BCD counter
Global Const BIN = 0
Global Const BCD = 1

'EEPROM
Global Const EEPROM_DEFAULT_BANK = 0
Global Const EEPROM_USER_BANK1 = 1


'----------- 9524 Const -----------------
'AI Interrupt
Global Const P9524_INT_LC_EOC = 2
Global Const P9524_INT_GP_EOC = 3
'DSP Constants
Global Const P9524_SPIKE_REJ_DISABLE = 0
Global Const P9524_SPIKE_REJ_ENABLE = 1
'AI Transfer Mode
Global Const P9524_AI_XFER_POLL = 0
Global Const P9524_AI_XFER_DMA = 1
'AI Poll all channels
Global Const P9524_AI_POLL_ALLCHANNELS = 8
Global Const P9524_AI_POLLSCANS_CH0_CH3 = 8
Global Const P9524_AI_POLLSCANS_CH0_CH2 = 9
Global Const P9524_AI_POLLSCANS_CH0_CH1 = 10
'AI Transfer Speed
Global Const P9524_ADC_30K_SPS = 0
Global Const P9524_ADC_15K_SPS = 1
Global Const P9524_ADC_7K5_SPS = 2
Global Const P9524_ADC_3K75_SPS = 3
Global Const P9524_ADC_2K_SPS = 4
Global Const P9524_ADC_1K_SPS = 5
Global Const P9524_ADC_500_SPS = 6
Global Const P9524_ADC_100_SPS = 7
Global Const P9524_ADC_60_SPS = 8
Global Const P9524_ADC_50_SPS = 9
Global Const P9524_ADC_30_SPS = 10
Global Const P9524_ADC_25_SPS = 11
Global Const P9524_ADC_15_SPS = 12
Global Const P9524_ADC_10_SPS = 13
Global Const P9524_ADC_5_SPS = 14
Global Const P9524_ADC_2R5_SPS = 15
'AI Configuration Mode
Global Const P9524_VEX_Range_2R5V = &H0
Global Const P9524_VEX_Range_10V = &H1
Global Const P9524_VEX_Sence_Local = &H0
Global Const P9524_VEX_Sence_Remote = &H2
Global Const P9524_AI_AZMode = &H4
Global Const P9524_AI_BufAutoReset = &H8
Global Const P9524_AI_EnEOCInt = &H10
'AI Trigger configuration
Global Const P9524_TRGMOD_POST = 0
Global Const P9524_TRGSRC_SOFT = 0
Global Const P9524_TRGSRC_ExtD = 1
Global Const P9524_TRGSRC_SSI = 2
Global Const P9524_TRGSRC_QD0 = 3
Global Const P9524_TRGSRC_PG0 = 4
Global Const P9524_AI_TrgPositive = 0
Global Const P9524_AI_TrgNegative = 8
'AI Group
Global Const P9524_AI_LC_Group = 0
Global Const P9524_AI_GP_Group = 1
'AI Channel
Global Const P9524_AI_LC_CH0 = 0
Global Const P9524_AI_LC_CH1 = 1
Global Const P9524_AI_LC_CH2 = 2
Global Const P9524_AI_LC_CH3 = 3
Global Const P9524_AI_GP_CH0 = 4
Global Const P9524_AI_GP_CH1 = 5
Global Const P9524_AI_GP_CH2 = 6
Global Const P9524_AI_GP_CH3 = 7

'Counter Number
Global Const P9524_CTR_PG0 = 0
Global Const P9524_CTR_PG1 = 1
Global Const P9524_CTR_PG2 = 2
Global Const P9524_CTR_QD0 = 3
Global Const P9524_CTR_QD1 = 4
Global Const P9524_CTR_QD2 = 5
Global Const P9524_CTR_INTCOUNTER = 6
'Counter Mode
Global Const P9524_PulseGen_OUTDIR_N = 0
Global Const P9524_PulseGen_OUTDIR_R = 1
Global Const P9524_PulseGen_CW = 0
Global Const P9524_PulseGen_CCW = 2
Global Const P9524_x4_AB_Phase_Decoder = 3
Global Const P9524_Timer = 4
'Counter Op
Global Const P9524_CTR_Enable = 0
'Event Mode
Global Const P9524_Event_Timer = 0

'AO
Global Const P9524_AO_CH0_1 = 0


'------Constants for PCI-6202------
Global Const P6202_ISO0 = 0
Global Const P6202_TTL0 = 1

Global Const P6202_GPTC0 = 0
Global Const P6202_GPTC1 = 1
Global Const P6202_ENCODER0 = 2
Global Const P6202_ENCODER1 = 3
Global Const P6202_ENCODER2 = 4

'DA control constant
Global Const P6202_DA_WRSRC_Int = 0
Global Const P6202_DA_WRSRC_AFI0 = 1
Global Const P6202_DA_WRSRC_SSI = 2
Global Const P6202_DA_WRSRC_AFI1 = 3

'DA trigger constant
Global Const P6202_DA_TRGSRC_SOFT = &H0
Global Const P6202_DA_TRGSRC_AFI0 = &H1
Global Const P6202_DA_TRSRC_SSI = &H2
Global Const P6202_DA_TRGSRC_AFI1 = &H3
Global Const P6202_DA_TRGMOD_POST = &H0
Global Const P6202_DA_TRGMOD_DELAY = &H4
Global Const P6202_DA_ReTrigEn = &H20
Global Const P6202_DA_DLY2En = &H100

'SSI signal code
Global Const P6202_SSI_DA_CONV = &H4
Global Const P6202_SSI_DA_TRIG = &H40

'Encoder constant
Global Const P6202_EVT_TYPE_EPT0 = &H0
Global Const P6202_EVT_TYPE_EPT1 = &H1
Global Const P6202_EVT_TYPE_EPT2 = &H2
Global Const P6202_EVT_TYPE_EZC0 = &H3
Global Const P6202_EVT_TYPE_EZC1 = &H4
Global Const P6202_EVT_TYPE_EZC2 = &H5

Global Const P6202_EVT_MOD_EPT = &H0

Global Const P6202_EPT_PULWIDTH_200us = &H0
Global Const P6202_EPT_PULWIDTH_2ms = &H1
Global Const P6202_EPT_PULWIDTH_20ms = &H2
Global Const P6202_EPT_PULWIDTH_200ms = &H3

Global Const P6202_EPT_TRGOUT_CALLBACK = &H4
Global Const P6202_EPT_TRGOUT_AFI = &H8

Global Const P6202_ENCODER0_LDATA = &H5
Global Const P6202_ENCODER1_LDATA = &H6
Global Const P6202_ENCODER2_LDATA = &H7

'------------------------'
' Constants for PCI-922x '
'------------------------'
'-- AI Constants --'
'Input Type
Global Const P922x_AI_SingEnded = &H0
Global Const P922x_AI_NonRef_SingEnded = &H1
Global Const P922x_AI_Differential = &H2
'Conversion Source
Global Const P922x_AI_CONVSRC_INT = &H0
Global Const P922x_AI_CONVSRC_GPI0 = &H10
Global Const P922x_AI_CONVSRC_GPI1 = &H20
Global Const P922x_AI_CONVSRC_GPI2 = &H30
Global Const P922x_AI_CONVSRC_GPI3 = &H40
Global Const P922x_AI_CONVSRC_GPI4 = &H50
Global Const P922x_AI_CONVSRC_GPI5 = &H60
Global Const P922x_AI_CONVSRC_GPI6 = &H70
Global Const P922x_AI_CONVSRC_GPI7 = &H80
Global Const P922x_AI_CONVSRC_SSI1 = &H90
Global Const P922x_AI_CONVSRC_SSI = &H90
'Trigger Mode
Global Const P922x_AI_TRGMOD_POST = &H0
Global Const P922x_AI_TRGMOD_GATED = &H1
'Trigger Source
Global Const P922x_AI_TRGSRC_SOFT = &H0
Global Const P922x_AI_TRGSRC_GPI0 = &H10
Global Const P922x_AI_TRGSRC_GPI1 = &H20
Global Const P922x_AI_TRGSRC_GPI2 = &H30
Global Const P922x_AI_TRGSRC_GPI3 = &H40
Global Const P922x_AI_TRGSRC_GPI4 = &H50
Global Const P922x_AI_TRGSRC_GPI5 = &H60
Global Const P922x_AI_TRGSRC_GPI6 = &H70
Global Const P922x_AI_TRGSRC_GPI7 = &H80
Global Const P922x_AI_TRGSRC_SSI5 = &H90
Global Const P922x_AI_TRGSRC_SSI = &H90
'Trigger Polarity
Global Const P922x_AI_TrgPositive = &H0
Global Const P922x_AI_TrgNegative = &H100
'ReTrigger
Global Const P922x_AI_EnReTigger = &H200

'-- AO Constants --'
'Conversion Source
Global Const P922x_AO_CONVSRC_INT = &H0
Global Const P922x_AO_CONVSRC_GPI0 = &H1
Global Const P922x_AO_CONVSRC_GPI1 = &H2
Global Const P922x_AO_CONVSRC_GPI2 = &H3
Global Const P922x_AO_CONVSRC_GPI3 = &H4
Global Const P922x_AO_CONVSRC_GPI4 = &H5
Global Const P922x_AO_CONVSRC_GPI5 = &H6
Global Const P922x_AO_CONVSRC_GPI6 = &H7
Global Const P922x_AO_CONVSRC_GPI7 = &H8
Global Const P922x_AO_CONVSRC_SSI2 = &H9
Global Const P922x_AO_CONVSRC_SSI = &H9
'Trigger Mode
Global Const P922x_AO_TRGMOD_POST = &H0
Global Const P922x_AO_TRGMOD_DELAY = &H1
'Trigger Source
Global Const P922x_AO_TRGSRC_SOFT = &H0
Global Const P922x_AO_TRGSRC_GPI0 = &H10
Global Const P922x_AO_TRGSRC_GPI1 = &H20
Global Const P922x_AO_TRGSRC_GPI2 = &H30
Global Const P922x_AO_TRGSRC_GPI3 = &H40
Global Const P922x_AO_TRGSRC_GPI4 = &H50
Global Const P922x_AO_TRGSRC_GPI5 = &H60
Global Const P922x_AO_TRGSRC_GPI6 = &H70
Global Const P922x_AO_TRGSRC_GPI7 = &H80
Global Const P922x_AO_TRGSRC_SSI6 = &H90
Global Const P922x_AO_TRGSRC_SSI = &H90
'Trigger Polarity
Global Const P922x_AO_TrgPositive = &H0
Global Const P922x_AO_TrgNegative = &H100
'Retrigger
Global Const P922x_AO_EnReTigger = &H200
'Delay 2
Global Const P922x_AO_EnDelay2 = &H400

'-- DI Constants --'
'Conversion Source
Global Const P922x_DI_CONVSRC_INT = &H0
Global Const P922x_DI_CONVSRC_GPI0 = &H1
Global Const P922x_DI_CONVSRC_GPI1 = &H2
Global Const P922x_DI_CONVSRC_GPI2 = &H3
Global Const P922x_DI_CONVSRC_GPI3 = &H4
Global Const P922x_DI_CONVSRC_GPI4 = &H5
Global Const P922x_DI_CONVSRC_GPI5 = &H6
Global Const P922x_DI_CONVSRC_GPI6 = &H7
Global Const P922x_DI_CONVSRC_GPI7 = &H8
Global Const P922x_DI_CONVSRC_ADCONV = &H9
Global Const P922x_DI_CONVSRC_DACONV = &HA
'Trigger Mode
Global Const P922x_DI_TRGMOD_POST = &H0
'Trigger Source
Global Const P922x_DI_TRGSRC_SOFT = &H0
Global Const P922x_DI_TRGSRC_GPI0 = &H10
Global Const P922x_DI_TRGSRC_GPI1 = &H20
Global Const P922x_DI_TRGSRC_GPI2 = &H30
Global Const P922x_DI_TRGSRC_GPI3 = &H40
Global Const P922x_DI_TRGSRC_GPI4 = &H50
Global Const P922x_DI_TRGSRC_GPI5 = &H60
Global Const P922x_DI_TRGSRC_GPI6 = &H70
Global Const P922x_DI_TRGSRC_GPI7 = &H80
'Trigger Polarity
Global Const P922x_DI_TrgPositive = &H0
Global Const P922x_DI_TrgNegative = &H100
'ReTrigger
Global Const P922x_DI_EnReTigger = &H200

'-- DO Constants --'
'Conversion Source
Global Const P922x_DO_CONVSRC_INT = &H0
Global Const P922x_DO_CONVSRC_GPI0 = &H1
Global Const P922x_DO_CONVSRC_GPI1 = &H2
Global Const P922x_DO_CONVSRC_GPI2 = &H3
Global Const P922x_DO_CONVSRC_GPI3 = &H4
Global Const P922x_DO_CONVSRC_GPI4 = &H5
Global Const P922x_DO_CONVSRC_GPI5 = &H6
Global Const P922x_DO_CONVSRC_GPI6 = &H7
Global Const P922x_DO_CONVSRC_GPI7 = &H8
Global Const P922x_DO_CONVSRC_ADCONV = &H9
Global Const P922x_DO_CONVSRC_DACONV = &HA
'Trigger Mode
Global Const P922x_DO_TRGMOD_POST = &H0
Global Const P922x_DO_TRGMOD_DELAY = &H1
'Trigger Source
Global Const P922x_DO_TRGSRC_SOFT = &H0
Global Const P922x_DO_TRGSRC_GPI0 = &H10
Global Const P922x_DO_TRGSRC_GPI1 = &H20
Global Const P922x_DO_TRGSRC_GPI2 = &H30
Global Const P922x_DO_TRGSRC_GPI3 = &H40
Global Const P922x_DO_TRGSRC_GPI4 = &H50
Global Const P922x_DO_TRGSRC_GPI5 = &H60
Global Const P922x_DO_TRGSRC_GPI6 = &H70
Global Const P922x_DO_TRGSRC_GPI7 = &H80
'Trigger Polarity
Global Const P922x_DO_TrgPositive = &H0
Global Const P922x_DO_TrgNegative = &H100
'Retrigger
Global Const P922x_DO_EnReTigger = &H200

'-- Encoder/GPTC Constants --'
Global Const P922x_GPTC0 = &H0
Global Const P922x_GPTC1 = &H1
Global Const P922x_GPTC2 = &H2
Global Const P922x_GPTC3 = &H3
Global Const P922x_ENCODER0 = &H4
Global Const P922x_ENCODER1 = &H5
'Encoder Setting Event Mode
Global Const P922x_EVT_MOD_EPT = &H0
'Encoder Setting Event Control
Global Const P922x_EPT_PULWIDTH_200us = &H0
Global Const P922x_EPT_PULWIDTH_2ms = &H1
Global Const P922x_EPT_PULWIDTH_20ms = &H2
Global Const P922x_EPT_PULWIDTH_200ms = &H3
Global Const P922x_EPT_TRGOUT_GPO = &H4
Global Const P922x_EPT_TRGOUT_CALLBACK = &H8
'Event Type
Global Const P922x_EVT_TYPE_EPT0 = &H0
Global Const P922x_EVT_TYPE_EPT1 = &H1

'SSI signal code
Global Const P922x_SSI_AI_CONV = &H2
Global Const P922x_SSI_AI_TRIG = &H20
Global Const P922x_SSI_AO_CONV = &H4
Global Const P922x_SSI_AO_TRIG = &H40

'
'Constants for PCIe-7350
'
Global Const P7350_PortDIO = 0
Global Const P7350_PortAFI = 1
'DIO Port
Global Const P7350_DIO_A = 0
Global Const P7350_DIO_B = 1
Global Const P7350_DIO_C = 2
Global Const P7350_DIO_D = 3
'AFI Port
Global Const P7350_AFI_0 = 0
Global Const P7350_AFI_1 = 1
Global Const P7350_AFI_2 = 2
Global Const P7350_AFI_3 = 3
Global Const P7350_AFI_4 = 4
Global Const P7350_AFI_5 = 5
Global Const P7350_AFI_6 = 6
Global Const P7350_AFI_7 = 7
'AFI Mode
Global Const P7350_AFI_DIStartTrig = 0
Global Const P7350_AFI_DOStartTrig = 1
Global Const P7350_AFI_DIPauseTrig = 2
Global Const P7350_AFI_DOPauseTrig = 3
Global Const P7350_AFI_DISWTrigOut = 4
Global Const P7350_AFI_DOSWTrigOut = 5
Global Const P7350_AFI_COSTrigOut = 6
Global Const P7350_AFI_PMTrigOut = 7
Global Const P7350_AFI_HSDIREQ = 8
Global Const P7350_AFI_HSDIACK = 9
Global Const P7350_AFI_HSDITRIG = 10
Global Const P7350_AFI_HSDOREQ = 11
Global Const P7350_AFI_HSDOACK = 12
Global Const P7350_AFI_HSDOTRIG = 13
Global Const P7350_AFI_SPI = 14
Global Const P7350_AFI_I2C = 15
Global Const P7350_POLL_DI = 16
Global Const P7350_POLL_DO = 17
'Operation Mode
Global Const P7350_FreeRun = 0
Global Const P7350_HandShake = 1
Global Const P7350_BurstHandShake = 2
'Trigger Status
Global Const P7350_WAIT_NO = 0
Global Const P7350_WAIT_EXTTRG = 1
Global Const P7350_WAIT_SOFTTRG = 2
'Sampled Clock
Global Const P7350_IntSampledCLK = &H0
Global Const P7350_ExtSampledCLK = &H1
'Sampled Clock Edge
Global Const P7350_SampledCLK_R = &H0
Global Const P7350_SampledCLK_F = &H2
'Enable Export Sample Clock*/
Global Const P7350_EnExpSampledCLK = &H4
'Trigger Configuration
Global Const P7350_EnPauseTrig = &H1
Global Const P7350_EnSoftTrigOut = &H2
'HandShake & Trigger Polarity
Global Const P7350_DIREQ_POS = &H0
Global Const P7350_DIREQ_NEG = &H1
Global Const P7350_DIACK_POS = &H0
Global Const P7350_DIACK_NEG = &H2
Global Const P7350_DITRIG_POS = &H0
Global Const P7350_DITRIG_NEG = &H4
Global Const P7350_DIStartTrig_POS = &H0
Global Const P7350_DIStartTrig_NEG = &H8
Global Const P7350_DIPauseTrig_POS = &H0
Global Const P7350_DIPauseTrig_NEG = &H10
Global Const P7350_DOREQ_POS = &H0
Global Const P7350_DOREQ_NEG = &H1
Global Const P7350_DOACK_POS = &H0
Global Const P7350_DOACK_NEG = &H2
Global Const P7350_DOTRIG_POS = &H0
Global Const P7350_DOTRIG_NEG = &H4
Global Const P7350_DOStartTrig_POS = &H0
Global Const P7350_DOStartTrig_NEG = &H8
Global Const P7350_DOPauseTrig_POS = &H0
Global Const P7350_DOPauseTrig_NEG = &H10

'External Sampled Clock Source
Global Const P7350_ECLK_IN = 8
'Export Sampled Clock
Global Const P7350_ECLK_OUT = 8
'Enable Dynamic Delay Adjust
Global Const P7350_DisDDA = &H0
Global Const P7350_EnDDA = &H1
'Dynamic Delay Adjust Mode
Global Const P7350_DDA_Lag = &H0
Global Const P7350_DDA_Lead = &H2
'Dynamic Delay Adjust Step
Global Const P7350_DDA_130PS = 0
Global Const P7350_DDA_260PS = 1
Global Const P7350_DDA_390PS = 2
Global Const P7350_DDA_520PS = 3
Global Const P7350_DDA_650PS = 4
Global Const P7350_DDA_780PS = 5
Global Const P7350_DDA_910PS = 6
Global Const P7350_DDA_1R04NS = 7
'Enable Dynamic Phase Adjust
Global Const P7350_DisDPA = &H0
Global Const P7350_EnDPA = &H1
'Dynamic Delay Adjust Degree
Global Const P7350_DPA_0DG = 0
Global Const P7350_DPA_22R5DG = 1
Global Const P7350_DPA_45DG = 2
Global Const P7350_DPA_67R5DG = 3
Global Const P7350_DPA_90DG = 4
Global Const P7350_DPA_112R5DG = 5
Global Const P7350_DPA_135DG = 6
Global Const P7350_DPA_157R5DG = 7
Global Const P7350_DPA_180DG = 8
Global Const P7350_DPA_202R5DG = 9
Global Const P7350_DPA_225DG = 10
Global Const P7350_DPA_247R5DG = 11
Global Const P7350_DPA_270DG = 12
Global Const P7350_DPA_292R5DG = 13
Global Const P7350_DPA_315DG = 14
Global Const P7350_DPA_337R5DG = 15

'DIO & AFI Voltage Level
Global Const VoltLevel_3R3 = 0
Global Const VoltLevel_2R5 = 1
Global Const VoltLevel_1R8 = 2

'Constants for I Squared C (I2C)
'I2C Port
Global Const I2C_Port_A = 0
'I2C Control Operation
Global Const I2C_ENABLE = 0
Global Const I2C_STOP = 1

'Constants for Serial Peripheral Interface
'SPI Port
Global Const SPI_Port_A = 0
'SPI Clock Mode
Global Const SPI_CLK_L = &H0
Global Const SPI_CLK_H = &H1
'SPI TX Polarity
Global Const SPI_TX_POS = &H0
Global Const SPI_TX_NEG = &H2
'SPI RX Polarity
Global Const SPI_RX_POS = &H0
Global Const SPI_RX_NEG = &H4
'SPI Transferred Order
Global Const SPI_MSB = &H0
Global Const SPI_LSB = &H8
'SPI Control Operation
Global Const SPI_ENABLE = 0

'Constants for Pattern Match
'Pattern Match Channel Mode
Global Const PATMATCH_CHNDisable = 0
Global Const PATMATCH_CHNEnable = 1
'Pattern Match Channel Type
Global Const PATMATCH_Level_L = 0
Global Const PATMATCH_Level_H = 1
Global Const PATMATCH_Edge_R = 2
Global Const PATMATCH_Edge_F = 3
'Pattern Match Operation
Global Const PATMATCH_STOP = 0
Global Const PATMATCH_START = 1
Global Const PATMATCH_RESTART = 2

'Constants for Access EEPROM
'for PCI-7230/PCMe-7230
Global Const P7230_EEP_BLK_0 = 0
Global Const P7230_EEP_BLK_1 = 1

Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Long, ByVal Milliseconds As Long) As Long
'-------------------------------------------------------------------'
'  PCIS-DASK Function prototype                                     '
'-------------------------------------------------------------------'
'Basic Functions
Declare Function Register_Card Lib "Pci-Dask.dll" (ByVal cardType As Integer, ByVal card_num As Integer) As Integer
Declare Function Release_Card Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer

'AI Functions
Declare Function AI_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrigSource As Integer, ByVal TrgMode As Integer, ByVal TraceCnt As Integer) As Integer
Declare Function AI_9112_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrigSource As Integer) As Integer
Declare Function AI_9113_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrigSource As Integer) As Integer
Declare Function AI_9114_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrigSource As Integer) As Integer
Declare Function AI_9114_PreTrigConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal PreTrgEn As Integer, ByVal TraceCnt As Integer) As Integer
Declare Function AI_9116_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal PostCnt As Integer, ByVal MCnt As Integer, ByVal ReTrgCnt As Integer) As Integer
Declare Function AI_9116_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ScanIntrv As Long, ByVal SampIntrv As Long) As Integer
Declare Function AI_9118_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ModeCtrl As Integer, ByVal FunCtrl As Integer, ByVal BurstCnt As Integer, ByVal PostCnt As Integer) As Integer
Declare Function AI_9221_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal AutoResetBuf As Byte) As Integer
Declare Function AI_9221_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ScanIntrv As Long, ByVal SampIntrv As Long) As Integer
Declare Function AI_9222_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTriggerCnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function AI_9222_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ScanIntrv As Long, ByVal SampIntrv As Long) As Integer
Declare Function AI_9223_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTriggerCnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function AI_9223_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ScanIntrv As Long, ByVal SampIntrv As Long) As Integer
Declare Function AI_922A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTriggerCnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function AI_922A_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ScanIntrv As Long, ByVal SampIntrv As Long) As Integer
Declare Function AI_9524_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Group As Integer, ByVal XMode As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal TrigValue As Long) As Integer
Declare Function AI_9524_PollConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Group As Integer, ByVal PollChannel As Integer, ByVal PollRange As Integer, ByVal PollSpeed As Integer) As Integer
Declare Function AI_9524_SetDSP Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal Mode As Integer, ByVal DFStage As Integer, ByVal SPKRejThreshold As Long) As Integer
Declare Function AI_9524_GetEOCEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Group As Integer, hEvent As Long) As Integer
Declare Function AI_9812_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrgMode As Integer, ByVal TrgSrc As Integer, ByVal TrgPol As Integer, ByVal ClkSel As Integer, ByVal TrgLevel As Integer, ByVal PostCnt As Integer) As Integer
Declare Function AI_9812_SetDiv Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal pacerVal As Long) As Integer
Declare Function AI_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Stopped As Byte, AccessCnt As Long) As Integer
Declare Function AI_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, AccessCnt As Long) As Integer
Declare Function AI_AsyncDblBufferHalfReady Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, HalfReady As Byte, StopFlag As Byte) As Integer
Declare Function AI_AsyncDblBufferMode Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Enable As Byte) As Integer
Declare Function AI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Integer) As Integer
Declare Function AI_AsyncDblBufferHandled Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function AI_AsyncDblBufferToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function AI_AsyncDblBufferOverrun Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal op As Integer, overrunFlag As Integer) As Integer
Declare Function AI_AsyncReTrigNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Ready As Byte, StopFlag As Byte, RdyTrigCnt As Integer) As Integer
Declare Function AI_ContReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Buffer As Integer, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function AI_ContReadChannelToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, ByVal FileName As String, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function AI_ContScanChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Buffer As Integer, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function AI_ContScanChannelsToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, ByVal FileName As String, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function AI_ContReadMultiChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Chans As Integer, AdRanges As Integer, Buffer As Integer, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function AI_ContReadMultiChannelsToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Chans As Integer, AdRanges As Integer, ByVal FileName As String, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function AI_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Status As Integer) As Integer
Declare Function AI_ContBufferReset Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function AI_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Any, ByVal ReadCount As Long, BufferId As Integer) As Integer
Declare Function AI_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Mode As Integer, ByVal EventType As Integer, ByVal callbackAddr As Long) As Integer
Declare Function AI_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, MemSize As Long) As Integer
Declare Function AI_ReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Value As Integer) As Integer
Declare Function AI_ReadChannel32 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Value As Long) As Integer
Declare Function AI_VReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Voltage As Double) As Integer
Declare Function AI_ScanReadChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Buffer As Integer) As Integer
Declare Function AI_ScanReadChannels32 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Buffer As Long) As Integer
Declare Function AI_ReadMultiChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Chans As Integer, AdRanges As Integer, Buffer As Integer) As Integer
Declare Function AI_VoltScale Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, ByVal reading As Integer, Voltage As Double) As Integer
Declare Function AI_VoltScale32 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, ByVal reading As Long, Voltage As Double) As Integer
Declare Function AI_ContVScale Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, readingArray As Integer, voltageArray As Double, ByVal CCount As Long) As Integer
Declare Function AI_SetTimeOut Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TimeOut As Long) As Integer

'AO Functions
Declare Function AO_6202_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTrgCnt As Long, ByVal DLY1Cnt As Long, ByVal DLY2Cnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function AO_6208A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal V2AMode As Integer) As Integer
Declare Function AO_6308A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal V2AMode As Integer) As Integer
Declare Function AO_6308V_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal OutputPolarity As Integer, ByVal refVoltage As Double) As Integer
Declare Function AO_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal OutputPolarity As Integer) As Integer
Declare Function AO_9112_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal refVoltage As Double) As Integer
Declare Function AO_9222_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTrgCnt As Long, ByVal DLY1Cnt As Long, ByVal DLY2Cnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function AO_9223_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTrgCnt As Long, ByVal DLY1Cnt As Long, ByVal DLY2Cnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function AO_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Stopped As Byte, AccessCnt As Long) As Integer
Declare Function AO_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, AccessCnt As Long, ByVal stop_mode As Integer) As Integer
Declare Function AO_AsyncDblBufferHalfReady Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, HalfReady As Byte) As Integer
Declare Function AO_AsyncDblBufferMode Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Enable As Byte) As Integer
Declare Function AO_ContBufferCompose Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TotalChnCount As Integer, ByVal ChnNum As Integer, ByVal UpdateCount As Long, ConBuffer As Any, Buffer As Any) As Integer
Declare Function AO_ContBufferReset Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function AO_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Any, ByVal WriteCount As Long, BufferId As Integer) As Integer
Declare Function AO_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Status As Integer) As Integer
Declare Function AO_ContWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal BufId As Integer, ByVal WriteCount As Long, ByVal Iterations As Long, ByVal CHUI As Long, ByVal definite As Integer, ByVal SyncMode As Integer) As Integer
Declare Function AO_ContWriteMultiChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Chans As Integer, ByVal BufId As Integer, ByVal WriteCount As Long, ByVal Iterations As Long, ByVal CHUI As Long, ByVal definite As Integer, ByVal SyncMode As Integer) As Integer
Declare Function AO_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Mode As Integer, ByVal EventType As Integer, ByVal callbackAddr As Long) As Integer
Declare Function AO_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, MemSize As Long) As Integer
Declare Function AO_SetTimeOut Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TimeOut As Long) As Integer
Declare Function AO_SimuVWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Group As Integer, voltageArray As Double) As Integer
Declare Function AO_SimuWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Group As Integer, valueArray As Integer) As Integer
Declare Function AO_VoltScale Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal Voltage As Double, binValue As Integer) As Integer
Declare Function AO_VWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal Voltage As Double) As Integer
Declare Function AO_WriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal Value As Integer) As Integer

'DI Functions
Declare Function DI_7200_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrigSource As Integer, ByVal ExtTrigEn As Integer, ByVal TrigPol As Integer, ByVal I_REQ_Pol As Integer) As Integer
Declare Function DI_7233_ForceLogic Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer) As Integer
Declare Function DI_7300A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal PortWidth As Integer, ByVal TrigSource As Integer, ByVal WaitStatus As Integer, ByVal Terminaor As Integer, ByVal I_REQ_Pol As Integer, ByVal clear_fifo As Byte, ByVal disable_di As Byte) As Integer
Declare Function DI_7300B_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal PortWidth As Integer, ByVal TrigSource As Integer, ByVal WaitStatus As Integer, ByVal Terminator As Integer, ByVal I_Cntrl_Pol As Integer, ByVal clear_fifo As Byte, ByVal disable_di As Byte) As Integer
Declare Function DI_7350_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal DIPortWidth As Integer, ByVal DIMode As Integer, ByVal DIWaitStatus As Integer, ByVal DIClkConfig As Integer) As Integer
Declare Function DI_7350_ExportSampCLKConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal CLK_Src As Integer, ByVal CLK_DPAMode As Integer, ByVal CLK_DPAVlaue As Integer) As Integer
Declare Function DI_7350_ExtSampCLKConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal CLK_Src As Integer, ByVal CLK_DDAMode As Integer, ByVal CLK_DPAMode As Integer, ByVal CLK_DDAVlaue As Integer, ByVal CLK_DPAVlaue As Integer) As Integer
Declare Function DI_7350_SoftTriggerGen Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function DI_7350_TrigHSConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrigConfig As Integer, ByVal DI_IPOL As Integer, ByVal DI_REQSrc As Integer, ByVal DI_ACKSrc As Integer, ByVal DI_TRIGSrc As Integer, ByVal StartTrigSrc As Integer, ByVal PauseTrigSrc As Integer, ByVal SoftTrigOutSrc As Integer, ByVal SoftTrigOutLength As Long, ByVal TrigCount As Long) As Integer
Declare Function DI_7350_BurstHandShakeDelay Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Delay As Byte) As Integer
Declare Function DI_9222_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTriggerCnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function DI_9223_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTriggerCnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function DI_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Stopped As Byte, AccessCnt As Long) As Integer
Declare Function DI_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, AccessCnt As Long) As Integer
Declare Function DI_AsyncDblBufferHalfReady Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, HalfReady As Byte) As Integer
Declare Function DI_AsyncDblBufferHandled Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function DI_AsyncDblBufferMode Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Enable As Byte) As Integer
Declare Function DI_AsyncDblBufferToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function DI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Any) As Integer
Declare Function DI_AsyncDblBufferOverrun Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal op As Integer, overrunFlag As Integer) As Integer
Declare Function DI_AsyncMultiBuffersHandled Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal bufcnt As Integer, bufs As Integer) As Integer
Declare Function DI_AsyncMultiBufferNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, NextReady As Byte, BufferId As Integer) As Integer
Declare Function DI_AsyncReTrigNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Ready As Byte, StopFlag As Byte, RdyTrigCnt As Integer) As Integer
Declare Function DI_ContBufferReset Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function DI_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Any, ByVal ReadCount As Long, BufferId As Integer) As Integer
Declare Function DI_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Any, ByVal ReadCount As Long, BufferId As Integer) As Integer
Declare Function DI_ContMultiBufferStart Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal SampleRate As Double) As Integer
Declare Function DI_ContReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, Buffer As Any, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function DI_ContReadPortToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal FileName As String, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function DI_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Status As Integer) As Integer
Declare Function DI_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Mode As Integer, ByVal EventType As Integer, ByVal callbackAddr As Long) As Integer
Declare Function DI_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, MemSize As Long) As Integer
Declare Function DI_ReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, Value As Long) As Integer
Declare Function DI_ReadLine Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal LLine As Integer, Value As Integer) As Integer
Declare Function DI_SetTimeOut Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TimeOut As Long) As Integer

'DO Functions
Declare Function DO_7200_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrigSource As Integer, ByVal OutReqEn As Integer, ByVal OutTrigSig As Integer) As Integer
Declare Function DO_7300A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal PortWidth As Integer, ByVal TrigSource As Integer, ByVal WaitStatus As Integer, ByVal Terminaor As Integer, ByVal O_REQ_Pol As Integer) As Integer
Declare Function DO_7300B_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal PortWidth As Integer, ByVal TrigSource As Integer, ByVal WaitStatus As Integer, ByVal Terminator As Integer, ByVal O_Cntrl_Pol As Integer, ByVal FifoThreshold As Long) As Integer
Declare Function DO_7300B_SetDODisableMode Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Mode As Integer) As Integer
Declare Function DO_7350_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal DOPortWidth As Integer, ByVal DOMode As Integer, ByVal DOWaitStatus As Integer, ByVal DOClkConfig As Integer) As Integer
Declare Function DO_7350_ExportSampCLKConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal CLK_Src As Integer, ByVal CLK_DPAMode As Integer, ByVal CLK_DPAVlaue As Integer) As Integer
Declare Function DO_7350_ExtSampCLKConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal CLK_Src As Integer, ByVal CLK_DDAMode As Integer, ByVal CLK_DPAMode As Integer, ByVal CLK_DDAVlaue As Integer, ByVal CLK_DPAVlaue As Integer) As Integer
Declare Function DO_7350_SoftTriggerGen Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function DO_7350_TrigHSConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TrigConfig As Integer, ByVal DO_IPOL As Integer, ByVal DO_REQSrc As Integer, ByVal DO_ACKSrc As Integer, ByVal DO_TRIGSrc As Integer, ByVal StartTrigSrc As Integer, ByVal PauseTrigSrc As Integer, ByVal SoftTrigOutSrc As Integer, ByVal SoftTrigOutLength As Long, ByVal TrigCount As Long) As Integer
Declare Function DO_7350_BurstHandShakeDelay Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Delay As Byte) As Integer
Declare Function EDO_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal EDO_Fun As Integer) As Integer
Declare Function DO_9222_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTrgCnt As Long, ByVal DLY1Cnt As Long, ByVal DLY2Cnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function DO_9223_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTrgCnt As Long, ByVal DLY1Cnt As Long, ByVal DLY2Cnt As Long, ByVal AutoResetBuf As Byte) As Integer
Declare Function DO_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Stopped As Byte, AccessCnt As Long) As Integer
Declare Function DO_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, AccessCnt As Long) As Integer
Declare Function DO_AsyncMultiBufferNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, NextReady As Byte, BufferId As Integer) As Integer
Declare Function DO_ContBufferReset Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function DO_ContBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Any, ByVal WriteCount As Long, BufferId As Integer) As Integer
Declare Function DO_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Any, ByVal WriteCount As Long, BufferId As Integer) As Integer
Declare Function DO_ContMultiBufferStart Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal SampleRate As Double) As Integer
Declare Function DO_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Status As Integer) As Integer
Declare Function DO_ContWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, Buffer As Any, ByVal WriteCount As Long, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function DO_ContWritePortEx Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, Buffer As Any, ByVal WriteCount As Long, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer

Declare Function DO_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Mode As Integer, ByVal EventType As Integer, ByVal callbackAddr As Long) As Integer
Declare Function DO_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, MemSize As Long) As Integer
Declare Function DO_PGStart Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, Buffer As Any, ByVal WriteCount As Long, ByVal SampleRate As Double) As Integer
Declare Function DO_PGStop Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function DO_ReadLine Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal LLine As Integer, Value As Integer) As Integer
Declare Function DO_ReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, Value As Long) As Integer
Declare Function DO_SetTimeOut Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal TimeOut As Long) As Integer
Declare Function DO_SimuWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Buffer As Long) As Integer
Declare Function DO_WriteExtTrigLine Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Value As Integer) As Integer
Declare Function DO_WriteLine Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal LLine As Integer, ByVal Value As Integer) As Integer
Declare Function DO_WritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal Value As Long) As Integer

'DIO Functions
Declare Function DIO_7300SetInterrupt Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal AuxDIEn As Integer, ByVal T2En As Integer, hEvent As Long) As Integer
Declare Function DIO_7350_AFIConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal AFI_Port As Integer, ByVal AFI_Enable As Integer, ByVal AFI_Mode As Integer, ByVal AFI_TrigOutLen As Long) As Integer
Declare Function DIO_AUXDI_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal AuxDIEn As Integer, ByVal windowHandle As Long, ByVal message As Long, ByVal callbackAddr As Long) As Integer
Declare Function DIO_COSInterruptCounter Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Counter_Num As Integer, ByVal Counter_Mode As Integer, ByVal DI_Port As Integer, ByVal DI_Line As Integer, Counter_Value As Long) As Integer
Declare Function DIO_GetCOSLatchData Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, CosLData As Integer) As Integer
Declare Function DIO_GetCOSLatchData32 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Byte, CosLData As Long) As Integer
Declare Function DIO_GetCOSLatchDataInt32 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Byte, CosLData As Long) As Integer
Declare Function DIO_GetPMLatchData32 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, PMLData As Long) As Integer
Declare Function DIO_INT_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Mode As Integer, ByVal hEvent As Long, ByVal windowHandle As Long, ByVal message As Long, ByVal callbackAddr As Long) As Integer
Declare Function DIO_INT1_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Int1Mode As Integer, ByVal windowHandle As Long, ByVal message As Long, ByVal callbackAddr As Long) As Integer
Declare Function DIO_INT2_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Int2Mode As Integer, ByVal windowHandle As Long, ByVal message As Long, ByVal callbackAddr As Long) As Integer
Declare Function DIO_LineConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal LLine As Integer, ByVal Direction As Integer) As Integer
Declare Function DIO_LinesConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal Linesdirmap As Integer) As Integer
Declare Function DIO_PortConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal Direction As Integer) As Integer
Declare Function DIO_PMConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal PM_ChnEn As Integer, ByVal PM_ChnType As Integer) As Integer
Declare Function DIO_PMControl Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal PM_Start As Integer, hEvent As Long, ByVal ManualReset As Byte) As Integer
Declare Function DIO_SetCOSInterrupt Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal ctlA As Integer, ByVal ctlB As Integer, ByVal ctlC As Integer) As Integer
Declare Function DIO_SetCOSInterrupt32 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Byte, ByVal ctl As Long, hEvent As Long, ByVal ManualReset As Byte) As Integer
Declare Function DIO_SetDualInterrupt Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Int1Mode As Integer, ByVal Int2Mode As Integer, hEvent As Long) As Integer
Declare Function DIO_SetPMInterrupt32 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal ctrl As Long, ByVal Pattern1 As Long, ByVal Pattern2 As Long, hEvent As Long, ByVal ManualReset As Byte) As Integer
Declare Function DIO_T2_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal T2En As Integer, ByVal windowHandle As Long, ByVal message As Long, ByVal callbackAddr As Long) As Integer
Declare Function DIO_VoltLevelConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal PortType As Integer, ByVal VoltLevel As Integer) As Integer

'Counter Functions
Declare Function CTR_8554_CK1_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ClockSource As Integer) As Integer
Declare Function CTR_8554_ClkSrc_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, ByVal ClockSource As Integer) As Integer
Declare Function CTR_8554_Debounce_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal DebounceClock As Integer) As Integer
Declare Function CTR_Clear Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, ByVal State As Integer) As Integer
Declare Function CTR_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, Value As Long) As Integer
Declare Function CTR_Read_All Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal CtrCnt As Integer, Ctr As Integer, Value As Long) As Integer
Declare Function CTR_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, ByVal Mode As Integer, ByVal CCount As Long, ByVal BinBcd As Integer) As Integer
Declare Function CTR_Setup_All Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal CtrCnt As Integer, Ctr As Integer, Mode As Integer, CCount As Long, BinBcd As Integer) As Integer
Declare Function CTR_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, Value As Long) As Integer
Declare Function CTR_Update Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, ByVal CCount As Long) As Integer
Declare Function GCTR_Clear Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer) As Integer
Declare Function GCTR_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, Value As Long) As Integer
Declare Function GCTR_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, ByVal GCtrCtrl As Integer, ByVal CCount As Long) As Integer
Declare Function GPTC_9524_PG_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, ByVal PulseGenNum As Long) As Integer
Declare Function GPTC_Clear Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer) As Integer
Declare Function GPTC_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, ByVal ParamID As Integer, ByVal Value As Integer) As Integer
Declare Function GPTC_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Enabled As Integer, ByVal EventType As Integer, ByVal callbackAddr As Long) As Integer
Declare Function GPTC_EventSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, ByVal Mode As Integer, ByVal ctrl As Integer, ByVal LVal_1 As Long, ByVal LVal_2 As Long) As Integer
Declare Function GPTC_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, Value As Long) As Integer
Declare Function GPTC_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, ByVal Mode As Integer, ByVal SrcCtrl As Integer, ByVal PolCtrl As Integer, ByVal LReg1_Val As Long, ByVal LReg2_Val As Long) As Integer
Declare Function GPTC_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, Value As Long) As Integer
Declare Function GPTC_9524_GetTimerEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, hEvent As Long) As Integer
Declare Function WDT_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, ByVal action As Integer) As Integer
Declare Function WDT_Reload Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, ByVal ovflowSec As Single, actualSec As Single) As Integer
Declare Function WDT_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, ByVal ovflowSec As Single, actualSec As Single, hEvent As Long) As Integer
Declare Function WDT_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Ctr As Integer, Value As Long) As Integer

'Get Event or View Functions
Declare Function AI_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, hEvent As Long) As Integer
Declare Function AO_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, hEvent As Long) As Integer
Declare Function DI_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, hEvent As Long) As Integer
Declare Function DO_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, hEvent As Long) As Integer

'Common Functions
Declare Function GetActualRate Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal SampleRate As Double, ActualRate As Double) As Integer
Declare Function GetActualRate_9524 Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Group As Integer, ByVal SampleRate As Double, ActualRate As Double) As Integer
Declare Function GetBaseAddr Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, BaseAddr As Long, BaseAddr2 As Long) As Integer
Declare Function GetCardIndexFromID Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, cardType As Integer, cardIndex As Integer) As Integer
Declare Function GetCardType Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, cardType As Integer) As Integer
Declare Function GetLCRAddr Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, LcrAddr As Long) As Integer
Declare Function PCI_EEPROM_LoadData Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal block As Integer, data As Integer) As Integer
Declare Function PCI_EEPROM_SaveData Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal block As Integer, ByVal data As Integer) As Integer

'Safety Control Functions
Declare Function EMGShutDownControl Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ctrl As Byte) As Integer
Declare Function EMGShutDownStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ctrl As Byte) As Integer
Declare Function GetInitPattern Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal patID As Byte, pattern As Long) As Integer
Declare Function HotResetHoldControl Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Enable As Byte) As Integer
Declare Function HotResetHoldStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, sts As Byte) As Integer
Declare Function IdentifyLED_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ctrl As Byte) As Integer
Declare Function SetInitPattern Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal patID As Byte, ByVal pattern As Long) As Integer

'Calibration Function
Declare Function PCI9524_Acquire_AD_CalConst Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Group As Integer, ByVal ADC_Range As Integer, ByVal ADC_Speed As Integer, CalDate As Long, CalTemp As Single, ADC_offset As Long, ADC_gain As Long, Residual_offset As Double, Residual_scaling As Double) As Integer
Declare Function PCI9524_Acquire_DA_CalConst Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, CalDate As Long, CalTemp As Single, DAC_offset As Byte, DAC_linearity As Byte, Gain_factor As Single) As Integer
Declare Function PCI9524_Read_EEProm Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal ReadAddr As Integer, ReadData As Byte) As Integer
Declare Function PCI9524_Read_RemoteSPI Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Addr As Integer, RdData As Byte) As Integer
Declare Function PCI9524_Write_EEProm Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal WriteAddr As Integer, WriteData As Byte) As Integer
Declare Function PCI9524_Write_RemoteSPI Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Addr As Integer, ByVal WrtData As Byte) As Integer
Declare Function PCI_DB_Auto_Calibration_ALL Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function PCI_EEPROM_CAL_Constant_Update Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal bank As Integer) As Integer
Declare Function PCI_Load_CAL_Data Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal bank As Integer) As Integer

'SSI Functions
Declare Function SSI_SourceConn Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal sigCode As Integer) As Integer
Declare Function SSI_SourceDisConn Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal sigCode As Integer) As Integer
Declare Function SSI_SourceClear Lib "Pci-Dask.dll" (ByVal CardNumber As Integer) As Integer

'PWM Functions
Declare Function PWM_Output Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal high_interval As Long, ByVal low_interval As Long) As Integer
Declare Function PWM_Stop Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer) As Integer

'I2C Functions
Declare Function I2C_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal I2C_Port As Integer, ByVal I2C_Config As Integer, ByVal I2C_SetupValue1 As Long, ByVal I2C_SetupValue2 As Long) As Integer
Declare Function I2C_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal I2C_Port As Integer, ByVal I2C_CtrlParam As Integer, ByVal I2C_CtrlValue As Long) As Integer
Declare Function I2C_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal I2C_Port As Integer, I2C_Status As Long) As Integer
Declare Function I2C_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal I2C_Port As Integer, ByVal I2C_SlaveAddr As Integer, ByVal I2C_CmdAddrBytes As Integer, ByVal I2C_DataBytes As Integer, ByVal I2C_CmdAddr As Long, I2C_Data As Long) As Integer
Declare Function I2C_Write Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal I2C_Port As Integer, ByVal I2C_SlaveAddr As Integer, ByVal I2C_CmdAddrBytes As Integer, ByVal I2C_DataBytes As Integer, ByVal I2C_CmdAddr As Long, ByVal I2C_Data As Long) As Integer

'SPI Functions
Declare Function SPI_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal SPI_Port As Integer, ByVal SPI_Config As Integer, ByVal SPI_SetupValue1 As Long, ByVal SPI_SetupValue2 As Long) As Integer
Declare Function SPI_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal SPI_Port As Integer, ByVal SPI_CtrlParam As Integer, ByVal SPI_CtrlValue As Long) As Integer
Declare Function SPI_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal SPI_Port As Integer, SPI_Status As Long) As Integer
Declare Function SPI_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal SPI_Port As Integer, ByVal SPI_SlaveAddr As Integer, ByVal SPI_CmdAddrBits As Integer, ByVal SPI_DataBits As Integer, ByVal SPI_FrontDummyBits As Integer, ByVal SPI_CmdAddr As Long, SPI_Data As Long) As Integer
Declare Function SPI_Write Lib "Pci-Dask.dll" (ByVal CardNumber As Integer, ByVal SPI_Port As Integer, ByVal SPI_SlaveAddr As Integer, ByVal SPI_CmdAddrBits As Integer, ByVal SPI_DataBits As Integer, ByVal SPI_FrontDummyBits As Integer, ByVal SPI_TailDummyBits As Integer, ByVal SPI_CmdAddr As Long, ByVal SPI_Data As Long) As Integer
