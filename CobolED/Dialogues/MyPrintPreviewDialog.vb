'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MyPrintPreviewDialog.vb                                 --
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

Namespace Dialogues
    Public Class MyPrintPreviewDialog
        Inherits PrintPreviewDialog

        Public Sub New()
            MyBase.New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.SuspendLayout()

            '
            'MyPrintPreviewDialog
            '
            Me.ClientSize = New System.Drawing.Size(400, 300)
            Me.Icon = Global.CobolED.My.Resources.Resources.CobolED
            Me.Name = "MyPrintPreviewDialog"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)

        End Sub

    End Class
End Namespace
