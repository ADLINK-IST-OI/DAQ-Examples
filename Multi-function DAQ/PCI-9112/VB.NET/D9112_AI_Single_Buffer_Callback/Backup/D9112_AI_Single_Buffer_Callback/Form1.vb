Public Class Form1
    Dim data_buffer(999) As UShort
    Dim voltage_array(999) As Double
    Dim m_dev As Short

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_dev = Register_Card(PCI_9112, 0)
        If (m_dev < 0) Then
            MessageBox.Show("Register_Card error!")
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim err As Short
        If (m_dev >= 0) Then
            err = Release_Card(m_dev)
        End If
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim err As Short
        err = AI_EventCallBack(m_dev, 1, AIEnd, AddressOf Callback)
        If (err < 0) Then
            MessageBox.Show("AI_EventCallBack error!")
            Return
        End If
        err = AI_9112_Config(m_dev, TRIG_INT_PACER)
        If (err < 0) Then
            MessageBox.Show("AI_9112_Config error!")
            Return
        End If
        err = AI_ContReadChannel(m_dev, 0, AD_B_5_V, data_buffer(0), 1000, 10000, ASYNCH_OP)
        If (err < 0) Then
            MessageBox.Show("AI_ContReadChannel error!")
            Return
        End If
    End Sub

    Sub Callback()
        Dim err As Short
        Dim access_cnt As Integer
        err = DASK.AI_AsyncClear(m_dev, access_cnt)
        If (err < 0) Then
            MessageBox.Show("D2K_AI_ContVScale error!")
            Return
        End If
        err = DASK.AI_ContVScale(m_dev, AD_B_5_V, data_buffer(0), voltage_array(0), 1000)
        If (err < 0) Then
            MessageBox.Show("D2K_AI_ContVScale error!")
            Return
        End If
        AxDGraph1.PlotGraph(voltage_array, 0)
    End Sub
End Class
