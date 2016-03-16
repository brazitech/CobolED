'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ICobolEDLex.vb                                          --
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

Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Document

Namespace Interfaces.Analyzer

    Public Interface ICobolEDLex

        ReadOnly Property KeyWords() As List(Of String)

        Function GetWords(ByVal parseString As String, Optional ByVal withSpaceAndComment As Boolean = True) As List(Of WordInfo)

        Function GetWordFromIndex(ByVal parseString As String, ByVal index As Integer) As WordInfo

    End Interface

End Namespace
