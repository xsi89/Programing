Imports System.Management
Imports Microsoft.DirectX.DirectSound

Public Class Form1
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim f As Form
        f = sender
        If f.WindowState = FormWindowState.Minimized Then
            ShowInTaskbar = False
            NotifyIcon1.Visible = True
        End If
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.WindowState = FormWindowState.Minimized
        ShowInTaskbar = False
        NotifyIcon1.Visible = True
    End Sub
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.WindowState = FormWindowState.Normal
        ShowInTaskbar = True
        NotifyIcon1.Visible = False
    End Sub
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
        ShowInTaskbar = True
        NotifyIcon1.Visible = False
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

  


    End Sub
End Class