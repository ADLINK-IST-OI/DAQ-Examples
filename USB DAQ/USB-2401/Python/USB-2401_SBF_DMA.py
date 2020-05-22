#####################################################################################
# ADLINK USB-2401 to acquire/measure DATA  
# This sample program shows how to import DLL
# AI One shot acquisition for USB-2401
# This sample program run on Python 3.x
# ADLINK Technologies 2020.05.13
#####################################################################################

import os
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

def is_64_windows():
    return 'PROGRAMFILES(X86)' in os.environ
    
def cal_interval(sampling_rate, num_of_channel):
    p190x_timebase = np.uint32(80000000)
    global var_scan_intv
    var_scan_intv = np.uint32(p190x_timebase/(sampling_rate*num_of_channel))


if  is_64_windows():
    dll = WinDLL("USB-Dask64.dll")
    print("On 64 bit OS using USB-Dask64.dll")
else:
    dll = WinDLL("USB-Dask.dll")
    print("On 32 bit OS using USB-Dask.dll")

dll.UD_Register_Card.restype = c_int16
dll.UD_Register_Card.argtypes = [c_uint16,c_uint16]
dll.UD_Release_Card.restype = c_int16
dll.UD_Release_Card.argtypes = [c_uint16]
dll.UD_AI_2401_Config.restype = c_int16
dll.UD_AI_2401_Config.argtypes = [c_uint16, c_uint16, c_uint16, c_uint32, c_uint32, c_uint32]
dll.UD_AI_AsyncDblBufferMode.restype = c_int16
dll.UD_AI_AsyncDblBufferMode.argtypes = [c_uint16, c_bool]
dll.UD_AI_1902_CounterInterval.restype = c_int16
dll.UD_AI_1902_CounterInterval.argtypes = [c_uint16, c_uint32, c_uint32]
dll.UD_AI_ContReadChannel.restype = c_int16
dll.UD_AI_ContReadChannel.argtypes = [c_uint16, c_uint16, c_uint16, POINTER(c_uint16), c_uint32, c_double, c_uint16]
dll.UD_AI_AsyncCheck.restype = c_int16
dll.UD_AI_AsyncCheck.argtypes = [c_uint16, POINTER(c_bool), POINTER(c_uint32)]
dll.UD_AI_AsyncClear.restype = c_int16
dll.UD_AI_AsyncClear.argtypes = [c_uint16, POINTER(c_uint32)]
dll.UD_AI_2401_ContVScale32.restype = c_int16
dll.UD_AI_2401_ContVScale32.argtypes = [c_uint16, c_uint16, c_uint16, POINTER(c_uint32), POINTER(c_double) ,c_uint32]

cfg_card_type = np.int16(0x04) #USB-2401  
cfg_inputtype = np.int16(0x01)#P1902_AI_SingEnded
cfg_convsrc = np.int16(0x00)#P1902_AI_CONVSRC_INT
cfg_trigsrc = np.int16(0x030)#P2401_AI_TRGSRC_SOFT
cfg_trigpolarity = np.int16(0x040)#P1902_AI_TrgPositive
cfg_trigmode = np.int16(0x000)#P2401_AI_TRGMOD_POST
cfg_triglevel = np.int32(0)
cfg_retrigcnt = np.int32(0)
cfg_delaycnt = np.int32(0)
cfg_doublebuf_mode = np.bool_(False)
cfg_num_of_channel = np.int16(1)
cfg_channel_num = np.int16(0)
cfg_sampling_rate = np.int32(2000) #2000 max
cfg_AI_read_cnt = np.int32(1024)
cfg_AD_RANGE = np.int16(36)#AD_B_25_V = 35,AD_B_12_5_V=36
cfg_sync_mode = np.int16(2)#ASYNCH_OP
cfg_chancfg = np.int16(0x00) #P2401_Voltage_2D5V_Above = 0x00, V >=2.5V
                             #P2401_Voltage_2D5V_Above = 0x01, V >=2.5V
var_card = np.int16(-1)
var_card_num = np.int16(0)
var_ret = np.int16(-1)
var_scan_intv = np.int32(320)
var_sample_intv = np.int32(320)

var_Buffer = (c_uint32*cfg_AI_read_cnt)()
var_Buffer_Ptr16 = cast(var_Buffer, POINTER(c_uint16))
var_Buffer_Ptr32 = cast(var_Buffer, POINTER(c_uint32))
var_Vol_Buffer = (c_double*cfg_AI_read_cnt)()
cast(var_Vol_Buffer, POINTER(c_double))

var_card = dll.UD_Register_Card(cfg_card_type,var_card_num)
if var_card < 0:
	print("UD_Register_Card fail, error = %d\n",var_card)
	exit()
print("Register card successfully")

var_ret = dll.UD_AI_2401_Config(var_card \
                               ,cfg_chancfg \
                               ,cfg_chancfg \
                               ,cfg_chancfg \
                               ,cfg_chancfg \
                               ,cfg_trigsrc | cfg_trigmode \
                               )
if var_ret < 0:
    dll.UD_Release_Card(var_card)
    print("UD_AI_1902_Config fail, error = %d\n",var_ret)
    exit()

dll.UD_AI_AsyncDblBufferMode(var_card,cfg_doublebuf_mode)

'''
cal_interval(cfg_sampling_rate,cfg_num_of_channel)
print("scan_intv = ",var_scan_intv,",sample_intv = ",var_sample_intv)

var_ret = dll.UD_AI_1902_CounterInterval(var_card,var_scan_intv,var_sample_intv)
if var_ret < 0:
    dll.UD_Release_Card(var_card)
    print("UD_AI_1902_CounterInterval fail, error = %d\n",var_ret)
    exit()
'''
var_ret = dll.UD_AI_ContReadChannel(var_card,cfg_channel_num,cfg_AD_RANGE,var_Buffer_Ptr16,cfg_AI_read_cnt,cfg_sampling_rate,cfg_sync_mode)
if var_ret < 0:
    dll.UD_Release_Card(var_card)
    print("UD_AI_ContReadChannel fail, error = %d\n",var_ret)
    exit()

print("Start AI");
Stopped = c_bool(False)
AccessCnt = c_uint32()
Startpos = c_uint32()

while Stopped.value == bool(False):
    var_ret = dll.UD_AI_AsyncCheck(var_card,Stopped,AccessCnt)
    if var_ret < 0:
        dll.UD_AI_AsyncClear(var_card,AccessCnt)
        dll.UD_Release_Card(var_card)
        exit()
    if Stopped == True:
        break
    time.sleep(0.01)
    print(".")
    
print("Stop AI")

var_ret = dll.UD_AI_AsyncClear(var_card,AccessCnt)
var_ret = dll.UD_AI_2401_ContVScale32(var_card, cfg_AD_RANGE, 0, var_Buffer, var_Vol_Buffer, cfg_AI_read_cnt)
print("UD_AI_ContVScale ret = ",var_ret)

dll.UD_Release_Card(var_card)
print("Release card successfully")

x = np.arange(0,cfg_AI_read_cnt)

plt.plot(x,var_Vol_Buffer,lw=1)
plt.plot(x,var_Vol_Buffer,"b-")
#plt.plot(x,VBuffer0,"-o")
#plt.plot(x,VBuffer0,"ro")
#plt.plot(x,VBuffer0,"y--")
plt.xlabel("count")
plt.ylabel("Voltage")
plt.title("USB-2401")
plt.ylim(-25,25)
plt.savefig("USB-2401_python_example_result.jpg",dpi=800,format="jpg")
plt.show()

print("Done...");
