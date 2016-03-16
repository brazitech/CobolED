'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  TextView.vb                                             --
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
Imports System.Drawing
Imports System.Windows.Forms
Imports CobolEDCore.EventArgs
Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.Document
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Enums
Imports CobolEDEditor.Caret
Imports CobolEDEditor.Forms

Namespace Views

    Public Class TextView
        Inherits ViewBase

        Private _textCaret As TextCaret
        Private _cobolEDAnalyzer As ICobolEDAnalyzer
        Private _splitLines As List(Of Integer)
        Private _fontColor As Dictionary(Of WordTypeEnum, Color)

        Public Sub New()
            Me.New(Nothing, Nothing, Nothing, Nothing)
        End Sub

        Public Sub New(ByVal document As Document, ByVal cobolEDAnalyzer As ICobolEDAnalyzer, ByVal textCaret As TextCaret, ByVal fontColor As Dictionary(Of WordTypeEnum, Color))
            MyBase.New(document)
            _cobolEDAnalyzer = cobolEDAnalyzer
            _textCaret = textCaret
            _fontColor = fontColor
            If CobolEDEditAssistant IsNot Nothing Then
                _splitLines = CobolEDEditAssistant.GetDefaultSplitLine
            Else
                _splitLines = New List(Of Integer)
            End If

        End Sub

        Public ReadOnly Property SplitLines() As List(Of Integer)
            Get
                Return _splitLines
            End Get
        End Property

        Public ReadOnly Property CobolEDLex() As ICobolEDLex
            Get
                If _cobolEDAnalyzer IsNot Nothing Then
                    Return _cobolEDAnalyzer.CobolEDLex
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property CobolEDSyntax() As ICobolEDSyntax
            Get
                If _cobolEDAnalyzer.CobolEDSyntax IsNot Nothing Then
                    Return _cobolEDAnalyzer.CobolEDSyntax
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property CobolEDEditAssistant() As ICobolEDEditAssistant
            Get
                If _cobolEDAnalyzer IsNot Nothing Then
                    Return _cobolEDAnalyzer.CobolEDEditAssistant
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Property CobolEDAnalyzer() As ICobolEDAnalyzer
            Get
                Return _cobolEDAnalyzer
            End Get
            Set(ByVal value As ICobolEDAnalyzer)
                _cobolEDAnalyzer = value
                If CobolEDEditAssistant IsNot Nothing Then
                    _splitLines = CobolEDEditAssistant.GetDefaultSplitLine
                Else
                    _splitLines.Clear()
                End If
            End Set
        End Property

        Public Property FontColor() As Dictionary(Of WordTypeEnum, Color)
            Get
                Return _fontColor
            End Get
            Set(ByVal value As Dictionary(Of WordTypeEnum, Color))
                _fontColor = value
            End Set
        End Property

        Public Property TextCaret() As TextCaret
            Get
                Return _textCaret
            End Get
            Set(ByVal value As TextCaret)
                _textCaret = value
            End Set
        End Property

        Public Overridable Shadows Sub RepaintDocumentLine(ByVal row As Integer, ByVal col As Integer, ByVal length As Integer)
            Dim drawDocumentLineRect As Rectangle
            Dim y As Integer
            Dim x As Integer
            Dim width As Integer

            If Document IsNot Nothing AndAlso row >= StartLine AndAlso row <= Document.DocumentLinesCount - 1 Then
                y = GetPointYFromIndex(row)
                x = CInt(Common.StringTransaction.GetByteCountFromIndex(Document.DocumentLineString(row), col) * Font_Width + 0.5)
                width = CInt(Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(row).Substring(col, length)) * Font_Width + 0.5)
                drawDocumentLineRect = New Rectangle(x, y, width, Font_Height)

                If Me.ClientRectangle.IntersectsWith(drawDocumentLineRect) Then
                    Me.Invalidate(drawDocumentLineRect)
                End If
            End If

        End Sub

        Public Overridable Shadows Sub RepaintDocumentLine(ByVal row As Integer, ByVal col As Integer)
            Dim length As Integer
            If Document IsNot Nothing AndAlso row >= StartLine AndAlso row <= Document.DocumentLinesCount - 1 Then
                If col >= 0 AndAlso col < Document.DocumentLineString(row).Length Then
                    length = Document.DocumentLineString(row).Substring(col).Length
                    RepaintDocumentLine(row, col, length)
                Else
                End If
            Else
            End If
        End Sub

        Public Overridable Shadows Sub RepaintDocumentLine(ByVal row As Integer, ByVal col As Integer, ByVal repaintBelow As Boolean)
            Dim drawDocumentLineRect As Rectangle
            Dim invalidateRect As Rectangle
            Dim belowRect As Rectangle
            Dim y As Integer
            Dim x As Integer

            If Document IsNot Nothing AndAlso row >= StartLine AndAlso row <= Document.DocumentLinesCount - 1 Then
                Using graphics As Graphics = Me.CreateGraphics
                    Using brush As New SolidBrush(Me.BackColor)

                        y = GetPointYFromIndex(row)
                        x = GetPointXFromIndex(col, row)
                        drawDocumentLineRect = New Rectangle(0, y, Me.Width, Font_Height)
                        invalidateRect = New Rectangle(x, y, Me.Width - x, Font_Height)

                        If Me.ClientRectangle.IntersectsWith(invalidateRect) Then
                            graphics.FillRectangle(brush, invalidateRect)
                        End If
                        PaintMe(graphics, drawDocumentLineRect)

                        If repaintBelow Then
                            belowRect = New Rectangle(0, y + Font_Height, Me.Width, Me.Height - y - Font_Height)
                            Me.Invalidate(belowRect)
                        Else
                        End If
                    End Using
                End Using
            End If
        End Sub

        Public Overridable Shadows Sub RepaintDocumentLine(ByVal row As Integer, ByVal repaintBelow As Boolean)
            MyBase.RepaintDocumentLine(row, repaintBelow)
        End Sub

        Public Overridable Shadows Sub Initialize(ByVal document As Document, ByVal cobolEDAnalyzer As ICobolEDAnalyzer, ByVal textCaret As TextCaret, ByVal fontColor As Dictionary(Of WordTypeEnum, Color))
            MyBase.Document = document
            _cobolEDAnalyzer = cobolEDAnalyzer
            _textCaret = textCaret
            _fontColor = fontColor
            If CobolEDEditAssistant IsNot Nothing Then
                _splitLines = CobolEDEditAssistant.GetDefaultSplitLine
            Else
                _splitLines = New List(Of Integer)
            End If
        End Sub

        Private Sub SetCompositionWindow()
            Dim hIMC As IntPtr
            Dim lpCompForm As Common.Win32APIFunction.COMPOSITIONFORM

            If _textCaret IsNot Nothing Then
                hIMC = Common.Win32APIFunction.ImmGetContext(Me.Handle)
                lpCompForm.dwStyle = Common.Win32APIFunction.CFS_POINT
                lpCompForm.ptCurrentPos.x = _textCaret.VisualPosition.X
                lpCompForm.ptCurrentPos.y = _textCaret.VisualPosition.Y
                Common.Win32APIFunction.ImmSetCompositionWindow(hIMC, lpCompForm)
            End If
        End Sub

        Public Function Print(ByVal fromDocumentLine As Integer, ByVal graphics As Graphics, ByVal printRectangle As Rectangle) As Integer
            Dim toDocumentLine As Integer
            Dim documentLineString As String
            Dim y As Integer

            toDocumentLine = fromDocumentLine
            documentLineString = Document.DocumentLineString(toDocumentLine)
            y = printRectangle.Top
            While (y + GetPrintDocumentLineHeight(documentLineString, graphics, printRectangle) < printRectangle.Top + printRectangle.Height) AndAlso _
                  (toDocumentLine < Document.DocumentLinesCount)
                y += PrintDocumentLine(documentLineString, graphics, New Point(printRectangle.X, y), printRectangle)
                toDocumentLine += 1
                documentLineString = Document.DocumentLineString(toDocumentLine)
            End While

            Return toDocumentLine
        End Function

        Protected Overrides Sub PaintMe(ByVal graphics As Graphics, ByVal clipRectangle As Rectangle)
            Dim y As Integer = 0
            Dim drawDocumentLineRect As RectangleF
            Dim drawDocumentLinePosition As PointF

            If Document IsNot Nothing Then
                'Draw SplitLine
                For Each splitLine As Integer In _splitLines
                    graphics.DrawLine(Pens.Gray, (splitLine - StartColumn) * Font_Width, 0, (splitLine - StartColumn) * Font_Width, Me.Height)
                Next

                For index As Integer = StartLine To StartLine + ShowMaxLineCount
                    If index <= Document.DocumentLinesCount - 1 Then
                        drawDocumentLineRect = New RectangleF(GetPointXFromIndex(0), _
                                                              y, _
                                                              CInt(GetDrawingStringWidth(graphics, Document.DocumentLineString(index))) + 1, _
                                                              FontHeight)
                        If RectangleF.op_Implicit(clipRectangle).IntersectsWith(drawDocumentLineRect) Then
                            drawDocumentLinePosition = New PointF(drawDocumentLineRect.X, drawDocumentLineRect.Y)
                            drawDocumentLineRect.Intersect(RectangleF.op_Implicit(clipRectangle))
                            PaintDocumentLine(Document.DocumentLineString(index), graphics, drawDocumentLinePosition, drawDocumentLineRect)
                            PaintSelectionBlock(graphics, drawDocumentLinePosition, index)
                        End If
                    Else
                        Exit For
                    End If
                    y += FontHeight
                Next
            End If

        End Sub

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            Select Case m.Msg
                Case Common.Win32APIFunction.WM_IME_STARTCOMPOSITION
                    SetCompositionWindow()
                    MyBase.WndProc(m)
                Case Else
                    MyBase.WndProc(m)
            End Select
        End Sub

        Private Sub PaintDocumentLine(ByVal documentLineString As String, ByVal graphics As Graphics, ByVal drawDocumentLinePosition As PointF, ByVal drawDocumentLineRect As RectangleF)
            Dim x As Single = drawDocumentLinePosition.X
            Dim DrawDocumentWordRect As RectangleF
            Dim DrawDocumentWordPosition As PointF

            If CobolEDLex IsNot Nothing Then
                For Each documentWordInfo As WordInfo In CobolEDLex.GetWords(documentLineString)
                    DrawDocumentWordRect = New RectangleF(x, drawDocumentLinePosition.Y, GetDrawingStringWidth(graphics, documentWordInfo.WordString), FontHeight)
                    If drawDocumentLineRect.IntersectsWith(DrawDocumentWordRect) Then
                        DrawDocumentWordPosition = New PointF(DrawDocumentWordRect.X, DrawDocumentWordRect.Y)
                        PaintDocumentWord(documentWordInfo, graphics, DrawDocumentWordPosition)
                    End If
                    x += GetDrawingStringWidth(graphics, documentWordInfo.WordString)
                Next
            Else
                PaintDocumentWord(New WordInfo(documentLineString, WordTypeEnum.Unknown, 0), graphics, drawDocumentLinePosition)
            End If
        End Sub

        Private Sub PaintDocumentWord(ByVal documentWord As WordInfo, ByVal graphics As Graphics, ByVal drawDocumentWordPosition As PointF)
            Dim drawDocumentWordBrush As Brush
            Dim drawDocumetnWordColor As Color
            If _fontColor IsNot Nothing AndAlso _fontColor.ContainsKey(documentWord.WordType) Then
                drawDocumetnWordColor = _fontColor(documentWord.WordType)
            Else
                drawDocumetnWordColor = Color.Black
            End If

            drawDocumentWordBrush = New SolidBrush(drawDocumetnWordColor)
            graphics.DrawString(documentWord.WordString, Me.Font, drawDocumentWordBrush, drawDocumentWordPosition, MeasureString)
        End Sub

        Private Sub PaintSelectionBlock(ByVal graphics As Graphics, ByVal drawDocumentLinePosition As PointF, ByVal row As Integer)

            Dim selectionBlockRectangle As RectangleF
            Dim x, y, width, height As Single
            Dim selectionStartRow, selectionStartCol As Integer
            Dim selectionEndRow, selectionEndCol As Integer
            Dim selectionBackBrush As New SolidBrush(SystemColors.Highlight)
            Dim selectionFontBrush As New SolidBrush(SystemColors.HighlightText)


            If Document Is Nothing OrElse _
               Document.Selection.Selected = False OrElse _
               row < Document.Selection.Start.Row OrElse _
               row > Document.Selection.End.Row Then
                Return
            End If

            selectionStartRow = Document.Selection.Start.Row
            selectionStartCol = Document.Selection.Start.Col
            selectionEndRow = Document.Selection.End.Row
            selectionEndCol = Document.Selection.End.Col

            If Document.Selection.IsSingleLine Then
                y = drawDocumentLinePosition.Y
                height = Font_Height
                x = drawDocumentLinePosition.X + Common.StringTransaction.GetByteCountFromIndex(Document.DocumentLineString(row), selectionStartCol) * Font_Width
                width = Common.StringTransaction.GetLengthByByte(Document.Selection.GetSelectedString) * Font_Width
                selectionBlockRectangle = New RectangleF(x, y, width, height)
                graphics.FillRectangle(selectionBackBrush, selectionBlockRectangle)
                graphics.DrawString(Document.DocumentLineString(row).Substring(selectionStartCol, selectionEndCol - selectionStartCol), Me.Font, selectionFontBrush, selectionBlockRectangle.X, selectionBlockRectangle.Y, MeasureString)
            Else
                If row = selectionStartRow Then
                    y = drawDocumentLinePosition.Y
                    height = Font_Height
                    x = drawDocumentLinePosition.X + Common.StringTransaction.GetByteCountFromIndex(Document.DocumentLineString(selectionStartRow), selectionStartCol) * Font_Width
                    width = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(row).Substring(selectionStartCol)) * Font_Width
                    selectionBlockRectangle = New RectangleF(x, y, width, height)
                    graphics.FillRectangle(selectionBackBrush, selectionBlockRectangle)
                    graphics.DrawString(Document.DocumentLineString(row).Substring(selectionStartCol), Me.Font, selectionFontBrush, selectionBlockRectangle.X, selectionBlockRectangle.Y, MeasureString)
                ElseIf row = selectionEndRow Then
                    y = drawDocumentLinePosition.Y
                    height = Font_Height
                    x = drawDocumentLinePosition.X
                    width = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(row).Substring(0, selectionEndCol)) * Font_Width
                    selectionBlockRectangle = New RectangleF(x, y, width, height)
                    graphics.FillRectangle(selectionBackBrush, selectionBlockRectangle)
                    graphics.DrawString(Document.DocumentLineString(row).Substring(0, selectionEndCol), Me.Font, selectionFontBrush, selectionBlockRectangle.X, selectionBlockRectangle.Y, MeasureString)
                Else
                    y = drawDocumentLinePosition.Y
                    height = Font_Height
                    x = drawDocumentLinePosition.X
                    width = Common.StringTransaction.GetLengthByByte(Document.DocumentLineString(row)) * Font_Width
                    selectionBlockRectangle = New RectangleF(x, y, width, height)
                    graphics.FillRectangle(selectionBackBrush, selectionBlockRectangle)
                    graphics.DrawString(Document.DocumentLineString(row), Me.Font, selectionFontBrush, selectionBlockRectangle.X, selectionBlockRectangle.Y, MeasureString)
                End If
            End If



        End Sub

        Private Function PrintDocumentLine(ByVal documentLineString As String, ByVal graphics As Graphics, ByVal printDocumentLinePosition As Point, ByVal printRectangle As Rectangle) As Integer            
            Dim printWordPosition As Point
            Dim printStartY As Integer

            printStartY = printDocumentLinePosition.Y
            printWordPosition = printDocumentLinePosition
            If CobolEDLex IsNot Nothing Then
                For Each documentWordInfo As WordInfo In CobolEDLex.GetWords(documentLineString)
                    printWordPosition = PrintDocumentWord(documentWordInfo, graphics, printWordPosition, printRectangle)
                Next
            Else
                printWordPosition = PrintDocumentWord(New WordInfo(documentLineString, WordTypeEnum.Unknown, 0), graphics, printWordPosition, printRectangle)
            End If

            Return printWordPosition.Y - printStartY + Font_Height
        End Function

        Private Function PrintDocumentWord(ByVal documentWord As WordInfo, ByVal graphics As Graphics, ByVal printWordPosition As Point, ByVal printRectangle As Rectangle) As Point
            Dim unprintWord As String
            Dim printingWord As String
            Dim printingWordPosition As Point
            Dim result As Point

            unprintWord = documentWord.WordString
            printingWordPosition = printWordPosition
            Do
                If printingWordPosition.X + GetDrawingStringWidth(graphics, unprintWord) > printRectangle.X + printRectangle.Width Then
                    printingWord = GetSubStringFromWidth(unprintWord, printRectangle.X + printRectangle.Width - printingWordPosition.X)
                Else
                    printingWord = unprintWord
                End If
                unprintWord = unprintWord.Substring(printingWord.Length)

                PaintDocumentWord(New WordInfo(printingWord, documentWord.WordType, 0), graphics, printingWordPosition)
                result = New Point(CInt(printingWordPosition.X + GetDrawingStringWidth(graphics, printingWord)), printingWordPosition.Y)
                printingWordPosition = New Point(printRectangle.X, printingWordPosition.Y + Font_Height)
            Loop While unprintWord <> String.Empty

            Return result
        End Function

        Private Function GetPrintDocumentLineHeight(ByVal documentLineString As String, ByVal graphics As Graphics, ByVal printRectangle As Rectangle) As Integer
            Dim result As Integer
            result = CInt(Math.Ceiling(GetDrawingStringWidth(graphics, documentLineString) / printRectangle.Width)) * Font_Height
            Return result
        End Function

        Private Function GetSubStringFromWidth(ByVal str As String, ByVal width As Integer) As String
            Dim result As String
            Dim byteCount As Integer            
            byteCount = CInt(width / Math.Ceiling(Font_Width))
            If byteCount > Common.StringTransaction.GetLengthByByte(str) Then
                result = str
            Else
                result = Common.StringTransaction.GetSubStringByByte(str, 0, byteCount)
            End If
            
            Return result
        End Function

        Private Function GetDrawingStringWidth(ByVal graphics As Graphics, ByVal s As String) As Single
            Return graphics.MeasureString(s, Me.Font, Int32.MaxValue, MeasureString).Width
        End Function

    End Class

End Namespace