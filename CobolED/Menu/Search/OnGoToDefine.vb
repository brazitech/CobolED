'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnGoToDefine.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.Search                                     --
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
Imports CobolED.Managers.Manager
Imports CobolEDCore.Document
Imports CobolEDCore.Enums
Imports CobolEDCore.Interfaces.Editor
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Infos.Analyzer

Namespace Menu.Search
    Public Class OnGoToDefine
        Inherits MenuItemProcessBase

        Private Const StrComment As String = "Go to variable or function that you position at the cursor"

        Public Sub New(ByVal cobolEdMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return StrComment
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                If DocumentFormManager.CurrentDocumentForm IsNot Nothing AndAlso _
                   ProjectManager.ProjectInfo IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides Sub Execute()
            Dim currentWord As WordInfo
            Dim currentPosition As Position
            Dim currentForm As DocumentForm
            Dim cobolEdEditor As ICobolEDEditor
            Dim cobolEdLex As ICobolEDLex
            Dim document As Document
            Dim functionInfo As FunctionInfo
            Dim variableInfo As VariableInfo

            currentForm = DocumentFormManager.CurrentDocumentForm

            If currentForm IsNot Nothing AndAlso _
               currentForm.CobolEDEditor.CobolEDAnalyzer IsNot Nothing AndAlso _
               currentForm.CobolEDEditor.CobolEDAnalyzer.CobolEDLex IsNot Nothing AndAlso _
               currentForm.Document IsNot Nothing Then

                cobolEDEditor = currentForm.CobolEDEditor
                cobolEDLex = cobolEDEditor.CobolEDAnalyzer.CobolEDLex
                document = currentForm.Document
                currentPosition = cobolEDEditor.CaretPhysicalPosition
                currentWord = cobolEDLex.GetWordFromIndex(document.DocumentLineString(currentPosition.Row), currentPosition.Col)

                If currentWord.WordType = WordTypeEnum.NormalWord Then

                    functionInfo = MemberManager.GetFunctionInfo(document.DocumentFileName, currentWord.WordString, True)
                    If functionInfo IsNot Nothing Then
                        DocumentFormManager.ActivateDocumentForm(functionInfo.FunctionFileName, FormWindowState.Maximized)
                        DocumentFormManager.CurrentDocumentForm.CobolEDEditor.CaretMoveTo(functionInfo.MovePosition.Row, functionInfo.MovePosition.Col)
                        Return
                    Else
                    End If

                    variableInfo = MemberManager.GetVariableInfo(document.DocumentFileName, currentWord.WordString, True)
                    If variableInfo IsNot Nothing Then
                        DocumentFormManager.ActivateDocumentForm(variableInfo.VariableFileName, FormWindowState.Maximized)
                        DocumentFormManager.CurrentDocumentForm.CobolEDEditor.CaretMoveTo(variableInfo.MovePosition.Row, variableInfo.MovePosition.Col)
                        Return
                    End If

                Else
                End If
            End If
        End Sub

    End Class
End Namespace