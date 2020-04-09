VERSION 5.00
Begin VB.Form plsgenc9524 
   Appearance      =   0  'Flat
   AutoRedraw      =   -1  'True
   BackColor       =   &H00C0C0C0&
   Caption         =   "9524 PulseGen"
   ClientHeight    =   5310
   ClientLeft      =   1170
   ClientTop       =   525
   ClientWidth     =   3135
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
   ScaleHeight     =   5310
   ScaleWidth      =   3135
   Begin VB.TextBox Textcount2 
      Height          =   285
      Left            =   1680
      Locked          =   -1  'True
      TabIndex        =   15
      Text            =   "Count"
      Top             =   2520
      Width           =   1215
   End
   Begin VB.TextBox Textcount1 
      Height          =   285
      Left            =   120
      Locked          =   -1  'True
      TabIndex        =   14
      Text            =   "Count"
      Top             =   2520
      Width           =   1095
   End
   Begin VB.OptionButton OptionCCW 
      Caption         =   "CCW"
      Height          =   495
      Left            =   1680
      TabIndex        =   11
      Top             =   840
      Width           =   1335
   End
   Begin VB.OptionButton OptionCW 
      Caption         =   "CW"
      Height          =   495
      Left            =   120
      TabIndex        =   10
      Top             =   840
      Width           =   1455
   End
   Begin VB.TextBox textTargetPluse 
      Height          =   375
      Left            =   120
      TabIndex        =   9
      Text            =   "Target Pluse"
      Top             =   1920
      Width           =   1455
   End
   Begin VB.HScrollBar HScrollpulseOn 
      Height          =   255
      Left            =   1560
      Max             =   20
      Min             =   1
      TabIndex        =   7
      Top             =   3360
      Value           =   1
      Width           =   1455
   End
   Begin VB.HScrollBar HScrollpulseOff 
      Height          =   255
      Left            =   120
      Max             =   20
      Min             =   1
      TabIndex        =   6
      Top             =   3360
      Value           =   1
      Width           =   1335
   End
   Begin VB.OptionButton OptionDirR 
      Caption         =   "OUT/DIR +"
      Height          =   495
      Left            =   1680
      TabIndex        =   5
      Top             =   120
      Width           =   1335
   End
   Begin VB.OptionButton OptionDirF 
      Caption         =   "OUT/DIR -"
      Height          =   495
      Left            =   120
      TabIndex        =   4
      Top             =   120
      Width           =   1455
   End
   Begin VB.CommandButton butStopRead 
      Caption         =   "Stop"
      Height          =   495
      Left            =   120
      TabIndex        =   3
      Top             =   4560
      Width           =   2895
   End
   Begin VB.CommandButton butStartRead 
      Caption         =   "Start"
      Height          =   495
      Left            =   120
      TabIndex        =   2
      Top             =   3840
      Width           =   2895
   End
   Begin VB.TextBox textDevalue 
      Height          =   375
      Left            =   1680
      Locked          =   -1  'True
      TabIndex        =   1
      Text            =   "Read Val"
      Top             =   1920
      Width           =   1335
   End
   Begin VB.Label Label3 
      Caption         =   "DurationCount"
      Height          =   255
      Left            =   1680
      TabIndex        =   13
      Top             =   3000
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "DelayCount"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   3000
      Width           =   1215
   End
   Begin VB.Line Line4 
      X1              =   3000
      X2              =   3000
      Y1              =   2880
      Y2              =   2400
   End
   Begin VB.Line Line3 
      X1              =   1560
      X2              =   3000
      Y1              =   2400
      Y2              =   2400
   End
   Begin VB.Line Line2 
      X1              =   1560
      X2              =   1560
      Y1              =   2400
      Y2              =   2880
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   1560
      Y1              =   2880
      Y2              =   2880
   End
   Begin VB.Label Label2 
      Caption         =   "Input Target Pluse"
      Height          =   375
      Left            =   120
      TabIndex        =   8
      Top             =   1440
      Width           =   1455
   End
   Begin VB.Label Labreadval 
      Caption         =   "Read Pluse"
      Height          =   375
      Left            =   1680
      TabIndex        =   0
      Top             =   1440
      Width           =   1335
   End
End
Attribute VB_Name = "plsgenc9524"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Dim Value As Long
Dim result As Long
Dim flag As Integer
Dim PulseValue As Long
Dim PulseLength As Long
Dim PulseGenNum As Long


Private Sub butStartRead_Click()
flag = 0
butStartRead.Enabled = False
PulseLength = CLng(HScrollpulseOn.Value * 1000000)
PulseValue = CLng(HScrollpulseOff.Value * 1000000)
PulseGenNum = CLng(textTargetPluse)
Value = 0
result = GPTC_Setup(card, GCtr, Mode, 0, 0, PulseValue, PulseLength)
  
  If result <> 0 Then
     MsgBox "GPTC_Setup Error"
     End
  End If
  
result = GPTC_9524_PG_Config(card, GCtr, PulseGenNum)
  If result <> 0 Then
     MsgBox "GPTC_9524_PG_Config Error"
     End
  End If
  
result = GPTC_Control(card, GCtr, P9524_CTR_Enable, 1)
  
   If result <> 0 Then
     MsgBox "GPTC_Control Error"
     End
  End If
  
Do While Value <> PulseGenNum
result = GPTC_Read(card, GCtr, Value)
  If result <> 0 Then
   MsgBox "Read Error"
     End
  End If
  
Value = PulseGenNum - Value
textDevalue = Value

DoEvents
Loop
flag = 1
butStartRead.Enabled = True
End Sub

Private Sub butStopRead_Click()
flag = 1
butStartRead.Enabled = True
result = GPTC_Control(card, GCtr, P9524_CTR_Enable, 0)
result = GPTC_Clear(card, GCtr)
End Sub


Private Sub Form_Unload(Cancel As Integer)
flag = 1
butStartRead.Enabled = True
Unload SettingForm
Release_Card (card)
End Sub

Private Sub Form_Load()
SettingForm.Show 1
textDevalue = 0
textTargetPluse = 1
result = GPTC_Read(card, GCtr, Value)
OptionDirF.Value = True
Mode = P9524_PulseGen_OUTDIR_N
PulseGenNum = 1
Textcount2 = HScrollpulseOn.Value * 1000000
Textcount1 = HScrollpulseOff.Value * 1000000
End Sub




Private Sub HScrollpulseOff_Change()
PulseValue = HScrollpulseOff.Value * 1000000
Textcount1 = PulseValue
End Sub

Private Sub HScrollpulseOn_Change()
PulseLength = HScrollpulseOn.Value * 1000000
Textcount2 = PulseLength
End Sub

Private Sub OptionDIR_Click()

End Sub

Private Sub OptionCCW_Click()
Mode = P9524_PulseGen_CCW
OptionCW.Value = False
End Sub

Private Sub OptionCW_Click()
Mode = P9524_PulseGen_CW
OptionCCW.Value = False
End Sub

Private Sub OptionDirF_Click()
Mode = P9524_PulseGen_OUTDIR_N

OptionDirR.Value = False
End Sub

Private Sub OptionDirR_Click()
Mode = P9524_PulseGen_OUTDIR_R

OptionDirF.Value = False
End Sub

