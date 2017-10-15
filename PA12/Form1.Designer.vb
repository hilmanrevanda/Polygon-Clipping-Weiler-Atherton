<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.picCanvas = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.gbDraw = New System.Windows.Forms.GroupBox()
        Me.btnDrawMPolygon = New System.Windows.Forms.Button()
        Me.btnDrawSPolygon = New System.Windows.Forms.Button()
        Me.gbClipping = New System.Windows.Forms.GroupBox()
        Me.btnClipPolygon = New System.Windows.Forms.Button()
        Me.btnClipRectangular = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDraw.SuspendLayout()
        Me.gbClipping.SuspendLayout()
        Me.SuspendLayout()
        '
        'picCanvas
        '
        Me.picCanvas.BackColor = System.Drawing.Color.White
        Me.picCanvas.Location = New System.Drawing.Point(13, 31)
        Me.picCanvas.Name = "picCanvas"
        Me.picCanvas.Size = New System.Drawing.Size(521, 281)
        Me.picCanvas.TabIndex = 0
        Me.picCanvas.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(598, 334)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'gbDraw
        '
        Me.gbDraw.Controls.Add(Me.btnDrawMPolygon)
        Me.gbDraw.Controls.Add(Me.btnDrawSPolygon)
        Me.gbDraw.Location = New System.Drawing.Point(540, 32)
        Me.gbDraw.Name = "gbDraw"
        Me.gbDraw.Size = New System.Drawing.Size(91, 113)
        Me.gbDraw.TabIndex = 2
        Me.gbDraw.TabStop = False
        Me.gbDraw.Text = "Draw"
        '
        'btnDrawMPolygon
        '
        Me.btnDrawMPolygon.Location = New System.Drawing.Point(6, 65)
        Me.btnDrawMPolygon.Name = "btnDrawMPolygon"
        Me.btnDrawMPolygon.Size = New System.Drawing.Size(75, 37)
        Me.btnDrawMPolygon.TabIndex = 1
        Me.btnDrawMPolygon.Text = "Multiple Polygon"
        Me.btnDrawMPolygon.UseVisualStyleBackColor = True
        '
        'btnDrawSPolygon
        '
        Me.btnDrawSPolygon.Location = New System.Drawing.Point(6, 19)
        Me.btnDrawSPolygon.Name = "btnDrawSPolygon"
        Me.btnDrawSPolygon.Size = New System.Drawing.Size(75, 40)
        Me.btnDrawSPolygon.TabIndex = 0
        Me.btnDrawSPolygon.Text = "Single Polygon"
        Me.btnDrawSPolygon.UseVisualStyleBackColor = True
        '
        'gbClipping
        '
        Me.gbClipping.Controls.Add(Me.btnClipPolygon)
        Me.gbClipping.Controls.Add(Me.btnClipRectangular)
        Me.gbClipping.Location = New System.Drawing.Point(540, 151)
        Me.gbClipping.Name = "gbClipping"
        Me.gbClipping.Size = New System.Drawing.Size(91, 108)
        Me.gbClipping.TabIndex = 3
        Me.gbClipping.TabStop = False
        Me.gbClipping.Text = "Clipping"
        '
        'btnClipPolygon
        '
        Me.btnClipPolygon.Location = New System.Drawing.Point(6, 60)
        Me.btnClipPolygon.Name = "btnClipPolygon"
        Me.btnClipPolygon.Size = New System.Drawing.Size(75, 36)
        Me.btnClipPolygon.TabIndex = 1
        Me.btnClipPolygon.Text = "Polygon"
        Me.btnClipPolygon.UseVisualStyleBackColor = True
        '
        'btnClipRectangular
        '
        Me.btnClipRectangular.Location = New System.Drawing.Point(6, 19)
        Me.btnClipRectangular.Name = "btnClipRectangular"
        Me.btnClipRectangular.Size = New System.Drawing.Size(75, 35)
        Me.btnClipRectangular.TabIndex = 0
        Me.btnClipRectangular.Text = "Rectangular"
        Me.btnClipRectangular.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(13, 334)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(113, 334)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 23)
        Me.btnMove.TabIndex = 6
        Me.btnMove.Text = "Move"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(352, 334)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(459, 334)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(637, 31)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(68, 108)
        Me.ListBox1.TabIndex = 9
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 369)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.gbClipping)
        Me.Controls.Add(Me.gbDraw)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.picCanvas)
        Me.Name = "MainWindow"
        Me.Text = "Draw me"
        CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDraw.ResumeLayout(False)
        Me.gbClipping.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picCanvas As PictureBox
    Friend WithEvents btnExit As Button
    Friend WithEvents gbDraw As GroupBox
    Friend WithEvents btnDrawMPolygon As Button
    Friend WithEvents btnDrawSPolygon As Button
    Friend WithEvents gbClipping As GroupBox
    Friend WithEvents btnClipPolygon As Button
    Friend WithEvents btnClipRectangular As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnMove As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents ListBox1 As ListBox
End Class
