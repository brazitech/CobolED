'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  RulerViewControl.vb                                     --
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

Imports System.Windows.Forms
Imports System.Drawing
Imports CobolEDEditor.Views
Imports CobolEDCore

Namespace Controls

    Public Class RulerViewControl
        Inherits ControlBase

        Private _rulerView As RulerView
        Private _textView As TextView
        Private Const _COMMENT_TIP As String = "{0}Phys.Col"

        Public Sub New(ByVal rulerView As RulerView, ByVal textView As TextView, ByVal controlManager As ControlManager)
            MyBase.New(controlManager)
            _rulerView = rulerView
            _textView = textView
        End Sub

        Public Function ChangeSplitLine(ByVal column As Integer) As Boolean
            Dim result As Boolean = True

            If _textView IsNot Nothing Then
                For index As Integer = 0 To _textView.SplitLines.Count - 1
                    If _textView.SplitLines(index) = column Then
                        _textView.SplitLines.RemoveAt(index)
                        result = False
                        Exit For
                    End If
                Next
                If result = True Then
                    _textView.SplitLines.Add(column)
                End If
            Else
                result = False
            End If

            Return result
        End Function

        Protected Overrides Sub AddAllHandler()
            AddHandler _rulerView.MouseDown, AddressOf OnMouseDown
            AddHandler _rulerView.MouseStop, AddressOf OnMouseStop
        End Sub

        Protected Overrides Sub RemoveAllHandler()

        End Sub

        Private ReadOnly Property Document() As Document.Document
            Get
                If _textView IsNot Nothing Then
                    Return _textView.Document
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Private Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim column As Integer
            If e.Button = MouseButtons.Left Then
                column = GetColumnFromPoint(e.X)
                ChangeSplitLine(column)
                _textView.Invalidate(New Rectangle((column - _textView.StartColumn) * _textView.Font_Width, 0, 1, _textView.Height))
            Else
            End If
        End Sub

        Private Sub OnMouseStop(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim column As Integer
            column = GetColumnFromPoint(e.X) + 1
            _rulerView.ShowCommentTip(String.Format(_COMMENT_TIP, column), New Point(e.X, e.Y - 20), -1)
        End Sub

        Private Function GetColumnFromPoint(ByVal x As Integer) As Integer
            Dim result As Integer

            If Document IsNot Nothing Then
                If x < 0 Then
                    result = _rulerView.StartColumn
                ElseIf x > _rulerView.Width Then
                    result = _rulerView.StartColumn + _rulerView.ShowMaxColumnCount
                Else
                    result = _rulerView.StartColumn + CInt((x / _rulerView.Font_Width) - 0.5)
                End If
            Else
                result = 0
            End If

            Return result
        End Function

    End Class

End Namespace
