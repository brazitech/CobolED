Namespace Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OptionFileExtensionsView
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
            Me._gpbFileExtensions = New System.Windows.Forms.GroupBox
            Me._lblExplication = New System.Windows.Forms.Label
            Me._lsvFileExtensions = New System.Windows.Forms.ListView
            Me._clnAnalyzer = New System.Windows.Forms.ColumnHeader
            Me._clnExtensions = New System.Windows.Forms.ColumnHeader
            Me._gpbFileExtensions.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gpbFileExtensions
            '
            Me._gpbFileExtensions.Controls.Add(Me._lblExplication)
            Me._gpbFileExtensions.Controls.Add(Me._lsvFileExtensions)
            Me._gpbFileExtensions.Location = New System.Drawing.Point(3, 3)
            Me._gpbFileExtensions.Name = "_gpbFileExtensions"
            Me._gpbFileExtensions.Size = New System.Drawing.Size(454, 264)
            Me._gpbFileExtensions.TabIndex = 0
            Me._gpbFileExtensions.TabStop = False
            Me._gpbFileExtensions.Text = "Setting File extension"
            '
            '_lblExplication
            '
            Me._lblExplication.AutoSize = True
            Me._lblExplication.Location = New System.Drawing.Point(6, 245)
            Me._lblExplication.Name = "_lblExplication"
            Me._lblExplication.Size = New System.Drawing.Size(366, 12)
            Me._lblExplication.TabIndex = 1
            Me._lblExplication.Text = "If you want to change the analyzer -related extension , please double- click on the appropriate line."
            '
            '_lsvFileExtensions
            '
            Me._lsvFileExtensions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._clnAnalyzer, Me._clnExtensions})
            Me._lsvFileExtensions.FullRowSelect = True
            Me._lsvFileExtensions.GridLines = True
            Me._lsvFileExtensions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me._lsvFileExtensions.HideSelection = False
            Me._lsvFileExtensions.Location = New System.Drawing.Point(6, 18)
            Me._lsvFileExtensions.MultiSelect = False
            Me._lsvFileExtensions.Name = "_lsvFileExtensions"
            Me._lsvFileExtensions.Size = New System.Drawing.Size(442, 221)
            Me._lsvFileExtensions.TabIndex = 0
            Me._lsvFileExtensions.TileSize = New System.Drawing.Size(200, 16)
            Me._lsvFileExtensions.UseCompatibleStateImageBehavior = False
            Me._lsvFileExtensions.View = System.Windows.Forms.View.Details
            '
            '_clnAnalyzer
            '
            Me._clnAnalyzer.Text = "Analyzer"
            Me._clnAnalyzer.Width = 80
            '
            '_clnExtensions
            '
            Me._clnExtensions.Text = "Related extension"
            Me._clnExtensions.Width = 358
            '
            'OptionFileExtensionsView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me._gpbFileExtensions)
            Me.Name = "OptionFileExtensionsView"
            Me._gpbFileExtensions.ResumeLayout(False)
            Me._gpbFileExtensions.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _gpbFileExtensions As System.Windows.Forms.GroupBox
        Friend WithEvents _lsvFileExtensions As System.Windows.Forms.ListView
        Friend WithEvents _clnAnalyzer As System.Windows.Forms.ColumnHeader
        Friend WithEvents _clnExtensions As System.Windows.Forms.ColumnHeader
        Friend WithEvents _lblExplication As System.Windows.Forms.Label

    End Class
End Namespace