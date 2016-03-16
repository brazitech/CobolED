'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  TextCaret.vb                                            --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Caret                                     --
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
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports CobolEDCore
Imports CobolEDCore.EventArgs
Imports CobolEDCore.Enums
Imports CobolEDEditor.Views

Namespace Caret

    Public Class TextCaret
        Inherits CaretBase

        Private _physicalPosition As Document.Position
        Private _status As CaretStatusEnum

        Public Event CaretPositionChanged(ByVal sender As Object, ByVal e As CaretPositionChangedEventArgs)
        Public Event CaretStatusChanged(ByVal sender As Object, ByVal e As CaretStatusChangedEventArgs)

        Public Sub New(ByVal MyParent As TextView)
            MyBase.New(MyParent)
            PhysicalPosition = New Document.Position(0, 0)
            Status = CaretStatusEnum.Insert
        End Sub

        Public Property PhysicalPosition() As Document.Position
            Get
                Return _physicalPosition
            End Get
            Set(ByVal Value As Document.Position)
                _physicalPosition = Value
                Me.Position = VisualPosition
                RaiseEvent CaretPositionChanged(Me, New CaretPositionChangedEventArgs(_physicalPosition.Row, _physicalPosition.Col))
            End Set
        End Property

        Public Property Status() As CaretStatusEnum
            Get
                Return _status
            End Get
            Set(ByVal value As CaretStatusEnum)
                If value = _status Then
                Else
                    Select Case value
                        Case CaretStatusEnum.Insert
                            Me.Size = New Size(2, MyParent.Font_Height)
                        Case CaretStatusEnum.OverWrite
                            Me.Size = New Size(CInt(MyParent.Font_Width), MyParent.Font_Height)
                    End Select
                    _status = value
                    RaiseEvent CaretStatusChanged(Me, New CaretStatusChangedEventArgs(_status))
                End If
            End Set
        End Property

        Public Shadows ReadOnly Property MyParent() As TextView
            Get
                Return DirectCast(MyBase.MyParent, TextView)
            End Get
        End Property

        Public ReadOnly Property VisualPosition() As Point
            Get
                Dim rst As New Point
                rst.X = MyParent.GetPointXFromIndex(_physicalPosition.Col, _physicalPosition.Row)
                rst.Y = MyParent.GetPointYFromIndex(_physicalPosition.Row)
                Return rst
            End Get
        End Property

        Public Sub RePaintCaret()
            Me.Position = VisualPosition
        End Sub

    End Class

End Namespace