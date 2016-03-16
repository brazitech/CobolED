'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  FunctionInfo.vb                                         --
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
    Public Class FunctionInfo
        Implements IMoveable

        Private Const ITEMNAME_NAME As String = "function名"
        Private Const ITEMNAME_FILENAME As String = "File"
        Private Const ITEMNAME_LOCATION As String = "位置"
        Private Const ITEMNAME_PARENT As String = "集団"
        Private Const ITEMNAME_DECLARE As String = "定義"

        Private _functionName As String
        Private _functionFileName As String
        Private _functionLocation As Integer
        Private _functionParent As String
        Private _functionDeclare As String

        Public Sub New(ByVal functionName As String, ByVal functionFileName As String, ByVal funcitonLocation As Integer, ByVal functionParent As String, ByVal functionDeclare As String)
            _functionName = functionName
            _functionFileName = functionFileName
            _functionLocation = funcitonLocation
            _functionParent = functionParent
            _functionDeclare = functionDeclare
        End Sub

        Public Sub New()
            Me.New(String.Empty, String.Empty, -1, String.Empty, String.Empty)
        End Sub

        <ShowInItem(True), ItemName(ITEMNAME_NAME)> _
        Public Property FunctionName() As String
            Get
                Return _functionName
            End Get
            Set(ByVal value As String)
                _functionName = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_FILENAME)> _
        Public Property FunctionFileName() As String
            Get
                Return _functionFileName
            End Get
            Set(ByVal value As String)
                _functionFileName = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_LOCATION)> _
        Public Property FunctionLocation() As Integer
            Get
                Return _functionLocation
            End Get
            Set(ByVal value As Integer)
                _functionLocation = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_PARENT)> _
            Public Property FunctionParent() As String
            Get
                Return _functionParent
            End Get
            Set(ByVal value As String)
                _functionParent = value
            End Set
        End Property

        <ShowInDescription(True), ItemName(ITEMNAME_DECLARE)> _
        Public Property FunctionDeclare() As String
            Get
                Return _functionDeclare
            End Get
            Set(ByVal value As String)
                _functionDeclare = value
            End Set
        End Property

        Public ReadOnly Property MoveFileName() As String Implements IMoveable.FileName
            Get
                Return FunctionFileName
            End Get
        End Property

        Public ReadOnly Property MovePosition() As Position Implements IMoveable.Position
            Get
                Return New Position(FunctionLocation, 0)
            End Get
        End Property

    End Class
End Namespace
