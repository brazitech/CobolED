Imports CobolEDCore.Enums
Namespace Infos.Analyzer
    Public Class StatusInfo

        Private _id As String
        Private _isTerminal As Boolean
        Private _needBack As Boolean
        Private _wordType As WordTypeEnum
        Private _caseList As List(Of CaseInfo)

        Public Sub New(ByVal id As String, _
                       ByVal isTerminal As Boolean, _
                       ByVal needBack As Boolean, _
                       ByVal wordType As WordTypeEnum, _
                       ByVal caseList As List(Of CaseInfo))
            _id = id
            _isTerminal = isTerminal
            _needBack = needBack
            _wordType = wordType
            _caseList = caseList
        End Sub

        Public Sub New()
            Me.New(String.Empty, False, False, WordTypeEnum.Unknown, New List(Of CaseInfo))
        End Sub

        Public Property ID() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property IsTerminal() As Boolean
            Get
                Return _isTerminal
            End Get
            Set(ByVal value As Boolean)
                _isTerminal = value
            End Set
        End Property

        Public Property NeedBack() As Boolean
            Get
                Return _needBack
            End Get
            Set(ByVal value As Boolean)
                _needBack = value
            End Set
        End Property

        Public Property WordType() As WordTypeEnum
            Get
                Return _wordType
            End Get
            Set(ByVal value As WordTypeEnum)
                _wordType = value
            End Set
        End Property

        Public Property CaseList() As List(Of CaseInfo)
            Get
                Return _caseList
            End Get
            Set(ByVal value As List(Of CaseInfo))
                _caseList = value
            End Set
        End Property

    End Class
End Namespace
