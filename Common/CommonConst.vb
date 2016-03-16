'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CommonConst.vb                                          --
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

Public Class CommonConst

    Public Shared ReadOnly KEY_TAB As String = Chr(9)
    Public Shared ReadOnly KEY_ENTER As String = Chr(13)
    Public Shared ReadOnly KEY_ESC As String = Chr(27)
    Public Shared ReadOnly WORD_SEPARATOR As Char() = {"!", Chr(34), "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/", ":", ";", "<", "=", ">", "?", "^", "`", "{", "|", "}", "~", " "}

End Class
