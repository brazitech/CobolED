'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  DocumentManagerSingleton.vb                             --
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

Imports CobolEDCore.Document
Imports CobolEDCore.Infos.Analyzer
Imports System.Xml
Namespace Managers

    Public Class DocumentManagerSingleton

        Private Const XmlBookmarkPath As String = "Project/BookMarks/BookMark"
        Private Const XmlBookmarkFilenameAtrribute As String = "FileName"
        Private Const XmlBookmarkLocationAtrribute As String = "Location"
        Private _documents As List(Of Document)

        Private Shared _documentManager As DocumentManagerSingleton

        Private Sub New()
            _documents = New List(Of Document)
            _documents.Clear()
        End Sub

        Public Shared ReadOnly Property DocumentManager() As DocumentManagerSingleton
            Get
                If _documentManager Is Nothing Then
                    _documentManager = New DocumentManagerSingleton
                End If
                Return _documentManager
            End Get
        End Property

        Public ReadOnly Property Documents() As List(Of Document)
            Get
                Return _documents
            End Get
        End Property

        Public ReadOnly Property Documents(ByVal documentFileName As String) As Document
            Get
                For Each document As Document In _documents
                    If document.DocumentFileName = documentFileName Then
                        Return document
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public Sub Rename(ByVal oldName As String, ByVal newName As String)
            For Each document As Document In _documents
                If document.DocumentFileName = oldName Then
                    document.DocumentFileName = newName
                End If
            Next
        End Sub

        Public Sub InitializeDocuments(ByVal projectInfo As ProjectInfo)
            _documents.Clear()
            If projectInfo IsNot Nothing Then
                For Each programinfo As ProgramInfo In projectInfo.ProgramInfos
                    AddDocument(programinfo.ProgramFileName)
                Next
            Else
            End If
        End Sub

        Public Sub InitializeBookMark(ByVal projectFileName As String)
            Dim fileName As String
            Dim location As Integer
            Dim document As Document
            Dim projectPath As String

            projectPath = IO.Path.GetDirectoryName(projectFileName)
            For Each bookMarkNode As XmlNode In GetBookMarkFromProject(projectFileName)
                fileName = IO.Path.Combine(projectPath, bookMarkNode.Attributes(XmlBookmarkFilenameAtrribute).Value)
                location = bookMarkNode.Attributes(XmlBookmarkLocationAtrribute).Value
                document = Documents(fileName)
                If document IsNot Nothing AndAlso _
                   location >= 0 AndAlso location <= document.DocumentLinesCount - 1 Then
                    document.SetBookMark(location, True)
                End If
            Next
        End Sub

        Public Sub AddDocument(ByVal documentFileName As String)
            _documents.Add(New Document(documentFileName))
        End Sub

        Public Sub AddDocument(ByVal documentFileName As String, ByVal templateLines As List(Of String), ByVal defineList As Dictionary(Of String, String))            
            Dim documentLines As List(Of String)

            documentLines = New List(Of String)
            documentLines.AddRange(templateLines)

            For index As Integer = 0 To documentLines.Count - 1
                For Each defineKey As String In defineList.Keys
                    documentLines(index) = documentLines(index).Replace(defineKey, defineList(defineKey))
                Next
            Next
            _documents.Add(New Document(documentFileName, documentLines))
        End Sub

        Public Sub RemoveAllDocument()
            _documents.Clear()
        End Sub

        Public Function RemoveDocument(ByVal documentFileName As String) As Boolean
            For Each doc As Document In _documents
                If doc.DocumentFileName = documentFileName Then
                    Return _documents.Remove(doc)
                End If
            Next
            Return False
        End Function

        Public Function Reload(ByVal documentFileName As String) As Boolean
            RemoveDocument(DocumentFileName)
            AddDocument(DocumentFileName)
            If IO.File.Exists(DocumentFileName) Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function GetBookMarkFromProject(ByVal projectFileName As String) As XmlNodeList
            Dim result As XmlNodeList
            Dim xmlDoc As New XmlDocument

            Try
                xmlDoc.Load(projectFileName)
                result = xmlDoc.SelectNodes(XmlBookmarkPath)
            Catch ex As Exception
                result = Nothing
            End Try
            Return result
        End Function

    End Class

End Namespace
