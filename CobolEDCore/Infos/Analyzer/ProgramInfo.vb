'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ProgramInfo.vb                                          --
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

Imports CobolEDCore.Attributes
Imports CobolEDCore.Interfaces.Info
Imports CobolEDCore.Document
Namespace Infos.Analyzer
    Public Class ProgramInfo
        Implements IMoveable

        Private Const ITEMNAME_NAME As String = "プログラム名前"
        Private Const ITEMNAME_FILENAME As String = "File"
        Private Const ITEMNAME_TYPE As String = "類型"

        Private _programFileName As String
        Private _programType As String

        Public Sub New(ByVal programFileName As String, ByVal programType As String)
            _programFileName = programFileName
            _programType = programType
        End Sub

        Public Sub New()
            Me.New(String.Empty, String.Empty)
        End Sub

        <ShowInItem(True), ItemName(ITEMNAME_FILENAME)> _
        Public Property ProgramFileName() As String
            Get
                Return _programFileName
            End Get
            Set(ByVal value As String)
                _programFileName = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_TYPE)> _
        Public Property ProgramType() As String
            Get
                Return _programType
            End Get
            Set(ByVal value As String)
                _programType = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_NAME)> _
        Public ReadOnly Property ProgramName() As String
            Get
                Return IO.Path.GetFileName(ProgramFileName)
            End Get
        End Property

        Public ReadOnly Property MoveFileName() As String Implements IMoveable.FileName
            Get
                Return ProgramFileName
            End Get
        End Property

        Public ReadOnly Property MovePosition() As Position Implements IMoveable.Position
            Get
                Return New Position(-1, -1)
            End Get
        End Property

    End Class
End Namespace
