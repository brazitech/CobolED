'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  SentenceInfo.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Infos.Analyzer                              --
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
Namespace Infos.Analyzer
    Public Class SentenceInfo
        Private _startRow As Integer
        Private _startCol As Integer
        Private _endRow As Integer
        Private _endCol As Integer
        Private _words As List(Of WordInfo)

        Public Sub New(ByVal startRow As Integer, ByVal startCol As Integer, ByVal endRow As Integer, ByVal endCol As Integer, ByVal words As List(Of WordInfo))
            _startRow = startRow
            _startCol = startCol
            _endRow = endRow
            _endCol = endCol
            _words = words
        End Sub

        Public Sub New()
            Me.New(0, 0, 0, 0, New List(Of WordInfo))
        End Sub

        Public Property StartRow() As Integer
            Get
                Return _startRow
            End Get
            Set(ByVal value As Integer)
                _startRow = value
            End Set
        End Property

        Public Property StartCol() As Integer
            Get
                Return _startCol
            End Get
            Set(ByVal value As Integer)
                _startCol = value
            End Set
        End Property

        Public Property EndRow() As Integer
            Get
                Return _endRow
            End Get
            Set(ByVal value As Integer)
                _endRow = value
            End Set
        End Property

        Public Property EndCol() As Integer
            Get
                Return _endCol
            End Get
            Set(ByVal value As Integer)
                _endCol = value
            End Set
        End Property

        Public Property Words() As List(Of WordInfo)
            Get
                Return _words
            End Get
            Set(ByVal value As List(Of WordInfo))
                _words = value
            End Set
        End Property

    End Class
End Namespace
