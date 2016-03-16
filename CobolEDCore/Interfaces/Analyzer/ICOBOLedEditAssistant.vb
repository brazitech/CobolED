'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ICobolEDEditAssistant.vb                                --
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
    Public Interface ICobolEDEditAssistant

        Function GetLineHearder(ByVal prevParseString As String) As String

        Function GetDefaultSplitLine() As List(Of Integer)

        Function GetCommentString(ByVal parseString As String) As String

        Function GetUnCommentString(ByVal parseString As String) As String

    End Interface
End Namespace
