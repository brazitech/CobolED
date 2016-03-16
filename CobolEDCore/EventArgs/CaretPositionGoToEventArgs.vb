'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CaretPositionGoToEventArgs.vb                           --
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

Imports CobolEDCore.Infos.Editor
Namespace EventArgs
    Public Class CaretPositionGoToEventArgs
        Inherits System.EventArgs

        Private _caretPositionInfo As CaretPositionInfo

        Public Sub New(ByVal caretPositionInfo As CaretPositionInfo)
            _caretPositionInfo = caretPositionInfo
        End Sub

        Public ReadOnly Property CaretPositionInfo() As CaretPositionInfo
            Get
                Return _caretPositionInfo
            End Get
        End Property

    End Class
End Namespace
