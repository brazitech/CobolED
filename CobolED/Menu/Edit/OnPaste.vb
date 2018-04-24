'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnPaste.vb                                              --
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
    Public Class OnPaste
        Inherits MenuItemProcessBase

        Private Const StrComment As String = "Paste the contents of the clipboard at the position of the cursor"

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
                Dim result As Boolean
                Dim dataObject As DataObject
                Dim currentDocumentForm As DocumentForm

                currentDocumentForm = DocumentFormManager.CurrentDocumentForm()
                dataObject = DirectCast(Clipboard.GetDataObject(), DataObject)

                If currentDocumentForm IsNot Nothing AndAlso _
                   dataObject.GetDataPresent(System.Windows.Forms.DataFormats.Text) Then
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
                currentDocumentForm.CobolEDEditor.Paste()
            Else
            End If
        End Sub

    End Class
End Namespace