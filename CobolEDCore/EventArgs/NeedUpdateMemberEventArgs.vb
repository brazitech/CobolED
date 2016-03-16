'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  NeedUpdateMemberEventArgs.vb                            --
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

Imports CobolEDCore.Document
Namespace EventArgs
    Public Class NeedUpdateMemberEventArgs
        Inherits System.EventArgs

        Private _currentPosition As Position

        Public Sub New(ByVal currentPosition As Position)
            _currentPosition = currentPosition
        End Sub

        Public Sub New()
            Me.New(New Position(0, 0))
        End Sub

        Public Property currentPosition() As Position
            Get
                Return _currentPosition
            End Get
            Set(ByVal value As Position)
                _currentPosition = value
            End Set
        End Property

    End Class
End Namespace
