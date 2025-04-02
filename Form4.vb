Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form4
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form3.Show()
        Me.Hide()

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboupdate()
        datagridupdate()
    End Sub

    Private Sub Form4_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
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
        Dim quer As String = "insert into medicine(med_name,category,quantity,unit_price)values(@name,@ctgor,@quant,@uprice)"
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim cmd = New MySqlCommand(quer, con)
        With cmd.Parameters

            .AddWithValue("@name", TextBox2.Text.Trim())
            .AddWithValue("@ctgor", TextBox3.Text.Trim())
            .AddWithValue("@quant", TextBox4.Text.Trim())
            .AddWithValue("@uprice", TextBox5.Text.Trim())
        End With
        Dim rs As Integer
        If (TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "") Then
            MessageBox.Show("Please Enter Values in all Boxes")
        Else
            rs = cmd.ExecuteNonQuery()
            If (rs > 0) Then
                datagridupdate()
                MessageBox.Show("Row added to database")
            End If
        End If
        Cleartext()
        con.Close()
        comboupdate()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Cleartext()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim cmd As New MySqlCommand
        cmd.Connection = con
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "") Then
            MessageBox.Show("Select a row and make changes")
        Else

            With cmd
                cmd.CommandText = "update medicine set med_name=@medname,category=@ctgor,quantity=@quant,unit_price=@uprice where med_id=@medid"
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@medid", TextBox1.Text)
                .Parameters.AddWithValue("@medname", TextBox2.Text)
                .Parameters.AddWithValue("@ctgor", TextBox3.Text)
                .Parameters.AddWithValue("@quant", TextBox4.Text)
                .Parameters.AddWithValue("@uprice", TextBox5.Text)
            End With
            cmd.ExecuteNonQuery()
            datagridupdate()
            Cleartext()
            con.Close()
            comboupdate()
            MessageBox.Show("Row updated")
        End If

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
        TextBox2.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
        TextBox4.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
        TextBox5.Text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "") Then
            MessageBox.Show("Select a row to delete")
        Else
            Dim quer As String = "delete from medicine where med_id=@medid"
            Dim con = New MySqlConnection(constr)
            con.Open()
            Dim cmd = New MySqlCommand(quer, con)
            With cmd.Parameters
                .AddWithValue("@medid", TextBox1.Text.Trim())
            End With

            cmd.ExecuteNonQuery()
            datagridupdate()
            con.Close()
            comboupdate()
            Cleartext()
            MessageBox.Show("Row deleted")
        End If
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        datagridupdate()
        Cleartext()
    End Sub
    Public Sub Cleartext()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
    End Sub
    Public Sub comboupdate()
        ComboBox1.DataSource = Nothing
        ComboBox1.Items.Clear()
        Dim cmd As New MySqlCommand
        Dim con = New MySqlConnection(constr)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select med_id from medicine"
        Dim dr1 As MySqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read
            ComboBox1.Items.Add(dr1("med_id"))

        Loop
        dr1.Close()
        datagridupdate()
    End Sub
    Public Sub Combosearch()
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select * from medicine where med_id=" + ComboBox1.Text.ToString

        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Combosearch()
    End Sub

    Private Sub Form4_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
End Class