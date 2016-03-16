'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  Message.vb                                              --
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

Imports System.Windows.Forms
Imports System.Reflection
Imports System.Resources

Public Class Message

    Private Shared MSG_CRITICAL As String = "C"
    Private Shared MSG_EXCLAMATION As String = "E"
    Private Shared MSG_INFORMATION As String = "I"
    Private Shared MSG_QUESTION As String = "Q"
    Private Shared MSG_TITLE As String = "Women Working with COBOL"
    Private Shared MSG_SEPARATOR As String = "|"

    Public Shared Function ShowMessage(ByVal messageDefine As String, ByVal ParamArray accessoryMessage() As String) As MsgBoxResult
        Dim messageDefines() As String
        Dim messageString As String
        Dim messageStyle As MsgBoxStyle

        messageDefines = messageDefine.Split(MSG_SEPARATOR)
        messageString = String.Format(messageDefines(0), accessoryMessage)

        Select Case True
            Case messageDefines.Length < 2
                messageStyle = MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly

            Case messageDefines(1).CompareTo(MSG_CRITICAL) = 0
                messageStyle = MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly

            Case messageDefines(1).CompareTo(MSG_EXCLAMATION) = 0
                messageStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly

            Case messageDefines(1).CompareTo(MSG_INFORMATION) = 0
                messageStyle = MsgBoxStyle.Information Or MsgBoxStyle.OkOnly

            Case messageDefines(1).CompareTo(MSG_QUESTION) = 0
                messageStyle = MsgBoxStyle.Question Or MsgBoxStyle.YesNo
        End Select

        Return MsgBox(messageString, messageStyle, MSG_TITLE)

    End Function

    Public Shared Function ShowMessage(ByVal e As MyException) As MsgBoxResult
        Return ShowMessage(e.MessageDefine, e.accessoryMessage)
    End Function

    Public Shared Function ShowMessage(ByVal e As Exception) As MsgBoxResult
        Return ShowMessage(e.Message, New String() {})
    End Function

End Class



