'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  SymbolInfo.vb                                           --
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
    Public Class SymbolInfo

        Private _name As String
        Private _isTerminal As Boolean

        Public Sub New(ByVal name As String, ByVal isterminal As Boolean)
            _name = name
            _isTerminal = isterminal
        End Sub

        Public Sub New()
            Me.New(String.Empty, True)
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property IsTerminal() As Boolean
            Get
                Return _isTerminal
            End Get
            Set(ByVal value As Boolean)
                _isTerminal = value
            End Set
        End Property

    End Class
End Namespace