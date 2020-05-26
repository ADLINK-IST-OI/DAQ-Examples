#include <windows.h>
#include <stdio.h>
#include <conio.h>
#include "d2kdask.h"

#define PI  3.14159
#define  PatternSize 4096
#define ch_num 4

short pattern1[PatternSize];
short pattern2[PatternSize];
short pattern3[PatternSize];
short pattern4[PatternSize];
short ao_buf[PatternSize*ch_num * 2];


main()
{
    I16 card, err, card_num,i, j;   
	U32 count = 0;    
	U16 DaId, da_ch[ch_num] = { 0, 1, 2, 3 };

	printf("Please input a card number: ");
    scanf(" %hd", &card_num);  
   if((card = D2K_Register_Card(DAQ_2502, card_num))<0) {
	 printf("Error %d trying to open daq2010\n", card);
	 exit(1);
   }
	
   //------------------------------------------------------------------
   for (i = 0; i < PatternSize; i++)  //sine wave
   {
	   pattern1[i] = (U16)((sin((double)(i + 0xBFF) / (PatternSize / 2)*PI) * 0x4FF) + 0x7FF);	  
   }
   //....................................................................
   for (i = 0; i < PatternSize; i++) //Triangle wave 
   {
	   if (i < PatternSize / 2)
		   pattern2[i] = (U16)(0x400 + i % (PatternSize / 2));

	   else
		   pattern2[i] = (U16)(0x400 + 2047 - i % (PatternSize / 2));
   }
   //....................................................................
   for (i = 0; i < PatternSize; i++)  //Pulse  wave
   {
	   if (i < PatternSize / 2)
	   {
		   pattern3[i] = 0x3FF;
	   }
	   else
	   {
		   pattern3[i] = 0xBFF;
	   }
   }
   //....................................................................
   for (i = 0; i < PatternSize; i++)  //Triangle wave
   {	
	  
	   if (i < PatternSize / 2)
		   pattern4[i] = (U16)(0x200+ i%(PatternSize / 2)) ;

	   else
		   pattern4[i] = (U16)(0x200+ 0x7FF -i% (PatternSize / 2)) ;
   }
   //....................................................................
   i = 0;
   for (int k = 0; k < PatternSize*ch_num * 2; k += ch_num * 2)
   {
	   ao_buf[k] = pattern1[i];
	   ao_buf[k + 1] = 0;
	   ao_buf[k + 2] = pattern2[i];
	   ao_buf[k + 3] = 0;
	   ao_buf[k + 4] = pattern3[i];
	   ao_buf[k + 5] = 0;
	   ao_buf[k + 6] = pattern4[i];
	   ao_buf[k + 7] = 0;
	   i++;
   }

   err = D2K_AO_CH_Config(card, All_Channels, DAQ2K_DA_BiPolar, DAQ2K_DA_Int_REF, (F64)10.0);

   err = D2K_AO_Config(card, DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGSRC_SOFT, DAQ2K_DA_TRGSRC_SOFT, 0, 0, 0);

   err = D2K_AO_Group_Setup(card, DA_Group_A, ch_num, da_ch);

   err = D2K_AO_ContBufferSetup(card, ao_buf, PatternSize*ch_num * 2, &DaId);
	
    err = D2K_AO_Group_WFM_Start (card, DA_Group_A, DaId, 0 , 1024 , 100, 400, 0);
    if(err!=NoError){
	   printf("D2K_AO_Group_WFM_Start Error %d \n", err);
	   D2K_AO_ContBufferReset (card);
	   D2K_Release_Card(card);
	   exit(1);
    }
	printf( "Press any key to stop wave form generating !!" );
	do {
	} while (!kbhit());

	
	err = D2K_AO_Group_WFM_AsyncClear(card, DA_Group_A, &count, DAQ2K_DA_TerminateImmediate);
    D2K_Release_Card(card);
    printf("\nPress ENTER to exit the program. "); 
	getch();
}
