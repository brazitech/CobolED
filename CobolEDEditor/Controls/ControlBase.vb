'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ControlBase.vb                                          --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Controls                                  --
'--                                                                           --
'--  Project       :  CobolEDEditor                                           --
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

Namespace Controls

    Public MustInherit Class ControlBase

        Private _Enable As Boolean
        Private _controlManager As ControlManager

        Public Property Enable() As Boolean
            Get
                Return _Enable
            End Get
            Set(ByVal Value As Boolean)
                If _Enable <> Value Then
                    If Value Then
                        AddAllHandler()
                    Else
                        RemoveAllHandler()
                    End If
                End If
                _Enable = Value
            End Set
        End Property

        Protected Sub New(ByVal controlManager As ControlManager)
            _controlManager = controlManager
        End Sub

        Protected ReadOnly Property Control(ByVal controlName As String) As ControlBase
            Get
                Return _controlManager.Control(controlName)
            End Get
        End Property

        Protected MustOverride Sub AddAllHandler()

        Protected MustOverride Sub RemoveAllHandler()

    End Class

End Namespace

