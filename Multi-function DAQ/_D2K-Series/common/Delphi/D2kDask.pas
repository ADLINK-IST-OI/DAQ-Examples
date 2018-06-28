unit D2KDASK;

interface

Const

(*-------- DAQ 2000 Card Type -----------*)
  DAQ_2010  =  1;
  DAQ_2205  =  2;
  DAQ_2206  =  3;
  DAQ_2005  =  4;
  DAQ_2204  =  5;
  DAQ_2006  =  6;
  DAQ_2501  =  7;
  DAQ_2502  =  8;
  DAQ_2208  =  9;
  DAQ_2213  =  10;
  DAQ_2214  =  11;
  DAQ_2016  =  12;

  MAX_CARD   = 32;

(*-------- Error Number -----------*)
  NoError                    =  0;
  ErrorUnknownCardType       = -1;
  ErrorInvalidCardNumber     = -2;
  ErrorTooManyCardRegistered = -3;
  ErrorCardNotRegistered     = -4;
  ErrorFuncNotSupport        = -5;
  ErrorInvalidIoChannel      = -6;
  ErrorInvalidAdRange        = -7;
  ErrorContIoNotAllowed      = -8;
  ErrorDiffRangeNotSupport   = -9;
  ErrorLastChannelNotZero    = -10;
  ErrorChannelNotDescending  = -11;
  ErrorChannelNotAscending   = -12;
  ErrorOpenDriverFailed      = -13;
  ErrorOpenEventFailed       = -14;
  ErrorTransferCountTooLarge = -15;
  ErrorNotDoubleBufferMode   = -16;
  ErrorInvalidSampleRate     = -17;
  ErrorInvalidCounterMode    = -18;
  ErrorInvalidCounter        = -19;
  ErrorInvalidCounterState   = -20;
  ErrorInvalidBinBcdParam    = -21;
  ErrorBadCardType           = -22;
  ErrorInvalidDaRefVoltage   = -23;
  ErrorAdTimeOut             = -24;
  ErrorNoAsyncAI             = -25;
  ErrorNoAsyncAO             = -26;
  ErrorNoAsyncDI             = -27;
  ErrorNoAsyncDO             = -28;
  ErrorNotInputPort          = -29;
  ErrorNotOutputPort         = -30;
  ErrorInvalidDioPort        = -31;
  ErrorInvalidDioLine        = -32;
  ErrorContIoActive          = -33;
  ErrorDblBufModeNotAllowed  = -34;
  ErrorConfigFailed          = -35;
  ErrorInvalidPortDirection  = -36;
  ErrorBeginThreadError      = -37;
  ErrorInvalidPortWidth      = -38;
  ErrorInvalidCtrSource      = -39;
  ErrorOpenFile              = -40;
  ErrorAllocateMemory        = -41;
  ErrorDaVoltageOutOfRange   = -42;
  ErrorInvalidSyncMode       = -43;
  ErrorInvalidBufferID       = -44;
  ErrorInvalidCNTInterval	 = -45;
  ErrorReTrigModeNotAllowed  = -46;
  ErrorResetBufferNotAllowed = -47;
  ErrorAnaTriggerLevel       = -48;
  ErrorDAQEvent				 = -49;
  ErrorConfigIoctl           = -201;
  ErrorAsyncSetIoctl         = -202;
  ErrorDBSetIoctl            = -203;
  ErrorDBHalfReadyIoctl      = -204;
  ErrorContOPIoctl           = -205;
  ErrorContStatusIoctl       = -206;
  ErrorPIOIoctl              = -207;
  ErrorDIntSetIoctl          = -208;
  ErrorWaitEvtIoctl          = -209;
  ErrorOpenEvtIoctl          = -210;
  ErrorCOSIntSetIoctl        = -211;
  ErrorMemMapIoctl           = -212;
  ErrorMemUMapSetIoctl       = -213;
  ErrorCTRIoctl              = -214;

(*-------- Synchronous Mode -----------*)
  SYNCH_OP  = 1;
  ASYNCH_OP = 2;

(*-------- AD Range -----------*)
  AD_B_10_V     =  1;
  AD_B_5_V      =  2;
  AD_B_2_5_V    =  3;
  AD_B_1_25_V   =  4;
  AD_B_0_625_V  =  5;
  AD_B_0_3125_V =  6;
  AD_B_0_5_V    =  7;
  AD_B_0_05_V   =  8;
  AD_B_0_005_V  =  9;
  AD_B_1_V      = 10;
  AD_B_0_1_V    = 11;
  AD_B_0_01_V   = 12;
  AD_B_0_001_V  = 13;
  AD_U_20_V     = 14;
  AD_U_10_V     = 15;
  AD_U_5_V      = 16;
  AD_U_2_5_V    = 17;
  AD_U_1_25_V   = 18;
  AD_U_1_V      = 19;
  AD_U_0_1_V    = 20;
  AD_U_0_01_V   = 21;
  AD_U_0_001_V  = 22;
  AD_B_2_V		= 23;
  AD_B_0_25_V	= 24;
  AD_B_0_2_V	= 25;
  AD_U_4_V		= 26;
  AD_U_2_V		= 27;
  AD_U_0_5_V	= 28;
  AD_U_0_4_V	= 29;

(*--------- Constants for DIO Port Direction ----------*)
 (*--- DIO Port Direction ---*)
  INPUT_PORT  = 1;
  OUTPUT_PORT = 2;

 (*--- Channel&Port ---*)
  Channel_P1A  = 0;
  Channel_P1B  = 1;
  Channel_P1C  = 2;
  Channel_P1CL = 3;
  Channel_P1CH = 4;
  Channel_P1AE = 10;
  Channel_P1BE = 11;
  Channel_P1CE = 12;
  Channel_P2A  = 5;
  Channel_P2B  = 6;
  Channel_P2C  = 7;
  Channel_P2CL = 8;
  Channel_P2CH = 9;
  Channel_P2AE = 15;
  Channel_P2BE = 16;
  Channel_P2CE = 17;
  Channel_P3A  = 10;
  Channel_P3B  = 11;
  Channel_P3C  = 12;
  Channel_P3CL = 13;
  Channel_P3CH = 14;
  Channel_P4A  = 15;
  Channel_P4B  = 16;
  Channel_P4C  = 17;
  Channel_P4CL = 18;
  Channel_P4CH = 19;
  Channel_P5A  = 20;
  Channel_P5B  = 21;
  Channel_P5C  = 22;
  Channel_P5CL = 23;
  Channel_P5CH = 24;
  Channel_P6A  = 25;
  Channel_P6B  = 26;
  Channel_P6C  = 27;
  Channel_P6CL = 28;
  Channel_P6CH = 29;

(*-------- Constants for DAQ-2000 ------------*)
  All_Channels = -1;
  BufferNotUsed = -1;

 (*-- Constants for AI --*)
  DAQ2K_AI_ADSTARTSRC_Int = $0;
  DAQ2K_AI_ADSTARTSRC_AFI0 = $10;
  DAQ2K_AI_ADSTARTSRC_SSI = $20;

  DAQ2K_AI_ADCONVSRC_Int = $0;
  DAQ2K_AI_ADCONVSRC_AFI0 = $4;
  DAQ2K_AI_ADCONVSRC_SSI = $8;
  DAQ2K_AI_ADCONVSRC_AFI1 = $C;

 (*-- Constants for AI Delay Counter SRC: only available for DAQ-250X --*)
  DAQ2K_AI_DTSRC_Int = $0;
  DAQ2K_AI_DTSRC_AFI1 = $10;
  DAQ2K_AI_DTSRC_GPTC0 = $20;
  DAQ2K_AI_DTSRC_GPTC1 = $30;

  DAQ2K_AI_TRGSRC_SOFT = $0;
  DAQ2K_AI_TRGSRC_ANA = $1;
  DAQ2K_AI_TRGSRC_ExtD = $2;
  DAQ2K_AI_TRSRC_SSI = $3;
  DAQ2K_AI_TRGMOD_POST = $0;    (*-- Post Trigger Mode --*)
  DAQ2K_AI_TRGMOD_DELAY = $8;   (*-- Delay Trigger Mode --*)
  DAQ2K_AI_TRGMOD_PRE = $10;    (*-- Pre-Trigger Mode --*)
  DAQ2K_AI_TRGMOD_MIDL = $18;   (*-- Middle Trigger Mode --*)
  DAQ2K_AI_ReTrigEn = $80;
  DAQ2K_AI_Dly1InSamples = $100;
  DAQ2K_AI_Dly1InTimebase = $0;
  DAQ2K_AI_MCounterEn = $400;
  DAQ2K_AI_TrgPositive = $0;
  DAQ2K_AI_TrgNegative = $1000;

  AI_RSE = $0;
  AI_DIFF = $100;
  AI_NRSE = $200;
 (*-- Constants for DA --*)
  DAQ2K_DA_BiPolar = $1;
  DAQ2K_DA_UniPolar = $0;
  DAQ2K_DA_Int_REF = $0;
  DAQ2K_DA_Ext_REF = $1;

  DAQ2K_DA_WRSRC_Int = $0;
  DAQ2K_DA_WRSRC_AFI0 = $1;
  DAQ2K_DA_WRSRC_AFI1 = $1;
  DAQ2K_DA_WRSRC_SSI = $2;
 (*-- DA group --*) 
  DA_Group_A = $0;
  DA_Group_B = $4;
  DA_Group_AB = $8;
 (*-- DA TD Counter SRC: only available for DAQ-250X --*) 
  DAQ2K_DA_TDSRC_Int = $0;
  DAQ2K_DA_TDSRC_AFI0 = $10;
  DAQ2K_DA_TDSRC_GPTC0 = $20;
  DAQ2K_DA_TDSRC_GPTC1 = $30;
 (*-- DA BD Counter SRC: only available for DAQ-250X --*)
  DAQ2K_DA_BDSRC_Int = $0;
  DAQ2K_DA_BDSRC_AFI0 = $40;
  DAQ2K_DA_BDSRC_GPTC0 = $80;
  DAQ2K_DA_BDSRC_GPTC1 = $C0;
 (*-- DA trigger constant --*)
  DAQ2K_DA_TRGSRC_SOFT = $0;   (*-- Software Trigger Mode --*)
  DAQ2K_DA_TRGSRC_ANA = $1;    (*--Post Trigger Mode --*)
  DAQ2K_DA_TRGSRC_ExtD = $2;   (*--Delay Trigger Mode --*)
  DAQ2K_DA_TRSRC_SSI = $3;
  DAQ2K_DA_TRGMOD_POST = $0;
  DAQ2K_DA_TRGMOD_DELAY = $4;
  DAQ2K_DA_ReTrigEn = $20;
  DAQ2K_DA_Dly1InUI = $40;
  DAQ2K_DA_Dly1InTimebase = $0;
  DAQ2K_DA_Dly2InUI = $80;
  DAQ2K_DA_Dly2InTimebase = $0;
  DAQ2K_DA_DLY2En = $100;
  DAQ2K_DA_TrgPositive = $0;
  DAQ2K_DA_TrgNegative = $200;

 (*-- DA stop mode --*)
  DAQ2K_DA_TerminateImmediate = 0;
  DAQ2K_DA_TerminateUC        = 1;
  DAQ2K_DA_TerminateFIFORC    = 2;
  DAQ2K_DA_TerminateIC	      = 2;

 (*-- Constants for Analog trigger --*)
  Below_Low_level = $0;
  Above_High_Level = $100;
  Inside_Region = $200;
  High_Hysteresis = $300;
  Low_Hysteresis = $400;
 (*-- Analog trigger Dedicated Channel --*)
  CH0ATRIG = $0;
  CH1ATRIG = $2;
  CH2ATRIG = $4;
  CH3ATRIG = $6;
  EXTATRIG = $1;
  ADCATRIG = $0;
 (*-- Time Base --*)
  DAQ2K_IntTimeBase = $0;
  DAQ2K_ExtTimeBase = $1;
  DAQ2K_SSITimeBase = $2;

 (*-------- General Purpose Timer/Counter ------------*)
 (*-- Counter Mode --*)
  SimpleGatedEventCNT = 1;
  SinglePeriodMSR = 2;
  SinglePulseWidthMSR = 3;
  SingleGatedPulseGen = 4;
  SingleTrigPulseGen = 5;
  RetrigSinglePulseGen = 6;
  SingleTrigContPulseGen = 7;
  ContGatedPulseGen = 8;
 (*-- GPTC clock source --*)
  GPTC_GATESRC_EXT = $4;
  GPTC_GATESRC_INT = $0;
  GPTC_CLKSRC_EXT = $8;
  GPTC_CLKSRC_INT = $0;
  GPTC_UPDOWN_SEL_EXT = $10;
  GPTC_UPDOWN_SEL_INT = $0;
 (*-- GPTC clock polarity --*)
  GPTC_CLKEN_LACTIVE = $1;
  GPTC_CLKEN_HACTIVE = $0;
  GPTC_GATE_LACTIVE = $2;
  GPTC_GATE_HACTIVE = $0;
  GPTC_UPDOWN_LACTIVE = $4;
  GPTC_UPDOWN_HACTIVE = $0;
  GPTC_OUTPUT_LACTIVE = $8;
  GPTC_OUTPUT_HACTIVE = $0;
  GPTC_INT_LACTIVE = $10;
  GPTC_INT_HACTIVE = $0;
 (*-- GPTC paramID --*)
  GPTC_IntGATE = $0;
  GPTC_IntUpDnCTR = $1;
  GPTC_IntENABLE = $2;

 (*-- SSI signal code --*)
  SSI_TIME	= 1;
  SSI_CONV	= 2;
  SSI_WR	= 4;
  SSI_ADSTART = 8; 
  SSI_ADTRIG = $20; 
  SSI_DATRIG = $40;

 (*-- DAQ Event type for the event message --*)
  DAQEnd	= 0;
  DBEvent	= 1;
  TrigEvent	= 2;
  DAQEnd_A	= 0;
  DAQEnd_B =  2;
  DAQEnd_AB = 3;
  DATrigEvent = 4;
  DATrigEvent_A = 4;
  DATrigEvent_B = 5;
  DATrigEvent_AB = 6;

(*-------- Timer/Counter -----------------------------*)
 (*-- Counter Mode (8254) --*)
  TOGGLE_OUTPUT          = 0;   (* Toggle output from low to high on terminal count *)
  PROG_ONE_SHOT          = 1;   (* Programmable one-shot      *)
  RATE_GENERATOR         = 2;   (* Rate generator             *)
  SQ_WAVE_RATE_GENERATOR = 3;   (* Square wave rate generator *)
  SOFT_TRIG              = 4;   (* Software-triggered strobe  *)
  HARD_TRIG              = 5;   (* Hardware-triggered strobe  *)

 (*-------- 16-bit binary or 4-decade BCD counter------------------*)
  BIN = 0;
  BCD = 1;

type
  TCallbackFunc = function : Integer;

(****************************************************************************)
(*          D2K-DASK Functions Declarations                                *)
(****************************************************************************)
function D2K_Register_Card (CardType:Word; card_num:Word):Smallint;stdcall;
function D2K_Release_Card  (CardNumber:Word):Smallint;stdcall;
function D2K_AIO_Config (CardNumber:Word; TimerBase:Word; AnaTrigCtrl:Word; H_TrgLevel:Word; L_TrgLevel:Word):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function D2K_AI_Config (CardNumber:Word; ConfigCtrl:Word; TrigCtrl:Word; MidOrDlyScans:Cardinal; MCnt:Word; ReTrgCnt:Word; AutoResetBuf:Byte):Smallint;stdcall;
function D2K_AI_PostTrig_Config (CardNumber:Word; ClkSrc:Word; TrigSrcCtrl:Word; ReTrgEn:Word; ReTrgCnt:Word; AutoResetBuf:Byte):Smallint;stdcall;
function D2K_AI_DelayTrig_Config (CardNumber:Word; ClkSrc:Word; TrigSrcCtrl:Word; DlyScans:Cardinal; ReTrgEn:Word; ReTrgCnt:Word; AutoResetBuf:Byte):Smallint;stdcall;
function D2K_AI_PreTrig_Config (CardNumber:Word; ClkSrc:Word; TrigSrcCtrl:Word; MCtrEn:Word; MCnt:Word; AutoResetBuf:Byte):Smallint;stdcall;
function D2K_AI_MiddleTrig_Config (CardNumber:Word; ClkSrc:Word; TrigSrcCtrl:Word; MiddleScans:Cardinal; MCtrEn:Word; MCnt:Word; AutoResetBuf:Byte):Smallint;stdcall;
function D2K_AI_CH_Config (CardNumber:Word; Channel:Word; AdRange_RefGnd:Word):Smallint;stdcall;
function D2K_AI_InitialMemoryAllocated (CardNumber:Word; var MemSize:Cardinal):Smallint;stdcall;
function D2K_AI_ReadChannel (CardNumber:Word; Channel:Word; var Value:Word):Smallint;stdcall;
function D2K_AI_VReadChannel (CardNumber:Word; Channel:Word; var voltage:Double):Smallint;stdcall;
function D2K_AI_SimuReadChannel (CardNumber:Word;  NumChans:Word; var Chans:Word; var Buffer:Word):Smallint;stdcall;
function D2K_AI_ScanReadChannels (CardNumber:Word;  NumChans:Word; var Chans:Word; var Buffer:Word):Smallint;stdcall;
function D2K_AI_VoltScale (CardNumber:Word; AdRange:Word; reading:Smallint; var voltage:Double):Smallint;stdcall;
function D2K_AI_ContReadChannel (CardNumber:Word; Channel:Word; BufId:Word; ReadScans:Cardinal; ScanIntrv:Cardinal; SampIntrv:Cardinal; SyncMode:Word):Smallint;stdcall;
function D2K_AI_ContReadMultiChannels (CardNumber:Word; NumChans:Word; var Chans:Word; BufId:Word; ReadScans:Cardinal;
               ScanIntrv:Cardinal; SampIntrv:Cardinal; SyncMode:Word):Smallint;stdcall;
function D2K_AI_ContScanChannels (CardNumber:Word; Channel:Word; BufId:Word; ReadScans:Cardinal; ScanIntrv:Cardinal; SampIntrv:Cardinal; SyncMode:Word):Smallint;stdcall;
function D2K_AI_ContReadChannelToFile (CardNumber:Word; Channel:Word; BufId:Word; var FileName:Char; ReadScans:Cardinal;
			   ScanIntrv:Cardinal; SampIntrv:Cardinal; SyncMode:Word):Smallint;stdcall;
function D2K_AI_ContReadMultiChannelsToFile (CardNumber:Word; NumChans:Word; var Chans:Word;
               BufId:Word; var FileName:Byte; ReadScans:Cardinal;
               ScanIntrv:Cardinal; SampIntrv:Cardinal; SyncMode:Word):Smallint;stdcall;
function D2K_AI_ContScanChannelsToFile (CardNumber:Word; Channel:Word; BufId:Word;
               var FileName:Char; ReadScans:Cardinal; ScanIntrv:Cardinal; SampIntrv:Cardinal; SyncMode:Word):Smallint;stdcall;
function D2K_AI_ContVScale (CardNumber:Word; AdRange:Word; var readingArray:Word; var voltageArray:Double; count:Longint):Smallint;stdcall;
function D2K_AI_ContStatus (CardNumber:Word; var Status:Word):Smallint;stdcall;
function D2K_AI_AsyncCheck (CardNumber:Word; var Stopped:Byte; var AccessCnt:Cardinal):Smallint;stdcall;
function D2K_AI_AsyncClear (CardNumber:Word; var StartPos:Cardinal; var AccessCnt:Cardinal):Smallint;stdcall;
function D2K_AI_AsyncDblBufferHalfReady (CardNumber:Word; var HalfReady:Byte; var StopFlag:Byte):Smallint;stdcall;
function D2K_AI_AsyncDblBufferMode (CardNumber:Word; Enable:Byte):Smallint;stdcall;
function D2K_AI_AsyncDblBufferToFile (CardNumber:Word):Smallint;stdcall;
function D2K_AI_ContBufferSetup (CardNumber:Word; var Buffer:Word; ReadCount:Cardinal; var BufferId:Word):Smallint;stdcall;
function D2K_AI_ContBufferReset (CardNumber:Word):Smallint;stdcall;
function D2K_AI_MuxScanSetup (CardNumber:Word; NumChans:Word; var Chans:Word; var AdRange_RefGnds:Word):Smallint;stdcall;
function D2K_AI_ReadMuxScan (CardNumber:Word; var Buffer:Word):Smallint;stdcall;
function D2K_AI_ContMuxScan (CardNumber:Word; BufId:Word; ReadScans:Cardinal; ScanIntrv:Cardinal; SampIntrv:Cardinal; SyncMode:Word):Smallint;stdcall;
function D2K_AI_ContMuxScanToFile (CardNumber:Word; BufId:Word; var FileName:Byte; ReadScans:Cardinal; ScanIntrv:Cardinal; SampIntrv:Cardinal; SyncMode:Word):Smallint;stdcall;
function D2K_AI_EventCallBack (CardNumber:Word; mode:Smallint; EventType:Smallint; callbackAddr:Cardinal):Smallint;stdcall;
function D2K_AI_AsyncReTrigNextReady (CardNumber:Word; var trgReady:Byte; var StopFlag:Byte; var RdyTrigCnt:Word):Smallint;stdcall;
function D2K_AI_AsyncDblBufferHandled (CardNumber:Word):Smallint;stdcall;
function D2K_AI_AsyncDblBufferOverrun (CardNumber:Word; op:Word; var overrunFlag:Word):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function D2K_AO_Config (CardNumber:Word; ConfigCtrl:Word; TrigCtrl:Word; ReTrgCnt:Word; DLY1Cnt:Word; DLY2Cnt:Word; AutoResetBuf:Byte):Smallint;stdcall;
function D2K_AO_PostTrig_Config (CardNumber:Word; ClkSrc:Word; TrigSrcCtrl:Word; DLY2Ctrl:Word; DLY2Cnt:Word; ReTrgEn:Word; ReTrgCnt:Word; AutoResetBuf:Byte):Smallint;stdcall;
function D2K_AO_DelayTrig_Config (CardNumber:Word; ClkSrc:Word; TrigSrcCtrl:Word; DLY1Cnt:Word; DLY2Ctrl:Word; DLY2Cnt:Word; ReTrgEn:Word; ReTrgCnt:Word; AutoResetBuf:Byte):Smallint;stdcall;
function D2K_AO_CH_Config (CardNumber:Word; Channel:Word; OutputPolarity:Word; IntOrExtRef:Word; refVoltage:Double):Smallint;stdcall;
function D2K_AO_InitialMemoryAllocated (CardNumber:Word; var MemSize:Cardinal):Smallint;stdcall;
function D2K_AO_WriteChannel (CardNumber:Word; Channel:Word; Value:Word):Smallint;stdcall;
function D2K_AO_VWriteChannel (CardNumber:Word; Channel:Word; Voltage:Double):Smallint;stdcall;
function D2K_AO_SimuWriteChannel (CardNumber:Word;  NumChans:Word; var Buffer:Word):Smallint;stdcall;
function D2K_AO_VoltScale (CardNumber:Word; Channel:Word; Voltage:Double; var binValue:Smallint):Smallint;stdcall;
function D2K_AO_ContWriteChannel (CardNumber:Word; Channel:Word; BufId:Word; UpdateCount:Cardinal; Iterations:Cardinal;
               CHUI:Cardinal; definite: Word; SyncMode:Word):Smallint;stdcall;
function D2K_AO_ContWriteMultiChannels (CardNumber:Word; NumChans:Word; var Chans:Word; BufId:Word; UpdateCount:Cardinal; Iterations:Cardinal;
               CHUI:Cardinal; definite: Word; SyncMode:Word):Smallint;stdcall;
function D2K_AO_ContStatus (CardNumber:Word; var Status:Word):Smallint;stdcall;
function D2K_AO_AsyncCheck (CardNumber:Word; var Stopped:Byte; var WriteCount:Cardinal):Smallint;stdcall;
function D2K_AO_AsyncClear (CardNumber:Word; var WriteCount:Cardinal; StopMode:Word):Smallint;stdcall;
function D2K_AO_AsyncDblBufferHalfReady (CardNumber:Word; var HalfReady:Byte):Smallint;stdcall;
function D2K_AO_AsyncDblBufferMode (CardNumber:Word; Enable:Byte):Smallint;stdcall;
function D2K_AO_AsyncDBHalfReady (CardNumber:Word; var HalfReady:Byte; var BufferId:Word):Smallint;stdcall;
function D2K_AO_ContBufferSetup (CardNumber:Word; var Buffer:Word; WriteCount:Cardinal; var BufferId:Word):Smallint;stdcall;
function D2K_AO_ContBufferReset (CardNumber:Word):Smallint;stdcall;
function D2K_AO_ContBufferComposeAll (CardNumber:Word; var Buffer:Word; WriteCount:Cardinal; var BufferId:Word):Smallint;stdcall;
function D2K_AO_ContBufferCompose (CardNumber:Word):Smallint;stdcall;
function D2K_AO_EventCallBack (CardNumber:Word; mode:Smallint; EventType:Smallint; callbackAddr:Cardinal):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function D2K_AO_Group_Setup (CardNumber:Word; group:Word; NumChans:Word; var Chans:Word):Smallint;stdcall;
function D2K_AO_Group_Update (CardNumber:Word; group:Word; var Buffer:Smallint):Smallint;stdcall;
function D2K_AO_Group_VUpdate (CardNumber:Word; group:Word; var Voltage:Double):Smallint;stdcall;
function D2K_AO_Group_FIFOLoad (CardNumber:Word;  group:Word; BufId:Word; WriteCount:Cardinal):Smallint;stdcall;
function D2K_AO_Group_WFM_StopConfig (CardNumber:Word; group:Word; stopSrc:Word; stopMode:Word):Smallint;stdcall;
function D2K_AO_Group_WFM_Start (CardNumber:Word; group:Word; fstBufIdOrNotUsed:Word; sndBufId:Word; UpdateCount:Cardinal; Iterations:Cardinal;
               CHUI:Cardinal; definite: Word):Smallint;stdcall;
function D2K_AO_Group_WFM_AsyncCheck (CardNumber:Word; group:Word; var Stopped:Byte; var WriteCount:Cardinal):Smallint;stdcall;
function D2K_AO_Group_WFM_AsyncClear (CardNumber:Word; group:Word; var WriteCount:Cardinal; StopMode:Word):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function D2K_DI_ReadLine (CardNumber:Word; Port:Word; Line:Word; var State:Word):Smallint;stdcall;
function D2K_DI_ReadPort (CardNumber:Word; Port:Word; var Value:Cardinal):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function D2K_DO_WriteLine (CardNumber:Word; Port:Word; Line:Word; Value:Word):Smallint;stdcall;
function D2K_DO_WritePort (CardNumber:Word; Port:Word; Value:Cardinal):Smallint;stdcall;
function D2K_DO_ReadLine (CardNumber:Word; Port:Word; Line:Word; var Value:Word):Smallint;stdcall;
function D2K_DO_ReadPort (CardNumber:Word; Port:Word; var Value:Cardinal):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function D2K_DIO_PortConfig (CardNumber:Word; Port:Word; Direction:Word):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function D2K_GCTR_Setup (CardNumber:Word; GCtr:Word; Mode:Word; SrcCtrl:Byte; PolCtrl:Byte; LReg1_Val:Word; LReg2_Val:Word):Smallint;stdcall;
function D2K_GCTR_Reset (CardNumber:Word; GCtr:Word):Smallint;stdcall;
function D2K_GCTR_Read (CardNumber:Word; GCtr:Word; var Value:Cardinal):Smallint;stdcall;
function D2K_GCTR_Status (CardNumber:Word; GCtr:Word; var Value:Word):Smallint;stdcall;
function D2K_GCTR_Control (CardNumber:Word; GCtr:Word; ParamID:Word; Value:Word):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function D2K_SSI_SourceConn (CardNumber:Word; sigCode:Word):Smallint;stdcall;
function D2K_SSI_SourceDisConn (CardNumber:Word; sigCode:Word):Smallint;stdcall;
function D2K_SSI_SourceClear (CardNumber:Word):Smallint;stdcall;
(*---------------------------------------------------------------------------*)
function DAQ2204_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var da0v_err:Single; var da5v_err:Single):Smallint;stdcall;
function DAQ2204_Acquire_AD_Error(CardNumber:Word; var gain_err:Single; var bioffset_err:Single; var unioffset_err:Single; var hg_bios_err:Single):Smallint;stdcall;
function DAQ2205_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var da0v_err:Single; var da5v_err:Single):Smallint;stdcall;
function DAQ2205_Acquire_AD_Error(CardNumber:Word; var gain_err:Single; var bioffset_err:Single; var unioffset_err:Single; var hg_bios_err:Single):Smallint;stdcall;
function DAQ2206_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var da0v_err:Single; var da5v_err:Single):Smallint;stdcall;
function DAQ2206_Acquire_AD_Error(CardNumber:Word; var gain_err:Single; var bioffset_err:Single; var unioffset_err:Single; var hg_bios_err:Single):Smallint;stdcall;
function DAQ2208_Acquire_AD_Error(CardNumber:Word; var gain_err:Single; var bioffset_err:Single; var unioffset_err:Single; var hg_bios_err:Single):Smallint;stdcall;
function DAQ2214_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var da0v_err:Single; var da5v_err:Single):Smallint;stdcall;
function DAQ2214_Acquire_AD_Error(CardNumber:Word; var gain_err:Single; var bioffset_err:Single; var unioffset_err:Single; var hg_bios_err:Single):Smallint;stdcall;
function DAQ2213_Acquire_AD_Error(CardNumber:Word; var gain_err:Single; var bioffset_err:Single; var unioffset_err:Single; var hg_bios_err:Single):Smallint;stdcall;
function DAQ2010_Acquire_AD_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ2010_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ2005_Acquire_AD_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ2005_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ2006_Acquire_AD_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ2006_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ2016_Acquire_AD_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ2016_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ250X_Acquire_AD_Error(CardNumber:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function DAQ250X_Acquire_DA_Error(CardNumber:Word; channel:Word; polarity:Word; var gain_err:Single; var offset_err:Single):Smallint;stdcall;
function D2K_DB_Auto_Calibration_ALL(CardNumber:Word):Smallint;stdcall;
function D2K_EEPROM_CAL_Constant_Update(CardNumber:Word; bank:Word):Smallint;stdcall;
function D2K_Load_CAL_Data(CardNumber:Word; bank:Word):Smallint;stdcall;

implementation

function D2K_Register_Card; external 'D2K-Dask.dll';
function D2K_Release_Card; external 'D2K-Dask.dll';
function D2K_AIO_Config; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function D2K_AI_Config; external 'D2K-Dask.dll';
function D2K_AI_PostTrig_Config; external 'D2K-Dask.dll';
function D2K_AI_DelayTrig_Config; external 'D2K-Dask.dll';
function D2K_AI_PreTrig_Config; external 'D2K-Dask.dll';
function D2K_AI_MiddleTrig_Config; external 'D2K-Dask.dll';
function D2K_AI_CH_Config; external 'D2K-Dask.dll';
function D2K_AI_InitialMemoryAllocated; external 'D2K-Dask.dll';
function D2K_AI_ReadChannel; external 'D2K-Dask.dll';
function D2K_AI_VReadChannel; external 'D2K-Dask.dll';
function D2K_AI_SimuReadChannel; external 'D2K-Dask.dll';
function D2K_AI_VoltScale; external 'D2K-Dask.dll';
function D2K_AI_ContReadChannel; external 'D2K-Dask.dll';
function D2K_AI_ContReadMultiChannels; external 'D2K-Dask.dll';
function D2K_AI_ContScanChannels; external 'D2K-Dask.dll';
function D2K_AI_ContReadChannelToFile; external 'D2K-Dask.dll';
function D2K_AI_ContReadMultiChannelsToFile; external 'D2K-Dask.dll';
function D2K_AI_ContScanChannelsToFile; external 'D2K-Dask.dll';
function D2K_AI_ContVScale; external 'D2K-Dask.dll';
function D2K_AI_ContStatus; external 'D2K-Dask.dll';
function D2K_AI_AsyncCheck; external 'D2K-Dask.dll';
function D2K_AI_AsyncClear; external 'D2K-Dask.dll';
function D2K_AI_AsyncDblBufferHalfReady; external 'D2K-Dask.dll';
function D2K_AI_AsyncDblBufferMode; external 'D2K-Dask.dll';
function D2K_AI_AsyncDblBufferToFile; external 'D2K-Dask.dll';
function D2K_AI_ContBufferSetup; external 'D2K-Dask.dll';
function D2K_AI_ContBufferReset; external 'D2K-Dask.dll';
function D2K_AI_MuxScanSetup; external 'D2K-Dask.dll';
function D2K_AI_ReadMuxScan; external 'D2K-Dask.dll';
function D2K_AI_ContMuxScan; external 'D2K-Dask.dll';
function D2K_AI_ContMuxScanToFile; external 'D2K-Dask.dll';
function D2K_AI_EventCallBack; external 'D2K-Dask.dll';
function D2K_AI_AsyncReTrigNextReady; external 'D2K-Dask.dll';
function D2K_AI_AsyncDblBufferHandled; external 'D2K-Dask.dll';
function D2K_AI_AsyncDblBufferOverrun; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function D2K_AO_Config; external 'D2K-Dask.dll';
function D2K_AO_PostTrig_Config; external 'D2K-Dask.dll';
function D2K_AO_DelayTrig_Config; external 'D2K-Dask.dll';
function D2K_AO_CH_Config; external 'D2K-Dask.dll';
function D2K_AO_InitialMemoryAllocated; external 'D2K-Dask.dll';
function D2K_AO_WriteChannel; external 'D2K-Dask.dll';
function D2K_AO_VWriteChannel; external 'D2K-Dask.dll';
function D2K_AO_SimuWriteChannel; external 'D2K-Dask.dll';
function D2K_AI_ScanReadChannels; external 'D2K-Dask.dll';
function D2K_AO_VoltScale; external 'D2K-Dask.dll';
function D2K_AO_ContWriteChannel; external 'D2K-Dask.dll';
function D2K_AO_ContWriteMultiChannels; external 'D2K-Dask.dll';
function D2K_AO_ContStatus; external 'D2K-Dask.dll';
function D2K_AO_AsyncCheck; external 'D2K-Dask.dll';
function D2K_AO_AsyncClear; external 'D2K-Dask.dll';
function D2K_AO_AsyncDblBufferHalfReady; external 'D2K-Dask.dll';
function D2K_AO_AsyncDblBufferMode; external 'D2K-Dask.dll';
function D2K_AO_AsyncDBHalfReady; external 'D2K-Dask.dll';
function D2K_AO_ContBufferSetup; external 'D2K-Dask.dll';
function D2K_AO_ContBufferReset; external 'D2K-Dask.dll';
function D2K_AO_ContBufferComposeAll; external 'D2K-Dask.dll';
function D2K_AO_ContBufferCompose; external 'D2K-Dask.dll';
function D2K_AO_EventCallBack; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function D2K_AO_Group_Setup; external 'D2K-Dask.dll';
function D2K_AO_Group_Update; external 'D2K-Dask.dll';
function D2K_AO_Group_VUpdate; external 'D2K-Dask.dll';
function D2K_AO_Group_FIFOLoad; external 'D2K-Dask.dll';
function D2K_AO_Group_WFM_StopConfig; external 'D2K-Dask.dll';
function D2K_AO_Group_WFM_Start; external 'D2K-Dask.dll';
function D2K_AO_Group_WFM_AsyncCheck; external 'D2K-Dask.dll';
function D2K_AO_Group_WFM_AsyncClear; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function D2K_DI_ReadLine; external 'D2K-Dask.dll';
function D2K_DI_ReadPort; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function D2K_DO_WriteLine; external 'D2K-Dask.dll';
function D2K_DO_WritePort; external 'D2K-Dask.dll';
function D2K_DO_ReadLine; external 'D2K-Dask.dll';
function D2K_DO_ReadPort; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function D2K_DIO_PortConfig; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function D2K_GCTR_Setup; external 'D2K-Dask.dll';
function D2K_GCTR_Reset; external 'D2K-Dask.dll';
function D2K_GCTR_Read; external 'D2K-Dask.dll';
function D2K_GCTR_Status; external 'D2K-Dask.dll';
function D2K_GCTR_Control; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function D2K_SSI_SourceConn; external 'D2K-Dask.dll';
function D2K_SSI_SourceDisConn; external 'D2K-Dask.dll';
function D2K_SSI_SourceClear; external 'D2K-Dask.dll';
(*---------------------------------------------------------------------------*)
function DAQ2204_Acquire_DA_Error; external 'D2K-Dask.dll';
function DAQ2204_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2205_Acquire_DA_Error; external 'D2K-Dask.dll';
function DAQ2205_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2206_Acquire_DA_Error; external 'D2K-Dask.dll';
function DAQ2206_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2208_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2214_Acquire_DA_Error; external 'D2K-Dask.dll';
function DAQ2214_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2213_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2010_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2010_Acquire_DA_Error; external 'D2K-Dask.dll';
function DAQ2005_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2005_Acquire_DA_Error; external 'D2K-Dask.dll';
function DAQ2006_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2006_Acquire_DA_Error; external 'D2K-Dask.dll';
function DAQ2016_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ2016_Acquire_DA_Error; external 'D2K-Dask.dll';
function DAQ250X_Acquire_AD_Error; external 'D2K-Dask.dll';
function DAQ250X_Acquire_DA_Error; external 'D2K-Dask.dll';
function D2K_DB_Auto_Calibration_ALL; external 'D2K-Dask.dll';
function D2K_EEPROM_CAL_Constant_Update; external 'D2K-Dask.dll';
function D2K_Load_CAL_Data; external 'D2K-Dask.dll';

end.
