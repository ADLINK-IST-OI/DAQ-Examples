<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_main
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
        Me.components = New System.ComponentModel.Container()
        Me.btn_start = New System.Windows.Forms.Button()
        Me.btn_stop = New System.Windows.Forms.Button()
        Me.tbox_sample_rate = New System.Windows.Forms.TextBox()
        Me.tbox_sample_cnt = New System.Windows.Forms.TextBox()
        Me.tbox_trigger_cnt = New System.Windows.Forms.TextBox()
        Me.lb_sample_rate = New System.Windows.Forms.Label()
        Me.lb_sample_cnt = New System.Windows.Forms.Label()
        Me.lb_trigger_cnt = New System.Windows.Forms.Label()
        Me.zg_waveform = New ZedGraph.ZedGraphControl()
        Me.cbox_show_data = New System.Windows.Forms.CheckBox()
        Me.cbox_save_data = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btn_start
        '
        Me.btn_start.Enabled = False
        Me.btn_start.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_start.Location = New System.Drawing.Point(492, 321)
        Me.btn_start.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(80, 31)
        Me.btn_start.TabIndex = 0
        Me.btn_start.Text = "Start"
        Me.btn_start.UseVisualStyleBackColor = True
        '
        'btn_stop
        '
        Me.btn_stop.Enabled = False
        Me.btn_stop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_stop.Location = New System.Drawing.Point(492, 285)
        Me.btn_stop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_stop.Name = "btn_stop"
        Me.btn_stop.Size = New System.Drawing.Size(80, 31)
        Me.btn_stop.TabIndex = 1
        Me.btn_stop.Text = "Stop"
        Me.btn_stop.UseVisualStyleBackColor = True
        '
        'tbox_sample_rate
        '
        Me.tbox_sample_rate.Location = New System.Drawing.Point(92, 330)
        Me.tbox_sample_rate.Name = "tbox_sample_rate"
        Me.tbox_sample_rate.Size = New System.Drawing.Size(100, 23)
        Me.tbox_sample_rate.TabIndex = 3
        '
        'tbox_sample_cnt
        '
        Me.tbox_sample_cnt.Location = New System.Drawing.Point(317, 329)
        Me.tbox_sample_cnt.Name = "tbox_sample_cnt"
        Me.tbox_sample_cnt.Size = New System.Drawing.Size(100, 23)
        Me.tbox_sample_cnt.TabIndex = 5
        '
        'tbox_trigger_cnt
        '
        Me.tbox_trigger_cnt.Location = New System.Drawing.Point(492, 31)
        Me.tbox_trigger_cnt.Name = "tbox_trigger_cnt"
        Me.tbox_trigger_cnt.ReadOnly = True
        Me.tbox_trigger_cnt.Size = New System.Drawing.Size(80, 23)
        Me.tbox_trigger_cnt.TabIndex = 9
        Me.tbox_trigger_cnt.TabStop = False
        Me.tbox_trigger_cnt.Text = "0"
        '
        'lb_sample_rate
        '
        Me.lb_sample_rate.AutoSize = True
        Me.lb_sample_rate.Location = New System.Drawing.Point(12, 333)
        Me.lb_sample_rate.Name = "lb_sample_rate"
        Me.lb_sample_rate.Size = New System.Drawing.Size(74, 15)
        Me.lb_sample_rate.TabIndex = 2
        Me.lb_sample_rate.Text = "Sample Rate"
        '
        'lb_sample_cnt
        '
        Me.lb_sample_cnt.AutoSize = True
        Me.lb_sample_cnt.Location = New System.Drawing.Point(229, 333)
        Me.lb_sample_cnt.Name = "lb_sample_cnt"
        Me.lb_sample_cnt.Size = New System.Drawing.Size(82, 15)
        Me.lb_sample_cnt.TabIndex = 4
        Me.lb_sample_cnt.Text = "Sample Count"
        '
        'lb_trigger_cnt
        '
        Me.lb_trigger_cnt.AutoSize = True
        Me.lb_trigger_cnt.Location = New System.Drawing.Point(489, 13)
        Me.lb_trigger_cnt.Name = "lb_trigger_cnt"
        Me.lb_trigger_cnt.Size = New System.Drawing.Size(79, 15)
        Me.lb_trigger_cnt.TabIndex = 8
        Me.lb_trigger_cnt.Text = "Trigger Count"
        '
        'zg_waveform
        '
        Me.zg_waveform.IsEnableWheelZoom = False
        Me.zg_waveform.IsPrintFillPage = False
        Me.zg_waveform.IsPrintKeepAspectRatio = False
        Me.zg_waveform.IsPrintScaleAll = False
        Me.zg_waveform.IsShowCopyMessage = False
        Me.zg_waveform.Location = New System.Drawing.Point(16, 16)
        Me.zg_waveform.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.zg_waveform.Name = "zg_waveform"
        Me.zg_waveform.ScrollGrace = 0.0R
        Me.zg_waveform.ScrollMaxX = 0.0R
        Me.zg_waveform.ScrollMaxY = 0.0R
        Me.zg_waveform.ScrollMaxY2 = 0.0R
        Me.zg_waveform.ScrollMinX = 0.0R
        Me.zg_waveform.ScrollMinY = 0.0R
        Me.zg_waveform.ScrollMinY2 = 0.0R
        Me.zg_waveform.Size = New System.Drawing.Size(454, 300)
        Me.zg_waveform.TabIndex = 10
        Me.zg_waveform.TabStop = False
        '
        'cbox_show_data
        '
        Me.cbox_show_data.AutoSize = True
        Me.cbox_show_data.Location = New System.Drawing.Point(492, 229)
        Me.cbox_show_data.Name = "cbox_show_data"
        Me.cbox_show_data.Size = New System.Drawing.Size(92, 19)
        Me.cbox_show_data.TabIndex = 6
        Me.cbox_show_data.Text = "Show Graph"
        Me.cbox_show_data.UseVisualStyleBackColor = True
        '
        'cbox_save_data
        '
        Me.cbox_save_data.AutoSize = True
        Me.cbox_save_data.Location = New System.Drawing.Point(492, 254)
        Me.cbox_save_data.Name = "cbox_save_data"
        Me.cbox_save_data.Size = New System.Drawing.Size(73, 19)
        Me.cbox_save_data.TabIndex = 7
        Me.cbox_save_data.Text = "Log Data"
        Me.cbox_save_data.UseVisualStyleBackColor = True
        '
        'frm_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 362)
        Me.Controls.Add(Me.cbox_save_data)
        Me.Controls.Add(Me.cbox_show_data)
        Me.Controls.Add(Me.zg_waveform)
        Me.Controls.Add(Me.lb_trigger_cnt)
        Me.Controls.Add(Me.lb_sample_cnt)
        Me.Controls.Add(Me.lb_sample_rate)
        Me.Controls.Add(Me.tbox_trigger_cnt)
        Me.Controls.Add(Me.tbox_sample_cnt)
        Me.Controls.Add(Me.tbox_sample_rate)
        Me.Controls.Add(Me.btn_stop)
        Me.Controls.Add(Me.btn_start)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frm_main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "USB-1903 Infinite Trigger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_start As System.Windows.Forms.Button
    Friend WithEvents btn_stop As System.Windows.Forms.Button
    Friend WithEvents tbox_sample_rate As System.Windows.Forms.TextBox
    Friend WithEvents tbox_sample_cnt As System.Windows.Forms.TextBox
    Friend WithEvents tbox_trigger_cnt As System.Windows.Forms.TextBox
    Friend WithEvents lb_sample_rate As System.Windows.Forms.Label
    Friend WithEvents lb_sample_cnt As System.Windows.Forms.Label
    Friend WithEvents lb_trigger_cnt As System.Windows.Forms.Label
    Friend WithEvents zg_waveform As ZedGraph.ZedGraphControl
    Friend WithEvents cbox_show_data As System.Windows.Forms.CheckBox
    Friend WithEvents cbox_save_data As System.Windows.Forms.CheckBox

End Class
