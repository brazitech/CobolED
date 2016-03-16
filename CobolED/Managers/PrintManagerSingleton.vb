'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  PrintManagerSingleton.vb                                --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Managers                                        --
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

Imports CobolED.Dialogues
Imports CobolEDCore.Interfaces.Editor
Imports System.Drawing.Printing
Namespace Managers
    Public Class PrintManagerSingleton

        Private WithEvents _printDocument As PrintDocument
        Private _pageSetupDialog As MyPageSetupDialog
        Private _printDialog As MyPrintDialog
        Private _printPreviewDialog As MyPrintPreviewDialog
        Private _currentEditor As ICobolEDEditor
        Private _fromDocumentLine As Integer


        Private Shared _printManager As PrintManagerSingleton

        Private Sub New()
            _printDocument = New PrintDocument

            _pageSetupDialog = New MyPageSetupDialog
            _pageSetupDialog.Document = _printDocument

            _printDialog = New MyPrintDialog
            _printDialog.Document = _printDocument

            _printPreviewDialog = New MyPrintPreviewDialog
            _printPreviewDialog.Document = _printDocument

            _currentEditor = Nothing
            _fromDocumentLine = 0
        End Sub

        Public Shared ReadOnly Property PrintManager() As PrintManagerSingleton
            Get
                If _printManager Is Nothing Then
                    _printManager = New PrintManagerSingleton
                End If
                Return _printManager
            End Get
        End Property

        Public ReadOnly Property PageSetupDialog() As MyPageSetupDialog
            Get
                Return _pageSetupDialog
            End Get
        End Property

        Public ReadOnly Property PrintDialog() As MyPrintDialog
            Get
                Return _printDialog
            End Get
        End Property

        Public Sub PrintPreview(ByVal currentEditor As ICobolEDEditor)
            _currentEditor = currentEditor

            _printDocument.DocumentName = _currentEditor.Document.DocumentFileName
            _fromDocumentLine = 0
            _printPreviewDialog.ShowDialog()
        End Sub

        Public Sub Print(ByVal currentEditor As ICobolEDEditor)
            _currentEditor = currentEditor

            _printDocument.DocumentName = _currentEditor.Document.DocumentFileName
            _fromDocumentLine = 0
            _printDocument.Print()
        End Sub

        Private Sub OnPrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles _printDocument.PrintPage
            If _currentEditor IsNot Nothing Then
                _fromDocumentLine = _currentEditor.Print(_fromDocumentLine, e.Graphics, e.MarginBounds)
                If _fromDocumentLine <= _currentEditor.Document.DocumentLinesCount - 1 Then
                    e.HasMorePages = True
                Else
                    e.HasMorePages = False
                    _fromDocumentLine = 0
                End If
            End If
        End Sub

    End Class
End Namespace
