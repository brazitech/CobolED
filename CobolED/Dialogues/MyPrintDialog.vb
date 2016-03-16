'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MyPrintDialog.vb                                        --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Dialogues                                       --
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

Imports System.Drawing.Printing
Namespace Dialogues
    Public Class MyPrintDialog

        Private _printDialog As PrintDialog

        Public Sub New()
            _printDialog = New PrintDialog
            _printDialog.AllowCurrentPage = False
            _printDialog.AllowPrintToFile = False
            _printDialog.AllowSelection = False
            _printDialog.AllowSomePages = False
            _printDialog.ShowNetwork = True
            _printDialog.ShowHelp = False
        End Sub

        Public Property Document() As PrintDocument
            Get
                Return _printDialog.Document
            End Get
            Set(ByVal value As PrintDocument)
                _printDialog.Document = value
            End Set
        End Property

        Public Function ShowDialog() As DialogResult
            Return _printDialog.ShowDialog
        End Function

    End Class
End Namespace
