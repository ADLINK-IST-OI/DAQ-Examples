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
   Begin VB.TextBox edAOValue 
      Height          =   375
      Left            =   1920
      TabIndex        =   3
      Text            =   "4"
      Top             =   1200
      Width           =   1215
   End
   Begin VB.CommandButton btnAO 
      Caption         =   "AO VWrite"
      Height          =   615
      Left            =   120
      TabIndex        =   2
      Top             =   960
      Width           =   1695
   End
   Begin VB.TextBox edCardNum 
      Height          =   375
      Left            =   1920
      TabIndex        =   1
      Text            =   "Text1"
      Top             =   360
      Width           =   1215
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

Private Sub btnAO_Click()
    
    AOCH = 0
    
    If IsNumeric(edAOValue.Text) Then
        AOValue = edAOValue.Text
        err = AO_VWriteChannel(CardNum, AOCH, AOValue)
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

