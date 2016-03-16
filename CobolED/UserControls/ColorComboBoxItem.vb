'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ColorComboBoxItem.vb                                    --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.UserControls                                    --
'--                                                                           --
'--  Project       :  CobolED                                                 --
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

Namespace UserControls
    Public Class ColorComboBoxItem
        Private _color As Color
        Private _text As String

        Public Sub New(ByVal color As Color, ByVal text As String)
            _color = color
            _text = text
        End Sub

        Public Property Color() As Color
            Get
                Return _color
            End Get
            Set(ByVal value As Color)
                _color = value
            End Set
        End Property

        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

    End Class

End Namespace