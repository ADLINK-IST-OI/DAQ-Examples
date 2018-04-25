using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Diagnostics;
using ZedGraph;

namespace AIO_Simultaneous_UI
{
    struct program_config
    {
        //
        // Program status
        //
        public bool is_reg_dev;
        public bool is_op_started;
        // AO
        public bool is_ao_enabled;
        public bool is_ao_set_buf;
        public bool is_ao_op_run;
        public bool is_ao_done_evt_set;
        public bool is_ao_buf_ready_evt_set;
        // AI
        public bool is_ai_enabled;
        public bool is_ai_set_buf;
        public bool is_ai_op_run;
        public bool is_ai_done_evt_set;
        public bool is_ai_buf_ready_evt_set;

        //
        // Device configuration variables
        //
        public ushort card_type;
        public ushort card_subtype;
        public ushort card_num;
        public ushort card_handle;

        //
        // Sample rate configuration variables
        //
        // AO
        public double ao_sample_rate;
        public double ao_actual_rate;
        public uint ao_sample_scaling;
        // AI
        public double ai_sample_rate;
        public double ai_actual_rate;
        public uint ai_sample_scaling;

        //
        // Channel configuration variables
        //
        // AO
        public ushort ao_chnl_sel;
        public ushort ao_chnl_cnt;
        public ushort ao_chnl_range;
        public ushort ao_chnl_config;
        // AI
        public ushort ai_chnl_sel;
        public ushort ai_chnl_cnt;
        public ushort ai_chnl_range;
        public ushort ai_chnl_config;
        public double ai_chnl_range_upper;
        public double ai_chnl_range_lower;

        //
        // Trigger configuration variables
        //
        public ushort trig_target;
        public ushort trig_config;
        public uint retrig_count;
        public uint trig_delay;
        public bool is_gen_sw_trig;
        public bool is_set_ana_trig;

        //
        // Analog trigger configuration variables
        //
        public uint ana_trig_src;
        public uint ana_trig_mode;
        public double ana_trig_threshold;
        public ushort ana_trig_src_range;
        public ushort ana_trig_src_config;

        //
        // Data buffer & file variables
        //
        // AO
        public uint ao_chnl_sample_count;
        public uint ao_all_data_count;
        public uint ao_buf_size;
        public IntPtr[] ao_raw_data_buf;
        // AI
        public uint ai_chnl_sample_count;
        public uint ai_all_data_count;
        public uint ai_buf_size;
        public IntPtr[] ai_raw_data_buf;
        public double[] ai_scale_data_buf;
        public uint[] ai_buf_id_array;

        //
        // Operation control variables
        //
        // AO
        public uint ao_upd_repeat_cnt;
        public uint ao_upd_repeat_interval;
        public ushort ao_upd_op_definite;

        //
        // Operation status variables
        //
        // AO
        public uint ao_access_cnt;
        public uint ao_buf_ready_idx;
        public long ao_buf_ready_cnt;
        // AI
        public uint ai_access_cnt;
        public uint ai_buf_ready_idx;
        public long ai_buf_ready_cnt;

        //
        // Waveform setting varibles
        //
        // AO
        public double sine_waveform_freq;
        public double sine_waveform_amp;
        public double sine_waveform_amp_max;
        public uint[] sine_waveform;

        //
        // UI update variables
        //
        // AO
        public System.Threading.Timer tmr_ao_update_data;
        public object locker_ao_update_data;
        public long ao_buf_update_cnt;
        // AI
        public System.Threading.Timer tmr_ai_update_data;
        public object locker_ai_update_data;
        public long ai_buf_update_cnt;
        // AI data
        public uint ai_update_buffer_array_size;
        public double[][][] ai_update_buffer_array_raw;
        // AI FFT
        public double[][][] ai_update_buffer_array_fft;
        public int ai_buf_fft_logN;
    }

    public partial class frm_main : Form
    {
        static program_config config_para;

        static void fn_initial_structure()
        {
            //
            // Program status
            //
            config_para.is_reg_dev = false;
            config_para.is_op_started = false;
            // AO
            config_para.is_ao_enabled = true;
            config_para.is_ao_set_buf = false;
            config_para.is_ao_op_run = false;
            config_para.is_ao_done_evt_set = false;
            config_para.is_ao_buf_ready_evt_set = false;
            // AI
            config_para.is_ai_enabled = true;
            config_para.is_ai_set_buf = false;
            config_para.is_ai_op_run = false;
            config_para.is_ai_done_evt_set = false;
            config_para.is_ai_buf_ready_evt_set = false;

            //
            // Device configuration variables
            //
            config_para.card_type = DSA_DASK.PCI_9527;
            config_para.card_subtype = 0;
            config_para.card_num = 0;
            config_para.card_handle = 0;

            //
            // Sample rate configuration variables
            //
            // AO
            config_para.ao_sample_rate = 216000.0;
            config_para.ao_actual_rate = config_para.ao_sample_rate;
            config_para.ao_sample_scaling = 8;
            // AI
            config_para.ai_sample_rate = 2 * config_para.ao_sample_rate;
            config_para.ai_actual_rate = config_para.ai_sample_rate;
            config_para.ai_sample_scaling = 8;

            //
            // Channel configuration variables
            //
            // AO
            config_para.ao_chnl_sel = DSA_DASK.P9527_AO_CH_DUAL;
            config_para.ao_chnl_cnt = 2;
            config_para.ao_chnl_range = DSA_DASK.AD_B_0_1_V;
            config_para.ao_chnl_config = DSA_DASK.P9527_AO_PseudoDifferential;
            // AI
            config_para.ai_chnl_sel = DSA_DASK.P9527_AI_CH_DUAL;
            config_para.ai_chnl_cnt = 2;
            config_para.ai_chnl_range = DSA_DASK.AD_B_0_316_V;
            config_para.ai_chnl_config = DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_Coupling_DC;
            config_para.ai_chnl_range_upper = 1;
            config_para.ai_chnl_range_lower = -1;

            //
            // Trigger configuration variables
            //
            config_para.trig_target = DSA_DASK.P9527_TRG_ALL;
            config_para.trig_config = DSA_DASK.P9527_TRG_MODE_POST | DSA_DASK.P9527_TRG_SRC_SOFT | DSA_DASK.P9527_TRG_Positive;
            config_para.retrig_count = 0;
            config_para.trig_delay = 0;
            config_para.is_gen_sw_trig = true;
            config_para.is_set_ana_trig = false;

            //
            // Analog trigger configuration variables
            //
            config_para.ana_trig_src = 0;
            config_para.ana_trig_mode = 0;
            config_para.ana_trig_threshold = 0;
            config_para.ana_trig_src_range = 0;
            config_para.ana_trig_src_config = 0;

            //
            // Data buffer & file variables
            //
            // AO
            config_para.ao_chnl_sample_count = (uint)(config_para.ao_sample_rate / config_para.ao_sample_scaling);
            config_para.ao_all_data_count = config_para.ao_chnl_sample_count * config_para.ao_chnl_cnt;
            config_para.ao_buf_size = config_para.ao_all_data_count;
            //config_para.ao_raw_data_buf;
            // AI
            config_para.ai_chnl_sample_count = (uint)(config_para.ai_sample_rate / config_para.ai_sample_scaling);
            config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
            config_para.ai_buf_size = config_para.ai_all_data_count;
            //config_para.ai_raw_data_buf;
            //config_para.ai_scale_data_buf;
            //config_para.ai_buf_id_array;

            //
            // Operation control variables
            //
            // AO
            config_para.ao_upd_repeat_cnt = 0;
            config_para.ao_upd_repeat_interval = 0;
            config_para.ao_upd_op_definite = 0;

            //
            // Operation status variables
            //
            // AO
            config_para.ao_access_cnt = 0;
            config_para.ao_buf_ready_idx = 0;
            config_para.ao_buf_ready_cnt = -1;
            // AI
            config_para.ai_access_cnt = 0;
            config_para.ai_buf_ready_idx = 0;
            config_para.ai_buf_ready_cnt = -1;

            //
            // Waveform setting varibles
            //
            // AO
            config_para.sine_waveform_freq = 50000.0; // 50 KHz
            config_para.sine_waveform_amp = 0.18;    // 0.18 Vpp
            config_para.sine_waveform_amp_max = 0.2; // 0.2 Vpp
            //config_para.sine_waveform;

            //
            // UI update variables
            //
            // AO
            //config_para.tmr_ao_update_data;
            //config_para.locker_ao_update_data;
            config_para.ao_buf_update_cnt = -1;
            // AI
            //config_para.tmr_ai_update_data;
            //config_para.locker_ai_update_data;
            config_para.ai_buf_update_cnt = -1;
            // AI data
            config_para.ai_update_buffer_array_size = 8;
            config_para.ai_update_buffer_array_raw = new double[2][][];
            // AI FFT
            config_para.ai_update_buffer_array_fft = new double[2][][];
            config_para.ai_buf_fft_logN = (int)Math.Log((double)config_para.ai_chnl_sample_count, 2);
        }

        // Initialization function for zed graph
        public void fn_zgrapg_initial()
        {
            // Raw data graph
            GraphPane tmp_ai_wave_raw_pane = this.zg_ai_wave_raw.GraphPane;
            tmp_ai_wave_raw_pane.Title.Text = "AI Waveform (Raw Data)";

            tmp_ai_wave_raw_pane.XAxis.Title.Text = "Time (Samples)";
            tmp_ai_wave_raw_pane.XAxis.Scale.Min = 0;
            tmp_ai_wave_raw_pane.XAxis.Scale.Max = config_para.ai_chnl_sample_count;

            tmp_ai_wave_raw_pane.YAxis.Title.Text = "(V)";
            tmp_ai_wave_raw_pane.YAxis.Scale.Min = config_para.ai_chnl_range_lower;
            tmp_ai_wave_raw_pane.YAxis.Scale.Max = config_para.ai_chnl_range_upper;

            this.zg_ai_wave_raw.AxisChange();
            this.zg_ai_wave_raw.Refresh();

            // FFT data graph
            GraphPane tmp_ai_wave_fft_pane = this.zg_ai_wave_fft.GraphPane;
            tmp_ai_wave_fft_pane.Title.Text = "AI Waveform (Frequency)";

            tmp_ai_wave_fft_pane.XAxis.Title.Text = "Frequency (Hz)";
            tmp_ai_wave_fft_pane.XAxis.Scale.Min = 0;
            tmp_ai_wave_fft_pane.XAxis.Scale.Max = config_para.ai_sample_rate / 2;

            tmp_ai_wave_fft_pane.YAxis.Title.Text = "(dB)";
            tmp_ai_wave_fft_pane.YAxis.Scale.Min = -200;
            tmp_ai_wave_fft_pane.YAxis.Scale.Max = 0;

            this.zg_ai_wave_fft.AxisChange();
            this.zg_ai_wave_fft.Refresh();
        }

        // Configuration function for 9527
        public void fn_p9527_config()
        {
            // Sub-card type
            this.cbox_device_type.SelectedIndex = config_para.card_subtype;

            // Card number
            this.cbox_device_index.SelectedIndex = config_para.card_num;

            // AO enabled
            this.cbox_ao_enabled.Checked = config_para.is_ao_enabled;

            // AI enabled
            this.cbox_ai_enabled.Checked = config_para.is_ai_enabled;
        }

        // AO Configuration function for 9527
        public void fn_p9527_config_ao()
        {
            // AO Sample rate
            this.tbox_ao_sample_rate.Text = config_para.ao_sample_rate.ToString();

            // AO channel select
            switch (config_para.ao_chnl_range)
            {
                case DSA_DASK.P9527_AO_CH_0:
                    this.cbox_ao_channel_select.SelectedIndex = 0;
                    break;
                case DSA_DASK.P9527_AO_CH_1:
                    this.cbox_ao_channel_select.SelectedIndex = 1;
                    break;
                case DSA_DASK.P9527_AO_CH_DUAL:
                    this.cbox_ao_channel_select.SelectedIndex = 2;
                    break;
                default:
                    this.cbox_ao_channel_select.SelectedIndex = 2;
                    break;
            }

            // AO channel range
            switch (config_para.ao_chnl_range)
            {
                case DSA_DASK.AD_B_10_V:
                    this.cbox_ao_channel_range.SelectedIndex = 0;
                    break;
                case DSA_DASK.AD_B_1_V:
                    this.cbox_ao_channel_range.SelectedIndex = 1;
                    break;
                case DSA_DASK.AD_B_0_1_V:
                    this.cbox_ao_channel_range.SelectedIndex = 2;
                    break;
                default:
                    this.cbox_ao_channel_range.SelectedIndex = 2;
                    break;
            }

            // AO channel output type
            switch (config_para.ao_chnl_config)
            {
                case DSA_DASK.P9527_AO_Differential:
                    this.cbox_ao_channel_type.SelectedIndex = 0;
                    break;
                case DSA_DASK.P9527_AO_PseudoDifferential:
                    this.cbox_ao_channel_type.SelectedIndex = 1;
                    break;
                default:
                    this.cbox_ao_channel_type.SelectedIndex = 1;
                    break;
            }

            // AO trigger source
            ushort tmp_trig_source = (ushort)(config_para.trig_config & 0xf0);
            switch (tmp_trig_source)
            {
                case DSA_DASK.P9527_TRG_SRC_SOFT:
                    this.cbox_ao_trigger_source.SelectedIndex = 0;
                    break;
                case DSA_DASK.P9527_TRG_SRC_EXTD:
                    this.cbox_ao_trigger_source.SelectedIndex = 1;
                    break;
                default:
                    this.cbox_ao_trigger_source.SelectedIndex = 0;
                    break;
            }

            // AO Sine waveform frequency
            this.tbox_ao_sine_freqency.Text = config_para.sine_waveform_freq.ToString();

            // AO Sine waveform amplitude
            this.tbox_ao_sine_amplitude.Text = config_para.sine_waveform_amp.ToString();
        }

        // AI Configuration function for 9527
        public void fn_p9527_config_ai()
        {
            // AI Sample rate
            this.tbox_ai_sample_rate.Text = config_para.ai_sample_rate.ToString();

            // AI channel select
            switch (config_para.ai_chnl_range)
            {
                case DSA_DASK.P9527_AI_CH_0:
                    this.cbox_ai_channel_select.SelectedIndex = 0;
                    break;
                case DSA_DASK.P9527_AI_CH_1:
                    this.cbox_ai_channel_select.SelectedIndex = 1;
                    break;
                case DSA_DASK.P9527_AI_CH_DUAL:
                    this.cbox_ai_channel_select.SelectedIndex = 2;
                    break;
                default:
                    this.cbox_ai_channel_select.SelectedIndex = 2;
                    break;
            }

            // AI channel range
            switch (config_para.ai_chnl_range)
            {
                case DSA_DASK.AD_B_40_V:
                    this.cbox_ai_channel_range.SelectedIndex = 0;
                    break;
                case DSA_DASK.AD_B_10_V:
                    this.cbox_ai_channel_range.SelectedIndex = 1;
                    break;
                case DSA_DASK.AD_B_3_16_V:
                    this.cbox_ai_channel_range.SelectedIndex = 2;
                    break;
                case DSA_DASK.AD_B_1_V:
                    this.cbox_ai_channel_range.SelectedIndex = 3;
                    break;
                case DSA_DASK.AD_B_0_316_V:
                    this.cbox_ai_channel_range.SelectedIndex = 4;
                    break;
                default:
                    this.cbox_ai_channel_range.SelectedIndex = 4;
                    break;
            }

            // AI channel output type
            switch (config_para.ai_chnl_config)
            {
                case (DSA_DASK.P9527_AI_Differential | DSA_DASK.P9527_AI_Coupling_DC):
                    this.cbox_ai_channel_type.SelectedIndex = 0;
                    break;
                case (DSA_DASK.P9527_AI_Differential | DSA_DASK.P9527_AI_Coupling_AC):
                    this.cbox_ai_channel_type.SelectedIndex = 1;
                    break;
                case (DSA_DASK.P9527_AI_Differential | DSA_DASK.P9527_AI_EnableIEPE):
                    this.cbox_ai_channel_type.SelectedIndex = 2;
                    break;
                case (DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_Coupling_DC):
                    this.cbox_ai_channel_type.SelectedIndex = 3;
                    break;
                case (DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_Coupling_AC):
                    this.cbox_ai_channel_type.SelectedIndex = 4;
                    break;
                case (DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_EnableIEPE):
                    this.cbox_ai_channel_type.SelectedIndex = 5;
                    break;
                default:
                    this.cbox_ao_channel_type.SelectedIndex = 3;
                    break;
            }
            // AI trigger source
            ushort tmp_trig_source = (ushort)(config_para.trig_config & 0xf0);
            switch (tmp_trig_source)
            {
                case DSA_DASK.P9527_TRG_SRC_SOFT:
                    this.cbox_ai_trigger_source.SelectedIndex = 0;
                    break;
                case DSA_DASK.P9527_TRG_SRC_EXTD:
                    this.cbox_ai_trigger_source.SelectedIndex = 1;
                    break;
                default:
                    this.cbox_ai_trigger_source.SelectedIndex = 0;
                    break;
            }
        }

        // TRIG Configuration function for 9527
        public void fn_p9527_config_trig()
        {
            // Reserved for configuring AI & AO trigger settings
        }

        // Resource release handler
        public void fn_free_resource(bool f_release_card)
        {
            if (config_para.is_ai_op_run)
            {
                // Async Clear
                DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, out config_para.ai_access_cnt);
                config_para.is_ai_op_run = false;
            }
            if (config_para.is_ao_op_run)
            {
                // Async Clear
                DSA_DASK.DSA_AO_AsyncClear(config_para.card_handle, out config_para.ao_access_cnt, 0);
                config_para.is_ao_op_run = false;
            }

            if (config_para.is_ai_done_evt_set)
            {
                // Reset done event
                DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.AIEnd/*EventType*/, ai_done_cbdel);
                config_para.is_ai_done_evt_set = false;
            }
            if (config_para.is_ao_done_evt_set)
            {
                // Reset done event
                DSA_DASK.DSA_AO_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.AOEnd/*EventType*/, ao_done_cbdel);
                config_para.is_ao_done_evt_set = false;
            }

            if (config_para.is_ai_buf_ready_evt_set)
            {
                // Reset buffer ready event
                DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
                config_para.is_ai_buf_ready_evt_set = false;
            }
            if (config_para.is_ao_buf_ready_evt_set)
            {
                // Reset buffer ready event
                DSA_DASK.DSA_AO_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.DBEvent/*EventType*/, ao_buf_ready_cbdel);
                config_para.is_ao_buf_ready_evt_set = false;
            }

            if (config_para.is_ai_set_buf)
            {
                // Reset buffer
                DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle);
                Marshal.FreeHGlobal(config_para.ai_raw_data_buf[0]);
                Marshal.FreeHGlobal(config_para.ai_raw_data_buf[1]);
                config_para.is_ai_set_buf = false;
            }
            if (config_para.is_ao_set_buf)
            {
                // Reset buffer
                DSA_DASK.DSA_AO_ContBufferReset(config_para.card_handle);
                Marshal.FreeHGlobal(config_para.ao_raw_data_buf[0]);
                Marshal.FreeHGlobal(config_para.ao_raw_data_buf[1]);
                config_para.is_ao_set_buf = false;
            }

            if (config_para.is_reg_dev && f_release_card)
            {
                // Release device
                short err = DSA_DASK.DSA_Release_Card(config_para.card_handle);
                config_para.is_reg_dev = false;
            }
        }

        static void fn_buffer_interleaving(double[] buf_src, double[][] buf_desc, uint buf_size, uint interleave_cnt)
        {
            uint interleave_length = buf_size / interleave_cnt;

            for (uint vi = 0, vix = 0; vi < interleave_length; ++ vi)
            {
                for (uint vj = 0; vj < interleave_cnt; ++ vj)
                {
                    buf_desc[vj][vi] = buf_src[vix++];
                }
            }
        }

        static double fft_magdb_freq(double[] fft_mag, double[] fft_freq, int fft_logN, double sample_rate, out double max_mag)
        {
            double ret_freq = 0;
            double max_magdb = double.MinValue;

            int fft_size = (1 << fft_logN);
            double fft_bin_space = sample_rate / fft_size;
            for (int vi = 0; vi < fft_size / 2; ++vi)
            {
                fft_freq[vi] = vi * fft_bin_space;
                if (fft_mag[vi] > max_magdb)
                {
                    max_magdb = fft_mag[vi];
                    ret_freq = fft_freq[vi];
                }
            }

            max_mag = max_magdb;
            return ret_freq;
        }

        static void fft_get_magdb(double[] raw, double[] fft_mag, int fft_size, int fft_logN, double fft_full_scale)
        {
            double[] re = new double[fft_size];
            double[] im = new double[fft_size];

            // Copy raw data into re, set im to zero
            Buffer.BlockCopy(raw, 0, re, 0, fft_size * sizeof(double));

            // FFT
            FFT2 myFFT = new FFT2();
            myFFT.init((uint)fft_logN);
            myFFT.run(re, im, false);

            // TODO: Do something with the FFT results, e.g. compute magnitude from re and im components.
            for (int vi = 0; vi < fft_size / 2; ++ vi)
            {
                fft_mag[vi] = 10 * Math.Log10(4 * (re[vi] * re[vi] + im[vi] * im[vi]) / (fft_size * fft_size) / (fft_full_scale * fft_full_scale));
            }
        }

        public delegate void delfn_ao_update_data(long curr_cnt, long pre_cnt);
        public void fn_ao_update_data(long curr_cnt, long pre_cnt)
        {
            if (InvokeRequired && IsHandleCreated)
            {
                try
                {
                    this.Invoke(new delfn_ao_update_data(fn_ao_update_data), new object[] { curr_cnt, pre_cnt });
                }
                catch (Exception e)
                {
                }
            }
            else
            {
                //
                // Update AO UI control HERE
                //
                if (IsHandleCreated)
                {
                    this.tbox_ao_buf_ready_cnt.Text = curr_cnt.ToString();
                }
            }
        }

        public void fn_tmr_ao_update_data(object State)
        {
            if (Monitor.TryEnter(config_para.locker_ao_update_data))
            {
                try
                {
                    if (config_para.is_ao_op_run == true && config_para.ao_buf_ready_cnt > config_para.ao_buf_update_cnt)
                    {
                        fn_ao_update_data(config_para.ao_buf_ready_cnt, config_para.ao_buf_update_cnt);
                        config_para.ao_buf_update_cnt = config_para.ao_buf_ready_cnt;
                    }
                }
                finally
                {
                    Monitor.Exit(config_para.locker_ao_update_data);
                }
            }
        }

        public delegate void delfn_ai_update_data(long curr_cnt, long pre_cnt);
        public void fn_ai_update_data(long curr_cnt, long pre_cnt)
        {
            if (InvokeRequired && IsHandleCreated)
            {
                try
                {
                    this.Invoke(new delfn_ai_update_data(fn_ai_update_data), new object[] { curr_cnt, pre_cnt });
                }
                catch (Exception e)
                {
                }
            }
            else
            {
                //
                // Update AI UI control HERE
                //
                if (IsHandleCreated)
                {
                    this.tbox_ai_buf_ready_cnt.Text = curr_cnt.ToString();

                    // Show last data of update buffer
                    long tmp_ai_buf_update_idx = curr_cnt % config_para.ai_update_buffer_array_size;

                    // Raw data graph
                    GraphPane tmp_ai_wave_raw_pane = this.zg_ai_wave_raw.GraphPane;
                    tmp_ai_wave_raw_pane.CurveList.Clear();

                    if (config_para.ai_chnl_sel == DSA_DASK.P9527_AI_CH_0)
                    {
                        LineItem tmp_ai_wave_raw_curve = tmp_ai_wave_raw_pane.AddCurve("CH0", null, config_para.ai_update_buffer_array_raw[0][tmp_ai_buf_update_idx], Color.Red, SymbolType.None);
                        tmp_ai_wave_raw_curve.Line.IsSmooth = true;
                    }
                    else if (config_para.ai_chnl_sel == DSA_DASK.P9527_AI_CH_1)
                    {
                        LineItem tmp_ai_wave_raw_curve = tmp_ai_wave_raw_pane.AddCurve("CH1", null, config_para.ai_update_buffer_array_raw[0][tmp_ai_buf_update_idx], Color.Red, SymbolType.None);
                        tmp_ai_wave_raw_curve.Line.IsSmooth = true;
                    }
                    else
                    {
                        LineItem tmp_ai_wave_raw_curve = tmp_ai_wave_raw_pane.AddCurve("CH0", null, config_para.ai_update_buffer_array_raw[0][tmp_ai_buf_update_idx], Color.Red, SymbolType.None);
                        tmp_ai_wave_raw_curve.Line.IsSmooth = true;
                        LineItem tmp_ai_wave_raw_curve2 = tmp_ai_wave_raw_pane.AddCurve("CH1", null, config_para.ai_update_buffer_array_raw[1][tmp_ai_buf_update_idx], Color.Blue, SymbolType.None);
                        tmp_ai_wave_raw_curve2.Line.IsSmooth = true;
                    }

                    this.zg_ai_wave_raw.AxisChange();
                    this.zg_ai_wave_raw.Refresh();

                    // FFT data graph
                    GraphPane tmp_ai_wave_fft_pane = this.zg_ai_wave_fft.GraphPane;
                    tmp_ai_wave_fft_pane.CurveList.Clear();

                    int tmp_fft_size_N = (1 << config_para.ai_buf_fft_logN);
                    if (config_para.ai_chnl_sel == DSA_DASK.P9527_AI_CH_0)
                    {
                        double tmp_ai_ch0_mag_max;
                        double[] tmp_ai_ch0_freq_array = new double[tmp_fft_size_N / 2];
                        double tmp_ai_ch0_freq = fft_magdb_freq(config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_update_idx], tmp_ai_ch0_freq_array, config_para.ai_buf_fft_logN, config_para.ai_sample_rate, out tmp_ai_ch0_mag_max);

                        LineItem tmp_ai_wave_fft_curve = tmp_ai_wave_fft_pane.AddCurve("CH0", tmp_ai_ch0_freq_array, config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_update_idx], Color.Red, SymbolType.None);
                        tmp_ai_wave_fft_curve.Line.IsSmooth = true;

                        // Wave frequency
                        this.tbox_ai_ch0_frequency.Text = tmp_ai_ch0_freq.ToString();
                        this.tbox_ai_ch1_frequency.Text = "";
                        // Wave magnitude
                        this.tbox_ai_ch0_magnitude.Text = tmp_ai_ch0_mag_max.ToString();
                        this.tbox_ai_ch1_magnitude.Text = "";
                    }
                    else if (config_para.ai_chnl_sel == DSA_DASK.P9527_AI_CH_1)
                    {
                        double tmp_ai_ch1_mag_max;
                        double[] tmp_ai_ch1_freq_array = new double[tmp_fft_size_N / 2];
                        double tmp_ai_ch1_freq = fft_magdb_freq(config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_update_idx], tmp_ai_ch1_freq_array, config_para.ai_buf_fft_logN, config_para.ai_sample_rate, out tmp_ai_ch1_mag_max);

                        LineItem tmp_ai_wave_fft_curve = tmp_ai_wave_fft_pane.AddCurve("CH1", tmp_ai_ch1_freq_array, config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_update_idx], Color.Red, SymbolType.None);
                        tmp_ai_wave_fft_curve.Line.IsSmooth = true;

                        // Wave frequency
                        this.tbox_ai_ch0_frequency.Text = "";
                        this.tbox_ai_ch1_frequency.Text = tmp_ai_ch1_freq.ToString();
                        // Wave magnitude
                        this.tbox_ai_ch0_magnitude.Text = "";
                        this.tbox_ai_ch1_magnitude.Text = tmp_ai_ch1_mag_max.ToString();
                    }
                    else
                    {
                        double tmp_ai_ch0_mag_max;
                        double tmp_ai_ch1_mag_max;
                        double[][] tmp_ai_ch_freq_array = new double[2][];
                        tmp_ai_ch_freq_array[0] = new double[tmp_fft_size_N / 2];
                        tmp_ai_ch_freq_array[1] = new double[tmp_fft_size_N / 2];
                        double tmp_ai_ch0_freq = fft_magdb_freq(config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_update_idx], tmp_ai_ch_freq_array[0], config_para.ai_buf_fft_logN, config_para.ai_sample_rate, out tmp_ai_ch0_mag_max);
                        double tmp_ai_ch1_freq = fft_magdb_freq(config_para.ai_update_buffer_array_fft[1][tmp_ai_buf_update_idx], tmp_ai_ch_freq_array[1], config_para.ai_buf_fft_logN, config_para.ai_sample_rate, out tmp_ai_ch1_mag_max);

                        LineItem tmp_ai_wave_fft_curve = tmp_ai_wave_fft_pane.AddCurve("CH0", tmp_ai_ch_freq_array[0], config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_update_idx], Color.Red, SymbolType.None);
                        tmp_ai_wave_fft_curve.Line.IsSmooth = true;

                        LineItem tmp_ai_wave_fft_curve2 = tmp_ai_wave_fft_pane.AddCurve("CH1", tmp_ai_ch_freq_array[1], config_para.ai_update_buffer_array_fft[1][tmp_ai_buf_update_idx], Color.Blue, SymbolType.None);
                        tmp_ai_wave_fft_curve2.Line.IsSmooth = true;

                        // Wave frequency
                        this.tbox_ai_ch0_frequency.Text = tmp_ai_ch0_freq.ToString();
                        this.tbox_ai_ch1_frequency.Text = tmp_ai_ch1_freq.ToString();
                        // Wave magnitude
                        this.tbox_ai_ch0_magnitude.Text = tmp_ai_ch0_mag_max.ToString();
                        this.tbox_ai_ch1_magnitude.Text = tmp_ai_ch1_mag_max.ToString();
                    }

                    this.zg_ai_wave_fft.AxisChange();
                    this.zg_ai_wave_fft.Refresh();
                }
            }
        }

        public void fn_tmr_ai_update_data(object State)
        {
            if (Monitor.TryEnter(config_para.locker_ai_update_data))
            {
                try
                {
                    if (config_para.is_ai_op_run == true && config_para.ai_buf_ready_cnt > config_para.ai_buf_update_cnt)
                    {
                        fn_ai_update_data(config_para.ai_buf_ready_cnt, config_para.ai_buf_update_cnt);
                        config_para.ai_buf_update_cnt = config_para.ai_buf_ready_cnt;
                    }
                }
                finally
                {
                    Monitor.Exit(config_para.locker_ai_update_data);
                }
            }
        }

        // Callback function for AO buffer ready event
        static void ao_buf_ready_cbfunc()
        {
            //
            // Process AO data of ready buffer HERE
            //

            config_para.ao_buf_ready_idx += 1;
            config_para.ao_buf_ready_idx %= 2;
            config_para.ao_buf_ready_cnt += 1;
        }
        static CallbackDelegate ao_buf_ready_cbdel = new CallbackDelegate(ao_buf_ready_cbfunc);

        // Callback function for AI buffer ready event
        static void ai_buf_ready_cbfunc()
        {
            //
            // Process AI data of ready buffer HERE
            //

            // Convert AI raw data to scaled data, it depends on the setting of channel range.
            DSA_DASK.DSA_AI_ContVScale(config_para.card_handle, config_para.ai_chnl_range, config_para.ai_raw_data_buf[config_para.ai_buf_ready_idx], config_para.ai_scale_data_buf, (int)config_para.ai_buf_size);

            // Tell DSA-DASK that the ready buffer is handled
            DSA_DASK.DSA_AI_AsyncDblBufferHandled(config_para.card_handle);

            // Copy data to update buffer
            long tmp_ai_buf_ready_to_update_idx = (config_para.ai_buf_ready_cnt + 1) % config_para.ai_update_buffer_array_size;

            if (config_para.ai_chnl_sel == DSA_DASK.P9527_AI_CH_DUAL)
            {
                // Raw
                double [][] tmp_ai_scale_data_buf = new double[2][];
                tmp_ai_scale_data_buf[0] = new double[config_para.ai_chnl_sample_count];
                tmp_ai_scale_data_buf[1] = new double[config_para.ai_chnl_sample_count];
                fn_buffer_interleaving(config_para.ai_scale_data_buf, tmp_ai_scale_data_buf, config_para.ai_chnl_sample_count * 2, 2);
                Buffer.BlockCopy(tmp_ai_scale_data_buf[0], 0, config_para.ai_update_buffer_array_raw[0][tmp_ai_buf_ready_to_update_idx], 0, (int)config_para.ai_chnl_sample_count * sizeof(double));
                Buffer.BlockCopy(tmp_ai_scale_data_buf[1], 0, config_para.ai_update_buffer_array_raw[1][tmp_ai_buf_ready_to_update_idx], 0, (int)config_para.ai_chnl_sample_count * sizeof(double));

                // FFT
                int tmp_fft_size_N = 1 << config_para.ai_buf_fft_logN;
                double[] tmp_fft_mag_array = new double[tmp_fft_size_N/2];

                fft_get_magdb(tmp_ai_scale_data_buf[0], tmp_fft_mag_array, tmp_fft_size_N, config_para.ai_buf_fft_logN, (double)config_para.ai_chnl_range_upper);
                Buffer.BlockCopy(tmp_fft_mag_array, 0, config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_ready_to_update_idx], 0, tmp_fft_size_N / 2 * sizeof(double));

                fft_get_magdb(tmp_ai_scale_data_buf[1], tmp_fft_mag_array, tmp_fft_size_N, config_para.ai_buf_fft_logN, (double)config_para.ai_chnl_range_upper);
                Buffer.BlockCopy(tmp_fft_mag_array, 0, config_para.ai_update_buffer_array_fft[1][tmp_ai_buf_ready_to_update_idx], 0, tmp_fft_size_N / 2 * sizeof(double));
            }
            else
            {
                // Raw
                Buffer.BlockCopy(config_para.ai_scale_data_buf, 0, config_para.ai_update_buffer_array_raw[0][tmp_ai_buf_ready_to_update_idx], 0, (int)config_para.ai_chnl_sample_count * sizeof(double));

                // FFT
                int tmp_fft_size_N = 1 << config_para.ai_buf_fft_logN;
                double[] tmp_fft_mag_array = new double[tmp_fft_size_N/2];

                fft_get_magdb(config_para.ai_scale_data_buf, tmp_fft_mag_array, tmp_fft_size_N, config_para.ai_buf_fft_logN, (double)config_para.ai_chnl_range_upper);
                Buffer.BlockCopy(tmp_fft_mag_array, 0, config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_ready_to_update_idx], 0, tmp_fft_size_N / 2 * sizeof(double));
            }

            config_para.ai_buf_ready_cnt += 1;
            config_para.ai_buf_ready_idx += 1;
            config_para.ai_buf_ready_idx %= 2;
        }
        static CallbackDelegate ai_buf_ready_cbdel = new CallbackDelegate(ai_buf_ready_cbfunc);

        // Callback function for AO operation is complete
        static AutoResetEvent ao_done_event = new AutoResetEvent(false);
        static void ao_done_cbfunc()
        {
            // Set event
            ao_done_event.Set();
        }
        static CallbackDelegate ao_done_cbdel = new CallbackDelegate(ao_done_cbfunc);

        // Callback function for AI operation is complete
        static AutoResetEvent ai_done_event = new AutoResetEvent(false);
        static void ai_done_cbfunc()
        {
            // Set event
            ai_done_event.Set();
        }
        static CallbackDelegate ai_done_cbdel = new CallbackDelegate(ai_done_cbfunc);

        public frm_main()
        {
            InitializeComponent();

            // Initialize global variables
            fn_initial_structure();
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            // Configure 9527 common settings
            fn_p9527_config();

            // Configure 9527 AO settings
            fn_p9527_config_ao();

            // Configure 9527 AI settings
            fn_p9527_config_ai();

            // Configure 9527 trigger
            fn_p9527_config_trig();

            // Initial graph
            fn_zgrapg_initial();
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit " + this.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // Push Stop button
            if (config_para.is_op_started)
            {
                btn_device_start_Click(btn_device_start, null);
            }

            // Free all related reources and close the open device (if necessary)
            fn_free_resource(true);

            this.Cursor = Cursors.Default;
        }

        private void frm_xxxxx_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl is TextBox)
            {
                this.ActiveControl = this.ActiveControl.Parent;
            }
        }

        private void cbox_xxxxx_MouseHover(object sender, EventArgs e)
        {
            if (sender != null)
            {
                this.ActiveControl = (Control)sender;
            }
        }

        private void cbox_xxxxx_MouseLeave(object sender, EventArgs e)
        {
            if (sender != null)
            {
                this.ActiveControl = ((Control)sender).Parent;
            }
        }

        private void cbox_device_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Card type
            if (sender != null)
            {
                ComboBox tmp_cbox_device_type = (ComboBox)sender;
                config_para.card_subtype = (ushort)tmp_cbox_device_type.SelectedIndex;
                if (config_para.card_subtype > 1)
                {
                    config_para.card_subtype = 0;
                }
            }
        }

        private void cbox_device_index_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Card number
            if (sender != null)
            {
                ComboBox tmp_cbox_device_index = (ComboBox)sender;
                config_para.card_num = Convert.ToUInt16(tmp_cbox_device_index.SelectedItem.ToString());
            }
        }

        private void cbox_ao_enabled_CheckedChanged(object sender, EventArgs e)
        {
            // AO enabled
            if (sender != null)
            {
                CheckBox tmp_cbox_ao_enabled = (CheckBox)sender;
                config_para.is_ao_enabled = tmp_cbox_ao_enabled.Checked;
            }
        }

        private void cbox_ai_enabled_CheckedChanged(object sender, EventArgs e)
        {
            // AI enabled
            if (sender != null)
            {
                CheckBox tmp_cbox_ai_enabled = (CheckBox)sender;
                config_para.is_ai_enabled = tmp_cbox_ai_enabled.Checked;
            }
        }

        private void btn_device_open_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Button tmp_btn_device_open = (Button)sender;
                this.Cursor = Cursors.WaitCursor;
                if (config_para.is_reg_dev == false)
                {
                    // Register a specified device, it sets and initializes all related variables and necessary resources.
                    // This function must be called before calling any other functions to control the device.
                    // Remember to call DSA_Release_Card() to release all allocated resources.
                    short result = DSA_DASK.DSA_Register_Card(config_para.card_type, config_para.card_num);
                    if (result < 0)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Falied to perform DSA_Register_Card(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    config_para.card_handle = (ushort)result;
                    config_para.is_reg_dev = true;

                    if (config_para.is_ao_enabled)
                    {
                        this.gbox_ao_operation.Enabled = true;
                    }
                    if (config_para.is_ai_enabled)
                    {
                        this.gbox_ai_operation.Enabled = true;
                        this.zg_ai_wave_raw.Enabled = true;
                        this.zg_ai_wave_fft.Enabled = true;
                    }
                    this.btn_device_start.Enabled = true;

                    this.cbox_device_type.Enabled = false;
                    this.cbox_device_index.Enabled = false;
                    this.cbox_ao_enabled.Enabled = false;
                    this.cbox_ai_enabled.Enabled = false;

                    tmp_btn_device_open.Text = "Close Device";
                }
                else
                {
                    fn_free_resource(true);
                    config_para.card_handle = 0;
                    config_para.is_reg_dev = false;

                    this.gbox_ao_operation.Enabled = false;
                    this.gbox_ai_operation.Enabled = false;
                    this.zg_ai_wave_raw.Enabled = false;
                    this.zg_ai_wave_fft.Enabled = false;
                    this.btn_device_start.Enabled = false;

                    this.cbox_device_type.Enabled = true;
                    this.cbox_device_index.Enabled = true;
                    this.cbox_ao_enabled.Enabled = true;
                    this.cbox_ai_enabled.Enabled = true;

                    tmp_btn_device_open.Text = "Open Device";
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btn_device_start_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Button tmp_btn_device_start = (Button)sender;
                this.Cursor = Cursors.WaitCursor;
                if (config_para.is_op_started == false)
                {
                    //
                    // Start operation - configure all necessary settings
                    //
                    ushort[] ao_buf_id = new ushort[2];
                    ushort[] ai_buf_id = new ushort[2];

                    if (config_para.is_ao_enabled)
                    {
                        // AO Sine waveform data
                        config_para.sine_waveform = new uint[config_para.ao_chnl_sample_count];
                        uint sine_amplitude = (uint)((double)0x7FFFFF * (config_para.sine_waveform_amp / config_para.sine_waveform_amp_max)); // AO +FSR
                        uint sine_frequency = (uint)config_para.sine_waveform_freq;
                        uint sine_scaling = config_para.ao_sample_scaling;
                        for (int vi = 0; vi < config_para.ao_chnl_sample_count; ++vi)
                        {
                            config_para.sine_waveform[vi] = (uint)(sine_amplitude * Math.Sin((2 * Math.PI * vi * sine_frequency / sine_scaling) / config_para.ao_chnl_sample_count));
                        }

                        // Configure sampling rate for a registered device, it will return the actual sample rate.
                        // This function must be called before calling any AO-related functions to perform AO operation.
                        // There is a timing constraint when AI and AO function are enabled simultaneously.
                        // Please refer P9527 Hardware Manual section 3.5.3 for details.
                        short result = DSA_DASK.DSA_AO_9527_ConfigSampleRate(config_para.card_handle, config_para.ao_sample_rate, out config_para.ao_actual_rate);
                        if (result != DSA_DASK.NoError)
                        {
                            if (result == -81)
                            {
                                //this.Cursor = Cursors.Default;
                                //MessageBox.Show("Sample rate has been locked by AI job" + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //this.Cursor = Cursors.WaitCursor;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Falied to perform DSA_AO_9527_ConfigSampleRate(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                fn_free_resource(false);
                                return;
                            }
                        }

                        // Configure AO channel/function for a registered device
                        result = DSA_DASK.DSA_AO_9527_ConfigChannel(config_para.card_handle, config_para.ao_chnl_sel, config_para.ao_chnl_range, config_para.ao_chnl_config, false/*AutoReset*/);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AO_9527_ConfigChannel(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                    }

                    if (config_para.is_ai_enabled)
                    {
                        // Configure sampling rate for a registered device, it will return the actual sample rate.
                        // This function must be called before calling any AI-related functions to perform AI operation.
                        // There is a timing constraint when AI and AO function are enabled simultaneously.
                        // Please refer P9527 Hardware Manual section 3.5.3 for details.
                        short result = DSA_DASK.DSA_AI_9527_ConfigSampleRate(config_para.card_handle, config_para.ai_sample_rate, out config_para.ai_actual_rate);
                        if (result != DSA_DASK.NoError)
                        {
                            if (result == -81)
                            {
                                //this.Cursor = Cursors.Default;
                                //MessageBox.Show("Sample rate has been locked by AO job" + result, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //this.Cursor = Cursors.WaitCursor;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Falied to perform DSA_AI_9527_ConfigSampleRate(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                fn_free_resource(false);
                                return;
                            }
                        }

                        // Configure AI channel/function for a registered device
                        // This function may take a few seconds to initial and adjust ADC settings
                        result = DSA_DASK.DSA_AI_9527_ConfigChannel(config_para.card_handle, config_para.ai_chnl_sel, config_para.ai_chnl_range, config_para.ai_chnl_config, false/*AutoReset*/);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AI_9527_ConfigChannel(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                    }

                    // Configure trigger for a registered device
                    if (config_para.is_ao_enabled || config_para.is_ai_enabled)
                    {
                        // Configure trigger for a registered device
                        short result = DSA_DASK.DSA_TRG_Config(config_para.card_handle, config_para.trig_target, config_para.trig_config, config_para.retrig_count, config_para.trig_delay);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_TRG_Config(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }

                        // If trigger source is set to analog trigger by using DSA_TRG_Config(),
                        // This function should be called to setup analog trigger configurations.
                        // Due to refer AI input range setting, DSA_AI_9527_ConfigChannel() must be called before calling this function.
                        /*if (config_para.is_set_ana_trig)
                        {
                            result = DSA_DASK.DSA_TRG_ConfigAnalogTrigger(config_para.card_handle, config_para.ana_trig_src, config_para.ana_trig_mode, config_para.ana_trig_threshold);
                            if (result != DSA_DASK.NoError)
                            {
                                this.Cursor = Cursors.Default;
                                Console.Write("\nFalied to perform DSA_TRG_ConfigAnalogTrigger(), error: " + result);
                                fn_free_resource();
                                return;
                            }
                        }*/
                    }

                    if (config_para.is_ao_enabled)
                    {
                        // Enable double-buffer mode
                        // DSA-Dask provides a technique called double-buffer mode to perform continuous AO operation.
                        // Please refer DSA-DASK User Manual section 5.2 for details.
                        short result = DSA_DASK.DSA_AO_AsyncDblBufferMode(config_para.card_handle, true);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AO_AsyncDblBufferMode(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }

                        // Setup buffer for data transfer
                        // Allocates memory from the unmanaged memory of the process.
                        // Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
                        //       the memory might be moved by the GC and then an unexpected memory exception error is happened.
                        config_para.ao_raw_data_buf = new IntPtr[2];
                        config_para.ao_raw_data_buf[0] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ao_buf_size));
                        config_para.ao_raw_data_buf[1] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ao_buf_size));
                        for (int vi = 0; vi < 2; ++vi)
                        {
                            result = DSA_DASK.DSA_AO_ContBufferSetup(config_para.card_handle, config_para.ao_raw_data_buf[vi], config_para.ao_buf_size, out ao_buf_id[vi]);
                            if (result != DSA_DASK.NoError)
                            {
                                this.Cursor = Cursors.Default;
                                if (vi != 0)
                                {
                                    // Reset buffer
                                    DSA_DASK.DSA_AO_ContBufferReset(config_para.card_handle);
                                }
                                for (int vj = 0; vj < vi; ++vj)
                                {
                                    Marshal.FreeHGlobal(config_para.ao_raw_data_buf[vj]);
                                }
                                MessageBox.Show("Falied to perform DSA_AO_ContBufferSetup(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                fn_free_resource(false);
                                return;
                            }
                        }
                        config_para.is_ao_set_buf = true;

                        // Copy sine waveform to update buffer
                        uint[] tmp_ao_raw_data_buf_1 = new uint[config_para.ao_buf_size];
                        uint[] tmp_ao_raw_data_buf_2 = new uint[config_para.ao_buf_size];
                        for (ushort vi = 0; vi < config_para.ao_chnl_cnt; ++vi)
                        {
                            for (uint vj = 0; vj < config_para.ao_chnl_sample_count; ++vj)
                            {
                                uint tmp_buf_idx = vj * config_para.ao_chnl_cnt + vi;
                                if (tmp_buf_idx >= config_para.ao_buf_size)
                                {
                                    break;
                                }
                                tmp_ao_raw_data_buf_1[vj * config_para.ao_chnl_cnt + vi] = config_para.sine_waveform[vj];
                                tmp_ao_raw_data_buf_2[vj * config_para.ao_chnl_cnt + vi] = config_para.sine_waveform[vj];
                            }
                        }
                        Marshal.Copy((int[])(object)tmp_ao_raw_data_buf_1, 0, config_para.ao_raw_data_buf[0], (int)(config_para.ao_buf_size));
                        Marshal.Copy((int[])(object)tmp_ao_raw_data_buf_2, 0, config_para.ao_raw_data_buf[1], (int)(config_para.ao_buf_size));

                        // Set AO buffer Ready event
                        result = DSA_DASK.DSA_AO_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.DBEvent/*EventType*/, ao_buf_ready_cbdel);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AO_EventCallBack(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ao_buf_ready_evt_set = true;

                        // Set AO done event
                        result = DSA_DASK.DSA_AO_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.AOEnd/*EventType*/, ao_done_cbdel);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AO_EventCallBack(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ao_done_evt_set = true;
                    }

                    if (config_para.is_ai_enabled)
                    {
                        // Enable double-buffer mode
                        // DSA-Dask provides a technique called double-buffer mode to perform continuous AI operation.
                        // Please refer DSA-DASK User Manual section 5.2 for details.
                        short result = DSA_DASK.DSA_AI_AsyncDblBufferMode(config_para.card_handle, true);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AI_AsyncDblBufferMode(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }

                        // Setup buffer for data transfer
                        // Allocates memory from the unmanaged memory of the process.
                        // Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
                        //       the memory might be moved by the GC and then an unexpected memory exception error is happened.
                        config_para.ai_raw_data_buf = new IntPtr[2];
                        config_para.ai_raw_data_buf[0] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ai_buf_size));
                        config_para.ai_raw_data_buf[1] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ai_buf_size));
                        config_para.ai_scale_data_buf = new double[config_para.ai_buf_size];
                        config_para.ai_buf_id_array = new uint[1];
                        for (int vi = 0; vi < 2; ++vi)
                        {
                            result = DSA_DASK.DSA_AI_ContBufferSetup(config_para.card_handle, config_para.ai_raw_data_buf[vi], config_para.ai_buf_size, out ai_buf_id[vi]);
                            if (result != DSA_DASK.NoError)
                            {
                                this.Cursor = Cursors.Default;
                                if (vi != 0)
                                {
                                    // Reset buffer
                                    DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle);
                                }
                                for (int vj = 0; vj < vi; ++vj)
                                {
                                    Marshal.FreeHGlobal(config_para.ai_raw_data_buf[vj]);
                                }
                                MessageBox.Show("Falied to perform DSA_AI_ContBufferSetup(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                fn_free_resource(false);
                                return;
                            }
                        }
                        config_para.ai_buf_id_array[0] = ai_buf_id[0];
                        config_para.is_ai_set_buf = true;

                        // Create AI copy memory
                        for (uint vi = 0; vi < 2; ++ vi)
                        {
                            config_para.ai_update_buffer_array_raw[vi] = new double[config_para.ai_update_buffer_array_size][]; // for Raw data
                            config_para.ai_update_buffer_array_fft[vi] = new double[config_para.ai_update_buffer_array_size][]; // for FFT data
                            for (uint vj = 0; vj < config_para.ai_update_buffer_array_size; ++ vj)
                            {
                                config_para.ai_update_buffer_array_raw[vi][vj] = new double[config_para.ai_chnl_sample_count];
                                config_para.ai_update_buffer_array_fft[vi][vj] = new double[(1 << config_para.ai_buf_fft_logN) / 2];
                            }
                        }

                        // Set AI buffer Ready event
                        result = DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AI_EventCallBack(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ai_buf_ready_evt_set = true;

                        // Set AI done event
                        result = DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.AIEnd/*EventType*/, ai_done_cbdel);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AI_EventCallBack(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ai_done_evt_set = true;
                    }

                    if (config_para.is_ao_enabled)
                    {
                        config_para.ao_access_cnt = 0;
                        config_para.ao_buf_ready_idx = 0;
                        config_para.ao_buf_ready_cnt = -1;

                        // Write AO channel
                        short result = DSA_DASK.DSA_AO_ContWriteChannel(config_para.card_handle, config_para.ao_chnl_sel, ao_buf_id[0], config_para.ao_all_data_count, config_para.ao_upd_repeat_cnt, config_para.ao_upd_repeat_interval, config_para.ao_upd_op_definite, DSA_DASK.ASYNCH_OP);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AO_ContWriteChannel(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ao_op_run = true;

                        // Create timer for updating UI
                        config_para.ao_buf_update_cnt = -1;
                        config_para.locker_ao_update_data = new object();
                        config_para.tmr_ao_update_data = new System.Threading.Timer(new System.Threading.TimerCallback(fn_tmr_ao_update_data), new StackTrace(true).GetFrame(0).GetMethod().Name, 0, 1);
                    }

                    if (config_para.is_ai_enabled)
                    {
                        config_para.ai_access_cnt = 0;
                        config_para.ai_buf_ready_idx = 0;
                        config_para.ai_buf_ready_cnt = -1;

                        // Read AI data, and the acquired raw data will be stored in the set buffer.
                        short result = DSA_DASK.DSA_AI_ContReadChannel(config_para.card_handle, config_para.ai_chnl_sel, 0/*Ignored*/, config_para.ai_buf_id_array, config_para.ai_all_data_count, 0/*Ignored*/, DSA_DASK.ASYNCH_OP);
                        if (result != DSA_DASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform DSA_AI_ContReadChannel(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ai_op_run = true;

                        // Create timer for updating UI
                        config_para.ai_buf_update_cnt = -1;
                        config_para.locker_ai_update_data = new object();
                        config_para.tmr_ai_update_data = new System.Threading.Timer(new System.Threading.TimerCallback(fn_tmr_ai_update_data), new StackTrace(true).GetFrame(0).GetMethod().Name, 0, 1);
                    }

                    // Generate software trigger if the trigger source is set to software trigger
                    if (config_para.is_ao_enabled || config_para.is_ai_enabled)
                    {
                        if (config_para.is_gen_sw_trig)
                        {
                            DSA_DASK.DSA_TRG_SoftTriggerGen(config_para.card_handle);
                        }
                    }
                    config_para.is_op_started = true;

                    this.gbox_ao_sine_settings.Enabled = false;
                    this.gbox_ao_settings.Enabled = false;
                    this.gbox_ai_settings.Enabled = false;
                    this.btn_device_open.Enabled = false;

                    tmp_btn_device_start.Text = "Stop Operation";
                }
                else
                {
                    //
                    // Stop operation
                    //
                    if (config_para.is_ai_enabled)
                    {
                        // Dispose timer
                        config_para.tmr_ai_update_data.Dispose();

                        // Stop AI and clear AI setting
                        DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, out config_para.ai_access_cnt);
                        config_para.is_ai_op_run = false;

                        // Wait for that ai_done_cbfunc() is complete
                        ai_done_event.WaitOne();
                    }
                    if (config_para.is_ao_enabled)
                    {
                        // Dispose timer
                        config_para.tmr_ao_update_data.Dispose();

                        // Stop AO and clear AO setting
                        DSA_DASK.DSA_AO_AsyncClear(config_para.card_handle, out config_para.ao_access_cnt, 0);
                        config_para.is_ao_op_run = false;

                        // Wait for that ao_done_cbfunc() is complete
                        ao_done_event.WaitOne();
                    }
                    fn_free_resource(false);
                    config_para.is_op_started = false;

                    if (config_para.is_ao_enabled)
                    {
                        this.gbox_ao_sine_settings.Enabled = true;
                        this.gbox_ao_settings.Enabled = true;
                    }
                    if (config_para.is_ai_enabled)
                    {
                        this.gbox_ai_settings.Enabled = true;
                    }
                    this.btn_device_open.Enabled = true;

                    tmp_btn_device_start.Text = "Start Operation";
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void tbox_ao_sample_rate_Validating(object sender, CancelEventArgs e)
        {
            // AO Sample rate
            if (sender != null)
            {
                TextBox tmp_tbox_ao_sample_rate = (TextBox)sender;
                if (tmp_tbox_ao_sample_rate.Text == "")
                {
                    return;
                }

                double tmp_sample_rate = Convert.ToDouble(tmp_tbox_ao_sample_rate.Text);
                if (tmp_sample_rate < DSA_DASK.P9527_AO_MinDDSFreq)
                {
                    MessageBox.Show("AO sample rate must be greater than " + DSA_DASK.P9527_AO_MinDDSFreq + " Hz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sample_rate = DSA_DASK.P9527_AO_MinDDSFreq;
                }
                else if (tmp_sample_rate > DSA_DASK.P9527_AO_MaxDDSFreq)
                {
                    MessageBox.Show("AO sample rate must be less than " + DSA_DASK.P9527_AO_MaxDDSFreq + " Hz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sample_rate = DSA_DASK.P9527_AO_MaxDDSFreq;
                }

                if (tmp_sample_rate != config_para.ao_sample_rate)
                {
                    MessageBox.Show("AI sample rate must be twice of AO sample rate\n It may be changed automatically", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                config_para.ao_sample_rate = tmp_sample_rate;
                this.tbox_ao_sample_rate.Text = config_para.ao_sample_rate.ToString();
            }
        }

        private void tbox_ao_sample_rate_Validated(object sender, EventArgs e)
        {
            // AO Sample rate
            if (sender != null)
            {
                // AI Sample rate, twice of AO sample rate
                config_para.ai_sample_rate = config_para.ao_sample_rate * 2;
                this.tbox_ai_sample_rate.Text = config_para.ai_sample_rate.ToString();

                // AO waveform frequency, half of AO sample rate
                double max_wave_freq = config_para.ao_sample_rate / 2;
                if (config_para.sine_waveform_freq > max_wave_freq)
                {
                    config_para.sine_waveform_freq = max_wave_freq;
                }
                this.tbox_ao_sine_freqency.Text = config_para.sine_waveform_freq.ToString();

                // Set new AI buffer size
                config_para.ai_chnl_sample_count = (uint)(config_para.ai_sample_rate / config_para.ai_sample_scaling);
                config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
                config_para.ai_buf_size = config_para.ai_all_data_count;
                config_para.ai_buf_fft_logN = (int)Math.Log((double)config_para.ai_chnl_sample_count, 2);

                // Set new AO buffer size
                config_para.ao_chnl_sample_count = (uint)(config_para.ao_sample_rate / config_para.ao_sample_scaling);
                config_para.ao_all_data_count = config_para.ao_chnl_sample_count * config_para.ao_chnl_cnt;
                config_para.ao_buf_size = config_para.ao_all_data_count;

                // Reset AI graph
                GraphPane tmp_ai_wave_raw_pane = this.zg_ai_wave_raw.GraphPane;
                tmp_ai_wave_raw_pane.XAxis.Scale.Min = 0;
                tmp_ai_wave_raw_pane.XAxis.Scale.Max = config_para.ai_chnl_sample_count;
                this.zg_ai_wave_raw.AxisChange();
                this.zg_ai_wave_raw.Refresh();
                GraphPane tmp_ai_wave_fft_pane = this.zg_ai_wave_fft.GraphPane;
                tmp_ai_wave_fft_pane.XAxis.Scale.Min = 0;
                tmp_ai_wave_fft_pane.XAxis.Scale.Max = config_para.ai_sample_rate / 2;
                this.zg_ai_wave_fft.AxisChange();
                this.zg_ai_wave_fft.Refresh();
            }
        }

        private void tbox_ao_sample_rate_KeyDown(object sender, KeyEventArgs e)
        {
            // AO Sample rate
            if (sender != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void cbox_ao_channel_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            // AO channel select
            if (sender != null)
            {
                ComboBox tmp_cbox_ao_channel_select = (ComboBox)sender;
                ushort tmp_ao_chnl_select = (ushort)tmp_cbox_ao_channel_select.SelectedIndex;
                switch (tmp_ao_chnl_select)
                {
                    case 0:
                        config_para.ao_chnl_sel = (ushort)DSA_DASK.P9527_AO_CH_0;
                        config_para.ao_chnl_cnt = 1;
                        break;
                    case 1:
                        config_para.ao_chnl_sel = (ushort)DSA_DASK.P9527_AO_CH_1;
                        config_para.ao_chnl_cnt = 1;
                        break;
                    case 2:
                        config_para.ao_chnl_sel = (ushort)DSA_DASK.P9527_AO_CH_DUAL;
                        config_para.ao_chnl_cnt = 2;
                        break;
                    default:
                        config_para.ao_chnl_sel = (ushort)DSA_DASK.P9527_AO_CH_DUAL;
                        config_para.ao_chnl_cnt = 2;
                        break;
                }
                // Set new AO buffer size
                config_para.ao_all_data_count = config_para.ao_chnl_sample_count * config_para.ao_chnl_cnt;
                config_para.ao_buf_size = config_para.ao_all_data_count;
            }
        }

        private void cbox_ao_channel_range_SelectedIndexChanged(object sender, EventArgs e)
        {
            // AO channel range
            if (sender != null)
            {
                ComboBox tmp_cbox_ao_channel_range = (ComboBox)sender;
                ushort tmp_ao_chnl_range = (ushort)tmp_cbox_ao_channel_range.SelectedIndex;
                switch (tmp_ao_chnl_range)
                {
                    case 0:
                        config_para.ao_chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                        config_para.sine_waveform_amp_max = 20;
                        break;
                    case 1:
                        config_para.ao_chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                        config_para.sine_waveform_amp_max = 2;
                        break;
                    case 2:
                        config_para.ao_chnl_range = (ushort)DSA_DASK.AD_B_0_1_V;
                        config_para.sine_waveform_amp_max = 0.2;
                        break;
                    default:
                        config_para.ao_chnl_range = (ushort)DSA_DASK.AD_B_0_1_V;
                        config_para.sine_waveform_amp_max = 0.2;
                        break;
                }

                if (config_para.sine_waveform_amp > config_para.sine_waveform_amp_max)
                {
                    MessageBox.Show("AO sine wave amplitude must be less than " + config_para.sine_waveform_amp_max + " Vpp\n It will be changed automatically", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    config_para.sine_waveform_amp = config_para.sine_waveform_amp_max;
                    this.tbox_ao_sine_amplitude.Text = config_para.sine_waveform_amp.ToString();
                }
            }
        }

        private void cbox_ao_channel_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // AO channel output type
            if (sender != null)
            {
                ComboBox cbox_ao_channel_type = (ComboBox)sender;
                ushort tmp_ao_chnl_config = (ushort)cbox_ao_channel_type.SelectedIndex;
                switch (tmp_ao_chnl_config)
                {
                    case 0:
                        config_para.ao_chnl_config = (ushort)DSA_DASK.P9527_AO_Differential;
                        break;
                    case 1:
                        config_para.ao_chnl_config = (ushort)DSA_DASK.P9527_AO_PseudoDifferential;
                        break;
                    default:
                        config_para.ao_chnl_config = (ushort)DSA_DASK.P9527_AO_PseudoDifferential;
                        break;
                }
            }
        }

        private void cbox_ao_trigger_source_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reserved
        }

        private void tbox_ao_sine_freqency_Validating(object sender, CancelEventArgs e)
        {
            // AO Sine waveform frequency
            if (sender != null)
            {
                TextBox tmp_tbox_ao_sine_freqency = (TextBox)sender;
                if (tmp_tbox_ao_sine_freqency.Text == "")
                {
                    return;
                }

                double tmp_sine_waveform_freq = Convert.ToDouble(tmp_tbox_ao_sine_freqency.Text);
                double max_wave_freq = config_para.ao_sample_rate / 2;
                double min_wave_freq = config_para.ao_sample_scaling;
                if (tmp_sine_waveform_freq < min_wave_freq)
                {
                    MessageBox.Show("AO sine wave freqiency must be greater than " + min_wave_freq + " Hz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sine_waveform_freq = min_wave_freq;
                }
                else if (tmp_sine_waveform_freq > max_wave_freq)
                {
                    MessageBox.Show("AO sine wave freqiency must be less than " + max_wave_freq + " Hz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sine_waveform_freq = max_wave_freq;
                }

                config_para.sine_waveform_freq = tmp_sine_waveform_freq;
                this.tbox_ao_sine_freqency.Text = config_para.sine_waveform_freq.ToString();
            }
        }

        private void tbox_ao_sine_freqency_KeyDown(object sender, KeyEventArgs e)
        {
            // AO Sine waveform frequency
            if (sender != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void tbox_ao_sine_amplitude_Validating(object sender, CancelEventArgs e)
        {
            // AO Sine waveform amplitude
            if (sender != null)
            {
                TextBox tmp_tbox_ao_sine_amplitude = (TextBox)sender;
                if (tmp_tbox_ao_sine_amplitude.Text == "")
                {
                    return;
                }

                double tmp_sine_waveform_amp = Convert.ToDouble(tmp_tbox_ao_sine_amplitude.Text);
                if (tmp_sine_waveform_amp == 0)
                {
                    MessageBox.Show("AO sine wave amplitude can't be set to 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sine_waveform_amp = config_para.sine_waveform_amp;
                }
                else if (tmp_sine_waveform_amp > config_para.sine_waveform_amp_max)
                {
                    MessageBox.Show("AO sine wave amplitude must be less than " + config_para.sine_waveform_amp_max + " Vpp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sine_waveform_amp = config_para.sine_waveform_amp_max;
                }

                config_para.sine_waveform_amp = tmp_sine_waveform_amp;
                this.tbox_ao_sine_amplitude.Text = config_para.sine_waveform_amp.ToString();
            }
        }

        private void tbox_ao_sine_amplitude_KeyDown(object sender, KeyEventArgs e)
        {
            // AO Sine waveform amplitude
            if (sender != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void tbox_ai_sample_rate_Validating(object sender, CancelEventArgs e)
        {
            // AI Sample rate
            if (sender != null)
            {
                TextBox tmp_tbox_ai_sample_rate = (TextBox)sender;
                if (tmp_tbox_ai_sample_rate.Text == "")
                {
                    return;
                }

                double tmp_sample_rate = Convert.ToDouble(tmp_tbox_ai_sample_rate.Text);
                if (tmp_sample_rate < DSA_DASK.P9527_AI_MinDDSFreq)
                {
                    MessageBox.Show("AI sample rate must be greater than " + DSA_DASK.P9527_AI_MinDDSFreq + " Hz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sample_rate = DSA_DASK.P9527_AI_MinDDSFreq;
                }
                else if (tmp_sample_rate > DSA_DASK.P9527_AI_MaxDDSFreq)
                {
                    MessageBox.Show("AI sample rate must be less than " + DSA_DASK.P9527_AI_MaxDDSFreq + " Hz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sample_rate = DSA_DASK.P9527_AI_MaxDDSFreq;
                }

                if (tmp_sample_rate != config_para.ai_sample_rate)
                {
                    MessageBox.Show("AO sample rate must be half of AI sample rate\n It may be changed automatically", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                config_para.ai_sample_rate = tmp_sample_rate;
                this.tbox_ai_sample_rate.Text = config_para.ai_sample_rate.ToString();
            }
        }

        private void tbox_ai_sample_rate_Validated(object sender, EventArgs e)
        {
            // AI Sample rate
            if (sender != null)
            {
                // AO Sample rate, half of AI sample rate
                config_para.ao_sample_rate = config_para.ai_sample_rate / 2;
                this.tbox_ao_sample_rate.Text = config_para.ao_sample_rate.ToString();

                // AO waveform frequency, half of AO sample rate
                double max_wave_freq = config_para.ao_sample_rate / 2;
                if (config_para.sine_waveform_freq > max_wave_freq)
                {
                    config_para.sine_waveform_freq = max_wave_freq;
                }
                this.tbox_ao_sine_freqency.Text = config_para.sine_waveform_freq.ToString();

                // Set new AI buffer size
                config_para.ai_chnl_sample_count = (uint)(config_para.ai_sample_rate / config_para.ai_sample_scaling);
                config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
                config_para.ai_buf_size = config_para.ai_all_data_count;
                config_para.ai_buf_fft_logN = (int)Math.Log((double)config_para.ai_chnl_sample_count, 2);

                // Set new AO buffer size
                config_para.ao_chnl_sample_count = (uint)(config_para.ao_sample_rate / config_para.ao_sample_scaling);
                config_para.ao_all_data_count = config_para.ao_chnl_sample_count * config_para.ao_chnl_cnt;
                config_para.ao_buf_size = config_para.ao_all_data_count;

                // Reset AI graph
                GraphPane tmp_ai_wave_raw_pane = this.zg_ai_wave_raw.GraphPane;
                tmp_ai_wave_raw_pane.XAxis.Scale.Min = 0;
                tmp_ai_wave_raw_pane.XAxis.Scale.Max = config_para.ai_chnl_sample_count;
                this.zg_ai_wave_raw.AxisChange();
                this.zg_ai_wave_raw.Refresh();
                GraphPane tmp_ai_wave_fft_pane = this.zg_ai_wave_fft.GraphPane;
                tmp_ai_wave_fft_pane.XAxis.Scale.Min = 0;
                tmp_ai_wave_fft_pane.XAxis.Scale.Max = config_para.ai_sample_rate / 2;
                this.zg_ai_wave_fft.AxisChange();
                this.zg_ai_wave_fft.Refresh();
            }
        }

        private void tbox_ai_sample_rate_KeyDown(object sender, KeyEventArgs e)
        {
            // AI Sample rate
            if (sender != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void cbox_ai_channel_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            // AI channel select
            if (sender != null)
            {
                ComboBox tmp_cbox_ai_channel_select = (ComboBox)sender;
                ushort tmp_ai_chnl_select = (ushort)tmp_cbox_ai_channel_select.SelectedIndex;
                switch (tmp_ai_chnl_select)
                {
                    case 0:
                        config_para.ai_chnl_sel = (ushort)DSA_DASK.P9527_AI_CH_0;
                        config_para.ai_chnl_cnt = 1;
                        break;
                    case 1:
                        config_para.ai_chnl_sel = (ushort)DSA_DASK.P9527_AI_CH_1;
                        config_para.ai_chnl_cnt = 1;
                        break;
                    case 2:
                        config_para.ai_chnl_sel = (ushort)DSA_DASK.P9527_AI_CH_DUAL;
                        config_para.ai_chnl_cnt = 2;
                        break;
                    default:
                        config_para.ai_chnl_sel = (ushort)DSA_DASK.P9527_AI_CH_DUAL;
                        config_para.ai_chnl_cnt = 2;
                        break;
                }
                // Set new AI buffer size
                config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
                config_para.ai_buf_size = config_para.ai_all_data_count;
            }
        }

        private void cbox_ai_channel_range_SelectedIndexChanged(object sender, EventArgs e)
        {
            // AI channel range
            if (sender != null)
            {
                ComboBox tmp_cbox_ai_channel_range = (ComboBox)sender;
                ushort tmp_ai_chnl_range = (ushort)tmp_cbox_ai_channel_range.SelectedIndex;
                switch (tmp_ai_chnl_range)
                {
                    case 0:
                        config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_40_V;
                        config_para.ai_chnl_range_upper = 40;
                        config_para.ai_chnl_range_lower = -40;
                        break;
                    case 1:
                        config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                        config_para.ai_chnl_range_upper = 10;
                        config_para.ai_chnl_range_lower = -10;
                        break;
                    case 2:
                        config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_3_16_V;
                        config_para.ai_chnl_range_upper = 3.16;
                        config_para.ai_chnl_range_lower = -3.16;
                        break;
                    case 3:
                        config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                        config_para.ai_chnl_range_upper = 1;
                        config_para.ai_chnl_range_lower = -1;
                        break;
                    case 4:
                        config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_0_316_V;
                        config_para.ai_chnl_range_upper = 0.316;
                        config_para.ai_chnl_range_lower = -0.316;
                        break;
                    default:
                        config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_0_316_V;
                        config_para.ai_chnl_range_upper = 0.316;
                        config_para.ai_chnl_range_lower = -0.316;
                        break;
                }

                // Change graph Y Axis
                GraphPane tmp_ai_wave_raw_pane = this.zg_ai_wave_raw.GraphPane;
                tmp_ai_wave_raw_pane.YAxis.Scale.Min = config_para.ai_chnl_range_lower;
                tmp_ai_wave_raw_pane.YAxis.Scale.Max = config_para.ai_chnl_range_upper;
                this.zg_ai_wave_raw.AxisChange();
                this.zg_ai_wave_raw.Refresh();
            }
        }

        private void cbox_ai_channel_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // AI channel input type
            if (sender != null)
            {
                ComboBox cbox_ai_channel_type = (ComboBox)sender;
                ushort tmp_ai_chnl_config = (ushort)cbox_ai_channel_type.SelectedIndex;
                switch (tmp_ai_chnl_config)
                {
                    case 0:
                        config_para.ai_chnl_config = (ushort)(DSA_DASK.P9527_AI_Differential | DSA_DASK.P9527_AI_Coupling_DC);
                        break;
                    case 1:
                        config_para.ai_chnl_config = (ushort)(DSA_DASK.P9527_AI_Differential | DSA_DASK.P9527_AI_Coupling_AC);
                        break;
                    case 2:
                        config_para.ai_chnl_config = (ushort)(DSA_DASK.P9527_AI_Differential | DSA_DASK.P9527_AI_EnableIEPE);
                        break;
                    case 3:
                        config_para.ai_chnl_config = (ushort)(DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_Coupling_DC);
                        break;
                    case 4:
                        config_para.ai_chnl_config = (ushort)(DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_Coupling_AC);
                        break;
                    case 5:
                        config_para.ai_chnl_config = (ushort)(DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_EnableIEPE);
                        break;
                    default:
                        config_para.ai_chnl_config = (ushort)(DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_Coupling_DC);
                        break;
                }
            }
        }

        private void cbox_ai_trigger_source_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reserved
        }
    }
}
