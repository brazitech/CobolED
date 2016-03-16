'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CodeCompletionFormControl.vb                            --
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

Option Strict On
Imports CobolEDCore.Document
Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDEditor.Views
Imports CobolEDEditor.Forms
Imports CobolEDEditor.Caret
Imports System.Drawing
Imports System.Windows.Forms

Namespace Controls
    Public Class CodeCompletionFormControl
        Inherits ControlBase

        Private _textView As TextView
        Private _codeCompletionForm As CodeCompletionForm

        Public Sub New(ByVal textView As TextView, _
                       ByVal codeCompletionForm As CodeCompletionForm, _
                       ByVal controlManager As ControlManager)
            MyBase.New(controlManager)
            _textView = textView
            _codeCompletionForm = codeCompletionForm
            Me.Enable = True
        End Sub

        Public Sub ShowCodeCompletionForm()
            Dim location As Point
            Dim currentWord As WordInfo

            If CobolEDLex IsNot Nothing AndAlso TextCaret.PhysicalPosition.Col > 0 Then
                location = TextView.PointToScreen(TextCaret.VisualPosition)
                location.Offset(20, 20)
                If location.Y + CodeCompletionForm.Height > TextView.PointToScreen(New Point(0, TextView.Height)).Y Then
                    location.Y -= CodeCompletionForm.Height
                End If
                currentWord = CobolEDLex.GetWordFromIndex(Document.DocumentLineString(TextCaret.PhysicalPosition.Row), TextCaret.PhysicalPosition.Col - 1)
                If currentWord.WordType = CobolEDCore.Enums.WordTypeEnum.KeyWord OrElse _
                   currentWord.WordType = CobolEDCore.Enums.WordTypeEnum.NormalWord Then
                    CodeCompletionForm.ShowMe(location, currentWord.WordString)
                Else
                    HideCodeCompletionForm()
                End If
                TextView.Focus()
            Else
                HideCodeCompletionForm()
            End If

        End Sub

        Public Sub HideCodeCompletionForm()
            CodeCompletionForm.HideMe()
            TextView.Focus()
        End Sub

        Public Sub SetCompletionWord()
            Dim currentWord As WordInfo
            Dim currentLine As String
            Dim completionWord As String
            Dim textViewCaretControl As TextViewCaretControl
            Dim textViewEditControl As TextViewEditControl

            textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
            textViewEditControl = DirectCast(Control(ControlManager.TEXTVIEW_EDIT), TextViewEditControl)

            If Document IsNot Nothing AndAlso _
               CobolEDLex IsNot Nothing AndAlso _
               TextCaret IsNot Nothing AndAlso _
               TextCaret.PhysicalPosition.Col > 0 AndAlso _
               textViewCaretControl IsNot Nothing AndAlso _
               textViewEditControl IsNot Nothing Then

                TextCaret.Hide()
                currentLine = Document.DocumentLineString(TextCaret.PhysicalPosition.Row)
                currentWord = CobolEDLex.GetWordFromIndex(currentLine, TextCaret.PhysicalPosition.Col - 1)
                completionWord = CodeCompletionForm.SelectedWord

                HideCodeCompletionForm()
                textViewCaretControl.CaretMoveByStep(-currentWord.WordString.Length)
                textViewEditControl.DeleteText(currentWord.WordString.Length)
                textViewEditControl.EditText(completionWord)
                TextCaret.Show()
            Else
                HideCodeCompletionForm()
            End If

        End Sub

        Public Sub SelectNextItem(ByVal nextStep As Integer)
            CodeCompletionForm.SelectNextItem(nextStep)
            TextView.Focus()
        End Sub

        Protected Overrides Sub AddAllHandler()
            AddHandler _textView.KeyPress, AddressOf OnKeyPress
            AddHandler _textView.KeyDown, AddressOf OnKeyDown
            AddHandler _textView.MouseDown, AddressOf OnMouseDown
            AddHandler _textView.MouseWheel, AddressOf OnMouseWheel
        End Sub

        Protected Overrides Sub RemoveAllHandler()
            RemoveHandler _textView.KeyPress, AddressOf OnKeyPress
            RemoveHandler _textView.KeyDown, AddressOf OnKeyDown
            RemoveHandler _textView.MouseDown, AddressOf OnMouseDown
            RemoveHandler _textView.MouseWheel, AddressOf OnMouseWheel
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

        Private ReadOnly Property CobolEDLex() As ICobolEDLex
            Get
                Return _textView.CobolEDLex
            End Get
        End Property

        Private ReadOnly Property CodeCompletionForm() As CodeCompletionForm
            Get
                Return _codeCompletionForm
            End Get
        End Property

        Private Sub OnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso CobolEDLex IsNot Nothing Then
                If Common.CommonFunction.IsEditChar(e.KeyChar) Then  'Edit Char
                    ShowCodeCompletionForm()
                ElseIf e.KeyChar = Common.CommonConst.KEY_ENTER OrElse _
                       e.KeyChar = Common.CommonConst.KEY_TAB Then  'Enter or Table Char
                    If CodeCompletionForm.IsShown Then
                        SetCompletionWord()
                    Else
                    End If
                ElseIf e.KeyChar = Common.CommonConst.KEY_ESC Then 'ESC
                    HideCodeCompletionForm()
                Else
                End If
            End If
        End Sub

        Private Sub OnKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso CobolEDLex IsNot Nothing Then
                Select Case e.KeyData
                    Case Keys.Back
                        HideCodeCompletionForm()
                    Case Keys.Delete
                        HideCodeCompletionForm()
                    Case Keys.Up
                        SelectNextItem(-1)
                    Case Keys.Down
                        SelectNextItem(1)
                    Case Keys.Left
                        SelectNextItem(-1)
                    Case Keys.Right
                        SelectNextItem(1)
                    Case Keys.PageUp
                        SelectNextItem(-10)
                    Case Keys.PageDown
                        SelectNextItem(10)
                    Case Else
                End Select
            End If
        End Sub

        Private Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            HideCodeCompletionForm()
        End Sub

        Private Sub OnMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
            HideCodeCompletionForm()
        End Sub


    End Class
End Namespace
