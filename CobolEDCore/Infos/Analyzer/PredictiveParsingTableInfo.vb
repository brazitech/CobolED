'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  PredictiveParsingTableInfo.vb                           --
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

Namespace Infos.Analyzer
    Public Class PredictiveParsingTableInfo

        Private _items As Dictionary(Of String, Dictionary(Of String, ProductionInfo))

        Public Sub New()
            _items = New Dictionary(Of String, Dictionary(Of String, ProductionInfo))
        End Sub

        Public ReadOnly Property Items(ByVal row As String, ByVal col As String) As ProductionInfo
            Get
                Dim result As ProductionInfo
                If _items.ContainsKey(row) AndAlso _items(row).ContainsKey(col) Then
                    result = _items(row)(col)
                Else
                    result = Nothing
                End If
                Return result
            End Get
        End Property

        Public Sub AddItem(ByVal productionInfo As ProductionInfo, ByVal col As String)
            Dim row = productionInfo.Name

            If _items.ContainsKey(row) Then
                If _items(row).ContainsKey(col) Then
                    _items(row)(col) = productionInfo
                Else
                    _items(row).Add(col, productionInfo)
                End If
            Else
                _items.Add(row, New Dictionary(Of String, ProductionInfo))
                _items(row).Add(col, productionInfo)
            End If
        End Sub

    End Class
End Namespace