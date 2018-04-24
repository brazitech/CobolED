'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnOption.vb                                             --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.Setting                                    --
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
Imports CobolED.Forms

Namespace Menu.Setting
    Public Class OnOption
        Inherits MenuItemProcessBase

        Private _optionDialog As OptionDialog
        Private Const StrComment As String = "CobolED Change the editor options"

        Public Sub New(ByVal cobolEdMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
            _optionDialog = New OptionDialog
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return StrComment
            End Get
        End Property

        Public Overrides Sub Execute()
            If _optionDialog.ShowDialog = DialogResult.OK Then

            End If
        End Sub

    End Class
End Namespace
