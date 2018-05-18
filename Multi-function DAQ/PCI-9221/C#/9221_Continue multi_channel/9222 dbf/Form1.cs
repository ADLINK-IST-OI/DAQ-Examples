using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;
using System.IO;
namespace _9112_polling
{
    public partial class Form1 : Form
    {
        private ushort cardRegNumber;
        private IntPtr[] _ptr;
        private ushort[] _bufferId;
        IntPtr[] VBuffer;
        uint AI_TotalReadCount; /*AI Read Count*/
        uint AI_PerChannelCount;              
        int err;    
        int bufindex;
        uint accesscnt;
        ushort Channel;      
        double[] dtx ;
        double[] voltage;
        double[] ch0 ;
        double[] ch1 ;
        double[] ch2 ;
        double[] ch3 ;
        double[] ch4 ;
        ushort ConfigCtrl;
        ushort TrigCtrl ;
        uint ReTriggerCount ; /*Ignore in Non-Retrigger*/
        uint SampIntrv; /*Sampling Rate: P922X_TIMEBASE/320 = 250K Hz*/
        uint ScanIntrv ; /*Scan Rate: P922X_TIMEBASE/320 = 250K Hz*/
        ushort AdRange ; /*AI range*/
        uint m_dwOverrunCnt;
        string path;
        DateTime TrendDateTime;
        GraphPane[] tmp_ai_wave_raw_pane;
        LineItem[] tmp_ai_wave_raw_curve = new LineItem[5];
        PointPairList userCursorsList = new PointPairList();
        LineItem userCursorsCurve = new LineItem("userCursorsCurve");
        CallbackDelegate ai_buf_ready_cbdel;
        public delegate void DisplayInvoke();
        public delegate void DisplayTrend(IntPtr data);
        Thread queue;
        Queue<IntPtr> myqueue = new Queue<IntPtr>();
        public Form1()
        {
            InitializeComponent();
            parameterConfigIntital();
            
        }

        private void parameterConfigIntital()
        {
            tmp_ai_wave_raw_pane = new GraphPane[1] { this.zedGraphtime.GraphPane };
            m_dwOverrunCnt = 0;
            _ptr= new IntPtr[2];
            _bufferId=new  ushort[2];
            VBuffer = new IntPtr[1];
            ConfigCtrl = DASK.P922x_AI_SingEnded | DASK.P922x_AI_CONVSRC_INT;
            TrigCtrl = DASK.P922x_AI_TRGMOD_POST | DASK.P922x_AI_TRGSRC_SOFT;
            ReTriggerCount = 0; /*Ignore in Non-Retrigger*/
            bufindex = 0;
            Channel=5; /*AI Channel Number to be read*/
            SampIntrv = 800; /*Sampling Rate: P922X_TIMEBASE/320 = 250K Hz*/
            ScanIntrv = (uint)(SampIntrv * Channel); /*Scan Rate: P922X_TIMEBASE/320 = 250K Hz*/           
            AdRange = DASK.AD_B_5_V; /*AI range*/           
            AI_PerChannelCount = 10000;
            AI_TotalReadCount = Channel * AI_PerChannelCount;
            _ptr[0] = Marshal.AllocHGlobal((sizeof(ushort) * ((Int32)AI_TotalReadCount)));
            _ptr[1] = Marshal.AllocHGlobal((sizeof(ushort) * ((Int32)AI_TotalReadCount)));
            VBuffer[0] = Marshal.AllocHGlobal((sizeof(double) * ((Int32)AI_TotalReadCount)));
            ai_buf_ready_cbdel = new CallbackDelegate(ai_buf_ready_cbfunc);         
            queue = new Thread(DataProcess);
            dtx = new double[AI_PerChannelCount];
            voltage = new double[AI_TotalReadCount];
            ch0 = new double[AI_PerChannelCount];
            ch1 = new double[AI_PerChannelCount];
            ch2 = new double[AI_PerChannelCount];
            ch3 = new double[AI_PerChannelCount];
            ch4 = new double[AI_PerChannelCount];
            for (int i = 0; i < AI_PerChannelCount; i++)
            {
                dtx[i] = i;
            }

        }
        private void DAQConfig()
        {
            err = DASK.AI_9221_Config(cardRegNumber, ConfigCtrl, TrigCtrl,  true);
            if (err < 0)
            {
                MessageBox.Show("config");
            }

            /*Set Scan and Sampling Rate*/
            ; err = DASK.AI_9221_CounterInterval(cardRegNumber, ScanIntrv, SampIntrv);
            if (err < 0)
            {
                MessageBox.Show("AI_9222_CounterInterval");
            }

            /*Enable Double Buffer Mode*/
            err = DASK.AI_AsyncDblBufferMode(cardRegNumber, true);
            if (err < 0)
            {
                MessageBox.Show("AI_AsyncDblBufferMode");
            }

            /*Setup Buffer for AI DMA Transfer*/
            err = DASK.AI_ContBufferSetup(cardRegNumber, _ptr[0], AI_TotalReadCount, out _bufferId[0]);
            if (err < 0)
            {
                MessageBox.Show("AI_ContBufferSetup");
            }
            err = DASK.AI_ContBufferSetup(cardRegNumber, _ptr[1], AI_TotalReadCount, out _bufferId[1]);
            if (err < 0)
            {
                MessageBox.Show("AI_ContBufferSetup");
            }

            err = DASK.AI_EventCallBack(cardRegNumber, 1/*add*/, DASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
            if (err < 0)
            {
                MessageBox.Show("AI_EventCallBack");

            }

            err = DASK.AI_ContScanChannels(cardRegNumber, (ushort)(Channel - 1), AdRange, _bufferId, AI_TotalReadCount, 0/*Ignore*/, DASK.ASYNCH_OP);
            if (err < 0)
            {
                MessageBox.Show("AI_ContScanChannels");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            queue = new Thread(DataProcess);           
            DAQConfig();                   
            btnStart.Enabled= false;
            button1.Enabled = true;
            queue.Start();
        }
       
        private void ai_buf_ready_cbfunc()
        {         
            if (bufindex == 0)
            {
                myqueue.Enqueue(_ptr[0]);                
                bufindex = 1;
            }
            else
            {
                myqueue.Enqueue(_ptr[1]);   
                bufindex = 0;
            }
            ushort OverrunFlag;

            DASK.AI_AsyncDblBufferHandled(0);
            DASK.AI_AsyncDblBufferOverrun(0, 0, out OverrunFlag);
            
            if (OverrunFlag == 1)
            {
                m_dwOverrunCnt = m_dwOverrunCnt + 1;
                DASK.AI_AsyncDblBufferOverrun(0, 1, out OverrunFlag);
                this.Invoke((MethodInvoker)delegate
                {
                    textBoxOverrun.Text = m_dwOverrunCnt.ToString();
                });
            }
                                        
        }
        private void Displayaidata(IntPtr writedata)
        {
            tmp_ai_wave_raw_pane[0].CurveList.Clear();
            Marshal.Copy(writedata, voltage, 0, (int)AI_TotalReadCount);
            for (int i = 0; i < AI_PerChannelCount; i++)
            {
                Array.Copy(voltage, i * Channel, ch0, i, 1);
                Array.Copy(voltage, i * Channel + 1, ch1, i, 1);
                Array.Copy(voltage, i * Channel + 2, ch2, i, 1);
                Array.Copy(voltage, i * Channel + 3, ch3, i, 1);
                Array.Copy(voltage, i * Channel + 4, ch4, i, 1);
            }
            tmp_ai_wave_raw_curve[0] = tmp_ai_wave_raw_pane[0].AddCurve("Ch0", dtx, ch0, Color.Red, SymbolType.None);
            tmp_ai_wave_raw_curve[1] = tmp_ai_wave_raw_pane[0].AddCurve("Ch1", dtx, ch1, Color.Blue, SymbolType.None);
            tmp_ai_wave_raw_curve[2] = tmp_ai_wave_raw_pane[0].AddCurve("Ch2", dtx, ch2, Color.DarkGreen, SymbolType.None);
            tmp_ai_wave_raw_curve[3] = tmp_ai_wave_raw_pane[0].AddCurve("Ch3", dtx, ch3, Color.DarkOrange, SymbolType.None);
            tmp_ai_wave_raw_curve[4] = tmp_ai_wave_raw_pane[0].AddCurve("Ch4", dtx, ch4, Color.DimGray, SymbolType.None);
            tmp_ai_wave_raw_pane[0].YAxis.Title.Text = "v";
            tmp_ai_wave_raw_pane[0].XAxis.Title.Text = "Samples";
            this.zedGraphtime.GraphPane.Title.Text = "Data";
            this.zedGraphtime.AxisChange();
            this.zedGraphtime.Refresh();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            short ret = DASK.Register_Card(DASK.PCI_9221, 0);
            if (ret >= 0)
            {
                cardRegNumber = (ushort)ret;
            }
            else
            {
                MessageBox.Show("9222卡初始化失败！");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queue.Abort();
            err = DASK.AI_AsyncClear(cardRegNumber, out accesscnt); 
            if(err<0)
            {
                MessageBox.Show("AI_AsyncClear");
            }
            button1.Enabled = false;
            btnStart.Enabled = true;
            

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (queue.IsAlive)
            {
                if (false == queue.Join(200))
                {
                    queue.Abort();

                }
                err = DASK.Release_Card(cardRegNumber);
                if (err < 0)
                {
                    MessageBox.Show("Release_Card");
                }               
            }
            
            
        }
        private void DataProcess()
        {
           
            while(queue.IsAlive)
            {
                while (myqueue.Count > 0)
                {

                        err=DASK.AI_ContVScale(cardRegNumber, DASK.AD_B_5_V, myqueue.Dequeue(), VBuffer[0], (int)AI_TotalReadCount);
                        if (err < 0)
                        {
                            MessageBox.Show("AI_ContVScale");
                        }
                        this.Invoke((MethodInvoker)delegate
                        {

                               Displayaidata(VBuffer[0]);
                               writefftdataCsv(0, ch0);                         
                               //writefftdataCsv(1, ch1);
                               //writefftdataCsv(2, ch2);
                               //writefftdataCsv(3, ch3);
                               //writefftdataCsv(4, ch4);
                               textBoxQueueCount.Text = myqueue.Count.ToString();
                         });
                       
                    
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }
         private void writefftdataCsv(int ch, double[] chdata)
        {
          TrendDateTime = Convert.ToDateTime(DateTime.Now);
          path = TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss.ffffff") + "_Ch" + ch.ToString() + ".csv";
          File.WriteAllLines(path, chdata.Select(d => d.ToString()).ToArray());                          
         }


    }
}
