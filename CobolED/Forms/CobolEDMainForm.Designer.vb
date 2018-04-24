Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CobolEdMainForm
        Inherits System.Windows.Forms.Form

        'Form will override the dispose to clean up the list of components .



        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'It is required by the Windows Form Designer .



        Private components As System.ComponentModel.IContainer

        'Note : The following procedure It is required by the Windows Form Designer.



        'It can be changed using the Windows Forms Designer . 
        'Please do not change with the code editor .



        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CobolEDMainForm))
            Me._statusBar = New System.Windows.Forms.StatusStrip
            Me._statusBarComment = New System.Windows.Forms.ToolStripStatusLabel
            Me._statusBarRow = New System.Windows.Forms.ToolStripStatusLabel
            Me._statusBarPhysicalCol = New System.Windows.Forms.ToolStripStatusLabel
            Me._statusBarCol = New System.Windows.Forms.ToolStripStatusLabel
            Me._statusBarCaretStatus = New System.Windows.Forms.ToolStripStatusLabel
            Me._menu = New System.Windows.Forms.MenuStrip
            Me._menuFile = New System.Windows.Forms.ToolStripMenuItem
            Me._menuNewProject = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFileSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me._menuOpenProject = New System.Windows.Forms.ToolStripMenuItem
            Me._menuOpenFile = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFileSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me._menuCloseProject = New System.Windows.Forms.ToolStripMenuItem
            Me._menuCloseFile = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFileSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me._menuSave = New System.Windows.Forms.ToolStripMenuItem
            Me._menuSaveAs = New System.Windows.Forms.ToolStripMenuItem
            Me._menuSaveAll = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFileSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me._menuPageSetup = New System.Windows.Forms.ToolStripMenuItem
            Me._menuPrintPreview = New System.Windows.Forms.ToolStripMenuItem
            Me._menuPrint = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFileSeparator5 = New System.Windows.Forms.ToolStripSeparator
            Me._menuRecentProjects = New System.Windows.Forms.ToolStripMenuItem
            Me._menuRecentFiles = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFileSeparator6 = New System.Windows.Forms.ToolStripSeparator
            Me._menuExit = New System.Windows.Forms.ToolStripMenuItem
            Me._menuEdit = New System.Windows.Forms.ToolStripMenuItem
            Me._menuUndo = New System.Windows.Forms.ToolStripMenuItem
            Me._menuRedo = New System.Windows.Forms.ToolStripMenuItem
            Me._menuEditSaparator1 = New System.Windows.Forms.ToolStripSeparator
            Me._menuCut = New System.Windows.Forms.ToolStripMenuItem
            Me._menuCopy = New System.Windows.Forms.ToolStripMenuItem
            Me._menuPaste = New System.Windows.Forms.ToolStripMenuItem
            Me._menuEditSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me._menuCommentOut = New System.Windows.Forms.ToolStripMenuItem
            Me._menuCommentCancel = New System.Windows.Forms.ToolStripMenuItem
            Me._menuEditSeparator = New System.Windows.Forms.ToolStripSeparator
            Me._menuSelectAll = New System.Windows.Forms.ToolStripMenuItem
            Me._menuSearch = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFind = New System.Windows.Forms.ToolStripMenuItem
            Me._menuReplace = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFindNext = New System.Windows.Forms.ToolStripMenuItem
            Me._menuFindPrev = New System.Windows.Forms.ToolStripMenuItem
            Me._menuSearchSaparator1 = New System.Windows.Forms.ToolStripSeparator
            Me._menuReGoTo = New System.Windows.Forms.ToolStripMenuItem
            Me._menuUnGoTo = New System.Windows.Forms.ToolStripMenuItem
            Me._menuJump = New System.Windows.Forms.ToolStripMenuItem
            Me._menuSearchSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me._menuGoToDefine = New System.Windows.Forms.ToolStripMenuItem
            Me._menuSearchSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me._menuSetBookMark = New System.Windows.Forms.ToolStripMenuItem
            Me._menuNextBookMark = New System.Windows.Forms.ToolStripMenuItem
            Me._menuPrevBookMark = New System.Windows.Forms.ToolStripMenuItem
            Me._menuClearBookMark = New System.Windows.Forms.ToolStripMenuItem
            Me._menuProject = New System.Windows.Forms.ToolStripMenuItem
            Me._menuAddNewFile = New System.Windows.Forms.ToolStripMenuItem
            Me._menuAddExistingFile = New System.Windows.Forms.ToolStripMenuItem
            Me._menuProjectSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me._menuDeleteFile = New System.Windows.Forms.ToolStripMenuItem
            Me._menuSetting = New System.Windows.Forms.ToolStripMenuItem
            Me._menuOption = New System.Windows.Forms.ToolStripMenuItem
            Me._menuWindow = New System.Windows.Forms.ToolStripMenuItem
            Me._menuNextWindow = New System.Windows.Forms.ToolStripMenuItem
            Me._menuPrevWindow = New System.Windows.Forms.ToolStripMenuItem
            Me._menuWindowSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me._menuHorizontalWindow = New System.Windows.Forms.ToolStripMenuItem
            Me._menuVerticalWindow = New System.Windows.Forms.ToolStripMenuItem
            Me._menuMinimizeWindow = New System.Windows.Forms.ToolStripMenuItem
            Me._menuRevertWindow = New System.Windows.Forms.ToolStripMenuItem
            Me._menuCloseWindow = New System.Windows.Forms.ToolStripMenuItem
            Me._menuWindowSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me._menuWindowList = New System.Windows.Forms.ToolStripMenuItem
            Me._menuHelp = New System.Windows.Forms.ToolStripMenuItem
            Me._menuTechnology = New System.Windows.Forms.ToolStripMenuItem
            Me._menuHistory = New System.Windows.Forms.ToolStripMenuItem
            Me._menuHelpSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me._menuGPL = New System.Windows.Forms.ToolStripMenuItem
            Me._menuGPLNative = New System.Windows.Forms.ToolStripMenuItem
            Me._menuHelpSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me._menuAbout = New System.Windows.Forms.ToolStripMenuItem
            Me._toolBar = New System.Windows.Forms.ToolStrip
            Me._toolBarNewProject = New System.Windows.Forms.ToolStripButton
            Me._toolBarOpenProject = New System.Windows.Forms.ToolStripButton
            Me._toolBarOpenFile = New System.Windows.Forms.ToolStripButton
            Me._toolBarSave = New System.Windows.Forms.ToolStripButton
            Me._toolBarSaveAll = New System.Windows.Forms.ToolStripButton
            Me._toolBarSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me._toolBarUndo = New System.Windows.Forms.ToolStripButton
            Me._toolBarRedo = New System.Windows.Forms.ToolStripButton
            Me._toolBarSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me._toolBarCut = New System.Windows.Forms.ToolStripButton
            Me._toolBarCopy = New System.Windows.Forms.ToolStripButton
            Me._toolBarPaste = New System.Windows.Forms.ToolStripButton
            Me._toolBarSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me._toolBarCommentOut = New System.Windows.Forms.ToolStripButton
            Me._toolBarCommentCancel = New System.Windows.Forms.ToolStripButton
            Me._toolBarSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me._toolBarFind = New System.Windows.Forms.ToolStripButton
            Me._toolBarFindPrev = New System.Windows.Forms.ToolStripButton
            Me._toolBarFindNext = New System.Windows.Forms.ToolStripButton
            Me._toolBarSeparator5 = New System.Windows.Forms.ToolStripSeparator
            Me._toolBarUnGoTo = New System.Windows.Forms.ToolStripButton
            Me._toolBarReGoTo = New System.Windows.Forms.ToolStripButton
            Me._toolBarSeparator6 = New System.Windows.Forms.ToolStripSeparator
            Me._toolBarSetBookMark = New System.Windows.Forms.ToolStripButton
            Me._toolBarPrevBookMark = New System.Windows.Forms.ToolStripButton
            Me._toolBarNextBookMark = New System.Windows.Forms.ToolStripButton
            Me._toolBarClearBookMark = New System.Windows.Forms.ToolStripButton
            Me._projectViewPanel = New System.Windows.Forms.Panel
            Me._projectView = New CobolED.Views.ProjectView
            Me._projectViewSplitter = New System.Windows.Forms.Splitter
            Me._resultViewPanel = New System.Windows.Forms.Panel
            Me._resultViewTabControl = New System.Windows.Forms.TabControl
            Me._findResultTabPage = New System.Windows.Forms.TabPage
            Me._findResultView = New CobolED.Views.FindResultView
            Me._resultViewSplitter = New System.Windows.Forms.Splitter
            Me._statusBar.SuspendLayout()
            Me._menu.SuspendLayout()
            Me._toolBar.SuspendLayout()
            Me._projectViewPanel.SuspendLayout()
            Me._resultViewPanel.SuspendLayout()
            Me._resultViewTabControl.SuspendLayout()
            Me._findResultTabPage.SuspendLayout()
            Me.SuspendLayout()
            '
            '_statusBar
            '
            Me._statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._statusBarComment, Me._statusBarRow, Me._statusBarPhysicalCol, Me._statusBarCol, Me._statusBarCaretStatus})
            Me._statusBar.Location = New System.Drawing.Point(0, 544)
            Me._statusBar.Name = "_statusBar"
            Me._statusBar.Size = New System.Drawing.Size(792, 22)
            Me._statusBar.TabIndex = 3
            Me._statusBar.Text = "StatusStrip1"
            '
            '_statusBarComment
            '
            Me._statusBarComment.Name = "_statusBarComment"
            Me._statusBarComment.Size = New System.Drawing.Size(577, 17)
            Me._statusBarComment.Spring = True
            Me._statusBarComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_statusBarRow
            '
            Me._statusBarRow.AutoSize = False
            Me._statusBarRow.Name = "_statusBarRow"
            Me._statusBarRow.Size = New System.Drawing.Size(50, 17)
            Me._statusBarRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_statusBarPhysicalCol
            '
            Me._statusBarPhysicalCol.AutoSize = False
            Me._statusBarPhysicalCol.Name = "_statusBarPhysicalCol"
            Me._statusBarPhysicalCol.Size = New System.Drawing.Size(50, 17)
            Me._statusBarPhysicalCol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_statusBarCol
            '
            Me._statusBarCol.AutoSize = False
            Me._statusBarCol.Name = "_statusBarCol"
            Me._statusBarCol.Size = New System.Drawing.Size(50, 17)
            Me._statusBarCol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_statusBarCaretStatus
            '
            Me._statusBarCaretStatus.AutoSize = False
            Me._statusBarCaretStatus.Name = "_statusBarCaretStatus"
            Me._statusBarCaretStatus.Size = New System.Drawing.Size(50, 17)
            '
            '_menu
            '
            Me._menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuFile, Me._menuEdit, Me._menuSearch, Me._menuProject, Me._menuSetting, Me._menuWindow, Me._menuHelp})
            Me._menu.Location = New System.Drawing.Point(0, 0)
            Me._menu.Name = "_menu"
            Me._menu.Size = New System.Drawing.Size(792, 24)
            Me._menu.TabIndex = 4
            Me._menu.Text = "MenuStrip1"
            '
            '_menuFile
            '
            Me._menuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuNewProject, Me._menuFileSeparator1, Me._menuOpenProject, Me._menuOpenFile, Me._menuFileSeparator2, Me._menuCloseProject, Me._menuCloseFile, Me._menuFileSeparator3, Me._menuSave, Me._menuSaveAs, Me._menuSaveAll, Me._menuFileSeparator4, Me._menuPageSetup, Me._menuPrintPreview, Me._menuPrint, Me._menuFileSeparator5, Me._menuRecentProjects, Me._menuRecentFiles, Me._menuFileSeparator6, Me._menuExit})
            Me._menuFile.Name = "_menuFile"
            Me._menuFile.Size = New System.Drawing.Size(66, 20)
            Me._menuFile.Text = "File"
            '
            '_menuNewProject
            '
            Me._menuNewProject.Image = Global.CobolED.My.Resources.Resources.File_NewProject
            Me._menuNewProject.Name = "_menuNewProject"
            Me._menuNewProject.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
            Me._menuNewProject.Size = New System.Drawing.Size(223, 22)
            Me._menuNewProject.Text = "New project(&P)..."
            '
            '_menuFileSeparator1
            '
            Me._menuFileSeparator1.Name = "_menuFileSeparator1"
            Me._menuFileSeparator1.Size = New System.Drawing.Size(220, 6)
            '
            '_menuOpenProject
            '
            Me._menuOpenProject.Image = Global.CobolED.My.Resources.Resources.File_OpenProject
            Me._menuOpenProject.Name = "_menuOpenProject"
            Me._menuOpenProject.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
            Me._menuOpenProject.Size = New System.Drawing.Size(223, 22)
            Me._menuOpenProject.Text = "Open Project(&P)..."
            '
            '_menuOpenFile
            '
            Me._menuOpenFile.Image = Global.CobolED.My.Resources.Resources.File_OpenFile
            Me._menuOpenFile.Name = "_menuOpenFile"
            Me._menuOpenFile.Size = New System.Drawing.Size(223, 22)
            Me._menuOpenFile.Text = "Open file..."
            '
            '_menuFileSeparator2
            '
            Me._menuFileSeparator2.Name = "_menuFileSeparator2"
            Me._menuFileSeparator2.Size = New System.Drawing.Size(220, 6)
            '
            '_menuCloseProject
            '
            Me._menuCloseProject.Name = "_menuCloseProject"
            Me._menuCloseProject.Size = New System.Drawing.Size(223, 22)
            Me._menuCloseProject.Text = "Close Project"
            '
            '_menuCloseFile
            '
            Me._menuCloseFile.Name = "_menuCloseFile"
            Me._menuCloseFile.Size = New System.Drawing.Size(223, 22)
            Me._menuCloseFile.Text = "Close File"
            '
            '_menuFileSeparator3
            '
            Me._menuFileSeparator3.Name = "_menuFileSeparator3"
            Me._menuFileSeparator3.Size = New System.Drawing.Size(220, 6)
            '
            '_menuSave
            '
            Me._menuSave.Image = Global.CobolED.My.Resources.Resources.File_Save
            Me._menuSave.Name = "_menuSave"
            Me._menuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
            Me._menuSave.Size = New System.Drawing.Size(223, 22)
            Me._menuSave.Text = "File Save"
            '
            '_menuSaveAs
            '
            Me._menuSaveAs.Name = "_menuSaveAs"
            Me._menuSaveAs.Size = New System.Drawing.Size(223, 22)
            Me._menuSaveAs.Text = "Save As..."
            '
            '_menuSaveAll
            '
            Me._menuSaveAll.Image = Global.CobolED.My.Resources.Resources.File_SaveAll
            Me._menuSaveAll.Name = "_menuSaveAll"
            Me._menuSaveAll.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                        Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
            Me._menuSaveAll.Size = New System.Drawing.Size(223, 22)
            Me._menuSaveAll.Text = "Save All"
            '
            '_menuFileSeparator4
            '
            Me._menuFileSeparator4.Name = "_menuFileSeparator4"
            Me._menuFileSeparator4.Size = New System.Drawing.Size(220, 6)
            '
            '_menuPageSetup
            '
            Me._menuPageSetup.Image = Global.CobolED.My.Resources.Resources.File_PageSetup
            Me._menuPageSetup.Name = "_menuPageSetup"
            Me._menuPageSetup.Size = New System.Drawing.Size(223, 22)
            Me._menuPageSetup.Text = "Page Setup..."
            '
            '_menuPrintPreview
            '
            Me._menuPrintPreview.Image = Global.CobolED.My.Resources.Resources.File_PrintPreview
            Me._menuPrintPreview.Name = "_menuPrintPreview"
            Me._menuPrintPreview.Size = New System.Drawing.Size(223, 22)
            Me._menuPrintPreview.Text = "Print Prev."
            '
            '_menuPrint
            '
            Me._menuPrint.Image = Global.CobolED.My.Resources.Resources.File_Print
            Me._menuPrint.Name = "_menuPrint"
            Me._menuPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
            Me._menuPrint.Size = New System.Drawing.Size(223, 22)
            Me._menuPrint.Text = "Print..."
            '
            '_menuFileSeparator5
            '
            Me._menuFileSeparator5.Name = "_menuFileSeparator5"
            Me._menuFileSeparator5.Size = New System.Drawing.Size(220, 6)
            '
            '_menuRecentProjects
            '
            Me._menuRecentProjects.Name = "_menuRecentProjects"
            Me._menuRecentProjects.Size = New System.Drawing.Size(223, 22)
            Me._menuRecentProjects.Text = "Recent Projects"
            '
            '_menuRecentFiles
            '
            Me._menuRecentFiles.Name = "_menuRecentFiles"
            Me._menuRecentFiles.Size = New System.Drawing.Size(223, 22)
            Me._menuRecentFiles.Text = "Recent Files"
            '
            '_menuFileSeparator6
            '
            Me._menuFileSeparator6.Name = "_menuFileSeparator6"
            Me._menuFileSeparator6.Size = New System.Drawing.Size(220, 6)
            '
            '_menuExit
            '
            Me._menuExit.Name = "_menuExit"
            Me._menuExit.Size = New System.Drawing.Size(223, 22)
            Me._menuExit.Text = "Exit"
            '
            '_menuEdit
            '
            Me._menuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuUndo, Me._menuRedo, Me._menuEditSaparator1, Me._menuCut, Me._menuCopy, Me._menuPaste, Me._menuEditSeparator2, Me._menuCommentOut, Me._menuCommentCancel, Me._menuEditSeparator, Me._menuSelectAll})
            Me._menuEdit.Name = "_menuEdit"
            Me._menuEdit.Size = New System.Drawing.Size(56, 20)
            Me._menuEdit.Text = "Edit"
            '
            '_menuUndo
            '
            Me._menuUndo.Image = Global.CobolED.My.Resources.Resources.Edit_Undo
            Me._menuUndo.Name = "_menuUndo"
            Me._menuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
            Me._menuUndo.Size = New System.Drawing.Size(177, 22)
            Me._menuUndo.Text = "Undo"
            '
            '_menuRedo
            '
            Me._menuRedo.Image = Global.CobolED.My.Resources.Resources.Edit_Redo
            Me._menuRedo.Name = "_menuRedo"
            Me._menuRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
            Me._menuRedo.Size = New System.Drawing.Size(177, 22)
            Me._menuRedo.Text = "Redo"
            '
            '_menuEditSaparator1
            '
            Me._menuEditSaparator1.Name = "_menuEditSaparator1"
            Me._menuEditSaparator1.Size = New System.Drawing.Size(174, 6)
            '
            '_menuCut
            '
            Me._menuCut.Image = Global.CobolED.My.Resources.Resources.Edit_Cut
            Me._menuCut.Name = "_menuCut"
            Me._menuCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
            Me._menuCut.Size = New System.Drawing.Size(177, 22)
            Me._menuCut.Text = "Cut"
            '
            '_menuCopy
            '
            Me._menuCopy.Image = Global.CobolED.My.Resources.Resources.Edit_Copy
            Me._menuCopy.Name = "_menuCopy"
            Me._menuCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
            Me._menuCopy.Size = New System.Drawing.Size(177, 22)
            Me._menuCopy.Text = "Copy"
            '
            '_menuPaste
            '
            Me._menuPaste.Image = Global.CobolED.My.Resources.Resources.Edit_Paste
            Me._menuPaste.Name = "_menuPaste"
            Me._menuPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
            Me._menuPaste.Size = New System.Drawing.Size(177, 22)
            Me._menuPaste.Text = "Paste"
            '
            '_menuEditSeparator2
            '
            Me._menuEditSeparator2.Name = "_menuEditSeparator2"
            Me._menuEditSeparator2.Size = New System.Drawing.Size(174, 6)
            '
            '_menuCommentOut
            '
            Me._menuCommentOut.Image = Global.CobolED.My.Resources.Resources.Edit_CommentOut
            Me._menuCommentOut.Name = "_menuCommentOut"
            Me._menuCommentOut.Size = New System.Drawing.Size(177, 22)
            Me._menuCommentOut.Text = "Comment Out"
            '
            '_menuCommentCancel
            '
            Me._menuCommentCancel.Image = Global.CobolED.My.Resources.Resources.Edit_CommentCancel
            Me._menuCommentCancel.Name = "_menuCommentCancel"
            Me._menuCommentCancel.Size = New System.Drawing.Size(177, 22)
            Me._menuCommentCancel.Text = "Cancel Comment"
            '
            '_menuEditSeparator
            '
            Me._menuEditSeparator.Name = "_menuEditSeparator"
            Me._menuEditSeparator.Size = New System.Drawing.Size(174, 6)
            '
            '_menuSelectAll
            '
            Me._menuSelectAll.Name = "_menuSelectAll"
            Me._menuSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
            Me._menuSelectAll.Size = New System.Drawing.Size(177, 22)
            Me._menuSelectAll.Text = "Select All"
            '
            '_menuSearch
            '
            Me._menuSearch.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuFind, Me._menuReplace, Me._menuFindNext, Me._menuFindPrev, Me._menuSearchSaparator1, Me._menuReGoTo, Me._menuUnGoTo, Me._menuJump, Me._menuSearchSeparator2, Me._menuGoToDefine, Me._menuSearchSeparator3, Me._menuSetBookMark, Me._menuNextBookMark, Me._menuPrevBookMark, Me._menuClearBookMark})
            Me._menuSearch.Name = "_menuSearch"
            Me._menuSearch.Size = New System.Drawing.Size(56, 20)
            Me._menuSearch.Text = "Search(&S)"
            '
            '_menuFind
            '
            Me._menuFind.Image = Global.CobolED.My.Resources.Resources.Search_Find
            Me._menuFind.Name = "_menuFind"
            Me._menuFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
            Me._menuFind.Size = New System.Drawing.Size(243, 22)
            Me._menuFind.Text = "Find..."
            '
            '_menuReplace
            '
            Me._menuReplace.Image = Global.CobolED.My.Resources.Resources.Search_Replace
            Me._menuReplace.Name = "_menuReplace"
            Me._menuReplace.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
            Me._menuReplace.Size = New System.Drawing.Size(243, 22)
            Me._menuReplace.Text = "Replace..."
            '
            '_menuFindNext
            '
            Me._menuFindNext.Image = Global.CobolED.My.Resources.Resources.Search_FindNext
            Me._menuFindNext.Name = "_menuFindNext"
            Me._menuFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3
            Me._menuFindNext.Size = New System.Drawing.Size(243, 22)
            Me._menuFindNext.Text = "Find Next"
            '
            '_menuFindPrev
            '
            Me._menuFindPrev.Image = Global.CobolED.My.Resources.Resources.Search_FindPrev
            Me._menuFindPrev.Name = "_menuFindPrev"
            Me._menuFindPrev.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
            Me._menuFindPrev.Size = New System.Drawing.Size(243, 22)
            Me._menuFindPrev.Text = "Find Prev"
            'FindPrev
            '_menuSearchSaparator1
            '
            Me._menuSearchSaparator1.Name = "_menuSearchSaparator1"
            Me._menuSearchSaparator1.Size = New System.Drawing.Size(240, 6)
            '
            '_menuReGoTo
            '
            Me._menuReGoTo.Image = Global.CobolED.My.Resources.Resources.Search_ReGoTo
            Me._menuReGoTo.Name = "_menuReGoTo"
            Me._menuReGoTo.Size = New System.Drawing.Size(243, 22)
            Me._menuReGoTo.Text = "ReGoTo"
            '
            '_menuUnGoTo
            '
            Me._menuUnGoTo.Image = Global.CobolED.My.Resources.Resources.Search_UnGoTo
            Me._menuUnGoTo.Name = "_menuUnGoTo"
            Me._menuUnGoTo.Size = New System.Drawing.Size(243, 22)
            Me._menuUnGoTo.Text = "UnGoTo"
            '
            '_menuJump
            '
            Me._menuJump.Name = "_menuJump"
            Me._menuJump.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
            Me._menuJump.Size = New System.Drawing.Size(243, 22)
            Me._menuJump.Text = "Next..."
            '
            '_menuSearchSeparator2
            '
            Me._menuSearchSeparator2.Name = "_menuSearchSeparator2"
            Me._menuSearchSeparator2.Size = New System.Drawing.Size(240, 6)
            '
            '_menuGoToDefine
            '
            Me._menuGoToDefine.Image = Global.CobolED.My.Resources.Resources.Search_GoToDefine
            Me._menuGoToDefine.Name = "_menuGoToDefine"
            Me._menuGoToDefine.Size = New System.Drawing.Size(243, 22)
            Me._menuGoToDefine.Text = "Goto)"
            '
            '_menuSearchSeparator3
            '
            Me._menuSearchSeparator3.Name = "_menuSearchSeparator3"
            Me._menuSearchSeparator3.Size = New System.Drawing.Size(240, 6)
            '
            '_menuSetBookMark
            '
            Me._menuSetBookMark.Image = Global.CobolED.My.Resources.Resources.Search_SetBookMark
            Me._menuSetBookMark.Name = "_menuSetBookMark"
            Me._menuSetBookMark.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
            Me._menuSetBookMark.Size = New System.Drawing.Size(243, 22)
            Me._menuSetBookMark.Text = "Mark"
            '
            '_menuNextBookMark
            '
            Me._menuNextBookMark.Image = Global.CobolED.My.Resources.Resources.Search_NextBookMark
            Me._menuNextBookMark.Name = "_menuNextBookMark"
            Me._menuNextBookMark.ShortcutKeys = System.Windows.Forms.Keys.F2
            Me._menuNextBookMark.Size = New System.Drawing.Size(243, 22)
            Me._menuNextBookMark.Text = "Next Mark"
            '
            '_menuPrevBookMark
            '
            Me._menuPrevBookMark.Image = Global.CobolED.My.Resources.Resources.Search_PrevBookMark
            Me._menuPrevBookMark.Name = "_menuPrevBookMark"
            Me._menuPrevBookMark.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
            Me._menuPrevBookMark.Size = New System.Drawing.Size(243, 22)
            Me._menuPrevBookMark.Text = "Prev Mark"
            '
            '_menuClearBookMark
            '
            Me._menuClearBookMark.Image = Global.CobolED.My.Resources.Resources.Search_ClearBookMark
            Me._menuClearBookMark.Name = "_menuClearBookMark"
            Me._menuClearBookMark.Size = New System.Drawing.Size(243, 22)
            Me._menuClearBookMark.Text = "Clear Mark"
            '
            '_menuProject
            '
            Me._menuProject.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuAddNewFile, Me._menuAddExistingFile, Me._menuProjectSeparator1, Me._menuDeleteFile})
            Me._menuProject.Name = "_menuProject"
            Me._menuProject.Size = New System.Drawing.Size(83, 20)
            Me._menuProject.Text = "Project"
            '
            '_menuAddNewFile
            '
            Me._menuAddNewFile.Name = "_menuAddNewFile"
            Me._menuAddNewFile.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                        Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
            Me._menuAddNewFile.Size = New System.Drawing.Size(259, 22)
            Me._menuAddNewFile.Text = "AddNewFile..."
            '
            '_menuAddExistingFile
            '
            Me._menuAddExistingFile.Name = "_menuAddExistingFile"
            Me._menuAddExistingFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
            Me._menuAddExistingFile.Size = New System.Drawing.Size(259, 22)
            Me._menuAddExistingFile.Text = "AddExistingFile..."
            '
            '_menuProjectSeparator1
            '
            Me._menuProjectSeparator1.Name = "_menuProjectSeparator1"
            Me._menuProjectSeparator1.Size = New System.Drawing.Size(256, 6)
            '
            '_menuDeleteFile
            '
            Me._menuDeleteFile.Name = "_menuDeleteFile"
            Me._menuDeleteFile.Size = New System.Drawing.Size(259, 22)
            Me._menuDeleteFile.Text = "DeleteFile"
            '
            '_menuSetting
            '
            Me._menuSetting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuOption})
            Me._menuSetting.Name = "_menuSetting"
            Me._menuSetting.Size = New System.Drawing.Size(56, 20)
            Me._menuSetting.Text = "Setting"
            '
            '_menuOption
            '
            Me._menuOption.Image = Global.CobolED.My.Resources.Resources.Setting_Option
            Me._menuOption.Name = "_menuOption"
            Me._menuOption.Size = New System.Drawing.Size(135, 22)
            Me._menuOption.Text = "Option..."
            '
            '_menuWindow
            '
            Me._menuWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuNextWindow, Me._menuPrevWindow, Me._menuWindowSeparator1, Me._menuHorizontalWindow, Me._menuVerticalWindow, Me._menuMinimizeWindow, Me._menuRevertWindow, Me._menuCloseWindow, Me._menuWindowSeparator2, Me._menuWindowList})
            Me._menuWindow.Name = "_menuWindow"
            Me._menuWindow.Size = New System.Drawing.Size(68, 20)
            Me._menuWindow.Text = "Window"
            '
            '_menuNextWindow
            '
            Me._menuNextWindow.Name = "_menuNextWindow"
            Me._menuNextWindow.ShortcutKeys = System.Windows.Forms.Keys.F6
            Me._menuNextWindow.Size = New System.Drawing.Size(198, 22)
            Me._menuNextWindow.Text = "NextWindow"
            '
            '_menuPrevWindow
            '
            Me._menuPrevWindow.Name = "_menuPrevWindow"
            Me._menuPrevWindow.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F6), System.Windows.Forms.Keys)
            Me._menuPrevWindow.Size = New System.Drawing.Size(198, 22)
            Me._menuPrevWindow.Text = "PrevWindow"
            '
            '_menuWindowSeparator1
            '
            Me._menuWindowSeparator1.Name = "_menuWindowSeparator1"
            Me._menuWindowSeparator1.Size = New System.Drawing.Size(195, 6)
            '
            '_menuHorizontalWindow
            '
            Me._menuHorizontalWindow.Name = "_menuHorizontalWindow"
            Me._menuHorizontalWindow.Size = New System.Drawing.Size(198, 22)
            Me._menuHorizontalWindow.Text = "Split Horz."
            '
            '_menuVerticalWindow
            '
            Me._menuVerticalWindow.Name = "_menuVerticalWindow"
            Me._menuVerticalWindow.Size = New System.Drawing.Size(198, 22)
            Me._menuVerticalWindow.Text = "Split Vert."
            '
            '_menuMinimizeWindow
            '
            Me._menuMinimizeWindow.Name = "_menuMinimizeWindow"
            Me._menuMinimizeWindow.Size = New System.Drawing.Size(198, 22)
            Me._menuMinimizeWindow.Text = "Minimize"
            '
            '_menuRevertWindow
            '
            Me._menuRevertWindow.Image = Global.CobolED.My.Resources.Resources.Window_RevertWindow
            Me._menuRevertWindow.Name = "_menuRevertWindow"
            Me._menuRevertWindow.Size = New System.Drawing.Size(198, 22)
            Me._menuRevertWindow.Text = "Maximize"
            '
            '_menuCloseWindow
            '
            Me._menuCloseWindow.Image = Global.CobolED.My.Resources.Resources.Window_CloseWindow
            Me._menuCloseWindow.Name = "_menuCloseWindow"
            Me._menuCloseWindow.Size = New System.Drawing.Size(198, 22)
            Me._menuCloseWindow.Text = "CloseWindow"
            '
            '_menuWindowSeparator2
            '
            Me._menuWindowSeparator2.Name = "_menuWindowSeparator2"
            Me._menuWindowSeparator2.Size = New System.Drawing.Size(195, 6)
            '
            '_menuWindowList
            '
            Me._menuWindowList.Name = "_menuWindowList"
            Me._menuWindowList.Size = New System.Drawing.Size(198, 22)
            Me._menuWindowList.Text = "WindowList"
            '
            '_menuHelp
            '
            Me._menuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuTechnology, Me._menuHistory, Me._menuHelpSeparator1, Me._menuGPL, Me._menuGPLNative, Me._menuHelpSeparator2, Me._menuAbout})
            Me._menuHelp.Name = "_menuHelp"
            Me._menuHelp.Size = New System.Drawing.Size(62, 20)
            Me._menuHelp.Text = "Help"
            '
            '_menuTechnology
            '
            Me._menuTechnology.Image = Global.CobolED.My.Resources.Resources.Help_Technology
            Me._menuTechnology.Name = "_menuTechnology"
            Me._menuTechnology.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                        Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
            Me._menuTechnology.Size = New System.Drawing.Size(232, 22)
            Me._menuTechnology.Text = "Docs..."
            '
            '_menuHistory
            '
            Me._menuHistory.Image = Global.CobolED.My.Resources.Resources.Help_History
            Me._menuHistory.Name = "_menuHistory"
            Me._menuHistory.Size = New System.Drawing.Size(232, 22)
            Me._menuHistory.Text = "History..."
            '
            '_menuHelpSeparator1
            '
            Me._menuHelpSeparator1.Name = "_menuHelpSeparator1"
            Me._menuHelpSeparator1.Size = New System.Drawing.Size(229, 6)
            '
            '_menuGPL
            '
            Me._menuGPL.Image = Global.CobolED.My.Resources.Resources.Help_GPL
            Me._menuGPL.Name = "_menuGPL"
            Me._menuGPL.Size = New System.Drawing.Size(232, 22)
            Me._menuGPL.Text = "GNU General Public License..."
            '
            '_menuGPLNative
            '
            Me._menuGPLNative.Image = Global.CobolED.My.Resources.Resources.Help_GPL
            Me._menuGPLNative.Name = "_menuGPLNative"
            Me._menuGPLNative.Size = New System.Drawing.Size(232, 22)
            Me._menuGPLNative.Text = "GNU一GPLNative..."
            '
            '_menuHelpSeparator2
            '
            Me._menuHelpSeparator2.Name = "_menuHelpSeparator2"
            Me._menuHelpSeparator2.Size = New System.Drawing.Size(229, 6)
            '
            '_menuAbout
            '
            Me._menuAbout.Name = "_menuAbout"
            Me._menuAbout.Size = New System.Drawing.Size(232, 22)
            Me._menuAbout.Text = "About..."
            '
            '_toolBar
            '
            Me._toolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._toolBarNewProject, Me._toolBarOpenProject, Me._toolBarOpenFile, Me._toolBarSave, Me._toolBarSaveAll, Me._toolBarSeparator1, Me._toolBarUndo, Me._toolBarRedo, Me._toolBarSeparator2, Me._toolBarCut, Me._toolBarCopy, Me._toolBarPaste, Me._toolBarSeparator3, Me._toolBarCommentOut, Me._toolBarCommentCancel, Me._toolBarSeparator4, Me._toolBarFind, Me._toolBarFindPrev, Me._toolBarFindNext, Me._toolBarSeparator5, Me._toolBarUnGoTo, Me._toolBarReGoTo, Me._toolBarSeparator6, Me._toolBarSetBookMark, Me._toolBarPrevBookMark, Me._toolBarNextBookMark, Me._toolBarClearBookMark})
            Me._toolBar.Location = New System.Drawing.Point(0, 24)
            Me._toolBar.Name = "_toolBar"
            Me._toolBar.Size = New System.Drawing.Size(792, 25)
            Me._toolBar.TabIndex = 8
            Me._toolBar.Text = "ToolStrip1"
            '
            '_toolBarNewProject
            '
            Me._toolBarNewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarNewProject.Image = Global.CobolED.My.Resources.Resources.File_NewProject
            Me._toolBarNewProject.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarNewProject.Name = "_toolBarNewProject"
            Me._toolBarNewProject.Size = New System.Drawing.Size(23, 22)
            Me._toolBarNewProject.Text = "New project"
            '
            '_toolBarOpenProject
            '
            Me._toolBarOpenProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarOpenProject.Image = Global.CobolED.My.Resources.Resources.File_OpenProject
            Me._toolBarOpenProject.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarOpenProject.Name = "_toolBarOpenProject"
            Me._toolBarOpenProject.Size = New System.Drawing.Size(23, 22)
            Me._toolBarOpenProject.Text = "Open Project"
            '
            '_toolBarOpenFile
            '
            Me._toolBarOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarOpenFile.Image = Global.CobolED.My.Resources.Resources.File_OpenFile
            Me._toolBarOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarOpenFile.Name = "_toolBarOpenFile"
            Me._toolBarOpenFile.Size = New System.Drawing.Size(23, 22)
            Me._toolBarOpenFile.Text = "Open file"
            '
            '_toolBarSave
            '
            Me._toolBarSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarSave.Image = Global.CobolED.My.Resources.Resources.File_Save
            Me._toolBarSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarSave.Name = "_toolBarSave"
            Me._toolBarSave.Size = New System.Drawing.Size(23, 22)
            Me._toolBarSave.Text = "File Save "
            '
            '_toolBarSaveAll
            '
            Me._toolBarSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarSaveAll.Image = Global.CobolED.My.Resources.Resources.File_SaveAll
            Me._toolBarSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarSaveAll.Name = "_toolBarSaveAll"
            Me._toolBarSaveAll.Size = New System.Drawing.Size(23, 22)
            Me._toolBarSaveAll.Text = "Save All"
            '
            '_toolBarSeparator1
            '
            Me._toolBarSeparator1.Name = "_toolBarSeparator1"
            Me._toolBarSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            '_toolBarUndo
            '
            Me._toolBarUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarUndo.Image = Global.CobolED.My.Resources.Resources.Edit_Undo
            Me._toolBarUndo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarUndo.Name = "_toolBarUndo"
            Me._toolBarUndo.Size = New System.Drawing.Size(23, 22)
            Me._toolBarUndo.Text = "Undo"
            '
            '_toolBarRedo
            '
            Me._toolBarRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarRedo.Image = Global.CobolED.My.Resources.Resources.Edit_Redo
            Me._toolBarRedo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarRedo.Name = "_toolBarRedo"
            Me._toolBarRedo.Size = New System.Drawing.Size(23, 22)
            Me._toolBarRedo.Text = "Redo"
            '
            '_toolBarSeparator2
            '
            Me._toolBarSeparator2.Name = "_toolBarSeparator2"
            Me._toolBarSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            '_toolBarCut
            '
            Me._toolBarCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarCut.Image = Global.CobolED.My.Resources.Resources.Edit_Cut
            Me._toolBarCut.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarCut.Name = "_toolBarCut"
            Me._toolBarCut.Size = New System.Drawing.Size(23, 22)
            Me._toolBarCut.Text = "Cut"
            '
            '_toolBarCopy
            '
            Me._toolBarCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarCopy.Image = Global.CobolED.My.Resources.Resources.Edit_Copy
            Me._toolBarCopy.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarCopy.Name = "_toolBarCopy"
            Me._toolBarCopy.Size = New System.Drawing.Size(23, 22)
            Me._toolBarCopy.Text = "Copy"
            '
            '_toolBarPaste
            '
            Me._toolBarPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarPaste.Image = Global.CobolED.My.Resources.Resources.Edit_Paste
            Me._toolBarPaste.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarPaste.Name = "_toolBarPaste"
            Me._toolBarPaste.Size = New System.Drawing.Size(23, 22)
            Me._toolBarPaste.Text = "Paste"
            '
            '_toolBarSeparator3
            '
            Me._toolBarSeparator3.Name = "_toolBarSeparator3"
            Me._toolBarSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            '_toolBarCommentOut
            '
            Me._toolBarCommentOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarCommentOut.Image = Global.CobolED.My.Resources.Resources.Edit_CommentOut
            Me._toolBarCommentOut.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarCommentOut.Name = "_toolBarCommentOut"
            Me._toolBarCommentOut.Size = New System.Drawing.Size(23, 22)
            Me._toolBarCommentOut.Text = "Comment Out"
            '
            '_toolBarCommentCancel
            '
            Me._toolBarCommentCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarCommentCancel.Image = Global.CobolED.My.Resources.Resources.Edit_CommentCancel
            Me._toolBarCommentCancel.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarCommentCancel.Name = "_toolBarCommentCancel"
            Me._toolBarCommentCancel.Size = New System.Drawing.Size(23, 22)
            Me._toolBarCommentCancel.Text = "Cancel Comment"
            '
            '_toolBarSeparator4
            '
            Me._toolBarSeparator4.Name = "_toolBarSeparator4"
            Me._toolBarSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            '_toolBarFind
            '
            Me._toolBarFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarFind.Image = Global.CobolED.My.Resources.Resources.Search_Find
            Me._toolBarFind.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarFind.Name = "_toolBarFind"
            Me._toolBarFind.Size = New System.Drawing.Size(23, 22)
            Me._toolBarFind.Text = "Search"
            '
            '_toolBarFindPrev
            '
            Me._toolBarFindPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarFindPrev.Image = Global.CobolED.My.Resources.Resources.Search_FindPrev
            Me._toolBarFindPrev.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarFindPrev.Name = "_toolBarFindPrev"
            Me._toolBarFindPrev.Size = New System.Drawing.Size(23, 22)
            Me._toolBarFindPrev.Text = "FindPrev"
            '
            '_toolBarFindNext
            '
            Me._toolBarFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarFindNext.Image = Global.CobolED.My.Resources.Resources.Search_FindNext
            Me._toolBarFindNext.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarFindNext.Name = "_toolBarFindNext"
            Me._toolBarFindNext.Size = New System.Drawing.Size(23, 22)
            Me._toolBarFindNext.Text = "FindNext"
            '
            '_toolBarSeparator5
            '
            Me._toolBarSeparator5.Name = "_toolBarSeparator5"
            Me._toolBarSeparator5.Size = New System.Drawing.Size(6, 25)
            '
            '_toolBarUnGoTo
            '
            Me._toolBarUnGoTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarUnGoTo.Image = Global.CobolED.My.Resources.Resources.Search_UnGoTo
            Me._toolBarUnGoTo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarUnGoTo.Name = "_toolBarUnGoTo"
            Me._toolBarUnGoTo.Size = New System.Drawing.Size(23, 22)
            Me._toolBarUnGoTo.Text = "UnGoTo"
            '
            '_toolBarReGoTo
            '
            Me._toolBarReGoTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarReGoTo.Image = Global.CobolED.My.Resources.Resources.Search_ReGoTo
            Me._toolBarReGoTo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarReGoTo.Name = "_toolBarReGoTo"
            Me._toolBarReGoTo.Size = New System.Drawing.Size(23, 22)
            Me._toolBarReGoTo.Text = "ReGoTo"
            '
            '_toolBarSeparator6
            '
            Me._toolBarSeparator6.Name = "_toolBarSeparator6"
            Me._toolBarSeparator6.Size = New System.Drawing.Size(6, 25)
            '
            '_toolBarSetBookMark
            '
            Me._toolBarSetBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarSetBookMark.Image = Global.CobolED.My.Resources.Resources.Search_SetBookMark
            Me._toolBarSetBookMark.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarSetBookMark.Name = "_toolBarSetBookMark"
            Me._toolBarSetBookMark.Size = New System.Drawing.Size(23, 22)
            Me._toolBarSetBookMark.Text = "Set Mark"
            '
            '_toolBarPrevBookMark
            '
            Me._toolBarPrevBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarPrevBookMark.Image = Global.CobolED.My.Resources.Resources.Search_PrevBookMark
            Me._toolBarPrevBookMark.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarPrevBookMark.Name = "_toolBarPrevBookMark"
            Me._toolBarPrevBookMark.Size = New System.Drawing.Size(23, 22)
            Me._toolBarPrevBookMark.Text = "PrevMark"
            '
            '_toolBarNextBookMark
            '
            Me._toolBarNextBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarNextBookMark.Image = Global.CobolED.My.Resources.Resources.Search_NextBookMark
            Me._toolBarNextBookMark.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarNextBookMark.Name = "_toolBarNextBookMark"
            Me._toolBarNextBookMark.Size = New System.Drawing.Size(23, 22)
            Me._toolBarNextBookMark.Text = "NextMark"
            '
            '_toolBarClearBookMark
            '
            Me._toolBarClearBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me._toolBarClearBookMark.Image = Global.CobolED.My.Resources.Resources.Search_ClearBookMark
            Me._toolBarClearBookMark.ImageTransparentColor = System.Drawing.Color.Magenta
            Me._toolBarClearBookMark.Name = "_toolBarClearBookMark"
            Me._toolBarClearBookMark.Size = New System.Drawing.Size(23, 22)
            Me._toolBarClearBookMark.Text = "ClearMark"
            '
            '_projectViewPanel
            '
            Me._projectViewPanel.Controls.Add(Me._projectView)
            Me._projectViewPanel.Dock = System.Windows.Forms.DockStyle.Right
            Me._projectViewPanel.Location = New System.Drawing.Point(442, 49)
            Me._projectViewPanel.Name = "_projectViewPanel"
            Me._projectViewPanel.Size = New System.Drawing.Size(350, 495)
            Me._projectViewPanel.TabIndex = 9
            '
            '_projectView
            '
            Me._projectView.Dock = System.Windows.Forms.DockStyle.Fill
            Me._projectView.Location = New System.Drawing.Point(0, 0)
            Me._projectView.Name = "_projectView"
            Me._projectView.Size = New System.Drawing.Size(350, 495)
            Me._projectView.TabIndex = 0
            '
            '_projectViewSplitter
            '
            Me._projectViewSplitter.Dock = System.Windows.Forms.DockStyle.Right
            Me._projectViewSplitter.Location = New System.Drawing.Point(439, 49)
            Me._projectViewSplitter.Name = "_projectViewSplitter"
            Me._projectViewSplitter.Size = New System.Drawing.Size(3, 495)
            Me._projectViewSplitter.TabIndex = 10
            Me._projectViewSplitter.TabStop = False
            '
            '_resultViewPanel
            '
            Me._resultViewPanel.Controls.Add(Me._resultViewTabControl)
            Me._resultViewPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me._resultViewPanel.Location = New System.Drawing.Point(0, 376)
            Me._resultViewPanel.Name = "_resultViewPanel"
            Me._resultViewPanel.Size = New System.Drawing.Size(439, 168)
            Me._resultViewPanel.TabIndex = 12
            '
            '_resultViewTabControl
            '
            Me._resultViewTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
            Me._resultViewTabControl.Controls.Add(Me._findResultTabPage)
            Me._resultViewTabControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me._resultViewTabControl.Location = New System.Drawing.Point(0, 0)
            Me._resultViewTabControl.Name = "_resultViewTabControl"
            Me._resultViewTabControl.SelectedIndex = 0
            Me._resultViewTabControl.Size = New System.Drawing.Size(439, 168)
            Me._resultViewTabControl.TabIndex = 0
            '
            '_findResultTabPage
            '
            Me._findResultTabPage.Controls.Add(Me._findResultView)
            Me._findResultTabPage.Location = New System.Drawing.Point(4, 4)
            Me._findResultTabPage.Name = "_findResultTabPage"
            Me._findResultTabPage.Padding = New System.Windows.Forms.Padding(3)
            Me._findResultTabPage.Size = New System.Drawing.Size(431, 143)
            Me._findResultTabPage.TabIndex = 0
            Me._findResultTabPage.Text = "Search results"
            Me._findResultTabPage.UseVisualStyleBackColor = True
            '
            '_findResultView
            '
            Me._findResultView.Dock = System.Windows.Forms.DockStyle.Fill
            Me._findResultView.Location = New System.Drawing.Point(3, 3)
            Me._findResultView.Name = "_findResultView"
            Me._findResultView.Size = New System.Drawing.Size(425, 137)
            Me._findResultView.TabIndex = 0
            '
            '_resultViewSplitter
            '
            Me._resultViewSplitter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me._resultViewSplitter.Location = New System.Drawing.Point(0, 373)
            Me._resultViewSplitter.Name = "_resultViewSplitter"
            Me._resultViewSplitter.Size = New System.Drawing.Size(439, 3)
            Me._resultViewSplitter.TabIndex = 13
            Me._resultViewSplitter.TabStop = False
            '
            'CobolEDMainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(792, 566)
            Me.Controls.Add(Me._resultViewSplitter)
            Me.Controls.Add(Me._resultViewPanel)
            Me.Controls.Add(Me._projectViewSplitter)
            Me.Controls.Add(Me._projectViewPanel)
            Me.Controls.Add(Me._toolBar)
            Me.Controls.Add(Me._statusBar)
            Me.Controls.Add(Me._menu)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.IsMdiContainer = True
            Me.MainMenuStrip = Me._menu
            Me.Name = "CobolEDMainForm"
            Me.Text = "CobolED"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me._statusBar.ResumeLayout(False)
            Me._statusBar.PerformLayout()
            Me._menu.ResumeLayout(False)
            Me._menu.PerformLayout()
            Me._toolBar.ResumeLayout(False)
            Me._toolBar.PerformLayout()
            Me._projectViewPanel.ResumeLayout(False)
            Me._resultViewPanel.ResumeLayout(False)
            Me._resultViewTabControl.ResumeLayout(False)
            Me._findResultTabPage.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents _statusBar As System.Windows.Forms.StatusStrip
        Friend WithEvents _menu As System.Windows.Forms.MenuStrip
        Friend WithEvents _toolBar As System.Windows.Forms.ToolStrip
        Friend WithEvents _projectViewPanel As System.Windows.Forms.Panel
        Friend WithEvents _projectViewSplitter As System.Windows.Forms.Splitter
        Friend WithEvents _projectView As Views.ProjectView
        Friend WithEvents _menuFile As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuOpenProject As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuNewProject As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _resultViewPanel As System.Windows.Forms.Panel
        Friend WithEvents _resultViewTabControl As System.Windows.Forms.TabControl
        Friend WithEvents _findResultTabPage As System.Windows.Forms.TabPage
        Friend WithEvents _resultViewSplitter As System.Windows.Forms.Splitter
        Friend WithEvents _findResultView As CobolED.Views.FindResultView
        Friend WithEvents _menuEdit As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuUndo As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuRedo As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuEditSaparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuCut As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuCopy As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuPaste As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuSelectAll As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuSearch As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuFind As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuFindNext As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuFindPrev As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuSearchSaparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuSetBookMark As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuNextBookMark As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuPrevBookMark As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuClearBookMark As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuFileSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuOpenFile As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuFileSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuFileSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuCloseFile As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuCloseProject As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuFileSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuSave As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuSaveAs As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuSaveAll As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuFileSeparator5 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuPageSetup As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuPrint As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuFileSeparator6 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuRecentFiles As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuRecentProjects As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuExit As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuEditSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuReGoTo As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuUnGoTo As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuJump As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuSearchSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuProject As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuCommentOut As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuCommentCancel As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuEditSeparator As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuAddNewFile As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuAddExistingFile As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuProjectSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuDeleteFile As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuSetting As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuOption As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuHelp As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuNextWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuPrevWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuWindowSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuHorizontalWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuVerticalWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuMinimizeWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuRevertWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuCloseWindow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuWindowSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuTechnology As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuHelpSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _menuAbout As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuReplace As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuGoToDefine As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuSearchSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _toolBarNewProject As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarOpenFile As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarOpenProject As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarSave As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarSaveAll As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _toolBarUndo As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarRedo As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarCut As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarCopy As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarPaste As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _toolBarSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _toolBarFindNext As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _toolBarUnGoTo As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarReGoTo As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarSeparator5 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _toolBarSetBookMark As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarPrevBookMark As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarNextBookMark As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarClearBookMark As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarCommentOut As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarCommentCancel As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarFindPrev As System.Windows.Forms.ToolStripButton
        Friend WithEvents _toolBarSeparator6 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents _statusBarComment As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents _statusBarRow As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents _statusBarCol As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents _statusBarCaretStatus As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents _statusBarPhysicalCol As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents _toolBarFind As System.Windows.Forms.ToolStripButton
        Friend WithEvents _menuWindowList As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuPrintPreview As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuGPLNative As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuGPL As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuHistory As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents _menuHelpSeparator2 As System.Windows.Forms.ToolStripSeparator

    End Class

End Namespace