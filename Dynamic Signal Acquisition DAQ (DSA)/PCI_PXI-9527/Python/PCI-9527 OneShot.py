#####################################################################################
# ADLINK DAQ-9527 to acquire/measure DATA  
# This sample program shows how to import DLL
# AI One shot acquisition for PCI-9527
# This sample program was built with Python IDLE 3.7.1
# ADLINK Technologies 2018.12.04
#####################################################################################

import sys
import time
import os
import numpy as np
from ctypes import *
u16 = np.dtype(np.uint16)
lib = WinDLL('C:\Windows\SysWOW64\DSA-Dask.dll')

PCI_9527 = np.uint16(1)
SampleRate = c_longdouble(432000.0) #Hz
SampleCount = np.uint32(4096)

card = np.int16(-1)
err = np.int16(-1)
ignore = np.uint16(0)
GetActualRate = c_longdouble()
channel = np.uint16(0) #0 for AI0, 1 for AI1, 2 for AI0+AI1
AIRange = np.uint16(1) #1 for +-10V,
Range = np.uint16(1) #1  AD_B_10_V
AI_Config = np.uint16(1) #1 for P9527_AI_PseudoDifferential|P9527_AI_Coupling_DC; #0 for P9527_AI_Differential|P9527_AI_Coupling_DC
AutoReset = np.bool_(True) #for Auto Reset Buffer
SyncMode = np.uint16(1) #1 for Sync, 2 for Async
BufId = c_uint16()
Buffer0 = (c_uint32*SampleCount)()

lib.DSA_Register_Card.restype = c_int16
lib.DSA_Register_Card.argtypes = [c_uint16,c_uint16]
lib.DSA_AI_9527_ConfigSampleRate.restype = c_int16
lib.DSA_AI_9527_ConfigSampleRate.argtypes = [c_int16,c_longdouble,POINTER(c_longdouble)]
lib.DSA_AI_9527_ConfigChannel.restype = c_int16
lib.DSA_AI_9527_ConfigChannel.argtypes = [c_int16,c_uint16,c_uint16,c_uint16,c_bool]
lib.DSA_AI_AsyncDblBufferMode.restype = c_int16
lib.DSA_AI_AsyncDblBufferMode.argtypes = [c_int16,c_bool]
lib.DSA_AI_ContBufferSetup.restype = c_int16
lib.DSA_AI_ContBufferSetup.argtypes = [c_int16,POINTER(c_uint32),c_uint32,POINTER(c_uint16)]
lib.DSA_AI_ContReadChannel.restype = c_int16
lib.DSA_AI_ContReadChannel.argtypes = [c_int16,c_uint16,c_uint16,POINTER(c_uint16),c_uint32,c_longdouble,c_uint16]
lib.DSA_AI_ContBufferReset.restype = c_int16
lib.DSA_AI_ContBufferReset.argtypes = [c_uint16]
lib.DSA_Release_Card.restype = c_int16
lib.DSA_Release_Card.argtypes = [c_uint16]


card = lib.DSA_Register_Card(PCI_9527, 0)
if card <0:
    print("Register 9527 Fail : ",card)
else:
    err = lib.DSA_AI_9527_ConfigSampleRate(card,SampleRate,pointer(GetActualRate))
    if err < 0:
        print("DSA_AI_9527_ConfigSampleRate err :",err)
    else:
        print("\nSetting Samplerate : ",SampleRate, "\nActully Samplerate : ", GetActualRate,"\n")
        
    err = lib.DSA_AI_9527_ConfigChannel(card, channel, Range, AI_Config, AutoReset)
    if err < 0:
        print("DSA_AI_9527_ConfigChannel err :",err)

    err = lib.DSA_AI_AsyncDblBufferMode(card, 0)
    if err < 0:
        print("DSA_AI_9527_ConfigChannel err :",err)
    
    err = lib.DSA_AI_ContBufferSetup(card, Buffer0, SampleCount, byref(BufId))
    if err < 0:
        print("DSA_AI_ContBufferSetup err :",err)
        
    err = lib.DSA_AI_ContReadChannel(card, channel, ignore, pointer(BufId), SampleCount, ignore, SyncMode)
    if err < 0:
        print("DSA_AI_ContReadChannel err :",err)
        
    print("DSA_AI_ContReadChannel End...")   
    err = lib.DSA_Release_Card(card)
    if err < 0:
        print("DSA_Release_Card err :",err)
        
    print(list(Buffer0))
