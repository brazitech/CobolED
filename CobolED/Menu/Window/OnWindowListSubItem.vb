'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnWindowListSubItem.vb                                  --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
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
    Public Class OnWindowListSubItem
        Inherits MenuItemProcessBase

        Private _documentFileName As String
        Private Const STR_COMMENT As String = "Display the Specified window"


        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm, ByVal documentFileName As String)
            MyBase.New(cobolEDMainForm)
            _documentFileName = documentFileName
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides Sub Execute()
            DocumentFormManager.ActivateDocumentForm(_documentFileName, FormWindowState.Maximized)
        End Sub

    End Class

End Namespace
