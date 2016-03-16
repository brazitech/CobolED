'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  IMenuItemProcess.vb                                     --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Interfaces.Menu                             --
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

Imports CobolEDCore.Infos.Menu
Namespace Interfaces.Menu

    Public Interface IMenuItemProcess

        ReadOnly Property Comment() As String

        ReadOnly Property IsEnable() As Boolean

        ReadOnly Property HasDynamicMenuItem() As Boolean

        ReadOnly Property DynamicMenuItemInfos() As List(Of DynamicMenuItemInfo)

        Sub Execute()

    End Interface

End Namespace
