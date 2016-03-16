'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  BookMarkView.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Views                                     --
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
Imports CobolEDCore
Imports System.Windows.Forms

Namespace Views
    Public Class BookMarkView
        Inherits ViewBase

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal document As Document.Document)
            MyBase.New(document)
        End Sub

        Public Sub PaintDocumentLine(ByVal Index As Integer, ByVal Graphics As Graphics, ByVal y As Integer)
            If Document IsNot Nothing AndAlso Document.DocumentLineBookMark(Index) Then
                PaintBookMark(Graphics, y)
            End If
        End Sub

        Protected Overrides Sub PaintMe(ByVal Graphics As Graphics, ByVal ClipRectangle As Rectangle)
            Dim y As Integer = 0
            Dim drawDocumentLineRect As Rectangle

            Graphics.DrawLine(New Pen(Color.Gray), 0, 0, 0, Me.Height)
            Graphics.DrawLine(New Pen(Color.Gray), Me.Width - 1, 0, Me.Width - 1, Me.Height)

            If Document IsNot Nothing Then
                For index As Integer = StartLine To StartLine + ShowMaxLineCount

                    If index <= Document.DocumentLinesCount - 1 Then
                        drawDocumentLineRect = New Rectangle(0, y, Me.Width, FontHeight)
                        If ClipRectangle.IntersectsWith(drawDocumentLineRect) Then
                            PaintDocumentLine(index, Graphics, drawDocumentLineRect.Top)
                        End If
                    Else
                        Exit For
                    End If
                    y += FontHeight
                Next
            Else
            End If

        End Sub

        Private Sub PaintBookMark(ByVal Graphics As Graphics, ByVal y As Integer)

            Dim Path As New Drawing2D.GraphicsPath
            Dim Rect As New Rectangle(3, y + 2, 10, 10)
            Dim drawingColor As Color = Color.Blue
            Path.AddEllipse(Rect)
            Dim DrawingBrush As New Drawing2D.PathGradientBrush(Path)
            DrawingBrush.CenterPoint = New PointF(Rect.Left + Rect.Width \ 3, Rect.Top + Rect.Height \ 3)
            DrawingBrush.CenterColor = Color.White
            DrawingBrush.SurroundColors = New Color() {drawingColor}
            Graphics.FillRectangle(DrawingBrush, Rect)

        End Sub

    End Class
End Namespace
