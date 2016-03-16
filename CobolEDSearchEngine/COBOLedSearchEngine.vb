'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CobolEDSearchEngine.vb                                  --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
'--                                                                           --
'--  NameSpace     :  CobolEDSearchEngine                                     --
'--                                                                           --
'--  Project       :  CobolEDSearchEngine                                     --
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
Imports CobolEDCore.Infos.SearchEngine
Imports CobolEDCore.Document
Imports Common

Public Class CobolEDSearchEngine
    Implements ICobolEDSearchEngine

    Public Function GetNextBookMark(ByVal document As Document, _
                                    ByVal currentRow As Integer, _
                                    ByVal upDirection As Boolean) As FindResultInfo Implements ICobolEDSearchEngine.GetNextBookMark
        Dim result As FindResultInfo
        Dim startRow As Integer
        Dim lineNoEnumerator As LineNoEnumerator

        result = Nothing
        startRow = GetNextRow(currentRow, document.DocumentLinesCount, upDirection)
        lineNoEnumerator = New LineNoEnumerator(document.DocumentLinesCount, startRow, upDirection)

        Do
            If document.DocumentLineBookMark(lineNoEnumerator.CurrentRow) Then
                result = New FindResultInfo
                result.FindResultFileName = document.DocumentFileName
                result.FindResultLine = document.DocumentLineString(lineNoEnumerator.CurrentRow)
                result.FindResultRow = lineNoEnumerator.CurrentRow
                result.FindResultCol = 0
                Exit Do
            Else
            End If
        Loop While lineNoEnumerator.MoveNext

        Return result
    End Function

    Public Function GetNextFindString(ByVal document As Document, _
                                      ByVal findstring As String, _
                                      ByVal currentRow As Integer, _
                                      ByVal currentCol As Integer, _
                                      ByVal matchCase As Boolean, _
                                      ByVal matchWord As Boolean, _
                                      ByVal upDirection As Boolean) As FindResultInfo Implements ICobolEDSearchEngine.GetNextFindString
        Dim result As FindResultInfo
        Dim index As Integer
        Dim currentLineString As String
        Dim lineNoEnumerator As LineNoEnumerator

        result = Nothing
        If upDirection Then
            currentLineString = document.DocumentLineString(currentRow).Substring(0, currentCol)
        Else
            currentLineString = document.DocumentLineString(currentRow).Substring(currentCol)
        End If

        index = FindInSingleLine(currentLineString, findstring, matchCase, matchWord, upDirection)
        If index >= 0 Then
            result = New FindResultInfo
            result.FindResultFileName = document.DocumentFileName
            result.FindResultLine = document.DocumentLineString(currentRow)
            result.FindResultRow = currentRow
            If upDirection Then
                result.FindResultCol = index
            Else
                result.FindResultCol = index + currentCol
            End If

        Else
            lineNoEnumerator = New LineNoEnumerator(document.DocumentLinesCount, _
                                                    GetNextRow(currentRow, document.DocumentLinesCount, upDirection), _
                                                    upDirection)
            Do
                index = FindInSingleLine(document.DocumentLineString(lineNoEnumerator.CurrentRow), findstring, matchCase, matchWord, upDirection)
                If index >= 0 Then
                    result = New FindResultInfo
                    result.FindResultFileName = document.DocumentFileName
                    result.FindResultLine = document.DocumentLineString(lineNoEnumerator.CurrentRow)
                    result.FindResultRow = lineNoEnumerator.CurrentRow
                    result.FindResultCol = index
                    Exit Do
                Else
                End If
            Loop While lineNoEnumerator.MoveNext
        End If

        Return result
    End Function

    Public Function GetAllFindString(ByVal documentList As List(Of Document), _
                                     ByVal findString As String, _
                                     ByVal matchCase As Boolean, _
                                     ByVal matchWord As Boolean) As List(Of FindResultInfo) Implements ICobolEDSearchEngine.GetAllFindString
        Dim result As List(Of FindResultInfo)
        Dim index As Integer
        Dim oneResult As FindResultInfo

        result = New List(Of FindResultInfo)
        For Each document As Document In documentList
            For i As Integer = 0 To document.DocumentLinesCount - 1
                index = FindInSingleLine(document.DocumentLineString(i), findString, matchCase, matchWord, False)
                If index >= 0 Then
                    oneResult = New FindResultInfo
                    oneResult.FindResultFileName = document.DocumentFileName
                    oneResult.FindResultLine = document.DocumentLineString(i)
                    oneResult.FindResultRow = i
                    oneResult.FindResultCol = index
                    result.Add(oneResult)
                End If
            Next
        Next

        Return result
    End Function

    Private Function FindInSingleLine(ByVal docLineString As String, _
                                      ByVal findString As String, _
                                      ByVal matchCase As Boolean, _
                                      ByVal matchWord As Boolean, _
                                      ByVal upDirection As Boolean) As Integer
        Dim result As Integer
        Dim startIndex As Integer

        If Not matchCase Then
            docLineString = docLineString.ToUpper
            findString = findString.ToUpper            
        Else
        End If

        If upDirection Then
            startIndex = docLineString.Length
            result = docLineString.LastIndexOf(findString, startIndex)
        Else
            startIndex = 0
            result = docLineString.IndexOf(findString, startIndex)
        End If

        While result <> -1 AndAlso _
              (matchWord AndAlso Not IsWord(docLineString, result, findString.Length))
            If upDirection Then
                startIndex = result + findString.Length - 2
                If startIndex < 0 Then
                    result = -1
                    Exit While
                End If
                result = docLineString.LastIndexOf(findString, startIndex)
            Else
                startIndex = result + 1
                result = docLineString.IndexOf(findString, startIndex)
            End If
        End While

        Return result
    End Function

    Private Function GetNextRow(ByVal currentRow As Integer, ByVal documentLineCount As Integer, ByVal upDirection As Boolean) As Integer
        Dim result As Integer
        If upDirection Then
            If currentRow = 0 Then
                result = documentLineCount - 1
            Else
                result = currentRow - 1
            End If
        Else
            If currentRow = documentLineCount - 1 Then
                result = 0
            Else
                result = currentRow + 1
            End If
        End If
        Return result
    End Function

    Private Function IsWord(ByVal docLineString As String, ByVal index As Integer, ByVal length As Integer) As Boolean
        Dim blnIsWord As Boolean = False

        If index >= 0 AndAlso index <= docLineString.Length - 1 AndAlso _
           length > 0 AndAlso length < docLineString.Length - index + 1 Then

            If index = 0 AndAlso index + length = docLineString.Length Then
                blnIsWord = True

            ElseIf index = 0 AndAlso index + length < docLineString.Length Then

                If CommonFunction.IsSeparator(docLineString.Chars(index + length)) Then
                    blnIsWord = True
                Else
                    blnIsWord = False
                End If

            ElseIf index > 0 AndAlso index + length = docLineString.Length Then

                If CommonFunction.IsSeparator(docLineString.Chars(index - 1)) Then
                    blnIsWord = True
                Else
                    blnIsWord = False
                End If

            Else
                If CommonFunction.IsSeparator(docLineString.Chars(index - 1)) AndAlso _
                   CommonFunction.IsSeparator(docLineString.Chars(index + length)) Then
                    blnIsWord = True
                Else
                    blnIsWord = False
                End If

            End If
        Else
            blnIsWord = False
        End If

        Return blnIsWord

    End Function

End Class
