
Imports System.Threading
Imports System.Xml
Imports CobolED.Managers
Imports CobolED.Managers.Manager
Imports CobolED.Forms
Imports Common

Namespace My

    Partial Friend Class MyApplication

        Private Const STATUS_SETTING As String = "Loading settings ..."
        Private Const STATUS_ANALYZER As String = "Loading the analyzer..."
        Private Const STATUS_EDITOR As String = "Loading the editor..."
        Private Const STATUS_SEARCHENGINE As String = "Loading the search engine..."

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim splashScreen As New SplashScreenForm
            Dim xmlDoc As XmlDocument

            Try
                splashScreen.Show()

                If IO.File.Exists(My.Resources.SettingFileName) Then
                    splashScreen.Status = STATUS_SETTING
                    SettingManager.LoadFromXML(My.Resources.SettingFileName)
                Else
                    Common.Message.ShowMessage(My.Resources.CED002_001_I, My.Resources.SettingFileName)
                End If


                If IO.File.Exists(My.Resources.ComponentFileName) Then
                    xmlDoc = New XmlDocument()
                    xmlDoc.Load(My.Resources.ComponentFileName)

                    splashScreen.Status = STATUS_ANALYZER
                    AnalyzerManager.CreateAnalyzers(xmlDoc)

                    splashScreen.Status = STATUS_EDITOR
                    EditorManager.CreateEditorType(xmlDoc)

                    splashScreen.Status = STATUS_SEARCHENGINE
                    SearchManager.CreateSearchEngine(xmlDoc)
                Else
                    Throw New MyException(My.Resources.CED002_002_C, My.Resources.ComponentFileName)
                End If

            Catch myex As MyException
                Common.Message.ShowMessage(myex)
                e.Cancel = True

            Catch ex As Exception
                Common.Message.ShowMessage(ex)
                e.Cancel = True

            Finally
                splashScreen.Close()
            End Try

        End Sub

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            Try
                SettingManager.SaveToXML(My.Resources.SettingFileName)

            Catch myex As MyException
                Common.Message.ShowMessage(myex)

            Catch ex As Exception
                Common.Message.ShowMessage(ex)
            End Try
        End Sub

    End Class

End Namespace

