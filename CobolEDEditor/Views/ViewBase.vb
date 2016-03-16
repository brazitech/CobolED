'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ViewBase.vb                                             --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Views                                     --
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
Imports System.Windows.Forms
Imports System.Drawing
Imports CobolEDCore

Namespace Views

    Public MustInherit Class ViewBase
        Inherits System.Windows.Forms.Control

        Private _startLine As Integer = 0
        Private _startColumn As Integer = 0
        Private _document As Document.Document = Nothing
        Private _measureString As StringFormat
        Private _commentTip As ToolTip
        Private WithEvents _timer As Timer

        Public Event MouseStop(ByVal sender As Object, ByVal e As MouseEventArgs)

        Public Sub New(ByVal document As Document.Document)
            MyBase.new()
            Me.BackColor = Color.White
            _document = document
            _measureString = StringFormat.GenericTypographic
            _measureString.FormatFlags = _measureString.FormatFlags Or StringFormatFlags.MeasureTrailingSpaces
            _commentTip = New ToolTip
            _timer = New Timer
            _timer.Interval = 500
            _timer.Enabled = False
        End Sub

        Public Sub New()
            Me.New(Nothing)
        End Sub

        Public ReadOnly Property ShowMaxLineCount() As Integer
            Get
                Return Me.Height \ FontHeight
            End Get
        End Property

        Public ReadOnly Property ShowMaxColumnCount() As Integer
            Get
                Dim result As Integer
                result = CInt(Me.Width / Font_Width) - 1
                If result < 0 Then
                    result = 0
                End If
                Return result
            End Get
        End Property

        Public ReadOnly Property Font_Height() As Integer
            Get
                Return FontHeight
            End Get
        End Property

        Public ReadOnly Property Font_Width() As Single
            Get
                Dim g As Graphics = Me.CreateGraphics
                Dim rst As Single = g.MeasureString(" ", Font, Me.Width, _measureString).Width
                g.Dispose()
                Return rst
            End Get
        End Property

        Public ReadOnly Property MeasureString() As StringFormat
            Get
                Return _measureString
            End Get
        End Property

        Public Property Document() As Document.Document
            Get
                Return _document
            End Get
            Set(ByVal value As Document.Document)
                _document = value
                Me.Initialize()
            End Set
        End Property

        Public Property StartLine() As Integer
            Get
                Return _startLine
            End Get
            Set(ByVal Value As Integer)
                If _document IsNot Nothing AndAlso Value >= 0 AndAlso Value <= _document.DocumentLinesCount - 1 Then
                    Dim y As Integer = 0 - GetPointYFromIndex(Value)
                    _startLine = Value
                    MoveMe(0, y)
                Else
                End If
            End Set
        End Property

        Public Property StartColumn() As Integer
            Get
                Return _startColumn
            End Get
            Set(ByVal Value As Integer)
                If Value >= 0 Then
                    Dim x As Integer = 0 - GetPointXFromIndex(Value)
                    _startColumn = Value
                    MoveMe(x, 0)
                End If
            End Set
        End Property

        Public Overridable Sub RepaintDocumentLine(ByVal row As Integer, ByVal repaintBelow As Boolean)
            Dim drawDocumentLineRect As Rectangle
            Dim y As Integer

            If _document IsNot Nothing AndAlso row >= _startLine AndAlso row <= _document.DocumentLinesCount - 1 Then

                y = GetPointYFromIndex(row)
                If repaintBelow Then
                    drawDocumentLineRect = New Rectangle(0, y, Me.Width, Me.Height - y)
                Else
                    drawDocumentLineRect = New Rectangle(0, y, Me.Width, Font_Height)
                End If

                If Me.ClientRectangle.IntersectsWith(drawDocumentLineRect) Then
                    drawDocumentLineRect.Intersect(Me.ClientRectangle)
                    Me.Invalidate(drawDocumentLineRect)
                End If

            End If

        End Sub
       
        Public Overridable Sub Initialize()
            _startLine = 0
            _startColumn = 0
            Me.Refresh()
        End Sub

        Public Overridable Sub Initialize(ByVal document As Document.Document)
            _document = document
            Initialize()
        End Sub

        Public Overridable Sub ShowCommentTip(ByVal comment As String, ByVal position As Point, ByVal duration As Integer)            

            If duration < 0 Then
                _commentTip.ShowAlways = True
                _commentTip.Show(comment, Me, position)
            Else
                _commentTip.ShowAlways = False
                _commentTip.Show(comment, Me, position, duration)
            End If

        End Sub

        Public Overridable Sub HideCommentTip()
            _commentTip.Hide(Me)
        End Sub

        Public Overridable Function GetPointYFromIndex(ByVal index As Integer) As Integer
            Dim result As Integer = 0

            If _document IsNot Nothing AndAlso index >= 0 AndAlso index <= _document.DocumentLinesCount - 1 Then
                If index >= _startLine Then
                    For i As Integer = _startLine To index - 1
                        If i > _document.DocumentLinesCount - 1 Then
                            Exit For
                        Else
                            result += Font_Height
                        End If
                    Next
                Else
                    For i As Integer = index To _startLine - 1
                        result -= Font_Height
                    Next
                End If
            Else
            End If

            Return result
        End Function

        Public Overridable Function GetPointXFromIndex(ByVal index As Integer) As Integer
            Dim result As Integer
            If index >= 0 Then
                result = CInt((index - _startColumn) * Font_Width)
            Else
                result = 0
            End If
            Return result
        End Function

        Public Overridable Function GetPointXFromIndex(ByVal index As Integer, ByVal row As Integer) As Integer
            Dim result As Integer
            Dim subString As String

            If _document Is Nothing Then
                result = 0
            ElseIf row < 0 OrElse row > _document.DocumentLinesCount - 1 Then
                result = 0
            ElseIf index < 0 OrElse index > _document.DocumentLineString(row).Length Then
                result = 0
            Else
                subString = _document.DocumentLineString(row).Substring(0, index)
                result = GetPointXFromIndex(Common.StringTransaction.GetLengthByByte(subString))
            End If
            Return result
        End Function

        Protected Sub MoveMe(ByVal x As Integer, ByVal y As Integer)
            If x <> 0 OrElse y <> 0 Then
                Dim MoveRect As Common.Win32APIFunction.Rect
                MoveRect.left = 0
                MoveRect.top = 0
                MoveRect.right = Me.Width
                MoveRect.bottom = Me.Bottom
                Common.Win32APIFunction.ScrollWindow(Me.Handle, x, y, MoveRect, MoveRect)
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            PaintMe(e.Graphics, e.ClipRectangle)
        End Sub

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            Select Case m.Msg
                Case Common.Win32APIFunction.WM_GETDLGCODE      'Process all keys
                    m.Result = New System.IntPtr(Common.Win32APIFunction.DLGC_WANTALLKEYS)
                Case Else
                    MyBase.WndProc(m)
            End Select
        End Sub

        Protected MustOverride Sub PaintMe(ByVal graphics As Graphics, ByVal clipRectangle As Rectangle)

        Private Sub ViewBase_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
            _timer.Start()
            _commentTip.Hide(Me)
        End Sub

        Private Sub ViewBase_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
            _timer.Stop()
            _commentTip.Hide(Me)
        End Sub

        Private Sub ViewBase_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
            _timer.Start()
        End Sub

        Private Sub _timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _timer.Tick
            Dim position As Point = Me.PointToClient(MousePosition)
            RaiseEvent MouseStop(Me, New MouseEventArgs(Windows.Forms.MouseButtons.None, 0, position.X, position.Y, 0))

        End Sub

    End Class

End Namespace