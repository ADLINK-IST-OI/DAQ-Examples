
#ifndef		_WDDASKEX_H
#define		_WDDASKEX_H

#ifdef __cplusplus
extern "C" {
#endif

#pragma pack(push,1)

typedef struct _DAS_IOT_DEV_PROP
{
		short	card_type;			
		short	num_of_channel;		
		short	data_width;		
		short   default_range;
		unsigned long	ctrKHz;
		unsigned long   bdbase;
		unsigned long   mask;
		unsigned long	reserved[15];

}
DAS_IOT_DEV_PROP;

#pragma pack(pop)

//api for samples
unsigned short __stdcall WD_ChooseDeviceType(unsigned short app); //0: console
short __stdcall WD_GetDeviceProperties (unsigned short wCardNumber, unsigned short type, DAS_IOT_DEV_PROP* cardProp); //0:ai

#ifdef __cplusplus
}
#endif

#endif		//_DAQHEADER_H
