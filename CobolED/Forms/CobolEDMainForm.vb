'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CobolEDMainForm.vb                                      --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
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

Imports CobolEDCore.Infos
Imports CobolEDCore.Document
Imports CobolEDCore.Interfaces
Imports CobolED.Managers.Manager
Imports CobolED.Managers

Namespace Forms

    Public Class CobolEDMainForm

        Public Sub New()

            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            ' Add the initialization after the InitializeComponent () call .
            MenuManager.Initialize(Me)
            ToolBarManager.Initialize(Me)
            MemberManager.Initialize(Me._projectView)
        End Sub
        
    End Class

End Namespace