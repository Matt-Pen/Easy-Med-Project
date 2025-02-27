Imports MySql.Data.MySqlClient
Public Class Form7
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"
    Dim custid, custph, orddate As String
    Dim n1, n2, total, gtotal, stock As Integer

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form7_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        resetclear()
        DataGridView1.DataSource = Nothing
        Form8.Show()
        paymentinsert()
        custid = ""
        custph = ""
        orddate = ""

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.TextBox1.Text = ""
        Form1.TextBox2.Text = ""
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboupdate()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        DateTimePicker1.MinDate = Today
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox2.Text = "") Then
            MessageBox.Show("Enter the necessary Information")
        Else
            custidadd()
            datagridupdate()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        deletemidresest()
        resetclear()

        DataGridView1.DataSource = Nothing
    End Sub
    Public Sub proclear()

        TextBox2.Visible = False
        DateTimePicker1.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Button1.Visible = False

        Label5.Visible = True
        Label7.Visible = True
        Label8.Visible = True
        Label9.Visible = True
        Label11.Visible = True
        Label10.Visible = True
        Label2.Visible = True
        Label12.Visible = True
        ComboBox1.Visible = True
        ComboBox2.Visible = True
        TextBox4.Visible = True
        TextBox5.Visible = True
        TextBox1.Visible = True
        TextBox6.Visible = True
        TextBox7.Visible = True
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        Button7.Visible = True
        DataGridView1.Visible = True
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim cmd As New MySqlCommand
        Dim con = New MySqlConnection(constr)
        Dim a As String
        a = ComboBox2.SelectedItem.ToString()
        TextBox6.Text = a
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select med_id,unit_price from medicine where med_name='" + a + "'"
        Dim dr1 As MySqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read()
            TextBox1.Text = dr1("med_id")
            TextBox5.Text = dr1("unit_price")
        Loop
        ComboBox1.Text = ""
        dr1.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cmd As New MySqlCommand
        Dim con = New MySqlConnection(constr)
        Dim a As String
        a = ComboBox1.SelectedItem.ToString()
        TextBox1.Text = a
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select med_name,unit_price from medicine where med_id=" + a
        Dim dr1 As MySqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read()

            TextBox6.Text = dr1("med_name")
            TextBox5.Text = dr1("unit_price")
        Loop
        dr1.Close()
        ComboBox2.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        n1 = Val(TextBox4.Text)
        n2 = Val(TextBox5.Text)
        total = n1 * n2
        gtotal += n1 * n2

        Dim con = New MySqlConnection(constr)
        Dim quer As String = "insert into cust_purchase(cust_id,med_id,purch_quantity,unit_cost,total_cost)values(@custid,@medid,@quant,@cost,@total)"
        con.Open()
        Dim cmd = New MySqlCommand(quer, con)

        If (ComboBox1.Text = "" Or ComboBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "") Then
            Dim dr1 As MySqlDataReader
            cmd.CommandText = "select quantity from medicine where med_id=" + TextBox1.Text
            dr1 = cmd.ExecuteReader
            dr1.Read()
            stock = dr1("quantity")
            If stock < n1 Then
                MessageBox.Show("Insufficient Stock, only " + stock.ToString + "available")
            Else
                custpurinsert()
                medupdate()
                cartclear()
            End If

            dr1.Close()
            con.Close()
        End If
        TextBox7.Text = gtotal.ToString

    End Sub

    Public Sub resetclear()
        Label5.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label2.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        ComboBox1.Visible = False
        ComboBox2.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        TextBox6.Visible = False
        TextBox1.Visible = False
        TextBox7.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button7.Visible = False
        DataGridView1.Visible = False


        TextBox2.Visible = True
        DateTimePicker1.Visible = True
        Label3.Visible = True
        Label4.Visible = True

        Button1.Visible = True

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

    End Sub

    Public Sub custidadd()
        Dim con = New MySqlConnection(constr)
        Dim con2 = New MySqlConnection(constr)
        custph = TextBox2.Text
        orddate = DateTimePicker1.Text.ToString
        Dim phon As ArrayList = New ArrayList()
        Dim cmd2 As New MySqlCommand
        con2.Open()
        cmd2.Connection = con2

        Dim dr2 As MySqlDataReader
        cmd2.CommandText = "select phone_no from customer"
        dr2 = cmd2.ExecuteReader
        Do While dr2.Read()
            phon.Add(dr2("phone_no"))
        Loop
        If phon.Contains(custph) = False Then
            proclear()
            Dim quer As String = "insert into customer(phone_no)values(@phon)"
            con.Open()
            Dim cmd = New MySqlCommand(quer, con)
            With cmd.Parameters
                .AddWithValue("@phon", custph)
            End With
            Dim rs As Integer
            If (TextBox2.Text = "") Then
                MessageBox.Show("Please Enter Values in all Boxes")
            Else
                rs = cmd.ExecuteNonQuery()
                If (rs > 0) Then
                    'datagridupdate()
                End If
            End If

            Dim dr1 As MySqlDataReader
            cmd.CommandText = "select cust_id from customer where phone_no=" + custph
            dr1 = cmd.ExecuteReader
            dr1.Read()
            custid = dr1("cust_id")
            'MessageBox.Show("cust id:" + custid.ToString)
            dr1.Close()

        Else
            resetclear()
            MessageBox.Show("Phone Number Already Exists")
        End If
        dr2.Close()
        con.Close()
        con2.Close()
        phon.Clear()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim delcost, delamt As Integer
        Dim quer As String = "delete from cust_purchase where cust_id=@custid and med_id=@medid"
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim cmd = New MySqlCommand(quer, con)
        With cmd.Parameters
            .AddWithValue("@custid", custid)
            .AddWithValue("@medid", DataGridView1.SelectedRows(0).Cells(1).Value.ToString)

        End With
        delcost = Val(DataGridView1.SelectedRows(0).Cells(4).Value.ToString)
        delamt = Val(DataGridView1.SelectedRows(0).Cells(2).Value.ToString)
        gtotal = gtotal - delcost
        TextBox7.Text = gtotal
        cmd.ExecuteNonQuery()

        Dim cmd1 As New MySqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "update medicine set quantity=quantity+ @quant where med_id=@medid"
        cmd1.Parameters.AddWithValue("@quant", delamt)
        cmd1.Parameters.AddWithValue("@medid", DataGridView1.SelectedRows(0).Cells(1).Value.ToString)
        cmd1.ExecuteNonQuery()

        datagridupdate()
        con.Close()
        comboupdate()
        MessageBox.Show("Row deleted")
    End Sub


    Public Sub cartclear()
        TextBox1.Text = ""
        TextBox6.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub



    Public Sub datagridupdate()
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select * from cust_purchase where cust_id=" + custid
        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()
    End Sub
    Public Sub medupdate()
        Dim con2 = New MySqlConnection(constr)
        con2.Open()
        Dim cmd2 As New MySqlCommand
        cmd2.Connection = con2

        With cmd2
            cmd2.CommandText = "update medicine set quantity=quantity-@quant where med_id=@medid"
            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@quant", TextBox4.Text)
            .Parameters.AddWithValue("@medid", TextBox1.Text)
        End With
        cmd2.ExecuteNonQuery()

        con2.Close()
    End Sub
    Public Sub custpurinsert()
        Dim con = New MySqlConnection(constr)
        Dim quer As String = "insert into cust_purchase(cust_id,med_id,purch_quantity,unit_cost,total_cost)values(@custid,@medid,@quant,@cost,@total)"
        con.Open()
        Dim cmd = New MySqlCommand(quer, con)
        With cmd.Parameters
            .AddWithValue("@custid", custid)
            .AddWithValue("@medid", TextBox1.Text.Trim())
            .AddWithValue("@quant", TextBox4.Text.Trim())
            .AddWithValue("@cost", TextBox5.Text.Trim())
            .AddWithValue("@total", total)
        End With
        Dim rs As Integer
        If (TextBox2.Text = "") Then
            MessageBox.Show("Please Enter Values in all Boxes")
        Else
            rs = cmd.ExecuteNonQuery()
            If (rs > 0) Then
                datagridupdate()

            End If
        End If
    End Sub

    Public Sub paymentinsert()
        'MessageBox.Show("thevalues " + custid.ToString + orddate.ToString + gtotal.ToString)
        Dim quer1 As String = "insert into payment(cust_id,date,total_cost)values(@custid1,@date,@total)"
        Dim con1 = New MySqlConnection(constr)
        con1.Open()
        Dim cmd1 = New MySqlCommand(quer1, con1)
        With cmd1.Parameters
            .AddWithValue("@custid1", custid)
            .AddWithValue("@date", orddate)
            .AddWithValue("@total", gtotal)

        End With
        cmd1.ExecuteNonQuery()
        gtotal = 0
    End Sub
    Public Sub comboupdate()
        ComboBox1.DataSource = Nothing
        ComboBox2.DataSource = Nothing
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()

        Dim cmd As New MySqlCommand
        Dim con = New MySqlConnection(constr)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select med_id,med_name from medicine"
        Dim dr1 As MySqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read
            ComboBox1.Items.Add(dr1("med_id"))
            ComboBox2.Items.Add(dr1("med_name"))
        Loop
        dr1.Close()
    End Sub
    Public Sub deletemidresest()
        Dim quer As String = "delete from cust_purchase where cust_id=@custid"
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim cmd = New MySqlCommand(quer, con)
        With cmd.Parameters
            .AddWithValue("@custid", custid)
        End With

        cmd.ExecuteNonQuery()
        datagridupdate()
        con.Close()
        custid = ""
        custph = ""
        orddate = ""
        gtotal = 0
    End Sub
End Class