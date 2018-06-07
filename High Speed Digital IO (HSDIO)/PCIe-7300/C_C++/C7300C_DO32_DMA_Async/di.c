/*----------------------------------------------------------------------------*/
/* Company : ADLINK                                                           */
/* Date    : 2015/09/23                                                       */
/*                                                                            */
/* This sample performs continuous DO output.                                 */
/*----------------------------------------------------------------------------*/
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "dask64.h"


int main(int argc, char **argv)
{
    I16 card, err;
    U16 card_num;
    U16 DOPortWidth = 32;
    U32 *Buffer;         
    U32 ReadCount = 1024;
    U32 vi;
    BOOLEAN Stopped = 0;
    U32 AccessCnt = 0;
	U32 count = 1;
	U32 FreqDiv = 1;

    printf("This sample performs continuous DO output\n");
    printf("Card Number? ");
    scanf(" %hd", &card_num);
    printf("Update Count? ");
    scanf(" %ld", &ReadCount);
    printf("SampleRate?(Hz) ");
    scanf(" %ld", &FreqDiv);

    card = Register_Card(PCI_7300A_RevC, card_num);
    if(card<0){
        printf("Register_Card Error: %d\n", card);
        exit(1);
    }

    Buffer = (U32 *)VirtualAlloc(NULL, ReadCount*(DOPortWidth/8), MEM_COMMIT, PAGE_READWRITE);
    memset(Buffer, '\0', ReadCount*(DOPortWidth/8));
	for(vi=0; vi<ReadCount; vi++)
		Buffer[vi]= (U32)(vi%(2^32));
	
    err = DO_7300B_Config (card, DOPortWidth, TRIG_INT_PACER, P7300_WAIT_NO, P7300_TERM_ON, 0, 0x40004000);
    if(err!=NoError){
        printf("DO_7300B_Config Error: %d\n", err);
        Release_Card(card);
        exit(1);
    }

	printf("Press ANYKEY to start DO Operation....\n");
	getch();
    
	err = DO_ContWritePort(card, 0, (void *)Buffer, ReadCount, 1, FreqDiv, ASYNCH_OP);
    if(err!=NoError){
        printf("DI_ContReadPort Error: %d\n", err);
        Release_Card(card);
        VirtualFree(Buffer, 0, MEM_RELEASE);
        exit(1);
    }

    do{
        err = DO_AsyncCheck(card, &Stopped, &AccessCnt);
        if(err!=NoError){
            printf("DO_AsyncCheck Error: %d\n", err);
        }
    }while((!kbhit())&&(!Stopped));

    if(!Stopped){
        getch();
        printf("DO Operation has been stopped manually...\n");
    }
    else
        printf("DO Operation Done\n");

    DO_AsyncClear(card, &AccessCnt);

    printf("Press any key to exit...\n");
    getch();
    Release_Card(card);
    VirtualFree(Buffer, 0, MEM_RELEASE);
    return 0;
}
