'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MyException.vb                                          --
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

Public Class MyException
    Inherits Exception

    Private _messageDefine As String
    Private _accessoryMessage() As String

    Public ReadOnly Property MessageDefine() As String
        Get
            Return _messageDefine
        End Get
    End Property

    Public ReadOnly Property accessoryMessage() As String()
        Get
            Return _accessoryMessage
        End Get
    End Property

    Public Sub New(ByVal messageDefine As String, ByVal ParamArray accessoryMessage() As String)
        _messageDefine = messageDefine
        _accessoryMessage = accessoryMessage
    End Sub


End Class
