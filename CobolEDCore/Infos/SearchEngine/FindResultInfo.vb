'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  FindResultInfo.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Infos.SearchEngine                          --
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

Imports CobolEDCore.Interfaces.Info
Imports CobolEDCore.Document
Namespace Infos.SearchEngine

    Public Class FindResultInfo
        Implements IMoveable

        Private _findResultLine As String
        Private _findResultFileName As String
        Private _findResultRow As Integer
        Private _findResultCol As Integer

        Public Sub New(ByVal findResultLine As String, ByVal findResultFileName As String, ByVal findResultRow As Integer, ByVal findResultCol As Integer)
            _findResultLine = findResultLine
            _findResultFileName = findResultFileName
            _findResultRow = findResultRow
            _findResultCol = findResultCol
        End Sub

        Public Sub New()
            Me.New(String.Empty, String.Empty, 0, 0)
        End Sub

        Public Property FindResultLine() As String
            Get
                Return _findResultLine
            End Get
            Set(ByVal value As String)
                _findResultLine = value
            End Set
        End Property

        Public Property FindResultFileName() As String
            Get
                Return _findResultFileName
            End Get
            Set(ByVal value As String)
                _findResultFileName = value
            End Set
        End Property

        Public Property FindResultRow() As Integer
            Get
                Return _findResultRow
            End Get
            Set(ByVal value As Integer)
                _findResultRow = value
            End Set
        End Property

        Public Property FindResultCol() As Integer
            Get
                Return _findResultCol
            End Get
            Set(ByVal value As Integer)
                _findResultCol = value
            End Set
        End Property

        Public ReadOnly Property MoveFileName() As String Implements IMoveable.FileName
            Get
                Return FindResultFileName
            End Get
        End Property

        Public ReadOnly Property MovePosition() As Position Implements IMoveable.Position
            Get
                Return New Position(FindResultRow, FindResultCol)
            End Get
        End Property

    End Class
End Namespace
