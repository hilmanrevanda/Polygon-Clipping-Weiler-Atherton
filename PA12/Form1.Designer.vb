<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.pbDraw = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.gbDraw = New System.Windows.Forms.GroupBox()
        Me.gbClipping = New System.Windows.Forms.GroupBox()
        Me.btnDrawSPolygon = New System.Windows.Forms.Button()
        Me.btnDrawMPolygon = New System.Windows.Forms.Button()
        Me.btnClipRectangular = New System.Windows.Forms.Button()
        Me.btnClipPolygon = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.pbDraw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDraw.SuspendLayout()
        Me.gbClipping.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbDraw
        '
        Me.pbDraw.BackColor = System.Drawing.Color.White
        Me.pbDraw.Location = New System.Drawing.Point(13, 31)
        Me.pbDraw.Name = "pbDraw"
        Me.pbDraw.Size = New System.Drawing.Size(521, 281)
        Me.pbDraw.TabIndex = 0
        Me.pbDraw.TabStop = False
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
        Me.gbDraw.Size = New System.Drawing.Size(133, 135)
        Me.gbDraw.TabIndex = 2
        Me.gbDraw.TabStop = False
        Me.gbDraw.Text = "Draw"
        '
        'gbClipping
        '
        Me.gbClipping.Controls.Add(Me.btnClipPolygon)
        Me.gbClipping.Controls.Add(Me.btnClipRectangular)
        Me.gbClipping.Location = New System.Drawing.Point(540, 195)
        Me.gbClipping.Name = "gbClipping"
        Me.gbClipping.Size = New System.Drawing.Size(133, 117)
        Me.gbClipping.TabIndex = 3
        Me.gbClipping.TabStop = False
        Me.gbClipping.Text = "Clipping"
        '
        'btnDrawSPolygon
        '
        Me.btnDrawSPolygon.Location = New System.Drawing.Point(31, 19)
        Me.btnDrawSPolygon.Name = "btnDrawSPolygon"
        Me.btnDrawSPolygon.Size = New System.Drawing.Size(75, 40)
        Me.btnDrawSPolygon.TabIndex = 0
        Me.btnDrawSPolygon.Text = "Single Polygon"
        Me.btnDrawSPolygon.UseVisualStyleBackColor = True
        '
        'btnDrawMPolygon
        '
        Me.btnDrawMPolygon.Location = New System.Drawing.Point(31, 79)
        Me.btnDrawMPolygon.Name = "btnDrawMPolygon"
        Me.btnDrawMPolygon.Size = New System.Drawing.Size(75, 37)
        Me.btnDrawMPolygon.TabIndex = 1
        Me.btnDrawMPolygon.Text = "Multiple Polygon"
        Me.btnDrawMPolygon.UseVisualStyleBackColor = True
        '
        'btnClipRectangular
        '
        Me.btnClipRectangular.Location = New System.Drawing.Point(31, 19)
        Me.btnClipRectangular.Name = "btnClipRectangular"
        Me.btnClipRectangular.Size = New System.Drawing.Size(75, 35)
        Me.btnClipRectangular.TabIndex = 0
        Me.btnClipRectangular.Text = "Rectangular"
        Me.btnClipRectangular.UseVisualStyleBackColor = True
        '
        'btnClipPolygon
        '
        Me.btnClipPolygon.Location = New System.Drawing.Point(31, 60)
        Me.btnClipPolygon.Name = "btnClipPolygon"
        Me.btnClipPolygon.Size = New System.Drawing.Size(75, 36)
        Me.btnClipPolygon.TabIndex = 1
        Me.btnClipPolygon.Text = "Polygon"
        Me.btnClipPolygon.UseVisualStyleBackColor = True
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
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(122, 334)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(234, 334)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 369)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.gbClipping)
        Me.Controls.Add(Me.gbDraw)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pbDraw)
        Me.Name = "Form1"
        Me.Text = "Draw me"
        CType(Me.pbDraw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDraw.ResumeLayout(False)
        Me.gbClipping.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbDraw As PictureBox
    Friend WithEvents btnExit As Button
    Friend WithEvents gbDraw As GroupBox
    Friend WithEvents btnDrawMPolygon As Button
    Friend WithEvents btnDrawSPolygon As Button
    Friend WithEvents gbClipping As GroupBox
    Friend WithEvents btnClipPolygon As Button
    Friend WithEvents btnClipRectangular As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnMove As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
End Class
