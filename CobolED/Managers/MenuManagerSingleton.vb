'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MenuManagerSingleton.vb                                 --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Managers                                        --
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

Imports CobolED.Menu
Imports CobolED.Forms
Imports CobolEDCore.Interfaces.Menu
Imports CobolEDCore.Infos.Menu
Imports Common

Namespace Managers
    Public Class MenuManagerSingleton
        Private _menuItemProcessList As Dictionary(Of ToolStripMenuItem, IMenuItemProcess)
        Private _editorContextMenu As ContextMenuStrip
        Private _projectNodeContextMenu As ContextMenuStrip
        Private _programNodeContextMenu As ContextMenuStrip
        Private Shared _menuManager As MenuManagerSingleton

        Private Sub New()            
            _menuItemProcessList = New Dictionary(Of ToolStripMenuItem, IMenuItemProcess)

            _editorContextMenu = New ContextMenuStrip
            AddHandler _editorContextMenu.Opening, AddressOf OnContextMenuOpening

            _projectNodeContextMenu = New ContextMenuStrip
            AddHandler _projectNodeContextMenu.Opening, AddressOf OnContextMenuOpening

            _programNodeContextMenu = New ContextMenuStrip
            AddHandler _programNodeContextMenu.Opening, AddressOf OnContextMenuOpening
        End Sub

        Public Shared ReadOnly Property MenuManager() As MenuManagerSingleton
            Get
                If _menuManager Is Nothing Then
                    _menuManager = New MenuManagerSingleton
                End If
                Return _menuManager
            End Get
        End Property

        Public ReadOnly Property EditorContextMenu() As ContextMenuStrip
            Get
                Return _editorContextMenu
            End Get
        End Property

        Public ReadOnly Property ProjectNodeContextMenu() As ContextMenuStrip
            Get
                Return _projectNodeContextMenu
            End Get
        End Property

        Public ReadOnly Property ProgramNodeContextMenu() As ContextMenuStrip
            Get
                Return _programNodeContextMenu
            End Get
        End Property

        Public Sub Initialize(ByVal cobolEDMainForm As CobolEDMainForm)
            CreateProcessList(cobolEDMainForm)
            CreateEditorContextMenu(cobolEDMainForm)
            CreateProjectNodeContextMenu(cobolEDMainForm)
            CreateProgramNodeContextMenu(cobolEDMainForm)
        End Sub

        Public Sub AddMenuItemProcess(ByVal menuItem As ToolStripMenuItem, ByVal menuItemProcess As IMenuItemProcess)
            If Not _menuItemProcessList.ContainsKey(menuItem) Then
                _menuItemProcessList.Add(menuItem, menuItemProcess)
                AddHandler menuItem.Click, AddressOf OnMenuItemClick
                AddHandler menuItem.DropDownOpening, AddressOf OnMenuItemDropDownOpening
                AddHandler menuItem.DropDownClosed, AddressOf OnMenuItemDropDownClosed
                AddHandler menuItem.MouseEnter, AddressOf OnMenuItemMouseEnter
            Else
            End If
        End Sub

        Public Sub DelMenuItemProcess(ByVal menuItem As ToolStripMenuItem)
            If _menuItemProcessList.ContainsKey(menuItem) Then
                _menuItemProcessList.Remove(menuItem)
                RemoveHandler menuItem.Click, AddressOf OnMenuItemClick
                RemoveHandler menuItem.DropDownOpening, AddressOf OnMenuItemDropDownOpening
                RemoveHandler menuItem.DropDownClosed, AddressOf OnMenuItemDropDownClosed
                RemoveHandler menuItem.MouseEnter, AddressOf OnMenuItemMouseEnter
            Else
            End If
        End Sub

        Public Sub AddContextMenuItemProcess(ByVal mainMenuItem As ToolStripMenuItem, ByVal contextMenu As ContextMenuStrip)
            Dim contextMenuItem As ToolStripMenuItem

            If _menuItemProcessList.ContainsKey(mainMenuItem) Then
                contextMenuItem = New ToolStripMenuItem(mainMenuItem.Text, mainMenuItem.Image)
                contextMenu.Items.Add(contextMenuItem)
                AddMenuItemProcess(contextMenuItem, _menuItemProcessList(mainMenuItem))
            Else
            End If
        End Sub

        Private Sub CreateProcessList(ByVal cobolEDMainForm As CobolEDMainForm)

            AddMenuItemProcess(cobolEDMainForm._menuFile, Nothing)
            AddMenuItemProcess(cobolEDMainForm._menuNewProject, New File.OnNewProject(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuOpenProject, New File.OnOpenProject(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuOpenFile, New File.OnOpenFile(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuCloseProject, New File.OnCloseProject(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuCloseFile, New File.OnCloseFile(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuSave, New File.OnSave(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuSaveAs, New File.OnSaveAs(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuSaveAll, New File.OnSaveAll(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuPageSetup, New File.OnPageSetup(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuPrintPreview, New File.OnPrintPreview(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuPrint, New File.OnPrint(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuRecentProjects, New File.OnRecentProjects(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuRecentFiles, New File.OnRecentFiles(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuExit, New File.OnExit(cobolEDMainForm))

            AddMenuItemProcess(cobolEDMainForm._menuEdit, Nothing)
            AddMenuItemProcess(cobolEDMainForm._menuUndo, New Edit.OnUndo(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuRedo, New Edit.OnRedo(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuCut, New Edit.OnCut(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuCopy, New Edit.OnCopy(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuPaste, New Edit.OnPaste(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuCommentOut, New Edit.OnCommentOut(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuCommentCancel, New Edit.OnCommentCancel(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuSelectAll, New Edit.OnSelectAll(cobolEDMainForm))

            AddMenuItemProcess(cobolEDMainForm._menuSearch, Nothing)
            AddMenuItemProcess(cobolEDMainForm._menuFind, New Search.OnFind(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuClearBookMark, New Search.OnClearBookMark(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuNextBookMark, New Search.OnNextBookMark(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuFindNext, New Search.OnNextFind(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuPrevBookMark, New Search.OnPrevBookMark(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuFindPrev, New Search.OnPrevFind(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuReplace, New Search.OnReplace(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuSetBookMark, New Search.OnSetBookMark(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuJump, New Search.OnJump(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuGoToDefine, New Search.OnGoToDefine(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuUnGoTo, New Search.OnUnGoTo(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuReGoTo, New Search.OnReGoTo(cobolEDMainForm))

            AddMenuItemProcess(cobolEDMainForm._menuProject, Nothing)
            AddMenuItemProcess(cobolEDMainForm._menuAddNewFile, New Project.OnAddNewFile(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuAddExistingFile, New Project.OnAddExistingFile(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuDeleteFile, New Project.OnDeleteFile(cobolEDMainForm))

            AddMenuItemProcess(cobolEDMainForm._menuSetting, Nothing)
            AddMenuItemProcess(cobolEDMainForm._menuOption, New Setting.OnOption(cobolEDMainForm))

            AddMenuItemProcess(cobolEDMainForm._menuWindow, Nothing)
            AddMenuItemProcess(cobolEDMainForm._menuNextWindow, New Window.OnNextWindow(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuPrevWindow, New Window.OnPrevWindow(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuWindowList, New Window.OnWindowList(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuVerticalWindow, New Window.OnVerticalWindow(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuHorizontalWindow, New Window.OnHorizontalWindow(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuMinimizeWindow, New Window.OnMinimizeWindow(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuRevertWindow, New Window.OnRevertWindow(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuCloseWindow, New Window.OnCloseWindow(cobolEDMainForm))

            AddMenuItemProcess(cobolEDMainForm._menuHelp, Nothing)
            AddMenuItemProcess(cobolEDMainForm._menuTechnology, New Help.OnTechnology(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuHistory, New Help.OnHistory(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuGPL, New Help.OnGPL(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuGPLNative, New Help.OnGPLNative(cobolEDMainForm))
            AddMenuItemProcess(cobolEDMainForm._menuAbout, New Help.OnAbout(cobolEDMainForm))

        End Sub

        Private Sub CreateEditorContextMenu(ByVal cobolEDMainForm As CobolEDMainForm)

            EditorContextMenu.Items.Clear()

            AddContextMenuItemProcess(cobolEDMainForm._menuCut, EditorContextMenu)
            AddContextMenuItemProcess(cobolEDMainForm._menuCopy, EditorContextMenu)
            AddContextMenuItemProcess(cobolEDMainForm._menuPaste, EditorContextMenu)

            EditorContextMenu.Items.Add(New ToolStripSeparator())
            AddContextMenuItemProcess(cobolEDMainForm._menuGoToDefine, EditorContextMenu)

            EditorContextMenu.Items.Add(New ToolStripSeparator())
            AddContextMenuItemProcess(cobolEDMainForm._menuCommentOut, EditorContextMenu)
            AddContextMenuItemProcess(cobolEDMainForm._menuCommentCancel, EditorContextMenu)

        End Sub

        Private Sub CreateProjectNodeContextMenu(ByVal cobolEDMainForm As CobolEDMainForm)
            ProjectNodeContextMenu.Items.Clear()

            AddContextMenuItemProcess(cobolEDMainForm._menuAddNewFile, ProjectNodeContextMenu)
            AddContextMenuItemProcess(cobolEDMainForm._menuAddExistingFile, ProjectNodeContextMenu)

        End Sub

        Private Sub CreateProgramNodeContextMenu(ByVal cobolEDMainForm As CobolEDMainForm)
            ProgramNodeContextMenu.Items.Clear()

            AddContextMenuItemProcess(cobolEDMainForm._menuDeleteFile, ProgramNodeContextMenu)

        End Sub

        Private Sub OnMenuItemClick(ByVal sender As Object, ByVal e As System.EventArgs)
            If _menuItemProcessList.ContainsKey(sender) AndAlso _menuItemProcessList(sender) IsNot Nothing Then
                If _menuItemProcessList(sender).IsEnable Then
                    Try
                        _menuItemProcessList(sender).Execute()
                    Catch myex As MyException
                        Common.Message.ShowMessage(myex)
                    Catch ex As Exception
                        Common.Message.ShowMessage(ex)
                    End Try
                Else
                End If
            End If
        End Sub

        Private Sub OnMenuItemDropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim menuItem As ToolStripMenuItem
            menuItem = DirectCast(sender, ToolStripMenuItem)
            For Each submenuItem As ToolStripItem In menuItem.DropDownItems
                If TypeOf submenuItem Is ToolStripMenuItem AndAlso _
                   _menuItemProcessList.ContainsKey(submenuItem) AndAlso _
                   _menuItemProcessList(submenuItem) IsNot Nothing Then

                    submenuItem.Enabled = _menuItemProcessList(submenuItem).IsEnable
                    If _menuItemProcessList(submenuItem).HasDynamicMenuItem Then
                        DelSubMenuItem(submenuItem)
                        AddSubMenuItem(submenuItem)
                    Else
                    End If

                Else
                End If
            Next
        End Sub

        Private Sub OnMenuItemDropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim menuItem As ToolStripMenuItem
            menuItem = DirectCast(sender, ToolStripMenuItem)
            For Each submenuItem As ToolStripItem In menuItem.DropDownItems
                If TypeOf submenuItem Is ToolStripMenuItem AndAlso _
                   _menuItemProcessList.ContainsKey(submenuItem) AndAlso _
                   _menuItemProcessList(submenuItem) IsNot Nothing Then

                    submenuItem.Enabled = True
                End If
            Next
        End Sub

        Private Sub OnMenuItemMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim menuItem As ToolStripMenuItem
            menuItem = DirectCast(sender, ToolStripMenuItem)
            If _menuItemProcessList.ContainsKey(menuItem) AndAlso _menuItemProcessList(menuItem) IsNot Nothing Then
                CobolEDMainForm._statusBarComment.Text = _menuItemProcessList(menuItem).Comment
            Else
                CobolEDMainForm._statusBarComment.Text = String.Empty
            End If
        End Sub

        Private Sub AddSubMenuItem(ByVal menuItem As ToolStripMenuItem)
            For Each dynamicMenuItemInfo As DynamicMenuItemInfo In _menuItemProcessList(menuItem).DynamicMenuItemInfos
                menuItem.DropDownItems.Add(dynamicMenuItemInfo.ToolStripMenuItem)
                AddMenuItemProcess(dynamicMenuItemInfo.ToolStripMenuItem, dynamicMenuItemInfo.MenuItemProcess)
            Next
        End Sub

        Private Sub DelSubMenuItem(ByVal menuItem As ToolStripMenuItem)
            For Each subMenuItem As ToolStripMenuItem In menuItem.DropDownItems
                DelMenuItemProcess(subMenuItem)
            Next
            menuItem.DropDownItems.Clear()
        End Sub

        Private Sub OnContextMenuOpening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            Dim contextMenu As ContextMenuStrip
            contextMenu = DirectCast(sender, ContextMenuStrip)

            For Each menuItem As ToolStripItem In contextMenu.Items
                If TypeOf menuItem Is ToolStripMenuItem AndAlso _
                   _menuItemProcessList.ContainsKey(menuItem) AndAlso _
                   _menuItemProcessList(menuItem) IsNot Nothing Then

                    menuItem.Enabled = _menuItemProcessList(menuItem).IsEnable
                Else
                End If
            Next
        End Sub

    End Class
End Namespace
