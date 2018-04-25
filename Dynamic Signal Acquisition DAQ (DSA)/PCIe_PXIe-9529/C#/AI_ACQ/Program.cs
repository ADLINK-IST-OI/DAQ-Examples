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

namespace AI_ACQ
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
        public ushort timebase_src;
        public double sample_rate;
        public double actual_rate;

        // Channel configuration variables
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

        // Data buffer & file variables
        public uint chnl_sample_count;
        public uint all_data_count;
        public uint buf_size;
        public IntPtr raw_data_buf;
        public IntPtr raw_data_buf_alignment;
        public double[] scale_data_buf;
        public uint[] buf_id_array;
        public ushort file_format;
        public string file_name;
        public StreamWriter file_writer;

        // AI operation status variables
        public uint access_cnt;
        public bool op_stopped;
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
                DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, out config_para.access_cnt);
            }

            if (config_para.is_set_buf)
            {
                // Reset buffer
                DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle);

                Marshal.FreeHGlobal(config_para.raw_data_buf);
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

        // Configuration function for 9529
        static void p9529_config()
        {
            // Sub-card type
            Console.Write("\nSub-card type? (0) PCIe-9529, (1) PXIe-9529: [0] ");
            config_para.card_subtype = get_console_input((ushort)0);
            if (config_para.card_subtype > 1)
            {
                Console.Write("Warning! Invalid sub-card type. Force to set to PCIe-9529.\n");
                config_para.card_subtype = 0;
            }

            // Card number
            Console.Write("Card number? [0] ");
            config_para.card_num = get_console_input((ushort)0);

            // AI channel
            Console.Write("Number of channels? (1, 2, 4, 8): [1] ");
            config_para.chnl_cnt = get_console_input((ushort)1);
            if (config_para.chnl_cnt != 1 && config_para.chnl_cnt != 2 && config_para.chnl_cnt != 4 && config_para.chnl_cnt != 8)
            {
                Console.Write("Warning! Invalid number of channels. Force to set to 1.\n");
                config_para.chnl_cnt = 1;
            }

            // AI channel range
            Console.Write("Channel range? (0) B_10_V, (1) AD_B_1_V: [0] ");
            ushort tmp_chnl_range = get_console_input((ushort)0);
            double tmp_range_lower, tmp_range_upper;
            switch (tmp_chnl_range)
            {
                case 0:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                    tmp_range_lower = -10;
                    tmp_range_upper = 10;
                    break;
                case 1:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                    tmp_range_lower = -1;
                    tmp_range_upper = 1;
                    break;
                default:
                    Console.Write("Warning! Invalid channel range. Force to set to B_10_V.\n");
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                    tmp_range_lower = -10;
                    tmp_range_upper = 10;
                    break;
            }

            // AI channel input type
            Console.Write("Channel input type? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ", DSA_DASK.P9529_AI_Diff, DSA_DASK.P9529_AI_PseDiff);
            config_para.chnl_config = get_console_input((ushort)DSA_DASK.P9529_AI_PseDiff);
            if (config_para.chnl_config > DSA_DASK.P9529_AI_PseDiff)
            {
                Console.Write("Warning! Invalid channel input type. Force to set to PseudoDifferential.\n");
                config_para.chnl_config = (ushort)DSA_DASK.P9529_AI_PseDiff;
            }

            // AI channel input coupling
            Console.Write("Channel input coupling? (0) DC_Coupling, (1) AC_Coupling, (2) IEPE: [0] ");
            ushort tmp_chnl_config = get_console_input((ushort)0);
            switch (tmp_chnl_config)
            {
                case 0:
                    config_para.chnl_config |= (ushort)DSA_DASK.P9529_AI_Coupling_DC;
                    break;
                case 1:
                    config_para.chnl_config |= (ushort)DSA_DASK.P9529_AI_Coupling_AC;
                    break;
                case 2:
                    config_para.chnl_config |= (ushort)DSA_DASK.P9529_AI_EnableIEPE;
                    break;
                default:
                    Console.Write("Warning! Invalid channel input coupling. Force to set to DC_Coupling.\n");
                    config_para.chnl_config |= (ushort)DSA_DASK.P9529_AI_Coupling_DC;
                    break;
            }

            // Timebase source
            ushort tmp_tb_source;
            if (config_para.card_subtype == 0)
            {
                //PCIe-9529
                Console.Write("Timebase source? (0) Internal, (1) SSI_BUS[0]: [0] ");
                tmp_tb_source = get_console_input((ushort)0);
                switch(tmp_tb_source)
                {
                    case 0:
                        config_para.timebase_src = DSA_DASK.P9529_Internal;
                        break;
                    case 1:
                        config_para.timebase_src = DSA_DASK.P9529_TimeBase_SSI | DSA_DASK.P9529_ExtCLK_SSI;
                        break;
                    default:
                        Console.Write("Warning! Invalid timebase source. Force to set to Internal.\n");
                        config_para.timebase_src = DSA_DASK.P9529_Internal;
                        break;
                }
            }
            else
            {
                // PXIe-9529
                Console.Write("Timebase source? (0) Internal, (1) PXI_CLK10, (2) PXIe_CLK100, (3) TRIG_BUS[0], (4) TRIG_BUS[1], (5) TRIG_BUS[2], (6) TRIG_BUS[3], (7) TRIG_BUS[4], (8) TRIG_BUS[5], (9) TRIG_BUS[6], (10) TRIG_BUS[7]: [0] ");
                tmp_tb_source = get_console_input((ushort)0);
                switch(tmp_tb_source)
                {
                    case 0:
                        config_para.timebase_src = DSA_DASK.P9529_Internal;
                        break;
                    case 1:
                        config_para.timebase_src = DSA_DASK.P9529_PXI10M;
                        break;
                    case 2:
                        config_para.timebase_src = DSA_DASK.P9529_PXIE100M;
                        break;
                    case 3:
                        config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus | DSA_DASK.P9529_ExtCLK_TrgBus0;
                        break;
                    case 4:
                        config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus | DSA_DASK.P9529_ExtCLK_TrgBus1;
                        break;
                    case 5:
                        config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus | DSA_DASK.P9529_ExtCLK_TrgBus2;
                        break;
                    case 6:
                        config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus | DSA_DASK.P9529_ExtCLK_TrgBus3;
                        break;
                    case 7:
                        config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus | DSA_DASK.P9529_ExtCLK_TrgBus4;
                        break;
                    case 8:
                        config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus | DSA_DASK.P9529_ExtCLK_TrgBus5;
                        break;
                    case 9:
                        config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus | DSA_DASK.P9529_ExtCLK_TrgBus6;
                        break;
                    case 10:
                        config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus | DSA_DASK.P9529_ExtCLK_TrgBus7;
                        break;
                    default:
                        Console.Write("Warning! Invalid timebase source. Force to set to Internal.\n");
                        config_para.timebase_src = DSA_DASK.P9529_Internal;
                        break;
                }
            }

            // Timebase clk out

            // Sample rate
            uint tmp_sample_rate_min = 8000;
            uint tmp_sample_rate_max = 192000;
            Console.Write("Sample rate? ({0} ~ {1}): [{1}] ", tmp_sample_rate_min, tmp_sample_rate_max);
            config_para.sample_rate = get_console_input((double)tmp_sample_rate_max);
            if (config_para.sample_rate < tmp_sample_rate_min || config_para.sample_rate > tmp_sample_rate_max)
            {
                Console.Write("Warning! Invalid sample rate. Force to set to {0}.\n", tmp_sample_rate_max);
                config_para.sample_rate = (double)tmp_sample_rate_max;
            }

            // Trigger target
            config_para.trig_target = DSA_DASK.P9529_TRG_AI;

            // Trigger mode
            Console.Write("Trigger mode? ({0}) Post_trigger, ({1}) Delay_trigger: [{0}] ", DSA_DASK.P9529_TRG_MODE_POST, DSA_DASK.P9529_TRG_MODE_DELAY);
            bool tmp_set_delay_trig_cnt = false;
            config_para.trig_config = get_console_input((ushort)DSA_DASK.P9529_TRG_MODE_POST);
            if (config_para.trig_config > DSA_DASK.P9529_TRG_MODE_DELAY)
            {
                Console.Write("Warning! Invalid trigger mode. Force to set to Post_trigger.\n");
                config_para.trig_config = (ushort)DSA_DASK.P9529_TRG_MODE_POST;
            }
            else if (config_para.trig_config == DSA_DASK.P9529_TRG_MODE_DELAY)
            {
                tmp_set_delay_trig_cnt = true;
            }

            // Trigger source
            ushort tmp_trig_source;
            bool tmp_set_trig_pol = false;
            if (config_para.card_subtype == 0)
            {
                // PCIe-9529
                Console.Write("Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) SSI_BUS[5], (4) No_Wait: [4] ");
                tmp_trig_source = get_console_input((ushort)4);
                switch (tmp_trig_source)
                {
                    case 0:
                        config_para.is_gen_sw_trig = true;
                        config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_SOFT;
                        break;
                    case 1:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_EXTD;
                        break;
                    case 2:
                        config_para.is_set_ana_trig = true;
                        config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_ANALOG;
                        break;
                    case 3:
                        tmp_set_trig_pol = true;
                        config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_SSI;
                        break;
                    case 4:
                        config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_NOWAIT;
                        break;
                    default:
                        Console.Write("Warning! Invalid trigger source. Force to set to No_Wait.\n");
                        config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_NOWAIT;
                        break;
                }
            }
            else
            {
                // PXIe-9529
                Console.Write("Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) No_Wait, (4) PXIe_DSTARB, (5) PXI_STAR, (6) TRIG_BUS[0], (7) TRIG_BUS[1], (8) TRIG_BUS[2], (9) TRIG_BUS[3], (10) TRIG_BUS[4], (11) TRIG_BUS[5], (12) TRIG_BUS[6], (13) TRIG_BUS[7]: [3] ");
                tmp_trig_source = get_console_input((ushort)3);
                switch (tmp_trig_source)
                {
                case 0:
                    config_para.is_gen_sw_trig = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_SOFT;
                    break;
                case 1:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_EXTD;
                    break;
                case 2:
                    config_para.is_set_ana_trig = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_ANALOG;
                    break;
                case 3:
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_NOWAIT;
                    break;
                case 4:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXIE_STARTIN;
                    break;
                case 5:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_STARTIN;
                    break;
                case 6:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_BUS0;
                    break;
                case 7:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_BUS1;
                    break;
                case 8:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_BUS2;
                    break;
                case 9:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_BUS3;
                    break;
                case 10:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_BUS4;
                    break;
                case 11:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_BUS5;
                    break;
                case 12:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_BUS6;
                    break;
                case 13:
                    tmp_set_trig_pol = true;
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_PXI_BUS7;
                    break;
                default:
                    Console.Write("Warning! Invalid trigger source. Force to set to No_Wait.\n");
                    config_para.trig_config |= DSA_DASK.P9529_TRG_SRC_NOWAIT;
                    break;
                }
            }

            // Trigger out


            // Trigger polarity
            if (tmp_set_trig_pol)
            {
                Console.Write("Trigger polarity? (0) Negative, (1) Positive: [1] ");
                ushort tmp_trig_polarity = get_console_input((ushort)1);
                switch (tmp_trig_polarity)
                {
                    case 0:
                        config_para.trig_config |= DSA_DASK.P9529_TRG_Negative;
                        break;
                    case 1:
                        config_para.trig_config |= DSA_DASK.P9529_TRG_Positive;
                        break;
                    default:
                        Console.Write("Warning! Invalid trigger polarity. Force to set to Positive.\n");
                        config_para.trig_config |= DSA_DASK.P9529_TRG_Positive;
                        break;
                }
            }

            // Re-trigger settings
            // Disable re-trigger
            config_para.trig_config &= unchecked((ushort)(~((uint)DSA_DASK.P9529_TRG_EnReTigger)));
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
                Console.Write("Analog trigger source? AI_CH_(0 ~ {0}) [0] ", config_para.chnl_cnt - 1);
                ushort tmp_ana_trig_src = get_console_input((ushort)0);
                switch (tmp_ana_trig_src)
                {
                    case 0:
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH0;
                        break;
                    case 1:
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH1;
                        break;
                    case 2:
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH2;
                        break;
                    case 3:
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH3;
                        break;
                    case 4:
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH4;
                        break;
                    case 5:
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH5;
                        break;
                    case 6:
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH6;
                        break;
                    case 7:
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH7;
                        break;
                    default:
                        Console.Write("Warning! Invalid analog trigger source. Force to set to AI_CH_0.\n");
                        config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH0;
                        break;
                }

                // Analog trigger mode
                Console.Write("Analog trigger mode? ({0}) Above_threshold, ({1}) Below_threshold: [{0}] ", DSA_DASK.P9529_TRG_Analog_Above, DSA_DASK.P9529_TRG_Analog_Below);
                config_para.ana_trig_mode = get_console_input((uint)DSA_DASK.P9529_TRG_Analog_Above);
                if (config_para.ana_trig_mode > DSA_DASK.P9529_TRG_Analog_Below)
                {
                    Console.Write("Warning! Invalid analog trigger source. Force to set to Above_threshold.\n");
                    config_para.ana_trig_mode = DSA_DASK.P9529_TRG_Analog_Above;
                }

                // Analog trigger threshold
                Console.Write("Analog trigger threshold? ({0} ~ {1}): [0] ", tmp_range_lower, tmp_range_upper);
                config_para.ana_trig_threshold = get_console_input((double)0);
                if (config_para.ana_trig_threshold < tmp_range_lower || config_para.ana_trig_threshold > tmp_range_upper)
                {
                    Console.Write("Warning! Invalid analog trigger threshold. Force to set to 0.\n");
                    config_para.ana_trig_threshold = 0;
                }
            }

            // Sample count
            Console.Write("Sample count (per channel / per trigger)? [65536] ");
            config_para.chnl_sample_count = get_console_input((uint)65536);
            config_para.all_data_count = config_para.chnl_sample_count * config_para.chnl_cnt;
            if (config_para.all_data_count == 0 || config_para.all_data_count % 2 != 0)
            {
                Console.Write("Warning! Invalid sample count. Force to set to 65536.\n");
                config_para.chnl_sample_count = (uint)65536;
                config_para.all_data_count = config_para.chnl_sample_count * config_para.chnl_cnt;
            }
            config_para.buf_size = config_para.all_data_count;

            // File format
            Console.Write("Store data to (0) Text file, (1) Binary file: [0] ");
            config_para.file_format = get_console_input((ushort)0);
            string tmp_default_file_name;
            switch (config_para.file_format)
            {
                case 0:
                    tmp_default_file_name = "ai_data.csv";
                    break;
                case 1:
                    tmp_default_file_name = "ai_data";
                    break;
                default:
                    config_para.file_format = 0;
                    tmp_default_file_name = "ai_data.csv";
                    break;
            }
            if (config_para.file_format > 1)
            {
                config_para.file_format = 0;
            }

            // File name
            Console.Write("File name to be stored: [{0}] ", tmp_default_file_name);
            config_para.file_name = Console.ReadLine();
            if (config_para.file_name == "")
            {
                config_para.file_name = tmp_default_file_name;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("This example performs AI acquisition of a fixed number of samples.\n");
            Console.Write("Press 'Enter' to continue...");
            Console.ReadLine();

            config_para.card_type = DSA_DASK.PCI_9529;
            p9529_config();

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

            // Configure AI channels for a registered device
            // Note that the channel input range and input configuration can be set to different for each channel (This example sets the same setting for all enabled channels).
            bool chnl_mode = false;
            for (ushort vi = 0; vi < 8; ++ vi)
            {
                if (vi < config_para.chnl_cnt)
                {
                    chnl_mode = true; // This channel will be enabled
                }
                else
                {
                    chnl_mode = false; // This channel will be disabled
                }
                result = DSA_DASK.DSA_AI_9529_ConfigChannel(config_para.card_handle, vi, chnl_mode, config_para.chnl_range, config_para.chnl_config);
                if (result != DSA_DASK.NoError)
                {
                    Console.Write("\nFalied to perform DSA_AI_9529_ConfigChannel(), error: " + result);
                    exit_handle();
                }
            }

            Console.Write("\nConfiguring AI timebase...");
            Console.Write("\nIt may take a few seconds to initial ADC, please wait... ");

            // Configure sampling rate for a registered device, it will return the actual sample rate.
            // This function must be called before calling any AI-related functions to perform AI operation.
            // This function may take a few seconds to initial and adjust ADC settings
            result = DSA_DASK.DSA_ConfigSpeedRate(config_para.card_handle, DSA_DASK.DAQ_AI, config_para.timebase_src, config_para.sample_rate, out config_para.actual_rate);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_ConfigSpeedRate(), error: " + result);
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
            // Due to refer AI input range setting, DSA_AI_9529_ConfigChannel() must be called before calling this function.
            if (config_para.is_set_ana_trig)
            {
                result = DSA_DASK.DSA_TRG_ConfigAnalogTrigger(config_para.card_handle, config_para.ana_trig_src, config_para.ana_trig_mode, config_para.ana_trig_threshold);
                if (result != DSA_DASK.NoError)
                {
                    Console.Write("\nFalied to perform DSA_TRG_ConfigAnalogTrigger(), error: " + result);
                    exit_handle();
                }
            }

            // Disable double-buffer mode
            // DSA-Dask provides a technique called double-buffer mode to perform continuous AI operation.
            // Please refer DSA-DASK User Manual section 5.2 for details.
            // Due to acquire finite number of AI samples, we disable it.
            result = DSA_DASK.DSA_AI_AsyncDblBufferMode(config_para.card_handle, false);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_AsyncDblBufferMode(), error: " + result);
                exit_handle();
            }

            // Setup buffer for data transfer
            // Allocates memory from the unmanaged memory of the process.
            // Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
            //       the memory might be moved by the GC and then an unexpected memory exception error is happened.
            //       For 9529, the memory address of performing DMA transfer should be 16 alignment.
            config_para.raw_data_buf = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.buf_size) + 8);
            if (((int)config_para.raw_data_buf & 0x8) != 0)
            {
                config_para.raw_data_buf_alignment = config_para.raw_data_buf + 8;
            }
            else
            {
                config_para.raw_data_buf_alignment = config_para.raw_data_buf;
            }
            config_para.scale_data_buf = new double[config_para.buf_size];
            config_para.buf_id_array = new uint[1];
            ushort buf_id;
            result = DSA_DASK.DSA_AI_ContBufferSetup(config_para.card_handle, config_para.raw_data_buf_alignment, config_para.buf_size, out buf_id);
            if (result != DSA_DASK.NoError)
            {
                Marshal.FreeHGlobal(config_para.raw_data_buf);
                Console.Write("\nFalied to perform DSA_AI_ContBufferSetup(), error: " + result);
                exit_handle();
            }
            config_para.buf_id_array[0] = buf_id;
            config_para.is_set_buf = true;

            Console.Write("\nPress 'Enter' to start AI operation");
            Console.ReadLine();
            if (config_para.file_format == 0)
            {
                // Read AI data, and the acquired raw data will be stored in the set buffer.
                result = DSA_DASK.DSA_AI_ContReadChannel(config_para.card_handle, config_para.chnl_cnt, 0, config_para.buf_id_array, config_para.all_data_count, 0, DSA_DASK.ASYNCH_OP);
            }
            else
            {
                // Read AI data, and the acquired raw data will be stored in the set buffer.
                // When the buffer is ready, call DSA_AI_AsyncDblBufferToFile() to transfer data to the specified binary file.
                result = DSA_DASK.DSA_AI_ContReadChannelToFile(config_para.card_handle, config_para.chnl_cnt, 0, config_para.file_name, config_para.all_data_count, 0, DSA_DASK.ASYNCH_OP);
            }
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_ContReadChannel[ToFile](), error: " + result);
                exit_handle();
            }
            config_para.is_op_run = true;

            Console.Write("\nAI operation is started, waiting trigger from the set trigger source...\n");
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
                // In asynchronous mode, you can use this function to check the operation status.
                // When operation is complete, DSA_AI_AsyncClear() should be called to clear no longer used settings.
                result = DSA_DASK.DSA_AI_AsyncCheck(config_para.card_handle, out config_para.op_stopped, out config_para.access_cnt);
                if (result != DSA_DASK.NoError)
                {
                    Console.Write("\nFalied to perform DSA_AI_AsyncCheck(), error: " + result);
                    exit_handle();
                }

                Thread.Sleep(1);
            } while (Win32Interop._kbhit() == 0 && ! config_para.op_stopped);

            if (! config_para.op_stopped)
            {
                Console.ReadLine();
                Console.Write("AI acquisition is manually stopped!");
            }
            else
            {
                Console.Write("\nAI acquisition is complete!");
            }

            // Clear AI setting
            DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, out config_para.access_cnt);
            config_para.is_op_run = false;

            if (config_para.file_format == 0)
            {
                // Convert AI raw data to scaled data, it depends on the setting of channel range.
                Console.Write("\nConverting AI raw data... ");
                DSA_DASK.DSA_AI_ContVScale(config_para.card_handle, config_para.chnl_range, config_para.raw_data_buf_alignment, config_para.scale_data_buf, (int)config_para.access_cnt);
                Console.Write("done");

                // Write to file
                Console.Write("\nWriting AI data to text file {0}... ", config_para.file_name);
                config_para.file_writer = new StreamWriter(config_para.file_name);
                for (int vi = 0; vi < config_para.access_cnt / config_para.chnl_cnt; ++ vi)
                {
                    for (int vj = 0; vj < config_para.chnl_cnt; ++ vj)
                    {
                        config_para.file_writer.Write("{0:f8},", config_para.scale_data_buf[vi * config_para.chnl_cnt + vj]);
                    }
                    config_para.file_writer.Write("\n");
                }
                config_para.file_writer.Close();
                Console.Write("done");
            }
            else
            {
                // Transfer data to file
                Console.Write("\nTransfer AI data to binary file {0}.dat... ", config_para.file_name);
                DSA_DASK.DSA_AI_AsyncDblBufferToFile(config_para.card_handle);
                Console.Write("done");
                Console.Write("\nYou can use Data File Convert Utility to convert it.");
            }

            // Exit program
            exit_handle();
        }
    }
}
