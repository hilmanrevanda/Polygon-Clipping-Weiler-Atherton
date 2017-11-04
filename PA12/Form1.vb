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

    Private NewRect As List(Of Point) = Nothing

    Private Clockwise As Boolean = Nothing

    ' The current mouse position while drawing a new polygon.
    Private NewPoint As Point

    Private TempPoint As Point

    'test
    Dim lst As New LinkedList(Of LinkendL)

    ' Start or continue drawing a new polygon.
    Private Sub picCanvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCanvas.MouseDown

        ' See if we are already drawing a polygon.
        If (NewPolygon IsNot Nothing) Then

            ' We are already drawing a polygon.
            ' If it's the right mouse button, finish this polygon.
            If (e.Button = MouseButtons.Right) Then
                ' Finish this polygon.

                If ButtonMenu = "SPolygon" Or ButtonMenu = "MPolygon" Then
                    If (NewPolygon.Count > 2) Then
                        'NewPolygon store coordinate
                        Polygons.Add(NewPolygon)
                        'Remove current polygon coordinate
                        NewPolygon = Nothing

                        btnClipRectangular.Enabled = True
                        btnClipPolygon.Enabled = True

                    End If
                ElseIf ButtonMenu = "RClipping" Then
                    'test
                End If
            Else
                ' Add a point to this polygon.
                If (NewPolygon(NewPolygon.Count - 1) <> e.Location) Then
                    If ButtonMenu = "RClipping" Then
                        '02 22
                        '00 20
                        Dim A As Point
                        Dim B As Point
                        Dim C As Point

                        A = TempPoint
                        B = e.Location

                        C.X = B.X
                        C.Y = A.Y

                        NewPolygon.Add(C)
                        'Add the point into list box
                        listBox1.Items.Add(NewPoint)
                        i = 0
                        i += 1

                        NewPolygon.Add(B)
                        'Add the point into list box
                        listBox1.Items.Add(NewPoint)
                        i = 0
                        i += 1

                        C.X = A.X
                        C.Y = B.Y

                        NewPolygon.Add(C)
                        'Add the point into list box
                        listBox1.Items.Add(NewPoint)
                        i = 0
                        i += 1
                        'NewPolygon store coordinaten coordinate
                        Polygons.Add(NewPolygon)
                        NewPolygon = Nothing

                        ButtonMenu = Nothing
                        btnClipRectangular.Enabled = False
                        btnClipPolygon.Enabled = False

                        Clockwise = True

                        ClippingPoint(Polygons(0), Polygons(1))
                    Else
                        NewPolygon.Add(e.Location)
                        'Add the point into list box
                        listBox1.Items.Add(NewPoint)
                        i = 0
                        i += 1
                    End If
                End If
            End If
        Else
            ' Start a new polygon.
            NewPolygon = New List(Of Point)()
            NewPoint = e.Location
            NewPolygon.Add(e.Location)
            If ButtonMenu = "SPolygon" Or ButtonMenu = "MPolygon" Then
                listBox1.Items.Add("Polygon")
            ElseIf ButtonMenu = "RClipping" Then
                listBox1.Items.Add("Clipping")
            End If
            'MsgBox(NewPolygon.Count & " " & NewPoint.X & ", " & NewPoint.Y)

            If (ButtonMenu = "RClipping") Then TempPoint = NewPoint

            listBox1.Items.Add(NewPoint)


        End If

        ' Redraw.
        picCanvas.Invalidate()

    End Sub

    ' Move the next point in the new polygon.
    Private Sub picCanvas_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCanvas.MouseMove
        If ButtonMenu = "SPolygon" Or ButtonMenu = "MPolygon" Or ButtonMenu = "RClipping" Then
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



            If CrossProductOf(((polygon(nextpoint).X) - (polygon(currentpoint).X)), ((polygon(nextnextPoint).X) - (polygon(nextpoint).X)),
                              ((polygon(nextpoint).Y) - (polygon(currentpoint).Y)), ((polygon(nextnextPoint).Y) - (polygon(nextpoint).Y))) >= 0 Then
                P = P + 1
            Else N = N + 1
            End If
        Next

        'MsgBox(P.ToString & " " & N.ToString)

        If N = 0 And P > 0 Then
            Clockwise = True
            Return True
        ElseIf P = 0 And N > 0 Then
            Clockwise = False
            Return True
        Else
            MsgBox("Not a convex cliping")
            Return False
        End If
    End Function

    Function CrossProductOf(Ax As Integer, Bx As Integer, Ay As Integer, By As Integer) As Integer
        Return (Ax * By) - (Ay * Bx)
    End Function


    Function ClippingPoint(Polygon As List(Of Point), Rect As List(Of Point)) As Point

        Dim B As Integer
        Dim T As Integer

        For A = 0 To Polygon.Count - 1
            B = NextPoint(A, Polygon.Count)

            For S = 0 To Rect.Count - 1
                T = NextPoint(S, Rect.Count)

                If (Not InsidePoint(Rect(S), Rect(T), Polygon(B)) And InsidePoint(Rect(S), Rect(T), Polygon(A))) Then 'False and True means out in
                    'leaving
                    MsgBox("edge " & S & T & " with " & A & B & " is EN")
                ElseIf (InsidePoint(Rect(S), Rect(T), Polygon(B)) And Not InsidePoint(Rect(S), Rect(T), Polygon(A))) Then 'true and false means in out
                    'entering
                    MsgBox("edge " & S & T & " with " & A & B & " is LEAV")
                Else
                    MsgBox("rejected")
                End If
                'if t max < t min leaving then acc
            Next
        Next

    End Function

    'Fungsi ini menentukan inside atau outside dari saru point saja (Point S)
    Function InsidePoint(WA As Point, WB As Point, S As Point) As Boolean
        Dim N As Point
        Dim D As Point

        N.X = WB.Y - WA.Y
        N.Y = WB.X - WA.X
        If (Clockwise) Then
            N.Y = N.Y * -1
        ElseIf (Not Clockwise) Then
            N.X = N.X * -1
        End If

        D.X = (S.X - WA.X) * N.X
        D.Y = (S.Y - WA.Y) * N.Y

        If (D.X >= 0 And D.Y >= 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function NextPoint(Point As Integer, Total As Integer) As Integer
        If Point + 1 = Total Then
            Return 0
        Else
            Return Point + 1
        End If
    End Function

    'coba linkend list
    Sub test()
        lst.AddFirst(New LinkendL With {.Value = "Ziggy"})
    End Sub
End Class

Friend Class LinkendL
    Public Property Value As String
    Public Property nextL As LinkendL = Nothing
End Class
