﻿Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Public Class Form2
    Dim constr = "server=localhost; user id=root; password= 0126; database=easy-medicine;"
    Dim custid As String
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.MaxDate = Today
        DateTimePicker1.MinDate = Today
    End Sub
    Public Sub readvars()
        custid = Form11.custid
    End Sub
    Public Sub datagridinput()
        If custid <> "" Then
            Label7.Visible = True
            Label8.Visible = True

            Label8.Text = custid
            Dim con = New MySqlConnection(constr)
            con.Open()
            Dim quer As String = "select cust_id, cust_purchase.med_id, med_name, purch_quantity, unit_cost,total_cost from cust_purchase,medicine where medicine.med_id=cust_purchase.med_id and cust_id=" + custid
            Dim dta = New MySqlDataAdapter(quer, con)
            Dim dt = New DataTable()
            dta.Fill(dt)
            DataGridView1.DataSource = dt

            con.Close()
        Else
            Label7.Visible = False
            Label8.Visible = False


            Dim con = New MySqlConnection(constr)
            con.Open()
            Dim quer As String = "select cust_id, cust_purchase.med_id, med_name, purch_quantity, unit_cost,total_cost from cust_purchase,medicine where medicine.med_id=cust_purchase.med_id order by cust_id"
            Dim dta = New MySqlDataAdapter(quer, con)
            Dim dt = New DataTable()
            dta.Fill(dt)
            DataGridView1.DataSource = dt

            con.Close()
        End If
    End Sub

    Public Sub setreportid()
        Dim cmd As New MySqlCommand
        Dim con = New MySqlConnection(constr)
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "select reportid from bill_report"
        Dim dr1 As MySqlDataReader
        dr1 = cmd.ExecuteReader
        dr1.Read()
        Label3.Text = dr1("reportid").ToString
        con.Close()

        Dim con1 = New MySqlConnection(constr)
        con1.Open()
        Dim cmd1 As New MySqlCommand
        cmd1.Connection = con1
        cmd1.CommandText = "update bill_report set reportid = reportid + 1"
        cmd1.ExecuteNonQuery()
        con1.Close()

    End Sub

    Public Sub callfunc()
        readvars()
        datagridinput()
        Label6.Text = Form11.Label6.Text
        setreportid()
    End Sub

    Dim WithEvents mPrintDocument As New PrintDocument
    Dim mPrintBitMap As Bitmap

    Private Sub m_PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles mPrintDocument.PrintPage

        Dim lWidth As Integer = e.MarginBounds.X + (e.MarginBounds.Width - mPrintBitMap.Width) \ 2
        Dim lHeight As Integer = e.MarginBounds.Y + (e.MarginBounds.Height - mPrintBitMap.Height) \ 2
        e.Graphics.DrawImage(mPrintBitMap, lWidth, lHeight)


        e.HasMorePages = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.FormBorderStyle = FormBorderStyle.None
        Button1.Visible = False
        mPrintBitMap = New Bitmap(Me.Width, Me.Height)
        Dim lRect As System.Drawing.Rectangle
        lRect.Width = Me.Width
        lRect.Height = Me.Height
        Me.DrawToBitmap(mPrintBitMap, lRect)

        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        mPrintDocument = New PrintDocument
        mPrintDocument.Print()

        Me.Hide()
        Button1.Visible = True
    End Sub
End Class