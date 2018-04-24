Imports CobolED.Forms
Namespace Menu.Help
    Public Class OnHistory
        Inherits MenuItemProcessBase

        Private Const HistoryFilename As String = "Documents\History.chm"
        Private Const StrComment As String = "View history"

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
                Return IO.File.Exists(HistoryFilename)
            End Get
        End Property

        Public Overrides Sub Execute()
            If IO.File.Exists(HistoryFilename) Then
                System.Windows.Forms.Help.ShowHelp(CobolEDMainForm, HistoryFilename)
            Else
            End If
        End Sub

    End Class
End Namespace