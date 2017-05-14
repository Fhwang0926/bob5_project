Imports System.Data.OleDb

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Try
            ExcelTest(TextBox1.Text)
        Catch
        End Try
    End Sub
    Private Sub ExcelTest(ren_tmp As String)
        ' OLEDB를 이용한 엑셀 연결
        ' Excel 97-2003 .xls
        ' string szConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\x\test.xls;Extended Properties='Excel 8.0;HDR=No'";

        ' Excel 2007 이후 .xlsx
        Dim szConn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ren_tmp & ";Extended Properties='Excel 8.0;HDR=No'"

        Dim conn As New OleDbConnection(szConn)
        conn.Open()

        ' 엑셀로부터 데이타 읽기
        Dim cmd As New OleDbCommand("SELECT * FROM [" & conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("Table_Name").ToString() & "]", conn)
        Dim adpt As New OleDbDataAdapter(cmd)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        ' For Each Columns As DataRow In ds.Tables(0).Columns



        For Each Rows As DataRow In ds.Tables(0).Rows
            'Dim data As String = String.Format("F1:{0}, F2:{1}, F3:{2}", Rows(0), Rows(1), Rows(2))

            Dim in_tmp As Integer = 0
            Do While True
                Try
                    RichTextBox1.Text = RichTextBox1.Text & Rows(in_tmp).ToString
                    in_tmp += 1
                Catch
                    Exit Do
                End Try
            Loop

        Next

        ' Next

        conn.Close()
    End Sub

    Private Function GetExcelSheetNames(excelFile As String) As [String]()
        Dim objConn As OleDbConnection = Nothing
        Dim dt As System.Data.DataTable = Nothing

        Try
            ' Connection String. Change the excel file to the file you
            ' will search.
            Dim connString As [String] = (Convert.ToString("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=") & excelFile) + ";Extended Properties=Excel 8.0;"
            ' Create connection object by using the preceding connection string.
            objConn = New OleDbConnection(connString)
            ' Open connection with the database.
            objConn.Open()
            ' Get the data table containg the schema guid.
            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            If dt Is Nothing Then
                Return Nothing
            End If

            Dim excelSheets As [String]() = New [String](dt.Rows.Count - 1) {}
            Dim i As Integer = 0

            ' Add the sheet name to the string array.
            For Each row As DataRow In dt.Rows
                excelSheets(i) = row("TABLE_NAME").ToString()
                i += 1
            Next

            ' Loop through all of the sheets if you want too...
            ' Query each excel sheet.
            For j As Integer = 0 To excelSheets.Length - 1
            Next

            Return excelSheets
        Catch ex As Exception
            Return Nothing
        Finally
            ' Clean up.
            If objConn IsNot Nothing Then
                objConn.Close()
                objConn.Dispose()
            End If
            If dt IsNot Nothing Then
                dt.Dispose()
            End If
        End Try
    End Function


End Class
