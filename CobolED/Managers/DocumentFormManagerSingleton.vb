'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  DocumentFormManagerSingleton.vb                         --
'--                                                                           --
'--  Author(s)     :  Yin Xuebin, Chen Qinghua, He Hui (Three Swordsmen Team) --
'--                                                                           --
'--  NameSpace     :  CobolED.Managers                                        --
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

Imports CobolED.Forms
Imports CobolED.Managers.Manager
Imports CobolEDCore.Document
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Interfaces.Editor
Imports CobolEDCore.Infos.Editor
Imports CobolEDCore.EventArgs
Imports CobolEDCore.Enums

Namespace Managers

    Public Class DocumentFormManagerSingleton
        Private Const DIRTY_FLAG As String = "*"
        Private Const STATUSBAR_ROW_TEXT As String = "{0} Row"
        Private Const STATUSBAR_PHYSICALCOL_TEXT As String = "{0} Phys.Col"
        Private Const STATUSBAR_COL_TEXT As String = "{0} Col"
        Private Const STATUSBAR_INSERT_TEXT As String = "Insert"
        Private Const STATUSBAR_OVERWRITE_TEXT As String = "Letter"
        Private Const SAVE_DIALOG_TITLE As String = "File Close"

        Private Shared _documentFormManager As DocumentFormManagerSingleton
        Private _unGoToStack As Stack(Of CaretPositionInfo)
        Private _reGoToStack As Stack(Of CaretPositionInfo)
        Private _currentPos As CaretPositionInfo

        Private Sub New()
            _unGoToStack = New Stack(Of CaretPositionInfo)
            _reGoToStack = New Stack(Of CaretPositionInfo)
            _currentPos = Nothing
        End Sub

        Public Shared ReadOnly Property DocumentFormManager() As DocumentFormManagerSingleton
            Get
                If _documentFormManager Is Nothing Then
                    _documentFormManager = New DocumentFormManagerSingleton
                End If
                Return _documentFormManager
            End Get
        End Property

        Public ReadOnly Property CanUnGoTo() As Boolean
            Get
                If _unGoToStack.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public ReadOnly Property CanReGoTo() As Boolean
            Get
                If _reGoToStack.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public ReadOnly Property CurrentDocumentForm() As DocumentForm
            Get
                If TypeOf CobolEDMainForm.ActiveMdiChild Is DocumentForm Then
                    Return CobolEDMainForm.ActiveMdiChild
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property DocumentForms(ByVal documentFileName As String) As DocumentForm
            Get
                For Each docForm As DocumentForm In CobolEDMainForm.MdiChildren
                    If docForm.Name = documentFileName Then
                        Return docForm
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property DocumentForms() As List(Of DocumentForm)
            Get
                Dim result As List(Of DocumentForm)
                result = New List(Of DocumentForm)
                For Each documentForm As DocumentForm In CobolEDMainForm.MdiChildren
                    result.Add(documentForm)
                Next
                Return result
            End Get
        End Property

        Public Sub Rename(ByVal oldName As String, ByVal newName As String)
            For Each docForm As DocumentForm In CobolEDMainForm.MdiChildren
                If docForm.Name = oldName Then
                    docForm.Name = newName
                    docForm.Text = newName
                End If
            Next
        End Sub

        Public Sub WindowCloseAll()
            For Each documentForm As DocumentForm In DocumentForms
                RemoveDocumentForm(documentForm)
            Next
            Array.Clear(CobolEDMainForm.MdiChildren, 0, CobolEDMainForm.MdiChildren.Length)
        End Sub

        Public Sub RemoveDocumentForm(ByVal documentForm As DocumentForm)
            If documentForm IsNot Nothing Then
                MemberManager.RemoveDocumentForm(documentForm)
                documentForm.Close()
                RemoveHandler documentForm.Document.DocumentDirty, AddressOf OnDocumentDirty
                RemoveHandler documentForm.CobolEDEditor.CaretPositionGoTo, AddressOf PushCaretPosition
                RemoveHandler documentForm.FormClosing, AddressOf OnDoucmentFormClose
                RemoveHandler documentForm.CobolEDEditor.CaretPositionChanged, AddressOf OnCaretPositionChanged
                RemoveHandler documentForm.CobolEDEditor.CaretStatusChanged, AddressOf OnCaretStatusChanged
                RemoveHandler documentForm.Activated, AddressOf OnDocumentFormActived
            End If
        End Sub

        Public Sub ReGoTo()
            Dim targetPosInfo As CaretPositionInfo
            While _reGoToStack.Count > 0
                targetPosInfo = _reGoToStack.Pop
                For Each docForm As DocumentForm In DocumentForms
                    If docForm.Document.DocumentFileName = targetPosInfo.DocumentFileName Then
                        ActivateDocumentForm(targetPosInfo.DocumentFileName, FormWindowState.Maximized)
                        CurrentDocumentForm.CobolEDEditor.CaretMoveTo(targetPosInfo.Row, targetPosInfo.Col, False)
                        _unGoToStack.Push(_currentPos)
                        _currentPos = targetPosInfo
                        Exit While
                    End If
                Next
            End While
        End Sub

        Public Sub UnGoTo()
            Dim targetPosInfo As CaretPositionInfo
            While _unGoToStack.Count > 0
                targetPosInfo = _unGoToStack.Pop
                For Each docForm As DocumentForm In DocumentForms
                    If docForm.Document.DocumentFileName = targetPosInfo.DocumentFileName Then
                        ActivateDocumentForm(targetPosInfo.DocumentFileName, FormWindowState.Maximized)
                        CurrentDocumentForm.CobolEDEditor.CaretMoveTo(targetPosInfo.Row, targetPosInfo.Col, False)
                        _reGoToStack.Push(_currentPos)
                        _currentPos = targetPosInfo
                        Exit While
                    End If
                Next
            End While

        End Sub

        Public Sub ClearGoToHistory()
            _reGoToStack.Clear()
            _unGoToStack.Clear()
            _currentPos = Nothing
        End Sub

        Public Sub NextDocumentFormActivate()
            Dim i As Integer
            i = DocumentFormManager.DocumentForms.IndexOf(DocumentFormManager.CurrentDocumentForm)
            i += 1
            If i > DocumentFormManager.DocumentForms.Count - 1 Then
                i = 0
            End If
            DocumentFormManager.DocumentForms.Item(i).Activate()
        End Sub

        Public Sub PrevDocumentFormActivate()
            Dim i As Integer
            i = DocumentFormManager.DocumentForms.IndexOf(DocumentFormManager.CurrentDocumentForm)
            i -= 1
            If i < 0 Then
                i = DocumentFormManager.DocumentForms.Count - 1
            End If
            DocumentFormManager.DocumentForms.Item(i).Activate()

        End Sub

        Public Function AddDocumentForm(ByVal document As Document, ByVal cobolEDAnalyzer As ICobolEDAnalyzer) As DocumentForm
            Dim documentForm As DocumentForm
            documentForm = New DocumentForm(EditorManager.CobolEDEditorFactory(document, cobolEDAnalyzer))
            documentForm.Name = document.DocumentFileName
            If document.DocumentDirtyFlag Then
                documentForm.Text = document.DocumentFileName & DIRTY_FLAG
            Else
                documentForm.Text = document.DocumentFileName
            End If
            documentForm.CobolEDEditor.SetContextMenuStrip(MenuManager.EditorContextMenu)
            documentForm.MdiParent = CobolEDMainForm
            AddHandler document.DocumentDirty, AddressOf OnDocumentDirty
            AddHandler documentForm.CobolEDEditor.CaretPositionGoTo, AddressOf PushCaretPosition
            AddHandler documentForm.FormClosing, AddressOf OnDoucmentFormClose
            AddHandler documentForm.CobolEDEditor.CaretPositionChanged, AddressOf OnCaretPositionChanged
            AddHandler documentForm.CobolEDEditor.CaretStatusChanged, AddressOf OnCaretStatusChanged
            AddHandler documentForm.Activated, AddressOf OnDocumentFormActived

            MemberManager.AddDocumentForm(documentForm)

            Return documentForm
        End Function

        Public Function ActivateDocumentForm(ByVal documentFileName As String, ByVal windowState As FormWindowState) As DocumentForm
            Dim wantedForm As DocumentForm
            Dim wantedDocument As Document
            Dim wantedAnalyzer As ICobolEDAnalyzer
            wantedForm = DocumentFormManager.DocumentForms(documentFileName)

            If wantedForm IsNot Nothing Then
            Else
                wantedDocument = DocumentManager.Documents(documentFileName)
                wantedAnalyzer = AnalyzerManager.Analyzers(ProjectManager.ProjectInfo.ProgramInfos(documentFileName).ProgramType)
                If wantedDocument IsNot Nothing Then
                    wantedForm = AddDocumentForm(wantedDocument, wantedAnalyzer)
                End If
            End If

            wantedForm.WindowState = windowState
            wantedForm.Show()
            wantedForm.CobolEDEditor.Focus()
            Return wantedForm
        End Function

        Private Sub OnDocumentDirty(ByVal sender As Object, ByVal e As DocumentDirtyEventArgs)
            Dim document As Document
            Dim documentForm As DocumentForm
            document = DirectCast(sender, Document)
            documentForm = DocumentForms(document.DocumentFileName)
            If documentForm IsNot Nothing AndAlso e.DocumentDirtyFlag Then
                documentForm.Text = document.DocumentFileName & DIRTY_FLAG
            Else
                documentForm.Text = document.DocumentFileName
            End If

        End Sub

        Private Sub PushCaretPosition(ByVal sender As Object, ByVal e As CaretPositionGoToEventArgs)
            If _currentPos IsNot Nothing Then
                If _currentPos.DocumentFileName = e.CaretPositionInfo.DocumentFileName AndAlso _
                  _currentPos.Col = e.CaretPositionInfo.Col AndAlso _
                  _currentPos.Row = e.CaretPositionInfo.Row Then
                Else
                    _unGoToStack.Push(_currentPos)
                    _currentPos = e.CaretPositionInfo
                End If
            Else
                _currentPos = e.CaretPositionInfo
            End If
        End Sub

        Private Sub OnDoucmentFormClose(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
            Dim documentForm As DocumentForm
            Dim doc As Document
            documentForm = DirectCast(sender, DocumentForm)
            doc = documentForm.Document
            If doc.DocumentDirtyFlag AndAlso _
                Common.Message.ShowMessage(My.Resources.CED002_017_Q, doc.DocumentFileName) = DialogResult.Yes Then
                doc.Save()
            Else
                If ProjectManager.ProjectInfo IsNot Nothing AndAlso ProjectManager.ProjectInfo.ProgramInfos(doc.DocumentFileName) IsNot Nothing Then
                    If DocumentManager.Reload(doc.DocumentFileName) = False Then
                        Common.Message.ShowMessage(My.Resources.CED002_018_E)
                    End If
                End If

            End If
        End Sub

        Private Sub OnCaretPositionChanged(ByVal sender As Object, ByVal e As CaretPositionChangedEventArgs)
            Dim currentDocumentForm As DocumentForm
            Dim currentLine As String
            Dim physicalCol As Integer

            currentDocumentForm = DocumentFormManager.CurrentDocumentForm
            If currentDocumentForm IsNot Nothing Then
                currentLine = currentDocumentForm.Document.DocumentLineString(e.row)
                physicalCol = Common.StringTransaction.GetByteCountFromIndex(currentLine, e.col)
            Else
                physicalCol = 0
            End If
            SetStatusBarRow(e.row + 1)
            SetStatusBarPhysicalCol(physicalCol + 1)
            SetStatusBarCol(e.col + 1)
        End Sub

        Private Sub OnCaretStatusChanged(ByVal sender As Object, ByVal e As CaretStatusChangedEventArgs)
            SetStatusBarCaretStatus(e.CaretStatus)
        End Sub

        Private Sub OnDocumentFormActived(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim documentForm As DocumentForm
            Dim cobolEDEditor As ICobolEDEditor
            Dim currentLine As String
            Dim physicalCol As Integer

            documentForm = DirectCast(sender, DocumentForm)
            cobolEDEditor = documentForm.CobolEDEditor
            currentLine = documentForm.Document.DocumentLineString(cobolEDEditor.CaretPhysicalPosition.Row)
            physicalCol = Common.StringTransaction.GetByteCountFromIndex(currentLine, cobolEDEditor.CaretPhysicalPosition.Col)

            SetStatusBarRow(cobolEDEditor.CaretPhysicalPosition.Row + 1)
            SetStatusBarPhysicalCol(physicalCol + 1)
            SetStatusBarCol(cobolEDEditor.CaretPhysicalPosition.Col + 1)
            SetStatusBarCaretStatus(cobolEDEditor.CaretStatus)

        End Sub

        Private Sub SetStatusBarRow(ByVal row As Integer)
            CobolEDMainForm._statusBarRow.Text = String.Format(STATUSBAR_ROW_TEXT, row)
        End Sub

        Private Sub SetStatusBarPhysicalCol(ByVal col As Integer)
            CobolEDMainForm._statusBarPhysicalCol.Text = String.Format(STATUSBAR_PHYSICALCOL_TEXT, col)
        End Sub

        Private Sub SetStatusBarCol(ByVal col As Integer)
            CobolEDMainForm._statusBarCol.Text = String.Format(STATUSBAR_COL_TEXT, col)
        End Sub

        Private Sub SetStatusBarCaretStatus(ByVal status As CaretStatusEnum)
            Select Case status
                Case CaretStatusEnum.Insert
                    CobolEDMainForm._statusBarCaretStatus.Text = STATUSBAR_INSERT_TEXT
                Case CaretStatusEnum.OverWrite
                    CobolEDMainForm._statusBarCaretStatus.Text = STATUSBAR_OVERWRITE_TEXT
                Case Else
                    CobolEDMainForm._statusBarCaretStatus.Text = String.Empty
            End Select
        End Sub

    End Class

End Namespace