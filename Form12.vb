Imports System.Runtime.CompilerServices
Imports MySql.Data.MySqlClient

Public Class Form12
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"
    Public supid As String
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboupdate()
        totalcalc()
    End Sub
    Public Sub datagridupdate()
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select supplier_pur.sup_id, company, supplier_pur.med_id, medicine.med_name, cost_of_purchase from supplier_details,supplier_pur,medicine where supplier_details.sup_id=supplier_pur.sup_id and supplier_pur.med_id=medicine.med_id order by supplier_pur.sup_id"
        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        con.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cleartext()
        supid = ""
        totalcalc()
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
    Public Sub cleartext()
        ComboBox1.Text = ""
    End Sub
    Public Sub combosearch()
        supid = ComboBox1.Text
        Dim con = New MySqlConnection(constr)
        con.Open()
        Dim quer As String = "select supplier_pur.sup_id, company, supplier_pur.med_id, medicine.med_name, cost_of_purchase from supplier_details,supplier_pur,medicine where supplier_details.sup_id=supplier_pur.sup_id and supplier_pur.med_id=medicine.med_id and supplier_pur.sup_id=" + ComboBox1.Text.ToString

        Dim dta = New MySqlDataAdapter(quer, con)
        Dim dt = New DataTable()
        dta.Fill(dt)
        DataGridView1.DataSource = dt

        totalcalc()
        con.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        combosearch()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form14.callfunc()
        Form14.Show()

    End Sub

    Public Sub totalcalc()
        Dim tcost As Integer
        If ComboBox1.Text <> "" Then
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select supplier_pur.sup_id, company, supplier_pur.med_id, medicine.med_name, cost_of_purchase from supplier_details,supplier_pur,medicine where supplier_details.sup_id=supplier_pur.sup_id and supplier_pur.med_id=medicine.med_id and supplier_pur.sup_id=" + ComboBox1.Text.ToString
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                tcost += dr1("cost_of_purchase")


            Loop
            Label6.Text = tcost.ToString
            con.Close()
        Else
            Dim cmd As New MySqlCommand
            Dim con = New MySqlConnection(constr)
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select supplier_pur.sup_id, company, supplier_pur.med_id, medicine.med_name, cost_of_purchase from supplier_details,supplier_pur,medicine where supplier_details.sup_id=supplier_pur.sup_id and supplier_pur.med_id=medicine.med_id order by supplier_pur.sup_id"
            Dim dr1 As MySqlDataReader
            dr1 = cmd.ExecuteReader
            Do While dr1.Read
                tcost += dr1("cost_of_purchase")
            Loop
            Label6.Text = tcost.ToString
            con.Close()
        End If
    End Sub
    Private Sub Form12_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class