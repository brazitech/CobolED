'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  TextViewEditControl.vb                                  --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Controls                                  --
'--                                                                           --
'--  Project       :  CobolEDEditor                                           --
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

Imports CobolEDCore.Document
Imports CobolEDCore.Enums
Imports CobolEDCore.EventArgs
Imports CobolEDCore.Interfaces
Imports CobolEDCore.Infos.Analyzer
Imports System.Windows.Forms
Imports System.Drawing
Imports CobolEDEditor.Caret
Imports CobolEDEditor.Views
Imports CobolEDEditor.Forms

Namespace Controls
    Public Class TextViewEditControl
        Inherits ControlBase

        Private _textView As TextView
        Private _bookMarkView As BookMarkView
        Private _codeCompletionForm As CodeCompletionForm

        Public Sub New(ByVal textView As TextView, _
                       ByVal bookMarkView As BookMarkView, _
                       ByVal codeCompletionForm As CodeCompletionForm, _
                       ByVal controlManager As ControlManager)
            MyBase.New(controlManager)
            _textView = textView
            _bookMarkView = bookMarkView
            _codeCompletionForm = codeCompletionForm
            Me.Enable = True
        End Sub

        Public Sub EditText(ByVal text As String)
            Dim textViewCaretControl As TextViewCaretControl
            Dim textViewSelectionControl As TextViewSelectionControl
            Dim scrollBarControl As ScrollBarControl

            Dim repaintBelow As Boolean
            Dim removedText As String = String.Empty
            Dim selectionLength As Integer
            Dim selectionStart As Position

            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                TextCaret.Hide()

                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                scrollBarControl = DirectCast(Control(ControlManager.SCROLLBAR), ScrollBarControl)

                selectionLength = Document.Selection.Length
                selectionStart = Document.Selection.Start

                If textViewSelectionControl IsNot Nothing Then textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)

                If selectionLength <> 0 Then
                    TextCaret.PhysicalPosition = selectionStart
                    removedText = Document.ReplaceText(selectionStart.Row, selectionStart.Col, selectionLength, text, True)
                ElseIf TextCaret.Status = CaretStatusEnum.OverWrite Then
                    removedText = Document.ReplaceText(TextCaret.PhysicalPosition.Row, TextCaret.PhysicalPosition.Col, text.Replace(Document.EOL, " ").Length, text, True)
                Else
                    Document.InsertText(TextCaret.PhysicalPosition.Row, TextCaret.PhysicalPosition.Col, text, True)
                End If

                If text.IndexOf(Document.EOL) <> -1 Then
                    repaintBelow = True
                ElseIf removedText.IndexOf(Document.EOL) <> -1 Then
                    repaintBelow = True
                Else
                    repaintBelow = False
                End If
                _textView.RepaintDocumentLine(TextCaret.PhysicalPosition.Row, TextCaret.PhysicalPosition.Col, repaintBelow)
                _bookMarkView.RepaintDocumentLine(TextCaret.PhysicalPosition.Row, repaintBelow)

                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretMoveByStep(text.Replace(Document.EOL, " ").Length)
                If textViewSelectionControl IsNot Nothing Then textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                If scrollBarControl IsNot Nothing Then scrollBarControl.ReSetScrollBarRange()
                TextCaret.Show()
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CommentOut()
            Dim scrollBarControl As ScrollBarControl
            Dim formerString As String
            Dim commentString As String
            Dim startRow As Integer
            Dim endRow As Integer

            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso TextView.CobolEDEditAssistant IsNot Nothing Then
                TextCaret.Hide()

                scrollBarControl = DirectCast(Control(ControlManager.SCROLLBAR), ScrollBarControl)

                If Document.Selection.Selected Then
                    startRow = Document.Selection.Start.Row
                    endRow = Document.Selection.End.Row
                Else
                    startRow = TextCaret.PhysicalPosition.Row
                    endRow = TextCaret.PhysicalPosition.Row
                End If

                For index As Integer = startRow To endRow
                    formerString = Document.DocumentLineString(index)
                    commentString = TextView.CobolEDEditAssistant.GetCommentString(formerString)
                    Document.ReplaceText(index, 0, formerString.Length, commentString, True)
                    _textView.RepaintDocumentLine(index, False)
                Next

                If scrollBarControl IsNot Nothing Then scrollBarControl.ReSetScrollBarRange()
                TextCaret.Show()
            Else
            End If
        End Sub

        Public Sub CommentCancel()
            Dim scrollBarControl As ScrollBarControl
            Dim formerString As String
            Dim uncommentString As String
            Dim startRow As Integer
            Dim endRow As Integer

            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso TextView.CobolEDEditAssistant IsNot Nothing Then
                TextCaret.Hide()

                scrollBarControl = DirectCast(Control(ControlManager.SCROLLBAR), ScrollBarControl)

                If Document.Selection.Selected Then
                    startRow = Document.Selection.Start.Row
                    endRow = Document.Selection.End.Row
                Else
                    startRow = TextCaret.PhysicalPosition.Row
                    endRow = TextCaret.PhysicalPosition.Row
                End If

                For index As Integer = startRow To endRow
                    formerString = Document.DocumentLineString(index)
                    uncommentString = TextView.CobolEDEditAssistant.GetUnCommentString(formerString)
                    Document.ReplaceText(index, 0, formerString.Length, uncommentString, True)
                    _textView.RepaintDocumentLine(index, False)
                Next

                If scrollBarControl IsNot Nothing Then scrollBarControl.ReSetScrollBarRange()
                TextCaret.Show()
            Else
            End If
        End Sub

        Public Function DeleteText(ByVal length As Integer) As String
            Dim textViewCaretControl As TextViewCaretControl
            Dim textViewSelectionControl As TextViewSelectionControl
            Dim scrollBarControl As ScrollBarControl

            Dim repaintBelow As Boolean
            Dim removedText As String
            Dim delLength As Integer

            If length > 0 AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                TextCaret.Hide()

                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                scrollBarControl = DirectCast(Control(ControlManager.SCROLLBAR), ScrollBarControl)

                If Document.Selection.Selected Then
                    delLength = length - 1 + Document.Selection.Length
                    TextCaret.PhysicalPosition = Document.Selection.Start
                Else
                    delLength = length
                End If

                If textViewSelectionControl IsNot Nothing Then textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)

                removedText = Document.RemoveText(TextCaret.PhysicalPosition.Row, TextCaret.PhysicalPosition.Col, delLength, True)

                If removedText.IndexOf(Document.EOL) <> -1 Then
                    repaintBelow = True
                Else
                    repaintBelow = False
                End If

                _textView.RepaintDocumentLine(TextCaret.PhysicalPosition.Row, TextCaret.PhysicalPosition.Col, repaintBelow)
                _bookMarkView.RepaintDocumentLine(TextCaret.PhysicalPosition.Row, repaintBelow)

                If scrollBarControl IsNot Nothing Then scrollBarControl.ReSetScrollBarRange()
                TextCaret.Show()
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.MoveTextViewToShowCaret()
            Else
                removedText = String.Empty
            End If

            Return removedText
        End Function

        Protected Overrides Sub AddAllHandler()
            AddHandler _textView.KeyDown, AddressOf OnKeyDown
            AddHandler _textView.KeyPress, AddressOf OnKeyPress
        End Sub

        Protected Overrides Sub RemoveAllHandler()
            RemoveHandler _textView.KeyDown, AddressOf OnKeyDown
            RemoveHandler _textView.KeyPress, AddressOf OnKeyPress
        End Sub

        Private ReadOnly Property TextView() As TextView
            Get
                Return _textView
            End Get            
        End Property

        Private ReadOnly Property Document() As Document
            Get
                Return _textView.Document
            End Get
        End Property

        Private ReadOnly Property TextCaret() As TextCaret
            Get
                Return _textView.TextCaret
            End Get
        End Property

        Private ReadOnly Property CodeCompletionForm() As CodeCompletionForm
            Get
                Return _codeCompletionForm
            End Get
        End Property

        Private Sub OnKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                Select Case e.KeyData
                    Case Keys.Back
                        OnBackKeyDown(sender, e)
                    Case Keys.Delete
                        OnDeleteKeyDown(sender, e)
                    Case Else
                End Select
            End If
        End Sub

        Private Sub OnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                If Common.CommonFunction.IsEditChar(e.KeyChar) Then
                    OnEditKeyPress(e.KeyChar)
                    e.Handled = True
                ElseIf e.KeyChar = Common.CommonConst.KEY_ENTER Then
                    OnEnterKeyPress()
                    e.Handled = True
                ElseIf e.KeyChar = Common.CommonConst.KEY_TAB Then
                    OnTabKeyPress()
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub OnEditKeyPress(ByVal KeyChar As Char)
            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                EditText(KeyChar.ToString)
            Else
            End If
        End Sub

        Private Sub OnEnterKeyPress()
            Dim insertText As String
            Dim prevParseString As String
            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                If _textView.CobolEDLex IsNot Nothing AndAlso TextCaret.Status = CaretStatusEnum.Insert Then
                    prevParseString = Document.DocumentLineString(TextCaret.PhysicalPosition.Row).Substring(0, TextCaret.PhysicalPosition.Col)
                    insertText = Document.EOL & _textView.CobolEDEditAssistant.GetLineHearder(prevParseString)
                Else
                    insertText = Document.EOL
                End If
                EditText(insertText)
            Else
            End If
        End Sub

        Private Sub OnTabKeyPress()
            Dim str As String
            Dim SpaceCount As Integer

            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                str = Document.DocumentLineString(TextCaret.PhysicalPosition.Row)
                SpaceCount = Document.TabSpan - (Common.StringTransaction.GetByteCountFromIndex(str, TextCaret.PhysicalPosition.Col) Mod Document.TabSpan)
                EditText(Space(SpaceCount))
            Else
            End If
        End Sub

        Private Sub OnBackKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl

            If e.KeyData = Keys.Back AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing AndAlso textViewCaretControl.CaretMoveByStep(-1) = True Then
                    DeleteText(1)
                End If
            End If

        End Sub

        Private Sub OnDeleteKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = Keys.Delete AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                DeleteText(1)
            End If
        End Sub
    End Class

End Namespace