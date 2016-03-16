'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CobolSyntax.vb                                          --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDAnalyzer.Cobol                                   --
'--                                                                           --
'--  Project       :  CobolEDAnalyzer                                         --
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

Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Document
Imports CobolEDCore.Enums
Imports CobolEDCore.AnalyzerBase
Imports System.Text


Namespace Cobol
    Public Class CobolSyntax
        Inherits SyntaxBase

        Private Const XML_GRAMMAR_FILE As String = "Analyzer\CobolSyntax.xml"
        Private Const XML_FUNCTION_PRODUCTION_PATH As String = "Syntax/FunctionDefineGrammar/Productions/Production"
        Private Const XML_FUNCTION_PPTABLE_PATH As String = "Syntax/FunctionDefineGrammar/PredictiveParsingTable/Item"
        Private Const XML_VARIABLE_PRODUCTION_PATH As String = "Syntax/VariableDefineGrammar/Productions/Production"
        Private Const XML_VARIABLE_PPTABLE_PATH As String = "Syntax/VariableDefineGrammar/PredictiveParsingTable/Item"
        Private Const XML_INCLUDE_PRODUCTION_PATH As String = "Syntax/IncludeDefineGrammar/Productions/Production"
        Private Const XML_INCLUDE_PPTABLE_PATH As String = "Syntax/IncludeDefineGrammar/PredictiveParsingTable/Item"

        Private Const ITEM_FUNCTION_NAME As String = "(FunctionName)"
        Private Const ITEM_FUNCTION_START As String = "(FunctionDefine)"
        Private Const ITEM_VARIABLE_NAME As String = "(VariableName)"
        Private Const ITEM_VARIABLE_LEVEL As String = "(LevelNumber)"
        Private Const ITEM_VARIABLE_TYPE As String = "(VariableType)"
        Private Const ITEM_VARIABLE_START As String = "(VariableDefine)"
        Private Const ITEM_INCLUDE_NAME As String = "(IncludeName)"
        Private Const ITEM_INCLUDE_START As String = "(IncludeDefine)"


        Private Const KEYWORD_SECTION As String = "SECTION"

        Private Const LAYER_RENAMES As Integer = 66
        Private Const LAYER_SIMPLE As Integer = 77
        Private Const LAYER_CONDITION As Integer = 88
        Private Const LAYER_MAX As Integer = 99

        Private _functionPredictiveParsingTable As PredictiveParsingTableInfo
        Private _variablePredictiveParsingTable As PredictiveParsingTableInfo
        Private _includePredictiveParsingTable As PredictiveParsingTableInfo

        Public Sub New(ByVal cobolEDLex As ICobolEDLex)
            MyBase.New(cobolEDLex)
            _functionPredictiveParsingTable = GetPredictiveParsingTable(XML_GRAMMAR_FILE, XML_FUNCTION_PRODUCTION_PATH, XML_FUNCTION_PPTABLE_PATH)
            _variablePredictiveParsingTable = GetPredictiveParsingTable(XML_GRAMMAR_FILE, XML_VARIABLE_PRODUCTION_PATH, XML_VARIABLE_PPTABLE_PATH)
            _includePredictiveParsingTable = GetPredictiveParsingTable(XML_GRAMMAR_FILE, XML_INCLUDE_PRODUCTION_PATH, XML_INCLUDE_PPTABLE_PATH)
        End Sub

        Public Overrides Sub GetMembers(ByVal document As Document, ByRef functions As List(Of FunctionInfo), ByRef variables As List(Of VariableInfo), ByRef includes As List(Of IncludeInfo))
            Dim sentenceInfos As List(Of SentenceInfo)
            Dim functionInfo As FunctionInfo
            Dim variableInfo As VariableInfo
            Dim includeInfo As IncludeInfo

            Dim currentSECTION As String
            Dim variableLayer As Integer
            Dim parentArray(LAYER_MAX) As String

            sentenceInfos = GetSentences(document, False)
            currentSECTION = String.Empty
            functions = New List(Of FunctionInfo)
            variables = New List(Of VariableInfo)

            For Each sentenceInfo As SentenceInfo In sentenceInfos

                'Function
                functionInfo = GetFunction(sentenceInfo)
                If functionInfo IsNot Nothing Then
                    functionInfo.FunctionFileName = document.DocumentFileName
                    functionInfo.FunctionDeclare = document.DocumentString(New Position(sentenceInfo.StartRow, sentenceInfo.StartCol), _
                                                                           New Position(sentenceInfo.EndRow, sentenceInfo.EndCol))
                    If functionInfo.FunctionDeclare.IndexOf(KEYWORD_SECTION) = -1 Then
                        functionInfo.FunctionParent = currentSECTION
                    Else
                        currentSECTION = functionInfo.FunctionName
                    End If
                    functions.Add(functionInfo)
                End If

                'Variable
                variableInfo = GetVariable(sentenceInfo)
                If variableInfo IsNot Nothing Then
                    variableInfo.VariableFileName = document.DocumentFileName
                    variableInfo.VariableDeclare = document.DocumentString(New Position(sentenceInfo.StartRow, sentenceInfo.StartCol), _
                                                                           New Position(sentenceInfo.EndRow, sentenceInfo.EndCol))

                    variableLayer = CInt(variableInfo.VariableLayer)
                    If variableLayer > LAYER_MAX Then

                    ElseIf variableLayer = LAYER_RENAMES OrElse _
                           variableLayer = LAYER_SIMPLE OrElse _
                           variableLayer = LAYER_CONDITION Then
                        For index As Integer = 0 To LAYER_MAX
                            parentArray(index) = Nothing
                        Next
                    Else
                        For index As Integer = variableLayer + 1 To LAYER_MAX
                            parentArray(index) = Nothing
                        Next
                        For index As Integer = variableLayer - 1 To 1 Step -1
                            If parentArray(index) IsNot Nothing Then
                                variableInfo.VariableParent = parentArray(index)
                                Exit For
                            End If
                        Next
                        parentArray(variableLayer) = variableInfo.VariableName
                    End If

                    variables.Add(variableInfo)
                End If

                'Include
                includeInfo = GetInclude(sentenceInfo)
                If includeInfo IsNot Nothing Then
                    includeInfo.IncludeDeclare = document.DocumentString(New Position(sentenceInfo.StartRow, sentenceInfo.StartCol), _
                                                                         New Position(sentenceInfo.EndRow, sentenceInfo.EndCol))
                    includes.Add(includeInfo)
                End If
            Next

        End Sub

        Public Overrides Function GetFunctions(ByVal document As Document) As List(Of FunctionInfo)
            Dim sentenceInfos As List(Of SentenceInfo)
            Dim functionInfo As FunctionInfo
            Dim result As List(Of FunctionInfo)
            Dim currentSECTION As String

            sentenceInfos = GetSentences(document, False)
            result = New List(Of FunctionInfo)
            currentSECTION = String.Empty
            For Each sentenceInfo As SentenceInfo In sentenceInfos
                functionInfo = GetFunction(sentenceInfo)
                If functionInfo IsNot Nothing Then
                    functionInfo.FunctionFileName = document.DocumentFileName
                    functionInfo.FunctionDeclare = document.DocumentString(New Position(sentenceInfo.StartRow, sentenceInfo.StartCol), _
                                                                           New Position(sentenceInfo.EndRow, sentenceInfo.EndCol))
                    If functionInfo.FunctionDeclare.IndexOf(KEYWORD_SECTION) = -1 Then
                        functionInfo.FunctionParent = currentSECTION
                    Else
                        currentSECTION = functionInfo.FunctionName
                    End If
                    result.Add(functionInfo)
                End If
            Next

            Return result
        End Function

        Public Overrides Function GetIncludes(ByVal document As Document) As List(Of IncludeInfo)
            Dim sentenceInfos As List(Of SentenceInfo)
            Dim includeInfo As IncludeInfo
            Dim result As List(Of IncludeInfo)

            sentenceInfos = GetSentences(document, False)
            result = New List(Of IncludeInfo)
            For Each sentenceInfo As SentenceInfo In sentenceInfos
                includeInfo = GetInclude(sentenceInfo)
                If includeInfo IsNot Nothing Then
                    includeInfo.IncludeDeclare = document.DocumentString(New Position(sentenceInfo.StartRow, sentenceInfo.StartCol), _
                                                                         New Position(sentenceInfo.EndRow, sentenceInfo.EndCol))
                    result.Add(includeInfo)
                End If
            Next

            Return result
        End Function

        Public Overrides Function GetVariables(ByVal document As Document) As List(Of VariableInfo)
            Dim sentenceInfos As List(Of SentenceInfo)
            Dim variableInfo As VariableInfo
            Dim result As List(Of VariableInfo)

            Dim variableLayer As Integer
            Dim parentArray(LAYER_MAX) As String

            sentenceInfos = GetSentences(document, False)
            result = New List(Of VariableInfo)
            For Each sentenceInfo As SentenceInfo In sentenceInfos
                variableInfo = GetVariable(sentenceInfo)
                If variableInfo IsNot Nothing Then
                    variableInfo.VariableFileName = document.DocumentFileName
                    variableInfo.VariableDeclare = document.DocumentString(New Position(sentenceInfo.StartRow, sentenceInfo.StartCol), _
                                                                           New Position(sentenceInfo.EndRow, sentenceInfo.EndCol))

                    variableLayer = CInt(variableInfo.VariableLayer)
                    If variableLayer > LAYER_MAX Then

                    ElseIf variableLayer = LAYER_RENAMES OrElse _
                           variableLayer = LAYER_SIMPLE OrElse _
                           variableLayer = LAYER_CONDITION Then
                        For index As Integer = 0 To LAYER_MAX
                            parentArray(index) = Nothing
                        Next
                    Else
                        For index As Integer = variableLayer + 1 To LAYER_MAX
                            parentArray(index) = Nothing
                        Next
                        For index As Integer = variableLayer - 1 To 1 Step -1
                            If parentArray(index) IsNot Nothing Then
                                variableInfo.VariableParent = parentArray(index)
                                Exit For
                            End If
                        Next
                        parentArray(variableLayer) = variableInfo.VariableName
                    End If

                    result.Add(variableInfo)
                End If
            Next
            Return result
        End Function

        Public Overrides Function GetFunction(ByVal sentenceInfo As SentenceInfo) As FunctionInfo
            Dim result As FunctionInfo
            Dim wordList As List(Of WordInfo)
            Dim partFunctionInfo As Dictionary(Of String, StringBuilder)

            wordList = New List(Of WordInfo)(sentenceInfo.Words.ToArray)
            partFunctionInfo = New Dictionary(Of String, StringBuilder)
            partFunctionInfo.Add(ITEM_FUNCTION_NAME, New StringBuilder)

            If SyntaxParse(wordList, New SymbolInfo(ITEM_FUNCTION_START, False), _functionPredictiveParsingTable, partFunctionInfo) Then
                result = New FunctionInfo(partFunctionInfo(ITEM_FUNCTION_NAME).ToString, String.Empty, sentenceInfo.StartRow, String.Empty, String.Empty)
            Else
                result = Nothing
            End If
            Return result
        End Function

        Public Overrides Function GetInclude(ByVal sentenceInfo As SentenceInfo) As IncludeInfo
            Dim result As IncludeInfo
            Dim wordList As List(Of WordInfo)
            Dim partIncludeInfo As Dictionary(Of String, StringBuilder)

            wordList = New List(Of WordInfo)(sentenceInfo.Words.ToArray)
            partIncludeInfo = New Dictionary(Of String, StringBuilder)
            partIncludeInfo.Add(ITEM_INCLUDE_NAME, New StringBuilder)

            If SyntaxParse(wordList, New SymbolInfo(ITEM_INCLUDE_START, False), _includePredictiveParsingTable, partIncludeInfo) Then
                result = New IncludeInfo(partIncludeInfo(ITEM_INCLUDE_NAME).ToString, String.Empty, String.Empty, String.Empty)
            Else
                result = Nothing
            End If
            Return result
        End Function

        Public Overrides Function GetVariable(ByVal sentenceInfo As SentenceInfo) As VariableInfo
            Dim result As VariableInfo
            Dim wordList As List(Of WordInfo)
            Dim partVariableInfo As Dictionary(Of String, StringBuilder)

            wordList = New List(Of WordInfo)(sentenceInfo.Words.ToArray)
            partVariableInfo = New Dictionary(Of String, StringBuilder)
            partVariableInfo.Add(ITEM_VARIABLE_NAME, New StringBuilder)
            partVariableInfo.Add(ITEM_VARIABLE_TYPE, New StringBuilder)
            partVariableInfo.Add(ITEM_VARIABLE_LEVEL, New StringBuilder)

            If SyntaxParse(wordList, New SymbolInfo(ITEM_VARIABLE_START, False), _variablePredictiveParsingTable, partVariableInfo) Then
                result = New VariableInfo(partVariableInfo(ITEM_VARIABLE_NAME).ToString, _
                                          partVariableInfo(ITEM_VARIABLE_TYPE).ToString, _
                                          String.Empty, _
                                          partVariableInfo(ITEM_VARIABLE_LEVEL).ToString, _
                                          String.Empty, _
                                          sentenceInfo.StartRow, _
                                          String.Empty, _
                                          String.Empty)
            Else
                result = Nothing
            End If
            Return result
        End Function

    End Class
End Namespace
