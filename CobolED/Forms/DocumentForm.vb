'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  DocumentForm.vb                                         --
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

Imports CobolEDCore.Document
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Interfaces.Editor
Imports CobolED.Managers


Namespace Forms

    Public Class DocumentForm

        Private WithEvents _document As Document
        Private WithEvents _cobolEdEditor As ICobolEDEditor

        Public Sub New(ByVal cobolEdEditor As ICobolEDEditor)
            InitializeComponent()
            _document = cobolEDEditor.Document
            _cobolEDEditor = cobolEDEditor
            _cobolEDEditor.Location = New Point(0, 0)
            _cobolEDEditor.Dock = DockStyle.Fill
            Me.Controls.Add(_cobolEDEditor)

        End Sub

        Public ReadOnly Property CobolEdEditor() As ICobolEDEditor
            Get
                Return Me._cobolEDEditor
            End Get
        End Property

        Public ReadOnly Property Document() As Document
            Get
                Return _document
            End Get
        End Property

    End Class

End Namespace