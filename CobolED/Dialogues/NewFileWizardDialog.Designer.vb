Namespace Dialogues
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NewFileWizardDialog
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
            Me._tlpButton = New System.Windows.Forms.TableLayoutPanel
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOK = New System.Windows.Forms.Button
            Me._pnlTitle = New System.Windows.Forms.Panel
            Me._lblDescription = New System.Windows.Forms.Label
            Me._lblTitle = New System.Windows.Forms.Label
            Me._tabCFrame = New System.Windows.Forms.TabControl
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
            Me._tlpButton.Controls.Add(Me._btnCancel, 1, 0)
            Me._tlpButton.Controls.Add(Me._btnOK, 0, 0)
            Me._tlpButton.Location = New System.Drawing.Point(368, 371)
            Me._tlpButton.Name = "_tlpButton"
            Me._tlpButton.RowCount = 1
            Me._tlpButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me._tlpButton.Size = New System.Drawing.Size(146, 27)
            Me._tlpButton.TabIndex = 0
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
            '_btnOK
            '
            Me._btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
            Me._btnOK.Location = New System.Drawing.Point(3, 3)
            Me._btnOK.Name = "_btnOK"
            Me._btnOK.Size = New System.Drawing.Size(67, 21)
            Me._btnOK.TabIndex = 1
            Me._btnOK.Text = "Ok"
            '
            '_pnlTitle
            '
            Me._pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me._pnlTitle.BackgroundImage = Global.CobolED.My.Resources.Resources.Background
            Me._pnlTitle.Controls.Add(Me._lblDescription)
            Me._pnlTitle.Controls.Add(Me._lblTitle)
            Me._pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me._pnlTitle.Location = New System.Drawing.Point(0, 0)
            Me._pnlTitle.Name = "_pnlTitle"
            Me._pnlTitle.Size = New System.Drawing.Size(526, 64)
            Me._pnlTitle.TabIndex = 2
            '
            '_lblDescription
            '
            Me._lblDescription.AutoSize = True
            Me._lblDescription.BackColor = System.Drawing.Color.Transparent
            Me._lblDescription.Location = New System.Drawing.Point(40, 41)
            Me._lblDescription.Name = "_lblDescription"
            Me._lblDescription.Size = New System.Drawing.Size(296, 12)
            Me._lblDescription.TabIndex = 1
            Me._lblDescription.Text = "CobolED Template to create a new file"
            '
            '_lblTitle
            '
            Me._lblTitle.AutoSize = True
            Me._lblTitle.BackColor = System.Drawing.Color.Transparent
            Me._lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me._lblTitle.Location = New System.Drawing.Point(39, 14)
            Me._lblTitle.Name = "_lblTitle"
            Me._lblTitle.Size = New System.Drawing.Size(203, 15)
            Me._lblTitle.TabIndex = 0
            Me._lblTitle.Text = "New file Wizard"
            '
            '_tabCFrame
            '
            Me._tabCFrame.Location = New System.Drawing.Point(0, 67)
            Me._tabCFrame.Name = "_tabCFrame"
            Me._tabCFrame.SelectedIndex = 0
            Me._tabCFrame.Size = New System.Drawing.Size(526, 305)
            Me._tabCFrame.TabIndex = 3
            '
            'NewFileWizardDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(526, 401)
            Me.Controls.Add(Me._tabCFrame)
            Me.Controls.Add(Me._pnlTitle)
            Me.Controls.Add(Me._tlpButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "NewFileWizardDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "New file Wizard"
            Me._tlpButton.ResumeLayout(False)
            Me._pnlTitle.ResumeLayout(False)
            Me._pnlTitle.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _tlpButton As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents _btnOK As System.Windows.Forms.Button
        Friend WithEvents _btnCancel As System.Windows.Forms.Button
        Friend WithEvents _pnlTitle As System.Windows.Forms.Panel
        Friend WithEvents _lblDescription As System.Windows.Forms.Label
        Friend WithEvents _lblTitle As System.Windows.Forms.Label
        Friend WithEvents _tabCFrame As System.Windows.Forms.TabControl

    End Class
End Namespace