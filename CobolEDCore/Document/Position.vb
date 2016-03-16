'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  Position.vb                                             --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Document                                    --
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

Namespace Document

    Public Structure Position
        Implements IComparable(Of Position)

        Private _row As Integer
        Private _col As Integer

        Public Sub New(ByVal row As Integer, ByVal col As Integer)
            _row = row
            _col = col
        End Sub

        Public Property Row() As Integer
            Get
                Return _row
            End Get
            Set(ByVal value As Integer)
                _row = value
            End Set
        End Property

        Public Property Col() As Integer
            Get
                Return _col
            End Get
            Set(ByVal value As Integer)
                _col = value
            End Set
        End Property

        Public Function CompareTo(ByVal other As Position) As Integer Implements System.IComparable(Of Position).CompareTo
            Dim rst As Integer = 0
            If _row < other.Row Then
                rst = -1
            ElseIf _row > other.Row Then
                rst = 1
            Else
                If _col < other.Col Then
                    rst = -1
                ElseIf _col > other.Col Then
                    rst = 1
                Else
                    rst = 0
                End If
            End If
            Return rst
        End Function

    End Structure

End Namespace
