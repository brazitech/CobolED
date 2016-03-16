'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CobolLex.vb                                             --
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

Imports System.Text
Imports System.xml
Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Document
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Enums
Imports CobolEDCore.AnalyzerBase

Namespace Cobol

    Public Class CobolLex
        Inherits LexBase

        Private Const XML_SYNTAX_FILE As String = "Analyzer\CobolLex.xml"
        Private Const XML_KEYWORD_PATH As String = "Lex/KeyWords/KeyWord"
        Private Const XML_DFA_STATUS_PATH As String = "Lex/DFA/Status"
        Private Const DFA_START_STATUS_ID As String = "0"

        Public Sub New()
            MyBase.new(XML_SYNTAX_FILE, XML_KEYWORD_PATH, XML_DFA_STATUS_PATH, Encoding.GetEncoding(932))
        End Sub

        Public Overrides Function GetWords(ByVal parseString As String, Optional ByVal withSpaceAndComment As Boolean = True) As List(Of WordInfo)
            Dim result As New List(Of WordInfo)
            Dim lastComment As String = String.Empty

            If Common.StringTransaction.GetLengthByByte(parseString) <= 6 Then
                'This is not a COBOL Program Line
                If withSpaceAndComment Then
                    result.Add(New WordInfo(parseString, WordTypeEnum.Unknown, 0))
                Else
                End If

            ElseIf Common.StringTransaction.GetLengthByByte(parseString) >= 7 Then
                If withSpaceAndComment Then result.Add(New WordInfo(Common.StringTransaction.GetSubStringByByte(parseString, 0, 6), WordTypeEnum.Comment, 0))
                If Common.StringTransaction.GetSubStringByByte(parseString, 6, 1) = "*" Then
                    'This is a COBOL comment Line
                    If withSpaceAndComment Then result.Add(New WordInfo(Common.StringTransaction.GetSubStringByByte(parseString, 6), _
                                                                     WordTypeEnum.Comment, _
                                                                     Common.StringTransaction.GetIndexFromByteCount(parseString, 6)))
                Else
                    'This is a normal COBOL Program Line
                    If withSpaceAndComment Then result.Add(New WordInfo(Common.StringTransaction.GetSubStringByByte(parseString, 6, 1), _
                                                                     WordTypeEnum.Comment, _
                                                                     Common.StringTransaction.GetIndexFromByteCount(parseString, 6)))
                    If Common.StringTransaction.GetLengthByByte(parseString) > 72 Then
                        'This COBOL Program Line has a lastComment
                        lastComment = Common.StringTransaction.GetSubStringByByte(parseString, 72)
                        result.AddRange(LexParse(Common.StringTransaction.GetSubStringByByte(parseString, 7, 65), _
                                                 DFA_START_STATUS_ID, _
                                                 False, _
                                                 withSpaceAndComment, _
                                                 Common.StringTransaction.GetIndexFromByteCount(parseString, 7)))
                        If withSpaceAndComment Then result.Add(New WordInfo(lastComment, WordTypeEnum.Comment, Common.StringTransaction.GetIndexFromByteCount(parseString, 72)))
                    Else
                        'This COBOL Program Line do not have any lastComment
                        result.AddRange(LexParse(Common.StringTransaction.GetSubStringByByte(parseString, 7), _
                                                 DFA_START_STATUS_ID, _
                                                 False, _
                                                 withSpaceAndComment, _
                                                 Common.StringTransaction.GetIndexFromByteCount(parseString, 7)))
                    End If
                End If
            End If

            Return result
        End Function

    End Class

End Namespace