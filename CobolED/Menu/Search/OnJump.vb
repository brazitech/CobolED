'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnJump.vb                                               --
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
Imports CobolEDCore.Document
Imports CobolEDCore.Infos.SearchEngine
Imports CobolED.Dialogues
Imports CobolED.Managers.Manager

Namespace Menu.Search
    Public Class OnJump
        Inherits MenuItemProcessBase

        Private _jumpDialog As JumpDialog
        Private Const STR_COMMENT As String = "Move the cursor to the specified line number"


        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _jumpDialog = New JumpDialog
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
            Dim intTargetLine As Integer
            Dim currentDocForm As DocumentForm
            Dim currentDoc As Document

            currentDocForm = DocumentFormManager.CurrentDocumentForm
            If currentDocForm IsNot Nothing AndAlso _jumpDialog.ShowDialog() = DialogResult.OK Then
                currentDoc = currentDocForm.Document
                intTargetLine = _jumpDialog.LineNo - 1
                If intTargetLine > currentDoc.DocumentLinesCount - 1 Then
                    intTargetLine = currentDoc.DocumentLinesCount - 1
                ElseIf intTargetLine < 0 Then
                    intTargetLine = 0
                End If
                currentDocForm.CobolEDEditor.CaretMoveTo(intTargetLine, 0)
            Else
            End If
        End Sub

    End Class
End Namespace
