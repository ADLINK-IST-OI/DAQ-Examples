Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Threading

Public Class Win32Interop
    <DllImport("crtdll.dll")>
    Public Shared Function _kbhit() As Integer
    End Function
End Class

Public Structure program_config
    ' Program status
    Public is_reg_dev As Boolean
    Public is_set_buf As Boolean
    Public is_op_run As Boolean
    Public is_file_open As Boolean

    ' Device configuration variables
    Public card_type As UShort
    Public card_subtype As UShort
    Public card_num As UShort
    Public card_handle As UShort

    ' Timebase configuration variables
    Public timebase_src As UShort
    Public sample_rate As Double
    Public actual_rate As Double

    ' Channel configuration variables
    Public chnl_cnt As UShort
    Public chnl_range As UShort
    Public chnl_config As UShort

    ' Trigger configuration variables
    Public trig_target As UShort
    Public trig_config As UShort
    Public retrig_count As UInteger
    Public trig_delay As UInteger
    Public is_gen_sw_trig As Boolean
    Public is_set_ana_trig As Boolean

    ' Analog trigger configuration variables
    Public ana_trig_src As UInteger
    Public ana_trig_mode As UInteger
    Public ana_trig_threshold As Double

    ' Data buffer & file variables
    Public chnl_sample_count As UInteger
    Public all_data_count As UInteger
    Public buf_size As UInteger
    Public raw_data_buf As IntPtr()
    Public raw_data_buf_alignment As IntPtr()
    Public scale_data_buf As Double()
    Public buf_id_array As UInteger()
    Public file_format As UShort
    Public file_name As String
    Public file_writer As StreamWriter

    ' AI operation status variables
    Public access_cnt As UInteger
    Public op_stopped As Boolean
    Public is_buf_ready As Boolean
    Public buf_ready_idx As UInteger
    Public buf_ready_cnt As UInteger
End Structure

Module Module1
    Dim config_para As program_config

    'Get console ushort input
    Function get_console_input(default_value As UShort) As UShort
        Dim result As UShort

        Try
            result = Convert.ToUInt16(Console.ReadLine())
        Catch ex As Exception
            result = default_value
        End Try

        Return result
    End Function

    'Get console uint input
    Function get_console_input(default_value As UInteger) As UInteger
        Dim result As UInteger

        Try
            result = Convert.ToUInt32(Console.ReadLine())
        Catch ex As Exception
            result = default_value
        End Try

        Return result
    End Function

    'Get console double input
    Function get_console_input(default_value As Double) As Double
        Dim result As Double

        Try
            result = Convert.ToDouble(Console.ReadLine())
        Catch ex As Exception
            result = default_value
        End Try

        Return result
    End Function

    ' Program exit handler
    Sub exit_handle()
        If config_para.is_op_run Then
            ' Async Clear
            DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, config_para.access_cnt)
        End If

        If config_para.is_file_open Then
            ' Close file
            config_para.file_writer.Close()
        End If

        If config_para.is_set_buf Then
            ' Reset buffer
            DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle)

            Marshal.FreeHGlobal(config_para.raw_data_buf(0))
            Marshal.FreeHGlobal(config_para.raw_data_buf(1))
        End If

        If config_para.is_reg_dev Then
            ' Release device
            DSA_DASK.DSA_Release_Card(config_para.card_handle)
        End If

        Console.Write(vbCrLf + vbCrLf + "Press any key to exit...")
        Console.ReadLine()
        Environment.Exit(0)
    End Sub

    ' Configuration function for 9529
    Sub p9529_config()
        ' Sub-card type
        Console.Write(vbCrLf + "Sub-card type? (0) PCIe-9529, (1) PXIe-9529: [0] ")
        config_para.card_subtype = get_console_input(Convert.ToUInt16(0))
        If config_para.card_subtype > 1 Then
            Console.Write("Warning! Invalid sub-card type. Force to set to PCIe-9529." + vbCrLf)
            config_para.card_subtype = 0
        End If

        ' Card number
        Console.Write("Card number? [0] ")
        config_para.card_num = get_console_input(Convert.ToUInt16(0))

        ' AI channel
        Console.Write("Number of channels? (1, 2, 4, 8): [1] ")
        config_para.chnl_cnt = get_console_input(Convert.ToUInt16(1))
        If config_para.chnl_cnt <> 1 AndAlso config_para.chnl_cnt <> 2 AndAlso config_para.chnl_cnt <> 4 AndAlso config_para.chnl_cnt <> 8 Then
            Console.Write("Warning! Invalid number of channels. Force to set to 1." + vbCrLf)
            config_para.chnl_cnt = 1
        End If

        ' AI channel range
        Console.Write("Channel range? (0) B_10_V, (1) AD_B_1_V: [0] ")
        Dim tmp_chnl_range As UShort = get_console_input(Convert.ToUInt16(0))
        Dim tmp_range_lower As Double, tmp_range_upper As Double
        Select Case tmp_chnl_range
            Case 0
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_10_V)
                tmp_range_lower = -10
                tmp_range_upper = 10
            Case 1
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_1_V)
                tmp_range_lower = -1
                tmp_range_upper = 1
            Case Else
                Console.Write("Warning! Invalid channel range. Force to set to B_10_V." + vbCrLf)
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_10_V)
                tmp_range_lower = -10
                tmp_range_upper = 10
        End Select

        ' AI channel input type
        Console.Write("Channel input type? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ", DSA_DASK.P9529_AI_Diff, DSA_DASK.P9529_AI_PseDiff)
        config_para.chnl_config = get_console_input(Convert.ToUInt16(DSA_DASK.P9529_AI_PseDiff))
        If config_para.chnl_config > DSA_DASK.P9529_AI_PseDiff Then
            Console.Write("Warning! Invalid channel input type. Force to set to PseudoDifferential." + vbCrLf)
            config_para.chnl_config = Convert.ToUInt16(DSA_DASK.P9529_AI_PseDiff)
        End If

        ' AI channel input coupling
        Console.Write("Channel input coupling? (0) DC_Coupling, (1) AC_Coupling, (2) IEPE: [0] ")
        Dim tmp_chnl_config As UShort = get_console_input(Convert.ToUInt16(0))
        Select Case tmp_chnl_config
            Case 0
                config_para.chnl_config = config_para.chnl_config Or Convert.ToUInt16(DSA_DASK.P9529_AI_Coupling_DC)
            Case 1
                config_para.chnl_config = config_para.chnl_config Or Convert.ToUInt16(DSA_DASK.P9529_AI_Coupling_AC)
            Case 2
                config_para.chnl_config = config_para.chnl_config Or Convert.ToUInt16(DSA_DASK.P9529_AI_EnableIEPE)
            Case Else
                Console.Write("Warning! Invalid channel input coupling. Force to set to DC_Coupling." + vbCrLf)
                config_para.chnl_config = config_para.chnl_config Or Convert.ToUInt16(DSA_DASK.P9529_AI_Coupling_DC)
        End Select

        ' Timebase source
        Dim tmp_tb_source As UShort
        If config_para.card_subtype = 0 Then
            ' PCIe-9529
            Console.Write("Timebase source? (0) Internal, (1) SSI_BUS[0]: [0] ")
            tmp_tb_source = get_console_input(Convert.ToUInt16(0))
            Select Case tmp_tb_source
                Case 0
                    config_para.timebase_src = DSA_DASK.P9529_Internal
                Case 1
                    config_para.timebase_src = DSA_DASK.P9529_TimeBase_SSI Or DSA_DASK.P9529_ExtCLK_SSI
                Case Else
                    Console.Write("Warning! Invalid timebase source. Force to set to Internal." + vbCrLf)
                    config_para.timebase_src = DSA_DASK.P9529_Internal
            End Select
        Else
            ' PXIe-9529
            Console.Write("Timebase source? (0) Internal, (1) PXI_CLK10, (2) PXIe_CLK100, (3) TRIG_BUS[0], (4) TRIG_BUS[1], (5) TRIG_BUS[2], (6) TRIG_BUS[3], (7) TRIG_BUS[4], (8) TRIG_BUS[5], (9) TRIG_BUS[6], (10) TRIG_BUS[7]: [0] ")
            tmp_tb_source = get_console_input(Convert.ToUInt16(0))
            Select Case tmp_tb_source
                Case 0
                    config_para.timebase_src = DSA_DASK.P9529_Internal
                Case 1
                    config_para.timebase_src = DSA_DASK.P9529_PXI10M
                Case 2
                    config_para.timebase_src = DSA_DASK.P9529_PXI100M
                Case 3
                    config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus Or DSA_DASK.P9529_ExtCLK_TrgBus0
                Case 4
                    config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus Or DSA_DASK.P9529_ExtCLK_TrgBus1
                Case 5
                    config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus Or DSA_DASK.P9529_ExtCLK_TrgBus2
                Case 6
                    config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus Or DSA_DASK.P9529_ExtCLK_TrgBus3
                Case 7
                    config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus Or DSA_DASK.P9529_ExtCLK_TrgBus4
                Case 8
                    config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus Or DSA_DASK.P9529_ExtCLK_TrgBus5
                Case 9
                    config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus Or DSA_DASK.P9529_ExtCLK_TrgBus6
                Case 10
                    config_para.timebase_src = DSA_DASK.P9529_PXITRIGBus Or DSA_DASK.P9529_ExtCLK_TrgBus7
                Case Else
                    Console.Write("Warning! Invalid timebase source. Force to set to Internal." + vbCrLf)
                    config_para.timebase_src = DSA_DASK.P9529_Internal
            End Select
        End If

        ' Timebase clk out

        ' Sample rate
        Dim tmp_sample_rate_min As UInteger = 8000
        Dim tmp_sample_rate_max As UInteger = 192000
        Console.Write("Sample rate? ({0} ~ {1}): [{2}] ", tmp_sample_rate_min, tmp_sample_rate_max, 48000)
        config_para.sample_rate = get_console_input(48000)
        If config_para.sample_rate < tmp_sample_rate_min OrElse config_para.sample_rate > tmp_sample_rate_max Then
            Console.Write("Warning! Invalid sample rate. Force to set to {0}." + vbCrLf, 48000)
            config_para.sample_rate = Convert.ToDouble(48000)
        End If

        ' Trigger target
        config_para.trig_target = DSA_DASK.P9529_TRG_AI

        ' Trigger mode
        Console.Write("Trigger mode? ({0}) Post_trigger, ({1}) Delay_trigger: [{0}] ", DSA_DASK.P9529_TRG_MODE_POST, DSA_DASK.P9529_TRG_MODE_DELAY)
        Dim tmp_set_delay_trig_cnt As Boolean = False
        config_para.trig_config = get_console_input(Convert.ToUInt16(DSA_DASK.P9529_TRG_MODE_POST))
        If config_para.trig_config > DSA_DASK.P9529_TRG_MODE_DELAY Then
            Console.Write("Warning! Invalid trigger mode. Force to set to Post_trigger." + vbCrLf)
            config_para.trig_config = Convert.ToUInt16(DSA_DASK.P9529_TRG_MODE_POST)
        ElseIf config_para.trig_config = DSA_DASK.P9527_TRG_MODE_DELAY Then
            tmp_set_delay_trig_cnt = True
        End If

        ' Trigger source
        Dim tmp_trig_source As UShort
        Dim tmp_set_trig_pol As Boolean = False
        If config_para.card_subtype = 0 Then
            ' PCIe-9529
            Console.Write("Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) SSI_BUS[5], (4) No_Wait: [4] ")
            tmp_trig_source = get_console_input(Convert.ToUInt16(4))
            Select Case tmp_trig_source
                Case 0
                    config_para.is_gen_sw_trig = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_SOFT
                Case 1
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_EXTD
                Case 2
                    config_para.is_set_ana_trig = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_ANALOG
                Case 3
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_SSI
                Case 4
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_NOWAIT
                Case Else
                    Console.Write("Warning! Invalid trigger source. Force to set to No_Wait." + vbCrLf)
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_NOWAIT
            End Select
        Else
            ' PXIe-9529
            Console.Write("Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) No_Wait, (4) PXIe_DSTARB, (5) PXI_STAR, (6) TRIG_BUS[0], (7) TRIG_BUS[1], (8) TRIG_BUS[2], (9) TRIG_BUS[3], (10) TRIG_BUS[4], (11) TRIG_BUS[5], (12) TRIG_BUS[6], (13) TRIG_BUS[7]: [3] ")
            tmp_trig_source = get_console_input(Convert.ToUInt16(3))
            Select Case tmp_trig_source
                Case 0
                    config_para.is_gen_sw_trig = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_SOFT
                Case 1
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_EXTD
                Case 2
                    config_para.is_set_ana_trig = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_ANALOG
                Case 3
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_NOWAIT
                Case 4
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXIE_STARTIN
                Case 5
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_STARTIN
                Case 6
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_BUS0
                Case 7
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_BUS1
                Case 8
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_BUS2
                Case 9
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_BUS3
                Case 10
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_BUS4
                Case 11
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_BUS5
                Case 12
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_BUS6
                Case 13
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_PXI_BUS7
                Case Else
                    Console.Write("Warning! Invalid trigger source. Force to set to No_Wait." + vbCrLf)
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_SRC_NOWAIT
            End Select
        End If

        ' Trigger out

        ' Trigger polarity
        If tmp_set_trig_pol Then
            Console.Write("Trigger polarity? (0) Negative, (1) Positive: [1] ")
            Dim tmp_trig_polarity As UShort = get_console_input(Convert.ToUInt16(1))
            Select Case tmp_trig_polarity
                Case 0
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_Negative
                Case 1
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_Positive
                Case Else
                    Console.Write("Warning! Invalid trigger polarity. Force to set to Positive." + vbCrLf)
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9529_TRG_Positive
            End Select
        End If

        ' Re-trigger settings
        ' Disable re-trigger
        config_para.trig_config = config_para.trig_config And (Not Convert.ToUInt32(DSA_DASK.P9529_TRG_EnReTigger))
        config_para.retrig_count = 0

        ' Delay trigger settings
        If tmp_set_delay_trig_cnt Then
            Console.Write("Delay trigger count? (0 ~ 4294967295): [0] ")
            config_para.trig_delay = get_console_input(Convert.ToUInt32(0))
        End If

        ' Analog trigger settings
        If config_para.is_set_ana_trig Then
            ' Analog trigger source
            Console.Write("Analog trigger source? AI_CH_(0 ~ {0}) [0] ", config_para.chnl_cnt - 1)
            Dim tmp_ana_trig_src As UShort = get_console_input(Convert.ToUInt16(0))
            Select Case tmp_ana_trig_src
                Case 0
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH0
                Case 1
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH1
                Case 2
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH2
                Case 3
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH3
                Case 4
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH4
                Case 5
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH5
                Case 6
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH6
                Case 7
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH7
                Case Else
                    Console.Write("Warning! Invalid analog trigger source. Force to set to AI_CH_0." + vbCrLf)
                    config_para.ana_trig_src = DSA_DASK.P9529_TRG_Analog_CH0
            End Select

            ' Analog trigger mode
            Console.Write("Analog trigger mode? ({0}) Above_threshold, ({1}) Below_threshold: [{0}] ", DSA_DASK.P9529_TRG_Analog_Above, DSA_DASK.P9529_TRG_Analog_Below)
            config_para.ana_trig_mode = get_console_input(Convert.ToUInt32(DSA_DASK.P9529_TRG_Analog_Above))
            If config_para.ana_trig_mode > DSA_DASK.P9529_TRG_Analog_Below Then
                Console.Write("Warning! Invalid analog trigger source. Force to set to Above_threshold." + vbCrLf)
                config_para.ana_trig_mode = DSA_DASK.P9529_TRG_Analog_Above
            End If

            ' Analog trigger threshold
            Console.Write("Analog trigger threshold? ({0} ~ {1}): [0] ", tmp_range_lower, tmp_range_upper)
            config_para.ana_trig_threshold = get_console_input(Convert.ToDouble(0))
            If config_para.ana_trig_threshold < tmp_range_lower OrElse config_para.ana_trig_threshold > tmp_range_upper Then
                Console.Write("Warning! Invalid analog trigger threshold. Force to set to 0." + vbCrLf)
                config_para.ana_trig_threshold = 0
            End If
        End If

        ' Sample count
        Console.Write("Sample count (per channel / per buffer)? [65536] ")
        config_para.chnl_sample_count = get_console_input(Convert.ToUInt32(65536))
        config_para.all_data_count = config_para.chnl_sample_count * config_para.chnl_cnt
        If config_para.all_data_count = 0 OrElse config_para.all_data_count Mod 2 <> 0 Then
            Console.Write("Warning! Invalid sample count. Force to set to 65536." + vbCrLf)
            config_para.chnl_sample_count = Convert.ToUInt32(65536)
            config_para.all_data_count = config_para.chnl_sample_count * config_para.chnl_cnt
        End If

        config_para.buf_size = config_para.all_data_count

        ' File format
        Console.Write("Store data to (0) Text file, (1) Binary file: [0] ")
        config_para.file_format = get_console_input(Convert.ToUInt16(0))
        Dim tmp_default_file_name As String
        Select Case config_para.file_format
            Case 0
                tmp_default_file_name = "ai_data.csv"
            Case 1
                tmp_default_file_name = "ai_data"
            Case Else
                config_para.file_format = 0
                tmp_default_file_name = "ai_data.csv"
        End Select

        ' File name
        Console.Write("File name to be stored: [{0}] ", tmp_default_file_name)
        config_para.file_name = Console.ReadLine()
        If config_para.file_name = "" Then
            config_para.file_name = tmp_default_file_name
        End If
    End Sub

    Sub Main()
        Console.Write("This example performs AI acquisition of infinite number of samples." + vbCrLf)
        Console.Write("Press 'Enter' to continue...")
        Console.ReadLine()

        config_para.card_type = DSA_DASK.PCI_9529
        p9529_config()

        ' Register a specified device, it sets and initializes all related variables and necessary resources.
        ' This function must be called before calling any other functions to control the device.
        ' Remember to call DSA_Release_Card() to release all allocated resources.
        Dim result As Short = DSA_DASK.DSA_Register_Card(config_para.card_type, config_para.card_num)
        If result < 0 Then
            Console.Write(vbCrLf + "Falied to perform DSA_Register_Card(), error: " + result.ToString())
            exit_handle()
        End If
        config_para.card_handle = Convert.ToUInt16(result)
        config_para.is_reg_dev = True

        ' Configure AI channels for a registered device
        ' Note that the channel input range and input configuration can be set to different for each channel (This example sets the same setting for all enabled channels).
        Dim chnl_mode As Boolean = False
        For vi = 0 To 7
            If vi < config_para.chnl_cnt Then
                chnl_mode = True 'This channel will be enabled
            Else
                chnl_mode = False 'This channel will be disabled
            End If
            result = DSA_DASK.DSA_AI_9529_ConfigChannel(config_para.card_handle, vi, chnl_mode, config_para.chnl_range, config_para.chnl_config)
            If result <> DSA_DASK.NoError Then
                Console.Write(vbCrLf + "Falied to perform DSA_AI_9529_ConfigChannel(), error: " + result.ToString())
                exit_handle()
            End If
        Next

        Console.Write(vbCrLf + "Configuring AI timebase...")
        Console.Write(vbCrLf + "It may take a few seconds to initial ADC, please wait... ")

        ' Configure sampling rate for a registered device, it will return the actual sample rate.
        ' This function must be called before calling any AI-related functions to perform AI operation.
        ' This function may take a few seconds to initial and adjust ADC settings
        result = DSA_DASK.DSA_ConfigSpeedRate(config_para.card_handle, DSA_DASK.DAQ_AI, config_para.timebase_src, config_para.sample_rate, config_para.actual_rate)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_ConfigSpeedRate(), error: " + result.ToString())
            exit_handle()
        End If

        Console.Write("done" + vbCrLf)

        ' Configure trigger for a registered device
        result = DSA_DASK.DSA_TRG_Config(config_para.card_handle, config_para.trig_target, config_para.trig_config, config_para.retrig_count, config_para.trig_delay)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_TRG_Config(), error: " + result.ToString())
            exit_handle()
        End If

        ' If trigger source is set to analog trigger by using DSA_TRG_Config(),
        ' This function should be called to setup analog trigger configurations.
        ' Due to refer AI input range setting, DSA_AI_9529_ConfigChannel() must be called before calling this function.
        If config_para.is_set_ana_trig Then
            result = DSA_DASK.DSA_TRG_ConfigAnalogTrigger(config_para.card_handle, config_para.ana_trig_src, config_para.ana_trig_mode, config_para.ana_trig_threshold)
            If result <> DSA_DASK.NoError Then
                Console.Write(vbCrLf + "Falied to perform DSA_TRG_ConfigAnalogTrigger(), error: " + result.ToString())
                exit_handle()
            End If
        End If

        ' Enable double-buffer mode
        ' DSA-Dask provides a technique called double-buffer mode to perform continuous AI operation.
        ' Please refer DSA-DASK User Manual section 5.2 for details.
        result = DSA_DASK.DSA_AI_AsyncDblBufferMode(config_para.card_handle, True)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_AsyncDblBufferMode(), error: " + result.ToString())
            exit_handle()
        End If

        ' Setup buffer for data transfer
        ' Allocates memory from the unmanaged memory of the process.
        ' Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
        '       the memory might be moved by the GC and then an unexpected memory exception error is happened.
        '       For 9529, the memory address of performing DMA transfer should be 16 alignment.
        config_para.raw_data_buf = New IntPtr(1) {}
        config_para.raw_data_buf(0) = Marshal.AllocHGlobal(Convert.ToInt32(Marshal.SizeOf(GetType(UInteger)) * config_para.buf_size) + 8)
        config_para.raw_data_buf(1) = Marshal.AllocHGlobal(Convert.ToInt32(Marshal.SizeOf(GetType(UInteger)) * config_para.buf_size) + 8)
        ' Adjust memory address for 16 alignment
        config_para.raw_data_buf_alignment = New IntPtr(1) {}
        Dim pBufferAlign As UInt32
        If (CUInt(config_para.raw_data_buf(0)) And &H8) Then
            pBufferAlign = CUInt(config_para.raw_data_buf(0)) + 8
        Else
            pBufferAlign = CUInt(config_para.raw_data_buf(0))
        End If
        config_para.raw_data_buf_alignment(0) = CType(pBufferAlign, IntPtr)

        If (CUInt(config_para.raw_data_buf(1)) And &H8) Then
            pBufferAlign = CUInt(config_para.raw_data_buf(1)) + 8
        Else
            pBufferAlign = CUInt(config_para.raw_data_buf(1))
        End If
        config_para.raw_data_buf_alignment(1) = CType(pBufferAlign, IntPtr)
        config_para.scale_data_buf = New Double(config_para.buf_size - 1) {}
        config_para.buf_id_array = New UInteger(0) {}
        Dim buf_id(1) As UShort
        For vi = 0 To 1
            result = DSA_DASK.DSA_AI_ContBufferSetup(config_para.card_handle, config_para.raw_data_buf_alignment(vi), config_para.buf_size, buf_id(vi))
            If result <> DSA_DASK.NoError Then
                If vi <> 0 Then
                    ' Reset buffer
                    DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle)
                End If
                For vj = 0 To vi - 1
                    Marshal.FreeHGlobal(config_para.raw_data_buf(vj))
                Next
                Console.Write(vbCrLf + "Falied to perform DSA_AI_ContBufferSetup(), error: " + result.ToString())
                exit_handle()
            End If
        Next
        config_para.buf_id_array(0) = buf_id(0)
        config_para.is_set_buf = True

        Console.Write(vbCrLf + "Press 'Enter' to start AI operation")
        Console.ReadLine()
        If config_para.file_format = 0 Then
            ' Open file
            config_para.file_writer = New StreamWriter(config_para.file_name)
            config_para.is_file_open = True

            ' Read AI data, and the acquired raw data will be stored in the set buffer.
            result = DSA_DASK.DSA_AI_ContReadChannel(config_para.card_handle, config_para.chnl_cnt, 0, config_para.buf_id_array, config_para.all_data_count, 0, DSA_DASK.ASYNCH_OP)
        Else
            ' Read AI data, and the acquired raw data will be stored in the set buffer.
            ' When the buffer is ready, call DSA_AI_AsyncDblBufferToFile() to transfer data to the specified binary file.
            result = DSA_DASK.DSA_AI_ContReadChannelToFile(config_para.card_handle, config_para.chnl_cnt, 0, config_para.file_name, config_para.all_data_count, 0, DSA_DASK.ASYNCH_OP)
        End If
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_ContReadChannel[ToFile](), error: " + result.ToString())
            exit_handle()
        End If
        config_para.is_op_run = True

        Console.Write(vbCrLf + "AI operation is started, waiting trigger from the set trigger source..." + vbCrLf)
        If config_para.is_gen_sw_trig Then
            ' Generate software trigger if the trigger source is set to software trigger
            Console.Write(vbCrLf + "Press 'Enter' to generate software trigger.")
            Console.ReadLine()
            Console.Write("Generating software trigger... ")
            DSA_DASK.DSA_TRG_SoftTriggerGen(config_para.card_handle)
            Console.Write("done" + vbCrLf)
        End If

        Do
            ' In double-buffer mode, you can use this function to check the operation status.
            ' After stopping operation, DSA_AI_AsyncClear() should be called to clear no longer used settings.
            result = DSA_DASK.DSA_AI_AsyncDblBufferHalfReady(config_para.card_handle, config_para.is_buf_ready, config_para.op_stopped)
            If result <> DSA_DASK.NoError Then
                Console.Write(vbCrLf + "Falied to perform DSA_AI_AsyncDblBufferHalfReady(), error: " + result.ToString())
                exit_handle()
            End If

            If config_para.is_buf_ready Then
                config_para.buf_ready_cnt += 1
                Console.Write("Buffer half ready, ready count: {0}" + vbCr, config_para.buf_ready_cnt)

                If config_para.file_format = 0 Then
                    ' Convert AI raw data to scaled data, it depends on the setting of channel range.
                    DSA_DASK.DSA_AI_ContVScale(config_para.card_handle, config_para.chnl_range, config_para.raw_data_buf_alignment(config_para.buf_ready_idx), config_para.scale_data_buf, Convert.ToInt32(config_para.buf_size))

                    config_para.buf_ready_idx += 1
                    config_para.buf_ready_idx = config_para.buf_ready_idx Mod 2

                    ' Write to file
                    Dim vi As Integer
                    For vi = 0 To config_para.buf_size / config_para.chnl_cnt - 1
                        Dim vj As Integer
                        For vj = 0 To config_para.chnl_cnt - 1
                            config_para.file_writer.Write("{0:f8},", config_para.scale_data_buf(vi * config_para.chnl_cnt + vj))
                        Next
                        config_para.file_writer.Write(vbCrLf)
                    Next

                    ' Tell DSA-DASK that the ready buffer is handled
                    DSA_DASK.DSA_AI_AsyncDblBufferHandled(config_para.card_handle)
                Else
                    ' Transfer data to file
                    DSA_DASK.DSA_AI_AsyncDblBufferToFile(config_para.card_handle)

                    ' Tell DSA-DASK that the ready buffer is handled
                    DSA_DASK.DSA_AI_AsyncDblBufferHandled(config_para.card_handle)
                End If
            End If

            Thread.Sleep(1)
        Loop While (Win32Interop._kbhit() = 0 And Not config_para.op_stopped)

        If Not config_para.op_stopped Then
            Console.ReadLine()
        End If

        ' Clear AI setting
        DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, config_para.access_cnt)
        config_para.is_op_run = False

        If config_para.file_format = 0 Then
            Console.Write(vbCrLf + "AI data is stored in file {0}", config_para.file_name)
        Else
            Console.Write(vbCrLf + "AI data is stored in binary file {0}.dat", config_para.file_name)
            Console.Write(vbCrLf + "You can use Data File Convert Utility to convert it.")
        End If

        ' Exit program
        exit_handle()
    End Sub

End Module
