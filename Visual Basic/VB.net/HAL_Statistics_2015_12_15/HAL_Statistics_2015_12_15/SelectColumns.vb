
Public Class SelectColumns

   


  


    Public SQLTermList As New List(Of String)

    'Public Sub MyColBtnSelNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyColBtnSelNone.Click
    '    For i As Integer = 0 To MyCbList.Items.Count - 1
    '        MyCbList.SetItemChecked(i, False)
    '    Next
    'End Sub

    'Public Sub MyColBtnSelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyColBtnSelAll.Click
    '    For i As Integer = 0 To MyCbList.Items.Count - 1
    '        MyCbList.SetItemChecked(i, True)
    '    Next
    'End Sub


    'Public Sub SQL_Columns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Dim caseslist As New List(Of String)

    '    'MyCbList.Items.Add("Owner", CheckState.Checked)
    '    'MyCbList.Items.Add("Translator", CheckState.Checked)
    '    'MyCbList.Items.Add("Order number", CheckState.Checked)
    '    'MyCbList.Items.Add("Quotation number", CheckState.Checked)
    '    'MyCbList.Items.Add("Area", CheckState.Checked)
    '    'MyCbList.Items.Add("Description", CheckState.Checked)
    '    'MyCbList.Items.Add("Order date", CheckState.Checked)
    '    'MyCbList.Items.Add("Delivery date", CheckState.Checked)
    '    'MyCbList.Items.Add("Source langugage", CheckState.Checked)
    '    'MyCbList.Items.Add("Target langugage", CheckState.Checked)
    '    'MyCbList.Items.Add("No hit", CheckState.Checked)
    '    'MyCbList.Items.Add("Words(75-84)", CheckState.Checked)
    '    'MyCbList.Items.Add("Words(85-94) ", CheckState.Checked)
    '    'MyCbList.Items.Add("Words (95-99)", CheckState.Checked)
    '    'MyCbList.Items.Add("Words (100%)", CheckState.Checked)
    '    'MyCbList.Items.Add("Words (repetitins)", CheckState.Checked)
    '    'MyCbList.Items.Add("Words (CM)", CheckState.Checked)
    '    'MyCbList.Items.Add("Words (Total Words)", CheckState.Checked)
    '    'MyCbList.Items.Add("DTP", CheckState.Checked)
    '    'MyCbList.Items.Add("Ext.hr", CheckState.Checked)
    '    'MyCbList.Items.Add("Int.hrs", CheckState.Checked)
    '    'MyCbList.Items.Add("Cust. Invoiced", CheckState.Checked)
    '    'MyCbList.Items.Add("Estimated Customer Total", CheckState.Checked)
    '    'MyCbList.Items.Add("Estimated TB", CheckState.Checked)

    'End Sub




    'Private Sub MyCbList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim checkedItems As New List(Of Object)(MyCbList.CheckedItems.Count)
    '    For Each i As Object In MyCbList.CheckedItems
    '        checkedItems.Add(i)
    '    Next

    '    For Each item In checkedItems
    '        SQLTermList.Add(item)
    '    Next



    '    SQLTermList = SQLTermList.Distinct().ToList

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Proceed.Click
        Dim HashList As New List(Of String)

        If CheBx_COwner.Checked Then
            HashList.Add("antal50_74")
        Else
            HashList.Remove("antal50_74")
        End If

        If CheBx_NoHit.Checked Then
            HashList.Add("antal75_84")
        Else
            HashList.Remove("antal75_84")
        End If

        If CheBx_Words100.Checked Then
            HashList.Add("Words (100%)")
        Else
            HashList.Remove("Words (100%)")
        End If

        If CheBx_WordsRep.Checked Then
            HashList.Add("antalrep")
        Else
            HashList.Remove("antalrep")
        End If

        If CheBx_WordsCM.Checked Then
            HashList.Add("CM")
        Else
            HashList.Remove("CM")
        End If






        SQLTermList = HashList.Distinct().ToList
        SQLTermList.Sort()

        For Each item In SQLTermList
            MsgBox(item)
        Next


    End Sub

    Private Sub SelectColumns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheBx_Words100_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheBx_Words100.CheckedChanged













    End Sub
End Class

