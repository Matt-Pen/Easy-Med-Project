Imports MySql.Data.MySqlClient

Public Class Form10
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"
    Public ctg As String
    Public quant As Integer

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datagridupdate()
        comboupdate()
        totalcalc()
    End Sub
    Public Sub datagridupdate()

        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select med_id as Med_ID, med_name as Name, category, quantity, unit_price from medicine"
        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form10_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Public Sub comboupdate()
        Dim ctg As String
        ComboBox1.DataSource = Nothing
        ComboBox1.Items.Clear()
        Dim cmd As New MySqlCommand
        Dim con = New MySqlConnection(constr)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select category from medicine"
        Dim dr1 As MySqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read
            ctg = dr1("category")
            If ComboBox1.Items.Contains(ctg) Then
                Continue Do
            Else
                ComboBox1.Items.Add(ctg)
            End If

        Loop
        dr1.Close()
        datagridupdate()
    End Sub

    Public Sub combosearch()
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select * from medicine where category like '%" + ComboBox1.Text + "%'"

        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt
        ComboBox1.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox4.Text = "" Then
            MessageBox.Show("Enter The Quantity")
        Else
            Dim con = New MySqlConnection(constr)
            con.Open()
            Dim quer As String = "select * from medicine where quantity <=" + TextBox4.Text

            Dim dta = New MySqlDataAdapter(quer, con)
            Dim dt = New DataTable()
            dta.Fill(dt)
            DataGridView1.DataSource = dt

            con.Close()

        End If
        ctg = ""
        quant = Val(TextBox4.Text)
        totalcalc()
        cleartext()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        datagridupdate()
        cleartext()
        ctg = ""
        quant = 0
        totalcalc()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ctg = ComboBox1.Text.ToString
        combosearch()
        quant = 0
        totalcalc()
    End Sub
    Public Sub cleartext()
        TextBox4.Text = ""
        ComboBox1.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form13.callfunc()
        Form13.Show()
    End Sub

    Public Sub totalcalc()
        Dim qt, upr, total As Integer

        If ctg <> "" Then
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Select * from medicine where category Like '%" + ctg + "%'"
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                qt = dr1("quantity")
                upr = dr1("unit_price")
                total += qt * upr

            Loop
            Label6.Text = total.ToString
            con.Close()
        ElseIf quant <> 0 Then
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select * from medicine where quantity <=" + quant.ToString
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                qt = dr1("quantity")
                upr = dr1("unit_price")
                total += qt * upr

            Loop
            Label6.Text = total.ToString
            con.Close()
        Else
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select * from medicine"
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                qt = dr1("quantity")
                upr = dr1("unit_price")
                total += qt * upr

            Loop
            Label6.Text = total.ToString
            con.Close()
        End If

    End Sub


End Class