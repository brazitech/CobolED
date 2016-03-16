'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ICobolEDSearchEngine.vb                                 --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Interfaces.SearchEngine                     --
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

Imports CobolEDCore.Infos.SearchEngine
Imports CobolEDCore.Document
Namespace Interfaces.SearchEngine
    Public Interface ICobolEDSearchEngine

        Function GetAllFindString(ByVal documentList As List(Of Document.Document), _
                                  ByVal findString As String, _
                                  ByVal matchCase As Boolean, _
                                  ByVal matchWord As Boolean) As List(Of FindResultInfo)

        Function GetNextFindString(ByVal document As Document.Document, _
                                   ByVal findstring As String, _
                                   ByVal currentRow As Integer, _
                                   ByVal currentCol As Integer, _
                                   ByVal matchCase As Boolean, _
                                   ByVal matchWord As Boolean, _
                                   ByVal upDirection As Boolean) As FindResultInfo

        Function GetNextBookMark(ByVal document As Document.Document, _
                                 ByVal currentRow As Integer, _
                                 ByVal upDirection As Boolean) As FindResultInfo

    End Interface
End Namespace
