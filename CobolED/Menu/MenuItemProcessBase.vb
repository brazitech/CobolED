'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MenuItemProcessBase.vb                                  --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu                                            --
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

Imports CobolEDCore.Interfaces.Menu
Imports CobolEDCore.Infos.Menu
Imports CobolED.Forms

Namespace Menu
    Public MustInherit Class MenuItemProcessBase
        Implements IMenuItemProcess

        Private _cobolEDMainForm As CobolEDMainForm

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            _cobolEDMainForm = cobolEDMainForm
        End Sub

        Public Overridable ReadOnly Property Comment() As String Implements IMenuItemProcess.Comment
            Get
                Return String.Empty
            End Get
        End Property

        Public Overridable ReadOnly Property IsEnable() As Boolean Implements IMenuItemProcess.IsEnable
            Get
                Return True
            End Get
        End Property

        Public Overridable ReadOnly Property HasDynamicMenuItem() As Boolean Implements IMenuItemProcess.HasDynamicMenuItem
            Get
                Return False
            End Get
        End Property

        Public Overridable ReadOnly Property DynamicMenuItemInfos() As List(Of DynamicMenuItemInfo) Implements IMenuItemProcess.DynamicMenuItemInfos
            Get
                Return Nothing
            End Get
        End Property

        Public MustOverride Sub Execute() Implements IMenuItemProcess.Execute

        Protected ReadOnly Property CobolEDMainForm() As CobolEDMainForm
            Get
                Return _cobolEDMainForm
            End Get
        End Property

    End Class
End Namespace
