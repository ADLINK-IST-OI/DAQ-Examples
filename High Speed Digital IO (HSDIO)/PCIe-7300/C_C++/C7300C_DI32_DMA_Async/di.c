/*----------------------------------------------------------------------------*/
/* Company : ADLINK                                                           */
/* Date    : 2015/09/23                                                       */
/*                                                                            */
/* This sample performs continuous DI acquisition.                            */
/*----------------------------------------------------------------------------*/
#include <windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "Dask64.h"


int main(int argc, char **argv)
{
    I16 card, err;
    U16 card_num;
    U16 DIPortWidth = 32;                  //Port Width
    U32 *Buffer;                           //Buffer to be read
    U32 ReadCount = 1024;                 //Data Count to be read
    F64 SampleRate = 10000000;             //Sampling Rate
    U32 vi;
    BOOLEAN Stopped = 0;
    U32 AccessCnt = 0;
    FILE *fout;
    BOOLEAN fwrite = FALSE;
	U32 count = 1;
	U32 FreqDiv = 1;

    printf("This sample performs continuous DI acquisition\n");
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

    Buffer = (U32 *)VirtualAlloc(NULL, ReadCount*(DIPortWidth/8), MEM_COMMIT, PAGE_READWRITE);
    memset(Buffer, '\0', ReadCount*(DIPortWidth/8));
	
    /*
     * Set DI Configurations
     */
    err = DI_7300B_Config (card, 32, TRIG_INT_PACER, P7300_WAIT_NO, P7300_TERM_ON, P7300_DIREQ_POS, 1, 1);
    if(err!=NoError){
        printf("DI_7350_Config Error: %d\n", err);
        Release_Card(card);
        exit(1);
    }

    /*
     * Perform Continuous DI
     * Note: If the data count is too large, driver may spend some time
     *       to lock memory to avoid memory page-out.
     */
    err = DI_ContReadPort(card, 0, (void *)Buffer, ReadCount, FreqDiv, ASYNCH_OP);
    if(err!=NoError){
        printf("DI_ContReadPort Error: %d\n", err);
        Release_Card(card);
        VirtualFree(Buffer, 0, MEM_RELEASE);
        exit(1);
    }
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
	Sleep(1000);

    printf("\n\nWrite Data to file? [Y]es or [N]o: ");
    scanf(" %c", &fwrite);
    if((fwrite=='y')||(fwrite=='Y')){
        printf("\n\nWrite Data...");
        if((fout = fopen("di_read.txt", "w"))==NULL)
            printf("fopen error: %d\n", GetLastError());
        else{
            for(vi=0; vi<ReadCount; vi++){
                fprintf(fout, "%d\n", *(Buffer+vi));
            }
            fclose(fout);
        }
        printf("\rWrite Data Done...\n\n");
    }

    printf("Press any key to exit...\n");
    getch();
    Release_Card(card);
    VirtualFree(Buffer, 0, MEM_RELEASE);
    return 0;
}
