VERSION 5.00
Begin VB.Form AI9524 
   Appearance      =   0  'Flat
   AutoRedraw      =   -1  'True
   BackColor       =   &H00C0C0C0&
   Caption         =   "9524 AI"
   ClientHeight    =   4635
   ClientLeft      =   1170
   ClientTop       =   825
   ClientWidth     =   6975
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   8.25
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H0000FFFF&
   LinkTopic       =   "Form1"
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4635
   ScaleWidth      =   6975
   Begin VB.Frame dmaFrame 
      Appearance      =   0  'Flat
      BackColor       =   &H00C0C0C0&
      Caption         =   "Input(A/D)"
      ForeColor       =   &H00FF0000&
      Height          =   3735
      Left            =   120
      TabIndex        =   6
      Top             =   120
      Width           =   6675
      Begin VB.HScrollBar scrollView 
         Height          =   255
         LargeChange     =   10
         Left            =   720
         TabIndex        =   8
         Top             =   3360
         Width           =   5655
      End
      Begin VB.PictureBox picScreen 
         Appearance      =   0  'Flat
         AutoRedraw      =   -1  'True
         BackColor       =   &H00000000&
         ForeColor       =   &H80000008&
         Height          =   2595
         Left            =   720
         ScaleHeight     =   171
         ScaleMode       =   3  'Pixel
         ScaleWidth      =   375
         TabIndex        =   7
         Top             =   480
         Width           =   5655
      End
      Begin VB.Image TriggerPos 
         Height          =   120
         Left            =   6360
         Top             =   600
         Visible         =   0   'False
         Width           =   120
      End
      Begin VB.Label lblLeft 
         Caption         =   "0"
         Height          =   195
         Left            =   660
         TabIndex        =   16
         Top             =   3120
         Width           =   795
      End
      Begin VB.Label lblRight 
         Alignment       =   1  'Right Justify
         Caption         =   "0"
         Height          =   195
         Left            =   5520
         TabIndex        =   15
         Top             =   3120
         Width           =   915
      End
      Begin VB.Label labValue 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "-10.00"
         ForeColor       =   &H0000FFFF&
         Height          =   255
         Index           =   4
         Left            =   45
         TabIndex        =   14
         Top             =   2940
         Width           =   600
      End
      Begin VB.Label labValue 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "-5.00"
         ForeColor       =   &H0000FFFF&
         Height          =   255
         Index           =   3
         Left            =   45
         TabIndex        =   13
         Top             =   2280
         Width           =   600
      End
      Begin VB.Label labValue 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "0.00"
         ForeColor       =   &H0000FFFF&
         Height          =   255
         Index           =   2
         Left            =   45
         TabIndex        =   12
         Top             =   1680
         Width           =   600
      End
      Begin VB.Label labValue 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "5.00"
         ForeColor       =   &H0000FFFF&
         Height          =   255
         Index           =   1
         Left            =   45
         TabIndex        =   11
         Top             =   1020
         Width           =   600
      End
      Begin VB.Label labValue 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "10.00"
         ForeColor       =   &H0000FFFF&
         Height          =   255
         Index           =   0
         Left            =   45
         TabIndex        =   10
         Top             =   420
         Width           =   600
      End
      Begin VB.Label labVots 
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "Volt"
         ForeColor       =   &H0000FFFF&
         Height          =   255
         Left            =   180
         TabIndex        =   9
         Top             =   195
         Width           =   435
      End
   End
   Begin VB.Frame Frame2 
      Appearance      =   0  'Flat
      BackColor       =   &H00C0C0C0&
      Caption         =   "Channel No."
      ForeColor       =   &H00FF0000&
      Height          =   615
      Left            =   2640
      TabIndex        =   3
      Top             =   3840
      Width           =   2055
      Begin VB.ComboBox cobChn 
         Appearance      =   0  'Flat
         Height          =   315
         Left            =   240
         Style           =   2  'Dropdown List
         TabIndex        =   4
         Top             =   240
         Width           =   1335
      End
      Begin VB.Label Label8 
         Appearance      =   0  'Flat
         BackColor       =   &H00C0C0C0&
         Caption         =   "CH"
         ForeColor       =   &H0000FFFF&
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   240
         Width           =   375
      End
   End
   Begin VB.CommandButton btnStart 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Caption         =   "Start"
      Height          =   375
      Left            =   5280
      TabIndex        =   1
      Top             =   4080
      Width           =   1485
   End
   Begin VB.Frame frmData 
      Appearance      =   0  'Flat
      BackColor       =   &H00C0C0C0&
      Caption         =   "Scan Count"
      ForeColor       =   &H00FF0000&
      Height          =   615
      Left            =   120
      TabIndex        =   0
      Top             =   3840
      Width           =   2055
      Begin VB.ComboBox cobDataSize 
         Appearance      =   0  'Flat
         Height          =   315
         Left            =   180
         TabIndex        =   2
         Text            =   "cobDataSize"
         Top             =   240
         Width           =   1395
      End
   End
   Begin VB.Shape shpColor 
      BackColor       =   &H0000FFFF&
      BackStyle       =   1  'Opaque
      BorderColor     =   &H00000000&
      Height          =   255
      Index           =   0
      Left            =   8280
      Top             =   960
      Width           =   195
   End
   Begin VB.Menu mnuExit 
      Caption         =   "E&xit!"
   End
End
Attribute VB_Name = "AI9524"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Const DISP_COUNT = 1000
Dim gnADChn As Long
Dim gnCount As Long
Dim gnClkDiv As Integer
Dim gnClkDiv2 As Integer
Dim count1 As Long
Dim ch_cnt As Integer
Dim gnBuffer(160000) As Integer
Dim dma_size As Long
Dim range As Integer
Dim ConfigCtrl As Integer
Dim TrigCtrl As Integer
Dim Mode As Integer
Dim TimeOut As Long
Dim BufID1 As Integer
Dim voltageArray(160000) As Double
Dim ActualRate As Double


Private Sub btnStart_Click()
  Dim result As Long
  Dim Status As Byte
  Dim i As Long, k As Long
  Timout = 20000
  dma_size = CLng(cobDataSize.Text)
  range = AD_B_10_V
  sample_rate = P9524_ADC_30K_SPS 'set up sampling rate'
  ConfigCtrl = P9524_AI_BufAutoReset
  ai_type = P9524_AI_GP_Group 'General Purpose AI'
  Mode = P9524_AI_XFER_DMA
  btnStart.Enabled = False
  Select Case cobChn.ListIndex  'Select General Purpose AI CH4~Ch7'
    Case 0
     ch_cnt = P9524_AI_GP_CH0
    Case 1
     ch_cnt = P9524_AI_GP_CH1
    Case 2
     ch_cnt = P9524_AI_GP_CH2
    Case 3
     ch_cnt = P9524_AI_GP_CH3
   End Select

  result = AI_ContBufferReset(card)
  result = AI_SetTimeOut(card, TimeOut)
  result = AI_ContBufferSetup(card, gnBuffer(0), dma_size, BufID1)
  result = AI_9524_Config(card, ai_type, Mode, ConfigCtrl, 0, 0)
  Status = 0
  gnBuffer(0) = 0
  result = AI_ContReadChannel(card, ch_cnt, range, gnBuffer(0), dma_size, sample_rate, ASYNCH_OP)
    If result <> 0 Then
     MsgBox "Continuous AI Failed"
     End
  End If
  While Status = 0
    result = AI_AsyncCheck(card, Status, count1)
  Wend
  result = AI_AsyncClear(card, count1)
  scrollView.Value = 0
  scrollView.Max = Fix((count1 - 1) / DISP_COUNT)
  ShowData 0, Min(count1, DISP_COUNT)
  btnStart.Enabled = True
End Sub
Private Sub cobRate_Click()
  gnClkDiv = Val(cobRate.Text) * (CLng(cobChn.ListIndex) + 1)
  cobScan.Text = Str(gnClkDiv)
End Sub

Private Sub Form_Load()
    Dim result As Long
    Dim i As Integer

    SettingForm.Show 1
    If card < 0 Then
      MsgBox "Register card failed."
      End
    End If

    cobDataSize.AddItem "1000"
   
    cobDataSize.ListIndex = 0

    cobChn.AddItem "CH4"
    cobChn.AddItem "CH5"
    cobChn.AddItem "CH6"
    cobChn.AddItem "CH7"
    cobChn.ListIndex = 0
    dma_size = 0
End Sub


Private Sub ShowData(ByVal startidx As Long, ByVal acq_count As Long)
    Dim i As Long, k As Long, n As Long
    Dim w As Long, h As Long
    Dim X As Long, Y As Long
    Dim last_x As Long, last_y As Long
    Dim samp As Integer, trig_pos As Long
    Dim data As Double
    picScreen.Cls
    DrawTrigLevel -1, trigLevel
    lblLeft.Caption = CStr(CLng(scrollView.Value) * DISP_COUNT)
    lblRight.Caption = CStr(CLng(lblLeft) + DISP_COUNT - 1)
    w = picScreen.ScaleWidth
    h = picScreen.ScaleHeight
    result = AI_ContVScale(card, range, gnBuffer(0), voltageArray(0), dma_size)
    
    
  
      last_x = -1
      last_y = -1
   
    For i = 0 To acq_count - 1
    
        X = (i * w) / (DISP_COUNT - 1)
        samp = gnBuffer(i)
        data = voltageArray(i)
        Y = CInt(-(171 * (data - 10) / 20)) ''change voltage(-10V~10V) to screen scale(0~171 Height)
        If Y <= 0 Then
        Y = 1
        End If
        If Y >= 171 Then
        Y = 170
        End If
        
        If last_y <> -1 Then
            picScreen.Line (last_x, last_y)-(X, Y), shpColor(0).BackColor
        End If
        last_x = X
        last_y = Y
    Next
   
   
End Sub

Private Sub Form_Unload(Cancel As Integer)
  Dim result As Long
   If card >= 0 Then
      Release_Card (card)
   End If
End Sub

Private Sub Label7_Click()

End Sub

Private Sub mnuExit_Click()
  If card >= 0 Then Release_Card (card)
  End
End Sub

Private Sub scrollView_Change()
  Dim idx As Long
  idx = CLng(scrollView.Value) * DISP_COUNT
  ShowData idx Mod count1, Min(count1 - idx, DISP_COUNT)
End Sub
Private Sub DrawTrigLevel(ByVal old_level As Integer, ByVal level As Integer)
    Dim w As Long, h As Long
    Dim Y As Long

    w = picScreen.ScaleWidth
    h = picScreen.ScaleHeight
    If old_level <> -1 Then
        Y = h * (255 - old_level) / 255
        picScreen.Line (0, Y)-(w, Y), &H0
    End If
    Y = h * (255 - level) / 255
    picScreen.Line (0, Y)-(w, Y), &H909090
End Sub

Private Function Min(ByVal v1 As Long, ByVal v2 As Long) As Long
  If v1 < v2 Then
    Min = v1
  Else
    Min = v2
  End If
End Function



