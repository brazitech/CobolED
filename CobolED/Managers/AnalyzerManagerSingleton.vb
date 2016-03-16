'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  AnalyzerManagerSingleton.vb                             --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
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

Imports System.Xml
Imports System.Windows.Forms
Imports System.Reflection
Imports CobolEDCore.Interfaces.Analyzer
Imports Common

Namespace Managers

    Public Class AnalyzerManagerSingleton

        Private Const XML_ANALYZERDEFINE_PATH As String = "CobolEDComponentDefines/CobolEDAnalyzerDefines/CobolEDAnalyzerDefine"
        Private Const XML_ANALYZER_NAME_ATTRIBUTE As String = "Name"
        Private Const XML_ANALYZER_FILENAME_ATTRIBUTE As String = "FileName"
        Private Const XML_ANALYZER_CLASSNAME_ATTRIBUTE As String = "ClassName"
        Private Const DEFAULT_ANALYZER_NAME As String = "Text"

        Private _analyzers As Dictionary(Of String, ICobolEDAnalyzer)

        Private Shared _analyzerManager As AnalyzerManagerSingleton

        Private Sub New()
            _analyzers = New Dictionary(Of String, ICobolEDAnalyzer)
        End Sub

        Public Shared ReadOnly Property AnalyzerManager() As AnalyzerManagerSingleton
            Get
                If _analyzerManager Is Nothing Then
                    _analyzerManager = New AnalyzerManagerSingleton
                End If
                Return _analyzerManager
            End Get
        End Property

        Public ReadOnly Property Analyzers(ByVal analyzerName As String) As ICobolEDAnalyzer
            Get
                If _analyzers.ContainsKey(analyzerName) Then
                    Return _analyzers(analyzerName)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property AnalyzerNames() As List(Of String)
            Get
                Dim result As List(Of String)
                result = New List(Of String)
                For Each analyzerName As String In _analyzers.Keys
                    result.Add(analyzerName)
                Next
                Return result
            End Get
        End Property

        Public ReadOnly Property DefaultAnalyzerName() As String
            Get
                Return DEFAULT_ANALYZER_NAME
            End Get
        End Property

        Public ReadOnly Property DefaultAnalyzer() As ICobolEDAnalyzer
            Get
                Return Nothing
            End Get
        End Property

        Public Sub CreateAnalyzers(ByVal xmlDoc As XmlDocument)
            Dim analyzerType As Type
            Dim analyzerName As String
            Dim analyzerFileName As String
            Dim analyzerClassName As String
            _analyzers.Add(DEFAULT_ANALYZER_NAME, Nothing)

            Try
                For Each analyzerDefineNode As XmlNode In xmlDoc.SelectNodes(XML_ANALYZERDEFINE_PATH)

                    analyzerName = analyzerDefineNode.Attributes(XML_ANALYZER_NAME_ATTRIBUTE).Value
                    analyzerFileName = IO.Path.Combine(Application.StartupPath, analyzerDefineNode.Attributes(XML_ANALYZER_FILENAME_ATTRIBUTE).Value)
                    analyzerClassName = analyzerDefineNode.Attributes(XML_ANALYZER_CLASSNAME_ATTRIBUTE).Value
                    analyzerType = Assembly.LoadFile(analyzerFileName).GetType(analyzerClassName)
                    _analyzers.Add(analyzerName, Activator.CreateInstance(analyzerType))

                Next
            Catch ex As Exception
                Throw New MyException(My.Resources.CED002_003_C, ex.Message)
            End Try

        End Sub

    End Class

End Namespace
