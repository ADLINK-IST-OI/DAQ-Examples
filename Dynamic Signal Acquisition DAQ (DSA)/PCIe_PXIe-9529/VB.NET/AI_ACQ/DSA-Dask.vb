Imports System.Runtime.InteropServices
Imports System

Public Delegate Sub CallbackDelegate()

Public Class DSA_DASK

    'ADLink DSA Card Type
    Public Const PCI_9527 As UShort = 1
    Public Const PXI_9529 As UShort = 2
    Public Const PCI_9529 As UShort = 2

    Public Const MAX_CARD As UShort = 32

    'Error Number
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
    Public Const ErrorInvalidTriggerParam As Short = -49
    Public Const ErrorInvalidCounterValue As Short = -50
    Public Const ErrorInvalidConfig As Short = -51
    Public Const ErrorIncompatibleOperation As Short = -52
    Public Const ErrorInvalidEventHandle As Short = -60
    Public Const ErrorNoMessageAvailable As Short = -61
    Public Const ErrorEventMessgaeNotAdded As Short = -62
    Public Const ErrorCalibrationTimeOut As Short = -63
    Public Const ErrorUndefinedParameter As Short = -64
    Public Const ErrorInvalidBufferID As Short = -65
    Public Const ErrorInvalidSampledClock As Short = -66
    Public Const ErrorInvalisOperationMode As Short = -67
    Public Const ErrorOptionOutOfRanged As Short = -70
    Public Const ErrorInvalidDDSFrequency As Short = -80
    Public Const ErrorFrequencyLocked As Short = -81
    Public Const ErrorInvalidUpdateRate As Short = -82
    Public Const ErrorClockFailed As Short = -83
    Public Const ErrorInvalidParmPointer As Short = -84
    Public Const ErrorIoChannelNotCreated As Short = -85
    Public Const ErrorInvalidAOParameter As Short = -86
    Public Const ErrorIntClkFailed As Short = -87
    Public Const ErrorBadSyncSetting As Short = -88
    Public Const ErrorAICalibrationFailed As Short = -91
    Public Const ErrorAOCalibrationFailed As Short = -92
    Public Const ErrorRefVolOutOfRanged As Short = -93

    'Error number for driver API
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
    Public Const ErrorCalIoctl As Short = -216
    Public Const ErrorPMIntSetIoctl As Short = -217

    'AD Range
    Public Const AD_B_10_V As UShort = 1
    Public Const AD_B_5_V As UShort = 2
    Public Const AD_B_2_5_V As UShort = 3
    Public Const AD_B_1_25_V As UShort = 4
    Public Const AD_B_0_625_V As UShort = 5
    Public Const AD_B_0_3125_V As UShort = 6
    Public Const AD_B_0_5_V As UShort = 7
    Public Const AD_B_0_05_V As UShort = 8
    Public Const AD_B_0_005_V As UShort = 9
    Public Const AD_B_1_V As UShort = 10
    Public Const AD_B_0_1_V As UShort = 11
    Public Const AD_B_0_01_V As UShort = 12
    Public Const AD_B_0_001_V As UShort = 13
    Public Const AD_U_20_V As UShort = 14
    Public Const AD_U_10_V As UShort = 15
    Public Const AD_U_5_V As UShort = 16
    Public Const AD_U_2_5_V As UShort = 17
    Public Const AD_U_1_25_V As UShort = 18
    Public Const AD_U_1_V As UShort = 19
    Public Const AD_U_0_1_V As UShort = 20
    Public Const AD_U_0_01_V As UShort = 21
    Public Const AD_U_0_001_V As UShort = 22
    Public Const AD_B_2_V As UShort = 23
    Public Const AD_B_0_25_V As UShort = 24
    Public Const AD_B_0_2_V As UShort = 25
    Public Const AD_U_4_V As UShort = 26
    Public Const AD_U_2_V As UShort = 27
    Public Const AD_U_0_5_V As UShort = 28
    Public Const AD_U_0_4_V As UShort = 29
    Public Const AD_B_1_5_V As UShort = 30
    Public Const AD_B_0_2125_V As UShort = 31
    Public Const AD_B_40_V As UShort = 32
    Public Const AD_B_3_16_V As UShort = 33
    Public Const AD_B_0_316_V As UShort = 34

    'T or F
    'Public Const TRUE As UShort = 1
    'Public Const FALSE As UShort = 0

    'Synchronous Mode
    Public Const SYNCH_OP As UShort = 1
    Public Const ASYNCH_OP As UShort = 2

    'Clock Mode
    Public Const TRIG_INTERNAL As UShort = 0
    Public Const TRIG_PXI_CLK As UShort = 1

    'DAQ Event type for the event message
    Public Const AIEnd As UShort = 0
    Public Const A0End As UShort = 0
    Public Const DIEnd As UShort = 0
    Public Const DOEnd As UShort = 0
    Public Const DBEvent As UShort = 1
    Public Const TrigEvent As UShort = 2

    'Type Constants
    Public Const DAQ_AI As UShort = 0
    Public Const DAQ_AO As UShort = 1
    Public Const DAQ_DI As UShort = 2
    Public Const DAQ_DO As UShort = 3

    'EEPROM
    Public Const EEPROM_DEFAULT_BANK As UShort = 0
    Public Const EEPROM_USER_BANK1 As UShort = 1
    Public Const EEPROM_USER_BANK2 As UShort = 2
    Public Const EEPROM_USER_BANK3 As UShort = 3

    'System Function
    ''Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
    'Public Delegate Sub CallbackDelegate()

    '------------------------'
    ' Constants for PCI-9527 '
    '------------------------'
    'DDS Constants
    Public Const P9527_AI_MaxDDSFreq As UInteger = 432000
    Public Const P9527_AI_MinDDSFreq As UInteger = 2000
    Public Const P9527_AO_MaxDDSFreq As UInteger = 216000
    Public Const P9527_AO_MinDDSFreq As UInteger = 1000
    'DDS Phase
    Public Const P9527_DDSPhase_0D As UShort = &H0S
    Public Const P9527_DDSPhase_11R25D As UShort = &H1S
    Public Const P9527_DDSPhase_22R5D As UShort = &H2S
    Public Const P9527_DDSPhase_33R75D As UShort = &H3S
    Public Const P9527_DDSPhase_45D As UShort = &H4S
    Public Const P9527_DDSPhase_56R25D As UShort = &H5S
    Public Const P9527_DDSPhase_67R5D As UShort = &H8S
    Public Const P9527_DDSPhase_78R75D As UShort = &H7S
    Public Const P9527_DDSPhase_90D As UShort = &H8S
    Public Const P9527_DDSPhase_101R25D As UShort = &H9S
    Public Const P9527_DDSPhase_112R5D As UShort = &HAS
    Public Const P9527_DDSPhase_123R75D As UShort = &HBS
    Public Const P9527_DDSPhase_135D As UShort = &HCS
    Public Const P9527_DDSPhase_146R25D As UShort = &HDS
    Public Const P9527_DDSPhase_157R5D As UShort = &HES
    Public Const P9527_DDSPhase_168R75D As UShort = &HFS
    Public Const P9527_DDSPhase_180D As UShort = &H10S
    Public Const P9527_DDSPhase_191R25D As UShort = &H11S
    Public Const P9527_DDSPhase_202R5D As UShort = &H12S
    Public Const P9527_DDSPhase_213R75D As UShort = &H13S
    Public Const P9527_DDSPhase_225D As UShort = &H14S
    Public Const P9527_DDSPhase_236R25D As UShort = &H15S
    Public Const P9527_DDSPhase_247R5D As UShort = &H16S
    Public Const P9527_DDSPhase_258R75D As UShort = &H17S
    Public Const P9527_DDSPhase_270D As UShort = &H18S
    Public Const P9527_DDSPhase_281R25D As UShort = &H19S
    Public Const P9527_DDSPhase_292R5D As UShort = &H1AS
    Public Const P9527_DDSPhase_303R75D As UShort = &H1BS
    Public Const P9527_DDSPhase_315D As UShort = &H1CS
    Public Const P9527_DDSPhase_326R25D As UShort = &H1DS
    Public Const P9527_DDSPhase_337R5D As UShort = &H1ES
    Public Const P9527_DDSPhase_348R75D As UShort = &H1FS

    'AI Constants
    'AI Select Channel
    Public Const P9527_AI_CH_0 As UShort = 0
    Public Const P9527_AI_CH_1 As UShort = 1
    Public Const P9527_AI_CH_DUAL As UShort = 2
    'Input Type
    Public Const P9527_AI_Differential As UShort = &H0S
    Public Const P9527_AI_PseudoDifferential As UShort = &H1S
    'Input Coupling
    Public Const P9527_AI_Coupling_DC As UShort = &H0S
    Public Const P9527_AI_Coupling_AC As UShort = &H10S
    Public Const P9527_AI_EnableIEPE As UShort = &H20S

    'AO Constants
    'AO Select Channel
    Public Const P9527_AO_CH_0 As UShort = 0
    Public Const P9527_AO_CH_1 As UShort = 1
    Public Const P9527_AO_CH_DUAL As UShort = 2
    'Input Type
    Public Const P9527_AO_Differential As UShort = &H0S
    Public Const P9527_AO_PseudoDifferential As UShort = &H1S
    Public Const P9527_AO_BalancedOutput As UShort = &H2S

    'Trigger Constants
    'Trigger Mode
    Public Const P9527_TRG_MODE_POST As UShort = &H0S
    Public Const P9527_TRG_MODE_DELAY As UShort = &H1S
    'Trigger Target
    Public Const P9527_TRG_NONE As UShort = &H0S
    Public Const P9527_TRG_AI As UShort = &H1S
    Public Const P9527_TRG_AO As UShort = &H2S
    Public Const P9527_TRG_ALL As UShort = &H3S
    'Trigger Source
    Public Const P9527_TRG_SRC_SOFT As UShort = &H0S
    Public Const P9527_TRG_SRC_EXTD As UShort = &H10S
    Public Const P9527_TRG_SRC_ANALOG As UShort = &H20S
    Public Const P9527_TRG_SRC_SSI9 As UShort = &H30S
    Public Const P9527_TRG_SRC_NOWAIT As UShort = &H40S
    Public Const P9527_TRG_SRC_PXI_STARTIN As UShort = &H70S
    Public Const P9527_TRG_SRC_PXI_BUS0 As UShort = &H80S
    Public Const P9527_TRG_SRC_PXI_BUS1 As UShort = &H90S
    Public Const P9527_TRG_SRC_PXI_BUS2 As UShort = &HA0S
    Public Const P9527_TRG_SRC_PXI_BUS3 As UShort = &HB0S
    Public Const P9527_TRG_SRC_PXI_BUS4 As UShort = &HC0S
    Public Const P9527_TRG_SRC_PXI_BUS5 As UShort = &HD0S
    Public Const P9527_TRG_SRC_PXI_BUS6 As UShort = &HE0S
    Public Const P9527_TRG_SRC_PXI_BUS7 As UShort = &HF0S
    'Trigger Polarity
    Public Const P9527_TRG_Negative As UShort = &H0S
    Public Const P9527_TRG_Positive As UShort = &H100S
    'ReTrigger
    Public Const P9527_TRG_EnReTigger As UShort = &H200S
    'Analog Trigger Source
    Public Const P9527_TRG_Analog_CH0 As UShort = 0
    Public Const P9527_TRG_Analog_CH1 As UShort = 1
    'Analog Trigger Source
    Public Const P9527_TRG_Analog_Above_threshold As UShort = 0
    Public Const P9527_TRG_Analog_Below_threshold As UShort = 1

    'Trigger out
    Public Const P9527_TRG_OUT_SSI9 As UShort = &H40S
    Public Const P9527_TRG_OUT_PXI_BUS0 As UShort = &H40S
    Public Const P9527_TRG_OUT_PXI_BUS1 As UShort = &H41S
    Public Const P9527_TRG_OUT_PXI_BUS2 As UShort = &H42S
    Public Const P9527_TRG_OUT_PXI_BUS3 As UShort = &H43S
    Public Const P9527_TRG_OUT_PXI_BUS4 As UShort = &H44S
    Public Const P9527_TRG_OUT_PXI_BUS5 As UShort = &H45S
    Public Const P9527_TRG_OUT_PXI_BUS6 As UShort = &H46S
    Public Const P9527_TRG_OUT_PXI_BUS7 As UShort = &H47S

    '------------------------'
    ' Constants for PXI-9529 '
    '------------------------'
    'AI Constants
    'AI Select Channel
    Public Const P9529_AI_CH_0 As UShort = 0
    Public Const P9529_AI_CH_1 As UShort = 1
    Public Const P9529_AI_CH_2 As UShort = 2
    Public Const P9529_AI_CH_3 As UShort = 3
    Public Const P9529_AI_CH_4 As UShort = 4
    Public Const P9529_AI_CH_5 As UShort = 5
    Public Const P9529_AI_CH_6 As UShort = 6
    Public Const P9529_AI_CH_7 As UShort = 7
    'Input Type
    Public Const P9529_AI_Diff As UShort = &H0S
    Public Const P9529_AI_PseDiff As UShort = &H1S
    'Input Coupling
    Public Const P9529_AI_Coupling_DC As UShort = &H0S
    Public Const P9529_AI_Coupling_AC As UShort = &H4S
    Public Const P9529_AI_EnableIEPE As UShort = &H6S

    'Timebase Constants
    'Timebase Source
    Public Const P9529_Internal As UShort = &H0S
    Public Const P9529_PXI10M As UShort = &H1S
    Public Const P9529_PXI100M As UShort = &H2S
    Public Const P9529_PXITRIGBus As UShort = &H3S
    Public Const P9529_TimeBase_SSI As UShort = &H4S
    'Timebase Output Control
    Public Const P9529_CLKOut_Disable As UShort = &H0S
    Public Const P9529_CLKOut_Enable As UShort = &H10S
    'Timebase from/to TRIGBUS
    Public Const P9529_ExtCLK_TrgBus0 As UShort = &H0S
    Public Const P9529_ExtCLK_TrgBus1 As UShort = &H100S
    Public Const P9529_ExtCLK_TrgBus2 As UShort = &H200S
    Public Const P9529_ExtCLK_TrgBus3 As UShort = &H300S
    Public Const P9529_ExtCLK_TrgBus4 As UShort = &H400S
    Public Const P9529_ExtCLK_TrgBus5 As UShort = &H500S
    Public Const P9529_ExtCLK_TrgBus6 As UShort = &H600S
    Public Const P9529_ExtCLK_TrgBus7 As UShort = &H700S
    Public Const P9529_ExtCLK_SSI As UShort = &H800S

    'Trigger Constants
    'Trigger Target
    Public Const P9529_TRG_NONE As UShort = &H0S
    Public Const P9529_TRG_AI As UShort = &H1S
    'Trigger Mode
    Public Const P9529_TRG_MODE_POST As UShort = &H0S
    Public Const P9529_TRG_MODE_DELAY As UShort = &H1S
    'Trigger Source
    Public Const P9529_TRG_SRC_SOFT As UShort = &H0S
    Public Const P9529_TRG_SRC_EXTD As UShort = &H10S
    Public Const P9529_TRG_SRC_ANALOG As UShort = &H20S
    Public Const P9529_TRG_SRC_SSI As UShort = &HD0S
    Public Const P9529_TRG_SRC_NOWAIT As UShort = &H40S
    Public Const P9529_TRG_SRC_PXIE_STARTIN As UShort = &H60S
    Public Const P9529_TRG_SRC_PXI_STARTIN As UShort = &H70S
    Public Const P9529_TRG_SRC_PXI_BUS0 As UShort = &H80S
    Public Const P9529_TRG_SRC_PXI_BUS1 As UShort = &H90S
    Public Const P9529_TRG_SRC_PXI_BUS2 As UShort = &HA0S
    Public Const P9529_TRG_SRC_PXI_BUS3 As UShort = &HB0S
    Public Const P9529_TRG_SRC_PXI_BUS4 As UShort = &HC0S
    Public Const P9529_TRG_SRC_PXI_BUS5 As UShort = &HD0S
    Public Const P9529_TRG_SRC_PXI_BUS6 As UShort = &HE0S
    Public Const P9529_TRG_SRC_PXI_BUS7 As UShort = &HF0S
    'Trigger Polarity
    Public Const P9529_TRG_Negative As UShort = &H0S
    Public Const P9529_TRG_Positive As UShort = &H100S
    'ReTrigger
    Public Const P9529_TRG_EnReTigger As UShort = &H200S
    'Analog Trigger Source
    Public Const P9529_TRG_Analog_CH0 As UShort = 0
    Public Const P9529_TRG_Analog_CH1 As UShort = 1
    Public Const P9529_TRG_Analog_CH2 As UShort = 2
    Public Const P9529_TRG_Analog_CH3 As UShort = 3
    Public Const P9529_TRG_Analog_CH4 As UShort = 4
    Public Const P9529_TRG_Analog_CH5 As UShort = 5
    Public Const P9529_TRG_Analog_CH6 As UShort = 6
    Public Const P9529_TRG_Analog_CH7 As UShort = 7
    'Analog Trigger Source
    Public Const P9529_TRG_Analog_Above As UShort = 0
    Public Const P9529_TRG_Analog_Below As UShort = 1

    'Trigger out
    Public Const P9529_TRG_OUT_PXI_BUS0 As UShort = &H40S
    Public Const P9529_TRG_OUT_PXI_BUS1 As UShort = &H41S
    Public Const P9529_TRG_OUT_PXI_BUS2 As UShort = &H42S
    Public Const P9529_TRG_OUT_PXI_BUS3 As UShort = &H43S
    Public Const P9529_TRG_OUT_PXI_BUS4 As UShort = &H44S
    Public Const P9529_TRG_OUT_PXI_BUS5 As UShort = &H45S
    Public Const P9529_TRG_OUT_PXI_BUS6 As UShort = &H46S
    Public Const P9529_TRG_OUT_PXI_BUS7 As UShort = &H47S
    Public Const P9529_TRG_OUT_SSI As UShort = &H45S

    'Multi-Card Sync Constants
    'Multi-Card setting
    Public Const P9529_SYN_Disable As UShort = &H0S
    Public Const P9529_SYN_MasterCard As UShort = &H1S
    Public Const P9529_SYN_SlaveCard As UShort = &H2S
    'Multi-Card PDN via specific source
    Public Const P9529_SYN_PXI_BUS0 As UShort = &H0S
    Public Const P9529_SYN_PXI_BUS1 As UShort = &H1S
    Public Const P9529_SYN_PXI_BUS2 As UShort = &H2S
    Public Const P9529_SYN_PXI_BUS3 As UShort = &H3S
    Public Const P9529_SYN_PXI_BUS4 As UShort = &H4S
    Public Const P9529_SYN_PXI_BUS5 As UShort = &H5S
    Public Const P9529_SYN_PXI_BUS6 As UShort = &H6S
    Public Const P9529_SYN_PXI_BUS7 As UShort = &H7S
    Public Const P9529_SYN_PXI_STARTRIG As UShort = &H8S
    Public Const P9529_SYN_PXIE_STARTRIG As UShort = &H9S
    Public Const P9529_SYN_FRONT_SMB As UShort = &HAS
    Public Const P9529_SYN_SSI As UShort = &H1S
    'Status Mask
    Public Const P9529_SYN_IsMultiCard As UShort = &H1S
    Public Const P9529_SYN_IsMasterCard As UShort = &H2S
    Public Const P9529_SYN_IsPDNSyncReady As UShort = &H4S

    '----------------------------------------------------------------------------
    ' DSA-DASK Function prototype
    '----------------------------------------------------------------------------
    'Basic Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_Register_Card(ByVal cardType As UShort, ByVal card_num As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_Release_Card(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_SetTimebase(ByVal CardNumber As UShort, ByVal ClockSrc As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_ConfigSpeedRate(ByVal CardNumber As UShort, ByVal Func As UShort, ByVal Setting As UShort, ByVal SetDemandRate As Double, ByRef GetActualRate As Double) As Short
    End Function

    'AI Functions
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_9527_ConfigChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByVal ConfigCtrl As UShort, ByVal AutoResetBuf As Boolean) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_9529_ConfigChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal Enable As Boolean, ByVal AdRange As UShort, ByVal ConfigCtrl As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_9527_ConfigSampleRate(ByVal CardNumber As UShort, ByVal SetDemandRate As Double, ByRef GetActualRate As Double) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_AsyncCheck(ByVal CardNumber As UShort, ByRef Stopped As Boolean, ByRef AccessCnt As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_AsyncClear(ByVal CardNumber As UShort, ByRef AccessCnt As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_AsyncDblBufferHalfReady(ByVal CardNumber As UShort, ByRef HalfReady As Boolean, ByRef StopFlag As Boolean) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_AsyncDblBufferHandled(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_AsyncDblBufferMode(ByVal CardNumber As UShort, ByVal Enable As Boolean) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_AsyncDblBufferOverrun(ByVal CardNumber As UShort, ByVal op As UShort, ByRef overrunFlag As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_AsyncDblBufferToFile(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_AsyncReTrigNextReady(ByVal CardNumber As UShort, ByRef Ready As Boolean, ByRef StopFlag As Boolean, ByRef RdyTrigCnt As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_ContBufferReset(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_ContBufferSetup(ByVal CardNumber As UShort, ByVal Buffer As IntPtr, ByVal ReadCount As UInteger, ByRef BufferId As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_ContReadChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByVal Buffer() As UInteger, ByVal ReadCount As UInteger, ByVal SampleRate As Double, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_ContReadChannelToFile(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByVal FileName As String, ByVal ReadCount As UInteger, ByVal SampleRate As Double, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_ContStatus(ByVal CardNumber As UShort, ByRef Status As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_ContVScale(ByVal CardNumber As UShort, ByVal AdRange As UShort, ByVal readingArray As IntPtr, ByVal voltageArray() As Double, ByVal count As Integer) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_DataScaler(ByVal cardType As UShort, ByVal AdRange As UShort, ByVal readingArray As IntPtr, ByVal voltageArray() As Double, ByVal count As Integer) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_EventCallBack(ByVal CardNumber As UShort, ByVal Mode As UShort, ByVal EventType As UShort, ByVal callbackAddr As CallbackDelegate) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_InitialMemoryAllocated(ByVal CardNumber As UShort, ByRef MemSize As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AI_SetTimeOut(ByVal CardNumber As UShort, ByVal TimeOut As UInteger) As Short
    End Function

    'AO Functions
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_9527_ConfigChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByVal ConfigCtrl As UShort, ByVal AutoResetBuf As Boolean) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_9527_ConfigSampleRate(ByVal CardNumber As UShort, ByVal SetDemandRate As Double, ByRef GetActualRate As Double) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_AsyncCheck(ByVal CardNumber As UShort, ByRef Stopped As Boolean, ByRef AccessCnt As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_AsyncClear(ByVal CardNumber As UShort, ByRef AccessCnt As UInteger, ByVal stop_mode As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_AsyncDblBufferHalfReady(ByVal CardNumber As UShort, ByRef HalfReady As Boolean) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_AsyncDblBufferMode(ByVal CardNumber As UShort, ByVal Enable As Boolean) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_ContBufferReset(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_ContBufferSetup(ByVal CardNumber As UShort, ByVal Buffer As IntPtr, ByVal WriteCount As UInteger, ByRef BufferId As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_ContStatus(ByVal CardNumber As UShort, ByRef Status As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_ContWriteChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal BufId As UShort, ByVal WriteCount As UInteger, ByVal Iterations As UInteger, ByVal dwInterval As UInteger, ByVal definite As UShort, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_EventCallBack(ByVal CardNumber As UShort, ByVal Mode As UShort, ByVal EventType As UShort, ByVal callbackAddr As CallbackDelegate) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_InitialMemoryAllocated(ByVal CardNumber As UShort, ByRef MemSize As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_SetTimeOut(ByVal CardNumber As UShort, ByVal TimeOut As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_AO_VoltScale(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal Voltage As Double, ByRef binValue As UInteger) As Short
    End Function

    'Trigger Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_TRG_Config(ByVal CardNumber As UShort, ByVal FuncSel As UShort, ByVal TrigCtrl As UShort, ByVal ReTriggerCnt As UInteger, ByVal TriggerDelay As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_TRG_ConfigAnalogTrigger(ByVal CardNumber As UShort, ByVal ATrigSrc As UInteger, ByVal ATrigMode As UInteger, ByVal Threshold As Double) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_TRG_SoftTriggerGen(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_TRG_SourceConn(ByVal CardNumber As UShort, ByVal sigCode As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_TRG_SourceDisConn(ByVal CardNumber As UShort, ByVal sigCode As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_TRG_SourceClear(ByVal CardNumber As UShort) As Short
    End Function

    'Multi-Card Sync Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_SYN_ConfigMultiCard(ByVal CardNumber As UShort, ByVal Func As UShort, ByVal Parameter As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_SYN_CheckMultiCardStatus(ByVal CardNumber As UShort, ByRef Status As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_SYN_SyncStart(ByVal CardNumber As UShort) As Short
    End Function

    'Get Event or View Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function AI_GetEvent(ByVal CardNumber As UShort, ByRef hEvent As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function AO_GetEvent(ByVal CardNumber As UShort, ByRef hEvent As UInteger) As Short
    End Function

    'Common Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_GetActualRate(ByVal CardNumber As UShort, ByVal SampleRate As Double, ByRef ActualRate As Double) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_GetBaseAddr(ByVal CardNumber As UShort, ByRef BaseAddr As UInteger, ByRef BaseAddr2 As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_GetLCRAddr(ByVal CardNumber As UShort, ByRef LcrAddr As UInteger) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_GetFPGAVersion(ByVal CardNumber As UShort, ByRef FPGAVersion As UInteger) As Short
    End Function

    'Cal Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_Auto_Calibration_ALL(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_CAL_SetDefaultBank(ByVal CardNumber As UShort, ByVal bank As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_CAL_SaveToUserBank(ByVal CardNumber As UShort, ByVal bank As UShort) As Short
    End Function
    <DllImport("DSA-Dask.dll")>
    Public Shared Function DSA_CAL_LoadFromBank(ByVal CardNumber As UShort, ByVal bank As UShort) As Short
    End Function
End Class
