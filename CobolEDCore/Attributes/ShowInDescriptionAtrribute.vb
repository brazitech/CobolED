'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ShowInDescriptionAttribute.vb                           --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Attributes                                  --
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

Namespace Attributes
    <AttributeUsage(AttributeTargets.Property)> _
    Public Class ShowInDescriptionAttribute
        Inherits Attribute

        Private _isShow As Boolean

        Public Sub New(ByVal isShow As Boolean)
            _isShow = isShow
        End Sub

        Public ReadOnly Property IsShow() As Boolean
            Get
                Return _isShow
            End Get
        End Property



    End Class
End Namespace
