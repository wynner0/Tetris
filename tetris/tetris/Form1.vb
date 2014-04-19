Public Class Form1
    Dim g As Graphics
    Dim mozgo(9, 15) As Boolean
    Dim allo(9, 15) As Boolean
    Dim alak As Integer
    Dim pos As Integer = 0

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub allorajzol()
        g = Panel1.CreateGraphics

        For x = 0 To 9
            For y = 0 To 15
                
                If allo(x, y) Then
                    g.DrawRectangle(Pens.Pink, (x) * 17, (y) * 17, 15, 15)
                End If
            Next
        Next
    End Sub
    Private Sub mozgorajzol()
        g = Panel1.CreateGraphics

        For x = 0 To 9
            For y = 0 To 15
                If mozgo(x, y) Then
                    g.DrawRectangle(Pens.Black, (x) * 17, (y) * 17, 15, 15)
                Else
                    g.DrawRectangle(Pens.White, (x) * 17, (y) * 17, 15, 15)
                End If
               
            Next
        Next


    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        mozgorajzol()
        allorajzol()
        eses()
        érkezés()

    End Sub
    Private Sub érkezés()
        For x = 0 To 9
            If mozgo(x, 15) Then
                mozgo(x, 15) = False
                allo(x, 15) = True
            End If
        Next
        Dim leérkezette As Boolean = 0
        For y = 15 To 0 Step -1
            For x = 9 To 0 Step -1
                If y < 15 Then
                    If mozgo(x, y) And allo(x, y + 1) Then
                        leérkezette = 1

                    End If
                End If
            Next
        Next

        If leérkezette Then
            For x = 0 To 9
                For y = 0 To 15
                    If Not allo(x, y) Then
                        allo(x, y) = mozgo(x, y)
                        mozgo(x, y) = False
                    End If
                Next
            Next
        End If

    End Sub
    Private Sub eses()
        g = Panel1.CreateGraphics
        For x = 9 To 0 Step -1
            For y = 15 To 0 Step -1

                If mozgo(x, y) And y < 15 Then
                    'g.DrawRectangle(Pens.Black, (x) * 17, (y + 1) * 17, 15, 15)
                    'g.DrawRectangle(Pens.White, (x) * 17, (y) * 17, 15, 15)
                    mozgo(x, y) = False
                    mozgo(x, y + 1) = True
                    pos = y + 1
                End If
            Next
        Next

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        g = Panel1.CreateGraphics

        For Each a In mozgo
            a = False
        Next
        For Each a In allo
            a = False
        Next



        For x = 0 To 9
            For y = 0 To 15
                If mozgo(x, y) = True Then
                    g.DrawRectangle(Pens.Black, x * 16, y * 16, 15, 15)
                End If
            Next
        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        Dim r As New Random()
        alak = r.Next(1, 4)

        If alak = 1 Then

            mozgo(3, 0) = True
            mozgo(4, 0) = True
            mozgo(5, 0) = True
            mozgo(6, 0) = True
        End If
        If alak = 2 Then

            mozgo(4, 0) = True
            mozgo(5, 0) = True
            If r.Next(1, 3) = 1 Then
                mozgo(4, 1) = True
                mozgo(4, 2) = True

            Else

                mozgo(5, 2) = True
                mozgo(5, 1) = True

            End If

        End If
        If alak = 3 Then

        End If
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.A.ToString.ToLower) Then
            For x = 0 To 9
                For y = 15 To 0 Step -1

                    If mozgo(x, y) And x > 0 Then

                        mozgo(x - 1, y) = True
                        mozgo(x, y) = False
                        mozgorajzol()
                    End If
                Next
            Next

        End If


        If e.KeyChar = Convert.ToChar(Keys.D.ToString.ToLower) Then
            For x = 9 To 0 Step -1
                For y = 15 To 0 Step -1

                    If mozgo(x, y) And x < 9 Then
                        mozgo(x, y) = False
                        mozgo(x + 1, y) = True
                        mozgorajzol()
                    End If
                Next
            Next

        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
       
    End Sub
End Class
