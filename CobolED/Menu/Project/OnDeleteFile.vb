'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnDeleteFile.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.Project                                    --
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
Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Document
Imports CobolEDCore.Interfaces.Info
Imports CobolED.Managers.Manager

Namespace Menu.Project
    Public Class OnDeleteFile
        Inherits Menu.MenuItemProcessBase

        Private Const StrComment As String = "Delete File from project"

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
                If CobolEDMainForm._projectView._projectTreeView.SelectedNode IsNot Nothing _
                  AndAlso TypeOf (CobolEDMainForm._projectView._projectTreeView.SelectedNode.Tag) Is ProgramInfo Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides Sub Execute()
            DeleteSelectedNode(ProjectTreeView.SelectedNode())
        End Sub

        Private ReadOnly Property ProjectTreeView() As TreeView
            Get
                Return CobolEDMainForm._projectView._projectTreeView
            End Get
        End Property

        Private Sub DeleteSelectedNode(ByVal selectedNode As TreeNode)
            Dim programFileName As String
            Dim docForm As DocumentForm
            programFileName = DirectCast(selectedNode.Tag, ProgramInfo).ProgramFileName
            docForm = DocumentFormManager.DocumentForms(programFileName)
            DocumentFormManager.RemoveDocumentForm(docForm)
            ProjectManager.RemoveProgramInfo(programFileName)
            DocumentManager.RemoveDocument(programFileName)
            ProjectTreeView.Nodes.Remove(selectedNode)
            MemberManager.DeleteMembers(programFileName)
            CobolEDMainForm._findResultView.ViewClear()
        End Sub

    End Class
End Namespace