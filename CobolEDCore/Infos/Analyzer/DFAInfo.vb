Namespace Infos.Analyzer
    Public Class DFAInfo

        Private _statusList As Dictionary(Of String, StatusInfo)

        Public Sub New()
            _statusList = New Dictionary(Of String, StatusInfo)
        End Sub

        Public ReadOnly Property StatusList(ByVal id As String) As StatusInfo
            Get
                If _statusList.ContainsKey(id) Then
                    Return _statusList(id)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub AddStatus(ByVal status As StatusInfo)
            If _statusList.ContainsKey(status.ID) Then
            Else
                _statusList.Add(status.ID, status)
            End If
        End Sub

    End Class
End Namespace
