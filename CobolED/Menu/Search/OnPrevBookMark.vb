'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnPrevBookMark.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.Search                                     --
'--                                                                           --
'--  Project       :  CobolED                                                 --
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

Imports CobolED.Forms
Imports CobolED.Managers.Manager
Imports CobolEDCore.Document
Imports CobolEDCore.Infos.SearchEngine

Namespace Menu.Search
    Public Class OnPrevBookMark
        Inherits MenuItemProcessBase

        Private Const STR_COMMENT As String = "Previous Mark"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                If DocumentFormManager.CurrentDocumentForm IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
            
        Public Overrides Sub Execute()
            Dim currentDocForm As DocumentForm
            Dim currentDoc As Document
            Dim rtnFind As FindResultInfo
            Dim startRow As Integer

            currentDocForm = DocumentFormManager.CurrentDocumentForm
            If currentDocForm IsNot Nothing Then
                startRow = currentDocForm.CobolEDEditor.CaretPhysicalPosition.Row()
                currentDoc = currentDocForm.Document
                rtnFind = SearchManager.CobolEDSearchEngine.GetNextBookMark(currentDoc, startRow, True)
                If rtnFind IsNot Nothing Then
                    currentDocForm.CobolEDEditor.CaretMoveTo(rtnFind.FindResultRow, 0)
                End If
            End If
        End Sub

    End Class
End Namespace
