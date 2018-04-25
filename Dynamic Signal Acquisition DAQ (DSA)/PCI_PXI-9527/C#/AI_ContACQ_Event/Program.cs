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

namespace AI_ContACQ_Event
{
    struct program_config
    {
        // Program status
        public bool is_reg_dev;
        public bool is_set_buf;
        public bool is_op_run;
        public bool is_done_evt_set;
        public bool is_buf_ready_evt_set;
        public bool is_file_open;

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

        // Data buffer & file variables
        public uint chnl_sample_count;
        public uint all_data_count;
        public uint buf_size;
        public IntPtr[] raw_data_buf;
        public double[] scale_data_buf;
        public uint[] buf_id_array;
        public ushort file_format;
        public string file_name;
        public StreamWriter file_writer;

        // AI operation status variables
        public uint access_cnt;
        public uint buf_ready_idx;
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
                DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, out config_para.access_cnt);
            }

            if (config_para.is_file_open)
            {
                // Close file
                config_para.file_writer.Close();
            }

            if (config_para.is_done_evt_set)
            {
                // Reset done event
                DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.AIEnd/*EventType*/, ai_done_cbdel);
            }

            if (config_para.is_buf_ready_evt_set)
            {
                // Reset buffer ready event
                DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 0/*remove*/, DSA_DASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
            }

            if (config_para.is_set_buf)
            {
                // Reset buffer
                DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle);

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
            Console.Write("Sample rate? ({0} ~ {1}): [{2}] ", DSA_DASK.P9527_AI_MinDDSFreq, DSA_DASK.P9527_AI_MaxDDSFreq, 48000);
            config_para.sample_rate = get_console_input((double)48000);
            if (config_para.sample_rate < DSA_DASK.P9527_AI_MinDDSFreq || config_para.sample_rate > DSA_DASK.P9527_AI_MaxDDSFreq)
            {
                Console.Write("Warning! Invalid sample rate. Force to set to {0}.\n", 48000);
                config_para.sample_rate = 48000;
            }

            // AI channel
            Console.Write("Channel selection? ({0}) AI_CH_0, ({1}) AI_CH_1, ({2}) AI_CH_DUAL: [{2}] ",
                          DSA_DASK.P9527_AI_CH_0, DSA_DASK.P9527_AI_CH_1, DSA_DASK.P9527_AI_CH_DUAL);
            config_para.chnl_sel = get_console_input((ushort)DSA_DASK.P9527_AI_CH_DUAL);
            switch(config_para.chnl_sel)
            {
                case DSA_DASK.P9527_AI_CH_0:
                case DSA_DASK.P9527_AI_CH_1:
                    config_para.chnl_cnt = 1;
                    break;
                case DSA_DASK.P9527_AI_CH_DUAL:
                    config_para.chnl_cnt = 2;
                    break;
                default:
                    Console.Write("Warning! Invalid channel selection. Force to set to AI_CH_DUAL.\n");
                    config_para.chnl_sel = (ushort)DSA_DASK.P9527_AI_CH_DUAL;
                    config_para.chnl_cnt = 2;
                    break;
            }

            // AI channel range
            Console.Write("Channel range? (0) B_40_V, (1) B_10_V, (2) B_3_16_V, (3) AD_B_1_V, (4) AD_B_0_316_V: [1] ");
            ushort tmp_chnl_range = get_console_input((ushort)1);
            double tmp_range_lower, tmp_range_upper;
            switch (tmp_chnl_range)
            {
                case 0:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_40_V;
                    tmp_range_lower = -40;
                    tmp_range_upper = 40;
                    break;
                case 1:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                    tmp_range_lower = -10;
                    tmp_range_upper = 10;
                    break;
                case 2:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_3_16_V;
                    tmp_range_lower = -3.16;
                    tmp_range_upper = 3.16;
                    break;
                case 3:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_1_V;
                    tmp_range_lower = -1;
                    tmp_range_upper = 1;
                    break;
                case 4:
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_0_316_V;
                    tmp_range_lower = -0.316;
                    tmp_range_upper = 0.316;
                    break;
                default:
                    Console.Write("Warning! Invalid channel range. Force to set to B_10_V.\n");
                    config_para.chnl_range = (ushort)DSA_DASK.AD_B_10_V;
                    tmp_range_lower = -10;
                    tmp_range_upper = 10;
                    break;
            }

            // AI channel input type
            Console.Write("Channel input type? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ",
                          DSA_DASK.P9527_AI_Differential, DSA_DASK.P9527_AI_PseudoDifferential);
            config_para.chnl_config = get_console_input((ushort)DSA_DASK.P9527_AI_PseudoDifferential);
            if (config_para.chnl_config > DSA_DASK.P9527_AI_PseudoDifferential)
            {
                Console.Write("Warning! Invalid channel input type. Force to set to PseudoDifferential.\n");
                config_para.chnl_config = (ushort)DSA_DASK.P9527_AI_PseudoDifferential;
            }

            // AI channel input coupling
            Console.Write("Channel input coupling? (0) DC_Coupling, (1) AC_Coupling, (2) IEPE: [0] ");
            ushort tmp_chnl_config = get_console_input((ushort)0);
            switch (tmp_chnl_config)
            {
                case 0:
                    config_para.chnl_config |= (ushort)DSA_DASK.P9527_AI_Coupling_DC;
                    break;
                case 1:
                    config_para.chnl_config |= (ushort)DSA_DASK.P9527_AI_Coupling_AC;
                    break;
                case 2:
                    config_para.chnl_config |= (ushort)DSA_DASK.P9527_AI_EnableIEPE;
                    break;
                default:
                    Console.Write("Warning! Invalid channel input coupling. Force to set to DC_Coupling.\n");
                    config_para.chnl_config |= (ushort)DSA_DASK.P9527_AI_Coupling_DC;
                    break;
            }

            // Trigger target
            config_para.trig_target = DSA_DASK.P9527_TRG_AI;

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
                if (config_para.chnl_sel == DSA_DASK.P9527_AI_CH_0)
                {
                    config_para.ana_trig_src = DSA_DASK.P9527_TRG_Analog_CH0;
                }
                else if (config_para.chnl_sel == DSA_DASK.P9527_AI_CH_1)
                {
                    config_para.ana_trig_src = DSA_DASK.P9527_TRG_Analog_CH1;
                }
                else
                {
                    Console.Write("Analog trigger source? ({0}) AI_CH_0, ({1}) AI_CH_1: [{0}] ",
                                  DSA_DASK.P9527_TRG_Analog_CH0, DSA_DASK.P9527_TRG_Analog_CH1);
                    config_para.ana_trig_src = get_console_input((uint)DSA_DASK.P9527_TRG_Analog_CH0);
                    if (config_para.ana_trig_src > DSA_DASK.P9527_TRG_Analog_CH1)
                    {
                        Console.Write("Warning! Invalid analog trigger source. Force to set to AI_CH_0.\n");
                        config_para.ana_trig_src = DSA_DASK.P9527_TRG_Analog_CH0;
                    }
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
                Console.Write("Analog trigger threshold? ({0} ~ {1}): [0] ", tmp_range_lower, tmp_range_upper);
                config_para.ana_trig_threshold = get_console_input((double)0);
                if (config_para.ana_trig_threshold < tmp_range_lower || config_para.ana_trig_threshold > tmp_range_upper)
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

        // Callback function for AI buffer ready event
        static void ai_buf_ready_cbfunc()
        {
            Console.Write("Buffer half ready, ready count: {0}\r", ++ config_para.buf_ready_cnt);

            if (config_para.file_format == 0)
            {
                // Convert AI raw data to scaled data, it depends on the setting of channel range.
                DSA_DASK.DSA_AI_ContVScale(config_para.card_handle, config_para.chnl_range,
                                           config_para.raw_data_buf[config_para.buf_ready_idx], config_para.scale_data_buf,
                                           (int)config_para.buf_size);

                config_para.buf_ready_idx ++;
                config_para.buf_ready_idx %= 2;

                // Write to file
                for (int vi = 0; vi < config_para.buf_size / config_para.chnl_cnt; ++ vi)
                {
                    for (int vj = 0; vj < config_para.chnl_cnt; ++ vj)
                    {
                        config_para.file_writer.Write("{0:f8},", config_para.scale_data_buf[vi * config_para.chnl_cnt + vj]);
                    }
                    config_para.file_writer.Write("\n");
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

        // Callback function for AI operation is complete
        static AutoResetEvent ai_store_last_buf_event = new AutoResetEvent(false);
        static AutoResetEvent ai_done_event = new AutoResetEvent(false);
        static void ai_done_cbfunc()
        {
            // Wait for that DSA_AI_AsyncClear() returns access_cnt to save last buffer data
            ai_store_last_buf_event.WaitOne();

            if (config_para.file_format == 0)
            {
                // Save last buffer data to file
                // Convert AI raw data to scaled data, it depends on the setting of channel range.
                DSA_DASK.DSA_AI_ContVScale(config_para.card_handle, config_para.chnl_range,
                                           config_para.raw_data_buf[config_para.buf_ready_idx], config_para.scale_data_buf,
                                           (int)config_para.access_cnt);

                // Write to file
                for (int vi = 0; vi < config_para.access_cnt / config_para.chnl_cnt; ++ vi)
                {
                    for (int vj = 0; vj < config_para.chnl_cnt; ++ vj)
                    {
                        config_para.file_writer.Write("{0:f8},", config_para.scale_data_buf[vi * config_para.chnl_cnt + vj]);
                    }
                    config_para.file_writer.Write("\n");
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
            Console.Write("This example performs AI acquisition of infinite number of samples.\n");
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
            // This function must be called before calling any AI-related functions to perform AI operation.
            // There is a timing constraint when AI and AO function are enabled simultaneously.
            // Please refer P9527 Hardware Manual section 3.5.3 for details.
            result = DSA_DASK.DSA_AI_9527_ConfigSampleRate(config_para.card_handle, config_para.sample_rate, out config_para.actual_rate);
            if (result != DSA_DASK.NoError)
            {
                if (result == -81)
                {
                    Console.Write("\nWarning! Sample rate has been locked by AO job!");
                }
                else
                {
                    Console.Write("\nFalied to perform DSA_AI_9527_ConfigSampleRate(), error: " + result);
                    exit_handle();
                }
            }

            // Configure AI channel/function for a registered device
            // This function may take a few seconds to initial and adjust ADC settings
            Console.Write("\nConfiguring AI...");
            Console.Write("\nIt may take a few seconds to initial ADC, please wait... ");
            result = DSA_DASK.DSA_AI_9527_ConfigChannel(config_para.card_handle, config_para.chnl_sel, config_para.chnl_range,
                                                        config_para.chnl_config, false/*AutoReset*/);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_9527_ConfigChannel(), error: " + result);
                exit_handle();
            }
            Console.Write("done\n");

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
                result = DSA_DASK.DSA_TRG_ConfigAnalogTrigger(config_para.card_handle, config_para.ana_trig_src, config_para.ana_trig_mode,
                                                              config_para.ana_trig_threshold);
                if (result != DSA_DASK.NoError)
                {
                    Console.Write("\nFalied to perform DSA_TRG_ConfigAnalogTrigger(), error: " + result);
                    exit_handle();
                }
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
            config_para.raw_data_buf = new IntPtr[2];
            config_para.raw_data_buf[0] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.buf_size));
            config_para.raw_data_buf[1] = Marshal.AllocHGlobal((int)(sizeof(uint) * config_para.buf_size));
            config_para.scale_data_buf = new double[config_para.buf_size];
            config_para.buf_id_array = new uint[1];
            ushort[] buf_id = new ushort[2];
            for (int vi = 0; vi < 2; ++ vi)
            {
                result = DSA_DASK.DSA_AI_ContBufferSetup(config_para.card_handle, config_para.raw_data_buf[vi],
                                                         config_para.buf_size, out buf_id[vi]);
                if (result != DSA_DASK.NoError)
                {
                    if (vi != 0)
                    {
                        // Reset buffer
                        DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle);
                    }
                    for (int vj = 0; vj < vi; ++ vj)
                    {
                        Marshal.FreeHGlobal(config_para.raw_data_buf[vj]);
                    }
                    Console.Write("\nFalied to perform DSA_AI_ContBufferSetup(), error: " + result);
                    exit_handle();
                }
            }
            config_para.buf_id_array[0] = buf_id[0];
            config_para.is_set_buf = true;

            // Set AI buffer Ready event
            result = DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_EventCallBack(), error: " + result);
                exit_handle();
            }
            config_para.is_buf_ready_evt_set = true;

            // Set AI done event
            result = DSA_DASK.DSA_AI_EventCallBack(config_para.card_handle, 1/*add*/, DSA_DASK.AIEnd/*EventType*/, ai_done_cbdel);
            if (result != DSA_DASK.NoError)
            {
                Console.Write("\nFalied to perform DSA_AI_EventCallBack(), error: " + result);
                exit_handle();
            }
            config_para.is_done_evt_set = true;

            Console.Write("\nPress 'Enter' to start AI operation with actual sample rate {0:f4} Hz", config_para.actual_rate);
            Console.ReadLine();
            if (config_para.file_format == 0)
            {
                // Open file
                config_para.file_writer = new StreamWriter(config_para.file_name);
                config_para.is_file_open = true;

                // Read AI data, and the acquired raw data will be stored in the set buffer.
                result = DSA_DASK.DSA_AI_ContReadChannel(config_para.card_handle, config_para.chnl_sel, 0/*Ignored*/,
                                                         config_para.buf_id_array, config_para.all_data_count, 0/*Ignored*/, DSA_DASK.ASYNCH_OP);
            }
            else
            {
                // Read AI data, and the acquired raw data will be stored in the set buffer.
                // When the buffer is ready, call DSA_AI_AsyncDblBufferToFile() to transfer data to the specified binary file.
                result = DSA_DASK.DSA_AI_ContReadChannelToFile(config_para.card_handle, config_para.chnl_sel, 0/*Ignored*/,
                                                               config_para.file_name, config_para.all_data_count, 0/*Ignored*/, DSA_DASK.ASYNCH_OP);
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

            Console.ReadLine();

            // Stop AI and clear AI setting
            DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, out config_para.access_cnt);
            config_para.is_op_run = false;

            // Set event to tell ai_done_cbfunc() that DSA_AI_AsyncClear() is complete
            ai_store_last_buf_event.Set();

            // Wait for that ai_done_cbfunc() is complete
            ai_done_event.WaitOne();

            if (config_para.file_format == 0)
            {
                Console.Write("\nAI data is stored in file {0}", config_para.file_name);
            }
            else
            {
                Console.Write("\nAI data is stored in binary file {0}.dat", config_para.file_name);
                Console.Write("\nYou can use Data File Convert Utility to convert it.");
            }

            // Exit program
            exit_handle();
        }
    }
}
