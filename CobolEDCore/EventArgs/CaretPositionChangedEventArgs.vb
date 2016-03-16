'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CaretPositionChangedEventArgs.vb                        --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.EventArgs                                   --
'--                                                                           --
'--  Project       :  CobolEDCore                                             --
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

Namespace EventArgs
    Public Class CaretPositionChangedEventArgs
        Inherits System.EventArgs

        Private _row As Integer
        Private _col As Integer

        Public Sub New(ByVal row As Integer, ByVal col As Integer)
            _row = row
            _col = col
        End Sub

        Public ReadOnly Property row() As Integer
            Get
                Return _row
            End Get
        End Property

        Public ReadOnly Property col() As Integer
            Get
                Return _col
            End Get
        End Property

    End Class
End Namespace
