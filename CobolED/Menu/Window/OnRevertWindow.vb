'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnRevertWindow.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.Window                                     --
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
Imports CobolED.Managers.Manager

Namespace Menu.Window

    Public Class OnRevertWindow
        Inherits Menu.MenuItemProcessBase

        Private Const STR_COMMENT As String = "Return all of the window to its original size"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                If DocumentFormManager.DocumentForms.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides Sub Execute()
            For Each docForm As DocumentForm In DocumentFormManager.DocumentForms
                docForm.WindowState = FormWindowState.Normal
            Next
            Me.CobolEDMainForm.LayoutMdi(MdiLayout.Cascade)
        End Sub

    End Class
End Namespace
