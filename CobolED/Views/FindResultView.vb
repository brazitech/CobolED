'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  FindResultView.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
'--                                                                           --
'--  NameSpace     :  CobolED.Views                                           --
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

Imports CobolEDCore.Infos.SearchEngine
Imports CobolEDCore.Document
Imports CobolEDCore.Interfaces.Info
Imports CobolED.Managers.Manager
Imports CobolED.Forms


Namespace Views
    Public Class FindResultView

        Private Const END_STRING As String = "Matching Row: {0} "&" match to File: {1} "&" Search for File total number : { 2 }"
        Private Const LINE_STRING As String = "{0} ({1})        {2}"

        Public Sub SetFindResult(ByVal findResult As List(Of FindResultInfo), ByVal allFileCount As Integer)
            Dim hitFileCount As Integer
            Dim item As ListViewItem
            Dim currentFileName As String

            ViewClear()
            hitFileCount = 0
            currentFileName = String.Empty

            For index As Integer = 0 To findResult.Count - 1
                If currentFileName <> findResult(index).FindResultFileName Then
                    hitFileCount += 1
                    currentFileName = findResult(index).FindResultFileName
                End If
                item = New ListViewItem(CreateLineString(findResult(index)))
                item.Tag = findResult(index)
                _findResultListView.Items.Add(item)
            Next
            item = New ListViewItem(CreateEndString(findResult.Count, hitFileCount, allFileCount))
            item.Tag = Nothing
            Me._findResultListView.Items.Add(item)

        End Sub

        Public Sub ViewClear()
            Me._findResultListView.Items.Clear()
        End Sub

        Private Sub MoveTo(ByVal moveInfo As IMoveable)
            Dim posGoTo As Position
            posGoTo = moveInfo.Position
            DocumentFormManager.ActivateDocumentForm(moveInfo.FileName, FormWindowState.Maximized)
            DocumentFormManager.CurrentDocumentForm.CobolEDEditor.CaretMoveTo(posGoTo.Row, posGoTo.Col)
        End Sub

        Private Sub _findResultListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _findResultListView.DoubleClick
            If Me._findResultListView.SelectedItems.Count > 0 Then
                If TypeOf Me._findResultListView.SelectedItems(0).Tag Is IMoveable Then
                    MoveTo(Me._findResultListView.SelectedItems(0).Tag)
                End If
            End If
        End Sub

        Private Function CreateEndString(ByVal listCount As Integer, _
                                         ByVal hitFileCount As Integer, _
                                         ByVal allFileCount As Integer) As String
            Return String.Format(END_STRING, listCount, hitFileCount, allFileCount)
        End Function

        Private Function CreateLineString(ByVal findResult As FindResultInfo) As String
            Return String.Format(LINE_STRING, findResult.FindResultFileName, findResult.FindResultRow, findResult.FindResultLine)
        End Function

    End Class
End Namespace
