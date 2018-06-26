Imports System.Data
Imports System.Data.SqlClient

Public Class SQLControl

    Private SQLCon As New SqlConnection("Data Source=TTDEV\TEKNOTRANS_DEV;Initial Catalog=Teknotrans_dev;Integrated Security=True")
    Private SQLCmd As SqlCommand

    ' SQL DATA
    Public SQLDA As SqlDataAdapter
    Public SQLDS As DataSet

    ' QUERY PARAMETER
    Public Params As New List(Of SqlParameter)

    'QUERY STATISTICS
    Public RecordCount As Integer
    Public Exception As String

    Public Sub ExecQuery(ByVal Query As String)

        Try
            'CREATE SQL COMMAND
            SQLCmd = New SqlCommand(Query, SQLCon)

            ' LOAD PARAMETERS INTO SQL COMMAND

            Params.ForEach(Sub(x) SQLCmd.Parameters.Add(x))

            ' CLEAR PARAMETER LIST
            Params.Clear()

            'EXECUTE COMMAND FILL DATASET
            SQLDS = New DataSet
            SQLDA = New SqlDataAdapter(SQLCmd)
            RecordCount = SQLDA.Fill(SQLDS)

            SQLCon.Close()

        Catch ex As Exception

            Exception = ex.Message
        End Try

        'MAKE SURE THE CONNECTION IS CLOSED

        If SQLCon.State = ConnectionState.Open Then SQLCon.Close()

    End Sub
    Public Sub AddParam(ByVal name As String, ByVal value As Object)
        Dim NewParam As New SqlParameter(name, value)
        Params.Add(NewParam)
    End Sub

End Class
