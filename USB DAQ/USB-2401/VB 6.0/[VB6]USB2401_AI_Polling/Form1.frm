VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6030
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   8880
   LinkTopic       =   "Form1"
   ScaleHeight     =   6030
   ScaleWidth      =   8880
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnReadAI 
      Caption         =   " Start Read AI"
      Height          =   615
      Index           =   1
      Left            =   360
      TabIndex        =   5
      Top             =   1800
      Width           =   1215
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   100
      Left            =   3240
      Top             =   240
   End
   Begin VB.TextBox edAIValue 
      Height          =   375
      Left            =   1680
      TabIndex        =   4
      Top             =   1920
      Width           =   1215
   End
   Begin VB.CommandButton btnReadAI 
      Caption         =   "Stop Read AI"
      Height          =   615
      Index           =   0
      Left            =   360
      TabIndex        =   3
      Top             =   2520
      Width           =   1215
   End
   Begin VB.CommandButton btnConfigAI 
      Caption         =   "Config AI"
      Height          =   615
      Left            =   360
      TabIndex        =   2
      Top             =   1080
      Width           =   1215
   End
   Begin VB.TextBox edModuleNo 
      Height          =   375
      Left            =   1680
      TabIndex        =   1
      Top             =   360
      Width           =   1215
   End
   Begin VB.CommandButton btnRegister 
      Caption         =   "Register"
      Height          =   615
      Left            =   360
      TabIndex        =   0
      Top             =   240
      Width           =   1215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim ModuleNo As Integer
Dim tmpFlag As Boolean
Dim NumCHs As Integer
Dim CHs() As Integer
Dim ADRanges() As Integer
Dim AIBuff() As Long
Dim AIValueV As Double
Dim err As Integer


Private Sub btnConfigAI_Click()

    err = UD_AI_2401_PollConfig(ModuleNo, P2401_ADC_2000_SPS, P2401_Polling_MAvg_Disable, P2401_Polling_MAvg_Disable, P2401_Polling_MAvg_Disable, P2401_Polling_MAvg_Disable)
    
    CHs(0) = 0
    ADRanges(0) = AD_B_12_5_V
    
End Sub

Private Sub btnReadAI_Click(Index As Integer)
    
    tmpFlag = Index
    Timer1.Enabled = tmpFlag

End Sub

Private Sub btnRegister_Click()
    
    ModuleNo = UD_Register_Card(USB_2401, 0)
    edModuleNo.Text = ModuleNo
    
End Sub

Private Sub Form_Load()

    ModuleNo = -1
    
    NumCHs = 1
    ReDim CHs(NumCHs)
    ReDim AIBuff(NumCHs)
    ReDim ADRanges(NumCHs)

End Sub

Private Sub Form_Unload(Cancel As Integer)

    If ModuleNo >= 0 Then
        UD_Release_Card ModuleNo
    End If

End Sub

Private Sub Timer1_Timer()

    err = UD_AI_ReadMultiChannels(ModuleNo, NumCHs, CHs(0), ADRanges(0), AIBuff(0))
    err = UD_AI_2401_Scale32(ModuleNo, AD_B_12_5_V, P2401_Voltage_2D5V_Above, AIBuff(0), AIValueV)
    edAIValue.Text = AIValueV

End Sub
