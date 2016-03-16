Namespace Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FindResultView
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me._findResultListView = New System.Windows.Forms.ListView
            Me._clnFindResult = New System.Windows.Forms.ColumnHeader
            Me.SuspendLayout()
            '
            '_findResultListView
            '
            Me._findResultListView.CausesValidation = False
            Me._findResultListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._clnFindResult})
            Me._findResultListView.Dock = System.Windows.Forms.DockStyle.Fill
            Me._findResultListView.FullRowSelect = True
            Me._findResultListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me._findResultListView.Location = New System.Drawing.Point(0, 0)
            Me._findResultListView.Name = "_findResultListView"
            Me._findResultListView.Size = New System.Drawing.Size(699, 217)
            Me._findResultListView.TabIndex = 0
            Me._findResultListView.UseCompatibleStateImageBehavior = False
            Me._findResultListView.View = System.Windows.Forms.View.Details
            '
            '_clnFindResult
            '
            Me._clnFindResult.Text = ""
            Me._clnFindResult.Width = 1000
            '
            'FindResultView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me._findResultListView)
            Me.Name = "FindResultView"
            Me.Size = New System.Drawing.Size(699, 217)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents _findResultListView As System.Windows.Forms.ListView
        Friend WithEvents _clnFindResult As System.Windows.Forms.ColumnHeader

    End Class
End Namespace