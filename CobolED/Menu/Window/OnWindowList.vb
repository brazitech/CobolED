'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnWindowList.vb                                         --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.Window                                     --
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

Imports CobolEDCore.Infos.Menu
Imports CobolEDCore.Interfaces.Menu
Imports CobolED.Forms
Imports CobolED.Managers.Manager

Namespace Menu.Window
    Public Class OnWindowList
        Inherits MenuItemProcessBase

        Private Const StrComment As String = "List all of the open windows"

        Public Sub New(ByVal cobolEdMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return StrComment
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                If DocumentFormManager.DocumentForms.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides ReadOnly Property HasDynamicMenuItem() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property DynamicMenuItemInfos() As System.Collections.Generic.List(Of CobolEDCore.Infos.Menu.DynamicMenuItemInfo)
            Get
                Dim result As List(Of DynamicMenuItemInfo)
                Dim toolStripMenuItem As ToolStripMenuItem
                Dim menuItemProcess As IMenuItemProcess
                Dim documentFileName As String

                result = New List(Of DynamicMenuItemInfo)
                For Each documentForm As DocumentForm In DocumentFormManager.DocumentForms
                    documentFileName = documentForm.Document.DocumentFileName
                    toolStripMenuItem = New ToolStripMenuItem(documentFileName)
                    menuItemProcess = New OnWindowListSubItem(CobolEDMainForm, documentFileName)
                    result.Add(New DynamicMenuItemInfo(toolStripMenuItem, menuItemProcess))
                Next
                Return result
            End Get
        End Property

        Public Overrides Sub Execute()

        End Sub

    End Class
End Namespace
