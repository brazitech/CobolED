'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnSaveAs.vb                                             --
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
Imports CobolED.Dialogues
Imports CobolED.Managers.Manager

Namespace Menu.File
    Public Class OnSaveAs
        Inherits MenuItemProcessBase

        Private _saveAsDialog As MySaveAsDialog
        Private Const STR_COMMENT As String = "Save File As"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _saveAsDialog = New MySaveAsDialog
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                If DocumentFormManager.CurrentDocumentForm IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides Sub Execute()
            Dim currentDocumentForm As DocumentForm
            Dim documentName As String
            Dim analyzer As CobolEDCore.Interfaces.Analyzer.ICobolEDAnalyzer
            currentDocumentForm = DocumentFormManager.CurrentDocumentForm
           
            If currentDocumentForm IsNot Nothing AndAlso _saveAsDialog.ShowDialog = DialogResult.OK Then
                documentName = currentDocumentForm.Document.DocumentFileName
                analyzer = DocumentFormManager.DocumentForms(documentName).CobolEDEditor.CobolEDAnalyzer
                DocumentFormManager.Rename(documentName, _saveAsDialog.FileName)
                DocumentManager.Rename(documentName, _saveAsDialog.FileName)
                ProjectManager.RenameProgram(documentName, _saveAsDialog.FileName)
                currentDocumentForm.Document.Save()
                MemberManager.DeleteMembers(documentName)
                If analyzer Is Nothing Then
                    MemberManager.SetMembers(DocumentManager.Documents(_saveAsDialog.FileName), Nothing)
                Else
                    MemberManager.SetMembers(DocumentManager.Documents(_saveAsDialog.FileName), analyzer.CobolEDSyntax)
                End If
                CobolEDMainForm._projectView.Rename(documentName, _saveAsDialog.FileName)
            Else
            End If
        End Sub

    End Class
End Namespace
