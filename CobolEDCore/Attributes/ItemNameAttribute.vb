'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ItemNameAttribute.vb                                    --
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
    Public Class ItemNameAttribute
        Inherits Attribute

        Private _name As String

        Public Sub New(ByVal name As String)
            _name = name
        End Sub

        Public ReadOnly Property Name() As String
            Get
                Return _name
            End Get
        End Property


    End Class
End Namespace
