'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  SyntaxBase.vb                                           --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDAnalyzer.Base                                    --
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
Imports System.Xml
Imports System.Text

Namespace AnalyzerBase
    Public MustInherit Class SyntaxBase
        Implements ICobolEDSyntax

        Private Const XML_ATTRIBUTE_PRODUCTION_NAME As String = "Name"
        Private Const XML_ATTRIBUTE_PRODUCTION_ID As String = "ID"
        Private Const XML_ATTRIBUTE_SYMBOL_NAME As String = "Name"
        Private Const XML_ATTRIBUTE_SYMBOL_TYPE As String = "Type"
        Private Const XML_ATTRIBUTE_SYMBOL_ISTERMINAL As String = "IsTerminal"
        Private Const XML_ATTRIBUTE_ITEM_ID As String = "ID"
        Private Const XML_ATTRIBUTE_ITEM_COL As String = "Col"

        Private _cobolEDLex As ICobolEDLex
        Private _functionPPT As PredictiveParsingTableInfo

        Public Sub New(ByVal cobolEDLex As ICobolEDLex)
            _cobolEDLex = cobolEDLex
        End Sub

        Public MustOverride Sub GetMembers(ByVal document As Document.Document, ByRef functions As List(Of FunctionInfo), ByRef variables As List(Of VariableInfo), ByRef includes As List(Of IncludeInfo)) Implements ICobolEDSyntax.GetMembers

        Public Overridable Function GetSentences(ByVal document As Document.Document, Optional ByVal withSpaceAndComment As Boolean = False) As List(Of SentenceInfo) Implements ICobolEDSyntax.GetSentences
            Dim row, col As Integer
            Dim sentenceInfo As SentenceInfo
            Dim result As List(Of SentenceInfo)

            row = 0
            col = 0
            result = New List(Of SentenceInfo)

            While row < document.DocumentLinesCount
                sentenceInfo = GetSentence(document, row, col, withSpaceAndComment)
                If sentenceInfo IsNot Nothing Then
                    result.Add(sentenceInfo)
                End If
                row = sentenceInfo.EndRow
                col = sentenceInfo.EndCol + 1

                If row = -1 Then
                    Exit While
                End If

                If col > document.DocumentLineString(row).Length - 1 Then
                    col = 0
                    row += 1
                End If

            End While

            Return result
        End Function

        Public Overridable Function GetSentence(ByVal document As Document.Document, ByVal startRow As Integer, ByVal startCol As Integer, Optional ByVal withSpaceAndComment As Boolean = False) As SentenceInfo Implements ICobolEDSyntax.GetSentence
            Dim sentenceWords As List(Of WordInfo)
            Dim sentenceStartRow As Integer
            Dim sentenceStartCol As Integer
            Dim sentenceEndRow As Integer
            Dim sentenceEndCol As Integer

            Dim currentRow As Integer
            Dim lineWords As List(Of WordInfo)
            Dim result As SentenceInfo
            Dim endWordNotFound As Boolean

            sentenceWords = New List(Of WordInfo)
            currentRow = startRow
            sentenceStartRow = -1
            sentenceStartCol = -1
            endWordNotFound = True

            While currentRow < document.DocumentLinesCount AndAlso endWordNotFound
                lineWords = CobolEDLex.GetWords(document.DocumentLineString(currentRow), withSpaceAndComment)
                For Each word As WordInfo In lineWords
                    If (currentRow > startRow) OrElse (currentRow = startRow AndAlso word.WordLocation >= startCol) Then

                        sentenceWords.Add(word)

                        If sentenceStartRow = -1 AndAlso sentenceStartCol = -1 Then
                            sentenceStartRow = currentRow
                            sentenceStartCol = word.WordLocation
                        Else
                        End If

                        If word.WordType = WordTypeEnum.End Then
                            endWordNotFound = False
                            Exit For
                        Else
                        End If

                    Else
                    End If
                Next

                If endWordNotFound Then
                    If currentRow + 1 > document.DocumentLinesCount Then
                        Exit While
                    Else
                        currentRow += 1
                    End If
                Else
                    Exit While
                End If
            End While

            If sentenceWords.Count = 0 Then
                sentenceEndRow = sentenceStartRow
                sentenceEndCol = sentenceStartCol
            Else
                sentenceEndRow = currentRow
                sentenceEndCol = sentenceWords(sentenceWords.Count - 1).WordLocation + sentenceWords(sentenceWords.Count - 1).WordString.Length - 1
            End If

            result = New SentenceInfo(sentenceStartRow, sentenceStartCol, sentenceEndRow, sentenceEndCol, sentenceWords)
            Return result

        End Function

        Public MustOverride Function GetFunctions(ByVal document As Document.Document) As List(Of FunctionInfo) Implements ICobolEDSyntax.GetFunctions

        Public MustOverride Function GetIncludes(ByVal document As Document.Document) As List(Of IncludeInfo) Implements ICobolEDSyntax.GetIncludes

        Public MustOverride Function GetVariables(ByVal document As Document.Document) As List(Of VariableInfo) Implements ICobolEDSyntax.GetVariables

        Public MustOverride Function GetFunction(ByVal sentenceInfo As SentenceInfo) As FunctionInfo Implements ICobolEDSyntax.GetFunction

        Public MustOverride Function GetVariable(ByVal sentenceInfo As SentenceInfo) As VariableInfo Implements ICobolEDSyntax.GetVariable

        Public MustOverride Function GetInclude(ByVal sentenceInfo As SentenceInfo) As IncludeInfo Implements ICobolEDSyntax.GetInclude

        Protected ReadOnly Property CobolEDLex() As ICobolEDLex
            Get
                Return _cobolEDLex
            End Get
        End Property

        Protected Function SyntaxParse(ByVal wordlist As List(Of WordInfo), ByVal startSymbol As SymbolInfo, ByVal predictiveParsingTable As PredictiveParsingTableInfo, Optional ByRef result As Dictionary(Of String, StringBuilder) = Nothing) As Boolean
            Dim parsingStack As Stack(Of SymbolInfo)
            Dim currentSymbol As SymbolInfo
            Dim productionInfo As ProductionInfo
            Dim saveResult As Dictionary(Of String, Integer)
            Dim saveResultKeyList As List(Of String)

            parsingStack = New Stack(Of SymbolInfo)
            parsingStack.Push(startSymbol)

            saveResult = New Dictionary(Of String, Integer)
            If result IsNot Nothing Then
                For Each resultSymbolName As String In result.Keys
                    saveResult.Add(resultSymbolName, -1)
                Next
            End If


            If wordlist.Count <= 0 Then
                Return False
            End If

            While parsingStack.Count > 0
                currentSymbol = parsingStack.Pop()
                If saveResult.ContainsKey(currentSymbol.Name) Then
                    saveResult(currentSymbol.Name) = parsingStack.Count
                End If

                If wordlist.Count > 0 Then
                    productionInfo = predictiveParsingTable.Items(currentSymbol.Name, GetNameFromWordInfo(wordlist(0)))
                Else
                    productionInfo = Nothing
                End If

                If productionInfo Is Nothing Then
                    Return False
                Else
                    'Push into stack
                    For index As Integer = productionInfo.Symbols.Count - 1 To 0 Step -1
                        parsingStack.Push(productionInfo.Symbols(index))
                    Next
                    saveResultKeyList = New List(Of String)
                    For Each saveResultName As String In saveResult.Keys
                        saveResultKeyList.Add(saveResultName)
                    Next
                    For Each saveResultName As String In saveResultKeyList
                        If saveResult(saveResultName) <> -1 AndAlso parsingStack.Count <= saveResult(saveResultName) Then
                            saveResult(saveResultName) = -1
                        End If
                    Next

                    'Pop from stack
                    While parsingStack.Count > 0 AndAlso parsingStack.Peek.IsTerminal = True
                        If wordlist.Count > 0 AndAlso parsingStack.Peek.Name = GetNameFromWordInfo(wordlist(0)) Then

                            currentSymbol = parsingStack.Pop()

                            For Each saveResultName As String In saveResult.Keys
                                If saveResult(saveResultName) <> -1 Then
                                    result(saveResultName).Append(wordlist(0).WordString)
                                Else
                                End If
                            Next

                            saveResultKeyList = New List(Of String)
                            For Each saveResultName As String In saveResult.Keys
                                saveResultKeyList.Add(saveResultName)
                            Next
                            For Each saveResultName As String In saveResultKeyList
                                If saveResult(saveResultName) <> -1 AndAlso parsingStack.Count <= saveResult(saveResultName) Then
                                    saveResult(saveResultName) = -1
                                End If
                            Next

                            wordlist.RemoveAt(0)

                        Else
                            Return False
                        End If
                    End While
                End If
            End While

            Return True
        End Function

        Protected Function GetNameFromWordInfo(ByVal wordInfo As WordInfo) As String
            Dim result As String
            Select Case wordInfo.WordType
                Case WordTypeEnum.NormalWord
                    result = "(NormalWord)"
                Case WordTypeEnum.Number
                    result = "(Number)"
                Case WordTypeEnum.Operator
                    result = "(Operator)"
                Case WordTypeEnum.String
                    result = "(String)"
                Case WordTypeEnum.Bracket
                    result = "(Bracket)"
                Case WordTypeEnum.End
                    result = "(End)"
                Case WordTypeEnum.Symbol
                    result = "(Symbol)"
                Case WordTypeEnum.KeyWord
                    result = wordInfo.WordString.ToUpper
                Case Else
                    result = "(Unknown)"
            End Select
            Return result
        End Function

        Protected Function GetPredictiveParsingTable(ByVal fileName As String, ByVal GrammarProductionsPath As String, ByVal PredictiveParsingTablePath As String) As PredictiveParsingTableInfo
            Dim result As New PredictiveParsingTableInfo
            Dim xmlDoc As New XmlDocument()
            Dim productions As New Dictionary(Of String, ProductionInfo)
            Dim itemID As String
            Dim itemCol As String

            If IO.File.Exists(fileName) Then
                xmlDoc.Load(fileName)
                productions = GetProductions(xmlDoc.SelectNodes(GrammarProductionsPath))

                For Each itemNode As XmlNode In xmlDoc.SelectNodes(PredictiveParsingTablePath)
                    itemID = itemNode.Attributes(XML_ATTRIBUTE_ITEM_ID).Value
                    itemCol = itemNode.Attributes(XML_ATTRIBUTE_ITEM_COL).Value
                    If productions.ContainsKey(itemID) Then
                        result.AddItem(productions(itemID), itemCol)
                    Else
                    End If
                Next

            Else
            End If
            Return result
        End Function

        Protected Function GetProductions(ByVal productionNodes As XmlNodeList) As Dictionary(Of String, ProductionInfo)
            Dim result As Dictionary(Of String, ProductionInfo)
            Dim productionInfo As ProductionInfo

            result = New Dictionary(Of String, ProductionInfo)

            For Each productiondNode As XmlNode In productionNodes
                productionInfo = GetProductionInfo(productiondNode)
                result.Add(productionInfo.ID, productionInfo)
            Next

            Return result
        End Function

        Protected Function GetProductionInfo(ByVal productionNode As XmlNode) As ProductionInfo
            Dim name As String
            Dim id As String
            Dim symbols As List(Of SymbolInfo)
            Dim symbolName As String
            Dim symbolIsTerminal As Boolean
            Dim result As ProductionInfo

            name = productionNode.Attributes(XML_ATTRIBUTE_PRODUCTION_NAME).Value
            id = productionNode.Attributes(XML_ATTRIBUTE_PRODUCTION_ID).Value
            symbols = New List(Of SymbolInfo)

            For Each symbolNode As XmlNode In productionNode.ChildNodes
                symbolName = symbolNode.Attributes(XML_ATTRIBUTE_SYMBOL_NAME).Value
                Select Case symbolNode.Attributes(XML_ATTRIBUTE_SYMBOL_ISTERMINAL).Value.ToUpper
                    Case "TRUE"
                        symbolIsTerminal = True
                    Case "FALSE"
                        symbolIsTerminal = False
                    Case Else
                        symbolIsTerminal = True
                End Select
                symbols.Add(New SymbolInfo(symbolName, symbolIsTerminal))
            Next

            result = New ProductionInfo(name, id, symbols)
            Return result

        End Function

    End Class
End Namespace
