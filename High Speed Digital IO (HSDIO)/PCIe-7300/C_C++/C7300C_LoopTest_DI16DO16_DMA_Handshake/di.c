/*----------------------------------------------------------------------------*/
/* Company : ADLINK                                                           */
/* Date    : 2015/09/23                                                       */
/*                                                                            */
/* This sample performs continuous DI/DO with handshake of 7300 Rev.C .       */
/*----------------------------------------------------------------------------*/
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "dask64.h"

#define PI          3.14159

int main(int argc, char **argv)
{
    I16 card, err;
    U16 card_num;
    U16 DIPortWidth = 16;                  //Port Width
	U16 DOPortWidth = 16;                  //Port Width
    U16 DIMode = P7350_FreeRun;            //DI Mode
    U16 DIWaitStatus = P7350_WAIT_NO;      //No Wait Trigger
    U16 DIClkConfig = P7350_IntSampledCLK; //Internal Conversion Clock
    U16 *Buffer_I, *Buffer_O;                           //Buffer to be read
    U32 ReadCount = 1024;                 //Data Count to be read
    F64 SampleRate = 10000000;             //Sampling Rate
    U32 vi;
    BOOLEAN Stopped = 0;
    U32 AccessCnt = 0;
    FILE *fout;
    BOOLEAN fwrite = FALSE;
	U32 count = 1;

    printf("This sample performs continuous DI acquisition\n");
    printf("with %lf sample rate.\n\n", SampleRate);
    printf("Card Number? ");
    scanf(" %hd", &card_num);
    printf("Sample Count? ");
    scanf(" %ld", &ReadCount);

    /*
     * Open and initialize PCIe-7300
     */
    card = Register_Card(PCI_7300A_RevC, card_num);
    if(card<0){
        printf("Register_Card Error: %d\n", card);
        exit(1);
    }

    Buffer_I = (U16 *)VirtualAlloc(NULL, ReadCount*(DIPortWidth/8), MEM_COMMIT, PAGE_READWRITE);
    memset(Buffer_I, '\0', ReadCount*(DIPortWidth/8));
    Buffer_O = (U16 *)VirtualAlloc(NULL, ReadCount*(DOPortWidth/8), MEM_COMMIT, PAGE_READWRITE);
	for(vi=0; vi<ReadCount; vi++)
		Buffer_O[vi]= (U16)(vi%65536);

    err = DI_7300B_Config (card, 16, TRIG_HANDSHAKE, P7300_WAIT_NO, P7300_TERM_ON, P7300_DIREQ_POS|P7300_DIACK_POS|P7300_DOTRIG_POS, 1, 1);
    if(err!=NoError){
        printf("DI_7350_Config Error: %d\n", err);
        Release_Card(card);
        exit(1);
    }
    err = DO_7300B_Config (card, 16, TRIG_HANDSHAKE, P7300_WAIT_NO, P7300_TERM_ON, P7300_DOREQ_POS|P7300_DOACK_POS|P7300_DOTRIG_POS, 0x40004000);
    if(err!=NoError){
        printf("DO_7300B_Config Error: %d\n", err);
        Release_Card(card);
        exit(1);
    }

    err = DI_ContReadPort(card, 0, (void *)Buffer_I, ReadCount, 1, ASYNCH_OP);
    if(err!=NoError){
        printf("DI_ContReadPort Error: %d\n", err);
        Release_Card(card);
        VirtualFree(Buffer_I, 0, MEM_RELEASE);
		VirtualFree(Buffer_O, 0, MEM_RELEASE);
        exit(1);
    }

	err = DO_ContWritePort (card, 0, (void *)Buffer_O, ReadCount, 1, 1, ASYNCH_OP);
    if(err!=NoError){
        printf("DO_ContWritePort Error: %d\n", err);
        Release_Card(card);
        VirtualFree(Buffer_I, 0, MEM_RELEASE);
		VirtualFree(Buffer_O, 0, MEM_RELEASE);
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
        printf("\n\nDO Operation has been stopped manually...");
    }
    else
        printf("\n\nDO Operation Done");
    DO_AsyncClear(card, &AccessCnt);

	do{
        err = DI_AsyncCheck(card, &Stopped, &AccessCnt);
        if(err!=NoError){
            printf("DI_AsyncCheck Error: %d\n", err);
        }
    }while((!kbhit())&&(!Stopped));
    if(!Stopped){
        getch();
        printf("\n\nDI Operation has been stopped manually...");
    }
    else
        printf("\n\nDI Operation Done");

    DI_AsyncClear(card, &AccessCnt);
	
    printf("\n\nWrite Data to file? [Y]es or [N]o: ");
    scanf(" %c", &fwrite);
    if((fwrite=='y')||(fwrite=='Y')){
        printf("\n\nWrite Data...");
        if((fout = fopen("di_read.txt", "w"))==NULL)
            printf("fopen error: %d\n", GetLastError());
        else{
            for(vi=0; vi<ReadCount; vi++){
                fprintf(fout, "%d\n", *(Buffer_I+vi));
            }
            fclose(fout);
        }
        printf("\rWrite Data Done...\n\n");
    }

    printf("Press any key to exit...\n");
    getch();
    Release_Card(card);
    VirtualFree(Buffer_I, 0, MEM_RELEASE);
	VirtualFree(Buffer_O, 0, MEM_RELEASE);
    return 0;
}