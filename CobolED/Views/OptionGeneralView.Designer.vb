Namespace Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OptionGeneralView
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
            Me._lblRecentProjectCount = New System.Windows.Forms.Label
            Me._numProjectFileCount = New System.Windows.Forms.NumericUpDown
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me._lblRecentFileCount = New System.Windows.Forms.Label
            Me._numFileCount = New System.Windows.Forms.NumericUpDown
            CType(Me._numProjectFileCount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me._numFileCount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_lblRecentProjectCount
            '
            Me._lblRecentProjectCount.AutoSize = True
            Me._lblRecentProjectCount.Location = New System.Drawing.Point(71, 26)
            Me._lblRecentProjectCount.Name = "_lblRecentProjectCount"
            Me._lblRecentProjectCount.Size = New System.Drawing.Size(183, 12)
            Me._lblRecentProjectCount.TabIndex = 0
            Me._lblRecentProjectCount.Text = "Recent number of open projects"
            '
            '_numProjectFileCount
            '
            Me._numProjectFileCount.Location = New System.Drawing.Point(19, 24)
            Me._numProjectFileCount.Name = "_numProjectFileCount"
            Me._numProjectFileCount.Size = New System.Drawing.Size(46, 19)
            Me._numProjectFileCount.TabIndex = 1
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me._lblRecentFileCount)
            Me.GroupBox1.Controls.Add(Me._lblRecentProjectCount)
            Me.GroupBox1.Controls.Add(Me._numFileCount)
            Me.GroupBox1.Controls.Add(Me._numProjectFileCount)
            Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(454, 80)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Recent ProjectsとFile"
            '
            '_lblRecentFileCount
            '
            Me._lblRecentFileCount.AutoSize = True
            Me._lblRecentFileCount.Location = New System.Drawing.Point(71, 51)
            Me._lblRecentFileCount.Name = "_lblRecentFileCount"
            Me._lblRecentFileCount.Size = New System.Drawing.Size(166, 12)
            Me._lblRecentFileCount.TabIndex = 3
            Me._lblRecentFileCount.Text = "Number of Recently Opened Files"
            '
            '_numFileCount
            '
            Me._numFileCount.Location = New System.Drawing.Point(19, 49)
            Me._numFileCount.Name = "_numFileCount"
            Me._numFileCount.Size = New System.Drawing.Size(46, 19)
            Me._numFileCount.TabIndex = 4
            '
            'OptionGeneralView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.GroupBox1)
            Me.Name = "OptionGeneralView"
            CType(Me._numProjectFileCount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me._numFileCount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _lblRecentProjectCount As System.Windows.Forms.Label
        Friend WithEvents _numProjectFileCount As System.Windows.Forms.NumericUpDown
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents _lblRecentFileCount As System.Windows.Forms.Label
        Friend WithEvents _numFileCount As System.Windows.Forms.NumericUpDown

    End Class
End Namespace