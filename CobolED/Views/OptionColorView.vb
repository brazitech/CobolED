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

        Private Const ItemComment As String = "comment"
        Private Const ItemNormalword As String = "word"
        Private Const ItemNumber As String = "number"
        Private Const ItemSpace As String = "space"
        Private Const ItemOperator As String = "operator"
        Private Const ItemString As String = "string"
        Private Const ItemBracket As String = "parentheses"
        Private Const ItemEnd As String = "end"
        Private Const ItemSymbol As String = "symbol"
        Private Const ItemKeyword As String = "keyword"
        Private Const ItemUnknown As String = "unknown word"

        Private Const ColorBlack As String = "BLACK"
        Private Const ColorWhite As String = "WHITE"
        Private Const ColorGreen As String = "GREEN"
        Private Const ColorRed As String = "RED"
        Private Const ColorYellow As String = "YELLOW"
        Private Const ColorBlue As String = "BLUE"
        Private Const ColorCustom As String = "CUSTOM"

        Private _colorDictionary As Dictionary(Of Color, String)

        Public Sub New()

            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            ' Add the initialization after the InitializeComponent () call .
            InitializeColorDictionary()

        End Sub

        Public Overrides Sub Initialize(ByVal settingInfo As SettingInfo)
            Me._lsbColorItem.Items.Clear()
            AddColorItem(ItemComment, WordTypeEnum.Comment, settingInfo.FontColor(WordTypeEnum.Comment))
            AddColorItem(ItemNormalword, WordTypeEnum.NormalWord, settingInfo.FontColor(WordTypeEnum.NormalWord))
            AddColorItem(ItemNumber, WordTypeEnum.Number, settingInfo.FontColor(WordTypeEnum.Number))
            AddColorItem(ItemSpace, WordTypeEnum.Space, settingInfo.FontColor(WordTypeEnum.Space))
            AddColorItem(ItemOperator, WordTypeEnum.Operator, settingInfo.FontColor(WordTypeEnum.Operator))
            AddColorItem(ItemString, WordTypeEnum.String, settingInfo.FontColor(WordTypeEnum.String))
            AddColorItem(ItemBracket, WordTypeEnum.Bracket, settingInfo.FontColor(WordTypeEnum.Bracket))
            AddColorItem(ItemEnd, WordTypeEnum.End, settingInfo.FontColor(WordTypeEnum.End))
            AddColorItem(ItemSymbol, WordTypeEnum.Symbol, settingInfo.FontColor(WordTypeEnum.Symbol))
            AddColorItem(ItemKeyword, WordTypeEnum.KeyWord, settingInfo.FontColor(WordTypeEnum.KeyWord))
            AddColorItem(ItemUnknown, WordTypeEnum.Unknown, settingInfo.FontColor(WordTypeEnum.Unknown))
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
            _colorDictionary.Add(Color.Black, ColorBlack)
            _colorDictionary.Add(Color.White, ColorWhite)
            _colorDictionary.Add(Color.Green, ColorGreen)
            _colorDictionary.Add(Color.Red, ColorRed)
            _colorDictionary.Add(Color.Yellow, ColorYellow)
            _colorDictionary.Add(Color.Blue, ColorBlue)
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

            If DirectCast(Me._cboColor.Items(_cboColor.Items.Count - 1), ColorComboBoxItem).Text = ColorCustom Then
                Me._cboColor.Items.RemoveAt(Me._cboColor.Items.Count - 1)
            End If
            Me._cboColor.AddItem(color, ColorCustom)
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
