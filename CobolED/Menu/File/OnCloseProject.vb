'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnCloseProject.vb                                       --
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
Imports CobolEDCore
Imports CobolED.Managers.Manager

Namespace Menu.File
    Public Class OnCloseProject
        Inherits Menu.MenuItemProcessBase

        Private Const STR_COMMENT As String = "Close Project"

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
                If ProjectManager.ProjectInfo IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides Sub Execute()
            CloseDocumentForms()
            ProjectManager.SaveProject()
            DocumentFormManager.WindowCloseAll()
            MemberManager.RemoveAllMember()
            DocumentManager.RemoveAllDocument()
            ProjectManager.RemoveAllProgramInfo()
            CobolEDMainForm._projectView.ClearProjectTreeView()
            CobolEDMainForm._findResultView.ViewClear()
            CobolEDMainForm._projectView._propertyView.Rows.Clear()
        End Sub

        Private Sub CloseDocumentForms()
            For Each docForm As DocumentForm In DocumentFormManager.DocumentForms
                docForm.Close()
            Next
            DocumentFormManager.ClearGoToHistory()
        End Sub

    End Class
End Namespace
