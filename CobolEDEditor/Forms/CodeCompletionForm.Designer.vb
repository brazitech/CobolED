Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CodeCompletionForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CodeCompletionForm))
            Me._codeListView = New System.Windows.Forms.ListView
            Me._columnHeader = New System.Windows.Forms.ColumnHeader
            Me._imageList = New System.Windows.Forms.ImageList(Me.components)
            Me.SuspendLayout()
            '
            '_codeListView
            '
            Me._codeListView.Alignment = System.Windows.Forms.ListViewAlignment.Left
            Me._codeListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._columnHeader})
            Me._codeListView.Dock = System.Windows.Forms.DockStyle.Fill
            Me._codeListView.FullRowSelect = True
            Me._codeListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me._codeListView.HideSelection = False
            Me._codeListView.ImeMode = System.Windows.Forms.ImeMode.[On]
            Me._codeListView.Location = New System.Drawing.Point(0, 0)
            Me._codeListView.MultiSelect = False
            Me._codeListView.Name = "_codeListView"
            Me._codeListView.Size = New System.Drawing.Size(165, 202)
            Me._codeListView.SmallImageList = Me._imageList
            Me._codeListView.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me._codeListView.TabIndex = 0
            Me._codeListView.TabStop = False
            Me._codeListView.UseCompatibleStateImageBehavior = False
            Me._codeListView.View = System.Windows.Forms.View.Details
            '
            '_columnHeader
            '
            Me._columnHeader.Text = "CodeCompletion"
            Me._columnHeader.Width = 161
            '
            '_imageList
            '
            Me._imageList.ImageStream = CType(resources.GetObject("_imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me._imageList.TransparentColor = System.Drawing.Color.Transparent
            Me._imageList.Images.SetKeyName(0, "keyword.bmp")
            Me._imageList.Images.SetKeyName(1, "function.bmp")
            Me._imageList.Images.SetKeyName(2, "variable.bmp")
            '
            'CodeCompletionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(165, 202)
            Me.Controls.Add(Me._codeListView)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.ImeMode = System.Windows.Forms.ImeMode.[On]
            Me.Name = "CodeCompletionForm"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "CodeCompletionForm"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _codeListView As System.Windows.Forms.ListView
        Friend WithEvents _imageList As System.Windows.Forms.ImageList
        Friend WithEvents _columnHeader As System.Windows.Forms.ColumnHeader
    End Class
End Namespace