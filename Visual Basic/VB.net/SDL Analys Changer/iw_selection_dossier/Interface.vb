Public Class SdlStudioChanger

    ';;;;;;;;;;;;;;;;;;;;;;;;;;     WRITTEN BY DANIEL ELMNÄS 2015 06-02-15   ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    ';;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;     COPYRIGHT TEKNOTRANS AB     ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;     



    Private Sub BT_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Browse.Click

        ' Set Folder PATH default
        FolderBrowserDialog1.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        ' Show the new folder button
        FolderBrowserDialog1.ShowNewFolderButton = True 'folderdialog button

        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Get the full path to the file that selected by the user.
            Dim mySelFile As String = FolderBrowserDialog1.SelectedPath

            Dim intcount As Integer = Nothing



            ' Displays the full path of the file selected by the user in the box (TextBox)
            Tb_FilePath.Text = mySelFile

            'Displays the folder name (only) selected, the user"Subtlety, use the" IO.Path.GetFileName "on the path to a folder
            'To get the name of the target folder.
            'While "IO.Path.GetDirectoryName" would have shown you the folder path CONTAINING file
            'Targeted by the specified path as a parameter
            'MsgBox("Du har valt: " & IO.Path.GetFileName(mySelFile))


            If Not IO.Directory.GetFiles(mySelFile, "*.xml").Any() Then
                MsgBox("there are no XML files here")
                Application.Restart()
            End If

            For Each filename As String In IO.Directory.GetFiles(mySelFile, "*.xml") 'I define the type of all files the loop go through

                intcount = intcount + 1
                'Here is the counter before save to see how many files are modified

                'Variables I use
                Dim analyse
                Dim exactContexts
                Dim subnode
                Dim repeated
                Dim realRepeated
                Dim tmpValue As String = ""


                ' here are two loops for the nodes in the XML file
                analyse = CreateObject("Msxml2.DOMDocument.6.0")
                analyse.Load(filename)

                exactContexts = analyse.SelectNodes("//inContextExact")

                For i = 0 To exactContexts.Length - 1
                    subnode = exactContexts(i)
                    For Each att In subnode.Attributes
                        If att.Name = "words" Then
                            att.Value = "0"
                            Exit For
                        End If
                    Next att
                Next i

                repeated = analyse.SelectNodes("//crossFileRepeated")

                For i = 0 To repeated.Length - 1
                    subnode = repeated(i)
                    For Each att In subnode.Attributes
                        If att.Name = "words" Then
                            tmpValue = att.Value
                            att.Value = "0"
                            Exit For
                        End If
                    Next att

                    realRepeated = subnode.NextSibling
                    If Not realRepeated Is Nothing Then

                    End If
                    For Each att In realRepeated.Attributes
                        If att.Name = "words" Then
                            att.Value = Val(att.Value) + Val(tmpValue)
                            Exit For
                        End If
                    Next att
                Next i



                analyse.Save(filename) 'Save the analyze file on same path also same name.


            Next

            MsgBox("Modified (" + intcount.ToString + ") XML files") 


        Else

            'if the user has not selected a folder, it is a warning
            MsgBox("No Folder selected", MsgBoxStyle.Exclamation, "No selected folders")
        End If


    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Tb_FilePath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tb_FilePath.TextChanged


    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class