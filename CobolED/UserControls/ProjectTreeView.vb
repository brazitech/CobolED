'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ProjectTreeView.vb                                      --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.UserControls                                    --
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
Imports CobolEDCore.Interfaces.Info
Namespace UserControls
    Public Class ProjectTreeView
        Inherits TreeView

        Private _doNotAutoExpandandCollapse As Boolean

        Public Sub New()
            MyBase.New()
        End Sub

        Private Sub ProjectTreeView_BeforeCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Me.BeforeCollapse
            If _doNotAutoExpandandCollapse Then
                e.Cancel = True
            End If
            _doNotAutoExpandandCollapse = False
        End Sub

        Private Sub ProjectTreeView_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Me.BeforeExpand
            If _doNotAutoExpandandCollapse Then
                e.Cancel = True
            End If
            _doNotAutoExpandandCollapse = False
        End Sub

        Private Sub ProjectTreeView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
            Dim currentNode As TreeNode
            If e.Button = Windows.Forms.MouseButtons.Right Then
                currentNode = GetNodeAt(e.Location)
                If currentNode IsNot Nothing Then
                    Me.SelectedNode = currentNode
                End If
            End If
        End Sub

        Private Sub ProjectTreeView_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Me.NodeMouseClick
            If e.Node.Bounds.Contains(Me.PointToClient(Windows.Forms.Cursor.Position)) AndAlso TypeOf e.Node.Tag Is IMoveable Then
                _doNotAutoExpandandCollapse = True
            Else
            End If
        End Sub


    End Class
End Namespace
