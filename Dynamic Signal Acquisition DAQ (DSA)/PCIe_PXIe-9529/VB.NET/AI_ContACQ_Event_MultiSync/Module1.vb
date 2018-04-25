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
    Public is_done_evt_set As Boolean
    Public is_buf_ready_evt_set As Boolean
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
    Public trig_out As UShort
    Public is_trig_out_connected As Boolean

    ' Analog trigger configuration variables
    Public ana_trig_src As UInteger
    Public ana_trig_mode As UInteger
    Public ana_trig_threshold As Double

    ' PDN sync variables
    Public pdn_sync_type As UShort
    Public pdn_sync_path As UInteger
    Public pdn_sync_status As UShort
    Public is_pdn_sync As Boolean

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
    Public buf_ready_idx As UInteger
    Public buf_ready_cnt As UInteger
End Structure

Module Module1
    Dim config_para_master As program_config
    Dim config_para_slave As program_config

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
        ' Async Clear
        If config_para_master.is_op_run Then
            DSA_DASK.DSA_AI_AsyncClear(config_para_master.card_handle, config_para_master.access_cnt)
        End If
        If config_para_slave.is_op_run Then
            DSA_DASK.DSA_AI_AsyncClear(config_para_slave.card_handle, config_para_slave.access_cnt)
        End If

        ' Close file
        If config_para_master.is_file_open Then
            config_para_master.file_writer.Close()
        End If
        If config_para_slave.is_file_open Then
            config_para_slave.file_writer.Close()
        End If

        ' Reset done event
        If config_para_master.is_done_evt_set Then
            DSA_DASK.DSA_AI_EventCallBack(config_para_master.card_handle, 0, DSA_DASK.AIEnd, ai_done_cbdel_master)
        End If
        If config_para_slave.is_done_evt_set Then
            DSA_DASK.DSA_AI_EventCallBack(config_para_slave.card_handle, 0, DSA_DASK.AIEnd, ai_done_cbdel_slave)
        End If

        ' Reset done event
        If config_para_master.is_done_evt_set Then
            DSA_DASK.DSA_AI_EventCallBack(config_para_master.card_handle, 0, DSA_DASK.DBEvent, ai_buf_ready_cbdel_master)
        End If
        If config_para_slave.is_done_evt_set Then
            DSA_DASK.DSA_AI_EventCallBack(config_para_slave.card_handle, 0, DSA_DASK.DBEvent, ai_buf_ready_cbdel_slave)
        End If

        ' Reset buffer
        If config_para_master.is_set_buf Then
            DSA_DASK.DSA_AI_ContBufferReset(config_para_master.card_handle)
            Marshal.FreeHGlobal(config_para_master.raw_data_buf(0))
            Marshal.FreeHGlobal(config_para_master.raw_data_buf(1))
        End If
        If config_para_slave.is_set_buf Then
            DSA_DASK.DSA_AI_ContBufferReset(config_para_slave.card_handle)
            Marshal.FreeHGlobal(config_para_slave.raw_data_buf(0))
            Marshal.FreeHGlobal(config_para_slave.raw_data_buf(1))
        End If

        ' Disable synchronization
        If config_para_master.is_pdn_sync Then
            DSA_DASK.DSA_SYN_ConfigMultiCard(config_para_master.card_handle, DSA_DASK.P9529_SYN_Disable, config_para_master.pdn_sync_path)
        End If
        If config_para_slave.is_pdn_sync Then
            DSA_DASK.DSA_SYN_ConfigMultiCard(config_para_slave.card_handle, DSA_DASK.P9529_SYN_Disable, config_para_slave.pdn_sync_path)
        End If

        ' Disconnect trigger out (only Master)
        If config_para_master.is_trig_out_connected Then
            DSA_DASK.DSA_TRG_SourceDisConn(config_para_master.card_handle, config_para_master.trig_out)
        End If

        ' Release device
        If config_para_master.is_reg_dev Then
            DSA_DASK.DSA_Release_Card(config_para_master.card_handle)
        End If
        If config_para_slave.is_reg_dev Then
            DSA_DASK.DSA_Release_Card(config_para_slave.card_handle)
        End If

        Console.Write(vbCrLf + vbCrLf + "Press any key to exit...")
        Console.ReadLine()
        Environment.Exit(0)
    End Sub

    Sub init_master_struct()
        ' Program status
        config_para_master.is_reg_dev = False
        config_para_master.is_set_buf = False
        config_para_master.is_op_run = False
        config_para_master.is_done_evt_set = False
        config_para_master.is_buf_ready_evt_set = False
        config_para_master.is_file_open = False

        ' Device configuration variables
        config_para_master.card_type = DSA_DASK.PCI_9529
        config_para_master.card_subtype = 0
        config_para_master.card_num = 0
        config_para_master.card_handle = 0

        ' Timebase configuration variables
        config_para_master.timebase_src = DSA_DASK.P9529_Internal Or DSA_DASK.P9529_CLKOut_Enable Or DSA_DASK.P9529_ExtCLK_SSI ' Export clock to SSI_BUS[0]
        config_para_master.sample_rate = 48000
        config_para_master.actual_rate = 48000

        ' Channel configuration variables
        config_para_master.chnl_cnt = 8
        config_para_master.chnl_range = DSA_DASK.AD_B_10_V
        config_para_master.chnl_config = DSA_DASK.P9529_AI_PseDiff Or DSA_DASK.P9529_AI_Coupling_DC

        ' Trigger configuration variables
        config_para_master.trig_target = DSA_DASK.P9529_TRG_AI
        config_para_master.trig_config = DSA_DASK.P9529_TRG_MODE_POST Or DSA_DASK.P9529_TRG_SRC_SOFT
        config_para_master.retrig_count = 0
        config_para_master.trig_delay = 0
        config_para_master.is_gen_sw_trig = True
        config_para_master.is_set_ana_trig = False
        config_para_master.trig_out = DSA_DASK.P9529_TRG_OUT_SSI ' Export trigger to SSI_BUS[5]
        config_para_master.is_trig_out_connected = False

        ' Analog trigger configuration variables
        config_para_master.ana_trig_src = 0
        config_para_master.ana_trig_mode = 0
        config_para_master.ana_trig_threshold = 0

        ' PDN sync variables
        config_para_master.pdn_sync_type = DSA_DASK.P9529_SYN_MasterCard
        config_para_master.pdn_sync_path = DSA_DASK.P9529_SYN_SSI
        config_para_master.pdn_sync_status = 0
        config_para_master.is_pdn_sync = False

        ' Data buffer & file variables
        config_para_master.chnl_sample_count = 65536
        config_para_master.all_data_count = config_para_master.chnl_cnt * config_para_master.chnl_sample_count
        config_para_master.buf_size = config_para_master.all_data_count
        'config_para_master.raw_data_buf As IntPtr()
        'config_para_master.raw_data_buf_alignment As IntPtr()
        'config_para_master.scale_data_buf As Double()
        'config_para_master.buf_id_array As UInteger()
        config_para_master.file_format = 0
        config_para_master.file_name = "ai_data_master.csv"
        'config_para_master.file_writer As StreamWriter

        ' AI operation status variables
        config_para_master.access_cnt = 0
        config_para_master.buf_ready_idx = 0
        config_para_master.buf_ready_cnt = 0
    End Sub

    Sub init_slave_struct()
        ' Program status
        config_para_slave.is_reg_dev = False
        config_para_slave.is_set_buf = False
        config_para_slave.is_op_run = False
        config_para_slave.is_done_evt_set = False
        config_para_slave.is_buf_ready_evt_set = False
        config_para_slave.is_file_open = False

        ' Device configuration variables
        config_para_slave.card_type = DSA_DASK.PCI_9529
        config_para_slave.card_subtype = 0
        config_para_slave.card_num = 1
        config_para_slave.card_handle = 0

        ' Timebase configuration variables
        config_para_slave.timebase_src = DSA_DASK.P9529_TimeBase_SSI Or DSA_DASK.P9529_ExtCLK_SSI ' External timebase and from SSI_BUS[0]
        config_para_slave.sample_rate = 48000
        config_para_slave.actual_rate = 48000

        ' Channel configuration variables
        config_para_slave.chnl_cnt = 8
        config_para_slave.chnl_range = DSA_DASK.AD_B_10_V
        config_para_slave.chnl_config = DSA_DASK.P9529_AI_PseDiff Or DSA_DASK.P9529_AI_Coupling_DC

        ' Trigger configuration variables
        config_para_slave.trig_target = DSA_DASK.P9529_TRG_AI
        config_para_slave.trig_config = DSA_DASK.P9529_TRG_MODE_POST Or DSA_DASK.P9529_TRG_SRC_SSI ' Trigger source SSI_BUS[5]
        config_para_slave.retrig_count = 0
        config_para_slave.trig_delay = 0
        config_para_slave.is_gen_sw_trig = False
        config_para_slave.is_set_ana_trig = False
        config_para_slave.trig_out = 0
        config_para_slave.is_trig_out_connected = False

        ' Analog trigger configuration variables
        config_para_slave.ana_trig_src = 0
        config_para_slave.ana_trig_mode = 0
        config_para_slave.ana_trig_threshold = 0

        ' PDN sync variables
        config_para_slave.pdn_sync_type = DSA_DASK.P9529_SYN_SlaveCard
        config_para_slave.pdn_sync_path = DSA_DASK.P9529_SYN_SSI
        config_para_slave.pdn_sync_status = 0
        config_para_slave.is_pdn_sync = False

        ' Data buffer & file variables
        config_para_slave.chnl_sample_count = 65536
        config_para_slave.all_data_count = config_para_slave.chnl_cnt * config_para_slave.chnl_sample_count
        config_para_slave.buf_size = config_para_slave.all_data_count
        'config_para_slave.raw_data_buf As IntPtr()
        'config_para_slave.raw_data_buf_alignment As IntPtr()
        'config_para_slave.scale_data_buf As Double()
        'config_para_slave.buf_id_array As UInteger()
        config_para_slave.file_format = 0
        config_para_slave.file_name = "ai_data_slave.csv"
        'config_para_slave.file_writer As StreamWriter

        ' AI operation status variables
        config_para_slave.access_cnt = 0
        config_para_slave.buf_ready_idx = 0
        config_para_slave.buf_ready_cnt = 0
    End Sub

    Sub console_config_master()
        ' Card number
        Console.Write(vbCrLf + "Master card number? [0] ")
        config_para_master.card_num = get_console_input(Convert.ToUInt16(0))

        ' AI channel
        Console.Write("Master number of channels? (1, 2, 4, 8): [8] ")
        config_para_master.chnl_cnt = get_console_input(Convert.ToUInt16(8))
        If config_para_master.chnl_cnt <> 1 AndAlso config_para_master.chnl_cnt <> 2 AndAlso config_para_master.chnl_cnt <> 4 AndAlso config_para_master.chnl_cnt <> 8 Then
            Console.Write("Warning! Invalid number of channels. Force to set to 8." + vbCrLf)
            config_para_master.chnl_cnt = 8
        End If

        ' AI channel range
        Console.Write("Master channel range? (0) B_10_V, (1) AD_B_1_V: [0] ")
        Dim tmp_chnl_range As UShort = get_console_input(Convert.ToUInt16(0))
        Select Case tmp_chnl_range
            Case 0
                config_para_master.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_10_V)
            Case 1
                config_para_master.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_1_V)
            Case Else
                Console.Write("Warning! Invalid channel range. Force to set to B_10_V." + vbCrLf)
                config_para_master.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_10_V)
        End Select

        ' Trigger source
        Dim tmp_trig_source As UShort
        Console.Write("Master trigger source? (0) Software, (1) External_Digital: [0] ")
        tmp_trig_source = get_console_input(Convert.ToUInt16(0))
        Select Case tmp_trig_source
            Case 0
                config_para_master.is_gen_sw_trig = True
                config_para_master.trig_config = DSA_DASK.P9529_TRG_MODE_POST Or DSA_DASK.P9529_TRG_SRC_SOFT
            Case 1
                config_para_master.is_gen_sw_trig = False
                config_para_master.trig_config = DSA_DASK.P9529_TRG_MODE_POST Or DSA_DASK.P9529_TRG_SRC_EXTD
            Case Else
                Console.Write("Warning! Invalid trigger source. Force to set to Software." + vbCrLf)
                config_para_master.is_gen_sw_trig = True
                config_para_master.trig_config = DSA_DASK.P9529_TRG_MODE_POST Or DSA_DASK.P9529_TRG_SRC_SOFT
        End Select

        ' Sample rate
        Dim tmp_sample_rate_min As UInteger = 8000
        Dim tmp_sample_rate_max As UInteger = 192000
        Console.Write("Master sample rate? ({0} ~ {1}): [{2}] ", tmp_sample_rate_min, tmp_sample_rate_max, 48000)
        config_para_master.sample_rate = get_console_input(48000)
        If config_para_master.sample_rate < tmp_sample_rate_min OrElse config_para_master.sample_rate > tmp_sample_rate_max Then
            Console.Write("Warning! Invalid sample rate. Force to set to {0}." + vbCrLf, 48000)
            config_para_master.sample_rate = Convert.ToDouble(48000)
        End If

        ' Sample count
        Console.Write("Master sample count (per channel / per buffer)? [65536] ")
        config_para_master.chnl_sample_count = get_console_input(Convert.ToUInt32(65536))
        config_para_master.all_data_count = config_para_master.chnl_sample_count * config_para_master.chnl_cnt
        If config_para_master.all_data_count = 0 OrElse config_para_master.all_data_count Mod 2 <> 0 Then
            Console.Write("Warning! Invalid sample count. Force to set to 65536." + vbCrLf)
            config_para_master.chnl_sample_count = Convert.ToUInt32(65536)
            config_para_master.all_data_count = config_para_master.chnl_sample_count * config_para_master.chnl_cnt
        End If

        config_para_master.buf_size = config_para_master.all_data_count
    End Sub

    Sub console_config_slave()
        ' Card number
        Console.Write(vbCrLf + "Slave card number? [1] ")
        config_para_slave.card_num = get_console_input(Convert.ToUInt16(1))

        ' AI channel
        Console.Write("Slave number of channels? (1, 2, 4, 8): [8] ")
        config_para_slave.chnl_cnt = get_console_input(Convert.ToUInt16(8))
        If config_para_slave.chnl_cnt <> 1 AndAlso config_para_slave.chnl_cnt <> 2 AndAlso config_para_slave.chnl_cnt <> 4 AndAlso config_para_slave.chnl_cnt <> 8 Then
            Console.Write("Warning! Invalid number of channels. Force to set to 8." + vbCrLf)
            config_para_slave.chnl_cnt = 8
        End If

        ' AI channel range
        Console.Write("Slave channel range? (0) B_10_V, (1) AD_B_1_V: [0] ")
        Dim tmp_chnl_range As UShort = get_console_input(Convert.ToUInt16(0))
        Select Case tmp_chnl_range
            Case 0
                config_para_slave.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_10_V)
            Case 1
                config_para_slave.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_1_V)
            Case Else
                Console.Write("Warning! Invalid channel range. Force to set to B_10_V." + vbCrLf)
                config_para_slave.chnl_range = Convert.ToUInt16(DSA_DASK.AD_B_10_V)
        End Select

        ' Sample rate
        config_para_slave.sample_rate = config_para_master.sample_rate

        ' Sample count
        Console.Write("Slave sample count (per channel / per buffer)? [65536] ")
        config_para_slave.chnl_sample_count = get_console_input(Convert.ToUInt32(65536))
        config_para_slave.all_data_count = config_para_slave.chnl_sample_count * config_para_slave.chnl_cnt
        If config_para_slave.all_data_count = 0 OrElse config_para_slave.all_data_count Mod 2 <> 0 Then
            Console.Write("Warning! Invalid sample count. Force to set to 65536." + vbCrLf)
            config_para_slave.chnl_sample_count = Convert.ToUInt32(65536)
            config_para_slave.all_data_count = config_para_slave.chnl_sample_count * config_para_slave.chnl_cnt
        End If

        config_para_slave.buf_size = config_para_slave.all_data_count
    End Sub

    Function register_master_slave() As Short
        Console.Write(vbCrLf + "Registering devices... ")

        ' Register a specified device, it sets and initializes all related variables and necessary resources.
        ' This function must be called before calling any other functions to control the device.
        ' Remember to call DSA_Release_Card() to release all allocated resources.

        ' Master
        Dim result As Short = DSA_DASK.DSA_Register_Card(config_para_master.card_type, config_para_master.card_num)
        If result < 0 Then
            Console.Write(vbCrLf + "Falied to perform DSA_Register_Card() for Master, error: " + result.ToString())
            Return -1
        End If
        config_para_master.card_handle = Convert.ToUInt16(result)
        config_para_master.is_reg_dev = True

        ' Slave
        result = DSA_DASK.DSA_Register_Card(config_para_slave.card_type, config_para_slave.card_num)
        If result < 0 Then
            Console.Write(vbCrLf + "Falied to perform DSA_Register_Card() for Slave, error: " + result.ToString())
            Return -11
        End If
        config_para_slave.card_handle = Convert.ToUInt16(result)
        config_para_slave.is_reg_dev = True

        Console.Write("done" + vbCrLf)
        Return 0
    End Function

    Function set_sync_master_slave() As Short
        Console.Write(vbCrLf + "Configuring AI...")
        Console.Write(vbCrLf + "It may take a few seconds to initial ADC, please wait... ")

        ' Configure Master timebase
        ' This function may take a few seconds to initial and adjust ADC settings
        Dim result As Short = DSA_DASK.DSA_ConfigSpeedRate(config_para_master.card_handle, DSA_DASK.DAQ_AI, config_para_master.timebase_src, config_para_master.sample_rate, config_para_master.actual_rate)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_ConfigSpeedRate() for Master, error: " + result.ToString())
            Return -1
        End If

        ' Configure Master trigger out
        result = DSA_DASK.DSA_TRG_SourceConn(config_para_master.card_handle, config_para_master.trig_out)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_TRG_SourceConn() for Master, error: " + result.ToString())
            Return -2
        End If
        config_para_master.is_trig_out_connected = True

        ' Configure Master trigger
        result = DSA_DASK.DSA_TRG_Config(config_para_master.card_handle, config_para_master.trig_target, config_para_master.trig_config, config_para_master.retrig_count, config_para_master.trig_delay)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_TRG_Config() for Master, error: " + result.ToString())
            Return -3
        End If

        ' Configure Master PDN sync
        result = DSA_DASK.DSA_SYN_ConfigMultiCard(config_para_master.card_handle, config_para_master.pdn_sync_type, config_para_master.pdn_sync_path)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_TRG_Config() for Master, error: " + result.ToString())
            Return -4
        End If
        config_para_master.is_pdn_sync = True

        ' Configure Slave timebase
        ' This function may take a few seconds to initial and adjust ADC settings
        result = DSA_DASK.DSA_ConfigSpeedRate(config_para_slave.card_handle, DSA_DASK.DAQ_AI, config_para_slave.timebase_src, config_para_slave.sample_rate, config_para_slave.actual_rate)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_ConfigSpeedRate() for Slave, error: " + result.ToString())
            Return -11
        End If

        ' Configure Slave trigger
        result = DSA_DASK.DSA_TRG_Config(config_para_slave.card_handle, config_para_slave.trig_target, config_para_slave.trig_config, config_para_slave.retrig_count, config_para_slave.trig_delay)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_TRG_Config() for Slave, error: " + result.ToString())
            Return -13
        End If

        ' Configure Slave PDN sync
        result = DSA_DASK.DSA_SYN_ConfigMultiCard(config_para_slave.card_handle, config_para_slave.pdn_sync_type, config_para_slave.pdn_sync_path)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_TRG_Config() for Slave, error: " + result.ToString())
            Return -14
        End If
        config_para_slave.is_pdn_sync = True

        Console.Write("done" + vbCrLf)
        Return 0
    End Function

    Function start_sync_master_slave() As Short
        ' Check Master sync status
        Do
            Thread.Sleep(1)
            DSA_DASK.DSA_SYN_CheckMultiCardStatus(config_para_master.card_handle, config_para_master.pdn_sync_status)
        Loop Until ((config_para_master.pdn_sync_status And DSA_DASK.P9529_SYN_IsMasterCard) AndAlso (config_para_master.pdn_sync_status And DSA_DASK.P9529_SYN_IsMultiCard))

        ' Check Slave sync status
        Do
            Thread.Sleep(1)
            DSA_DASK.DSA_SYN_CheckMultiCardStatus(config_para_slave.card_handle, config_para_slave.pdn_sync_status)
        Loop Until (config_para_slave.pdn_sync_status And DSA_DASK.P9529_SYN_IsMultiCard)

        ' Start synchronization (only Master)
        Dim result As Short = DSA_DASK.DSA_SYN_SyncStart(config_para_master.card_handle)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_SYN_SyncStart() for Slave, error: " + result.ToString())
            Return -1
        End If

        ' Wait Master status to Sync Done
        Dim wait_loop As Integer = 0
        Do
            wait_loop += 1
            If wait_loop > 1000 Then
                Console.Write(vbCrLf + "Falied to wait Master Sync Done")
                Return -2
            End If
            Thread.Sleep(1)
            DSA_DASK.DSA_SYN_CheckMultiCardStatus(config_para_master.card_handle, config_para_master.pdn_sync_status)
        Loop Until (config_para_master.pdn_sync_status And DSA_DASK.P9529_SYN_IsPDNSyncReady)

        ' Wait Slave status to Sync Done
        wait_loop = 0
        Do
            wait_loop += 1
            If wait_loop > 1000 Then
                Console.Write(vbCrLf + "Falied to wait Master Sync Done")
                Return -12
            End If
            Thread.Sleep(1)
            DSA_DASK.DSA_SYN_CheckMultiCardStatus(config_para_slave.card_handle, config_para_slave.pdn_sync_status)
        Loop Until (config_para_slave.pdn_sync_status And DSA_DASK.P9529_SYN_IsPDNSyncReady)

        Return 0
    End Function

    Function config_channel_master_slave() As Short
        ' Configure AI channels for a registered device
        ' Note that the channel input range and input configuration can be set to different for each channel (This example sets the same setting for all enabled channels).

        ' Master
        Dim chnl_mode As Boolean = False
        For vi = 0 To 7
            If vi < config_para_master.chnl_cnt Then
                chnl_mode = True 'This channel will be enabled
            Else
                chnl_mode = False 'This channel will be disabled
            End If
            Dim result As Short = DSA_DASK.DSA_AI_9529_ConfigChannel(config_para_master.card_handle, vi, chnl_mode, config_para_master.chnl_range, config_para_master.chnl_config)
            If result <> DSA_DASK.NoError Then
                Console.Write(vbCrLf + "Falied to perform DSA_AI_9529_ConfigChannel() for Master, error: " + result.ToString())
                Return -1
            End If
        Next

        ' Slave
        chnl_mode = False
        For vi = 0 To 7
            If vi < config_para_slave.chnl_cnt Then
                chnl_mode = True 'This channel will be enabled
            Else
                chnl_mode = False 'This channel will be disabled
            End If
            Dim result As Short = DSA_DASK.DSA_AI_9529_ConfigChannel(config_para_slave.card_handle, vi, chnl_mode, config_para_slave.chnl_range, config_para_slave.chnl_config)
            If result <> DSA_DASK.NoError Then
                Console.Write(vbCrLf + "Falied to perform DSA_AI_9529_ConfigChannel() for Slave, error: " + result.ToString())
                Return -11
            End If
        Next

        Return 0
    End Function

    Function config_buffer_master_slave() As Short
        ' Enable double-buffer mode
        ' DSA-Dask provides a technique called double-buffer mode to perform continuous AI operation.
        ' Please refer DSA-DASK User Manual section 5.2 for details.

        ' Master
        Dim result As Short = DSA_DASK.DSA_AI_AsyncDblBufferMode(config_para_master.card_handle, True)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_AsyncDblBufferMode() for Master, error: " + result.ToString())
            Return -1
        End If

        ' Slave
        result = DSA_DASK.DSA_AI_AsyncDblBufferMode(config_para_slave.card_handle, True)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_AsyncDblBufferMode() for Master, error: " + result.ToString())
            Return -11
        End If

        ' Setup buffer for data transfer
        ' Allocates memory from the unmanaged memory of the process.
        ' Note: If a memory is allocated from the managed heap to perform DAQ/DMA operation,
        '       the memory might be moved by the GC and then an unexpected memory exception error is happened.
        '       For 9529, the memory address of performing DMA transfer should be 16 alignment.

        ' Master
        config_para_master.raw_data_buf = New IntPtr(1) {}
        config_para_master.raw_data_buf(0) = Marshal.AllocHGlobal(Convert.ToInt32(Marshal.SizeOf(GetType(UInteger)) * config_para_master.buf_size) + 8)
        config_para_master.raw_data_buf(1) = Marshal.AllocHGlobal(Convert.ToInt32(Marshal.SizeOf(GetType(UInteger)) * config_para_master.buf_size) + 8)
        ' Adjust memory address for 16 alignment
        config_para_master.raw_data_buf_alignment = New IntPtr(1) {}
        Dim pBufferAlign As UInt32
        If (CUInt(config_para_master.raw_data_buf(0)) And &H8) Then
            pBufferAlign = CUInt(config_para_master.raw_data_buf(0)) + 8
        Else
            pBufferAlign = CUInt(config_para_master.raw_data_buf(0))
        End If
        config_para_master.raw_data_buf_alignment(0) = CType(pBufferAlign, IntPtr)

        If (CUInt(config_para_master.raw_data_buf(1)) And &H8) Then
            pBufferAlign = CUInt(config_para_master.raw_data_buf(1)) + 8
        Else
            pBufferAlign = CUInt(config_para_master.raw_data_buf(1))
        End If
        config_para_master.raw_data_buf_alignment(1) = CType(pBufferAlign, IntPtr)
        config_para_master.scale_data_buf = New Double(config_para_master.buf_size - 1) {}
        config_para_master.buf_id_array = New UInteger(0) {}
        Dim buf_id(1) As UShort
        For vi = 0 To 1
            result = DSA_DASK.DSA_AI_ContBufferSetup(config_para_master.card_handle, config_para_master.raw_data_buf_alignment(vi), config_para_master.buf_size, buf_id(vi))
            If result <> DSA_DASK.NoError Then
                If vi <> 0 Then
                    ' Reset buffer
                    DSA_DASK.DSA_AI_ContBufferReset(config_para_master.card_handle)
                End If
                For vj = 0 To vi - 1
                    Marshal.FreeHGlobal(config_para_master.raw_data_buf(vj))
                Next
                Console.Write(vbCrLf + "Falied to perform DSA_AI_ContBufferSetup() for Master, error: " + result.ToString())
                Return -2
            End If
        Next
        config_para_master.buf_id_array(0) = buf_id(0)
        config_para_master.is_set_buf = True

        ' Slave
        config_para_slave.raw_data_buf = New IntPtr(1) {}
        config_para_slave.raw_data_buf(0) = Marshal.AllocHGlobal(Convert.ToInt32(Marshal.SizeOf(GetType(UInteger)) * config_para_slave.buf_size) + 8)
        config_para_slave.raw_data_buf(1) = Marshal.AllocHGlobal(Convert.ToInt32(Marshal.SizeOf(GetType(UInteger)) * config_para_slave.buf_size) + 8)
        ' Adjust memory address for 16 alignment
        config_para_slave.raw_data_buf_alignment = New IntPtr(1) {}
        If (CUInt(config_para_slave.raw_data_buf(0)) And &H8) Then
            pBufferAlign = CUInt(config_para_slave.raw_data_buf(0)) + 8
        Else
            pBufferAlign = CUInt(config_para_slave.raw_data_buf(0))
        End If
        config_para_slave.raw_data_buf_alignment(0) = CType(pBufferAlign, IntPtr)

        If (CUInt(config_para_slave.raw_data_buf(1)) And &H8) Then
            pBufferAlign = CUInt(config_para_slave.raw_data_buf(1)) + 8
        Else
            pBufferAlign = CUInt(config_para_slave.raw_data_buf(1))
        End If
        config_para_slave.raw_data_buf_alignment(1) = CType(pBufferAlign, IntPtr)
        config_para_slave.scale_data_buf = New Double(config_para_slave.buf_size - 1) {}
        config_para_slave.buf_id_array = New UInteger(0) {}
        For vi = 0 To 1
            result = DSA_DASK.DSA_AI_ContBufferSetup(config_para_slave.card_handle, config_para_slave.raw_data_buf_alignment(vi), config_para_slave.buf_size, buf_id(vi))
            If result <> DSA_DASK.NoError Then
                If vi <> 0 Then
                    ' Reset buffer
                    DSA_DASK.DSA_AI_ContBufferReset(config_para_slave.card_handle)
                End If
                For vj = 0 To vi - 1
                    Marshal.FreeHGlobal(config_para_slave.raw_data_buf(vj))
                Next
                Console.Write(vbCrLf + "Falied to perform DSA_AI_ContBufferSetup() for Slave, error: " + result.ToString())
                Return -12
            End If
        Next
        config_para_slave.buf_id_array(0) = buf_id(0)
        config_para_slave.is_set_buf = True

        Return 0
    End Function

    Function config_event_master_slave() As Short
        ' Set AI buffer Ready event

        ' Master
        Dim result As Short = DSA_DASK.DSA_AI_EventCallBack(config_para_master.card_handle, 1, DSA_DASK.DBEvent, ai_buf_ready_cbdel_master)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_EventCallBack() for Master, error: " + result.ToString())
            Return -1
        End If
        config_para_master.is_buf_ready_evt_set = True

        ' Slave
        result = DSA_DASK.DSA_AI_EventCallBack(config_para_slave.card_handle, 1, DSA_DASK.DBEvent, ai_buf_ready_cbdel_slave)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_EventCallBack() for Slave, error: " + result.ToString())
            Return -11
        End If
        config_para_slave.is_buf_ready_evt_set = True

        ' Set AI done event

        ' Master
        result = DSA_DASK.DSA_AI_EventCallBack(config_para_master.card_handle, 1, DSA_DASK.AIEnd, ai_done_cbdel_master)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_EventCallBack() for Master, error: " + result.ToString())
            Return -2
        End If
        config_para_master.is_done_evt_set = True

        ' Slave
        result = DSA_DASK.DSA_AI_EventCallBack(config_para_slave.card_handle, 1, DSA_DASK.AIEnd, ai_done_cbdel_slave)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_EventCallBack() for Slave, error: " + result.ToString())
            Return -12
        End If
        config_para_slave.is_done_evt_set = True

        Return 0
    End Function

    Function start_acquisition_master_slave() As Short
        ' Open file
        config_para_master.file_writer = New StreamWriter(config_para_master.file_name)
        config_para_master.is_file_open = True

        config_para_slave.file_writer = New StreamWriter(config_para_slave.file_name)
        config_para_slave.is_file_open = True

        ' Read AI data, and the acquired raw data will be stored in the set buffer.
        ' Note that Slave should be started before starting Master

        ' Slave
        Dim result As Short = DSA_DASK.DSA_AI_ContReadChannel(config_para_slave.card_handle, config_para_slave.chnl_cnt, 0, config_para_slave.buf_id_array, config_para_slave.all_data_count, 0, DSA_DASK.ASYNCH_OP)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_ContReadChannel() for Slave, error: " + result.ToString())
            Return -11
        End If
        config_para_slave.is_op_run = True

        ' Master
        result = DSA_DASK.DSA_AI_ContReadChannel(config_para_master.card_handle, config_para_master.chnl_cnt, 0, config_para_master.buf_id_array, config_para_master.all_data_count, 0, DSA_DASK.ASYNCH_OP)
        If result <> DSA_DASK.NoError Then
            Console.Write(vbCrLf + "Falied to perform DSA_AI_ContReadChannel() for Master, error: " + result.ToString())
            Return -1
        End If
        config_para_master.is_op_run = True

        Console.Write(vbCrLf + "AI operation is started, waiting trigger from the set trigger source..." + vbCrLf)
        If config_para_master.is_gen_sw_trig Then
            ' Generate software trigger if the trigger source is set to software trigger
            Console.Write(vbCrLf + "Press 'Enter' to generate software trigger for Master.")
            Console.ReadLine()
            Console.Write("Generating software trigger... ")
            DSA_DASK.DSA_TRG_SoftTriggerGen(config_para_master.card_handle)
            Console.Write("done" + vbCrLf)
        End If

        Return 0
    End Function

    ' Callback function for Master AI buffer ready event
    Sub ai_buf_ready_cbfunc_master()
        config_para_master.buf_ready_cnt += 1
        Console.Write(vbCrLf + "Master buffer half ready, ready count: {0}", config_para_master.buf_ready_cnt)

        ' Convert AI raw data to scaled data, it depends on the setting of channel range.
        DSA_DASK.DSA_AI_ContVScale(config_para_master.card_handle, config_para_master.chnl_range, config_para_master.raw_data_buf_alignment(config_para_master.buf_ready_idx), config_para_master.scale_data_buf, Convert.ToInt32(config_para_master.buf_size))

        config_para_master.buf_ready_idx += 1
        config_para_master.buf_ready_idx = config_para_master.buf_ready_idx Mod 2

        ' Write to file
        Dim vi As Integer
        For vi = 0 To config_para_master.buf_size / config_para_master.chnl_cnt - 1
            Dim vj As Integer
            For vj = 0 To config_para_master.chnl_cnt - 1
                config_para_master.file_writer.Write("{0:f8},", config_para_master.scale_data_buf(vi * config_para_master.chnl_cnt + vj))
            Next
            config_para_master.file_writer.Write(vbCrLf)
        Next

        'Tell DSA-DASK that the ready buffer is handled
        DSA_DASK.DSA_AI_AsyncDblBufferHandled(config_para_master.card_handle)
    End Sub
    Dim ai_buf_ready_cbdel_master As New CallbackDelegate(AddressOf ai_buf_ready_cbfunc_master)

    ' Callback function for Slave AI buffer ready event
    Sub ai_buf_ready_cbfunc_slave()
        config_para_slave.buf_ready_cnt += 1
        Console.Write(vbCrLf + "Slave buffer half ready, ready count: {0}", config_para_slave.buf_ready_cnt)

        ' Convert AI raw data to scaled data, it depends on the setting of channel range.
        DSA_DASK.DSA_AI_ContVScale(config_para_slave.card_handle, config_para_slave.chnl_range, config_para_slave.raw_data_buf_alignment(config_para_slave.buf_ready_idx), config_para_slave.scale_data_buf, Convert.ToInt32(config_para_slave.buf_size))

        config_para_slave.buf_ready_idx += 1
        config_para_slave.buf_ready_idx = config_para_slave.buf_ready_idx Mod 2

        ' Write to file
        Dim vi As Integer
        For vi = 0 To config_para_slave.buf_size / config_para_slave.chnl_cnt - 1
            Dim vj As Integer
            For vj = 0 To config_para_slave.chnl_cnt - 1
                config_para_slave.file_writer.Write("{0:f8},", config_para_slave.scale_data_buf(vi * config_para_slave.chnl_cnt + vj))
            Next
            config_para_slave.file_writer.Write(vbCrLf)
        Next

        'Tell DSA-DASK that the ready buffer is handled
        DSA_DASK.DSA_AI_AsyncDblBufferHandled(config_para_slave.card_handle)
    End Sub
    Dim ai_buf_ready_cbdel_slave As New CallbackDelegate(AddressOf ai_buf_ready_cbfunc_slave)

    ' Callback function for Master AI operation is complete
    Dim ai_done_event_master As New AutoResetEvent(False)
    Sub ai_done_cbfunc_master()
        Console.Write(vbCrLf + "Master AI acquisition is complete!")

        ' Set event
        ai_done_event_master.Set()
    End Sub
    Dim ai_done_cbdel_master As New CallbackDelegate(AddressOf ai_done_cbfunc_master)

    ' Callback function for Slave AI operation is complete
    Dim ai_done_event_slave As New AutoResetEvent(False)
    Sub ai_done_cbfunc_slave()
        Console.Write(vbCrLf + "Slave AI acquisition is complete!")

        ' Set event
        ai_done_event_slave.Set()
    End Sub
    Dim ai_done_cbdel_slave As New CallbackDelegate(AddressOf ai_done_cbfunc_slave)

    Sub Main()
        Console.Write("This example performs Synchronization of multiple devices for AI acquisition." + vbCrLf)
        Console.Write("Please attach two devices and connect their SSI bus." + vbCrLf)
        Console.Write("Press 'Enter' to continue...")
        Console.ReadLine()

        ' Initialize configuration structure
        init_master_struct()
        init_slave_struct()

        ' Configure device by console input
        console_config_master()
        console_config_slave()

        ' Register Master and Slave
        Dim result As Short = register_master_slave()
        If result < 0 Then
            exit_handle()
        End If

        ' Setting synchronization Mater and Slave
        result = set_sync_master_slave()
        If result < 0 Then
            exit_handle()
        End If

        ' Start synchronzation Master and Slave
        result = start_sync_master_slave()
        If result < 0 Then
            exit_handle()
        End If

        ' Configure channel Master and Slave
        result = config_channel_master_slave()
        If result < 0 Then
            exit_handle()
        End If

        ' Configure DMA buffer Master and Slave
        result = config_buffer_master_slave
        If result < 0 Then
            exit_handle()
        End If

        ' Configure event (callback) Master and Slave
        result = config_event_master_slave()
        If result < 0 Then
            exit_handle()
        End If

        Console.Write(vbCrLf + "Press 'Enter' to start AI operation")
        Console.ReadLine()

        ' Start AI acquisition
        result = start_acquisition_master_slave()
        If result < 0 Then
            exit_handle()
        End If

        Console.ReadLine()

        ' Clear AI setting
        DSA_DASK.DSA_AI_AsyncClear(config_para_master.card_handle, config_para_master.access_cnt)
        config_para_master.is_op_run = False
        DSA_DASK.DSA_AI_AsyncClear(config_para_slave.card_handle, config_para_slave.access_cnt)
        config_para_slave.is_op_run = False

        ' Wait for that ai_done_cbfunc() is complete
        ai_done_event_master.WaitOne()
        ai_done_event_slave.WaitOne()

        Console.Write(vbCrLf + "Master AI data is stored in file {0}", config_para_master.file_name)
        Console.Write(vbCrLf + "Slave AI data is stored in file {0}", config_para_slave.file_name)

        ' Exit program
        exit_handle()
    End Sub

End Module
