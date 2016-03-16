Namespace Dialogues
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NewProjectDialog
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me._tlpButton = New System.Windows.Forms.TableLayoutPanel
            Me._btnOK = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._lblTitle = New System.Windows.Forms.Label
            Me._lblDescription = New System.Windows.Forms.Label
            Me._btnBrowse = New System.Windows.Forms.Button
            Me._cmbProjectFolderName = New System.Windows.Forms.ComboBox
            Me._lblProjectFolder = New System.Windows.Forms.Label
            Me._txtProjectName = New System.Windows.Forms.TextBox
            Me._lblProjectName = New System.Windows.Forms.Label
            Me._folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
            Me._pnlTitle = New System.Windows.Forms.Panel
            Me._tlpButton.SuspendLayout()
            Me._pnlTitle.SuspendLayout()
            Me.SuspendLayout()
            '
            '_tlpButton
            '
            Me._tlpButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._tlpButton.ColumnCount = 2
            Me._tlpButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me._tlpButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me._tlpButton.Controls.Add(Me._btnOK, 0, 0)
            Me._tlpButton.Controls.Add(Me._btnCancel, 1, 0)
            Me._tlpButton.Location = New System.Drawing.Point(397, 260)
            Me._tlpButton.Name = "_tlpButton"
            Me._tlpButton.RowCount = 1
            Me._tlpButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me._tlpButton.Size = New System.Drawing.Size(146, 27)
            Me._tlpButton.TabIndex = 0
            '
            '_btnOK
            '
            Me._btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
            Me._btnOK.Location = New System.Drawing.Point(3, 3)
            Me._btnOK.Name = "_btnOK"
            Me._btnOK.Size = New System.Drawing.Size(67, 21)
            Me._btnOK.TabIndex = 0
            Me._btnOK.Text = "OK"
            '
            '_btnCancel
            '
            Me._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.Location = New System.Drawing.Point(76, 3)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(67, 21)
            Me._btnCancel.TabIndex = 1
            Me._btnCancel.Text = "Cancel"
            '
            '_lblTitle
            '
            Me._lblTitle.AutoSize = True
            Me._lblTitle.BackColor = System.Drawing.Color.Transparent
            Me._lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me._lblTitle.Location = New System.Drawing.Point(33, 13)
            Me._lblTitle.Name = "_lblTitle"
            Me._lblTitle.Size = New System.Drawing.Size(131, 15)
            Me._lblTitle.TabIndex = 1
            Me._lblTitle.Text = "New Project"
            '
            '_lblDescription
            '
            Me._lblDescription.AutoSize = True
            Me._lblDescription.BackColor = System.Drawing.Color.Transparent
            Me._lblDescription.Location = New System.Drawing.Point(34, 37)
            Me._lblDescription.Name = "_lblDescription"
            Me._lblDescription.Size = New System.Drawing.Size(233, 12)
            Me._lblDescription.TabIndex = 2
            Me._lblDescription.Text = "New CobolED project to create."
            '
            '_btnBrowse
            '
            Me._btnBrowse.Location = New System.Drawing.Point(453, 140)
            Me._btnBrowse.Name = "_btnBrowse"
            Me._btnBrowse.Size = New System.Drawing.Size(75, 20)
            Me._btnBrowse.TabIndex = 10
            Me._btnBrowse.Text = "Browse"
            Me._btnBrowse.UseVisualStyleBackColor = True
            '
            '_cmbProjectFolderName
            '
            Me._cmbProjectFolderName.FormattingEnabled = True
            Me._cmbProjectFolderName.Location = New System.Drawing.Point(98, 140)
            Me._cmbProjectFolderName.Name = "_cmbProjectFolderName"
            Me._cmbProjectFolderName.Size = New System.Drawing.Size(345, 20)
            Me._cmbProjectFolderName.TabIndex = 9
            '
            '_lblProjectFolder
            '
            Me._lblProjectFolder.AutoSize = True
            Me._lblProjectFolder.Location = New System.Drawing.Point(12, 144)
            Me._lblProjectFolder.Name = "_lblProjectFolder"
            Me._lblProjectFolder.Size = New System.Drawing.Size(29, 12)
            Me._lblProjectFolder.TabIndex = 8
            Me._lblProjectFolder.Text = "Folder"
            '
            '_txtProjectName
            '
            Me._txtProjectName.Location = New System.Drawing.Point(98, 105)
            Me._txtProjectName.Name = "_txtProjectName"
            Me._txtProjectName.Size = New System.Drawing.Size(430, 19)
            Me._txtProjectName.TabIndex = 7
            '
            '_lblProjectName
            '
            Me._lblProjectName.AutoSize = True
            Me._lblProjectName.Location = New System.Drawing.Point(12, 108)
            Me._lblProjectName.Name = "_lblProjectName"
            Me._lblProjectName.Size = New System.Drawing.Size(68, 12)
            Me._lblProjectName.TabIndex = 6
            Me._lblProjectName.Text = "Project"
            '
            '_folderBrowserDialog
            '
            Me._folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer
            '
            '_pnlTitle
            '
            Me._pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me._pnlTitle.BackgroundImage = Global.CobolED.My.Resources.Resources.Background
            Me._pnlTitle.Controls.Add(Me._lblTitle)
            Me._pnlTitle.Controls.Add(Me._lblDescription)
            Me._pnlTitle.Location = New System.Drawing.Point(0, 0)
            Me._pnlTitle.Name = "_pnlTitle"
            Me._pnlTitle.Size = New System.Drawing.Size(555, 64)
            Me._pnlTitle.TabIndex = 3
            '
            'NewProjectDialog
            '
            Me.AcceptButton = Me._btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(555, 298)
            Me.Controls.Add(Me._btnBrowse)
            Me.Controls.Add(Me._cmbProjectFolderName)
            Me.Controls.Add(Me._lblProjectFolder)
            Me.Controls.Add(Me._txtProjectName)
            Me.Controls.Add(Me._lblProjectName)
            Me.Controls.Add(Me._pnlTitle)
            Me.Controls.Add(Me._tlpButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "NewProjectDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "New project"
            Me._tlpButton.ResumeLayout(False)
            Me._pnlTitle.ResumeLayout(False)
            Me._pnlTitle.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents _tlpButton As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents _btnOK As System.Windows.Forms.Button
        Friend WithEvents _btnCancel As System.Windows.Forms.Button
        Friend WithEvents _lblTitle As System.Windows.Forms.Label
        Friend WithEvents _lblDescription As System.Windows.Forms.Label
        Friend WithEvents _btnBrowse As System.Windows.Forms.Button
        Friend WithEvents _cmbProjectFolderName As System.Windows.Forms.ComboBox
        Friend WithEvents _lblProjectFolder As System.Windows.Forms.Label
        Friend WithEvents _txtProjectName As System.Windows.Forms.TextBox
        Friend WithEvents _lblProjectName As System.Windows.Forms.Label
        Friend WithEvents _folderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
        Friend WithEvents _pnlTitle As System.Windows.Forms.Panel

    End Class

End Namespace