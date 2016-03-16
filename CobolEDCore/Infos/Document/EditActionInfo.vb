'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  EditActionInfo.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Infos.Document                              --
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
Namespace Infos.Document

    Public Class EditActionInfo

        Private _documentChangeType As DocumentChangeTypeEnum
        Private _row As Integer
        Private _col As Integer
        Private _text As String
        Private _oldText As String

        Public Sub New(ByVal documentChangeType As DocumentChangeTypeEnum, ByVal row As Integer, ByVal col As Integer, ByVal text As String, ByVal oldText As String)
            _documentChangeType = documentChangeType
            _row = row
            _col = col
            _text = text
            _oldText = oldText
        End Sub

        Public Sub New()
            Me.New(DocumentChangeTypeEnum.Unknown, 0, 0, String.Empty, String.Empty)
        End Sub

        Public ReadOnly Property DocumentChangeType() As DocumentChangeTypeEnum
            Get
                Return _documentChangeType
            End Get
        End Property

        Public ReadOnly Property Row() As Integer
            Get
                Return _row
            End Get
        End Property

        Public ReadOnly Property Col() As Integer
            Get
                Return _col
            End Get
        End Property

        Public ReadOnly Property Text() As String
            Get
                Return _text
            End Get
        End Property

        Public ReadOnly Property OldText() As String
            Get
                Return _oldText
            End Get
        End Property

    End Class
End Namespace
