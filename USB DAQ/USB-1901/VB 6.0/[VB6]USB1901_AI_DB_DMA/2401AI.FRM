VERSION 5.00
Begin VB.Form AI2401 
   Appearance      =   0  'Flat
   AutoRedraw      =   -1  'True
   BackColor       =   &H00C0C0C0&
   Caption         =   "2401AI"
   ClientHeight    =   5010
   ClientLeft      =   11325
   ClientTop       =   5025
   ClientWidth     =   7065
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
   ScaleHeight     =   5010
   ScaleWidth      =   7065
   Begin VB.CommandButton btn_stop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   6120
      TabIndex        =   20
      Top             =   4440
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Left            =   1680
      Top             =   4560
   End
   Begin VB.Frame framsample 
      Appearance      =   0  'Flat
      BackColor       =   &H00C0C0C0&
      Caption         =   "Sampling Rate"
      ForeColor       =   &H00FF0000&
      Height          =   615
      Left            =   2040
      TabIndex        =   17
      Top             =   3840
      Width           =   1575
      Begin VB.ComboBox cobsamplerate 
         Appearance      =   0  'Flat
         Enabled         =   0   'False
         Height          =   315
         Left            =   120
         TabIndex        =   18
         Text            =   "cobSampleRate"
         Top             =   240
         Width           =   1395
      End
   End
   Begin VB.Frame dmaFrame 
      Appearance      =   0  'Flat
      BackColor       =   &H00C0C0C0&
      Caption         =   "Input(A/D)"
      ForeColor       =   &H00FF0000&
      Height          =   3735
      Left            =   120
      TabIndex        =   6
      Top             =   0
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
      Left            =   4080
      TabIndex        =   3
      Top             =   3840
      Width           =   1695
      Begin VB.ComboBox cobChn 
         Appearance      =   0  'Flat
         Height          =   315
         Left            =   120
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
      Left            =   6120
      TabIndex        =   1
      Top             =   3960
      Width           =   765
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
      Width           =   1815
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
   Begin VB.Label Label1 
      Caption         =   "Hz"
      Height          =   255
      Left            =   3600
      TabIndex        =   19
      Top             =   4080
      Width           =   255
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
Attribute VB_Name = "AI2401"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Const DISP_COUNT = 1024
Dim DISP_COUNT As Integer
Dim gnADChn As Long
Dim gnCount As Long
Dim gnClkDiv As Integer
Dim gnClkDiv2 As Integer
Dim count1 As Long
Dim ch_cnt As Integer
Dim gnBuffer() As Integer 'As Long '
Dim dma_size As Long
Dim range As Integer
Dim ConfigCtrl As Integer
Dim TrigCtrl As Integer
Dim Mode As Integer
Dim TimeOut As Long
Dim BufID1 As Integer
Dim voltageArray() As Double
Dim sample_rate As Double
'Dim ActualRate As Double
Dim wChanCfg As Integer

Private Sub btn_stop_Click()
 Dim Err As Integer
  Dim AccessCnt As Long

   Err = UD_AI_AsyncClear(card, AccessCnt)
   Timer1.Enabled = False
    btnStart.Enabled = True
End Sub

Private Sub btnStart_Click()
  Dim result As Long
  Dim Status As Byte
  Dim i As Integer
  Dim bHalfReady, fStop As Byte
 
  dma_size = cobDataSize.Text
  DISP_COUNT = cobDataSize.Text
  
  
  DISP_COUNT = DISP_COUNT / 2
  
  range = AD_B_10_V
  sample_rate = cobsamplerate.Text  'set up sampling rate'
  'TrigCtrl = P2401_AI_TRGSRC_SOFT Or P2401_AI_TRGMOD_POST
  wChanCfg = P1902_AI_Differential
  Dim dwInvCnt As Long
  btnStart.Enabled = False
  
    
  ch_cnt = cobChn.ListIndex + 1
  'ch_cnt = 4
  'Select Case cobChn.ListIndex  'Select AI CH0~Ch3'
   ' Case 0
    ' ch_cnt = 0
    'Case 1
    ' ch_cnt = 1
   'Case 2
   ' ch_cnt = 2
   'Case 3
   '  ch_cnt = 3
   'End Select
    sample_rate = 250000 / ch_cnt
    
   result = UD_AI_1902_Config(card, wChanCfg, 48, 0, 1, 0)
   
    Dim Chans() As Integer
    ReDim Chans(ch_cnt - 1)
   Dim AdRanges() As Integer
   ReDim AdRanges(ch_cnt - 1)
   ReDim gnBuffer((ch_cnt - 1) * dma_size)
   
   For i = 0 To ch_cnt - 1
     Chans(i) = i
     AdRanges(i) = AD_B_10_V
   Next
        
   result = UD_AI_AsyncDblBufferMode(card, 1)
   Status = 0
   dwInvCnt = 80000000 / sample_rate
    'result = UD_AI_1902_CounterInterval(card, dwInvCnt * ch_cnt, dwInvCnt)
     result = UD_AI_1902_CounterInterval(card, 2560, 320)
    If result <> 0 Then
        MsgBox "UD_AI_1902_CounterInterval Failed"
        End
     End If
        
    'result = UD_AI_ContReadChannel(card, 0, range, gnBuffer(0), dma_size, sample_rate, ASYNCH_OP)
   result = UD_AI_ContReadMultiChannels(card, ch_cnt, Chans(0), AdRanges(0), gnBuffer(0), dma_size * ch_cnt, sample_rate, ASYNCH_OP)
   If result <> 0 Then
     MsgBox "Continuous AI Failed"
     End
   End If
   Timer1.Interval = 50
    Timer1.Enabled = True
    
  'While Status = 0
  '     result = UD_AI_AsyncCheck(card, Status, count1)
  'Wend
  'result = UD_AI_AsyncClear(card, count1)
  'scrollView.Value = 0
  'scrollView.Max = Fix((count1 - 1) / DISP_COUNT)
  'ShowData 0, DISP_COUNT
  'ShowData 0, Min(count1, DISP_COUNT)
  'btnStart.Enabled = True
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
       
    cobDataSize.AddItem "1024"
    cobDataSize.AddItem "2048"
    cobDataSize.ListIndex = 0
    
    cobsamplerate.AddItem "250000"
    cobsamplerate.AddItem "12800"
    cobsamplerate.AddItem "50000"
    cobsamplerate.ListIndex = 0
    cobChn.AddItem "CH0"
    cobChn.AddItem "CH1"
    cobChn.AddItem "CH2"
    cobChn.AddItem "CH3"
    cobChn.AddItem "CH4"
    cobChn.AddItem "CH5"
    cobChn.AddItem "CH6"
    cobChn.AddItem "CH7"
    cobChn.AddItem "CH8"
    cobChn.AddItem "CH9"
    cobChn.AddItem "CH10"
    cobChn.AddItem "CH11"
    cobChn.AddItem "CH12"
    cobChn.AddItem "CH13"
    cobChn.AddItem "CH14"
    cobChn.AddItem "CH15"
    cobChn.ListIndex = 0
    dma_size = 0
End Sub


Private Sub ShowData(ByVal startidx As Long, ByVal acq_count As Long)
    Dim i, Cur_Channel As Integer
    Dim k As Long, n As Long
    Dim w As Long, h As Long
    Dim X As Long, Y As Long
    Dim last_x As Long, last_y As Long
    Dim samp As Long, trig_pos As Long
    Dim data As Double
    ch_cnt = cobChn.ListIndex + 1
    'ReDim gnBuffer(dma_size * ch_cnt)
    ReDim voltageArray(dma_size * ch_cnt - 1)
    picScreen.Cls
    DrawTrigLevel -1, trigLevel
    lblLeft.Caption = CStr(CLng(scrollView.Value) * DISP_COUNT)
    lblRight.Caption = CStr(CLng(lblLeft) + DISP_COUNT - 1)
    w = picScreen.ScaleWidth
    h = picScreen.ScaleHeight
    result = UD_AI_ContVScale(card, range, gnBuffer(0), voltageArray(0), (dma_size * ch_cnt) / 2) 'change to voltage scale
   
   Dim color(16)
   color(0) = RGB(255, 0, 0)
   color(1) = RGB(0, 255, 0)
   color(2) = RGB(0, 0, 255)
   color(3) = RGB(255, 255, 255)
   color(4) = RGB(125, 0, 0)
   color(5) = RGB(0, 125, 0)
   color(6) = RGB(0, 0, 125)
   color(7) = RGB(125, 125, 125)
   color(8) = RGB(0, 255, 255)
   color(9) = RGB(255, 0, 255)
   color(10) = RGB(255, 255, 0)
   color(11) = RGB(0, 125, 125)
   color(12) = RGB(125, 0, 125)
   color(13) = RGB(125, 125, 0)
   color(14) = RGB(100, 100, 100)
   color(15) = RGB(200, 200, 200)
   
   For Cur_Channel = 0 To ch_cnt - 1
      last_x = -1
      last_y = -1
    For i = 0 To (acq_count) - 1
        X = (i * w) / (DISP_COUNT - 1)
        'samp = gnBuffer(i)
        data = voltageArray((i * ch_cnt) + Cur_Channel)
        Y = CInt(-(171 * (data - 10) / 20)) ''change voltage(-10V~10V) to screen scale(0~171 Height)
        If Y <= 0 Then
        Y = 1
        End If
        If Y >= 171 Then
        Y = 170
        End If
        
        If last_y <> -1 Then
            picScreen.Line (last_x, last_y)-(X, Y), color(Cur_Channel) 'shpColor(0).BackColor
        End If
        last_x = X
        last_y = Y
    Next
   Next
   
   
End Sub

Private Sub Form_Unload(Cancel As Integer)
  Dim result As Long
   If card >= 0 Then
      UD_Release_Card (card)
   End If
End Sub

Private Sub mnuExit_Click()
  If card >= 0 Then UD_Release_Card (card)
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

Private Sub Timer1_Timer()
 Dim Err As Integer
        Dim bHalfReady As Byte
        Dim fStop As Byte

        '//Check half-buffer ready
        Err = UD_AI_AsyncDblBufferHalfReady(card, bHalfReady, fStop)

        If bHalfReady = 1 Then ' half-buffer ready
            Err = UD_AI_AsyncDblBufferTransfer(card, gnBuffer(0))
            If Err <> 0 Then
                MsgBox ("UD_AI_AsyncDblBufferTransfer error:" + Str(Err))
                Timer1.Enabled = False

                Exit Sub
            End If
            scrollView.Value = 0
            scrollView.Max = Fix((count1 - 1) / DISP_COUNT)
            ShowData 0, DISP_COUNT
        End If

End Sub
