Imports System.Drawing.Drawing2D

Public Class MainWindow

    Dim i As Integer

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
                    MsgBox(IsPolygonConvex(NewPolygon).ToString)
                    NewPolygon = Nothing

                Else
                    ' Add a point to this polygon.
                    If (NewPolygon(NewPolygon.Count - 1) <> e.Location) Then
                        NewPolygon.Add(e.Location)
                        'Add the point into list box
                        listBox1.Items.Add(NewPoint)
                        i = i + 1
                    End If
                End If
            Else
                ' Start a new polygon.
                NewPolygon = New List(Of Point)()
                NewPoint = e.Location
                NewPolygon.Add(e.Location)
                listBox1.Items.Add("Polygon")
                listBox1.Items.Add(NewPoint)


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
        'Clear list box, polygons and canvas
        listBox1.Items.Clear()
        Polygons.Clear()
        picCanvas.Image = Nothing
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ButtonMenu = "Delete"

        If (listBox1.SelectedItem Is "Polygon") Then
            listBox1.Items.Remove(listBox1.SelectedItem)

        Else
            MsgBox("Please select a polygon!")
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listBox1.SelectedIndexChanged

    End Sub

    Function IsPolygonConvex(polygon As List(Of Point)) As Boolean
        Dim N As Integer = 0
        Dim P As Integer = 0

        Dim nextpoint As Integer
        Dim nextnextPoint As Integer

        For currentpoint = 0 To polygon.Count - 1
            If currentpoint + 1 = polygon.Count Then
                nextpoint = 0
                nextnextPoint = 1
            ElseIf currentpoint + 2 = polygon.Count Then
                nextnextPoint = 0
            Else nextpoint = currentpoint + 1
                nextnextPoint = currentpoint + 2
            End If



            If CrossProductOf(((polygon(nextpoint).X) - (polygon(currentpoint).X)), ((polygon(nextnextPoint).X) - (polygon(nextpoint).X)), ((polygon(nextpoint).Y) - (polygon(currentpoint).Y)), ((polygon(nextnextPoint).Y) - (polygon(nextpoint).Y))) >= 0 Then
                P = P + 1
            Else N = N + 1
            End If
        Next

        MsgBox(P.ToString & " " & N.ToString)
        If N = 0 And P > 0 Then
            MsgBox("Clockwise")
            Return True
        ElseIf P = 0 And N > 0 Then
            MsgBox("Anti-Clockwise")
            Return True
        Else
            Return False
        End If
    End Function

    Function CrossProductOf(Ax As Integer, Bx As Integer, Ay As Integer, By As Integer) As Integer
        Dim result As Integer = (Ax * By) - (Ay * Bx)
        MsgBox("Ax " & Ax.ToString & "Ay " & Ay.ToString & "Bx " & Bx.ToString & "By " & By.ToString & "Hasil " & result.ToString)
        Return (Ax * By) - (Ay * Bx)
    End Function
End Class
