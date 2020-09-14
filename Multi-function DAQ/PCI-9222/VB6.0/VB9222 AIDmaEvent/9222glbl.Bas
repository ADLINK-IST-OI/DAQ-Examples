Attribute VB_Name = "Module1"
Option Explicit

Declare Function BitBlt Lib "GDI32" (ByVal hDestDC As Long, ByVal X As Long, ByVal Y As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal hSrcDC As Long, ByVal XSrc As Long, ByVal YSrc As Long, ByVal dwRop As Long) As Long

Global Const SRCCOPY = &HCC0020 ' (DWORD) dest = source
Global card As Integer
Global card_number As Integer
Global card_type As Integer

Public Function AI_END_CALLBACK() As Long
     Dim result As Integer
     Dim AccessCnt As Long
      'MsgBox "AI_END_CALLBACK"
    result = AI_AsyncClear(card, AccessCnt)
    'do what you want to do with data here...
End Function
