Public Class SQL_Columns

    Private Sub MyColBtnSelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyColBtnSelAll.Click
        For i As Integer = 0 To MyColBox.Items.Count - 1
            MyColBox.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub MyColBtnSelNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyColBtnSelNone.Click
        For i As Integer = 0 To MyColBox.Items.Count - 1
            MyColBox.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub SQL_Columns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MyColBox.Items.Add("Owner", CheckState.Checked)
        MyColBox.Items.Add("Translator", CheckState.Checked)
        MyColBox.Items.Add("Order number", CheckState.Checked)
        MyColBox.Items.Add("Quotation number", CheckState.Checked)
        MyColBox.Items.Add("Area", CheckState.Checked)
        MyColBox.Items.Add("Description", CheckState.Checked)
        MyColBox.Items.Add("Order date", CheckState.Checked)
        MyColBox.Items.Add("Delivery date", CheckState.Checked)
        MyColBox.Items.Add("Source langugage", CheckState.Checked)
        MyColBox.Items.Add("Target langugage", CheckState.Checked)
        MyColBox.Items.Add("No hit", CheckState.Checked)
        MyColBox.Items.Add("Words(75-84)", CheckState.Checked)
        MyColBox.Items.Add("Words(85-94) ", CheckState.Checked)
        MyColBox.Items.Add("Words (95-99)", CheckState.Checked)
        MyColBox.Items.Add("Words (100%)", CheckState.Checked)
        MyColBox.Items.Add("Words (repetitins)", CheckState.Checked)
        MyColBox.Items.Add("Words (CM)", CheckState.Checked)
        MyColBox.Items.Add("Words (Total Words)", CheckState.Checked)
        MyColBox.Items.Add("DTP", CheckState.Checked)
        MyColBox.Items.Add("Ext.hr", CheckState.Checked)
        MyColBox.Items.Add("Int.hrs", CheckState.Checked)
        MyColBox.Items.Add("Cust. Invoiced", CheckState.Checked)
        MyColBox.Items.Add("Estimated Customer Total", CheckState.Checked)
        MyColBox.Items.Add("Estimated TB", CheckState.Checked)


    End Sub
End Class