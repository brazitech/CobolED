'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CobolEDEditor.vb                                        --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor                                           --
'--                                                                           --
'--  Project       :  CobolEDEditor                                           --
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

Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Interfaces.Editor
Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Infos.Editor
Imports CobolEDCore.Infos.Document
Imports CobolEDCore.EventArgs
Imports CobolEDCore.Document
Imports CobolEDCore.Enums
Imports CobolEDEditor.Caret
Imports CobolEDEditor.Views
Imports CobolEDEditor.Controls
Imports CobolEDEditor.Forms
Imports System.Drawing
Imports System.Windows.Forms

Public Class CobolEDEditor
    Implements ICobolEDEditor

    Private _controlManager As ControlManager
    Private _scrollBarControl As ScrollBarControl
    Private _textViewCaretControl As TextViewCaretControl
    Private _textViewEditControl As TextViewEditControl
    Private _textViewSelectionControl As TextViewSelectionControl
    Private _textViewUndoControl As TextViewUndoControl
    Private _bookMarkViewControl As BookMarkViewControl
    Private _rulerViewControl As RulerViewControl
    Private _codeCompletionFormControl As CodeCompletionFormControl

    Private WithEvents _textCaret As TextCaret
    Private WithEvents _codeCompletionForm As CodeCompletionForm

    Public Sub New()

        ' This call is required by the Windows Form Designer .
        InitializeComponent()

        ' Add the initialization after the InitializeComponent () call .
        'Caretの確立
        _textCaret = New TextCaret(Me._textView)
        _textView.TextCaret = _textCaret

        'CodeCompletionFormの確立
        _codeCompletionForm = New CodeCompletionForm(_textView)

        'Controlsの確立
        _controlManager = New ControlManager

        _scrollBarControl = New ScrollBarControl(_vScrollBar, _hScrollBar, _textView, _bookMarkView, _rulerView, _controlManager)
        _scrollBarControl.ReSetScrollBarRange()
        _controlManager.AddControl(ControlManager.SCROLLBAR, _scrollBarControl)

        _textViewCaretControl = New TextViewCaretControl(_textView, _vScrollBar, _hScrollBar, _codeCompletionForm, _controlManager)
        _controlManager.AddControl(ControlManager.TEXTVIEW_CARET, _textViewCaretControl)

        _textViewEditControl = New TextViewEditControl(_textView, _bookMarkView, _codeCompletionForm, _controlManager)
        _controlManager.AddControl(ControlManager.TEXTVIEW_EDIT, _textViewEditControl)

        _textViewSelectionControl = New TextViewSelectionControl(_textView, _vScrollBar, _hScrollBar, _controlManager)
        _controlManager.AddControl(ControlManager.TEXTVIEW_SELECTION, _textViewSelectionControl)

        _textViewUndoControl = New TextViewUndoControl(_textView, _bookMarkView, _controlManager)
        _controlManager.AddControl(ControlManager.TEXTVIEW_UNDO, _textViewUndoControl)

        _bookMarkViewControl = New BookMarkViewControl(_bookMarkView, _controlManager)
        _controlManager.AddControl(ControlManager.BOOKMARKVIEW, _bookMarkViewControl)

        _rulerViewControl = New RulerViewControl(_rulerView, _textView, _controlManager)
        _controlManager.AddControl(ControlManager.RULERVIEW, _rulerViewControl)

        _codeCompletionFormControl = New CodeCompletionFormControl(_textView, _codeCompletionForm, _controlManager)
        _controlManager.AddControl(ControlManager.CODECOMPLETIONFORM, _codeCompletionFormControl)
    End Sub

#Region "The procedures of events of myself"

    Private Sub CobolEDEditor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        If _codeCompletionForm.IsShown Then
            _codeCompletionFormControl.HideCodeCompletionForm()
        End If
    End Sub

    Private Sub CobolEDEditor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If _scrollBarControl IsNot Nothing Then
            _scrollBarControl.ReSetScrollBarRange()
        End If
    End Sub

    Private Sub _textCaret_CaretPositionChanged(ByVal sender As Object, ByVal e As CaretPositionChangedEventArgs) Handles _textCaret.CaretPositionChanged
        RaiseEvent CaretPositionChanged(Me, e)
    End Sub

    Private Sub _textCaret_CaretStatusChanged(ByVal sender As Object, ByVal e As CaretStatusChangedEventArgs) Handles _textCaret.CaretStatusChanged
        RaiseEvent CaretStatusChanged(Me, e)
    End Sub

    Private Sub _textViewDocument_DocumentChanged(ByVal sender As Object, ByVal e As DocumentChangedEventArgs)
        If NeedUpdate(e.EditActionInfo) Then
            RaiseEvent NeedUpdateMember(Me, New NeedUpdateMemberEventArgs(_textCaret.PhysicalPosition))
        End If

    End Sub

    Private Sub _textView_MouseStop(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _textView.MouseStop
        Dim currentWord As WordInfo
        Dim currentPosition As Position

        If _textView.CobolEDLex IsNot Nothing AndAlso Document IsNot Nothing AndAlso _textViewCaretControl IsNot Nothing Then
            currentPosition = _textViewCaretControl.GetCaretPhysicalPositionFromPoint(e.Location)
            currentWord = _textView.CobolEDLex.GetWordFromIndex(Document.DocumentLineString(currentPosition.Row), currentPosition.Col)
            RaiseEvent MouseStopAtWord(Me, New MouseStopAtWordEventArgs(currentWord, e.Location))
        End If
    End Sub

    Private Sub _textView_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _textView.MouseUp
        Dim caretPositionInfo As CaretPositionInfo
        Dim position As Position
        position = _textViewCaretControl.GetCaretPhysicalPositionFromPoint(e.Location)
        caretPositionInfo = New CaretPositionInfo(position.Row, position.Col, Document.DocumentFileName)
        RaiseEvent CaretPositionGoTo(Me, New CaretPositionGoToEventArgs(caretPositionInfo))
    End Sub

    Private Function NeedUpdate(ByVal e As EditActionInfo) As Boolean
        Dim result As Boolean
        If (e.Text.IndexOf(Document.EOL) >= 0 OrElse e.OldText.IndexOf(Document.EOL) >= 0) AndAlso _
           (Document.DocumentLineString(e.Row).Trim.Length > 0) Then
            result = True
        Else
            result = False
        End If
        Return result
    End Function

#End Region

#Region "The implements of Interface ICobolEDEditor"

#Region "Events"

    Public Event CaretPositionChanged(ByVal sender As Object, ByVal e As CaretPositionChangedEventArgs) Implements ICobolEDEditor.CaretPositionChanged
    Public Event CaretPositionGoTo(ByVal sender As Object, ByVal e As CaretPositionGoToEventArgs) Implements ICobolEDEditor.CaretPositionGoTo
    Public Event CaretStatusChanged(ByVal sender As Object, ByVal e As CaretStatusChangedEventArgs) Implements ICobolEDEditor.CaretStatusChanged
    Public Event MouseStopAtWord(ByVal sender As Object, ByVal e As MouseStopAtWordEventArgs) Implements ICobolEDEditor.MouseStopAtWord
    Public Event NeedUpdateMember(ByVal sender As Object, ByVal e As NeedUpdateMemberEventArgs) Implements ICobolEDEditor.NeedUpdateMember


#End Region

#Region "Properties"

    Public ReadOnly Property CaretPhysicalPosition() As Position Implements ICobolEDEditor.CaretPhysicalPosition
        Get
            Return _textView.TextCaret.PhysicalPosition
        End Get
    End Property

    Public ReadOnly Property CaretStatus() As CaretStatusEnum Implements ICobolEDEditor.CaretStatus
        Get
            Return _textView.TextCaret.Status
        End Get
    End Property

    Public ReadOnly Property CanUndo() As Boolean Implements ICobolEDEditor.CanUndo
        Get
            Return _textViewUndoControl.CanUndo
        End Get
    End Property

    Public ReadOnly Property CanRedo() As Boolean Implements ICobolEDEditor.CanRedo
        Get
            Return _textViewUndoControl.CanRedo
        End Get
    End Property

    Public Property Document() As Document Implements ICobolEDEditor.Document
        Get
            Return _textView.Document
        End Get
        Set(ByVal value As Document)
            _textView.Document = value
            _bookMarkView.Document = value
        End Set
    End Property

    Public Property CobolEDAnalyzer() As ICobolEDAnalyzer Implements ICobolEDEditor.CobolEDAnalyzer
        Get
            Return _textView.CobolEDAnalyzer
        End Get
        Set(ByVal value As ICobolEDAnalyzer)
            _textView.CobolEDAnalyzer = value
        End Set
    End Property

    Public Property FontColor() As Dictionary(Of WordTypeEnum, Color) Implements ICobolEDEditor.FontColor
        Get
            Return _textView.FontColor
        End Get
        Set(ByVal value As Dictionary(Of WordTypeEnum, Color))
            _textView.FontColor = value
        End Set
    End Property


#End Region

#Region "Usercontrol Properties"

    Public Shadows Property Font() As Font Implements ICobolEDEditor.Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
        End Set
    End Property

    Public Shadows Property Dock() As DockStyle Implements ICobolEDEditor.Dock
        Get
            Return MyBase.Dock
        End Get
        Set(ByVal value As DockStyle)
            MyBase.Dock = value
        End Set
    End Property

    Public Shadows Property Location() As Point Implements ICobolEDEditor.Location
        Get
            Return MyBase.Location
        End Get
        Set(ByVal value As Point)
            MyBase.Location = value
        End Set
    End Property

#End Region

#Region "About Selection"

    Public Sub SetSelection(ByVal selectionStart As Position, ByVal selectionEnd As Position) Implements ICobolEDEditor.SetSelection
        _textViewSelectionControl.SetSelection(selectionStart, selectionEnd)
    End Sub

    Public Sub SelectAll() Implements ICobolEDEditor.SelectAll
        _textViewSelectionControl.SelectAll()
    End Sub

    Public Sub Copy() Implements ICobolEDEditor.Copy
        _textViewSelectionControl.Copy()
    End Sub

    Public Sub Cut() Implements ICobolEDEditor.Cut
        _textViewSelectionControl.Cut()
    End Sub

    Public Sub Paste() Implements ICobolEDEditor.Paste
        _textViewSelectionControl.Paste()
    End Sub

#End Region

#Region "About Caret"

    Public Sub CaretMoveTo(ByVal row As Integer, ByVal col As Integer, Optional ByVal sendEvent As Boolean = True) Implements ICobolEDEditor.CaretMoveTo
        Dim caretPositionInfo As CaretPositionInfo

        _textViewCaretControl.CaretMoveTo(row, col)
        If sendEvent Then
            caretPositionInfo = New CaretPositionInfo(CaretPhysicalPosition.Row, CaretPhysicalPosition.Col, Document.DocumentFileName)
            RaiseEvent CaretPositionGoTo(Me, New CaretPositionGoToEventArgs(caretPositionInfo))
        Else
        End If

    End Sub

    Public Shadows Function Focus() As Boolean Implements CobolEDCore.Interfaces.Editor.ICobolEDEditor.Focus
        Return _textView.Focus()
    End Function

#End Region

#Region "About BookMark"

    Public Sub SetBookMark(ByVal row As Integer, ByVal bookMark As Boolean) Implements ICobolEDEditor.SetBookMark
        _bookMarkViewControl.SetBookMark(row, bookMark)
    End Sub

#End Region

#Region "About Edit"

    Public Sub CommentOut() Implements ICobolEDEditor.CommentOut
        _textViewEditControl.CommentOut()
    End Sub

    Public Sub CommentCancel() Implements ICobolEDEditor.CommentCancel
        _textViewEditControl.CommentCancel()
    End Sub

    Public Sub EditText(ByVal text As String) Implements ICobolEDEditor.EditText
        _textViewEditControl.EditText(text)
    End Sub

    Public Sub Undo() Implements ICobolEDEditor.Undo
        _textViewUndoControl.Undo()
    End Sub

    Public Sub Redo() Implements ICobolEDEditor.Redo
        _textViewUndoControl.Redo()
    End Sub

    Public Function DeleteText(ByVal length As Integer) As String Implements ICobolEDEditor.DeleteText
        Return _textViewEditControl.DeleteText(length)
    End Function

#End Region

#Region "Others"


    Public Sub Initialize(ByVal document As Document, ByVal cobolEDAnalyzer As ICobolEDAnalyzer, ByVal fontColor As Dictionary(Of WordTypeEnum, Color)) Implements ICobolEDEditor.Initialize
        If _textView.Document IsNot Nothing Then
            RemoveHandler _textView.Document.DocumentChanged, AddressOf _textViewDocument_DocumentChanged
        End If
        AddHandler document.DocumentChanged, AddressOf _textViewDocument_DocumentChanged
        _textView.Initialize(document, cobolEDAnalyzer, _textCaret, fontColor)
        _bookMarkView.Initialize(document)
        _textCaret.PhysicalPosition = New Position(0, 0)
        _scrollBarControl.ReSetScrollBarRange()

        If cobolEDAnalyzer IsNot Nothing AndAlso cobolEDAnalyzer.CobolEDLex IsNot Nothing Then
            _codeCompletionForm.InitializeCodeListView(CobolEDCore.Enums.CodeCompletionListTypeEnum.All, cobolEDAnalyzer.CobolEDLex.KeyWords, Nothing, Nothing)
        Else
            _codeCompletionForm.InitializeCodeListView(CobolEDCore.Enums.CodeCompletionListTypeEnum.All, Nothing, Nothing, Nothing)
        End If
    End Sub

    Private Delegate Sub InitializeCodeListViewDelegate(ByVal codeCompletionListType As CodeCompletionListTypeEnum, _
                                      ByVal keyWords As List(Of String), _
                                      ByVal functionList As List(Of String), _
                                      ByVal variableList As List(Of String))

    Public Sub InitializeCodeListView(ByVal codeCompletionListType As CodeCompletionListTypeEnum, _
                                      ByVal keyWords As List(Of String), _
                                      ByVal functionList As List(Of String), _
                                      ByVal variableList As List(Of String)) Implements ICobolEDEditor.InitializeCodeListView
        Dim params() As Object = {codeCompletionListType, keyWords, functionList, variableList}
        Dim initializeSub As New InitializeCodeListViewDelegate(AddressOf _codeCompletionForm.InitializeCodeListView)
        Me.BeginInvoke(initializeSub, params)
    End Sub

    Public Shadows Sub Refresh() Implements ICobolEDEditor.Refresh
        _textView.Invalidate()
        _bookMarkView.Invalidate()
        _rulerView.Invalidate()
    End Sub

    Public Sub ShowCommentTip(ByVal comment As String, ByVal position As Point, ByVal duration As Integer) Implements ICobolEDEditor.ShowCommentTip
        _textView.ShowCommentTip(comment, position, duration)
    End Sub

    Public Sub HideCommentTip() Implements ICobolEDEditor.HideCommentTip
        _textView.HideCommentTip()
    End Sub

    Public Sub SetContextMenuStrip(ByVal contextMenuStrip As ContextMenuStrip) Implements ICobolEDEditor.SetContextMenuStrip
        _textView.ContextMenuStrip = contextMenuStrip
    End Sub

    Public Function Print(ByVal fromDocumentLine As Integer, ByVal graphics As Graphics, ByVal printRectangle As Rectangle) As Integer Implements ICobolEDEditor.Print
        Return _textView.Print(fromDocumentLine, graphics, printRectangle)
    End Function

#End Region

#End Region



End Class
