'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnCommentOut.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.Edit                                       --
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

Namespace Menu.Edit
    Public Class OnCommentOut
        Inherits MenuItemProcessBase

        Private Const STR_COMMENT As String = "Comment out the selected content"

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
                Dim currentDocumentForm As DocumentForm
                currentDocumentForm = DocumentFormManager.CurrentDocumentForm()
                If currentDocumentForm IsNot Nothing Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides Sub Execute()
            Dim currentDocumentForm As DocumentForm
            currentDocumentForm = DocumentFormManager.CurrentDocumentForm()
            If currentDocumentForm IsNot Nothing Then
                currentDocumentForm.CobolEDEditor.CommentOut()
            Else
            End If
        End Sub

    End Class
End Namespace
