#ifndef _USBDASK_H
#define _USBDASK_H

#ifdef __cplusplus
extern "C" {
#endif

    #include <Windows.h>

    /*
     * DASK Data Types
     */
    typedef unsigned char  U8;
    typedef short          I16;
    typedef unsigned short U16;
    typedef long           I32;
    typedef unsigned long  U32;
    typedef float          F32;
    typedef double         F64;

    typedef LONGLONG       I64;


    /*
     * ADLink USBDAQ Module Type
     */

    typedef enum _USBDAQ_TYPE_ {
        USB_1902 = 1,
        USB_1903,  // USB_1902A
        USB_1901,  // USB_1902L
        USB_2401,
        USB_7250,
        USB_7230,
        USB_2405,
        USB_1210,        
        NUM_USBDAQ_TYPE     
//        NUM_MODULE_TYPE =  USB_2405 + 1,
//    2012Dec16, Jeff remove NUM_MODULE_TYPE enumeration
    } USBDAQ_TYPE;

    typedef struct _USBDAQ_INFO {
        USHORT      wModuleType;                      // Card Type: USB_19020 (1)
        USHORT      wCardID;                          // Card ID configured with onboard DIP-Switch
    } USBDAQ_DEVICE, *PUSBDAQ_DEVICE;

    typedef struct _CAL_INFO_1902 {
        union {
            struct {
                ULONG AI_Offset[2]; // Offset Calibration for AI GAIN[1,5,10,50]
                ULONG AI_Gain[2]; // Gain Calibration for AI GAIN[1,5,10,50]
                ULONG AO_Offset; // Offset Calibration for AO0 and AO1
                ULONG AO_Gain;  // Gain Calibration for AO0 and AO1
            } CalInfo;
            UCHAR bValue[24];
        } CalInfo_1902;
    }
    CAL_INFO_1902;

    typedef struct _CAL_INFO_1903 {
        union {
            struct {
                ULONG AI_Offset[4]; // Offset Calibration for AI0~AI7 GAIN[10]
                ULONG AI_Gain[4]; // Gain Calibration for AI0~AI7 GAIN[10]
            } CalInfo;
            UCHAR bValue[32];
        } CalInfo_1903;
    }
    CAL_INFO_1903;
    
    typedef struct _CAL_CHAN_INFO_2401 {
        union {
            struct {
                ULONG Vol_Offset[4]; // Offset Calibration for AI [25V, 12.5V, 2.5V, 3.125mV]
                ULONG Vol_Gain[4];   // Gain Calibration for AI [25V, 12.5V, 2.5V, 3.125mV]
                ULONG Cur_Offset;    // Offset Calibration for Current [20mA]
                ULONG Cur_Gain;      // Gain Calibration for Current [20mA]
                ULONG RTD_Offset[4];    // Offset Calibration for RTD 4/3/2-wire [1mA] and Resistor [100uA]
                ULONG RTD_Gain[4];      // Gain Calibration for RTD 4/3/2-wire [1mA] and  Resistor [100uA]
                ULONG TC_Offset;    // Offset Calibration for ThermoCouple [1mA]
                ULONG TC_Gain;      // Gain Calibration for ThermoCouple [1mA]
                ULONG LC_Offset;    // Offset Calibration for LoadCellCouple [1mA]
                ULONG LC_Gain;      // Gain Calibration for LoadCellCouple [1mA]
                ULONG Reserved_Offset;  // Reserved for future use
                ULONG Reserved_Gain;  // Reserved for future use
            } ChanCalInfo;
            UCHAR bValue[96];
        } ChanCalInfo_2401;

    } CAL_CHAN_INFO_2401;

    typedef struct {
        union {
            struct {
                ULONG LC_Offset_350Ohm_full;    // Offset Calibration for LoadCellCouple [1mA]
                ULONG LC_Gain_350Ohm_full;      // Gain Calibration for LoadCellCouple [1mA]
                ULONG LC_Offset_350Ohm_half;    // Offset Calibration for LoadCellCouple [1mA]
                ULONG LC_Gain_350Ohm_half;      // Gain Calibration for LoadCellCouple [1mA]
                ULONG LC_Offset_120Ohm_full;    // Offset Calibration for LoadCellCouple [1mA]
                ULONG LC_Gain_120Ohm_full;      // Gain Calibration for LoadCellCouple [1mA]
                ULONG LC_Offset_120Ohm_half;    // Offset Calibration for LoadCellCouple [1mA]
                ULONG LC_Gain_120Ohm_half;      // Gain Calibration for LoadCellCouple [1mA]
                //ULONG Checksum;  // Reserved for future use
            } ChanCalInfo_LC;
            UCHAR bValue[32];
        } ChanCalInfo_2401_LC;

    } CAL_CHAN_INFO_2401_LC;

    typedef struct _QC_INFO_1902 {
        union {
            struct {
                double RefVoltage[4]; // Actual Voltage of onboard Reference-Voltage
                USHORT Trimmer; // Only Low-byet is required
                USHORT Reserved[3];  // reserved WORD
            } QCInfo;
            UCHAR bValue[40];
        } QCInfo_1902;
    }
    QC_INFO_1902;

    typedef struct _VOLT_INFO_2405 {
        union {
            struct {
                double RefVoltage[2]; // Actual Voltage of onboard Reference-Voltage                
            } VoltInfo;
            UCHAR bValue[16];
        } VoltInfo_2405;
    }
    VOLT_INFO_2405;

    typedef struct _CAL_INFO_2405 {
        union {
            struct {
                ULONG AI_Offset[4]; // Offset Calibration for 4 AI (128K Samples/s)
                ULONG AI_Gain[4]; // Gain Calibration for 4 AI (128K Samples/s)                
            } CalInfo;
            UCHAR bValue[32];
        } CalInfo_2405;
    }
    CAL_INFO_2405;


    typedef struct _VOLT_INFO_1210 {
        union {
            struct {
                double RefVoltage[3]; // Actual Voltage of onboard Reference-Voltage                
            } VoltInfo;
            UCHAR bValue[24];
        } VoltInfo_1210;
    }
    VOLT_INFO_1210;  

    typedef struct _CAL_INFO_1210 {
        union {
            struct {
                ULONG AI_Offset[4]; // Offset Calibration settings for กำ9V or กำ1.5V
                ULONG AI_Gain[4];   // Gain Calibration settings for กำ9V or กำ1.5V              
            } CalInfo;
            UCHAR bValue[32];
        } CalInfo_1210;
    }
    CAL_INFO_1210;

// 2013July16, Jeff extends the MAX_USB_DEVICE definition
#define MAX_USB_DEVICE       8
//#define MAX_USB_DEVICE       32

    /*
     * Error Number
     */
#define NoError                        0
#define ErrorUnknownCardType          -1
#define ErrorInvalidCardNumber        -2
#define ErrorTooManyCardRegistered    -3
#define ErrorCardNotRegistered        -4
#define ErrorFuncNotSupport           -5
#define ErrorInvalidIoChannel         -6
#define ErrorInvalidAdRange           -7
#define ErrorContIoNotAllowed         -8
#define ErrorDiffRangeNotSupport      -9
#define ErrorLastChannelNotZero       -10
#define ErrorChannelNotDescending     -11
#define ErrorChannelNotAscending      -12
#define ErrorOpenDriverFailed         -13
#define ErrorOpenEventFailed          -14
#define ErrorTransferCountTooLarge    -15
#define ErrorNotDoubleBufferMode      -16
#define ErrorInvalidSampleRate        -17
#define ErrorInvalidCounterMode       -18
#define ErrorInvalidCounter           -19
#define ErrorInvalidCounterState      -20
#define ErrorInvalidBinBcdParam       -21
#define ErrorBadCardType              -22
#define ErrorInvalidDaRefVoltage      -23
#define ErrorAdTimeOut                -24
#define ErrorNoAsyncAI                -25
#define ErrorNoAsyncAO                -26
#define ErrorNoAsyncDI                -27
#define ErrorNoAsyncDO                -28
#define ErrorNotInputPort             -29
#define ErrorNotOutputPort            -30
#define ErrorInvalidDioPort           -31
#define ErrorInvalidDioLine           -32
#define ErrorContIoActive             -33
#define ErrorDblBufModeNotAllowed     -34
#define ErrorConfigFailed             -35
#define ErrorInvalidPortDirection     -36
#define ErrorBeginThreadError         -37
#define ErrorInvalidPortWidth         -38
#define ErrorInvalidCtrSource         -39
#define ErrorOpenFile                 -40
#define ErrorAllocateMemory           -41
#define ErrorDaVoltageOutOfRange      -42
#define ErrorDaExtRefNotAllowed       -43
#define ErrorDIODataWidthError        -44
#define ErrorTaskCodeError            -45
#define ErrorTriggercountError        -46
#define ErrorInvalidTriggerMode       -47
#define ErrorInvalidTriggerType       -48
#define ErrorInvalidCounterValue      -50
#define ErrorInvalidEventHandle       -60
#define ErrorNoMessageAvailable       -61
#define ErrorEventMessgaeNotAdded     -62
#define ErrorCalibrationTimeOut       -63
#define ErrorUndefinedParameter       -64
#define ErrorInvalidBufferID          -65
#define ErrorInvalidSampledClock      -66
#define ErrorInvalidOperationMode     -67

    /*Error number for driver API*/
#define ErrorConfigIoctl              -201
#define ErrorAsyncSetIoctl            -202
#define ErrorDBSetIoctl               -203
#define ErrorDBHalfReadyIoctl         -204
#define ErrorContOPIoctl              -205
#define ErrorContStatusIoctl          -206
#define ErrorPIOIoctl                 -207
#define ErrorDIntSetIoctl             -208
#define ErrorWaitEvtIoctl             -209
#define ErrorOpenEvtIoctl             -210
#define ErrorCOSIntSetIoctl           -211
#define ErrorMemMapIoctl              -212
#define ErrorMemUMapSetIoctl          -213
#define ErrorCTRIoctl                 -214
#define ErrorGetResIoctl              -215
#define ErrorCalIoctl                 -216
#define ErrorPMIntSetIoctl            -217

    // Jeff added
#define ErrorAccessViolationDataCopy  -301
#define ErrorNoModuleFound            -302
#define ErrorCardIDDuplicated         -303
#define ErrorCardDisconnected         -304
#define ErrorInvalidScannedIndex      -305
#define ErrorUndefinedException       -306
#define ErrorInvalidDioConfig         -307
#define ErrorInvalidAOCfgCtrl         -308
#define ErrorInvalidAOTrigCtrl        -309
#define ErrorConflictWithSyncMode     -310
#define ErrorConflictWithFifoMode     -311
#define ErrorInvalidAOIteration       -312
#define ErrorZeroChannelNumber        -313
#define ErrorSystemCallFailed         -314
#define ErrorTimeoutFromSyncMode      -315
#define ErrorInvalidPulseCount        -316
#define ErrorInvalidDelayCount        -317
#define ErrorConflictWithDelay2       -318
#define ErrorAOFifoCountTooLarge      -319
#define ErrorConflictWithWaveRepeat   -320
#define ErrorConflictWithReTrig       -321
#define ErrorInvalidTriggerChannel    -322
#define ErrorInvalidInputSignal       -323
#define ErrorInvalidConversionSrc     -324
#define ErrorInvalidRefVoltage        -325
#define ErrorCalibrateFailed          -326
#define ErrorInvalidCalData           -327
#define ErrorChanGainQueueTooLarge    -328
#define ErrorInvalidCardType          -329
#define ErrorInvalidSyncMode          -330
#define ErrorIICVersion               -331
#define ErrorFX2UpgradeFailed         -332
#define ErrorInvalidReadCount         -333

#define ErrorInvalidChannel           -397
#define ErrorNullPoint                -398
#define ErrorInvalidParamSetting      -399

    // -401 ~ -499 the Kernel error
#define ErrorAIStartFailed            -401
#define ErrorAOStartFailed            -402
#define ErrorConflictWithGPIOConfig   -403
#define ErrorEepromReadback           -404
#define ErrorConflictWithInfiniteOp   -405
#define ErrorWaitingUSBHostResponse   -406
#define ErrorAOFifoModeTimeout        -407
#define ErrorInvalidModuleFunction    -408
#define ErrorAdFifoFull               -409
#define ErrorInvalidTransferCount     -410
#define ErrorConflictWithAIConfig     -411
#define ErrorDDSConfigFailed          -412
#define ErrorFpgaAccessFailed         -413
#define ErrorPLDBusy                  -414
#define ErrorPLDTimeout               -415


#define ErrorUndefinedKernelError     -420



    // the functions supported in the future
#define ErrorSyncModeNotSupport       -501

    /*
     * AD Range
     */
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
#define AD_B_40_V     32 // PCI-9527 AI
#define AD_B_3_16_V   33 // PCI-9527 AI
#define AD_B_0_316_V  34 // PCI-9527 AI
#define AD_B_25_V     35 // Jeff added for USB-2401 AI
#define AD_B_12_5_V   36



    /*------------------*/
    /* Common Constants */
    /*------------------*/
    /* T or F*/
#define TRUE  1
#define FALSE 0

    /*Synchronous Mode*/
#define SYNCH_OP  1
#define ASYNCH_OP 2


// Input Type
#define UD_AI_NonRef_SingEnded      0x01
#define UD_AI_SingEnded             0x02
#define UD_AI_Differential          0x04
#define UD_AI_PseudoDifferential	0x08

// Input Coupling
#define UD_AI_EnableIEPE         	0x10
#define UD_AI_DisableIEPE         	0x20
#define UD_AI_Coupling_AC        	0x40
#define UD_AI_Coupling_None       	0x80



// Conversion Source
#define UD_AI_CONVSRC_INT        0x01
#define UD_AI_CONVSRC_EXT        0x02


// wTrigCtrl in UD_AI_Trigger_Config()

// Trigger Source (bit9:0)
#define UD_AI_TRGSRC_AI0         0x0200
#define UD_AI_TRGSRC_AI1         0x0201
#define UD_AI_TRGSRC_AI2         0x0202
#define UD_AI_TRGSRC_AI3         0x0203
#define UD_AI_TRGSRC_AI4         0x0204
#define UD_AI_TRGSRC_AI5         0x0205
#define UD_AI_TRGSRC_AI6         0x0206
#define UD_AI_TRGSRC_AI7         0x0207
#define UD_AI_TRGSRC_AI8         0x0208
#define UD_AI_TRGSRC_AI9         0x0209
#define UD_AI_TRGSRC_AI10        0x020A
#define UD_AI_TRGSRC_AI11        0x020B
#define UD_AI_TRGSRC_AI12        0x020C
#define UD_AI_TRGSRC_AI13        0x020D
#define UD_AI_TRGSRC_AI14        0x020E
#define UD_AI_TRGSRC_AI15        0x020F
#define UD_AI_TRGSRC_SOFT        0x0380
#define UD_AI_TRGSRC_DTRIG       0x0388


// Trigger Edge (bit14)
#define UD_AI_TrigPositive         0x4000
#define UD_AI_TrigNegative         0x0000

// Trigger Edge (bit14)
#define UD_AI_Gate_ActiveHigh      0x4000
#define UD_AI_Gate_ActiveLow       0x0000

// ReTrigger (bit13)
#define UD_AI_EnReTrigger          0x2000 // 0x02000000
#define UD_AI_DisReTrigger         0x0000 // 0x00000000

// AI Trigger Mode
#define UD_AI_TRGMOD_POST          0x0000 // 0x00000000
#define UD_AI_TRGMOD_DELAY         0x4000 // 0x40000000
#define UD_AI_TRGMOD_PRE           0x8000 // 0x80000000
#define UD_AI_TRGMOD_MIDDLE        0xC000 // 0xC0000000
#define UD_AI_TRGMOD_GATED         0x1000 // 0x10000000

// DIO_Config
#define UD_DIO_DIGITAL_INPUT          0x30
#define UD_DIO_COUNTER_INPUT          0x31
#define UD_DIO_DIGITAL_OUTPUT         0x32
#define UD_DIO_PULSE_OUTPUT           0x33
    /*------------------------*/
    /* Constants for USB-1902 */
    /*------------------------*/

    // wConfigCtrl in UD_AI_1902_Config()
    /*Input Type*/ // bit 7:6 in AI_CONFG
    // 2011April29, Jeff changed
#define P1902_AI_NonRef_SingEnded   0x00
#define P1902_AI_SingEnded          0x01
#define P1902_AI_Differential       0x02

    /*Conversion Source*/ // bit 9 in AI_ACQMCR
#define P1902_AI_CONVSRC_INT        0x00
#define P1902_AI_CONVSRC_EXT        0x80


    // wTrigCtrl in UD_AI_1902_Config()
    /*Trigger Source*/ // bit 8:3 in AI_ACQMCR
#define P1902_AI_TRGSRC_AI0         0x020
#define P1902_AI_TRGSRC_AI1         0x021
#define P1902_AI_TRGSRC_AI2         0x022
#define P1902_AI_TRGSRC_AI3         0x023
#define P1902_AI_TRGSRC_AI4         0x024
#define P1902_AI_TRGSRC_AI5         0x025
#define P1902_AI_TRGSRC_AI6         0x026
#define P1902_AI_TRGSRC_AI7         0x027
#define P1902_AI_TRGSRC_AI8         0x028
#define P1902_AI_TRGSRC_AI9         0x029
#define P1902_AI_TRGSRC_AI10        0x02A
#define P1902_AI_TRGSRC_AI11        0x02B
#define P1902_AI_TRGSRC_AI12        0x02C
#define P1902_AI_TRGSRC_AI13        0x02D
#define P1902_AI_TRGSRC_AI14        0x02E
#define P1902_AI_TRGSRC_AI15        0x02F
#define P1902_AI_TRGSRC_SOFT        0x030
#define P1902_AI_TRGSRC_DTRIG       0x031


    /*Trigger Edge*/ // bit 2 in AI_ACQMCR
#define P1902_AI_TrgPositive        0x000
#define P1902_AI_TrgNegative        0x040

    /*Gated Trigger Level*/  // bit 2 in AI_ACQMCR
#define P1902_AI_Gate_ActiveHigh        0x000
#define P1902_AI_Gate_ActiveLow         0x040

    /*Trigger Mode*/
#define P1902_AI_TRGMOD_POST        0x000
#define P1902_AI_TRGMOD_GATED       0x080
#define P1902_AI_TRGMOD_DELAY       0x100

    /*ReTrigger*/ // bit 25 in AI_ACQMCR
#define P1902_AI_EnReTigger         0x200

    /**/

    /*
     * AO Constants
     */

    /*Conversion Source*/
#define P1902_AO_CONVSRC_INT        0x00

#define P1902_AO_TRIG_CTRL_MASK      (~0x00000711)
    /*Trigger Mode*/
#define P1902_AO_TRGMOD_POST        0x00
#define P1902_AO_TRGMOD_DELAY       0x01

    /*Trigger Source*/ // bit 24 in AO_TCFIGR
#define P1902_AO_TRGSRC_SOFT        0x00
#define P1902_AO_TRGSRC_DTRIG       0x10

    /*Trigger Edge*/ // bit 25 in AI_ACQMCR
#define P1902_AO_TrgPositive        0x100
#define P1902_AO_TrgNegative        0x000

    /*Enable Re-Trigger*/ // bit 10 in AO_TCFIGR
#define P1902_AO_EnReTigger         0x200
    /* Flag for AO Waveform Seperation Interval COunt Register (AO_WSIC) */
#define P1902_AO_EnDelay2           0x400


    /*------------------------*/
    /* Constants for USB-2401 */
    /*------------------------*/

    // wConfigCtrl in UD_AI_2401_Config()
    /*Input Type*/ // V >=2.5V, V<2.5, Current, RTD (4 wire), RTD (3-wire), RTD (2-wire), Resistor, Thermocouple, Full-Bridge, Half-Bridge
#define P2401_Voltage_2D5V_Above      0x00
#define P2401_Voltage_2D5V_Below      0x01
#define P2401_Current                 0x02
#define P2401_RTD_4_Wire              0x03
#define P2401_RTD_3_Wire              0x04
#define P2401_RTD_2_Wire              0x05
#define P2401_Resistor                0x06
#define P2401_ThermoCouple            0x07
#define P2401_Full_Bridge             0x08
#define P2401_Half_Bridge             0x09
#define P2401_ThermoCouple_Gnd        0x0A
#define P2401_350Ohm_Full_Bridge      0x0B
#define P2401_350Ohm_Half_Bridge      0x0C
#define P2401_120Ohm_Full_Bridge      0x0D
#define P2401_120Ohm_Half_Bridge      0x0E

    /*Conversion Source*/ // bit 9 in AI_ACQMCR
#define P2401_AI_CONVSRC_INT        0x00

    // wTrigCtrl in UD_AI_2401_Config()
    /*Trigger Source*/ // bit 8:3 in AI_ACQMCR
#define P2401_AI_TRGSRC_SOFT        0x030
#define P2401_AI_TRGSRC_DTRIG       0x031

    /*Trigger Edge*/ // bit 2 in AI_ACQMCR
#define P2401_AI_TrgPositive        0x040
#define P2401_AI_TrgNegative        0x000

    /*Trigger Mode*/
#define P2401_AI_TRGMOD_POST        0x000


    // wMAvgStageCh1 ~ wMAvgStageCh4 in UD_AI_2401_PollConfig()
#define P2401_Polling_MAvg_Disable    0x00
#define P2401_Polling_MAvg_2_Sampes   0x01
#define P2401_Polling_MAvg_4_Sampes   0x02
#define P2401_Polling_MAvg_8_Sampes   0x03
#define P2401_Polling_MAvg_16_Sampes  0x04

    // wEnContPolling in UD_AI_2401_PollConfig()
#define P2401_Continue_Polling_Disable 0x00
#define P2401_Continue_Polling_Enable  0x01

    // wPollSpeed in UD_AI_2401_PollConfig()
#define P2401_ADC_2000_SPS            0x09
#define P2401_ADC_1000_SPS            0x08
#define P2401_ADC_640_SPS             0x07
#define P2401_ADC_320_SPS             0x06
#define P2401_ADC_160_SPS             0x05
#define P2401_ADC_80_SPS              0x04
#define P2401_ADC_40_SPS              0x03
#define P2401_ADC_20_SPS              0x02


/*
 * DDS Constants
 */
#define P2405_AI_MaxDDSFreq        128000
#define P2405_AI_MinDDSFreq        1000

// #define P2405_AI_POLLING_RATE      20000.0f // (20K = 10240K/512 )

/*
 * AI Constants
 */
/*AI Select Channel*/
#define P2405_AI_CH_0					0
#define P2405_AI_CH_1					1
#define P2405_AI_CH_2					2
#define P2405_AI_CH_3					3

/*Input Coupling*/
#define P2405_AI_EnableIEPE         	0x00000004
#define P2405_AI_DisableIEPE         	0x00000008
#define P2405_AI_Coupling_AC        	0x00000010
#define P2405_AI_Coupling_None       	0x00000020

/*Input Type*/
#define P2405_AI_Differential			  0x00000000
#define P2405_AI_PseudoDifferential		  0x00000040

#define P2405_AI_CONVSRC_INT            0x00000000
#define P2405_AI_CONVSRC_EXT            0x00000200

    // wTrigCtrl in UD_AIO_2405_Config() <TBD>
    /* Mask for Trigger bits, Internal use */    

    /*Trigger Source*/ 
#define P2405_AI_TRGSRC_AI0           0x00000200
#define P2405_AI_TRGSRC_AI1           0x00000208
#define P2405_AI_TRGSRC_AI2           0x00000210
#define P2405_AI_TRGSRC_AI3           0x00000218
#define P2405_AI_TRGSRC_SOFT          0x00000380
#define P2405_AI_TRGSRC_DTRIG         0x00000388 // digital-trigger, 

    /*Trigger Edge*/ 
#define P2405_AI_TrgPositive          0x00000004
#define P2405_AI_TrgNegative          0x00000000

#define P2405_AI_Gate_ActiveHigh      0x00000004
#define P2405_AI_Gate_ActiveLow       0x00000000

    /*ReTrigger*/ // bit 25 in AI_ACQMCR
#define P2405_AI_EnReTigger           0x2000 // 0x02000000

// wTrigMode in UD_AIO_2405_Config()

    /*AI Trigger Mode*/
#define P2405_AI_TRGMOD_POST          0x0000 // 0x00000000
#define P2405_AI_TRGMOD_DELAY         0x4000 // 0x40000000
#define P2405_AI_TRGMOD_PRE           0x8000 // 0x80000000
#define P2405_AI_TRGMOD_MIDDLE        0xC000// 0xC0000000
//#define P2405_AI_TRGMOD_GATED         0x00000001
#define P2405_AI_TRGMOD_GATED         0x1000 // 0x10000000


   
    /*-------------------------------*/
    /* GPIO/GPTC Configuration       */
    /*-------------------------------*/
#define GPIO_IGNORE_CONFIG 0x00

   /*UD_DIO_1902_Config, UD_DIO_2401_Config*/ 
#define GPTC0_GPO1         0x01
#define GPI0_3_GPO0_1      0x02
//#define ENC0_GPO0          0x04
#define GPTC0_TC1          0x08

#define GPTC2_GPO3         0x10
#define GPI4_7_GPO2_3      0x20
//#define ENC1_GPO2          0x40
#define GPTC2_TC3          0x80

    /*GPIO Port*/
#define GPIO_PortA         0
#define GPIO_PortB         1

/*UD_DIO_2405_Config*/ 
#define P2405_DIGITAL_INPUT          0x30
#define P2405_COUNTER_INPUT          0x31
#define P2405_DIGITAL_OUTPUT         0x32
#define P2405_PULSE_OUTPUT           0x33


    /*-------------------------------------------------*/
    /* General Purpose Timer/Counter for USB-1902 */
    /*-------------------------------------------------*/
    /*Counter Mode*/
#define SimpleGatedEventCNT       0x01
#define SinglePeriodMSR           0x02
#define SinglePulseWidthMSR       0x03
#define SingleGatedPulseGen       0x04
#define SingleTrigPulseGen        0x05
#define RetrigSinglePulseGen      0x06
#define SingleTrigContPulseGen    0x07
#define ContGatedPulseGen         0x08
#define EdgeSeparationMSR         0x09
#define SingleTrigContPulseGenPWM 0x0a
#define ContGatedPulseGenPWM      0x0b
#define CW_CCW_Encoder            0x0c
#define x1_AB_Phase_Encoder       0x0d
#define x2_AB_Phase_Encoder       0x0e
#define x4_AB_Phase_Encoder       0x0f
#define Phase_Z                   0x10
#define MultipleGatedPulseGen     0x11
    /*GPTC clock source*/
#define GPTC_CLK_SRC_Ext          0x01
#define GPTC_CLK_SRC_Int          0x00
#define GPTC_GATE_SRC_Ext         0x02
#define GPTC_GATE_SRC_Int         0x00
#define GPTC_UPDOWN_Ext           0x04
#define GPTC_UPDOWN_Int           0x00
    /*GPTC clock polarity*/
#define GPTC_CLKSRC_LACTIVE       0x01
#define GPTC_CLKSRC_HACTIVE       0x00
#define GPTC_GATE_LACTIVE         0x02
#define GPTC_GATE_HACTIVE         0x00
#define GPTC_UPDOWN_LACTIVE       0x04
#define GPTC_UPDOWN_HACTIVE       0x00
#define GPTC_OUTPUT_LACTIVE       0x08
#define GPTC_OUTPUT_HACTIVE       0x00
    /*GPTC OP Parameter*/
#define IntGate                   0x0  /* Internal Gate */
#define IntUpDnCTR                0x1  /* Internal Up/Down Counter */
#define IntENABLE                 0x2  /* Internal Enable */


    /*----------------------------------------------------------*/
    /* Previous renamed functions re-directed for compatibility */
    /*----------------------------------------------------------*/
#define AI_VScale AI_VoltScale
#define AO_VScale UD_AO_VoltScale
#define CTR_Reset CTR_Clear


    /*--------------------------------------*/
    /* DAQ Event type for the event message */
    /*--------------------------------------*/
#define AIEnd     0
#define AOEnd     0
#define DIEnd     0
#define DOEnd     0
#define DBEvent   1
//#define TrigEvent 2


    /*
     * Encoder/GPTC Constants
     */
#define P1902_GPTC0                 0x00
#define P1902_GPTC1                 0x01

    /*Encoder Setting Event Control*/
#define P1902_EPT_PULWIDTH_200us    0x00
#define P1902_EPT_PULWIDTH_2ms      0x01
#define P1902_EPT_PULWIDTH_20ms     0x02
#define P1902_EPT_PULWIDTH_200ms    0x03
#define P1902_EPT_TRGOUT_GPO        0x04
#define P1902_EPT_TRGOUT_CALLBACK   0x08
    /*Event Type*/
#define P1902_EVT_TYPE_EPT0         0x00
#define P1902_EVT_TYPE_EPT1         0x01

    /*---------------------------------*/
    /* Constants for I Squared C (I2C) */
    /*---------------------------------*/
    /*I2C Port*/
#define I2C_Port_A 0
    /*I2C Control Operation*/
#define I2C_ENABLE 0
#define I2C_STOP   1

    /*----------------------------------------------------------------------------*/
    /* USB-DASK Function prototype                                               */
    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    /* Basic Function */
    I16 __stdcall UD_Register_Card ( U16 CardType, U16 card_num );

    I16 __stdcall UD_Release_Card ( U16 CardNumber );

    I16 __stdcall UD_Device_Scan ( U16 *pModuleNum, USBDAQ_DEVICE *pAvailModules );

    /*----------------------------------------------------------------------------*/
    /* AI Function */
    I16 __stdcall UD_AI_1902_Config ( U16 CardNumber, U16 wConfigCtrl, U16 wTrigCtrl, \
                                      U32 dwTrgLevel, U32 wReTriggerCnt, U32 dwDelayCount );

    I16 __stdcall UD_AI_2401_Config ( U16 CardNumber, U16 wChanCfg1, U16 wChanCfg2, \
                                      U16 wChanCfg3, U16 wChanCfg4, U16 wTrigCtrl );

    I16 __stdcall UD_AI_2401_PollConfig ( U16 wCardNumber, U16 wPollSpeed, \
                                          U16 wMAvgStageCh1, U16 wMAvgStageCh2, U16 wMAvgStageCh3, U16 wMAvgStageCh4 );

    I16 __stdcall UD_AI_1902_CounterInterval ( U16 CardNumber, U32 ScanIntrv, \
            U32 SampIntrv );

    I16 __stdcall UD_AI_AsyncCheck ( U16 CardNumber, BOOLEAN *Stopped, U32 *AccessCnt );

    I16 __stdcall UD_AI_AsyncClear ( U16 CardNumber, U32 *AccessCnt );

    I16 __stdcall UD_AI_AsyncDblBufferHalfReady ( U16 CardNumber, BOOLEAN *HalfReady, \
            BOOLEAN *StopFlag );

    I16 __stdcall UD_AI_AsyncDblBufferMode ( U16 CardNumber, BOOLEAN Enable );

    I16 __stdcall UD_AI_AsyncDblBufferTransfer ( U16 CardNumber, U16 *Buffer );

    I16 __stdcall UD_AI_AsyncDblBufferTransfer32 ( U16 CardNumber, U32 *pwBuffer );

    I16 __stdcall UD_AI_AsyncDblBufferOverrun ( U16 CardNumber, U16 op, U16 *overrunFlag );

    I16 __stdcall UD_AI_AsyncDblBufferHandled ( U16 CardNumber );

    I16 __stdcall UD_AI_AsyncDblBufferToFile ( U16 CardNumber );

    I16 __stdcall UD_AI_ContReadChannel ( U16 CardNumber, U16 Channel, U16 AdRange, \
                                          U16 *Buffer, U32 ReadCount, F64 SampleRate, U16 SyncMode );

    I16 __stdcall UD_AI_ContReadMultiChannels ( U16 CardNumber, U16 NumChans, \
            U16 *Chans, U16 *AdRanges, U16 *Buffer, U32 ReadCount, F64 SampleRate, \
            U16 SyncMode );

    I16 __stdcall UD_AI_ContReadChannelToFile ( U16 CardNumber, U16 Channel, \
            U16 AdRange, U8 *FileName, U32 ReadCount, F64 SampleRate, U16 SyncMode );

    I16 __stdcall UD_AI_ContReadMultiChannelsToFile ( U16 CardNumber, U16 NumChans, \
            U16 *Chans, U16 *AdRanges, U8 *FileName, U32 ReadCount, F64 SampleRate, \
            U16 SyncMode );

    I16 __stdcall UD_AI_ContScanChannelsToFile ( U16 CardNumber, U16 Channel, \
            U16 AdRange, U8 *FileName, U32 ReadCount, F64 SampleRate, U16 SyncMode );

    I16 __stdcall UD_AI_InitialMemoryAllocated ( U16 CardNumber, U32 *MemSize );

    I16 __stdcall UD_AI_ReadChannel ( U16 CardNumber, U16 Channel, U16 AdRange, \
                                      U16 *Value );

    I16 __stdcall UD_AI_VReadChannel ( U16 CardNumber, U16 Channel, U16 AdRange, \
                                       F64 *voltage );

    I16 __stdcall UD_AI_ReadMultiChannels ( U16 CardNumber, U16 NumChans, U16 *Chans, \
                                            U16 *AdRanges, U16 *Buffer );

    I16 __stdcall UD_AI_SetTimeOut ( U16 CardNumber, U32 TimeOut );

    I16 __stdcall UD_AI_VoltScale ( U16 CardNumber, U16 AdRange, I16 reading, \
                                    F64 *voltage );

    I16 __stdcall UD_AI_ContVScale ( U16 CardNumber, U16 adRange, void *readingArray, \
                                     F64 *voltageArray, I32 count );

    I16 __stdcall UD_AI_2401_Scale32 ( U16 CardNumber, U16 adRange, U16 inType, \
                                       U32 reading, F64 *voltage );
                                       
    I16 __stdcall UD_AI_2401_ContVScale32 ( U16 CardNumber, U16 adRange, U16 inType, \
                                            U32 *readingArray, F64 *voltageArray, I32 count );

    I16 __stdcall UD_AI_AsyncReTrigNextReady ( U16 CardNumber, BOOLEAN *Ready, \
            BOOLEAN *StopFlag, U32 *RdyTrigCnt );

    I16 __stdcall UD_AI_AsyncBufferTransfer ( USHORT wCardNumber, USHORT *pwBuffer, \
            U32 offset, U32 count );

    I16 __stdcall UD_AI_EventCallBack ( U16 CardNumber, I16 mode, I16 EventType, \
                                        U32 callbackAddr );

    I16 __stdcall UD_AI_Moving_Average32 ( U16 CardNumber, U32 *SrcBuf, U32 *DesBuf, \
            U32 dwTgChIdx, U32 dwTotalCh, U32 dwMovAvgWindow, U32 dwSamplCnt );

    I16 __stdcall UD_AI_2401_Stop_Poll ( USHORT wCardNumber ); 

    I16 __stdcall UD_AI_DDS_ActualRate_Get ( U16 CardNumber, F64 fSampleRate, F64 *fActualRate );

    I16 __stdcall UD_AI_Channel_Config ( U16 CardNumber, U16 wChanCfg1, U16 wChanCfg2, U16 wChanCfg3, U16 wChanCfg4);

    I16 __stdcall UD_AI_Trigger_Config ( U16 CardNumber, U16 wConvSrc, U16 wTrigMode, U16 wTrigCtrl,  \
                                           U32 wReTrigCnt, U32 dwDLY1Cnt, U32 dwDLY2Cnt, U32 dwTrgLevel );

    I16 __stdcall UD_AI_2405_Chan_Config ( U16 CardNumber, U16 wChanCfg1, U16 wChanCfg2, U16 wChanCfg3, U16 wChanCfg4);

    I16 __stdcall UD_AI_2405_Trig_Config ( U16 CardNumber, U16 wConvSrc, U16 wTrigMode, U16 wTrigCtrl,  \
                                           U32 wReTrigCnt, U32 dwDLY1Cnt, U32 dwDLY2Cnt, U32 dwTrgLevel );
                                                                            
    I16 __stdcall UD_AI_VoltScale32 ( U16 CardNumber, U16 adRange, U16 inType, \
                                       U32 reading, F64 *voltage );
                                       
    I16 __stdcall UD_AI_ContVScale32 ( U16 CardNumber, U16 adRange, U16 inType, \
                                            U32 *readingArray, F64 *voltageArray, I32 count );
                                            
    I16 __stdcall UD_AI_AsyncBufferTransfer32 ( U16 wCardNumber, U32 *pdwBuffer,
            U32 offset, U32 count );                                            
    /*----------------------------------------------------------------------------*/
    /* AO Function */

    I16 __stdcall UD_AO_1902_Config ( U16 CardNumber, U16 ConfigCtrl, U16 TrigCtrl, \
                                      U32 ReTrgCnt, U32 DLY1Cnt, U32 DLY2Cnt );

    I16 __stdcall UD_AO_AsyncCheck ( U16 CardNumber, BOOLEAN *Stopped, U32 *AccessCnt );

    I16 __stdcall UD_AO_AsyncClear ( U16 CardNumber, U32 *AccessCnt, U16 stop_mode );

    I16 __stdcall UD_AO_AsyncDblBufferHalfReady ( U16 CardNumber, BOOLEAN *bHalfReady );

    I16 __stdcall UD_AO_AsyncDblBufferTransfer ( U16 wCardNumber, USHORT wBufferID, USHORT *pwBuffer );

    I16 __stdcall UD_AO_AsyncDblBufferMode ( U16 CardNumber, BOOLEAN Enable, BOOLEAN bEnFifoMode );

    I16 __stdcall UD_AO_ContBufferCompose ( U16 CardNumber, U16 TotalChnCount, \
                                            U16 ChnNum, U32 UpdateCount, void *ConBuffer, void *Buffer );

    I16 __stdcall UD_AO_ContWriteChannel ( U16 CardNumber, U16 Channel,   VOID *pAOBuffer, \
                                           U32 WriteCount, U32 Iterations, U32 CHUI, U16 definite, U16 SyncMode );

    I16 __stdcall UD_AO_ContWriteMultiChannels ( U16 CardNumber, U16 NumChans, \
            U16 *Chans, VOID *pAOBuffer, U32 WriteCount, U32 Iterations, U32 CHUI, \
            U16 definite, U16 SyncMode );

    I16 __stdcall UD_AO_InitialMemoryAllocated ( U16 CardNumber, U32 *MemSize );

    I16 __stdcall UD_AO_SetTimeOut ( U16 CardNumber, U32 TimeOut );

    I16 __stdcall UD_AO_SimuVWriteChannel ( U16 CardNumber, U16 Group, F64 *VBuffer );

    I16 __stdcall UD_AO_SimuWriteChannel ( U16 CardNumber, U16 Group, I16 *Buffer );

    I16 __stdcall UD_AO_VWriteChannel ( U16 CardNumber, U16 Channel, F64 Voltage );

    I16 __stdcall UD_AO_WriteChannel ( U16 CardNumber, U16 Channel, I16 Value );

    I16 __stdcall UD_AO_WriteChannels ( U16 wCardNumber, U16 wNumChans, U16 *pwChans, \
                                        U16 *pwBuffer );

    I16 __stdcall UD_AO_VoltScale ( U16 CardNumber, U16 Channel, F64 Voltage, \
                                    I16 *binValue );

                                      
    I16 __stdcall UD_AO_EventCallBack ( U16 CardNumber, I16 mode, I16 EventType, \
                                        U32 callbackAddr );
                                      
    I16 __stdcall UD_AO_VoltScale32 ( U16 CardNumber, U16 Channel, F64 Voltage, \
                                    I32 *binValue );
                                    

    /*----------------------------------------------------------------------------*/

    I16 __stdcall UD_DIO_1902_Config ( U16 wCardNumber, U16 wPart1Cfg, U16 wPart2Cfg );
    I16 __stdcall UD_DIO_2401_Config ( U16 wCardNumber, U16 wPart1Cfg );  
    I16 __stdcall UD_DIO_2405_Config ( U16 wCardNumber, U16 wPart1Cfg, U16 wPart2Cfg );    
    I16 __stdcall UD_DIO_Config ( U16 wCardNumber, U16 wPart1Cfg, U16 wPart2Cfg ); 
    /*----------------------------------------------------------------------------*/
    /* DI Function */

    I16 __stdcall UD_DI_ReadLine ( U16 CardNumber, U16 Port, U16 Line, U16 *State );

    I16 __stdcall UD_DI_ReadPort ( U16 CardNumber, U16 Port, U32 *Value );

    /*----------------------------------------------------------------------------*/
    /* DO Function */

    I16 __stdcall UD_DO_ReadLine ( U16 CardNumber, U16 Port, U16 Line, U16 *Value );

    I16 __stdcall UD_DO_ReadPort ( U16 CardNumber, U16 Port, U32 *Value );

    I16 __stdcall UD_DO_WriteLine ( U16 CardNumber, U16 Port, U16 Line, U16 Value );

    I16 __stdcall UD_DO_WritePort ( U16 CardNumber, U16 Port, U32 Value );

    /*----------------------------------------------------------------------------*/
    /* Timer/Counter Function */
    I16 __stdcall UD_GPTC_Clear ( U16 CardNumber, U16 GCtr );

    I16 __stdcall UD_GPTC_Control ( U16 CardNumber, U16 GCtr, U16 ParamID, U16 Value );

    I16 __stdcall UD_GPTC_Read ( U16 CardNumber, U16 GCtr, U32 *Value );

    I16 __stdcall UD_GPTC_Setup ( U16 CardNumber, U16 GCtr, U16 Mode, U16 SrcCtrl, \
                                  U16 PolCtrl, U32 LReg1_Val, U32 LReg2_Val, U32 PulseCount );
                                  
    I16 __stdcall UD_GPTC_Setup_N ( U16 CardNumber, U16 GCtr, U16 Mode, U16 SrcCtrl, \
                                  U16 PolCtrl, U32 LReg1_Val, U32 LReg2_Val, U32 PulseCount );                                  

    I16 __stdcall UD_GPTC_Status ( U16 CardNumber, U16 GCtr, U16 *Value );

    /* Get Event or View Function */
    I16 __stdcall UD_AI_GetEvent ( U16 CardNumber, HANDLE *Event );

    I16 __stdcall UD_AO_GetEvent ( U16 CardNumber, HANDLE *Event );
    
    I16 __stdcall UD_AI_GetView ( U16 CardNumber, U32 *View );

    I16 __stdcall UD_AO_GetView ( U16 CardNumber, U32 *View );

    /*---------------------------------------------------------------------------*/
    /* Common Function */
    I16 __stdcall UD_GetActualRate ( U16 CardNumber, F64 SampleRate, F64 *ActualRate );

    I16 __stdcall UD_GetCardIndexFromID ( U16 CardNumber, U16 *cardType, U16 *cardIndex );

    I16 __stdcall UD_GetCardType ( U16 CardNumber, U16 *cardType );

    I16 __stdcall UD_IdentifyLED_Control ( U16 wCardNumber, U8  bEnable ); // 1: enable , 0: disable LED flash

    /*---------------------------------------------------------------------------*/
    /* Misc. Functions */
    I16 __stdcall UD_Read_ColdJunc_Thermo ( U16 wCardNumber, F64 *pfValue  );
    I16 __stdcall UD_Read_ColdJunc_Thermo_QC ( USHORT wCardNumber, USHORT wSensorNo, double *pfValue );   
    
    /*----------------------------------------------------------------------------*/
    /* Calibration Function */

    I16 __stdcall usbdaq_1901_Calibration_All ( U16 wCardNumber, U16 *pCalOp, U16 *pCalSrc );
    I16 __stdcall usbdaq_1902_Calibration_All ( U16 wCardNumber, U16 *pCalOp, U16 *pCalSrc );
    I16 __stdcall usbdaq_1901_Calibration_User ( U16 wCardNumber, U16 *pCalOp, U16 *pCalSrc );
    I16 __stdcall usbdaq_1902_Calibration_User ( U16 wCardNumber, U16 *pCalOp, U16 *pCalSrc );    
    
    /*----------------------------------------------------------------------------*/    
    I16 __stdcall UD_CTR_Control ( U16 wCardNumber, U16 wCtr, U32 dwCtrl);

    I16 __stdcall UD_CTR_ReadFrequency ( U16 wCardNumber, U16 wCtr, F64 *pfValue );

    I16 __stdcall UD_CTR_ReadEdgeCounter ( U16 wCardNumber, U16 wCtr, U32 *dwValue );
    I16 __stdcall UD_CTR_ReadRisingEdgeCounter ( U16 wCardNumber, U16 wCtr, U32 *dwValue );    

    enum {
        UD_CTR_Filter_Disable,
        UD_CTR_Filter_Enable = 1,
        UD_CTR_Reset_Rising_Edge_Counter = 2,
        UD_CTR_Reset_Frequency_Counter = 4,
        UD_CTR_Polarity_Positive = 8,
        UD_CTR_Polarity_Negative = 0,
    };

    I16 __stdcall UD_CTR_SetupMinPulseWidth ( U16 wCardNumber, U16 wCtr, U16 wValue );

    I16 __stdcall UD_DI_GetCOSLatchData32 ( U16 wCardNumber, U16 wPort, U32 *pwCosLData );

    I16 __stdcall UD_DI_SetupMinPulseWidth ( U16 wCardNumber, U16 wValue );

    I16 __stdcall UD_DI_Control ( U16 wCardNumber, U16 wPort, U32 dwCtrl );

    I16 __stdcall UD_DI_SetCOSInterrupt32 ( U16 wCardNumber, U16 wPort, U32 dwCtrl, HANDLE *hEvent, BOOLEAN ManualReset );

    I16 __stdcall UD_DO_GetInitPattern (U16 wCardNumber, U16 wPort, U32 *pdwPattern);

    I16 __stdcall UD_DO_SetInitPattern (U16 wCardNumber, U16 wPort, U32 *pdwPattern);

    I16 __stdcall UD_DIO_INT_EventMessage (U16 wCardNumber, I16 mode, HANDLE evt, HWND windowHandle, U32 message, void (__stdcall*callbackAddr)(void));
    

    /*----------------------------------------------------------------------------*/   
    /* internal use only */

    /* Calibration Function */
    I16 __stdcall UD_CAL_AD_Read_Sum ( U16 wCardNumber, U16 wChannelCount, U16 wChannel, U16 wGain, U16 wOperation, U16 wCalSrc, \
		                               U32 dwSampleRate, U32 dwCalSamples, I64 *pAD_Data );

    I16 __stdcall UD_AI_Calibration ( U16 wCardNumber, U32 dwReserved );

    I16 __stdcall usbdaq_AI_Calibration ( U16 wCardNumber, U16 wOperation, U16 wCalSrc, U16 wGain, F64 fRefVolt, U32 dwSampleRate, \
		                                  U32 dwCalSamples, U32 *pCalValue );

    I16 __stdcall usbdaq_Cal_ReadEeprom ( U16 wCardNumber, UCHAR bOperation, UCHAR *CalData, UCHAR bFromEeprom );

    I16 __stdcall usbdaq_Cal_WriteEeprom ( U16 wCardNumber, UCHAR bOperation, ULONG dwDataLen, UCHAR *CalData );

    I16 __stdcall usbdaq_ReadRefVoltage ( U16 wCardNumber, F64 *pRefVOLT, UCHAR bFromEeprom );
    /*----------------------------------------------------------------------------*/


    /* USB-1901/1902 Calibration */
    I16 __stdcall UD_1902_AD_Read_Average ( U16 wCardNumber, USHORT wCalSrc, UCHAR bOffsetGain, I32 *pAD_Data );
    I16 __stdcall usbdaq_1902_RefVol_ReadEeprom ( U16 wCardNumber, DOUBLE *RefVol, WORD *wTrimmer );
    I16 __stdcall usbdaq_1902_RefVol_WriteEeprom ( U16 wCardNumber, DOUBLE *RefVol, WORD wTrimmer );
    I16 __stdcall usbdaq_1902_Calibration ( U16 wCardNumber, WORD wOperation, WORD wCalSrc, double fRefVolt );
    I16 __stdcall usbdaq_1902_Cal_WriteEeprom ( U16 wCardNumber, UCHAR bOperation, UCHAR *CALdata );
    I16 __stdcall usbdaq_1902_CalSrc_Switch ( U16 wCardNumber, WORD wOperation, WORD wCalSrc );
    I16 __stdcall usbdaq_1902_GainOffset_Write ( U16 wCardNumber, WORD wCalSrc, WORD wOperation, WORD wValue );
    I16 __stdcall usbdaq_1902_ReadEeprom ( U16 wCardNumber, QC_INFO_1902 *pQCInfo, CAL_INFO_1902 *pCalInfo );
    I16 __stdcall usbdaq_1902_WriteEeprom ( U16 wCardNumber, UCHAR bOperation, U8 *QCdata,  U8 *CALdata );
    I16 __stdcall usbdaq_1902_Cal_ReadEeprom ( U16 wCardNumber, UCHAR bOperation, CAL_INFO_1902 *pCalInfo );
    I16 __stdcall usbdaq_1901_Cal_Switch ( U16 wCardNumber, UCHAR bOperation );
    I16 __stdcall usbdaq_1902_Cal_Switch ( U16 wCardNumber, UCHAR bOperation );
    I16 __stdcall usbdaq_1902_Cal_Read ( U16 wCardNumber, CAL_INFO_1902 *pCalInfo );

    /* internal use only, USB-1903 Calibration */
    I16 __stdcall usbdaq_1903_Calibration_All ( U16 wCardNumber, DOUBLE RefVol_10V, U16 *pCalOp, U16 *pCalSrc );
    I16 __stdcall UD_1903_AD_Read_Average ( U16 wCardNumber, USHORT wCalSrc, I32 *pAD_Data );
    I16 __stdcall usbdaq_1903_Current_Calibration ( U16 wCardNumber, WORD wOperation, WORD wCalChan, double fRefCur, DWORD *pCalReg );
    I16 __stdcall usbdaq_1903_GainOffset_Write ( U16 wCardNumber, WORD wCalSrc, WORD wOperation, WORD wValue );
    I16 __stdcall usbdaq_1903_WriteEeprom ( U16 wCardNumber, WORD wTrimmer, U8 *CALdata );

    /* internal use only, USB-2401 Calibration */

    I16 __stdcall usbdaq_2401_Trimmer_WriteEeprom ( U16 wCardNumber, USHORT wTrimmer );
    I16 __stdcall usbdaq_2401_Trimmer_ReadEeprom ( U16 wCardNumber, USHORT *pTrimmer );
    I16 __stdcall usbdaq_2401_Chan_WriteEeprom ( U16 wCardNumber, USHORT wChan, ULONG dwSampleRate, UCHAR *CALdata );
    I16 __stdcall usbdaq_2401_Chan_ReadEeprom ( U16 wCardNumber, USHORT wChan, ULONG dwSamplerate, UCHAR *CALdata );
    I16 __stdcall usbdaq_2401_Chan_WriteEeprom_LC ( U16 wCardNumber, USHORT wChan, ULONG dwSampleRate, UCHAR *CALdata );
    I16 __stdcall usbdaq_2401_Chan_ReadEeprom_LC ( U16 wCardNumber, USHORT wChan, ULONG dwSamplerate, UCHAR *CALdata );

    I16 __stdcall usbdaq_2401_Calibration ( U16 wCardNumber, WORD wOperation, WORD wCalSrc, double fRefVolt[], ULONG dwSampleRate, DWORD *pCalValue );
    I16 __stdcall UD_2401_AD_Read_Sum ( U16 wCardNumber, WORD wOperation, U16 wCalSrc, ULONG dwSampleRate, I64 *pAD_Data );
    I16 __stdcall UD_2401_AD_Read_Raw ( U16 wCardNumber, WORD wOperation, U16 wCalSrc, ULONG dwSampleRate, I32 **pAD_Data );

    I16 __stdcall UD_2405_Calibration_QC ( U16 wCardNumber );
    I16 __stdcall UD_2405_Calibration ( U16 wCardNumber );
    I16 __stdcall usbdaq_2405_ReadRefVoltage ( U16 wCardNumber, VOLT_INFO_2405 *pVOLTInfo, UCHAR bFromEeprom );
    I16 __stdcall usbdaq_2405_ReadEeprom ( U16 wCardNumber, UCHAR bOperation, CAL_INFO_2405 *pCalInfo, UCHAR bFromEeprom );
    I16 __stdcall usbdaq_2405_WriteEeprom ( U16 wCardNumber, UCHAR bOperation, ULONG dwDataLen, UCHAR *QCdata );
    I16 __stdcall usbdaq_2405_Calibration_Single ( U16 wCardNumber, U16 wChannel, WORD wOperation, WORD wCalSrc, double fRefVolt, ULONG dwSampleRate, ULONG dwCalSamples, DWORD *pCalValue );
    I16 __stdcall usbdaq_2405_Calibration ( U16 wCardNumber, WORD wOperation, WORD wCalSrc, double fRefVolt, ULONG dwSampleRate, ULONG dwCalSamples, DWORD *pCalValue );
    I16 __stdcall UD_2405_AD_Read_Sum ( U16 wCardNumber, WORD wChannelCount, WORD wChannel, WORD wOperation, WORD wCalSrc, ULONG dwSampleRate, ULONG dwCalSamples, I64 *pAD_Data );   
    I16 __stdcall usbdaq_2405_GainOffset_Write ( U16 wCardNumber, WORD  wChannel, WORD  wOperation, DWORD dwValue );    
    I16 __stdcall usbdaq_2405_VScale_w_Sensitivity ( U16 wCardNumber, U32 reading, F64 fSensitivity, F64 *voltage );
    I16 __stdcall usbdaq_2405_ContVScale_w_Sensitivity ( U16 wCardNumber, U32 *readingArray, F64 fSensitivity, F64 *voltageArray, U32 count );
    /*-------------------------- Internal Use --------------------------*/
    I16 __stdcall UD_GetFPGAVersion ( U16 wCardNumber, U32 *pdwFPGAVersion );
    I16 __stdcall usbdaq_GetRotarySwitchID ( U16 wCardNumber, U32 *pdwSwitchID );

    I16 __stdcall UD_1902_Trimmer_Set ( U16 wCardNumber, UCHAR bValue );

    I16 __stdcall UD_2401_Trimmer_Set ( U16 wCardNumber, UCHAR bValue );

    /*---------------------------------------------------------------------------*/
    /* Misc. Functions */
    I16 __stdcall UD_Serial_Number_Read ( U16 wCardNumber, U8 *pSerialNum );
    I16 __stdcall UD_Serial_Number_Write ( U16 wCardNumber, U8 *pSerialNum );
    I16 __stdcall UD_GetVersion ( U16 wCardNumber, U32 *pdwFPGAVersion, U16 wDrvVer[4], U16 wLibVersion[4], U32 dwVersionCmd, PVOID pVersion );    
    /*----------------------------------------------------------------------------*/


    /*-------------------------- For DAQPilot --------------------------*/

    I16 __stdcall UD_GetCardActualRate ( U16 CardType, DOUBLE fSampleRate, DOUBLE *fActualRate );

    I16 __stdcall UD_get_actualRate ( U16 CardType, U32 dwCtrKHz, ULONG dwPacerValue, DOUBLE *fActualRate );

    I16 __stdcall UD_AI_ContVolScale ( U16 CardType, U16 adRange, VOID *readingArray, \
                                       DOUBLE *voltageArray, LONG count );

    I16 __stdcall UD_AIVoltScale ( U16 CardType, U16 adRange, SHORT reading, DOUBLE *voltage );

    I16 __stdcall UD_AI_ScanReadChannels ( U16 CardNumber, U16 Channel, U16 AdRange, \
                                           U16 *Buffer );

    I16 __stdcall UD_AI_ContScanChannels ( U16 CardNumber, U16 Channel, U16 AdRange, \
                                           U16 *Buffer, U32 ReadCount, F64 SampleRate, U16 SyncMode );
    /*----------------------------------------------------------------------------*/

    I16 __stdcall usbdaq_ReadPort ( U16 CardNumber, U16 wPortAddr, U32 *pdwData );
    I16 __stdcall usbdaq_WritePort ( U16 CardNumber, U16 wPortAddr, U32 dwData );
    I16 __stdcall usbdaq_AITest ( U16 wCardNumber, U16 wNumChans, U16 *pwChans, \
                                  U16 *pwAdRanges, U16 *pwBuffer, U32 dwReadCount, F64 fSampleRate, U16 wSyncMode );
    I16 __stdcall usbdaq_AOTest ( U16 wCardNumber, U16 wNumChans, U16 *pwChans, \
                                  U16 *pwAdRanges, U16 *pwBuffer, U32 dwReadCount, F64 fSampleRate, U16 wSyncMode );
    I16 __stdcall usbdaq_RequestZLP ( USHORT wCardNumber );
    I16 __stdcall usbdaq_ResetFIFO ( USHORT wCardNumber, USHORT wEndPoint );

    /*----------------------------------------------------------------------------*/

#ifdef __cplusplus
}
#endif

#endif
