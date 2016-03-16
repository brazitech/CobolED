'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ColorComboBox.vb                                        --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
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
    Public Class ColorComboBox
        Inherits ComboBox

        Public Sub New()
            MyBase.New()
            Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
            Me.DropDownStyle = ComboBoxStyle.DropDownList
            Me.Items.Clear()
        End Sub

        Public ReadOnly Property Item(ByVal index As Integer) As ColorComboBoxItem
            Get
                If index < 0 OrElse index > Me.Items.Count - 1 OrElse Not TypeOf Me.Items(index) Is ColorComboBoxItem Then
                    Return Nothing
                Else
                    Return DirectCast(Me.Items(index), ColorComboBoxItem)
                End If
            End Get
        End Property

        Public Function AddItem(ByVal color As Color, ByVal text As String) As Integer
            Return Me.Items.Add(New ColorComboBoxItem(color, text))
        End Function

        Private Sub ColorComboBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
            Dim graphics As Graphics
            Dim item As ColorComboBoxItem

            If e.Index >= 0 AndAlso e.Index <= Me.Items.Count - 1 AndAlso TypeOf Me.Items(e.Index) Is ColorComboBoxItem Then
                graphics = e.Graphics
                item = DirectCast(Me.Items(e.Index), ColorComboBoxItem)

                e.DrawBackground()
                graphics.FillRectangle(New SolidBrush(item.Color), _
                                       New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 10, 10))
                graphics.DrawString(item.Text, Me.Font, Brushes.Black, e.Bounds.X + 14, e.Bounds.Y)
                e.DrawFocusRectangle()
            Else
            End If
        End Sub

    End Class
End Namespace