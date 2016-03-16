'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ICobolEDAnalyzer.vb                                     --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Interfaces.Analyzer                         --
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

Namespace Interfaces.Analyzer

    Public Interface ICobolEDAnalyzer

        ReadOnly Property CobolEDLex() As ICobolEDLex

        ReadOnly Property CobolEDSyntax() As ICobolEDSyntax

        ReadOnly Property CobolEDEditAssistant() As ICobolEDEditAssistant

    End Interface

End Namespace
