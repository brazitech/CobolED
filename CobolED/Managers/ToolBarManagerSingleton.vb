'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ToolBarManagerSingleton.vb                              --
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
Imports Common

Namespace Managers
    Public Class ToolBarManagerSingleton

        Private _toolBarButtonProcessList As Dictionary(Of ToolStripButton, IMenuItemProcess)
        Private WithEvents _interception As Timer
        Private Shared _toolBarManager As ToolBarManagerSingleton

        Private Sub New()
            _toolBarButtonProcessList = New Dictionary(Of ToolStripButton, IMenuItemProcess)
            _interception = New Timer()
            _interception.Interval = 500
            _interception.Enabled = True
        End Sub

        Public Shared ReadOnly Property ToolBarManager() As ToolBarManagerSingleton
            Get
                If _toolBarManager Is Nothing Then
                    _toolBarManager = New ToolBarManagerSingleton
                End If
                Return _toolBarManager
            End Get
        End Property

        Public Sub Initialize(ByVal cobolEDMainForm As CobolEDMainForm)

            AddToolBarButtonProcess(cobolEDMainForm._toolBarNewProject, New File.OnNewProject(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarOpenProject, New File.OnOpenProject(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarOpenFile, New File.OnOpenFile(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarSave, New File.OnSave(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarSaveAll, New File.OnSaveAll(cobolEDMainForm))

            AddToolBarButtonProcess(cobolEDMainForm._toolBarUndo, New Edit.OnUndo(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarRedo, New Edit.OnRedo(cobolEDMainForm))

            AddToolBarButtonProcess(cobolEDMainForm._toolBarCut, New Edit.OnCut(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarCopy, New Edit.OnCopy(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarPaste, New Edit.OnPaste(cobolEDMainForm))

            AddToolBarButtonProcess(cobolEDMainForm._toolBarCommentOut, New Edit.OnCommentOut(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarCommentCancel, New Edit.OnCommentCancel(cobolEDMainForm))

            AddToolBarButtonProcess(cobolEDMainForm._toolBarFind, New Search.OnFind(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarFindPrev, New Search.OnPrevFind(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarFindNext, New Search.OnNextFind(cobolEDMainForm))

            AddToolBarButtonProcess(cobolEDMainForm._toolBarUnGoTo, New Search.OnUnGoTo(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarReGoTo, New Search.OnReGoTo(cobolEDMainForm))

            AddToolBarButtonProcess(cobolEDMainForm._toolBarSetBookMark, New Search.OnSetBookMark(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarPrevBookMark, New Search.OnPrevBookMark(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarNextBookMark, New Search.OnNextBookMark(cobolEDMainForm))
            AddToolBarButtonProcess(cobolEDMainForm._toolBarClearBookMark, New Search.OnClearBookMark(cobolEDMainForm))

        End Sub

        Public Sub AddToolBarButtonProcess(ByVal toolBarButton As ToolStripButton, ByVal menuItemProcess As IMenuItemProcess)
            If Not _toolBarButtonProcessList.ContainsKey(toolBarButton) Then
                _toolBarButtonProcessList.Add(toolBarButton, menuItemProcess)
                AddHandler toolBarButton.Click, AddressOf OnToolBarButtonClick
            Else
            End If
        End Sub

        Private Sub OnToolBarButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
            If _toolBarButtonProcessList.ContainsKey(sender) AndAlso _toolBarButtonProcessList(sender) IsNot Nothing Then
                If _toolBarButtonProcessList(sender).IsEnable Then
                    DirectCast(sender, ToolStripButton).Enabled = True
                    Try
                        _toolBarButtonProcessList(sender).Execute()
                    Catch myex As MyException
                        Common.Message.ShowMessage(myex)
                    Catch ex As Exception
                        Common.Message.ShowMessage(ex)
                    End Try
                Else
                    DirectCast(sender, ToolStripButton).Enabled = False
                End If
            End If
        End Sub

        Private Sub OnInterceptionTick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _interception.Tick
            For Each toolBarButton As ToolStripButton In _toolBarButtonProcessList.Keys
                If _toolBarButtonProcessList(toolBarButton) IsNot Nothing Then
                    toolBarButton.Enabled = _toolBarButtonProcessList(toolBarButton).IsEnable
                Else
                End If
            Next
        End Sub

    End Class
End Namespace

