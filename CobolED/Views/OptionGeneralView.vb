'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OptionGeneralView.vb                                    --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
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

Namespace Views
    Public Class OptionGeneralView

        Public Overrides Sub SetPartSettingInfo(ByRef settingInfo As SettingInfo)
            settingInfo.MaxRecentProjectCount = Me._numProjectFileCount.Value
            If settingInfo.RecentProjects.Count > settingInfo.MaxRecentProjectCount Then
                settingInfo.RecentProjects.RemoveRange(settingInfo.MaxRecentProjectCount, settingInfo.RecentProjects.Count - settingInfo.MaxRecentProjectCount)
            End If
            settingInfo.MaxRecentFileCount = Me._numFileCount.Value
            If settingInfo.RecentFiles.Count > settingInfo.MaxRecentFileCount Then
                settingInfo.RecentFiles.RemoveRange(settingInfo.MaxRecentFileCount, settingInfo.RecentFiles.Count - settingInfo.MaxRecentFileCount)
            End If
        End Sub

        Public Overrides Sub Initialize(ByVal settingInfo As SettingInfo)
            Me._numProjectFileCount.Value = settingInfo.MaxRecentProjectCount
            Me._numFileCount.Value = settingInfo.MaxRecentFileCount
        End Sub

    End Class
End Namespace
