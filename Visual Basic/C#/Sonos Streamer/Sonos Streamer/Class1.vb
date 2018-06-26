Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Module modSoundRec
    Public Class Class1

    End Class
    Private Const MMSYSERR_NOERROR As Integer = 0
    Private Const CALLBACK_FUNCTION As Integer = &H30000
    Private Const WAVE_FORMAT_4S16 As Integer = &H800 ' 44.1 kHz, Stereo, 16-bit
    Private Const WAVE_FORMAT_PCM As Integer = 1
    Private Const WAVE_MAPPER As Integer = -1
    Private Const WIM_DATA As Integer = &H3C0
    Private Const NumSamples As Integer = 1024

    <StructLayout(LayoutKind.Sequential)>
    Structure WaveFormatEx
        Dim FormatTag As Short
        Dim Channels As Short
        Dim SamplesPerSec As Integer
        Dim AvgBytesPerSec As Integer
        Dim BlockAlign As Short
        Dim BitsPerSample As Short
        Dim ExtraDataSize As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Structure WaveHdr
        Dim lpData As IntPtr
        Dim dwBufferLength As Integer
        Dim dwBytesRecorded As Integer
        Dim dwUser As Integer
        Dim dwFlags As Integer
        Dim dwLoops As Integer
        Dim lpNext As Integer
        Dim Reserved As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Structure WaveInCaps
        Dim ManufacturerID As Short
        Dim ProductID As Short
        Dim DriverVersion As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
        Dim ProductName() As Byte
        Dim Formats As Integer
        Dim Channels As Short
        Dim Reserved As Short
    End Structure

    <DllImport("winmm.dll", EntryPoint:="waveInAddBuffer")>
    Private Function waveInAddBuffer(
            ByVal InputDeviceHandle As IntPtr,
            ByRef WaveHdrPointer As WaveHdr,
            ByVal WaveHdrStructSize As Integer) As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInPrepareHeader")>
    Private Function waveInPrepareHeader(
            ByVal InputDeviceHandle As IntPtr,
            ByRef WaveHdrPointer As WaveHdr,
            ByVal WaveHdrStructSize As Integer) As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInUnprepareHeader")>
    Private Function waveInUnprepareHeader(
            ByVal InputDeviceHandle As IntPtr,
            ByRef WaveHdrPointer As WaveHdr,
            ByVal WaveHdrStructSize As Integer) As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInGetNumDevs")>
    Private Function waveInGetNumDevs() As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInGetDevCapsA")>
    Private Function waveInGetDevCaps(
            ByVal uDeviceID As Integer,
            ByRef WaveInCapsPointer As WaveInCaps,
            ByVal WaveInCapsStructSize As Integer) As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInOpen")>
    Private Function waveInOpen(
            ByRef WaveDeviceInputHandle As IntPtr,
            ByVal WhichDevice As Integer,
            ByRef WaveFormatExPointer As WaveFormatEx,
            ByVal dwCallback As WaveCallbackProc,
            ByVal CallBackInstance As Integer,
            ByVal Flags As Integer) As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInClose")>
    Private Function waveInClose(
            ByVal WaveDeviceInputHandle As IntPtr) As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInStart")>
    Private Function waveInStart(
            ByVal WaveDeviceInputHandle As IntPtr) As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInReset")>
    Private Function waveInReset(
            ByVal WaveDeviceInputHandle As IntPtr) As Integer
    End Function

    <DllImport("winmm.dll", EntryPoint:="waveInStop")>
    Private Function waveInStop(
            ByVal WaveDeviceInputHandle As IntPtr) As Integer
    End Function

    Private DevHandle As IntPtr = IntPtr.Zero
    Private tWH As New WaveHdr
    Private WaveData As Short() = New Short(0 To (NumSamples * 2) - 1) {}
    Private RecData As Short() = New Short(0 To (NumSamples * 2) - 1) {}
    Private IsRunning As New Boolean
    Private GC As New GCHandle
    Private pCallback As WaveCallbackProc = AddressOf WaveInProc

    Private Delegate Sub WaveCallbackProc(ByVal hWaveIn As IntPtr, ByVal uMsg As Integer,
            ByVal dwInstance As Integer, ByRef dwParam1 As WaveHdr, ByVal dwParam2 As Integer)

    Private Sub WaveInProc(ByVal hWaveIn As IntPtr, ByVal uMsg As Integer,
            ByVal dwInstance As Integer, ByRef dwParam1 As WaveHdr, ByVal dwParam2 As Integer)

        If uMsg = WIM_DATA Then
            If IsRunning = True Then

                Marshal.Copy(dwParam1.lpData, RecData, 0, NumSamples * 2)

                ' in RecData stehen jetzt die aktuellen Wavedaten

                Call waveInAddBuffer(DevHandle, tWH, Marshal.SizeOf(tWH))

                modSoundPlay.WriteSamples(RecData)
            End If
        End If

    End Sub

    Public Function ListSoundDevice(ByRef DeviceName() As String) As Boolean

        Dim intItem As New Integer
        Dim intNext As New Integer
        Dim intCount As New Integer
        Dim tWIC As New WaveInCaps
        Dim Enc As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()

        intCount = waveInGetNumDevs()

        If intCount <> 0 Then
            For intItem = 0 To intCount - 1
                If waveInGetDevCaps(intItem, tWIC, Marshal.SizeOf(tWIC)) = MMSYSERR_NOERROR Then
                    If (tWIC.Formats And WAVE_FORMAT_4S16) = WAVE_FORMAT_4S16 Then
                        ReDim Preserve DeviceName(intNext)
                        DeviceName(intNext) = Enc.GetString(tWIC.ProductName)
                        intNext += 1
                    End If
                End If
            Next

            If intNext > 0 Then
                ListSoundDevice = True
            End If
        End If

    End Function

    Public Function StartRec(Optional ByVal DeviceID As Integer = WAVE_MAPPER) As Boolean

        Dim tWFE As New WaveFormatEx

        If IsRunning = False Then
            With tWFE
                .FormatTag = WAVE_FORMAT_PCM
                .Channels = 2
                .SamplesPerSec = 44100
                .BitsPerSample = 16
                .BlockAlign = CShort((.Channels * .BitsPerSample) \ 8)
                .AvgBytesPerSec = .BlockAlign * .SamplesPerSec
                .ExtraDataSize = 0
            End With

            If waveInOpen(DevHandle, DeviceID, tWFE, pCallback, 0&,
                    CALLBACK_FUNCTION) = MMSYSERR_NOERROR Then

                GC = GCHandle.Alloc(WaveData, GCHandleType.Pinned)

                With tWH
                    .lpData = GC.AddrOfPinnedObject
                    .dwBufferLength = NumSamples * 4
                    .dwFlags = 0
                End With

                If waveInPrepareHeader(DevHandle, tWH, Marshal.SizeOf(tWH)) =
                        MMSYSERR_NOERROR Then

                    If waveInAddBuffer(DevHandle, tWH, Marshal.SizeOf(tWH)) =
                            MMSYSERR_NOERROR Then

                        IsRunning = True

                        If waveInStart(DevHandle) = MMSYSERR_NOERROR Then

                            StartRec = True

                        End If

                    End If
                End If
            End If
        End If

    End Function

    Public Function StopRec() As Boolean

        If IsRunning = True Then
            IsRunning = False
            If DevHandle <> IntPtr.Zero Then
                If waveInReset(DevHandle) = MMSYSERR_NOERROR Then
                    If waveInStop(DevHandle) = MMSYSERR_NOERROR Then

                        If waveInUnprepareHeader(DevHandle, tWH,
                                Marshal.SizeOf(tWH)) = MMSYSERR_NOERROR Then

                            If waveInClose(DevHandle) = MMSYSERR_NOERROR Then

                                DevHandle = IntPtr.Zero
                                GC.Free()
                                StopRec = True

                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Function

End Module




Module modSoundPlay

        Private Const MMSYSERR_NOERROR As Integer = 0
        Private Const CALLBACK_FUNCTION As Integer = &H30000
        Private Const WAVE_FORMAT_4S16 As Integer = &H800 ' 44.1 kHz, Stereo, 16-bit
        Private Const WAVE_FORMAT_PCM As Integer = 1
        Private Const WAVE_MAPPER As Integer = -1
        Private Const WIM_DATA As Integer = &H3C0
        Private Const NumSamples As Integer = 1024

        <StructLayout(LayoutKind.Sequential)>
        Structure WaveFormatEx
            Dim FormatTag As Short
            Dim Channels As Short
            Dim SamplesPerSec As Integer
            Dim AvgBytesPerSec As Integer
            Dim BlockAlign As Short
            Dim BitsPerSample As Short
            Dim ExtraDataSize As Short
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Structure WaveHdr
            Dim lpData As IntPtr
            Dim dwBufferLength As Integer
            Dim dwBytesRecorded As Integer
            Dim dwUser As Integer
            Dim dwFlags As Integer
            Dim dwLoops As Integer
            Dim lpNext As Integer
            Dim Reserved As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Structure WaveOutCaps
            Dim ManufacturerID As Short
            Dim ProductID As Short
            Dim DriverVersion As Integer
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
            Dim ProductName() As Byte
            Dim Formats As Integer
            Dim Channels As Short
            Dim Reserved As Short
        End Structure

        <DllImport("winmm.dll", EntryPoint:="waveOutWrite")>
        Private Function waveOutWrite(
        ByVal OutputDeviceHandle As IntPtr,
        ByRef WaveHdrPointer As WaveHdr,
        ByVal WaveHdrStructSize As Integer) As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutPrepareHeader")>
        Private Function waveOutPrepareHeader(
            ByVal OutputDeviceHandle As IntPtr,
            ByRef WaveHdrPointer As WaveHdr,
            ByVal WaveHdrStructSize As Integer) As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutUnprepareHeader")>
        Private Function waveOutUnprepareHeader(
            ByVal OutputDeviceHandle As IntPtr,
            ByRef WaveHdrPointer As WaveHdr,
            ByVal WaveHdrStructSize As Integer) As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutGetNumDevs")>
        Private Function waveOutGetNumDevs() As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutGetDevCapsA")>
        Private Function waveOutGetDevCaps(
            ByVal uDeviceID As Integer,
            ByRef WaveInCapsPointer As WaveOutCaps,
            ByVal WaveInCapsStructSize As Integer) As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutOpen")>
        Private Function waveOutOpen(
            ByRef OutputDeviceHandle As IntPtr,
            ByVal WhichDevice As Integer,
            ByRef WaveFormatExPointer As WaveFormatEx,
            ByVal dwCallback As WaveCallbackProc,
            ByVal CallBackInstance As Integer,
            ByVal Flags As Integer) As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutClose")>
        Private Function waveOutClose(
            ByVal OutputDeviceHandle As IntPtr) As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutRestart")>
        Private Function waveOutRestart(
            ByVal OutputDeviceHandle As IntPtr) As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutReset")>
        Private Function waveOutReset(
            ByVal OutputDeviceHandle As IntPtr) As Integer
        End Function

        <DllImport("winmm.dll", EntryPoint:="waveOutPause")>
        Private Function waveOutPause(
            ByVal OutputDeviceHandle As IntPtr) As Integer
        End Function

        Private DevHandle As IntPtr = IntPtr.Zero
        Private tWH As New WaveHdr
        Private WaveData As Short() = New Short(0 To (NumSamples * 2) - 1) {}
        Private RecData As Short() = New Short(0 To (NumSamples * 2) - 1) {}
        Private IsRunning As New Boolean
        Private GC As New GCHandle
        Private pCallback As WaveCallbackProc = AddressOf WaveInProc

        Private Delegate Sub WaveCallbackProc(ByVal hWaveOut As IntPtr, ByVal uMsg As Integer,
            ByVal dwInstance As Integer, ByRef dwParam1 As WaveHdr, ByVal dwParam2 As Integer)

        Private Sub WaveInProc(ByVal hWaveOut As IntPtr, ByVal uMsg As Integer,
            ByVal dwInstance As Integer, ByRef dwParam1 As WaveHdr, ByVal dwParam2 As Integer)

            ' If uMsg = WIM_DATA Then
            'If IsRunning = True Then

            'Marshal.Copy(dwParam1.lpData, RecData, 0, NumSamples * 2)

            ' in RecData stehen jetzt die aktuellen Wavedaten

            'Call waveOutAddBuffer(DevHandle, tWH, Marshal.SizeOf(tWH))
            'End If
            'End If

        End Sub

        Public Function ListSoundDevice(ByRef DeviceName() As String) As Boolean

            Dim intItem As New Integer
            Dim intNext As New Integer
            Dim intCount As New Integer
            Dim tWIC As New WaveOutCaps
            Dim Enc As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()

            intCount = waveOutGetNumDevs()

            If intCount <> 0 Then
                For intItem = 0 To intCount - 1
                    If waveOutGetDevCaps(intItem, tWIC, Marshal.SizeOf(tWIC)) = MMSYSERR_NOERROR Then
                        If (tWIC.Formats And WAVE_FORMAT_4S16) = WAVE_FORMAT_4S16 Then
                            ReDim Preserve DeviceName(intNext)
                            DeviceName(intNext) = Enc.GetString(tWIC.ProductName)
                            intNext += 1
                        End If
                    End If
                Next

                If intNext > 0 Then
                    ListSoundDevice = True
                End If
            End If

        End Function

        Public Function StartPlayback(Optional ByVal DeviceID As Integer = WAVE_MAPPER) As Boolean

            Dim tWFE As New WaveFormatEx

            If IsRunning = False Then
                With tWFE
                    .FormatTag = WAVE_FORMAT_PCM
                    .Channels = 2
                    .SamplesPerSec = 44100
                    .BitsPerSample = 16
                    .BlockAlign = CShort((.Channels * .BitsPerSample) \ 8)
                    .AvgBytesPerSec = .BlockAlign * .SamplesPerSec
                    .ExtraDataSize = 0
                End With

                If waveOutOpen(DevHandle, DeviceID, tWFE, pCallback, 0&, CALLBACK_FUNCTION) = MMSYSERR_NOERROR Then

                    GC = GCHandle.Alloc(WaveData, GCHandleType.Pinned)

                    With tWH
                        .lpData = GC.AddrOfPinnedObject
                        .dwBufferLength = NumSamples * 4
                        .dwFlags = 0
                    End With

                    If waveOutPrepareHeader(DevHandle, tWH, Marshal.SizeOf(tWH)) = MMSYSERR_NOERROR Then



                        IsRunning = True

                        If waveOutRestart(DevHandle) = MMSYSERR_NOERROR Then

                            StartPlayback = True

                        End If

                    End If
                End If
            End If

        End Function

        Public Function WriteSamples(ByVal Samples() As Short) As Boolean
            With tWH
                '.lpData = 
                .dwBufferLength = Samples.Length * 2
                .dwFlags = 0
            End With

            Marshal.Copy(tWH.lpData, Samples, 0, Samples.Length)
            waveOutPrepareHeader(DevHandle, tWH, Marshal.SizeOf(tWH))
            waveOutWrite(DevHandle, tWH, Marshal.SizeOf(tWH))
        End Function

    Public Function StopPlayback() As Boolean

        If IsRunning = True Then
            IsRunning = False
            If DevHandle <> IntPtr.Zero Then
                If waveOutReset(DevHandle) = MMSYSERR_NOERROR Then
                    If waveOutPause(DevHandle) = MMSYSERR_NOERROR Then

                        If waveOutUnprepareHeader(DevHandle, tWH,
                            Marshal.SizeOf(tWH)) = MMSYSERR_NOERROR Then

                            If waveOutClose(DevHandle) = MMSYSERR_NOERROR Then

                                DevHandle = IntPtr.Zero
                                GC.Free()
                                StopPlayback = True

                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Function

End Module
