using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace AI_ContDbfDma_Decoder
{
    unsafe class Program
    {
        static void Main(string[] args)
        {

            short err;
            ushort card_num = 0;
            short card;
            uint ReadCount = 60;
            ushort Group = 0; // Load Cell Channel Group
            ushort XMode = DASK.P9524_AI_XFER_DMA;
            ushort ADC_Range = 0;
            ushort ADC_SampRate = DASK.P9524_ADC_60_SPS;
            ushort ConfigCtrl = DASK.P9524_VEX_Range_10V | DASK.P9524_AI_BufAutoReset;
            ushort TrigCtrl = 0;
            uint dwTrigValue = 0;
            ushort GCtr0 = DASK.P9524_CTR_QD0;
            ushort Mode = DASK.P9524_x4_AB_Phase_Decoder;
            ushort Channel = DASK.P9524_AI_LC_CH0;
            byte Stopped = 0;
            byte HalfReady = 0;
            uint AccessCnt;
            int viewidx = 0;
            ushort overrunFlag = 0;
            double ActualRate;
            IntPtr BufPtr1;
            ushort BufID1;
            IntPtr BufPtr2;
            ushort BufID2;
            double[] voltageArray = new double[ReadCount];
            ushort DFStage = 2;
            uint SPKRejThreshold = 16;
            StreamWriter sw = new StreamWriter("acq.csv");

            BufPtr1 = Marshal.AllocHGlobal((int)(sizeof(uint) * (ReadCount)));
            BufPtr2 = Marshal.AllocHGlobal((int)(sizeof(uint) * (ReadCount)));

            card = DASK.Register_Card(DASK.PCI_9524, card_num);
            if (card < 0)
            {
                throw new InvalidOperationException("DSA_Register_Card Fail, error:  " + card);
            }

            //Enable Decoder0
            err = DASK.GPTC_Clear((ushort)card, GCtr0);
            if (err < 0)
            {
                throw new InvalidOperationException("GPTC_Clear Fail, error:  " + err);
            }

            err = DASK.GPTC_Setup((ushort)card, GCtr0, Mode, 0, 0, 0, 0);
            if (err < 0)
            {
                throw new InvalidOperationException("GPTC_Setup Fail, error:  " + err);
            }

            //apply parameter 4 to "2" to combine data to AI
            err = DASK.GPTC_Control((ushort)card, GCtr0, DASK.P9524_CTR_Enable, 2);
            if (err < 0)
            {
                throw new InvalidOperationException("GPTC_Control Fail, error:  " + err);
            }

            err = DASK.AI_AsyncDblBufferMode((ushort)card, true);
            if (err < 0)
            {
                throw new InvalidOperationException("AI_AsyncDblBufferMode Fail, error:  " + err);
            }

            /*In Double Buffer Mode, you should setup two buffers*/
            err = DASK.AI_ContBufferSetup((ushort)card, BufPtr1, ReadCount,out BufID1);
            if (err < 0)
            {
                throw new InvalidOperationException("AI_ContBufferSetup Fail, error:  " + err);
            }

            err = DASK.AI_ContBufferSetup((ushort)card, BufPtr2, ReadCount, out BufID2);
            if (err < 0)
            {
                throw new InvalidOperationException("AI_ContBufferSetup Fail, error:  " + err);
            }

            /*Load Cell Group*/
            /*Set DSP - it is necessary fot Load Cell Group*/
            err = DASK.AI_9524_SetDSP((ushort)card, Channel, DASK.P9524_SPIKE_REJ_ENABLE, DFStage, (ushort)SPKRejThreshold);
            if (err < 0)
            {
                throw new InvalidOperationException("AI_9524_SetDSP Fail, error:  " + err);
            }

            err = DASK.AI_9524_Config((ushort)card, Group, XMode, ConfigCtrl, TrigCtrl, (ushort)dwTrigValue);
            if (err < 0)
            {
                throw new InvalidOperationException("AI_9524_Config Fail, error:  " + err);
            }


            Console.WriteLine("\nPress any key to start AI Infinite Acquisition\n");
            Console.ReadKey(true);
            Console.WriteLine("\nYou can press any key to stop...\n\n");

            err = DASK.AI_ContReadChannel((ushort)card, Channel, ADC_Range, new ushort[] { BufID1 }, ReadCount, ADC_SampRate, DASK.ASYNCH_OP);
            if (err < 0)
            {
                throw new InvalidOperationException("AI_ContReadChannel Fail, error:  " + err);
            }

          
            do
            {
                err = DASK.AI_AsyncDblBufferHalfReady((ushort)card, out HalfReady,out Stopped);
                if (err < 0)
                {
                    throw new InvalidOperationException("AI_AsyncDblBufferHalfReady Fail, error:  " + err);
                }
                System.Threading.Thread.Sleep(1);
                if (HalfReady == 1)
                {
                    if (viewidx == 0)
                    {
                        Console.WriteLine("Buffer 1 HalfReady, Process the data of Buffer 1\n");
                        /*Process buffer 1 data*/
                        DASK.AI_ContVScale((ushort)card, ADC_Range, BufPtr1, voltageArray, (int)ReadCount);
                        for (int j = 0; j < ReadCount; j = j + 2)
                        {
                            //fprintf(fin, "AI0:,%13.9f,2's Complement Decoder Valuse:, %d\n", voltageArray[i], (int)(Buffer1[i + 1] * 256) / 256);
                            sw.WriteLine(voltageArray[j] + "," + (int)(((uint*)(void*)BufPtr1)[j + 1] * 256) / 256);

                        }

                        viewidx = 1;
                        /*Tell the driver you complete the buffer 1 process*/
                        err = DASK.AI_AsyncDblBufferHandled((ushort)card);
                        if (err < 0)
                        {
                            throw new InvalidOperationException("AI_AsyncDblBufferHandled Fail, error:  " + err);

                        }

                    }

                    else
                    {

                        Console.WriteLine("Buffer 2 HalfReady, Process the data of Buffer 2\n");
                        /*Process buffer 2 data*/
                        DASK.AI_ContVScale((ushort)card, ADC_Range, BufPtr2, voltageArray, (int)ReadCount);
                        for (int j = 0; j < ReadCount; j = j + 2)
                        {
                            //fprintf(fin, "AI0:,%13.9f,2's Complement Decoder Valuse:, %d\n", voltageArray[i], (int)(Buffer1[i + 1] * 256) / 256);
                            sw.WriteLine(voltageArray[j] + "," + (int)(((uint*)(void*)BufPtr2)[j + 1] * 256) / 256);

                        }

                        viewidx = 0;
                        /*Tell the driver you complete the buffer 2 process*/
                        err = DASK.AI_AsyncDblBufferHandled((ushort)card);
                        if (err < 0)
                        {
                            throw new InvalidOperationException("AI_AsyncDblBufferHandled Fail, error:  " + err);

                        }
                    }

                    // This function can check if the overrun occurs. If the
                    // function is called, AI_AsyncDblBufferHandled() should
                    // be called to let driver to know user buffer is processed
                    // completely
                    err = DASK.AI_AsyncDblBufferOverrun((ushort)card, 0, out overrunFlag);
                    if (err < 0)
                    {
                        throw new InvalidOperationException("AI_AsyncDblBufferOverrun Fail, error:  " + err);

                    }
                    if (overrunFlag!=0)
                    {
                         Console.WriteLine("OVERRUN:\n"+ overrunFlag);
                         DASK.AI_AsyncDblBufferOverrun((ushort)card, 1, out overrunFlag);
                    }
                }

            } while ( (Stopped==0)&&(Console.KeyAvailable == false));

            DASK.GetActualRate_9524((ushort)card, Group, ADC_SampRate, out ActualRate);
            Console.WriteLine("\n\nGeneral Purpose Channel 0 Acquisition Done in "+ ActualRate + "Hz");
            Console.WriteLine("The acquired data stored in acq.dat\n");

            /*Clear AI setting while existing*/
            err = DASK.AI_AsyncClear((ushort)card, out AccessCnt);
            if (err < 0)
            {
                Console.WriteLine("AI_AsyncClear Error:" + err + "\n");
                DASK.AI_ContBufferReset((ushort)card);
                DASK.Release_Card((ushort)card);
            }


            if ((ConfigCtrl & DASK.P9524_AI_BufAutoReset)==0)
            {
                err = DASK.AI_ContBufferReset((ushort)card);
                if (err < 0)
                {
                    throw new InvalidOperationException("AI_ContBufferReset Fail, error:  " + err);
                }
            }

           DASK.GPTC_Clear((ushort)card, GCtr0);
            
           DASK. Release_Card((ushort)card);

           Console.Write("Press any key to save data . . .");
           sw.Close();
           Console.ReadKey(true);



        }
    }
}
