'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  TextViewUndoControl.vb                                  --
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

Imports CobolEDCore.Infos.Document
Imports CobolEDCore.Document
Imports CobolEDCore.Enums
Imports CobolEDEditor.Views
Imports CobolEDEditor.Caret
Imports System.Windows.Forms

Namespace Controls
    Public Class TextViewUndoControl
        Inherits ControlBase

        Private _textView As TextView

        Public Sub New(ByVal textView As TextView, _
                       ByVal bookMarkView As BookMarkView, _
                       ByVal controlManager As ControlManager)
            MyBase.New(controlManager)
            _textView = textView
            Me.Enable = True
        End Sub

        Public ReadOnly Property CanUndo() As Boolean
            Get
                Return Document.CanUndo
            End Get
        End Property

        Public ReadOnly Property CanRedo() As Boolean
            Get
                Return Document.CanRedo
            End Get
        End Property

        Public Sub Undo()
            Dim editActionInfo As EditActionInfo
            editActionInfo = Document.Undo()
            If editActionInfo IsNot Nothing Then
                UpdateEditorForAction(editActionInfo)
            Else
            End If
        End Sub

        Public Sub Redo()
            Dim editActionInfo As EditActionInfo
            editActionInfo = Document.Redo()
            If editActionInfo IsNot Nothing Then
                UpdateEditorForAction(editActionInfo)
            Else
            End If
        End Sub

        Protected Overrides Sub AddAllHandler()
            AddHandler _textView.KeyDown, AddressOf OnKeyDown
        End Sub

        Protected Overrides Sub RemoveAllHandler()
            RemoveHandler _textView.KeyDown, AddressOf OnKeyDown
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

        Private Sub OnKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                Select Case e.KeyData
                    Case Keys.Control Or Keys.Z
                        OnCtrlZ(sender, e)
                    Case Keys.Control Or Keys.Y
                        OnCtrlY(sender, e)
                    Case Else
                End Select
            End If
        End Sub

        Private Sub OnCtrlZ(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = (Keys.Control Or Keys.Z) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                Undo()
            End If
        End Sub

        Private Sub OnCtrlY(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = (Keys.Control Or Keys.Y) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                Redo()
            End If
        End Sub

        Private Sub UpdateEditorForAction(ByVal editActionInfo As EditActionInfo)
            Dim codeCompletionFormControl As CodeCompletionFormControl
            Dim textViewCaretControl As TextViewCaretControl
            Dim textViewSelectionControl As TextViewSelectionControl
            Dim scrollBarControl As ScrollBarControl
            Dim repaintBelow As Boolean

            codeCompletionFormControl = DirectCast(Control(ControlManager.CODECOMPLETIONFORM), CodeCompletionFormControl)
            textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
            textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
            scrollBarControl = DirectCast(Control(ControlManager.SCROLLBAR), ScrollBarControl)

            If editActionInfo IsNot Nothing Then

                If textViewSelectionControl IsNot Nothing Then textViewSelectionControl.ClearSelection(New Position(editActionInfo.Row, editActionInfo.Col))

                If codeCompletionFormControl IsNot Nothing Then codeCompletionFormControl.HideCodeCompletionForm()

                If editActionInfo.Text.IndexOf(Document.EOL) <> -1 OrElse _
                   editActionInfo.OldText.IndexOf(Document.EOL) <> -1 Then
                    repaintBelow = True
                Else
                    repaintBelow = False
                End If

                If textViewCaretControl IsNot Nothing Then
                    TextCaret.Hide()
                    textViewCaretControl.CaretMoveTo(editActionInfo.Row, editActionInfo.Col)
                End If

                If editActionInfo.DocumentChangeType = DocumentChangeTypeEnum.InsertText OrElse _
                   editActionInfo.DocumentChangeType = DocumentChangeTypeEnum.ReplaceText Then
                    If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretMoveByStep(editActionInfo.Text.Replace(Document.EOL, " ").Length)
                    If textViewSelectionControl IsNot Nothing Then textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
                TextView.RepaintDocumentLine(editActionInfo.Row, editActionInfo.Col, repaintBelow)
                If scrollBarControl IsNot Nothing Then scrollBarControl.ReSetScrollBarRange()

                TextCaret.Show()

            Else
            End If
        End Sub

    End Class
End Namespace
