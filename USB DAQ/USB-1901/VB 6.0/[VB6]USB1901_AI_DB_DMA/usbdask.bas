Attribute VB_Name = "USBDASK"
Option Explicit

Type USBDAQ_DEVICE

    wModuleType As Long ' Defaults to Public access.

    wCardID As Long

End Type

'ADLink UD-DASK module Type
Global Const USB_1902 = 1
Global Const USB_1903 = 2
Global Const USB_1901 = 3
Global Const USB_2401 = 4
Global Const USB_7250 = 5
Global Const USB_7230 = 6
Global Const USB_2405 = 7

Global Const MAX_USB_DEVICE = 8

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

'Error code for driver API
Global Const ErrorAccessViolationDataCopy = -301
Global Const ErrorNoModuleFound = -302
Global Const ErrorCardIDDuplicated = -303
Global Const ErrorCardDisconnected = -304
Global Const ErrorInvalidScannedIndex = -305
Global Const ErrorUndefinedException = -306
Global Const ErrorInvalidDioConfig = -307
Global Const ErrorInvalidAOCfgCtrl = -308
Global Const ErrorInvalidAOTrigCtrl = -309
Global Const ErrorConflictWithSyncMode = -310
Global Const ErrorConflictWithFifoMode = -311
Global Const ErrorInvalidAOIteration = -312
Global Const ErrorZeroChannelNumber = -313
Global Const ErrorSystemCallFailed = -314
Global Const ErrorTimeoutFromSyncMode = -315
Global Const ErrorInvalidPulseCount = -316
Global Const ErrorInvalidDelayCount = -317
Global Const ErrorConflictWithDelay2 = -318
Global Const ErrorAOFifoCountTooLarge = -319
Global Const ErrorConflictWithWaveRepeat = -320
Global Const ErrorConflictWithReTrig = -321
Global Const ErrorInvalidTriggerChannel = -322
Global Const ErrorInvalidInputSignal = -323
Global Const ErrorInvalidConversionSrc = -324
Global Const ErrorInvalidRefVoltage = -325
Global Const ErrorCalibrateFailed = -326
Global Const ErrorInvalidCalData = -327
Global Const ErrorChanGainQueueTooLarge = -328
Global Const ErrorInvalidCardType = -329
Global Const ErrorInvalidChannel = -397
Global Const ErrorNullPoint = -398
Global Const ErrorInvalidParamSetting = -399

' -401 ~ -499 the Kernel error
Global Const ErrorAIStartFailed = -401
Global Const ErrorAOStartFailed = -402
Global Const ErrorConflictWithGPIOConfig = -403
Global Const ErrorEepromReadback = -404
Global Const ErrorConflictWithInfiniteOp = -405
Global Const ErrorWaitingUSBHostResponse = -406
Global Const ErrorAOFifoModeTimeout = -407
Global Const ErrorInvalidModuleFunction = -408
Global Const ErrorAdFifoFull = -409
Global Const ErrorInvalidTransferCount = -410
Global Const ErrorConflictWithAIConfig = -411
Global Const ErrorDDSConfigFailed = -412
Global Const ErrorFpgaAccessFailed = -413

Global Const ErrorUndefinedKernelError = -420

Global Const ErrorSyncModeNotSupport = -501

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
Global Const AD_B_1_5_V = 30
Global Const AD_B_0_2125_V = 31
Global Const AD_B_40_V = 32  ' PCI-9527 AI
Global Const AD_B_3_16_V = 33 ' PCI-9527 AI
Global Const AD_B_0_316_V = 34 ' PCI-9527 AI
Global Const AD_B_25_V = 35 ' Jeff added for USB-2401 AI
Global Const AD_B_12_5_V = 36

'Synchronous Mode
Global Const SYNCH_OP = 1
Global Const ASYNCH_OP = 2


'--------- Constants for USB-1901/USB-1902/USB-1903 --------------
'wConfigCtrl in UD_AI_1902_Config()
'Input Type
Global Const P1902_AI_NonRef_SingEnded = &H0
Global Const P1902_AI_SingEnded = &H1
Global Const P1902_AI_Differential = &H2

'Conversion Source
Global Const P1902_AI_CONVSRC_INT = &H0
Global Const P1902_AI_CONVSRC_EXT = &H80

'wTrigCtrl in UD_AI_1902_Config()
'Trigger Source
Global Const P1902_AI_TRGSRC_AI0 = &H20
Global Const P1902_AI_TRGSRC_AI1 = &H21
Global Const P1902_AI_TRGSRC_AI2 = &H22
Global Const P1902_AI_TRGSRC_AI3 = &H23
Global Const P1902_AI_TRGSRC_AI4 = &H24
Global Const P1902_AI_TRGSRC_AI5 = &H25
Global Const P1902_AI_TRGSRC_AI6 = &H26
Global Const P1902_AI_TRGSRC_AI7 = &H27
Global Const P1902_AI_TRGSRC_AI8 = &H28
Global Const P1902_AI_TRGSRC_AI9 = &H29
Global Const P1902_AI_TRGSRC_AI10 = &H2A
Global Const P1902_AI_TRGSRC_AI11 = &H2B
Global Const P1902_AI_TRGSRC_AI12 = &H2C
Global Const P1902_AI_TRGSRC_AI13 = &H2D
Global Const P1902_AI_TRGSRC_AI14 = &H2E
Global Const P1902_AI_TRGSRC_AI15 = &H2F
Global Const P1902_AI_TRGSRC_SOFT = &H30
Global Const P1902_AI_TRGSRC_DTRIG = &H31

'Trigger Polarity
Global Const P1902_AI_TrgNegative = &H0
Global Const P1902_AI_TrgPositive = &H40

'Gated Trigger Level
Global Const P1902_AI_Gate_ActiveHigh = &H0
Global Const P1902_AI_Gate_ActiveLow = &H40

'Trigger Mode
Global Const P1902_AI_TRGMOD_POST = &H0
Global Const P1902_AI_TRGMOD_GATED = &H80
Global Const P1902_AI_TRGMOD_DELAY = &H100

'ReTrigger
Global Const P1902_AI_EnReTigger = &H200



'AO Constants
'Conversion Source
Global Const P1902_AO_CONVSRC_INT = &H0
Global Const P1902_AO_TRIG_CTRL_MASK = (Not &H711)


'Trigger Mode
Global Const P1902_AO_TRGMOD_POST = &H0
Global Const P1902_AO_TRGMOD_DELAY = &H1

'Trigger Source
Global Const P1902_AO_TRGSRC_SOFT = &H0
Global Const P1902_AO_TRGSRC_DTRIG = &H10

'Trigger Edge
Global Const P1902_AO_TrgPositive = &H100
Global Const P1902_AO_TrgNegative = &H0

'Enable Re-Trigger
Global Const P1902_AO_EnReTigger = &H200

'Flag for AO Waveform Seperation Interval COunt Register (AO_WSIC)
Global Const P1902_AO_EnDelay2 = &H400

'Constants for USB-2401
'wConfigCtrl in UD_AI_2401_Config()
'Input Type
'V >=2.5V, V<2.5,
'Current,
'RTD (4 wire), RTD (3-wire), RTD (2-wire),
'Resistor, Thermocouple, Full-Bridge, Half-Bridge
Global Const P2401_Voltage_2D5V_Above = &H0
Global Const P2401_Voltage_2D5V_Below = &H1
Global Const P2401_Current = &H2
Global Const P2401_RTD_4_Wire = &H3
Global Const P2401_RTD_3_Wire = &H4
Global Const P2401_RTD_2_Wire = &H5
Global Const P2401_Resistor = &H6
Global Const P2401_ThermoCouple = &H7
Global Const P2401_Full_Bridge = &H8
Global Const P2401_Half_Bridge = &H9
Global Const P2401_ThermoCouple_Gnd = &HA
Global Const P2401_350Ohm_Full_Bridge = &HB
Global Const P2401_350Ohm_Half_Bridge = &HC
Global Const P2401_120Ohm_Full_Bridge = &HD
Global Const P2401_120Ohm_Half_Bridge = &HE
'Conversion Source
' bit 9 in AI_ACQMCR
Global Const P2401_AI_CONVSRC_INT = &H0
'wTrigCtrl in UD_AI_2401_Config()
'Trigger Source
'bit 8:3 in AI_ACQMCR
Global Const P2401_AI_TRGSRC_SOFT = &H30
Global Const P2401_AI_TRGSRC_DTRIG = &H31
'Trigger Edge
'bit 2 in AI_ACQMCR
Global Const P2401_AI_TrgPositive = &H40
Global Const P2401_AI_TrgNegative = &H0
'Trigger Mode
Global Const P2401_AI_TRGMOD_POST = &H0
'wMAvgStageCh1 ~ wMAvgStageCh4 in UD_AI_2401_PollConfig()
Global Const P2401_Polling_MAvg_Disable = &H0
Global Const P2401_Polling_MAvg_2_Sampes = &H1
Global Const P2401_Polling_MAvg_4_Sampes = &H2
Global Const P2401_Polling_MAvg_8_Sampes = &H3
Global Const P2401_Polling_MAvg_16_Sampes = &H4
'wEnContPolling in UD_AI_2401_PollConfig()
Global Const P2401_Continue_Polling_Disable = &H0
Global Const P2401_Continue_Polling_Enable = &H1
'wPollSpeed in UD_AI_2401_PollConfig()
Global Const P2401_ADC_2000_SPS = &H9
Global Const P2401_ADC_1000_SPS = &H8
Global Const P2401_ADC_640_SPS = &H7
Global Const P2401_ADC_320_SPS = &H6
Global Const P2401_ADC_160_SPS = &H5
Global Const P2401_ADC_80_SPS = &H4
Global Const P2401_ADC_40_SPS = &H3
Global Const P2401_ADC_20_SPS = &H2

' AI Constants
' AI Select Channel
      
''Global Const P2405_AI_CH_0 As UShort = &H0
''Global Const P2405_AI_CH_1 As UShort = &H1
''Global Const P2405_AI_CH_2 As UShort = &H2
''Global Const P2405_AI_CH_3 As UShort = &H3


' Input Coupling
''Global Const P2405_AI_EnableIEPE As UShort = &H4
''Global Const P2405_AI_DisableIEPE As UShort = &H8
''Global Const P2405_AI_Coupling_AC As UShort = &H10
''Global Const P2405_AI_Coupling_None As UShort = &H20
                   

' Input Type
''Global Const P2405_AI_Differential As UShort = &H0
''Global Const P2405_AI_PseudoDifferential As UShort = &H40
       
' Conversion Source
''Global Const P2405_AI_CONVSRC_INT As UShort = &H0
''Global Const P2405_AI_CONVSRC_EXT As UShort = &H200

' Trigger Source
''Global Const P2405_AI_TRGSRC_AI0 As UShort = &H200
''Global Const P2405_AI_TRGSRC_AI1 As UShort = &H208
''Global Const P2405_AI_TRGSRC_AI2 As UShort = &H210
''Global Const P2405_AI_TRGSRC_AI3 As UShort = &H218
''Global Const P2405_AI_TRGSRC_SOFT As UShort = &H380
''Global Const P2405_AI_TRGSRC_DTRIG As UShort = &H388

' Trigger Edge
''Global Const P2405_AI_TrgPositive As UShort = &H4
'Global Const P2405_AI_TrgNegative As UShort = &H0

' Gated Trigger Level
''Global Const P2405_AI_Gate_ActiveHigh As UShort = &H4
''Global Const P2405_AI_Gate_ActiveLow As UShort = &H0

' ReTrigger
'Global Const P2405_AI_EnReTigger As UShort = &H2000

' AI Trigger Mode
'Global Const P2405_AI_TRGMOD_POST As UShort = &H0
'Global Const P2405_AI_TRGMOD_DELAY As UShort = &H4000
'Global Const P2405_AI_TRGMOD_PRE As UShort = &H8000
'Global Const P2405_AI_TRGMOD_MIDDLE As UShort = &HC000
'Global Const P2405_AI_TRGMOD_GATED As UShort = &H1000

' UD_DIO_2405_Config
'Global Const P2405_DIGITAL_INPUT As UShort = &H30
'Global Const P2405_COUNTER_INPUT As UShort = &H31
'Global Const P2405_DIGITAL_OUTPUT As UShort = &H32
'Global Const P2405_PULSE_OUTPUT As UShort = &H33

' GPIO/GPTC Configuration

Global Const GPIO_IGNORE_CONFIG = &H0

Global Const GPTC0_GPO1 = &H1
Global Const GPI0_3_GPO0_1 = &H2
Global Const ENC0_GPO0 = &H4
Global Const GPTC0_TC1 = &H8

Global Const GPTC2_GPO3 = &H10
Global Const GPI4_7_GPO2_3 = &H20
Global Const ENC1_GPO2 = &H40
Global Const GPTC2_TC3 = &H80

' GPIO Port
Global Const GPIO_PortA = 1
Global Const GPIO_PortB = 2

' General Purpose Timer/Counter for USB-1901/1902/1903 */

'Counter Mode
Global Const SimpleGatedEventCNT = &H1
Global Const SinglePeriodMSR = &H2
Global Const SinglePulseWidthMSR = &H3
Global Const SingleGatedPulseGen = &H4
Global Const SingleTrigPulseGen = &H5
Global Const RetrigSinglePulseGen = &H6
Global Const SingleTrigContPulseGen = &H7
Global Const ContGatedPulseGen = &H8
Global Const EdgeSeparationMSR = &H9
Global Const SingleTrigContPulseGenPWM = &HA
Global Const ContGatedPulseGenPWM = &HB
Global Const CW_CCW_Encoder = &HC
Global Const x1_AB_Phase_Encoder = &HD
Global Const x2_AB_Phase_Encoder = &HE
Global Const x4_AB_Phase_Encoder = &HF
Global Const Phase_Z = &H10
Global Const MultipleGatedPulseGen = &H11

'GPTC clock source
Global Const GPTC_CLK_SRC_Ext = &H1
Global Const GPTC_CLK_SRC_Int = &H0
Global Const GPTC_GATE_SRC_Ext = &H2
Global Const GPTC_GATE_SRC_Int = &H0
Global Const GPTC_UPDOWN_Ext = &H4
Global Const GPTC_UPDOWN_Int = &H0
'GPTC clock polarity
Global Const GPTC_CLKSRC_LACTIVE = &H1
Global Const GPTC_CLKSRC_HACTIVE = &H0
Global Const GPTC_GATE_LACTIVE = &H2
Global Const GPTC_GATE_HACTIVE = &H0
Global Const GPTC_UPDOWN_LACTIVE = &H4
Global Const GPTC_UPDOWN_HACTIVE = &H0
Global Const GPTC_OUTPUT_LACTIVE = &H8
Global Const GPTC_OUTPUT_HACTIVE = &H0
'GPTC OP Parameter
Global Const IntGate = &H0
Global Const IntUpDnCTR = &H1
Global Const IntENABLE = &H2

'DAQ Event type for the event message
Global Const AIEnd = 0
Global Const AOEnd = 0
Global Const DIEnd = 0
Global Const DOEnd = 0
Global Const DBEvent = 1
Global Const TrigEvent = 2

'Encoder/GPTC Constants
Global Const P1902_GPTC0 = &H0
Global Const P1902_GPTC1 = &H1

'Encoder Setting Event Control
Global Const P1902_EPT_PULWIDTH_200us = &H0
Global Const P1902_EPT_PULWIDTH_2ms = &H1
Global Const P1902_EPT_PULWIDTH_20ms = &H2
Global Const P1902_EPT_PULWIDTH_200ms = &H3
Global Const P1902_EPT_TRGOUT_GPO = &H4
Global Const P1902_EPT_TRGOUT_CALLBACK = &H8
'Event Type
Global Const P1902_EVT_TYPE_EPT0 = &H0
Global Const P1902_EVT_TYPE_EPT1 = &H1
'Constants for I Squared C (I2C)
'I2C Port
Global Const I2C_Port_A = 0
'I2C Control Operation
Global Const I2C_ENABLE = 0
Global Const I2C_STOP = 1
'convert from enum
Global Const UD_CTR_Filter_Disable = 0
Global Const UD_CTR_Filter_Enable = 1
Global Const UD_CTR_Reset_Rising_Edge_Counter = 2
Global Const UD_CTR_Reset_Frequency_Counter = 4
Global Const UD_CTR_Polarity_Positive = 0
Global Const UD_CTR_Polarity_Negative = 8

Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Long, ByVal dwMilliseconds As Long) As Long
'-------------------------------------------------------------------'
'  PCIS-DASK Function prototype                                     '
'-------------------------------------------------------------------'
'Basic Functions
Declare Function UD_Register_Card Lib "Usb-Dask.dll" (ByVal cardType As Integer, ByVal card_num As Integer) As Integer
Declare Function UD_Release_Card Lib "Usb-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function UD_Device_Scan Lib "Usb-Dask.dll" (ByRef pModuleNum As Integer, ByRef pAvailModules As USBDAQ_DEVICE) As Integer

'AI Functions
Declare Function UD_AI_1902_Config Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal TrgLevel As Long, ByVal ReTriggerCnt As Long, ByVal DelayCount As Long) As Integer
Declare Function UD_AI_2401_Config Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wChanCfg1 As Integer, ByVal wChanCfg2 As Integer, ByVal wChanCfg3 As Integer, ByVal wChanCfg4 As Integer, ByVal wTrigCtrl As Integer) As Integer
Declare Function UD_AI_2401_PollConfig Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wPollSpeed As Integer, ByVal wMAvgStageCh1 As Integer, ByVal wMAvgStageCh2 As Integer, ByVal wMAvgStageCh3 As Integer, ByVal wMAvgStageCh4 As Integer) As Integer
Declare Function UD_AI_1902_CounterInterval Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal ScanIntrv As Long, ByVal SampIntrv As Long) As Integer

Declare Function UD_AI_AsyncCheck Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, Stopped As Byte, AccessCnt As Long) As Integer
Declare Function UD_AI_AsyncClear Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, AccessCnt As Long) As Integer
Declare Function UD_AI_AsyncDblBufferHalfReady Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, HalfReady As Byte, StopFlag As Byte) As Integer
Declare Function UD_AI_AsyncDblBufferMode Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Enable As Byte) As Integer
Declare Function UD_AI_AsyncDblBufferTransfer Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef Buffer As Integer) As Integer
Declare Function UD_AI_AsyncDblBufferTransfer32 Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef Buffer As Long) As Integer
Declare Function UD_AI_AsyncDblBufferOverrun Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal op As Integer, overrunFlag As Integer) As Integer
Declare Function UD_AI_AsyncDblBufferHandled Lib "Usb-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function UD_AI_AsyncDblBufferToFile Lib "Usb-Dask.dll" (ByVal CardNumber As Integer) As Integer
Declare Function UD_AI_AsyncReTrigNextReady Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, Ready As Byte, StopFlag As Byte, RdyTrigCnt As Long) As Integer
'Declare Function UD_AI_ContReadChannel Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Buffer As Long, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function UD_AI_ContReadChannel Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Buffer As Integer, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function UD_AI_ContReadMultiChannels Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Chans As Integer, AdRanges As Integer, ByRef Buffer As Integer, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function UD_AI_ContReadChannelToFile Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, ByVal FileName As String, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function UD_AI_ContReadMultiChannelsToFile Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Chans As Integer, AdRanges As Integer, ByVal FileName As String, ByVal ReadCount As Long, ByVal SampleRate As Double, ByVal SyncMode As Integer) As Integer
Declare Function UD_AI_EventCallBack Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Mode As Integer, ByVal EventType As Integer, ByVal callbackAddr As Long) As Integer
Declare Function UD_AI_InitialMemoryAllocated Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, MemSize As Long) As Integer
Declare Function UD_AI_ReadChannel Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Value As Integer) As Integer
Declare Function UD_AI_VReadChannel Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal AdRange As Integer, Voltage As Double) As Integer
Declare Function UD_AI_ReadMultiChannels Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Chans As Integer, AdRanges As Integer, ByRef Buffer As Integer) As Integer
Declare Function UD_AI_VoltScale Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, ByVal reading As Integer, Voltage As Double) As Integer
Declare Function UD_AI_ContVScale Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, readingArray As Integer, voltageArray As Double, ByVal CCount As Long) As Integer
Declare Function UD_AI_2401_Scale32 Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, ByVal inType As Integer, ByVal reading As Long, ByRef Voltage As Double) As Integer
Declare Function UD_AI_2401_ContVScale32 Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, ByVal inType As Integer, ByRef readingArray As Long, ByRef voltageArray As Double, ByVal count As Long) As Integer
Declare Function UD_AI_SetTimeOut Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal TimeOut As Long) As Integer
Declare Function UD_AI_Moving_Average32 Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef SrcBuf As Long, ByRef DesBuf As Long, ByVal dwTgChIdx As Long, ByVal dwTotalCh As Long, ByVal dwMovAvgWindow As Long, ByVal dwSamplCnt As Long) As Integer
' 2012Oct18, Jeff added for USB-2405
Declare Function UD_AI_2405_Chan_Config Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wChanCfg1 As Integer, ByVal wChanCfg2 As Integer, ByVal wChanCfg3 As Integer, ByVal wChanCfg4 As Integer) As Integer
Declare Function UD_AI_2405_Trig_Config Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wConvSrc As Integer, ByVal wTrigMode As Integer, ByVal wTrigCtrl As Integer, ByVal dwReTrigCnt As Long, ByVal dwDLY1Cnt As Long, ByVal dwDLY2Cnt As Long, ByVal dwTrgLevel As Long) As Integer
Declare Function UD_AI_VoltScale32 Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, ByVal inType As Integer, ByVal reading As Long, ByRef Voltage As Double) As Integer
Declare Function UD_AI_ContVScale32 Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal AdRange As Integer, ByVal inType As Integer, ByRef readingArray As Long, ByRef voltageArray As Double, ByVal count As Long) As Integer
Declare Function UD_AI_AsyncBufferTransfer322 Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef Buffer As Long, ByVal offset As Long, ByVal count As Long) As Integer
Declare Function UD_AI_DDS_ActualRate_Get Lib "Usb-Dask.dll" (ByVal CardNumber, ByVal SampleRate As Double, ByRef ActualRate As Double) As Integer

'AO Functions
Declare Function UD_AO_1902_Config Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal ConfigCtrl As Integer, ByVal TrigCtrl As Integer, ByVal ReTrgCnt As Long, ByVal DLY1Cnt As Long, ByVal DLY2Cnt As Long) As Integer
Declare Function UD_AO_AsyncCheck Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, Stopped As Byte, AccessCnt As Long) As Integer
Declare Function UD_AO_AsyncClear Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, AccessCnt As Long, ByVal stop_mode As Integer) As Integer
Declare Function UD_AO_AsyncDblBufferHalfReady Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, HalfReady As Byte) As Integer
Declare Function UD_AO_AsyncDblBufferMode Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Enable As Byte, ByVal bEnFifoMode As Byte) As Integer
Declare Function UD_AO_ContBufferCompose Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal TotalChnCount As Integer, ByVal ChnNum As Integer, ByVal UpdateCount As Long, ConBuffer As Any, Buffer As Any) As Integer
Declare Function UD_AO_AsyncDblBufferTransfer Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wBufferID As Integer, Buffer As Integer) As Integer
Declare Function UD_AO_ContWriteChannel Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal BufId As Integer, ByVal WriteCount As Long, ByVal Iterations As Long, ByVal CHUI As Long, ByVal definite As Integer, ByVal SyncMode As Integer) As Integer
Declare Function UD_AO_ContWriteMultiChannels Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal NumChans As Integer, Chans As Integer, ByVal BufId As Integer, ByVal WriteCount As Long, ByVal Iterations As Long, ByVal CHUI As Long, ByVal definite As Integer, ByVal SyncMode As Integer) As Integer
Declare Function UD_AO_EventCallBack Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Mode As Integer, ByVal EventType As Integer, ByVal callbackAddr As Long) As Integer
Declare Function UD_AO_InitialMemoryAllocated Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, MemSize As Long) As Integer
Declare Function UD_AO_SetTimeOut Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal TimeOut As Long) As Integer
Declare Function UD_AO_VoltScale Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal Voltage As Double, binValue As Integer) As Integer
Declare Function UD_AO_VWriteChannel Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal Voltage As Double) As Integer
Declare Function UD_AO_WriteChannel Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Channel As Integer, ByVal Value As Integer) As Integer

'DIO Configuration Functions
Declare Function UD_DIO_1902_Config Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wPart1Cfg As Integer, ByVal wPart2Cfg As Integer) As Integer
Declare Function UD_DIO_2401_Config Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wPart1Cfg As Integer) As Integer
' 2012Oct18, Jeff added for USB-2405
Declare Function UD_DIO_2405_Config Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wPart1Cfg As Integer, ByVal wPart2Cfg As Integer) As Integer

'DI Functions
Declare Function UD_DI_ReadPort Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, Value As Long) As Integer
Declare Function UD_DI_ReadLine Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal LLine As Integer, Value As Integer) As Integer

'DO Functions
Declare Function UD_DO_ReadLine Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal LLine As Integer, Value As Integer) As Integer
Declare Function UD_DO_ReadPort Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, Value As Long) As Integer
Declare Function UD_DO_WriteLine Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal LLine As Integer, ByVal Value As Integer) As Integer
Declare Function UD_DO_WritePort Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal Port As Integer, ByVal Value As Long) As Integer


'Timer/Counter Function
Declare Function UD_GPTC_Clear Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer) As Integer
Declare Function UD_GPTC_Control Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, ByVal ParamID As Integer, ByVal Value As Integer) As Integer
Declare Function UD_GPTC_Read Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, Value As Long) As Integer
Declare Function UD_GPTC_Setup Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, ByVal Mode As Integer, ByVal SrcCtrl As Integer, ByVal PolCtrl As Integer, ByVal LReg1_Val As Long, ByVal LReg2_Val As Long, ByVal PulseCount As Long) As Integer
Declare Function UD_GPTC_Status Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal GCtr As Integer, Value As Integer) As Integer

'Get Event or View Functions
Declare Function UD_AI_GetEvent Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, hEvent As Object) As Integer
Declare Function UD_AO_GetEvent Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, hEvent As Object) As Integer
Declare Function UD_AI_GetView Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, View As Long) As Integer
Declare Function UD_AO_GetView Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, View As Long) As Integer

'Common Functions
Declare Function UD_GetActualRate Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal SampleRate As Double, ActualRate As Double) As Integer
Declare Function UD_GetCardIndexFromID Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, cardType As Integer, cardIndex As Integer) As Integer
Declare Function UD_GetCardType Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, cardType As Integer) As Integer
Declare Function UD_IdentifyLED_Control Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal bEnable As Byte) As Integer


'---------------------------------------------------------------------------

Declare Function UD_GetFPGAVersion Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef pdwFPGAVersion As Long) As Integer

Declare Function UD_1902_Trimmer_Set Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal bValue As Byte) As Integer

Declare Function usbdaq_1902_RefVol_WriteEeprom Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef RefVol As Double, ByVal wTrimmer As Integer) As Integer

Declare Function usbdaq_1902_RefVol_ReadEeprom Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef RefVol As Double, ByRef wTrimmer As Integer) As Integer

Declare Function usbdaq_1902_CalSrc_Switch Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wOperation As Integer, ByVal wCalSrc As Integer) As Integer

Declare Function usbdaq_1902_Calibration_All Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef pCalOp As Integer, ByRef pCalSrc As Integer) As Integer

Declare Function usbdaq_1903_Calibration_All Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal RefVol_10V As Double, ByRef pCalOp As Integer, ByRef pCalSrc As Integer) As Integer

Declare Function usbdaq_1903_Current_Calibration Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wOperation As Integer, ByVal wCalChan As Integer, ByVal fRefCur As Double, ByRef pCalReg As Integer) As Integer

Declare Function usbdaq_1903_WriteEeprom Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wTrimmer As Integer, ByRef CALdata As Byte) As Integer

Declare Function usbdaq_ReadPort Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByVal wPortAddr As Integer, ByRef pdwData As Long) As Integer

Declare Function UD_Read_ColdJunc_Thermo Lib "Usb-Dask.dll" (ByVal CardNumber As Integer, ByRef pfValue As Double) As Integer

Declare Function ADC_to_Thermo Lib "Usb-Dask.dll" (ByVal wThermoType As Integer, ByVal fScaledADC As Double, ByVal fColdJuncTemp As Double, ByRef pfTemp As Double) As Integer

Declare Function UD_AI_2401_Stop_Poll Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer) As Integer

'For USB-1900 Series
Declare Function UD_AI_AsyncBufferTransfer Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByRef pwBuffer As Integer, ByVal offset As Long, ByVal count As Long) As Integer

'For USB-7250 As, USB-7230
Declare Function UD_CTR_Control Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wCtr As Integer, ByVal dwCtrl As Long) As Integer

Declare Function UD_CTR_ReadFrequency Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wCtr As Integer, ByRef pfValue As Double) As Integer

Declare Function UD_CTR_ReadRisingEdgeCounter Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wCtr As Integer, ByRef dwValue As Long) As Integer

Declare Function UD_CTR_SetupMinPulseWidth Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wCtr As Integer, ByVal Value As Integer) As Integer

Declare Function UD_DI_SetupMinPulseWidth Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal Value As Integer) As Integer

Declare Function UD_DI_Control Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wPort As Integer, ByVal dwCtrl As Long) As Integer

Declare Function UD_DI_SetCOSInterrupt32 Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wPort As Integer, ByVal dwCtrl As Integer, ByRef hEvent As Long, ByVal ManualReset As Boolean) As Integer

Declare Function UD_DI_GetCOSLatchData32 Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wPort As Integer, ByRef pwCosLData As Long) As Integer

Declare Function UD_DIO_INT_EventMessage Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal Mode As Integer, ByVal evt As Object, ByVal windowHandle As Object, ByVal message As Long, ByVal callbackAddr As Long) As Integer

Declare Function UD_DO_GetInitPattern Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wPort As Integer, ByRef pdwPattern As Long) As Integer

Declare Function UD_DO_SetInitPattern Lib "Usb-Dask.dll" (ByVal wCardNumber As Integer, ByVal wPort As Integer, ByRef pdwPattern As Long) As Integer

