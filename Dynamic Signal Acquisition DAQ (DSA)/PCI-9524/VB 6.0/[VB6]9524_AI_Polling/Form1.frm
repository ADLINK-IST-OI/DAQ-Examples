VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6165
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   9255
   LinkTopic       =   "Form1"
   ScaleHeight     =   6165
   ScaleWidth      =   9255
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox edCardNum 
      Height          =   375
      Left            =   1920
      TabIndex        =   4
      Text            =   "Text1"
      Top             =   360
      Width           =   1215
   End
   Begin VB.CommandButton edAIStop 
      Caption         =   "AI Read Stop"
      Height          =   615
      Left            =   120
      TabIndex        =   3
      Top             =   1680
      Width           =   1695
   End
   Begin VB.TextBox edAIValue 
      Height          =   375
      Left            =   1920
      TabIndex        =   2
      Text            =   "Text1"
      Top             =   1200
      Width           =   1215
   End
   Begin VB.Timer timerAI 
      Enabled         =   0   'False
      Interval        =   100
      Left            =   1920
      Top             =   1800
   End
   Begin VB.CommandButton btnAIStart 
      Caption         =   "AI Read Start"
      Height          =   615
      Left            =   120
      TabIndex        =   1
      Top             =   960
      Width           =   1695
   End
   Begin VB.CommandButton btnRegister 
      Caption         =   "Register Card"
      Height          =   615
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   1695
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim err As Integer
Dim CardNum As Integer
Dim Config As Integer
Dim Trig As Integer
Dim AIValue As Double
Dim AICH As Integer
Dim AdRange As Integer
Dim AOCH As Integer
Dim AOValue As Double

Private Sub btnAIStart_Click()

    Trig = P9524_TRGMOD_POST Or P9524_TRGSRC_SOFT Or P9524_AI_TrgPositive
    AI_9524_Config CardNum, P9524_AI_GP_Group, P9524_AI_XFER_POLL, 0, Trig, 0
    
    AICH = P9524_AI_GP_CH0
    AdRange = AD_B_10_V
    
    AI_9524_PollConfig CardNum, P9524_AI_GP_Group, AICH, AdRange, P9524_ADC_30K_SPS
    timerAI.Enabled = True
    
End Sub


Private Sub btnRegister_Click()
    
    CardNum = Register_Card(PCI_9524, 0)
    edCardNum.Text = CardNum
    
End Sub

Private Sub edAIStop_Click()
    
    timerAI.Enabled = False
    
End Sub

Private Sub Form_Unload(Cancel As Integer)
    
    If CardNum >= 0 Then
        Release_Card (CardNum)
    End If
    
End Sub

Private Sub timerAI_Timer()
    
    AI_VReadChannel CardNum, AICH, AdRange, AIValue
    edAIValue.Text = AIValue
    
End Sub
