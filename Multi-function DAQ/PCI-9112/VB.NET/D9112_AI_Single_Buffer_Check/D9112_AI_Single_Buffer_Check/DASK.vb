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
	
	'Synchronous Mode
	Public Const SYNCH_OP As Short = 1
	Public Const ASYNCH_OP As Short = 2
	
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
	Public Const DI_WAITING As Short = &H2s
	Public Const DI_NOWAITING As Short = &H0s
	
	Public Const DI_TRIG_RISING As Short = &H4s
	Public Const DI_TRIG_FALLING As Short = &H0s
	
	Public Const IREQ_RISING As Short = &H8s
	Public Const IREQ_FALLING As Short = &H0s
	
	'Output Mode
	Public Const OREQ_ENABLE As Short = &H10s
	Public Const OREQ_DISABLE As Short = &H0s
	
	Public Const OTRIG_HIGH As Short = &H20s
	Public Const OTRIG_LOW As Short = &H0s
	
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
	
	Public Const P7442_CH0 As Short = 0
	Public Const P7442_CH1 As Short = 1
	Public Const P7442_TTL0 As Short = 2
	Public Const P7442_TTL1 As Short = 3
	
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
	Public Const P7300_DIREQ_POS As Short = &H0s
	Public Const P7300_DIREQ_NEG As Short = &H1s
	Public Const P7300_DIACK_POS As Short = &H0s
	Public Const P7300_DIACK_NEG As Short = &H2s
	Public Const P7300_DITRIG_POS As Short = &H0s
	Public Const P7300_DITRIG_NEG As Short = &H4s
	
	'DO control signals polarity for PCI-7300A Rev. B
	Public Const P7300_DOREQ_POS As Short = &H0s
	Public Const P7300_DOREQ_NEG As Short = &H8s
	Public Const P7300_DOACK_POS As Short = &H0s
	Public Const P7300_DOACK_NEG As Short = &H10s
	Public Const P7300_DOTRIG_POS As Short = &H0s
	Public Const P7300_DOTRIG_NEG As Short = &H20s
	
	'--------- Constants for PCI-7432/7433/7434 --------------
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
	
	'----- Dual-Interrupt Source control for PCI-7248/49/96 & 7230 & 8554 & 7396 &7256/58 & 7260-----
	Public Const INT1_DISABLE As Short = -1 'INT1 Disabled
	Public Const INT1_COS As Short = 0 'INT1 COS : only available for PCI-7396, PCI-7256/58 & PCI-7260
	Public Const INT1_FP1C0 As Short = 1 'INT1 by Falling edge of P1C0
	Public Const INT1_RP1C0_FP1C3 As Short = 2 'INT1 by P1C0 Rising or P1C3 Falling
	Public Const INT1_EVENT_COUNTER As Short = 3 'INT1 by Event Counter down to zero
	Public Const INT1_EXT_SIGNAL As Short = 1 'INT1 by external signal : only available for PCI7432/PCI7433/PCI7230
	Public Const INT1_COUT12 As Short = 1 'INT1 COUT12 : only available for PCI8554
	Public Const INT1_CH0 As Short = 1 'INT1 CH0 : only available for PCI7256/58/60
	Public Const INT1_COS0 As Short = 1 'INT1 COS0 : only available for PCI-7452
	Public Const INT1_COS1 As Short = 2 'INT1 COS1 : only available for PCI-7452
	Public Const INT1_COS2 As Short = 3 'INT1 COS2 : only available for PCI-7452
	Public Const INT1_COS3 As Short = 8 'INT1 COS3 : only available for PCI-7452
	Public Const INT2_DISABLE As Short = -1 'INT2 Disabled
	Public Const INT2_COS As Short = 0 'INT2 COS : only available for PCI-7396
	Public Const INT2_FP2C0 As Short = 1 'INT2 by Falling edge of P2C0
	Public Const INT2_RP2C0_FP2C3 As Short = 2 'INT2 by P2C0 Rising or P2C3 Falling
	Public Const INT2_TIMER_COUNTER As Short = 3 'INT2 by Timer Counter down to zero
	Public Const INT2_EXT_SIGNAL As Short = 1 'INT2 by external signal : only available for PCI7432/PCI7433/PCI7230
	Public Const INT2_CH1 As Short = 2 'INT2 CH1 : only available for PCI7256/58/60
	Public Const INT2_WDT As Short = 4 'INT2 by WDT
	
	Public Const WDT_OVRFLOW_SAFETYOUT As Short = &H8000s 'enable safteyout while WDT overflow
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
	Public Const P9118_AI_BiPolar As Short = &H0s
	Public Const P9118_AI_UniPolar As Short = &H1s
	
	Public Const P9118_AI_SingEnded As Short = &H0s
	Public Const P9118_AI_Differential As Short = &H2s
	
	Public Const P9118_AI_ExtG As Short = &H4s
	
	Public Const P9118_AI_ExtTrig As Short = &H8s
	
	Public Const P9118_AI_DtrgNegative As Short = &H0s
	Public Const P9118_AI_DtrgPositive As Short = &H10s
	
	Public Const P9118_AI_EtrgNegative As Short = &H0s
	Public Const P9118_AI_EtrgPositive As Short = &H20s
	
	Public Const P9118_AI_BurstModeEn As Short = &H40s
	Public Const P9118_AI_SampleHold As Short = &H80s
	Public Const P9118_AI_PostTrgEn As Short = &H100s
	Public Const P9118_AI_AboutTrgEn As Short = &H200s
	
	'--------- Constants for PCI-9812/9810 --------------
	'Channel Count
	Public Const P9116_AI_LocalGND As Short = &H0s
	Public Const P9116_AI_UserCMMD As Short = &H1s
	Public Const P9116_AI_SingEnded As Short = &H0s
	Public Const P9116_AI_Differential As Short = &H2s
	Public Const P9116_AI_BiPolar As Short = &H0s
	Public Const P9116_AI_UniPolar As Short = &H4s
	
	Public Const P9116_TRGMOD_SOFT As Short = &H0s 'Software Trigger Mode
	Public Const P9116_TRGMOD_POST As Short = &H10s 'Post Trigger Mode
	Public Const P9116_TRGMOD_DELAY As Short = &H20s 'Delay Trigger Mode
	Public Const P9116_TRGMOD_PRE As Short = &H30s 'Pre-Trigger Mode
	Public Const P9116_TRGMOD_MIDL As Short = &H40s 'Middle Trigger Mode
	Public Const P9116_AI_TrgPositive As Short = &H0s
	Public Const P9116_AI_TrgNegative As Short = &H80s
	Public Const P9116_AI_IntTimeBase As Short = &H0s
	Public Const P9116_AI_ExtTimeBase As Short = &H100s
	Public Const P9116_AI_DlyInSamples As Short = &H200s
	Public Const P9116_AI_DlyInTimebase As Short = &H0s
	Public Const P9116_AI_ReTrigEn As Short = &H400s
	Public Const P9116_AI_MCounterEn As Short = &H800s
	Public Const P9116_AI_SoftPolling As Short = &H0s
	Public Const P9116_AI_INT As Short = &H1000s
	Public Const P9116_AI_DMA As Short = &H2000s
	
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
	Public Const P9812_TRGSRC_CH0 As Short = 0 'trigger source --CH0
	Public Const P9812_TRGSRC_CH1 As Short = 8 'trigger source --CH1
	Public Const P9812_TRGSRC_CH2 As Short = &H10s 'trigger source --CH2
	Public Const P9812_TRGSRC_CH3 As Short = &H18s 'trigger source --CH3
	Public Const P9812_TRGSRC_EXT_DIG As Short = &H20s 'External Digital Trigger
	
	'Trigger Polarity
	Public Const P9812_TRGSLP_POS As Short = 0 'Positive slope trigger
	Public Const P9812_TRGSLP_NEG As Short = &H40s 'Negative slope trigger
	
	'Frequency Selection
	Public Const P9812_AD2_GT_PCI As Short = &H80s 'Freq. of A/D clock > PCI clock freq.
	Public Const P9812_AD2_LT_PCI As Short = &H0s 'Freq. of A/D clock < PCI clock freq.
	
	'Clock Source
	Public Const P9812_CLKSRC_INT As Short = &H0s 'Internal clock
	Public Const P9812_CLKSRC_EXT_SIN As Short = &H100s 'External SIN wave clock
	Public Const P9812_CLKSRC_EXT_DIG As Short = &H200s 'External Square wave clock
	
	'DAQ Event type for the event message
	Public Const AIEnd As Short = 0
	Public Const DIEnd As Short = 0
	Public Const DOEnd As Short = 0
	Public Const DBEvent As Short = 1
	
	'EMG shdn ctrl code
	Public Const EMGSHDN_OFF As Short = 0 'off
	Public Const EMGSHDN_ON As Short = 1 'on
	Public Const EMGSHDN_RECOVERY As Short = 2 'recovery
	
	'Hot Reset Hold ctrl code
	Public Const HRH_OFF As Short = 0 'off
	Public Const HRH_ON As Short = 1 'on
	
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
	Public Const General_Counter As Short = &H0s 'general counter
	Public Const Pulse_Generation As Short = &H1s 'pulse generation
	'GPTC clock source
	Public Const GPTC_CLKSRC_EXT As Short = &H8s
	Public Const GPTC_CLKSRC_INT As Short = &H0s
	Public Const GPTC_GATESRC_EXT As Short = &H10s
	Public Const GPTC_GATESRC_INT As Short = &H0s
	Public Const GPTC_UPDOWN_SELECT_EXT As Short = &H20s
	Public Const GPTC_UPDOWN_SELECT_SOFT As Short = &H0s
	Public Const GPTC_UP_CTR As Short = &H40s
	Public Const GPTC_DOWN_CTR As Short = &H0s
	Public Const GPTC_ENABLE As Short = &H80s
	Public Const GPTC_DISABLE As Short = &H0s
	
	'Watchdog Timer
	'Counter action
	Public Const WDT_DISARM As Short = 0
	Public Const WDT_ARM As Short = 1
	Public Const WDT_RESTART As Short = 2
	
	'Pattern ID
	Public Const INIT_PTN As Short = 0
	Public Const EMGSHDN_PTN As Short = 1
	
	'Pattern ID for 7442
	Public Const INIT_PTN_CH0 As Short = 0
	Public Const INIT_PTN_CH1 As Short = 1
	Public Const SAFTOUT_PTN_CH0 As Short = 4
	Public Const SAFTOUT_PTN_CH1 As Short = 5
	
	'16-bit binary or 4-decade BCD counter
	Public Const BIN As Short = 0
	Public Const BCD As Short = 1
	
	Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
    Public Delegate Sub CallbackDelegate()

	'-------------------------------------------------------------------
	'  PCIS-DASK Function prototype
	'-----------------------------------------------------------------*/
	Declare Function Register_Card Lib "Pci-Dask.dll" (ByVal cardType As Short, ByVal card_num As Short) As Short
	Declare Function Release_Card Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
	Declare Function GetActualRate Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal SampleRate As Double, ByRef ActualRate As Double) As Short
	Declare Function GetCardType Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef cardType As Short) As Short
	Declare Function GetBaseAddr Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef BaseAddr As Integer, ByRef BaseAddr2 As Integer) As Short
	Declare Function GetLCRAddr Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef LcrAddr As Integer) As Short
	Declare Function GetCardIndexFromID Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef cardType As Short, ByRef cardIndex As Short) As Short
	Declare Function EMGShutDownControl Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ctrl As Byte) As Short
	Declare Function EMGShutDownStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef ctrl As Byte) As Short
	Declare Function HotResetHoldControl Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal Enable As Byte) As Short
	Declare Function HotResetHoldStatus Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByRef sts As Byte) As Short
	Declare Function SetInitPattern Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal patID As Byte, ByVal pattern As Integer) As Short
	Declare Function GetInitPattern Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal patID As Byte, ByRef pattern As Integer) As Short
	Declare Function IdentifyLED_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ctrl As Byte) As Short
	
	'AI Functions
	Declare Function AI_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short, ByVal TrgMode As Short, ByVal wTraceCnt As Short) As Short
	Declare Function AI_9112_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short) As Short
	Declare Function AI_9113_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short) As Short
	Declare Function AI_9114_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short) As Short
	Declare Function AI_9114_PreTrigConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PreTrgEn As Short, ByVal TraceCnt As Short) As Short
	Declare Function AI_9116_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal PostCnt As Short, ByVal MCnt As Short, ByVal ReTrgCnt As Short) As Short
	Declare Function AI_9118_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wModeCtrl As Short, ByVal wFunCtrl As Short, ByVal wBurstCnt As Short, ByVal wPostCnt As Short) As Short
	Declare Function AI_9812_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wTrgMode As Short, ByVal wTrgSrc As Short, ByVal wTrgPol As Short, ByVal wClkSel As Short, ByVal wTrgLevel As Short, ByVal wPostCnt As Short) As Short
	Declare Function AI_9116_CounterInterval Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer) As Short
	Declare Function AI_9812_SetDiv Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal pacerVal As Integer) As Short
	Declare Function AI_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
	Declare Function AI_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef AccessCnt As Integer) As Short
	Declare Function AI_AsyncDblBufferHalfReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte, ByRef StopFlag As Byte) As Short
	Declare Function AI_AsyncDblBufferMode Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Enable As Byte) As Short
	Declare Function AI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short) As Short
    Declare Function AI_ContReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Buffer As UShort, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
	Declare Function AI_ContScanChannels Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal wChannel As Short, ByVal wAdRange As Short, ByRef pwBuffer As Short, ByVal dwReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
	Declare Function AI_ContReadMultiChannels Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByRef AdRanges As Short, ByRef Buffer As Short, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
	Declare Function AI_ContReadChannelToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByVal FileName As String, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
	Declare Function AI_ContScanChannelsToFile Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal wChannel As Short, ByVal wAdRange As Short, ByVal FileName As String, ByVal dwReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
	Declare Function AI_ContReadMultiChannelsToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByRef AdRanges As Short, ByVal FileName As String, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
	Declare Function AI_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Status As Short) As Short
	Declare Function AI_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
	Declare Function AI_ReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Value As Short) As Short
	Declare Function AI_VReadChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal AdRange As Short, ByRef Voltage As Double) As Short
    Declare Function AI_VoltScale Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByVal reading As Short, ByRef Voltage As Double) As Short
    Declare Function AI_ContVScale Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByRef readingArray As UShort, ByRef voltageArray As Double, ByVal Count As Integer) As Short
	Declare Function AI_AsyncDblBufferOverrun Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal op As Short, ByRef overrunFlag As Short) As Short
    Declare Function AI_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As CallbackDelegate) As Short
	
	'AO Functions
	Declare Function AO_6208A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal V2AMode As Short) As Short
	Declare Function AO_6308A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal V2AMode As Short) As Short
	Declare Function AO_6308V_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal OutputPolarity As Short, ByVal refVoltage As Double) As Short
	Declare Function AO_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal OutputPolarity As Short) As Short
	Declare Function AO_9112_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal refVoltage As Double) As Short
	Declare Function AO_WriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal Value As Short) As Short
	Declare Function AO_VWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal Voltage As Double) As Short
	Declare Function AO_VoltScale Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Channel As Short, ByVal Voltage As Double, ByRef binValue As Short) As Short
	Declare Function AO_SimuWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wGroup As Short, ByRef valueArray As Short) As Short
	Declare Function AO_SimuVWriteChannel Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wGroup As Short, ByRef voltageArray As Double) As Short
	
	'DI Functions
	Declare Function DI_7200_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short, ByVal wExtTrigEn As Short, ByVal wTrigPol As Short, ByVal wI_REQ_Pol As Short) As Short
	Declare Function DI_7300A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortWidth As Short, ByVal TrigSource As Short, ByVal WaitStatus As Short, ByVal Terminaor As Short, ByVal I_REQ_Pol As Short, ByVal clear_fifo As Byte, ByVal disable_di As Byte) As Short
	Declare Function DI_7300B_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortWidth As Short, ByVal TrigSource As Short, ByVal WaitStatus As Short, ByVal Terminator As Short, ByVal I_Cntrl_Pol As Short, ByVal clear_fifo As Byte, ByVal disable_di As Byte) As Short
	Declare Function DI_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
	Declare Function DI_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef AccessCnt As Integer) As Short
	Declare Function DI_AsyncDblBufferHalfReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte) As Short
	Declare Function DI_AsyncDblBufferMode Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Enable As Byte) As Short
    Declare Function DI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Byte) As Short
    Declare Function DI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short) As Short
    Declare Function DI_AsyncDblBufferTransfer Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As UInt32) As Short
    Declare Function DI_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Byte, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DI_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DI_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As UInt32, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DI_ContMultiBufferStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal SampleRate As Double) As Short
	Declare Function DI_AsyncMultiBufferNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef NextReady As Byte, ByRef BufferId As Short) As Short
    Declare Function DI_ContReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As Byte, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DI_ContReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As UShort, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DI_ContReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As UInt32, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DI_ContReadPortToFile Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal FileName As String, ByVal ReadCount As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
	Declare Function DI_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Status As Short) As Short
	Declare Function DI_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
	Declare Function DI_ReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Value As Integer) As Short
	Declare Function DI_ReadLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByRef Value As Short) As Short
	Declare Function DI_AsyncDblBufferOverrun Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal op As Short, ByRef overrunFlag As Short) As Short
	Declare Function DI_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As Integer) As Short
	
	'DO Functions
	Declare Function DO_7200_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal TrigSource As Short, ByVal wOutReqEn As Short, ByVal wOutTrigSig As Short) As Short
	Declare Function DO_7300A_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortWidth As Short, ByVal TrigSource As Short, ByVal WaitStatus As Short, ByVal Terminaor As Short, ByVal O_REQ_Pol As Short) As Short
	Declare Function DO_7300B_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal PortWidth As Short, ByVal TrigSource As Short, ByVal WaitStatus As Short, ByVal Terminator As Short, ByVal O_Cntrl_Pol As Short, ByVal FifoThreshold As Integer) As Short
	Declare Function DO_AsyncCheck Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
	Declare Function DO_AsyncClear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef AccessCnt As Integer) As Short
    Declare Function DO_ContWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As Byte, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As UShort, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContWritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Integer, ByRef Buffer As UInt32, ByVal WriteCount As Integer, ByVal Iterations As Integer, ByVal SampleRate As Double, ByVal SyncMode As Short) As Short
    Declare Function DO_ContStatus Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Status As Short) As Short
	Declare Function DO_InitialMemoryAllocated Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
    Declare Function DO_PGStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Byte, ByVal WriteCount As Integer, ByVal SampleRate As Double) As Short
    Declare Function DO_PGStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal WriteCount As Integer, ByVal SampleRate As Double) As Short
    Declare Function DO_PGStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As UInt32, ByVal WriteCount As Integer, ByVal SampleRate As Double) As Short
    Declare Function DO_PGStop Lib "Pci-Dask.dll" (ByVal CardNumber As Short) As Short
	Declare Function DO_WritePort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Value As Integer) As Short
	Declare Function DO_WriteLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByVal Value As Short) As Short
	Declare Function DO_SimuWritePort Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal wNumChans As Short, ByRef pdwBuffer As Integer) As Short
	Declare Function DO_ReadLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByRef Value As Short) As Short
	Declare Function DO_ReadPort Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Value As Integer) As Short
	Declare Function EDO_9111_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wEDO_Fun As Short) As Short
	Declare Function DO_WriteExtTrigLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Value As Short) As Short
    Declare Function DO_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Byte, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DO_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DO_ContMultiBufferSetup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As UInt32, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function DO_ContMultiBufferStart Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal SampleRate As Double) As Short
	Declare Function DO_AsyncMultiBufferNextReady Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef NextReady As Byte, ByRef BufferId As Short) As Short
	Declare Function DO_EventCallBack Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As Integer) As Short
	
	'DIO Functions
	Declare Function DIO_PortConfig Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Direction As Short) As Short
    Declare Function DIO_LinesConfig Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal wPort As Short, ByVal wLinesdirmap As Short) As Short
	Declare Function DIO_LineConfig Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal wPort As Short, ByVal wLine As Short, ByVal wDirection As Short) As Short
	Declare Function DIO_SetDualInterrupt Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal wInt1Mode As Short, ByVal wInt2Mode As Short, ByRef hEvent As Integer) As Short
	Declare Function DIO_SetCOSInterrupt Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal Port As Short, ByVal ctlA As Short, ByVal ctlB As Short, ByVal ctlC As Short) As Short
	Declare Function DIO_GetCOSLatchData Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef CosLData As Integer) As Short
	Declare Function DIO_SetCOSInterrupt32 Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal Port As Byte, ByVal ctl As Integer, ByRef hEvent As Integer, ByVal bManualReset As Byte) As Short
	Declare Function DIO_GetCOSLatchData32 Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef CosLData As Integer) As Short
    Declare Function DIO_INT_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal hEvent As Integer, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DIO_INT1_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Int1Mode As Short, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DIO_INT2_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Int2Mode As Short, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
	Declare Function DIO_7300SetInterrupt Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal AuxDIEn As Short, ByVal T2En As Short, ByRef hEvent As Integer) As Short
    Declare Function DIO_AUXDI_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal AuxDIEn As Short, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
    Declare Function DIO_T2_EventMessage Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal T2En As Short, ByVal windowHandle As Integer, ByVal message As Integer, ByVal callbackAddr As CallbackDelegate) As Short
	
	'Counter Functions
	Declare Function CTR_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal Mode As Short, ByVal Count As Integer, ByVal BinBcd As Short) As Short
	Declare Function CTR_Clear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal State As Short) As Short
	Declare Function CTR_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByRef Value As Integer) As Short
	Declare Function CTR_Update Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal Count As Integer) As Short
	Declare Function CTR_8554_ClkSrc_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Ctr As Short, ByVal ClockSource As Short) As Short
	Declare Function CTR_8554_CK1_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal ClockSource As Short) As Short
	Declare Function CTR_8554_Debounce_Config Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal DebounceClock As Short) As Short
	Declare Function GCTR_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByVal wGCtrCtrl As Short, ByVal dwCount As Integer) As Short
	Declare Function GCTR_Clear Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short) As Short
	Declare Function GCTR_Read Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByRef pValue As Integer) As Short
	Declare Function WDT_Setup Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wCtr As Short, ByVal ovflowSec As Single, ByRef actualSec As Single, ByRef hEvent As Integer) As Short
	Declare Function WDT_Control Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wCtr As Short, ByVal action As Short) As Short
	Declare Function WDT_Status Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal wCtr As Short, ByRef pValue As Integer) As Short
	Declare Function WDT_Reload Lib "Pci-Dask.dll" (ByVal wCardNumber As Short, ByVal ovflowSec As Single, ByRef actualSec As Single) As Short
	
	Declare Function AI_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef hEvent As Integer) As Short
	Declare Function AO_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef hEvent As Integer) As Short
	Declare Function DI_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef hEvent As Integer) As Short
	Declare Function DO_GetEvent Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByRef hEvent As Integer) As Short
End Module