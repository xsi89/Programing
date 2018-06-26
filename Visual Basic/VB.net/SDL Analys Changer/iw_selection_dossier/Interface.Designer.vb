<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SdlStudioChanger
    Inherits System.Windows.Forms.Form

    'Form replaces dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SdlStudioChanger))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tb_FilePath = New System.Windows.Forms.TextBox()
        Me.BT_Browse = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select your XML folder"
        Me.FolderBrowserDialog1.SelectedPath = "C:\Users\Documents"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Location:"
        '
        'Tb_FilePath
        '
        Me.Tb_FilePath.Location = New System.Drawing.Point(12, 48)
        Me.Tb_FilePath.Name = "Tb_FilePath"
        Me.Tb_FilePath.Size = New System.Drawing.Size(255, 20)
        Me.Tb_FilePath.TabIndex = 1
        '
        'BT_Browse
        '
        Me.BT_Browse.Location = New System.Drawing.Point(273, 48)
        Me.BT_Browse.Name = "BT_Browse"
        Me.BT_Browse.Size = New System.Drawing.Size(75, 23)
        Me.BT_Browse.TabIndex = 2
        Me.BT_Browse.Text = "Browse"
        Me.BT_Browse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Created by Daniel Elmnäs"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SDL_studio_analys_Changer.My.Resources.Resources.TEKNOTRANS_logo_40x40
        Me.PictureBox1.Location = New System.Drawing.Point(309, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(39, 39)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'SdlStudioChanger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 87)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BT_Browse)
        Me.Controls.Add(Me.Tb_FilePath)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SdlStudioChanger"
        Me.Text = "SDL Studio analyze changer © Teknotrans AB"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tb_FilePath As System.Windows.Forms.TextBox
    Friend WithEvents BT_Browse As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
