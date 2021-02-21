Imports System.Data
Imports System.Data.OleDb
Public Class frmlogin
    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\visualbasic\cafePOS\posdatabase.accdb;Persist Security Info=True")
    Dim cmd As OleDbCommand
    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Me.Hide()
        Dim sql = "SELECT username ,password FROM StaffTBL WHERE username='" & txtusername.Text & "' AND password='" & txtpassword.Text & "'"
        cmd = New OleDbCommand(sql, conn)
        conn.Open()
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        Try
            If dr.Read = False Then
                MessageBox.Show("Login failed...")
                Me.Show()
            Else
                MessageBox.Show("Login Successfully...")
                Dim frmDialogue As New frmmain
                frmDialogue.ShowDialog()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
End Class