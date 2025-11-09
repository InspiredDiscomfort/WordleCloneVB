Public Class FormSolve
    Private Sub btn_Ifelse_Click(sender As Object, e As EventArgs) Handles btn_Ifelse.Click
        Dim age1 As Integer
        If txtbx_Input.Text <> "" Then
            age1 = txtbx_Input.Text
            lbl_Result.Text = "Invalid Input, Please Enter a valid input!"
            If age1 <= 12 Then
                lbl_Result.Text = "You're a Child"
            ElseIf age1 <= 19 Then
                lbl_Result.Text = "You're a Teenager"
            ElseIf age1 <= 60 Then
                lbl_Result.Text = "You're an Adult"
            Else
                lbl_Result.Text = "You're a Senior"
            End If
        End If
    End Sub
    Private Sub btn_Case_Click(sender As Object, e As EventArgs) Handles btn_Case.Click
        Dim age1_Again As Integer
        If txtbx_Input.Text <> "" Then
            age1_Again = txtbx_Input.Text
            Select Case age1_Again
                Case 0 To 12
                    lbl_Result.Text = "You're a Child"
                Case 13 To 19
                    lbl_Result.Text = "You're a Teenager"
                Case 20 To 60
                    lbl_Result.Text = "You're an Adult"
                Case Else
                    lbl_Result.Text = "You're a Senior"
            End Select

        End If
    End Sub

    Private Sub FormSolve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class