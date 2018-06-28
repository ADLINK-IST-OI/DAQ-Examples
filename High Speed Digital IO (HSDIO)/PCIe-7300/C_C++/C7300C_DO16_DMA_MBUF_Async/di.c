/*----------------------------------------------------------------------------*/
/* Company : ADLINK                                                           */
/* Date    : 2015/09/23                                                       */
/*                                                                            */
/* This sample performs multi-buffers continuous DO output.                   */
/*----------------------------------------------------------------------------*/
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "dask64.h"

#define MBufCount 4 //Buffer count to be set

int main(int argc, char **argv)
{
    I16 card, err;
    U16 card_num;
    U16 DIPortWidth = 16;                  //Port Width
    U32 ReadCount = 1024;                 //Data Count to be read
    F64 SampleRate = 10000000;             //Sampling Rate
    U32 vi,vj;
    BOOLEAN Stopped = 0;
    U32 AccessCnt = 0;
    BOOLEAN fwrite = FALSE;
	U32 count = 1;
	U32 FreqDiv = 1;
	U16 *Buffer[MBufCount];                //Buffer to be written
	U16 BufferID[MBufCount];               //Buffer ID returned
    BOOLEAN NextReady = FALSE;
    U16 ReadyBufferId = 0;
	U32 BufRdyCnt = 0;

    printf("This sample performs continuous DO output\n");
    printf("with %lf sample rate.\n\n", SampleRate);
    printf("Card Number? ");
    scanf(" %hd", &card_num);
	printf("Sample Count? ");
    scanf(" %ld", &ReadCount);
    printf("SampleRate?(Hz) ");
    scanf(" %ld", &FreqDiv);

    /*
     * Open and initialize PCIe-7300 Rev.C
     */
    card = Register_Card(PCI_7300A_RevC, card_num);
    if(card<0){
        printf("Register_Card Error: %d\n", card);
        exit(1);
    }

    /*
     * Set DI Configurations
     */
	err = DO_7300B_Config (card, 16, TRIG_INT_PACER, P7300_WAIT_NO, P7300_TERM_ON, 0, 0x40004000);
    if(err!=NoError){
        printf("DI_7350_Config Error: %d\n", err);
        Release_Card(card);
        exit(1);
    }

    for(vi=0; vi<MBufCount; vi++)
	{
        Buffer[vi] = (U16 *)VirtualAlloc(NULL, ReadCount*(DIPortWidth/8), MEM_COMMIT, PAGE_READWRITE);
        for(vj=0; vj<ReadCount; vj++)
            *(Buffer[vi]+vj) = vi*ReadCount+vj;
	}

    for(vi=0; vi<MBufCount; vi++)
	{
        err = DO_ContMultiBufferSetup(card, Buffer[vi], ReadCount, &BufferID[vi]);
        if(err!=NoError)
		{
            printf("DO_ContMultiBufferSetup %d Error: %d\n", vi, err);
            Release_Card(card);
            for(vj=0; vj<MBufCount; vj++)
                VirtualFree(Buffer[vj], 0, MEM_RELEASE);
            exit(1);
        }
		printf("ID allocated: %d\n", BufferID[vi]);
    }

	printf("Press ANYKEY to start output...\n");
	getch();

	err = DO_ContMultiBufferStart(card, 0, FreqDiv);    
    if(err!=NoError){
        printf("DI_ContMultiBufferStart Error: %d\n", err);
		getch();
        Release_Card(card);
        for(vi=0; vi<MBufCount; vi++)
            VirtualFree(Buffer[vi], 0, MEM_RELEASE);
        exit(1);
    }
    do{
        err = DO_AsyncMultiBufferNextReady(card, &NextReady, &ReadyBufferId);
        if(err!=NoError){
            printf("DO_AsyncMultiBufferNextReady Error: %d\n", err);
        }
		if(NextReady){
			BufRdyCnt++;
			printf("Buffer Ready Count: %d, ReadyBufferId: %d\r", BufRdyCnt, ReadyBufferId);
		}
    }while((!kbhit())&&(!Stopped));
	
	printf("Press ANYKEY to stop...\n");
	getch();

    DO_AsyncClear(card, &AccessCnt);

    printf("Press any key to exit...\n");
    getch();
    Release_Card(card);
    for(vi=0; vi<MBufCount; vi++)
        VirtualFree(Buffer[vi], 0, MEM_RELEASE);
    return 0;
}
