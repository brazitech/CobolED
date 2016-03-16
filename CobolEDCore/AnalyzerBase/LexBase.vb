'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  LexBase.vb                                              --
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
Imports CobolEDCore.Enums
Imports System.Xml
Imports System.Text

Namespace AnalyzerBase

    Public MustInherit Class LexBase
        Implements ICobolEDLex

        Private Const XML_ATTRIBUTE_STATUS_ID As String = "ID"
        Private Const XML_ATTRIBUTE_STATUS_ISTERMINAL As String = "IsTerminal"
        Private Const XML_ATTRIBUTE_STATUS_NEEDBACK As String = "NeedBack"
        Private Const XML_ATTRIBUTE_STATUS_WORDTYPE As String = "WordType"
        Private Const XML_ATTRIBUTE_CASE_CONDITION As String = "Condition"
        Private Const XML_ATTRIBUTE_CASE_TARGET As String = "Target"

        Private _keyWords As List(Of String)
        Private _dfa As DFAInfo
        Private _encoding As Encoding

        Public Sub New(ByVal lexFileName As String, ByVal keyWordPath As String, ByVal dfaStatusPath As String, ByVal encoding As Encoding)
            Dim xmlDoc As XmlDocument

            If IO.File.Exists(lexFileName) Then
                xmlDoc = New XmlDocument
                xmlDoc.Load(lexFileName)
                _keyWords = GetKeyWordsFromXML(xmlDoc, keyWordPath)
                _dfa = GetDFAFromXML(xmlDoc, dfaStatusPath)                
            Else
                _keyWords = New List(Of String)
                _dfa = New DFAInfo
            End If
            _encoding = encoding
        End Sub

        Public ReadOnly Property KeyWords() As List(Of String) Implements ICobolEDLex.KeyWords
            Get
                Return _keyWords
            End Get
        End Property

        Public MustOverride Function GetWords(ByVal parseString As String, Optional ByVal withSpaceAndComment As Boolean = True) As List(Of WordInfo) Implements ICobolEDLex.GetWords

        Public Overridable Function GetWordFromIndex(ByVal parseString As String, ByVal index As Integer) As WordInfo Implements ICobolEDLex.GetWordFromIndex
            Dim result As WordInfo
            Dim parseWords As List(Of WordInfo)

            parseWords = GetWords(parseString)

            result = Nothing
            For Each parseWord As WordInfo In parseWords
                If parseWord.WordLocation > index Then
                    Exit For
                Else
                    result = parseWord
                End If
            Next

            Return result
        End Function

        Protected Function LexParse(ByVal parseString As String, ByVal startStatusID As String, ByVal withCase As Boolean, Optional ByVal withSpaceAndComment As Boolean = True, Optional ByVal startLocation As Integer = 0) As List(Of WordInfo)
            Dim result As List(Of WordInfo)
            Dim currentStatusID As String
            Dim currentStatus As StatusInfo
            Dim currentIndex As Integer
            Dim currentWord As StringBuilder
            'Dim currentWordType As WordTypeEnum

            result = New List(Of WordInfo)
            currentStatusID = startStatusID
            currentStatus = _dfa.StatusList(currentStatusID)
            currentIndex = 0
            currentWord = New StringBuilder(String.Empty)

            While currentStatus IsNot Nothing AndAlso currentIndex < parseString.Length

                currentStatusID = GetNextStatus(currentStatus.CaseList, parseString.Substring(currentIndex, 1))
                currentWord.Append(parseString.Substring(currentIndex, 1))
                currentIndex += 1
                currentStatus = _dfa.StatusList(currentStatusID)

                If currentStatus.IsTerminal Then
                    If currentStatus.NeedBack Then
                        currentWord.Remove(currentWord.Length - 1, 1)
                        currentIndex -= 1
                    Else
                    End If
                    If (withSpaceAndComment = True) OrElse _
                       (withSpaceAndComment = False AndAlso currentStatus.WordType <> WordTypeEnum.Space AndAlso currentStatus.WordType <> WordTypeEnum.Comment) Then
                        If currentStatus.WordType = WordTypeEnum.NormalWord AndAlso IsKeyWord(currentWord.ToString, withCase) Then
                            result.Add(New WordInfo(currentWord.ToString, WordTypeEnum.KeyWord, currentIndex - currentWord.Length + startLocation))
                        Else
                            result.Add(New WordInfo(currentWord.ToString, currentStatus.WordType, currentIndex - currentWord.Length + startLocation))
                        End If

                    End If
                    currentStatusID = startStatusID
                    currentStatus = _dfa.StatusList(currentStatusID)
                    currentWord.Remove(0, currentWord.Length)
                Else
                End If
            End While
            If currentWord.Length > 0 Then
                If (withSpaceAndComment = True) OrElse _
                   (withSpaceAndComment = False AndAlso currentStatus.WordType <> WordTypeEnum.Space AndAlso currentStatus.WordType <> WordTypeEnum.Comment) Then
                    If currentStatus.WordType = WordTypeEnum.NormalWord AndAlso IsKeyWord(currentWord.ToString, withCase) Then
                        result.Add(New WordInfo(currentWord.ToString, WordTypeEnum.KeyWord, parseString.Length - currentWord.Length + startLocation))
                    Else
                        result.Add(New WordInfo(currentWord.ToString, currentStatus.WordType, parseString.Length - currentWord.Length + startLocation))
                    End If

                End If
            End If

            Return result
        End Function

        Private Function GetNextStatus(ByVal caseList As List(Of CaseInfo), ByVal currentChar As String) As String
            Dim result As String

            result = String.Empty
            For Each caseInfo As CaseInfo In caseList
                If IsEqual(caseInfo.Condition, currentChar) Then
                    result = caseInfo.Target
                    Exit For
                Else
                End If
            Next
            Return result
        End Function

        Private Function GetKeyWordsFromXML(ByVal xmlDoc As XmlDocument, ByVal keyWordPath As String) As List(Of String)
            Dim result As New List(Of String)
            For Each keyWordNode As XmlNode In xmlDoc.SelectNodes(keyWordPath)
                result.Add(keyWordNode.InnerText)
            Next
            Return result
        End Function

        Private Function GetDFAFromXML(ByVal xmlDoc As XmlDocument, ByVal dfaStatusPath As String) As DFAInfo
            Dim result As DFAInfo

            result = New DFAInfo
            For Each statusNode As XmlNode In xmlDoc.SelectNodes(dfaStatusPath)
                result.AddStatus(GetStatusInfo(statusNode))
            Next
            Return result
        End Function

        Private Function GetStatusInfo(ByVal statusNode As XmlNode) As StatusInfo
            Dim result As StatusInfo
            Dim id As String
            Dim isTerminal As Boolean
            Dim needBack As Boolean
            Dim wordType As WordTypeEnum
            Dim caseList As List(Of CaseInfo)

            id = statusNode.Attributes(XML_ATTRIBUTE_STATUS_ID).Value
            isTerminal = GetBooleanValue(statusNode.Attributes(XML_ATTRIBUTE_STATUS_ISTERMINAL).Value)
            needBack = GetBooleanValue(statusNode.Attributes(XML_ATTRIBUTE_STATUS_NEEDBACK).Value)
            wordType = GetWordTypeValue(statusNode.Attributes(XML_ATTRIBUTE_STATUS_WORDTYPE).Value)
            caseList = GetCaseList(statusNode.ChildNodes)
            result = New StatusInfo(id, isTerminal, needBack, wordType, caseList)

            Return result
        End Function

        Private Function GetCaseList(ByVal caseNodeList As XmlNodeList) As List(Of CaseInfo)
            Dim result As List(Of CaseInfo)
            Dim condition As String
            Dim target As String
            result = New List(Of CaseInfo)
            For Each caseNode As XmlNode In caseNodeList
                condition = caseNode.Attributes(XML_ATTRIBUTE_CASE_CONDITION).Value
                target = caseNode.Attributes(XML_ATTRIBUTE_CASE_TARGET).Value
                result.Add(New CaseInfo(condition, target))
            Next
            Return result
        End Function

        Private Function GetBooleanValue(ByVal booleanString As String) As Boolean
            If booleanString.ToUpper = "TRUE" Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function GetWordTypeValue(ByVal wordTypeString As String) As WordTypeEnum
            Select Case wordTypeString.ToUpper
                Case "(NORMALWORD)"
                    Return WordTypeEnum.NormalWord
                Case "(NUMBER)"
                    Return WordTypeEnum.Number
                Case "(SPACE)"
                    Return WordTypeEnum.Space
                Case "(OPERATOR)"
                    Return WordTypeEnum.Operator
                Case "(STRING)"
                    Return WordTypeEnum.String
                Case "(BRACKET)"
                    Return WordTypeEnum.Bracket
                Case "(END)"
                    Return WordTypeEnum.End
                Case "(SYMBOL)"
                    Return WordTypeEnum.Symbol
                Case Else
                    Return WordTypeEnum.Unknown
            End Select
        End Function

        Private Function IsChar(ByVal chr As String) As Boolean
            Dim rst As Boolean = False
            If (chr >= "a" AndAlso chr <= "z") OrElse _
               (chr >= "A" AndAlso chr <= "Z") Then
                rst = True
            ElseIf _encoding.GetByteCount(chr) > 1 Then
                rst = True
            Else
                rst = False
            End If
            Return rst
        End Function

        Private Function IsDigit(ByVal chr As String) As Boolean
            Return Char.IsDigit(chr, 0)
        End Function

        Private Function IsEqual(ByVal condition As String, ByVal chr As String) As Boolean
            Dim result As Boolean
            Select Case condition.ToUpper
                Case "(CHAR)"
                    result = IsChar(chr)
                Case "(DIGITAL)"
                    result = IsDigit(chr)
                Case "(ELSE)"
                    result = True
                Case Else
                    result = chr.Equals(condition)
            End Select
            Return result
        End Function

        Private Function IsKeyWord(ByVal s As String, ByVal withCase As Boolean) As Boolean
            If withCase Then
                Return _keyWords.IndexOf(s) <> -1
            Else
                Return _keyWords.IndexOf(s.ToUpper) <> -1
            End If
        End Function

    End Class

End Namespace
