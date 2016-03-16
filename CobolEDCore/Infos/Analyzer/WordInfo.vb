'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  WordInfo.vb                                             --
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

Imports CobolEDCore.Enums
Namespace Infos.Analyzer

    Public Class WordInfo
        Private _wordString As String
        Private _wordType As WordTypeEnum
        Private _wordLocation As Integer

        Public Sub New(ByVal wordString As String, ByVal wordType As WordTypeEnum, ByVal wordLocation As Integer)
            _wordString = wordString
            _wordType = wordType
            _wordLocation = wordLocation
        End Sub

        Public Sub New()
            Me.New(String.Empty, WordTypeEnum.Unknown, 0)
        End Sub

        Public ReadOnly Property WordString() As String
            Get
                Return _wordString
            End Get
        End Property

        Public ReadOnly Property WordType() As WordTypeEnum
            Get
                Return _wordType
            End Get
        End Property

        Public ReadOnly Property WordLocation() As Integer
            Get
                Return _wordLocation
            End Get
        End Property

    End Class

End Namespace
