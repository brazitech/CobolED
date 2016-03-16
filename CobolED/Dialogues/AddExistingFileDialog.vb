'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  AddExistingFileDialog.vb                                --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
'--                                                                           --
'--  NameSpace     :  CobolED.Dialogues                                       --
'--                                                                           --
'--  Project       :  CobolED                                                 --
'--                                                                           --
'--  Solution      :  NVSDI CobolED                             --
'--                                                                           --
'--  Creation Date :  2016/01/22                                              --
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

Imports System
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports Common.Win32APIFunction
Imports CobolED.Managers.Manager
Imports CobolED

Namespace Dialogues
    Public Class AddExistingFileDialog
        Inherits CommonDialog

        Private Const DLG_FILTER_SEPRATOR_CHAR As Char = ChrW(0)
        Private Const DLG_TITLE As String = "Select an existing file"
        Private Const USERCONTROL_LEFT As Integer = 90
        Private Const DIALOG_HEIGHT As Integer = 420
        Private Const USERCONTROL_TOP As Integer = 350

        Private _hookProcSub As OFNHookProc = AddressOf HookProc
        Private _userControl As UserControls.AnalyzerComboBox
        Private _fileNameBuffer As IntPtr

        Public Sub New()
            MyBase.New()
            _fileNameBuffer = Marshal.AllocCoTaskMem(2 * OFS_MAXPATHNAME)
            _userControl = New UserControls.AnalyzerComboBox()
            For Each analyzer As String In AnalyzerManager.AnalyzerNames
                _userControl.AddItem(analyzer)
            Next
        End Sub

        Public ReadOnly Property SelectedPath()
            Get
                Return Marshal.PtrToStringUni(_fileNameBuffer)
            End Get
        End Property

        Public ReadOnly Property SelectedAnalyzer()
            Get
                Return Me._userControl.Analyzer
            End Get
        End Property

        Public Overrides Sub Reset()

        End Sub

        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Function HookProc(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
            Dim hWndParent As IntPtr
            Dim lhdr As LHDR
            Dim lRetValue As Long

            If (hWnd = IntPtr.Zero) Then
                Return IntPtr.Zero
            End If

            Select Case msg
                Case WM_INITDIALOG
                    hWndParent = GetParent(hWnd)
                    SetParent(_userControl.Handle, hWndParent)
                    Return IntPtr.Zero
                Case WM_NOTIFY
                    FindAndResizePanels(hWnd)
                    lhdr = CType(Marshal.PtrToStructure(lParam, GetType(LHDR)), LHDR)
                    If lhdr.code = SELECT_CHANGED Then
                        hWndParent = GetParent(hWnd)
                        lRetValue = SendMessage(hWndParent, CDM_GETFILEPATH, OFS_MAXPATHNAME, _fileNameBuffer)
                        Dim path As String = Me.SelectedPath
                        If path <> String.Empty Then
                            SetAnalyzerComboBox(path)
                        End If
                    End If
                    Return IntPtr.Zero
                Case Else
                    Return IntPtr.Zero
            End Select

        End Function

        Protected Overrides Function RunDialog(ByVal hwndOwner As System.IntPtr) As Boolean
            Dim ofn As OpenFileName = New OpenFileName()
            Dim zeroBuffer(2 * (OFS_MAXPATHNAME + 1)) As Byte

            For i As Integer = 0 To 2 * (OFS_MAXPATHNAME + 1) - 1
                zeroBuffer(i) = 0
            Next
            Marshal.Copy(zeroBuffer, 0, _fileNameBuffer, 2 * OFS_MAXPATHNAME)

            ofn.nStructSize = Marshal.SizeOf(ofn)
            ofn.ptrOwner = hwndOwner
            ofn.sFilter = SettingManager.SettingInfo.FileFilter.Replace("|", DLG_FILTER_SEPRATOR_CHAR) & DLG_FILTER_SEPRATOR_CHAR
            ofn.sFile = New String(New Char(256) {})
            ofn.nMaxFile = ofn.sFile.Length
            ofn.sFileTitle = New String(New Char(64) {})
            ofn.nMaxFileTitle = ofn.sFileTitle.Length
            ofn.sTitle = DLG_TITLE
            ofn.nFlags = OFN_EXPLORER Or _
            OFN_ENABLEHOOK Or _
            OFN_LONGNAMES Or _
            OFN_NODEREFERENCELINKS Or _
            OFN_CREATEPROMPT Or _
            OFN_HIDEREADONLY Or _
            OFN_FILEMUSTEXIST Or _
            OFN_PATHMUSTEXIST Or _
            OFS_MAXPATHNAME Or _
            OFN_NOCHANGEDIR
            ofn.ofnHook = _hookProcSub

            Return GetOpenFileName(ofn)

        End Function

        Private Sub FindAndResizePanels(ByVal hWnd As IntPtr)

            ' The FileOpenDialog is actually of the parent of the specified window
            Dim hWndParent As IntPtr = GetParent(hWnd)
            Dim rcClient As Rectangle = New Rectangle(0, 0, 0, 0)
            Dim rcContent As Rectangle = New Rectangle(0, 0, 0, 0)
            Dim rc As Rect = New Rect()

            ' Get client rectangle of dialog
            Dim rcTemp As Rect = New Rect()
            GetWindowRect(hWndParent, rcTemp)
            rcClient.X = rcTemp.left
            rcClient.Y = rcTemp.top
            rcClient.Width = rcTemp.right - rcTemp.left
            rcClient.Height = DIALOG_HEIGHT
            MoveWindow(hWndParent, rcClient.X, rcClient.Y, rcClient.Width, rcClient.Height, True)


            ' Position the user-supplied control alongside the content panel
            rcContent.X = USERCONTROL_LEFT
            rcContent.Y = USERCONTROL_TOP
            rcContent.Width = _userControl.Width
            rcContent.Height = _userControl.Height
            MoveWindow(_userControl.Handle, rcContent.X, rcContent.Y, rcContent.Width, rcContent.Height, True)
        End Sub

        Private Sub SetAnalyzerComboBox(ByVal path As String)
            Dim fileExternsion As String
            Dim AnalyzerName As String
            fileExternsion = IO.Path.GetExtension(path)
            AnalyzerName = SettingManager.SettingInfo.FileExtension(fileExternsion)
            If AnalyzerName Is Nothing Then
                Me._userControl.Analyzer = AnalyzerManager.DefaultAnalyzerName
            Else
                Me._userControl.Analyzer = AnalyzerName
            End If
        End Sub

    End Class
End Namespace
