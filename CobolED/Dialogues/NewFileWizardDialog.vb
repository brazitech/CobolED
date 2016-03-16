'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  NewFileWizardDialog.vb                                  --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
'--                                                                           --
'--  NameSpace     :  CobolED.Dialogues                                       --
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

Imports System.Windows.Forms
Imports System.Xml
Imports System.Reflection
Imports Common

Namespace Dialogues
    Public Class NewFileWizardDialog
        Private Const XML_TABPAGE_DEFINE As String = "Template/WizardDefine/TabPage"
        Private Const XML_TABPAGE_NAME_ATTR As String = "Name"
        Private Const XML_CONTROL_NAME_ATTR As String = "Name"
        Private Const XML_CONTROL_LOCATIONX_ATTR As String = "Left"
        Private Const XML_CONTROL_LOCATIONY_ATTR As String = "Top"
        Private Const XML_REPLACEKEY_ID_ATTR As String = "Id"
        Private Const XML_CONTROL_WIDTH_ATTR As String = "Width"

        Private _defineInfos As Dictionary(Of String, String)

        Public Sub New(ByVal templateName As String)
            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            ' Add the initialization after the InitializeComponent () call .
            _defineInfos = New Dictionary(Of String, String)
            CreateControls(templateName)

        End Sub

        Public ReadOnly Property DefineInfos() As Dictionary(Of String, String)
            Get
                Return _defineInfos
            End Get
        End Property

        Public ReadOnly Property CreateSuccess() As Boolean
            Get
                If _tabCFrame.TabPages.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Private Sub _btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnOK.Click
            SetDefineInfos()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub _btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub SetDefineInfos()
            _defineInfos.Clear()
            For Each tabInstanse As TabPage In Me._tabCFrame.TabPages
                For Each control As Control In tabInstanse.Controls
                    If TypeOf control Is TextBox Then
                        _defineInfos.Add(control.Tag, control.Text.Trim)
                    End If
                Next
            Next
        End Sub

        Private Sub CreateControls(ByVal templateName As String)
            Dim tabInstance As TabPage
            Dim xmlDoc As XmlDocument

            xmlDoc = New XmlDocument
            Try
                xmlDoc.Load(templateName)
                For Each xmlNode As XmlNode In xmlDoc.SelectNodes(XML_TABPAGE_DEFINE)
                    tabInstance = AddTabPage(xmlNode.Attributes(XML_TABPAGE_NAME_ATTR).Value, Me._tabCFrame)
                    For Each xmlChildNode As XmlNode In xmlNode.ChildNodes

                        AddTextControl(xmlChildNode.Attributes(XML_CONTROL_NAME_ATTR).Value, _
                                       xmlChildNode.Attributes(XML_CONTROL_LOCATIONX_ATTR).Value, _
                                       xmlChildNode.Attributes(XML_CONTROL_LOCATIONY_ATTR).Value, _
                                       xmlChildNode.Attributes(XML_CONTROL_WIDTH_ATTR).Value, _
                                       xmlChildNode.Attributes(XML_REPLACEKEY_ID_ATTR).Value, _
                                       tabInstance)
                    Next
                Next
            Catch ex As Exception
                Throw New MyException(My.Resources.CED002_013_C, templateName)
            End Try

        End Sub

        Private Function AddTabPage(ByVal tabPageName As String, ByRef tabFrame As TabControl) As TabPage
            Dim tabPage As TabPage
            tabPage = New TabPage
            tabPage.Text = tabPageName
            tabFrame.Controls.Add(tabPage)
            Return tabPage
        End Function

        Private Function AddTextControl(ByVal textControlName As String, _
                                        ByVal textControlLocationX As Integer, _
                                        ByVal textControlLocationY As Integer, _
                                        ByVal textControlWidth As Integer, _
                                        ByVal textControlID As String, _
                                        ByRef tabPage As TabPage) As TextBox
            Dim textControl As TextBox
            Dim labelControl As Label

            labelControl = New Label
            labelControl.Text = textControlName
            labelControl.AutoSize = True
            labelControl.Left = textControlLocationX - labelControl.PreferredWidth - 2
            labelControl.Top = textControlLocationY + 2
            tabPage.Controls.Add(labelControl)


            textControl = New TextBox()
            textControl.Left = textControlLocationX
            textControl.Top = textControlLocationY
            textControl.Width = textControlWidth
            textControl.Tag = textControlID
            tabPage.Controls.Add(textControl)

            Return textControl
        End Function

    End Class

End Namespace

