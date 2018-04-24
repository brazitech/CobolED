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

        Private Const XmlAnalyzerPath As String = "CobolEDComponentDefines/CobolEDAnalyzerDefines/CobolEDAnalyzerDefine"
        Private Const XmlEditorPath As String = "CobolEDComponentDefines/CobolEDEditorDefine"
        Private Const XmlSearchenginePath As String = "CobolEDComponentDefines/CobolEDSearchEngineDefine"
        Private Const XmlFilenameAttribute As String = "FileName"

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

                For Each analyzerDefineNode As XmlNode In xmlDoc.SelectNodes(XmlAnalyzerPath)
                    AddListViewItem(IO.Path.Combine(Application.StartupPath, analyzerDefineNode.Attributes(XmlFilenameAttribute).Value))
                Next

                For Each editorDefineNode As XmlNode In xmlDoc.SelectNodes(XmlEditorPath)
                    AddListViewItem(IO.Path.Combine(Application.StartupPath, editorDefineNode.Attributes(XmlFilenameAttribute).Value))
                Next

                For Each searchEngineDefineNode As XmlNode In xmlDoc.SelectNodes(XmlSearchenginePath)
                    AddListViewItem(IO.Path.Combine(Application.StartupPath, searchEngineDefineNode.Attributes(XmlFilenameAttribute).Value))
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