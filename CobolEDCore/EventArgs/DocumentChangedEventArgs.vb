'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  DocumentChangedEventArgs.vb                             --
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

Imports CobolEDCore.Infos.Document
Namespace EventArgs
    Public Class DocumentChangedEventArgs

        Private _editActionInfo As EditActionInfo

        Public Sub New(ByVal editActionInfo As EditActionInfo)
            _editActionInfo = editActionInfo
        End Sub

        Public ReadOnly Property EditActionInfo() As EditActionInfo
            Get
                Return _editActionInfo
            End Get
        End Property

    End Class
End Namespace
