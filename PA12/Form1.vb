Imports System.Drawing.Drawing2D

Public Class MainWindow
    Dim i As Integer
    'To know which button chosen.
    Private ButtonMenu As String
    ' Each polygon is represented by a List(Of Point).
    Private Polygons As New List(Of List(Of Point))()

    Private Clippings As New List(Of List(Of Point))()

    Private SelectedPolygon As List(Of List(Of Point)) = Nothing
    ' Points for the new polygon.
    ' Ambil nilai NewPolygon pada line 24 sebelum di hapus untuk record coordinate setiap poligon guna pengaplikasian ke rumus nantinya, atau ada cara lain?
    Private NewPolygon As List(Of Point) = Nothing

    Private NewRect As List(Of Point) = Nothing

    Public ListofPolygonsLinkedList As List(Of List(Of LinkedLValue)) = Nothing

    Private Intersection As List(Of LinkedLValue) = Nothing

    Private Clockwise As Boolean = Nothing

    Private Tolistbox As Boolean = Nothing

    ' The current mouse position while drawing a new polygon.
    Private NewPoint As Point

    Private TempPoint As Point

    'Status
    Private EN As String = "EN"
    Private LEAV As String = "LEAV"

    ' Start or continue drawing a new polygon.
    Private Sub picCanvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCanvas.MouseDown
        If ButtonMenu = "SPolygon" Or ButtonMenu = "MPolygon" Or ButtonMenu = "RClipping" Or ButtonMenu = "FClipping" Then
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
                            btnDelete.Enabled = True
                            btnSave.Enabled = True
                            btnRefresh.Enabled = True

                            Tolistbox = True
                        End If
                    ElseIf ButtonMenu = "FClipping" Then
                        If (NewPolygon.Count > 2) Then
                            If IsPolygonConvex(NewPolygon) Then
                                Polygons.Add(NewPolygon)
                                NewPolygon = Nothing

                                'masukin semuanya jadi linked list
                                ListofPolygonsLinkedList = New List(Of List(Of LinkedLValue))
                                ListofPolygonsLinkedList = PolygonstoLinkedList()

                                btnClipPolygon.Enabled = False
                                btnClipRectangular.Enabled = False

                                'exe clippingpoint function
                                Doclip()
                            End If
                        End If
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

                            NewPolygon.Add(B)

                            C.X = A.X
                            C.Y = B.Y

                            NewPolygon.Add(C)

                            'NewPolygon store coordinaten coordinate
                            Polygons.Add(NewPolygon)
                            NewPolygon = Nothing

                            ButtonMenu = Nothing
                            btnClipRectangular.Enabled = False
                            btnClipPolygon.Enabled = False

                            Clockwise = True
                            'masukin semuanya jadi linked list
                            ListofPolygonsLinkedList = New List(Of List(Of LinkedLValue))
                            ListofPolygonsLinkedList = PolygonstoLinkedList()


                            'exe clippingpoint function
                            Doclip()

                        Else
                            NewPolygon.Add(e.Location)
                        End If
                    End If
                End If
            Else
                ' Start a new polygon.
                NewPolygon = New List(Of Point)()
                NewPoint = e.Location
                NewPolygon.Add(e.Location)

                If (ButtonMenu = "RClipping") Then TempPoint = NewPoint


            End If
        End If
        ' Redraw.
        picCanvas.Invalidate()
    End Sub

    Sub Doclip()
        For j = 0 To Polygons.Count - 2
            ClippingPoint(j, Polygons.Count - 1)
        Next j
    End Sub
    ' Move the next point in the new polygon.
    Private Sub picCanvas_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCanvas.MouseMove
        If ButtonMenu = "SPolygon" Or ButtonMenu = "MPolygon" Or ButtonMenu = "RClipping" Or ButtonMenu = "FClipping" Then
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

        If Tolistbox Then
            listBox1.Items.Clear()
            i = 0
            For Each Polygon In Polygons
                listBox1.Items.Add("Polygon " & i)
                i = i + 1
            Next Polygon

            ListBox3.Items.Clear()
            i = 0
            For Each Clip In Clippings
                ListBox3.Items.Add("Clipped Polygon " & i)
                i = i + 1
            Next Clip
            Tolistbox = False
        End If

        For Each Clipping As List(Of Point) In Clippings

            e.Graphics.DrawPolygon(Pens.Red, Clipping.ToArray())

        Next Clipping

        If SelectedPolygon IsNot Nothing Then
            For Each selected In SelectedPolygon
                e.Graphics.DrawPolygon(Pens.Yellow, selected.ToArray())
            Next selected
        End If

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
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnRefresh.Enabled = False

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
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        Polygons.Clear()
        picCanvas.Image = Nothing
        NewPolygon = Nothing
        NewRect = Nothing
        Intersection = Nothing
        ListofPolygonsLinkedList = New List(Of List(Of LinkedLValue))
        ListofPolygonsLinkedList.Clear()

        Clippings.Clear()



        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnRefresh.Enabled = False
        btnClipRectangular.Enabled = False
        btnClipPolygon.Enabled = False
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ButtonMenu = "Delete"

        Tolistbox = True
        If listBox1.SelectedIndex >= 0 Then
            Polygons.RemoveAt(listBox1.SelectedIndex)
            SelectedPolygon.Clear()
            ListBox2.Items.Clear()
            picCanvas.Invalidate()
        Else
            MsgBox("Please select a polygon!")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Save as BMP-file
        Dim bmp As New Bitmap(picCanvas.Width, picCanvas.Height)
        picCanvas.DrawToBitmap(bmp, New Rectangle(0, 0, picCanvas.Width, picCanvas.Height))
        bmp.Save("C:\Users\User\Desktop\output.png", Imaging.ImageFormat.Png)
        MsgBox("Saved as Bitmap")

        Dim W As IO.StreamWriter
        Dim j As Integer
        W = New IO.StreamWriter("C:\Users\User\Desktop\test.txt")

        For i = 0 To listBox1.Items.Count - 1
            W.WriteLine(listBox1.Items.Item(i))
        Next
        For i = 0 To ListBox3.Items.Count - 1
            W.WriteLine(ListBox3.Items.Item(i))
        Next

        W.Close()
        MsgBox("Saved as text")
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
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
            MsgBox("Not a convex clipping")
            Return False
        End If
    End Function

    Function CrossProductOf(Ax As Integer, Bx As Integer, Ay As Integer, By As Integer) As Integer
        Return (Ax * By) - (Ay * Bx)
    End Function

    Function ClippingPoint(X As Integer, Z As Integer) As Point
        Dim Polygon = Polygons(X)
        Dim Rect = Polygons(Z)

        Dim C As Integer
        C = 0
        Dim B As Integer
        Dim T As Integer
        Dim NP As Point
        Dim NW As Point

        Dim TempIntersection As New List(Of LinkedLValue)
        Dim TempLinkedLIntersection As LinkedLValue
        Dim TempPoint As Point
        Dim Status As String

        'NewPolygon = New List(Of Point)()
        For A = 0 To Polygon.Count - 1
            B = NextPoint(A, Polygon.Count)

            For S = 0 To Rect.Count - 1
                T = NextPoint(S, Rect.Count)
                NW = Normal(Rect(S), Rect(T))
                NP = Normal(Polygon(A), Polygon(B))

                If (Not InsidePoint(Rect(S), Rect(T), Polygon(B)) And (Not InsidePoint(Rect(S), Rect(T), Polygon(A)))) Then
                    C = C + 1
                ElseIf (Not InsidePoint(Rect(S), Rect(T), Polygon(B)) And InsidePoint(Rect(S), Rect(T), Polygon(A))) Then 'False and True means out in
                    'EN
                    'MsgBox("edge " & S & T & " with " & A & B & " is EN")
                    If TisAcc(Tis(Polygon(A), Polygon(B), Rect(S), NW)) And TisAcc(Tis(Rect(S), Rect(T), Polygon(A), NP)) Then
                        TempPoint = SetTPoint(Polygon(A), Polygon(B), Tis(Polygon(A), Polygon(B), Rect(S), NW))
                        Status = EN
                        TempLinkedLIntersection = New LinkedLValue
                        TempLinkedLIntersection.NewI(Tis(Polygon(A), Polygon(B), Rect(S), NW),
                                                     ToPoint(A, B),
                                                     Tis(Rect(S), Rect(T), Polygon(A), NP),
                                                     ToPoint(S, T),
                                                     TempPoint,
                                                     Status)

                        TempIntersection.Add(TempLinkedLIntersection)

                        'TempIntersection = SetNextPandW(TempIntersection)
                    End If
                ElseIf (InsidePoint(Rect(S), Rect(T), Polygon(B)) And Not InsidePoint(Rect(S), Rect(T), Polygon(A))) Then 'true and false means in out
                    'LEAV
                    'MsgBox("edge " & S & T & " with " & A & B & " is LEAV")
                    If TisAcc(Tis(Polygon(A), Polygon(B), Rect(S), NW)) And TisAcc(Tis(Rect(S), Rect(T), Polygon(A), NP)) Then
                        TempPoint = SetTPoint(Polygon(A), Polygon(B), Tis(Polygon(A), Polygon(B), Rect(S), NW))
                        Status = LEAV
                        TempLinkedLIntersection = New LinkedLValue
                        TempLinkedLIntersection.NewI(Tis(Polygon(A), Polygon(B), Rect(S), NW),
                                                     ToPoint(A, B),
                                                     Tis(Rect(S), Rect(T), Polygon(A), NP),
                                                     ToPoint(S, T),
                                                     TempPoint,
                                                     Status)

                        TempIntersection.Add(TempLinkedLIntersection)

                        'TempIntersection = SetNextPandW(TempIntersection)
                    End If
                End If
            Next
        Next

        If Polygon.Count * Rect.Count = C Then
            Clippings.Add(Polygons.First)
        Else
            Intersection = New List(Of LinkedLValue)
            Intersection = TempIntersection

            'TENTUIN NEXT
            SetNext(PolygonstoLinkedList(X), PolygonstoLinkedList(Z))

            'DrawIntersection START
            NewPolygon = New List(Of Point)

            Dim CurrentPos As LinkedLValue = New LinkedLValue
            Dim Start As LinkedLValue = New LinkedLValue
            For i = 0 To Intersection.Count - 1
                NewPolygon = New List(Of Point)
                If Intersection(i).status Is EN Then
                    CurrentPos = Intersection(i)
                    Start = Intersection(i)

                    NewPolygon.Add(CurrentPos.point)

                    CurrentPos = CurrentPos.NextP

                    NewPolygon.Add(CurrentPos.point)

                    Do While CurrentPos IsNot Start
                        If CurrentPos.status Is LEAV Then
                            CurrentPos = CurrentPos.NextW
                            NewPolygon.Add(CurrentPos.point)
                            Do Until CurrentPos.status Is EN
                                CurrentPos = CurrentPos.NextW
                                NewPolygon.Add(CurrentPos.point)
                            Loop
                        ElseIf CurrentPos.status Is EN Or CurrentPos.status Is "P" Or CurrentPos.status Is "W" Then
                            CurrentPos = CurrentPos.NextP
                            NewPolygon.Add(CurrentPos.point)
                            Do Until CurrentPos.status Is LEAV
                                CurrentPos = CurrentPos.NextP
                                NewPolygon.Add(CurrentPos.point)
                            Loop
                        Else
                            Exit Do
                        End If
                    Loop

                    Clippings.Add(NewPolygon)
                    NewPolygon = Nothing
                End If
            Next
        End If
        'DrawIntersection END

        Tolistbox = True

        ListofPolygonsLinkedList = Nothing

        Intersection = Nothing
    End Function

    'Fungsi ini menentukan inside atau outside dari saru point saja (Point S)
    Function InsidePoint(WA As Point, WB As Point, S As Point) As Boolean
        Dim N As Point
        Dim D As Point

        N = Normal(WA, WB)

        D.X = (S.X - WA.X) * N.X
        D.Y = (S.Y - WA.Y) * N.Y

        If D.X >= 0 And D.Y >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function Normal(WA As Point, WB As Point) As Point
        Dim N As Point

        N.X = WB.Y - WA.Y
        N.Y = WB.X - WA.X
        If (Clockwise) Then
            N.Y = N.Y * -1
        ElseIf (Not Clockwise) Then
            N.X = N.X * -1
        End If

        Return N
    End Function

    Function NextPoint(Point As Integer, Total As Integer) As Integer
        If Point + 1 = Total Then Return 0
        Return Point + 1
    End Function

    Function Tis(A As Point, B As Point, P As Point, N As Point) As Decimal
        Return ((((P.X - A.X) * N.X) + ((P.Y - A.Y) * N.Y)) / (((B.X - A.X) * N.X) + ((B.Y - A.Y) * N.Y))) * 1.0
    End Function

    Function TisAcc(X As Decimal) As Boolean
        If X >= 0 And X <= 1 Then Return True
        Return False
    End Function

    'ShowList(Head, Head) just to show linkedlist
    'Sub ShowList(Start As LinkedLValue, Current As LinkedLValue)
    '   MsgBox(Current.Point.ToString)
    'If Current.NextList IsNot Start Then
    '       ShowList(Start, Current.NextList)
    'End If
    'End Sub

    Function ToPoint(X As Integer, Y As Integer) As Point
        Dim A As Point
        A.X = X
        A.Y = Y
        Return A
    End Function

    Function PolygonstoLinkedList() As List(Of List(Of LinkedLValue))
        Dim ListofPolygonLinkedList As List(Of List(Of LinkedLValue)) = New List(Of List(Of LinkedLValue))
        Dim Temp As List(Of LinkedLValue)
        For Each Polygon As List(Of Point) In Polygons
            Temp = PolygontoLinkedList(Polygon)
            ListofPolygonLinkedList.Add(Temp)
        Next
        Return ListofPolygonLinkedList
    End Function

    Function PolygontoLinkedList(JustPolygon As List(Of Point)) As List(Of LinkedLValue)
        Dim ListRect As New List(Of LinkedLValue)
        Dim Head As LinkedLValue = New LinkedLValue 'still useless
        Dim LinkedLValueTemp As LinkedLValue
        Dim Polygon As List(Of Point) = JustPolygon
        Dim Temp As Point
        Dim isPolygon As Boolean = True

        If JustPolygon Is Polygons.Last Then
            isPolygon = False
        End If

        For i = 0 To Polygon.Count - 1
            Temp = Polygon(i)

            LinkedLValueTemp = New LinkedLValue
            LinkedLValueTemp.NewP(Temp)

            ListRect.Add(LinkedLValueTemp)
            If i = 0 Then
                Head = ListRect(i)
                If isPolygon Then
                    ListRect(i).NextP = Head
                    ListRect(i).status = "P"
                Else
                    ListRect(i).NextW = Head
                    ListRect(i).status = "W"
                End If
            Else
                If isPolygon Then
                    ListRect(i - 1).NextP = ListRect(i)
                    ListRect(i).NextP = Head
                    ListRect(i).status = "P"
                Else
                    ListRect(i - 1).NextW = ListRect(i)
                    ListRect(i).NextW = Head
                    ListRect(i).status = "W"
                End If
            End If
        Next

        Return ListRect
    End Function

    Function SetTPoint(A As Point, B As Point, T As Decimal) As Point
        Dim Result As Point

        Result.X = A.X + (T * (B.X - A.X))
        Result.Y = A.Y + (T * (B.Y - A.Y))

        Return Result
    End Function

    Sub SetNext(Polygon As List(Of LinkedLValue), Window As List(Of LinkedLValue))

        Dim B As Integer
        Dim Point As Point

        Dim Inter As List(Of Integer)

        Dim Start, Endd As Integer

        For A = 0 To Polygon.Count - 1
            B = NextPoint(A, Polygon.Count)

            Point.X = A
            Point.Y = B

            Inter = IntersectionExistP(Point)

            If Inter.Count > 0 Then
                Start = Intersection(Inter.First).p.X
                Endd = Intersection(Inter.First).p.Y
            End If

            If Inter.Count = 1 Then
                Polygon(Start).NextP = Intersection(Inter.First)
                Intersection(Inter.First).NextP = Polygon(Endd)
            ElseIf Inter.Count > 1 Then
                Inter = SortlistP(Inter)

                Polygon(Start).NextP = Intersection(Inter.First)

                For i = 0 To Inter.Count - 1
                    If Not (i + 1 = Inter.Count) Then
                        Intersection(Inter(i)).NextP = Intersection(Inter(i + 1))
                    End If
                Next

                Intersection(Inter.Last).NextP = Polygon(Endd)
            End If
        Next

        For A = 0 To Window.Count - 1
            B = NextPoint(A, Window.Count)

            Point.X = A
            Point.Y = B

            Inter = IntersectionExistW(Point)

            If Inter.Count > 0 Then
                Start = Intersection(Inter.First).w.X
                Endd = Intersection(Inter.First).w.Y
            End If

            If Inter.Count = 1 Then
                Window(Start).NextW = Intersection(Inter.First)
                Intersection(Inter.First).NextW = Window(Endd)
            ElseIf Inter.Count > 1 Then
                Inter = SortlistW(Inter)

                Window(Start).NextW = Intersection(Inter.First)

                For i = 0 To Inter.Count - 1
                    If Not (i + 1 = Inter.Count) Then
                        Intersection(Inter(i)).NextW = Intersection(Inter(i + 1))
                    End If
                Next

                Intersection(Inter.Last).NextW = Window(Endd)
            Else
                'Window(Start).NextW = Window(Endd)
            End If
        Next
    End Sub

    Function IntersectionExistP(Point As Point) As List(Of Integer)
        Dim Result As List(Of Integer) = New List(Of Integer)
        For i = 0 To Intersection.Count - 1
            If Intersection(i).p = Point Then
                Result.Add(i)
            End If
        Next
        Return Result
    End Function

    Function IntersectionExistW(Point As Point) As List(Of Integer)
        Dim Result As List(Of Integer) = New List(Of Integer)
        For i = 0 To Intersection.Count - 1
            If Intersection(i).w = Point Then
                Result.Add(i)
            End If
        Next
        Return Result
    End Function

    Function SortlistP(list As List(Of Integer)) As List(Of Integer)
        Dim C As Integer = 0

        Dim Temp As Integer
        Do While C = 0
            For i = 0 To list.Count - 1
                If Not (i + 1 = list.Count) Then
                    If Intersection(list(i)).tp > Intersection(list(i + 1)).tp Then
                        Temp = list(i)
                        list(i) = list(i + 1)
                        list(i + 1) = Temp
                        C = C + 1
                    End If
                End If
                If i = list.Count - 1 And C = 0 Then
                    Exit Do
                End If
            Next
            If C > 0 Then C = 0
        Loop

        Return list
    End Function

    Function SortlistW(list As List(Of Integer)) As List(Of Integer)
        Dim C As Integer = 0

        Dim Temp As Integer
        Do While C = 0
            For i = 0 To list.Count - 1
                If Not (i + 1 = list.Count) Then
                    If Intersection(list(i)).tw > Intersection(list(i + 1)).tw Then
                        Temp = list(i)
                        list(i) = list(i + 1)
                        list(i + 1) = Temp
                        C = C + 1
                    End If
                End If
                If i = list.Count - 1 And C = 0 Then
                    Exit Do
                End If
            Next
            If C > 0 Then C = 0
        Loop

        Return list
    End Function

    Sub DrawIntersection()
        Dim Current As LinkedLValue

        For i = 0 To Intersection.Count - 1
            NewPolygon = New List(Of Point)
            Current = Intersection(i)

            'MsgBox(Current.status)
            If Current.status = "EN" Then
                Console.WriteLine(Current.point.ToString)
                NewPolygon.Add(Current.point)

                Current = Current.NextP
                Do While Current IsNot Intersection(i)
                    Console.WriteLine(Current.point.ToString)
                    NewPolygon.Add(Current.point)
                    If Current.status = "LEAV" Then
                        Current = Current.NextW
                        Do While Current IsNot Intersection(i)
                            Console.WriteLine(Current.point.ToString)
                            NewPolygon.Add(Current.point)
                            Current = Current.NextW
                        Loop
                    Else
                        Current = Current.NextP
                    End If
                Loop

                Clippings.Add(NewPolygon)
                NewPolygon = Nothing
                Exit For
            End If
            NewPolygon = Nothing
        Next
    End Sub

    Private Sub listBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listBox1.SelectedIndexChanged
        If listBox1.SelectedIndex >= 0 Then
            ListBox2.Items.Clear()
            For Each poly In Polygons(listBox1.SelectedIndex)
                ListBox2.Items.Add(poly.ToString)
                SelectedPolygon = Nothing
                SelectedPolygon = New List(Of List(Of Point))()
                SelectedPolygon.Add(Polygons(listBox1.SelectedIndex))
                picCanvas.Invalidate()
            Next poly
        Else
            ListBox2.Items.Clear()
            SelectedPolygon = Nothing
            picCanvas.Invalidate()
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub
End Class

Public Class LinkedLValue
    Public point As Point
    Public tp As Decimal
    Public tw As Decimal
    Public w As Point
    Public p As Point
    Public status As String
    Public NextP As LinkedLValue
    Public NextW As LinkedLValue

    Sub New()
        Me.tp = Nothing
        Me.tw = Nothing
        Me.w = Nothing
        Me.p = Nothing
        Me.status = Nothing
        Me.NextP = Nothing
        Me.NextW = Nothing
    End Sub

    Sub NewI(TP As Decimal, P As Point, TW As Decimal, W As Point, Point As Point, Status As String)
        Me.tp = TP
        Me.p = P
        Me.tw = TW
        Me.w = W
        Me.point = Point
        Me.status = Status
    End Sub

    Sub NewP(e As Point)
        Me.point = e
    End Sub
End Class