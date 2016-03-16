'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MouseStopAtWordEventArgs.vb                             --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.EventArgs                                   --
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

Imports CobolEDCore.Infos.Analyzer
Imports System.Drawing
Namespace EventArgs
    Public Class MouseStopAtWordEventArgs
        Inherits System.EventArgs

        Private _word As WordInfo
        Private _position As Point

        Public Sub New(ByVal word As WordInfo, ByVal position As Point)
            _word = word
            _position = position
        End Sub

        Public Sub New()
            Me.New(Nothing, New Point(0, 0))
        End Sub

        Public Property Word() As WordInfo
            Get
                Return _word
            End Get
            Set(ByVal value As WordInfo)
                _word = value
            End Set
        End Property

        Public Property Position() As Point
            Get
                Return _position
            End Get
            Set(ByVal value As Point)
                _position = value
            End Set
        End Property

    End Class
End Namespace
