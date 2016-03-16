'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ProjectInfo.vb                                          --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Infos.Analyzer                              --
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

Imports CobolEDCore.Document
Imports CobolEDCore.Attributes
Namespace Infos.Analyzer
    Public Class ProjectInfo
        Private Const PROJECT_NONAME As String = "NewProject.ced"

        Private Const ITEMNAME_NAME As String = "プロジェクト名前"
        Private Const ITEMNAME_FILENAME As String = "File"

        Private _programInfos As List(Of ProgramInfo)
        Private _projectFileName As String

        Public Sub New(ByVal projectFileName As String)
            Me.New()
            _projectFileName = projectFileName
        End Sub

        Public Sub New()
            _programInfos = New List(Of ProgramInfo)
            _projectFileName = PROJECT_NONAME
        End Sub

        <ShowInItem(True), ItemName(ITEMNAME_FILENAME)> _
        Public Property ProjectFileName() As String
            Get
                Return _projectFileName
            End Get
            Set(ByVal value As String)
                _projectFileName = value
            End Set
        End Property

        Public ReadOnly Property ProgramInfos() As List(Of ProgramInfo)
            Get
                Return _programInfos
            End Get
        End Property

        Public ReadOnly Property ProgramInfos(ByVal programFileName As String) As ProgramInfo
            Get
                For Each programInfo As ProgramInfo In _programInfos
                    If programInfo.ProgramFileName = programFileName Then
                        Return programInfo
                    End If
                Next
                Return Nothing
            End Get
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_NAME)> _
        Public ReadOnly Property ProjectName() As String
            Get
                Return IO.Path.GetFileName(_projectFileName)
            End Get
        End Property

    End Class
End Namespace
