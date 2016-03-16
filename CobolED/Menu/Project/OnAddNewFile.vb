'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnAddNewFile.vb                                         --
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
Imports CobolEDCore
Imports CobolEDCore.Interfaces.Analyzer
Imports Common

Imports System.Xml

Namespace Menu.Project
    Public Class OnAddNewFile
        Inherits Menu.MenuItemProcessBase
        Private Const XML_TEMPLATE_DEFINE As String = "Template"
        Private Const XML_ANALYZER_ATTR As String = "Analyzer"
        Private Const XML_SOURCE_DEFINE As String = "Template/Source/Item"

        Private Const STR_COMMENT As String = "Add new File to project"
        Private _selectTemplateDialog As SelectTemplateDialog

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _selectTemplateDialog = New SelectTemplateDialog()
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
            Dim newFileWizardDialog As NewFileWizardDialog
            Dim xmlDoc As XmlDocument            
            Dim analyzerName As String

            Dim newFileFullName As String
            If _selectTemplateDialog.ShowDialog() = DialogResult.OK Then
                Try
                    newFileFullName = IO.Path.Combine(IO.Path.GetDirectoryName(ProjectManager.ProjectInfo.ProjectFileName()), _selectTemplateDialog.NewFileName)
                    newFileWizardDialog = CreateWizzard(_selectTemplateDialog.SelectedTemplateName)

                    xmlDoc = New XmlDocument()
                    xmlDoc.Load(_selectTemplateDialog.SelectedTemplateName)
                    analyzerName = xmlDoc.SelectSingleNode(XML_TEMPLATE_DEFINE).Attributes(XML_ANALYZER_ATTR).Value.Trim

                    If newFileWizardDialog Is Nothing Then
                        CreateProgram(newFileFullName, GetTemplateContent(False), New Dictionary(Of String, String), analyzerName)
                    Else
                        If newFileWizardDialog.ShowDialog() = DialogResult.OK Then
                            CreateProgram(newFileFullName, GetTemplateContent(True, xmlDoc), newFileWizardDialog.DefineInfos, analyzerName)
                        End If
                    End If
                Catch myex As MyException
                    Throw myex
                Catch ex As Exception
                    Throw New MyException(My.Resources.CED002_013_C, ex.Message)
                End Try
            End If
        End Sub

        Private Sub CreateProgram(ByVal newFileFullName As String, ByVal templateContentList As List(Of String), ByVal defineList As Dictionary(Of String, String), ByVal analyzerName As String)
            Dim analyzer As CobolEDCore.Interfaces.Analyzer.ICobolEDAnalyzer
            analyzer = AnalyzerManager.Analyzers(analyzerName)
            If DocumentManager.Documents(newFileFullName) Is Nothing Then
                DocumentManager.AddDocument(newFileFullName, templateContentList, defineList)
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
                DocumentFormManager.ActivateDocumentForm(newFileFullName, FormWindowState.Maximized)
            End If
        End Sub

        Private Function CreateWizzard(ByVal templateName As String) As NewFileWizardDialog
            Dim result As NewFileWizardDialog
            result = New NewFileWizardDialog(templateName)
            If Not result.CreateSuccess Then
                result = Nothing
            Else
            End If
            Return result
        End Function

        Private Function GetTemplateContent(ByVal hasTemplate As Boolean, Optional ByVal xmlDoc As XmlDocument = Nothing) As List(Of String)
            Dim nodeList As XmlNodeList
            Dim contentList As List(Of String)
            Try
                contentList = New List(Of String)
                If hasTemplate AndAlso xmlDoc IsNot Nothing Then
                    nodeList = xmlDoc.SelectNodes(XML_SOURCE_DEFINE)
                    For i As Integer = 0 To nodeList.Count - 1
                        contentList.Add(nodeList(i).InnerText())
                    Next
                Else
                    contentList.Add(String.Empty)
                End If
            Catch ex As Exception
                contentList = Nothing
                Throw New Common.MyException(My.Resources.CED002_013_C, ex.Message)
            End Try
            Return contentList
        End Function

    End Class

End Namespace
