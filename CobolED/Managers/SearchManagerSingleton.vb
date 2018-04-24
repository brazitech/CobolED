'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  SearchManagerSingleton.vb                               --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
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

Imports CobolEDCore.Interfaces.SearchEngine
Imports CobolED.Forms
Imports CobolED.Dialogues
Imports System.Windows.Forms
Imports System.Xml
Imports System.Reflection
Imports Common

Namespace Managers
    Public Class SearchManagerSingleton

        Private Const XmlSearchenginedefinePath As String = "CobolEDComponentDefines/CobolEDSearchEngineDefine"
        Private Const XmlClassnameAttribute As String = "ClassName"
        Private Const XmlFilenameAttribute As String = "FileName"

        Private Shared _searchManager As SearchManagerSingleton

        Private _cobolEDSearchEngine As ICobolEDSearchEngine
        Private _findDialog As FindDialog

        Private Sub New()
            _cobolEDSearchEngine = Nothing
            _findDialog = New FindDialog(CobolEdMainForm)
        End Sub

        Public Shared ReadOnly Property SearchManager() As SearchManagerSingleton
            Get
                If _searchManager Is Nothing Then
                    _searchManager = New SearchManagerSingleton
                End If
                Return _searchManager
            End Get
        End Property

        Public ReadOnly Property CobolEDSearchEngine() As ICobolEDSearchEngine
            Get
                Return _cobolEDSearchEngine
            End Get
        End Property

        Public ReadOnly Property FindDialog() As FindDialog
            Get
                _findDialog.IsFind = True
                Return _findDialog
            End Get
        End Property

        Public ReadOnly Property ReplaceDialog() As FindDialog
            Get
                _findDialog.IsFind = False
                Return _findDialog
            End Get
        End Property

        Public ReadOnly Property HasFindHistory() As Boolean
            Get
                If _findDialog._cmbFindString.Items.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Sub CreateSearchEngine(ByVal xmlDoc As XmlDocument)
            Dim searchEngineDefineNode As XmlNode
            Dim searchEngineClassName As String
            Dim searchEngineFileName As String
            Dim searchEngineType As Type

            Try
                searchEngineDefineNode = xmlDoc.SelectSingleNode(XmlSearchenginedefinePath)
                searchEngineClassName = searchEngineDefineNode.Attributes(XmlClassnameAttribute).Value
                searchEngineFileName = IO.Path.Combine(Application.StartupPath, searchEngineDefineNode.Attributes(XmlFilenameAttribute).Value)
                searchEngineType = Assembly.LoadFile(searchEngineFileName).GetType(searchEngineClassName)
                _cobolEDSearchEngine = Activator.CreateInstance(searchEngineType)
            Catch ex As Exception
                Throw New MyException(My.Resources.CED002_005_C, ex.Message)
            End Try
        End Sub
        
    End Class
End Namespace
