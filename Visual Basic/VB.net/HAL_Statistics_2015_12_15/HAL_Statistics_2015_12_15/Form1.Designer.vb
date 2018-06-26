<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DG2
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Cbx_FromYear = New System.Windows.Forms.ComboBox()
        Me.Cbx_From_Months = New System.Windows.Forms.ComboBox()
        Me.Cbx_To_Months = New System.Windows.Forms.ComboBox()
        Me.Cbx_Company = New System.Windows.Forms.ComboBox()
        Me.Btn_Fill_Grid = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Cbx_ToYear = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Cbx_ToExcel = New System.Windows.Forms.Button()
        Me.Cbx_Fill_Grid = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cbx_FromYear
        '
        Me.Cbx_FromYear.FormattingEnabled = True
        Me.Cbx_FromYear.Location = New System.Drawing.Point(484, 12)
        Me.Cbx_FromYear.Name = "Cbx_FromYear"
        Me.Cbx_FromYear.Size = New System.Drawing.Size(72, 21)
        Me.Cbx_FromYear.TabIndex = 0
        '
        'Cbx_From_Months
        '
        Me.Cbx_From_Months.FormattingEnabled = True
        Me.Cbx_From_Months.Location = New System.Drawing.Point(654, 10)
        Me.Cbx_From_Months.Name = "Cbx_From_Months"
        Me.Cbx_From_Months.Size = New System.Drawing.Size(54, 21)
        Me.Cbx_From_Months.TabIndex = 1
        '
        'Cbx_To_Months
        '
        Me.Cbx_To_Months.FormattingEnabled = True
        Me.Cbx_To_Months.Location = New System.Drawing.Point(714, 10)
        Me.Cbx_To_Months.Name = "Cbx_To_Months"
        Me.Cbx_To_Months.Size = New System.Drawing.Size(60, 21)
        Me.Cbx_To_Months.TabIndex = 2
        '
        'Cbx_Company
        '
        Me.Cbx_Company.FormattingEnabled = True
        Me.Cbx_Company.Location = New System.Drawing.Point(28, 12)
        Me.Cbx_Company.Name = "Cbx_Company"
        Me.Cbx_Company.Size = New System.Drawing.Size(450, 21)
        Me.Cbx_Company.TabIndex = 3
        '
        'Btn_Fill_Grid
        '
        Me.Btn_Fill_Grid.Location = New System.Drawing.Point(780, 8)
        Me.Btn_Fill_Grid.Name = "Btn_Fill_Grid"
        Me.Btn_Fill_Grid.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Fill_Grid.TabIndex = 4
        Me.Btn_Fill_Grid.Text = "Fill Grid"
        Me.Btn_Fill_Grid.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(3, 46)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(705, 532)
        Me.DataGridView1.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(933, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Select Columns"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Cbx_ToYear
        '
        Me.Cbx_ToYear.FormattingEnabled = True
        Me.Cbx_ToYear.Location = New System.Drawing.Point(562, 10)
        Me.Cbx_ToYear.Name = "Cbx_ToYear"
        Me.Cbx_ToYear.Size = New System.Drawing.Size(72, 21)
        Me.Cbx_ToYear.TabIndex = 8
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(861, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "DG2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Cbx_ToExcel
        '
        Me.Cbx_ToExcel.Location = New System.Drawing.Point(1028, 8)
        Me.Cbx_ToExcel.Name = "Cbx_ToExcel"
        Me.Cbx_ToExcel.Size = New System.Drawing.Size(95, 23)
        Me.Cbx_ToExcel.TabIndex = 12
        Me.Cbx_ToExcel.Text = "Export to Excel"
        Me.Cbx_ToExcel.UseVisualStyleBackColor = True
        '
        'Cbx_Fill_Grid
        '
        Me.Cbx_Fill_Grid.Location = New System.Drawing.Point(1129, 8)
        Me.Cbx_Fill_Grid.Name = "Cbx_Fill_Grid"
        Me.Cbx_Fill_Grid.Size = New System.Drawing.Size(75, 23)
        Me.Cbx_Fill_Grid.TabIndex = 13
        Me.Cbx_Fill_Grid.Text = "Fill Grid Merged"
        Me.Cbx_Fill_Grid.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.Location = New System.Drawing.Point(822, 46)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(491, 532)
        Me.DataGridView2.TabIndex = 14
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1238, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DG2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1373, 590)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Cbx_Fill_Grid)
        Me.Controls.Add(Me.Cbx_ToExcel)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Cbx_ToYear)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Btn_Fill_Grid)
        Me.Controls.Add(Me.Cbx_Company)
        Me.Controls.Add(Me.Cbx_To_Months)
        Me.Controls.Add(Me.Cbx_From_Months)
        Me.Controls.Add(Me.Cbx_FromYear)
        Me.Name = "DG2"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Cbx_FromYear As System.Windows.Forms.ComboBox
    Friend WithEvents Cbx_From_Months As System.Windows.Forms.ComboBox
    Friend WithEvents Cbx_To_Months As System.Windows.Forms.ComboBox
    Friend WithEvents Cbx_Company As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Fill_Grid As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Cbx_ToYear As System.Windows.Forms.ComboBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Cbx_ToExcel As System.Windows.Forms.Button
    Friend WithEvents Cbx_Fill_Grid As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
