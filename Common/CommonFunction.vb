'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CommonFunction.vb                                       --
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

Public Class CommonFunction

    Private Sub New()
    End Sub

    Public Shared Function IsEditChar(ByVal KeyChar As Char) As Boolean
        Return Not Char.IsControl(KeyChar)
    End Function

    Public Shared Function IsNumber(ByVal s As String) As Boolean
        Dim result As Boolean
        result = True
        For Each c As Char In s
            If Not Char.IsNumber(c) Then
                result = False
                Exit For
            End If
        Next
        Return result
    End Function

    Public Shared Function IsSeparator(ByVal chrTarget As Char) As Boolean
        If Array.IndexOf(Common.CommonConst.WORD_SEPARATOR, chrTarget) >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
