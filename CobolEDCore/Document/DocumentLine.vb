'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  DocumentLine.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Document                                    --
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

Imports System.Text

Namespace Document

    Public Class DocumentLine
        Private _text As StringBuilder
        Private _bookMark As Boolean

        Public Sub New(ByVal text As String, ByVal bookMark As Boolean)
            _text = New StringBuilder(text)
            _bookMark = bookMark
        End Sub

        Public Sub New(ByVal text As String)
            Me.New(text, False)
        End Sub

        Public Sub New()
            Me.New(String.Empty, False)
        End Sub

        Public ReadOnly Property Text() As StringBuilder
            Get
                Return _text
            End Get
        End Property

        Public ReadOnly Property TextString() As String
            Get
                Return _text.ToString
            End Get
        End Property

        Public Property BookMark() As Boolean
            Get
                Return _bookMark
            End Get
            Set(ByVal value As Boolean)
                _bookMark = value
            End Set
        End Property

    End Class

End Namespace
