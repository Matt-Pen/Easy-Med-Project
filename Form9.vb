Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form9
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"
    Public fdate, tdate As String
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datagridupdate()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM/dd"
        totalcalc()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        fdate = ""
        tdate = ""
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form9_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        datagridupdate()
        Cleartext()
        fdate = ""
        tdate = ""
        totalcalc()
    End Sub
    Public Sub datagridupdate()
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select * from payment"
        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (DateTimePicker1.Text = "" Or DateTimePicker2.Text = "") Then
            MessageBox.Show("Enter the Required Dates")

        Else
            fdate = DateTimePicker1.Text
            tdate = DateTimePicker2.Text

            totalcalc()
            Dim con = New MySqlConnection(constr)
            con.Open()
            Dim quer As String = "select * from payment where date between '" + DateTimePicker1.Text.ToString + "' and '" + DateTimePicker2.Text.ToString + "'"
            Dim dta = New MySqlDataAdapter(quer, con)
            Dim dt = New DataTable()
            dta.Fill(dt)
            DataGridView1.DataSource = dt
            con.Close()
        End If

    End Sub
    Public Sub Cleartext()
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
    End Sub

    Public Sub totalcalc()
        Dim stcost, ctcost As Integer
        If fdate <> "" And tdate <> "" Then
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select * from supplier_details, payment where date between '" + DateTimePicker1.Text.ToString + "' and '" + DateTimePicker2.Text.ToString + "' and payment.sup_id = supplier_details.sup_id"
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                stcost += dr1("total_cost")

            Loop
            Label6.Text = stcost.ToString
            dr1.Close()

            cmd.CommandText = "select * from customer, payment where date between '" + DateTimePicker1.Text.ToString + "' and '" + DateTimePicker2.Text.ToString + "' and payment.cust_id = customer.cust_id"
            Dim dr2 As MySqlDataReader
            dr2 = cmd.ExecuteReader
            Do While dr2.Read
                ctcost += dr2("total_cost")
            Loop
            dr2.Close()
            Label5.Text = ctcost.ToString
            stcost = 0
            ctcost = 0
            con.Close()
        Else
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select * from supplier_details, payment where payment.sup_id = supplier_details.sup_id"
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                stcost += dr1("total_cost")

            Loop
            Label6.Text = stcost.ToString
            dr1.Close()

            cmd.CommandText = "select * from customer, payment where payment.cust_id = customer.cust_id"
            Dim dr2 As MySqlDataReader
            dr2 = cmd.ExecuteReader
            Do While dr2.Read
                ctcost += dr2("total_cost")
            Loop
            dr2.Close()
            Label5.Text = ctcost.ToString
            stcost = 0
            ctcost = 0
            con.Close()


        End If

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form15.callfunc()
        Form15.Show()
    End Sub


End Class