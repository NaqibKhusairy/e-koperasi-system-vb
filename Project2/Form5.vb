Public Class Form5


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtName.Text = ""
        txtMatric.Text = ""
        txtFeedback.Text = ""
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If ValidateInput() Then
                EnterData()
            Else
                MessageBox.Show("Please enter all the fields.")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred during the data insertion: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        Return IsPresent(txtName.Text) AndAlso IsPresent(txtMatric.Text) AndAlso IsPresent(txtFeedback.Text)
    End Function

    Private Function IsPresent(ByVal textbox As String) As Boolean
        If String.IsNullOrWhiteSpace(textbox) Then
            MessageBox.Show("Please enter all the fields.", "Wrong Input")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub EnterData()
        con.Open()
        cmd.CommandText = "INSERT INTO Review ([Name], [Matric], [Feedback]) VALUES (@Name, @Matric, @Feedback)"

        cmd.Parameters.Clear() ' Clear any previous parameters

        cmd.Parameters.AddWithValue("@Name", txtName.Text)
        cmd.Parameters.AddWithValue("@Matric", txtMatric.Text)
        cmd.Parameters.AddWithValue("@Feedback", txtFeedback.Text)

        cmd.ExecuteNonQuery()

        MessageBox.Show("Data inserted successfully.")

    End Sub
End Class



