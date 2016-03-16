'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OptionViewBase.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Views                                           --
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

Imports CobolEDCore.Infos.Setting
Imports CobolED.Managers.Manager
Imports System.xml

Namespace Views
    Public Class OptionViewBase

        Public Overridable Sub SetPartSettingInfo(ByRef settingInfo As SettingInfo)
        End Sub

        Public Overridable Sub Initialize(ByVal settingInfo As SettingInfo)
        End Sub

    End Class
End Namespace
