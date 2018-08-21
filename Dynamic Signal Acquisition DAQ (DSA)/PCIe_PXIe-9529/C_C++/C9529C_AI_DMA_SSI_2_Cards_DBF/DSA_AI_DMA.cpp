/*----------------------------------------------------------------------------*/
/* Company : ADLINK                                                           */
/* Date    : 2013/11/15                                                       */
/*                                                                            */
/* This sample shows master side control routine of PXIe-9529 multi-sync.	  */
/*----------------------------------------------------------------------------*/

#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <queue>
#include "DSA-Dask.h"

using namespace std;

queue<F64*> masterQueue;
queue<F64*> slaveQueue;


I16 card_m, card_s, err, card_num_m, card_num_s;
    U16 Channel = 8, BufId0_m, BufId1_m,BufId0_s,BufId1_s,BufIdx_m=0,BufIdx_s=0;
	U16	RangeSel;
	U16 TbaseSrc_m=P9529_Internal|P9529_CLKOut_Enable|P9529_ExtCLK_SSI;
	U16 TbaseSrc_s=P9529_TimeBase_SSI|P9529_ExtCLK_SSI;
	U32 ReadCount=100000, AccessCnt, DelayCountIn=0, ReTRGCountIn=0;
	U32  *ppBufferAddr0_m,*ppBufferAddr1_m, *ppBufferAddr0_s,*ppBufferAddr1_s;
	F64 SampleRate = 100000, ActualRate = 0, *ppScaledVal_m, *ppScaledVal_s, data_m,data_s;
    BOOLEAN Stopped_m = FALSE, Stopped_s = FALSE,SyncReady_m=FALSE, SyncReady_s = FALSE,HalfReady_m=FALSE,HalfReady_s=FALSE;
	U16	TriggerOutBus=P9529_TRG_OUT_SSI;
	U16	TRGSetting_m=0,TRGSetting_s=0, TRGSrcSel=0, TRGTypeSel=0, TRGPolaSel=0, TRGAnalogCHSel=0, TRGAnalogModeSel=0, Export_Clk=1;
    U16 MCStatus_m, MCStatus_s;
    U32 vi_m = 0,vi_s=0,fileindex_m=0,fileindex_s=0;
	FILE *fout_m, *fout_s;
	char filename_m[64],filename_s[64];

int counter = 0;
    

void AI_m_END_CALLBACK()
{
   
}
void AI_s_END_CALLBACK()
{
   
}

void AI_m_DBEVENT_CALLBACK()
{
   
		
		if(BufIdx_m==0)
		{
			F64* ppScaledVal_m = new F64[ReadCount];
            DSA_AI_ContVScale(card_m, RangeSel, ppBufferAddr0_m, ppScaledVal_m, ReadCount);
			masterQueue.push(ppScaledVal_m);
		
			printf("BufIdx_m%d\n",BufIdx_m);
			BufIdx_m = 1;
					
		}				    		
		else
		{
			F64* ppScaledVal_m = new F64[ReadCount];
			DSA_AI_ContVScale(card_m, RangeSel, ppBufferAddr1_m, ppScaledVal_m, ReadCount);	
			masterQueue.push(ppScaledVal_m);
			
			printf("BufIdx_m%d\n",BufIdx_m);
			BufIdx_m = 0;
			
			
		}
		 
}
void AI_s_DBEVENT_CALLBACK()
{

		if(BufIdx_s==0)
		{
			F64* ppScaledVal_s = new F64[ReadCount];
			DSA_AI_ContVScale(card_s, RangeSel, ppBufferAddr0_s, ppScaledVal_s, ReadCount);
			slaveQueue.push(ppScaledVal_s);
		
            printf("BufIdx_s%d\n",BufIdx_s);
			BufIdx_s = 1;

			
		}		
		else
		{
			F64* ppScaledVal_s = new F64[ReadCount];
            DSA_AI_ContVScale(card_s, RangeSel, ppBufferAddr1_s, ppScaledVal_s, ReadCount);	
			slaveQueue.push(ppScaledVal_s);
			
			printf("BufIdx_s%d\n",BufIdx_s);
			BufIdx_s = 0;
				    
		}
	
}
int main(int argc, char **argv)
{
    

	printf("Master Card Number: ");
    scanf(" %hd", &card_num_m);
	 printf("Slave Card Number: ");
    scanf(" %hd", &card_num_s);
	RangeSel = AD_B_10_V;
	TRGSetting_m = P9529_TRG_SRC_SOFT| P9529_TRG_MODE_POST;
    TRGSetting_s = P9529_TRG_SRC_SSI|P9529_TRG_MODE_POST|P9529_TRG_Positive;;
	/*========== Typical Main procedure ==========*/

	//Register card before use
	card_m = DSA_Register_Card_ByID(PCI_9529, card_num_m);
    if(card_m<0){
        printf("DSA_Register_Card_ByID Error: %d\n", card_m);
        exit(1);
    }
		//Allocate user buffer for store DMA raw data
    ppBufferAddr0_m = (U32 *)VirtualAlloc(NULL, ReadCount*4,
        MEM_COMMIT, PAGE_READWRITE
    );
	 ppBufferAddr1_m = (U32 *)VirtualAlloc(NULL, ReadCount*4,
        MEM_COMMIT, PAGE_READWRITE
    );
	ppScaledVal_m = (F64 *)VirtualAlloc(NULL, ReadCount * 8,
		MEM_COMMIT, PAGE_READWRITE
	);

    if(SampleRate!=0)
	{
		err = DSA_ConfigSpeedRate(card_m, DAQ_AI, TbaseSrc_m, SampleRate, &ActualRate);
		if(err!=NoError){
			printf("DSA_ConfigSpeedRate Falied: %d\n", err);
			goto err_ret;
		}
	}
    
	err = DSA_SYN_ConfigMultiCard(card_m, P9529_SYN_MasterCard, P9529_SYN_SSI);
	if(err!=NoError){
		printf("DSA_ConfigMultiCard Falied: %d\n", err);
		goto err_ret;
	}

    err = DSA_TRG_SourceConn(card_m, TriggerOutBus);
	if(err!=NoError){
		printf("DSA_TRG_SourceConn Falied: %d\n", err);
		goto err_ret;
	}
    
	
    
	card_s = DSA_Register_Card_ByID(PCI_9529, card_num_s);
	if (card_s<0) {
		printf("DSA_Register_Card_ByID Error: %d\n", card_s);
		exit(1);
	}


	//Allocate user buffer for store scaled data
	ppScaledVal_s = (F64 *)VirtualAlloc(NULL, ReadCount*8,
        MEM_COMMIT, PAGE_READWRITE
    );
	ppBufferAddr0_s = (U32 *)VirtualAlloc(NULL, ReadCount * 4,
		MEM_COMMIT, PAGE_READWRITE
	);
	ppBufferAddr1_s = (U32 *)VirtualAlloc(NULL, ReadCount * 4,
		MEM_COMMIT, PAGE_READWRITE
	);

	//Allocate user buffer for store scaled data
	

	//set AI sample rate

	if (SampleRate != 0)
	{
		err = DSA_ConfigSpeedRate(card_s, DAQ_AI, TbaseSrc_s, SampleRate, &ActualRate);
		if (err != NoError) {
			printf("DSA_ConfigSpeedRate Falied: %d\n", err);
			goto err_ret;
		}
	}

	
	err = DSA_SYN_ConfigMultiCard(card_s, P9529_SYN_SlaveCard, P9529_SYN_SSI);
	if (err != NoError) {
		printf("DSA_ConfigMultiCard Falied: %d\n", err);
		goto err_ret;
	}

	
	//printf("Press any key to send SYNC signal to local hardware and all slave devices...\n");
	//getch();
	err = DSA_SYN_SyncStart(card_m);
	if(err!=NoError){
		printf("DSA_SYN_SyncStart Falied: %d\n", err);
		goto err_ret;
	}

	printf("Waiting SYNC signal to sync local AD hardware...\n");
	do
	{
		Sleep(1);
		DSA_SYN_CheckMultiCardStatus(card_m, &MCStatus_m);
		SyncReady_m = (BOOL)((MCStatus_m&0x4)>>2);
	}while((!SyncReady_m));
    printf("SyncReady_m Done\n");
	
	do
	{
		Sleep(1);
		DSA_SYN_CheckMultiCardStatus(card_s, &MCStatus_s);
		SyncReady_s = (BOOL)((MCStatus_s&0x4) >> 2);
	} while ((!SyncReady_s));
    printf("SyncReady_s Done\n");


	//AI Channel config: You should enable/disable/config each channel individually. IEPE no function now.
	for(vi_m=0;vi_m<8;vi_m++)
	{
		err = DSA_AI_9529_ConfigChannel(card_m, (U16)vi_m, TRUE, AD_B_10_V, P9529_AI_Diff|P9529_AI_Coupling_DC);
		err = DSA_AI_9529_ConfigChannel(card_s, (U16)vi_m, TRUE, AD_B_10_V, P9529_AI_Diff | P9529_AI_Coupling_DC);
		if(err!=NoError){
			printf("DSA_AI_9529_ConfigChannel Falied: %d\n", err);
			goto err_ret;
		}
	}
	
	//AI Trigger config: card, function to config, setting, retrigger count, delay trigger count(timebase is 125M)
	err = DSA_TRG_Config(card_m, P9529_TRG_AI, TRGSetting_m, ReTRGCountIn, DelayCountIn);
    if(err!=NoError){
        printf("DSA_TRG_Config Falied: %d\n", err);
        goto err_ret;
    }
     err = DSA_TRG_Config(card_s, P9529_TRG_AI, TRGSetting_s, ReTRGCountIn, DelayCountIn);
    if(err!=NoError){
        printf("DSA_TRG_Config Falied: %d\n", err);
        goto err_ret;
    }

	//Disable Double Buffer Mode
    err = DSA_AI_AsyncDblBufferMode(card_m, 1);
    if(err<0){
        printf("AI_AsyncDblBufferMode Error: %d\n", err);
        goto err_ret; 
    }
	err = DSA_AI_AsyncDblBufferMode(card_s, 1);
	if (err<0) {
		printf("AI_AsyncDblBufferMode Error: %d\n", err);
		goto err_ret;
	}

	//setup kernel DMA descriptor from user buffer
	err = DSA_AI_ContBufferSetup(card_m, (void *)ppBufferAddr0_m, ReadCount, &BufId0_m);
	if (err!=0) {
		printf("AI_ContBufferSetup error: %d\n", err);
		goto err_ret_withfree;
	}
	err = DSA_AI_ContBufferSetup(card_m, (void *)ppBufferAddr1_m, ReadCount, &BufId1_m);
	if (err!=0) {
		printf("AI_ContBufferSetup error: %d\n", err);
		goto err_ret_withfree;
	}

   err = DSA_AI_EventCallBack(card_m, 1, DBEvent, (U32)AI_m_DBEVENT_CALLBACK);
    if(err<0){
        printf("DSA_AI_EventCallBack Error: %d\n", err);
        DSA_AO_ContBufferReset(card_m);
        DSA_Release_Card(card_m);
        exit(1);
    }
	err = DSA_AI_EventCallBack(card_m, 1, AIEnd, (U32)AI_m_END_CALLBACK);
    if(err<0){
        printf("DSA_AI_EventCallBack2 Error: %d\n", err);
        DSA_AI_EventCallBack(card_m, 0, DBEvent, (U32)NULL);
        DSA_AI_ContBufferReset(card_m);
        DSA_Release_Card(card_m);
        exit(1);
    }
    
    err = DSA_AI_ContReadChannel(card_m, Channel, 0, &BufId0_m, ReadCount, 0, ASYNCH_OP);
	if (err!=0) {
		printf("DSA_AI_ContReadChannel error: %d\n", err);
		goto err_ret_withfree;
	}
	//to generate a software trigger if need
	err = DSA_AI_ContBufferSetup(card_s, (void *)ppBufferAddr0_s, ReadCount, &BufId0_s);
	if (err != 0) {
		printf("AI_ContBufferSetup error: %d\n", err);
		goto err_ret_withfree;
	}
	err = DSA_AI_ContBufferSetup(card_s, (void *)ppBufferAddr1_s, ReadCount, &BufId1_s);
	if (err != 0) {
		printf("AI_ContBufferSetup error: %d\n", err);
		goto err_ret_withfree;
	}
    
	err = DSA_AI_EventCallBack(card_s, 1, DBEvent, (U32)AI_s_DBEVENT_CALLBACK);
    if(err<0){
        printf("DSA_AO_EventCallBack Error: %d\n", err);
        DSA_AI_ContBufferReset(card_m);
        DSA_Release_Card(card_m);
        exit(1);
    }
	err = DSA_AI_EventCallBack(card_s, 1, AIEnd, (U32)AI_s_END_CALLBACK);
    if(err<0){
        printf("DSA_AI_EventCallBack2 Error: %d\n", err);
        DSA_AI_EventCallBack(card_s, 0, DBEvent, (U32)NULL);
        DSA_AI_ContBufferReset(card_s);
        DSA_Release_Card(card_s);
        exit(1);
    }
	//card, channel count(1/2/4/8), buffer id, sample count, not used, sync/async mode

	err = DSA_AI_ContReadChannel(card_s, Channel, 0, &BufId0_s, ReadCount, 0, ASYNCH_OP);
	if (err != 0) {
		printf("DSA_AI_ContReadChannel error: %d\n", err);
		goto err_ret_withfree;
	}
	//printf("Press ANYKEY to send sw trigger\n");
	//getch();
	DSA_TRG_SoftTriggerGen(card_m); 
	do{
        Sleep(1);
    }while(!kbhit());

    err = DSA_AI_AsyncClear(card_s, &AccessCnt);
    if(err<0){
        printf("DSA_AI_AsyncClear Error: %d\n", err);
        DSA_AI_AsyncClear(card_s, &AccessCnt);
        goto err_ret;
    }

	err = DSA_AI_AsyncClear(card_m, &AccessCnt);
    if(err<0){
        printf("DSA_AI_AsyncClear Error: %d\n", err);
        DSA_AI_AsyncClear(card_m, &AccessCnt);
        goto err_ret;
    }
	
   
    

	fout_m = fopen("ai_data_m.txt", "w");
    fout_s = fopen("ai_data_s.txt", "w");


	counter = 0;
	while(!masterQueue.empty())
	{
		F64* brffer = masterQueue.front();
		for (vi_m = 0; vi_m < ReadCount; vi_m ++)
		{
			if (vi_m%Channel == 7)
			{
				fprintf(fout_m, "%lf,%lf,%lf,%lf,%lf,%lf,%lf,%lf\n",*(brffer+vi_m -7)
																   ,*(brffer+vi_m -6)
																   ,*(brffer+vi_m -5) 
																   ,*(brffer+vi_m -4)
																   ,*(brffer+vi_m -3)
																   ,*(brffer+vi_m -2)
																   ,*(brffer+vi_m -1)
																   ,*(brffer+vi_m));
				
			}
		}
		delete[] brffer;
		printf("Queue size: %d, write buffer %d\n", masterQueue.size(), counter);
		masterQueue.pop();
		counter++;

	}

	counter = 0;
	while(!slaveQueue.empty())
	{
		F64* brffer = slaveQueue.front();
		for (vi_s = 0; vi_s < ReadCount; vi_s ++)
		{
			if (vi_s%Channel == 7)
			{
				fprintf(fout_s, "%lf,%lf,%lf,%lf,%lf,%lf,%lf,%lf\n",*(brffer+vi_s -7)
																   ,*(brffer+vi_s -6)
																   ,*(brffer+vi_s -5) 
																   ,*(brffer+vi_s -4)
																   ,*(brffer+vi_s -3)
																   ,*(brffer+vi_s -2)
																   ,*(brffer+vi_s -1)
																   ,*(brffer+vi_s));
				
			}
		}
		delete[] brffer;
		printf("Queue size: %d, write buffer %d\n", slaveQueue.size(), counter);
		slaveQueue.pop();
		counter++;



	}

    fclose(fout_m);
	fclose(fout_s);

	DSA_AI_EventCallBack(card_m, 0, DBEvent, (U32)NULL);
    DSA_AI_EventCallBack(card_m, 0, AIEnd, (U32)NULL);
	DSA_AI_EventCallBack(card_s, 0, DBEvent, (U32)NULL);
    DSA_AI_EventCallBack(card_s, 0, AIEnd, (U32)NULL);

	printf("Done...\n");
	err_ret_withfree:
    //Clear AI Setting and Get Remaining data
    err = DSA_AI_ContBufferReset(card_m);
	if (err!=0) {
		printf("AI_ContBufferReset: %d\n", err);
	}
	err = DSA_AI_ContBufferReset(card_s);
	if (err!=0) {
		printf("AI_ContBufferReset: %d\n", err);
	}
	
		//process boundary value and scale raw to double

err_ret:
	DSA_TRG_SourceClear(card_m); //To disable TrgOut
	DSA_SYN_ConfigMultiCard(card_m, P9529_SYN_Disable, 0); //To disable ClkOut of SSI
	DSA_Release_Card(card_m);  
	DSA_Release_Card(card_s);
	VirtualFree(ppBufferAddr0_m, 0, MEM_RELEASE);
	VirtualFree(ppBufferAddr1_m, 0, MEM_RELEASE);
	VirtualFree(ppScaledVal_m, 0, MEM_RELEASE);
	VirtualFree(ppBufferAddr0_s, 0, MEM_RELEASE);
	VirtualFree(ppBufferAddr1_s, 0, MEM_RELEASE);
	VirtualFree(ppScaledVal_s, 0, MEM_RELEASE);
	printf("Press any key to exit...\n");
    getch();
    return 0;
}