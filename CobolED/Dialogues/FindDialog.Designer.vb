Namespace Dialogues
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FindDialog
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
            Me._lblFindString = New System.Windows.Forms.Label
            Me._cmbFindString = New System.Windows.Forms.ComboBox
            Me._btnFindNext = New System.Windows.Forms.Button
            Me._pnlFind = New System.Windows.Forms.Panel
            Me._pnlReplace = New System.Windows.Forms.Panel
            Me._btnReplace = New System.Windows.Forms.Button
            Me._cmbReplaceString = New System.Windows.Forms.ComboBox
            Me._lblReplaceString = New System.Windows.Forms.Label
            Me._btnClose = New System.Windows.Forms.Button
            Me._chkFindPrev = New System.Windows.Forms.CheckBox
            Me._chkFindWithWord = New System.Windows.Forms.CheckBox
            Me._chkFindWithCaps = New System.Windows.Forms.CheckBox
            Me._grpFindArea = New System.Windows.Forms.GroupBox
            Me._optFindInNowProject = New System.Windows.Forms.RadioButton
            Me._optFindInOpenDocs = New System.Windows.Forms.RadioButton
            Me._optFindInNowDoc = New System.Windows.Forms.RadioButton
            Me._pnlOption = New System.Windows.Forms.Panel
            Me._btnFindAll = New System.Windows.Forms.Button
            Me._pnlRightDown = New System.Windows.Forms.Panel
            Me._btnReplaceAll = New System.Windows.Forms.Button
            Me._pnlDown = New System.Windows.Forms.Panel
            Me._pnlFind.SuspendLayout()
            Me._pnlReplace.SuspendLayout()
            Me._grpFindArea.SuspendLayout()
            Me._pnlOption.SuspendLayout()
            Me._pnlRightDown.SuspendLayout()
            Me._pnlDown.SuspendLayout()
            Me.SuspendLayout()
            '
            '_lblFindString
            '
            Me._lblFindString.AutoSize = True
            Me._lblFindString.Location = New System.Drawing.Point(8, 7)
            Me._lblFindString.Name = "_lblFindString"
            Me._lblFindString.Size = New System.Drawing.Size(100, 12)
            Me._lblFindString.TabIndex = 1
            Me._lblFindString.Text = "Search "
            '
            '_cmbFindString
            '
            Me._cmbFindString.FormattingEnabled = True
            Me._cmbFindString.Location = New System.Drawing.Point(114, 3)
            Me._cmbFindString.Name = "_cmbFindString"
            Me._cmbFindString.Size = New System.Drawing.Size(311, 20)
            Me._cmbFindString.TabIndex = 0
            '
            '_btnFindNext
            '
            Me._btnFindNext.Location = New System.Drawing.Point(431, 3)
            Me._btnFindNext.Name = "_btnFindNext"
            Me._btnFindNext.Size = New System.Drawing.Size(86, 20)
            Me._btnFindNext.TabIndex = 1
            Me._btnFindNext.Text = "Find Next"
            Me._btnFindNext.UseVisualStyleBackColor = True
            '
            '_pnlFind
            '
            Me._pnlFind.Controls.Add(Me._cmbFindString)
            Me._pnlFind.Controls.Add(Me._lblFindString)
            Me._pnlFind.Controls.Add(Me._btnFindNext)
            Me._pnlFind.Dock = System.Windows.Forms.DockStyle.Top
            Me._pnlFind.Location = New System.Drawing.Point(0, 0)
            Me._pnlFind.Name = "_pnlFind"
            Me._pnlFind.Size = New System.Drawing.Size(525, 26)
            Me._pnlFind.TabIndex = 0
            '
            '_pnlReplace
            '
            Me._pnlReplace.Controls.Add(Me._btnReplace)
            Me._pnlReplace.Controls.Add(Me._cmbReplaceString)
            Me._pnlReplace.Controls.Add(Me._lblReplaceString)
            Me._pnlReplace.Dock = System.Windows.Forms.DockStyle.Top
            Me._pnlReplace.Location = New System.Drawing.Point(0, 26)
            Me._pnlReplace.Name = "_pnlReplace"
            Me._pnlReplace.Size = New System.Drawing.Size(525, 27)
            Me._pnlReplace.TabIndex = 1
            '
            '_btnReplace
            '
            Me._btnReplace.Location = New System.Drawing.Point(431, 3)
            Me._btnReplace.Name = "_btnReplace"
            Me._btnReplace.Size = New System.Drawing.Size(86, 20)
            Me._btnReplace.TabIndex = 1
            Me._btnReplace.Text = "Replace"
            Me._btnReplace.UseVisualStyleBackColor = True
            '
            '_cmbReplaceString
            '
            Me._cmbReplaceString.FormattingEnabled = True
            Me._cmbReplaceString.Location = New System.Drawing.Point(114, 3)
            Me._cmbReplaceString.Name = "_cmbReplaceString"
            Me._cmbReplaceString.Size = New System.Drawing.Size(311, 20)
            Me._cmbReplaceString.TabIndex = 0
            '
            '_lblReplaceString
            '
            Me._lblReplaceString.AutoSize = True
            Me._lblReplaceString.Location = New System.Drawing.Point(8, 6)
            Me._lblReplaceString.Name = "_lblReplaceString"
            Me._lblReplaceString.Size = New System.Drawing.Size(102, 12)
            Me._lblReplaceString.TabIndex = 7
            Me._lblReplaceString.Text = "Replace Next)"
            '
            '_btnClose
            '
            Me._btnClose.Location = New System.Drawing.Point(6, 28)
            Me._btnClose.Name = "_btnClose"
            Me._btnClose.Size = New System.Drawing.Size(86, 20)
            Me._btnClose.TabIndex = 2
            Me._btnClose.Text = "Close"
            Me._btnClose.UseVisualStyleBackColor = True
            '
            '_chkFindPrev
            '
            Me._chkFindPrev.AutoSize = True
            Me._chkFindPrev.Location = New System.Drawing.Point(10, 7)
            Me._chkFindPrev.Name = "_chkFindPrev"
            Me._chkFindPrev.Size = New System.Drawing.Size(86, 16)
            Me._chkFindPrev.TabIndex = 0
            Me._chkFindPrev.Text = "Find Prev."
            Me._chkFindPrev.UseVisualStyleBackColor = True
            '
            '_chkFindWithWord
            '
            Me._chkFindWithWord.AutoSize = True
            Me._chkFindWithWord.Location = New System.Drawing.Point(10, 50)
            Me._chkFindWithWord.Name = "_chkFindWithWord"
            Me._chkFindWithWord.Size = New System.Drawing.Size(89, 16)
            Me._chkFindWithWord.TabIndex = 2
            Me._chkFindWithWord.Text = "Match String"
            Me._chkFindWithWord.UseVisualStyleBackColor = True
            '
            '_chkFindWithCaps
            '
            Me._chkFindWithCaps.AutoSize = True
            Me._chkFindWithCaps.Location = New System.Drawing.Point(10, 28)
            Me._chkFindWithCaps.Name = "_chkFindWithCaps"
            Me._chkFindWithCaps.Size = New System.Drawing.Size(172, 16)
            Me._chkFindWithCaps.TabIndex = 1
            Me._chkFindWithCaps.Text = "Match Case"
            Me._chkFindWithCaps.UseVisualStyleBackColor = True
            '
            '_grpFindArea
            '
            Me._grpFindArea.Controls.Add(Me._optFindInNowProject)
            Me._grpFindArea.Controls.Add(Me._optFindInOpenDocs)
            Me._grpFindArea.Controls.Add(Me._optFindInNowDoc)
            Me._grpFindArea.Location = New System.Drawing.Point(188, 3)
            Me._grpFindArea.Name = "_grpFindArea"
            Me._grpFindArea.Size = New System.Drawing.Size(237, 85)
            Me._grpFindArea.TabIndex = 3
            Me._grpFindArea.TabStop = False
            Me._grpFindArea.Text = "Search"
            '
            '_optFindInNowProject
            '
            Me._optFindInNowProject.AutoSize = True
            Me._optFindInNowProject.Location = New System.Drawing.Point(17, 62)
            Me._optFindInNowProject.Name = "_optFindInNowProject"
            Me._optFindInNowProject.Size = New System.Drawing.Size(123, 16)
            Me._optFindInNowProject.TabIndex = 2
            Me._optFindInNowProject.Text = "Search File"
            Me._optFindInNowProject.UseVisualStyleBackColor = True
            '
            '_optFindInOpenDocs
            '
            Me._optFindInOpenDocs.AutoSize = True
            Me._optFindInOpenDocs.Location = New System.Drawing.Point(17, 40)
            Me._optFindInOpenDocs.Name = "_optFindInOpenDocs"
            Me._optFindInOpenDocs.Size = New System.Drawing.Size(183, 16)
            Me._optFindInOpenDocs.TabIndex = 1
            Me._optFindInOpenDocs.Text = "Search Open Files"
            Me._optFindInOpenDocs.UseVisualStyleBackColor = True
            '
            '_optFindInNowDoc
            '
            Me._optFindInNowDoc.AutoSize = True
            Me._optFindInNowDoc.Checked = True
            Me._optFindInNowDoc.Location = New System.Drawing.Point(17, 18)
            Me._optFindInNowDoc.Name = "_optFindInNowDoc"
            Me._optFindInNowDoc.Size = New System.Drawing.Size(125, 16)
            Me._optFindInNowDoc.TabIndex = 0
            Me._optFindInNowDoc.TabStop = True
            Me._optFindInNowDoc.Text = "Find in File"
            Me._optFindInNowDoc.UseVisualStyleBackColor = True
            '
            '_pnlOption
            '
            Me._pnlOption.Controls.Add(Me._grpFindArea)
            Me._pnlOption.Controls.Add(Me._chkFindWithCaps)
            Me._pnlOption.Controls.Add(Me._chkFindWithWord)
            Me._pnlOption.Controls.Add(Me._chkFindPrev)
            Me._pnlOption.Dock = System.Windows.Forms.DockStyle.Left
            Me._pnlOption.Location = New System.Drawing.Point(0, 0)
            Me._pnlOption.Name = "_pnlOption"
            Me._pnlOption.Size = New System.Drawing.Size(425, 96)
            Me._pnlOption.TabIndex = 3
            '
            '_btnFindAll
            '
            Me._btnFindAll.Location = New System.Drawing.Point(6, 3)
            Me._btnFindAll.Name = "_btnFindAll"
            Me._btnFindAll.Size = New System.Drawing.Size(86, 20)
            Me._btnFindAll.TabIndex = 0
            Me._btnFindAll.Text = "Search All"
            Me._btnFindAll.UseVisualStyleBackColor = True
            '
            '_pnlRightDown
            '
            Me._pnlRightDown.AccessibleRole = System.Windows.Forms.AccessibleRole.None
            Me._pnlRightDown.Controls.Add(Me._btnReplaceAll)
            Me._pnlRightDown.Controls.Add(Me._btnFindAll)
            Me._pnlRightDown.Controls.Add(Me._btnClose)
            Me._pnlRightDown.Dock = System.Windows.Forms.DockStyle.Fill
            Me._pnlRightDown.Location = New System.Drawing.Point(425, 0)
            Me._pnlRightDown.Name = "_pnlRightDown"
            Me._pnlRightDown.Size = New System.Drawing.Size(100, 96)
            Me._pnlRightDown.TabIndex = 4
            '
            '_btnReplaceAll
            '
            Me._btnReplaceAll.Location = New System.Drawing.Point(6, 3)
            Me._btnReplaceAll.Name = "_btnReplaceAll"
            Me._btnReplaceAll.Size = New System.Drawing.Size(86, 20)
            Me._btnReplaceAll.TabIndex = 1
            Me._btnReplaceAll.Text = "Replace all(&A)"
            Me._btnReplaceAll.UseVisualStyleBackColor = True
            '
            '_pnlDown
            '
            Me._pnlDown.Controls.Add(Me._pnlRightDown)
            Me._pnlDown.Controls.Add(Me._pnlOption)
            Me._pnlDown.Dock = System.Windows.Forms.DockStyle.Fill
            Me._pnlDown.Location = New System.Drawing.Point(0, 53)
            Me._pnlDown.Name = "_pnlDown"
            Me._pnlDown.Size = New System.Drawing.Size(525, 96)
            Me._pnlDown.TabIndex = 2
            '
            'FindDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSize = True
            Me.ClientSize = New System.Drawing.Size(525, 149)
            Me.Controls.Add(Me._pnlDown)
            Me.Controls.Add(Me._pnlReplace)
            Me.Controls.Add(Me._pnlFind)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FindDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Search"
            Me._pnlFind.ResumeLayout(False)
            Me._pnlFind.PerformLayout()
            Me._pnlReplace.ResumeLayout(False)
            Me._pnlReplace.PerformLayout()
            Me._grpFindArea.ResumeLayout(False)
            Me._grpFindArea.PerformLayout()
            Me._pnlOption.ResumeLayout(False)
            Me._pnlOption.PerformLayout()
            Me._pnlRightDown.ResumeLayout(False)
            Me._pnlDown.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _cmbFindString As System.Windows.Forms.ComboBox
        Friend WithEvents _btnFindNext As System.Windows.Forms.Button
        Friend WithEvents _lblFindString As System.Windows.Forms.Label
        Friend WithEvents _pnlFind As System.Windows.Forms.Panel
        Friend WithEvents _pnlReplace As System.Windows.Forms.Panel
        Friend WithEvents _cmbReplaceString As System.Windows.Forms.ComboBox
        Friend WithEvents _lblReplaceString As System.Windows.Forms.Label
        Friend WithEvents _btnFindAll As System.Windows.Forms.Button
        Friend WithEvents _btnClose As System.Windows.Forms.Button
        Friend WithEvents _chkFindPrev As System.Windows.Forms.CheckBox
        Friend WithEvents _chkFindWithWord As System.Windows.Forms.CheckBox
        Friend WithEvents _chkFindWithCaps As System.Windows.Forms.CheckBox
        Friend WithEvents _grpFindArea As System.Windows.Forms.GroupBox
        Friend WithEvents _optFindInNowProject As System.Windows.Forms.RadioButton
        Friend WithEvents _optFindInOpenDocs As System.Windows.Forms.RadioButton
        Friend WithEvents _optFindInNowDoc As System.Windows.Forms.RadioButton
        Friend WithEvents _pnlOption As System.Windows.Forms.Panel
        Friend WithEvents _btnReplace As System.Windows.Forms.Button
        Friend WithEvents _pnlRightDown As System.Windows.Forms.Panel
        Friend WithEvents _pnlDown As System.Windows.Forms.Panel
        Friend WithEvents _btnReplaceAll As System.Windows.Forms.Button
    End Class

End Namespace