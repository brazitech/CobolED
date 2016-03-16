Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SplashScreenForm
        Inherits System.Windows.Forms.Form

        'Form will override the dispose to clean up the list of components .
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreenForm))
            Me._pnlBorder = New System.Windows.Forms.Panel
            Me._lblLanguage = New System.Windows.Forms.Label
            Me._lblVersionTitle = New System.Windows.Forms.Label
            Me._lblCopyright = New System.Windows.Forms.Label
            Me._gpbSeparator = New System.Windows.Forms.GroupBox
            Me._lblVersion = New System.Windows.Forms.Label
            Me._lblStatus = New System.Windows.Forms.Label
            Me._pcbTitle = New System.Windows.Forms.PictureBox
            Me._lblLicense = New System.Windows.Forms.Label
            Me._pnlBorder.SuspendLayout()
            CType(Me._pcbTitle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_pnlBorder
            '
            Me._pnlBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._pnlBorder.Controls.Add(Me._lblLicense)
            Me._pnlBorder.Controls.Add(Me._lblLanguage)
            Me._pnlBorder.Controls.Add(Me._lblVersionTitle)
            Me._pnlBorder.Controls.Add(Me._lblCopyright)
            Me._pnlBorder.Controls.Add(Me._gpbSeparator)
            Me._pnlBorder.Controls.Add(Me._lblVersion)
            Me._pnlBorder.Controls.Add(Me._lblStatus)
            Me._pnlBorder.Controls.Add(Me._pcbTitle)
            Me._pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill
            Me._pnlBorder.Location = New System.Drawing.Point(0, 0)
            Me._pnlBorder.Name = "_pnlBorder"
            Me._pnlBorder.Size = New System.Drawing.Size(498, 248)
            Me._pnlBorder.TabIndex = 1
            '
            '_lblLanguage
            '
            Me._lblLanguage.AutoSize = True
            Me._lblLanguage.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me._lblLanguage.Location = New System.Drawing.Point(250, 132)
            Me._lblLanguage.Name = "_lblLanguage"
            Me._lblLanguage.Size = New System.Drawing.Size(57, 12)
            Me._lblLanguage.TabIndex = 4
            Me._lblLanguage.Text = "English version"
            '
            '_lblVersionTitle
            '
            Me._lblVersionTitle.AutoSize = True
            Me._lblVersionTitle.BackColor = System.Drawing.Color.Transparent
            Me._lblVersionTitle.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me._lblVersionTitle.Location = New System.Drawing.Point(250, 110)
            Me._lblVersionTitle.Name = "_lblVersionTitle"
            Me._lblVersionTitle.Size = New System.Drawing.Size(55, 12)
            Me._lblVersionTitle.TabIndex = 1
            Me._lblVersionTitle.Text = "Version"
            '
            '_lblCopyright
            '
            Me._lblCopyright.AutoSize = True
            Me._lblCopyright.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me._lblCopyright.Location = New System.Drawing.Point(250, 153)
            Me._lblCopyright.Name = "_lblCopyright"
            Me._lblCopyright.Size = New System.Drawing.Size(67, 12)
            Me._lblCopyright.TabIndex = 3
            Me._lblCopyright.Text = "CopyRight"
            '
            '_gpbSeparator
            '
            Me._gpbSeparator.Dock = System.Windows.Forms.DockStyle.Top
            Me._gpbSeparator.Location = New System.Drawing.Point(0, 0)
            Me._gpbSeparator.Name = "_gpbSeparator"
            Me._gpbSeparator.Size = New System.Drawing.Size(496, 2)
            Me._gpbSeparator.TabIndex = 8
            Me._gpbSeparator.TabStop = False
            '
            '_lblVersion
            '
            Me._lblVersion.AutoSize = True
            Me._lblVersion.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me._lblVersion.Location = New System.Drawing.Point(306, 110)
            Me._lblVersion.Name = "_lblVersion"
            Me._lblVersion.Size = New System.Drawing.Size(51, 12)
            Me._lblVersion.TabIndex = 2
            Me._lblVersion.Text = "Version"
            '
            '_lblStatus
            '
            Me._lblStatus.BackColor = System.Drawing.Color.White
            Me._lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom
            Me._lblStatus.Location = New System.Drawing.Point(0, 223)
            Me._lblStatus.Name = "_lblStatus"
            Me._lblStatus.Size = New System.Drawing.Size(496, 23)
            Me._lblStatus.TabIndex = 5
            Me._lblStatus.Text = "Status..."
            Me._lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_pcbTitle
            '
            Me._pcbTitle.Dock = System.Windows.Forms.DockStyle.Fill
            Me._pcbTitle.Image = CType(resources.GetObject("_pcbTitle.Image"), System.Drawing.Image)
            Me._pcbTitle.Location = New System.Drawing.Point(0, 0)
            Me._pcbTitle.Name = "_pcbTitle"
            Me._pcbTitle.Size = New System.Drawing.Size(496, 246)
            Me._pcbTitle.TabIndex = 0
            Me._pcbTitle.TabStop = False
            '
            '_lblLicense
            '
            Me._lblLicense.BackColor = System.Drawing.Color.White
            Me._lblLicense.Dock = System.Windows.Forms.DockStyle.Bottom
            Me._lblLicense.Location = New System.Drawing.Point(0, 205)
            Me._lblLicense.Name = "_lblLicense"
            Me._lblLicense.Size = New System.Drawing.Size(496, 18)
            Me._lblLicense.TabIndex = 9
            Me._lblLicense.Text = "GNU General Public License(GNU General Public License)"
            Me._lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'SplashScreenForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(498, 248)
            Me.ControlBox = False
            Me.Controls.Add(Me._pnlBorder)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SplashScreenForm"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me._pnlBorder.ResumeLayout(False)
            Me._pnlBorder.PerformLayout()
            CType(Me._pcbTitle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _pnlBorder As System.Windows.Forms.Panel
        Friend WithEvents _lblVersionTitle As System.Windows.Forms.Label
        Friend WithEvents _lblCopyright As System.Windows.Forms.Label
        Friend WithEvents _lblVersion As System.Windows.Forms.Label
        Friend WithEvents _lblLanguage As System.Windows.Forms.Label
        Friend WithEvents _lblStatus As System.Windows.Forms.Label
        Friend WithEvents _gpbSeparator As System.Windows.Forms.GroupBox
        Friend WithEvents _pcbTitle As System.Windows.Forms.PictureBox
        Friend WithEvents _lblLicense As System.Windows.Forms.Label

    End Class
End Namespace