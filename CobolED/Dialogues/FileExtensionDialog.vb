'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  FileExtensionDialog.vb                                  --
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
Imports CobolEDCore.Document
Imports CobolED.Forms
Imports CobolED.Views
Imports CobolEDCore.Infos.SearchEngine
Imports CobolEDCore.Infos.Analyzer

Namespace Dialogues
    Public Class FileExtensionDialog

        Private Const EXTENSION As String = "{ 0 } analyzer corresponding file extension"
        Private _strAnalyzerName As String
        Private _strExtensions As String

        Public Property Extensions() As String
            Get
                Return Me._txtExtensions.Text
            End Get

            Set(ByVal value As String)
                Me._txtExtensions.Text = value
            End Set
        End Property

        Public Property AnalyzerName() As String
            Get
                Return _strAnalyzerName
            End Get
            Set(ByVal value As String)
                _strAnalyzerName = value
            End Set
        End Property

        Private Sub _btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOK.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub _btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub FileExtensionDialog_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            Me._txtExtensions.SelectAll()
            Me._txtExtensions.Focus()
        End Sub

        Private Sub FileExtensionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Me._lblExtension.Text = String.Format(EXTENSION, Me.AnalyzerName)
        End Sub

    End Class

End Namespace
