'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnNewProject.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
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
Imports CobolED.Menu
Imports CobolED.Dialogues
Imports Common
Imports System.Xml
Imports System.Text

Namespace Menu.File
    Public Class OnNewProject
        Inherits MenuItemProcessBase

        Private _newProjectDialog As NewProjectDialog
        Private Const STR_COMMENT As String = "Create a new project"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _newProjectDialog = New NewProjectDialog
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides Sub Execute()
            Dim projectFileName As String
            If _newProjectDialog.ShowDialog() = DialogResult.OK Then
                projectFileName = _newProjectDialog.ProjectFullName
                CreateNewProject(projectFileName)
            End If
        End Sub

        Private Sub CreateNewProject(ByVal projectFileName As String)
            DocumentFormManager.WindowCloseAll()
            DocumentManager.RemoveAllDocument()
            MemberManager.RemoveAllMember()
            ProjectManager.CreateProjectInfo(projectFileName)
            CobolEDMainForm._projectView.InitializeProjectTreeView()
        End Sub


    End Class
End Namespace
