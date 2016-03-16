Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AboutForm
        Inherits System.Windows.Forms.Form

        'Form will override the dispose to clean up the list of components .
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
            Me._pcbLogo = New System.Windows.Forms.PictureBox
            Me._lblProductName = New System.Windows.Forms.Label
            Me._btnOK = New System.Windows.Forms.Button
            Me._lblVersion = New System.Windows.Forms.Label
            Me._lblCopyright = New System.Windows.Forms.Label
            Me._gpbReference = New System.Windows.Forms.GroupBox
            Me._lsvReference = New System.Windows.Forms.ListView
            Me._clhAssembly = New System.Windows.Forms.ColumnHeader
            Me._clhVersion = New System.Windows.Forms.ColumnHeader
            Me._lblVersionTitle = New System.Windows.Forms.Label
            Me._lblMemoryTitle = New System.Windows.Forms.Label
            Me._lblMemory = New System.Windows.Forms.Label
            Me._pnlInformation = New System.Windows.Forms.Panel
            Me._lblLicense = New System.Windows.Forms.Label
            Me._gpbSplitterLine = New System.Windows.Forms.GroupBox
            CType(Me._pcbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gpbReference.SuspendLayout()
            Me._pnlInformation.SuspendLayout()
            Me.SuspendLayout()
            '
            '_pcbLogo
            '
            Me._pcbLogo.BackColor = System.Drawing.Color.Transparent
            Me._pcbLogo.Image = Global.CobolED.My.Resources.Resources.CobolED80
            Me._pcbLogo.Location = New System.Drawing.Point(5, 3)
            Me._pcbLogo.Name = "_pcbLogo"
            Me._pcbLogo.Size = New System.Drawing.Size(80, 80)
            Me._pcbLogo.TabIndex = 0
            Me._pcbLogo.TabStop = False
            '
            '_lblProductName
            '
            Me._lblProductName.AutoSize = True
            Me._lblProductName.BackColor = System.Drawing.Color.Transparent
            Me._lblProductName.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me._lblProductName.Location = New System.Drawing.Point(89, 3)
            Me._lblProductName.Name = "_lblProductName"
            Me._lblProductName.Size = New System.Drawing.Size(130, 19)
            Me._lblProductName.TabIndex = 1
            Me._lblProductName.Text = "ProductName"
            '
            '_btnOK
            '
            Me._btnOK.Location = New System.Drawing.Point(365, 221)
            Me._btnOK.Name = "_btnOK"
            Me._btnOK.Size = New System.Drawing.Size(75, 23)
            Me._btnOK.TabIndex = 2
            Me._btnOK.Text = "OK"
            Me._btnOK.UseVisualStyleBackColor = True
            '
            '_lblVersion
            '
            Me._lblVersion.AutoSize = True
            Me._lblVersion.BackColor = System.Drawing.Color.Transparent
            Me._lblVersion.Location = New System.Drawing.Point(147, 39)
            Me._lblVersion.Name = "_lblVersion"
            Me._lblVersion.Size = New System.Drawing.Size(44, 12)
            Me._lblVersion.TabIndex = 3
            Me._lblVersion.Text = "Version"
            '
            '_lblCopyright
            '
            Me._lblCopyright.AutoSize = True
            Me._lblCopyright.BackColor = System.Drawing.Color.Transparent
            Me._lblCopyright.Location = New System.Drawing.Point(91, 68)
            Me._lblCopyright.Name = "_lblCopyright"
            Me._lblCopyright.Size = New System.Drawing.Size(54, 12)
            Me._lblCopyright.TabIndex = 4
            Me._lblCopyright.Text = "Copyright"
            '
            '_gpbReference
            '
            Me._gpbReference.Controls.Add(Me._lsvReference)
            Me._gpbReference.Location = New System.Drawing.Point(12, 97)
            Me._gpbReference.Name = "_gpbReference"
            Me._gpbReference.Size = New System.Drawing.Size(428, 118)
            Me._gpbReference.TabIndex = 5
            Me._gpbReference.TabStop = False
            Me._gpbReference.Text = "Reference"
            '
            '_lsvReference
            '
            Me._lsvReference.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._clhAssembly, Me._clhVersion})
            Me._lsvReference.GridLines = True
            Me._lsvReference.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me._lsvReference.Location = New System.Drawing.Point(6, 15)
            Me._lsvReference.Name = "_lsvReference"
            Me._lsvReference.Size = New System.Drawing.Size(416, 97)
            Me._lsvReference.TabIndex = 0
            Me._lsvReference.UseCompatibleStateImageBehavior = False
            Me._lsvReference.View = System.Windows.Forms.View.Details
            '
            '_clhAssembly
            '
            Me._clhAssembly.Text = "Assembly"
            Me._clhAssembly.Width = 250
            '
            '_clhVersion
            '
            Me._clhVersion.Text = "Version"
            Me._clhVersion.Width = 162
            '
            '_lblVersionTitle
            '
            Me._lblVersionTitle.AutoSize = True
            Me._lblVersionTitle.BackColor = System.Drawing.Color.Transparent
            Me._lblVersionTitle.Location = New System.Drawing.Point(91, 39)
            Me._lblVersionTitle.Name = "_lblVersionTitle"
            Me._lblVersionTitle.Size = New System.Drawing.Size(50, 12)
            Me._lblVersionTitle.TabIndex = 6
            Me._lblVersionTitle.Text = "Version"
            '
            '_lblMemoryTitle
            '
            Me._lblMemoryTitle.AutoSize = True
            Me._lblMemoryTitle.Location = New System.Drawing.Point(16, 226)
            Me._lblMemoryTitle.Name = "_lblMemoryTitle"
            Me._lblMemoryTitle.Size = New System.Drawing.Size(105, 12)
            Me._lblMemoryTitle.TabIndex = 7
            Me._lblMemoryTitle.Text = "Memory"
            '
            '_lblMemory
            '
            Me._lblMemory.AutoSize = True
            Me._lblMemory.Location = New System.Drawing.Point(127, 226)
            Me._lblMemory.Name = "_lblMemory"
            Me._lblMemory.Size = New System.Drawing.Size(45, 12)
            Me._lblMemory.TabIndex = 8
            Me._lblMemory.Text = "Memory"
            '
            '_pnlInformation
            '
            Me._pnlInformation.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me._pnlInformation.BackgroundImage = Global.CobolED.My.Resources.Resources.Background
            Me._pnlInformation.Controls.Add(Me._pcbLogo)
            Me._pnlInformation.Controls.Add(Me._lblProductName)
            Me._pnlInformation.Controls.Add(Me._lblVersion)
            Me._pnlInformation.Controls.Add(Me._lblVersionTitle)
            Me._pnlInformation.Controls.Add(Me._lblCopyright)
            Me._pnlInformation.Location = New System.Drawing.Point(0, 0)
            Me._pnlInformation.Name = "_pnlInformation"
            Me._pnlInformation.Size = New System.Drawing.Size(453, 91)
            Me._pnlInformation.TabIndex = 9
            '
            '_lblLicense
            '
            Me._lblLicense.AutoSize = True
            Me._lblLicense.Location = New System.Drawing.Point(10, 265)
            Me._lblLicense.Name = "_lblLicense"
            Me._lblLicense.Size = New System.Drawing.Size(416, 12)
            Me._lblLicense.TabIndex = 7
            Me._lblLicense.Text = "GNU General Public License(GNU General Public License)"
            '
            '_gpbSplitterLine
            '
            Me._gpbSplitterLine.Location = New System.Drawing.Point(12, 250)
            Me._gpbSplitterLine.Name = "_gpbSplitterLine"
            Me._gpbSplitterLine.Size = New System.Drawing.Size(427, 4)
            Me._gpbSplitterLine.TabIndex = 10
            Me._gpbSplitterLine.TabStop = False
            '
            'AboutForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(452, 285)
            Me.Controls.Add(Me._gpbSplitterLine)
            Me.Controls.Add(Me._lblLicense)
            Me.Controls.Add(Me._pnlInformation)
            Me.Controls.Add(Me._lblMemory)
            Me.Controls.Add(Me._lblMemoryTitle)
            Me.Controls.Add(Me._gpbReference)
            Me.Controls.Add(Me._btnOK)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AboutForm"
            Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "AboutForm"
            CType(Me._pcbLogo, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gpbReference.ResumeLayout(False)
            Me._pnlInformation.ResumeLayout(False)
            Me._pnlInformation.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents _pcbLogo As System.Windows.Forms.PictureBox
        Friend WithEvents _lblProductName As System.Windows.Forms.Label
        Friend WithEvents _btnOK As System.Windows.Forms.Button
        Friend WithEvents _lblVersion As System.Windows.Forms.Label
        Friend WithEvents _lblCopyright As System.Windows.Forms.Label
        Friend WithEvents _gpbReference As System.Windows.Forms.GroupBox
        Friend WithEvents _lsvReference As System.Windows.Forms.ListView
        Friend WithEvents _lblVersionTitle As System.Windows.Forms.Label
        Friend WithEvents _clhAssembly As System.Windows.Forms.ColumnHeader
        Friend WithEvents _clhVersion As System.Windows.Forms.ColumnHeader
        Friend WithEvents _lblMemoryTitle As System.Windows.Forms.Label
        Friend WithEvents _lblMemory As System.Windows.Forms.Label
        Friend WithEvents _pnlInformation As System.Windows.Forms.Panel
        Friend WithEvents _lblLicense As System.Windows.Forms.Label
        Friend WithEvents _gpbSplitterLine As System.Windows.Forms.GroupBox

    End Class

End Namespace