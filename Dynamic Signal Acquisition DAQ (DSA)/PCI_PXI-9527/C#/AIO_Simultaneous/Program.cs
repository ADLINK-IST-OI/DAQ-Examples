using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

public class Win32Interop
{
    [DllImport("crtdll.dll")]
    public static extern int _kbhit();
}

namespace AIO_Simultaneous
{
    struct program_config
    {
        //
        // Program status
        //
        public bool is_reg_dev;
        // AO
        public bool is_ao_set_buf;
        public bool is_ao_op_run;
        public bool is_ao_done_evt_set;
        public bool is_ao_buf_ready_evt_set;
        // AI
        public bool is_ai_set_buf;
        public bool is_ai_op_run;
        public bool is_ai_done_evt_set;
        public bool is_ai_buf_ready_evt_set;
        public bool is_ai_file_open;

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
        public ushort ai_file_format;
        public string ai_file_name;
        public StreamWriter ai_file_writer;
        public uint ai_file_reset_factor;

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
        public uint ao_buf_ready_cnt;
        // AI
        public uint ai_access_cnt;
        public uint ai_buf_ready_idx;
        public uint ai_buf_ready_cnt;

        //
        // Waveform setting varibles
        // AO
        public double sine_waveform_freq;
        public double sine_waveform_amp;
        public uint[] sine_waveform;
    }

    class Program
    {
        static program_config config_para;

        // Get console ushort input
        static ushort get_console_input(ushort default_value)
        {
            ushort result;

            try { result = Convert.ToUInt16(Console.ReadLine()); }
            catch { result = default_value; }

            return result;
        }

        // Get console uint input
        static uint get_console_input(uint default_value)
        {
            uint result;
            try { result = Convert.ToUInt32(Console.ReadLine()); }
            catch { result = default_value; }

            return result;
        }

        // Get console double input
        static double get_console_input(double default_value)
        {
            double result;
            try { result = Convert.ToDouble(Console.ReadLine()); }
            catch { result = default_value; }

            return result;
        }

        // Program exit handler
        static void exit_handle()
        {
            if (config_para.is_ai_op_run)
            {
                // Async Clear
                DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, out config_para.ai_access_cnt);
            }
            if (config_para.is_ao_op_run)
            {
                // Async Clear
                DSA_DASK.DSA_AO_AsyncClear(config_para.card_handle, out config_para.ao_access_cnt, 0);
            }

            if (config_para.is_ai_file_open)
            {
                // Close file
                config_para.ai_file_writer.Close();
            }

            if (config_para.is_ai_done_evt_set)
            {
                // Reset done event
                DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.AIEnd/*EventType*/, ai_done_cbdel);
            }
            if (config_para.is_ao_done_evt_set)
            {
                // Reset done event
                DSA_DASK.DSA_AO_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.AOEnd/*EventType*/, ao_done_cbdel);
            }

            if (config_para.is_ai_buf_ready_evt_set)
            {
                // Reset buffer ready event
                DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
            }
            if (config_para.is_ao_buf_ready_evt_set)
            {
                // Reset buffer ready event
                DSA_DASK.DSA_AO_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.DBEvent/*EventType*/, ao_buf_ready_cbdel);
            }

            if (config_para.is_ai_set_buf)
            {
                // Reset buffer
                DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle);
                Marshal.FreeHGlobal(config_para.ai_raw_data_buf[0]);
                Marshal.FreeHGlobal(config_para.ai_raw_data_buf[1]);
            }
            if (config_para.is_ao_set_buf)
            {
                // Reset buffer
                DSA_DASK.DSA_AO_ContBufferReset(config_para.card_handle);
                Marshal.FreeHGlobal(config_para.ao_raw_data_buf[0]);
                Marshal.FreeHGlobal(config_para.ao_raw_data_buf[1]);
            }

            if (config_para.is_reg_dev)
            {
                // Release device
                DSA_DASK.DSA_Release_Card(config_para.card_handle);
            }

            Console.Write("\n\nPress any key to exit...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static void initial_structure()
        {
            //
            // Program status
            //
            config_para.is_reg_dev = false;
            // AO
            config_para.is_ao_set_buf = false;
            config_para.is_ao_op_run = false;
            config_para.is_ao_done_evt_set = false;
            config_para.is_ao_buf_ready_evt_set = false;
            // AI
            config_para.is_ai_set_buf = false;
            config_para.is_ai_op_run = false;
            config_para.is_ai_done_evt_set = false;
            config_para.is_ai_buf_ready_evt_set = false;
            config_para.is_ai_file_open = false;

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
            config_para.ao_sample_rate = 54000.0;
            config_para.ao_actual_rate = config_para.ao_sample_rate;
            config_para.ao_sample_scaling = 10;
            // AI
            config_para.ai_sample_rate = 2 * config_para.ao_sample_rate;
            config_para.ai_actual_rate = config_para.ai_sample_rate;
            config_para.ai_sample_scaling = config_para.ao_sample_scaling;

            //
            // Channel configuration variables
            //
            // AO
            config_para.ao_chnl_sel = DSA_DASK.P9527_AO_CH_DUAL;
            config_para.ao_chnl_cnt = 2;
            config_para.ao_chnl_range = DSA_DASK.AD_B_1_V;
            config_para.ao_chnl_config = DSA_DASK.P9527_AO_PseudoDifferential;
            // AI
            config_para.ai_chnl_sel = DSA_DASK.P9527_AI_CH_DUAL;
            config_para.ai_chnl_cnt = 2;
            config_para.ai_chnl_range = DSA_DASK.AD_B_1_V;
            config_para.ai_chnl_config = DSA_DASK.P9527_AI_PseudoDifferential | DSA_DASK.P9527_AI_Coupling_DC;

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
            config_para.ai_file_format = 0;
            config_para.ai_file_name = "ai_data.csv";
            //config_para.ai_file_writer;
            if (config_para.ai_sample_rate < 54000)
            {
                config_para.ai_file_reset_factor = 10;
            }
            else if (config_para.ai_sample_rate < 108000)
            {
                config_para.ai_file_reset_factor = 5;
            }
            else if (config_para.ai_sample_rate < 216000)
            {
                config_para.ai_file_reset_factor = 3;
            }
            else // if (config_para.ai_sample_rate < 432000)
            {
                config_para.ai_file_reset_factor = 1;
            }

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
            config_para.ao_buf_ready_cnt = 0;
            // AI
            config_para.ai_access_cnt = 0;
            config_para.ai_buf_ready_idx = 0;
            config_para.ai_buf_ready_cnt = 0;

            //
            // Waveform setting varibles
            // AO
            config_para.sine_waveform_freq = 1000.0; // 1 KHz
            config_para.sine_waveform_amp = 2.0;     // 2 Vpp
            //config_para.sine_waveform;
        }

        // Configuration function for 9527
        static void p9527_config()
        {
            // Sub-card type
            Console.Write("\nSub-card type? (0) PCI-9527, (1) PXI-9527: [0] ");
            config_para.card_subtype = get_console_input((ushort)0);
            if (config_para.card_subtype > 1)
            {
                Console.Write("Warning! Invalid sub-card type. Force to set to PCI-9527.\n");
                config_para.card_subtype = 0;
            }

            // Card number
            Console.Write("Card number? [0] ");
            config_para.card_num = get_console_input((ushort)0);
        }

        // AO Configuration function for 9527
        static void p9527_config_ao()
        {
            // AO Sample rate
            Console.Write("\nAO Sample rate? ({0} ~ {1}): [{2}] ", DSA_DASK.P9527_AO_MinDDSFreq, DSA_DASK.P9527_AO_MaxDDSFreq, config_para.ao_sample_rate);
            double tmp_sample_rate = get_console_input((double)config_para.ao_sample_rate);
            if (tmp_sample_rate < DSA_DASK.P9527_AO_MinDDSFreq || tmp_sample_rate > DSA_DASK.P9527_AO_MaxDDSFreq)
            {
                Console.Write("Warning! Invalid sample rate. Force to set to {0}.\n", config_para.ao_sample_rate);
                tmp_sample_rate = config_para.ao_sample_rate;
            }
            double max_wave_freq = config_para.ao_sample_rate / 2; // 27 KHz, half of sample rate
            if (tmp_sample_rate != config_para.ao_sample_rate)
            {
                config_para.ao_sample_rate = tmp_sample_rate;
                max_wave_freq = config_para.ao_sample_rate / 2;
                if (config_para.sine_waveform_freq > max_wave_freq)
                {
                    config_para.sine_waveform_freq = max_wave_freq;
                }
                // Set new buffer size
                config_para.ao_chnl_sample_count = (uint)(config_para.ao_sample_rate / config_para.ao_sample_scaling);
                config_para.ao_all_data_count = config_para.ao_chnl_sample_count * config_para.ao_chnl_cnt;
                config_para.ao_buf_size = config_para.ao_all_data_count;
            }

            // AO channel
            /*Console.Write("AO Channel selection? ({0}) AO_CH_0, ({1}) AO_CH_1, ({2}) AO_CH_DUAL: [{2}] ", DSA_DASK.P9527_AO_CH_0, DSA_DASK.P9527_AO_CH_1, DSA_DASK.P9527_AO_CH_DUAL);
            config_para.ao_chnl_sel = get_console_input((ushort)DSA_DASK.P9527_AO_CH_DUAL);
            switch(config_para.ao_chnl_sel)
            {
                case DSA_DASK.P9527_AO_CH_0:
                case DSA_DASK.P9527_AO_CH_1:
                    config_para.ao_chnl_cnt = 1;
                    break;
                case DSA_DASK.P9527_AO_CH_DUAL:
                    config_para.ao_chnl_cnt = 2;
                    break;
                default:
                    Console.Write("Warning! Invalid channel selection. Force to set to AO_CH_DUAL.\n");
                    config_para.ao_chnl_sel = (ushort)DSA_DASK.P9527_AO_CH_DUAL;
                    config_para.ao_chnl_cnt = 2;
                    break;
            }*/

            // AO channel range
            double max_wave_amp = 2.0; // 2 Vpp
            Console.Write("AO Channel range? (0) B_10_V, (1) AD_B_1_V, (2) AD_B_0_1_V: [1] ");
            ushort tmp_ao_chnl_range = get_console_input((ushort)1);
            switch (tmp_ao_chnl_range)
            {
                case 0:
                    config_para.ao_chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                    max_wave_amp = 20;
                    break;
                case 1:
                    config_para.ao_chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                    break;
                case 2:
                    config_para.ao_chnl_range = (ushort)DSA_DASK.AD_B_0_1_V;
                    max_wave_amp = 0.2;
                    break;
                default:
                    Console.Write("Warning! Invalid channel range. Force to set to B_1_V.\n");
                    config_para.ao_chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                    break;
            }
            if (config_para.sine_waveform_amp > max_wave_amp)
            {
                config_para.sine_waveform_amp = max_wave_amp;
            }

            // AO channel output type
            ushort tmp_chnl_output_type_max;
            if (config_para.ao_chnl_sel == DSA_DASK.P9527_AO_CH_0)
            {
                // BalancedOutput is only supported when channel is set to AO_CH_0
                tmp_chnl_output_type_max = DSA_DASK.P9527_AO_BalancedOutput;
                Console.Write("AO Channel output type? ({0}) Differential, ({1}) PseudoDifferential, ({2}) BalancedOutput: [{1}] ", DSA_DASK.P9527_AO_Differential, DSA_DASK.P9527_AO_PseudoDifferential, DSA_DASK.P9527_AO_BalancedOutput);
            }
            else
            {
                tmp_chnl_output_type_max = DSA_DASK.P9527_AO_PseudoDifferential;
                Console.Write("AO Channel output type? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ", DSA_DASK.P9527_AO_Differential, DSA_DASK.P9527_AO_PseudoDifferential);
            }
            config_para.ao_chnl_config = get_console_input((ushort)DSA_DASK.P9527_AO_PseudoDifferential);
            if (config_para.ao_chnl_config > tmp_chnl_output_type_max)
            {
                Console.Write("Warning! Invalid channel output type. Force to set to PseudoDifferential.\n");
                config_para.ao_chnl_config = (ushort)DSA_DASK.P9527_AO_PseudoDifferential;
            }

            // AO Sample count
            /*Console.Write("AO Sample count (per channel / per buffer)? [65536] ");
            config_para.ao_chnl_sample_count = get_console_input((uint)65536);
            config_para.ao_all_data_count = config_para.ao_chnl_sample_count * config_para.ao_chnl_cnt;
            if (config_para.ao_all_data_count == 0 || config_para.ao_all_data_count % 2 != 0)
            {
                Console.Write("Warning! Invalid sample count. Force to set to 65536.\n");
                config_para.ao_chnl_sample_count = (uint)65536;
                config_para.ao_all_data_count = config_para.ao_chnl_sample_count * config_para.ao_chnl_cnt;
            }
            config_para.ao_buf_size = config_para.ao_all_data_count;*/

            // AO Sine waveform frequency
            Console.Write("Sine waveform frequency (1 ~ {0} Hz)? [{1}] ", max_wave_freq, config_para.sine_waveform_freq);
            double tmp_sine_waveform_freq = get_console_input((double)config_para.sine_waveform_freq);
            if (tmp_sine_waveform_freq == 0 || tmp_sine_waveform_freq > max_wave_freq)
            {
                Console.Write("Warning! Invalid frequency. Force to set to {0}.\n", config_para.sine_waveform_freq);
                tmp_sine_waveform_freq = config_para.sine_waveform_freq;
            }
            config_para.sine_waveform_freq = tmp_sine_waveform_freq;

            // AO Sine waveform amplitude
            Console.Write("Sine waveform amplitude ( ~ {0} Vpp)? [{1}] ", max_wave_amp, config_para.sine_waveform_amp);
            double tmp_sine_waveform_amp = get_console_input((double)config_para.sine_waveform_amp);
            if (tmp_sine_waveform_amp == 0 || tmp_sine_waveform_amp > max_wave_amp)
            {
                Console.Write("Warning! Invalid amplitude. Force to set to {0}.\n", config_para.sine_waveform_amp);
                tmp_sine_waveform_amp = config_para.sine_waveform_amp;
            }
            config_para.sine_waveform_amp = tmp_sine_waveform_amp;

            // AO Sine waveform data
            config_para.sine_waveform = new uint[config_para.ao_chnl_sample_count];
            uint sine_amplitude = (uint)((double)0x7FFFFF * (config_para.sine_waveform_amp / max_wave_amp)); // AO +FSR
            uint sine_frequency = (uint)config_para.sine_waveform_freq;
            uint sine_scaling = config_para.ao_sample_scaling;
            for (int vi = 0; vi < config_para.ao_chnl_sample_count; ++ vi)
            {
                config_para.sine_waveform[vi] = (uint)(sine_amplitude * Math.Sin((2 * Math.PI * vi * sine_frequency / sine_scaling) / config_para.ao_chnl_sample_count));
            }

            // AO Update repeat iterations
            // When continuous waveforms to be output, set iteration to 0 and definite to 0
            /*config_para.ao_upd_repeat_cnt = 0;
            config_para.ao_upd_op_definite = 0;*/

            // AO Update repeat interval
            /*config_para.ao_upd_repeat_interval = 0;*/
        }

        // AI Configuration function for 9527
        static void p9527_config_ai()
        {
            // AI Sample rate
            // Automatically set to twice of AO sample rate, so p9527_config_ao() must be called before calling p9527_config_ai().
            double tmp_sample_rate = 2 * config_para.ao_sample_rate;
            /*Console.Write("\nAI Sample rate? ({0} ~ {1}): [{2}] ", DSA_DASK.P9527_AI_MinDDSFreq, DSA_DASK.P9527_AI_MaxDDSFreq, config_para.ai_sample_rate);
            double tmp_sample_rate = get_console_input((double)config_para.ai_sample_rate);
            if (tmp_sample_rate < DSA_DASK.P9527_AI_MinDDSFreq || tmp_sample_rate > DSA_DASK.P9527_AI_MaxDDSFreq)
            {
                Console.Write("Warning! Invalid sample rate. Force to set to {0}.\n", config_para.ai_sample_rate);
                tmp_sample_rate = config_para.ai_sample_rate;
            }*/
            if (tmp_sample_rate != config_para.ai_sample_rate)
            {
                config_para.ai_sample_rate = tmp_sample_rate;
                // Set new buffer size
                config_para.ai_chnl_sample_count = (uint)(config_para.ai_sample_rate / config_para.ai_sample_scaling);
                config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
                config_para.ai_buf_size = config_para.ai_all_data_count;
                // Set new file reset factor
                if (config_para.ai_sample_rate < 54000)
                {
                    config_para.ai_file_reset_factor = 10;
                }
                else if (config_para.ai_sample_rate < 108000)
                {
                    config_para.ai_file_reset_factor = 5;
                }
                else if (config_para.ai_sample_rate < 216000)
                {
                    config_para.ai_file_reset_factor = 3;
                }
                else // if (config_para.ai_sample_rate < 432000)
                {
                    config_para.ai_file_reset_factor = 1;
                }
            }

            // AI channel
            /*Console.Write("AI Channel selection? ({0}) AI_CH_0, ({1}) AI_CH_1, ({2}) AI_CH_DUAL: [{2}] ", DSA_DASK.P9527_AI_CH_0, DSA_DASK.P9527_AI_CH_1, DSA_DASK.P9527_AI_CH_DUAL);
            config_para.ai_chnl_sel = get_console_input((ushort)DSA_DASK.P9527_AI_CH_DUAL);
            switch(config_para.ai_chnl_sel)
            {
                case DSA_DASK.P9527_AI_CH_0:
                case DSA_DASK.P9527_AI_CH_1:
                    config_para.ai_chnl_cnt = 1;
                    break;
                case DSA_DASK.P9527_AI_CH_DUAL:
                    config_para.ai_chnl_cnt = 2;
                    break;
                default:
                    Console.Write("Warning! Invalid channel selection. Force to set to AI_CH_DUAL.\n");
                    config_para.ai_chnl_sel = (ushort)DSA_DASK.P9527_AI_CH_DUAL;
                    config_para.ai_chnl_cnt = 2;
                    break;
            }*/

            // AI channel range
            Console.Write("\nAI Channel range? (0) B_40_V, (1) B_10_V, (2) B_3_16_V, (3) AD_B_1_V, (4) AD_B_0_316_V: [3] ");
            ushort tmp_ai_chnl_range = get_console_input((ushort)3);
            switch (tmp_ai_chnl_range)
            {
                case 0:
                    config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_40_V;
                    break;
                case 1:
                    config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                    break;
                case 2:
                    config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_3_16_V;
                    break;
                case 3:
                    config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                    break;
                case 4:
                    config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_0_316_V;
                    break;
                default:
                    Console.Write("Warning! Invalid channel range. Force to set to B_1_V.\n");
                    config_para.ai_chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                    break;
            }

            // AI channel input type
            Console.Write("AI Channel input type? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ", DSA_DASK.P9527_AI_Differential, DSA_DASK.P9527_AI_PseudoDifferential);
            config_para.ai_chnl_config = get_console_input((ushort)DSA_DASK.P9527_AI_PseudoDifferential);
            if (config_para.ai_chnl_config > DSA_DASK.P9527_AI_PseudoDifferential)
            {
                Console.Write("Warning! Invalid channel input type. Force to set to PseudoDifferential.\n");
                config_para.ai_chnl_config = (ushort)DSA_DASK.P9527_AI_PseudoDifferential;
            }

            // AI channel input coupling
            Console.Write("AI Channel input coupling? (0) DC_Coupling, (1) AC_Coupling, (2) IEPE: [0] ");
            ushort tmp_ai_chnl_config = get_console_input((ushort)0);
            switch (tmp_ai_chnl_config)
            {
                case 0:
                    config_para.ai_chnl_config |= (ushort)DSA_DASK.P9527_AI_Coupling_DC;
                    break;
                case 1:
                    config_para.ai_chnl_config |= (ushort)DSA_DASK.P9527_AI_Coupling_AC;
                    break;
                case 2:
                    config_para.ai_chnl_config |= (ushort)DSA_DASK.P9527_AI_EnableIEPE;
                    break;
                default:
                    Console.Write("Warning! Invalid channel input coupling. Force to set to DC_Coupling.\n");
                    config_para.ai_chnl_config |= (ushort)DSA_DASK.P9527_AI_Coupling_DC;
                    break;
            }

            // AI Sample count
            /*Console.Write("AI Sample count (per channel / per buffer)? [65536] ");
            config_para.ai_chnl_sample_count = get_console_input((uint)65536);
            config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
            if (config_para.ai_all_data_count == 0 || config_para.ai_all_data_count % 2 != 0)
            {
                Console.Write("Warning! Invalid sample count. Force to set to 65536.\n");
                config_para.ai_chnl_sample_count = (uint)65536;
                config_para.ai_all_data_count = config_para.ai_chnl_sample_count * config_para.ai_chnl_cnt;
            }
            config_para.ai_buf_size = config_para.ai_all_data_count;*/

            // AI File format
            /*Console.Write("AI Store data to (0) Text file, (1) Binary file: [0] ");
            config_para.ai_file_format = get_console_input((ushort)0);
            string tmp_default_ai_file_name;
            switch (config_para.ai_file_format)
            {
                case 0:
                    tmp_default_ai_file_name = "ai_data.csv";
                    break;
                case 1:
                    tmp_default_ai_file_name = "ai_data";
                    break;
                default:
                    config_para.ai_file_format = 0;
                    tmp_default_ai_file_name = "ai_data.csv";
                    break;
            }
            if (config_para.ai_file_format > 1)
            {
                config_para.ai_file_format = 0;
            }*/

            // AI File name
            /*Console.Write("AI File name to be stored: [{0}] ", tmp_default_ai_file_name);
            config_para.ai_file_name = Console.ReadLine();
            if (config_para.ai_file_name == "")
            {
                config_para.ai_file_name = tmp_default_ai_file_name;
            }*/
        }

        // TRIG Configuration function for 9527
        static void p9527_config_trig()
        {
            // Trigger target
            /*config_para.trig_target = DSA_DASK.P9527_TRG_ALL;*/

            // Trigger mode
            /*Console.Write("Trigger mode? ({0}) Post_trigger, ({1}) Delay_trigger: [{0}] ", DSA_DASK.P9527_TRG_MODE_POST, DSA_DASK.P9527_TRG_MODE_DELAY);
            bool tmp_set_delay_trig_cnt = false;
            config_para.trig_config = get_console_input((ushort)DSA_DASK.P9527_TRG_MODE_POST);
            if (config_para.trig_config > DSA_DASK.P9527_TRG_MODE_DELAY)
            {
                Console.Write("Warning! Invalid trigger mode. Force to set to Post_trigger.\n");
                config_para.trig_config = (ushort)DSA_DASK.P9527_TRG_MODE_POST;
            }
            else if (config_para.trig_config == DSA_DASK.P9527_TRG_MODE_DELAY)
            {
                tmp_set_delay_trig_cnt = true;
            }*/

            // Trigger source
            /*ushort tmp_trig_source;
            bool tmp_set_trig_pol = false;
            if (config_para.card_subtype == 0)
            {
                // PCI-9527
                Console.Write("AO Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) SSI_9, (4) No_Wait: [4] ");
                tmp_trig_source = get_console_input((ushort)4);
                switch (tmp_trig_source)
                {
                    case 0:
                        config_para.is_gen_sw_trig = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_SOFT;
                        break;
                    case 1:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_EXTD;
                        break;
                    case 2:
                        config_para.is_set_ana_trig = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_ANALOG;
                        break;
                    case 3:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_SSI9;
                        break;
                    case 4:
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_NOWAIT;
                        break;
                    default:
                        Console.Write("Warning! Invalid trigger source. Force to set to No_Wait.\n");
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_NOWAIT;
                        break;
                }
            }
            else
            {
                // PXI-9527
                Console.Write("AO Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) No_Wait, (4) PXI_StartIn, (5) PXI_Bus_0, (6) PXI_Bus_1, (7) PXI_Bus_2, (8) PXI_Bus_3, (9) PXI_Bus_4, (10) PXI_Bus_5, (11) PXI_Bus_6, (12) PXI_Bus_7: [3] ");
                tmp_trig_source = get_console_input((ushort)3);
                switch (tmp_trig_source)
                {
                    case 0:
                        config_para.is_gen_sw_trig = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_SOFT;
                        break;
                    case 1:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_EXTD;
                        break;
                    case 2:
                        config_para.is_set_ana_trig = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_ANALOG;
                        break;
                    case 3:
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_NOWAIT;
                        break;
                    case 4:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_STARTIN;
                        break;
                    case 5:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_BUS0;
                        break;
                    case 6:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_BUS1;
                        break;
                    case 7:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_BUS2;
                        break;
                    case 8:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_BUS3;
                        break;
                    case 9:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_BUS4;
                        break;
                    case 10:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_BUS5;
                        break;
                    case 11:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_BUS6;
                        break;
                    case 12:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_PXI_BUS7;
                        break;
                    default:
                        Console.Write("Warning! Invalid trigger source. Force to set to No_Wait.\n");
                        config_para.trig_config |= DSA_DASK.P9527_TRG_SRC_NOWAIT;
                        break;
                }
            }*/

            // Trigger polarity
            /*if (tmp_set_trig_pol)
            {
                Console.Write("Trigger polarity? (0) Negative, (1) Positive: [1] ");
                ushort tmp_trig_polarity = get_console_input((ushort)1);
                switch (tmp_trig_polarity)
                {
                    case 0:
                        config_para.trig_config |= DSA_DASK.P9527_TRG_Negative;
                        break;
                    case 1:
                        config_para.trig_config |= DSA_DASK.P9527_TRG_Positive;
                        break;
                    default:
                        Console.Write("Warning! Invalid trigger polarity. Force to set to Positive.\n");
                        config_para.trig_config |= DSA_DASK.P9527_TRG_Positive;
                        break;
                }
            }*/

            // Re-trigger settings
            // Disable re-trigger
            /*config_para.trig_config &= unchecked((ushort)(~((uint)DSA_DASK.P9527_TRG_EnReTigger)));
            config_para.retrig_count = 0;*/

            // Delay trigger settings
            /*if (tmp_set_delay_trig_cnt)
            {
                Console.Write("Delay trigger count? (0 ~ 4294967295): [0] ");
                config_para.trig_delay = get_console_input((uint)0);
            }*/

            // Analog trigger settings
            /*if (config_para.is_set_ana_trig)
            {
                // AO Analog trigger source
                Console.Write("AO Analog trigger source? ({0}) AI_CH_0, ({1}) AI_CH_1: [{0}] ", DSA_DASK.P9527_TRG_Analog_CH0, DSA_DASK.P9527_TRG_Analog_CH1);
                config_para.ana_trig_src = get_console_input((uint)DSA_DASK.P9527_TRG_Analog_CH0);
                if (config_para.ana_trig_src > DSA_DASK.P9527_TRG_Analog_CH1)
                {
                    Console.Write("Warning! Invalid analog trigger source. Force to set to AI_CH_0.\n");
                    config_para.ana_trig_src = DSA_DASK.P9527_TRG_Analog_CH0;
                }

                // AO Analog trigger source range
                Console.Write("AO Analog trigger source configuration [range]? (0) B_40_V, (1) B_10_V, (2) B_3_16_V, (3) AD_B_1_V, (4) AD_B_0_316_V: [1] ");
                ushort tmp_ana_trig_src_range = get_console_input((ushort)1);
                double tmp_ana_trig_src_range_lower, tmp_ana_trig_src_range_upper;
                switch (tmp_ana_trig_src_range)
                {
                    case 0:
                        config_para.ana_trig_src_range = (ushort)DSA_DASK.AD_B_40_V;
                        tmp_ana_trig_src_range_lower = -40;
                        tmp_ana_trig_src_range_upper = 40;
                        break;
                    case 1:
                        config_para.ana_trig_src_range = (ushort)DSA_DASK.AD_B_10_V;
                        tmp_ana_trig_src_range_lower = -10;
                        tmp_ana_trig_src_range_upper = 10;
                        break;
                    case 2:
                        config_para.ana_trig_src_range = (ushort)DSA_DASK.AD_B_3_16_V;
                        tmp_ana_trig_src_range_lower = -3.16;
                        tmp_ana_trig_src_range_upper = 3.16;
                        break;
                    case 3:
                        config_para.ana_trig_src_range = (ushort)DSA_DASK.AD_B_1_V;
                        tmp_ana_trig_src_range_lower = -1;
                        tmp_ana_trig_src_range_upper = 1;
                        break;
                    case 4:
                        config_para.ana_trig_src_range = (ushort)DSA_DASK.AD_B_0_316_V;
                        tmp_ana_trig_src_range_lower = -0.316;
                        tmp_ana_trig_src_range_upper = 0.316;
                        break;
                    default:
                        Console.Write("Warning! Invalid analog trigger source range. Force to set to B_10_V.\n");
                        config_para.ana_trig_src_range = (ushort)DSA_DASK.AD_B_10_V;
                        tmp_ana_trig_src_range_lower = -10;
                        tmp_ana_trig_src_range_upper = 10;
                        break;
                }

                // AO Analog trigger source input type
                Console.Write("AO Analog trigger source configuration [input type]? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ", DSA_DASK.P9527_AI_Differential, DSA_DASK.P9527_AI_PseudoDifferential);
                config_para.ana_trig_src_config = get_console_input((ushort)DSA_DASK.P9527_AI_PseudoDifferential);
                if (config_para.ana_trig_src_config > DSA_DASK.P9527_AI_PseudoDifferential)
                {
                    Console.Write("Warning! Invalid analog trigger source input type. Force to set to PseudoDifferential.\n");
                    config_para.ana_trig_src_config = (ushort)DSA_DASK.P9527_AI_PseudoDifferential;
                }

                // AO Analog trigger source input coupling
                Console.Write("AO Analog trigger source configuration [input coupling]? (0) DC_Coupling, (1) AC_Coupling, (2) IEPE: [0] ");
                ushort tmp_ana_trig_src_config = get_console_input((ushort)0);
                switch (tmp_ana_trig_src_config)
                {
                    case 0:
                        config_para.ana_trig_src_config |= (ushort)DSA_DASK.P9527_AI_Coupling_DC;
                        break;
                    case 1:
                        config_para.ana_trig_src_config |= (ushort)DSA_DASK.P9527_AI_Coupling_AC;
                        break;
                    case 2:
                        config_para.ana_trig_src_config |= (ushort)DSA_DASK.P9527_AI_EnableIEPE;
                        break;
                    default:
                        Console.Write("Warning! Invalid analog trigger source input coupling. Force to set to DC_Coupling.\n");
                        config_para.ana_trig_src_config |= (ushort)DSA_DASK.P9527_AI_Coupling_DC;
                        break;
                }

                // AO Analog trigger mode
                Console.Write("AO Analog trigger mode? ({0}) Above_threshold, ({1}) Below_threshold: [{0}] ", DSA_DASK.P9527_TRG_Analog_Above_threshold, DSA_DASK.P9527_TRG_Analog_Below_threshold);
                config_para.ana_trig_mode = get_console_input((uint)DSA_DASK.P9527_TRG_Analog_Above_threshold);
                if (config_para.ana_trig_mode > DSA_DASK.P9527_TRG_Analog_Below_threshold)
                {
                    Console.Write("Warning! Invalid analog trigger source. Force to set to Above_threshold.\n");
                    config_para.ana_trig_mode = DSA_DASK.P9527_TRG_Analog_Above_threshold;
                }

                // AO Analog trigger threshold
                Console.Write("AO Analog trigger threshold? ({0} ~ {1}): [0] ", tmp_ana_trig_src_range_lower, tmp_ana_trig_src_range_upper);
                config_para.ana_trig_threshold = get_console_input((double)0);
                if (config_para.ana_trig_threshold < tmp_ana_trig_src_range_lower || config_para.ana_trig_threshold > tmp_ana_trig_src_range_upper)
                {
                    Console.Write("Warning! Invalid analog trigger threshold. Force to set to 0.\n");
                    config_para.ana_trig_threshold = 0;
                }
            }*/
        }

        // Callback function for AO buffer ready event
        static void ao_buf_ready_cbfunc()
        {
            //Console.Write("Buffer half ready, ready count: {0}\r", ++ config_para.ao_buf_ready_cnt);
        }
        static CallbackDelegate ao_buf_ready_cbdel = new CallbackDelegate(ao_buf_ready_cbfunc);

        // Callback function for AI buffer ready event
        static void ai_buf_ready_cbfunc()
        {
            Console.Write("Buffer half ready, ready count: {0}\r", ++ config_para.ai_buf_ready_cnt);

            if (config_para.ai_file_format == 0)
            {
                if (config_para.ai_buf_ready_cnt != 1 && (config_para.ai_buf_ready_cnt % (config_para.ai_sample_scaling * config_para.ai_file_reset_factor)) == 1)
                {
                    // Overwrite data file
                    config_para.ai_file_writer.Close();
                    config_para.ai_file_writer = new StreamWriter(config_para.ai_file_name);
                }

                // Convert AI raw data to scaled data, it depends on the setting of channel range.
                DSA_DASK.DSA_AI_ContVScale(config_para.card_handle, config_para.ai_chnl_range, config_para.ai_raw_data_buf[config_para.ai_buf_ready_idx], config_para.ai_scale_data_buf, (int)config_para.ai_buf_size);

                config_para.ai_buf_ready_idx ++;
                config_para.ai_buf_ready_idx %= 2;

                // Write to file
                for (int vi = 0; vi < config_para.ai_buf_size / config_para.ai_chnl_cnt; ++ vi)
                {
                    for (int vj = 0; vj < config_para.ai_chnl_cnt; ++ vj)
                    {
                        config_para.ai_file_writer.Write("{0:f8},", config_para.ai_scale_data_buf[vi * config_para.ai_chnl_cnt + vj]);
                    }
                    config_para.ai_file_writer.Write("\n");
                }

                // Tell DSA-DASK that the ready buffer is handled
                DSA_DASK.DSA_AI_AsyncDblBufferHandled(config_para.card_handle);
            }
            else
            {
                // Transfer data to file
                DSA_DASK.DSA_AI_AsyncDblBufferToFile(config_para.card_handle);

                // Tell DSA-DASK that the ready buffer is handled
                DSA_DASK.DSA_AI_AsyncDblBufferHandled(config_para.card_handle);
            }
        }
        static CallbackDelegate ai_buf_ready_cbdel = new CallbackDelegate(ai_buf_ready_cbfunc);

        // Callback function for AO operation is complete
        static AutoResetEvent ao_done_event = new AutoResetEvent(false);
        static void ao_done_cbfunc()
        {
            //Console.Write("\nAO update is manually stopped!");

            // Set event
            ao_done_event.Set();
        }
        static CallbackDelegate ao_done_cbdel = new CallbackDelegate(ao_done_cbfunc);

        // Callback function for AI operation is complete
        static AutoResetEvent ai_store_last_buf_event = new AutoResetEvent(false);
        static AutoResetEvent ai_done_event = new AutoResetEvent(false);
        static void ai_done_cbfunc()
        {
            // Wait for that DSA_AI_AsyncClear() returns ai_access_cnt to save last buffer data
            ai_store_last_buf_event.WaitOne();

            if (config_para.ai_file_format == 0)
            {
                // Save last buffer data to file
                // Convert AI raw data to scaled data, it depends on the setting of channel range.
                DSA_DASK.DSA_AI_ContVScale(config_para.card_handle, config_para.ai_chnl_range, config_para.ai_raw_data_buf[config_para.ai_buf_ready_idx], config_para.ai_scale_data_buf, (int)config_para.ai_access_cnt);

                // Write to file
                for (int vi = 0; vi < config_para.ai_access_cnt / config_para.ai_chnl_cnt; ++ vi)
                {
                    for (int vj = 0; vj < config_para.ai_chnl_cnt; ++ vj)
                    {
                        config_para.ai_file_writer.Write("{0:f8},", config_para.ai_scale_data_buf[vi * config_para.ai_chnl_cnt + vj]);
                    }
                    config_para.ai_file_writer.Write("\n");
                }
            }
            else
            {
                // Transfer data to file
                DSA_DASK.DSA_AI_AsyncDblBufferToFile(config_para.card_handle);
            }

            // Set event
            ai_done_event.Set();
        }
        static CallbackDelegate ai_done_cbdel = new CallbackDelegate(ai_done_cbfunc);

        static void Main(string[] args)
        {
            Console.Write("This example performs AI and AO simultaneously operation.\n");
            Console.Write("There is a timing constraint when AI and AO are enabled simultaneously.\n");
            Console.Write("AI sample rate will be set to twice of AO sample rate automatically.\n\n");
            Console.Write("Press 'Enter' to continue...");
            Console.ReadLine();

            // Initialize global variables
            initial_structure();

            // Configure 9527 common settings
            p9527_config();

            // Configure 9527 AO settings
            p9527_config_ao();

            // Configure 9527 AI settings
            p9527_config_ai();

            // Configure 9527 trigger
            p9527_config_trig();

            // Register a specified device, it sets and initializes all related variables and necessary resources.
            // This function must be called before calling any other functions to control the device.
            // Remember to call DSA_Release_Card() to release all allocated resources.
            short result = DSA_DASK.DSA_Register_Card(config_para.card_type, config_para.card_num);
            if (result < 0)
            {
                Console.Write("\nFalied to perform DSA_Register_Card(), error: " + result);
                exit_handle();
            }
            config_para.card_handle = (ushort)result;
            config_para.is_reg_dev = true;

            // Configure sampling rate for a registered device, it will return the actual sample rate.
            // This function must be called before calling any AO-related functions to perform AO operation.
            // There is a timing constraint when AI and AO function are enabled simultaneously.
            // Please refer P9527 Hardware Manual section 3.5.3 for details.
            result = DSA_DASK.DSA_AO_9527_ConfigSampleRate(config_para.card_handle, config_para.ao_sample_rate, out config_para.ao_actual_rate);
            if (result != DSA_DASK.NoError)
            {
                if (result == -81)
                {
                    //Console.Write("\nWarning! Sample rate has been locked by AI job!");
                }
                else
                {
                    Console.Write("\nFalied to perform DSA_AO_9527_ConfigSampleRate(), error: " + result);
                    exit_handle();
                }
            }

            // Configure sampling rate for a registered device, it will return the actual sample rate.
            // This function must be called before calling any AI-related functions to perform AI operation.
            // There is a timing constraint when AI and AO function are enabled simultaneously.
            // Please refer P9527 Hardware Manual section 3.5.3 for details.
            result = DSA_DASK.DSA_AI_9527_ConfigSampleRate(config_para.card_handle, config_para.ai_sample_rate, out config_para.ai_actual_rate);
            if (result != DSA_DASK.NoError)
            {
                if (result == -81)
                {
                    //Console.Write("\nWarning! Sample rate has been locked by AO job!");
                }
                else
                {
                    Console.Write("\nFalied to perform DSA_AI_9527_ConfigSampleRate(), error: " + result);
                    exit_handle();
                }
            }

            // Configure AO channel/function for a registered device
            result = DSA_DASK.DSA_AO_9527_ConfigChannel(config_para.card_handle, config_para.ao_chnl_sel, config_para.ao_chnl_range, config_para.ao_chnl_config, false/*AutoReset*/);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AO_9527_ConfigChannel(), error: " + result);
                exit_handle();
            }

            // Configure AI channel/function for a registered device
            // This function may take a few seconds to initial and adjust ADC settings
            Console.Write("\nConfiguring AI...");
            Console.Write("\nIt may take a few seconds to initial ADC, please wait... ");
            result = DSA_DASK.DSA_AI_9527_ConfigChannel(config_para.card_handle, config_para.ai_chnl_sel, config_para.ai_chnl_range, config_para.ai_chnl_config, false/*AutoReset*/);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_9527_ConfigChannel(), error: " + result);
                exit_handle();
            }
            Console.Write("done\n");

            // Configure trigger for a registered device
            result = DSA_DASK.DSA_TRG_Config(config_para.card_handle, config_para.trig_target, config_para.trig_config, config_para.retrig_count, config_para.trig_delay);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_TRG_Config(), error: " + result);
                exit_handle();
            }

            // If trigger source is set to analog trigger by using DSA_TRG_Config(),
            // This function should be called to setup analog trigger configurations.
            // Due to refer AI input range setting, DSA_AI_9527_ConfigChannel() must be called before calling this function.
            if (config_para.is_set_ana_trig)
            {
                result = DSA_DASK.DSA_TRG_ConfigAnalogTrigger(config_para.card_handle, config_para.ana_trig_src, config_para.ana_trig_mode, config_para.ana_trig_threshold);
                if (result != DSA_DASK.NoError)
                {
                    Console.Write("\nFalied to perform DSA_TRG_ConfigAnalogTrigger(), error: " + result);
                    exit_handle();
                }
            }

            // Enable double-buffer mode
            // DSA-Dask provides a technique called double-buffer mode to perform continuous AO operation.
            // Please refer DSA-DASK User Manual section 5.2 for details.
            result = DSA_DASK.DSA_AO_AsyncDblBufferMode(config_para.card_handle, true);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AO_AsyncDblBufferMode(), error: " + result);
                exit_handle();
            }

            // Enable double-buffer mode
            // DSA-Dask provides a technique called double-buffer mode to perform continuous AI operation.
            // Please refer DSA-DASK User Manual section 5.2 for details.
            result = DSA_DASK.DSA_AI_AsyncDblBufferMode(config_para.card_handle, true);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_AsyncDblBufferMode(), error: " + result);
                exit_handle();
            }

            // Setup buffer for data transfer
            // Allocates memory from the unmanaged memory of the process.
            // Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
            //       the memory might be moved by the GC and then an unexpected memory exception error is happened.
            config_para.ao_raw_data_buf = new IntPtr[2];
            config_para.ao_raw_data_buf[0] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ao_buf_size));
            config_para.ao_raw_data_buf[1] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ao_buf_size));
            ushort[] ao_buf_id = new ushort[2];
            for (int vi = 0; vi < 2; ++vi)
            {
                result = DSA_DASK.DSA_AO_ContBufferSetup(config_para.card_handle, config_para.ao_raw_data_buf[vi], config_para.ao_buf_size, out ao_buf_id[vi]);
                if (result != DSA_DASK.NoError)
                {
                    if (vi != 0)
                    {
                        // Reset buffer
                        DSA_DASK.DSA_AO_ContBufferReset(config_para.card_handle);
                    }
                    for (int vj = 0; vj < vi; ++ vj)
                    {
                        Marshal.FreeHGlobal(config_para.ao_raw_data_buf[vj]);
                    }
                    Console.Write("\nFalied to perform DSA_AO_ContBufferSetup(), error: " + result);
                    exit_handle();
                }
            }
            config_para.is_ao_set_buf = true;

            // Setup buffer for data transfer
            // Allocates memory from the unmanaged memory of the process.
            // Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
            //       the memory might be moved by the GC and then an unexpected memory exception error is happened.
            config_para.ai_raw_data_buf = new IntPtr[2];
            config_para.ai_raw_data_buf[0] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ai_buf_size));
            config_para.ai_raw_data_buf[1] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.ai_buf_size));
            config_para.ai_scale_data_buf = new double[config_para.ai_buf_size];
            config_para.ai_buf_id_array = new uint[1];
            ushort[] ai_buf_id = new ushort[2];
            for (int vi = 0; vi < 2; ++ vi)
            {
                result = DSA_DASK.DSA_AI_ContBufferSetup(config_para.card_handle, config_para.ai_raw_data_buf[vi], config_para.ai_buf_size, out ai_buf_id[vi]);
                if (result != DSA_DASK.NoError)
                {
                    if (vi != 0)
                    {
                        // Reset buffer
                        DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle);
                    }
                    for (int vj = 0; vj < vi; ++ vj)
                    {
                        Marshal.FreeHGlobal(config_para.ai_raw_data_buf[vj]);
                    }
                    Console.Write("\nFalied to perform DSA_AI_ContBufferSetup(), error: " + result);
                    exit_handle();
                }
            }
            config_para.ai_buf_id_array[0] = ai_buf_id[0];
            config_para.is_ai_set_buf = true;

            // Copy sine waveform to update buffer
            uint[] tmp_ao_raw_data_buf_1 = new uint[config_para.ao_buf_size];
            uint[] tmp_ao_raw_data_buf_2 = new uint[config_para.ao_buf_size];

            for (ushort vi = 0; vi < config_para.ao_chnl_cnt; ++ vi)
            {
                for (uint vj = 0; vj < config_para.ao_chnl_sample_count; ++ vj)
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
                Console.Write("\nFalied to perform DSA_AO_EventCallBack(), error: " + result);
                exit_handle();
            }
            config_para.is_ao_buf_ready_evt_set = true;

            // Set AI buffer Ready event
            result = DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_EventCallBack(), error: " + result);
                exit_handle();
            }
            config_para.is_ai_buf_ready_evt_set = true;

            // Set AO done event
            result = DSA_DASK.DSA_AO_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.AOEnd/*EventType*/, ao_done_cbdel);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AO_EventCallBack(), error: " + result);
                exit_handle();
            }
            config_para.is_ao_done_evt_set = true;

            // Set AI done event
            result = DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.AIEnd/*EventType*/, ai_done_cbdel);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_EventCallBack(), error: " + result);
                exit_handle();
            }
            config_para.is_ai_done_evt_set = true;

            Console.Write("\nPress 'Enter' to start AO & AI operation with actual sample rate {0:f4} & {1:f4} Hz", config_para.ao_actual_rate, config_para.ai_actual_rate);
            Console.ReadLine();

            // Write AO channel
            result = DSA_DASK.DSA_AO_ContWriteChannel(config_para.card_handle, config_para.ao_chnl_sel, ao_buf_id[0], config_para.ao_all_data_count, config_para.ao_upd_repeat_cnt, config_para.ao_upd_repeat_interval, config_para.ao_upd_op_definite, DSA_DASK.ASYNCH_OP);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AO_ContWriteChannel(), error: " + result);
                exit_handle();
            }
            config_para.is_ao_op_run = true;

            if (config_para.ai_file_format == 0)
            {
                // Open file
                config_para.ai_file_writer = new StreamWriter(config_para.ai_file_name);
                config_para.is_ai_file_open = true;

                // Read AI data, and the acquired raw data will be stored in the set buffer.
                result = DSA_DASK.DSA_AI_ContReadChannel(config_para.card_handle, config_para.ai_chnl_sel, 0/*Ignored*/, config_para.ai_buf_id_array, config_para.ai_all_data_count, 0/*Ignored*/, DSA_DASK.ASYNCH_OP);
            }
            else
            {
                // Read AI data, and the acquired raw data will be stored in the set buffer.
                // When the buffer is ready, call DSA_AI_AsyncDblBufferToFile() to transfer data to the specified binary file.
                result = DSA_DASK.DSA_AI_ContReadChannelToFile(config_para.card_handle, config_para.ai_chnl_sel, 0/*Ignored*/, config_para.ai_file_name, config_para.ai_all_data_count, 0/*Ignored*/, DSA_DASK.ASYNCH_OP);
            }
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_ContReadChannel[ToFile](), error: " + result);
                exit_handle();
            }
            config_para.is_ai_op_run = true;

            Console.Write("\nAO & AI operation is started, waiting trigger from the set trigger source...\n");

            if (config_para.is_gen_sw_trig)
            {
                // Generate software trigger if the trigger source is set to software trigger
                Console.Write("\nPress 'Enter' to generate software trigger.");
                Console.ReadLine();
                Console.Write("Generating software trigger... ");
                DSA_DASK.DSA_TRG_SoftTriggerGen(config_para.card_handle);
                Console.Write("done\n\n");
            }
            else
            {
                Console.Write("\n");
            }

            Console.ReadLine();

            // Stop AI and clear AI setting
            DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, out config_para.ai_access_cnt);
            config_para.is_ai_op_run = false;

            // Set event to tell ai_done_cbfunc() that DSA_AI_AsyncClear() is complete
            ai_store_last_buf_event.Set();

            // Wait for that ai_done_cbfunc() is complete
            ai_done_event.WaitOne();

            if (config_para.ai_file_format == 0)
            {
                Console.Write("\nAI data is stored in file {0}", config_para.ai_file_name);
                Console.Write("\nNote that the file was repeatly reset to be overwriten in each {0}s", config_para.ai_file_reset_factor);
            }
            else
            {
                Console.Write("\nAI data is stored in binary file {0}.dat", config_para.ai_file_name);
                Console.Write("\nYou can use Data File Convert Utility to convert it.");
            }

            // Stop AO and clear AO setting
            DSA_DASK.DSA_AO_AsyncClear(config_para.card_handle, out config_para.ao_access_cnt, 0);
            config_para.is_ao_op_run = false;

            // Wait for that ao_done_cbfunc() is complete
            ao_done_event.WaitOne();

            // Exit program
            exit_handle();
        }
    }
}
