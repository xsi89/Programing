'' ''Imports System.Data.Sql
'' ''Imports System.Data.SqlClient


'' ''Public Class SQLControl

'' ''     Public SQLCon As New SqlConnection With {.ConnectionString = "Server=TTDEV\TEKNOTRANS_DEV;Database=Teknotrans_Dev;User=tt\Daniel.elmnas;pwd=Dan.tt2;"}

'' ''    Public SQLCon As New SqlConnection With {.ConnectionString = "Server =TTDEV\Teknotrans_DEV;Initial Catalog=Teknotrans_dev;Integrated Security=SSPI;"}
'' ''    Public SQLCmd As SqlCommand
'' ''    Public Function HasConnection() As Boolean

'' ''        Try
'' ''            SQLCon.Open()




'' ''            SQLCon.Close()
'' ''            Return True
'' ''        Catch ex As Exception
'' ''            MsgBox(ex.Message)
'' ''            Return False
'' ''        End Try
'' ''    End Function
'' ''End Class

