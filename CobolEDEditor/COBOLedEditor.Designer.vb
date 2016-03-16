<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CobolEDEditor
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
        Me._vScrollBar = New System.Windows.Forms.VScrollBar
        Me._hScrollBar = New System.Windows.Forms.HScrollBar
        Me._textView = New Views.TextView
        Me._bookMarkView = New Views.BookMarkView
        Me._rulerView = New Views.RulerView

        Me.SuspendLayout()

        'CobolEDEditor
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Font = New System.Drawing.Font("ＭＳ Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Controls.Add(Me._rulerView)
        Me.Controls.Add(Me._bookMarkView)
        Me.Controls.Add(Me._textView)
        Me.Controls.Add(Me._hScrollBar)
        Me.Controls.Add(Me._vScrollBar)
        Me.Size = New System.Drawing.Size(500, 380)

        '_vScrollBar
        Me._vScrollBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or _
                                       System.Windows.Forms.AnchorStyles.Bottom Or _
                                       System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._vScrollBar.Location = New System.Drawing.Point(Me.Width - 16, 0)
        Me._vScrollBar.Size = New System.Drawing.Size(16, Me.Height - 16)
        Me._vScrollBar.TabStop = False

        '_hScrollBar
        Me._hScrollBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or _
                                       System.Windows.Forms.AnchorStyles.Left Or _
                                       System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._hScrollBar.Location = New System.Drawing.Point(0, Me.Height - 16)
        Me._hScrollBar.Size = New System.Drawing.Size(Me.Width - 16, 16)
        Me._hScrollBar.TabStop = False

        '_textView
        Me._textView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or _
                                     System.Windows.Forms.AnchorStyles.Bottom Or _
                                     System.Windows.Forms.AnchorStyles.Left Or _
                                     System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._textView.BackColor = System.Drawing.Color.White
        Me._textView.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._textView.Font = Me.Font
        Me._textView.Location = New System.Drawing.Point(16, 16)
        Me._textView.Size = New System.Drawing.Size(Me.Width - 32, Me.Height - 32)
        Me._textView.TabStop = False
        Me._textView.StartColumn = 0
        Me._textView.StartLine = 0
        Me._textView.Document = Nothing
        Me._textView.TextCaret = Nothing

        '_bookMarkView
        Me._bookMarkView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or _
                                         System.Windows.Forms.AnchorStyles.Bottom Or _
                                         System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._bookMarkView.BackColor = Me.BackColor
        Me._bookMarkView.Cursor = System.Windows.Forms.Cursors.Hand
        Me._bookMarkView.Font = Me.Font
        Me._bookMarkView.Location = New System.Drawing.Point(0, 16)
        Me._bookMarkView.Name = "_bookMarkView"
        Me._bookMarkView.Size = New System.Drawing.Size(16, Me.Height - 32)
        Me._bookMarkView.TabStop = False
        Me._bookMarkView.StartColumn = 0
        Me._bookMarkView.StartLine = 0
        Me._bookMarkView.Document = Nothing

        '_rulerView
        Me._rulerView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or _
                                         System.Windows.Forms.AnchorStyles.Left Or _
                                         System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._rulerView.BackColor = System.Drawing.Color.White
        Me._rulerView.Cursor = System.Windows.Forms.Cursors.UpArrow
        Me._rulerView.Font = Me.Font
        Me._rulerView.Location = New System.Drawing.Point(16, 0)
        Me._rulerView.Name = "_rulerView"
        Me._rulerView.Size = New System.Drawing.Size(Me.Width - 32, 16)
        Me._rulerView.TabStop = False
        Me._rulerView.StartColumn = 0
        Me._rulerView.StartLine = 0
        Me._rulerView.Document = Nothing

        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents _vScrollBar As System.Windows.Forms.VScrollBar
    Friend WithEvents _hScrollBar As System.Windows.Forms.HScrollBar
    Friend WithEvents _textView As Views.TextView
    Friend WithEvents _bookMarkView As Views.BookMarkView
    Friend WithEvents _rulerView As Views.RulerView

End Class
