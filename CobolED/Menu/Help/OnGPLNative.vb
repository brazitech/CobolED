'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnGPLNative.vb                                          --
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

    Public Class OnGplNative
        Inherits MenuItemProcessBase

        Private Const GplFilename As String = "Documents\GPL(Japanese).chm"
        Private Const StrComment As String = "English version GNUGeneral Public License"

        Public Sub New(ByVal cobolEdMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return StrComment
            End Get
        End Property

        Public Overrides Sub Execute()
            If IO.File.Exists(GplFilename) Then
                System.Windows.Forms.Help.ShowHelp(CobolEDMainForm, GplFilename)
            Else
            End If
        End Sub

    End Class

End Namespace
