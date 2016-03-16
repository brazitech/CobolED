Namespace Dialogues
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FileExtensionDialog
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
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
            Me._btnOK = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._lblExtension = New System.Windows.Forms.Label
            Me._txtExtensions = New System.Windows.Forms.TextBox
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me._btnOK, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me._btnCancel, 1, 0)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(217, 58)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
            Me.TableLayoutPanel1.TabIndex = 0
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
            '_lblExtension
            '
            Me._lblExtension.AutoSize = True
            Me._lblExtension.Location = New System.Drawing.Point(12, 9)
            Me._lblExtension.Name = "_lblExtension"
            Me._lblExtension.Size = New System.Drawing.Size(0, 12)
            Me._lblExtension.TabIndex = 1
            '
            '_txtExtensions
            '
            Me._txtExtensions.Location = New System.Drawing.Point(14, 28)
            Me._txtExtensions.Name = "_txtExtensions"
            Me._txtExtensions.Size = New System.Drawing.Size(347, 19)
            Me._txtExtensions.TabIndex = 0
            '
            'FileExtensionDialog
            '
            Me.AcceptButton = Me._btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(375, 96)
            Me.Controls.Add(Me._txtExtensions)
            Me.Controls.Add(Me._lblExtension)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FileExtensionDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Analyzer corresponding file extension settings"
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents _btnOK As System.Windows.Forms.Button
        Friend WithEvents _btnCancel As System.Windows.Forms.Button
        Friend WithEvents _lblExtension As System.Windows.Forms.Label
        Friend WithEvents _txtExtensions As System.Windows.Forms.TextBox

    End Class

End Namespace
