Public Class HAL_Statistics
    Private SQL As New SQLControl

    Private Sub HAL_Statistics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CompanyID()

    End Sub




    Private Sub CompanyID()



        Dim CompanyID(0) As String

        ' CompanyID = Company.SelectedItem.ToString().Split("-")

        SQL.ExecQuery(String.Format("SELECT tt.ordernr as 'Teknotrans Number'FROM [teknotrans_dev].dbo.OpusOrder as tt where tt.bolagsnr={0}", CompanyID(1).Trim()))



        '   CLEAR(ComboBox)
        Ordernr.Items.Clear()
        DataGridView1.Rows.Clear()

        MsgBox(SQL.Exception)

        If SQL.RecordCount > 0 Then
            If SQL.SQLDS.Tables.Count > 0 Then
                For Each r As DataRow In SQL.SQLDS.Tables(0).Rows

                    Company.Items.Add("asdasd")

                Next
                Ordernr.SelectedIndex = 0
            End If
        ElseIf SQL.Exception <> "" Then
            ' REPORT(ERRORS)
            MsgBox(SQL.Exception)
        End If

    End Sub


    Private Sub GetCompany()
        'QUERY TABLE
        SQL.ExecQuery("SELECT c.Name as 'Company', c.id as 'CompanyID' FROM [teknotrans_dev].dbo.CompanyMain as c WHERE EXISTS (SELECT * FROM [teknotrans_dev].dbo.OpusOrder WHERE bolagsnr=c.id")

        ' CLEAR COMBOBOX
        '     Company.Items.Clear()

        '   MsgBox(SQL.Exception)

        If SQL.RecordCount > 0 Then
            For Each r As DataRow In SQL.SQLDS.Tables(0).Rows


                Company.Items.Add(String.Format("{0} - {1}", r("Company"), r("CompanyID")))


                Company.Items.Add("asdsd")
            Next
            'SET THE COMBOBOX TO THE FIRST RECORD
            Company.SelectedIndex = 0
        ElseIf SQL.Exception <> "" Then
            'REPORT ERRORS
            MsgBox(SQL.Exception)
        End If
    End Sub



    Private Sub Order()

        Dim CompanyID(5) As String
        SQL.ExecQuery(String.Format("SELECT tt.ordernr as 'ORder Number'FROM [teknotrans_dev].dbo.OpusOrder as tt where tt.bolagsnr={0}", CompanyID))



    End Sub



    Private Sub GetOrderNR()
        Dim CompanyID(5) As String


        CompanyID = Company.SelectedItem.ToString().Split("-")

        SQL.ExecQuery(String.Format("SELECT tt.ordernr as 'Teknotrans Number'FROM [teknotrans_dev].dbo.OpusOrder as tt where tt.bolagsnr={0}", CompanyID(1).Trim()))

        ' CLEAR COMBOBOX
        '  OrderNR.Items.Clear()
        DataGridView1.Rows.Clear()

        '   MsgBox(SQL.Exception)

        If SQL.RecordCount > 0 Then
            If SQL.SQLDS.Tables.Count > 0 Then
                For Each r As DataRow In SQL.SQLDS.Tables(0).Rows


                    MsgBox({0}.ToString)

                Next
                '   OrderNR.SelectedIndex = 0
            End If
        ElseIf SQL.Exception <> "" Then
            'REPORT ERRORS
            MsgBox(SQL.Exception)
        End If


    End Sub

    Private Sub GetLangForOrderRow(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim CompanyID As String
        CompanyID = Order.SelectedItem.ToString()
        SQL.ExecQuery(String.Format("SELECT snSrc.kod as 'Source Language', snTrg.kod as 'Target Language' FROM [teknotrans_dev].dbo.OpusOrderrow as ord INNER JOIN [teknotrans_dev].dbo.OrderVolvoLanguageName as snSrc ON ord.kallspraknr = snSrc.spraknr INNER JOIN [teknotrans_dev].dbo.OrderVolvoLanguageName as snTrg ON ord.malspraknr = snTrg.spraknr WHERE ord.ordernr={0}", CompanyID.Trim()))

        TarLang.Clear()
        SourLang.Clear()
        DataGridView1.Rows.Clear()

        If SQL.RecordCount > 0 Then
            For Each r As DataRow In SQL.SQLDS.Tables(0).Rows

                SourLang.AppendText(String.Format("{0}" & vbCrLf, r("Source Language"), r("Target Language")))
                TarLang.AppendText(String.Format("{1}" & vbCrLf, r("Source Language"), r("Target Language")))


                TarLang.AppendText(String.Format("{1}" & vbCrLf, r("Source Language"), r("Target Language")).ToString)

                DataGridView1.Rows.Add("fsfd")
                Dim mystring As String
                Dim mycompany As String



                DataGridView1.Rows.Add()

            Next

            SET THE COMBOBOX TO THE FIRST RECORD
            Company.SelectedIndex = 0
        ElseIf SQL.Exception <> "" Then
            REPORT(ERRORS)
            MsgBox(SQL.Exception)
        End If

    End Sub

    Private Sub SelColumns_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelColumns.Click

        Select_Columns.Show()

    End Sub


  

    Private Sub Dropdown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Company.SelectedIndexChanged
        'MsgBox(Company.SelectedValue)
        GetOrderNR()
    End Sub


End Class




