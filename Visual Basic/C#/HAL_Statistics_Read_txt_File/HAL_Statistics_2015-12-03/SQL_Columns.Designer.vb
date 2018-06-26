<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQL_Columns
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
        Me.MyColBtnSelAll = New System.Windows.Forms.Button()
        Me.MyColBtnSelNone = New System.Windows.Forms.Button()
        Me.MyColBox = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'MyColBtnSelAll
        '
        Me.MyColBtnSelAll.Location = New System.Drawing.Point(94, 412)
        Me.MyColBtnSelAll.Name = "MyColBtnSelAll"
        Me.MyColBtnSelAll.Size = New System.Drawing.Size(75, 23)
        Me.MyColBtnSelAll.TabIndex = 7
        Me.MyColBtnSelAll.Text = "Select All"
        Me.MyColBtnSelAll.UseVisualStyleBackColor = True
        '
        'MyColBtnSelNone
        '
        Me.MyColBtnSelNone.Location = New System.Drawing.Point(8, 412)
        Me.MyColBtnSelNone.Name = "MyColBtnSelNone"
        Me.MyColBtnSelNone.Size = New System.Drawing.Size(80, 23)
        Me.MyColBtnSelNone.TabIndex = 6
        Me.MyColBtnSelNone.Text = "Select None"
        Me.MyColBtnSelNone.UseVisualStyleBackColor = True
        '
        'MyColBox
        '
        Me.MyColBox.FormattingEnabled = True
        Me.MyColBox.Location = New System.Drawing.Point(12, 12)
        Me.MyColBox.Name = "MyColBox"
        Me.MyColBox.Size = New System.Drawing.Size(169, 394)
        Me.MyColBox.TabIndex = 5
        '
        'SQL_Columns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(191, 444)
        Me.Controls.Add(Me.MyColBtnSelAll)
        Me.Controls.Add(Me.MyColBtnSelNone)
        Me.Controls.Add(Me.MyColBox)
        Me.Name = "SQL_Columns"
        Me.Text = "SQL_Columns"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyColBtnSelAll As System.Windows.Forms.Button
    Friend WithEvents MyColBtnSelNone As System.Windows.Forms.Button
    Friend WithEvents MyColBox As System.Windows.Forms.CheckedListBox
End Class
