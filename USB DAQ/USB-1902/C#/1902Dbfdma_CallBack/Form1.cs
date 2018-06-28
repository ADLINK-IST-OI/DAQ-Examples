using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace _902dma
{
    public partial class Form1 : Form
    {
        double U1902_TIMEBASE = 80000000.0;
        double fSampleRate = 100000.0;
        uint dwDataNum = 20480;
        ushort wSelModuleID;
        ushort wSelModuleType;
        ushort Module_Num;
        IntPtr m_data_buffer;
        int alloc = 0;
        Graphics gr;
        CallbackDelegate m_delegate;
        public delegate void DisplayTrend();
        public Form1()
        {
            InitializeComponent();

            Module_Num = USBDASK.INVALID_CARD_ID;
            wSelModuleID = USBDASK.INVALID_CARD_ID;
        }

        public void SetModuleType(ushort ModuleType)
        {
            wSelModuleType = ModuleType;
        }

        public void SetModuleID(ushort ModuleID)
        {
            wSelModuleID = ModuleID;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            short iTemp;
            int nBufSize;

            if (wSelModuleID == USBDASK.INVALID_CARD_ID)
                return;
            m_delegate = new CallbackDelegate(Callback);
            gr = pbxDisplay.CreateGraphics();

            iTemp = USBDASK.UD_Register_Card(wSelModuleType, wSelModuleID);
            if (iTemp < 0)
            {
                MessageBox.Show("UD_Register_Card() Fail, Code:" + iTemp.ToString());
                Close();
                return;
            }
            textBox_CardID.Text = wSelModuleID.ToString();

            nBufSize = sizeof(short) * Convert.ToInt32(dwDataNum);
            m_data_buffer = Marshal.AllocHGlobal(nBufSize);
            alloc = 1;
            Module_Num = (ushort)iTemp;

            tbxYup.Text = "10V";
            tbxYdown.Text = "-10V";
            textYZero.Text = "0V";
            pbxDisplay.BackColor = Color.Black;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            short err;
            uint AccessCnt;

            gr.Dispose();

            if (Module_Num != USBDASK.INVALID_CARD_ID)
                err = USBDASK.UD_AI_AsyncClear(Module_Num, out AccessCnt);

           

            if (alloc == 1)
                Marshal.FreeHGlobal(m_data_buffer);

            if (Module_Num != USBDASK.INVALID_CARD_ID)
            {
                USBDASK.UD_Release_Card(Module_Num);
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            short err;
            uint dwInvCnt;

            // Configure AI Channel
            err = USBDASK.UD_AI_1902_Config(Module_Num, USBDASK.P1902_AI_PseudoDifferential, 0, 0, 0, 0);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_1902_Config error = :" + err.ToString());
                Close();
                return;
            }

            // Enable double-buffer
            err = USBDASK.UD_AI_AsyncDblBufferMode(Module_Num, true);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_AsyncDblBufferMode error = :" + err.ToString());
                Close();
                return;
            }

            dwInvCnt = Convert.ToUInt32(U1902_TIMEBASE / fSampleRate);

            err = USBDASK.UD_AI_1902_CounterInterval(Module_Num, dwInvCnt, dwInvCnt);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_1902_CounterInterval error = :" + err.ToString());
                Close();
                return;
            }
            err = USBDASK.UD_AI_EventCallBack(Module_Num, 1, USBDASK.DBEvent, m_delegate);
            if (err < 0)
            {
                MessageBox.Show("UD_AI_EventCallBack error = :" + err.ToString());
                Close();
                return;
            }

            err = USBDASK.UD_AI_ContReadChannel(Module_Num, 0, USBDASK.AD_B_10_V, m_data_buffer, dwDataNum, fSampleRate, USBDASK.ASYNCH_OP);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_ContReadMultiChannels error = :" + err.ToString());
                Close();
                return;
            }

            //timer1.Enabled = true;
            btnStart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            short err;
            uint AccessCnt;

            err = USBDASK.UD_AI_AsyncClear(Module_Num, out AccessCnt);           
            btnStart.Enabled = true;

        }
        private void Callback()
        {
            short err;



            err = USBDASK.UD_AI_AsyncDblBufferTransfer(Module_Num, m_data_buffer);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_ContReadMultiChannels error = :" + err.ToString());
                return;
            }
            else
            {
                DisplayTrend displaytrendInvoke = new DisplayTrend(PlotData);
                BeginInvoke(displaytrendInvoke);

            }


        }

        private void PlotData()
        {
            float fScaleX, fScaleY, fMidY;
            ushort index;
            short I16Temp;
            ushort U16Temp;
            uint dwSampleCnt;
            Point[] PointArray = new Point[dwDataNum / 2];

            pbxDisplay.Refresh();

            dwSampleCnt = dwDataNum / 2;  // half-buffer
            fScaleX = (float)pbxDisplay.Width / (float)PointArray.Length;
            fScaleY = ((float)pbxDisplay.Height * (float)0.97) / (float)65536.0;
            fMidY = (float)pbxDisplay.Height / 2;

            for (index = 0; index < dwSampleCnt; index++)
            {
                PointArray[index].X = (int)(index * fScaleX);
            }

            // The unsafe section where byte pointers are used.
            unsafe
            {

                ushort* AiBuf = (ushort*)m_data_buffer.ToPointer();

                for (index = 0; index < dwSampleCnt; index++)
                {
                    U16Temp = (AiBuf[index]);

                    I16Temp = (short)U16Temp;
                    PointArray[index].Y = (int)(fMidY - I16Temp * fScaleY);

                }
            }

            gr.DrawLines(Pens.Yellow, PointArray);

        }

       
    }
}