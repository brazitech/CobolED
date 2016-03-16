'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  BookMarkViewControl.vb                                  --
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

Imports System.Drawing
Imports System.Windows.Forms
Imports CobolEDCore.Document
Imports CobolEDEditor.Views
Namespace Controls

    Public Class BookMarkViewControl
        Inherits ControlBase

        Private _bookMarkView As BookMarkView

        Public Sub New(ByVal bookMarkView As BookMarkView, ByVal controlManager As ControlManager)
            MyBase.New(controlManager)
            _bookMarkView = bookMarkView
        End Sub

        Public Sub SetBookMark(ByVal row As Integer, ByVal bookMark As Boolean)
            If Document IsNot Nothing AndAlso row >= 0 OrElse row <= Document.DocumentLinesCount - 1 Then
                Document.SetBookMark(row, bookMark)
                BookMarkView.RepaintDocumentLine(row, False)
            Else
            End If
        End Sub

        Protected Overrides Sub AddAllHandler()
            AddHandler _bookMarkView.MouseDown, AddressOf OnMouseDown
        End Sub

        Protected Overrides Sub RemoveAllHandler()
            RemoveHandler _bookMarkView.MouseDown, AddressOf OnMouseDown
        End Sub

        Private Property BookMarkView() As BookMarkView
            Get
                Return _bookMarkView
            End Get
            Set(ByVal value As BookMarkView)
                _bookMarkView = value
            End Set
        End Property

        Private ReadOnly Property Document() As Document
            Get
                Return _bookMarkView.Document
            End Get
        End Property

        Private Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim row As Integer
            Dim mousePosition As Point

            If e.Button = MouseButtons.Left AndAlso Document IsNot Nothing Then
                mousePosition = New Point(e.X + 16, e.Y)
                row = GetRowFromPointY(mousePosition.Y)

                If row <> -1 Then
                    If Document.DocumentLineBookMark(row) Then
                        SetBookMark(row, False)
                    Else
                        SetBookMark(row, True)
                    End If
                Else
                End If
            End If
        End Sub

        Private Function GetRowFromPointY(ByVal y As Integer) As Integer
            Dim result As Integer

            If Document IsNot Nothing Then
                If y < 0 Then
                    result = _bookMarkView.StartLine
                ElseIf y > _bookMarkView.Height Then
                    result = _bookMarkView.StartLine + _bookMarkView.ShowMaxLineCount
                Else
                    result = _bookMarkView.StartLine + CInt((y / _bookMarkView.Font_Height) - 0.5)
                End If

                If result < 0 Then
                    result = -1
                ElseIf result > Document.DocumentLinesCount - 1 Then
                    result = -1
                End If
            Else
                result = 0
            End If

            Return result
        End Function

    End Class

End Namespace
