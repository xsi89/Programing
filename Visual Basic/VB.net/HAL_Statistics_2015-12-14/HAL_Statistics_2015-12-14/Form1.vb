Imports System.Data.SqlClient
Public Class Form1
    Public connetionString = ("Data Source=ttdev\Teknotrans_dev;Initial Catalog=Teknotrans_dev;Integrated Security=True")

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim CompanyandID_Table As New DataTable
        Dim CompanyandID_Table_ds As New DataSet
        '  Dim Year_Table As New DataTable
        ' Dim Year_Table_ds As New DataSet
        Dim myConn As New SqlConnection(connetionString)


        CompanyandID_Table.Columns.Add("Name", GetType(System.String))
        CompanyandID_Table.Columns.Add("Id", GetType(System.String))
        '        Year_Table.Columns.Add("Year", GetType(System.String))


        Dim CompanyandID As New SqlDataAdapter("SELECT [t0].[Name],[t0].[Id] FROM [CompanyMain] AS [t0] ", myConn)

        Dim Year As New SqlDataAdapter("SELECT [t0].[bestdatum] AS [Bestdatum]FROM [OpusOrder] AS [t0]", myConn)

        myConn.Open()


        CompanyandID.Fill(CompanyandID_Table_ds, "Name")
        CompanyandID.Fill(CompanyandID_Table_ds, "Id")

        Dim Item_X As DataRow
        For Each Item_X In CompanyandID_Table_ds.Tables(0).Rows()
            Dim Item_Res As String = "(" & (Item_X.Item(1).ToString() & ")   " & Item_X.Item(0).ToString())
            Cbx_Company.Items.Add(Item_Res)
        Next



        Dim QueryString As String = String.Concat(CompanyandID, ";", Year)
        Dim command As New SqlCommand(QueryString, myConn)
        command.Connection.Open()
        command.ExecuteNonQuery()



        'Dim cbx_Months As New Dictionary(Of String, Integer)
        'Cbx_FromMonth.Add("Jan", 1)
        'Cbx_FromMonth.Add("Feb", 2)
        'Cbx_FromMonth.Add("Mar", 3)
        'Cbx_FromMonth.Add("Apr", 4)
        'Cbx_FromMonth.Add("May", 5)
        'Cbx_FromMonth.Add("Jun", 6)
        'Cbx_FromMonth.Add("Jul", 7)
        'Cbx_FromMonth.Add("Aug", 8)
        'Cbx_FromMonth.Add("Sep", 9)
        'Cbx_FromMonth.Add("Okt", 10)
        'Cbx_FromMonth.Add("Nov", 11)
        'Cbx_FromMonth.Add("Dec", 12)
        'Cbx_FromMonth.DataSource = New BindingSource(cbx_Months, Nothing)





        Dim FromMonths As New Dictionary(Of String, Integer)
        FromMonths.Add("Jan", 1)
        Cbx_FromMonths.DataSource = New BindingSource(Cbx_FromMonths, Nothing)


        



















    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        DataGridView1.DataSource = Nothing
        Dim da As SqlDataAdapter
        Dim ds2 As DataSet
        Dim SQLStr As String
        Dim SQLMStr As String
        Dim cnn As SqlConnection
        ' Dim CompanyN As String = (Cbx_Company.SelectedItem.Item(0))

        cnn = New SqlConnection(connetionString)
        cnn.Open()

        'Query för alla kolumner
        SQLStr = " SELECT " & _
        "tt.ordernr 'Teknotrans Number', " & _
        "tt.offertnr 'Offertnr', " & _
        "c.Name 'Company', " & _
        "tt.DescriptionHeader  'Type of documentation', " & _
        "tt.bestdatum 'Year', " & _
        "tt.bestdatum 'Month', " & _
        "snSrc.kod 'Source Language',  " & _
        "snTrg.kod 'Target Language',  " & _
        "ord.antal50_74 + ord.antalnohit 'No of New words', " & _
        "ord.antal75_84 + ord.antal85_94 + ord.antal95_99  'No of Fuzzy matches', " & _
        "ord.antal100 + ord.antalrep 'No of 100% match And Repetitions', " & _
        "ord.interna_timmar 'Project management (cost EUR)' " & _
        "FROM [teknotrans_dev].dbo.OpusOrder tt INNER JOIN " & _
        "[teknotrans_dev].dbo.CompanyMain c On tt.bolagsnr = c.id INNER JOIN  " & _
        "[teknotrans_dev].dbo.OpusOrderrow ord On ord.ordernr = tt.ordernr INNER JOIN " & _
        "[teknotrans_dev].dbo.OrderVolvoLanguageName snSrc ON ord.kallspraknr = snSrc.spraknr INNER JOIN " & _
        "[teknotrans_dev].dbo.OrderVolvoLanguageName snTrg ON ord.malspraknr = snTrg.spraknr  " & _
        "WHERE (DATEPART(year, tt.bestdatum) = '2015') and (DATEPART(month, tt.bestdatum)BETWEEN {0} and {1}) and (tt.makulerad=0) and (ord.makulerad= 0) AND c.Name like'V%'" & _
        "ORDER BY tt.ordernr,snSrc.kod, snTrg.kod "

        Dim FromMonth = (Cbx_FromMonths.SelectedItem.ToString().Chars(6))
        Dim ToMonth = (Cbx_FromMonths.SelectedItem.ToString().Chars(6))

        SQLMStr = String.Format(SQLStr, FromMonth, ToMonth)

        da = New SqlDataAdapter(SQLMStr, cnn)
        ds2 = New DataSet
        da.Fill(ds2)
        DataGridView1.DataSource = ds2.Tables(0)






        '        Dim myQueryTemplate As String = "SELECT employeeid, {0}, {1} FROM employees"
        '        Dim myFinalQuery As String = String.Format(myQueryTemplate, transport, Leave)


        '"SELECT employeeid, transport, leave FROM employees"






    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Dim da As SqlDataAdapter
        Dim SQLStr As String
        '  Dim SQLMStr As String
        Dim Con As SqlConnection = Nothing
        Con = New SqlConnection(connetionString)
        Con.Open()
        SQLStr = "SELECT [t0].[Name] FROM [CompanyMain] AS [t0] WHERE [t0].[IsActive] = 1"
        da = New SqlDataAdapter(SQLStr, Con)


    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Company.SelectedIndexChanged


        Dim comboBox As ComboBox = CType(sender, ComboBox)

        If Cbx_Company.SelectedItem IsNot Nothing Then
            Dim curValue = CType(Cbx_Company.SelectedItem, String)


            MsgBox(curValue)

        End If



    End Sub

    Private Sub Cbx_Company_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim thisConnection As New SqlConnection("Data Source=ttdev\Teknotrans_dev;Initial Catalog=Teknotrans_dev;Integrated Security=True")
        '   Dim cmdRecord As New SqlCommand("SELECT [t0].[Name],[t0].[Id] FROM [CompanyMain] AS [t0]", connetionString)
        '  Dim cmdRecordItem As New SqlCommand("SELECT [t0].[bestdatum] AS [Bestdatum]FROM [OpusOrder] AS [t0]", connetionString)





    End Sub

    Private Sub Cbx_FromMonths_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_FromMonths.SelectedIndexChanged

    End Sub
End Class









