'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  VariableInfo.vb                                         --
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
    Public Class VariableInfo
        Implements IMoveable

        Private Const ITEMNAME_NAME As String = "variable名"
        Private Const ITEMNAME_TYPE As String = "類型"
        Private Const ITEMNAME_PARENT As String = "集団"
        Private Const ITEMNAME_LAYER As String = "層番号"
        Private Const ITEMNAME_FILENAME As String = "File"
        Private Const ITEMNAME_LOCATION As String = "位置"
        Private Const ITEMNAME_AVAILABLEFUNCTION As String = "有効範囲"
        Private Const ITEMNAME_DECLARE As String = "定義"

        Private _variableName As String
        Private _variableType As String
        Private _variableParent As String
        Private _variableLayer As Integer
        Private _variableFileName As String
        Private _variableLocation As Integer
        Private _variableAvailableFunction As String
        Private _variableDeclare As String

        Public Sub New(ByVal variableName As String, _
                              ByVal variableType As String, _
                              ByVal variableParent As String, _
                              ByVal variableLayer As String, _
                              ByVal variableFileName As String, _
                              ByVal variableLocation As Integer, _
                              ByVal variableAvailableFunction As String, _
                              ByVal variableDeclare As String)
            _variableName = variableName
            _variableType = variableType
            _variableParent = variableParent
            _variableLayer = variableLayer
            _variableFileName = variableFileName
            _variableLocation = variableLocation
            _variableAvailableFunction = variableAvailableFunction
            _variableDeclare = variableDeclare
        End Sub

        Public Sub New()
            Me.New(String.Empty, String.Empty, String.Empty, 0, String.Empty, -1, String.Empty, String.Empty)
        End Sub

        <ShowInItem(True), ItemName(ITEMNAME_NAME)> _
        Public Property VariableName() As String
            Get
                Return _variableName
            End Get
            Set(ByVal value As String)
                _variableName = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_TYPE)> _
        Public Property VariableType() As String
            Get
                Return _variableType
            End Get
            Set(ByVal value As String)
                _variableType = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_PARENT)> _
        Public Property VariableParent() As String
            Get
                Return _variableParent
            End Get
            Set(ByVal value As String)
                _variableParent = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_LAYER)> _
        Public Property VariableLayer() As String
            Get
                Return _variableLayer
            End Get
            Set(ByVal value As String)
                _variableLayer = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_FILENAME)> _
        Public Property VariableFileName() As String
            Get
                Return _variableFileName
            End Get
            Set(ByVal value As String)
                _variableFileName = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_LOCATION)> _
        Public Property VariableLocation() As Integer
            Get
                Return _variableLocation
            End Get
            Set(ByVal value As Integer)
                _variableLocation = value
            End Set
        End Property

        <ShowInItem(True), ItemName(ITEMNAME_AVAILABLEFUNCTION)> _
        Public Property VariableAvailableFunction() As String
            Get
                Return _variableAvailableFunction
            End Get
            Set(ByVal value As String)
                _variableAvailableFunction = value
            End Set
        End Property

        <ShowInDescription(True), ItemName(ITEMNAME_DECLARE)> _
        Public Property VariableDeclare() As String
            Get
                Return _variableDeclare
            End Get
            Set(ByVal value As String)
                _variableDeclare = value
            End Set
        End Property

        Public ReadOnly Property MoveFileName() As String Implements IMoveable.FileName
            Get
                Return VariableFileName
            End Get
        End Property

        Public ReadOnly Property MovePosition() As Position Implements IMoveable.Position
            Get
                Return New Position(VariableLocation, 0)
            End Get
        End Property

    End Class
End Namespace
