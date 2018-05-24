#include <windows.h>
#include <stdio.h>
#include <conio.h>
#include "C:\ADLINK\WD-DASK\Include\WD-dask.h"
#include "C:\ADLINK\WD-DASK\Include\wddaskex.h"


#define CHANNELNUMBER All_Channels
#define MAXCHANNELCOUNT 4
#define SCANCOUNT     65536000
#define TIMEBASE      WD_IntTimeBase
#define ADTRIGSRC     WD_AI_TRGSRC_SOFT
#define ADTRIGMODE    WD_AI_TRGMOD_POST
#define ADTRIGPOL     WD_AI_TrgNegative
#define BUFAUTORESET  1
#define SCAN_INTERVAL 1

U16 ai_buf[SCANCOUNT*MAXCHANNELCOUNT];
void show_channel_data(U16 *buf);
DAS_IOT_DEV_PROP cardProp;
U16 chcnt=2, ai_range=0;
I16 card = 0;
void main()
{
    I16 err, card_num, Id;
    BOOLEAN fStop=0;
	U32 count=0, startPos=0, sdramsize=0;
	U16 card_type = 1;
	double take_msec = 0.0,take_msec_total = 0.0;
	unsigned int memcount = 0,uiDataCount = 0;
	unsigned long ultestcount = 0;
	 U16 loopcount = 5;
	U16 j ;
	LARGE_INTEGER freq, start_count, current_count;
    //printf("This program inputs %d scans for all channels.\n", SCANCOUNT);

	card_type = WD_ChooseDeviceType(0);
	printf("Please input a card number: ");
    scanf(" %hd", &card_num);
    if ((card=WD_Register_Card (card_type, card_num)) <0 ) {
        printf("Register_Card error=%d", card);
        exit(1);
    }
	WD_GetDeviceProperties (card, 0, &cardProp);
	chcnt = cardProp.num_of_channel;
	ai_range = cardProp.default_range;

	printf("Please Input the number of memory for test (units in MB; Max. 500MB).\n");
    scanf(" %hd", &memcount);
    if(memcount > 500);
		memcount = 500;
	uiDataCount = (unsigned long)((memcount/2)/4)*1048576;
	printf("\nPXI-98x6 Throuput Test Program - Transfer size = %d MB...\n",memcount);
	printf("-------------------------------------------------------------------\n");
	printf("Press any key to STOP...\n");
    //for( j = 0;j<loopcount;++j)
	do{
		++ultestcount;
		err = WD_AI_CH_Config (card, CHANNELNUMBER, ai_range);
		if (err!=NoError) {
		   printf("WD_AI_CH_Config error=%d", err);
		   exit(1);
		}
		err = WD_AI_Config (card, TIMEBASE, 1, WD_AI_ADCONVSRC_TimePacer, 0, BUFAUTORESET);
		if (err!=0) {
		   printf("WD_AI_Config error=%d", err);
		   exit(1);
		}
		err = WD_AI_Trig_Config (card, ADTRIGMODE, ADTRIGSRC, ADTRIGPOL, 0, 0.0, 0, 0, 0, 1);
		if (err!=0) {
		   printf("WD_AI_Trig_Config error=%d", err);
		   exit(1);
		}
		err = WD_AI_Set_Mode (card, DAQSTEPPED, 1);
		err=WD_AI_ContBufferSetup (card, ai_buf, uiDataCount*chcnt, &Id);
		if (err!=0) {
		   printf("WD_AI_ContBufferSetup 0 error=%d", err);
		   exit(1);
		}
		err = WD_AI_ContScanChannels (card, (chcnt-1), Id, uiDataCount, SCAN_INTERVAL, SCAN_INTERVAL, ASYNCH_OP);
		if (err!=0) {
		   printf("AI_ContScanChannels error=%d", err);
		   exit(1);
		}
		do {
			WD_AI_ConvertCheck(card, &fStop);
		} while (!fStop);
		//DAQ conversion stopped
		WD_AI_DMA_Transfer (card, Id);
		QueryPerformanceFrequency(&freq);
		QueryPerformanceCounter(&start_count);
		do {
			WD_AI_AsyncCheck(card, &fStop, &count);
		} while (!fStop);
		QueryPerformanceCounter(&current_count);
		take_msec =((double)(current_count.QuadPart-start_count.QuadPart))/freq.QuadPart*1000;
		   printf("[%d] : %4.3f MB/s \n",ultestcount,(memcount/take_msec)*1000);
		   take_msec_total += take_msec;
		//DMA transfer stop
		//show_channel_data(ai_buf);
		WD_AI_AsyncClear(card, &startPos, &count);    
	}while(!kbhit());
	//take_msec_total /= loopcount;
	take_msec_total /= ultestcount;
	printf("--------------------------------------\n");
	printf("[Average] : %4.3f MB/s \n",(memcount/take_msec_total)*1000);
    err = WD_Release_Card(card);
    printf("\nPress ENTER to exit the program. "); getch();
}

void show_channel_data( U16 *buf)
{
  int k, j;
  char c;
  U32 i, totalcnt = chcnt*SCANCOUNT;
  F64 vol = 0.0;

  printf(" >>>>>>>>>>>>>>> the valid scans  <<<<<<<<<<<<<<< \n");
  for(i=0;i<chcnt;i++)
	printf("    Ch%d        ", i);
  printf("\n");
  for (k=0; k<totalcnt/80; k++) {
   for( i=0+k*80; i<80+k*80 ; i=i+chcnt ){
	   for(j=0;j<chcnt;j++)
	   {   
		   WD_AI_VoltScale (card, ai_range, ai_buf[i+j], &vol);
		   printf(" %04x(%4.4fV) ", (U16) (ai_buf[i+j]&cardProp.mask), vol);
	   }
	   printf("\n");
   }
   printf("Press 'q' to EXIT or any other key for the continued data...\n");
   c=getch();
   if(c=='q')
	   return;
  }
}
