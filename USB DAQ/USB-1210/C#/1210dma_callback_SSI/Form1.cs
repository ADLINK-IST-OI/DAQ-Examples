using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _210dma
{
    public partial class Form1 : Form
    {
        //ushort wModuleNum;
        //ushort wSelModuleID;
        short Module_Num1, Module_Num2;
        USBDAQ_DEVICE[] AvailModules = new USBDAQ_DEVICE[USBDASK.MAX_USB_DEVICE];
        uint dwDataNum = 10240;
        ushort wSelectedChans = 4;
        double dSamplerate = 2000000.0;
        CallbackDelegate m_delegate;
        IntPtr m_data_buffer, m_data_buffer2;
        int alloc = 0;
        Graphics gr;
        SolidBrush blackBrush;
        Rectangle PanelRect;

        public Form1()
        {
            InitializeComponent();

            Module_Num1 = -1;
            Module_Num2 = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            short err;
            
            m_delegate = new CallbackDelegate(Callback);
            gr = pbxDisplay.CreateGraphics();

            blackBrush = new SolidBrush(Color.Black);
            // Create rectangle.
            PanelRect = new Rectangle(0, 0, pbxDisplay.Width, pbxDisplay.Height);
           
            
            TXT_SAMPLERATE.Text = dSamplerate.ToString();
            TXT_DATACOUNT.Text = dwDataNum.ToString();
            Module_Num1 = USBDASK.UD_Register_Card(USBDASK.USB_1210, 0);
            if (Module_Num1 < 0)
            {
                MessageBox.Show("Register card Fail, Code:" + Module_Num1.ToString());
                Close();
                return;
            }
            Module_Num2 = USBDASK.UD_Register_Card(USBDASK.USB_1210, 1);
            if (Module_Num2 < 0)
            {
                MessageBox.Show("Register card Fail, Code:" + Module_Num2.ToString());
                Close();
                return;
            }
          
            tbxYup.Text = "10V";
            tbxYdown.Text = "-10V";
            textYZero.Text = "0V";
            pbxDisplay.BackColor = Color.Black;

            err = USBDASK.UD_DIO_Config((ushort)Module_Num1, USBDASK.GPTC0_GPO1, USBDASK.GPTC2_GPO3);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_DIO_Config error = :" + err.ToString());
                Close();
                return;
            }

            err = USBDASK.UD_GPTC_Setup_N((ushort)Module_Num1, 0, USBDASK.ContGatedPulseGen, USBDASK.GPTC_GATE_SRC_Int, 0x00, 40, 40, 1);
            if (err < 0)
            {
                MessageBox.Show(string.Format("UD_GPTC_Setup_N Error: {0}", err));
                return;
            }
            err = USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntUpDnCTR, 0);
            if (err < 0)
            {
                MessageBox.Show(string.Format("UD_GPTC_Control IntUpDnCTR Error: {0}", err));
                return;
            }

            // Added on 2018/2/27 Ming-Yen
            USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntGate, 1);
            if (err < 0)
            {
                MessageBox.Show(string.Format("UD_GPTC_Control IntGate Error: {0}", err));
                return;
            }
            // Added on 2018/2/27 Ming-Yen
            // The 80M / 40 = 2MHz Clock will be sent out when IntEnable is set to 1
            // The 80M / 40 = 2MHz Clock will be stopped when IntEnable is set to 0
            err = USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntENABLE, 0);
            if (err < 0)
            {
                MessageBox.Show(string.Format("UD_GPTC_Control IntENABLE Error: {0}", err));
                return;
            }
            btnGPO0.Text = "GPO0 2MHz OFF";

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            short err;
            uint AccessCnt;

            // gr.Dispose();

            if (Module_Num1 != -1)
                err = USBDASK.UD_AI_AsyncClear((ushort)Module_Num1, out AccessCnt);


            if (Module_Num2 != -1)
                err = USBDASK.UD_AI_AsyncClear((ushort)Module_Num2, out AccessCnt);


            Marshal.FreeHGlobal(m_data_buffer);
            Marshal.FreeHGlobal(m_data_buffer2);

            // Added on 2018/2/27 Ming-Yen
            // The 80M / 40 = 2MHz Clock will be sent out when IntEnable is set to 1
            // The 80M / 40 = 2MHz Clock will be stopped when IntEnable is set to 0
            err = USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntENABLE, 0);
            if (err < 0)
            {
                MessageBox.Show(string.Format("UD_GPTC_Control IntENABLE Error: {0}", err));
                return;
            }
            // Added on 2018/2/27 Ming-Yen
            err = USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntGate, 0);
            if (err < 0)
            {
                MessageBox.Show(string.Format("UD_GPTC_Control IntGate Error: {0}", err));
                return;
            }
            //btnGPO0.Text = "GPO0 2MHz OFF";

            if (Module_Num1 != -1)
            {
                USBDASK.UD_Release_Card((ushort)Module_Num1);
            }
            if (Module_Num2 != -1)
            {
                USBDASK.UD_Release_Card((ushort)Module_Num2);
            }
        }

        private void Callback()
        {
            short err;
            uint dwAccessCnt;

            err = USBDASK.UD_AI_AsyncClear((ushort)Module_Num1, out dwAccessCnt);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_AsyncClear error = " + err.ToString());
                return;
            }

            err = USBDASK.UD_AI_AsyncClear((ushort)Module_Num2, out dwAccessCnt);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_AsyncClear error = " + err.ToString());
                return;
            }
            GPO0Close();
            PlotData(); 
        }

        // Added on 2018/2/27 Ming-Yen
        private void btnGPO0_Click(object sender, EventArgs e)
        {
            short err;
            // Added on 2018/2/27 Ming-Yen
            // The 80M / 40 = 2MHz Clock will be sent out when IntEnable is set to 1
            // The 80M / 40 = 2MHz Clock will be stopped when IntEnable is set to 0
            if (btnGPO0.Text == "GPO0 2MHz OFF")
            {
                err = USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntENABLE, 1);
                if (err < 0)
                {
                    MessageBox.Show(string.Format("UD_GPTC_Control IntENABLE Error: {0}", err));
                    return;
                }
                btnGPO0.Text = "GPO0 2MHz ON";
            }
            else
            {
                err = USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntENABLE, 0);
                if (err < 0)
                {
                    MessageBox.Show(string.Format("UD_GPTC_Control IntENABLE Error: {0}", err));
                    return;
                }
                btnGPO0.Text = "GPO0 2MHz OFF";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            short err;
            ushort i;
            int nBufSize;

            ushort[] ChanArray = new ushort[wSelectedChans];
            ushort[] GainArray = new ushort[wSelectedChans];

            dwDataNum = Convert.ToUInt32(TXT_DATACOUNT.Text);

            nBufSize = sizeof(short) * Convert.ToInt32(dwDataNum) * wSelectedChans;
            m_data_buffer = Marshal.AllocHGlobal(nBufSize);
            m_data_buffer2 = Marshal.AllocHGlobal(nBufSize);
           

            // Configure AI Channel
            err = USBDASK.UD_AI_Channel_Config((ushort)Module_Num1, USBDASK.UD_AI_Differential, USBDASK.UD_AI_Differential, USBDASK.UD_AI_Differential, USBDASK.UD_AI_Differential);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_Channel_Config error = " + err.ToString());
                Close();
                return;
            }
            err = USBDASK.UD_AI_Channel_Config((ushort)Module_Num2, USBDASK.UD_AI_Differential, USBDASK.UD_AI_Differential, USBDASK.UD_AI_Differential, USBDASK.UD_AI_Differential);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_Channel_Config error = :" + err.ToString());
                Close();
                return;
            }

            err = USBDASK.UD_AI_Trigger_Config((ushort)Module_Num1, USBDASK.UD_AI_CONVSRC_EXT, USBDASK.UD_AI_TRGMOD_POST, USBDASK.UD_AI_TRGSRC_SOFT, 0, 0, 0, 0);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_Trigger_Config error = " + err.ToString());
                Close();
                return;
            }
            err = USBDASK.UD_AI_Trigger_Config((ushort)Module_Num2, USBDASK.UD_AI_CONVSRC_EXT, USBDASK.UD_AI_TRGMOD_POST, USBDASK.UD_AI_TRGSRC_SOFT, 0, 0, 0, 0);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_Trigger_Config error = :" + err.ToString());
                Close();
                return;
            }

            // Disable double-buffer
            err = USBDASK.UD_AI_AsyncDblBufferMode((ushort)Module_Num1, false);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_AsyncDblBufferMode error = " + err.ToString());
                Close();
                return;
            }
            err = USBDASK.UD_AI_AsyncDblBufferMode((ushort)Module_Num2, false);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_AsyncDblBufferMode error = :" + err.ToString());
                Close();
                return;
            }

            err = USBDASK.UD_AI_EventCallBack_x64((ushort)Module_Num1, 1, USBDASK.AIEnd, m_delegate);
            if (err < 0)
            {
                MessageBox.Show("UD_AI_EventCallBack error = " + err.ToString());
                Close();
                return;
            }

            // Prepare the Channel Gain Queue
            for (i = 0; i < wSelectedChans; i++)
            {
                ChanArray[i] = i;
                GainArray[i] = USBDASK.AD_B_10_V;
            }

            dSamplerate = Convert.ToDouble(TXT_SAMPLERATE.Text);

            err = USBDASK.UD_AI_ContReadMultiChannels((ushort)Module_Num1, wSelectedChans, ChanArray, GainArray, m_data_buffer, dwDataNum * wSelectedChans, dSamplerate, USBDASK.ASYNCH_OP);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_ContReadMultiChannels error = " + err.ToString());
                Close();
                return;
            }
            err = USBDASK.UD_AI_ContReadMultiChannels((ushort)Module_Num2, wSelectedChans, ChanArray, GainArray, m_data_buffer2, dwDataNum * wSelectedChans, dSamplerate, USBDASK.ASYNCH_OP);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_ContReadMultiChannels error = " + err.ToString());
                Close();
                return;
            }

            GPO0Clk();           
        }

        private void GPO0Clk()
        {
            short err;
            err = USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntENABLE, 1);
            if (err < 0)
            {
                MessageBox.Show(string.Format("UD_GPTC_Control IntENABLE Error: {0}", err));
                return;
            }
        }

        private void GPO0Close()
        {
            short err;
            err = USBDASK.UD_GPTC_Control((ushort)Module_Num1, 0, USBDASK.IntENABLE, 0);
            if (err < 0)
            {
                MessageBox.Show(string.Format("UD_GPTC_Control IntENABLE Error: {0}", err));
                return;
            }
        }

        private void PlotData()
        {
            float fScaleX, fScaleY, fMidY;
            ushort Cur_Channel, index;
            short I16Temp;
            ushort U16Temp;
            Point[] PointArray = new Point[dwDataNum];
            Point[] PointArray2 = new Point[dwDataNum];
            Pen[] penArray = new Pen[8] { Pens.Yellow, Pens.LightGreen, Pens.Blue, Pens.Red, Pens.Violet, Pens.ForestGreen, Pens.DarkBlue, Pens.Olive };

            // Fill rectangle to screen.
            gr.FillRectangle(blackBrush, PanelRect);

            fScaleX = (float)pbxDisplay.Width / (float)PointArray.Length;
            fScaleY = ((float)pbxDisplay.Height * (float)0.97) / (float)65536.0;
            fMidY = (float)pbxDisplay.Height / 2;


            for (Cur_Channel = 0; Cur_Channel < wSelectedChans; Cur_Channel++)
            {
                // The unsafe section where byte pointers are used.
                unsafe
                {
                    ushort* AiBuf = (ushort*)m_data_buffer.ToPointer();
                    ushort* AiBuf2 = (ushort*)m_data_buffer2.ToPointer();

                    for (index = 0; index < dwDataNum; index++)
                    {
                        U16Temp = (AiBuf[index * wSelectedChans + Cur_Channel]);
                        I16Temp = (short)U16Temp;
                        PointArray[index].X = (int)(index * fScaleX);
                        PointArray[index].Y = (int)(fMidY - I16Temp * fScaleY);

                        U16Temp = (AiBuf2[index * wSelectedChans + Cur_Channel]);
                        I16Temp = (short)U16Temp;
                        PointArray2[index].X = (int)(index * fScaleX);
                        PointArray2[index].Y = (int)(fMidY - I16Temp * fScaleY);
                    }
                }// unsafe              
                gr.DrawLines(penArray[Cur_Channel], PointArray);
                gr.DrawLines(penArray[Cur_Channel+4], PointArray2);
            }
           SaveData();      
        }

        private void SaveData()
        {
            string fileName = "C:\\ADLINK\\UDASK\\Data\\Mode1.csv";
            string fileName2 = "C:\\ADLINK\\UDASK\\Data\\Mode2.csv";
            Directory.CreateDirectory("C:\\ADLINK\\UDASK\\Data");
            FileStream myStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            FileStream myStream2 = new FileStream(fileName2, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(myStream);
            StreamWriter sw2 = new StreamWriter(myStream2);
            ushort U16Temp;
            short I16Temp;
            ushort Cur_Channel, index;        
            string Sdata = string.Empty;
            List<string> pdata = new List<string>();
            List<string> pdata2 = new List<string>();

            unsafe
            {
                ushort* AiBuf = (ushort*)m_data_buffer.ToPointer();
                ushort* AiBuf2 = (ushort*)m_data_buffer2.ToPointer();
                for (index = 0; index < dwDataNum; index++)
                {                   
                    for (Cur_Channel = 0; Cur_Channel < wSelectedChans; Cur_Channel++)
                    {
                        U16Temp = (AiBuf[index * wSelectedChans + Cur_Channel]);
                        I16Temp = (short)U16Temp;
                        pdata.Add(I16Temp.ToString());
                        U16Temp = (AiBuf2[index * wSelectedChans + Cur_Channel]);
                        I16Temp = (short)U16Temp;
                        pdata2.Add(I16Temp.ToString());
                    }
                    pdata.Add("\r\n");
                    pdata2.Add("\r\n");
                }
            }
            string sVol = string.Join(",", pdata.ToArray());
            sVol = sVol.Replace("\r\n,", "\r\n");
            string str;
            str = "Ch0,Ch1,Ch2,Ch3\r\n";
            sVol = str + sVol;
            sw.Write(sVol);
            sw.Close();
            myStream.Close();
            sVol = string.Empty;
            sVol = string.Join(",", pdata2.ToArray());
            sVol = sVol.Replace("\r\n,", "\r\n");
            sVol = str + sVol;
            sw2.Write(sVol);
            sw2.Close();
            myStream2.Close();
            MessageBox.Show("Save OK");
        }
    }
}