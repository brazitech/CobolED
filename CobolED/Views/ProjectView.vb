'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ProjectView.vb                                          --
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

Imports System.Reflection
Imports common.CommonFunction
Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Interfaces.Info
Imports CobolEDCore.Interfaces.View
Imports CobolEDCore.Attributes
Imports CobolED.Managers.Manager
Imports CobolED.Forms
Imports System.Windows.Forms

Namespace Views
    Public Class ProjectView
        Implements INeedUpdateMember

        Private Const ImgProgject As Integer = 0
        Private Const ImgProgram As Integer = 1
        Private Const ImgFunction As Integer = 2
        Private Const ImgVariable As Integer = 3
        Private Const ImgInclude As Integer = 4
        Private Const ImgGather As Integer = 5
        Private Const TxtGatherFunction As String = "function"
        Private Const TxtGatherVariable As String = "variable"
        Private Const TxtGatherInclude As String = "Reference"

        Private Delegate Sub UpdateTreeNodeDelegate(ByVal programFileName As String, ByVal gatherNode As TreeNode)
        Private _updateInclude As UpdateTreeNodeDelegate
        Private _updateFunction As UpdateTreeNodeDelegate
        Private _updateVariable As UpdateTreeNodeDelegate

        Public Sub New()

            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            ' Add the initialization after the InitializeComponent () call .
            _updateInclude = New UpdateTreeNodeDelegate(AddressOf UpdateIncludeNode)
            _updateFunction = New UpdateTreeNodeDelegate(AddressOf UpdateFunctionNode)
            _updateVariable = New UpdateTreeNodeDelegate(AddressOf UpdateVariableNode)
        End Sub

        Public Sub ClearProjectTreeView()
            _projectTreeView.Nodes.Clear()
        End Sub

        Public Sub InitializeProjectTreeView()
            Dim projectInfo As ProjectInfo

            ClearProjectTreeView()

            'ProjectNode
            projectInfo = ProjectManager.ProjectInfo
            SetProjectNode(projectInfo)

            _projectTreeView.Nodes(0).Expand()
            _projectTreeView.SelectedNode = _projectTreeView.Nodes(0)
        End Sub

        Public Sub Rename(ByVal oldName As String, ByVal newName As String)
            Dim node As TreeNode
            node = Me.GetTreeNode(IO.Path.GetFileName(oldName), _projectTreeView.Nodes(0))
            node.Text = IO.Path.GetFileName(newName)
        End Sub

        Public Sub UpdateProgramNode(ByVal programInfo As ProgramInfo) Implements INeedUpdateMember.UpdateMember
            Dim programNode As TreeNode

            programNode = GetTreeNode(programInfo.ProgramName, Me._projectTreeView.Nodes(0))
            If programNode IsNot Nothing Then
                If programNode.IsExpanded Then
                    programNode.Collapse()
                End If
                programNode.Nodes(TxtGatherInclude).Tag = _updateInclude
                programNode.Nodes(TxtGatherFunction).Tag = _updateFunction
                programNode.Nodes(TxtGatherVariable).Tag = _updateVariable
            Else
            End If

        End Sub

        Private Sub SetProjectNode(ByVal projectInfo As ProjectInfo)
            Dim projectNode As TreeNode
            projectNode = _projectTreeView.Nodes.Add(projectInfo.ProjectName)
            projectNode.ImageIndex = ImgProgject
            projectNode.SelectedImageIndex = ImgProgject
            projectNode.Tag = projectInfo
            projectNode.ContextMenuStrip = MenuManager.ProjectNodeContextMenu

            'ProgramNode
            For Each programInfo As ProgramInfo In projectInfo.ProgramInfos
                AddProgramNode(programInfo, projectNode)
            Next
        End Sub

        Private Sub AddProgramNode(ByVal programInfo As ProgramInfo, ByVal projectNode As TreeNode)
            Dim programNode As TreeNode
            Dim gatherNode As TreeNode
            programNode = projectNode.Nodes.Add(programInfo.ProgramName)
            programNode.ImageIndex = ImgProgram
            programNode.SelectedImageIndex = ImgProgram
            programNode.Tag = programInfo
            programNode.ContextMenuStrip = MenuManager.ProgramNodeContextMenu

            'IncludeNode
            gatherNode = programNode.Nodes.Add(TxtGatherInclude)
            gatherNode.Name = TxtGatherInclude
            gatherNode.ImageIndex = ImgGather
            gatherNode.SelectedImageIndex = ImgGather
            gatherNode.Tag = Nothing

            For Each includeInfo As IncludeInfo In MemberManager.GetIncludeInfoList(programInfo.ProgramFileName)
                AddIncludeNode(includeInfo, gatherNode)
            Next

            'FunctionNode
            gatherNode = programNode.Nodes.Add(TxtGatherFunction)
            gatherNode.Name = TxtGatherFunction
            gatherNode.ImageIndex = ImgGather
            gatherNode.SelectedImageIndex = ImgGather
            gatherNode.Tag = Nothing
            For Each functionInfo As FunctionInfo In MemberManager.GetFunctionInfoList(programInfo.ProgramFileName)
                AddFunctionNode(functionInfo, gatherNode)
            Next

            'VariableNode
            gatherNode = programNode.Nodes.Add(TxtGatherVariable)
            gatherNode.Name = TxtGatherVariable
            gatherNode.ImageIndex = ImgGather
            gatherNode.SelectedImageIndex = ImgGather
            gatherNode.Tag = Nothing
            For Each variableInfo As VariableInfo In MemberManager.GetVariableInfoList(programInfo.ProgramFileName)
                AddVariableNode(variableInfo, gatherNode)
            Next

        End Sub

        Private Sub AddIncludeNode(ByVal includeInfo As IncludeInfo, ByVal gatherNode As TreeNode)
            Dim includeNode As TreeNode

            includeNode = gatherNode.Nodes.Add(includeInfo.IncludeName)
            includeNode.ImageIndex = ImgInclude
            includeNode.SelectedImageIndex = ImgInclude
            includeNode.Tag = includeInfo
        End Sub

        Private Sub AddFunctionNode(ByVal functionInfo As FunctionInfo, ByVal gatherNode As TreeNode)
            Dim functionNode As TreeNode
            Dim parentFunctionNode As TreeNode

            If functionInfo.FunctionParent = String.Empty Then
                parentFunctionNode = gatherNode
            Else
                parentFunctionNode = GetTreeNode(functionInfo.FunctionParent, gatherNode)
            End If
            If parentFunctionNode IsNot Nothing Then
                functionNode = parentFunctionNode.Nodes.Add(functionInfo.FunctionName)
                functionNode.ImageIndex = ImgFunction
                functionNode.SelectedImageIndex = ImgFunction
                functionNode.Tag = functionInfo
            Else
                functionNode = gatherNode.Nodes.Add(functionInfo.FunctionName)
                functionNode.ImageIndex = ImgFunction
                functionNode.SelectedImageIndex = ImgFunction
                functionNode.Tag = functionInfo
            End If
        End Sub

        Private Sub AddVariableNode(ByVal variableInfo As VariableInfo, ByVal gatherNode As TreeNode)
            Dim parentVariableNode As TreeNode
            Dim variableNode As TreeNode

            If variableInfo.VariableParent = String.Empty Then
                parentVariableNode = gatherNode
            Else
                parentVariableNode = GetTreeNode(variableInfo.VariableParent, gatherNode)
            End If

            If parentVariableNode IsNot Nothing Then
                variableNode = parentVariableNode.Nodes.Add(variableInfo.VariableName)
                variableNode.ImageIndex = ImgVariable
                variableNode.SelectedImageIndex = ImgVariable
                variableNode.Tag = variableInfo
            Else
                variableNode = gatherNode.Nodes.Add(variableInfo.VariableName)
                variableNode.ImageIndex = ImgVariable
                variableNode.SelectedImageIndex = ImgVariable
                variableNode.Tag = variableInfo
            End If
        End Sub

        Private Sub ShowDetail(ByVal showingObject As Object)
            Dim showInItemAttr As ShowInItemAttribute
            Dim itemNameAttr As ItemNameAttribute
            Dim showInDescriptionAttr As ShowInDescriptionAttribute

            _propertyView.Rows.Clear()
            _descriptionView.Text = String.Empty

            If showingObject IsNot Nothing Then
                For Each pinfo As Reflection.PropertyInfo In showingObject.GetType.GetProperties(BindingFlags.Public Or BindingFlags.Instance)

                    showInItemAttr = DirectCast(Attribute.GetCustomAttribute(pinfo, GetType(ShowInItemAttribute)), ShowInItemAttribute)
                    itemNameAttr = DirectCast(Attribute.GetCustomAttribute(pinfo, GetType(ItemNameAttribute)), ItemNameAttribute)
                    showInDescriptionAttr = DirectCast(Attribute.GetCustomAttribute(pinfo, GetType(ShowInDescriptionAttribute)), ShowInDescriptionAttribute)

                    If showInItemAttr IsNot Nothing AndAlso showInItemAttr.IsShow = True Then
                        If itemNameAttr IsNot Nothing Then
                            _propertyView.Rows.Add(itemNameAttr.Name, pinfo.GetValue(showingObject, Nothing))
                        Else
                            _propertyView.Rows.Add(pinfo.Name, pinfo.GetValue(showingObject, Nothing))
                        End If
                    End If

                    If showInDescriptionAttr IsNot Nothing AndAlso showInDescriptionAttr.IsShow = True Then
                        If itemNameAttr IsNot Nothing Then
                            _descriptionView.Text &= (itemNameAttr.Name & vbCrLf & pinfo.GetValue(showingObject, Nothing))
                        Else
                            _descriptionView.Text &= (pinfo.Name & vbCrLf & pinfo.GetValue(showingObject, Nothing))
                        End If
                    End If
                Next
            Else
            End If

        End Sub

        Private Sub _projectTreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles _projectTreeView.AfterSelect
            ShowDetail(e.Node.Tag)
        End Sub

        Private Sub _projectTreeView_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles _projectTreeView.BeforeExpand
            Dim updateTreeNode As UpdateTreeNodeDelegate
            Dim programFileName As String

            If TypeOf e.Node.Tag Is ProgramInfo Then
                programFileName = DirectCast(e.Node.Tag, ProgramInfo).ProgramFileName
                For Each gatherNode As TreeNode In e.Node.Nodes
                    If TypeOf gatherNode.Tag Is UpdateTreeNodeDelegate Then
                        updateTreeNode = DirectCast(gatherNode.Tag, UpdateTreeNodeDelegate)
                        gatherNode.Tag = Nothing
                        updateTreeNode(programFileName, gatherNode)
                    End If
                Next
            End If
        End Sub

        Private Sub _projectTreeView_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles _projectTreeView.NodeMouseDoubleClick
            Dim info As IMoveable
            Dim wantedForm As DocumentForm

            If TypeOf e.Node.Tag Is IMoveable Then
                info = DirectCast(e.Node.Tag, IMoveable)
                wantedForm = DocumentFormManager.ActivateDocumentForm(info.FileName, FormWindowState.Maximized)
                If info.Position.Row >= 0 AndAlso info.Position.Col >= 0 AndAlso wantedForm IsNot Nothing Then
                    wantedForm.CobolEDEditor.CaretMoveTo(info.Position.Row, info.Position.Col)
                Else
                End If
            Else
            End If
        End Sub

        Private Sub UpdateIncludeNode(ByVal programFileName As String, ByVal gatherNode As TreeNode)
            gatherNode.Nodes.Clear()
            For Each includeInfo As IncludeInfo In MemberManager.GetIncludeInfoList(programFileName)
                AddIncludeNode(includeInfo, gatherNode)
            Next
        End Sub

        Private Sub UpdateFunctionNode(ByVal programFileName As String, ByVal gatherNode As TreeNode)
            gatherNode.Nodes.Clear()
            For Each functionInfo As FunctionInfo In MemberManager.GetFunctionInfoList(programFileName)
                AddFunctionNode(functionInfo, gatherNode)
            Next
        End Sub

        Private Sub UpdateVariableNode(ByVal programFileName As String, ByVal gatherNode As TreeNode)
            gatherNode.Nodes.Clear()
            For Each variableInfo As VariableInfo In MemberManager.GetVariableInfoList(programFileName)
                AddVariableNode(variableInfo, gatherNode)
            Next
        End Sub

        Private Function GetTreeNode(ByVal name As String, ByVal fromNode As TreeNode) As TreeNode
            Dim result As TreeNode
            If fromNode.Text = name Then
                result = fromNode
            Else
                result = Nothing
                For Each childNode As TreeNode In fromNode.Nodes
                    result = GetTreeNode(name, childNode)
                    If result IsNot Nothing Then
                        Exit For
                    End If
                Next
            End If
            Return result
        End Function

    End Class

End Namespace