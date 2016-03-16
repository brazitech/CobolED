'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  IncludeInfo.vb                                          --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Infos.Analyzer                              --
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

Imports CobolEDCore.Attributes

Namespace Infos.Analyzer
    Public Class IncludeInfo

        Private Const ITEMNAME_FILENAME As String = "Reference名"
        Private Const ITEMNAME_DECLARE As String = "定義"

        Private _includeName As String
        Private _includePrefixing As String
        Private _includeSuffixing As String
        Private _includeDeclare As String

        Public Sub New(ByVal includeName As String, ByVal includePrefixing As String, ByVal includeSuffixing As String, ByVal includeDeclare As String)
            _includeName = includeName
            _includePrefixing = includePrefixing
            _includeSuffixing = includeSuffixing
            _includeDeclare = includeDeclare
        End Sub

        Public Sub New()
            Me.New(String.Empty, String.Empty, String.Empty, String.Empty)
        End Sub

        <ShowInItem(True), ItemName(ITEMNAME_FILENAME)> _
        Public Property IncludeName() As String
            Get
                Return _includeName
            End Get
            Set(ByVal value As String)
                _includeName = value
            End Set
        End Property

        Public Property IncludePrefixing() As String
            Get
                Return _includePrefixing
            End Get
            Set(ByVal value As String)
                _includePrefixing = value
            End Set
        End Property

        Public Property IncludeSuffixing() As String
            Get
                Return _includeSuffixing
            End Get
            Set(ByVal value As String)
                _includeSuffixing = value
            End Set
        End Property

        <ShowInDescription(True), ItemName(ITEMNAME_DECLARE)> _
        Public Property IncludeDeclare() As String
            Get
                Return _includeDeclare
            End Get
            Set(ByVal value As String)
                _includeDeclare = value
            End Set
        End Property

    End Class
End Namespace
