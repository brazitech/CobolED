'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ProductionInfo.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDAnalyzer.Infos                                   --
'--                                                                           --
'--  Project       :  CobolEDAnalyzer                                         --
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
    Public Class ProductionInfo
        Private _symbols As List(Of SymbolInfo)
        Private _id As String
        Private _name As String

        Public Sub New(ByVal name As String, ByVal id As String, ByVal symbols As List(Of SymbolInfo))
            _name = name
            _id = id
            _symbols = symbols
        End Sub

        Public Sub New()
            Me.New(String.Empty, String.Empty, New List(Of SymbolInfo))
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Symbols() As List(Of SymbolInfo)
            Get
                Return _symbols
            End Get
            Set(ByVal value As List(Of SymbolInfo))
                _symbols = value
            End Set
        End Property

        Public Property ID() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

    End Class
End Namespace
