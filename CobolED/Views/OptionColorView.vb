'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  OptionColorView.vb                                      --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Views                                           --
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

Imports CobolEDCore.Infos.Setting
Imports CobolEDCore.Enums
Imports CobolED.UserControls
Imports CobolED.Managers.Manager

Namespace Views
    Public Class OptionColorView

        Private Const ITEM_COMMENT As String = "comment"
        Private Const ITEM_NORMALWORD As String = "word"
        Private Const ITEM_NUMBER As String = "number"
        Private Const ITEM_SPACE As String = "space"
        Private Const ITEM_OPERATOR As String = "operator"
        Private Const ITEM_STRING As String = "string"
        Private Const ITEM_BRACKET As String = "parentheses"
        Private Const ITEM_END As String = "end"
        Private Const ITEM_SYMBOL As String = "symbol"
        Private Const ITEM_KEYWORD As String = "keyword"
        Private Const ITEM_UNKNOWN As String = "unknown word"

        Private Const COLOR_BLACK As String = "BLACK"
        Private Const COLOR_WHITE As String = "WHITE"
        Private Const COLOR_GREEN As String = "GREEN"
        Private Const COLOR_RED As String = "RED"
        Private Const COLOR_YELLOW As String = "YELLOW"
        Private Const COLOR_BLUE As String = "BLUE"
        Private Const COLOR_CUSTOM As String = "CUSTOM"

        Private _colorDictionary As Dictionary(Of Color, String)

        Public Sub New()

            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            ' Add the initialization after the InitializeComponent () call .
            InitializeColorDictionary()

        End Sub

        Public Overrides Sub Initialize(ByVal settingInfo As SettingInfo)
            Me._lsbColorItem.Items.Clear()
            AddColorItem(ITEM_COMMENT, WordTypeEnum.Comment, settingInfo.FontColor(WordTypeEnum.Comment))
            AddColorItem(ITEM_NORMALWORD, WordTypeEnum.NormalWord, settingInfo.FontColor(WordTypeEnum.NormalWord))
            AddColorItem(ITEM_NUMBER, WordTypeEnum.Number, settingInfo.FontColor(WordTypeEnum.Number))
            AddColorItem(ITEM_SPACE, WordTypeEnum.Space, settingInfo.FontColor(WordTypeEnum.Space))
            AddColorItem(ITEM_OPERATOR, WordTypeEnum.Operator, settingInfo.FontColor(WordTypeEnum.Operator))
            AddColorItem(ITEM_STRING, WordTypeEnum.String, settingInfo.FontColor(WordTypeEnum.String))
            AddColorItem(ITEM_BRACKET, WordTypeEnum.Bracket, settingInfo.FontColor(WordTypeEnum.Bracket))
            AddColorItem(ITEM_END, WordTypeEnum.End, settingInfo.FontColor(WordTypeEnum.End))
            AddColorItem(ITEM_SYMBOL, WordTypeEnum.Symbol, settingInfo.FontColor(WordTypeEnum.Symbol))
            AddColorItem(ITEM_KEYWORD, WordTypeEnum.KeyWord, settingInfo.FontColor(WordTypeEnum.KeyWord))
            AddColorItem(ITEM_UNKNOWN, WordTypeEnum.Unknown, settingInfo.FontColor(WordTypeEnum.Unknown))
            Me._lsbColorItem.SelectedIndex = 0
        End Sub

        Public Overrides Sub SetPartSettingInfo(ByRef settingInfo As SettingInfo)
            settingInfo.FontColor.Clear()
            For Each optionColorItem As OptionColorItem In _lsbColorItem.Items
                settingInfo.FontColor.Add(optionColorItem.Type, optionColorItem.Color)
            Next
        End Sub

        Private Sub InitializeColorDictionary()
            _colorDictionary = New Dictionary(Of Color, String)
            _colorDictionary.Add(Color.Black, COLOR_BLACK)
            _colorDictionary.Add(Color.White, COLOR_WHITE)
            _colorDictionary.Add(Color.Green, COLOR_GREEN)
            _colorDictionary.Add(Color.Red, COLOR_RED)
            _colorDictionary.Add(Color.Yellow, COLOR_YELLOW)
            _colorDictionary.Add(Color.Blue, COLOR_BLUE)
        End Sub

        Private Sub AddColorItem(ByVal text As String, ByVal wordType As WordTypeEnum, ByVal color As Color)
            Me._lsbColorItem.Items.Add(New OptionColorItem(text, wordType, color))
        End Sub

        Private Sub ColorItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _lsbColorItem.SelectedIndexChanged
            InitializeColorComboBox(DirectCast(Me._lsbColorItem.SelectedItem, OptionColorItem).Color)
        End Sub

        Private Sub InitializeColorComboBox(ByVal currentColor As Color)
            Dim index As Integer
            index = -1
            Me._cboColor.Items.Clear()
            For Each color As Color In _colorDictionary.Keys
                If color.ToArgb = currentColor.ToArgb Then
                    index = Me._cboColor.AddItem(color, _colorDictionary(color))
                Else
                    Me._cboColor.AddItem(color, _colorDictionary(color))
                End If
            Next
            If index >= 0 Then
                Me._cboColor.SelectedIndex = index
            Else
                AddCustomColor(currentColor)
            End If
        End Sub

        Private Sub AddCustomColor(ByVal color As Color)
            For Each colorComboBoxItem As ColorComboBoxItem In Me._cboColor.Items
                If color.ToArgb = colorComboBoxItem.Color.ToArgb Then
                    Me._cboColor.SelectedItem = colorComboBoxItem
                    Return
                End If
            Next

            If DirectCast(Me._cboColor.Items(_cboColor.Items.Count - 1), ColorComboBoxItem).Text = COLOR_CUSTOM Then
                Me._cboColor.Items.RemoveAt(Me._cboColor.Items.Count - 1)
            End If
            Me._cboColor.AddItem(color, COLOR_CUSTOM)
            Me._cboColor.SelectedIndex = _cboColor.Items.Count - 1
        End Sub

        Private Sub _btnCustom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnCustom.Click
            If Me._dlgColorDialog.ShowDialog = DialogResult.OK Then
                AddCustomColor(Me._dlgColorDialog.Color)
            End If
        End Sub

        Private Sub Color_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _cboColor.SelectedIndexChanged
            Me._lblSample.ForeColor = DirectCast(Me._cboColor.SelectedItem, ColorComboBoxItem).Color
            DirectCast(Me._lsbColorItem.SelectedItem, OptionColorItem).Color = DirectCast(Me._cboColor.SelectedItem, ColorComboBoxItem).Color
        End Sub

        Private Class OptionColorItem
            Private _name As String
            Private _type As WordTypeEnum
            Private _color As Color

            Public Property Name() As String
                Get
                    Return _name
                End Get
                Set(ByVal value As String)
                    _name = value
                End Set
            End Property

            Public Property Type() As WordTypeEnum
                Get
                    Return _type
                End Get
                Set(ByVal value As WordTypeEnum)
                    _type = value
                End Set
            End Property

            Public Property Color() As Color
                Get
                    Return _color
                End Get
                Set(ByVal value As Color)
                    _color = value
                End Set
            End Property

            Public Sub New(ByVal name As String, ByVal type As WordTypeEnum, ByVal color As Color)
                _name = name
                _type = type
                _color = color
            End Sub

            Public Sub New()
                Me.New(String.Empty, WordTypeEnum.Unknown, Color.Black)
            End Sub

            Public Overrides Function ToString() As String
                Return _name
            End Function
        End Class

    End Class
End Namespace
