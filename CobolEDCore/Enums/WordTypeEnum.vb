'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  WordTypeEnum.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Enums                                       --
'--                                                                           --
'--  Project       :  CobolEDCore                                             --
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

Namespace Enums
    Public Enum WordTypeEnum
        Comment = 0
        NormalWord = 1
        Number = 2
        Space = 3
        [Operator] = 4
        [String] = 5
        Bracket = 6
        [End] = 7
        Symbol = 8
        KeyWord = 98
        Unknown = 99
    End Enum
End Namespace
