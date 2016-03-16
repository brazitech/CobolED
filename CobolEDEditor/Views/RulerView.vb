'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  RulerView.vb                                            --
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

Namespace Views

    Public Class RulerView
        Inherits ViewBase

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal document As Document.Document)
            MyBase.New(document)
        End Sub

        Protected Overrides Sub PaintMe(ByVal graphics As System.Drawing.Graphics, ByVal clipRectangle As System.Drawing.Rectangle)
            Dim drawingPen As New Pen(Color.DodgerBlue)

            graphics.DrawLine(drawingPen, 0, Height \ 2, Width, Height \ 2)
            graphics.DrawLine(Pens.Gray, 0, Height - 1, Width, Height - 1)

            For i As Integer = 0 To ShowMaxColumnCount
                If (i + StartColumn) Mod 5 = 0 Then
                    If (i + StartColumn) Mod 10 = 0 Then
                        graphics.DrawLine(drawingPen, i * Font_Width, 2, i * Font_Width, Height - 2)
                    Else
                        graphics.DrawLine(drawingPen, i * Font_Width, 3, i * Font_Width, Height \ 2)
                    End If
                Else
                    graphics.DrawLine(drawingPen, i * Font_Width, 4, i * Font_Width, Height \ 2)
                End If
            Next
        End Sub

    End Class
End Namespace
