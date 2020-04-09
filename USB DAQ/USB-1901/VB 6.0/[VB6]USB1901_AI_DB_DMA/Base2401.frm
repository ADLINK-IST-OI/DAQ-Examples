VERSION 5.00
Begin VB.Form SettingForm 
   Appearance      =   0  'Flat
   BackColor       =   &H00C0C0C0&
   Caption         =   "Card Setting"
   ClientHeight    =   1410
   ClientLeft      =   2325
   ClientTop       =   2100
   ClientWidth     =   2835
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   8.25
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   LinkTopic       =   "Form2"
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   1410
   ScaleWidth      =   2835
   Begin VB.CommandButton OKBtn 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Default         =   -1  'True
      Height          =   315
      Left            =   120
      TabIndex        =   0
      Top             =   840
      Width           =   915
   End
   Begin VB.CommandButton CancelBtn 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Cancel          =   -1  'True
      Caption         =   "Cancel"
      Height          =   315
      Left            =   1680
      TabIndex        =   3
      Top             =   840
      Width           =   915
   End
   Begin VB.ComboBox CardNum 
      Appearance      =   0  'Flat
      Height          =   315
      Left            =   1440
      Style           =   2  'Dropdown List
      TabIndex        =   2
      Top             =   120
      Width           =   1215
   End
   Begin VB.Label Label2 
      Appearance      =   0  'Flat
      BackColor       =   &H00C0C0C0&
      Caption         =   "Card Number:"
      ForeColor       =   &H00000000&
      Height          =   195
      Index           =   0
      Left            =   120
      TabIndex        =   1
      Top             =   180
      Width           =   1275
   End
End
Attribute VB_Name = "SettingForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private Sub BaseAddr_Change()

End Sub


Private Sub CancelBtn_Click()
  Unload SettingForm
End Sub

Private Sub Form_Load()
  Dim i As Long
  For i = 0 To 15 Step 1
    CardNum.AddItem i
  Next
  CardNum.ListIndex = 0
 
End Sub

Private Sub OKBtn_Click()
  
  card = -1
  card_number = CardNum.ListIndex
  Dim AvailModules(MAX_USB_DEVICE) As USBDAQ_DEVICE
  
  Err = UD_Device_Scan(wModuleNum, AvailModules(0))
  If Err < 0 Then
     MsgBox "UD_Device_Scan Error"
     End
  End If
    
  card = UD_Register_Card(USB_1902, card_number)
  
  If card < 0 Then
     MsgBox "Register Card Failed"
     End
  End If
  Unload SettingForm
End Sub

