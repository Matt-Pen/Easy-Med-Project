
Imports System.Runtime.Serialization
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Crypto.Engines
Public Class Form1
    Dim con As New MySqlConnection
    Dim cmd As New MySqlCommand

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "0126"
    Dim database As String = "easy-medicine"
    Dim user As ArrayList = New ArrayList()
    Dim pass As ArrayList = New ArrayList()
    Dim desig As ArrayList = New ArrayList()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""

        con.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database =" + database + ";"
        con.Open()
        Dim dr1 As MySqlDataReader
        Dim r As Integer = 0
        cmd.Connection = con
        cmd.CommandText = "Select * from login"

        dr1 = cmd.ExecuteReader
        Do While dr1.Read

            user.Add(dr1("uname"))
            pass.Add(dr1("pass"))
            desig.Add(dr1("desig"))
            r += 1

        Loop
        r = 0

        dr1.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As String
        a = TextBox1.Text
        Dim B As String
        B = TextBox2.Text
        Dim c As Integer

        If user.Contains(a) Then

            For c = 0 To user.Count - 1

                If user(c) = a Then


                    If pass(c) = B Then
                        If desig(c) = "cashier" Then
                            Form7.Button5.Visible = False
                            Form7.Button6.Visible = True
                            Form7.Show()


                        End If
                        If desig(c) = "pharmacist" Then
                            Form3.Show()
                            Form7.Button5.Visible = True
                            Form7.Button6.Visible = False

                        End If

                        Me.Hide()
                    Else
                        MessageBox.Show("Password is Incorrect")

                    End If

                End If
            Next
        Else
            MessageBox.Show("Enter A valid Username")
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub


End Class
