'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  AnalyzerComboBox.vb                                     --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                           --
'--                                                                           --
'--  NameSpace     :  CobolED.UserControls                                    --
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

Namespace UserControls
    Public Class AnalyzerComboBox

        Public Sub New()

            ' This call is required by the Windows Form Designer .
            InitializeComponent()

            ' Add the initialization after the InitializeComponent () call .

            Me._cmbAnalyzer.Items.Clear()

        End Sub

        Public Property Analyzer() As String

            Get
                Return Me._cmbAnalyzer.Text
            End Get

            Set(ByVal value As String)
                Me._cmbAnalyzer.Text = value
            End Set
        End Property

        Public Sub AddItem(ByVal item As String)
            Me._cmbAnalyzer.Items.Add(item)
        End Sub

    End Class
End Namespace
