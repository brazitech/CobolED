Namespace Dialogues
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JumpDialog
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
            Me._btnOK = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._lblLineNO = New System.Windows.Forms.Label
            Me._txtLineNO = New System.Windows.Forms.TextBox
            Me._tlpButton.SuspendLayout()
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
            Me._tlpButton.Location = New System.Drawing.Point(66, 51)
            Me._tlpButton.Name = "_tlpButton"
            Me._tlpButton.RowCount = 1
            Me._tlpButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me._tlpButton.Size = New System.Drawing.Size(146, 27)
            Me._tlpButton.TabIndex = 1
            '
            '_btnOK
            '
            Me._btnOK.Anchor = System.Windows.Forms.AnchorStyles.None
            Me._btnOK.Location = New System.Drawing.Point(3, 3)
            Me._btnOK.Name = "_btnOK"
            Me._btnOK.Size = New System.Drawing.Size(67, 21)
            Me._btnOK.TabIndex = 1
            Me._btnOK.Text = "OK"
            '
            '_btnCancel
            '
            Me._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.Location = New System.Drawing.Point(76, 3)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(67, 21)
            Me._btnCancel.TabIndex = 2
            Me._btnCancel.Text = "Cancel"
            '
            '_lblLineNO
            '
            Me._lblLineNO.AutoSize = True
            Me._lblLineNO.Location = New System.Drawing.Point(12, 9)
            Me._lblLineNO.Name = "_lblLineNO"
            Me._lblLineNO.Size = New System.Drawing.Size(41, 12)
            Me._lblLineNO.TabIndex = 1
            Me._lblLineNO.Text = "Row番号"
            '
            '_txtLineNO
            '
            Me._txtLineNO.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"})
            Me._txtLineNO.Location = New System.Drawing.Point(12, 24)
            Me._txtLineNO.Name = "_txtLineNO"
            Me._txtLineNO.Size = New System.Drawing.Size(198, 19)
            Me._txtLineNO.TabIndex = 0
            '
            'JumpDialog
            '
            Me.AcceptButton = Me._btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(224, 89)
            Me.Controls.Add(Me._txtLineNO)
            Me.Controls.Add(Me._lblLineNO)
            Me.Controls.Add(Me._tlpButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "JumpDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "GoTo line"
            Me._tlpButton.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents _tlpButton As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents _btnOK As System.Windows.Forms.Button
        Friend WithEvents _btnCancel As System.Windows.Forms.Button
        Friend WithEvents _lblLineNO As System.Windows.Forms.Label
        Friend WithEvents _txtLineNO As System.Windows.Forms.TextBox

    End Class
End Namespace