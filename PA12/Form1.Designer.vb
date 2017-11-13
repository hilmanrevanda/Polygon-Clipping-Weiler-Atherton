<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDraw.SuspendLayout()
        Me.gbClipping.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'picCanvas
        '
        Me.picCanvas.BackColor = System.Drawing.Color.White
        Me.picCanvas.Location = New System.Drawing.Point(113, 69)
        Me.picCanvas.Name = "picCanvas"
        Me.picCanvas.Size = New System.Drawing.Size(521, 342)
        Me.picCanvas.TabIndex = 0
        Me.picCanvas.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExit.Location = New System.Drawing.Point(711, 8)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(37, 30)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'gbDraw
        '
        Me.gbDraw.BackColor = System.Drawing.Color.LightGray
        Me.gbDraw.Controls.Add(Me.btnDrawMPolygon)
        Me.gbDraw.Controls.Add(Me.btnDrawSPolygon)
        Me.gbDraw.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbDraw.Location = New System.Drawing.Point(657, 69)
        Me.gbDraw.Name = "gbDraw"
        Me.gbDraw.Size = New System.Drawing.Size(91, 113)
        Me.gbDraw.TabIndex = 2
        Me.gbDraw.TabStop = False
        Me.gbDraw.Text = "Draw"
        '
        'btnDrawMPolygon
        '
        Me.btnDrawMPolygon.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnDrawMPolygon.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDrawMPolygon.Location = New System.Drawing.Point(6, 65)
        Me.btnDrawMPolygon.Name = "btnDrawMPolygon"
        Me.btnDrawMPolygon.Size = New System.Drawing.Size(75, 37)
        Me.btnDrawMPolygon.TabIndex = 1
        Me.btnDrawMPolygon.Text = "Multiple Polygon"
        Me.btnDrawMPolygon.UseVisualStyleBackColor = False
        '
        'btnDrawSPolygon
        '
        Me.btnDrawSPolygon.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnDrawSPolygon.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDrawSPolygon.Location = New System.Drawing.Point(6, 19)
        Me.btnDrawSPolygon.Name = "btnDrawSPolygon"
        Me.btnDrawSPolygon.Size = New System.Drawing.Size(75, 40)
        Me.btnDrawSPolygon.TabIndex = 0
        Me.btnDrawSPolygon.Text = "Single Polygon"
        Me.btnDrawSPolygon.UseVisualStyleBackColor = False
        '
        'gbClipping
        '
        Me.gbClipping.BackColor = System.Drawing.Color.LightGray
        Me.gbClipping.Controls.Add(Me.btnClipPolygon)
        Me.gbClipping.Controls.Add(Me.btnClipRectangular)
        Me.gbClipping.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbClipping.Location = New System.Drawing.Point(657, 188)
        Me.gbClipping.Name = "gbClipping"
        Me.gbClipping.Size = New System.Drawing.Size(91, 108)
        Me.gbClipping.TabIndex = 3
        Me.gbClipping.TabStop = False
        Me.gbClipping.Text = "Clipping"
        '
        'btnClipPolygon
        '
        Me.btnClipPolygon.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnClipPolygon.Enabled = False
        Me.btnClipPolygon.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClipPolygon.Location = New System.Drawing.Point(6, 60)
        Me.btnClipPolygon.Name = "btnClipPolygon"
        Me.btnClipPolygon.Size = New System.Drawing.Size(75, 36)
        Me.btnClipPolygon.TabIndex = 1
        Me.btnClipPolygon.Text = "Polygon"
        Me.btnClipPolygon.UseVisualStyleBackColor = False
        '
        'btnClipRectangular
        '
        Me.btnClipRectangular.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnClipRectangular.Enabled = False
        Me.btnClipRectangular.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClipRectangular.Location = New System.Drawing.Point(6, 19)
        Me.btnClipRectangular.Name = "btnClipRectangular"
        Me.btnClipRectangular.Size = New System.Drawing.Size(75, 35)
        Me.btnClipRectangular.TabIndex = 0
        Me.btnClipRectangular.Text = "Rectangular"
        Me.btnClipRectangular.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(6, 48)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Location = New System.Drawing.Point(6, 19)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Location = New System.Drawing.Point(6, 77)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'listBox1
        '
        Me.listBox1.BackColor = System.Drawing.Color.MediumTurquoise
        Me.listBox1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.listBox1.FormattingEnabled = True
        Me.listBox1.Location = New System.Drawing.Point(12, 69)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(68, 342)
        Me.listBox1.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(657, 302)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(91, 109)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Properties"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("News706 BT", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(261, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 22)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Hil-Nik-Cha Drawing App"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.MediumAquamarine
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(763, 45)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Location = New System.Drawing.Point(0, -37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(95, 483)
        Me.Panel2.TabIndex = 13
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(763, 444)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.listBox1)
        Me.Controls.Add(Me.gbClipping)
        Me.Controls.Add(Me.gbDraw)
        Me.Controls.Add(Me.picCanvas)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainWindow"
        Me.Text = "Draw me"
        CType(Me.picCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDraw.ResumeLayout(False)
        Me.gbClipping.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents listBox1 As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
