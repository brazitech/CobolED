'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  NewProjectDialog.vb                                     --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
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
    Public Class NewProjectDialog

        Private Const ProjectExtend = ".ced"
        Private Const ProjectNoname As String = "NewProject"

        Public ReadOnly Property ProjectFullName() As String
            Get
                Return IO.Path.Combine(_cmbProjectFolderName.Text.Trim, _txtProjectName.Text.Trim)
            End Get
        End Property

        Private Sub _btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOK.Click
            Select Case InputCheck()
                Case 0
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me._cmbProjectFolderName.Items.Add(_folderBrowserDialog.SelectedPath())
                    Me.Close()
                Case 1
                    Me._txtProjectName.Focus()
                    Me._txtProjectName.SelectAll()
                    Common.Message.ShowMessage(My.Resources.CED002_007_E)
                Case 2
                    Me._cmbProjectFolderName.Focus()
                    Me._cmbProjectFolderName.SelectAll()
                    Common.Message.ShowMessage(My.Resources.CED002_008_E)
                Case 3
                    Me._cmbProjectFolderName.Focus()
                    Me._cmbProjectFolderName.SelectAll()
                    Common.Message.ShowMessage(My.Resources.CED002_009_E)
                Case Else
            End Select
        End Sub

        Private Sub _btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub _btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnBrowse.Click
            If Me._folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me._cmbProjectFolderName.Text = Me._folderBrowserDialog.SelectedPath
            End If
        End Sub

        Private Sub _txtProjectName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles _txtProjectName.LostFocus
            _txtProjectName.Text = IO.Path.GetFileNameWithoutExtension(_txtProjectName.Text.Trim) & ProjectExtend
        End Sub

        Private Sub NewProjectDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            _txtProjectName.Text = ProjectNoname & ProjectExtend
        End Sub

        Private Function InputCheck() As Integer
            Dim result As Integer
            If IO.Path.GetFileNameWithoutExtension(Me._txtProjectName.Text.Trim) = String.Empty Then
                result = 1
            ElseIf Me._cmbProjectFolderName.Text.Trim = String.Empty Then
                result = 2
            ElseIf Not IO.Directory.Exists(Me._cmbProjectFolderName.Text.Trim) Then
                result = 3
            Else
                result = 0
            End If
            Return result
        End Function

    End Class
End Namespace
