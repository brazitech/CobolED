'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  JumpDialog.vb                                           --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
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
    Public Class JumpDialog

        Public ReadOnly Property LineNo() As Integer
            Get
                Dim result As Integer

                If Common.CommonFunction.IsNumber(Me._txtLineNO.Text.Trim) Then
                    result = CInt(Me._txtLineNO.Text)
                Else
                    result = -1
                End If

                Return result
            End Get
        End Property

        Private Sub _btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOK.Click
            If Common.CommonFunction.IsNumber(Me._txtLineNO.Text.Trim) Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me._txtLineNO.Focus()
                Me._txtLineNO.SelectAll()
                Common.Message.ShowMessage(My.Resources.CED002_019_E)
            End If
        End Sub

        Private Sub _btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub JumpDialog_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            Me._txtLineNO.Focus()
            Me._txtLineNO.SelectAll()
        End Sub

    End Class

End Namespace

