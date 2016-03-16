'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnOpenFile.vb                                           --
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
Imports CobolEDCore.Interfaces.Analyzer

Namespace Menu.File
    Public Class OnOpenFile
        Inherits MenuItemProcessBase

        Private _openFileDialog As MyOpenFileDialog
        Private Const STR_COMMENT As String = "Opening a File that is saved"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _openFileDialog = New MyOpenFileDialog
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides Sub Execute()
            Dim documentFileName As String
            Dim documentFileExtension As String
            Dim cobolEDAnalyzerName As String
            Dim cobolEDAnalyzer As ICobolEDAnalyzer

            If _openFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                documentFileName = _openFileDialog.FileName
                documentFileExtension = IO.Path.GetExtension(documentFileName).ToLower
                cobolEDAnalyzerName = SettingManager.SettingInfo.FileExtension(documentFileExtension)
                If cobolEDAnalyzerName IsNot Nothing Then
                    cobolEDAnalyzer = AnalyzerManager.Analyzers(cobolEDAnalyzerName)
                Else
                    cobolEDAnalyzer = Nothing
                End If
                OpenFile(documentFileName, cobolEDAnalyzer)
            End If
        End Sub

        Private Sub OpenFile(ByVal fileName As String, ByVal cobolEDAnalyzer As ICobolEDAnalyzer)
            DocumentManager.AddDocument(fileName)
            DocumentFormManager.AddDocumentForm(DocumentManager.Documents(fileName), cobolEDAnalyzer)
            DocumentFormManager.ActivateDocumentForm(fileName, FormWindowState.Maximized)
            SettingManager.RefreshOpenFileHistory(fileName)
        End Sub

    End Class
End Namespace
