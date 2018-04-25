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

namespace AO_ContUPD
{
    struct program_config
    {
        // Program status
        public bool is_reg_dev;
        public bool is_set_buf;
        public bool is_op_run;

        // Device configuration variables
        public ushort card_type;
        public ushort card_subtype;
        public ushort card_num;
        public ushort card_handle;

        // Sample rate configuration variables
        public double sample_rate;
        public double actual_rate;

        // Channel configuration variables
        public ushort chnl_sel;
        public ushort chnl_cnt;
        public ushort chnl_range;
        public ushort chnl_config;

        // Trigger configuration variables
        public ushort trig_target;
        public ushort trig_config;
        public uint retrig_count;
        public uint trig_delay;
        public bool is_gen_sw_trig;
        public bool is_set_ana_trig;

        // Analog trigger configuration variables
        public uint ana_trig_src;
        public uint ana_trig_mode;
        public double ana_trig_threshold;
        public ushort ana_trig_src_range;
        public ushort ana_trig_src_config;

        // Data buffer & file variables
        public uint chnl_sample_count;
        public uint all_data_count;
        public uint buf_size;
        public uint[] sine_waveform;
        public uint[] square_waveform;
        public IntPtr[] raw_data_buf;

        // AO operation control variables
        public uint upd_repeat_cnt;
        public uint upd_repeat_interval;
        public ushort upd_op_definite;

        // AO operation status variables
        public uint access_cnt;
        public bool is_buf_ready;
        public uint buf_ready_cnt;
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
            if (config_para.is_op_run)
            {
                // Async Clear
                DSA_DASK.DSA_AO_AsyncClear(config_para.card_handle, out config_para.access_cnt, 0);
            }

            if (config_para.is_set_buf)
            {
                // Reset buffer
                DSA_DASK.DSA_AO_ContBufferReset(config_para.card_handle);

                Marshal.FreeHGlobal(config_para.raw_data_buf[0]);
                Marshal.FreeHGlobal(config_para.raw_data_buf[1]);
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

            // Sample rate
            Console.Write("Sample rate? ({0} ~ {1}): [{1}] ", DSA_DASK.P9527_AO_MinDDSFreq, DSA_DASK.P9527_AO_MaxDDSFreq);
            config_para.sample_rate = get_console_input((double)DSA_DASK.P9527_AO_MaxDDSFreq);
            if (config_para.sample_rate < DSA_DASK.P9527_AO_MinDDSFreq || config_para.sample_rate > DSA_DASK.P9527_AO_MaxDDSFreq)
            {
                Console.Write("Warning! Invalid sample rate. Force to set to {0}.\n", DSA_DASK.P9527_AO_MaxDDSFreq);
                config_para.sample_rate = (double)DSA_DASK.P9527_AO_MaxDDSFreq;
            }

            // AO channel
            Console.Write("Channel selection? ({0}) AO_CH_0, ({1}) AO_CH_1, ({2}) AO_CH_DUAL: [{2}] ",
                          DSA_DASK.P9527_AO_CH_0, DSA_DASK.P9527_AO_CH_1, DSA_DASK.P9527_AO_CH_DUAL);
            config_para.chnl_sel = get_console_input((ushort)DSA_DASK.P9527_AO_CH_DUAL);
            switch(config_para.chnl_sel)
            {
                case DSA_DASK.P9527_AO_CH_0:
                case DSA_DASK.P9527_AO_CH_1:
                    config_para.chnl_cnt = 1;
                    break;
                case DSA_DASK.P9527_AO_CH_DUAL:
                    config_para.chnl_cnt = 2;
                    break;
                default:
                    Console.Write("Warning! Invalid channel selection. Force to set to AO_CH_DUAL.\n");
                    config_para.chnl_sel = (ushort)DSA_DASK.P9527_AO_CH_DUAL;
                    config_para.chnl_cnt = 2;
                    break;
            }

            // AO channel range
            Console.Write("Channel range? (0) B_10_V, (1) AD_B_1_V, (2) AD_B_0_1_V: [0] ");
            ushort tmp_chnl_range = get_console_input((ushort)0);
            switch (tmp_chnl_range)
            {
                case 0:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                    break;
                case 1:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                    break;
                case 2:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_0_1_V;
                    break;
                default:
                    Console.Write("Warning! Invalid channel range. Force to set to B_10_V.\n");
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                    break;
            }

            // AO channel output type
            ushort tmp_chnl_output_type_max;
            if (config_para.chnl_sel == DSA_DASK.P9527_AO_CH_0)
            {
                // BalancedOutput is only supported when channel is set to AO_CH_0
                tmp_chnl_output_type_max = DSA_DASK.P9527_AO_BalancedOutput;
                Console.Write("Channel output type? ({0}) Differential, ({1}) PseudoDifferential, ({2}) BalancedOutput: [{1}] ",
                              DSA_DASK.P9527_AO_Differential, DSA_DASK.P9527_AO_PseudoDifferential, DSA_DASK.P9527_AO_BalancedOutput);
            }
            else
            {
                tmp_chnl_output_type_max = DSA_DASK.P9527_AO_PseudoDifferential;
                Console.Write("Channel output type? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ",
                              DSA_DASK.P9527_AO_Differential, DSA_DASK.P9527_AO_PseudoDifferential);
            }
            config_para.chnl_config = get_console_input((ushort)DSA_DASK.P9527_AO_PseudoDifferential);
            if (config_para.chnl_config > tmp_chnl_output_type_max)
            {
                Console.Write("Warning! Invalid channel output type. Force to set to PseudoDifferential.\n");
                config_para.chnl_config = (ushort)DSA_DASK.P9527_AO_PseudoDifferential;
            }

            // Trigger target
            config_para.trig_target = DSA_DASK.P9527_TRG_AO;

            // Trigger mode
            Console.Write("Trigger mode? ({0}) Post_trigger, ({1}) Delay_trigger: [{0}] ",
                          DSA_DASK.P9527_TRG_MODE_POST, DSA_DASK.P9527_TRG_MODE_DELAY);
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
            }

            // Trigger source
            ushort tmp_trig_source;
            bool tmp_set_trig_pol = false;
            if (config_para.card_subtype == 0)
            {
                // PCI-9527
                Console.Write("Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) SSI_9, (4) No_Wait: [4] ");
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
                Console.Write("Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) No_Wait, (4) PXI_StartIn, (5) PXI_Bus_0, (6) PXI_Bus_1, (7) PXI_Bus_2, (8) PXI_Bus_3, (9) PXI_Bus_4, (10) PXI_Bus_5, (11) PXI_Bus_6, (12) PXI_Bus_7: [3] ");
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
            }

            // Trigger polarity
            if (tmp_set_trig_pol)
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
            }

            // Re-trigger settings
            // Disable re-trigger
            config_para.trig_config &= unchecked((ushort)(~((uint)DSA_DASK.P9527_TRG_EnReTigger)));
            config_para.retrig_count = 0;

            // Delay trigger settings
            if (tmp_set_delay_trig_cnt)
            {
                Console.Write("Delay trigger count? (0 ~ 4294967295): [0] ");
                config_para.trig_delay = get_console_input((uint)0);
            }

            // Analog trigger settings
            if (config_para.is_set_ana_trig)
            {
                // Analog trigger source
                Console.Write("Analog trigger source? ({0}) AI_CH_0, ({1}) AI_CH_1: [{0}] ",
                              DSA_DASK.P9527_TRG_Analog_CH0, DSA_DASK.P9527_TRG_Analog_CH1);
                config_para.ana_trig_src = get_console_input((uint)DSA_DASK.P9527_TRG_Analog_CH0);
                if (config_para.ana_trig_src > DSA_DASK.P9527_TRG_Analog_CH1)
                {
                    Console.Write("Warning! Invalid analog trigger source. Force to set to AI_CH_0.\n");
                    config_para.ana_trig_src = DSA_DASK.P9527_TRG_Analog_CH0;
                }

                // Analog trigger source range
                Console.Write("Analog trigger source configuration [range]? (0) B_40_V, (1) B_10_V, (2) B_3_16_V, (3) AD_B_1_V, (4) AD_B_0_316_V: [1] ");
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

                // Analog trigger source input type
                Console.Write("Analog trigger source configuration [input type]? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ",
                              DSA_DASK.P9527_AI_Differential, DSA_DASK.P9527_AI_PseudoDifferential);
                config_para.ana_trig_src_config = get_console_input((ushort)DSA_DASK.P9527_AI_PseudoDifferential);
                if (config_para.ana_trig_src_config > DSA_DASK.P9527_AI_PseudoDifferential)
                {
                    Console.Write("Warning! Invalid analog trigger source input type. Force to set to PseudoDifferential.\n");
                    config_para.ana_trig_src_config = (ushort)DSA_DASK.P9527_AI_PseudoDifferential;
                }

                // Analog trigger source input coupling
                Console.Write("Analog trigger source configuration [input coupling]? (0) DC_Coupling, (1) AC_Coupling, (2) IEPE: [0] ");
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

                // Analog trigger mode
                Console.Write("Analog trigger mode? ({0}) Above_threshold, ({1}) Below_threshold: [{0}] ",
                              DSA_DASK.P9527_TRG_Analog_Above_threshold, DSA_DASK.P9527_TRG_Analog_Below_threshold);
                config_para.ana_trig_mode = get_console_input((uint)DSA_DASK.P9527_TRG_Analog_Above_threshold);
                if (config_para.ana_trig_mode > DSA_DASK.P9527_TRG_Analog_Below_threshold)
                {
                    Console.Write("Warning! Invalid analog trigger source. Force to set to Above_threshold.\n");
                    config_para.ana_trig_mode = DSA_DASK.P9527_TRG_Analog_Above_threshold;
                }

                // Analog trigger threshold
                Console.Write("Analog trigger threshold? ({0} ~ {1}): [0] ", tmp_ana_trig_src_range_lower, tmp_ana_trig_src_range_upper);
                config_para.ana_trig_threshold = get_console_input((double)0);
                if (config_para.ana_trig_threshold < tmp_ana_trig_src_range_lower || config_para.ana_trig_threshold > tmp_ana_trig_src_range_upper)
                {
                    Console.Write("Warning! Invalid analog trigger threshold. Force to set to 0.\n");
                    config_para.ana_trig_threshold = 0;
                }
            }

            // Sample count
            Console.Write("Sample count (per channel / per buffer)? [65536] ");
            config_para.chnl_sample_count = get_console_input((uint)65536);
            config_para.all_data_count = config_para.chnl_sample_count * config_para.chnl_cnt;
            if (config_para.all_data_count == 0 || config_para.all_data_count % 2 != 0)
            {
                Console.Write("Warning! Invalid sample count. Force to set to 65536.\n");
                config_para.chnl_sample_count = (uint)65536;
                config_para.all_data_count = config_para.chnl_sample_count * config_para.chnl_cnt;
            }
            config_para.buf_size = config_para.all_data_count;

            // Sine waveform
            config_para.sine_waveform = new uint[config_para.chnl_sample_count];
            uint sine_amplitude = 0x7FFFFF; // AO +FSR
            uint sine_frequency = 1;
            for (int vi = 0; vi < config_para.chnl_sample_count; ++ vi)
            {
                config_para.sine_waveform[vi] = (uint)(sine_amplitude * Math.Sin((2 * Math.PI * vi * sine_frequency) / config_para.chnl_sample_count));
            }

            // Square waveform
            config_para.square_waveform = new uint[config_para.chnl_sample_count];
            for (int vi = 0; vi < config_para.chnl_sample_count; ++vi)
            {
                if (vi <= config_para.chnl_sample_count / 2)
                {
                    config_para.square_waveform[vi] = 0x7FFFFF; // AO +FSR
                }
                else
                {
                    config_para.square_waveform[vi] = 0x800000; // AO -FSR
                }
            }

            // Update repeat iterations
            // When continuous waveforms to be output, set iteration to 0 and definite to 0
            config_para.upd_repeat_cnt = 0;
            config_para.upd_op_definite = 0;

            // Update repeat interval
            config_para.upd_repeat_interval = 0;
        }

        static void Main(string[] args)
        {
            Console.Write("This example performs AO update of continuous sine/SQUARE waveforms.\n");
            Console.Write("Press 'Enter' to continue...");
            Console.ReadLine();

            config_para.card_type = DSA_DASK.PCI_9527;
            p9527_config();

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
            result = DSA_DASK.DSA_AO_9527_ConfigSampleRate(config_para.card_handle, config_para.sample_rate, out config_para.actual_rate);
            if (result != DSA_DASK.NoError)
            {
                if (result == -81)
                {
                    Console.Write("\nWarning! Sample rate has been locked by AI job!");
                }
                else
                {
                    Console.Write("\nFalied to perform DSA_AO_9527_ConfigSampleRate(), error: " + result);
                    exit_handle();
                }
            }

            // Configure AO channel/function for a registered device
            result = DSA_DASK.DSA_AO_9527_ConfigChannel(config_para.card_handle, config_para.chnl_sel, config_para.chnl_range,
                                                        config_para.chnl_config, false/*AutoReset*/);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AO_9527_ConfigChannel(), error: " + result);
                exit_handle();
            }

            // Configure trigger for a registered device
            result = DSA_DASK.DSA_TRG_Config(config_para.card_handle, config_para.trig_target, config_para.trig_config,
                                             config_para.retrig_count, config_para.trig_delay);
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
                // Force to set AI sample rate to double of AO sample rate,
                // since there is a timing constraint when AI and AO function are enabled simultaneously.
                // Please refer P9527 Hardware Manual section 3.5.3 for details.
                double tmp_ai_sample_rate = config_para.sample_rate * 2;
                double tmp_ai_actual_rate;
                DSA_DASK.DSA_AI_9527_ConfigSampleRate(config_para.card_handle, tmp_ai_sample_rate, out tmp_ai_actual_rate);

                Console.Write("\nConfiguring AI...");
                Console.Write("\nIt may take a few seconds to initial ADC, please wait... ");
                DSA_DASK.DSA_AI_9527_ConfigChannel(config_para.card_handle, (ushort)config_para.ana_trig_src,
                                                   config_para.ana_trig_src_range, config_para.ana_trig_src_config, false/*AutoReset*/);
                Console.Write("done\n");

                result = DSA_DASK.DSA_TRG_ConfigAnalogTrigger(config_para.card_handle, config_para.ana_trig_src, config_para.ana_trig_mode,
                                                              config_para.ana_trig_threshold);
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

            // Setup buffer for data transfer
            // Allocates memory from the unmanaged memory of the process.
            // Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
            //       the memory might be moved by the GC and then an unexpected memory exception error is happened.
            config_para.raw_data_buf = new IntPtr[2];
            config_para.raw_data_buf[0] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.buf_size));
            config_para.raw_data_buf[1] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.buf_size));
            ushort[] buf_id = new ushort[2];
            for (int vi = 0; vi < 2; ++vi)
            {
                result = DSA_DASK.DSA_AO_ContBufferSetup(config_para.card_handle, config_para.raw_data_buf[vi],
                                                         config_para.buf_size, out buf_id[vi]);
                if (result != DSA_DASK.NoError)
                {
                    if (vi != 0)
                    {
                        // Reset buffer
                        DSA_DASK.DSA_AO_ContBufferReset(config_para.card_handle);
                    }
                    for (int vj = 0; vj < vi; ++ vj)
                    {
                        Marshal.FreeHGlobal(config_para.raw_data_buf[vj]);
                    }
                    Console.Write("\nFalied to perform DSA_AO_ContBufferSetup(), error: " + result);
                    exit_handle();
                }
            }
            config_para.is_set_buf = true;

            // Copy sine/square waveform to update buffer
            uint[] tmp_raw_data_buf_1 = new uint[config_para.buf_size];
            uint[] tmp_raw_data_buf_2 = new uint[config_para.buf_size];

            for (ushort vi = 0; vi < config_para.chnl_cnt; ++ vi)
            {
                for (uint vj = 0; vj < config_para.chnl_sample_count; ++ vj)
                {
                    uint tmp_buf_idx = vj * config_para.chnl_cnt + vi;
                    if (tmp_buf_idx >= config_para.buf_size)
                    {
                        break;
                    }
                    tmp_raw_data_buf_1[vj * config_para.chnl_cnt + vi] = config_para.sine_waveform[vj];
                    tmp_raw_data_buf_2[vj * config_para.chnl_cnt + vi] = config_para.square_waveform[vj];
                }
            }
            Marshal.Copy((int[])(object)tmp_raw_data_buf_1, 0, config_para.raw_data_buf[0], (int)(config_para.buf_size));
            Marshal.Copy((int[])(object)tmp_raw_data_buf_2, 0, config_para.raw_data_buf[1], (int)(config_para.buf_size));

            Console.Write("\nPress 'Enter' to start AO operation with actual sample rate {0:f4} Hz", config_para.actual_rate);
            Console.ReadLine();
            // Write AO channel
            result = DSA_DASK.DSA_AO_ContWriteChannel(config_para.card_handle, config_para.chnl_sel, buf_id[0], config_para.all_data_count,
                                                      config_para.upd_repeat_cnt, config_para.upd_repeat_interval,
                                                      config_para.upd_op_definite, DSA_DASK.ASYNCH_OP);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AO_ContWriteChannel(), error: " + result);
                exit_handle();
            }
            config_para.is_op_run = true;

            Console.Write("\nAO operation is started, waiting trigger from the set trigger source...\n");

            if (config_para.is_gen_sw_trig)
            {
                // Generate software trigger if the trigger source is set to software trigger
                Console.Write("\nPress 'Enter' to generate software trigger.");
                Console.ReadLine();
                Console.Write("Generating software trigger... ");
                DSA_DASK.DSA_TRG_SoftTriggerGen(config_para.card_handle);
                Console.Write("done\n");
            }

            do {
                // In double-buffer mode, you can use this function to check the operation status.
                // After stopping operation, DSA_AO_AsyncClear() should be called to clear no longer used settings.
                result = DSA_DASK.DSA_AO_AsyncDblBufferHalfReady(config_para.card_handle, out config_para.is_buf_ready);
                if (result != DSA_DASK.NoError)
                {
                    Console.Write("\nFalied to perform DSA_AO_AsyncDblBufferHalfReady(), error: " + result);
                    exit_handle();
                }

                if (config_para.is_buf_ready)
                {
                    Console.Write("Buffer half ready, ready count: {0}\r", ++ config_para.buf_ready_cnt);
                }

                Thread.Sleep(1);
            } while (Win32Interop._kbhit() == 0);

            Console.ReadLine();
            Console.Write("\nAO update is manually stopped!");

            // Clear AO setting
            DSA_DASK.DSA_AO_AsyncClear(config_para.card_handle, out config_para.access_cnt, 0);
            config_para.is_op_run = false;

            // Exit program
            exit_handle();
        }
    }
}
