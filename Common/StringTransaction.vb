'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  StringTransaction.vb                                    --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  Common                                                  --
'--                                                                           --
'--  Project       :  Common                                                  --
'--                                                                           --
'--  Solution      :  NVSDI CobolED                             --
'--                                                                           --
'--  Creation Date :  2007/04/03                                              --
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

Public Class StringTransaction

    Private Shared _encoding As Encoding = Encoding.GetEncoding(932)

    Public Shared Function GetLengthByByte(ByVal s As String) As Integer
        Return _encoding.GetByteCount(s)
    End Function

    Public Shared Function GetSubStringByByte(ByVal s As String, ByVal startIndex As Integer, ByVal length As Integer) As String
        Dim result As String
        Dim bytes() As Byte
        Dim subBytes(length - 1) As Byte
        bytes = _encoding.GetBytes(s)
        If startIndex >= 0 AndAlso startIndex < bytes.Length AndAlso _
           startIndex + length - 1 < bytes.Length Then
            Array.Copy(bytes, startIndex, subBytes, 0, length)
            result = _encoding.GetString(subBytes)
        Else
            result = String.Empty
        End If
        Return result
    End Function

    Public Shared Function GetSubStringByByte(ByVal s As String, ByVal startIndex As Integer) As String
        Dim result As String
        Dim length As Integer
        length = _encoding.GetByteCount(s) - startIndex
        result = GetSubStringByByte(s, startIndex, length)
        Return result
    End Function

    Public Shared Function GetIndexFromByteCount(ByVal s As String, ByVal byteCount As Integer) As Integer
        Dim result As Integer
        If byteCount <= 0 Then
            result = 0
        Else
            For result = 0 To s.Length - 1
                If _encoding.GetByteCount(s.Substring(0, result)) >= byteCount Then
                    Exit For
                End If
            Next
        End If
        Return result
    End Function

    Public Shared Function GetByteCountFromIndex(ByVal s As String, ByVal index As Integer) As Integer
        Dim result As Integer
        If index <= 0 OrElse index > s.Length Then
            result = 0
        Else
            result = _encoding.GetByteCount(s.Substring(0, index))
        End If
        Return result
    End Function

End Class
