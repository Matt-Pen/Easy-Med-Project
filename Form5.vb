Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form5
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form5_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboupdate()
        datagridupdate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim quer As String = "insert into supplier_details(company,supplier_name,phone_no,email)values(@comp,@supname,@phon,@email)"
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim cmd = New MySqlCommand(quer, con)
        With cmd.Parameters

            .AddWithValue("@comp", TextBox2.Text.Trim())
            .AddWithValue("@supname", TextBox3.Text.Trim())
            .AddWithValue("@phon", TextBox4.Text.Trim())
            .AddWithValue("@email", TextBox5.Text.Trim())
        End With
        Dim rs As Integer
        If (TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "") Then
            MessageBox.Show("Please Enter Values in all Boxes")
        Else
            rs = cmd.ExecuteNonQuery()
            If (rs > 0) Then
                datagridupdate()
            End If
        End If
        comboupdate()
        Cleartext()
        con.Close()
        MessageBox.Show("Row added to database")
    End Sub
    Public Sub datagridupdate()

        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select * from supplier_details"
        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()

    End Sub
    Public Sub Cleartext()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim cmd As New MySqlCommand
        cmd.Connection = con

        With cmd
            cmd.CommandText = "update Supplier_details set company=@comp,supplier_name=@supname,phone_no=@phone,email=@email where sup_id=@supid"
            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@supid", TextBox1.Text)
            .Parameters.AddWithValue("@comp", TextBox2.Text)
            .Parameters.AddWithValue("@supname", TextBox3.Text)
            .Parameters.AddWithValue("@phone", TextBox4.Text)
            .Parameters.AddWithValue("@email", TextBox5.Text)
        End With
        cmd.ExecuteNonQuery()
        datagridupdate()
        Cleartext()
        con.Close()
        MessageBox.Show("Row updated")
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        TextBox1.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
        TextBox2.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
        TextBox4.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
        TextBox5.Text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim quer As String = "delete from supplier_details where sup_id=@supid"
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim cmd = New MySqlCommand(quer, con)
        With cmd.Parameters
            .AddWithValue("@supid", TextBox1.Text.Trim())
        End With

        cmd.ExecuteNonQuery()
        datagridupdate()
        con.Close()
        comboupdate()
        Cleartext()
        MessageBox.Show("Row deleted")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Cleartext()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        datagridupdate()
    End Sub
    Public Sub comboupdate()
        ComboBox1.DataSource = Nothing
        ComboBox1.Items.Clear()
        Dim cmd As New MySqlCommand
        Dim con = New MySqlConnection(constr)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select sup_id from supplier_details"
        Dim dr1 As MySqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read
            ComboBox1.Items.Add(dr1("sup_id"))

        Loop
        dr1.Close()
        datagridupdate()
    End Sub

    Public Sub combosearch()
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select * from supplier_details where sup_id=" + ComboBox1.Text.ToString

        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        combosearch()
    End Sub


End Class