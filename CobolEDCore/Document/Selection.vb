'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  Selection.vb                                            --
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

Imports System

Namespace Document

    Public Class Selection

        Private _start As Position
        Private _end As Position
        Private _document As Document

        Public Sub New(ByVal document As Document, ByVal start As Position, ByVal [end] As Position)
            _document = document
            _start = start
            _end = [end]
        End Sub

        Public Sub New()
            _document = Nothing
            _start = New Position(0, 0)
            _end = New Position(0, 0)
        End Sub

        Public Property Start() As Position
            Get
                If _start.CompareTo(_end) < 0 Then
                    Return _start
                Else
                    Return _end
                End If
            End Get
            Set(ByVal Value As Position)
                _start = Value
            End Set
        End Property

        Public Property [End]() As Position
            Get
                If _start.CompareTo(_end) < 0 Then
                    Return _end
                Else
                    Return _start
                End If
            End Get
            Set(ByVal Value As Position)
                _end = Value
            End Set
        End Property

        Public Property Document() As Document
            Get
                Return _document
            End Get
            Set(ByVal value As Document)
                _document = value
            End Set
        End Property

        Public ReadOnly Property Selected() As Boolean
            Get
                If _start.CompareTo(_end) = 0 Then
                    Return False
                Else
                    Return True
                End If
            End Get
        End Property

        Public ReadOnly Property IsSingleLine() As Boolean
            Get
                If _start.Row = _end.Row Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Sub Clear(ByVal caretPosition As Position)
            _start = caretPosition
            _end = caretPosition
        End Sub

        Public Function Length() As Integer
            Dim rst As Integer = 0
            If Start.Row = [End].Row Then
                rst = [End].Col - Start.Col
            Else
                rst = _document.DocumentLineString(Start.Row).Substring(Start.Col).Length + 1
                For Index As Integer = Start.Row + 1 To [End].Row - 1
                    rst += _document.DocumentLineString(Index).Length + 1
                Next
                rst += [End].Col
            End If
            Return rst
        End Function

        Public Function GetSelectedString() As String
            Dim rst As String = String.Empty
            If Start.Row = [End].Row Then
                rst = _document.DocumentLineString(Start.Row).Substring(Start.Col, [End].Col - Start.Col)
            Else
                rst = _document.DocumentLineString(Start.Row).Substring(Start.Col) & _document.EOL
                For Index As Integer = Start.Row + 1 To [End].Row - 1
                    rst &= _document.DocumentLineString(Index) & _document.EOL
                Next
                rst &= _document.DocumentLineString([End].Row).Substring(0, [End].Col)
            End If
            Return rst
        End Function

    End Class

End Namespace