'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ICobolEDEditor.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Interfaces.Editor                           --
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
Imports System.Drawing
Imports CobolEDCore.EventArgs
Imports CobolEDCore.Document
Imports CobolEDCore.Enums
Imports CobolEDCore.Interfaces.Analyzer

Namespace Interfaces.Editor
    Public Interface ICobolEDEditor

#Region "Events"

        Event CaretPositionChanged(ByVal sender As Object, ByVal e As CaretPositionChangedEventArgs)
        Event CaretPositionGoTo(ByVal sender As Object, ByVal e As CaretPositionGoToEventArgs)
        Event CaretStatusChanged(ByVal sender As Object, ByVal e As CaretStatusChangedEventArgs)
        Event MouseStopAtWord(ByVal sender As Object, ByVal e As MouseStopAtWordEventArgs)
        Event NeedUpdateMember(ByVal sender As Object, ByVal e As NeedUpdateMemberEventArgs)

#End Region

#Region "Properties"

        ReadOnly Property CaretPhysicalPosition() As Position
        ReadOnly Property CaretStatus() As CaretStatusEnum
        ReadOnly Property CanUndo() As Boolean
        ReadOnly Property CanRedo() As Boolean
        Property FontColor() As Dictionary(Of WordTypeEnum, Color)
        Property Document() As Document.Document
        Property CobolEDAnalyzer() As ICobolEDAnalyzer        

#End Region

#Region "Usercontrol Properties"

        Property Font() As Font
        Property Dock() As DockStyle
        Property Location() As Point

#End Region

#Region "About Caret"

        Sub CaretMoveTo(ByVal row As Integer, ByVal col As Integer, Optional ByVal sendEvent As Boolean = True)
        Function Focus() As Boolean

#End Region

#Region "About Selection"

        Sub SetSelection(ByVal selectionStart As Position, ByVal selectionEnd As Position)
        Sub SelectAll()
        Sub Copy()
        Sub Cut()
        Sub Paste()

#End Region

#Region "About BookMark"

        Sub SetBookMark(ByVal row As Integer, ByVal bookMark As Boolean)

#End Region

#Region "About Edit"

        Sub CommentOut()
        Sub CommentCancel()
        Sub EditText(ByVal text As String)
        Sub Redo()
        Sub Undo()
        Function DeleteText(ByVal length As Integer) As String

#End Region

#Region "Others"

        Sub Initialize(ByVal document As Document.Document, ByVal cobolEDAnalyzer As ICobolEDAnalyzer, ByVal fontColor As Dictionary(Of WordTypeEnum, Color))
        Sub InitializeCodeListView(ByVal codeCompletionListType As CodeCompletionListTypeEnum, ByVal keyWords As List(Of String), ByVal functionList As List(Of String), ByVal variableList As List(Of String))
        Sub Refresh()
        Sub ShowCommentTip(ByVal comment As String, ByVal position As Point, ByVal duration As Integer)
        Sub HideCommentTip()
        Sub SetContextMenuStrip(ByVal contextMenuStrip As ContextMenuStrip)
        Function Print(ByVal fromDocumentLine As Integer, ByVal graphics As Graphics, ByVal printRectangle As Rectangle) As Integer

#End Region

    End Interface
End Namespace
