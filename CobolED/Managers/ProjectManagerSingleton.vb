'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ProjectManagerSingleton.vb                              --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick Nvsdi               --
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

Imports System.io
Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Document
Imports CobolED.Managers.Manager
Imports System.Xml
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Common


Namespace Managers

    Public Class ProjectManagerSingleton
        Private Const XmlProgramPath As String = "Project/Programs/Program"
        Private Const XmlRootElement = "Project"
        Private Const XmlProgeamsElement = "Programs"
        Private Const XmlProgeamElement = "Program"
        Private Const XmlBookmarksElement = "BookMarks"
        Private Const XmlBookmarkElement = "BookMark"
        Private Const XmlProgramNameAttribute As String = "FileName"
        Private Const XmlProgramTypeAttribute As String = "Type"
        Private Const XmlBookmarkFilenameAttribute = "FileName"
        Private Const XmlBookmarkLocationAttribute = "Location"

        Private _projectInfo As ProjectInfo

        Private Shared _projectManager As ProjectManagerSingleton

        Private Sub New()
            _projectInfo = Nothing
        End Sub

        Public Shared ReadOnly Property ProjectManager() As ProjectManagerSingleton
            Get
                If _projectManager Is Nothing Then
                    _projectManager = New ProjectManagerSingleton
                End If
                Return _projectManager
            End Get
        End Property

        Public ReadOnly Property ProjectInfo() As ProjectInfo
            Get
                Return _projectInfo
            End Get
        End Property

        Public Sub InitializeProjectInfo(ByVal projectFileName As String)            
            If File.Exists(projectFileName) Then
                _projectInfo = New ProjectInfo(projectFileName)
                InitializeProgramInfos(projectFileName)
            Else
                Throw New Common.MyException(My.Resources.CED002_014_E, projectFileName)
            End If
        End Sub

        Public Sub CreateProjectInfo(ByVal projectFileName As String)
            _projectInfo = New ProjectInfo(projectFileName)
        End Sub

        Public Sub AddProgramInfo(ByVal programFileName As String, ByVal programType As String)
            _projectInfo.ProgramInfos.Add(New ProgramInfo(programFileName, programType))
        End Sub

        Public Sub RemoveAllProgramInfo()
            _projectManager._projectInfo = Nothing
        End Sub

        Public Sub SaveProject()
            Dim attributeList As Dictionary(Of String, String)
            Dim parentPath As String
            Dim relativePath As String
            Dim xmlWriteSettings As XmlWriterSettings
            Dim xmlWriter As XmlWriter

            xmlWriter = Nothing
            Try
                parentPath = IO.Path.GetDirectoryName(Me.ProjectInfo.ProjectFileName)
                xmlWriteSettings = New Xml.XmlWriterSettings()
                xmlWriteSettings.Encoding = Encoding.GetEncoding(Globalization.CultureInfo.CurrentCulture.TextInfo.ANSICodePage)
                xmlWriteSettings.Indent = True

                xmlWriter = Xml.XmlWriter.Create(_projectInfo.ProjectFileName(), xmlWriteSettings)
                xmlWriter.WriteStartElement(XmlRootElement)

                xmlWriter.WriteStartElement(XmlProgeamsElement)
                attributeList = New Dictionary(Of String, String)
                For Each progarmInfo As ProgramInfo In Me._projectInfo.ProgramInfos()
                    relativePath = GetRelativePath(parentPath, progarmInfo.ProgramFileName, Path.DirectorySeparatorChar)
                    xmlWriter.WriteStartElement(XmlProgeamElement)
                    xmlWriter.WriteAttributeString(XmlProgramNameAttribute, relativePath)
                    xmlWriter.WriteAttributeString(XmlProgramTypeAttribute, progarmInfo.ProgramType)
                    xmlWriter.WriteEndElement()
                Next
                xmlWriter.WriteFullEndElement()

                xmlWriter.WriteStartElement(XmlBookmarksElement)
                For Each doc As Document In DocumentManager.Documents
                    relativePath = GetRelativePath(parentPath, doc.DocumentFileName, Path.DirectorySeparatorChar)
                    For Each bookMarkDefine As Integer In Me.GetBookMarkDefines(doc)
                        xmlWriter.WriteStartElement(XmlBookmarkElement)
                        xmlWriter.WriteAttributeString(XmlBookmarkFilenameAttribute, relativePath)
                        xmlWriter.WriteAttributeString(XmlBookmarkLocationAttribute, bookMarkDefine)
                        xmlWriter.WriteEndElement()
                    Next
                Next
                xmlWriter.WriteFullEndElement()

                xmlWriter.WriteFullEndElement()
                xmlWriter.WriteEndDocument()

                xmlWriter.Flush()

            Catch ex As Exception
                Throw New MyException(My.Resources.CED002_015_E, ex.Message)
            Finally
                If xmlWriter IsNot Nothing Then
                    xmlWriter.Close()
                End If
            End Try

        End Sub

        Public Sub RenameProgram(ByVal oldName As String, ByVal newName As String)
            If ProjectInfo IsNot Nothing Then
                For Each programInfo As ProgramInfo In Me._projectInfo.ProgramInfos()
                    If programInfo.ProgramFileName = oldName Then
                        programInfo.ProgramFileName = newName
                    End If
                Next
            End If
        End Sub

        Public Function GetRelativePath(ByVal basePath As String, ByVal combinePath As String, ByVal separater As String) As String
            Dim ret As String = combinePath
            Dim bPath() As String = basePath.Split(Separater)
            Dim cPath() As String = combinePath.Split(Separater)
            Dim i, j, parentCnt As Integer
            Dim sb As New System.Text.StringBuilder
            While i <= bPath.Length - 1 AndAlso String.Compare(bPath(i), cPath(i), True) = 0
                i = i + 1
            End While
            parentCnt = bPath.Length - i
            If parentCnt < bPath.Length Then
                For j = i To cPath.Length - 1
                    sb.Append(cPath(j))
                    If j < cPath.Length - 1 Then
                        sb.Append(Separater)
                    End If
                Next
                ret = sb.ToString
            End If
            Return ret
        End Function

        Public Function RemoveProgramInfo(ByVal programFileName As String) As Boolean
            For Each programInfo As ProgramInfo In _projectInfo.ProgramInfos
                If programInfo.ProgramFileName = programFileName Then
                    Return _projectInfo.ProgramInfos.Remove(programInfo)
                End If
            Next
            Return False
        End Function

        Private Sub InitializeProgramInfos(ByVal projectFileName As String)
            Dim programFileName As String
            Dim programType As String
            Dim projectPath As String
            Dim xmlDoc As XmlDocument

            If _projectInfo IsNot Nothing Then
                Try
                    projectPath = IO.Path.GetDirectoryName(projectFileName)
                    xmlDoc = New XmlDocument
                    xmlDoc.Load(projectFileName)
                    For Each programNode As XmlNode In xmlDoc.SelectNodes(XmlProgramPath)
                        programFileName = IO.Path.Combine(projectPath, programNode.Attributes(XmlProgramNameAttribute).Value)
                        programType = programNode.Attributes(XmlProgramTypeAttribute).Value
                        AddProgramInfo(programFileName, programType)
                    Next
                Catch ex As Exception
                    Throw New MyException(My.Resources.CED002_014_E, projectFileName)
                End Try
            Else
            End If
        End Sub

        Private Function GetBookMarkDefines(ByVal doc As Document) As List(Of Integer)
            Dim result As List(Of Integer)
            result = New List(Of Integer)
            For i As Integer = 0 To Doc.DocumentLinesCount - 1
                If Doc.DocumentLineBookMark(i) Then
                    result.Add(i)
                End If
            Next
            Return result
        End Function

    End Class

End Namespace
