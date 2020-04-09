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
   Begin VB.CommandButton btnDOWrite 
      Caption         =   "DO_WriteLine 0"
      Height          =   615
      Index           =   1
      Left            =   120
      TabIndex        =   5
      Top             =   2520
      Width           =   1695
   End
   Begin VB.CommandButton btnDOWrite 
      Caption         =   "DO_WriteLine 1"
      Height          =   615
      Index           =   0
      Left            =   120
      TabIndex        =   4
      Top             =   1800
      Width           =   1695
   End
   Begin VB.TextBox edCardNum 
      Height          =   375
      Left            =   1920
      TabIndex        =   3
      Text            =   "Text1"
      Top             =   360
      Width           =   1215
   End
   Begin VB.TextBox edAIValue 
      Height          =   375
      Left            =   1920
      TabIndex        =   2
      Text            =   "Text1"
      Top             =   1200
      Width           =   1215
   End
   Begin VB.CommandButton btnDIRead 
      Caption         =   "DI_ReadLine"
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
Dim DIValue As Integer
Dim DILine As Integer
Dim DOLine As Integer
Dim DOValue As Integer

Private Sub btnDIRead_Click()
    
    DILine = 0
    DI_ReadLine CardNum, 0, DILine, DIValue
    edAIValue.Text = DIValue
    
End Sub

Private Sub btnDOWrite_Click(Index As Integer)

    DOLine = 0
    If Index = 0 Then
        DO_WriteLine CardNum, 0, DOLine, 1
    Else
        DO_WriteLine CardNum, 0, DOLine, 0
    End If
    
End Sub

Private Sub btnRegister_Click()
    
    CardNum = Register_Card(PCI_9524, 0)
    edCardNum.Text = CardNum
    
End Sub

Private Sub Form_Unload(Cancel As Integer)
    
    If CardNum >= 0 Then
        Release_Card (CardNum)
    End If
    
End Sub
