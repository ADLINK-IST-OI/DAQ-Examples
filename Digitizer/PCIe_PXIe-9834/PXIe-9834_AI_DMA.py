#####################################################################################
# ADLINK PCI/PXI-98x6 to acquire/measure DATA  
# This sample program shows how to import DLL
# AI One shot acquisition for PCI/PXI-98x6
# This sample program was built with Python IDLE 3.7.1
# ADLINK Technologies 2019.08.26
#####################################################################################

import numpy as np
from ctypes import *
import matplotlib.pyplot as plt  #used to pilot chart
#if not installed , use following command to install
#python -m pip install -U pip setuptools
#python -m pip install matplotlib
#also use python -m pip install pillow to save image

import time
u16 = np.dtype(np.uint16)
F64 = np.dtype(np.float64)

def twos_comp(val, bits):
    """compute the 2's complement of int value val"""
    if (val & (1 << (bits - 1))) != 0: # if sign bit is set e.g., 8bit: 128-255
        val = val - (1 << bits)        # compute negative value
    return val 

#for cdecl
#dll = CDLL("WD-Dask.dll")
#for stdcall
#dll = WinDLL("WD-Dask.dll") 

#for x32
#dll = WinDLL("WD-Dask.dll") 
#for x64
dll = WinDLL("WD-Dask64.dll") 

card_type_PXIe_9834H = np.int16(0x39)

cfg_All_Channels = np.int16(-1)
cfg_TimeBase_WD_ExtTimeBase = np.int16(0x0)
cfg_TimeBase_WD_SSITimeBase = np.int16(0x1)
cfg_TimeBase_WD_IntTimeBase = np.int16(0x3)
cfg_ConvSrc_WD_AI_ADCONVSRC_TimePacer = np.int16(0)
cfg_ADRange_AD_B_10_V = np.int16(1)
cfg_ADRange_AD_B_5_V = np.int16(2)
cfg_ADRange_AD_B_1_V = np.int16(10)
cfg_TrigMod_WD_AI_TRGMOD_POST = np.int16(0x00)
cfg_TrigMod_WD_AI_TRGMOD_PRE = np.int16(0x01)
cfg_TrigMod_WD_AI_TRGMOD_MIDL = np.int16(0x02)
cfg_TrigMod_WD_AI_TRGMOD_DELAY = np.int16(0x03)
cfg_TrigSrc_WD_AI_TRGSRC_SOFT = np.int16(0x00)
cfg_TrigSrc_WD_AI_WD_AI_TRGSRC_ANA = np.int16(0x01)
cfg_TrigSrc_WD_AI_WD_AI_TRGSRC_ExtD = np.int16(0x02)
cfg_TrigPol_WD_AI_TrgPositive = np.int16(0x01)
cfg_TrigPol_WD_AI_TrgNegative = np.int16(0x00)
cfg_SyncMode_SYNCH_OP = np.int16(1);
cfg_SyncMode_ASYNCH_OP = np.int16(2);

param_AI_IMPEDANCE = np.int16(1)
param_IMPEDANCE_50Ohm = np.int16(0)
param_IMPEDANCE_HI	= np.int16(1)

anaTrigchan = np.int16(0);
anaTriglevel = np.float64(0.0);
postTrigScans = np.uint32(0);
preTrigScans = np.uint32(0);
trigDelayTicks = np.uint32(0);
reTrgCnt = np.uint32(1);
AI_ReadCount = np.int32(80000);
ScanIntrv = np.int32(1);
SampIntrv = np.int32(1);

card = np.int16(-1)
ret = np.int16(-1)
card_num = np.int16(0)
channel = np.uint16(0)
BufId = c_uint16()
Stopped = c_bool()
AccessCnt = c_uint32()
Startpos = c_uint32()
#Buffer0 = (c_uint32*AI_ReadCount)()
Buffer0 = POINTER(c_uint16*AI_ReadCount)()
VBuffer0 = (c_double*AI_ReadCount)()
cast(VBuffer0, POINTER(c_double))

AutoReset = np.bool_(True) #for Auto Reset Buffer


dll.WD_Register_Card.restype = c_int16
dll.WD_Register_Card.argtypes = [c_uint16,c_uint16]
dll.WD_AI_CH_Config.restype = c_int16
dll.WD_AI_CH_Config.argtypes = [c_int16,c_uint16,c_uint16]
dll.WD_AI_Config.restype = c_int16
dll.WD_AI_Config.argtypes = [c_int16,c_uint16,c_bool,c_uint16,c_bool,c_bool]
dll.WD_AI_Trig_Config.restype = c_int16
dll.WD_AI_Trig_Config.argtypes = [c_uint16,c_uint16,c_uint16,c_uint16,c_uint16,c_double,c_uint32,c_uint32,c_uint32,c_uint32]
dll.WD_AI_CH_ChangeParam.restype = c_int16
dll.WD_AI_CH_ChangeParam.argtypes = [c_uint16,c_uint16,c_uint16,c_uint16]
dll.WD_Buffer_Alloc.restype = POINTER(c_uint16)
dll.WD_Buffer_Alloc.argtypes = [c_uint16,c_uint32]
dll.WD_AI_ContBufferSetup.restype = c_int16
dll.WD_AI_ContBufferSetup.argtypes = [c_int16,POINTER(c_uint16),c_uint32,POINTER(c_uint16)]
dll.WD_AI_ContReadChannel.restype = c_int16
dll.WD_AI_ContReadChannel.argtypes = [c_uint16,c_uint16,c_uint16,c_uint32,c_uint32,c_uint32,c_uint16]
dll.WD_AI_ContReadMultiChannels.restype = c_int16
dll.WD_AI_ContReadMultiChannels.argtypes = [c_uint16,c_uint16,POINTER(c_uint16),c_uint16,c_uint32,c_uint32,c_uint32,c_uint16]
dll.WD_AI_AsyncCheck.restype = c_int16
dll.WD_AI_AsyncCheck.argtypes = [c_uint16,POINTER(c_bool),POINTER(c_uint32)]
dll.WD_AI_AsyncClear.restype = c_int16
dll.WD_AI_AsyncClear.argtypes = [c_uint16,POINTER(c_uint32),POINTER(c_uint32)]
dll.WD_AI_ContBufferReset.restype = c_int16
dll.WD_AI_ContBufferReset.argtypes = [c_uint16]
dll.WD_AI_ContVScale.restype = c_int16
dll.WD_AI_ContVScale.argtypes = [c_uint16,c_uint16,POINTER(c_uint16),POINTER(c_double),c_int32]
dll.WD_Release_Card.restype = c_int16
dll.WD_Release_Card.argtypes = [c_uint16]

card = dll.WD_Register_Card(card_type_PXIe_9834H,card_num)

print("card = ",card)
if card < 0:
	print("Register card fail\n")
	exit()
print("Register card sucess\n")
ret = dll.WD_AI_CH_Config(card,cfg_All_Channels,cfg_ADRange_AD_B_10_V)
print("Channel configuraton result is ", ret, "\n")
ret = dll.WD_AI_Config(card,cfg_TimeBase_WD_IntTimeBase,np.bool_(True),cfg_ConvSrc_WD_AI_ADCONVSRC_TimePacer,0,AutoReset)
print("AI configuraton result is ", ret, "\n")
ret = dll.WD_AI_Trig_Config(card \
                            ,cfg_TrigMod_WD_AI_TRGMOD_POST \
							,cfg_TrigSrc_WD_AI_TRGSRC_SOFT \
							,cfg_TrigPol_WD_AI_TrgPositive \
							,anaTrigchan \
							,anaTriglevel \
							,postTrigScans \
							,preTrigScans \
							,trigDelayTicks \
							,reTrgCnt)
print("Trig configuraton result is ", ret, "\n")
ret = dll.WD_AI_CH_ChangeParam(card,0,param_AI_IMPEDANCE,param_IMPEDANCE_HI)
print("Setup input impedence result is ", ret, "\n")
Buffer0 = dll.WD_Buffer_Alloc(card,AI_ReadCount*2)
print("Buffer0 -- ",Buffer0,"\n");
ret = dll.WD_AI_ContBufferSetup(card,Buffer0,AI_ReadCount,BufId)
print("Buffer setup result is ", ret, "\n")
ret = dll.WD_AI_ContReadChannel (card, channel,BufId, AI_ReadCount, ScanIntrv, SampIntrv, cfg_SyncMode_ASYNCH_OP)
print("ContReadChannel result is ", ret, "\n")

print('Start AI\n');
Stopped = c_bool(False)

while Stopped.value == bool(False):
	ret = dll.WD_AI_AsyncCheck(card,Stopped,AccessCnt)
	#print("ret = ",ret,"Stopped = ",Stopped,"\n")
	if ret < 0:
		#release
		dll.WD_AI_AsyncClear(card,Startpos,AccessCnt)
		dll.WD_AI_ContBufferReset(card)
		dll.WD_Release_Card(card)
		exit()
	if Stopped == True:
		break;
	time.sleep(0.01)	
print('Stop AI\n');

ret = dll.WD_AI_AsyncClear(card,Startpos,AccessCnt)
print("Async clear , ret = ",ret,", Startpos = ",Startpos,", AccessCnt = ",AccessCnt,"\n")

ret = dll.WD_AI_ContVScale(card, cfg_ADRange_AD_B_1_V, Buffer0, VBuffer0, AI_ReadCount)
print("AI ContVScale result = ",ret,"\n")
dll.WD_Release_Card(card)

#print(list(Buffer0))

#for i in range(0,AI_ReadCount) :
#	print(VBuffer0[i] , " ")
x = np.arange(0,AI_ReadCount)

#plt.plot(x,VBuffer0,lw=3)
plt.plot(x,VBuffer0,"b-")
#plt.plot(x,VBuffer0,"-o")
#plt.plot(x,VBuffer0,"ro")
#plt.plot(x,VBuffer0,"y--")
plt.xlabel("count")
plt.ylabel("Voltage")
plt.title("PXIe-9834")
plt.ylim(-1,1)
plt.savefig("9x86_python_example_result.jpg",dpi=300,format="jpg")
plt.show()


