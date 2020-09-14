<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.button1 = New System.Windows.Forms.Button
        Me.AxDGraph1 = New AxDBGRAPHLib.AxDGraph
        CType(Me.AxDGraph1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(100, 240)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(90, 30)
        Me.button1.TabIndex = 4
        Me.button1.Text = "Start"
        Me.button1.UseVisualStyleBackColor = True
        '
        'AxDGraph1
        '
        Me.AxDGraph1.Enabled = True
        Me.AxDGraph1.Location = New System.Drawing.Point(1, 5)
        Me.AxDGraph1.Name = "AxDGraph1"
        Me.AxDGraph1.OcxState = CType(resources.GetObject("AxDGraph1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxDGraph1.Size = New System.Drawing.Size(290, 229)
        Me.AxDGraph1.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.AxDGraph1)
        Me.Controls.Add(Me.button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.AxDGraph1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents AxDGraph1 As AxDBGRAPHLib.AxDGraph

End Class
