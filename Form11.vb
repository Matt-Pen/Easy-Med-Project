Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form11
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"
    Public custid As String
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboupdate()
        totalcalc()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form3.Show()
        Me.Hide()
    End Sub
    Public Sub datagridupdate()
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select cust_id, cust_purchase.med_id, med_name, purch_quantity, unit_cost,total_cost from cust_purchase,medicine where medicine.med_id=cust_purchase.med_id order by cust_id"
        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cleartext()
        datagridupdate()
        totalcalc()
        custid = ""
    End Sub

    Private Sub Form11_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Public Sub comboupdate()
        ComboBox1.DataSource = Nothing
        ComboBox1.Items.Clear()
        Dim cid As Integer
        Dim cmd As New MySqlCommand
        Dim con = New MySqlConnection(constr)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select cust_id from cust_purchase"
        Dim dr1 As MySqlDataReader
        dr1 = cmd.ExecuteReader
        Do While dr1.Read
            cid = dr1("cust_id")
            If ComboBox1.Items.Contains(cid) Then
                Continue Do
            Else
                ComboBox1.Items.Add(cid)
            End If

        Loop
        dr1.Close()
        datagridupdate()
    End Sub
    Public Sub cleartext()
        ComboBox1.Text = ""
    End Sub
    Public Sub combosearch()
        If ComboBox1.Text = "" Then
            MessageBox.Show("Enter The Customer ID")
        Else
            Dim con = New MySqlConnection(constr)
            con.Open()
            Dim quer As String = "select cust_id, cust_purchase.med_id, med_name, purch_quantity, unit_cost,total_cost from cust_purchase,medicine where medicine.med_id=cust_purchase.med_id and cust_id=" + ComboBox1.Text.ToString
            Dim dta = New MySqlDataAdapter(quer, con)
            Dim dt = New DataTable()
            dta.Fill(dt)
            DataGridView1.DataSource = dt

            con.Close()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        custid = ComboBox1.Text.ToString
        totalcalc()
        combosearch()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.callfunc()
        Form2.Show()
    End Sub
    Public Sub totalcalc()
        Dim tcost As Integer
        If ComboBox1.Text <> "" Then
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select cust_id, cust_purchase.med_id, med_name, purch_quantity, unit_cost,total_cost from cust_purchase,medicine where medicine.med_id=cust_purchase.med_id and cust_id=" + ComboBox1.Text.ToString
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                tcost += dr1("Total_cost")


            Loop
            Label6.Text = tcost.ToString
            con.Close()
        Else
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select cust_id, cust_purchase.med_id, med_name, purch_quantity, unit_cost,total_cost from cust_purchase,medicine where medicine.med_id=cust_purchase.med_id order by cust_id"
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                tcost += dr1("Total_cost")
            Loop
            Label6.Text = tcost.ToString
            con.Close()
        End If
    End Sub


End Class