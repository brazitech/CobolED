'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MyOpenProjectDialog.vb                                  --
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

Imports System.Windows.Forms
Namespace Dialogues
    Public Class MyOpenProjectDialog
        Private _openProjectDialog As OpenFileDialog

        Private Const DLG_TITLE As String = "Open Project"
        Private Const DLG_FILTER As String = "CobolED Project file(*.ced)|*.ced|All files(*.*)|*.*"

        Public Sub New()
            _openProjectDialog = New OpenFileDialog
            _openProjectDialog.CheckFileExists = True
            _openProjectDialog.CheckPathExists = True
            _openProjectDialog.RestoreDirectory = True
            _openProjectDialog.Filter = DLG_FILTER
            _openProjectDialog.Multiselect = False
            _openProjectDialog.Title = DLG_TITLE

        End Sub

        Public ReadOnly Property FileName() As String
            Get
                Return _openProjectDialog.FileName
            End Get
        End Property

        Public Function ShowDialog() As DialogResult
            Return _openProjectDialog.ShowDialog
        End Function

    End Class
End Namespace
