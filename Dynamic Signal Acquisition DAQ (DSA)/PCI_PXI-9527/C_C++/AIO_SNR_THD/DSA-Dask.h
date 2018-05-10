#ifndef _DSA_DASK_H_
#define _DSA_DASK_H_

#ifdef __cplusplus
extern "C" {
#endif

//--------------------------------//
//         DASK Data Types        //
//--------------------------------//
typedef unsigned char  U8;
typedef short          I16;
typedef unsigned short U16;
typedef long           I32;
typedef unsigned long  U32;
typedef float          F32;
typedef double         F64;

//--------------------------------//
// Card Type of ADLINK DSA Series //
//--------------------------------//
#define PCI_9527 		1
#define PXI_9529 		2
#define PCI_9529 		2

#define MAX_CARD 		32

//--------------------------------//
//Event type for the event message//
//--------------------------------//
#define AIEnd					0
#define AOEnd					0
#define DIEnd					0
#define DOEnd					0
#define DBEvent					1
#define TrigEvent				2

//--------------------------------//
//          Error Number          //
//--------------------------------//
#define NoError                     0
#define ErrorUnknownCardType       -1
#define ErrorInvalidCardNumber     -2
#define ErrorTooManyCardRegistered -3
#define ErrorCardNotRegistered     -4
#define ErrorFuncNotSupport        -5
#define ErrorInvalidIoChannel      -6
#define ErrorInvalidAdRange        -7
#define ErrorContIoNotAllowed      -8
#define ErrorDiffRangeNotSupport   -9
#define ErrorLastChannelNotZero    -10
#define ErrorChannelNotDescending  -11
#define ErrorChannelNotAscending   -12
#define ErrorOpenDriverFailed      -13
#define ErrorOpenEventFailed       -14
#define ErrorTransferCountTooLarge -15
#define ErrorNotDoubleBufferMode   -16
#define ErrorInvalidSampleRate     -17
#define ErrorInvalidCounterMode    -18
#define ErrorInvalidCounter        -19
#define ErrorInvalidCounterState   -20
#define ErrorInvalidBinBcdParam    -21
#define ErrorBadCardType           -22
#define ErrorInvalidDaRefVoltage   -23
#define ErrorAdTimeOut             -24
#define ErrorNoAsyncAI             -25
#define ErrorNoAsyncAO             -26
#define ErrorNoAsyncDI             -27
#define ErrorNoAsyncDO             -28
#define ErrorNotInputPort          -29
#define ErrorNotOutputPort         -30
#define ErrorInvalidDioPort        -31
#define ErrorInvalidDioLine        -32
#define ErrorContIoActive          -33
#define ErrorDblBufModeNotAllowed  -34
#define ErrorConfigFailed          -35
#define ErrorInvalidPortDirection  -36
#define ErrorBeginThreadError      -37
#define ErrorInvalidPortWidth      -38
#define ErrorInvalidCtrSource      -39
#define ErrorOpenFile              -40
#define ErrorAllocateMemory        -41
#define ErrorDaVoltageOutOfRange   -42
#define ErrorDaExtRefNotAllowed    -43
#define ErrorDIODataWidthError     -44
#define ErrorTaskCodeError         -45
#define ErrortriggercountError     -46
#define ErrorInvalidTriggerMode    -47
#define ErrorInvalidTriggerType    -48
#define ErrorInvalidTriggerParam   -49
#define ErrorInvalidCounterValue   -50
#define ErrorInvalidConfig		   -51
#define ErrorIncompatibleOperation -52
#define ErrorInvalidEventHandle    -60
#define ErrorNoMessageAvailable    -61
#define ErrorEventMessgaeNotAdded  -62
#define ErrorCalibrationTimeOut    -63
#define ErrorUndefinedParameter    -64
#define ErrorInvalidBufferID       -65
#define ErrorInvalidSampledClock   -66
#define ErrorInvalidOperationMode  -67
#define ErrorOptionOutOfRanged	   -70
#define ErrorInvalidDDSFrequency   -80
#define ErrorFrequencyLocked       -81
#define ErrorInvalidUpdateRate     -82
#define ErrorClockFailed 	       -83
#define ErrorInvalidParmPointer    -84
#define ErrorIoChannelNotCreated   -85
#define ErrorInvalidAOParameter	   -86
#define ErrorIntClkFailed 	       -87
#define ErrorBadSyncSetting		   -88
#define ErrorAICalibrationFailed   -91
#define ErrorAOCalibrationFailed   -92
#define ErrorRefVolOutOfRanged	   -93

/*Error number for driver API*/
#define ErrorConfigIoctl           -201
#define ErrorAsyncSetIoctl         -202
#define ErrorDBSetIoctl            -203
#define ErrorDBHalfReadyIoctl      -204
#define ErrorContOPIoctl           -205
#define ErrorContStatusIoctl       -206
#define ErrorPIOIoctl              -207
#define ErrorDIntSetIoctl          -208
#define ErrorWaitEvtIoctl          -209
#define ErrorOpenEvtIoctl          -210
#define ErrorCOSIntSetIoctl        -211
#define ErrorMemMapIoctl           -212
#define ErrorMemUMapSetIoctl       -213
#define ErrorCTRIoctl              -214
#define ErrorGetResIoctl           -215
#define ErrorCalIoctl              -216
#define ErrorPMIntSetIoctl         -217

//--------------------------------//
//           AI/AO Range          //
//--------------------------------//
#define AD_B_10_V     1
#define AD_B_5_V      2
#define AD_B_2_5_V    3
#define AD_B_1_25_V   4
#define AD_B_0_625_V  5
#define AD_B_0_3125_V 6
#define AD_B_0_5_V    7
#define AD_B_0_05_V   8
#define AD_B_0_005_V  9
#define AD_B_1_V      10
#define AD_B_0_1_V    11
#define AD_B_0_01_V   12
#define AD_B_0_001_V  13
#define AD_U_20_V     14
#define AD_U_10_V     15
#define AD_U_5_V      16
#define AD_U_2_5_V    17
#define AD_U_1_25_V   18
#define AD_U_1_V      19
#define AD_U_0_1_V    20
#define AD_U_0_01_V   21
#define AD_U_0_001_V  22
#define AD_B_2_V      23
#define AD_B_0_25_V   24
#define AD_B_0_2_V    25
#define AD_U_4_V      26
#define AD_U_2_V      27
#define AD_U_0_5_V    28
#define AD_U_0_4_V    29
#define AD_B_1_5_V    30 
#define AD_B_0_2125_V 31 
#define AD_B_40_V     32
#define AD_B_3_16_V   33
#define AD_B_0_316_V  34

//--------------------------------//
//        Common Constants        //
//--------------------------------//
/* T or F*/
#define FALSE					0
#define TRUE					1
/*Synchronous Mode*/
#define SYNCH_OP				1
#define ASYNCH_OP				2
/*Clock Mode*/
#define TRIG_INTERNAL			0
#define TRIG_PXI_CLK			1
/*Function Type Constants*/
#define DAQ_AI					0
#define DAQ_AO					1
#define DAQ_DI					2
#define DAQ_DO					3
/*EEPROM*/
#define EEPROM_DEFAULT_BANK		0
#define EEPROM_USER_BANK1		1
#define EEPROM_USER_BANK2		2
#define EEPROM_USER_BANK3		3

//--------------------------------//
//   Constants for PCI/PXI-9527   //
//--------------------------------//
/*DDS Constants*/
#define P9527_AI_MaxDDSFreq		432000
#define P9527_AI_MinDDSFreq		2000
#define P9527_AO_MaxDDSFreq		216000
#define P9527_AO_MinDDSFreq		1000
/*DDS Phase*/
#define P9527_DDSPhase_0D      0x00
#define P9527_DDSPhase_11R25D  0x01
#define P9527_DDSPhase_22R5D   0x02
#define P9527_DDSPhase_33R75D  0x03
#define P9527_DDSPhase_45D     0x04
#define P9527_DDSPhase_56R25D  0x05
#define P9527_DDSPhase_67R5D   0x08
#define P9527_DDSPhase_78R75D  0x07
#define P9527_DDSPhase_90D     0x08
#define P9527_DDSPhase_101R25D 0x09
#define P9527_DDSPhase_112R5D  0x0a
#define P9527_DDSPhase_123R75D 0x0b
#define P9527_DDSPhase_135D    0x0c
#define P9527_DDSPhase_146R25D 0x0d
#define P9527_DDSPhase_157R5D  0x0e
#define P9527_DDSPhase_168R75D 0x0f
#define P9527_DDSPhase_180D    0x10
#define P9527_DDSPhase_191R25D 0x11
#define P9527_DDSPhase_202R5D  0x12
#define P9527_DDSPhase_213R75D 0x13
#define P9527_DDSPhase_225D    0x14
#define P9527_DDSPhase_236R25D 0x15
#define P9527_DDSPhase_247R5D  0x16
#define P9527_DDSPhase_258R75D 0x17
#define P9527_DDSPhase_270D    0x18
#define P9527_DDSPhase_281R25D 0x19
#define P9527_DDSPhase_292R5D  0x1a
#define P9527_DDSPhase_303R75D 0x1b
#define P9527_DDSPhase_315D    0x1c
#define P9527_DDSPhase_326R25D 0x1d
#define P9527_DDSPhase_337R5D  0x1e
#define P9527_DDSPhase_348R75D 0x1f

/*
 * AI Constants
 */
/*AI Select Channel*/
#define P9527_AI_CH_0					0
#define P9527_AI_CH_1					1
#define P9527_AI_CH_DUAL				2
/*Input Type*/
#define P9527_AI_Differential			0x00
#define P9527_AI_PseudoDifferential		0x01
/*Input Coupling*/
#define P9527_AI_Coupling_DC        	0x00
#define P9527_AI_Coupling_AC        	0x10
#define P9527_AI_EnableIEPE         	0x20

/*
 * AO Constants
 */
/*AI Select Channel*/
#define P9527_AO_CH_0					0
#define P9527_AO_CH_1					1
#define P9527_AO_CH_DUAL				2
/*Output Type*/
#define P9527_AO_Differential			0x00
#define P9527_AO_PseudoDifferential		0x01
#define P9527_AO_BalancedOutput			0x02

/*
 * Trigger Constants
 */
/*Trigger Mode*/
#define P9527_TRG_MODE_POST        0x00
#define P9527_TRG_MODE_DELAY       0x01
/*Trigger Target*/
#define P9527_TRG_NONE				0x0
#define P9527_TRG_AI				0x1
#define P9527_TRG_AO				0x2
#define P9527_TRG_ALL				0x3
/*Trigger Source*/
#define P9527_TRG_SRC_SOFT        0x00
#define P9527_TRG_SRC_EXTD  	  0x10
#define P9527_TRG_SRC_ANALOG      0x20
#define P9527_TRG_SRC_SSI9        0x30
#define P9527_TRG_SRC_NOWAIT	  0x40

#define P9527_TRG_SRC_PXI_STARTIN	0x70
#define P9527_TRG_SRC_PXI_BUS0		0x80
#define P9527_TRG_SRC_PXI_BUS1		0x90
#define P9527_TRG_SRC_PXI_BUS2		0xA0
#define P9527_TRG_SRC_PXI_BUS3		0xB0
#define P9527_TRG_SRC_PXI_BUS4		0xC0
#define P9527_TRG_SRC_PXI_BUS5		0xD0
#define P9527_TRG_SRC_PXI_BUS6		0xE0
#define P9527_TRG_SRC_PXI_BUS7		0xF0
/*Trigger Polarity*/
#define P9527_TRG_Negative        0x000
#define P9527_TRG_Positive        0x100
/*ReTrigger*/
#define P9527_TRG_EnReTigger      0x200
/*Analog Trigger Source*/
#define P9527_TRG_Analog_CH0     0
#define P9527_TRG_Analog_CH1     1
/*Analog Trigger Mode*/
#define P9527_TRG_Analog_Above_threshold     0
#define P9527_TRG_Analog_Below_threshold     1

/*
 * External trigger signal code
 */
#define P9527_TRG_OUT_SSI9			0x40
#define P9527_TRG_OUT_PXI_BUS0		0x40
#define P9527_TRG_OUT_PXI_BUS1		0x41
#define P9527_TRG_OUT_PXI_BUS2		0x42
#define P9527_TRG_OUT_PXI_BUS3		0x43
#define P9527_TRG_OUT_PXI_BUS4		0x44
#define P9527_TRG_OUT_PXI_BUS5		0x45
#define P9527_TRG_OUT_PXI_BUS6		0x46
#define P9527_TRG_OUT_PXI_BUS7		0x47

//--------------------------------//
//     Constants for PXIe-9529    //
//--------------------------------//
/*
 * AI Constants
 */
#define P9529_AI_CH0				0
#define P9529_AI_CH1				1
#define P9529_AI_CH2				2
#define P9529_AI_CH3				3
#define P9529_AI_CH4				4
#define P9529_AI_CH5				5
#define P9529_AI_CH6				6
#define P9529_AI_CH7				7
/*Input Type*/
#define P9529_AI_Diff				0x0
#define P9529_AI_PseDiff			0x1
/*Input Coupling*/
#define P9529_AI_Coupling_DC        0x0
#define P9529_AI_Coupling_AC        0x4
#define P9529_AI_EnableIEPE         0x6
/*
 * Timebase Constants
 */
/*Timebase Source*/
#define P9529_Internal				0x0
#define P9529_PXI10M				0x1
#define P9529_PXIE100M				0x2
#define P9529_PXITRIGBus			0x3
#define P9529_TimeBase_SSI			0x4
/*Timebase Ouput Control*/
#define P9529_CLKOut_Disable		0x00
#define P9529_CLKOut_Enable			0x10
/*Timebase from/to TRIGBUS*/
#define P9529_ExtCLK_TrgBus0		0x000
#define P9529_ExtCLK_TrgBus1		0x100
#define P9529_ExtCLK_TrgBus2		0x200
#define P9529_ExtCLK_TrgBus3		0x300
#define P9529_ExtCLK_TrgBus4		0x400
#define P9529_ExtCLK_TrgBus5		0x500
#define P9529_ExtCLK_TrgBus6		0x600
#define P9529_ExtCLK_TrgBus7		0x700
#define P9529_ExtCLK_SSI			0x800
/*
 * Trigger Constants
 */
/*Trigger Configuration Target*/
#define P9529_TRG_NONE				0x0
#define P9529_TRG_AI				0x1
/*Trigger Mode*/
#define P9529_TRG_MODE_POST			0x00
#define P9529_TRG_MODE_DELAY		0x01
/*Trigger Source*/
#define P9529_TRG_SRC_SOFT			0x00
#define P9529_TRG_SRC_EXTD  		0x10
#define P9529_TRG_SRC_ANALOG		0x20
#define P9529_TRG_SRC_SSI			0xD0
#define P9529_TRG_SRC_NOWAIT		0x40
#define P9529_TRG_SRC_PXIE_STARTIN	0x60
#define P9529_TRG_SRC_PXI_STARTIN	0x70
#define P9529_TRG_SRC_PXI_BUS0		0x80
#define P9529_TRG_SRC_PXI_BUS1		0x90
#define P9529_TRG_SRC_PXI_BUS2		0xA0
#define P9529_TRG_SRC_PXI_BUS3		0xB0
#define P9529_TRG_SRC_PXI_BUS4		0xC0
#define P9529_TRG_SRC_PXI_BUS5		0xD0
#define P9529_TRG_SRC_PXI_BUS6		0xE0
#define P9529_TRG_SRC_PXI_BUS7		0xF0
/*PXI Trigger Output Target*/
#define P9529_TRG_OUT_PXI_BUS0		0x40
#define P9529_TRG_OUT_PXI_BUS1		0x41
#define P9529_TRG_OUT_PXI_BUS2		0x42
#define P9529_TRG_OUT_PXI_BUS3		0x43
#define P9529_TRG_OUT_PXI_BUS4		0x44
#define P9529_TRG_OUT_PXI_BUS5		0x45
#define P9529_TRG_OUT_PXI_BUS6		0x46
#define P9529_TRG_OUT_PXI_BUS7		0x47
#define P9529_TRG_OUT_SSI			0x45
/*Trigger Polarity*/
#define P9529_TRG_Negative			0x000
#define P9529_TRG_Positive			0x100
/*ReTrigger*/
#define P9529_TRG_EnReTigger		0x200
/*Analog Trigger Source*/
#define P9529_TRG_Analog_CH0		0
#define P9529_TRG_Analog_CH1		1
#define P9529_TRG_Analog_CH2		2
#define P9529_TRG_Analog_CH3		3
#define P9529_TRG_Analog_CH4		4
#define P9529_TRG_Analog_CH5		5
#define P9529_TRG_Analog_CH6		6
#define P9529_TRG_Analog_CH7		7
/*Analog Trigger Mode*/
#define P9529_TRG_Analog_Above		0
#define P9529_TRG_Analog_Below		1
/*
 * Multi-Card Sync Constants
 */
/*Multi-Card setting*/
#define P9529_SYN_Disable			0x0
#define P9529_SYN_MasterCard  		0x1
#define P9529_SYN_SlaveCard			0x2
/*Multi-Card PDN cia specific source*/
#define P9529_SYN_PXI_BUS0			0x0
#define P9529_SYN_PXI_BUS1			0x1
#define P9529_SYN_PXI_BUS2			0x2
#define P9529_SYN_PXI_BUS3			0x3
#define P9529_SYN_PXI_BUS4			0x4
#define P9529_SYN_PXI_BUS5			0x5
#define P9529_SYN_PXI_BUS6			0x6
#define P9529_SYN_PXI_BUS7			0x7
#define P9529_SYN_PXI_STARTRIG		0x8
#define P9529_SYN_PXIE_STARTRIG		0x9
#define P9529_SYN_FRONT_SMB			0xA
#define P9529_SYN_SSI				0x1
/*Status Mask*/
#define P9529_SYN_IsMultiCard		0x1
#define P9529_SYN_IsMasterCard		0x2
#define P9529_SYN_IsPDNSyncReady	0x4

//--------------------------------//
//  DSA-DASK Function prototype   //
//--------------------------------//
/* Basic Function */
I16 __stdcall DSA_Register_Card(U16 CardType, U16 card_num);
I16 __stdcall DSA_Release_Card(U16 CardNumber);
I16 __stdcall DSA_SetTimebase(U16 CardNumber, U32 ClockSrc);
I16 __stdcall DSA_ConfigSpeedRate(U16 wCardNumber,	U16 Function, U16 Setting, F64 SetDemandRate, F64 *GetActualRate);
/* AI Function */
I16 __stdcall DSA_AI_9527_ConfigChannel(U16 CardNumber, U16 Channel, U16 AdRange, U16 ConfigCtrl, BOOLEAN AutoResetBuf);
I16 __stdcall DSA_AI_9529_ConfigChannel(U16 CardNumber, U16	Channel, BOOLEAN Enable, U16 wAdRange, U16 ConfigCtrl);
I16 __stdcall DSA_AI_9527_ConfigSampleRate(U16 wCardNumber, F64 SetDemandRate, F64 *GetActualRate);
I16 __stdcall DSA_AI_AsyncCheck(U16 CardNumber, BOOLEAN *Stopped, U32 *AccessCnt);
I16 __stdcall DSA_AI_AsyncClear(U16 CardNumber, U32 *AccessCnt);
I16 __stdcall DSA_AI_AsyncDblBufferHalfReady(U16 CardNumber, BOOLEAN *HalfReady, BOOLEAN *StopFlag);
I16 __stdcall DSA_AI_AsyncDblBufferHandled(U16 CardNumber);
I16 __stdcall DSA_AI_AsyncDblBufferMode(U16 CardNumber, BOOLEAN Enable);
I16 __stdcall DSA_AI_AsyncDblBufferOverrun(U16 CardNumber, U16 op, U16 *overrunFlag);
I16 __stdcall DSA_AI_AsyncDblBufferToFile(U16 CardNumber);
I16 __stdcall DSA_AI_AsyncReTrigNextReady(U16 CardNumber, BOOLEAN *Ready, BOOLEAN *StopFlag, U16 *RdyTrigCnt);
I16 __stdcall DSA_AI_ContBufferReset(U16 CardNumber);
I16 __stdcall DSA_AI_ContBufferSetup(U16 CardNumber, void *Buffer, U32 ReadCount, U16 *BufferId);
I16 __stdcall DSA_AI_ContReadChannel(U16 CardNumber, U16 Channel, U16 AdRange, U16 *Buffer, U32 ReadCount, F64 SampleRate, U16 SyncMode);
I16 __stdcall DSA_AI_ContReadChannelToFile(U16 CardNumber, U16 Channel, U16 AdRange, U8 *FileName, U32 ReadCount, F64 SampleRate, U16 SyncMode);
I16 __stdcall DSA_AI_ContStatus(U16 CardNumber, U16 *Status);
I16 __stdcall DSA_AI_ContVScale(U16 CardNumber, U16 adRange, void *readingArray, F64 *voltageArray, I32 count);
I16 __stdcall DSA_AI_DataScaler(U16 cardType, U16 adRange, void *readingArray, F64 *voltageArray, I32 count);
I16 __stdcall DSA_AI_EventCallBack(U16 CardNumber, I16 mode, I16 EventType, U32 callbackAddr);
I16 __stdcall DSA_AI_InitialMemoryAllocated(U16 CardNumber, U32 *MemSize);
I16 __stdcall DSA_AI_SetTimeOut(U16 CardNumber, U32 TimeOut);
/* AO Function */
I16 __stdcall DSA_AO_9527_ConfigChannel(U16 CardNumber, U16 Channel, U16 AdRange, U16 ConfigCtrl, BOOLEAN AutoResetBuf);
I16 __stdcall DSA_AO_9527_ConfigSampleRate(U16 wCardNumber, F64 SetDemandRate, F64 *GetActualRate);
I16 __stdcall DSA_AO_AsyncCheck(U16 CardNumber, BOOLEAN *Stopped, U32 *AccessCnt);
I16 __stdcall DSA_AO_AsyncClear(U16 CardNumber, U32 *AccessCnt, U16 stop_mode);
I16 __stdcall DSA_AO_AsyncDblBufferHalfReady(U16 CardNumber, BOOLEAN *bHalfReady);
I16 __stdcall DSA_AO_AsyncDblBufferMode(U16 CardNumber, BOOLEAN Enable);
I16 __stdcall DSA_AO_ContBufferReset(U16 CardNumber);
I16 __stdcall DSA_AO_ContBufferSetup(U16 CardNumber, void *Buffer, U32 WriteCount, U16 *BufferId); 
I16 __stdcall DSA_AO_ContStatus(U16 CardNumber, U16	 *Status);
I16 __stdcall DSA_AO_ContWriteChannel(U16 CardNumber, U16 Channel, U16 BufId, U32 WriteCount, U32 Iterations, U32 dwInterval, U16 definite, U16 SyncMode);
I16 __stdcall DSA_AO_EventCallBack(U16 CardNumber, I16 mode, I16 EventType, U32 callbackAddr);
I16 __stdcall DSA_AO_InitialMemoryAllocated(U16 CardNumber, U32 *MemSize);
I16 __stdcall DSA_AO_SetTimeOut(U16 CardNumber, U32 TimeOut);
I16 __stdcall DSA_AO_VoltScale(U16 CardNumber, U16 Channel, F64 Voltage, I32 *binValue);
/* Trigger Function */
I16 __stdcall DSA_TRG_Config(U16 CardNumber, U16 FuncSel, U16 TrigCtrl, U32 ReTriggerCnt, U32 TriggerDelay);
I16 __stdcall DSA_TRG_ConfigAnalogTrigger(U16 CardNumber, U32 ATrigSrc, U32 ATrigMode, F64 Threshold);
I16 __stdcall DSA_TRG_SoftTriggerGen(U16 CardNumber);
I16 __stdcall DSA_TRG_SourceConn(U16 CardNumber, U16 sigCode);
I16 __stdcall DSA_TRG_SourceDisConn(U16 CardNumber, U16 sigCode);
I16 __stdcall DSA_TRG_SourceClear(U16 CardNumber);
/* Multi-Card Sync Function */
I16 __stdcall DSA_SYN_ConfigMultiCard(U16 wCardNumber, U16 Function, U32 Parameter);
I16 __stdcall DSA_SYN_CheckMultiCardStatus(U16 wCardNumber,	U16 *Status);
I16 __stdcall DSA_SYN_SyncStart(U16 wCardNumber);
/*Get Event or View Function */
I16 __stdcall DSA_GetAIEvent(U16 CardNumber, HANDLE *hEvent);
I16 __stdcall DSA_GetAOEvent(U16 CardNumber, HANDLE *hEvent);
/* Common Function */
I16 __stdcall DSA_GetActualRate(U16 CardNumber, F64 SampleRate, F64 *ActualRate);
I16 __stdcall DSA_GetBaseAddr(U16 CardNumber, U32 *BaseAddr, U32 *BaseAddr2);
I16 __stdcall DSA_GetLCRAddr(U16 CardNumber, U32 *LcrAddr);
I16 __stdcall DSA_GetFPGAVersion(U16 CardNumber, U32 *FPGAVersion);
/* Calibration Function */
I16 __stdcall DSA_Auto_Calibration_ALL(U16 CardNumber);
I16 __stdcall DSA_CAL_SetDefaultBank(U16 CardNumber, U16 bank);
I16 __stdcall DSA_CAL_SaveToUserBank(U16 CardNumber, U16 bank);
I16 __stdcall DSA_CAL_LoadFromBank(U16 CardNumber, U16 bank);

#ifdef __cplusplus
}
#endif

#endif