Imports System.Runtime.InteropServices

Public Delegate Sub CallbackDelegate()


<StructLayout(LayoutKind.Sequential, Pack:=1)> _
Public Structure USBDAQ_DEVICE
    <MarshalAs(UnmanagedType.U2)> _
    Public wModuleType As UShort
    <MarshalAs(UnmanagedType.U2)> _
    Public wCardID As UShort
End Structure

Public Class USBDASK
    'ADLink PCI Card Type
    Public Const USB_1902 As UShort = 1
    Public Const USB_1903 As UShort = 2
    Public Const USB_1901 As UShort = 3
    Public Const USB_2401 As UShort = 4
    Public Const USB_7250 As UShort = 5
    Public Const USB_7230 As UShort = 6
    Public Const USB_2405 As UShort = 7        
    Public Const USB_1210 As UShort = 8    
    
    Public Const NUM_MODULE_TYPE As UShort = 9

    Public Const MAX_USB_DEVICE As UShort = 9

    Public Const INVALID_CARD_ID As UShort = &HFFFF

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
    Public Const ErrorInvalidDaRefVoltage As Short = -23
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
    Public Const ErrorCalibrationTimeOut As Short = -63
    Public Const ErrorUndefinedParameter As Short = -64
    Public Const ErrorInvalidBufferID As Short = -65
    Public Const ErrorInvalidSampledClock As Short = -66
    Public Const ErrorInvalidOperationMode As Short = -67

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

    'Error added for USBDASK
    Public Const ErrorAccessViolationDataCopy As Short = -301
    Public Const ErrorNoModuleFound As Short = -302
    Public Const ErrorCardIDDuplicated As Short = -303
    Public Const ErrorCardDisconnected As Short = -304
    Public Const ErrorInvalidScannedIndex As Short = -305
    Public Const ErrorUndefinedException As Short = -306
    Public Const ErrorInvalidDioConfig As Short = -307
    Public Const ErrorInvalidAOCfgCtrl As Short = -308
    Public Const ErrorInvalidAOTrigCtrl As Short = -309
    Public Const ErrorConflictWithSyncMode As Short = -310
    Public Const ErrorConflictWithFifoMode As Short = -311
    Public Const ErrorInvalidAOIteration As Short = -312
    Public Const ErrorZeroChannelNumber As Short = -313
    Public Const ErrorSystemCallFailed As Short = -314
    Public Const ErrorTimeoutFromSyncMode As Short = -315
    Public Const ErrorInvalidPulseCount As Short = -316
    Public Const ErrorInvalidDelayCount As Short = -317
    Public Const ErrorConflictWithDelay2 As Short = -318
    Public Const ErrorAOFifoCountTooLarge As Short = -319
    Public Const ErrorConflictWithWaveRepeat As Short = -320
    Public Const ErrorConflictWithReTrig As Short = -321
    Public Const ErrorInvalidTriggerChannel As Short = -322
    Public Const ErrorInvalidRefVoltage As Short = -323
    Public Const ErrorInvalidConversionSrc As Short = -324
    Public Const ErrorInvalidInputSignal As Short = -325
    Public Const ErrorCalibrateFailed As Short = -326
    Public Const ErrorInvalidCalData As Short = -327
    Public Const ErrorChanGainQueueTooLarge As Short = -328
    Public Const ErrorInvalidCardType As Short = -329
    Public Const ErrorInvlaidSyncMode As Short = -330
    Public Const ErrorIICVersion = -331
    Public Const ErrorFX2UpgradeFailed = -332
    Public Const ErrorInvalidReadCount = -333
    Public Const ErrorTEDSInvalidSensorNo = -334
    Public Const ErroeTEDSAccessTimeout = -335
    Public Const ErrorTEDSChecksumFailed = -336
    Public Const ErrorTEDSNotIEEE1451_4 = -337
    Public Const ErrorTEDSInvalidTemplateID = -338
    Public Const ErrorTEDSInvalidPrecisionValue = -339
    Public Const ErrorTEDSUnsupportedTemplate = -340
    Public Const ErrorTEDSInvalidPropertyID = -341
    Public Const ErrorTEDSNoRawData = -342

    Public Const ErrorInvalidChannel As Short = -397
    Public Const ErrorNullPoint As Short = -398
    Public Const ErrorInvalidParamSetting As Short = -399



    ' -401 ~ -499 the Kernel error
    Public Const ErrorAIStartFailed As Short = -401
    Public Const ErrorAOStartFailed As Short = -402
    Public Const ErrorConflictWithGPIOConfig As Short = -403
    Public Const ErrorEepromReadback As Short = -404
    Public Const ErrorConflictWithInfiniteOp As Short = -405
    Public Const ErrorWaitingUSBHostResponse As Short = -406
    Public Const ErrorAOFifoModeTimeout As Short = -407
    Public Const ErrorInvalidModuleFunction As Short = -408
    Public Const ErrorAdFifoFull As Short = -409
    Public Const ErrorInvalidTransferCount As Short = -410
    Public Const ErrorConflictWithAIConfig As Short = -411
    Public Const ErrorDDSConfigFailed As Short = -412
    Public Const ErrorFpgaAccessFailed As Short = -413   
    Public Const ErrorPLDBusy As Short = -414
    Public Const ErrorPLDTimeout As Short = -415

    Public Const ErrorUndefinedKernelError As Short = -420

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
    Public Const AD_B_25_V As UShort = 35
    Public Const AD_B_12_5_V As UShort = 36

    'Synchronous Mode
    Public Const SYNCH_OP As UShort = 1
    Public Const ASYNCH_OP As UShort = 2


    'Input Type   
    Public Const UD_AI_NonRef_SingEnded = &H01
    Public Const UD_AI_SingEnded = &H02
    Public Const UD_AI_Differential = &H04
    Public Const UD_AI_PseudoDifferential = &H08

    'Input Coupling
    Public Const UD_AI_EnableIEPE = &H10
    Public Const UD_AI_DisableIEPE = &H20
    Public Const UD_AI_Coupling_AC = &H40
    Public Const UD_AI_Coupling_None = &H80



    'Conversion Source
    Public Const UD_AI_CONVSRC_INT = &H01
    Public Const UD_AI_CONVSRC_EXT = &H02


    'wTrigCtrl in UD_AI_Trigger_Config()

    'Trigger Source (bit9:0)
    Public Const UD_AI_TRGSRC_AI0 = &H200
    Public Const UD_AI_TRGSRC_AI1 = &H201
    Public Const UD_AI_TRGSRC_AI2 = &H202
    Public Const UD_AI_TRGSRC_AI3 = &H203
    Public Const UD_AI_TRGSRC_AI4 = &H204
    Public Const UD_AI_TRGSRC_AI5 = &H205
    Public Const UD_AI_TRGSRC_AI6 = &H206
    Public Const UD_AI_TRGSRC_AI7 = &H207
    Public Const UD_AI_TRGSRC_AI8 = &H208
    Public Const UD_AI_TRGSRC_AI9 = &H209
    Public Const UD_AI_TRGSRC_AI10 = &H20A
    Public Const UD_AI_TRGSRC_AI11 = &H20B
    Public Const UD_AI_TRGSRC_AI12 = &H20C
    Public Const UD_AI_TRGSRC_AI13 = &H20D
    Public Const UD_AI_TRGSRC_AI14 = &H20E
    Public Const UD_AI_TRGSRC_AI15 = &H20F
    Public Const UD_AI_TRGSRC_SOFT = &H380
    Public Const UD_AI_TRGSRC_DTRIG = &H388


    'Trigger Edge (bit14)
    Public Const UD_AI_TrigPositive = &H4000
    Public Const UD_AI_TrigNegative = &H0

    Public Const UD_AI_Gate_PauseLow = &H4000
    Public Const UD_AI_Gate_PauseHigh = &H0
    
    'ReTrigger (bit13)
    Public Const UD_AI_EnReTrigger = &H2000
    Public Const UD_AI_DisReTrigger = &H0

    'AI Trigger Mode
    Public Const UD_AI_TRGMOD_POST = &H0
    Public Const UD_AI_TRGMOD_DELAY = &H4000
    Public Const UD_AI_TRGMOD_PRE = &H8000
    Public Const UD_AI_TRGMOD_MIDDLE = &HC000
    Public Const UD_AI_TRGMOD_GATED = &H1000

    'DIO_Config
    Public Const UD_DIO_DIGITAL_INPUT = &H30
    Public Const UD_DIO_COUNTER_INPUT = &H31
    Public Const UD_DIO_DIGITAL_OUTPUT = &H2
    Public Const UD_DIO_PULSE_OUTPUT = &H33


    'TEDS Property IDs
    Public Const UD_TEDS_PROPERTY_TEMPLATE = 1
    Public Const UD_TEDS_PROPERTY_ElecSigType = 2
    Public Const UD_TEDS_PROPERTY_PhysMeasType = 3
    Public Const UD_TEDS_PROPERTY_MinPhysVal = 4
    Public Const UD_TEDS_PROPERTY_MaxPhysVal = 5
    Public Const UD_TEDS_PROPERTY_MinElecVal = 6
    Public Const UD_TEDS_PROPERTY_MaxElecVal = 7
    Public Const UD_TEDS_PROPERTY_MapMeth = 8
    Public Const UD_TEDS_PROPERTY_BridgeType = 9
    Public Const UD_TEDS_PROPERTY_SensorImped = 10
    Public Const UD_TEDS_PROPERTY_RespTime = 11
    Public Const UD_TEDS_PROPERTY_ExciteAmplNom = 12
    Public Const UD_TEDS_PROPERTY_ExciteAmplMin = 13
    Public Const UD_TEDS_PROPERTY_ExciteAmplMax = 14
    Public Const UD_TEDS_PROPERTY_CalDate = 15
    Public Const UD_TEDS_PROPERTY_CalInitials = 16
    Public Const UD_TEDS_PROPERTY_CalPeriod = 17
    Public Const UD_TEDS_PROPERTY_MeasID = 18

    '-------- Constants for USB-1902 --------------------

    'Input Type
    Public Const P1902_AI_NonRef_SingEnded As UShort = &H0
    Public Const P1902_AI_SingEnded As UShort = &H1
    Public Const P1902_AI_PseudoDifferential As UShort = &H2
    Public Const P1902_AI_Differential As UShort = &H2    

    'Conversion Source
    Public Const P1902_AI_CONVSRC_INT As UShort = &H0
    Public Const P1902_AI_CONVSRC_EXT As UShort = &H80


    ' wTrigCtrl in UD_AI_1902_Config()
    ' Trigger Source
    Public Const P1902_AI_TRGSRC_AI0 As UShort = &H20
    Public Const P1902_AI_TRGSRC_AI1 As UShort = &H21
    Public Const P1902_AI_TRGSRC_AI2 As UShort = &H22
    Public Const P1902_AI_TRGSRC_AI3 As UShort = &H23
    Public Const P1902_AI_TRGSRC_AI4 As UShort = &H24
    Public Const P1902_AI_TRGSRC_AI5 As UShort = &H25
    Public Const P1902_AI_TRGSRC_AI6 As UShort = &H26
    Public Const P1902_AI_TRGSRC_AI7 As UShort = &H27
    Public Const P1902_AI_TRGSRC_AI8 As UShort = &H28
    Public Const P1902_AI_TRGSRC_AI9 As UShort = &H29
    Public Const P1902_AI_TRGSRC_AI10 As UShort = &H2A
    Public Const P1902_AI_TRGSRC_AI11 As UShort = &H2B
    Public Const P1902_AI_TRGSRC_AI12 As UShort = &H2C
    Public Const P1902_AI_TRGSRC_AI13 As UShort = &H2D
    Public Const P1902_AI_TRGSRC_AI14 As UShort = &H2E
    Public Const P1902_AI_TRGSRC_AI15 As UShort = &H2F
    Public Const P1902_AI_TRGSRC_SOFT As UShort = &H30
    Public Const P1902_AI_TRGSRC_DTRIG As UShort = &H31


    ' Trigger Edge
    Public Const P1902_AI_TrgPositive As UShort = &H40    
    Public Const P1902_AI_TrgNegative As UShort = &H0


    ' Gated Trigger Level
    Public Const P1902_AI_Gate_PauseLow As UShort = &H0
    Public Const P1902_AI_Gate_PauseHigh As UShort = &H40

    ' Trigger Mode
    Public Const P1902_AI_TRGMOD_POST As UShort = &H0
    Public Const P1902_AI_TRGMOD_GATED As UShort = &H80
    Public Const P1902_AI_TRGMOD_DELAY As UShort = &H100

    ' ReTrigger
    Public Const P1902_AI_EnReTigger As UShort = &H200

    '
    ' AO Constants
    '

    ' Conversion Source
    Public Const P1902_AO_CONVSRC_INT As UShort = &H0

    ' Trigger Mode
    Public Const P1902_AO_TRGMOD_POST As UShort = &H0
    Public Const P1902_AO_TRGMOD_DELAY As UShort = &H1

    ' Trigger Source
    Public Const P1902_AO_TRGSRC_SOFT As UShort = &H0
    Public Const P1902_AO_TRGSRC_DTRIG As UShort = &H10

    ' Trigger Edge
    Public Const P1902_AO_TrgPositive As UShort = &H100
    Public Const P1902_AO_TrgNegative As UShort = &H0

    ' Enable Re-Trigger
    Public Const P1902_AO_EnReTigger As UShort = &H200
    ' Flag for AO Waveform Seperation Interval 
    Public Const P1902_AO_EnDelay2 As UShort = &H400

    '-------- Constants for USB-2401 --------------------
    ' wConfigCtrl in UD_AI_2401_Config()
    ' Input Type, V >=2.5V, V<2.5, Current, RTD (4 wire), RTD (3-wire), RTD (2-wire), Resistor, Thermocouple, Full-Bridge, Half-Bridge
    Public Const P2401_Voltage_2D5V_Above As UShort = &H0
    Public Const P2401_Voltage_2D5V_Below As UShort = &H1
    Public Const P2401_Current As UShort = &H2
    Public Const P2401_RTD_4_Wire As UShort = &H3
    Public Const P2401_RTD_3_Wire As UShort = &H4
    Public Const P2401_RTD_2_Wrie As UShort = &H5
    Public Const P2401_Resistor As UShort = &H6
    Public Const P2401_ThermoCouple As UShort = &H7
    Public Const P2401_Full_Bridge As UShort = &H8
    Public Const P2401_Half_Bridge As UShort = &H9
    Public Const P2401_ThermoCouple_Differential As UShort = &HA
    Public Const P2401_350Ohm_Full_Bridge As UShort = &HB
    Public Const P2401_350Ohm_Half_Bridge As UShort = &HC
    Public Const P2401_120Ohm_Full_Bridge As UShort = &HD
    Public Const P2401_120Ohm_Half_Bridge As UShort = &HE
    
    Public Const THERMO_B_TYPE As UShort = 1
    Public Const THERMO_C_TYPE As UShort = 2
    Public Const THERMO_E_TYPE As UShort = 3
    Public Const THERMO_K_TYPE As UShort = 4
    Public Const THERMO_R_TYPE As UShort = 5
    Public Const THERMO_S_TYPE As UShort = 6
    Public Const THERMO_T_TYPE As UShort = 7
    Public Const THERMO_J_TYPE As UShort = 8
    Public Const THERMO_N_TYPE As UShort = 9
    Public Const RTD_PT100 As UShort = 10
    Public Const THERMO_MAX_TYPE As UShort = RTD_PT100
    
    Public Const NoThermoError As Short = 0
    Public Const ErrorInvalidThermoType As Short = -601
    Public Const ErrorOutThermoRange As Short = -602
    Public Const ErrorThermoTable As Short = -603    
    
    ' Conversion Source 
    Public Const P2401_AI_CONVSRC_INT As UShort = &H0

    ' wTrigCtrl in UD_AI_2401_Config()
    ' Trigger Source, bit 8:3 in AI_ACQMCR
    Public Const P2401_AI_TRGSRC_SOFT As UShort = &H30

    ' Trigger Mode
    Public Const P2401_AI_TRGMOD_POST As UShort = &H0


    ' wMAvgStageCh1 ~ wMAvgStageCh4 in UD_AI_2401_PollConfig()
    Public Const P2401_Polling_MAvg_Disable As UShort = &H0
    Public Const P2401_Polling_MAvg_2_Sampes As UShort = &H1
    Public Const P2401_Polling_MAvg_4_Sampes As UShort = &H2
    Public Const P2401_Polling_MAvg_8_Sampes As UShort = &H3
    Public Const P2401_Polling_MAvg_16_Sampes As UShort = &H4

    ' wEnContPolling in UD_AI_2401_PollConfig()
    Public Const P2401_Continue_Polling_Disable As UShort = &H0
    Public Const P2401_Continue_Polling_Enable As UShort = &H1

    ' wPollSpeed in UD_AI_2401_PollConfig()
    Public Const P2401_ADC_2000_SPS As UShort = &H9
    Public Const P2401_ADC_1000_SPS As UShort = &H8
    Public Const P2401_ADC_640_SPS As UShort = &H7
    Public Const P2401_ADC_320_SPS As UShort = &H6
    Public Const P2401_ADC_160_SPS As UShort = &H5
    Public Const P2401_ADC_80_SPS As UShort = &H4
    Public Const P2401_ADC_40_SPS As UShort = &H3
    Public Const P2401_ADC_20_SPS As UShort = &H2


   ' AI Constants
   ' AI Select Channel
      
    Public Const P2405_AI_CH_0 As UShort = &H0
    Public Const P2405_AI_CH_1 As UShort = &H1
    Public Const P2405_AI_CH_2 As UShort = &H2
    Public Const P2405_AI_CH_3 As UShort = &H3            


   ' Input Coupling
    Public Const P2405_AI_EnableIEPE As UShort = &H4
    Public Const P2405_AI_DisableIEPE As UShort = &H8
    Public Const P2405_AI_Coupling_AC As UShort = &H10
    Public Const P2405_AI_Coupling_None As UShort = &H20
                   

   ' Input Type
    Public Const P2405_AI_Differential As UShort = &H0
    Public Const P2405_AI_PseudoDifferential As UShort = &H40    
       
   ' Conversion Source
    Public Const P2405_AI_CONVSRC_INT As UShort = &H0
    Public Const P2405_AI_CONVSRC_EXT As UShort = &H200

   ' Trigger Source
    Public Const P2405_AI_TRGSRC_AI0 As UShort = &H200
    Public Const P2405_AI_TRGSRC_AI1 As UShort = &H208
    Public Const P2405_AI_TRGSRC_AI2 As UShort = &H210
    Public Const P2405_AI_TRGSRC_AI3 As UShort = &H218
    Public Const P2405_AI_TRGSRC_SOFT As UShort = &H380
    Public Const P2405_AI_TRGSRC_DTRIG As UShort = &H388              

   ' Trigger Edge
    Public Const P2405_AI_TrgPositive As UShort = &H4
    Public Const P2405_AI_TrgNegative As UShort = &H0

   ' Gated Trigger Level
    Public Const P2405_AI_Gate_PauseLow As UShort = &H4
    Public Const P2405_AI_Gate_PauseHigh As UShort = &H0
    
   ' ReTrigger
    Public Const P2405_AI_EnReTigger As UShort = &H2000

   ' AI Trigger Mode
    Public Const P2405_AI_TRGMOD_POST As UShort = &H0
    Public Const P2405_AI_TRGMOD_DELAY As UShort = &H4000
    Public Const P2405_AI_TRGMOD_PRE As UShort = &H8000
    Public Const P2405_AI_TRGMOD_MIDDLE As UShort = &HC000    
    Public Const P2405_AI_TRGMOD_GATED As UShort = &H1000   

   ' UD_DIO_2405_Config
    Public Const P2405_DIGITAL_INPUT As UShort = &H30
    Public Const P2405_COUNTER_INPUT As UShort = &H31    
    Public Const P2405_DIGITAL_OUTPUT As UShort = &H32 
    Public Const P2405_PULSE_OUTPUT As UShort = &H33 

    '-------------------------------
    ' GPIO/GPTC Configuration       
    '-------------------------------
    Public Const IGNORE_CONFIG As UShort = &H0
    Public Const GPIO_IGNORE_CONFIG As UShort = &H0

    Public Const GPTC0_GPO1 As UShort = &H1
    Public Const GPI0_3_GPO0_1 As UShort = &H2
    ' Public Const ENC0_GPO0 As UShort = &H4
    Public Const GPTC0_TC1 As UShort = &H8

    Public Const GPTC2_GPO3 As UShort = &H10
    Public Const GPI4_7_GPO2_3 As UShort = &H20
    ' Public Const ENC1_GPO1 As UShort = &H40
    Public Const GPTC2_TC3 As UShort = &H80

    ' GPIO Port
    Public Const GPIO_PortA As UShort = 0
    Public Const GPIO_PortB As UShort = 1

    'Counter Mode
    Public Const SimpleGatedEventCNT As UShort = &H1
    Public Const SinglePeriodMSR As UShort = &H2
    Public Const SinglePulseWidthMSR As UShort = &H3
    Public Const SingleGatedPulseGen As UShort = &H4
    Public Const SingleTrigPulseGen As UShort = &H5
    Public Const RetrigSinglePulseGen As UShort = &H6
    Public Const SingleTrigContPulseGen As UShort = &H7
    Public Const ContGatedPulseGen As UShort = &H8
    Public Const EdgeSeparationMSR As UShort = &H9
    Public Const SingleTrigContPulseGenPWM As UShort = &HA
    Public Const ContGatedPulseGenPWM As UShort = &HB
    Public Const CW_CCW_Encoder As UShort = &HC
    Public Const x1_AB_Phase_Encoder As UShort = &HD
    Public Const x2_AB_Phase_Encoder As UShort = &HE
    Public Const x4_AB_Phase_Encoder As UShort = &HF
    Public Const Phase_Z As UShort = &H10
    Public Const MultipleGatedPulseGen As UShort = &H11

    'GPTC clock source
    Public Const GPTC_CLK_SRC_Ext As UShort = &H1
    Public Const GPTC_CLK_SRC_Int As UShort = &H0
    Public Const GPTC_GATE_SRC_Ext As UShort = &H2
    Public Const GPTC_GATE_SRC_Int As UShort = &H0
    Public Const GPTC_UPDOWN_Ext As UShort = &H4
    Public Const GPTC_UPDOWN_Int As UShort = &H0

    'GPTC clock polarity
    Public Const GPTC_CLKSRC_LACTIVE As UShort = &H1
    Public Const GPTC_CLKSRC_HACTIVE As UShort = &H0
    Public Const GPTC_GATE_LACTIVE As UShort = &H2
    Public Const GPTC_GATE_HACTIVE As UShort = &H0
    Public Const GPTC_UPDOWN_LACTIVE As UShort = &H4
    Public Const GPTC_UPDOWN_HACTIVE As UShort = &H0
    Public Const GPTC_OUTPUT_LACTIVE As UShort = &H8
    Public Const GPTC_OUTPUT_HACTIVE As UShort = &H0

    Public Const IntGate As UShort = &H0
    Public Const IntUpDnCTR As UShort = &H1
    Public Const IntENABLE As UShort = &H2

    'DAQ Event type for the event message  
    Public Const AIEnd As Short = 0
    Public Const AOEnd As Short = 0
    Public Const DIEnd As Short = 0
    Public Const DOEnd As Short = 0    
    Public Const DBEvent As Short = 1
    Public Const TrigEvent As Short = 2

    ' Calibration 
    Public Const Cal_Op_Offset As UShort = 0
    Public Const Cal_Op_Gain As UShort = 1

    Public Const U1902_CalSrc_REF_5V As UShort = 0
    Public Const U1902_CalSrc_REF_10V As UShort = 1
    Public Const U1902_CalSrc_REF_2V As UShort = 2
    Public Const U1902_CalSrc_REF_1V As UShort = 3
    Public Const U1902_CalSrc_REF_0_2V As UShort = 4
    Public Const U1902_CalSrc_AO_0 As UShort = 5
    Public Const U1902_CalSrc_AO_1 As UShort = 6

    ' CTR parameters
    Public Const UD_CTR_Filter_Disable As UShort = &H0
    Public Const UD_CTR_Filter_Enable As UShort = &H1
    Public Const UD_CTR_Reset_Edge_Counter As UShort = &H2
    Public Const UD_CTR_Reset_Frequency_Counter As UShort = &H4
    Public Const UD_CTR_Polarity_Positive As UShort = &H0
    Public Const UD_CTR_Polarity_Negative As UShort = &H8
    
    Enum USB_7250_7230_CTR
        UD_CTR_Filter_Disable
        UD_CTR_Filter_Enable = 1
        UD_CTR_Reset_Rising_Edge_Counter = 2
        UD_CTR_Reset_Frequency_Counter = 4
        UD_CTR_Polarity_Positive = 0
        UD_CTR_Polarity_Negative = 8
    End Enum
    
    '----------------------------------------------------------------------------

    ' USB-DASK Function prototype                                               

    '----------------------------------------------------------------------------

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_Register_Card(ByVal CardType As UShort, ByVal card_num As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_Release_Card(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_Device_Scan(ByRef pModuleNum As UShort, ByRef pAvailModules As USBDAQ_DEVICE) As Short
    End Function
    '----------------------------------------------------------------------------

    ' AI Function 

    <DllImport("usb-dask.dll")> _
    Public Shared Function IdentifyLED_Control(ByVal CardNumber As UShort, ByVal ctrl As Byte) As Short
    End Function
    '---------------------------------------------------------------------------

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_1902_Config(ByVal CardNumber As UShort, ByVal wConfigCtrl As UShort, ByVal wTrigCtrl As UShort, ByVal dwTrgLevel As UInteger, ByVal wReTriggerCnt As UInteger, ByVal dwDelayCount As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_2401_Config(ByVal CardNumber As UShort, ByVal wChanCfg1 As UShort, ByVal wChanCfg2 As UShort, ByVal wChanCfg3 As UShort, ByVal wChanCfg4 As UShort, ByVal wTrigCtrl As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_2401_PollConfig(ByVal CardNumber As UShort, ByVal wPollSpeed As UShort, ByVal wMAvgStageCh1 As UShort, ByVal wMAvgStageCh2 As UShort, ByVal wMAvgStageCh3 As UShort, ByVal wMAvgStageCh4 As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_1902_CounterInterval(ByVal CardNumber As UShort, ByVal ScanIntrv As UInteger, ByVal SampIntrv As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncCheck(ByVal CardNumber As UShort, ByRef Stopped As Byte, ByRef AccessCnt As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncClear(ByVal CardNumber As UShort, ByRef AccessCnt As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferHalfReady(ByVal CardNumber As UShort, ByRef HalfReady As Byte, ByRef StopFlag As Byte) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferMode(ByVal CardNumber As UShort, ByVal Enable As Boolean) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferTransfer32(ByVal CardNumber As UShort, ByVal Buffer As IntPtr) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferTransfer(ByVal CardNumber As UShort, ByVal Buffer As IntPtr) As Short
    End Function    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferOverrun(ByVal CardNumber As UShort, ByVal op As UShort, ByRef overrunFlag As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferHandled(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferToFile(ByVal CardNumber As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContReadChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByVal Buffer As IntPtr, ByVal ReadCount As UInteger, ByVal SampleRate As Double, _
    ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContReadMultiChannels(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UShort(), ByVal AdRanges As UShort(), ByVal Buffer As IntPtr, ByVal ReadCount As UInteger, _
    ByVal SampleRate As Double, ByVal SyncMode As UShort) As Short
    End Function    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_2401_Scale32(ByVal CardNumber As UShort, ByVal AdRange As UShort, ByVal inType As UShort, ByVal reading As UInteger, ByRef voltage As Double) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_2401_ContVScale32(ByVal CardNumber As UShort, ByVal AdRange As UShort, ByVal inType As UShort, ByVal readingArray As UInteger(), ByVal voltageArray As Double(), ByVal count As Integer) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContReadChannelToFile(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByVal FileName As String, ByVal ReadCount As UInteger, ByVal SampleRate As Double, _
    ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContReadMultiChannelsToFile(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UShort(), ByVal AdRanges As UShort(), ByVal FileName As String, ByVal ReadCount As UInteger, _
    ByVal SampleRate As Double, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_EventCallBack(ByVal CardNumber As UShort, ByVal mode As UShort, ByVal EventType As UShort, ByVal callbackAddr As MulticastDelegate) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_InitialMemoryAllocated(ByVal CardNumber As UShort, ByRef MemSize As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ReadChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByRef Value As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ReadMultiChannels(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UShort(), ByVal AdRanges As UShort(), ByVal Buffer As IntPtr) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_VReadChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByRef voltage As Double) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_VoltScale(ByVal CardNumber As UShort, ByVal AdRange As UShort, ByVal reading As UShort, ByRef voltage As Double) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContVScale(ByVal CardNumber As UShort, ByVal adRange As UShort, ByVal readingArray As UShort(), ByVal voltageArray As Double(), ByVal count As Integer) As Short
    End Function

    ' Add 10/03/16
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContVScale(ByVal CardNumber As UShort, ByVal adRange As UShort, ByVal readingArray As IntPtr, ByVal voltageArray As Double(), ByVal count As Integer) As Short
    End Function

    '[DllImport("usb-dask.dll")]
    'public static extern short UD_AI_2401_Scale32(ushort CardNumber, ushort adRange, ushort inType, uint reading, out double voltage);
    '[DllImport("usb-dask.dll")]
    'public static extern short UD_AI_2401_ContVScale32(ushort CardNumber, ushort adRange, ushort inType, uint[] readingArray, double[] voltageArray, int count);    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_SetTimeOut(ByVal CardNumber As UShort, ByVal TimeOut As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncReTrigNextReady(ByVal CardNumber As UShort, ByRef Ready As Byte, ByRef StopFlag As Byte, ByRef RdyTrigCnt As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_Moving_Average32(ByVal CardNumber As UShort, ByVal SrcBuf As UInteger(), ByVal DesBuf As UInteger(), ByVal dwTgChIdx As UInteger, ByVal dwTotalCh As UInteger, ByVal dwMovAvgWindow As UInteger, _
    ByVal dwSamplCnt As UInteger) As Short    
    End Function
    ' 2012Oct18, Jeff added for USB-2405
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_2405_Chan_Config(ByVal CardNumber As UShort, ByVal wChanCfg1 As UShort, ByVal wChanCfg2 As UShort, ByVal wChanCfg3 As UShort, ByVal wChanCfg4 As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_2405_Trig_Config(ByVal CardNumber As UShort, ByVal wConvSrc As UShort, ByVal wTrigMode As UShort, ByVal wTrigCtrl As UShort, ByVal wReTrigCnt As UInteger, ByVal dwDLY1Cnt As UInteger, ByVal dwDLY2Cnt As UInteger, ByVal dwTrgLevel As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_Channel_Config(ByVal CardNumber As UShort, ByVal wChanCfg1 As UShort, ByVal wChanCfg2 As UShort, ByVal wChanCfg3 As UShort, ByVal wChanCfg4 As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_Trigger_Config(ByVal CardNumber As UShort, ByVal wConvSrc As UShort, ByVal wTrigMode As UShort, ByVal wTrigCtrl As UShort, ByVal wReTrigCnt As UInteger, ByVal dwDLY1Cnt As UInteger, ByVal dwDLY2Cnt As UInteger, ByVal dwTrgLevel As UInteger) As Short
    End Function    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_VoltScale32(ByVal CardNumber As UShort, ByVal AdRange As UShort, ByVal inType As UShort, ByVal reading As UInteger, ByRef voltage As Double) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContVScale32(ByVal CardNumber As UShort, ByVal AdRange As UShort, ByVal inType As UShort, ByVal readingArray As UInteger(), ByVal voltageArray As Double(), ByVal count As Integer) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncBufferTransfer32(ByVal CardNumber As UShort, ByVal Buffer As UInteger(), ByVal offset As UInteger, ByVal count As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_DDS_ActualRate_Get(ByVal CardNumber As UShort, ByVal SampleRate As Double, ByRef ActualRate As Double) As Short
    End Function        
    '---------------------------------------------------------------------------    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_1902_Config(ByVal CardNumber As UShort, ByVal ConfigCtrl As UShort, ByVal TrigCtrl As UShort, ByVal ReTrgCnt As UInteger, ByVal DLY1Cnt As UInteger, ByVal DLY2Cnt As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_AsyncCheck(ByVal CardNumber As UShort, ByRef Stopped As Byte, ByRef AccessCnt As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_AsyncClear(ByVal CardNumber As UShort, ByRef AccessCnt As UInteger, ByVal stop_mode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_AsyncDblBufferMode(ByVal CardNumber As UShort, ByVal Enable As Byte, ByVal bEnFifoMode As Byte) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_AsyncDblBufferHalfReady(ByVal CardNumber As UShort, ByRef bHalfReady As Byte) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_AsyncDblBufferTransfer(ByVal CardNumber As UShort, ByVal wBufferID As UShort, ByVal AOBuffer As UShort()) As Short
    End Function        
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_ContBufferCompose(ByVal CardNumber As UShort, ByVal TotalChnCount As UShort, ByVal ChnNum As UShort, ByVal UpdateCount As UInteger, ByVal ConBuffer As UInteger(), ByVal Buffer As UInteger()) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_ContWriteChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AOBuffer As UShort(), ByVal WriteCount As UInteger, ByVal Iterations As UInteger, ByVal CHUI As UInteger, _
    ByVal finite As UShort, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_ContWriteMultiChannels(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UShort(), ByVal AOBuffer As UInteger(), ByVal WriteCount As UInteger, ByVal Iterations As UInteger, _
    ByVal CHUI As UInteger, ByVal finite As UShort, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_InitialMemoryAllocated(ByVal CardNumber As UShort, ByRef MemSize As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_SetTimeOut(ByVal CardNumber As UShort, ByVal TimeOut As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_SimuVWriteChannel(ByVal CardNumber As UShort, ByVal Group As UShort, ByVal VBuffer As Double()) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_SimuWriteChannel(ByVal CardNumber As UShort, ByVal Group As UShort, ByVal Buffer As Short()) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_VWriteChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal Voltage As Double) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_WriteChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal Value As Short) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_EventCallBack(ByVal CardNumber As UShort, ByVal mode As UShort, ByVal EventType As UShort, ByVal callbackAddr As MulticastDelegate) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_VoltScale(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal Voltage As Double, ByRef binValue As Short) As Short
    End Function

    '---------------------------------------------------------------------------

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DIO_1902_Config(ByVal CardNumber As UShort, ByVal wPart1Cfg As UShort, ByVal wPart2Cfg As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DIO_2401_Config(ByVal CardNumber As UShort, ByVal wPart1Cfg As UShort) As Short
    End Function
    ' 2012Oct18, Jeff added for USB-2405 
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DIO_2405_Config(ByVal CardNumber As UShort, ByVal wPart1Cfg As UShort, ByVal wPart2Cfg As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DIO_Config(ByVal CardNumber As UShort, ByVal wPart1Cfg As UShort, ByVal wPart2Cfg As UShort) As Short
    End Function    
    '---------------------------------------------------------------------------

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DI_ReadLine(ByVal CardNumber As UShort, ByVal Port As UShort, ByVal Line As UShort, ByRef State As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DI_ReadPort(ByVal CardNumber As UShort, ByVal Port As UShort, ByRef Value As UInteger) As Short
    End Function
    '---------------------------------------------------------------------------

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DO_ReadLine(ByVal CardNumber As UShort, ByVal Port As UShort, ByVal Line As UShort, ByRef Value As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DO_ReadPort(ByVal CardNumber As UShort, ByVal Port As UShort, ByRef Value As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DO_WriteLine(ByVal CardNumber As UShort, ByVal Port As UShort, ByVal Line As UShort, ByVal Value As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DO_WritePort(ByVal CardNumber As UShort, ByVal Port As UShort, ByVal Value As UInteger) As Short
    End Function
    '---------------------------------------------------------------------------

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GPTC_Clear(ByVal CardNumber As UShort, ByVal GCtr As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GPTC_Control(ByVal CardNumber As UShort, ByVal GCtr As UShort, ByVal ParamID As UShort, ByVal Value As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GPTC_Read(ByVal CardNumber As UShort, ByVal GCtr As UShort, ByRef Value As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GPTC_Setup(ByVal CardNumber As UShort, ByVal GCtr As UShort, ByVal Mode As UShort, ByVal SrcCtrl As UShort, ByVal PolCtrl As UShort, ByVal LReg1_Val As UInteger, _
    ByVal LReg2_Val As UInteger, ByVal PulseCount As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GPTC_Setup_N(ByVal CardNumber As UShort, ByVal GCtr As UShort, ByVal Mode As UShort, ByVal SrcCtrl As UShort, ByVal PolCtrl As UShort, ByVal LReg1_Val As UInteger, _
    ByVal LReg2_Val As UInteger, ByVal PulseCount As UInteger) As Short
    End Function    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GPTC_Status(ByVal CardNumber As UShort, ByVal GCtr As UShort, ByRef Value As UShort) As Short
    End Function
    '---------------------------------------------------------------------------
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_GetEvent(ByVal CardNumber As UShort, ByRef hEvent As IntPtr) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_GetEvent(ByVal CardNumber As UShort, ByRef hEvent As IntPtr) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_GetView(ByVal CardNumber As UShort, ByRef View As UInteger) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_GetView(ByVal CardNumber As UShort, ByRef View As UInteger) As Short
    End Function
    '---------------------------------------------------------------------------

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GetActualRate(ByVal CardNumber As UShort, ByVal fSampleRate As Double, ByRef fActualRate As Double) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GetCardIndexFromID(ByVal CardNumber As UShort, ByRef cardType As UShort, ByRef cardIndex As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GetCardType(ByVal CardNumber As UShort, ByRef cardType As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_IdentifyLED_Control(ByVal CardNumber As UShort, ByVal ctrl As Byte) As Short
    End Function

    '---------------------------------------------------------------------------

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_GetFPGAVersion(ByVal CardNumber As UShort, ByRef pdwFPGAVersion As UInteger) As Short
    End Function
     
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_1902_Trimmer_Set(ByVal CardNumber As UShort, ByVal bValue As Byte) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function usbdaq_1902_RefVol_WriteEeprom(ByVal CardNumber As UShort, ByVal RefVol As Double(), ByVal wTrimmer As UShort) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function usbdaq_1902_RefVol_ReadEeprom(ByVal CardNumber As UShort, ByVal RefVol As Double(), ByRef wTrimmer As UShort) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function usbdaq_1902_CalSrc_Switch(ByVal CardNumber As UShort, ByVal wOperation As UShort, ByVal wCalSrc As UShort) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function usbdaq_1902_Calibration_All(ByVal CardNumber As UShort, ByRef pCalOp As UShort, ByRef pCalSrc As UShort) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function usbdaq_1903_Calibration_All(ByVal CardNumber As UShort, ByVal RefVol_10V As Double, ByRef pCalOp As UShort, ByRef pCalSrc As UShort) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function usbdaq_1903_Current_Calibration(ByVal CardNumber As UShort, ByVal wOperation As UShort, ByVal wCalChan As UShort, ByVal fRefCur As Double, ByRef pCalReg As UInteger) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function usbdaq_1903_WriteEeprom(ByVal CardNumber As UShort, ByVal wTrimmer As UShort, ByVal CALdata As Byte()) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function usbdaq_ReadPort(ByVal CardNumber As UShort, ByVal wPortAddr As UShort, ByRef pdwData As UInteger) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_Read_ColdJunc_Thermo(ByVal CardNumber As UShort, ByRef pfValue As Double) As Short
    End Function

    <DllImport("UsbThermo.dll")> _
    Public Shared Function ADC_to_Thermo(ByVal wThermoType As UShort, ByVal fScaledADC As Double, ByVal fColdJuncTemp As Double, ByRef pfTemp As Double) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_2401_Stop_Poll(ByVal wCardNumber As UShort) As Short
    End Function

    'For USB-1900 Series
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncBufferTransfer(ByVal wCardNumber As UShort, ByVal pwBuffer As IntPtr, ByVal offset As UInteger, ByVal count As UInteger) As Short
    End Function

    'For USB-7250 As, USB-7230
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_CTR_Control(ByVal wCardNumber As UShort, ByVal wCtr As UShort, ByVal dwCtrl As UInteger) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_CTR_ReadFrequency(ByVal wCardNumber As UShort, ByVal wCtr As UShort, ByRef pfValue As Double) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_CTR_ReadRisingEdgeCounter(ByVal wCardNumber As UShort, ByVal wCtr As UShort, ByRef dwValue As UInteger) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_CTR_ReadEdgeCounter(ByVal wCardNumber As UShort, ByVal wCtr As UShort, ByRef dwValue As UInteger) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_CTR_SetupMinPulseWidth(ByVal wCardNumber As UShort, ByVal wCtr As UShort, ByVal Value As UShort) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DI_SetupMinPulseWidth(ByVal wCardNumber As UShort, ByVal Value As UShort) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DI_Control(ByVal wCardNumber As UShort, ByVal wPort As UShort, ByVal dwCtrl As UInteger) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DI_SetCOSInterrupt32(ByVal wCardNumber As UShort, ByVal wPort As UShort, ByVal dwCtrl As UInteger, ByRef hEvent As IntPtr, ByVal ManualReset As Boolean) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DI_GetCOSLatchData32(ByVal wCardNumber As UShort, ByVal wPort As UShort, ByRef pwCosLData As UInteger) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DIO_INT_EventMessage(ByVal wCardNumber As UShort, ByVal mode As Short, ByVal evt As IntPtr, ByVal windowHandle As IntPtr, ByVal message As UInteger, ByVal callbackAddr As MulticastDelegate) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DO_GetInitPattern(ByVal wCardNumber As UShort, ByVal wPort As UShort, ByRef pdwPattern As UInteger) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_DO_SetInitPattern(ByVal wCardNumber As UShort, ByVal wPort As UShort, ByRef pdwPattern As UInteger) As Short
    End Function


    ' override
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContReadChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByVal Buffer As UShort(), ByVal ReadCount As UInteger, ByVal SampleRate As Double, _
    ByVal SyncMode As UShort) As Short
    End Function    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContReadChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AdRange As UShort, ByVal Buffer As UInteger(), ByVal ReadCount As UInteger, ByVal SampleRate As Double, _
    ByVal SyncMode As UShort) As Short
    End Function     
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContReadMultiChannels(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UShort(), ByVal AdRanges As UShort(), ByVal Buffer As UShort(), ByVal ReadCount As UInteger, _
    ByVal SampleRate As Double, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ContReadMultiChannels(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UShort(), ByVal AdRanges As UShort(), ByVal Buffer As UInteger(), ByVal ReadCount As UInteger, _
    ByVal SampleRate As Double, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ReadMultiChannels(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UShort(), ByVal AdRanges As UShort(), ByVal Buffer As UInteger() ) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_ReadMultiChannels(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UShort(), ByVal AdRanges As UShort(), ByVal Buffer As UShort()) As Short
    End Function    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferTransfer32(ByVal CardNumber As UShort, ByVal Buffer As UInteger()) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_AsyncDblBufferTransfer(ByVal CardNumber As UShort, ByVal Buffer As UShort()) As Short
    End Function
    
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_ContWriteChannel(ByVal CardNumber As UShort, ByVal Channel As UShort, ByVal AOBuffer As UInteger(), ByVal WriteCount As UInteger, ByVal Iterations As UInteger, ByVal CHUI As UInteger, _
    ByVal finite As UShort, ByVal SyncMode As UShort) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_ContWriteMultiChannels(ByVal CardNumber As UShort, ByVal NumChans As UShort, ByVal Chans As UInteger(), ByVal AOBuffer As UInteger(), ByVal WriteCount As UInteger, ByVal Iterations As UInteger, _
    ByVal CHUI As UInteger, ByVal finite As UShort, ByVal SyncMode As UShort) As Short
    End Function

    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_GetEvent(ByVal CardNumber As UShort, ByRef hEvent As Long) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_GetEvent(ByVal CardNumber As UShort, ByRef hEvent As Long) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AI_GetView(ByVal CardNumber As UShort, ByVal View As UInteger()) As Short
    End Function
    <DllImport("usb-dask.dll")> _
    Public Shared Function UD_AO_GetView(ByVal CardNumber As UShort, ByVal View As UInteger()) As Short
    End Function    
End Class
