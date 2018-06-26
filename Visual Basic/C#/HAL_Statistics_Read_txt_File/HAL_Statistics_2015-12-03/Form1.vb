Imports Microsoft.Office.Interop
Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Form1
    'Deklarerar två listor som är public 
    Public CleanStringList As New List(Of String)
    Public PathStrings As New List(Of String)
    Public ExcelorderList As New List(Of String)
    Public QueryList As New ArrayList()
    Private SQL As New SQLController
    Public connectionString = ("Data Source=ttdev\Teknotrans_dev;Initial Catalog=Teknotrans_dev;Integrated Security=True")
    Public TTCon As New SqlConnection(connectionString)

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xlApp As New Excel.Application With {.DisplayAlerts = False}
        Dim xlSht As Excel.Worksheet = Nothing
        Dim xlRng As Excel.Range = Nothing
        Dim dlg As New OpenFileDialog
        Dim List As New ArrayList
        Dim excelCellRes As String

        dlg.Filter = " Excel-Arbetsbok(*.xlsx)|*.xlsx|Excel 97-2003-arbetsbok (*.xls)|*.xls)"
        dlg.ShowDialog()
        Dim FPath As String = IO.Path.GetDirectoryName(dlg.FileName)

        'Laddar filpath 
        TxtBoxPath.Text = FPath & dlg.FileName

        xlApp.Workbooks.Open(dlg.FileName)
        xlSht = DirectCast(xlApp.Sheets(1), Excel.Worksheet)
        xlRng = DirectCast(xlSht.Cells(1, 1), Excel.Range)
        Console.WriteLine(xlRng.Value)

        For i As Integer = 1 To DirectCast(xlApp.ActiveSheet, Excel.Worksheet).UsedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row

            excelCellRes = (DirectCast(xlSht.Cells(i, "A"), Excel.Range).Value).ToString()
            ExcelorderList.Add(excelCellRes)
        Next i
        ExcelOrderList = ExcelOrderList.Distinct().ToList()

        ' Dim OrderName As String = "C:\Orders.txt"
        ' Dim objWriter As New System.IO.StreamWriter(OrderName)

        'For Each item In ExcelorderList
        '    Console.WriteLine(item.ToString())
        'Next

    End Sub

    Public Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Riktiga Pathen For Each d In Directory.EnumerateDirectories("X:\1 Övriga kunder\Arkiv\Originalfiler", "*.*", SearchOption.AllDirectories)

        For Each d In Directory.EnumerateDirectories("C:\X\", "*.*", SearchOption.AllDirectories)
            Dim myPath = ((d))

            If myPath.Length < 36 Then
                PathStrings.Add(myPath)
            End If
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim sPath As String
        Dim OString As String
        Dim Pathstring As String() = PathStrings.ToArray()
        Dim OrderString As String() = ExcelorderList.ToArray()


        Using sw As StreamWriter = New StreamWriter("C:\(0)Paths.txt")
            For Each sPath In Pathstring
                sw.WriteLine(sPath)
            Next sPath
        End Using

        Using swr As StreamWriter = New StreamWriter("C:\(1)OrderNames.txt")
            For Each OString In OrderString
                swr.WriteLine(OString)
            Next OString
        End Using
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim fileA = File.ReadAllLines("C:\(0)Paths.txt")
        Dim fileB = File.ReadAllLines("C:\(1)OrderNames.txt")
        Dim differenceQuery = From line In fileA
                            Let w = line.Split({"\"}, StringSplitOptions.RemoveEmptyEntries)
                            Where w.Distinct().Intersect(fileB).Count = 1
                            Select line
        For Each item In differenceQuery
            CleanStringList.Add(item.ToString)
        Next
        CleanStringList.Sort()

        '  For Each item In CleanStringList
        'Console.WriteLine(item)
        ' Next

        Dim lineCount = File.ReadAllLines("C:\(1)OrderNames.txt").Length

        If lineCount.ToString() = CleanStringList.Count.ToString() = True Then

            MsgBox("There is the same amount of lines for both Paths and Order numbers")
        End If

        Dim sPath As String

        Dim Pathstring As String() = CleanStringList.ToArray()

        Using sw As StreamWriter = New StreamWriter("C:\(2)CleanStringList.txt")
            For Each sPath In Pathstring
                sw.WriteLine(sPath)
            Next sPath
        End Using

    End Sub

   
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Fpath = ("C:\XML_Files_Extract")
        Dim mystring As String = "C:\X\36001-37000\36001-36100\36062\"
        ' Dim files() As String ' array för minfil

        'MkDir("C:\XML_Files_Extract\")
        ''''använd denna Snippet för att läsa alla strängar i txtfil
        ' '' För alla Lines i textfilen.
        ''Dim fileA = File.ReadAllLines("C:\(2)CleanStringList.txt")
        ''Dim TxtItem = fileA.ToArray()
        ''For Each x In TxtItem
        ''    MsgBox(x)
        ''Next

        'files = System.IO.Directory.GetFiles(mystring, "*Original från kund*.zip")
        'For Each file As String In files
        '    System.IO.File.Copy(file, "C:\XML_Files_Extract\" & System.IO.Path.GetFileName(file))
        'Next

        Dim arFiles As String()
        arFiles = Directory.GetFiles("C:\XML_Files_Extract\", "*original från kund*.zip")
        Dim i As Integer
        For i = 0 To arFiles.Length - 1
            Dim myZipandPath As String = (arFiles(i).ToString())
            Dim MyZipDigits = CInt(Val(New Text.StringBuilder((From ch In myZipandPath.ToCharArray Where IsNumeric(ch)).ToArray).ToString))
            Dim myDigitString As String = MyZipDigits ' konverterat myZipDigits till en ren sträng från Array
            Dim ZPath As String = (Fpath + "\" + myDigitString)

            Dim dir As New IO.DirectoryInfo(ZPath)
            If dir.Exists Then
                MsgBox("Det finns redan en mapp på följande ställe: " + ZPath)
            Else
                MkDir(ZPath)
            End If

            ZipFile.ExtractToDirectory(myZipandPath, ZPath)

            'Dim ar As Array
            'ar = System.IO.Directory.GetFiles(ZPath, "*.zip", IO.SearchOption.AllDirectories)
            'For Each tok In ar
            '    Console.WriteLine(tok)
            'Next

        Next
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Enter

        Dim TTCon As New SqlConnection(connectionString)
        Dim CompanyandID_Table As New DataTable
        Dim CompanyandID_Table_ds As New DataSet
        Dim Months As New Dictionary(Of String, Integer)
        Dim CompanyandID As New SqlDataAdapter("SELECT [t0].[Name],[t0].[Id] FROM [CompanyMain] AS [t0] ", TTCon)
        Dim Year As New SqlDataAdapter("SELECT [t0].[bestdatum] AS [Bestdatum]FROM [OpusOrder] AS [t0]", TTCon)

        CompanyandID_Table.Columns.Add("Name", GetType(System.String))
        CompanyandID_Table.Columns.Add("Id", GetType(System.String))

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
        TTCon.Close()

        '----------------------------------------------------- YEAR FUNCTIONEN -------------------------------------------------------------------------------
        Dim DBConnString As String = "Data Source=ttdev\Teknotrans_dev;Initial Catalog=Teknotrans_dev;Integrated Security=True"
        Dim DBConn As New SqlConnection(DBConnString)
        Dim Year_List_HashTable As New List(Of Integer)
        Dim Years_List As List(Of Integer)
        Dim dt As New DataTable()
        Dim dv As New DataView(dt)

        DBConn.Open()
        Using da As New SqlDataAdapter("SELECT DISTINCT [t0].[bestdatum] AS [Bestdatum]FROM [OpusOrder] AS [t0]", DBConn)
            da.Fill(dt)
        End Using
        DBConn.Close()

        Dim Years_Table As DataTable = dv.ToTable(True, "Bestdatum")
        For Each Customer As DataRow In Years_Table.Rows
            Dim Year_Item = (Customer("Bestdatum").ToString)
            Dim Year_String As String = (Year_Item.Substring(0, Year_Item.Length - 15)) ' den tar bort alla tecknen förutom året (xxxx-xx-xx-xxxx:xx)
            Year_List_HashTable.Add(Year_String)
        Next

        Years_List = Year_List_HashTable.Distinct().ToList ' tar bort alla dubletter det därför jag har skapat en hashtable 
        Years_List.Sort()

        For Each item In Years_List
            Cbx_Year.Items.Add(item)
        Next

        ' Definerar att den väljer automatiskt det sista värdet.
        Dim lastitem As Integer = 0
        lastitem = Cbx_Year.Items.Count
        Cbx_Year.SelectedIndex = lastitem - 1
        '----------------------------------------------///// YEAR FUNCTIONEN -------------------------------------------------------------------------------











    End Sub

    Private Sub Cbx_Year_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Year.SelectedValueChanged
       

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Dim CompanyandID_Table As New DataTable
        'Dim CompanyandID_Table_ds As New DataSet
        'Dim TTCon As New SqlConnection(connectionString)
        'TTCon.Open()
        'Dim sb As New System.Text.StringBuilder
        'sb.AppendLine("SELECT")
        'sb.AppendLine("tt.ordernr as 'Teknotrans Number'")
        'sb.AppendLine("FROM")
        'sb.AppendLine("[teknotrans_dev].dbo.OpusOrder as tt INNER JOIN")
        'sb.AppendLine("[teknotrans_dev].dbo.CompanyMain as c On tt.bolagsnr = c.id INNER JOIN")
        'sb.AppendLine("[teknotrans_dev].dbo.OpusOrderrow as ord On ord.ordernr = tt.ordernr INNER JOIN")
        'sb.AppendLine("[teknotrans_dev].dbo.PostIt as PostIt On PostIt.ordernr = tt.ordernr INNER JOIN")
        'sb.AppendLine("[teknotrans_dev].dbo.OrderVolvoLanguageName as snSrc ON ord.kallspraknr = snSrc.spraknr INNER JOIN")
        'sb.AppendLine("[teknotrans_dev].dbo.OrderVolvoLanguageName as snTrg ON ord.malspraknr = snTrg.spraknr")
        'sb.AppendLine("WHERE")
        'sb.AppendLine("(DATEPART(year, tt.bestdatum) = '2015')")
        'sb.AppendLine("and")
        'sb.AppendLine("(DATEPART(month, tt.bestdatum)BETWEEN '09' and '11')")
        'sb.AppendLine("and")
        'sb.AppendLine("(tt.makulerad=0)")
        'sb.AppendLine("and")
        'sb.AppendLine("(ord.makulerad= 0)")
        'sb.AppendLine("and")
        'sb.AppendLine("c.id='1643'")
        'sb.AppendLine("ORDER BY")
        'sb.AppendLine("tt.ordernr,")
        'sb.AppendLine("snSrc.kod,")
        'sb.AppendLine("snTrg.kod")
        'Dim MyQuery As String = sb.ToString.Replace(vbCrLf, " ")
        'Console.WriteLine(MyQuery)
        '' Dim CompanyandID As New SqlDataAdapter(MyQuery, TTCon)
        'TTCon.Close()
        'Dim con = New SqlConnection("Data Source=ttdev\Teknotrans_dev;Initial Catalog=Teknotrans_dev;Integrated Security=True")


       

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Dim FromMonth = (Cbx_From_Months.SelectedItem.ToString().Chars(6))




    End Sub

    Private Sub Cbx_From_Months_SelectedIndexChanged(ByVal sender As Object, _
     ByVal e As System.EventArgs) Handles Cbx_From_Months.SelectedIndexChanged
        Dim comboBox As ComboBox = CType(sender, ComboBox)

        If Cbx_From_Months.SelectedItem IsNot Nothing Then
            Dim curValue = CType(Cbx_From_Months.SelectedItem.ToString(), String)
            Dim onlyDigits = New String(curValue.Where(Function(c) Char.IsDigit(c)).ToArray())
            Dim num = Int32.Parse(onlyDigits)

        End If

    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelColumns.Click

        SQL_Columns.Show()

    End Sub


End Class




