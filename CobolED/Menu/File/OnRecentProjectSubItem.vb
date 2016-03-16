'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnRecentProjectSubItem.vb                               --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
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

Imports CobolED.Forms
Imports CobolED.Managers.Manager

Namespace Menu.File
    Public Class OnRecentProjectSubItem
        Inherits MenuItemProcessBase

        Private _projectName As String
        Private Const STR_COMMENT As String = "Specified Project"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm, ByVal projectName As String)
            MyBase.New(cobolEDMainForm)
            _projectName = projectName
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides Sub Execute()
            OpenProject(_projectName)
        End Sub

        Private Sub OpenProject(ByVal projectFileName As String)

            DocumentFormManager.WindowCloseAll()
            ProjectManager.InitializeProjectInfo(projectFileName)
            DocumentManager.InitializeDocuments(ProjectManager.ProjectInfo)
            DocumentManager.InitializeBookMark(projectFileName)
            MemberManager.InitializeMemberInfosFromProjectInfo(ProjectManager.ProjectInfo)
            CobolEDMainForm._projectView.InitializeProjectTreeView()

        End Sub

    End Class

End Namespace
