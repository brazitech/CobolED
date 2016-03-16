'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  EditorManagerSingleton.vb                               --
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

Imports CobolEDCore.Interfaces.Editor
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Document
Imports CobolED.Managers.Manager
Imports System.Xml
Imports System.Reflection
Imports Common

Namespace Managers

    Public Class EditorManagerSingleton

        Private Const XML_EDITORDEFINE_PATH As String = "CobolEDComponentDefines/CobolEDEditorDefine"
        Private Const XML_CLASSNAME_ATTRIBUTE As String = "ClassName"
        Private Const XML_FILENAME_ATTRIBUTE As String = "FileName"

        Private Shared _editorManager As EditorManagerSingleton

        Private _cobolEDEditorType As Type

        Private Sub New()
        End Sub

        Public Shared ReadOnly Property EditorManager() As EditorManagerSingleton
            Get
                If _editorManager Is Nothing Then
                    _editorManager = New EditorManagerSingleton
                End If
                Return _editorManager
            End Get
        End Property

        Public Sub CreateEditorType(ByVal xmlDoc As XmlDocument)
            Dim editorDefineNode As XmlNode
            Dim editorClassName As String
            Dim editorFileName As String
            Try
                editorDefineNode = xmlDoc.SelectSingleNode(XML_EDITORDEFINE_PATH)
                editorClassName = editorDefineNode.Attributes(XML_CLASSNAME_ATTRIBUTE).Value
                editorFileName = IO.Path.Combine(Application.StartupPath, editorDefineNode.Attributes(XML_FILENAME_ATTRIBUTE).Value)
                _cobolEDEditorType = Assembly.LoadFile(editorFileName).GetType(editorClassName)
            Catch ex As Exception
                Throw New MyException(My.Resources.CED002_004_C, ex.Message)
            End Try

        End Sub

        Public Function CobolEDEditorFactory(ByVal document As Document, ByVal cobolEDAnalyzer As ICobolEDAnalyzer) As ICobolEDEditor
            Dim cobolEDEditor As ICobolEDEditor
            If _cobolEDEditorType IsNot Nothing Then
                cobolEDEditor = Activator.CreateInstance(_cobolEDEditorType)
                cobolEDEditor.Font = New System.Drawing.Font("ＭＳ Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
                cobolEDEditor.Initialize(document, cobolEDAnalyzer, SettingManager.SettingInfo.FontColor)
            Else
                cobolEDEditor = Nothing
            End If
            Return cobolEDEditor
        End Function

    End Class
End Namespace
