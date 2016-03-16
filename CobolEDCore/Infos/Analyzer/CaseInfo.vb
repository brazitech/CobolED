Namespace Infos.Analyzer
    Public Class CaseInfo

        Private _condition As String
        Private _target As String

        Public Sub New(ByVal condition As String, ByVal target As String)
            _condition = condition
            _target = target
        End Sub

        Public Sub New()
            Me.New(String.Empty, String.Empty)
        End Sub

        Public Property Condition() As String
            Get
                Return _condition
            End Get
            Set(ByVal value As String)
                _condition = value
            End Set
        End Property

        Public Property Target() As String
            Get
                Return _target
            End Get
            Set(ByVal value As String)
                _target = value
            End Set
        End Property

    End Class
End Namespace
