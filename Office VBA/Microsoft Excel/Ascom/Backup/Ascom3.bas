Attribute VB_Name = "Ascom"
Sub myyear()
'This function removes the 6 last characters from the word and then replace with the first 4 characters.Sheets("Volvo_Statistik").Activate

        

 Dim i As Long
 
 For i = 2 To ActiveSheet.UsedRange.SpecialCells(xlCellTypeLastCell).Row
 
 

 columnD = Cells(i, 4).Value
 
 'MsgBox columnD
 
 

If (columnD = Cells(i, 4).Value) <> "" Then

'MsgBox columnD


 EngCol = Len(Cells.Item(i, "K").Text)

If columnD > EngCol Then


mystringtwo = Cells.Item(i, "K").Value

Cells.Item(i, "K").Interior.ColorIndex = 4

'MsgBox "mindre"

Else


Cells.Item(i, "K").Interior.ColorIndex = 3


'MsgBox "det �r mer"

End If



End If

 


 Next i
   
   
  
   
   
    
End Sub



Sub checkcells()
    Dim ws1 As Worksheet
    Dim ws2 As Worksheet
    Dim r As Long
    Dim m As Long
    Dim s As Long
    Dim n As Long

    Set ws1 = Worksheets("Volvo_Statistik")
    m = ws1.Range("A" & ws1.Rows.Count).End(xlUp).Row
    
    Set ws2 = Worksheets("volvo_NewPrices")
    n = ws2.Range("A" & ws2.Rows.Count).End(xlUp).Row
    
    For r = 1 To m
        For s = 1 To n
          '  If Trim(ws1.Range("H" & r) & ws1.Range("I" & r)) = Trim(ws2.Range("A" & s) & ws2.Range("B" & s)) Then
                        
                  '  MsgBox "Cells " & "A" & r & " " & "B" & r & " on Sheet1 contain " & ws1.Range("A" & r) & " " & ws1.Range("B" & r) & " which matches A" & s & " " & "B" & s & " on Sheet2"
                            
''                    Sheets("Volvo_Statistik").Activate
'                     Range("J" & r).Select
'                     MsgBox ws1.Range("K" & r).Value
'
'                     Sheets("volvo_NewPrices").Activate
'                     Range("F" & s).Select
'                     MsgBox ws2.Range("F" & s).Value
                    
               '   ws1.Range("P" & r).Value = Val(ws1.Range("L" & r)) * Val(ws2.Range("D" & s))
                        
                 
            End If
        Next s
    Next r
End Sub


Sub MaxLength()










End Sub
