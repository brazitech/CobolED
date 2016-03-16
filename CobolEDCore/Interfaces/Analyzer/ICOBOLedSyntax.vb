'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ICobolEDSyntax.vb                                       --
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

Namespace Interfaces.Analyzer

    Public Interface ICobolEDSyntax

        Sub GetMembers(ByVal document As Document.Document, _
                       ByRef functions As List(Of FunctionInfo), _
                       ByRef variables As List(Of VariableInfo), _
                       ByRef includes As List(Of IncludeInfo))

        Function GetSentence(ByVal document As Document.Document, ByVal startRow As Integer, ByVal startCol As Integer, Optional ByVal withSpaceAndComment As Boolean = False) As SentenceInfo

        Function GetFunction(ByVal sentenceInfo As SentenceInfo) As FunctionInfo

        Function GetVariable(ByVal sentenceInfo As SentenceInfo) As VariableInfo

        Function GetInclude(ByVal sentenceInfo As SentenceInfo) As IncludeInfo

        Function GetSentences(ByVal document As Document.Document, Optional ByVal withSpaceAndComment As Boolean = False) As List(Of SentenceInfo)

        Function GetFunctions(ByVal document As Document.Document) As List(Of FunctionInfo)

        Function GetVariables(ByVal document As Document.Document) As List(Of VariableInfo)

        Function GetIncludes(ByVal document As Document.Document) As List(Of IncludeInfo)

    End Interface

End Namespace
