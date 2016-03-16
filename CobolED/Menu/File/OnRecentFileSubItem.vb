'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnRecentFileSubItem.vb                                  --
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
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolED.Managers.Manager
Imports Common

Namespace Menu.File
    Public Class OnRecentFileSubItem
        Inherits MenuItemProcessBase

        Private _fileName As String
        Private Const STR_COMMENT As String = "Open the specified File"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm, ByVal projectName As String)
            MyBase.New(cobolEDMainForm)
            _fileName = projectName
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides Sub Execute()
            Dim documentFileExtension As String
            Dim cobolEDAnalyzerName As String
            Dim cobolEDAnalyzer As ICobolEDAnalyzer

            If IO.File.Exists(_fileName) = True Then
                If DocumentFormManager.DocumentForms(_fileName) IsNot Nothing Then
                    DocumentFormManager.DocumentForms(_fileName).Activate()
                Else
                    documentFileExtension = IO.Path.GetExtension(_fileName).ToLower
                    cobolEDAnalyzerName = SettingManager.SettingInfo.FileExtension(documentFileExtension)
                    If cobolEDAnalyzerName IsNot Nothing Then
                        cobolEDAnalyzer = AnalyzerManager.Analyzers(cobolEDAnalyzerName)
                    Else
                        cobolEDAnalyzer = Nothing
                    End If
                    OpenFile(_fileName, cobolEDAnalyzer)
                End If
            Else
                Throw New MyException(My.Resources.CED002_016_E, _fileName)
            End If
        End Sub

        Private Sub OpenFile(ByVal fileName As String, ByVal cobolEDAnalyzer As ICobolEDAnalyzer)
            DocumentManager.AddDocument(fileName)
            DocumentFormManager.AddDocumentForm(DocumentManager.Documents(fileName), cobolEDAnalyzer)
            DocumentFormManager.ActivateDocumentForm(fileName, FormWindowState.Maximized)
        End Sub
    End Class

End Namespace
