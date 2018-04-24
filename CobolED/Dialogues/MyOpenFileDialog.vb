'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MyOpenFileDialog.vb                                     --
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
Imports System.Text
Imports CobolED.Managers.Manager

Namespace Dialogues
    Public Class MyOpenFileDialog
        Private _openFileDialog As OpenFileDialog

        Private Const DlgTitle As String = "Open file"

        Public Sub New()
            _openFileDialog = New OpenFileDialog
            _openFileDialog.CheckFileExists = True
            _openFileDialog.CheckPathExists = True
            _openFileDialog.Multiselect = False
            _openFileDialog.RestoreDirectory = True
            _openFileDialog.Title = DlgTitle
        End Sub

        Public ReadOnly Property FileName() As String
            Get
                Return _openFileDialog.FileName
            End Get
        End Property

        Public Function ShowDialog() As DialogResult
            _openFileDialog.Filter = SettingManager.SettingInfo.FileFilter
            Return _openFileDialog.ShowDialog
        End Function

    End Class
End Namespace
