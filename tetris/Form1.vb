Public Class Form1
    Dim g As Graphics
    Dim mozgo(9, 15) As Boolean
    Dim allo(9, 15) As Boolean

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        g = Panel1.CreateGraphics
        For x = 0 To 9
            For y = 0 To 15
                If mozgo(x, y) Then
                    g.DrawRectangle(Pens.Black, (x + 1) * 17, (y + 1) * 17, 15, 15)

                End If
            Next
        Next

        eses()


    End Sub

    Private Sub eses()
        For x = 0 To 9
            For y = 0 To 15
                If mozgo(x, y) And y < 15 Then
                    mozgo(x, y) = False
                    mozgo(x, y + 1) = True

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
        mozgo(4, 4) = True
        mozgo(5, 4) = True


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
    End Sub
End Class
