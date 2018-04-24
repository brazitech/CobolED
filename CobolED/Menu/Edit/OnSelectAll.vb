'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnSelectAll.vb                                          --
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
    Public Class OnSelectAll
        Inherits MenuItemProcessBase

        Private Const StrComment As String = "Select the entire File"

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
                Dim currentDocumentForm As DocumentForm
                Dim result As Boolean
                currentDocumentForm = DocumentFormManager.CurrentDocumentForm()

                If currentDocumentForm IsNot Nothing Then
                    result = True
                Else
                    result = False
                End If
                Return result

            End Get
        End Property

        Public Overrides Sub Execute()
            Dim currentDocumentForm As DocumentForm
            currentDocumentForm = DocumentFormManager.CurrentDocumentForm()

            If currentDocumentForm IsNot Nothing Then
                currentDocumentForm.CobolEDEditor.SelectAll()
            Else
            End If
        End Sub

    End Class
End Namespace