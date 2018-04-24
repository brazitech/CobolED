'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnSetBookMark.vb                                        --
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

Namespace Menu.Search
    Public Class OnSetBookMark
        Inherits MenuItemProcessBase

        Private Const StrComment As String = "Setting or canceling marks at position of the cursor"

        Public Sub New(ByVal cobolEdMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return StrComment
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
            Dim blnNowBookMark As Boolean
            Dim startRow As Integer

            currentDocForm = DocumentFormManager.CurrentDocumentForm
            If currentDocForm IsNot Nothing Then
                startRow = currentDocForm.CobolEDEditor.CaretPhysicalPosition.Row
                blnNowBookMark = currentDocForm.Document.DocumentLineBookMark(startRow)
                currentDocForm.CobolEDEditor.SetBookMark(startRow, Not blnNowBookMark)
            End If
        End Sub

    End Class
End Namespace
