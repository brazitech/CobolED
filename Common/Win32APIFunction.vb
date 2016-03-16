'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  Win32APIFunction.vb                                     --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  Common                                                  --
'--                                                                           --
'--  Project       :  Common                                                  --
'--                                                                           --
'--  Solution      :  NVSDI CobolED                             --
'--                                                                           --
'--  Creation Date :  2007/04/03                                              --
'-------------------------------------------------------------------------------
'--  Modifications :                                                          --
'--                                                                           --
'--                                                                           --
'--                                                                           --
'-------------------------------------------------------------------------------
'-- Copyright(C) 2016, NVSDI, Brazil                         --
'--                                                                           --
'-- This software is released under the GNU General Public License            --
'-------------------------------------------------------------------------------

Imports System.Runtime.InteropServices

Public Class Win32APIFunction

    Private Sub New()
    End Sub
    
#Region "Structure"

    Public Structure Rect
        Dim left As Integer
        Dim top As Integer
        Dim right As Integer
        Dim bottom As Integer
    End Structure

    Public Structure Point
        Dim x As Integer
        Dim y As Integer
    End Structure

    Public Structure COMPOSITIONFORM
        Dim dwStyle As Integer
        Dim ptCurrentPos As Point
        Dim rcArea As Rect
    End Structure

    Public Structure RGB
        Dim red As Byte
        Dim green As Byte
        Dim blue As Byte
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Class OpenFileName
        Public nStructSize As Integer = 0
        Public ptrOwner As IntPtr = IntPtr.Zero
        Public hInstance As Integer = 0
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public sFilter As String = Nothing
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public sCustomFilter As String = Nothing
        Public nMaxCustFilter As Integer = 0
        Public nFilterIndex As Integer = 0
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public sFile As String = Nothing
        Public nMaxFile As Integer = 0
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public sFileTitle As String = Nothing
        Public nMaxFileTitle As Integer = 0
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public sInitialDir As String = Nothing
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public sTitle As String = Nothing
        Public nFlags As Integer = 0
        Public nFileOffset As Short = 0
        Public nFileExt As Short = 0
        Public sDefExt As String = Nothing
        Public ptrCustData As IntPtr = IntPtr.Zero
        Public ofnHook As OFNHookProc
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public sTemplateName As String = Nothing
        Public ptrReserved As IntPtr = IntPtr.Zero
        Public nReserved As Integer = 0
        Public nFlagsEx As Integer = 0
    End Class

    Public Structure LHDR
        Public hwndFrom As IntPtr
        Public idFrom As Integer
        Public code As Integer
    End Structure

#End Region

#Region "Const"

    Public Const WM_GETDLGCODE As Integer = &H87
    Public Const DLGC_WANTALLKEYS As Integer = &H4
    Public Const WM_IME_STARTCOMPOSITION As Integer = &H10D
    Public Const WM_IME_ENDCOMPOSITION As Integer = &H10E
    Public Const CDM_GETFILEPATH As Integer = &H400 + 100 + 1

    Public Const WM_INITDIALOG As Long = &H110
    Public Const WM_NOTIFY As Long = &H4E

    Public Const OFN_CREATEPROMPT As Long = &H2000
    Public Const OFN_ENABLEHOOK As Long = &H20
    Public Const OFN_EXPLORER As Long = &H80000
    Public Const OFN_FILEMUSTEXIST As Long = &H1000
    Public Const OFN_HIDEREADONLY As Long = &H4
    Public Const OFN_LONGNAMES As Long = &H200000
    Public Const OFN_NOCHANGEDIR As Long = &H8
    Public Const OFN_NODEREFERENCELINKS As Long = &H100000
    Public Const OFN_PATHMUSTEXIST As Long = &H800
    Public Const OFS_MAXPATHNAME As Long = 260

    Public Const CFS_POINT As Integer = &H2
    Public Const SELECT_CHANGED As Integer = -602

#End Region

#Region "Declare Function"

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function ScrollWindow(ByVal hwnd As IntPtr, ByVal cx As Integer, ByVal cy As Integer, ByRef rectScroll As Rect, ByRef rectClip As Rect) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function CreateCaret(ByVal hwnd As IntPtr, ByVal hbm As IntPtr, ByVal width As Integer, ByVal height As Integer) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function DestroyCaret() As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function SetCaretPos(ByVal x As Integer, ByVal y As Integer) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function ShowCaret(ByVal hwnd As IntPtr) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function HideCaret(ByVal hwnd As IntPtr) As Integer
    End Function

    <DllImport("Imm32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function ImmGetContext(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("Imm32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function ImmSetCompositionWindow(ByVal hIMC As IntPtr, ByRef lpCompForm As COMPOSITIONFORM) As Integer
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function GetParent(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal wMsg As UInt32, ByVal wParam As UInt32, ByVal lParam As IntPtr) As UInt32
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef rc As Rect) As Long
    End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal repaint As Boolean) As Boolean
    End Function

    <DllImport("ComDlg32.dll", CharSet:=CharSet.Auto)> _
     Public Shared Function GetOpenFileName(ByVal ofn As OpenFileName) As Boolean
    End Function

#End Region

#Region "Other"

    Delegate Function OFNHookProc(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

#End Region

End Class
