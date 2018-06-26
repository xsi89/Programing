Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Public tb As New DataTable()
   

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ComboBox1.Items.Add("1643")
        ComboBox1.Items.Add("47")
        ComboBox1.Items.Add("48")
        ComboBox1.Items.Add("49")
        ComboBox1.Items.Add("137")

        With dgvData
            .AutoGenerateColumns = True
            .DataSource = tb
        End With


     


    End Sub


    Public Function GetName(ByVal bolagsid As String) As DataTable
        Dim SQLCon As New SqlConnection("Data Source=TTDEV\TEKNOTRANS_DEV;Initial Catalog=Teknotrans_dev;Integrated Security=True")
        Dim Query As String
        Dim ds As New DataSet()
        Dim cmd As New SqlCommand()
        Dim da As SqlDataAdapter
        SQLCon.Open()


        cmd.Parameters.AddWithValue("@bolagsid", bolagsid)
        Query = ("SELECT c.Name 'Company'FROM [Teknotrans_dev].dbo.OpusOrder as tt INNER JOIN [Teknotrans_dev].dbo.CompanyMain as c On tt.bolagsnr = c.id INNER JOIN [Teknotrans_dev].dbo.OpusOrderrow as ord On ord.ordernr = tt.ordernr WHERE (DATEPART(year, tt.bestdatum) = '2015') and (DATEPART(month, tt.bestdatum)BETWEEN '1' and '11') and (tt.makulerad=0) and (ord.makulerad= 0) AND c.id =@bolagsid")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = Query
        cmd.Connection = SQLCon

        da = New SqlDataAdapter(Query, SQLCon)
        da.Fill(ds)
        tb = ds.Tables(0)
        Return tb
        SQLCon.Close()



    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim SConn As String = "Data Source=TTDEV\TEKNOTRANS_DEV;Initial Catalog=Teknotrans_dev;Integrated Security=True"
        Dim sSql As String = "SELECT c.Name 'Company'FROM [Teknotrans_dev].dbo.OpusOrder as tt INNER JOIN [Teknotrans_dev].dbo.CompanyMain as c On tt.bolagsnr = c.id INNER JOIN [Teknotrans_dev].dbo.OpusOrderrow as ord On ord.ordernr = tt.ordernr WHERE (DATEPART(year, tt.bestdatum) = '2015') and (DATEPART(month, tt.bestdatum)BETWEEN '1' and '11') and (tt.makulerad=0) and (ord.makulerad= 0) AND c.id =@bolagsid"

        Dim Conn As New SqlConnection(SConn)
        Dim cmd As New SqlCommand(sSql, Conn)

        cmd.Parameters.Add("@bolagsid", SqlDbType.NVarChar)
        cmd.Parameters("@bolagsid").Value = ComboBox1.Text

        'easier to add in one go, and let the database deal with the data-type:


        Dim adapter As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adapter.Fill(ds, "OrdersTable")

        dgvData.DataSource = ds
        dgvData.DataMember = "OrdersTable"








    End Sub
End Class
