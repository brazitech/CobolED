'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OptionFileExtensionsView.vb                             --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
'--                                                                           --
'--  NameSpace     :  CobolED.Views                                           --
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

Imports CobolED.Managers.Manager
Imports CobolED.Dialogues
Imports CobolEDCore.Infos.Setting
Imports System.Text
Namespace Views
    Public Class OptionFileExtensionsView

        Private Const FileExtensionSeparator As String = "."

        Private _fileExtensionsDialog As FileExtensionDialog

        Public Sub New()

            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            _fileExtensionsDialog = New FileExtensionDialog
        End Sub

        Public Overrides Sub Initialize(ByVal settingInfo As SettingInfo)
            Dim listViewItem As ListViewItem
            Dim extensions As StringBuilder

            Me._lsvFileExtensions.Items.Clear()

            For Each analyzerName As String In AnalyzerManager.AnalyzerNames
                extensions = New StringBuilder(String.Empty)
                listViewItem = Me._lsvFileExtensions.Items.Add(analyzerName)
                For Each fileExtension As String In settingInfo.FileExtension.Keys
                    If settingInfo.FileExtension(fileExtension) = analyzerName Then
                        extensions.Append(fileExtension)
                    End If
                Next
                listViewItem.SubItems.Add(extensions.ToString)
            Next
        End Sub

        Public Overrides Sub SetPartSettingInfo(ByRef settingInfo As SettingInfo)
            Dim strAnalyzerName As String

            settingInfo.FileExtension.Clear()
            For Each listItem As ListViewItem In Me._lsvFileExtensions.Items
                strAnalyzerName = listItem.SubItems(0).Text
                For Each extension As String In GetExtensionList(listItem.SubItems(1).Text)
                    settingInfo.FileExtension.Add(extension, strAnalyzerName)
                Next
            Next
        End Sub

        Private Sub _lsvFileExptensions_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lsvFileExtensions.DoubleClick
            Dim result As StringBuilder
            Dim analyzerName As String

            analyzerName = Me._lsvFileExtensions.SelectedItems(0).SubItems(0).Text
            _fileExtensionsDialog.AnalyzerName = analyzerName
            _fileExtensionsDialog.Extensions = Me._lsvFileExtensions.SelectedItems(0).SubItems(1).Text
            _fileExtensionsDialog.ShowDialog()
            If _fileExtensionsDialog.DialogResult = DialogResult.OK Then
                result = New StringBuilder(String.Empty)
                For Each extension As String In GetExtensionList(_fileExtensionsDialog.Extensions)
                    If Not IsExistExtension(analyzerName, extension) Then
                        result.Append(extension)
                    Else
                    End If
                Next
                Me._lsvFileExtensions.SelectedItems(0).SubItems(1).Text = result.ToString
            Else
            End If
        End Sub

        Private Function GetExtensionList(ByVal strExtensions As String) As List(Of String)
            Dim rtnList As List(Of String)
            Dim arrayExtensions() As String

            rtnList = New List(Of String)
            arrayExtensions = strExtensions.Split(FileExtensionSeparator)
            If arrayExtensions.Length > 1 Then
                For i As Integer = 1 To arrayExtensions.Length - 1
                    If arrayExtensions(i) <> String.Empty AndAlso _
                       rtnList.IndexOf(FileExtensionSeparator & arrayExtensions(i).ToLower) < 0 Then
                        rtnList.Add(FileExtensionSeparator & arrayExtensions(i).ToLower)
                    Else
                    End If
                Next
            Else
            End If
            Return rtnList
        End Function

        Private Function IsExistExtension(ByVal strAnalyzerName As String, ByVal strExtionsion As String) As Boolean
            Dim blnRtn As Boolean

            blnRtn = False
            For Each listItem As ListViewItem In Me._lsvFileExtensions.Items
                If listItem.SubItems(0).Text <> strAnalyzerName Then
                    If GetExtensionList(listItem.SubItems(1).Text).IndexOf(strExtionsion) >= 0 Then
                        blnRtn = True
                        Exit For
                    Else
                    End If
                Else
                End If
            Next
            Return blnRtn
        End Function

    End Class
End Namespace
