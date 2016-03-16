'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnGPL.vb                                                --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.Help                                       --
'--                                                                           --
'--  Project       :  CobolED                                                 --
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

Imports CobolED.Forms
Namespace Menu.Help

    Public Class OnGPL
        Inherits MenuItemProcessBase

        Private Const GPL_FILENAME As String = "Documents\GPL(English).chm"
        Private Const STR_COMMENT As String = "GNUGeneral Public License"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides Sub Execute()
            If IO.File.Exists(GPL_FILENAME) Then
                System.Windows.Forms.Help.ShowHelp(CobolEDMainForm, GPL_FILENAME)
            Else
            End If
        End Sub

        
    End Class

End Namespace
