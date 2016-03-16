'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  SelectTemplateDialog.vb                                 --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
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
Imports System.IO
Imports CobolED.Managers.Manager

Namespace Dialogues
    Public Class SelectTemplateDialog
        Private Const TEMPLATE_DIRECTORY As String = "template"
        Private Const ROOT_TEMPLATE_NAME As String = "Template"
        Private Const TEMPLATE_OPTION As String = "*.template"
        Private Const TEMPLATE_EXTEND As String = ".template"
        Private Const IMG_CLOSED_FOLDER As Integer = 0
        Private Const IMG_OPENED_FOLDER As Integer = 1
        Private Const IMG_TEMPLATE As Integer = 0
        Private Const FILE_NONAME As String = "NoNameFile.txt"

        Private _templateFullDir = String.Empty
        Private _selectedTemplateName As String
        Private _newFileName As String

        Public ReadOnly Property SelectedTemplateName() As String
            Get
                Return _selectedTemplateName
            End Get
        End Property

        Public ReadOnly Property NewFileName() As String
            Get
                Return _newFileName
            End Get
        End Property

        Private Sub _btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOK.Click
            Select Case InputCheck()
                Case 0
                    _newFileName = Me._txtFileName.Text.Trim
                    _selectedTemplateName = Me._txtTemplateName.Text.Trim
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                Case 1
                    Me._txtFileName.Focus()
                    Me._txtFileName.SelectAll()
                    Common.Message.ShowMessage(My.Resources.CED002_010_E)
                Case 2
                    Me._lsvTemplateContext.Focus()
                    Common.Message.ShowMessage(My.Resources.CED002_011_E)
                Case 3
                    Me._txtFileName.Focus()
                    Me._txtFileName.SelectAll()
                    Common.Message.ShowMessage(My.Resources.CED002_012_E)
                Case Else

            End Select
        End Sub

        Private Sub _btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub SelectTemplateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim firstNode As TreeNode
            Me._trvTemplateDir.Nodes.Clear()
            firstNode = _trvTemplateDir.Nodes.Add(ROOT_TEMPLATE_NAME)
            firstNode.ImageIndex = IMG_CLOSED_FOLDER
            firstNode.SelectedImageIndex = IMG_OPENED_FOLDER
            firstNode.Tag = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), TEMPLATE_DIRECTORY)
            InitializeTemplateTreeView(TEMPLATE_DIRECTORY, firstNode)
            _lsvTemplateContext.Items.Clear()
            _txtFileName.Text = FILE_NONAME
            _txtTemplateName.Text = String.Empty
            _trvTemplateDir.Nodes(0).Expand()
            _trvTemplateDir.SelectedNode = _trvTemplateDir.Nodes(0)
        End Sub

        Private Sub InitializeTemplateTreeView(ByVal dir As String, ByVal templateTreeNode As TreeNode)
            Dim templateNode As TreeNode
            Dim parentDir As String
            Dim subDirName As String

            parentDir = Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), dir)
            If IO.Directory.Exists(parentDir) Then
                For Each childrenDir As String In IO.Directory.GetDirectories(parentDir)
                    templateNode = templateTreeNode.Nodes.Add(IO.Path.GetFileName(childrenDir))
                    templateNode.ImageIndex = IMG_CLOSED_FOLDER
                    templateNode.SelectedImageIndex = IMG_OPENED_FOLDER
                    templateNode.Tag = childrenDir
                    subDirName = IO.Path.Combine(dir, childrenDir)
                    InitializeTemplateTreeView(subDirName, templateNode)
                Next
            Else
            End If
        End Sub

        Private Sub _trvTemplateDir_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles _trvTemplateDir.AfterSelect
            ShowTemplateContext(Me._trvTemplateDir.SelectedNode.Tag)
        End Sub

        Private Sub ShowTemplateContext(ByVal notePath As String)
            Dim templateItem As ListViewItem
            Me._lsvTemplateContext.Items.Clear()
            If IO.Directory.Exists(notePath) Then
                For Each fileName As String In Directory.GetFiles(notePath, TEMPLATE_OPTION, SearchOption.TopDirectoryOnly)
                    templateItem = New ListViewItem(IO.Path.GetFileNameWithoutExtension(fileName), IMG_TEMPLATE)
                    templateItem.Tag = fileName
                    Me._lsvTemplateContext.Items.Add(templateItem)
                Next
            Else
            End If
        End Sub

        Private Sub _lsvTemplateContext_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lsvTemplateContext.SelectedIndexChanged
            If Me._lsvTemplateContext.SelectedItems.Count = 0 Then
                Me._txtTemplateName.Text = String.Empty
            Else
                Me._txtTemplateName.Text = Me._lsvTemplateContext.SelectedItems(0).Tag
            End If

        End Sub

        Private Function InputCheck() As Integer
            Dim programPath As String
            Dim programFullName As String
            Dim result As Integer

            programPath = IO.Path.GetDirectoryName(ProjectManager.ProjectInfo.ProjectFileName())
            programFullName = IO.Path.Combine(programPath, _txtFileName.Text.Trim())
            If Me._txtFileName.Text.Trim = String.Empty Then
                result = 1
            ElseIf Me._txtTemplateName.Text.Trim = String.Empty Then
                result = 2
            ElseIf IO.File.Exists(programFullName) Then
                result = 3
            Else
                result = 0
            End If

            Return result
        End Function

    End Class


End Namespace
