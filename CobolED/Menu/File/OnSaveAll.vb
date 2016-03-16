'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OnSaveAll.vb                                            --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
'--                                                                           --
'--  NameSpace     :  CobolED.Menu.File                                       --
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

Imports CobolED.Forms
Imports CobolED.Managers.Manager
Imports CobolEDCore

Namespace Menu.File
    Public Class OnSaveAll
        Inherits MenuItemProcessBase

        Private Const STR_COMMENT As String = "Save All"

        Public Sub New(ByVal cobolEDMainForm As CobolEDMainForm)
            MyBase.New(cobolEDMainForm)
        End Sub

        Public Overrides ReadOnly Property Comment() As String
            Get
                Return STR_COMMENT
            End Get
        End Property

        Public Overrides ReadOnly Property IsEnable() As Boolean
            Get
                If DocumentManager.Documents.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Overrides Sub Execute()
            SaveAllDocument()
            ProjectManager.SaveProject()
        End Sub

        Public Sub SaveAllDocument()
            For Each doc As Document.Document In DocumentManager.Documents
                If doc.DocumentDirtyFlag = True Then
                    doc.Save()
                End If
            Next
        End Sub

    End Class
End Namespace
