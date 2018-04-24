'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  FindDialog.vb                                           --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
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

Imports System.Windows.Forms
Imports CobolEDCore.Document
Imports CobolED.Managers.Manager
Imports CobolED.Forms
Imports CobolED.Views
Imports CobolEDCore.Infos.SearchEngine
Imports CobolEDCore.Infos.Analyzer

Namespace Dialogues
    Public Class FindDialog

        Private Const TitleFind As String = "Search"
        Private Const TitleReplace As String = "Replace"
        Private _blnIsFind As Boolean        
        Private _intReplacePnlHeight As Integer
        Private _cobolEdMainForm As CobolEDMainForm

        Public Sub New(ByVal cobolEdMainForm As CobolEDMainForm)

            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            ' Add the initialization after the InitializeComponent () call .
            _intReplacePnlHeight = Me._pnlReplace.Height
            _cobolEDMainForm = cobolEDMainForm
            Me.Owner = cobolEDMainForm
        End Sub

#Region "Properties"

        Public Property IsFind() As Boolean
            Get
                Return _blnIsFind
            End Get
            Set(ByVal value As Boolean)
                _blnIsFind = value
                If _blnIsFind Then
                    If Me._pnlReplace.Height <> 0 Then
                        Me._pnlReplace.Height = 0
                        Me._pnlReplace.Visible = False
                        Me.Height -= _intReplacePnlHeight
                        Me._btnReplaceAll.Visible = False
                        Me._btnFindAll.Visible = True
                        Me.Text = TitleFind
                    End If
                Else
                    If Me._pnlReplace.Height = 0 Then
                        Me._pnlReplace.Visible = True
                        Me._pnlReplace.Height = _intReplacePnlHeight
                        Me.Height += _intReplacePnlHeight
                        Me._btnReplaceAll.Visible = True
                        Me._btnFindAll.Visible = False
                        Me.Text = TitleReplace
                    End If
                End If
            End Set
        End Property

        Public ReadOnly Property FindString() As String
            Get
                Return Me._cmbFindString.Text
            End Get
        End Property

        Public ReadOnly Property ReplaceString() As String
            Get
                Return Me._cmbReplaceString.Text
            End Get
        End Property

        Public ReadOnly Property FindHistory() As List(Of String)
            Get
                Dim result As List(Of String)
                result = New List(Of String)
                For Each findWhatItem As String In Me._cmbFindString.Items
                    result.Add(findWhatItem)
                Next
                Return result
            End Get
        End Property

        Public ReadOnly Property MatchCase() As Boolean
            Get
                Return Me._chkFindWithCaps.Checked
            End Get
        End Property

        Public ReadOnly Property MatchWord() As Boolean
            Get
                Return Me._chkFindWithWord.Checked
            End Get
        End Property

        Public ReadOnly Property UpDirection() As Boolean
            Get
                Return Me._chkFindPrev.Checked
            End Get
        End Property

        Public ReadOnly Property FindInNowDoc() As Boolean
            Get
                Return Me._optFindInNowDoc.Checked
            End Get
        End Property

        Public ReadOnly Property FindInOpenDocs() As Boolean
            Get
                Return Me._optFindInOpenDocs.Checked
            End Get
        End Property

        Public ReadOnly Property FindInNowProject() As Boolean
            Get
                Return Me._optFindInNowProject.Checked
            End Get
        End Property

#End Region

#Region "Procedures"

        Public Sub FindNext()
            Dim currentDocumentForm As DocumentForm
            Dim document As Document
            Dim findString As String
            Dim startRow As Integer
            Dim startCol As Integer
            Dim findResult As FindResultInfo
            Dim selectStartPos As Position
            Dim selectEndPos As Position

            currentDocumentForm = DocumentFormManager.CurrentDocumentForm
            If currentDocumentForm IsNot Nothing AndAlso FindHistory.Count > 0 Then
                document = currentDocumentForm.Document
                findString = FindHistory(0)
                startRow = document.Selection.End.Row
                startCol = document.Selection.End.Col
                findResult = SearchManager.CobolEDSearchEngine.GetNextFindString(document, findString, startRow, startCol, MatchCase, MatchWord, False)
                If findResult IsNot Nothing Then
                    selectStartPos = New Position(findResult.FindResultRow, findResult.FindResultCol)
                    selectEndPos = New Position(findResult.FindResultRow, (findResult.FindResultCol + findString.Length))
                    currentDocumentForm.CobolEDEditor.SetSelection(selectStartPos, selectEndPos)
                Else
                    Common.Message.ShowMessage(My.Resources.CED002_020_I)
                End If
            Else
            End If
        End Sub

        Public Sub FindPrev()
            Dim currentDocumentForm As DocumentForm
            Dim document As Document
            Dim findString As String
            Dim startRow As Integer
            Dim startCol As Integer
            Dim findResult As FindResultInfo
            Dim selectStartPos As Position
            Dim selectEndPos As Position

            currentDocumentForm = DocumentFormManager.CurrentDocumentForm
            If currentDocumentForm IsNot Nothing AndAlso FindHistory.Count > 0 Then
                document = currentDocumentForm.Document
                findString = SearchManager.FindDialog.FindHistory(0)
                startRow = document.Selection.Start.Row
                startCol = document.Selection.Start.Col

                findResult = SearchManager.CobolEDSearchEngine.GetNextFindString(document, findString, startRow, startCol, MatchCase, MatchWord, True)
                If findResult IsNot Nothing Then
                    selectStartPos = New Position(findResult.FindResultRow, findResult.FindResultCol)
                    selectEndPos = New Position(findResult.FindResultRow, (findResult.FindResultCol + findString.Length))
                    currentDocumentForm.CobolEDEditor.SetSelection(selectStartPos, selectEndPos)
                Else
                    Common.Message.ShowMessage(My.Resources.CED002_020_I)
                End If
            Else
            End If
        End Sub

        Private Sub RefreshComboBox(ByRef comboBox As ComboBox, ByVal newItemString As String)
            Dim index As Integer
            If newItemString <> String.Empty Then
                index = comboBox.Items.IndexOf(newItemString)
                If index < 0 Then
                    comboBox.Items.Insert(0, newItemString)
                Else
                    comboBox.Items.RemoveAt(index)
                    comboBox.Items.Insert(0, newItemString)
                End If
            Else
            End If
        End Sub

        Private Sub Initialize()
            If DocumentFormManager.CurrentDocumentForm IsNot Nothing Then
                If Me._cmbFindString.Text <> String.Empty Then
                    Me._btnFindNext.Enabled = True
                    Me._btnReplace.Enabled = True
                Else
                    Me._btnFindNext.Enabled = False
                    Me._btnReplace.Enabled = False
                End If
            Else
                Me._btnFindNext.Enabled = False
                Me._btnReplace.Enabled = False
            End If

            If DocumentFormManager.CurrentDocumentForm IsNot Nothing OrElse _
               ProjectManager.ProjectInfo IsNot Nothing Then
                If Me._cmbFindString.Text <> String.Empty Then
                    Me._btnFindAll.Enabled = True
                    Me._btnReplaceAll.Enabled = True
                Else
                    Me._btnFindAll.Enabled = False
                    Me._btnReplaceAll.Enabled = False
                End If
            Else
                Me._btnFindAll.Enabled = False
                Me._btnReplaceAll.Enabled = False
            End If

            If DocumentFormManager.CurrentDocumentForm IsNot Nothing Then
                Me._optFindInNowDoc.Enabled = True
                Me._optFindInOpenDocs.Enabled = True
            Else
                Me._optFindInNowDoc.Enabled = False
                Me._optFindInOpenDocs.Enabled = False
            End If

            If ProjectManager.ProjectInfo IsNot Nothing Then
                Me._optFindInNowProject.Enabled = True
                If DocumentFormManager.CurrentDocumentForm Is Nothing Then
                    Me._optFindInNowProject.Checked = True
                End If
            Else
                Me._optFindInNowProject.Enabled = False
            End If
        End Sub

        Private Function GetDocumentList() As List(Of Document)
            Dim result As List(Of Document)
            result = New List(Of Document)

            If FindInNowDoc Then
                result.Add(DocumentFormManager.CurrentDocumentForm.Document)

            ElseIf FindInOpenDocs Then
                result = New List(Of Document)
                For Each documentForm As DocumentForm In DocumentFormManager.DocumentForms
                    result.Add(documentForm.Document)
                Next

            ElseIf FindInNowProject Then
                For Each programInfo As ProgramInfo In ProjectManager.ProjectInfo.ProgramInfos
                    result.Add(DocumentManager.Documents(programInfo.ProgramFileName))
                Next
            Else
            End If

            Return result
        End Function

#End Region

#Region "Event Processes"

        Private Sub _btnFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnFindNext.Click
            RefreshComboBox(Me._cmbFindString, FindString)
            If UpDirection = True Then
                FindPrev()
            Else
                FindNext()
            End If
        End Sub

        Private Sub _btnFindAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnFindAll.Click
            Dim documentList As List(Of Document)
            Dim rtnResultList As List(Of FindResultInfo)

            RefreshComboBox(Me._cmbFindString, FindString)
            documentList = GetDocumentList()
            rtnResultList = SearchManager.CobolEDSearchEngine.GetAllFindString(documentList, FindString, MatchCase, MatchWord)
            _cobolEDMainForm._findResultView.SetFindResult(rtnResultList, documentList.Count)
        End Sub

        Private Sub _btnReplace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnReplace.Click
            Dim currentDocumentForm As DocumentForm
            Dim document As Document

            RefreshComboBox(Me._cmbFindString, FindString)
            RefreshComboBox(Me._cmbReplaceString, ReplaceString)

            currentDocumentForm = DocumentFormManager.CurrentDocumentForm
            document = currentDocumentForm.Document

            If String.Compare(document.Selection.GetSelectedString, FindString, Not MatchCase) = 0 Then
                currentDocumentForm.CobolEDEditor.EditText(ReplaceString)
            End If

            If UpDirection = True Then
                FindPrev()
            Else
                FindNext()
            End If

        End Sub

        Private Sub _btnReplaceAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnReplaceAll.Click
            Dim currentDocumentForm As DocumentForm
            Dim documentList As List(Of Document)
            Dim documentForm As DocumentForm
            Dim findResult As FindResultInfo
            Dim startRow As Integer
            Dim startCol As Integer

            RefreshComboBox(Me._cmbFindString, FindString)
            RefreshComboBox(Me._cmbReplaceString, ReplaceString)

            currentDocumentForm = DocumentFormManager.CurrentDocumentForm
            documentList = GetDocumentList()

            For Each document As Document In documentList
                startRow = 0
                startCol = 0
                findResult = SearchManager.CobolEDSearchEngine.GetNextFindString(document, FindString, startRow, startCol, MatchCase, MatchWord, False)
                While findResult IsNot Nothing AndAlso _
                      New Position(startRow, startCol).CompareTo(New Position(findResult.FindResultRow, findResult.FindResultCol)) < 0

                    document.ReplaceText(findResult.FindResultRow, findResult.FindResultCol, FindString.Length, ReplaceString, True)
                    startRow = findResult.FindResultRow
                    startCol = findResult.FindResultCol + ReplaceString.Length                    
                    findResult = SearchManager.CobolEDSearchEngine.GetNextFindString(document, FindString, startRow, startCol, MatchCase, MatchWord, False)
                End While
                documentForm = DocumentFormManager.DocumentForms(document.DocumentFileName)
                If documentForm IsNot Nothing Then
                    documentForm.CobolEDEditor.Refresh()
                End If
            Next

        End Sub

        Private Sub _btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnClose.Click
            Me.Close()
        End Sub

        Private Sub _cmbFindString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cmbFindString.TextChanged
            Initialize()
        End Sub

        Private Sub FindDialog_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            Initialize()
            Me._cmbFindString.Focus()
        End Sub

        Private Sub FindDialog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.FormOwnerClosing Then
            Else
                e.Cancel = True
                If FindString = String.Empty AndAlso FindHistory.Count > 0 Then
                    Me._cmbFindString.Text = FindHistory(0)
                End If
                Me.Hide()
            End If
        End Sub

#End Region

    End Class

End Namespace