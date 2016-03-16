Namespace Dialogues
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SelectTemplateDialog
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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectTemplateDialog))
            Me._tplButton = New System.Windows.Forms.TableLayoutPanel
            Me._btnOK = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._pnlTitle = New System.Windows.Forms.Panel
            Me._lblDescription = New System.Windows.Forms.Label
            Me._lblTitle = New System.Windows.Forms.Label
            Me._pnlTemplateContext = New System.Windows.Forms.Panel
            Me._lsvTemplateContext = New System.Windows.Forms.ListView
            Me._imlTemplateContext = New System.Windows.Forms.ImageList(Me.components)
            Me._sptSplitter = New System.Windows.Forms.Splitter
            Me._trvTemplateDir = New System.Windows.Forms.TreeView
            Me._imlTemplateDir = New System.Windows.Forms.ImageList(Me.components)
            Me._lblTemplateTitle = New System.Windows.Forms.Label
            Me._pnlFileName = New System.Windows.Forms.Panel
            Me._lblFileName = New System.Windows.Forms.Label
            Me._txtFileName = New System.Windows.Forms.TextBox
            Me._pnlTemplateName = New System.Windows.Forms.Panel
            Me._lblTemplateName = New System.Windows.Forms.Label
            Me._txtTemplateName = New System.Windows.Forms.TextBox
            Me._tplButton.SuspendLayout()
            Me._pnlTitle.SuspendLayout()
            Me._pnlTemplateContext.SuspendLayout()
            Me._pnlFileName.SuspendLayout()
            Me._pnlTemplateName.SuspendLayout()
            Me.SuspendLayout()
            '
            '_tplButton
            '
            Me._tplButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._tplButton.ColumnCount = 2
            Me._tplButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me._tplButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me._tplButton.Controls.Add(Me._btnOK, 0, 0)
            Me._tplButton.Controls.Add(Me._btnCancel, 1, 0)
            Me._tplButton.Location = New System.Drawing.Point(444, 414)
            Me._tplButton.Name = "_tplButton"
            Me._tplButton.RowCount = 1
            Me._tplButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me._tplButton.Size = New System.Drawing.Size(146, 27)
            Me._tplButton.TabIndex = 0
            '
            '_btnOK
            '
            Me._btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._btnOK.Location = New System.Drawing.Point(3, 3)
            Me._btnOK.Name = "_btnOK"
            Me._btnOK.Size = New System.Drawing.Size(67, 21)
            Me._btnOK.TabIndex = 0
            Me._btnOK.Text = "Ok"
            '
            '_btnCancel
            '
            Me._btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.Location = New System.Drawing.Point(76, 3)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(67, 21)
            Me._btnCancel.TabIndex = 1
            Me._btnCancel.Text = "Cancel"
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
            Me._pnlTitle.Size = New System.Drawing.Size(602, 64)
            Me._pnlTitle.TabIndex = 1
            '
            '_lblDescription
            '
            Me._lblDescription.AutoSize = True
            Me._lblDescription.BackColor = System.Drawing.Color.Transparent
            Me._lblDescription.Location = New System.Drawing.Point(40, 41)
            Me._lblDescription.Name = "_lblDescription"
            Me._lblDescription.Size = New System.Drawing.Size(216, 12)
            Me._lblDescription.TabIndex = 1
            Me._lblDescription.Text = "Create new file."
            '
            '_lblTitle
            '
            Me._lblTitle.AutoSize = True
            Me._lblTitle.BackColor = System.Drawing.Color.Transparent
            Me._lblTitle.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Me._lblTitle.Location = New System.Drawing.Point(39, 14)
            Me._lblTitle.Name = "_lblTitle"
            Me._lblTitle.Size = New System.Drawing.Size(148, 15)
            Me._lblTitle.TabIndex = 0
            Me._lblTitle.Text = "Add new files"
            '
            '_pnlTemplateContext
            '
            Me._pnlTemplateContext.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._pnlTemplateContext.Controls.Add(Me._lsvTemplateContext)
            Me._pnlTemplateContext.Controls.Add(Me._sptSplitter)
            Me._pnlTemplateContext.Controls.Add(Me._trvTemplateDir)
            Me._pnlTemplateContext.Location = New System.Drawing.Point(12, 87)
            Me._pnlTemplateContext.Name = "_pnlTemplateContext"
            Me._pnlTemplateContext.Size = New System.Drawing.Size(578, 268)
            Me._pnlTemplateContext.TabIndex = 2
            '
            '_lsvTemplateContext
            '
            Me._lsvTemplateContext.Dock = System.Windows.Forms.DockStyle.Fill
            Me._lsvTemplateContext.HideSelection = False
            Me._lsvTemplateContext.LargeImageList = Me._imlTemplateContext
            Me._lsvTemplateContext.Location = New System.Drawing.Point(164, 0)
            Me._lsvTemplateContext.MultiSelect = False
            Me._lsvTemplateContext.Name = "_lsvTemplateContext"
            Me._lsvTemplateContext.Size = New System.Drawing.Size(414, 268)
            Me._lsvTemplateContext.TabIndex = 2
            Me._lsvTemplateContext.UseCompatibleStateImageBehavior = False
            '
            '_imlTemplateContext
            '
            Me._imlTemplateContext.ImageStream = CType(resources.GetObject("_imlTemplateContext.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me._imlTemplateContext.TransparentColor = System.Drawing.Color.Transparent
            Me._imlTemplateContext.Images.SetKeyName(0, "template.ico")
            '
            '_sptSplitter
            '
            Me._sptSplitter.Location = New System.Drawing.Point(161, 0)
            Me._sptSplitter.Name = "_sptSplitter"
            Me._sptSplitter.Size = New System.Drawing.Size(3, 268)
            Me._sptSplitter.TabIndex = 1
            Me._sptSplitter.TabStop = False
            '
            '_trvTemplateDir
            '
            Me._trvTemplateDir.Dock = System.Windows.Forms.DockStyle.Left
            Me._trvTemplateDir.ImageIndex = 0
            Me._trvTemplateDir.ImageList = Me._imlTemplateDir
            Me._trvTemplateDir.Location = New System.Drawing.Point(0, 0)
            Me._trvTemplateDir.Name = "_trvTemplateDir"
            Me._trvTemplateDir.SelectedImageIndex = 0
            Me._trvTemplateDir.Size = New System.Drawing.Size(161, 268)
            Me._trvTemplateDir.TabIndex = 0
            '
            '_imlTemplateDir
            '
            Me._imlTemplateDir.ImageStream = CType(resources.GetObject("_imlTemplateDir.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me._imlTemplateDir.TransparentColor = System.Drawing.Color.Transparent
            Me._imlTemplateDir.Images.SetKeyName(0, "ClosedFolder.png")
            Me._imlTemplateDir.Images.SetKeyName(1, "OpenedFolder.png")
            '
            '_lblTemplateTitle
            '
            Me._lblTemplateTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._lblTemplateTitle.AutoSize = True
            Me._lblTemplateTitle.Location = New System.Drawing.Point(10, 72)
            Me._lblTemplateTitle.Name = "_lblTemplateTitle"
            Me._lblTemplateTitle.Size = New System.Drawing.Size(173, 12)
            Me._lblTemplateTitle.TabIndex = 0
            Me._lblTemplateTitle.Text = "Templates "
            '
            '_pnlFileName
            '
            Me._pnlFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._pnlFileName.Controls.Add(Me._lblFileName)
            Me._pnlFileName.Controls.Add(Me._txtFileName)
            Me._pnlFileName.Location = New System.Drawing.Point(12, 361)
            Me._pnlFileName.Name = "_pnlFileName"
            Me._pnlFileName.Size = New System.Drawing.Size(578, 21)
            Me._pnlFileName.TabIndex = 4
            '
            '_lblFileName
            '
            Me._lblFileName.AutoSize = True
            Me._lblFileName.Location = New System.Drawing.Point(3, 4)
            Me._lblFileName.Name = "_lblFileName"
            Me._lblFileName.Size = New System.Drawing.Size(51, 12)
            Me._lblFileName.TabIndex = 0
            Me._lblFileName.Text = "File Name"
            '
            '_txtFileName
            '
            Me._txtFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._txtFileName.Location = New System.Drawing.Point(80, 1)
            Me._txtFileName.Name = "_txtFileName"
            Me._txtFileName.Size = New System.Drawing.Size(498, 19)
            Me._txtFileName.TabIndex = 0
            '
            '_pnlTemplateName
            '
            Me._pnlTemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._pnlTemplateName.Controls.Add(Me._lblTemplateName)
            Me._pnlTemplateName.Controls.Add(Me._txtTemplateName)
            Me._pnlTemplateName.Location = New System.Drawing.Point(12, 387)
            Me._pnlTemplateName.Name = "_pnlTemplateName"
            Me._pnlTemplateName.Size = New System.Drawing.Size(578, 21)
            Me._pnlTemplateName.TabIndex = 5
            '
            '_lblTemplateName
            '
            Me._lblTemplateName.AutoSize = True
            Me._lblTemplateName.Location = New System.Drawing.Point(3, 4)
            Me._lblTemplateName.Name = "_lblTemplateName"
            Me._lblTemplateName.Size = New System.Drawing.Size(71, 12)
            Me._lblTemplateName.TabIndex = 0
            Me._lblTemplateName.Text = "Template name"
            '
            '_txtTemplateName
            '
            Me._txtTemplateName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me._txtTemplateName.Location = New System.Drawing.Point(80, 1)
            Me._txtTemplateName.Name = "_txtTemplateName"
            Me._txtTemplateName.ReadOnly = True
            Me._txtTemplateName.Size = New System.Drawing.Size(498, 19)
            Me._txtTemplateName.TabIndex = 0
            '
            'SelectTemplateDialog
            '
            Me.AcceptButton = Me._btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(602, 449)
            Me.Controls.Add(Me._lblTemplateTitle)
            Me.Controls.Add(Me._pnlTemplateName)
            Me.Controls.Add(Me._pnlFileName)
            Me.Controls.Add(Me._pnlTemplateContext)
            Me.Controls.Add(Me._pnlTitle)
            Me.Controls.Add(Me._tplButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SelectTemplateDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Add new files"
            Me._tplButton.ResumeLayout(False)
            Me._pnlTitle.ResumeLayout(False)
            Me._pnlTitle.PerformLayout()
            Me._pnlTemplateContext.ResumeLayout(False)
            Me._pnlFileName.ResumeLayout(False)
            Me._pnlFileName.PerformLayout()
            Me._pnlTemplateName.ResumeLayout(False)
            Me._pnlTemplateName.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents _tplButton As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents _btnOK As System.Windows.Forms.Button
        Friend WithEvents _btnCancel As System.Windows.Forms.Button
        Friend WithEvents _pnlTitle As System.Windows.Forms.Panel
        Friend WithEvents _lblTitle As System.Windows.Forms.Label
        Friend WithEvents _lblDescription As System.Windows.Forms.Label
        Friend WithEvents _pnlTemplateContext As System.Windows.Forms.Panel
        Friend WithEvents _lsvTemplateContext As System.Windows.Forms.ListView
        Friend WithEvents _sptSplitter As System.Windows.Forms.Splitter
        Friend WithEvents _trvTemplateDir As System.Windows.Forms.TreeView
        Friend WithEvents _lblTemplateTitle As System.Windows.Forms.Label
        Friend WithEvents _pnlFileName As System.Windows.Forms.Panel
        Friend WithEvents _lblFileName As System.Windows.Forms.Label
        Friend WithEvents _txtFileName As System.Windows.Forms.TextBox
        Friend WithEvents _imlTemplateContext As System.Windows.Forms.ImageList
        Friend WithEvents _imlTemplateDir As System.Windows.Forms.ImageList
        Friend WithEvents _pnlTemplateName As System.Windows.Forms.Panel
        Friend WithEvents _lblTemplateName As System.Windows.Forms.Label
        Friend WithEvents _txtTemplateName As System.Windows.Forms.TextBox

    End Class
End Namespace