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

        Private Const XmlEditordefinePath As String = "CobolEDComponentDefines/CobolEDEditorDefine"
        Private Const XmlClassnameAttribute As String = "ClassName"
        Private Const XmlFilenameAttribute As String = "FileName"

        Private Shared _editorManager As EditorManagerSingleton

        Private _cobolEdEditorType As Type

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
                editorDefineNode = xmlDoc.SelectSingleNode(XmlEditordefinePath)
                editorClassName = editorDefineNode.Attributes(XmlClassnameAttribute).Value
                editorFileName = IO.Path.Combine(Application.StartupPath, editorDefineNode.Attributes(XmlFilenameAttribute).Value)
                _cobolEDEditorType = Assembly.LoadFile(editorFileName).GetType(editorClassName)
            Catch ex As Exception
                Throw New MyException(My.Resources.CED002_004_C, ex.Message)
            End Try

        End Sub

        Public Function CobolEdEditorFactory(ByVal document As Document, ByVal cobolEdAnalyzer As ICobolEDAnalyzer) As ICobolEDEditor
            Dim cobolEdEditor As ICobolEDEditor
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
