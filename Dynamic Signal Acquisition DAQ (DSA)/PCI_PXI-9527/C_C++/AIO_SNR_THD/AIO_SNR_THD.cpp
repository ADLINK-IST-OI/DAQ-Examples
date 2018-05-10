// AIO_SNR_THD.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "DSA-Dask.h"
#include "FFT.h"
#include "math.h"

#define AI_DATACOUNT		65536		/*acquisition counts per channel*/
#define AI_CHANNEL_COUNT	1
#define AI_SAMPLE_RATE		432000
#define AO_DATACOUNT		AI_DATACOUNT/2		/*output counts per channel*/
#define AO_CHANNEL_COUNT	1
#define AO_UPDATE_RATE		216000		/*Shall be half of AI_SAMPLE_RATE*/
#define PI					3.14159265358979323846264338327


struct Analysis_Result
{
	 F64         SINAD       ;
	 F64         SNR         ;
	 F64         THD         ;
	 F64         THD_Percent ;
	 F64         ENOB        ;
	 F64         SFDR        ;
	 U32	     MsbIndex	 ;
	 F64		 MsbPower	 ;
	 F64		 MFreqPower	 ;
	 F64		 MFreqPhase	 ;
	 U32		 MFreqIndex	 ;
	 F64*        lpFreqes    ; // Frequencies table
	 F64*        lpPowers    ; // fft power spectrum
	 F64*        lpPhases    ; // fft phase spectrum
	 U32*        FreqIndexes ; // frequencies found for analysis (indexes)
     F64*        FreqPowers  ; // powers according to FreqIndexes
	 F64         FreqStep;
	 F64         Max;
	 F64         Length;
	 F64         Fs;
	 F64         MFreq;
	 U32		 result;//To determin if the caculation success
	 F64         Vpp;
	 F64         Vp;
	 F64         Vrms;
	 F64         dBV;
	 F64         dBu;
};

struct Harmonic_Search_Setting
{
	 U32 dwHarmCount   ; // [IN ] harmonic count, range [1, dwHalf)
	 U32 dwHarmSpan    ; // [IN ] span of the harmonic frequency on each side
	 U32 dwSearch      ; // [IN ] approximate search span for harmonics on each side
	 U32 dwMainSpan    ; // [IN ] span of the input frequency on each side
	 U32 dwIndexDc     ; // [IN ] parameter used to avoid the dc stuff
};

struct TestData_Arg
{
    U32         dwSamples     ; // [IN ] number of samples, must be power of 2
    const F64*  lpDataIn      ; // [IN ] input data, reals
    F64*        lpDataWin     ; // [IN ] hanning window data
};

Harmonic_Search_Setting GetDefaultHarmonicSearchSetting(U32 length)
{
	Harmonic_Search_Setting Setting;		
	//Default settings
	Setting.dwHarmCount = 6;
	Setting.dwHarmSpan  = 5;
	Setting.dwSearch    = 25;
	Setting.dwMainSpan  = length/200 ;
	Setting.dwIndexDc   = 6;

	return Setting;
}

U32 FindSignalAMP(F64 *__Dout, U32 data_length, F64 Fs, Analysis_Result&  __r)
{
	F64 Max = -999999999.0;//std::numeric_limits<double>::min();
	F64 Min = 999999999.0;//std::numeric_limits<double>::max();
	F64 Maverage = 0;
	F64 Eaverage = 0;
    F64 Msum = 0;
	F64 Esum = 0;

	__r.Fs = Fs;
	__r.Length = data_length;
	__r.FreqStep = __r.Fs/data_length;
	__r.Max = 10*::log10(__r.MFreqPower);

	__r.lpFreqes = new F64[data_length];

	for(U32 i=0 ;i<data_length ;i++ )
	{
		if(__r.lpPowers!=NULL && __r.lpFreqes!=NULL)
		{
			__r.lpPowers[i] = 10*::log10(__r.lpPowers[i])-__r.Max;
			__r.lpFreqes[i] = i*__r.FreqStep;
		}
		Msum += ((F64)__Dout[i]) / data_length;
        Esum += ((F64)__Dout[i]) / data_length * __Dout[i];

		if(__Dout[i]>Max)
			Max = __Dout[i];
		if(__Dout[i]<Min)
			Min = __Dout[i];
	}

	Maverage = Msum;
    Eaverage = Esum;
            
    // __r.Vrms = pow(Eaverage - Maverage * Maverage,0.5);
	__r.Vrms = pow(Esum,0.5);
	__r.Vpp  = ::fabs(Max-Min);
	__r.Vp   = __r.Vpp/2.0;
	__r.dBV  = 20*::log10(__r.Vrms);
	__r.dBu  = __r.dBV + 2.218487499;

	
	
	
	__r.MFreq = __r.FreqStep*__r.MFreqIndex;

	return 0;
}

Analysis_Result FindSignalAMP  (F64 *__Dout, U32 data_length)
{
	Analysis_Result __r;
	__r.lpPowers = NULL;
	__r.lpPhases = NULL;
	__r.FreqIndexes = NULL;
	__r.FreqPowers = NULL;
	__r.lpFreqes = NULL;

	FindSignalAMP(__Dout,data_length,0,__r);
	return __r;
}

U32 TEST__SingleTone_Member(const TestData_Arg&  __x,const Harmonic_Search_Setting&  __h,Analysis_Result&  __r)
{
    U32  result = FFT_TRUE;

	
    hanning(
      __x.dwSamples     // [IN ] number of samples, must be power of 2
    , __x.lpDataIn      // [IN ] source samples, reals, could be null
    , __x.lpDataWin     // [OUT] target results, reals
	);                  // [RET] number of processing, actual
	
	/*
	hanning(
      __x.dwSamples     // [IN ] number of samples, must be power of 2
    , __x.lpDataIn      // [IN ] source samples, reals, could be null
    , __x.lpDataWin     // [OUT] target results, reals
	);                  // [RET] number of processing, actual
	*/
    // -------------- Performing the FFT ------------- //
    //
    // %%% Dout_spec = fft(Doutw);
    //     Recalculate to dB
    // %%% Dout_dB = 20*log10(abs(Dout_spec));
    //     Determine power spectrum
    // %%% spectP = (abs(Dout_spec)).*(abs(Dout_spec));
    //
    U32  __error_index;
    __error_index =
    fft_spectrum_double(
          __x.dwSamples     // [IN ] number of samples, must be power of 2
        , __x.lpDataWin     // [IN ] source samples, real part
        , 0                 // [IN ] source samples, image part, could be NULL
        , __r.lpPowers      // [OUT] power outputs, reals only
        , __r.lpPhases      // [OUT] phase outputs, reals only, radians
        );                  // [RET] 0) no error, x) error index

    if ( __error_index )
	{
        result = FFT_FALSE;
		return result;
    }

    // search the harmonic bins & dynamic performance
    __error_index = dynamic_performance(
          __x.dwSamples >> 1    // [IN ] half number of samples, must be power of 2
        , __r.lpPowers          // [IN ] fft spectrum, dB
        , __h.dwIndexDc         // [IN ] parameter used to avoid the dc stuff
        , __h.dwSearch          // [IN ] approximate search span for harmonics on each side
        , __h.dwMainSpan        // [IN ] span of the input frequency on each side
        , __h.dwHarmSpan        // [IN ] span of the harmonic frequency on each side
        , __h.dwHarmCount       // [IN ] harmonic count, range [1, dwHalf)
        , __r.FreqIndexes     // [OUT] harmonic frequencies (indexes)
        , __r.FreqPowers      // [OUT] harmonic poweres
        , &__r.SINAD              // [OUT] pointer, SINAD
        , &__r.SNR                // [OUT] pointer, SNR
        , &__r.THD                // [OUT] pointer, THD
        , &__r.ENOB               // [OUT] pointer, ENOB
        , &__r.SFDR               // [OUT] pointer, SFDR
        , &__r.MsbIndex           // [OUT] pointer, maximum spurious bin (index)
        , &__r.MsbPower           // [OUT] pointer, maximum spurious power
        );                      // [RET] 0) no error, x) error index

	__r.THD_Percent =  __r.Vrms = 100.0*pow(10.0,__r.THD/20.0);  

    if ( __error_index ) 
	{
        result = FFT_FALSE;
		return result;
    }

	__r.result = result;
	
    return result;
}

Analysis_Result TEST_SingleTone(F64 *__Dout, U32 data_length, F64 fs, Harmonic_Search_Setting __h)
{
	Analysis_Result __r;

	__r.FreqIndexes = new U32[__h.dwHarmCount];
	__r.FreqPowers  = new F64 [__h.dwHarmCount];
	__r.lpPowers = new F64[data_length];
	__r.lpPhases = new F64[data_length];

	// %%% Doutw = Dout.*hanning(length(Dout));
	F64  *__Doutw     = new F64[data_length];
	//
	// arg
	//
	TestData_Arg  __x;
	__x.dwSamples     = data_length;        // [IN ] number of samples, must be power of 2
	__x.lpDataIn      = __Dout;             // [IN ] input data, reals
	__x.lpDataWin     = __Doutw;            // [IN ] hanning window data
	
	__r.result = TEST__SingleTone_Member(__x,__h,__r);

	__r.MFreqPower = __r.lpPowers[__r.FreqIndexes[0]];
	__r.MFreqPhase = __r.lpPhases[__r.FreqIndexes[0]];
	__r.MFreqIndex = __r.FreqIndexes[0];
	FindSignalAMP(__Dout,data_length,fs,__r);
	
	delete[] __Doutw;
		   
    return __r;
}


int main(int argc, char* argv[])
{
	// TODO: Place code here.
//General variable
    I16 card, err;
    U16 card_num;
    U32 vi = 0;
	FILE *fout;

	//Sample Rate configuration variables
	F64 UpdateRate = AO_UPDATE_RATE;
	F64 SampleRate = AI_SAMPLE_RATE;
	F64 ActualSampleRate;
	F64 ActualUpdateRate;

	//AO channel configuration variables
    U16 AOChannel = P9527_AO_CH_0;
	U16 AORange = AD_B_1_V;
	F64 FAORange = 1.0;//1.0 Vp for AD_B_1_V
	U16 AO_Config = P9527_AI_Differential;
	U8  AOAutoReset = 1;
	U32 UpdateCount = AO_DATACOUNT*AO_CHANNEL_COUNT;
	U16 AOBufId; 
	F64 OutputFrequency = 1000.0;
	F64 OutputAmp = 0.9;//Vp

	//AO Trigger configuration variables
	U16	AOTrigger_Target = P9527_TRG_AO;
	U16	AOTrigger_Config = P9527_TRG_MODE_POST|P9527_TRG_SRC_SOFT|P9527_TRG_Positive;
	U32 Iterations = 1;
	U32	RepeatInterval = 0;
	U16 definite = 1;
	U16	AOSyncMode = ASYNCH_OP;
    
	//AI channel configuration variables
	U16 AIChannel = P9527_AI_CH_0;
	U8  AIRange = AD_B_1_V;
	U8  AI_Config = P9527_AI_PseudoDifferential|P9527_AI_Coupling_DC;
	U8  AIAutoReset = 1;
	U32 SampleCount = AI_DATACOUNT*AI_CHANNEL_COUNT;
	U16 AIBufId; 
	BOOLEAN AOStopped;
	U32 AOAccessCnt;


	//AI Trigger configuration variables
	U16	AITrigger_Target = P9527_TRG_AI;
	U16	AITrigger_Config = AOTrigger_Config;
	U32 ReTriggerCount = 0;
	U32 DelayTrigger = 0;
	U16	AISyncMode = ASYNCH_OP;
    BOOLEAN AIStopped;
	U32 AIAccessCnt;

	//AO Data buffer
	U32 AOBuffer[ AO_DATACOUNT*AO_CHANNEL_COUNT];

	//AI Data buffer
	U32 AIBuffer[ AI_DATACOUNT*AI_CHANNEL_COUNT];
	F64 AIVBuffer[ AI_DATACOUNT*AI_CHANNEL_COUNT];
	memset(AIBuffer, '\0', SampleCount*sizeof(U32));
	memset(AIVBuffer, '\0', SampleCount*sizeof(U32));

    printf("Card Number? ");
    scanf(" %hd", &card_num);

	//Build waveform`
	for(vi=0; vi<UpdateCount; vi++)
	{
		 AOBuffer[vi] =(U32)((sin((F64)vi * 2.0 * PI * OutputFrequency / UpdateRate) * 0x7fffff * (OutputAmp / FAORange))); //Sin
    }

    card = DSA_Register_Card(PCI_9527, card_num);
    if(card<0){
        printf("DSA_Register_Card Error: %d\n", card);
        exit(1);
    }

	err = DSA_AO_9527_ConfigSampleRate(card, UpdateRate, &ActualUpdateRate);
    if(err!=NoError){
		if(err == -81)
		{
			printf("WARNING! Update Rate has been locked by AI job!\n");
		}
		else
		{
			printf("DSA_AO_9527_ConfigSampleRate Falied: %d\n", err);
			goto err_ret;
		}
    }
	printf("Actual Update Rate %f Hz\n", ActualUpdateRate);

	err = DSA_AI_9527_ConfigSampleRate(card, SampleRate, &ActualSampleRate);
    if(err!=NoError){
		if(err == -81)
		{
			//Sample Rate shall already been locked by AO job, so do nothing here
		}
		else
		{
			printf("DSA_AI_9527_ConfigSampleRate Falied: %d\n", err);
			goto err_ret;
		}
    }
	printf("Actual Sample Rate %f Hz\n", ActualSampleRate);



	err = DSA_AO_9527_ConfigChannel(card, AOChannel, AORange, AO_Config, AOAutoReset);
	 if(err!=NoError){
        printf("DSA_AI_9527_ChannelConfig Falied: %d\n", err);
        goto err_ret;
    }

	err = DSA_AI_9527_ConfigChannel(card, AIChannel, AIRange, AI_Config, AIAutoReset);
    if(err!=NoError){
        printf("DSA_AI_9527_ChannelConfig Falied: %d\n", err);
        goto err_ret;
    }


	err =  DSA_TRG_Config(card, AOTrigger_Target, AOTrigger_Config, 0, 0);
    if(err!=NoError){
        printf("DSA_TRG_9527_Config Falied: %d\n", err);
        goto err_ret;
    }

	err = DSA_TRG_Config(card, AITrigger_Target, AITrigger_Config, ReTriggerCount, DelayTrigger);
    if(err!=NoError){
        printf("DSA_TRG_9527_Config Falied: %d\n", err);
        goto err_ret;
    }

	err = DSA_AO_AsyncDblBufferMode(card, 0);
    if(err<0){
        printf("DSA_AO_AsyncDblBufferMode Error: %d\n", err);
        DSA_Release_Card(card);
        exit(1);
    }

    err = DSA_AI_AsyncDblBufferMode(card, 0);
    if(err<0){
        printf("AI_AsyncDblBufferMode Error: %d\n", err);
        DSA_Release_Card(card);
        exit(1);
    }

	err = DSA_AO_ContBufferSetup(card,AOBuffer, UpdateCount, &AOBufId);
	if (err!=0) {
		printf("DSA_AO_ContBufferSetup: %d\n", err);
		goto err_ret;
	}

	err = DSA_AO_ContWriteChannel(card, AOChannel, AOBufId, UpdateCount, Iterations, RepeatInterval, definite, AOSyncMode);
    if (err!=0) {
		printf("DSA_AO_ContWriteChannel: %d\n", err);
		goto err_ret;
	}

	err = DSA_AI_ContBufferSetup(card, AIBuffer, SampleCount, &AIBufId);
	if (err!=0) {
		printf("AI_ContBufferSetup_ERR: %d\n", err);
		goto err_ret;
	}

	err = DSA_AI_ContReadChannel(card, AIChannel, 0/*Ignored*/, &AIBufId, SampleCount, 0/*Ignored*/, AISyncMode);
	if (err!=0) {
		printf("DSA_AI_ContReadChannel err: %d\n", err);
		goto err_ret;
	}

	//Send Trigger
	err = DSA_TRG_SoftTriggerGen(card);
	if (err!=0) {
		printf("DSA_TRG_SoftTriggerGen err: %d\n", err);
		goto err_ret;
	}

	do{

		//Check whether AO Acquisition is done
        err = DSA_AO_AsyncCheck(card, &AOStopped, &AOAccessCnt);
		if(err<0){
            printf("DSA_AO_AsyncCheck Error: %d\n", err);
            DSA_AO_AsyncClear(card, &AOAccessCnt,0);
            DSA_AO_ContBufferReset(card);
            DSA_Release_Card(card);
            exit(1);
        }

        //Check whether AI Acquisition is done
        err = DSA_AI_AsyncCheck(card, &AIStopped, &AIAccessCnt);
        if(err<0){
            printf("DSA_AI_AsyncCheck Error: %d\n", err);
            DSA_AI_AsyncClear(card, &AIAccessCnt);
            DSA_AI_ContBufferReset(card);
            DSA_Release_Card(card);
            exit(1);
        }
    }while((!kbhit())&&(!AOStopped)&&(!AIStopped));


	err = DSA_AO_AsyncClear(card, &AOAccessCnt, 0);
	if (err!=0) {
		printf("DSA_AO_AsyncClear err: %d\n", err);
		goto err_ret;
	}

    //Clear AI Setting and Get Remaining data
    err = DSA_AI_AsyncClear(card, &AIAccessCnt);
    if(err<0){
        printf("AI_AsyncClear Error: %d\n", err);
        DSA_AI_ContBufferReset(card);
        DSA_Release_Card(card);
        exit(1);
    }

	err = DSA_AI_ContVScale(card, AIRange, AIBuffer, AIVBuffer, SampleCount);

	//Analysis data
	Analysis_Result  __r = TEST_SingleTone(AIVBuffer,SampleCount,SampleRate,GetDefaultHarmonicSearchSetting(SampleCount));

	printf("Fin: %lf Hz\n"  ,__r.MFreq);
	printf("AMP: %lf Vrms\n",__r.Vrms);
	printf("SNR: %lf dB\n"  ,__r.SNR);
	printf("THD: %lf dB\n"  ,__r.THD);

	//Wreite data to file
	fout = fopen("ai_read.txt", "w");
	for (vi = 0; vi <  AI_DATACOUNT*AI_CHANNEL_COUNT; vi ++)
	{
		fprintf(fout, "%lf\n",  AIVBuffer[vi]);
	}

	fclose(fout);

err_ret:
	if(!AIAutoReset)
	{
		err = DSA_AI_ContBufferReset(card);
		if (err!=0) {
			printf("AI_ContBufferReset error: %d\n", err);
			goto err_ret;
		}
	}

    DSA_Release_Card(card);    

	printf("Press any key to exit...\n");
    getch();
    return 0;
}

