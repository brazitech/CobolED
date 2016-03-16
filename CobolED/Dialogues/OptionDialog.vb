'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OptionDialog.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
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
Imports CobolED.Views
Imports CobolED.Managers.Manager
Imports CobolED.Managers

Namespace Dialogues
    Public Class OptionDialog

        Private Const ITEM_GENERAL As String = "Folder"
        Private Const ITEM_COLOR As String = "Color"
        Private Const ITEM_FILEEXPANSION As String = "Ext"

        Public Sub New()

            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            ' Add the initialization after the InitializeComponent () call .
            InitializeTreeView()

        End Sub

        Private Sub _btnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnDefault.Click
            Dim optionView As OptionViewBase
            For Each treeViewItem As TreeNode In _trvItems.Nodes
                If TypeOf treeViewItem.Tag Is OptionViewBase Then
                    optionView = DirectCast(treeViewItem.Tag, OptionViewBase)
                    optionView.Initialize(SettingManager.GetDefaultSettingInfo)
                End If
            Next
        End Sub

        Private Sub _btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOK.Click
            SettingManager.SetSettingInfo(GetMulticastDelegate)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub _btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub InitializeTreeView()
            AddTreeViewItem(ITEM_GENERAL, New OptionGeneralView)
            AddTreeViewItem(ITEM_COLOR, New OptionColorView)
            AddTreeViewItem(ITEM_FILEEXPANSION, New OptionFileExtensionsView)
            If _trvItems.Nodes.Count > 0 Then
                _trvItems.SelectedNode = _trvItems.Nodes(0)
            Else
            End If
        End Sub

        Private Sub AddTreeViewItem(ByVal itemName As String, ByVal OptionView As OptionViewBase)
            Dim treeViewItem As TreeNode
            treeViewItem = New TreeNode(itemName)
            treeViewItem.Tag = OptionView
            _trvItems.Nodes.Add(treeViewItem)
            OptionView.Location = New Point(200, 10)
            OptionView.Enabled = False
            OptionView.Visible = False
            Me.Controls.Add(OptionView)
            OptionView.Initialize(SettingManager.SettingInfo)
        End Sub

        Private Sub _trvItems_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles _trvItems.AfterSelect
            Dim optionView As OptionViewBase
            For Each treeNode As TreeNode In _trvItems.Nodes
                If TypeOf treeNode.Tag Is OptionViewBase Then
                    optionView = DirectCast(treeNode.Tag, OptionViewBase)
                    optionView.Enabled = False
                    optionView.Visible = False
                End If
            Next
            If TypeOf _trvItems.SelectedNode.Tag Is OptionViewBase Then
                optionView = DirectCast(_trvItems.SelectedNode.Tag, OptionViewBase)
                optionView.Enabled = True
                optionView.Visible = True
            End If
        End Sub

        Private Function GetMulticastDelegate() As SettingManagerSingleton.SetSettingInfoDelegate
            Dim delegateList As List(Of SettingManagerSingleton.SetSettingInfoDelegate)
            Dim optionView As OptionViewBase

            delegateList = New List(Of SettingManagerSingleton.SetSettingInfoDelegate)
            For Each treeViewItem As TreeNode In _trvItems.Nodes
                If TypeOf treeViewItem.Tag Is OptionViewBase Then
                    optionView = DirectCast(treeViewItem.Tag, OptionViewBase)
                    delegateList.Add(New SettingManagerSingleton.SetSettingInfoDelegate(AddressOf optionView.SetPartSettingInfo))
                End If
            Next
            Return [Delegate].Combine(delegateList.ToArray)
        End Function

    End Class
End Namespace
