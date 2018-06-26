<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HAL_Statistics
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Company = New System.Windows.Forms.ComboBox()
        Me.SourLang = New System.Windows.Forms.RichTextBox()
        Me.TarLang = New System.Windows.Forms.RichTextBox()
        Me.SelColumns = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Owner_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Translator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quotation_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delivery_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Source_language = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Target_langugage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No_Hit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Words_75_84 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Words_85_94 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Words_95_99 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Words_100 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Words_Repetitins = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Words_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total_words = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXT_hrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Int_hrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cust_Invoiced = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estimated_customer_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estimated_CM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ordernr = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Company
        '
        Me.Company.FormattingEnabled = True
        Me.Company.Location = New System.Drawing.Point(103, 14)
        Me.Company.Name = "Company"
        Me.Company.Size = New System.Drawing.Size(305, 21)
        Me.Company.TabIndex = 0
        '
        'SourLang
        '
        Me.SourLang.Location = New System.Drawing.Point(12, 52)
        Me.SourLang.Name = "SourLang"
        Me.SourLang.Size = New System.Drawing.Size(75, 218)
        Me.SourLang.TabIndex = 3
        Me.SourLang.Text = ""
        '
        'TarLang
        '
        Me.TarLang.Location = New System.Drawing.Point(12, 276)
        Me.TarLang.Name = "TarLang"
        Me.TarLang.Size = New System.Drawing.Size(75, 279)
        Me.TarLang.TabIndex = 4
        Me.TarLang.Text = ""
        '
        'SelColumns
        '
        Me.SelColumns.Location = New System.Drawing.Point(12, 12)
        Me.SelColumns.Name = "SelColumns"
        Me.SelColumns.Size = New System.Drawing.Size(75, 23)
        Me.SelColumns.TabIndex = 5
        Me.SelColumns.Text = "Select columns"
        Me.SelColumns.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Owner_, Me.Translator, Me.Order_number, Me.Quotation_number, Me.Area, Me.Description, Me.Order_date, Me.Delivery_date, Me.Source_language, Me.Target_langugage, Me.No_Hit, Me.Words_75_84, Me.Words_85_94, Me.Words_95_99, Me.Words_100, Me.Words_Repetitins, Me.Words_CM, Me.Total_words, Me.dtp, Me.EXT_hrs, Me.Int_hrs, Me.Cust_Invoiced, Me.Estimated_customer_total, Me.Estimated_CM})
        Me.DataGridView1.Location = New System.Drawing.Point(103, 52)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1148, 503)
        Me.DataGridView1.TabIndex = 6
        '
        'Owner_
        '
        Me.Owner_.HeaderText = "Owner_"
        Me.Owner_.Name = "Owner_"
        Me.Owner_.ReadOnly = True
        '
        'Translator
        '
        Me.Translator.HeaderText = "Translator"
        Me.Translator.Name = "Translator"
        Me.Translator.ReadOnly = True
        '
        'Order_number
        '
        Me.Order_number.HeaderText = "Order number"
        Me.Order_number.Name = "Order_number"
        Me.Order_number.ReadOnly = True
        '
        'Quotation_number
        '
        Me.Quotation_number.HeaderText = "Quotation number"
        Me.Quotation_number.Name = "Quotation_number"
        Me.Quotation_number.ReadOnly = True
        '
        'Area
        '
        Me.Area.HeaderText = "Area"
        Me.Area.Name = "Area"
        Me.Area.ReadOnly = True
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'Order_date
        '
        Me.Order_date.HeaderText = "Order date"
        Me.Order_date.Name = "Order_date"
        Me.Order_date.ReadOnly = True
        '
        'Delivery_date
        '
        Me.Delivery_date.HeaderText = "Delivery date"
        Me.Delivery_date.Name = "Delivery_date"
        Me.Delivery_date.ReadOnly = True
        '
        'Source_language
        '
        Me.Source_language.HeaderText = "Source language"
        Me.Source_language.Name = "Source_language"
        Me.Source_language.ReadOnly = True
        '
        'Target_langugage
        '
        Me.Target_langugage.HeaderText = "Target language"
        Me.Target_langugage.Name = "Target_langugage"
        Me.Target_langugage.ReadOnly = True
        '
        'No_Hit
        '
        Me.No_Hit.HeaderText = "No-Hit"
        Me.No_Hit.Name = "No_Hit"
        Me.No_Hit.ReadOnly = True
        '
        'Words_75_84
        '
        Me.Words_75_84.HeaderText = "Words (75 84)"
        Me.Words_75_84.Name = "Words_75_84"
        Me.Words_75_84.ReadOnly = True
        '
        'Words_85_94
        '
        Me.Words_85_94.HeaderText = "Words (85-94)"
        Me.Words_85_94.Name = "Words_85_94"
        Me.Words_85_94.ReadOnly = True
        '
        'Words_95_99
        '
        Me.Words_95_99.HeaderText = "Words (95-99)"
        Me.Words_95_99.Name = "Words_95_99"
        Me.Words_95_99.ReadOnly = True
        '
        'Words_100
        '
        Me.Words_100.HeaderText = "Words (100%)"
        Me.Words_100.Name = "Words_100"
        Me.Words_100.ReadOnly = True
        '
        'Words_Repetitins
        '
        Me.Words_Repetitins.HeaderText = "Words (Repititions)"
        Me.Words_Repetitins.Name = "Words_Repetitins"
        Me.Words_Repetitins.ReadOnly = True
        '
        'Words_CM
        '
        Me.Words_CM.HeaderText = "Words (CM)"
        Me.Words_CM.Name = "Words_CM"
        Me.Words_CM.ReadOnly = True
        '
        'Total_words
        '
        Me.Total_words.HeaderText = "Total words"
        Me.Total_words.Name = "Total_words"
        Me.Total_words.ReadOnly = True
        '
        'dtp
        '
        Me.dtp.HeaderText = "DTP"
        Me.dtp.Name = "dtp"
        Me.dtp.ReadOnly = True
        '
        'EXT_hrs
        '
        Me.EXT_hrs.HeaderText = "Ext hrs"
        Me.EXT_hrs.Name = "EXT_hrs"
        Me.EXT_hrs.ReadOnly = True
        '
        'Int_hrs
        '
        Me.Int_hrs.HeaderText = "Int hrs"
        Me.Int_hrs.Name = "Int_hrs"
        Me.Int_hrs.ReadOnly = True
        '
        'Cust_Invoiced
        '
        Me.Cust_Invoiced.HeaderText = "Cust. invoiced"
        Me.Cust_Invoiced.Name = "Cust_Invoiced"
        Me.Cust_Invoiced.ReadOnly = True
        '
        'Estimated_customer_total
        '
        Me.Estimated_customer_total.HeaderText = "Estimated customer total"
        Me.Estimated_customer_total.Name = "Estimated_customer_total"
        Me.Estimated_customer_total.ReadOnly = True
        '
        'Estimated_CM
        '
        Me.Estimated_CM.HeaderText = "Estimated CM"
        Me.Estimated_CM.Name = "Estimated_CM"
        Me.Estimated_CM.ReadOnly = True
        '
        'Ordernr
        '
        Me.Ordernr.FormattingEnabled = True
        Me.Ordernr.Location = New System.Drawing.Point(470, 13)
        Me.Ordernr.Name = "Ordernr"
        Me.Ordernr.Size = New System.Drawing.Size(121, 21)
        Me.Ordernr.TabIndex = 7
        '
        'HAL_Statistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1263, 567)
        Me.Controls.Add(Me.Ordernr)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.SelColumns)
        Me.Controls.Add(Me.TarLang)
        Me.Controls.Add(Me.SourLang)
        Me.Controls.Add(Me.Company)
        Me.Name = "HAL_Statistics"
        Me.Text = "HAL Statistics"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Company As System.Windows.Forms.ComboBox
    Friend WithEvents SourLang As System.Windows.Forms.RichTextBox
    Friend WithEvents TarLang As System.Windows.Forms.RichTextBox
    Friend WithEvents SelColumns As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Owner_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Translator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order_number As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quotation_number As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Area As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delivery_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Source_language As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Target_langugage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No_Hit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Words_75_84 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Words_85_94 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Words_95_99 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Words_100 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Words_Repetitins As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Words_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total_words As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXT_hrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Int_hrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cust_Invoiced As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estimated_customer_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estimated_CM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ordernr As System.Windows.Forms.ComboBox
End Class
