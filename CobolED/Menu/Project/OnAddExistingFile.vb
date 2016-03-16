'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnAddExistingFile.vb                                    --
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

Imports CobolED.Menu
Imports CobolED.Forms
Imports CobolED.Managers.Manager
Imports CobolED.Dialogues

Namespace Menu.Project
    Public Class OnAddExistingFile
        Inherits CobolED.Menu.MenuItemProcessBase

        Private Const STR_COMMENT As String = "Add File to Project"
        Private _addExistingFileDialog As AddExistingFileDialog

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _addExistingFileDialog = New AddExistingFileDialog()
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                If ProjectManager.ProjectInfo Is Nothing Then
                    Return False
                Else
                    Return True
                End If
            End Get
        End Property

        Public Overrides Sub Execute()
            If Me._addExistingFileDialog.ShowDialog() = DialogResult.OK Then
                AddProgram(_addExistingFileDialog.SelectedPath, _addExistingFileDialog.SelectedAnalyzer)
            End If
        End Sub

        Private Sub AddProgram(ByVal newFileFullName As String, ByVal analyzerName As String)
            Dim analyzer As CobolEDCore.Interfaces.Analyzer.ICobolEDAnalyzer
            analyzer = AnalyzerManager.Analyzers(analyzerName)
            If DocumentManager.Documents(newFileFullName) Is Nothing Then
                DocumentManager.AddDocument(newFileFullName)
                ProjectManager.AddProgramInfo(newFileFullName, analyzerName)
                If analyzer Is Nothing Then
                    MemberManager.SetMembers(DocumentManager.Documents(newFileFullName), Nothing)
                Else
                    MemberManager.SetMembers(DocumentManager.Documents(newFileFullName), analyzer.CobolEDSyntax)
                End If
                CobolEDMainForm._projectView.InitializeProjectTreeView()
                DocumentFormManager.AddDocumentForm(DocumentManager.Documents(newFileFullName), analyzer)
                DocumentFormManager.ActivateDocumentForm(newFileFullName, FormWindowState.Maximized)
            Else
                If DocumentFormManager.DocumentForms(newFileFullName) Is Nothing Then
                    DocumentFormManager.AddDocumentForm(DocumentManager.Documents(newFileFullName), analyzer)
                    DocumentFormManager.ActivateDocumentForm(newFileFullName, FormWindowState.Maximized)
                End If
            End If
        End Sub

    End Class
End Namespace