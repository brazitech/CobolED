'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CobolAnalyzer.vb                                        --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDAnalyzer.Cobol                                   --
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

Imports CobolEDCore.Interfaces.Analyzer
Namespace Cobol
    Public Class CobolAnalyzer
        Implements ICobolEDAnalyzer

        Private _cobolLex As CobolLex
        Private _cobolSyntax As CobolSyntax
        Private _cobolEditAssistant As CobolEditAssistant

        Public Sub New()
            _cobolLex = New CobolLex()
            _cobolSyntax = New CobolSyntax(_cobolLex)
            _cobolEditAssistant = New CobolEditAssistant(_cobolLex, _cobolSyntax)
        End Sub

        Public ReadOnly Property CobolEDLex() As ICobolEDLex Implements ICobolEDAnalyzer.CobolEDLex
            Get
                Return _cobolLex
            End Get
        End Property

        Public ReadOnly Property CobolEDSyntax() As ICobolEDSyntax Implements ICobolEDAnalyzer.CobolEDSyntax
            Get
                Return _cobolSyntax
            End Get
        End Property

        Public ReadOnly Property CobolEDEditAssistant() As ICobolEDEditAssistant Implements ICobolEDAnalyzer.CobolEDEditAssistant
            Get
                Return _cobolEditAssistant
            End Get
        End Property

    End Class
End Namespace
