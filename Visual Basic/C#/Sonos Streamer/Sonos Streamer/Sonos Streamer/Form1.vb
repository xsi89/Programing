Imports System.Management
Imports Microsoft.DirectX
Imports Microsoft.DirectX.AudioVideoPlayback
Imports Microsoft.DirectX.DirectSound

Public Class Form1
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Dim f As Form
        f = sender
        If f.WindowState = FormWindowState.Minimized Then
            ShowInTaskbar = False
            NotifyIcon1.Visible = True
        End If


        ' listar alla ljudkort




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

        Dim objSearcher As New System.Management.ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice")
        Dim objCollection As System.Management.ManagementObjectCollection = objSearcher.Get()

        '   For Each obj As System.Management.ManagementObject In objCollection
        '   ComboBox1.Items.Add(obj.GetPropertyValue("Caption").ToString())
        '  Next

    End Sub


    Public Declare Function waveOutGetNumDevs Lib "winmm.dll" () As Long
    Public Declare Function waveInGetNumDevs Lib "winmm.dll" () As Long


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        '    Dim SoundDevicelist As New List(Of String)
        '    Try
        '        Dim searcher As New ManagementObjectSearcher(
        '            "root\CIMV2",
        '            "SELECT * FROM Win32_SoundDevice")

        '        For Each queryObj As ManagementObject In searcher.Get()
        '            ' Console.WriteLine("-----------------------------------")
        '            'Console.WriteLine("Description: {0}", queryObj("Description"))
        '            'Console.WriteLine("Manufacturer: {0}", queryObj("Manufacturer"))
        '            ' Console.WriteLine("Caption: {0}", queryObj("Caption"))
        '            ' Console.WriteLine("PNPDeviceID: {0}", queryObj("PNPDeviceID"))
        '            ' Console.WriteLine("Availability: {0}", queryObj("Availability"))
        '            SoundDevicelist.Add(queryObj("Caption").ToString())
        '        Next
        '    Catch err As ManagementException
        '        MessageBox.Show("An error occurred while querying for WMI data: " & err.Message)
        '    End Try
        '    For Each item In SoundDevicelist
        '        MsgBox(item)
        '    Next
        Dim audioPlaybackDevices As Long
        audioPlaybackDevices = waveOutGetNumDevs
        MsgBox("This computer has: " & audioPlaybackDevices & " playback devices")



    End Sub
End Class