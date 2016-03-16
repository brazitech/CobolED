'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  TextViewSelectionControl.vb                             --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Controls                                  --
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

Option Strict On
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports CobolEDCore.Document
Imports CobolEDEditor.Caret
Imports CobolEDEditor.Views

Namespace Controls

    Public Class TextViewSelectionControl
        Inherits ControlBase

        Private _textView As TextView
        Private _vScrollBar As VScrollBar
        Private _hScrollBar As HScrollBar

        Private _isSelecting As Boolean
        Private _oldMousePhysicalPosition As Position
        Private WithEvents _timer As Timer
        Private _hScrollBarMoveStep As Integer
        Private _vScrollBarMoveStep As Integer

        Public Sub New(ByVal textView As TextView, _
                       ByVal vScrollBar As VScrollBar, _
                       ByVal hScrollBar As HScrollBar, _
                       ByVal controlManager As ControlManager)
            MyBase.New(controlManager)
            _textView = textView
            _vScrollBar = vScrollBar
            _hScrollBar = hScrollBar
            _isSelecting = False
            _timer = New Timer()
            _timer.Interval = 50
            _timer.Enabled = False
            _hScrollBarMoveStep = 0
            _vScrollBarMoveStep = 0
            Me.Enable = True
        End Sub

        Public Sub PaintChangedSelectionBlock(ByVal oldCaretPosition As Position, ByVal newCaretPosition As Position)
            Dim caretPositionFrom As Position
            Dim caretPositionTo As Position

            Select Case newCaretPosition.CompareTo(oldCaretPosition)
                Case 0
                    Return
                Case 1
                    caretPositionFrom = oldCaretPosition
                    caretPositionTo = newCaretPosition
                Case -1
                    caretPositionFrom = newCaretPosition
                    caretPositionTo = oldCaretPosition
            End Select

            If caretPositionFrom.Row = caretPositionTo.Row Then
                _textView.RepaintDocumentLine(caretPositionFrom.Row, caretPositionFrom.Col, caretPositionTo.Col - caretPositionFrom.Col)
            Else
                _textView.RepaintDocumentLine(caretPositionFrom.Row, caretPositionFrom.Col)
                For index As Integer = caretPositionFrom.Row + 1 To caretPositionTo.Row - 1
                    _textView.RepaintDocumentLine(index, False)
                Next
                _textView.RepaintDocumentLine(caretPositionTo.Row, 0, caretPositionTo.Col)
            End If
        End Sub

        Public Sub ClearSelection(ByVal caretPhysicalPosition As Position)
            Dim selectionStartRow, selectionEndRow As Integer

            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                If Document.Selection.Selected Then
                    selectionStartRow = Document.Selection.Start.Row
                    selectionEndRow = Document.Selection.End.Row
                    Document.Selection.Clear(caretPhysicalPosition)

                    TextCaret.Hide()
                    For index As Integer = selectionStartRow To selectionEndRow
                        _textView.RepaintDocumentLine(index, False)
                    Next
                    TextCaret.Show()
                Else
                    Document.Selection.Clear(caretPhysicalPosition)
                End If
            Else
            End If
        End Sub

        Public Sub SetSelection(ByVal selectionStart As Position, ByVal selectionEnd As Position)
            Dim textViewCaretControl As TextViewCaretControl

            textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)

            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso textViewCaretControl IsNot Nothing Then
                TextCaret.Hide()
                ClearSelection(selectionEnd)
                textViewCaretControl.CaretMoveTo(selectionEnd.Row, selectionEnd.Col)

                Document.Selection.Start = selectionStart

                For index As Integer = selectionStart.Row To selectionEnd.Row
                    TextView.RepaintDocumentLine(index, False)
                Next
                TextCaret.Show()
            End If


        End Sub

        Public Sub Copy()
            Dim DataObject As New DataObject
            If Document IsNot Nothing AndAlso Document.Selection.Selected Then
                DataObject.SetData(DataFormats.Text, Document.Selection.GetSelectedString())
                Clipboard.SetDataObject(DataObject)
            Else
            End If
        End Sub

        Public Sub Paste()
            Dim textViewEditControl As TextViewEditControl
            Dim dataObject As DataObject
            Dim insertStr As String

            dataObject = DirectCast(Clipboard.GetDataObject(), DataObject)
            textViewEditControl = DirectCast(Control(ControlManager.TEXTVIEW_EDIT), TextViewEditControl)

            If dataObject.GetDataPresent(System.Windows.Forms.DataFormats.Text) AndAlso textViewEditControl IsNot Nothing Then
                insertStr = DirectCast(dataObject.GetData(DataFormats.Text), String)
                textViewEditControl.EditText(insertStr)
            End If

        End Sub

        Public Sub Cut()
            Dim textViewEditControl As TextViewEditControl
            textViewEditControl = DirectCast(Control(ControlManager.TEXTVIEW_EDIT), TextViewEditControl)

            If Document.Selection.Selected AndAlso textViewEditControl IsNot Nothing Then
                Copy()
                textViewEditControl.DeleteText(1)
            Else
            End If
        End Sub

        Public Sub SelectAll()
            Dim documentEndRow As Integer
            Dim documentEndCol As Integer

            documentEndRow = Document.DocumentLinesCount - 1
            documentEndCol = Document.DocumentLineString(documentEndRow).Length

            SetSelection(New Position(0, 0), New Position(documentEndRow, documentEndCol))
        End Sub

        Public Sub AutoSelect(ByVal row As Integer, ByVal col As Integer)
            Dim selectionStartCol As Integer
            Dim selectionEndCol As Integer
            Dim currentLine As String

            If row < 0 OrElse row > Document.DocumentLinesCount - 1 Then
                Return
            End If
            If col < 0 OrElse col > Document.DocumentLineString(row).Length Then
                Return
            End If
            If col = Document.DocumentLineString(row).Length Then
                col = Document.DocumentLineString(row).Length - 1
            End If

            currentLine = Document.DocumentLineString(row)
            selectionStartCol = currentLine.LastIndexOfAny(Common.CommonConst.WORD_SEPARATOR, col) + 1
            selectionEndCol = currentLine.IndexOfAny(Common.CommonConst.WORD_SEPARATOR, col)
            If selectionStartCol < 0 Then
                selectionStartCol = 0
            End If
            If selectionEndCol < 0 Then
                selectionEndCol = Document.DocumentLineString(row).Length
            End If
            SetSelection(New Position(row, selectionStartCol), New Position(row, selectionEndCol))
        End Sub

        Protected Overrides Sub AddAllHandler()
            AddHandler _textView.KeyDown, AddressOf OnKeyDown
            AddHandler _textView.MouseDown, AddressOf OnMouseDown
            AddHandler _textView.MouseUp, AddressOf OnMouseUp
            AddHandler _textView.MouseMove, AddressOf OnMouseMove
            AddHandler _textView.DoubleClick, AddressOf OnDoubleClick
        End Sub

        Protected Overrides Sub RemoveAllHandler()
            RemoveHandler _textView.KeyDown, AddressOf OnKeyDown
            RemoveHandler _textView.MouseDown, AddressOf OnMouseDown
            RemoveHandler _textView.MouseUp, AddressOf OnMouseUp
            RemoveHandler _textView.MouseMove, AddressOf OnMouseMove
        End Sub

        Private ReadOnly Property TextView() As TextView
            Get
                Return _textView
            End Get            
        End Property

        Private ReadOnly Property Document() As Document
            Get
                Return _textView.Document
            End Get
        End Property

        Private ReadOnly Property TextCaret() As TextCaret
            Get
                Return _textView.TextCaret
            End Get
        End Property

        Private Sub OnKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                Select Case e.KeyData
                    Case Keys.Shift Or Keys.Left
                        OnShiftLeftKeyDown(sender, e)
                    Case Keys.Shift Or Keys.Right
                        OnShiftRightKeyDown(sender, e)
                    Case Keys.Shift Or Keys.Up
                        OnShiftUpKeyDown(sender, e)
                    Case Keys.Shift Or Keys.Down
                        OnShiftDownKeyDown(sender, e)
                    Case Keys.Shift Or Keys.Home
                        OnShiftHomeKeyDown(sender, e)
                    Case Keys.Shift Or Keys.End
                        OnShiftEndKeyDown(sender, e)
                    Case Keys.Shift Or Keys.PageUp
                        OnShiftPageUpKeyDown(sender, e)
                    Case Keys.Shift Or Keys.PageDown
                        OnShiftPageDownKeyDown(sender, e)
                    Case Keys.Control Or Keys.C
                        OnCtrlCKeyDown(sender, e)
                    Case Keys.Control Or Keys.V
                        OnCtrlVKeyDown(sender, e)
                    Case Keys.Control Or Keys.X
                        OnCtrlXKeyDown(sender, e)
                    Case Keys.Control Or Keys.A
                        OnCtrlAKeyDown(sender, e)
                    Case Else
                End Select
            End If
        End Sub

        Private Sub OnShiftLeftKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim oldCaretPosition As Position

            If e.KeyData = (Keys.Shift Or Keys.Left) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                oldCaretPosition = TextCaret.PhysicalPosition
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretLeftMove()
                If TextCaret.PhysicalPosition.CompareTo(oldCaretPosition) <> 0 Then
                    Document.Selection.End = TextCaret.PhysicalPosition
                    TextCaret.Hide()
                    PaintChangedSelectionBlock(oldCaretPosition, TextCaret.PhysicalPosition)
                    TextCaret.Show()
                End If
            End If
        End Sub

        Private Sub OnShiftRightKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim oldCaretPosition As Position

            If e.KeyData = (Keys.Shift Or Keys.Right) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                oldCaretPosition = TextCaret.PhysicalPosition
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretRightMove()
                If TextCaret.PhysicalPosition.CompareTo(oldCaretPosition) <> 0 Then
                    Document.Selection.End = TextCaret.PhysicalPosition
                    TextCaret.Hide()
                    PaintChangedSelectionBlock(oldCaretPosition, TextCaret.PhysicalPosition)
                    TextCaret.Show()
                End If
            End If
        End Sub

        Private Sub OnShiftUpKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim oldCaretPosition As Position

            If e.KeyData = (Keys.Shift Or Keys.Up) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                oldCaretPosition = TextCaret.PhysicalPosition
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretUpMove()
                If TextCaret.PhysicalPosition.CompareTo(oldCaretPosition) <> 0 Then
                    Document.Selection.End = TextCaret.PhysicalPosition
                    TextCaret.Hide()
                    PaintChangedSelectionBlock(oldCaretPosition, TextCaret.PhysicalPosition)
                    TextCaret.Show()
                End If
            End If

        End Sub

        Private Sub OnShiftDownKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim oldCaretPosition As Position

            If e.KeyData = (Keys.Shift Or Keys.Down) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                oldCaretPosition = TextCaret.PhysicalPosition
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretDownMove()
                If TextCaret.PhysicalPosition.CompareTo(oldCaretPosition) <> 0 Then
                    Document.Selection.End = TextCaret.PhysicalPosition
                    TextCaret.Hide()
                    PaintChangedSelectionBlock(oldCaretPosition, TextCaret.PhysicalPosition)
                    TextCaret.Show()
                End If
            End If

        End Sub

        Private Sub OnShiftHomeKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim oldCaretPosition As Position

            If e.KeyData = (Keys.Shift Or Keys.Home) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                oldCaretPosition = TextCaret.PhysicalPosition
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretHomeMove()
                If TextCaret.PhysicalPosition.CompareTo(oldCaretPosition) <> 0 Then
                    Document.Selection.End = TextCaret.PhysicalPosition
                    TextCaret.Hide()
                    PaintChangedSelectionBlock(oldCaretPosition, TextCaret.PhysicalPosition)
                    TextCaret.Show()
                End If
            End If
        End Sub

        Private Sub OnShiftEndKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim oldCaretPosition As Position

            If e.KeyData = (Keys.Shift Or Keys.End) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                oldCaretPosition = TextCaret.PhysicalPosition
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretEndMove()
                If TextCaret.PhysicalPosition.CompareTo(oldCaretPosition) <> 0 Then
                    Document.Selection.End = TextCaret.PhysicalPosition
                    TextCaret.Hide()
                    PaintChangedSelectionBlock(oldCaretPosition, TextCaret.PhysicalPosition)
                    TextCaret.Show()
                End If
            End If
        End Sub

        Private Sub OnShiftPageUpKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim oldCaretPosition As Position

            If e.KeyData = (Keys.Shift Or Keys.PageUp) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                oldCaretPosition = TextCaret.PhysicalPosition
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretPageUpMove()
                If TextCaret.PhysicalPosition.CompareTo(oldCaretPosition) <> 0 Then
                    Document.Selection.End = TextCaret.PhysicalPosition
                    TextCaret.Hide()
                    PaintChangedSelectionBlock(oldCaretPosition, TextCaret.PhysicalPosition)
                    TextCaret.Show()
                End If
            End If

        End Sub

        Private Sub OnShiftPageDownKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim oldCaretPosition As Position

            If e.KeyData = (Keys.Shift Or Keys.PageDown) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                oldCaretPosition = TextCaret.PhysicalPosition
                textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)
                If textViewCaretControl IsNot Nothing Then textViewCaretControl.CaretPageDownMove()
                If TextCaret.PhysicalPosition.CompareTo(oldCaretPosition) <> 0 Then
                    Document.Selection.End = TextCaret.PhysicalPosition
                    TextCaret.Hide()
                    PaintChangedSelectionBlock(oldCaretPosition, TextCaret.PhysicalPosition)
                    TextCaret.Show()
                End If
            End If

        End Sub

        Private Sub OnCtrlCKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = (Keys.Control Or Keys.C) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                Copy()
            End If
        End Sub

        Private Sub OnCtrlVKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = (Keys.Control Or Keys.V) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                Paste()
            End If
        End Sub

        Private Sub OnCtrlXKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = (Keys.Control Or Keys.X) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                Cut()
            End If
        End Sub

        Private Sub OnCtrlAKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = (Keys.Control Or Keys.A) AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                SelectAll()
            End If
        End Sub

        Private Sub OnMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim newPhysicalPosition As Position

            textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)

            If e.Button = MouseButtons.Left AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso textViewCaretControl IsNot Nothing Then
                _textView.Focus()
                newPhysicalPosition = textViewCaretControl.GetCaretPhysicalPositionFromPoint(New Point(e.X, e.Y))
                ClearSelection(newPhysicalPosition)
                _isSelecting = True
                _oldMousePhysicalPosition = newPhysicalPosition
                TextCaret.Hide()
            ElseIf e.Button = MouseButtons.Right AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso textViewCaretControl IsNot Nothing Then
                _textView.Focus()
                newPhysicalPosition = textViewCaretControl.GetCaretPhysicalPositionFromPoint(New Point(e.X, e.Y))
                If newPhysicalPosition.CompareTo(Document.Selection.Start) < 0 OrElse _
                   newPhysicalPosition.CompareTo(Document.Selection.End) > 0 Then
                    ClearSelection(newPhysicalPosition)
                Else
                End If
            Else
            End If
        End Sub

        Private Sub OnMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim newPhysicalPosition As Position

            textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)

            If _isSelecting AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso textViewCaretControl IsNot Nothing Then
                newPhysicalPosition = textViewCaretControl.GetCaretPhysicalPositionFromPoint(New Point(e.X, e.Y))
                Document.Selection.End = newPhysicalPosition
                PaintChangedSelectionBlock(_oldMousePhysicalPosition, newPhysicalPosition)
                _oldMousePhysicalPosition = newPhysicalPosition

                If e.Y > _textView.Height Then
                    _vScrollBarMoveStep = 1
                    _hScrollBarMoveStep = 0
                    _timer.Enabled = True
                ElseIf e.Y < 0 Then
                    _vScrollBarMoveStep = -1
                    _hScrollBarMoveStep = 0
                    _timer.Enabled = True
                ElseIf e.X > _textView.Width Then
                    _vScrollBarMoveStep = 0
                    _hScrollBarMoveStep = 1
                    _timer.Enabled = True
                ElseIf e.X < 0 Then
                    _vScrollBarMoveStep = 0
                    _hScrollBarMoveStep = -1
                    _timer.Enabled = True
                Else
                    _timer.Enabled = False
                    _hScrollBarMoveStep = 0
                    _vScrollBarMoveStep = 0
                End If
            End If


        End Sub

        Private Sub OnMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            If e.Button = MouseButtons.Left AndAlso Document IsNot Nothing AndAlso TextCaret IsNot Nothing Then
                _isSelecting = False
                TextCaret.Show()
                _timer.Enabled = False
                _hScrollBarMoveStep = 0
                _vScrollBarMoveStep = 0
            Else
            End If
        End Sub

        Private Sub OnDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim textViewCaretControl As TextViewCaretControl
            Dim currentPhysicalPosition As Position
            Dim currentMousePosition As Point
            textViewCaretControl = DirectCast(Control(ControlManager.TEXTVIEW_CARET), TextViewCaretControl)

            If Document IsNot Nothing AndAlso TextCaret IsNot Nothing AndAlso textViewCaretControl IsNot Nothing Then
                _textView.Focus()
                currentMousePosition = _textView.PointToClient(Windows.Forms.Control.MousePosition)
                currentPhysicalPosition = textViewCaretControl.GetCaretPhysicalPositionFromPoint(currentMousePosition)
                AutoSelect(currentPhysicalPosition.Row, currentPhysicalPosition.Col)
            Else
            End If
        End Sub

        Private Sub OnTimer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _timer.Tick
            If _vScrollBarMoveStep <> 0 AndAlso _
               _vScrollBar.Value + _vScrollBarMoveStep >= _vScrollBar.Minimum AndAlso _
               _vScrollBar.Value + _vScrollBarMoveStep <= _vScrollBar.Maximum - _vScrollBar.LargeChange + 1 Then
                _vScrollBar.Value += _vScrollBarMoveStep
            End If
            If _hScrollBarMoveStep <> 0 AndAlso _
               _hScrollBar.Value + _hScrollBarMoveStep >= _hScrollBar.Minimum AndAlso _
               _hScrollBar.Value + _hScrollBarMoveStep <= _hScrollBar.Maximum - _hScrollBar.LargeChange + 1 Then
                _hScrollBar.Value += _hScrollBarMoveStep
            End If
        End Sub

    End Class

End Namespace