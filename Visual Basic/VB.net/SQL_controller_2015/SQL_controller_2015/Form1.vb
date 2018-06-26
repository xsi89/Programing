Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class Form1
    ' Dim SQL As New SQLControl




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If SQL.HasConnection = True Then
        '    ''    MsgBox("Successfully connected!")

        '    ''    '   SQL.RunQuery("SELECT TOP (100) [t0].[Id], [t0].[IdAnonymous], [t0].[Name], [t0].[Address1], [t0].[Address2], [t0].[PostalCode], [t0].[City], [t0].[Country], [t0].[Phone], [t0].[Fax], [t0].[Email], [t0].[Web], [t0].[VAT], [t0].[Agreement], [t0].[AgreementEndDate], [t0].[TradosTM], [t0].[PathRefMaterial], [t0].[PaymentTerms], [t0].[Owner], [t0].[CreationDate], [t0].[PriceListName], [t0].[Currency], [t0].[IsActive], [t0].[LogoBlob] FROM [CompanyMain] AS [t0]")

        '    ''    Dim cmd As New SqlCommand("SELECT username, WindowsLogin FROM users WHERE username='user'", con)
        '    ''    con.Open()






        '    SQL.SQLCmd("SELECT username, WindowsLogin FROM users WHERE username='user'", SQL.SQLCon)




        'End If




        Public sqlconnection1 As New SqlConnection With {.ConnectionString = "Server =TTDEV\Teknotrans_DEV;Initial Catalog=Teknotrans_dev;Integrated Security=SSPI;"}
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader

        cmd.CommandText = "SELECT * FROM Customers"
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()

        reader = cmd.ExecuteReader()
        ' Data is accessible through the DataReader object here.

        sqlConnection1.Close()





    End Sub
End Class
