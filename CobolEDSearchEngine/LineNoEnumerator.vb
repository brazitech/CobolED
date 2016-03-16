'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  LineNoEnumerator.vb                                     --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDSearchEngine                                     --
'--                                                                           --
'--  Project       :  CobolEDSearchEngine                                     --
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

Imports CobolEDCore.Document

Public Class LineNoEnumerator
    Implements IEnumerator

    Private _documentLineCount As Integer
    Private _startRow As Integer
    Private _currentRow As Integer
    Private _isUpDirection As Boolean

    Public Sub New(ByVal documentLineCount As Integer, ByVal startRow As Integer, ByVal isUpDirection As Boolean)
        _documentLineCount = documentLineCount
        _startRow = startRow
        _currentRow = startRow
        _isUpDirection = isUpDirection
    End Sub

    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return _currentRow
        End Get
    End Property

    Public ReadOnly Property CurrentRow() As Integer
        Get
            Return _currentRow
        End Get
    End Property

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        _currentRow = _startRow
    End Sub

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Dim result As Boolean
        If _isUpDirection Then
            _currentRow -= 1
            If _currentRow < 0 Then
                _currentRow = _documentLineCount - 1
            End If
        Else
            _currentRow += 1
            If _currentRow > _documentLineCount - 1 Then
                _currentRow = 0
            End If
        End If

        If _currentRow = _startRow Then
            result = False
        Else
            result = True
        End If
        Return result
    End Function

End Class

