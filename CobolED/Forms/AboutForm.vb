'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  AboutForm.vb                                            --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Forms                                           --
'--                                                                           --
'--  Project       :  CobolED                                                 --
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

Imports System.Reflection
Imports System.Xml

Namespace Forms
    Public Class AboutForm

        Private Const XML_ANALYZER_PATH As String = "CobolEDComponentDefines/CobolEDAnalyzerDefines/CobolEDAnalyzerDefine"
        Private Const XML_EDITOR_PATH As String = "CobolEDComponentDefines/CobolEDEditorDefine"
        Private Const XML_SEARCHENGINE_PATH As String = "CobolEDComponentDefines/CobolEDSearchEngineDefine"
        Private Const XML_FILENAME_ATTRIBUTE As String = "FileName"

        Private Sub AboutForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.Text = My.Application.Info.Title
            Me._lblProductName.Text = My.Application.Info.Title
            Me._lblVersion.Text = My.Application.Info.Version.ToString
            Me._lblCopyright.Text = My.Application.Info.Copyright
            Me._lblMemory.Text = (My.Computer.Info.AvailablePhysicalMemory \ 1024).ToString("###,###K")

            SetReference(My.Resources.ComponentFileName)

        End Sub

        Private Sub _btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOK.Click
            Me.Close()
        End Sub

        Private Sub SetReference(ByVal componentFileName As String)
            Dim xmlDoc As XmlDocument

            Me._lsvReference.Items.Clear()
            Try
                xmlDoc = New XmlDocument
                xmlDoc.Load(componentFileName)

                For Each analyzerDefineNode As XmlNode In xmlDoc.SelectNodes(XML_ANALYZER_PATH)
                    AddListViewItem(IO.Path.Combine(Application.StartupPath, analyzerDefineNode.Attributes(XML_FILENAME_ATTRIBUTE).Value))
                Next

                For Each editorDefineNode As XmlNode In xmlDoc.SelectNodes(XML_EDITOR_PATH)
                    AddListViewItem(IO.Path.Combine(Application.StartupPath, editorDefineNode.Attributes(XML_FILENAME_ATTRIBUTE).Value))
                Next

                For Each searchEngineDefineNode As XmlNode In xmlDoc.SelectNodes(XML_SEARCHENGINE_PATH)
                    AddListViewItem(IO.Path.Combine(Application.StartupPath, searchEngineDefineNode.Attributes(XML_FILENAME_ATTRIBUTE).Value))
                Next

            Catch ex As Exception
            End Try
        End Sub

        Private Sub AddListViewItem(ByVal assemblyFileName As String)
            Dim ass As Assembly
            Dim listViewItem As ListViewItem

            ass = Assembly.LoadFile(assemblyFileName)
            listViewItem = New ListViewItem(ass.GetName.Name)
            listViewItem.SubItems.Add(ass.GetName.Version.ToString)            
            Me._lsvReference.Items.Add(listViewItem)
        End Sub

    End Class

End Namespace