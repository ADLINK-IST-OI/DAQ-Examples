Imports System.Windows.Forms

Public Class frm_card_sel
    Dim card_cnt As UShort
    Dim card_id As UShort
    Dim card_type As UShort

    Dim AvailModulesCnt As UShort
    Dim AvailModulesArray(USBDASK.MAX_USB_DEVICE) As USBDAQ_DEVICE
    Dim SelCardID(USBDASK.MAX_USB_DEVICE) As UShort

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        card_cnt = 0
        card_id = USBDASK.INVALID_CARD_ID
        card_type = USBDASK.USB_1903

    End Sub

    Private Sub frm_card_sel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim status As Short
        Dim vi As UShort
        Dim found As Boolean = False

        ' Scan the active USB-DAQ modules
        status = USBDASK.UD_Device_Scan(AvailModulesCnt, AvailModulesArray(0))
        If (status <> USBDASK.NoError) Then
            MessageBox.Show("Failed to perform UD_Device_Scan(), status code: " + status.ToString(), "Error", MessageBoxButtons.OK)
            Environment.Exit(0)
        End If

        ' Filter card_type (USBDASK.USB_1903)
        For vi = 0 To CUShort(AvailModulesCnt - 1)
            If (AvailModulesArray(vi).wModuleType = card_type) Then
                SelCardID(card_cnt) = AvailModulesArray(vi).wCardID
                card_cnt = card_cnt + 1
                found = True
            End If
        Next

        ' Update card_id ComboBox
        cbox_card_id.Items.Clear()
        If found = True Then
            For vi = 0 To CUShort(card_cnt - 1)
                cbox_card_id.Items.Add(SelCardID(vi))
            Next
            cbox_card_id.SelectedIndex = 0
            btn_OK.Enabled = True
        Else
            MessageBox.Show("No USB-1903 exists", "Error", MessageBoxButtons.OK)
            Environment.Exit(0)
        End If

    End Sub

    Private Sub btn_OK_Click(sender As System.Object, e As System.EventArgs) Handles btn_OK.Click

        card_id = cbox_card_id.SelectedItem
        Me.Close()

    End Sub

    Private Sub btn_cancel_Click(sender As System.Object, e As System.EventArgs) Handles btn_cancel.Click

        Environment.Exit(0)

    End Sub

    Public Function fn_get_card_type() As UShort

        Return card_type

    End Function

    Public Function fn_get_card_id() As UShort

        Return card_id

    End Function

End Class