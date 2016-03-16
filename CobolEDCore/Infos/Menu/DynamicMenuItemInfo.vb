'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  DynamicMenuItemInfo.vb                                  --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Infos.Menu                                  --
'--                                                                           --
'--  Project       :  CobolEDCore                                             --
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
Imports CobolEDCore.Interfaces.Menu
Namespace Infos.Menu
    Public Class DynamicMenuItemInfo

        Private _toolStripMenuItem As ToolStripMenuItem
        Private _menuItemProcess As IMenuItemProcess

        Public Sub New(ByVal toolStripMenuItem As ToolStripMenuItem, ByVal menuItemProcess As IMenuItemProcess)
            _toolStripMenuItem = toolStripMenuItem
            _menuItemProcess = menuItemProcess
        End Sub

        Public Sub New()
            Me.New(Nothing, Nothing)
        End Sub

        Public Property ToolStripMenuItem() As ToolStripMenuItem
            Get
                Return _toolStripMenuItem
            End Get
            Set(ByVal value As ToolStripMenuItem)
                _toolStripMenuItem = value
            End Set
        End Property

        Public Property MenuItemProcess() As IMenuItemProcess
            Get
                Return _menuItemProcess
            End Get
            Set(ByVal value As IMenuItemProcess)
                _menuItemProcess = value
            End Set
        End Property

    End Class
End Namespace
