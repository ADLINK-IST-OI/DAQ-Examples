<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_card_sel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.lb_card_id = New System.Windows.Forms.Label()
        Me.cbox_card_id = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btn_OK
        '
        Me.btn_OK.Enabled = False
        Me.btn_OK.Location = New System.Drawing.Point(197, 60)
        Me.btn_OK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(78, 26)
        Me.btn_OK.TabIndex = 0
        Me.btn_OK.Text = "OK"
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(113, 60)
        Me.btn_cancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(78, 26)
        Me.btn_cancel.TabIndex = 3
        Me.btn_cancel.Text = "Cancel"
        '
        'lb_card_id
        '
        Me.lb_card_id.AutoSize = True
        Me.lb_card_id.Location = New System.Drawing.Point(16, 32)
        Me.lb_card_id.Name = "lb_card_id"
        Me.lb_card_id.Size = New System.Drawing.Size(48, 15)
        Me.lb_card_id.TabIndex = 2
        Me.lb_card_id.Text = "Card ID"
        '
        'cbox_card_id
        '
        Me.cbox_card_id.FormattingEnabled = True
        Me.cbox_card_id.Location = New System.Drawing.Point(80, 29)
        Me.cbox_card_id.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbox_card_id.Name = "cbox_card_id"
        Me.cbox_card_id.Size = New System.Drawing.Size(195, 23)
        Me.cbox_card_id.TabIndex = 1
        '
        'frm_card_sel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 100)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.lb_card_id)
        Me.Controls.Add(Me.cbox_card_id)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_card_sel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "USB-1903 Card Selection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Private WithEvents lb_card_id As System.Windows.Forms.Label
    Private WithEvents cbox_card_id As System.Windows.Forms.ComboBox

End Class
