'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  SettingManagerSingleton.vb                              --
'--                                                                           --
'--  Author(s)     :  Chen Qinghua, Robert Skolnick NVSDI         --
'--                                                                           --
'--  NameSpace     :  CobolED.Managers                                        --
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

Imports CobolEDCore.Infos.Setting
Imports CobolEDCore.Enums
Imports CobolED.Forms
Imports CobolED.Managers.Manager
Imports System.Drawing
Imports System.Xml
Imports System.Text
Imports Common

Namespace Managers
    Public Class SettingManagerSingleton

        Private Const XmlRecentprojectcountDefinePath As String = "CobolEDSettingDefines/GeneralDefines/MaxRecentProjectCount"
        Private Const XmlRecentfilecountDefinePath As String = "CobolEDSettingDefines/GeneralDefines/MaxRecentFileCount"
        Private Const XmlFontcolorDefinePath As String = "CobolEDSettingDefines/FontColorDefines/FontColorDefine"
        Private Const XmlRecentprojectsPath As String = "CobolEDSettingDefines/RecentProjects/RecentProject"
        Private Const XmlRecentfilesPath As String = "CobolEDSettingDefines/RecentFiles/RecentFile"
        Private Const XmlFileextensionDefinePath As String = "CobolEDSettingDefines/FileExtensionDefines/FileExtensionDefine"

        Private Const XmlRootElement As String = "CobolEDSettingDefines"
        Private Const XmlGeneralDefines As String = "GeneralDefines"
        Private Const XmlGeneralMaxrecentprojectcount As String = "MaxRecentProjectCount"
        Private Const XmlGeneralMaxrecentfilecount As String = "MaxRecentFileCount"
        Private Const XmlRecentprojects As String = "RecentProjects"
        Private Const XmlRecentproject As String = "RecentProject"
        Private Const XmlRecentfiles As String = "RecentFiles"
        Private Const XmlRecentfile As String = "RecentFile"

        Private Const XmlFontcolorDefines As String = "FontColorDefines"
        Private Const XmlFontcolorDefine As String = "FontColorDefine"
        Private Const XmlFontcolorIdAtrribute As String = "Id"
        Private Const XmlFontcolorColorrAtrribute As String = "ColorR"
        Private Const XmlFontcolorColorgAtrribute As String = "ColorG"
        Private Const XmlFontcolorColorbAtrribute As String = "ColorB"
        Private Const XmlFileextensionDefines As String = "FileExtensionDefines"
        Private Const XmlFileextensionDefine As String = "FileExtensionDefine"
        Private Const XmlFileextensionExtensionAtrribute As String = "FileExtension"
        Private Const XmlFileextensionAnalyzerAttribute As String = "AnalyzerName"

        Private _settingInfo As SettingInfo
        Private Shared _settingManager As SettingManagerSingleton
        Public Delegate Sub SetSettingInfoDelegate(ByRef settingInfo As SettingInfo)

        Private Sub New()
            _settingInfo = GetDefaultSettingInfo()
        End Sub

        Public Shared ReadOnly Property SettingManager() As SettingManagerSingleton
            Get
                If _settingManager Is Nothing Then
                    _settingManager = New SettingManagerSingleton
                End If
                Return _settingManager
            End Get
        End Property

        Public ReadOnly Property SettingInfo() As SettingInfo
            Get
                Return _settingInfo
            End Get
        End Property

        Public Sub LoadFromXml(ByVal xmlFileName As String)
            Dim fontColorId As Integer
            Dim fontColorR As Integer
            Dim fontColorG As Integer
            Dim fontColorB As Integer
            Dim extension As String
            Dim analyzer As String
            Dim xmlDoc As XmlDocument

            Try
                xmlDoc = New XmlDocument
                xmlDoc.Load(xmlFileName)

                _settingInfo.MaxRecentProjectCount = xmlDoc.SelectSingleNode(XmlRecentprojectcountDefinePath).InnerText
                _settingInfo.MaxRecentFileCount = xmlDoc.SelectSingleNode(XmlRecentfilecountDefinePath).InnerText

                _settingInfo.RecentProjects.Clear()
                For Each recentProjectNode As XmlNode In xmlDoc.SelectNodes(XmlRecentprojectsPath)
                    _settingInfo.RecentProjects.Add(recentProjectNode.InnerText)
                Next

                _settingInfo.RecentFiles.Clear()
                For Each recentFileNode As XmlNode In xmlDoc.SelectNodes(XmlRecentfilesPath)
                    _settingInfo.RecentFiles.Add(recentFileNode.InnerText)
                Next

                _settingInfo.FontColor.Clear()
                For Each fontColorNode As XmlNode In xmlDoc.SelectNodes(XmlFontcolorDefinePath)
                    fontColorId = fontColorNode.Attributes(XmlFontcolorIdAtrribute).Value
                    fontColorR = fontColorNode.Attributes(XmlFontcolorColorrAtrribute).Value
                    fontColorG = fontColorNode.Attributes(XmlFontcolorColorgAtrribute).Value
                    fontColorB = fontColorNode.Attributes(XmlFontcolorColorbAtrribute).Value
                    _settingInfo.FontColor.Add(fontColorId, Color.FromArgb(fontColorR, fontColorG, fontColorB))
                Next

                _settingInfo.FileExtension.Clear()
                For Each fileExtensionNode As XmlNode In xmlDoc.SelectNodes(XmlFileextensionDefinePath)
                    extension = fileExtensionNode.Attributes(XmlFileextensionExtensionAtrribute).Value
                    analyzer = fileExtensionNode.Attributes(XmlFileextensionAnalyzerAttribute).Value
                    _settingInfo.FileExtension.Add(extension, analyzer)
                Next
            Catch ex As Exception
                _settingInfo = GetDefaultSettingInfo()
                Common.Message.ShowMessage(My.Resources.CED002_001_I, xmlFileName)
            End Try

        End Sub

        Public Sub SetSettingInfo(ByVal setSettingInfoDelegate As SetSettingInfoDelegate)
            setSettingInfoDelegate.Invoke(_settingInfo)
            RefreshAllDocumentForm()
        End Sub

        Public Sub SaveToXml(ByVal xmlFileName As String)
            Dim xmlWriteSettings As XmlWriterSettings
            Dim xmlWriter As XmlWriter

            xmlWriter = Nothing
            Try
                xmlWriteSettings = New Xml.XmlWriterSettings()
                xmlWriteSettings.Encoding = Encoding.GetEncoding(Globalization.CultureInfo.CurrentCulture.TextInfo.ANSICodePage)
                xmlWriteSettings.Indent = True

                xmlWriter = Xml.XmlWriter.Create(xmlFileName, xmlWriteSettings)
                xmlWriter.WriteStartElement(XmlRootElement)

                xmlWriter.WriteStartElement(XmlGeneralDefines)
                xmlWriter.WriteStartElement(XmlGeneralMaxrecentprojectcount)
                xmlWriter.WriteValue(SettingInfo.MaxRecentProjectCount)
                xmlWriter.WriteEndElement()
                xmlWriter.WriteStartElement(XmlGeneralMaxrecentfilecount)
                xmlWriter.WriteValue(SettingInfo.MaxRecentFileCount)
                xmlWriter.WriteEndElement()
                xmlWriter.WriteFullEndElement()

                xmlWriter.WriteStartElement(XmlRecentprojects)
                For Each recentProject As String In SettingInfo.RecentProjects
                    xmlWriter.WriteStartElement(XmlRecentproject)
                    xmlWriter.WriteValue(recentProject)
                    xmlWriter.WriteEndElement()
                Next
                xmlWriter.WriteEndElement()

                xmlWriter.WriteStartElement(XmlRecentfiles)
                For Each recentFile As String In SettingInfo.RecentFiles
                    xmlWriter.WriteStartElement(XmlRecentfile)
                    xmlWriter.WriteValue(recentFile)
                    xmlWriter.WriteEndElement()
                Next
                xmlWriter.WriteEndElement()

                xmlWriter.WriteStartElement(XmlFontcolorDefines)
                For Each wordType As Integer In SettingInfo.FontColor.Keys
                    xmlWriter.WriteStartElement(XmlFontcolorDefine)
                    xmlWriter.WriteAttributeString(XmlFontcolorIdAtrribute, wordType.ToString)
                    xmlWriter.WriteAttributeString(XmlFontcolorColorrAtrribute, SettingInfo.FontColor(wordType).R.ToString)
                    xmlWriter.WriteAttributeString(XmlFontcolorColorgAtrribute, SettingInfo.FontColor(wordType).G.ToString)
                    xmlWriter.WriteAttributeString(XmlFontcolorColorbAtrribute, SettingInfo.FontColor(wordType).B.ToString)
                    xmlWriter.WriteEndElement()
                Next
                xmlWriter.WriteFullEndElement()

                xmlWriter.WriteStartElement(XmlFileextensionDefines)
                For Each extension As String In SettingInfo.FileExtension.Keys
                    xmlWriter.WriteStartElement(XmlFileextensionDefine)
                    xmlWriter.WriteAttributeString(XmlFileextensionExtensionAtrribute, extension)
                    xmlWriter.WriteAttributeString(XmlFileextensionAnalyzerAttribute, SettingInfo.FileExtension(extension))
                    xmlWriter.WriteEndElement()
                Next
                xmlWriter.WriteFullEndElement()

                xmlWriter.WriteFullEndElement()
                xmlWriter.WriteEndDocument()

                xmlWriter.Flush()

            Catch ex As Exception
                Throw New myexception(My.Resources.CED002_006_E, ex.Message)
            Finally
                If xmlWriter IsNot Nothing Then
                    xmlWriter.Close()
                End If
            End Try
        End Sub

        Public Sub RefreshOpenProjectHistory(ByVal newProject As String)
            If SettingInfo.RecentProjects.Contains(newProject) Then
                SettingInfo.RecentProjects.Remove(newProject)
                SettingInfo.RecentProjects.Insert(0, newProject)
            Else
                SettingInfo.RecentProjects.Insert(0, newProject)
                While SettingInfo.RecentProjects.Count > SettingInfo.MaxRecentProjectCount
                    SettingInfo.RecentProjects.RemoveAt(SettingInfo.MaxRecentProjectCount)
                End While
            End If
        End Sub

        Public Sub RefreshOpenFileHistory(ByVal newFile As String)
            If SettingInfo.RecentFiles.Contains(newFile) Then
                SettingInfo.RecentFiles.Remove(newFile)
                SettingInfo.RecentFiles.Insert(0, newFile)
            Else
                SettingInfo.RecentFiles.Insert(0, newFile)
                While SettingInfo.RecentFiles.Count > SettingInfo.MaxRecentFileCount
                    SettingInfo.RecentFiles.RemoveAt(SettingInfo.MaxRecentFileCount)
                End While
            End If
        End Sub

        Public Function GetDefaultSettingInfo() As SettingInfo
            Dim result As SettingInfo
            result = New SettingInfo

            result.MaxRecentProjectCount = 5
            result.MaxRecentFileCount = 5
            result.RecentProjects.Clear()
            result.RecentFiles.Clear()

            result.FontColor.Clear()
            result.FontColor.Add(WordTypeEnum.Comment, Color.Green)
            result.FontColor.Add(WordTypeEnum.NormalWord, Color.Black)
            result.FontColor.Add(WordTypeEnum.Number, Color.Brown)
            result.FontColor.Add(WordTypeEnum.Space, Color.White)
            result.FontColor.Add(WordTypeEnum.Operator, Color.Brown)
            result.FontColor.Add(WordTypeEnum.String, Color.Red)
            result.FontColor.Add(WordTypeEnum.Bracket, Color.Brown)
            result.FontColor.Add(WordTypeEnum.End, Color.Blue)
            result.FontColor.Add(WordTypeEnum.Symbol, Color.Brown)
            result.FontColor.Add(WordTypeEnum.KeyWord, Color.Blue)
            result.FontColor.Add(WordTypeEnum.Unknown, Color.Black)

            result.FileExtension.Clear()
            result.FileExtension.Add(".txt", "Text")
            result.FileExtension.Add(".cbl", "COBOL")
            result.FileExtension.Add(".cpy", "COPY")
            result.FileExtension.Add(".cob", "COBOL")

            Return result
        End Function

        Private Sub RefreshAllDocumentForm()
            For Each documentForm As DocumentForm In DocumentFormManager.DocumentForms
                documentForm.CobolEDEditor.FontColor = _settingInfo.FontColor
                documentForm.CobolEDEditor.Refresh()
            Next
        End Sub



    End Class
End Namespace
