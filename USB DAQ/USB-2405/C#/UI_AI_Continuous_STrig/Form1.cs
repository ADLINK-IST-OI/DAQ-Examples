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
    struct file_header
    {
        public ushort ai_chnl_cnt;
        public ushort reserved0;
        public uint reserved1;
        public uint reserved2;
        public uint reserved3;
        public double ai_chnl_sensitivity0;
        public double ai_chnl_sensitivity1;
        public double ai_chnl_sensitivity2;
        public double ai_chnl_sensitivity3;
    }

    struct program_config
    {
        //
        // Program status
        //
        public bool is_reg_dev;
        public bool is_op_started;
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
        // AI
        public double ai_sample_rate;
        // 05/05/16
        public /*uint*/double ai_sample_scaling;

        //
        // Channel configuration variables
        //
        // AI
        public ushort[] ai_chnl_sel;
        public ushort ai_chnl_cnt;
        public ushort ai_chnl_range;
        public ushort ai_chnl_config;
        public double ai_chnl_range_upper;
        public double ai_chnl_range_lower;

        //
        // Trigger configuration variables
        //
        public ushort conv_src;
        public ushort trig_mode;
        public ushort trig_control;
        public uint retrig_count;
        public uint trig_delay;
        public uint trig_delay2;
        public bool is_set_ana_trig;

        //
        // Analog trigger configuration variables
        //
        public uint ana_trig_src;
        public uint ana_trig_threshold;

        //
        // Data buffer & file variables
        //
        // AI
        public uint ai_chnl_sample_count;
        public uint ai_all_data_count;
        public uint ai_buf_size;
        public IntPtr[] ai_raw_data_buf;
        public double[] ai_scale_data_buf;

        //
        // Operation status variables
        //
        // AI
        public uint ai_access_cnt;
        public uint ai_buf_ready_idx;
        public long ai_buf_ready_cnt;

        //
        // Sensor settings
        //
        public uint ai_sensor_settings;
        public double[] ai_sensor_ch_sensitivity;
        public uint ai_ch_magnitude_unit;

        //
        // UI update variables
        //
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
        // ZG Color
        public Color[] zg_color;

        //
        // Data Logger
        //
        public frm_logger data_logger_form;
        public string data_logger_path;
        public double data_logger_seconds;
        public bool data_logger_enabled;
        public bool data_logger_started;
        public FileStream data_logger_file_writer;
        public bool data_logger_file_open;
    }

    public partial class frm_main : Form
    {
        static USBDAQ_DEVICE[] avail_modules = new USBDAQ_DEVICE[USBDASK.MAX_USB_DEVICE];
        static program_config config_para;
        static file_header file_info;

        public void fn_rsset_data_logger_form()
        {
            config_para.data_logger_form = null;
        }

        public void fn_set_data_logger_path(string data_logger_path)
        {
            config_para.data_logger_path = data_logger_path;
        }

        public void fn_get_data_logger_path(out string data_logger_path)
        {
            data_logger_path = config_para.data_logger_path;
        }

        public void fn_set_data_logger_seconds(double data_logger_seconds)
        {
            config_para.data_logger_seconds = data_logger_seconds;
        }

        public void fn_get_data_logger_seconds(out double data_logger_seconds)
        {
            data_logger_seconds = config_para.data_logger_seconds;
        }

        public void fn_set_data_logger_enabled(bool data_logger_enabled)
        {
            config_para.data_logger_enabled = data_logger_enabled;
        }

        public void fn_get_data_logger_enabled(out bool data_logger_enabled)
        {
            data_logger_enabled = config_para.data_logger_enabled;
        }

        public void fn_set_data_logger_started(bool data_logger_started)
        {
            config_para.data_logger_started = data_logger_started;
        }

        public void fn_get_data_logger_started(out bool data_logger_started)
        {
            data_logger_started = config_para.data_logger_started;
        }

        public void fn_initial_structure()
        {
            //
            // Program status
            //
            config_para.is_reg_dev = false;
            config_para.is_op_started = false;
            // AI
            config_para.is_ai_enabled = true;
            config_para.is_ai_set_buf = false;
            config_para.is_ai_op_run = false;
            config_para.is_ai_done_evt_set = false;
            config_para.is_ai_buf_ready_evt_set = false;

            //
            // Device configuration variables
            //
            config_para.card_type = USBDASK.USB_2405;
            config_para.card_subtype = 0;
            config_para.card_num = 0;
            config_para.card_handle = 0;

            //
            // Sample rate configuration variables
            //
            // AI
            config_para.ai_sample_rate = 20480;
            config_para.ai_sample_scaling = 0.625;

            //
            // Channel configuration variables
            //
            // AI
            config_para.ai_chnl_sel = new ushort[4] {USBDASK.P2405_AI_CH_0, USBDASK.P2405_AI_CH_1, USBDASK.P2405_AI_CH_2, USBDASK.P2405_AI_CH_3};
            config_para.ai_chnl_cnt = 1;
            config_para.ai_chnl_range = USBDASK.AD_B_10_V;
            config_para.ai_chnl_config = USBDASK.P2405_AI_PseudoDifferential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_EnableIEPE;
            config_para.ai_chnl_range_upper = 10;
            config_para.ai_chnl_range_lower = -10;

            //
            // Trigger configuration variables
            //
            config_para.conv_src = USBDASK.P2405_AI_CONVSRC_INT;
            config_para.trig_mode = USBDASK.P2405_AI_TRGMOD_POST;
            config_para.trig_control = USBDASK.P2405_AI_TRGSRC_SOFT;
            config_para.retrig_count = 0;
            config_para.trig_delay = 0;
            config_para.trig_delay2 = 0;
            config_para.is_set_ana_trig = false;

            //
            // Analog trigger configuration variables
            //
            config_para.ana_trig_src = 0;
            config_para.ana_trig_threshold = 0;

            //
            // Data buffer & file variables
            //
            // AI
            config_para.ai_chnl_sample_count = ((uint)(config_para.ai_sample_rate / config_para.ai_sample_scaling) + 255) / 256 * 256;
            config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
            config_para.ai_buf_size = config_para.ai_all_data_count;
            //config_para.ai_raw_data_buf;
            //config_para.ai_scale_data_buf;

            //
            // Operation status variables
            //
            // AI
            config_para.ai_access_cnt = 0;
            config_para.ai_buf_ready_idx = 0;
            config_para.ai_buf_ready_cnt = -1;

            //
            // Sensor settings
            //
            config_para.ai_sensor_settings = 0;
            config_para.ai_sensor_ch_sensitivity = new double[4] {1.0, 1.0, 1.0, 1.0};
            config_para.ai_ch_magnitude_unit = /*2*/0; // 05/05/16 set default to V and remove dB

            //
            // UI update variables
            //
            // AI
            //config_para.tmr_ai_update_data;
            //config_para.locker_ai_update_data;
            config_para.ai_buf_update_cnt = -1;
            // AI data
            config_para.ai_update_buffer_array_size = 8;
            config_para.ai_update_buffer_array_raw = new double[4][][]; // maximum of 4CH
            // AI FFT
            config_para.ai_update_buffer_array_fft = new double[4][][]; // maximum of 4CH
            config_para.ai_buf_fft_logN = (int)Math.Log((double)config_para.ai_chnl_sample_count, 2);
            // ZG Color
            config_para.zg_color = new Color[4] { Color.Red, Color.Blue, Color.Green, Color.Purple };

            //
            // Data Logger
            //
            config_para.data_logger_form = null;
            config_para.data_logger_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\data_logger.bin";
            config_para.data_logger_seconds = 5;
            config_para.data_logger_enabled = true;
            config_para.data_logger_started = false;
            //config_para.data_logger_file_writer;
            config_para.data_logger_file_open = false;

            //
            // File header
            //
            file_info.ai_chnl_cnt = config_para.ai_chnl_cnt;
            file_info.ai_chnl_sensitivity0 = config_para.ai_sensor_ch_sensitivity[0];
            file_info.ai_chnl_sensitivity1 = config_para.ai_sensor_ch_sensitivity[1];
            file_info.ai_chnl_sensitivity2 = config_para.ai_sensor_ch_sensitivity[2];
            file_info.ai_chnl_sensitivity3 = config_para.ai_sensor_ch_sensitivity[3];
        }

        // Scan USB modules
        public short fn_scan_usb_modules(ushort module_type, USBDAQ_DEVICE[] module_array)
        {
            short tmp_module_index = -1;

            // scan the active USB DASK module
            ushort tmp_module_cnt;
            short result = USBDASK.UD_Device_Scan(out tmp_module_cnt, out module_array[0]);
            if (result == USBDASK.NoError)
            {
                for (short vi = 0; vi < tmp_module_cnt; ++vi)
                {
                    if (module_array[vi].wModuleType == module_type)
                    {
                        tmp_module_index = (short)module_array[vi].wCardID;
                        break;
                    }
                }
            }
            return tmp_module_index;
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
            tmp_ai_wave_fft_pane.YAxis.Scale.Max = 100;

            this.zg_ai_wave_fft.AxisChange();
            this.zg_ai_wave_fft.Refresh();
        }

        // Configuration function for 2405
        public void fn_u2405_config()
        {
            // Sub-card type
            this.cbox_device_type.SelectedIndex = config_para.card_subtype;

            // Card number
            this.cbox_device_index.SelectedIndex = config_para.card_num;
        }

        // AI Configuration function for 2405
        public void fn_u2405_config_ai()
        {
            // AI Sample rate
            this.tbox_ai_sample_rate.Text = config_para.ai_sample_rate.ToString();

            // AI channel select
            switch (config_para.ai_chnl_cnt)
            {
                case 1:
                    this.cbox_ai_channel_select.SelectedIndex = 0;
                    this.tbox_sensor_ch0_sensitivity.Enabled = true;
                    this.tbox_sensor_ch1_sensitivity.Enabled = false;
                    this.tbox_sensor_ch2_sensitivity.Enabled = false;
                    this.tbox_sensor_ch3_sensitivity.Enabled = false;
                    break;
                case 2:
                    this.cbox_ai_channel_select.SelectedIndex = 1;
                    this.tbox_sensor_ch0_sensitivity.Enabled = true;
                    this.tbox_sensor_ch1_sensitivity.Enabled = true;
                    this.tbox_sensor_ch2_sensitivity.Enabled = false;
                    this.tbox_sensor_ch3_sensitivity.Enabled = false;
                    break;
                case 3:
                    this.cbox_ai_channel_select.SelectedIndex = 2;
                    this.tbox_sensor_ch0_sensitivity.Enabled = true;
                    this.tbox_sensor_ch1_sensitivity.Enabled = true;
                    this.tbox_sensor_ch2_sensitivity.Enabled = true;
                    this.tbox_sensor_ch3_sensitivity.Enabled = false;
                    break;
                case 4:
                    this.cbox_ai_channel_select.SelectedIndex = 3;
                    this.tbox_sensor_ch0_sensitivity.Enabled = true;
                    this.tbox_sensor_ch1_sensitivity.Enabled = true;
                    this.tbox_sensor_ch2_sensitivity.Enabled = true;
                    this.tbox_sensor_ch3_sensitivity.Enabled = true;
                    break;
                default:
                    this.cbox_ai_channel_select.SelectedIndex = 0;
                    this.tbox_sensor_ch0_sensitivity.Enabled = true;
                    this.tbox_sensor_ch1_sensitivity.Enabled = false;
                    this.tbox_sensor_ch2_sensitivity.Enabled = false;
                    this.tbox_sensor_ch3_sensitivity.Enabled = false;
                    break;
            }

            // AI channel range
            switch (config_para.ai_chnl_range)
            {
                case USBDASK.AD_B_10_V:
                default:
                    this.cbox_ai_channel_range.SelectedIndex = 0;
                    break;
            }

            // AI channel input type
            switch (config_para.ai_chnl_config)
            {
                case (USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_DisableIEPE):
                    this.cbox_ai_channel_type.SelectedIndex = 0;
                    break;
                case (USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_DisableIEPE):
                    this.cbox_ai_channel_type.SelectedIndex = 1;
                    break;
                case (USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_EnableIEPE):
                    this.cbox_ai_channel_type.SelectedIndex = 2;
                    break;
                case (USBDASK.P2405_AI_PseudoDifferential | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_DisableIEPE):
                    this.cbox_ai_channel_type.SelectedIndex = 3;
                    break;
                case (USBDASK.P2405_AI_PseudoDifferential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_DisableIEPE):
                    this.cbox_ai_channel_type.SelectedIndex = 4;
                    break;
                case (USBDASK.P2405_AI_PseudoDifferential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_EnableIEPE):
                    this.cbox_ai_channel_type.SelectedIndex = 5;
                    break;
                default:
                    this.cbox_ai_channel_type.SelectedIndex = 3;
                    break;
            }

            //
            // Sensor settings
            //
            this.cbox_ai_sensor_settings.SelectedIndex = (int)config_para.ai_sensor_settings;
            this.tbox_sensor_ch0_sensitivity.Text = config_para.ai_sensor_ch_sensitivity[0].ToString();
            this.tbox_sensor_ch1_sensitivity.Text = config_para.ai_sensor_ch_sensitivity[1].ToString();
            this.tbox_sensor_ch2_sensitivity.Text = config_para.ai_sensor_ch_sensitivity[2].ToString();
            this.tbox_sensor_ch3_sensitivity.Text = config_para.ai_sensor_ch_sensitivity[3].ToString();
            this.cbox_ai_ch_magnitude_unit.SelectedIndex = (int)config_para.ai_ch_magnitude_unit;
        }

        // TRIG Configuration function for 2405
        public void fn_u2405_config_trig()
        {
            //
            // Reserved for configuring AI trigger settings
            //

            // AI trigger source (only support software trigger)
            ushort tmp_trig_source = (ushort)(config_para.trig_control & 0x398);
            switch (tmp_trig_source)
            {
                case USBDASK.P2405_AI_TRGSRC_SOFT:
                default:
                    this.cbox_ai_trigger_source.SelectedIndex = 0;
                    break;
            }
        }

        // Resource release handler
        public void fn_free_resource(bool f_release_card)
        {
            if (config_para.is_ai_op_run)
            {
                // Async Clear
                USBDASK.UD_AI_AsyncClear(config_para.card_handle, out config_para.ai_access_cnt);
                config_para.is_ai_op_run = false;
            }

            if (config_para.is_ai_done_evt_set)
            {
                // Reset done event
                USBDASK.UD_AI_EventCallBack(config_para.card_handle, 0/*remove*/, USBDASK.AIEnd/*EventType*/, ai_done_cbdel);
                config_para.is_ai_done_evt_set = false;
            }

            if (config_para.is_ai_buf_ready_evt_set)
            {
                // Reset buffer ready event
                USBDASK.UD_AI_EventCallBack(config_para.card_handle, 0/*remove*/, USBDASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
                config_para.is_ai_buf_ready_evt_set = false;
            }

            if (config_para.is_ai_set_buf)
            {
                // Reset buffer
                Marshal.FreeHGlobal(config_para.ai_raw_data_buf[0]);
                Marshal.FreeHGlobal(config_para.ai_raw_data_buf[1]);
                config_para.is_ai_set_buf = false;
            }

            if (config_para.is_reg_dev && f_release_card)
            {
                // Release device
                short err = USBDASK.UD_Release_Card(config_para.card_handle);
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
                // 05/05/16ignore DC (Less than 6Hz)
                if (fft_freq[vi] < 6)
                {
                    continue;
                }
                if (fft_mag[vi] > max_magdb)
                {
                    max_magdb = fft_mag[vi];
                    ret_freq = fft_freq[vi];
                }
            }

            max_mag = max_magdb;
            return ret_freq;
        }

        static double fft_magdb_freq(double[] fft_mag, double[] fft_freq, int fft_logN, double sample_rate, uint max_mag_cnt, out double[] max_mag_array)
        {
            double ret_freq = 0;
            uint max_magdb_bin = 0;
            double[] max_magdb_array = new double [max_mag_cnt];

            for (uint vi = 0; vi < max_mag_cnt; ++ vi)
            {
                max_magdb_array[vi] = double.MinValue;
            }

            int fft_size = (1 << fft_logN);
            double fft_bin_space = sample_rate / fft_size;
            for (uint vi = 0; vi < fft_size / 2; ++vi)
            {
                fft_freq[vi] = vi * fft_bin_space;
                // 05/05/16 Ignore DC (Less than 6Hz)
                if (fft_freq[vi] < 6)
                {
                    continue;
                }
                if (fft_mag[vi] > max_magdb_array[0])
                {
                    ret_freq = fft_freq[vi];
                    max_magdb_bin = vi;
                    max_magdb_array[0] = fft_mag[vi];
                }
            }

            for (uint vi = 1; vi < max_mag_cnt; ++ vi)
            {
                uint tmp_max_magdb_bin = max_magdb_bin * (vi + 1);
                if (tmp_max_magdb_bin < fft_size / 2)
                {
                    max_magdb_array[vi] = fft_mag[tmp_max_magdb_bin];
                }
            }

            max_mag_array = max_magdb_array;
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
                fft_mag[vi] = 10 * Math.Log10(4 * (re[vi] * re[vi] + im[vi] * im[vi]) / ((double)fft_size * (double)fft_size) / (fft_full_scale * fft_full_scale));
            }
        }

        static double fft_magdb_volt(double magdb, double full_scale)
        {
            return (full_scale * Math.Pow(10, magdb/20));
        }

        static double accelerometer_mv_2_g(double mv, double sensitivity)
        {
            return (mv / sensitivity);
        }

        // 05/05/16
        static void fn_find_peak(double[] data, uint length, out double max_value, out uint max_pos, out double min_value, out uint min_pos)
        {
            max_value = Double.MinValue;
            max_pos = 0;
            min_value = Double.MaxValue;
            min_pos = 0;

            for (uint vi = 0; vi < length; ++vi)
            {
                if (data[vi] > max_value)
                {
                    max_value = data[vi];
                    max_pos = vi;
                }
                if (data[vi] < min_value)
                {
                    min_value = data[vi];
                    min_pos = vi;
                }
            }
        }

        static void fn_find_peak(double[] data, uint length, uint average, out double max_value, out double min_value)
        {
            Array.Sort<double>(data);

            if (average > length / 2)
            {
                average = length / 2;
            }
            
            max_value = 0;
            min_value = 0;

            for (uint vi = 0; vi < average; ++ vi)
            {
                min_value += data[vi];
                max_value += data[length - 1 - vi];
            }
            min_value /= average;
            max_value /= average;
        }

        static void fn_find_peak(double[] data, uint length, uint average, uint ignore, out double max_value, out double min_value)
        {
            Array.Sort<double>(data);
            if (average > length / 2)
            {
                ignore = 0;
                average = length / 2;  
            }
            else if (ignore + average > length / 2)
            {
                ignore = length / 2 - average;
            }

            max_value = 0;
            min_value = 0;

            for (uint vi = ignore; vi < ignore + average; ++ vi)
            {
                min_value += data[vi];
                max_value += data[length - 1 - vi];
            }
            min_value /= average;
            max_value /= average;
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

                    // 05/05/16 add peak amplitude
                    TextBox[] tmp_tbox_ai_ch_amplitude = new TextBox[4] { this.tbox_ai_ch0_amplitude, this.tbox_ai_ch1_amplitude, this.tbox_ai_ch2_amplitude, this.tbox_ai_ch3_amplitude };
                    
                    LineItem[] tmp_ai_wave_raw_curve = new LineItem[config_para.ai_chnl_cnt];
                    for (ushort vi = 0; vi < config_para.ai_chnl_cnt; ++ vi)
                    {
                        tmp_ai_wave_raw_curve[vi] = tmp_ai_wave_raw_pane.AddCurve("CH" + vi.ToString(), null, config_para.ai_update_buffer_array_raw[vi][tmp_ai_buf_update_idx], config_para.zg_color[vi], SymbolType.None);
                        tmp_ai_wave_raw_curve[vi].Line.IsSmooth = true;
                    
                        double max_value, min_value;
                        //uint max_pos, min_pos;
                        //fn_find_peak(config_para.ai_update_buffer_array_raw[vi][tmp_ai_buf_update_idx], config_para.ai_chnl_sample_count, out max_value, out max_pos, out min_value, out min_pos);
                        uint average = 1024;
                        //fn_find_peak(config_para.ai_update_buffer_array_raw[vi][tmp_ai_buf_update_idx], config_para.ai_chnl_sample_count, average, out max_value, out min_value);
                        uint ignore = 1024;
                        fn_find_peak(config_para.ai_update_buffer_array_raw[vi][tmp_ai_buf_update_idx], config_para.ai_chnl_sample_count, average, ignore, out max_value, out min_value);

                        switch (config_para.ai_ch_magnitude_unit)
                        {
                            case 0:
                            default:
                                // V
                                tmp_tbox_ai_ch_amplitude[vi].Text = ((max_value - min_value) / 2).ToString("F6");
                                break;
                            case 1:
                                // g
                                tmp_tbox_ai_ch_amplitude[vi].Text = accelerometer_mv_2_g(((max_value - min_value) / 2) * 1000, config_para.ai_sensor_ch_sensitivity[vi]).ToString("F6");
                                break;
                        }
                    }

                    this.zg_ai_wave_raw.AxisChange();
                    this.zg_ai_wave_raw.Refresh();

                    // FFT data graph
                    GraphPane tmp_ai_wave_fft_pane = this.zg_ai_wave_fft.GraphPane;
                    tmp_ai_wave_fft_pane.CurveList.Clear();

                    TextBox[] tmp_tbox_ai_ch_frequency = new TextBox[4] {this.tbox_ai_ch0_frequency, this.tbox_ai_ch1_frequency, this.tbox_ai_ch2_frequency, this.tbox_ai_ch3_frequency};
                    TextBox[] tmp_tbox_ai_ch_magnitude = new TextBox[4] {this.tbox_ai_ch0_magnitude, this.tbox_ai_ch1_magnitude, this.tbox_ai_ch2_magnitude, this.tbox_ai_ch3_magnitude};
                    TextBox[] tmp_tbox_ai_ch_magnitude2 = new TextBox[4] {this.tbox_ai_ch0_magnitude2, this.tbox_ai_ch1_magnitude2, this.tbox_ai_ch2_magnitude2, this.tbox_ai_ch3_magnitude2};
                    TextBox[] tmp_tbox_ai_ch_magnitude3 = new TextBox[4] {this.tbox_ai_ch0_magnitude3, this.tbox_ai_ch1_magnitude3, this.tbox_ai_ch2_magnitude3, this.tbox_ai_ch3_magnitude3};

                    int tmp_fft_size_N = (1 << config_para.ai_buf_fft_logN);

                    for (ushort vi = 0; vi < config_para.ai_chnl_cnt; ++ vi)
                    {
                        double[] tmp_ai_ch_mag_max_array = new double[3]; // X3 magnitude
                        double[] tmp_ai_ch_freq_array = new double[tmp_fft_size_N / 2];
                        double tmp_ai_ch_freq = fft_magdb_freq(config_para.ai_update_buffer_array_fft[vi][tmp_ai_buf_update_idx], tmp_ai_ch_freq_array, config_para.ai_buf_fft_logN, config_para.ai_sample_rate, 3, out tmp_ai_ch_mag_max_array);

                        LineItem tmp_ai_wave_fft_curve = tmp_ai_wave_fft_pane.AddCurve("CH" + vi.ToString(), tmp_ai_ch_freq_array, config_para.ai_update_buffer_array_fft[vi][tmp_ai_buf_update_idx], config_para.zg_color[vi], SymbolType.None);
                        tmp_ai_wave_fft_curve.Line.IsSmooth = true;

                        // Wave frequency
                        tmp_tbox_ai_ch_frequency[vi].Text = tmp_ai_ch_freq.ToString();
                        // Wave magnitude 1X, 2X, 3X
                        switch (config_para.ai_ch_magnitude_unit)
                        {
                            // 05/05/16 remove dB
                            /*case 0:
                                // dB
                                tmp_tbox_ai_ch_magnitude[vi].Text = tmp_ai_ch_mag_max_array[0].ToString();
                                tmp_tbox_ai_ch_magnitude2[vi].Text = (tmp_ai_ch_mag_max_array[1] == double.MinValue) ? "" : tmp_ai_ch_mag_max_array[1].ToString();
                                tmp_tbox_ai_ch_magnitude3[vi].Text = (tmp_ai_ch_mag_max_array[2] == double.MinValue) ? "" : tmp_ai_ch_mag_max_array[2].ToString();
                                break;
                            case 1:
                                // V
                                tmp_tbox_ai_ch_magnitude[vi].Text = fft_magdb_volt(tmp_ai_ch_mag_max_array[0], (double)config_para.ai_chnl_range_upper).ToString();
                                tmp_tbox_ai_ch_magnitude2[vi].Text = (tmp_ai_ch_mag_max_array[1] == double.MinValue) ? "" : fft_magdb_volt(tmp_ai_ch_mag_max_array[1], (double)config_para.ai_chnl_range_upper).ToString();
                                tmp_tbox_ai_ch_magnitude3[vi].Text = (tmp_ai_ch_mag_max_array[2] == double.MinValue) ? "" : fft_magdb_volt(tmp_ai_ch_mag_max_array[2], (double)config_para.ai_chnl_range_upper).ToString();
                                break;
                            case 2:
                            default:
                                // g
                                tmp_tbox_ai_ch_magnitude[vi].Text = accelerometer_mv_2_g(fft_magdb_volt(tmp_ai_ch_mag_max_array[0], (double)config_para.ai_chnl_range_upper) * 1000, config_para.ai_sensor_ch_sensitivity[vi]).ToString();
                                tmp_tbox_ai_ch_magnitude2[vi].Text = (tmp_ai_ch_mag_max_array[1] == double.MinValue) ? "" : accelerometer_mv_2_g(fft_magdb_volt(tmp_ai_ch_mag_max_array[1], (double)config_para.ai_chnl_range_upper) * 1000, config_para.ai_sensor_ch_sensitivity[vi]).ToString();
                                tmp_tbox_ai_ch_magnitude3[vi].Text = (tmp_ai_ch_mag_max_array[2] == double.MinValue) ? "" : accelerometer_mv_2_g(fft_magdb_volt(tmp_ai_ch_mag_max_array[2], (double)config_para.ai_chnl_range_upper) * 1000, config_para.ai_sensor_ch_sensitivity[vi]).ToString();
                                break;*/
                            case 0:
                            default:
                                // V
                                tmp_tbox_ai_ch_magnitude[vi].Text = fft_magdb_volt(tmp_ai_ch_mag_max_array[0], (double)config_para.ai_chnl_range_upper).ToString("F6");
                                tmp_tbox_ai_ch_magnitude2[vi].Text = (tmp_ai_ch_mag_max_array[1] == double.MinValue) ? "" : fft_magdb_volt(tmp_ai_ch_mag_max_array[1], (double)config_para.ai_chnl_range_upper).ToString("F6");
                                tmp_tbox_ai_ch_magnitude3[vi].Text = (tmp_ai_ch_mag_max_array[2] == double.MinValue) ? "" : fft_magdb_volt(tmp_ai_ch_mag_max_array[2], (double)config_para.ai_chnl_range_upper).ToString("F6");
                                break;
                            case 1:
                                // g
                                tmp_tbox_ai_ch_magnitude[vi].Text = accelerometer_mv_2_g(fft_magdb_volt(tmp_ai_ch_mag_max_array[0], (double)config_para.ai_chnl_range_upper) * 1000, config_para.ai_sensor_ch_sensitivity[vi]).ToString("F6");
                                tmp_tbox_ai_ch_magnitude2[vi].Text = (tmp_ai_ch_mag_max_array[1] == double.MinValue) ? "" : accelerometer_mv_2_g(fft_magdb_volt(tmp_ai_ch_mag_max_array[1], (double)config_para.ai_chnl_range_upper) * 1000, config_para.ai_sensor_ch_sensitivity[vi]).ToString("F6");
                                tmp_tbox_ai_ch_magnitude3[vi].Text = (tmp_ai_ch_mag_max_array[2] == double.MinValue) ? "" : accelerometer_mv_2_g(fft_magdb_volt(tmp_ai_ch_mag_max_array[2], (double)config_para.ai_chnl_range_upper) * 1000, config_para.ai_sensor_ch_sensitivity[vi]).ToString("F6");

                                break;
                        }
                    }

                    for (ushort vi = config_para.ai_chnl_cnt; vi < 4; ++ vi)
                    {
                        // Wave frequency
                        tmp_tbox_ai_ch_frequency[vi].Text = "";
                        // Wave magnitude
                        tmp_tbox_ai_ch_magnitude[vi].Text = "";
                        // Wave magnitude2
                        tmp_tbox_ai_ch_magnitude2[vi].Text = "";
                        // Wave magnitude3
                        tmp_tbox_ai_ch_magnitude3[vi].Text = "";
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

        static byte[] fn_get_byte_array(double[] double_array)
        {
            return double_array.SelectMany(value => BitConverter.GetBytes(value)).ToArray();
        }

        static byte[] fn_get_byte_array(file_header my_struct)
        {
            int my_struct_size = Marshal.SizeOf(my_struct);
            byte[] my_struct_byte_array = new byte[my_struct_size];

            IntPtr my_struct_ptr = Marshal.AllocHGlobal(my_struct_size);
            Marshal.StructureToPtr(my_struct, my_struct_ptr, true);
            Marshal.Copy(my_struct_ptr, my_struct_byte_array, 0, my_struct_size);
            Marshal.FreeHGlobal(my_struct_ptr);

            return my_struct_byte_array;
        }

        // Callback function for AI buffer ready event
        static void ai_buf_ready_cbfunc()
        {
            //
            // Process AI data of ready buffer HERE
            //

            // Transfer data from kernel to user
            USBDASK.UD_AI_AsyncDblBufferTransfer32(config_para.card_handle, config_para.ai_raw_data_buf[config_para.ai_buf_ready_idx]);

            // Convert AI raw data to scaled data, it depends on the setting of channel range.
            USBDASK.UD_AI_ContVScale32(config_para.card_handle, config_para.ai_chnl_range, 0/*inType*/, config_para.ai_raw_data_buf[config_para.ai_buf_ready_idx], config_para.ai_scale_data_buf, (int)config_para.ai_buf_size);

            // Tell UD-DASK that the ready buffer is handled
            USBDASK.UD_AI_AsyncDblBufferHandled(config_para.card_handle);

            // Save data if necessary
            try
            {
                if (config_para.data_logger_started)
                {
                    if (!config_para.data_logger_file_open)
                    {
                        config_para.data_logger_file_writer = new FileStream(config_para.data_logger_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                        config_para.data_logger_file_open = true;
                        config_para.data_logger_file_writer.Write(fn_get_byte_array(file_info), 0, Marshal.SizeOf(file_info));
                    }
                    config_para.data_logger_file_writer.Seek(0, SeekOrigin.End);
                    config_para.data_logger_file_writer.Write(fn_get_byte_array(config_para.ai_scale_data_buf), 0, (int)(config_para.ai_buf_size * sizeof(double)));
                }
                else
                {
                    if (config_para.data_logger_file_open)
                    {
                        config_para.data_logger_file_writer.Close();
                        config_para.data_logger_file_open = false;
                    }
                }
            }
            catch (Exception e)
            {
            }

            // Copy data to update buffer
            long tmp_ai_buf_ready_to_update_idx = (config_para.ai_buf_ready_cnt + 1) % config_para.ai_update_buffer_array_size;

            if (config_para.ai_chnl_cnt == 1)
            {
                // Raw
                Buffer.BlockCopy(config_para.ai_scale_data_buf, 0, config_para.ai_update_buffer_array_raw[0][tmp_ai_buf_ready_to_update_idx], 0, (int)config_para.ai_chnl_sample_count * sizeof(double));

                // FFT
                int tmp_fft_size_N = 1 << config_para.ai_buf_fft_logN;
                double[] tmp_fft_mag_array = new double[tmp_fft_size_N/2];
                fft_get_magdb(config_para.ai_scale_data_buf, tmp_fft_mag_array, tmp_fft_size_N, config_para.ai_buf_fft_logN, (double)config_para.ai_chnl_range_upper);
                Buffer.BlockCopy(tmp_fft_mag_array, 0, config_para.ai_update_buffer_array_fft[0][tmp_ai_buf_ready_to_update_idx], 0, tmp_fft_size_N / 2 * sizeof(double));
            }
            else
            {
                // Raw
                double [][] tmp_ai_scale_data_buf = new double[config_para.ai_chnl_cnt][];
                for (ushort vi = 0; vi < config_para.ai_chnl_cnt; ++ vi)
                {
                    tmp_ai_scale_data_buf[vi] = new double[config_para.ai_chnl_sample_count];
                }
                fn_buffer_interleaving(config_para.ai_scale_data_buf, tmp_ai_scale_data_buf, config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt, config_para.ai_chnl_cnt);
                for (ushort vi = 0; vi < config_para.ai_chnl_cnt; ++ vi)
                {
                    Buffer.BlockCopy(tmp_ai_scale_data_buf[vi], 0, config_para.ai_update_buffer_array_raw[vi][tmp_ai_buf_ready_to_update_idx], 0, (int)config_para.ai_chnl_sample_count * sizeof(double));
                }

                // FFT
                int tmp_fft_size_N = 1 << config_para.ai_buf_fft_logN;
                double[] tmp_fft_mag_array = new double[tmp_fft_size_N/2];
                for (ushort vi = 0; vi < config_para.ai_chnl_cnt; ++ vi)
                {
                    fft_get_magdb(tmp_ai_scale_data_buf[vi], tmp_fft_mag_array, tmp_fft_size_N, config_para.ai_buf_fft_logN, (double)config_para.ai_chnl_range_upper);
                    Buffer.BlockCopy(tmp_fft_mag_array, 0, config_para.ai_update_buffer_array_fft[vi][tmp_ai_buf_ready_to_update_idx], 0, tmp_fft_size_N / 2 * sizeof(double));
                }
            }

            config_para.ai_buf_ready_cnt += 1;
            config_para.ai_buf_ready_idx += 1;
            config_para.ai_buf_ready_idx %= 2;
        }
        static CallbackDelegate ai_buf_ready_cbdel = new CallbackDelegate(ai_buf_ready_cbfunc);

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

            // Scan usb modules
            short tmp_card_num = fn_scan_usb_modules(config_para.card_type, avail_modules);
            if (tmp_card_num < 0)
            {
                MessageBox.Show("No active module found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            config_para.card_num = (ushort)tmp_card_num;
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            // Configure 2405 common settings
            fn_u2405_config();

            // Configure 2405 AI settings
            fn_u2405_config_ai();

            // Configure 2405 trigger
            fn_u2405_config_trig();

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
                btn_device_start_Click(this.btn_device_start, null);
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
                if (config_para.card_subtype > 0)
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
                    // Remember to call UD_Release_Card() to release all allocated resources.
                    short result = USBDASK.UD_Register_Card(config_para.card_type, config_para.card_num);
                    if (result < 0)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Falied to perform UD_Register_Card(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    config_para.card_handle = (ushort)result;
                    config_para.is_reg_dev = true;

                    if (config_para.is_ai_enabled)
                    {
                        this.gbox_ai_operation.Enabled = true;
                        this.zg_ai_wave_raw.Enabled = true;
                        this.zg_ai_wave_fft.Enabled = true;
                    }
                    this.btn_device_start.Enabled = true;

                    this.cbox_device_type.Enabled = false;
                    this.cbox_device_index.Enabled = false;

                    tmp_btn_device_open.Text = "Close Device";
                }
                else
                {
                    fn_free_resource(true);
                    config_para.card_handle = 0;
                    config_para.is_reg_dev = false;

                    this.gbox_ai_operation.Enabled = false;
                    this.zg_ai_wave_raw.Enabled = false;
                    this.zg_ai_wave_fft.Enabled = false;
                    this.btn_device_start.Enabled = false;

                    this.cbox_device_type.Enabled = true;
                    this.cbox_device_index.Enabled = true;

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

                    if (config_para.is_ai_enabled)
                    {
                        // Configure AI Channel for a registered device
                        // This function must be called before calling any AI-related functions to perform AI operation.
                        // In this example, we configure 4 channels to be the same configurations (They can be set to be different).
                        short result = USBDASK.UD_AI_2405_Chan_Config(config_para.card_handle, config_para.ai_chnl_config, config_para.ai_chnl_config, config_para.ai_chnl_config, config_para.ai_chnl_config);
                        if (result != USBDASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform UD_AI_2405_Chan_Config(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }

                        // Configure trigger for a registered device
                        result = USBDASK.UD_AI_2405_Trig_Config(config_para.card_handle, config_para.conv_src, config_para.trig_mode, config_para.trig_control, config_para.retrig_count, config_para.trig_delay, config_para.trig_delay2, config_para.ana_trig_threshold);
                        if (result != USBDASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform UD_AI_2405_Trig_Config(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }

                        // Enable double-buffer mode
                        // UD-Dask provides a technique called double-buffer mode to perform continuous AI operation.
                        result = USBDASK.UD_AI_AsyncDblBufferMode(config_para.card_handle, true);
                        if (result != USBDASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform UD_AI_AsyncDblBufferMode(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }

                        // Setup buffer for data transfer
                        // Allocates memory from the unmanaged memory of the process.
                        config_para.ai_raw_data_buf = new IntPtr[2];
                        config_para.ai_raw_data_buf[0] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ai_buf_size));
                        config_para.ai_raw_data_buf[1] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ai_buf_size));
                        config_para.ai_scale_data_buf = new double[config_para.ai_buf_size];
                        config_para.is_ai_set_buf = true;

                        // Create AI copy memory
                        for (uint vi = 0; vi < 4; ++ vi)
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
                        result = USBDASK.UD_AI_EventCallBack(config_para.card_handle, 1/*add*/, USBDASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
                        if (result != USBDASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform UD_AI_EventCallBack(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ai_buf_ready_evt_set = true;

                        // Set AI done event
                        result = USBDASK.UD_AI_EventCallBack(config_para.card_handle, 1/*add*/, USBDASK.AIEnd/*EventType*/, ai_done_cbdel);
                        if (result != USBDASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform UD_AI_EventCallBack(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ai_done_evt_set = true;

                        // Reset status variables
                        config_para.ai_access_cnt = 0;
                        config_para.ai_buf_ready_idx = 0;
                        config_para.ai_buf_ready_cnt = -1;

                        // Create timer for updating UI
                        config_para.ai_buf_update_cnt = -1;
                        config_para.locker_ai_update_data = new object();
                        config_para.tmr_ai_update_data = new System.Threading.Timer(new System.Threading.TimerCallback(fn_tmr_ai_update_data), new StackTrace(true).GetFrame(0).GetMethod().Name, 0, 1);

                        // Read AI data, and the acquired raw data will be stored in the set buffer.
                        // For UD-Dask double-buffer mode, the number of samples should be set twice of buffer size.
                        ushort[] tmp_ai_chnl_range_array = new ushort[4] {config_para.ai_chnl_range, config_para.ai_chnl_range, config_para.ai_chnl_range, config_para.ai_chnl_range};
                        uint tmp_ai_all_data_count = config_para.ai_all_data_count * 2;
                        result = USBDASK.UD_AI_ContReadMultiChannels(config_para.card_handle, config_para.ai_chnl_cnt, config_para.ai_chnl_sel, tmp_ai_chnl_range_array, config_para.ai_raw_data_buf[0], tmp_ai_all_data_count, config_para.ai_sample_rate, USBDASK.ASYNCH_OP);
                        if (result != USBDASK.NoError)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falied to perform UD_AI_ContReadMultiChannels(), error: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fn_free_resource(false);
                            return;
                        }
                        config_para.is_ai_op_run = true;
                    }
                    config_para.is_op_started = true;

                    if (config_para.is_ai_enabled)
                    {
                        this.gbox_ai_settings.Enabled = false;
                        this.gbox_ai_sensor_settings.Enabled = false;
                    }
                    this.btn_device_open.Enabled = false;
                    this.btn_data_logger.Enabled = true;

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
                        USBDASK.UD_AI_AsyncClear(config_para.card_handle, out config_para.ai_access_cnt);
                        config_para.is_ai_op_run = false;

                        // Wait for that ai_done_cbfunc() is complete
                        ai_done_event.WaitOne();
                    }
                    fn_free_resource(false);
                    config_para.is_op_started = false;

                    if (config_para.data_logger_form != null)
                    {
                        config_para.data_logger_form.Close();
                    }

                    if (config_para.is_ai_enabled)
                    {
                        this.gbox_ai_settings.Enabled = true;
                        this.gbox_ai_sensor_settings.Enabled = true;
                    }
                    this.btn_device_open.Enabled = true;
                    this.btn_data_logger.Enabled = false;

                    tmp_btn_device_start.Text = "Start Operation";
                }
                this.Cursor = Cursors.Default;
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
                    MessageBox.Show("AI sample rate is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.tbox_ai_sample_rate.Text = config_para.ai_sample_rate.ToString();
                    this.tbox_ai_sample_rate.Focus();
                    return;
                }

                double tmp_sample_rate = Convert.ToDouble(tmp_tbox_ai_sample_rate.Text);
                if (tmp_sample_rate < 1000)
                {
                    MessageBox.Show("AI sample rate must be greater than 1000 Hz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sample_rate = 1000;
                }
                else if (tmp_sample_rate > 128000)
                {
                    MessageBox.Show("AI sample rate must be less than 128000 Hz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tmp_sample_rate = 128000;
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
                // Set new AI buffer size
                config_para.ai_chnl_sample_count = ((uint)(config_para.ai_sample_rate / config_para.ai_sample_scaling) + 255) / 256 * 256;
                config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
                config_para.ai_buf_size = config_para.ai_all_data_count;
                config_para.ai_buf_fft_logN = (int)Math.Log((double)config_para.ai_chnl_sample_count, 2);

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
                        tbox_sensor_ch0_sensitivity.Enabled = true;
                        tbox_sensor_ch1_sensitivity.Enabled = false;
                        tbox_sensor_ch2_sensitivity.Enabled = false;
                        tbox_sensor_ch3_sensitivity.Enabled = false;
                        config_para.ai_chnl_cnt = 1;
                        break;
                    case 1:
                        tbox_sensor_ch0_sensitivity.Enabled = true;
                        tbox_sensor_ch1_sensitivity.Enabled = true;
                        tbox_sensor_ch2_sensitivity.Enabled = false;
                        tbox_sensor_ch3_sensitivity.Enabled = false;
                        config_para.ai_chnl_cnt = 2;
                        break;
                    case 2:
                        tbox_sensor_ch0_sensitivity.Enabled = true;
                        tbox_sensor_ch1_sensitivity.Enabled = true;
                        tbox_sensor_ch2_sensitivity.Enabled = true;
                        tbox_sensor_ch3_sensitivity.Enabled = false;
                        config_para.ai_chnl_cnt = 3;
                        break;
                    case 3:
                        tbox_sensor_ch0_sensitivity.Enabled = true;
                        tbox_sensor_ch1_sensitivity.Enabled = true;
                        tbox_sensor_ch2_sensitivity.Enabled = true;
                        tbox_sensor_ch3_sensitivity.Enabled = true;
                        config_para.ai_chnl_cnt = 4;
                        break;
                    default:
                        tbox_sensor_ch0_sensitivity.Enabled = true;
                        tbox_sensor_ch1_sensitivity.Enabled = false;
                        tbox_sensor_ch2_sensitivity.Enabled = false;
                        tbox_sensor_ch3_sensitivity.Enabled = false;
                        config_para.ai_chnl_cnt = 1;
                        break;
                }
                // Set new AI buffer size
                config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
                config_para.ai_buf_size = config_para.ai_all_data_count;

                // Set new value for file header
                file_info.ai_chnl_cnt = config_para.ai_chnl_cnt;
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
                    default:
                        config_para.ai_chnl_range = (ushort)USBDASK.AD_B_10_V;
                        config_para.ai_chnl_range_upper = 10;
                        config_para.ai_chnl_range_lower = -10;
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
                        config_para.ai_chnl_config = (ushort)(USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_DisableIEPE);
                        break;
                    case 1:
                        config_para.ai_chnl_config = (ushort)(USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_DisableIEPE);
                        break;
                    case 2:
                        config_para.ai_chnl_config = (ushort)(USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_EnableIEPE);
                        break;
                    case 3:
                        config_para.ai_chnl_config = (ushort)(USBDASK.P2405_AI_PseudoDifferential | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_DisableIEPE);
                        break;
                    case 4:
                        config_para.ai_chnl_config = (ushort)(USBDASK.P2405_AI_PseudoDifferential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_DisableIEPE);
                        break;
                    case 5:
                        config_para.ai_chnl_config = (ushort)(USBDASK.P2405_AI_PseudoDifferential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_EnableIEPE);
                        break;
                    default:
                        config_para.ai_chnl_config = (ushort)(USBDASK.P2405_AI_PseudoDifferential | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_DisableIEPE);
                        break;
                }
            }
        }

        private void cbox_ai_trigger_source_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reserved
        }

        private void tbox_sensor_ch_sensitivity_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void cbox_ai_sensor_settings_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sensor settings
            if (sender != null)
            {
                ComboBox tmp_cbox_ai_sensor_settings = (ComboBox)sender;
                config_para.ai_sensor_settings = (uint)tmp_cbox_ai_sensor_settings.SelectedIndex;
                if (config_para.ai_sensor_settings > 0)
                {
                    config_para.ai_sensor_settings = 0;
                }
            }
        }

        private void tbox_sensor_ch0_sensitivity_Validating(object sender, CancelEventArgs e)
        {
            if (sender != null)
            {
                TextBox tmp_sensor_ch0_sensitivity = (TextBox)sender;
                if (tmp_sensor_ch0_sensitivity.Text == "")
                {
                    return;
                }

                double sensor_ch0_sensitivity = Convert.ToDouble(tmp_sensor_ch0_sensitivity.Text);
                if (sensor_ch0_sensitivity < 0)
                {
                    MessageBox.Show("Sensor sensitivity must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sensor_ch0_sensitivity = 1;
                }

                config_para.ai_sensor_ch_sensitivity[0] = sensor_ch0_sensitivity;
                file_info.ai_chnl_sensitivity0 = config_para.ai_sensor_ch_sensitivity[0];
                this.tbox_sensor_ch0_sensitivity.Text = config_para.ai_sensor_ch_sensitivity[0].ToString();
            }
        }

        private void tbox_sensor_ch1_sensitivity_Validating(object sender, CancelEventArgs e)
        {
            if (sender != null)
            {
                TextBox tmp_sensor_ch1_sensitivity = (TextBox)sender;
                if (tmp_sensor_ch1_sensitivity.Text == "")
                {
                    return;
                }

                double sensor_ch1_sensitivity = Convert.ToDouble(tmp_sensor_ch1_sensitivity.Text);
                if (sensor_ch1_sensitivity < 0)
                {
                    MessageBox.Show("Sensor sensitivity must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sensor_ch1_sensitivity = 1;
                }

                config_para.ai_sensor_ch_sensitivity[1] = sensor_ch1_sensitivity;
                file_info.ai_chnl_sensitivity1 = config_para.ai_sensor_ch_sensitivity[1];
                this.tbox_sensor_ch1_sensitivity.Text = config_para.ai_sensor_ch_sensitivity[1].ToString();
            }
        }

        private void tbox_sensor_ch2_sensitivity_Validating(object sender, CancelEventArgs e)
        {
            if (sender != null)
            {
                TextBox tmp_sensor_ch2_sensitivity = (TextBox)sender;
                if (tmp_sensor_ch2_sensitivity.Text == "")
                {
                    return;
                }

                double sensor_ch2_sensitivity = Convert.ToDouble(tmp_sensor_ch2_sensitivity.Text);
                if (sensor_ch2_sensitivity < 0)
                {
                    MessageBox.Show("Sensor sensitivity must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sensor_ch2_sensitivity = 1;
                }

                config_para.ai_sensor_ch_sensitivity[2] = sensor_ch2_sensitivity;
                file_info.ai_chnl_sensitivity2 = config_para.ai_sensor_ch_sensitivity[2];
                this.tbox_sensor_ch2_sensitivity.Text = config_para.ai_sensor_ch_sensitivity[2].ToString();
            }
        }

        private void tbox_sensor_ch3_sensitivity_Validating(object sender, CancelEventArgs e)
        {
            if (sender != null)
            {
                TextBox tmp_sensor_ch3_sensitivity = (TextBox)sender;
                if (tmp_sensor_ch3_sensitivity.Text == "")
                {
                    return;
                }

                double sensor_ch3_sensitivity = Convert.ToDouble(tmp_sensor_ch3_sensitivity.Text);
                if (sensor_ch3_sensitivity < 0)
                {
                    MessageBox.Show("Sensor sensitivity must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sensor_ch3_sensitivity = 1;
                }

                config_para.ai_sensor_ch_sensitivity[3] = sensor_ch3_sensitivity;
                file_info.ai_chnl_sensitivity3 = config_para.ai_sensor_ch_sensitivity[3];
                this.tbox_sensor_ch3_sensitivity.Text = config_para.ai_sensor_ch_sensitivity[3].ToString();
            }
        }

        private void cbox_ai_ch_magnitude_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Magnitude unit
            if (sender != null)
            {
                ComboBox tmp_cbox_ai_ch_magnitude_unit = (ComboBox)sender;
                config_para.ai_ch_magnitude_unit = (uint)tmp_cbox_ai_ch_magnitude_unit.SelectedIndex;
                // 05/05/16 remove dB
                if (config_para.ai_ch_magnitude_unit > /*2*/1)
                {
                    config_para.ai_ch_magnitude_unit = /*2*/1;
                }
            }
        }

        private void btn_data_logger_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Button btn_btn_data_logger = (Button)sender;
                this.Cursor = Cursors.WaitCursor;
                if (config_para.data_logger_form == null)
                {
                    config_para.data_logger_form = new frm_logger();
                    config_para.data_logger_form.g_parent = this;
                }
                config_para.data_logger_form.Show();
                config_para.data_logger_form.Activate();
                this.Cursor = Cursors.Default;
            }
        }
    }
}
