'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnOpenProject.vb                                        --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.File                                       --
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

Imports CobolED.Menu
Imports CobolED.Forms
Imports CobolED.Dialogues
Imports CobolED.Managers.Manager

Namespace Menu.File
    Public Class OnOpenProject
        Inherits MenuItemProcessBase

        Private Const STR_COMMENT As String = "Open CobolED Project"

        Private _openProjectDialog As MyOpenProjectDialog

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _openProjectDialog = New MyOpenProjectDialog
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides Sub Execute()
            Dim projectFileName As String

            If _openProjectDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                projectFileName = _openProjectDialog.FileName
                OpenProject(projectFileName)
            End If
        End Sub

        Private Sub OpenProject(ByVal projectFileName As String)

            DocumentFormManager.WindowCloseAll()
            ProjectManager.InitializeProjectInfo(projectFileName)
            DocumentManager.InitializeDocuments(ProjectManager.ProjectInfo)
            DocumentManager.InitializeBookMark(projectFileName)
            MemberManager.InitializeMemberInfosFromProjectInfo(ProjectManager.ProjectInfo)
            CobolEDMainForm._projectView.InitializeProjectTreeView()
            SettingManager.RefreshOpenProjectHistory(projectFileName)

        End Sub

    End Class
End Namespace
