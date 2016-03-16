'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CaterBase.vb                                            --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Caret                                     --
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

Namespace Caret
    Public MustInherit Class CaretBase

        Private _myParent As Control
        Private _size As Size
        Private _position As Point
        Private _visible As Boolean

        Protected Sub New(ByVal MyParent As Control)
            _myParent = MyParent
            _position = New Point(0, 0)
            _size = New Size(2, _myParent.Font.Height)
            _visible = True

            AddHandler _myParent.GotFocus, AddressOf ParentOnGotFocus
            AddHandler _myParent.LostFocus, AddressOf ParentOnLostFocus

            ParentOnGotFocus(MyParent, New System.EventArgs)
        End Sub

        Public Property Size() As Size
            Get
                Return _size
            End Get
            Set(ByVal Value As Size)
                ParentOnLostFocus(_myParent, New System.EventArgs)
                _size = Value
                ParentOnGotFocus(_myParent, New System.EventArgs)
            End Set
        End Property

        Public Property Visible() As Boolean
            Get
                Return _visible
            End Get
            Set(ByVal Value As Boolean)
                _visible = Value
                If _visible Then
                    Common.Win32APIFunction.ShowCaret(_myParent.Handle)
                Else
                    Common.Win32APIFunction.HideCaret(_myParent.Handle)
                End If
            End Set
        End Property

        Public Sub Show()
            Visible = True
        End Sub

        Public Sub Hide()
            Visible = False
        End Sub

        Public Sub Dispose()
            If _myParent.Focused Then
                ParentOnLostFocus(_myParent, New System.EventArgs)
            End If
            RemoveHandler _myParent.GotFocus, AddressOf ParentOnGotFocus
            RemoveHandler _myParent.LostFocus, AddressOf ParentOnLostFocus
        End Sub

        Protected ReadOnly Property MyParent() As Control
            Get
                Return _myParent
            End Get
        End Property

        Protected Property Position() As Point
            Get
                Return _position
            End Get
            Set(ByVal Value As Point)
                _position = Value
                Common.Win32APIFunction.SetCaretPos(_position.X, _position.Y)
            End Set
        End Property

        Private Sub ParentOnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            Common.Win32APIFunction.CreateCaret(_myParent.Handle, IntPtr.Zero, Size.Width, Size.Height)
            Common.Win32APIFunction.SetCaretPos(Position.X, Position.Y)
            Show()
        End Sub

        Private Sub ParentOnLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            Hide()
            Common.Win32APIFunction.DestroyCaret()
        End Sub

    End Class

End Namespace
