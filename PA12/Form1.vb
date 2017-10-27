Imports System.Drawing.Drawing2D

Public Class MainWindow


    'To know which button chosen.
    Private ButtonMenu As String
    ' Each polygon is represented by a List(Of Point).
    Private Polygons As New List(Of List(Of Point))()

    ' Points for the new polygon.
    ' Ambil nilai NewPolygon pada line 24 sebelum di hapus untuk record coordinate setiap poligon guna pengaplikasian ke rumus nantinya, atau ada cara lain?
    Private NewPolygon As List(Of Point) = Nothing

    ' The current mouse position while drawing a new polygon.
    Private NewPoint As Point




    ' Start or continue drawing a new polygon.
    Private Sub picCanvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCanvas.MouseDown
        If ButtonMenu = "SPolygon" Or ButtonMenu = "MPolygon" Then
            ' See if we are already drawing a polygon.
            If (NewPolygon IsNot Nothing) Then
                ' We are already drawing a polygon.
                ' If it's the right mouse button, finish this polygon.

                If (e.Button = MouseButtons.Right) Then
                    ' Finish this polygon.
                    If (NewPolygon.Count > 2) Then Polygons.Add(NewPolygon) 'NewPolygon store coordinate
                    'Remove current polygon coordinate
                    NewPolygon = Nothing

                Else
                    ' Add a point to this polygon.
                    If (NewPolygon(NewPolygon.Count - 1) <> e.Location) Then
                        NewPolygon.Add(e.Location)
                        'Add the point into list box
                        listBox1.Items.Add(NewPoint)
                    End If
                End If
            Else
                ' Start a new polygon.
                NewPolygon = New List(Of Point)()
                NewPoint = e.Location
                NewPolygon.Add(e.Location)


            End If

            ' Redraw.
            picCanvas.Invalidate()
        End If
    End Sub

    ' Move the next point in the new polygon.
    Private Sub picCanvas_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCanvas.MouseMove
        If ButtonMenu = "SPolygon" Or ButtonMenu = "MPolygon" Then
            If (NewPolygon Is Nothing) Then Exit Sub
            NewPoint = e.Location
            picCanvas.Invalidate()

        End If
    End Sub

    ' Redraw old polygons in blue. Draw the new polygon in green.
    ' Draw the final segment dashed.
    Private Sub picCanvas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picCanvas.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.Clear(picCanvas.BackColor)

        ' Draw the old polygons.

        For Each polygon As List(Of Point) In Polygons

            e.Graphics.DrawPolygon(Pens.Blue, polygon.ToArray())

        Next polygon

        ' Draw the new polygon.
        If (NewPolygon IsNot Nothing) Then
            ' Draw the new polygon.
            If (NewPolygon.Count > 1) Then
                e.Graphics.DrawLines(Pens.Green, NewPolygon.ToArray())

                'Delete all the previous polygons when we draw another one from Single Polygon button
                If ButtonMenu = "SPolygon" Then
                    Polygons.Clear()
                End If
            End If

            ' Draw the newest edge.
            If (NewPolygon.Count > 0) Then
                Using dashed_pen As New Pen(Color.Green)
                    dashed_pen.DashPattern = New Single() {3, 3}
                    e.Graphics.DrawLine(dashed_pen,
                        NewPolygon(NewPolygon.Count - 1),
                        NewPoint)
                End Using
            End If
        End If
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub picCanvas_Click(sender As Object, e As EventArgs) Handles picCanvas.Click

    End Sub

    Private Sub btnDrawSPolygon_Click(sender As Object, e As EventArgs) Handles btnDrawSPolygon.Click
        ButtonMenu = "SPolygon"
    End Sub

    Private Sub btnDrawMPolygon_Click(sender As Object, e As EventArgs) Handles btnDrawMPolygon.Click
        ButtonMenu = "MPolygon"
    End Sub

    Private Sub btnClipRectangular_Click(sender As Object, e As EventArgs) Handles btnClipRectangular.Click
        ButtonMenu = "RClipping"
    End Sub

    Private Sub btnClipPolygon_Click(sender As Object, e As EventArgs) Handles btnClipPolygon.Click
        ButtonMenu = "FClipping"
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ButtonMenu = "Refresh"
        'Clear list box
        listBox1.Items.Clear()
        Polygons.Clear()


    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ButtonMenu = "Delete"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listBox1.SelectedIndexChanged

    End Sub
End Class
