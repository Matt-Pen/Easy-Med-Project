Imports MySql.Data.MySqlClient

Public Class Form6
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form6_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datagridupdate()
        comboupdate()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        DateTimePicker1.MinDate = Today
    End Sub
    Public Sub datagridupdate()

        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select supplier_pur.sup_id, company, med_id,cost_of_purchase from supplier_pur,supplier_details where supplier_pur.sup_id=supplier_details.sup_id"
        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox1.Text = "") Then
            MessageBox.Show("Enter the nesessary details")
        Else

            Dim quer As String = "insert into supplier_pur(sup_id,med_id,cost_of_purchase)values(@supid,@medid,@cost)"
            Dim con = New MySqlConnection(constr)
            con.Open()
            Dim cmd = New MySqlCommand(quer, con)
            With cmd.Parameters
                .AddWithValue("@supid", ComboBox1.SelectedItem)
                .AddWithValue("@medid", ComboBox2.SelectedItem)
                .AddWithValue("@cost", TextBox1.Text.Trim())

            End With
            Dim quer1 As String = "insert into payment(sup_id,date,total_cost)values(@supid1,@date,@total)"
            Dim con1 = New MySqlConnection(constr)
            con1.Open()
            Dim cmd1 = New MySqlCommand(quer1, con1)
            With cmd1.Parameters
                .AddWithValue("@supid1", ComboBox1.SelectedItem)
                .AddWithValue("@date", DateTimePicker1.Text.ToString)
                .AddWithValue("@total", TextBox1.Text.Trim())

            End With


            'Dim rs As Integer
            'If (TextBox1.Text = "" Or TextBox2.Text = "") Then
            '    MessageBox.Show("Please Enter Values in all Boxes")
            'Else
            '    rs = cmd.ExecuteNonQuery()
            '    If (rs > 0) Then
            '        datagridupdate()
            '    End If
            'End If
            cmd.ExecuteNonQuery()
            cmd1.ExecuteNonQuery()
            Cleartext()
            con.Close()
            con1.Close()
            datagridupdate()
            MessageBox.Show("Row added to database")
        End If


    End Sub
    Public Sub Cleartext()
        TextBox1.Text = ""

        ComboBox1.Text = ""
        ComboBox2.Text = ""

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
        con.Close()

        ComboBox2.DataSource = Nothing
        ComboBox2.Items.Clear()
        Dim cmd2 As New MySqlCommand
        Dim con2 = New MySqlConnection(constr)
        con2.Open()
        cmd2.Connection = con2
        cmd2.CommandText = "Select med_id from medicine"
        Dim dr2 As MySqlDataReader
        dr2 = cmd2.ExecuteReader
        Do While dr2.Read
            ComboBox2.Items.Add(dr2("med_id"))

        Loop
        dr2.Close()
        con2.Close()
    End Sub



End Class