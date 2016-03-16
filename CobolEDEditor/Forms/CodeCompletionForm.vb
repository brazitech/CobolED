'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  CodeCompletionForm.vb                                   --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Forms                                     --
'--                                                                           --
'--  Project       :  CobolEDEditor                                           --
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

Imports System.Drawing
Imports System.Windows.Forms
Imports CobolEDCore.Infos
Imports CobolEDCore.Interfaces
Imports CobolEDCore.Document
Imports CobolEDCore.Enums
Imports CobolEDEditor.Views


Namespace Forms
    Public Class CodeCompletionForm

        Private Const IMG_KEYWORD As Integer = 0
        Private Const IMG_FUNCTION As Integer = 1
        Private Const IMG_VARIABLE As Integer = 2
        Private _textView As TextView

        Public Sub New(ByVal textView As TextView)
            InitializeComponent()
            _textView = textView
        End Sub

        Public ReadOnly Property TextView() As TextView
            Get
                Return _textView
            End Get
        End Property

        Public ReadOnly Property Document() As Document
            Get
                Return _textView.Document
            End Get
        End Property

        Public ReadOnly Property IsShown() As Boolean
            Get
                Return Me.Visible
            End Get
        End Property

        Public ReadOnly Property CodeListView() As ListView
            Get
                Return _codeListView
            End Get
        End Property

        Public ReadOnly Property SelectedWord() As String
            Get
                Dim result As String
                If _codeListView.SelectedItems.Count > 0 Then
                    result = _codeListView.SelectedItems(0).Text
                Else
                    result = String.Empty
                End If
                Return result
            End Get
        End Property

        Public Sub InitializeCodeListView(ByVal codeCompletionListType As CodeCompletionListTypeEnum, _
                                          ByVal keyWords As List(Of String), _
                                          ByVal functionList As List(Of String), _
                                          ByVal variableList As List(Of String))
            Dim listViewItemList As List(Of ListViewItem)

            _codeListView.BeginUpdate()

            _codeListView.Items.Clear()
            If codeCompletionListType And CodeCompletionListTypeEnum.KeyWord > 0 AndAlso keyWords IsNot Nothing Then
                listViewItemList = New List(Of ListViewItem)
                For Each keyWord As String In keyWords
                    listViewItemList.Add(New ListViewItem(keyWord, IMG_KEYWORD))
                Next
                _codeListView.Items.AddRange(listViewItemList.ToArray)
            Else
            End If

            If codeCompletionListType And CodeCompletionListTypeEnum.Function > 0 AndAlso functionList IsNot Nothing Then
                listViewItemList = New List(Of ListViewItem)
                For Each functionName As String In functionList
                    listViewItemList.Add(New ListViewItem(functionName, IMG_FUNCTION))
                Next
                _codeListView.Items.AddRange(listViewItemList.ToArray)
            Else
            End If

            If codeCompletionListType And CodeCompletionListTypeEnum.Variable > 0 AndAlso variableList IsNot Nothing Then
                listViewItemList = New List(Of ListViewItem)
                For Each variableName As String In variableList
                    listViewItemList.Add(New ListViewItem(variableName, IMG_VARIABLE))
                Next
                _codeListView.Items.AddRange(listViewItemList.ToArray)
            Else
            End If

            _codeListView.EndUpdate()

        End Sub

        Public Sub ShowMe(ByVal location As Point, ByVal wordStartWith As String)
            Dim selectedListViewItem As ListViewItem
            selectedListViewItem = _codeListView.FindItemWithText(wordStartWith)
            If selectedListViewItem IsNot Nothing Then
                selectedListViewItem.Selected = True                
                _codeListView.EnsureVisible(selectedListViewItem.Index)
                Me.Location = location
                Me.Show()
            Else
                Me.Hide()
            End If
        End Sub

        Public Sub HideMe()
            Me.Hide()
        End Sub

        Public Sub SelectNextItem(ByVal nextStep As Integer)
            Dim selectIndex As Integer
            Dim selectListViewItem As ListViewItem
            If IsShown Then
                selectIndex = _codeListView.SelectedItems(0).Index + nextStep
                If selectIndex < 0 Then selectIndex = 0
                If selectIndex > _codeListView.Items.Count - 1 Then selectIndex = _codeListView.Items.Count - 1
                selectListViewItem = _codeListView.Items(selectIndex)
                selectListViewItem.Selected = True
                _codeListView.EnsureVisible(selectIndex)
            Else
            End If
        End Sub

        Private Sub _codeListView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _codeListView.Click
            _textView.Focus()
        End Sub

    End Class

End Namespace