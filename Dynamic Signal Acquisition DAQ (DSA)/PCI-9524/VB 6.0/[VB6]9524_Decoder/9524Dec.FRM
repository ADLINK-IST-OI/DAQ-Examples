VERSION 5.00
Begin VB.Form Dec9524 
   Appearance      =   0  'Flat
   AutoRedraw      =   -1  'True
   BackColor       =   &H00C0C0C0&
   Caption         =   "9524 Decoder"
   ClientHeight    =   2655
   ClientLeft      =   1170
   ClientTop       =   525
   ClientWidth     =   3870
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
   ScaleHeight     =   2655
   ScaleWidth      =   3870
   Begin VB.CommandButton butStopRead 
      Caption         =   "Stop"
      Height          =   495
      Left            =   120
      TabIndex        =   3
      Top             =   1920
      Width           =   3615
   End
   Begin VB.CommandButton butStartRead 
      Caption         =   "Start"
      Height          =   495
      Left            =   120
      TabIndex        =   2
      Top             =   1320
      Width           =   3615
   End
   Begin VB.TextBox textDevalue 
      Height          =   375
      Left            =   1680
      TabIndex        =   1
      Text            =   "Read Val"
      Top             =   600
      Width           =   2055
   End
   Begin VB.Label Labreadval 
      Caption         =   "Read Value"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   600
      Width           =   1455
   End
End
Attribute VB_Name = "Dec9524"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Dim Value As Long
Dim result As Long
Dim flag As Integer

Dim oldvalue As Long
Dim newvalue As Long





Private Sub butStartRead_Click()
flag = 0
butStartRead.Enabled = False
Do While flag <> 1
result = GPTC_Read(card, GCtr, Value)
  If result <> 0 Then
   MsgBox "Read Error"
     End
  End If
  
     
textDevalue = Value

DoEvents
Loop
End Sub

Private Sub butStopRead_Click()
flag = 1
butStartRead.Enabled = True
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

result = GPTC_Read(card, GCtr, Value)
oldvalue = Value

End Sub




