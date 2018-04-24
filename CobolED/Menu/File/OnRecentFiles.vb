'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnRecentFiles.vb                                        --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                    --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.File                                       --
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
Imports CobolEDCore.Infos.Menu
Imports CobolEDCore.Interfaces.Menu
Imports CobolED.Forms
Imports CobolED.Managers.Manager

Namespace Menu.File
    Public Class OnRecentFiles
        Inherits MenuItemProcessBase

        Private Const StrComment As String = "List Files recently opened"

        Public Sub New(ByVal cobolEdMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return StrComment
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                If SettingManager.SettingInfo.MaxRecentFileCount > 0 AndAlso _
                   SettingManager.SettingInfo.RecentFiles.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides ReadOnly Property HasDynamicMenuItem() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property DynamicMenuItemInfos() As System.Collections.Generic.List(Of CobolEDCore.Infos.Menu.DynamicMenuItemInfo)
            Get
                Dim result As List(Of DynamicMenuItemInfo)
                Dim toolStripMenuItem As ToolStripMenuItem
                Dim menuItemProcess As IMenuItemProcess

                result = New List(Of DynamicMenuItemInfo)
                For Each recentFile As String In SettingManager.SettingInfo.RecentFiles
                    toolStripMenuItem = New ToolStripMenuItem(recentFile)
                    menuItemProcess = New OnRecentFileSubItem(CobolEDMainForm, recentFile)
                    result.Add(New DynamicMenuItemInfo(toolStripMenuItem, menuItemProcess))
                Next
                Return result
            End Get
        End Property

        Public Overrides Sub Execute()

        End Sub

    End Class
End Namespace