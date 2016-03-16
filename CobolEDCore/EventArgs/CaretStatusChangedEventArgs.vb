'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CaretStatusChangedEventArgs.vb                          --
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

Imports CobolEDCore.Enums

Namespace EventArgs
    Public Class CaretStatusChangedEventArgs
        Inherits System.EventArgs

        Private _caretStatus As CaretStatusEnum

        Public Sub New(ByVal caretStatus As CaretStatusEnum)
            _caretStatus = caretStatus
        End Sub

        Public ReadOnly Property CaretStatus() As CaretStatusEnum
            Get
                Return _caretStatus
            End Get
        End Property

    End Class
End Namespace
