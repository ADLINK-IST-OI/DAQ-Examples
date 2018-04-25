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

    ' Device configuration variables
    Public card_type As UShort
    Public card_subtype As UShort
    Public card_num As UShort
    Public card_handle As UShort

    ' Sample rate configuration variables
    Public sample_rate As Double
    Public actual_rate As Double

    ' Channel configuration variables
    Public chnl_sel As UShort
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
    Public raw_data_buf As IntPtr
    Public scale_data_buf As Double()
    Public buf_id_array As UInteger()
    Public file_format As UShort
    Public file_name As String
    Public file_writer As StreamWriter

    ' AI operation status variables
    Public access_cnt As UInteger
    Public op_stopped As Boolean
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

        If config_para.is_set_buf Then
            ' Reset buffer
            DSA_DASK.DSA_AI_ContBufferReset(config_para.card_handle)

            Marshal.FreeHGlobal(config_para.raw_data_buf)
        End If

        If config_para.is_reg_dev Then
            ' Release device
            DSA_DASK.DSA_Release_Card(config_para.card_handle)
        End If

        Console.Write(vbCrLf + vbCrLf + "Press any key to exit...")
        Console.ReadLine()
        Environment.Exit(0)
    End Sub

    ' Configuration function for 9527
    Sub p9527_config()
        ' Sub-card type
        Console.Write(vbCrLf + "Sub-card type? (0) PCI-9527, (1) PXI-9527: [0] ")
        config_para.card_subtype = get_console_input(Convert.ToUInt16(0))
        If config_para.card_subtype > 1 Then
            Console.Write("Warning! Invalid sub-card type. Force to set to PCI-9527." + vbCrLf)
            config_para.card_subtype = 0
        End If

        ' Card number
        Console.Write("Card number? [0] ")
        config_para.card_num = get_console_input(Convert.ToUInt16(0))

        ' Sample rate
        Console.Write("Sample rate? ({0} ~ {1}): [{1}] ", DSA_DASK.P9527_AI_MinDDSFreq, DSA_DASK.P9527_AI_MaxDDSFreq)
        config_para.sample_rate = get_console_input(Convert.ToDouble(DSA_DASK.P9527_AI_MaxDDSFreq))
        If config_para.sample_rate < DSA_DASK.P9527_AI_MinDDSFreq OrElse config_para.sample_rate > DSA_DASK.P9527_AI_MaxDDSFreq Then
            Console.Write("Warning! Invalid sample rate. Force to set to {0}." + vbCrLf, DSA_DASK.P9527_AI_MaxDDSFreq)
            config_para.sample_rate = Convert.ToDouble(DSA_DASK.P9527_AI_MaxDDSFreq)
        End If

        ' AI channel
        Console.Write("Channel selection? ({0}) AI_CH_0, ({1}) AI_CH_1, ({2}) AI_CH_DUAL: [{2}] ",
                      DSA_DASK.P9527_AI_CH_0, DSA_DASK.P9527_AI_CH_1, DSA_DASK.P9527_AI_CH_DUAL)
        config_para.chnl_sel = get_console_input(Convert.ToUInt16(DSA_DASK.P9527_AI_CH_DUAL))
        Select config_para.chnl_sel
            Case DSA_DASK.P9527_AI_CH_0
            Case DSA_DASK.P9527_AI_CH_1
                config_para.chnl_cnt = 1
            Case DSA_DASK.P9527_AI_CH_DUAL
                config_para.chnl_cnt = 2
            Case Else
                Console.Write("Warning! Invalid channel selection. Force to set to AI_CH_DUAL." + vbCrLf)
                config_para.chnl_sel = Convert.ToUInt16(DSA_DASK.P9527_AI_CH_DUAL)
                config_para.chnl_cnt = 2
        End Select

        ' AI channel range
        Console.Write("Channel range? (0) B_40_V, (1) B_10_V, (2) B_3_16_V, (3) AD_B_1_V, (4) AD_B_0_316_V: [1] ")
        Dim tmp_chnl_range As UShort = get_console_input(Convert.ToUInt16(1))
        Dim tmp_range_lower As Double, tmp_range_upper As Double
        Select tmp_chnl_range
            Case 0
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_40_V)
                tmp_range_lower = -40
                tmp_range_upper = 40
            Case 1
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_10_V)
                tmp_range_lower = -10
                tmp_range_upper = 10
            Case 2
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_3_16_V)
                tmp_range_lower = -3.16
                tmp_range_upper = 3.16
            Case 3
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_1_V)
                tmp_range_lower = -1
                tmp_range_upper = 1
            Case 4
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_0_316_V)
                tmp_range_lower = -0.316
                tmp_range_upper = 0.316
            Case Else
                Console.Write("Warning! Invalid channel range. Force to set to B_10_V." + vbCrLf)
                config_para.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_10_V)
                tmp_range_lower = -10
                tmp_range_upper = 10
        End Select

        ' AI channel input type
        Console.Write("Channel input type? ({0}) Differential, ({1}) PseudoDifferential: [{1}] ",
                      DSA_DASK.P9527_AI_Differential, DSA_DASK.P9527_AI_PseudoDifferential)
        config_para.chnl_config = get_console_input(Convert.ToUInt16(DSA_DASK.P9527_AI_PseudoDifferential))
        If config_para.chnl_config > DSA_DASK.P9527_AI_PseudoDifferential Then
            Console.Write("Warning! Invalid channel input type. Force to set to PseudoDifferential." + vbCrLf)
            config_para.chnl_config = Convert.ToUInt16(DSA_DASK.P9527_AI_PseudoDifferential)

        End If

        ' AI channel input coupling
        Console.Write("Channel input coupling? (0) DC_Coupling, (1) AC_Coupling, (2) IEPE: [0] ")
        Dim tmp_chnl_config As UShort = get_console_input(Convert.ToUInt16(0))
        Select Case tmp_chnl_config
            Case 0
                config_para.chnl_config = config_para.chnl_config Or Convert.ToUInt16(DSA_DASK.P9527_AI_Coupling_DC)
            Case 1
                config_para.chnl_config = config_para.chnl_config Or Convert.ToUInt16(DSA_DASK.P9527_AI_Coupling_AC)
            Case 2
                config_para.chnl_config = config_para.chnl_config Or Convert.ToUInt16(DSA_DASK.P9527_AI_EnableIEPE)
            Case Else
                Console.Write("Warning! Invalid channel input coupling. Force to set to DC_Coupling." + vbCrLf)
                config_para.chnl_config = config_para.chnl_config Or Convert.ToUInt16(DSA_DASK.P9527_AI_Coupling_DC)
        End Select

        ' Trigger target
        config_para.trig_target = DSA_DASK.P9527_TRG_AI

        ' Trigger mode
        Console.Write("Trigger mode? ({0}) Post_trigger, ({1}) Delay_trigger: [{0}] ",
                      DSA_DASK.P9527_TRG_MODE_POST, DSA_DASK.P9527_TRG_MODE_DELAY)
        Dim tmp_set_delay_trig_cnt As Boolean = False
        config_para.trig_config = get_console_input(Convert.ToUInt16(DSA_DASK.P9527_TRG_MODE_POST))
        If config_para.trig_config > DSA_DASK.P9527_TRG_MODE_DELAY Then
            Console.Write("Warning! Invalid trigger mode. Force to set to Post_trigger." + vbCrLf)
            config_para.trig_config = Convert.ToUInt16(DSA_DASK.P9527_TRG_MODE_POST)
        ElseIf config_para.trig_config = DSA_DASK.P9527_TRG_MODE_DELAY Then
            tmp_set_delay_trig_cnt = True
        End If

        ' Trigger source
        Dim tmp_trig_source As UShort
        Dim tmp_set_trig_pol As Boolean = False
        If config_para.card_subtype = 0 Then
            ' PCI-9527
            Console.Write("Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) SSI_9, (4) No_Wait: [4] ")
            tmp_trig_source = get_console_input(Convert.ToUInt16(4))
            Select Case tmp_trig_source
                Case 0
                    config_para.is_gen_sw_trig = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_SOFT
                Case 1
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_EXTD
                Case 2
                    config_para.is_set_ana_trig = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_ANALOG
                Case 3
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_SSI9
                Case 4
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_NOWAIT
                Case Else
                    Console.Write("Warning! Invalid trigger source. Force to set to No_Wait." + vbCrLf)
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_NOWAIT
            End Select
        Else
            ' PXI-9527
            Console.Write("Trigger source? (0) Software, (1) External_Digital, (2) Analog, (3) No_Wait, (4) PXI_StartIn, (5) PXI_Bus_0, (6) PXI_Bus_1, (7) PXI_Bus_2, (8) PXI_Bus_3, (9) PXI_Bus_4, (10) PXI_Bus_5, (11) PXI_Bus_6, (12) PXI_Bus_7: [3] ")
            tmp_trig_source = get_console_input(Convert.ToUInt16(3))
            Select Case tmp_trig_source
                Case 0
                    config_para.is_gen_sw_trig = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_SOFT
                Case 1
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_EXTD
                Case 2
                    config_para.is_set_ana_trig = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_ANALOG
                Case 3
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_NOWAIT
                Case 4
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_STARTIN
                Case 5
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_BUS0
                Case 6
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_BUS1
                Case 7
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_BUS2
                Case 8
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_BUS3
                Case 9
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_BUS4
                Case 10
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_BUS5
                Case 11
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_BUS6
                Case 12
                    tmp_set_trig_pol = True
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_PXI_BUS7
                Case Else
                    Console.Write("Warning! Invalid trigger source. Force to set to No_Wait." + vbCrLf)
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_SRC_NOWAIT
            End Select
        End If

        ' Trigger polarity
        If tmp_set_trig_pol Then
            Console.Write("Trigger polarity? (0) Negative, (1) Positive: [1] ")
            Dim tmp_trig_polarity As UShort = get_console_input(Convert.ToUInt16(1))
            Select Case tmp_trig_polarity
                Case 0
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_Negative
                Case 1
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_Positive
                Case Else
                    Console.Write("Warning! Invalid trigger polarity. Force to set to Positive." + vbCrLf)
                    config_para.trig_config = config_para.trig_config Or DSA_DASK.P9527_TRG_Positive
            End Select
        End If

        ' Re-trigger settings
        ' Disable re-trigger
        config_para.trig_config = config_para.trig_config And (Not Convert.ToUInt32(DSA_DASK.P9527_TRG_EnReTigger))
        config_para.retrig_count = 0

        ' Delay trigger settings
        If tmp_set_delay_trig_cnt Then
            Console.Write("Delay trigger count? (0 ~ 4294967295): [0] ")
            config_para.trig_delay = get_console_input(Convert.ToUInt32(0))
        End If

        ' Analog trigger settings
        If config_para.is_set_ana_trig Then
            ' Analog trigger source
            If config_para.chnl_sel = DSA_DASK.P9527_AI_CH_0 Then
                config_para.ana_trig_src = DSA_DASK.P9527_TRG_Analog_CH0
            ElseIf config_para.chnl_sel = DSA_DASK.P9527_AI_CH_1 Then
                config_para.ana_trig_src = DSA_DASK.P9527_TRG_Analog_CH1
            Else
                Console.Write("Analog trigger source? ({0}) AI_CH_0, ({1}) AI_CH_1: [{0}] ",
                              DSA_DASK.P9527_TRG_Analog_CH0, DSA_DASK.P9527_TRG_Analog_CH1)
                config_para.ana_trig_src = get_console_input(Convert.ToUInt32(DSA_DASK.P9527_TRG_Analog_CH0))
                If config_para.ana_trig_src > DSA_DASK.P9527_TRG_Analog_CH1 Then
                    Console.Write("Warning! Invalid analog trigger source. Force to set to AI_CH_0." + vbCrLf)
                    config_para.ana_trig_src = DSA_DASK.P9527_TRG_Analog_CH0
                End If
            End If

            ' Analog trigger mode
            Console.Write("Analog trigger mode? ({0}) Above_threshold, ({1}) Below_threshold: [{0}] ",
                          DSA_DASK.P9527_TRG_Analog_Above_threshold, DSA_DASK.P9527_TRG_Analog_Below_threshold)
            config_para.ana_trig_mode = get_console_input(Convert.ToUInt32(DSA_DASK.P9527_TRG_Analog_Above_threshold))
            If config_para.ana_trig_mode > DSA_DASK.P9527_TRG_Analog_Below_threshold Then
                Console.Write("Warning! Invalid analog trigger source. Force to set to Above_threshold." + vbCrLf)
                config_para.ana_trig_mode = DSA_DASK.P9527_TRG_Analog_Above_threshold
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
        Console.Write("Sample count (per channel / per trigger)? [65536] ")
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
        Select config_para.file_format
            Case 0
                tmp_default_file_name = "ai_data.csv"
            Case 1
                tmp_default_file_name = "ai_data"
            Case Else
                config_para.file_format = 0
                tmp_default_file_name = "ai_data.csv"
        End Select
        If config_para.file_format > 1 Then
            config_para.file_format = 0
        End If

        ' File name
        Console.Write("File name to be stored: [{0}] ", tmp_default_file_name)
        config_para.file_name = Console.ReadLine()
        If config_para.file_name = "" Then
            config_para.file_name = tmp_default_file_name
        End If
    End Sub

    Sub Main()
        Console.Write("This example performs AI acquisition of a fixed number of samples." + vbCrLf)
        Console.Write("Press 'Enter' to continue...")
        Console.ReadLine()

        config_para.card_type = DSA_DASK.PCI_9527
        p9527_config()

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

        ' Configure sampling rate for a registered device, it will return the actual sample rate.
        ' This function must be called before calling any AI-related functions to perform AI operation.
        ' There is a timing constraint when AI and AO function are enabled simultaneously.
        ' Please refer P9527 Hardware Manual section 3.5.3 for details.
        result = DSA_DASK.DSA_AI_9527_ConfigSampleRate(config_para.card_handle, config_para.sample_rate, config_para.actual_rate)
        If result <> DSA_DASK.NoError Then
            If result = -81 Then
                Console.Write(vbCrLf + "Warning! Sample rate has been locked by AO job!")
            Else
                Console.Write(vbCrLf + "Falied to perform DSA_AI_9527_ConfigSampleRate(), error: " + result.ToString())
                exit_handle()
            End If
        End If

        ' Configure AI channel/function for a registered device
        ' This function may take a few seconds to initial and adjust ADC settings
        Console.Write(vbCrLf + "Configuring AI...")
        Console.Write(vbCrLf + "It may take a few seconds to initial ADC, please wait... ")
        result = DSA_DASK.DSA_AI_9527_ConfigChannel(config_para.card_handle, config_para.chnl_sel, config_para.chnl_range,
                                                    config_para.chnl_config, False)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_9527_ConfigChannel(), error: " + result.ToString())
            exit_handle()
        End If
        Console.Write("done" + vbCrLf)

        ' Configure trigger for a registered device
        result = DSA_DASK.DSA_TRG_Config(config_para.card_handle, config_para.trig_target, config_para.trig_config,
                                         config_para.retrig_count, config_para.trig_delay)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_TRG_Config(), error: " + result.ToString())
            exit_handle()
        End If

        ' If trigger source is set to analog trigger by using DSA_TRG_Config(),
        ' This function should be called to setup analog trigger configurations.
        ' Due to refer AI input range setting, DSA_AI_9527_ConfigChannel() must be called before calling this function.
        If config_para.is_set_ana_trig Then
            result = DSA_DASK.DSA_TRG_ConfigAnalogTrigger(config_para.card_handle, config_para.ana_trig_src, config_para.ana_trig_mode,
                                                          config_para.ana_trig_threshold)
            If result <> DSA_DASK.NoError Then
                Console.Write(vbCrLf + "Falied to perform DSA_TRG_ConfigAnalogTrigger(), error: " + result.ToString())
                exit_handle()
            End If
        End If

        ' Disable double-buffer mode
        ' DSA-Dask provides a technique called double-buffer mode to perform continuous AI operation.
        ' Please refer DSA-DASK User Manual section 5.2 for details.
        ' Due to acquire finite number of AI samples, we disable it.
        result = DSA_DASK.DSA_AI_AsyncDblBufferMode(config_para.card_handle, False)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_AsyncDblBufferMode(), error: " + result.ToString())
            exit_handle()
        End If

        ' Setup buffer for data transfer
        ' Allocates memory from the unmanaged memory of the process.
        ' Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
        '       the memory might be moved by the GC and then an unexpected memory exception error is happened.
        config_para.raw_data_buf = Marshal.AllocHGlobal(Convert.ToInt32(Marshal.SizeOf(GetType(UInteger)) * config_para.buf_size))
        config_para.scale_data_buf = New Double(config_para.buf_size - 1) {}
        config_para.buf_id_array = New UInteger(0) {}
        Dim buf_id As UShort
        result = DSA_DASK.DSA_AI_ContBufferSetup(config_para.card_handle, config_para.raw_data_buf,
                                                 config_para.buf_size, buf_id)
        If result <> DSA_DASK.NoError Then
            Marshal.FreeHGlobal(config_para.raw_data_buf)
            Console.Write(vbCrLf + "Falied to perform DSA_AI_ContBufferSetup(), error: " + result.ToString())
            exit_handle()
        End If
        config_para.buf_id_array(0) = buf_id
        config_para.is_set_buf = True

        Console.Write(vbCrLf + "Press 'Enter' to start AI operation with actual sample rate {0:f4} Hz", config_para.actual_rate)
        Console.ReadLine()
        If config_para.file_format = 0 Then
            ' Read AI data, and the acquired raw data will be stored in the set buffer.
            result = DSA_DASK.DSA_AI_ContReadChannel(config_para.card_handle, config_para.chnl_sel, 0,
                                                     config_para.buf_id_array, config_para.all_data_count, 0, DSA_DASK.ASYNCH_OP)
        Else
            ' Read AI data, and the acquired raw data will be stored in the set buffer.
            ' When the buffer is ready, call DSA_AI_AsyncDblBufferToFile() to transfer data to the specified binary file.
            result = DSA_DASK.DSA_AI_ContReadChannelToFile(config_para.card_handle, config_para.chnl_sel, 0,
                                                           config_para.file_name, config_para.all_data_count, 0, DSA_DASK.ASYNCH_OP)
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
            ' In asynchronous mode, you can use this function to check the operation status.
            ' When operation is complete, DSA_AI_AsyncClear() should be called to clear no longer used settings.
            result = DSA_DASK.DSA_AI_AsyncCheck(config_para.card_handle, config_para.op_stopped, config_para.access_cnt)
            If result <> DSA_DASK.NoError Then
                Console.Write(vbCrLf + "Falied to perform DSA_AI_AsyncCheck(), error: " + result.ToString())
                exit_handle()
            End If

            Thread.Sleep(1)
        Loop While (Win32Interop._kbhit() = 0 And Not config_para.op_stopped)

        If Not config_para.op_stopped Then
            Console.ReadLine()
            Console.Write("AI acquisition is manually stopped!")
        Else
            Console.Write(vbCrLf + "AI acquisition is complete!")
        End If

        ' Clear AI setting
        DSA_DASK.DSA_AI_AsyncClear(config_para.card_handle, config_para.access_cnt)
        config_para.is_op_run = False

        If config_para.file_format = 0 Then
            ' Convert AI raw data to scaled data, it depends on the setting of channel range.
            Console.Write(vbCrLf + "Converting AI raw data... ")
            DSA_DASK.DSA_AI_ContVScale(config_para.card_handle, config_para.chnl_range, config_para.raw_data_buf,
                                       config_para.scale_data_buf, Convert.ToInt32(config_para.access_cnt))
            Console.Write("done")

            ' Write to file
            Console.Write(vbCrLf + "Writing AI data to text file {0}... ", config_para.file_name)
            config_para.file_writer = New StreamWriter(config_para.file_name)
            Dim vi As Integer
            For vi = 0 To config_para.access_cnt / config_para.chnl_cnt - 1
                Dim vj As Integer
                For vj = 0 To config_para.chnl_cnt - 1
                    config_para.file_writer.Write("{0:f8},", config_para.scale_data_buf(vi * config_para.chnl_cnt + vj))
                Next
                config_para.file_writer.Write(vbCrLf)
            Next
            config_para.file_writer.Close()
            Console.Write("done")
        Else
            ' Transfer data to file
            Console.Write(vbCrLf + "Transfer AI data to binary file {0}.dat... ", config_para.file_name)
            DSA_DASK.DSA_AI_AsyncDblBufferToFile(config_para.card_handle)
            Console.Write("done")
            Console.Write(vbCrLf + "You can use Data File Convert Utility to convert it.")
        End If

        ' Exit program
        exit_handle()
    End Sub

End Module
