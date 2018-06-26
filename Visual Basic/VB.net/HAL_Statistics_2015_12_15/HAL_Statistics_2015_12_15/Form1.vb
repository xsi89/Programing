Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions


Public Class DG2
    Public QueryList As New ArrayList()
    Private SQL As New SQLController
    Public connectionString = ("Data Source=ttdev\Teknotrans_dev;Initial Catalog=Teknotrans_dev;Integrated Security=True")
    Public TTCon As New SqlConnection(connectionString)
    Public ds2 As DataSet
    Public ds As New DataSet()
    Public excel As New Microsoft.Office.Interop.Excel.Application
    Public wBook As Microsoft.Office.Interop.Excel.Workbook
    Public wSheet As Microsoft.Office.Interop.Excel.Worksheet

    'Public FromMonthsVal = CType(Cbx_From_Months.SelectedItem.ToString(), String)
    'Public FromMonthsValOnlDig = New String(FromMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
    'Public FromMonthsValdig = Int32.Parse(FromMonthsValOnlDig)

    ''Query strängdelen för Månad till
    'Public ToMonthsVal = CType(Cbx_To_Months.SelectedItem.ToString(), String)
    'Public ToMonthsValOnlDig = New String(ToMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
    'Public ToMonthsValdig = Int32.Parse(ToMonthsValOnlDig)

    ''Query strängdelen för bolagsID tagen från cbx_Company (två första tecknen)
    'Public CompanyVal = CType(Cbx_Company.SelectedItem.ToString(), String)
    'Public CompanyValOnlDig = New String(CompanyVal.Where(Function(c) Char.IsDigit(c)).ToArray())
    'Dim CompanyValdig = Int32.Parse(CompanyValOnlDig)
    'Public Bolagsid = CompanyValdig.ToString().Substring(0, 2) ' query sträng för bolagsid

    ''Query strängdelen för år från
    'Public YearFromVal = CType(Cbx_FromYear.SelectedItem.ToString(), String)
    'Public YerFromValDigOn = New String(YearFromVal.Where(Function(c) Char.IsDigit(c)).ToArray())
    'Public YearFromvalValdig = Int32.Parse(YerFromValDigOn)

    ''Query strängdelen för år till
    'Public YearToVal = CType(Cbx_ToYear.SelectedItem.ToString(), String)
    'Public YerToValDigOn = New String(YearToVal.Where(Function(c) Char.IsDigit(c)).ToArray())
    'Public YearTovalValdig = Int32.Parse(YerToValDigOn)



    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState <> FormWindowState.Minimized Then
            Me.DataGridView1.Size = New Size(Me.ClientRectangle.Width - 10, Me.ClientRectangle.Height - 50)
        End If
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim CompanyandID_Table As New DataTable
        Dim CompanyandID_Table_ds As New DataSet
        Dim Months As New Dictionary(Of String, Integer)
        Dim CompanyandID As New SqlDataAdapter("SELECT [t0].[Name],[t0].[Id] FROM [CompanyMain] AS [t0] ", TTCon)
        Dim Year As New SqlDataAdapter("SELECT [t0].[bestdatum] AS [Bestdatum]FROM [OpusOrder] AS [t0]", TTCon)

        CompanyandID_Table.Columns.Add("Name", GetType(System.String))
        CompanyandID_Table.Columns.Add("Id", GetType(System.String))
        QueryList.Add("tt.ordernr 'Teknotrans Number', ")

        Months.Add("Jan", 1)
        Months.Add("Feb", 2)
        Months.Add("Mar", 3)
        Months.Add("Apr", 4)
        Months.Add("May", 5)
        Months.Add("Jun", 6)
        Months.Add("Jul", 7)
        Months.Add("Aug", 8)
        Months.Add("Sep", 9)
        Months.Add("Okt", 10)
        Months.Add("Nov", 11)
        Months.Add("Dec", 12)
        Cbx_From_Months.DataSource = New BindingSource(Months, Nothing)
        Cbx_To_Months.DataSource = New BindingSource(Months, Nothing)

        TTCon.Open()
        CompanyandID.Fill(CompanyandID_Table_ds, "Name")
        CompanyandID.Fill(CompanyandID_Table_ds, "Id")

        Dim Item_X As DataRow
        For Each Item_X In CompanyandID_Table_ds.Tables(0).Rows()
            Dim Item_Res As String = "(" & (Item_X.Item(1).ToString() & ")   " & Item_X.Item(0).ToString())
            Cbx_Company.Items.Add(Item_Res)
        Next

        Cbx_Company.SelectedIndex = 0

        Dim QueryString As String = String.Concat(CompanyandID, ";", Year)
        Dim command As New SqlCommand(QueryString, TTCon)
        command.Connection.Open()
        command.ExecuteNonQuery()
        MsgBox(Cbx_From_Months.Text)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Fill_Grid.Click

        Dim da As SqlDataAdapter
        Dim SQLStr As String
        Dim SQLMStr As String
        Dim cnn As SqlConnection
        DataGridView1.DataSource = Nothing

        cnn = New SqlConnection(connectionString)
        cnn.Open()

        'Query strängdelen för Månad från
        Dim FromMonthsVal = CType(Cbx_From_Months.SelectedItem.ToString(), String)
        Dim FromMonthsValOnlDig = New String(FromMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim FromMonthsValdig = Int32.Parse(FromMonthsValOnlDig)

        'Query strängdelen för Månad till
        Dim ToMonthsVal = CType(Cbx_To_Months.SelectedItem.ToString(), String)
        Dim ToMonthsValOnlDig = New String(ToMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim ToMonthsValdig = Int32.Parse(ToMonthsValOnlDig)

        'Query strängdelen för bolagsID tagen från cbx_Company (två första tecknen)
        Dim CompanyVal = CType(Cbx_Company.SelectedItem.ToString(), String)
        Dim CompanyValOnlDig = New String(CompanyVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim CompanyValdig = Int32.Parse(CompanyValOnlDig)
        Dim Bolagsid = CompanyValdig.ToString().Substring(0, 2) ' query sträng för bolagsid

        'Query strängdelen för år från
        Dim YearFromVal = CType(Cbx_FromYear.SelectedItem.ToString(), String)
        Dim YerFromValDigOn = New String(YearFromVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim YearFromvalValdig = Int32.Parse(YerFromValDigOn)

        'Query strängdelen för år till
        Dim YearToVal = CType(Cbx_ToYear.SelectedItem.ToString(), String)
        Dim YerToValDigOn = New String(YearToVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim YearTovalValdig = Int32.Parse(YerToValDigOn)

        'Query för alla kolumner
        SQLStr = " SELECT " & _
        "tt.ordernr 'Order number', " & _
        "tt.offertnr 'Offertnr', " & _
        "tt.Bestallarnr 'Owner', " & _
        "c.Name 'Company', " & _
        "tt.DescriptionHeader  'Type of documentation', " & _
        "tt.bestdatum 'Year', " & _
        "tt.bestdatum 'Month', " & _
        "snSrc.kod 'Source language',  " & _
        "snTrg.kod 'Target language',  " & _
        "ord.antal50_74 + ord.antalnohit 'No of New words', " & _
        "ord.antal75_84 + ord.antal85_94 + ord.antal95_99  'No of Fuzzy matches', " & _
        "ord.antal100 + ord.antalrep 'No of 100% match And Repetitions', " & _
        "ord.interna_timmar 'Project management (cost EUR)' " & _
        "FROM [teknotrans_dev].dbo.OpusOrder tt INNER JOIN " & _
        "[teknotrans_dev].dbo.CompanyMain c On tt.bolagsnr = c.id INNER JOIN  " & _
        "[teknotrans_dev].dbo.OpusOrderrow ord On ord.ordernr = tt.ordernr INNER JOIN " & _
        "[teknotrans_dev].dbo.OrderVolvoLanguageName snSrc ON ord.kallspraknr = snSrc.spraknr INNER JOIN " & _
        "[teknotrans_dev].dbo.OrderVolvoLanguageName snTrg ON ord.malspraknr = snTrg.spraknr  " & _
        "WHERE (DATEPART(year, tt.bestdatum) BETWEEN '" & YearFromvalValdig & "' and '" & YearTovalValdig & "') and (DATEPART(month, tt.bestdatum)BETWEEN '" & FromMonthsValdig & "' and " & "'" & ToMonthsValdig & "'" & ") and (tt.makulerad=0) and (ord.makulerad= 0) AND c.ID=" & Bolagsid & " ORDER BY tt.ordernr,snSrc.kod, snTrg.kod "

        Dim cmd As New SqlCommand(SQLStr, cnn)
        Dim FromMonth = (Cbx_From_Months.SelectedItem.ToString().Chars(6))
        Dim ToMonth = (Cbx_To_Months.SelectedItem.ToString().Chars(6))
        SQLMStr = String.Format(SQLStr, FromMonth, ToMonth)

        da = New SqlDataAdapter(SQLMStr, TTCon)
        ds2 = New DataSet
        da.Fill(ds2)
        DataGridView1.DataSource = ds2.Tables(0)

        Dim SConn As String = "Data Source=TTDEV\TEKNOTRANS_DEV;Initial Catalog=Teknotrans_dev;Integrated Security=True"
        Dim sSql As String = "SELECT c.Name 'Company'FROM [Teknotrans_dev].dbo.OpusOrder as tt INNER JOIN [Teknotrans_dev].dbo.CompanyMain as c On tt.bolagsnr = c.id INNER JOIN [Teknotrans_dev].dbo.OpusOrderrow as ord On ord.ordernr = tt.ordernr WHERE (DATEPART(year, tt.bestdatum) = '2015') and (DATEPART(month, tt.bestdatum)BETWEEN '1' and '11') and (tt.makulerad=0) and (ord.makulerad= 0) AND c.id =@bolagsid"
        Dim Conn As New SqlConnection(SConn)
        '  cmd.Parameters.Add("@bolagsid", SqlDbType.NVarChar)
        '  cmd.Parameters("@bolagsid").Value = ComboBox1.Text
        'easier to add in one go, and let the database deal with the data-type:
        Dim adapter As New SqlDataAdapter(cmd)
        adapter.Fill(ds, "OrdersTable")
        Console.WriteLine(SQLStr)
        cnn.Close()


    End Sub

    Private Sub Cbx_Company_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Company.SelectedIndexChanged
        Dim Combobox As ComboBox = CType(sender, ComboBox)
        If Cbx_Company.SelectedItem IsNot Nothing Then
            Dim CurrentVal = CType(Cbx_Company.SelectedItem, String)
            ' MsgBox(CurrentVal)

        End If

    End Sub


    Private Sub Cbx_FromYear_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbx_FromYear.TabIndexChanged

        Dim Combobox As ComboBox = CType(sender, ComboBox)
        If Cbx_FromYear.SelectedItem IsNot Nothing Then
            Dim CurrentVal = CType(Cbx_FromYear.SelectedItem, String)
            '  MsgBox(CurrentVal)
        End If

        Dim Year_List_HashTable As New List(Of Integer)
        Dim Years_list As List(Of Integer)
        Dim dt As New DataTable()
        Dim dv As New DataView(dt)
        Dim ConnectionString As String = "Data Source=ttdev\Teknotrans_dev;Initial Catalog=Teknotrans_dev;Integrated Security=True"
        Dim myconn As New SqlConnection(ConnectionString)
        myconn.Open()
        Using da As New SqlDataAdapter("SELECT DISTINCT [t0].[bestdatum] AS [Bestdatum]FROM [OpusOrder] AS [t0]", myconn)
            da.Fill(dt)
        End Using
        myconn.Close()
        Dim Years_Table As DataTable = dv.ToTable(True, "Bestdatum") ' tabellen ur databasen samt kolumen med datan
        For Each customer As DataRow In Years_Table.Rows
            Dim Year_Item = (customer("Bestdatum").ToString)
            Dim Year_String As String = (Year_Item.Substring(0, Year_Item.Length - 15))
            Year_List_HashTable.Add(Year_String)
        Next
        Years_list = Year_List_HashTable.Distinct().ToList ' Ta bort dubletter
        Years_list.Sort()
        For Each item In Years_list
            Cbx_FromYear.Items.Add(item)
        Next
        Cbx_FromYear.SelectedIndex = 0
    End Sub

    Private Sub Cbx_ToYear_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbx_ToYear.TabIndexChanged

        Dim Combobox As ComboBox = CType(sender, ComboBox)
        If Cbx_FromYear.SelectedItem IsNot Nothing Then
            Dim CurrentVal = CType(Cbx_ToYear.SelectedItem, String)
            '  MsgBox(CurrentVal)
        End If

        Dim Year_List_HashTable As New List(Of Integer)
        Dim Years_list As List(Of Integer)
        Dim dt As New DataTable()
        Dim dv As New DataView(dt)
        Dim ConnectionString As String = "Data Source=ttdev\Teknotrans_dev;Initial Catalog=Teknotrans_dev;Integrated Security=True"
        Dim myconn As New SqlConnection(ConnectionString)
        myconn.Open()
        Using da As New SqlDataAdapter("SELECT DISTINCT [t0].[bestdatum] AS [Bestdatum]FROM [OpusOrder] AS [t0]", myconn)
            da.Fill(dt)
        End Using
        myconn.Close()
        Dim Years_Table As DataTable = dv.ToTable(True, "Bestdatum") ' tabellen ur databasen samt kolumen med datan
        For Each customer As DataRow In Years_Table.Rows
            Dim Year_Item = (customer("Bestdatum").ToString)
            Dim Year_String As String = (Year_Item.Substring(0, Year_Item.Length - 15))
            Year_List_HashTable.Add(Year_String)
        Next
        Years_list = Year_List_HashTable.Distinct().ToList ' Ta bort dubletter
        Years_list.Sort()
        For Each item In Years_list
            Cbx_ToYear.Items.Add(item)
        Next
        Cbx_ToYear.SelectedIndex = 0
    End Sub

    'Private Sub Cbx_ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dset As New DataSet
    '    dset.Tables.Add(1)
    '    Dim dr1 As DataRow
    '    Dim dt As System.Data.DataTable = dset.Tables(1)
    '    Dim dc As System.Data.DataColumn
    '    Dim dr As System.Data.DataRow
    '    Dim colIndex As Integer = 0
    '    Dim rowIndex As Integer = 0
    '    ' Dim strFileName As String = "D:\ss.xls"
    '    Dim blnFileOpen As Boolean = False
    '    excel.Visible = True

    '    If ((DataGridView2.Columns.Count = 0) Or (DataGridView2.Rows.Count = 0)) Then
    '        Exit Sub
    '    End If

    '    'add table to dataset
    '    dset.Tables.Add()
    '    'add column to that table
    '    For i As Integer = 0 To DataGridView2.ColumnCount - 1
    '        dset.Tables(0).Columns.Add(DataGridView2.Columns(i).HeaderText)
    '    Next
    '    'add rows to the table

    '    For i As Integer = 0 To DataGridView2.RowCount - 1
    '        dr1 = dset.Tables(0).NewRow
    '        For j As Integer = 0 To DataGridView2.Columns.Count - 1
    '            dr1(j) = DataGridView2.Rows(i).Cells(j).Value
    '        Next
    '        dset.Tables(0).Rows.Add(dr1)
    '    Next
    '    wBook = excel.Workbooks.Add()
    '    wSheet = wBook.ActiveSheet()

    '    For Each dc In dt.Columns
    '        colIndex = colIndex + 1
    '        excel.Cells(1, colIndex) = dc.ColumnName
    '    Next
    '    For Each dr In dt.Rows
    '        rowIndex = rowIndex + 1
    '        colIndex = 0
    '        For Each dc In dt.Columns
    '            colIndex = colIndex + 1
    '            excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
    '        Next
    '    Next
    '    wSheet.Columns.AutoFit()
    'End Sub




    Public Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SelectColumns.Show()
    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_ToExcel.Click

        Dim appXL As Excel.Application
        Dim wbXl As Excel.Workbook
        Dim shXL As Excel.Worksheet

        ' Start Excel and get Application object.
        appXL = CreateObject("Excel.Application")
        appXL.Visible = True
        ' Add a new workbook.
        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet

        For i = 0 To DataGridView1.RowCount - 2
            For j = 0 To DataGridView1.ColumnCount - 1
                shXL.Cells(i + 1, j + 1) = _
                    DataGridView1(j, i).Value.ToString()
            Next
        Next


    End Sub
    Public QueryHashTable As New DataTable()
    Private Sub Cbx_Fill_Grid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Fill_Grid.Click

        Dim da As SqlDataAdapter
        Dim SQLStr As String
        Dim SQLMStr As String
        Dim cnn As SqlConnection
        DataGridView1.DataSource = Nothing
        Dim QueryTable As New DataTable()
        'Query strängdelen för Månad från
        Dim FromMonthsVal = CType(Cbx_From_Months.SelectedItem.ToString(), String)
        Dim FromMonthsValOnlDig = New String(FromMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim FromMonthsValdig = Int32.Parse(FromMonthsValOnlDig)
        '--------------------------------------------------------------------------------------------------
        'Query strängdelen för Månad till
        Dim ToMonthsVal = CType(Cbx_To_Months.SelectedItem.ToString(), String)
        Dim ToMonthsValOnlDig = New String(ToMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim ToMonthsValdig = Int32.Parse(ToMonthsValOnlDig)
        '--------------------------------------------------------------------------------------------------
        'Query strängdelen för bolagsID tagen från cbx_Company (två första tecknen)
        Dim CompanyVal = CType(Cbx_Company.SelectedItem.ToString(), String)
        Dim CompanyValOnlDig = New String(CompanyVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim CompanyValdig = Int32.Parse(CompanyValOnlDig)
        Dim Bolagsid = CompanyValdig.ToString().Substring(0, 2) ' query sträng för bolagsid
        '--------------------------------------------------------------------------------------------------
        'Query strängdelen för år från
        Dim YearFromVal = CType(Cbx_FromYear.SelectedItem.ToString(), String)
        Dim YerFromValDigOn = New String(YearFromVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim YearFromvalValdig = Int32.Parse(YerFromValDigOn)
        '--------------------------------------------------------------------------------------------------
        'Query strängdelen för år till
        Dim YearToVal = CType(Cbx_ToYear.SelectedItem.ToString(), String)
        Dim YerToValDigOn = New String(YearToVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim YearTovalValdig = Int32.Parse(YerToValDigOn)

        '--------------------------------------------------------------------------------------------------
        'Skapar en ny instans av SQL connection samt öppnar.
        cnn = New SqlConnection(connectionString)
        cnn.Open()

        'Rensar tabell fårn innehåll för om man hämtar nytt innehåll med en ny query så att inte datagriden inte bara lääger på befintligt om det är olika kunder
        QueryHashTable.Clear()
        'hashtabell skapar kolumner 
        DataGridView1.DataSource = Nothing

        ' Här skall jag montera loopen för om kolumner för QueryHashTable finns / inte finns

        For x As Integer = 0 To CmTable.Columns.Count

            If QueryHashTable.Columns.Contains("Owner") Then
            Else
                QueryHashTable.Columns.Add("Owner", GetType(String))
            End If

            CmTable.Clear()
        Next

        '// Slut på loop
        QueryHashTable.Columns.Add("Owner")
        QueryHashTable.Columns.Add("Order number")
        QueryHashTable.Columns.Add("Offert number")
        QueryHashTable.Columns.Add("Invoice number")
        QueryHashTable.Columns.Add("Date of invoice")
        QueryHashTable.Columns.Add("Invoiced")
        QueryHashTable.Columns.Add("Company")
        QueryHashTable.Columns.Add("Year")
        QueryHashTable.Columns.Add("Month")
        QueryHashTable.Columns.Add("Type of documentation")
        QueryHashTable.Columns.Add("Source language")
        QueryHashTable.Columns.Add("Target language")
        QueryHashTable.Columns.Add("No Hit")
        QueryHashTable.Columns.Add("75-84")
        QueryHashTable.Columns.Add("85-94")
        QueryHashTable.Columns.Add("95-99")
        QueryHashTable.Columns.Add("100%")
        QueryHashTable.Columns.Add("Rep")
        QueryHashTable.Columns.Add("Context Matches")
        QueryHashTable.Columns.Add("Project management (cost EUR)")
        QueryHashTable.Columns.Add("Estimated TB")
        'loopen gör så att alla kolumner går att uppdatera.
        For Each dc As DataColumn In QueryHashTable.Columns
            dc.ReadOnly = False
        Next

        'SQL Query sträng
        SQLStr = "SELECT DISTINCT " & _
            "tt.Bestallarnr 'Owner'," & _
            "tt.ordernr 'Order number',	 " & _
            "tt.offertnr 'Offert number'," & _
            "ord.fakturerad_kund_datum 'Date of invoice'," & _
            "ord.fakturerad_kund 'invoiced'," & _
            "c.Name 'Company', tt.DescriptionHeader  'Type of documentation'," & _
            "tt.bestdatum 'Year', tt.bestdatum 'Month', snSrc.kod 'Source language'," & _
            "snTrg.kod 'Target language'," & _
            "ord.antal50_74 + ord.antalnohit 'No Hit'," & _
            "ord.antal75_84 '75-84'," & _
            "ord.antal85_94 '85-94'," & _
            "ord.antal95_99 '95-99'," & _
            "ord.antal100 '100%'," & _
            "ord.antalrep 'Rep'," & _
            "'' as 'Context Matches'," & _
            "ord.interna_timmar 'Project management (cost EUR)'" & _
            "FROM" & _
            "[teknotrans_dev].dbo.OpusOrder tt INNER JOIN" & _
            "[teknotrans_dev].dbo.CompanyMain c On tt.bolagsnr = c.id INNER JOIN" & _
            "[teknotrans_dev].dbo.OpusOrderrow ord On ord.ordernr = tt.ordernr INNER JOIN" & _
            "[teknotrans_dev].dbo.OrderVolvoLanguageName snSrc ON ord.kallspraknr = snSrc.spraknr INNER JOIN" & _
            "[teknotrans_dev].dbo.OrderVolvoLanguageName snTrg ON ord.malspraknr = snTrg.spraknr INNER JOIN" & _
            "[Teknotrans_dev].dbo.PostIt as PostIt On PostIt.ordernr = tt.ordernr " & _
            "WHERE (DATEPART(year, tt.bestdatum) BETWEEN '" & YearFromvalValdig & "' AND '" & YearTovalValdig & "') and (DATEPART(month, tt.bestdatum)BETWEEN '" & FromMonthsValdig & "' and " & "'" & ToMonthsValdig & "'" & ") and (tt.makulerad=0) and (ord.makulerad= 0) AND c.ID=" & Bolagsid & " ORDER BY tt.ordernr,snSrc.kod, snTrg.kod "
        '"WHERE (DATEPART(year, tt.bestdatum) BETWEEN '2006' AND '2015') and (DATEPART(month, tt.bestdatum)BETWEEN '2' and " & "'3'" & ") and (tt.makulerad=0) and (ord.makulerad= 0) AND c.ID='47' ORDER BY tt.ordernr,snSrc.kod, snTrg.kod "
        '  Console.WriteLine(SQLStr)

        Dim cmd As New SqlCommand(SQLStr, cnn)
        Dim FromMonth = (Cbx_From_Months.SelectedItem.ToString().Chars(6))
        Dim ToMonth = (Cbx_To_Months.SelectedItem.ToString().Chars(6))
        SQLMStr = String.Format(SQLStr, FromMonth, ToMonth)

        da = New SqlDataAdapter(SQLMStr, TTCon)
        ds2 = New DataSet

        da.Fill(QueryTable)

        '' fyller hela CM kolumnen
        ''If HashDatatable1.Rows.Count > 0 Then
        ''    For i As Integer = 0 To HashDatatable1.Rows.Count - 1
        ''        If Not HashDatatable1.Rows(i).Item(18).ToString.Contains("Language:") Then
        ''            HashDatatable1.Rows(i)(18) = "0"
        ''        End If
        ''        '  MsgBox(HashDatatable1.Rows(i).Item(18).ToString())
        ''    Next
        ''End If

        Dim ThisOrder As Integer = 0
        Dim LastOrder As Integer = 0
        Dim ThisLanguage As String = ""

        For i As Integer = 0 To QueryHashTable.Rows.Count - 1
            ThisOrder = QueryHashTable.Rows(i).Item("Order Number") 'get Order Number from current row

            If i = 0 Then ThisLanguage = QueryHashTable.Rows(i).Item("Context Matches") 'Get Target Language if this is the first row

            If i > 0 Then 'only run this code for rows after the first
                If ThisOrder = LastOrder Then 'check if ThisOrder is the same as LastOrder
                    QueryHashTable.Rows(i).Item("Context Matches") = ThisLanguage 'ThisOrder and LastOrder match, so copy ThisLanguage to current row's Target Language
                Else
                    ThisLanguage = QueryHashTable.Rows(i).Item("Context Matches") 'ThisOrder and LastOrder do not match (i.e., this is a new order number), so get the Target Language from the current row
                End If
            End If
            LastOrder = ThisOrder 'set LastOrder equal to ThisOrder
        Next
        DataGridView1.DataSource = QueryTable



        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoResizeColumns()
        cnn.Close()

        ' Slut på ovanstående programsats























































    End Sub

    Public CmTable As New DataTable()
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim da As SqlDataAdapter
        Dim SQLStr As String
        Dim cnn As SqlConnection


        Dim FromMonthsVal = CType(Cbx_From_Months.SelectedItem.ToString(), String)
        Dim FromMonthsValOnlDig = New String(FromMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim FromMonthsValdig = Int32.Parse(FromMonthsValOnlDig)

        'Query strängdelen för Månad till
        Dim ToMonthsVal = CType(Cbx_To_Months.SelectedItem.ToString(), String)
        Dim ToMonthsValOnlDig = New String(ToMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim ToMonthsValdig = Int32.Parse(ToMonthsValOnlDig)

        'Query strängdelen för bolagsID tagen från cbx_Company (två första tecknen)
        Dim CompanyVal = CType(Cbx_Company.SelectedItem.ToString(), String)
        Dim CompanyValOnlDig = New String(CompanyVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim CompanyValdig = Int32.Parse(CompanyValOnlDig)
        Dim Bolagsid = CompanyValdig.ToString().Substring(0, 2) ' query sträng för bolagsid

        'Query strängdelen för år från
        Dim YearFromVal = CType(Cbx_FromYear.SelectedItem.ToString(), String)
        Dim YerFromValDigOn = New String(YearFromVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim YearFromvalValdig = Int32.Parse(YerFromValDigOn)

        'Query strängdelen för år till
        Dim YearToVal = CType(Cbx_ToYear.SelectedItem.ToString(), String)
        Dim YerToValDigOn = New String(YearToVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim YearTovalValdig = Int32.Parse(YerToValDigOn)


        Dim HashDatatable1 As New DataTable()
        Dim HashDataTable2 As New DataTable()
        Dim HashDataTable3 As New DataTable()
        Dim HashDataTable4 As New DataTable()



        HashDatatable1.Columns.Add("Context Matches") ' lägger till kolumnen Context Matches
        HashDataTable2.Columns.Add("Context Matches") ' lägger till kolumnen Context Matches
        HashDataTable3.Columns.Add("Context Matches") ' lägger till kolumnen Context Matches
        HashDataTable4.Columns.Add("Context Matches") ' lägger till kolumnen Context Matches

        '  DataGridView2.DataSource = Nothing

        cnn = New SqlConnection(connectionString)
        cnn.Open()

        'Query för alla kolumner
        SQLStr = "SELECT DISTINCT '(' + CAST (tt.offertnr as varchar(10))+ ') - '+ CAST (tt.OrderNr AS varchar(10)) + ' – ' + PostIt.Text  AS 'Context Matches' " & _
            "FROM [Teknotrans_dev].dbo.OpusOrder as tt INNER JOIN" & _
            "[Teknotrans_dev].dbo.CompanyMain as c On tt.bolagsnr = c.id INNER JOIN" & _
            "[Teknotrans_dev].dbo.OpusOrderrow as ord On ord.ordernr = tt.ordernr INNER JOIN" & _
            "[Teknotrans_dev].dbo.PostIt as PostIt On PostIt.ordernr = tt.ordernr INNER JOIN" & _
            "[Teknotrans_dev].dbo.OrderVolvoLanguageName as snSrc ON ord.kallspraknr = snSrc.spraknr INNER JOIN" & _
            "[Teknotrans_dev].dbo.OrderVolvoLanguageName as snTrg ON ord.malspraknr = snTrg.spraknr " & _
            "WHERE (DATEPART(year, tt.bestdatum) BETWEEN '" & YearFromvalValdig & "' AND '" & YearTovalValdig & "') and (DATEPART(month, tt.bestdatum)BETWEEN '" & FromMonthsValdig & "' and " & "'" & ToMonthsValdig & "'" & ") and (tt.makulerad=0) and (ord.makulerad= 0) AND c.ID=" & Bolagsid & " "

        Console.WriteLine(SQLStr)

        da = New SqlDataAdapter(SQLStr, TTCon)
        da.Fill(HashDatatable1)


        For Each row As DataRow In HashDatatable1.Rows
            If row.Item(0).ToString().Contains("Language:") Then
                HashDataTable2.Rows.Add(row.Field(Of String)(0).ToString())
            End If
        Next
        HashDatatable1.Clear()

        For Each dtrow As DataRow In HashDataTable2.Rows
            Dim str As String = dtrow.Item(0).ToString()
            str = Regex.Replace(str, "Language(.*)\r\n(.*)\r\nContext Match(.*)\r\n(.*)\r\n(.*)\r\n", "Language$1 Context Match$3")
            HashDataTable3.Rows.Add(str)
        Next

        HashDataTable2.Clear()

        For Each dthrow As DataRow In HashDataTable3.Rows
            Dim hashtbstring As String = dthrow.Item(0).ToString() ' sträng
            Dim regex1 As Regex = New Regex("(.*)(\D(\d{1})\D)(.- )(\d{5})(.*)(Language: )(.*)(\;)")
            Dim match1 = regex1.Match(hashtbstring)
            If match1.Success Then
                Dim CmRegMatch As String = (match1.Value).ToString()
                HashDataTable4.Rows.Add(CmRegMatch)
            End If

        Next


       

        'CmTable.Columns.Add("Order number", GetType(String))
        'CmTable.Columns.Add("Source language", GetType(String))
        'CmTable.Columns.Add("Target language", GetType(String))
        'CmTable.Columns.Add("Context Matches", GetType(String))

        For x As Integer = 0 To CmTable.Columns.Count

            If CmTable.Columns.Contains("Order number") Then
            Else
                CmTable.Columns.Add("Order number", GetType(String))
            End If

            If CmTable.Columns.Contains("Source language") Then
            Else
                CmTable.Columns.Add("Source language", GetType(String))
            End If


            If CmTable.Columns.Contains("Target language") Then
            Else
                CmTable.Columns.Add("Target language", GetType(String))
            End If

            If CmTable.Columns.Contains("Context Matches") Then
            Else
                CmTable.Columns.Add("Context Matches", GetType(String))
            End If

            CmTable.Clear()
        Next




        For Each dt2row As DataRow In HashDataTable4.Rows

            Dim CmString As String = (dt2row.Item(0).ToString()) ' Here is how I get my textstring.
            Dim ordernr As String = Regex.Replace(CmString, "(.*)(\d{5})(.*)(;)", "$2") ' ordernr
            Dim SoLang As String = Regex.Replace(CmString, "(.*)(\d{5})(.*)(Language: )(\w{3})(.*)", "$5") ' source language
            Dim TarLang As String = Regex.Replace(CmString, "(.*)(\w{3})(-)(\w{3})(.*)", "$4") ' target language
            Dim Cm As String = Regex.Replace(CmString, "(.*)(Context Match: )(.*)(;)", "$3") ' Context Match

            CmTable.Rows.Add(ordernr, SoLang, TarLang, Cm)
        Next

        CmTable.DefaultView.Sort = "Order number" ' sorterar kolumnen
        DataGridView2.DataSource = CmTable


    End Sub
    Dim HashDatatable1 As New DataTable()
    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Dim CMda As SqlDataAdapter
        Dim CMSQLStr As String
        Dim cnn As SqlConnection


        Dim FromMonthsVal = CType(Cbx_From_Months.SelectedItem.ToString(), String)
        Dim FromMonthsValOnlDig = New String(FromMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim FromMonthsValdig = Int32.Parse(FromMonthsValOnlDig)

        'Query strängdelen för Månad till
        Dim ToMonthsVal = CType(Cbx_To_Months.SelectedItem.ToString(), String)
        Dim ToMonthsValOnlDig = New String(ToMonthsVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim ToMonthsValdig = Int32.Parse(ToMonthsValOnlDig)

        'Query strängdelen för bolagsID tagen från cbx_Company (två första tecknen)
        Dim CompanyVal = CType(Cbx_Company.SelectedItem.ToString(), String)
        Dim CompanyValOnlDig = New String(CompanyVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim CompanyValdig = Int32.Parse(CompanyValOnlDig)
        Dim Bolagsid = CompanyValdig.ToString().Substring(0, 2) ' query sträng för bolagsid

        'Query strängdelen för år från
        Dim YearFromVal = CType(Cbx_FromYear.SelectedItem.ToString(), String)
        Dim YerFromValDigOn = New String(YearFromVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim YearFromvalValdig = Int32.Parse(YerFromValDigOn)

        'Query strängdelen för år till
        Dim YearToVal = CType(Cbx_ToYear.SelectedItem.ToString(), String)
        Dim YerToValDigOn = New String(YearToVal.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim YearTovalValdig = Int32.Parse(YerToValDigOn)

        '  DataGridView2.DataSource = Nothing

        cnn = New SqlConnection(connectionString)
        cnn.Open()

        'Query för alla kolumner
        CMSQLStr = "SELECT DISTINCT '(' + CAST (tt.offertnr as varchar(10))+ ') - '+ CAST (tt.OrderNr AS varchar(10)) + ' – ' + PostIt.Text  AS 'Context Matches' " & _
            "FROM [Teknotrans_dev].dbo.OpusOrder as tt INNER JOIN" & _
            "[Teknotrans_dev].dbo.CompanyMain as c On tt.bolagsnr = c.id INNER JOIN" & _
            "[Teknotrans_dev].dbo.OpusOrderrow as ord On ord.ordernr = tt.ordernr INNER JOIN" & _
            "[Teknotrans_dev].dbo.PostIt as PostIt On PostIt.ordernr = tt.ordernr INNER JOIN" & _
            "[Teknotrans_dev].dbo.OrderVolvoLanguageName as snSrc ON ord.kallspraknr = snSrc.spraknr INNER JOIN" & _
            "[Teknotrans_dev].dbo.OrderVolvoLanguageName as snTrg ON ord.malspraknr = snTrg.spraknr " & _
            "WHERE (DATEPART(year, tt.bestdatum) BETWEEN '" & YearFromvalValdig & "' AND '" & YearTovalValdig & "') and (DATEPART(month, tt.bestdatum)BETWEEN '" & FromMonthsValdig & "' and " & "'" & ToMonthsValdig & "'" & ") and (tt.makulerad=0) and (ord.makulerad= 0) AND c.ID=" & Bolagsid & " "

        Console.WriteLine(CMSQLStr)

        CMda = New SqlDataAdapter(CMSQLStr, TTCon)
        CMda.Fill(HashDatatable1)



        For x As Integer = 0 To HashDatatable1.Rows.Count - 1

            Dim cmRegex2R As New Regex("Language$1 Context Match$3")
            Dim cm As String = (HashDatatable1.Rows(x).Item("Context Matches"))
            Dim m As Match = Regex.Match(cm, "^(\()(-)(\d+)")
            Dim a As Match = Regex.Match(cm, "Language(.*)\r\n(.*)\r\nContext Match(.*)\r\n(.*)\r\n(.*)\r\n")


            If Not (m.Success) Then
                HashDatatable1.Rows(x).Item("Context Matches") = ""
            End If
            If Not (a.Success) Then
                HashDatatable1.Rows(x).Item("Context Matches") = ""
            End If

        Next





        'For y As Integer = 0 To HashDatatable1.Rows.Count - 1

        '    Dim ccm As String = (HashDatatable1.Rows(y).Item("Context Matches"))

        '    If Not ccm = "" Then
        '        Dim numr As Match = Regex.Match(ccm, "(\d{5})")

        '        If (numr.Success) Then


        '            For i As Integer = 0 To CmTable.Rows.Count - 1

        '                Dim cnum As String = (CmTable.Rows(i).Item("Order number"))

        '                If (numr.ToString = cnum.ToString()) Then

        '                    MsgBox("samma")

        '                End If
        '            Next
        '        End If
        '    End If
        'Next











        'For Each row As DataRow In HashDatatable1.Rows
        '    If row.Item(0).ToString().Contains("Language:") Then
        '        HashDataTable2.Rows.Add(row.Field(Of String)(0).ToString())
        '    End If
        'Next
        'HashDatatable1.Clear()

        'For Each dtrow As DataRow In HashDataTable2.Rows
        '    Dim str As String = dtrow.Item(0).ToString()
        '    str = Regex.Replace(str, "Language(.*)\r\n(.*)\r\nContext Match(.*)\r\n(.*)\r\n(.*)\r\n", "Language$1 Context Match$3")
        '    HashDataTable3.Rows.Add(str)
        'Next

        'HashDataTable2.Clear()

        'For Each dthrow As DataRow In HashDataTable3.Rows
        '    Dim hashtbstring As String = dthrow.Item(0).ToString() ' sträng
        '    Dim regex1 As Regex = New Regex("(.*)(\D(\d{1})\D)(.- )(\d{5})(.*)(Language: )(.*)(\;)")
        '    Dim match1 = regex1.Match(hashtbstring)
        '    If match1.Success Then
        '        Dim CmRegMatch As String = (match1.Value).ToString()
        '        HashDataTable4.Rows.Add(CmRegMatch)
        '    End If

        'Next




        'CmTable.Columns.Add("Order number", GetType(String))
        'CmTable.Columns.Add("Source language", GetType(String))
        'CmTable.Columns.Add("Target language", GetType(String))
        'CmTable.Columns.Add("Context Matches", GetType(String))

        'For x As Integer = 0 To CmTable.Columns.Count

        '    If CmTable.Columns.Contains("Order number") Then
        '    Else
        '        CmTable.Columns.Add("Order number", GetType(String))
        '    End If

        '    If CmTable.Columns.Contains("Source language") Then
        '    Else
        '        CmTable.Columns.Add("Source language", GetType(String))
        '    End If


        '    If CmTable.Columns.Contains("Target language") Then
        '    Else
        '        CmTable.Columns.Add("Target language", GetType(String))
        '    End If

        '    If CmTable.Columns.Contains("Context Matches") Then
        '    Else
        '        CmTable.Columns.Add("Context Matches", GetType(String))
        '    End If

        '    CmTable.Clear()
        'Next


        'For Each dt2row As DataRow In HashDataTable4.Rows
        '    Dim CmString As String = (dt2row.Item(0).ToString()) ' Here is how I get my textstring.
        '    Dim ordernr As String = Regex.Replace(CmString, "(.*)(\d{5})(.*)(;)", "$2") ' ordernr
        '    Dim SoLang As String = Regex.Replace(CmString, "(.*)(\d{5})(.*)(Language: )(\w{3})(.*)", "$5") ' source language
        '    Dim TarLang As String = Regex.Replace(CmString, "(.*)(\w{3})(-)(\w{3})(.*)", "$4") ' target language
        '    Dim Cm As String = Regex.Replace(CmString, "(.*)(Context Match: )(.*)(;)", "$3") ' Context Match

        '    CmTable.Rows.Add(ordernr, SoLang, TarLang, Cm)
        'Next
        'CmTable.DefaultView.Sort = "Order number" ' sorterar kolumnen
        DataGridView2.DataSource = HashDatatable1


        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView2.AutoResizeColumns()




        Dim dv As DataView = CmTable.DefaultView

        For Each dr As DataRow In HashDatatable1.Rows
            dv.RowFilter = "ContextMatches LIKE '%" & dr.Item("OrderNumber") & "%'"
            For Each drv As DataRowView In dv
                drv.Item("ContextMatches") = dr.Item("ContextMatches")
            Next
            dv.RowFilter = Nothing
        Next



    End Sub
End Class


'Public Class Select_Columns

'    Private Sub Select_Columns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        MyColBox.Visible = True
'        MyColBox.Items.Add("Owner", CheckState.Checked)
'        MyColBox.Items.Add("Translator", CheckState.Checked)
'        MyColBox.Items.Add("Order number", CheckState.Checked)
'        MyColBox.Items.Add("Quotation number", CheckState.Checked)
'        MyColBox.Items.Add("Area", CheckState.Checked)
'        MyColBox.Items.Add("Description", CheckState.Checked)
'        MyColBox.Items.Add("Order date", CheckState.Checked)
'        MyColBox.Items.Add("Delivery date", CheckState.Checked)
'        MyColBox.Items.Add("Source langugage", CheckState.Checked)
'        MyColBox.Items.Add("Target langugage", CheckState.Checked)
'        MyColBox.Items.Add("No hit", CheckState.Checked)
'        MyColBox.Items.Add("Words(75-84)", CheckState.Checked)
'        MyColBox.Items.Add("Words(85-94) ", CheckState.Checked)
'        MyColBox.Items.Add("Words (95-99)", CheckState.Checked)
'        MyColBox.Items.Add("Words (100%)", CheckState.Checked)
'        MyColBox.Items.Add("Words (repetitins)", CheckState.Checked)
'        MyColBox.Items.Add("Words (CM)", CheckState.Checked)
'        MyColBox.Items.Add("Words (Total Words)", CheckState.Checked)
'        MyColBox.Items.Add("DTP", CheckState.Checked)
'        MyColBox.Items.Add("Ext.hr", CheckState.Checked)
'        MyColBox.Items.Add("Int.hrs", CheckState.Checked)
'        MyColBox.Items.Add("Cust. Invoiced", CheckState.Checked)
'        MyColBox.Items.Add("Estimated Customer Total", CheckState.Checked)
'        MyColBox.Items.Add("Estimated TB", CheckState.Checked)

'    End Sub








