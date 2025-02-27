Public Class Form3

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form5.datagridupdate()
        Form5.Cleartext()
        Form5.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form7.resetclear()
        Form7.DataGridView1.DataSource = Nothing
        Form7.comboupdate()
        Form7.Show()
        Me.Hide()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form10.comboupdate()
        Form10.datagridupdate()
        Form10.cleartext()
        Form10.totalcalc()
        Form10.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form9.Cleartext()
        Form9.totalcalc()
        Form9.datagridupdate()
        Form9.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Cleartext()
        Form4.comboupdate()
        Form4.datagridupdate()
        Form4.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form6.comboupdate()
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Form1.TextBox1.Text = ""
        Form1.TextBox2.Text = ""
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form11.cleartext()
        Form11.datagridupdate()
        Form11.totalcalc()
        Form11.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form12.cleartext()
        Form12.datagridupdate()
        Form12.Show()
        Form12.totalcalc()
        Me.Hide()

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class