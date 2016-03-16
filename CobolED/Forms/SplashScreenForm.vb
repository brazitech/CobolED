'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  SplashScreenForm.vb                                     --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Forms                                           --
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

Namespace Forms
    Public NotInheritable Class SplashScreenForm

        Public Property Status() As String
            Get
                Return Me._lblStatus.Text
            End Get
            Set(ByVal value As String)
                Me._lblStatus.Text = value
                Me.Refresh()
            End Set
        End Property

        Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Me._lblVersion.Text = My.Application.Info.Version.ToString
            Me._lblCopyright.Text = My.Application.Info.Copyright
            Me._lblStatus.Text = String.Empty
        End Sub

    End Class
End Namespace