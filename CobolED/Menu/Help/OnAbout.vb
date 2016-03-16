'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnAbout.vb                                              --
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
    Public Class OnAbout
        Inherits MenuItemProcessBase

        Private _aboutDialog As AboutForm
        Private Const STR_COMMENT As String = "System information about the CobolED editor , version information, and the display of copyright information"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _aboutDialog = New AboutForm
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides Sub Execute()
            _aboutDialog.ShowDialog()
        End Sub

    End Class
End Namespace
