Namespace Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OptionColorView
        Inherits OptionViewBase

        'UserControl overrides dispose to clean up the component list .
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'It is required by the Windows Form Designer .
        Private components As System.ComponentModel.IContainer

        'Note : The following procedure It is required by the Windows Form Designer.
        'It can be changed using the Windows Forms Designer . 
        'Please do not change with the code editor .
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me._lsbColorItem = New System.Windows.Forms.ListBox
            Me._lblColorItem = New System.Windows.Forms.Label
            Me._btnCustom = New System.Windows.Forms.Button
            Me._lblSample = New System.Windows.Forms.Label
            Me._lblSampleTile = New System.Windows.Forms.Label
            Me._gpbColor = New System.Windows.Forms.GroupBox
            Me._cboColor = New CobolED.UserControls.ColorComboBox
            Me._lblColor = New System.Windows.Forms.Label
            Me._dlgColorDialog = New System.Windows.Forms.ColorDialog
            Me._gpbColor.SuspendLayout()
            Me.SuspendLayout()
            '
            '_lsbColorItem
            '
            Me._lsbColorItem.FormattingEnabled = True
            Me._lsbColorItem.ItemHeight = 12
            Me._lsbColorItem.Location = New System.Drawing.Point(8, 30)
            Me._lsbColorItem.Name = "_lsbColorItem"
            Me._lsbColorItem.ScrollAlwaysVisible = True
            Me._lsbColorItem.Size = New System.Drawing.Size(133, 76)
            Me._lsbColorItem.TabIndex = 0
            '
            '_lblColorItem
            '
            Me._lblColorItem.AutoSize = True
            Me._lblColorItem.Location = New System.Drawing.Point(6, 15)
            Me._lblColorItem.Name = "_lblColorItem"
            Me._lblColorItem.Size = New System.Drawing.Size(59, 12)
            Me._lblColorItem.TabIndex = 1
            Me._lblColorItem.Text = "Indicates that the project :"
            '
            '_btnCustom
            '
            Me._btnCustom.Location = New System.Drawing.Point(276, 30)
            Me._btnCustom.Name = "_btnCustom"
            Me._btnCustom.Size = New System.Drawing.Size(75, 23)
            Me._btnCustom.TabIndex = 2
            Me._btnCustom.Text = "Custom  ,,,"
            Me._btnCustom.UseVisualStyleBackColor = True
            '
            '_lblSample
            '
            Me._lblSample.BackColor = System.Drawing.Color.White
            Me._lblSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me._lblSample.Location = New System.Drawing.Point(147, 77)
            Me._lblSample.Name = "_lblSample"
            Me._lblSample.Size = New System.Drawing.Size(202, 29)
            Me._lblSample.TabIndex = 4
            Me._lblSample.Text = "AaBbCcXxYyZz"
            Me._lblSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            '_lblSampleTile
            '
            Me._lblSampleTile.AutoSize = True
            Me._lblSampleTile.Location = New System.Drawing.Point(147, 65)
            Me._lblSampleTile.Name = "_lblSampleTile"
            Me._lblSampleTile.Size = New System.Drawing.Size(49, 12)
            Me._lblSampleTile.TabIndex = 5
            Me._lblSampleTile.Text = "sample:"
            '
            '_gpbColor
            '
            Me._gpbColor.AccessibleRole = System.Windows.Forms.AccessibleRole.None
            Me._gpbColor.Controls.Add(Me._cboColor)
            Me._gpbColor.Controls.Add(Me._lblColor)
            Me._gpbColor.Controls.Add(Me._lsbColorItem)
            Me._gpbColor.Controls.Add(Me._btnCustom)
            Me._gpbColor.Controls.Add(Me._lblSampleTile)
            Me._gpbColor.Controls.Add(Me._lblColorItem)
            Me._gpbColor.Controls.Add(Me._lblSample)
            Me._gpbColor.Location = New System.Drawing.Point(3, 3)
            Me._gpbColor.Name = "_gpbColor"
            Me._gpbColor.Size = New System.Drawing.Size(454, 117)
            Me._gpbColor.TabIndex = 6
            Me._gpbColor.TabStop = False
            Me._gpbColor.Text = "Color settings of the text"
            '
            '_cboColor
            '
            Me._cboColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me._cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cboColor.FormattingEnabled = True
            Me._cboColor.Location = New System.Drawing.Point(149, 30)
            Me._cboColor.Name = "_cboColor"
            Me._cboColor.Size = New System.Drawing.Size(121, 20)
            Me._cboColor.TabIndex = 9
            '
            '_lblColor
            '
            Me._lblColor.AutoSize = True
            Me._lblColor.Location = New System.Drawing.Point(147, 15)
            Me._lblColor.Name = "_lblColor"
            Me._lblColor.Size = New System.Drawing.Size(38, 12)
            Me._lblColor.TabIndex = 7
            Me._lblColor.Text = "Color:"
            '
            'OptionColorView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me._gpbColor)
            Me.Name = "OptionColorView"
            Me._gpbColor.ResumeLayout(False)
            Me._gpbColor.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _lsbColorItem As System.Windows.Forms.ListBox
        Friend WithEvents _lblColorItem As System.Windows.Forms.Label
        Friend WithEvents _btnCustom As System.Windows.Forms.Button
        Friend WithEvents _lblSample As System.Windows.Forms.Label
        Friend WithEvents _lblSampleTile As System.Windows.Forms.Label
        Friend WithEvents _gpbColor As System.Windows.Forms.GroupBox
        Friend WithEvents _lblColor As System.Windows.Forms.Label
        Friend WithEvents _dlgColorDialog As System.Windows.Forms.ColorDialog
        Friend WithEvents _cboColor As CobolED.UserControls.ColorComboBox

    End Class
End Namespace