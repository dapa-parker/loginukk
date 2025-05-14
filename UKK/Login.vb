Imports System.Data.Odbc
Public Class Login1

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        TextBox2.MaxLength = 100
        If e.KeyChar = Chr(13) Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        TextBox1.MaxLength = 100
        If e.KeyChar = Chr(13) Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        TextBox2.UseSystemPasswordChar = False
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        TextBox2.UseSystemPasswordChar = True
    End Sub
    Dim Peringatan As String

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Data harus diisi !", MsgBoxStyle.Critical, "PERINGATAN")
            TextBox1.Focus()
            Exit Sub
        End If
        Call openconnection()
        cmd = New OdbcCommand("select * from usernew where username='" & "' and password='" & TextBox2.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            'protect
            Me.Visible = False
            Menu_Utama.Show()
                'tidak bisa akses Application
            End If
            'login 3 kali kesempatan
            Peringatan = Peringatan + 1
            MsgBox("Login Gagal")
            TextBox2.Focus()
            If Peringatan > 2 Then
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
                MsgBox("Percobaan Login Telah Gagal lebih dari 2 kali, silakan coba lagi", MsgBoxStyle.Critical)
                End
            End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Call User.ShowDialog()
    End Sub
End Class