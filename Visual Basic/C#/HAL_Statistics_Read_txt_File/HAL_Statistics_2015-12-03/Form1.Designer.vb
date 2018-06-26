<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TxtBoxPath = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Btn_Fill_Grid = New System.Windows.Forms.Button()
        Me.SelColumns = New System.Windows.Forms.Button()
        Me.Cbx_To_Months = New System.Windows.Forms.ComboBox()
        Me.Cbx_From_Months = New System.Windows.Forms.ComboBox()
        Me.Cbx_Year = New System.Windows.Forms.ComboBox()
        Me.Cbx_Company = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(577, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Load Excelfile"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TxtBoxPath
        '
        Me.TxtBoxPath.Location = New System.Drawing.Point(81, 9)
        Me.TxtBoxPath.Name = "TxtBoxPath"
        Me.TxtBoxPath.Size = New System.Drawing.Size(293, 20)
        Me.TxtBoxPath.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(577, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Read Folders"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(577, 65)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Create txt Files"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(577, 94)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(92, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Find Duplicates"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(81, 123)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(400, 21)
        Me.ComboBox1.TabIndex = 7
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(594, 123)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Extract"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(2, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1032, 544)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button7)
        Me.TabPage2.Controls.Add(Me.Btn_Fill_Grid)
        Me.TabPage2.Controls.Add(Me.SelColumns)
        Me.TabPage2.Controls.Add(Me.Cbx_To_Months)
        Me.TabPage2.Controls.Add(Me.Cbx_From_Months)
        Me.TabPage2.Controls.Add(Me.Cbx_Year)
        Me.TabPage2.Controls.Add(Me.Cbx_Company)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1024, 518)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Statistics"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(704, 13)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 10
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Btn_Fill_Grid
        '
        Me.Btn_Fill_Grid.Location = New System.Drawing.Point(623, 13)
        Me.Btn_Fill_Grid.Name = "Btn_Fill_Grid"
        Me.Btn_Fill_Grid.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Fill_Grid.TabIndex = 9
        Me.Btn_Fill_Grid.Text = "Fill Grid"
        Me.Btn_Fill_Grid.UseVisualStyleBackColor = True
        '
        'SelColumns
        '
        Me.SelColumns.Location = New System.Drawing.Point(528, 13)
        Me.SelColumns.Name = "SelColumns"
        Me.SelColumns.Size = New System.Drawing.Size(89, 23)
        Me.SelColumns.TabIndex = 8
        Me.SelColumns.Text = "Select Columns"
        Me.SelColumns.UseVisualStyleBackColor = True
        '
        'Cbx_To_Months
        '
        Me.Cbx_To_Months.FormattingEnabled = True
        Me.Cbx_To_Months.Location = New System.Drawing.Point(462, 15)
        Me.Cbx_To_Months.Name = "Cbx_To_Months"
        Me.Cbx_To_Months.Size = New System.Drawing.Size(60, 21)
        Me.Cbx_To_Months.TabIndex = 7
        '
        'Cbx_From_Months
        '
        Me.Cbx_From_Months.FormattingEnabled = True
        Me.Cbx_From_Months.Location = New System.Drawing.Point(402, 15)
        Me.Cbx_From_Months.Name = "Cbx_From_Months"
        Me.Cbx_From_Months.Size = New System.Drawing.Size(54, 21)
        Me.Cbx_From_Months.TabIndex = 6
        '
        'Cbx_Year
        '
        Me.Cbx_Year.FormattingEnabled = True
        Me.Cbx_Year.Location = New System.Drawing.Point(324, 15)
        Me.Cbx_Year.Name = "Cbx_Year"
        Me.Cbx_Year.Size = New System.Drawing.Size(72, 21)
        Me.Cbx_Year.TabIndex = 5
        '
        'Cbx_Company
        '
        Me.Cbx_Company.FormattingEnabled = True
        Me.Cbx_Company.Location = New System.Drawing.Point(6, 15)
        Me.Cbx_Company.Name = "Cbx_Company"
        Me.Cbx_Company.Size = New System.Drawing.Size(312, 21)
        Me.Cbx_Company.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 42)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(982, 470)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.TxtBoxPath)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1024, 518)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "CM"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 551)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "HAL_Statistics"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TxtBoxPath As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Fill_Grid As System.Windows.Forms.Button
    Friend WithEvents SelColumns As System.Windows.Forms.Button
    Friend WithEvents Cbx_To_Months As System.Windows.Forms.ComboBox
    Friend WithEvents Cbx_From_Months As System.Windows.Forms.ComboBox
    Friend WithEvents Cbx_Year As System.Windows.Forms.ComboBox
    Friend WithEvents Cbx_Company As System.Windows.Forms.ComboBox
    Friend WithEvents Button7 As System.Windows.Forms.Button

End Class
