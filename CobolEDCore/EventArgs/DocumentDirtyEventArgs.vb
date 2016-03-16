'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  DocumentDirtyEventArgs.vb                               --
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
    Public Class DocumentDirtyEventArgs
        Inherits System.EventArgs

        Private _documentDirtyFlag As Boolean

        Public Sub New(ByVal documentDirtyFlag As Boolean)
            _documentDirtyFlag = documentDirtyFlag
        End Sub

        Public Property DocumentDirtyFlag() As Boolean
            Get
                Return _documentDirtyFlag
            End Get
            Set(ByVal value As Boolean)
                _documentDirtyFlag = value
            End Set
        End Property

    End Class
End Namespace
