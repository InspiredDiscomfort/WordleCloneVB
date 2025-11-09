Module global_Functions
    Public DarkModeEnabled As Boolean = False

    Public Sub ApplyTheme(form As Form)
        If DarkModeEnabled Then
            form.BackColor = Color.FromArgb(30, 30, 30)
        Else
            form.BackColor = Color.White
        End If

        For Each ctrl As Control In form.Controls
            ApplyThemeToControl(ctrl)
        Next
    End Sub

    Private Sub ApplyThemeToControl(ctrl As Control)
        If TypeOf ctrl Is Label Then
            ctrl.ForeColor = If(DarkModeEnabled, Color.White, Color.Black)

        ElseIf TypeOf ctrl Is Button OrElse TypeOf ctrl Is ComboBox OrElse TypeOf ctrl Is CheckBox Then
            ctrl.BackColor = If(DarkModeEnabled, Color.FromArgb(45, 45, 48), Color.White)
            ctrl.ForeColor = If(DarkModeEnabled, Color.White, Color.Black)
            ctrl.Font = New Font("Segoe UI", 10, FontStyle.Regular)

        ElseIf TypeOf ctrl Is Panel Then
            ctrl.BackColor = If(DarkModeEnabled, Color.FromArgb(30, 30, 30), Color.White)

            ' Recursively apply theme to controls inside the panel
            For Each child As Control In ctrl.Controls
                ApplyThemeToControl(child)
            Next
        End If
    End Sub

End Module
