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
   Begin VB.TextBox edDIValue 
      Height          =   375
      Left            =   1680
      TabIndex        =   6
      Top             =   1920
      Width           =   1215
   End
   Begin VB.CommandButton Command2 
      Caption         =   " DO_0 off"
      Height          =   615
      Left            =   360
      TabIndex        =   5
      Top             =   3240
      Width           =   1215
   End
   Begin VB.CommandButton Command1 
      Caption         =   "DO_0 on"
      Height          =   615
      Left            =   360
      TabIndex        =   4
      Top             =   2520
      Width           =   1215
   End
   Begin VB.CommandButton btnReadDI 
      Caption         =   "Read DI_0"
      Height          =   615
      Left            =   360
      TabIndex        =   3
      Top             =   1800
      Width           =   1215
   End
   Begin VB.CommandButton btnConfigDIO 
      Caption         =   "Config DIO"
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
Dim DIValue As Integer

Private Sub btnConfigDIO_Click()

    UD_DIO_2401_Config ModuleNo, GPI0_3_GPO0_1

End Sub

Private Sub btnReadDI_Click()
    
    UD_DI_ReadLine ModuleNo, 0, 0, DIValue
    edDIValue.Text = DIValue

End Sub

Private Sub btnRegister_Click()
    
    ModuleNo = UD_Register_Card(USB_1901, 0)
    edModuleNo.Text = ModuleNo
    
End Sub

Private Sub Command1_Click()

    UD_DO_WriteLine ModuleNo, 0, 0, 1

End Sub

Private Sub Command2_Click()

    UD_DO_WriteLine ModuleNo, 0, 0, 0

End Sub

Private Sub Form_Load()

    ModuleNo = -1
    
End Sub

Private Sub Form_Unload(Cancel As Integer)

    If ModuleNo >= 0 Then
        UD_Release_Card ModuleNo
    End If

End Sub
