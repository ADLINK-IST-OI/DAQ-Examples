Option Explicit On

Imports System.Runtime.InteropServices
Imports System.IO
Imports ZedGraph

Public Class frm_main
    Dim card_open As Boolean = False
    Dim card_run As Boolean = False
    Dim card_handle As UShort = USBDASK.INVALID_CARD_ID
    Dim sample_rate As Double = 3650
    Dim sample_cnt As UInteger = 512
    Dim trigger_cnt As UInteger = 0
    Dim chnl_conf As UShort = (USBDASK.P1902_AI_PseudoDifferential Or USBDASK.P1902_AI_CONVSRC_INT)
    Dim trig_conf As UShort = (USBDASK.P1902_AI_TRGSRC_DTRIG Or USBDASK.P1902_AI_TrgPositive Or USBDASK.P1902_AI_EnReTigger)
    Dim raw_data_buffer As IntPtr
    Dim raw_data_buffer_alloc As Boolean = False
    Dim scale_data_buffer As Double()
    Dim event_set As Boolean

    Dim is_show_data As Boolean = False
    Dim is_save_data As Boolean = False

    Dim file_writer As StreamWriter
    Dim file_open As Boolean = False

    Const U190x_TIMEBASE As UInteger = 80000000  '80M

    Private Sub frm_main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Select device
        Dim card_form As frm_card_sel = New frm_card_sel()
        card_form.ShowDialog()

        Dim sel_card_type As UShort = card_form.fn_get_card_type ' USB-1903
        Dim sel_card_id As UShort = card_form.fn_get_card_id

        ' Open and initialize device
        Dim status As Short = USBDASK.UD_Register_Card(sel_card_type, sel_card_id)
        If status < 0 Then
            MessageBox.Show("Failed to perform UD_Register_Card(), status code: " + status.ToString(), "Error", MessageBoxButtons.OK)
            Environment.Exit(0)
        End If
        card_handle = status
        card_open = True

        ' Initial componnent
        Dim pane As GraphPane = Me.zg_waveform.GraphPane
        pane.Title.Text = "Data"
        pane.XAxis.Title.Text = "Time (Samples)"
        pane.XAxis.Scale.Min = 0
        pane.XAxis.Scale.Max = sample_cnt
        pane.YAxis.Title.Text = "Value (mA)"
        pane.YAxis.Scale.Min = 0
        pane.YAxis.Scale.Max = 20
        Me.zg_waveform.AxisChange()
        Me.zg_waveform.Refresh()

        Me.cbox_show_data.Checked = is_show_data
        Me.cbox_save_data.Checked = is_save_data

        Me.tbox_sample_rate.Text = sample_rate
        Me.tbox_sample_cnt.Text = sample_cnt

        Me.btn_start.Enabled = True

    End Sub

    Private Sub frm_main_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        ' Stop device
        If card_run Then
            btn_stop_Click(sender, e)
            card_run = False
        End If

        ' Release device
        If card_open Then
            USBDASK.UD_Release_Card(card_handle)
            card_open = False
        End If

        ' Free memory
        If (raw_data_buffer_alloc = True) Then
            Marshal.FreeHGlobal(raw_data_buffer)
            raw_data_buffer_alloc = False
        End If

        ' Dispose graphic


    End Sub

    Private Sub cbox_show_data_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbox_show_data.CheckedChanged

        is_show_data = Me.cbox_show_data.Checked

    End Sub

    Private Sub cbox_save_data_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbox_save_data.CheckedChanged

        is_save_data = Me.cbox_save_data.Checked

    End Sub

    Private Sub btn_start_Click(sender As System.Object, e As System.EventArgs) Handles btn_start.Click

        ' Get current configuration
        sample_cnt = Me.tbox_sample_cnt.Text
        sample_rate = Me.tbox_sample_rate.Text

        ' Set new settings
        Dim pane As GraphPane = Me.zg_waveform.GraphPane
        pane.CurveList.Clear()
        pane.XAxis.Scale.Max = sample_cnt
        Me.zg_waveform.AxisChange()
        Me.zg_waveform.Refresh()

        trigger_cnt = 0
        Me.tbox_trigger_cnt.Text = trigger_cnt

        ' Configure AI
        Dim status As Short = USBDASK.UD_AI_1902_Config(card_handle, chnl_conf, trig_conf, 0, 0, 0)
        If (status <> USBDASK.NoError) Then
            MessageBox.Show("Failed to perform UD_AI_1902_Config(), status code: " + status.ToString(), "Error", MessageBoxButtons.OK)
            Exit Sub
        End If

        ' Configure Timebase
        Dim sample_intrv As UInteger = U190x_TIMEBASE / sample_rate
        status = USBDASK.UD_AI_1902_CounterInterval(card_handle, sample_intrv, sample_intrv)
        If (status <> USBDASK.NoError) Then
            MessageBox.Show("Failed to perform UD_AI_1902_CounterInterval(), status code: " + status.ToString(), "Error", MessageBoxButtons.OK)
            Exit Sub
        End If

        ' Set AI callback event
        status = USBDASK.UD_AI_EventCallBack(card_handle, 1, USBDASK.DBEvent, ai_buf_ready_cbdel)
        If (status <> USBDASK.NoError) Then
            MessageBox.Show("Failed to perform UD_AI_EventCallBack(), status code: " + status.ToString(), "Error", MessageBoxButtons.OK)
            Exit Sub
        End If
        event_set = True

        ' Enable double-buffer for infinite trigger
        status = USBDASK.UD_AI_AsyncDblBufferMode(card_handle, 1)
        If (status <> USBDASK.NoError) Then
            MessageBox.Show("Failed to perform UD_AI_AsyncDblBufferMode(), status code: " + status.ToString(), "Error", MessageBoxButtons.OK)
            Exit Sub
        End If

        ' Free memory if it was allocated in previous operation
        If (raw_data_buffer_alloc = True) Then
            Marshal.FreeHGlobal(raw_data_buffer)
            raw_data_buffer_alloc = False
        End If

        ' Allocate memory
        raw_data_buffer = Marshal.AllocHGlobal(2 * Convert.ToInt32(sample_cnt) * 2) ' 2-bit * dwDataNum * double buffer
        raw_data_buffer_alloc = True
        scale_data_buffer = New Double(Convert.ToInt32(sample_cnt)) {}

        ' Start AI
        status = USBDASK.UD_AI_ContReadChannel(card_handle, 0, USBDASK.AD_B_10_V, raw_data_buffer, sample_cnt * 2, sample_rate, USBDASK.ASYNCH_OP)
        If (status <> USBDASK.NoError) Then
            MessageBox.Show("Failed to perform UD_AI_ContReadChannel(), status code: " + status.ToString(), "Error", MessageBoxButtons.OK)
            Exit Sub
        End If
        card_run = True

        ' Open file
        If is_save_data Then
            Try
                file_writer = New StreamWriter("data.csv")
                file_open = True
            Catch ex As Exception

            End Try
        End If

        Me.btn_start.Enabled = False
        Me.btn_stop.Enabled = True
        Me.tbox_sample_cnt.Enabled = False
        Me.tbox_sample_rate.Enabled = False
        Me.cbox_show_data.Enabled = False
        Me.cbox_save_data.Enabled = False

    End Sub

    Private Sub btn_stop_Click(sender As System.Object, e As System.EventArgs) Handles btn_stop.Click

        ' Reset AI callback event
        If event_set Then
            USBDASK.UD_AI_EventCallBack(card_handle, 0, USBDASK.DBEvent, ai_buf_ready_cbdel)
            event_set = False
        End If

        ' Stop AI
        If (card_run = True) Then
            Dim access_cnt As UInteger
            USBDASK.UD_AI_AsyncClear(card_handle, access_cnt)

            card_run = False
        End If

        ' Close file
        If is_save_data AndAlso file_open Then
            file_writer.Close()
            file_open = False
        End If

        Me.btn_start.Enabled = True
        Me.btn_stop.Enabled = False
        Me.tbox_sample_cnt.Enabled = True
        Me.tbox_sample_rate.Enabled = True
        Me.cbox_show_data.Enabled = True
        Me.cbox_save_data.Enabled = True

    End Sub

    ' Callback function for AI buffer ready event
    Sub ai_buf_ready_cbfunc()

        trigger_cnt = trigger_cnt + 1

        ' Transfer data from device
        USBDASK.UD_AI_AsyncDblBufferTransfer(card_handle, raw_data_buffer)

        ' Convert data to scale value
        USBDASK.UD_AI_ContVScale(card_handle, USBDASK.AD_B_10_V, raw_data_buffer, scale_data_buffer, sample_cnt)

        'Tell DSA-DASK that the ready buffer is handled
        USBDASK.UD_AI_AsyncDblBufferHandled(card_handle)

        ' Update data
        fn_plot_data()

    End Sub

    Dim ai_buf_ready_cbdel As New CallbackDelegate(AddressOf ai_buf_ready_cbfunc)

    'Dim delfn_plot_data As CallbackDelegate
    Sub fn_plot_data()

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf fn_plot_data))
        Else
            ' Only update number of triggers
            Me.tbox_trigger_cnt.Text = trigger_cnt

            Dim vi As UInteger
            For vi = 0 To sample_cnt - 1
                scale_data_buffer(vi) = scale_data_buffer(vi) * 1000 ' A -> mA
                ' Log Data
                If is_save_data AndAlso file_open Then
                    file_writer.Write("{0:f8}," + vbCrLf, scale_data_buffer(vi))
                End If
            Next

            ' Show Data
            If is_show_data Then
                Dim pane As GraphPane = Me.zg_waveform.GraphPane
                pane.CurveList.Clear()
                Dim curve As LineItem = pane.AddCurve("CH0", Nothing, scale_data_buffer, Color.Red, SymbolType.None)
                curve.Line.IsSmooth = True
                Me.zg_waveform.AxisChange()
                Me.zg_waveform.Refresh()
            End If
        End If

    End Sub

End Class