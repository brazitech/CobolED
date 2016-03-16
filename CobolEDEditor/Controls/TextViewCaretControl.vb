'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  TextViewCaretControl.vb                                 --
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

Imports CobolEDCore
Imports System.Windows.Forms
Imports System.Drawing
Imports CobolEDEditor.Caret
Imports CobolEDEditor.Views
Imports CobolEDCore.Enums
Imports CobolEDEditor.Forms

Namespace Controls
    Public Class TextViewCaretControl
        Inherits ControlBase

        Private _textView As TextView
        Private _vScrollbar As VScrollBar
        Private _hScrollbar As HScrollBar
        Private _codeCompletionForm As CodeCompletionForm
        Private _cacheCol As Integer
        Private _mouseDownPosition As Document.Position


        Public Sub New(ByVal textView As TextView, _
                       ByVal vScrollBar As VScrollBar, _
                       ByVal hScrollBar As HScrollBar, _
                       ByVal codeCompletionForm As CodeCompletionForm, _
                       ByVal controlManager As ControlManager)

            MyBase.New(controlManager)
            _textView = textView
            _vScrollbar = vScrollBar
            _hScrollbar = hScrollBar
            _codeCompletionForm = codeCompletionForm
            _cacheCol = 0
            _mouseDownPosition = Nothing
            Me.Enable = True
        End Sub

        Public Sub MoveTextViewToShowCaret()

            Dim newVScrollBarValue As Integer = _vScrollbar.Value
            Dim newHScrollBarValue As Integer = _hScrollbar.Value

            If TextCaret IsNot Nothing Then

                If TextCaret.VisualPosition.X <= 0 Then
                    newHScrollBarValue += CInt(TextCaret.VisualPosition.X / _textView.Font_Width)
                ElseIf TextCaret.VisualPosition.X >= _textView.Width Then
                    newHScrollBarValue += CInt((TextCaret.VisualPosition.X - _textView.Width) / _textView.Font_Width) + 1
                End If


                If TextCaret.VisualPosition.Y <= 0 Then
                    newVScrollBarValue += CInt(TextCaret.VisualPosition.Y / _textView.Font_Height)
                ElseIf TextCaret.VisualPosition.Y >= _textView.Height - _textView.Font_Height Then
                    newVScrollBarValue += CInt((TextCaret.VisualPosition.Y - _textView.Height) / _textView.Font_Height) + 1
                End If


                If newVScrollBarValue <> _vScrollbar.Value Then
                    _vScrollbar.Value = newVScrollBarValue
                End If

                If newHScrollBarValue <> _hScrollbar.Value Then
                    _hScrollbar.Value = newHScrollBarValue
                End If
            Else
            End If

        End Sub

        Public Sub CaretLeftMove()
            Dim newPhysicalPosition As Document.Position

            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                newPhysicalPosition = TextCaret.PhysicalPosition
                newPhysicalPosition.Col -= 1

                If newPhysicalPosition.Col < 0 Then
                    If newPhysicalPosition.Row > 0 Then
                        newPhysicalPosition.Row -= 1
                        newPhysicalPosition.Col = Document.DocumentLineString(newPhysicalPosition.Row).Length
                    Else
                        newPhysicalPosition.Col = 0
                    End If
                Else
                End If

                _cacheCol = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(newPhysicalPosition.Row).Substring(0, newPhysicalPosition.Col))

                TextCaret.PhysicalPosition = newPhysicalPosition
                MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CaretRightMove()
            Dim newPhysicalPosition As Document.Position

            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                newPhysicalPosition = TextCaret.PhysicalPosition
                newPhysicalPosition.Col += 1

                If newPhysicalPosition.Col > Document.DocumentLineString(newPhysicalPosition.Row).Length Then
                    If newPhysicalPosition.Row < Document.DocumentLinesCount - 1 Then
                        newPhysicalPosition.Row += 1
                        newPhysicalPosition.Col = 0
                    Else
                        newPhysicalPosition.Col = Document.DocumentLineString(newPhysicalPosition.Row).Length
                    End If
                End If

                _cacheCol = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(newPhysicalPosition.Row).Substring(0, newPhysicalPosition.Col))
                TextCaret.PhysicalPosition = GetAVailableCaretPhysicalPosition(newPhysicalPosition)
                MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CaretUpMove()
            Dim newPhysicalPosition As Document.Position

            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                newPhysicalPosition = TextCaret.PhysicalPosition
                newPhysicalPosition.Row -= 1

                If newPhysicalPosition.Row < 0 Then
                    newPhysicalPosition.Row = 0
                Else
                End If

                newPhysicalPosition.Col = Common.StringTransaction.GetIndexFromByteCount(Document.DocumentLineString(newPhysicalPosition.Row), _cacheCol)
                If newPhysicalPosition.Col < 0 Then
                    newPhysicalPosition.Col = 0
                ElseIf newPhysicalPosition.Col > Document.DocumentLineString(newPhysicalPosition.Row).Length Then
                    newPhysicalPosition.Col = Document.DocumentLineString(newPhysicalPosition.Row).Length
                End If

                TextCaret.PhysicalPosition = newPhysicalPosition
                MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CaretDownMove()
            Dim newPhysicalPosition As Document.Position
            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                newPhysicalPosition = TextCaret.PhysicalPosition
                newPhysicalPosition.Row += 1

                If newPhysicalPosition.Row > Document.DocumentLinesCount - 1 Then
                    newPhysicalPosition.Row = Document.DocumentLinesCount - 1
                Else
                End If

                newPhysicalPosition.Col = Common.StringTransaction.GetIndexFromByteCount(Document.DocumentLineString(newPhysicalPosition.Row), _cacheCol)
                If newPhysicalPosition.Col < 0 Then
                    newPhysicalPosition.Col = 0
                ElseIf newPhysicalPosition.Col > Document.DocumentLineString(newPhysicalPosition.Row).Length Then
                    newPhysicalPosition.Col = Document.DocumentLineString(newPhysicalPosition.Row).Length
                End If

                TextCaret.PhysicalPosition = newPhysicalPosition
                MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CaretHomeMove()
            Dim newPhysicalPosition As Document.Position
            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                newPhysicalPosition = TextCaret.PhysicalPosition
                newPhysicalPosition.Col = 0
                _cacheCol = 0
                TextCaret.PhysicalPosition = newPhysicalPosition
                MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CaretEndMove()
            Dim newPhysicalPosition As Document.Position
            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                newPhysicalPosition = TextCaret.PhysicalPosition
                newPhysicalPosition.Col = Document.DocumentLineString(newPhysicalPosition.Row).Length
                _cacheCol = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(newPhysicalPosition.Row).Substring(0, newPhysicalPosition.Col))
                TextCaret.PhysicalPosition = newPhysicalPosition
                MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CaretPageUpMove()
            Dim newPhysicalPosition As Document.Position
            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then

                newPhysicalPosition = TextCaret.PhysicalPosition
                newPhysicalPosition.Row -= _textView.ShowMaxLineCount

                If newPhysicalPosition.Row < 0 Then
                    newPhysicalPosition.Row = 0
                Else
                End If

                newPhysicalPosition.Col = Common.StringTransaction.GetIndexFromByteCount(Document.DocumentLineString(newPhysicalPosition.Row), _cacheCol)
                If newPhysicalPosition.Col < 0 Then
                    newPhysicalPosition.Col = 0
                ElseIf newPhysicalPosition.Col > Document.DocumentLineString(newPhysicalPosition.Row).Length Then
                    newPhysicalPosition.Col = Document.DocumentLineString(newPhysicalPosition.Row).Length
                End If

                TextCaret.PhysicalPosition = newPhysicalPosition
                MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CaretPageDownMove()
            Dim newPhysicalPosition As Document.Position
            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then

                newPhysicalPosition = TextCaret.PhysicalPosition
                newPhysicalPosition.Row += TextView.ShowMaxLineCount
                If newPhysicalPosition.Row > Document.DocumentLinesCount - 1 Then
                    newPhysicalPosition.Row = Document.DocumentLinesCount - 1
                Else
                End If

                newPhysicalPosition.Col = Common.StringTransaction.GetIndexFromByteCount(Document.DocumentLineString(newPhysicalPosition.Row), _cacheCol)
                If newPhysicalPosition.Col < 0 Then
                    newPhysicalPosition.Col = 0
                ElseIf newPhysicalPosition.Col > Document.DocumentLineString(newPhysicalPosition.Row).Length Then
                    newPhysicalPosition.Col = Document.DocumentLineString(newPhysicalPosition.Row).Length
                End If

                TextCaret.PhysicalPosition = newPhysicalPosition
                MoveTextViewToShowCaret()
            Else
            End If
        End Sub

        Public Sub CaretChangeStatus()
            Select Case TextCaret.Status
                Case CaretStatusEnum.Insert
                    TextCaret.Status = CaretStatusEnum.OverWrite
                Case CaretStatusEnum.OverWrite
                    TextCaret.Status = CaretStatusEnum.Insert
            End Select
            MoveTextViewToShowCaret()
        End Sub

        Public Sub CaretMoveTo(ByVal row As Integer, ByVal col As Integer)
            Dim newPhysicalPosition As Document.Position
            Dim newScrollBarValue As Integer

            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                _textView.Focus()
                newPhysicalPosition = GetAVailableCaretPhysicalPosition(New Document.Position(row, col))
                TextCaret.PhysicalPosition = newPhysicalPosition
                _cacheCol = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(newPhysicalPosition.Row).Substring(0, newPhysicalPosition.Col))
                MoveTextViewToShowCaret()

                _textView.TextCaret.Hide()

                If newPhysicalPosition.Row - _textView.StartLine < _textView.ShowMaxLineCount \ 4 Then
                    newScrollBarValue = _vScrollbar.Value - _textView.ShowMaxLineCount \ 4
                ElseIf _textView.StartLine + _textView.ShowMaxLineCount - newPhysicalPosition.Row < _textView.ShowMaxLineCount \ 4 Then
                    newScrollBarValue = _vScrollbar.Value + _textView.ShowMaxLineCount \ 4
                Else
                    newScrollBarValue = _vScrollbar.Value
                End If


                If newScrollBarValue > _vScrollbar.Maximum Then
                    newScrollBarValue = _vScrollbar.Maximum
                ElseIf newScrollBarValue < _vScrollbar.Minimum Then
                    newScrollBarValue = _vScrollbar.Minimum
                End If
                _vScrollbar.Value = newScrollBarValue
                _textView.TextCaret.RePaintCaret()
                _textView.TextCaret.Show()

            End If
        End Sub

        Public Function CaretMoveByStep(ByVal moveStep As Integer) As Boolean
            If moveStep > 0 Then
                Return CaretMoveBackward(moveStep)
            ElseIf moveStep < 0 Then
                Return CaretMoveHeadward(-moveStep)
            Else
                Return False
            End If
        End Function

        Public Function GetAVailableCaretPhysicalPosition(ByVal caretPhysicalPosition As Document.Position) As Document.Position
            Dim result As Document.Position = caretPhysicalPosition

            If Document IsNot Nothing Then
                If result.Row < 0 Then
                    result.Row = 0
                ElseIf result.Row > Document.DocumentLinesCount - 1 Then
                    result.Row = Document.DocumentLinesCount - 1
                End If

                If result.Col < 0 Then
                    result.Col = 0
                ElseIf result.Col > Document.DocumentLineString(result.Row).Length Then
                    result.Col = Document.DocumentLineString(result.Row).Length
                End If
            Else
                result.Row = 0
                result.Col = 0
            End If

            Return result
        End Function

        Public Function GetCaretPhysicalPositionFromPoint(ByVal point As Point) As Document.Position
            Dim result As Document.Position
            Dim row, col As Integer
            Dim byteCount As Integer

            If Document IsNot Nothing Then
                row = CInt(point.Y / _textView.Font_Height - 0.5) + _textView.StartLine
                If row > Document.DocumentLinesCount - 1 Then
                    row = Document.DocumentLinesCount - 1
                ElseIf row < 0 Then
                    row = 0
                End If
                byteCount = CInt(point.X / _textView.Font_Width - 0.5) + _textView.StartColumn
                col = Common.StringTransaction.GetIndexFromByteCount(Document.DocumentLineString(row), byteCount)
                result = GetAVailableCaretPhysicalPosition(New Document.Position(row, col))
            Else
                result.Row = 0
                result.Col = 0
            End If

            Return result
        End Function

        Protected Overrides Sub AddAllHandler()
            AddHandler _textView.KeyDown, AddressOf OnKeyDown
            AddHandler _textView.MouseDown, AddressOf OnMouseDown
            AddHandler _textView.MouseUp, AddressOf OnMouseUp
        End Sub

        Protected Overrides Sub RemoveAllHandler()
            RemoveHandler _textView.KeyDown, AddressOf OnKeyDown
            RemoveHandler _textView.MouseDown, AddressOf OnMouseDown
            RemoveHandler _textView.MouseUp, AddressOf OnMouseUp
        End Sub

        Private ReadOnly Property TextView() As TextView
            Get
                Return _textView
            End Get
        End Property

        Private ReadOnly Property Document() As Document.Document
            Get
                Return _textView.Document
            End Get
        End Property

        Private ReadOnly Property TextCaret() As TextCaret
            Get
                Return _textView.TextCaret
            End Get
        End Property

        Private ReadOnly Property CodeCompletionForm() As CodeCompletionForm
            Get
                Return _codeCompletionForm
            End Get
        End Property

        Private Sub OnKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                Select Case e.KeyData
                    Case Keys.Left
                        OnLeftKeyDown(sender, e)
                    Case Keys.Right
                        OnRightKeyDown(sender, e)
                    Case Keys.Up
                        OnUpKeyDown(sender, e)
                    Case Keys.Down
                        OnDownKeyDown(sender, e)
                    Case Keys.Home
                        OnHomeKeyDown(sender, e)
                    Case Keys.End
                        OnEndKeyDown(sender, e)
                    Case Keys.PageUp
                        OnPageUpKeyDown(sender, e)
                    Case Keys.PageDown
                        OnPageDownKeyDown(sender, e)
                    Case Keys.Insert
                        OnInsertKeyDown(sender, e)
                    Case Else
                End Select
            End If
        End Sub

        Private Sub OnLeftKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewSelectionControl As TextViewSelectionControl
            If e.KeyData = Keys.Left AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                CaretLeftMove()
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                If textViewSelectionControl IsNot Nothing Then
                    textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
            End If
        End Sub

        Private Sub OnRightKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewSelectionControl As TextViewSelectionControl
            If e.KeyData = Keys.Right AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                CaretRightMove()
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                If textViewSelectionControl IsNot Nothing Then
                    textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
            End If
        End Sub

        Private Sub OnUpKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewSelectionControl As TextViewSelectionControl
            If e.KeyData = Keys.Up AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                CaretUpMove()
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                If textViewSelectionControl IsNot Nothing Then
                    textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
            End If
        End Sub

        Private Sub OnDownKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewSelectionControl As TextViewSelectionControl
            If e.KeyData = Keys.Down AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                CaretDownMove()
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                If textViewSelectionControl IsNot Nothing Then
                    textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
            End If
        End Sub

        Private Sub OnHomeKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewSelectionControl As TextViewSelectionControl
            If e.KeyData = Keys.Home AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                CaretHomeMove()
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                If textViewSelectionControl IsNot Nothing Then
                    textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
            End If
        End Sub

        Private Sub OnEndKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewSelectionControl As TextViewSelectionControl
            If e.KeyData = Keys.End AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                CaretEndMove()
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                If textViewSelectionControl IsNot Nothing Then
                    textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
            End If
        End Sub

        Private Sub OnPageUpKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewSelectionControl As TextViewSelectionControl
            If e.KeyData = Keys.PageUp AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                CaretPageUpMove()
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                If textViewSelectionControl IsNot Nothing Then
                    textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
            End If
        End Sub

        Private Sub OnPageDownKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim textViewSelectionControl As TextViewSelectionControl
            If e.KeyData = Keys.PageDown AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing AndAlso Not CodeCompletionForm.IsShown Then
                CaretPageDownMove()
                textViewSelectionControl = DirectCast(Control(ControlManager.TEXTVIEW_SELECTION), TextViewSelectionControl)
                If textViewSelectionControl IsNot Nothing Then
                    textViewSelectionControl.ClearSelection(TextCaret.PhysicalPosition)
                End If
            End If
        End Sub

        Private Sub OnInsertKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyData = Keys.Insert AndAlso TextCaret IsNot Nothing Then
                CaretChangeStatus()
            End If
        End Sub

        Private Sub OnMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim newPhysicalPosition As Document.Position
            If e.Button = MouseButtons.Left AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                _textView.Focus()
                newPhysicalPosition = GetCaretPhysicalPositionFromPoint(New Point(e.X, e.Y))
                TextCaret.PhysicalPosition = newPhysicalPosition
                _cacheCol = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(newPhysicalPosition.Row).Substring(0, newPhysicalPosition.Col))
                _mouseDownPosition = newPhysicalPosition
            ElseIf e.Button = MouseButtons.Right AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                _textView.Focus()
                newPhysicalPosition = GetCaretPhysicalPositionFromPoint(New Point(e.X, e.Y))
                If newPhysicalPosition.CompareTo(Document.Selection.Start) < 0 OrElse _
                   newPhysicalPosition.CompareTo(Document.Selection.End) > 0 Then
                    TextCaret.PhysicalPosition = newPhysicalPosition
                    _cacheCol = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(newPhysicalPosition.Row).Substring(0, newPhysicalPosition.Col))
                    _mouseDownPosition = newPhysicalPosition
                Else
                End If
            Else
            End If

        End Sub

        Private Sub OnMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim newPhysicalPosition As Document.Position
            If e.Button = MouseButtons.Left AndAlso TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                _textView.Focus()
                newPhysicalPosition = GetCaretPhysicalPositionFromPoint(New Point(e.X, e.Y))
                If _mouseDownPosition.CompareTo(newPhysicalPosition) <> 0 Then
                    TextCaret.PhysicalPosition = newPhysicalPosition
                    _cacheCol = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(newPhysicalPosition.Row).Substring(0, newPhysicalPosition.Col))
                Else
                End If
            End If
        End Sub

        Private Function CaretMoveHeadward(ByVal moveStep As Integer) As Boolean
            Dim totalMoveStep As Integer = moveStep
            Dim moveLen As Integer
            Dim result As Boolean
            Dim newPhysicalPosition As Document.Position

            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                newPhysicalPosition = TextCaret.PhysicalPosition

                If newPhysicalPosition.Col < totalMoveStep Then
                    moveLen = newPhysicalPosition.Col
                Else
                    moveLen = totalMoveStep
                End If
                totalMoveStep -= moveLen
                newPhysicalPosition.Col -= moveLen

                While totalMoveStep > 0
                    If newPhysicalPosition.Row - 1 < 0 Then
                        Exit While
                    Else
                        newPhysicalPosition.Row -= 1
                        newPhysicalPosition.Col = Document.DocumentLineString(newPhysicalPosition.Row).Length
                        totalMoveStep -= 1
                    End If

                    If newPhysicalPosition.Col < totalMoveStep Then
                        moveLen = newPhysicalPosition.Col
                    Else
                        moveLen = totalMoveStep
                    End If
                    totalMoveStep -= moveLen
                    newPhysicalPosition.Col -= moveLen
                End While

                If TextCaret.PhysicalPosition.CompareTo(newPhysicalPosition) = 0 Then
                    result = False
                Else
                    TextCaret.PhysicalPosition = newPhysicalPosition
                    result = True
                End If
            Else
                result = False
            End If

            Return result
        End Function

        Private Function CaretMoveBackward(ByVal moveStep As Integer) As Boolean
            Dim totalMoveStep As Integer = moveStep
            Dim moveLen As Integer
            Dim result As Boolean
            Dim newPhysicalPosition As Document.Position

            If TextCaret IsNot Nothing AndAlso Document IsNot Nothing Then
                newPhysicalPosition = TextCaret.PhysicalPosition

                If Document.DocumentLineString(newPhysicalPosition.Row).Length - newPhysicalPosition.Col < totalMoveStep Then
                    moveLen = Document.DocumentLineString(newPhysicalPosition.Row).Length - newPhysicalPosition.Col
                Else
                    moveLen = totalMoveStep
                End If
                totalMoveStep -= moveLen
                newPhysicalPosition.Col += moveLen

                While totalMoveStep > 0
                    If newPhysicalPosition.Row + 1 > Document.DocumentLinesCount - 1 Then
                        Exit While
                    Else
                        newPhysicalPosition.Row += 1
                        newPhysicalPosition.Col = 0
                        totalMoveStep -= 1
                    End If

                    If Document.DocumentLineString(newPhysicalPosition.Row).Length - newPhysicalPosition.Col < totalMoveStep Then
                        moveLen = Document.DocumentLineString(newPhysicalPosition.Row).Length - newPhysicalPosition.Col
                    Else
                        moveLen = totalMoveStep
                    End If
                    totalMoveStep -= moveLen
                    newPhysicalPosition.Col += moveLen
                End While

                If TextCaret.PhysicalPosition.CompareTo(newPhysicalPosition) = 0 Then
                    result = False
                Else
                    TextCaret.PhysicalPosition = newPhysicalPosition
                    result = True
                End If
            Else
                result = False
            End If

            Return result
        End Function

    End Class


End Namespace