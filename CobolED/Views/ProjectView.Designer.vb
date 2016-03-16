Namespace Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectView
        Inherits System.Windows.Forms.UserControl

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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectView))
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me._projectTreeViewList = New System.Windows.Forms.ImageList(Me.components)
            Me._descriptionViewPanel = New System.Windows.Forms.Panel
            Me._descriptionView = New System.Windows.Forms.Label
            Me._propertyViewSplitter = New System.Windows.Forms.Splitter
            Me._propertyViewPanel = New System.Windows.Forms.Panel
            Me._propertyView = New System.Windows.Forms.DataGridView
            Me._propertyViewColumnItem = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me._propertyViewColumnValue = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me._projectTreeViewSplitter = New System.Windows.Forms.Splitter
            Me._projectTreeViewPanel = New System.Windows.Forms.Panel
            Me._projectTreeView = New CobolED.UserControls.ProjectTreeView
            Me._descriptionViewPanel.SuspendLayout()
            Me._propertyViewPanel.SuspendLayout()
            CType(Me._propertyView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._projectTreeViewPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            '_projectTreeViewList
            '
            Me._projectTreeViewList.ImageStream = CType(resources.GetObject("_projectTreeViewList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me._projectTreeViewList.TransparentColor = System.Drawing.Color.Transparent
            Me._projectTreeViewList.Images.SetKeyName(0, "project.bmp")
            Me._projectTreeViewList.Images.SetKeyName(1, "program.bmp")
            Me._projectTreeViewList.Images.SetKeyName(2, "function.bmp")
            Me._projectTreeViewList.Images.SetKeyName(3, "variable.bmp")
            Me._projectTreeViewList.Images.SetKeyName(4, "include.bmp")
            Me._projectTreeViewList.Images.SetKeyName(5, "gather.bmp")
            '
            '_descriptionViewPanel
            '
            Me._descriptionViewPanel.Controls.Add(Me._descriptionView)
            Me._descriptionViewPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me._descriptionViewPanel.Location = New System.Drawing.Point(0, 373)
            Me._descriptionViewPanel.Name = "_descriptionViewPanel"
            Me._descriptionViewPanel.Size = New System.Drawing.Size(350, 93)
            Me._descriptionViewPanel.TabIndex = 1
            '
            '_descriptionView
            '
            Me._descriptionView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me._descriptionView.Dock = System.Windows.Forms.DockStyle.Fill
            Me._descriptionView.Location = New System.Drawing.Point(0, 0)
            Me._descriptionView.Name = "_descriptionView"
            Me._descriptionView.Size = New System.Drawing.Size(350, 93)
            Me._descriptionView.TabIndex = 0
            '
            '_propertyViewSplitter
            '
            Me._propertyViewSplitter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me._propertyViewSplitter.Location = New System.Drawing.Point(0, 370)
            Me._propertyViewSplitter.Name = "_propertyViewSplitter"
            Me._propertyViewSplitter.Size = New System.Drawing.Size(350, 3)
            Me._propertyViewSplitter.TabIndex = 5
            Me._propertyViewSplitter.TabStop = False
            '
            '_propertyViewPanel
            '
            Me._propertyViewPanel.Controls.Add(Me._propertyView)
            Me._propertyViewPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me._propertyViewPanel.Location = New System.Drawing.Point(0, 165)
            Me._propertyViewPanel.Name = "_propertyViewPanel"
            Me._propertyViewPanel.Size = New System.Drawing.Size(350, 205)
            Me._propertyViewPanel.TabIndex = 6
            '
            '_propertyView
            '
            Me._propertyView.AllowUserToAddRows = False
            Me._propertyView.AllowUserToDeleteRows = False
            Me._propertyView.AllowUserToResizeColumns = False
            Me._propertyView.AllowUserToResizeRows = False
            Me._propertyView.BackgroundColor = System.Drawing.Color.White
            Me._propertyView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me._propertyView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me._propertyView.ColumnHeadersVisible = False
            Me._propertyView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._propertyViewColumnItem, Me._propertyViewColumnValue})
            Me._propertyView.Dock = System.Windows.Forms.DockStyle.Fill
            Me._propertyView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
            Me._propertyView.Location = New System.Drawing.Point(0, 0)
            Me._propertyView.MultiSelect = False
            Me._propertyView.Name = "_propertyView"
            Me._propertyView.ReadOnly = True
            Me._propertyView.RowHeadersVisible = False
            Me._propertyView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
            Me._propertyView.RowTemplate.Height = 16
            Me._propertyView.RowTemplate.ReadOnly = True
            Me._propertyView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me._propertyView.ShowCellErrors = False
            Me._propertyView.ShowCellToolTips = False
            Me._propertyView.ShowEditingIcon = False
            Me._propertyView.ShowRowErrors = False
            Me._propertyView.Size = New System.Drawing.Size(350, 205)
            Me._propertyView.TabIndex = 1
            Me._propertyView.TabStop = False
            '
            '_propertyViewColumnItem
            '
            Me._propertyViewColumnItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me._propertyViewColumnItem.DefaultCellStyle = DataGridViewCellStyle2
            Me._propertyViewColumnItem.Frozen = True
            Me._propertyViewColumnItem.HeaderText = "Item"
            Me._propertyViewColumnItem.Name = "_propertyViewColumnItem"
            Me._propertyViewColumnItem.ReadOnly = True
            Me._propertyViewColumnItem.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me._propertyViewColumnItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            '
            '_propertyViewColumnValue
            '
            Me._propertyViewColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me._propertyViewColumnValue.FillWeight = 500.0!
            Me._propertyViewColumnValue.HeaderText = "Value"
            Me._propertyViewColumnValue.Name = "_propertyViewColumnValue"
            Me._propertyViewColumnValue.ReadOnly = True
            Me._propertyViewColumnValue.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
            Me._propertyViewColumnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me._propertyViewColumnValue.Width = 247
            '
            '_projectTreeViewSplitter
            '
            Me._projectTreeViewSplitter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me._projectTreeViewSplitter.Location = New System.Drawing.Point(0, 162)
            Me._projectTreeViewSplitter.Name = "_projectTreeViewSplitter"
            Me._projectTreeViewSplitter.Size = New System.Drawing.Size(350, 3)
            Me._projectTreeViewSplitter.TabIndex = 7
            Me._projectTreeViewSplitter.TabStop = False
            '
            '_projectTreeViewPanel
            '
            Me._projectTreeViewPanel.Controls.Add(Me._projectTreeView)
            Me._projectTreeViewPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me._projectTreeViewPanel.Location = New System.Drawing.Point(0, 0)
            Me._projectTreeViewPanel.Name = "_projectTreeViewPanel"
            Me._projectTreeViewPanel.Size = New System.Drawing.Size(350, 162)
            Me._projectTreeViewPanel.TabIndex = 8
            '
            '_projectTreeView
            '
            Me._projectTreeView.Dock = System.Windows.Forms.DockStyle.Fill
            Me._projectTreeView.ImageIndex = 0
            Me._projectTreeView.ImageList = Me._projectTreeViewList
            Me._projectTreeView.Location = New System.Drawing.Point(0, 0)
            Me._projectTreeView.Name = "_projectTreeView"
            Me._projectTreeView.SelectedImageIndex = 0
            Me._projectTreeView.Size = New System.Drawing.Size(350, 162)
            Me._projectTreeView.TabIndex = 1
            Me._projectTreeView.TabStop = False
            '
            'ProjectView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me._projectTreeViewPanel)
            Me.Controls.Add(Me._projectTreeViewSplitter)
            Me.Controls.Add(Me._propertyViewPanel)
            Me.Controls.Add(Me._propertyViewSplitter)
            Me.Controls.Add(Me._descriptionViewPanel)
            Me.Name = "ProjectView"
            Me.Size = New System.Drawing.Size(350, 466)
            Me._descriptionViewPanel.ResumeLayout(False)
            Me._propertyViewPanel.ResumeLayout(False)
            CType(Me._propertyView, System.ComponentModel.ISupportInitialize).EndInit()
            Me._projectTreeViewPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _projectTreeViewList As System.Windows.Forms.ImageList
        Friend WithEvents _descriptionViewPanel As System.Windows.Forms.Panel
        Friend WithEvents _descriptionView As System.Windows.Forms.Label
        Friend WithEvents _propertyViewSplitter As System.Windows.Forms.Splitter
        Friend WithEvents _propertyViewPanel As System.Windows.Forms.Panel
        Friend WithEvents _propertyView As System.Windows.Forms.DataGridView
        Friend WithEvents _propertyViewColumnItem As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents _propertyViewColumnValue As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents _projectTreeViewSplitter As System.Windows.Forms.Splitter
        Friend WithEvents _projectTreeViewPanel As System.Windows.Forms.Panel
        Friend WithEvents _projectTreeView As CobolED.UserControls.ProjectTreeView

    End Class
End Namespace