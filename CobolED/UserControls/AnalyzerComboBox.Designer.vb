Namespace UserControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AnalyzerComboBox
        Inherits System.Windows.Forms.UserControl

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
            Me._lblTitle = New System.Windows.Forms.Label
            Me._cmbAnalyzer = New System.Windows.Forms.ComboBox
            Me._pnlAnalyzer = New System.Windows.Forms.Panel
            Me._pnlAnalyzer.SuspendLayout()
            Me.SuspendLayout()
            '
            '_lblTitle
            '
            Me._lblTitle.AutoSize = True
            Me._lblTitle.Location = New System.Drawing.Point(25, 8)
            Me._lblTitle.Name = "_lblTitle"
            Me._lblTitle.Size = New System.Drawing.Size(69, 12)
            Me._lblTitle.TabIndex = 0
            Me._lblTitle.Text = "analyzer(&A):"
            '
            '_cmbAnalyzer
            '
            Me._cmbAnalyzer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbAnalyzer.FormattingEnabled = True
            Me._cmbAnalyzer.Location = New System.Drawing.Point(137, 4)
            Me._cmbAnalyzer.Name = "_cmbAnalyzer"
            Me._cmbAnalyzer.Size = New System.Drawing.Size(288, 20)
            Me._cmbAnalyzer.TabIndex = 1
            '
            '_pnlAnalyzer
            '
            Me._pnlAnalyzer.Controls.Add(Me._cmbAnalyzer)
            Me._pnlAnalyzer.Controls.Add(Me._lblTitle)
            Me._pnlAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill
            Me._pnlAnalyzer.Location = New System.Drawing.Point(0, 0)
            Me._pnlAnalyzer.Name = "_pnlAnalyzer"
            Me._pnlAnalyzer.Size = New System.Drawing.Size(434, 31)
            Me._pnlAnalyzer.TabIndex = 3
            '
            'AnalyzerComboBox
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me._pnlAnalyzer)
            Me.Name = "AnalyzerComboBox"
            Me.Size = New System.Drawing.Size(434, 31)
            Me._pnlAnalyzer.ResumeLayout(False)
            Me._pnlAnalyzer.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _lblTitle As System.Windows.Forms.Label
        Friend WithEvents _cmbAnalyzer As System.Windows.Forms.ComboBox
        Friend WithEvents _pnlAnalyzer As System.Windows.Forms.Panel

    End Class
End Namespace