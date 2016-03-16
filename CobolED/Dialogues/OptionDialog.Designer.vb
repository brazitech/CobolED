Namespace Dialogues
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OptionDialog
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
            Me._btnCancel = New System.Windows.Forms.Button
            Me._trvItems = New System.Windows.Forms.TreeView
            Me._gpbLine = New System.Windows.Forms.GroupBox
            Me._btnOK = New System.Windows.Forms.Button
            Me._btnDefault = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            '_btnCancel
            '
            Me._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.Location = New System.Drawing.Point(592, 295)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(67, 21)
            Me._btnCancel.TabIndex = 1
            Me._btnCancel.Text = "Cancel"
            '
            '_trvItems
            '
            Me._trvItems.Location = New System.Drawing.Point(12, 12)
            Me._trvItems.Name = "_trvItems"
            Me._trvItems.Size = New System.Drawing.Size(182, 276)
            Me._trvItems.TabIndex = 1
            '
            '_gpbLine
            '
            Me._gpbLine.Location = New System.Drawing.Point(203, 286)
            Me._gpbLine.Name = "_gpbLine"
            Me._gpbLine.Size = New System.Drawing.Size(456, 2)
            Me._gpbLine.TabIndex = 2
            Me._gpbLine.TabStop = False
            '
            '_btnOK
            '
            Me._btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
            Me._btnOK.Location = New System.Drawing.Point(519, 295)
            Me._btnOK.Name = "_btnOK"
            Me._btnOK.Size = New System.Drawing.Size(67, 21)
            Me._btnOK.TabIndex = 0
            Me._btnOK.Text = "OK"
            '
            '_btnDefault
            '
            Me._btnDefault.Anchor = System.Windows.Forms.AnchorStyles.None
            Me._btnDefault.Location = New System.Drawing.Point(446, 295)
            Me._btnDefault.Name = "_btnDefault"
            Me._btnDefault.Size = New System.Drawing.Size(67, 21)
            Me._btnDefault.TabIndex = 3
            Me._btnDefault.Text = "default"
            Me._btnDefault.UseVisualStyleBackColor = True
            '
            'OptionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(671, 324)
            Me.Controls.Add(Me._btnDefault)
            Me.Controls.Add(Me._btnOK)
            Me.Controls.Add(Me._gpbLine)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._trvItems)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "OptionDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "option"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _btnCancel As System.Windows.Forms.Button
        Friend WithEvents _trvItems As System.Windows.Forms.TreeView
        Friend WithEvents _gpbLine As System.Windows.Forms.GroupBox
        Friend WithEvents _btnOK As System.Windows.Forms.Button
        Friend WithEvents _btnDefault As System.Windows.Forms.Button

    End Class
End Namespace