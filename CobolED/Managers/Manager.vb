'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  Manager.vb                                              --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Managers                                        --
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

Imports CobolED.Managers
Namespace Managers
    Public Class Manager

        Private Sub New()
        End Sub

        Public Shared ReadOnly Property AnalyzerManager() As AnalyzerManagerSingleton
            Get
                Return AnalyzerManagerSingleton.AnalyzerManager
            End Get
        End Property

        Public Shared ReadOnly Property DocumentFormManager() As DocumentFormManagerSingleton
            Get
                Return DocumentFormManagerSingleton.DocumentFormManager
            End Get
        End Property

        Public Shared ReadOnly Property DocumentManager() As DocumentManagerSingleton
            Get
                Return DocumentManagerSingleton.DocumentManager
            End Get
        End Property

        Public Shared ReadOnly Property EditorManager() As EditorManagerSingleton
            Get
                Return EditorManagerSingleton.EditorManager
            End Get
        End Property

        Public Shared ReadOnly Property MemberManager() As MemberManagerSingleton
            Get
                Return MemberManagerSingleton.MemberManager
            End Get
        End Property

        Public Shared ReadOnly Property MenuManager() As MenuManagerSingleton
            Get
                Return MenuManagerSingleton.MenuManager
            End Get
        End Property

        Public Shared ReadOnly Property ProjectManager() As ProjectManagerSingleton
            Get
                Return ProjectManagerSingleton.ProjectManager
            End Get
        End Property

        Public Shared ReadOnly Property SearchManager() As SearchManagerSingleton
            Get
                Return SearchManagerSingleton.SearchManager
            End Get
        End Property

        Public Shared ReadOnly Property SettingManager() As SettingManagerSingleton
            Get
                Return SettingManagerSingleton.SettingManager
            End Get
        End Property

        Public Shared ReadOnly Property ToolBarManager() As ToolBarManagerSingleton
            Get
                Return ToolBarManagerSingleton.ToolBarManager
            End Get
        End Property

        Public Shared ReadOnly Property PrintManager() As PrintManagerSingleton
            Get
                Return PrintManagerSingleton.PrintManager
            End Get
        End Property

    End Class
End Namespace
