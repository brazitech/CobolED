'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MySaveAsDialog.vb                                       --
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

Imports System.Text
Imports CobolED.Managers.Manager

Namespace Dialogues
    Public Class MySaveAsDialog

        Private Const DLG_TITLE As String = "Save as"

        Private _saveAsDialog As SaveFileDialog

        Public Sub New()
            _saveAsDialog = New SaveFileDialog
            _saveAsDialog.CheckPathExists = True
            _saveAsDialog.RestoreDirectory = True                        
            _saveAsDialog.Title = DLG_TITLE
        End Sub

        Public ReadOnly Property FileName() As String
            Get
                Return _saveAsDialog.FileName
            End Get
        End Property

        Public Function ShowDialog() As DialogResult
            _saveAsDialog.Filter = SettingManager.SettingInfo.FileFilter
            Return _saveAsDialog.ShowDialog
        End Function


    End Class
End Namespace
