'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MyPageSetupDialog.vb                                    --
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
    Public Class MyPageSetupDialog

        Private _pageSetupDialog As PageSetupDialog

        Public Sub New()
            _pageSetupDialog = New PageSetupDialog
            _pageSetupDialog.AllowMargins = True
            _pageSetupDialog.AllowOrientation = False
            _pageSetupDialog.AllowPaper = True
            _pageSetupDialog.AllowPrinter = True
            _pageSetupDialog.ShowNetwork = True
            _pageSetupDialog.ShowHelp = False
            _pageSetupDialog.EnableMetric = True
        End Sub

        Public Property Document() As PrintDocument
            Get
                Return _pageSetupDialog.Document
            End Get
            Set(ByVal value As PrintDocument)
                _pageSetupDialog.Document = value
            End Set
        End Property

        Public Function ShowDialog() As DialogResult
            Return _pageSetupDialog.ShowDialog()
        End Function

    End Class
End Namespace
