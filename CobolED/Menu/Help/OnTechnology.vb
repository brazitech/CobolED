'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnTechnology.vb                                         --
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
    Public Class OnTechnology
        Inherits MenuItemProcessBase

        Private Const TechFilename As String = "Documents\Technology.chm"
        Private Const StrComment As String = "Documents"

        Public Sub New(ByVal cobolEdMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return StrComment
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                Return IO.File.Exists(TechFilename)
            End Get
        End Property

        Public Overrides Sub Execute()
            If IO.File.Exists(TechFilename) Then
                System.Windows.Forms.Help.ShowHelp(CobolEDMainForm, TechFilename)
            Else
            End If
        End Sub

    End Class
End Namespace
