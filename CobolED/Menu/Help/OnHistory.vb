Imports CobolED.Forms
Namespace Menu.Help
    Public Class OnHistory
        Inherits MenuItemProcessBase

        Private Const HISTORY_FILENAME As String = "Documents\History.chm"
        Private Const STR_COMMENT As String = "View history"

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
                Return IO.File.Exists(HISTORY_FILENAME)
            End Get
        End Property

        Public Overrides Sub Execute()
            If IO.File.Exists(HISTORY_FILENAME) Then
                System.Windows.Forms.Help.ShowHelp(CobolEDMainForm, HISTORY_FILENAME)
            Else
            End If
        End Sub

    End Class
End Namespace