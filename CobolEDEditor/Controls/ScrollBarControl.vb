'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ScrollBarControl.vb                                     --
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
Imports CobolEDCore
Imports CobolEDEditor.Caret
Imports CobolEDEditor.Views

Namespace Controls

    Public Class ScrollBarControl
        Inherits ControlBase

        Private _textView As TextView
        Private _bookMarkView As BookMarkView
        Private _rulerView As RulerView
        Private _vScrollBar As VScrollBar
        Private _hScrollBar As HScrollBar

        Public Sub New(ByVal vScrollBar As VScrollBar, _
                       ByVal hScrollBar As HScrollBar, _
                       ByVal textView As TextView, _
                       ByVal bookMarkView As BookMarkView, _
                       ByVal rulerView As RulerView, _
                       ByVal controlManager As ControlManager)
            MyBase.New(controlManager)
            _vScrollBar = vScrollBar
            _hScrollBar = hScrollBar
            _textView = textView
            _bookMarkView = bookMarkView
            _rulerView = rulerView
            Me.Enable = True
        End Sub

        Public Sub ReSetScrollBarRange()

            If _textView.Document IsNot Nothing Then
                _vScrollBar.Maximum = _textView.Document.DocumentLinesCount - 1
            Else
                _vScrollBar.Maximum = 0
            End If
            _vScrollBar.Minimum = 0
            _vScrollBar.LargeChange = _textView.ShowMaxLineCount
            _vScrollBar.SmallChange = 1

            _hScrollBar.Maximum = 256
            _hScrollBar.Minimum = 0
            _hScrollBar.LargeChange = _textView.ShowMaxColumnCount
            _hScrollBar.SmallChange = 1
        End Sub

        Protected Overrides Sub AddAllHandler()
            AddHandler _vScrollBar.ValueChanged, AddressOf VScrollBar_OnValueChanged
            AddHandler _hScrollBar.ValueChanged, AddressOf HScrollBar_OnValueChanged
            AddHandler _textView.MouseWheel, AddressOf OnMouseWheel
            AddHandler _bookMarkView.MouseWheel, AddressOf OnMouseWheel
        End Sub

        Protected Overrides Sub RemoveAllHandler()
            RemoveHandler _vScrollBar.ValueChanged, AddressOf VScrollBar_OnValueChanged
            RemoveHandler _hScrollBar.ValueChanged, AddressOf HScrollBar_OnValueChanged
            RemoveHandler _textView.MouseWheel, AddressOf OnMouseWheel
            RemoveHandler _bookMarkView.MouseWheel, AddressOf OnMouseWheel
        End Sub

        Protected Sub VScrollBar_OnValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If TextCaret IsNot Nothing Then TextCaret.Hide()
            _textView.StartLine = _vScrollBar.Value
            _bookMarkView.StartLine = _vScrollBar.Value
            If TextCaret IsNot Nothing Then TextCaret.RePaintCaret()
            If TextCaret IsNot Nothing Then TextCaret.Show()

        End Sub

        Protected Sub HScrollBar_OnValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If TextCaret IsNot Nothing Then TextCaret.Hide()
            _textView.StartColumn = _hScrollBar.Value
            _rulerView.StartColumn = _hScrollBar.Value
            If TextCaret IsNot Nothing Then TextCaret.RePaintCaret()
            If TextCaret IsNot Nothing Then TextCaret.Show()
        End Sub

        Protected Sub OnMouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim vScrollBarValue As Integer = _vScrollBar.Value - (e.Delta * System.Windows.Forms.SystemInformation.MouseWheelScrollLines \ 120)
            If vScrollBarValue < _vScrollBar.Minimum Then
                vScrollBarValue = _vScrollBar.Minimum
            End If

            If vScrollBarValue > _vScrollBar.Maximum - _vScrollBar.LargeChange + 1 Then
                vScrollBarValue = _vScrollBar.Maximum - _vScrollBar.LargeChange + 1
            End If

            If vScrollBarValue >= _vScrollBar.Minimum AndAlso vScrollBarValue <= _vScrollBar.Maximum - _vScrollBar.LargeChange + 1 Then
                _vScrollBar.Value = vScrollBarValue
            End If
        End Sub

        Private ReadOnly Property TextCaret() As TextCaret
            Get
                Return _textView.TextCaret
            End Get
        End Property

    End Class

End Namespace