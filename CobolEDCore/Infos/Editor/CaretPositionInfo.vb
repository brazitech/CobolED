'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CaretPositionInfo.vb                                    --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Infos.Editor                                --
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

Namespace Infos.Editor
    Public Class CaretPositionInfo
        Private _row As Integer
        Private _col As Integer
        Private _documentFileName As String

        Public Sub New(ByVal row As Integer, ByVal col As Integer, ByVal documentFileName As String)
            _row = row
            _col = col
            _documentFileName = documentFileName
        End Sub

        Public Sub New()
            Me.New(0, 0, String.Empty)
        End Sub

        Public Property Row() As Integer
            Get
                Return _row
            End Get
            Set(ByVal value As Integer)
                _row = value
            End Set
        End Property

        Public Property Col() As Integer
            Get
                Return _col
            End Get
            Set(ByVal value As Integer)
                _col = value
            End Set
        End Property

        Public Property DocumentFileName() As String
            Get
                Return _documentFileName
            End Get
            Set(ByVal value As String)
                _documentFileName = value
            End Set
        End Property

    End Class
End Namespace
