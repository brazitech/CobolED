'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CobolEditAssistant.vb                                   --
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
Imports CobolEDCore.Enums
Namespace Cobol
    Public Class CobolEditAssistant
        Implements ICobolEDEditAssistant

        Private Const COMMENT_SYMBOL As String = "*"

        Private _cobolLex As ICobolEDLex
        Private _cobolSyntax As ICobolEDSyntax

        Public Sub New(ByVal cobolLex As ICobolEDLex, ByVal cobolSyntax As ICobolEDSyntax)
            _cobolLex = cobolLex
            _cobolSyntax = cobolSyntax
        End Sub

        Public Function GetDefaultSplitLine() As List(Of Integer) Implements ICobolEDEditAssistant.GetDefaultSplitLine
            Dim result As New List(Of Integer)
            result.Add(6)
            result.Add(7)
            result.Add(72)
            Return result
        End Function

        Public Function GetLineHearder(ByVal prevParseString As String) As String Implements ICobolEDEditAssistant.GetLineHearder
            Dim result As String = String.Empty
            Dim prevParseWords As List(Of WordInfo)

            prevParseWords = _cobolLex.GetWords(prevParseString)

            If prevParseWords.Count = 1 Then
                result = String.Empty
            ElseIf prevParseWords.Count = 2 Then
                result = Space(6)
            ElseIf prevParseWords.Count > 2 Then
                If prevParseWords(2).WordType = WordTypeEnum.Space Then
                    result = Space(7 + prevParseWords(2).WordString.Length)
                Else
                    result = Space(7)
                End If
            Else
                result = String.Empty
            End If
            Return result
        End Function

        Public Function GetCommentString(ByVal parseString As String) As String Implements ICobolEDEditAssistant.GetCommentString
            Dim result As String

            If Common.StringTransaction.GetLengthByByte(parseString) < 7 Then
                result = parseString
            Else
                result = Common.StringTransaction.GetSubStringByByte(parseString, 0, 6) & _
                         COMMENT_SYMBOL & _
                         Common.StringTransaction.GetSubStringByByte(parseString, 7)
            End If
            Return result
        End Function

        Public Function GetUnCommentString(ByVal parseString As String) As String Implements ICobolEDEditAssistant.GetUnCommentString
            Dim result As String

            If Common.StringTransaction.GetLengthByByte(parseString) < 7 Then
                result = parseString
            Else
                result = Common.StringTransaction.GetSubStringByByte(parseString, 0, 6) & _
                         Space(1) & _
                         Common.StringTransaction.GetSubStringByByte(parseString, 7)
            End If
            Return result
        End Function

    End Class
End Namespace
