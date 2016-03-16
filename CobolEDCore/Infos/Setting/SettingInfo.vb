'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  SettingInfo.vb                                          --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Infos.Setting                               --
'--                                                                           --
'--  Project       :  CobolEDCore                                             --
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
Imports System.Text
Imports CobolEDCore.Enums
Namespace Infos.Setting
    Public Class SettingInfo

        Private Const DLG_FILTER_DEFAULT As String = "All files (*.*)|*.*"
        Private Const DLG_FILTER_FORMAT As String = "{0} File ({1})|{1}|"
        Private Const DLG_FILTER_PREFIXING As String = "*"
        Private Const DLG_FILTER_SEPRATOR As String = ";"

        Private _fontColor As Dictionary(Of WordTypeEnum, Color)
        Private _fileExtension As Dictionary(Of String, String)
        Private _maxRecentProjectCount As Integer
        Private _maxRecentFileCount As Integer
        Private _recentProjects As List(Of String)
        Private _recentFiles As List(Of String)

        Public Sub New()
            _fontColor = New Dictionary(Of WordTypeEnum, Color)
            _fileExtension = New Dictionary(Of String, String)
            _recentProjects = New List(Of String)
            _recentFiles = New List(Of String)
        End Sub

        Public Property MaxRecentProjectCount() As Integer
            Get
                Return _maxRecentProjectCount
            End Get
            Set(ByVal value As Integer)
                _maxRecentProjectCount = value
            End Set
        End Property

        Public Property MaxRecentFileCount() As Integer
            Get
                Return _maxRecentFileCount
            End Get
            Set(ByVal value As Integer)
                _maxRecentFileCount = value
            End Set
        End Property

        Public ReadOnly Property RecentProjects() As List(Of String)
            Get
                Return _recentProjects
            End Get
        End Property

        Public ReadOnly Property RecentFiles() As List(Of String)
            Get
                Return _recentFiles
            End Get
        End Property

        Public ReadOnly Property FontColor() As Dictionary(Of WordTypeEnum, Color)
            Get
                Return _fontColor
            End Get
        End Property

        Public ReadOnly Property FontColor(ByVal wordType As WordTypeEnum) As Color
            Get
                If _fontColor.ContainsKey(wordType) Then
                    Return _fontColor(wordType)
                Else
                    Return Color.Black
                End If
            End Get
        End Property

        Public ReadOnly Property FileExtension() As Dictionary(Of String, String)
            Get
                Return _fileExtension
            End Get
        End Property

        Public ReadOnly Property FileExtension(ByVal fileExtensionString As String) As String
            Get
                If _fileExtension.ContainsKey(fileExtensionString) Then
                    Return _fileExtension(fileExtensionString)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property FileFilter() As String
            Get
                Dim result As StringBuilder
                Dim analyzerNameList As Dictionary(Of String, StringBuilder)
                Dim analyzerName As String

                result = New StringBuilder(String.Empty)
                analyzerNameList = New Dictionary(Of String, StringBuilder)

                For Each strFileExtension As String In _fileExtension.Keys
                    analyzerName = _fileExtension(strFileExtension)
                    If analyzerNameList.ContainsKey(analyzerName) Then
                        analyzerNameList(analyzerName).Append(DLG_FILTER_SEPRATOR & DLG_FILTER_PREFIXING & strFileExtension)
                    Else
                        analyzerNameList.Add(analyzerName, New StringBuilder(String.Empty))
                        analyzerNameList(analyzerName).Append(DLG_FILTER_PREFIXING & strFileExtension)
                    End If
                Next

                For Each analyzerName In analyzerNameList.Keys
                    result.Append(String.Format(DLG_FILTER_FORMAT, analyzerName, analyzerNameList.Item(analyzerName).ToString))
                Next

                result.Append(DLG_FILTER_DEFAULT)

                Return result.ToString
            End Get
        End Property

    End Class
End Namespace
