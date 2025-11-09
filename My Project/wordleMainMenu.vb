Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.Media
Public Class wordleMainMenu

    ' Allows dragging the borderless form
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Dim backgroundPlayer As SoundPlayer
    Private moveDirection As Integer = 1 ' 1 = right, -1 = left
    Private moveSpeed As Integer = 1 ' pixels per tick
    Private moveDistance As Integer = 5 ' how far to move from starting point
    Private startX As Integer ' original X position
    Private WithEvents labelMoveTimer As New Timer()
    Private lblHeader As Label
    Private fallingTiles As New List(Of FallingTile)
    Private rnd As New Random()
    Private Class FallingTile
        Public Property Letter As String
        Public Property X As Integer
        Public Property Y As Integer
        Public Property Speed As Integer
        Public Property Color As Brush
    End Class
    Private Sub wordleMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.None
        Me.DoubleBuffered = True
        RoundFormCorners(20)
        SetupTitleBar()
        CenterControls()
        labelMoveTimer.Interval = 20 ' update speed (~50 FPS)
        labelMoveTimer.Start()
        cmbDifficulty.SelectedIndex = 0 ' Default to Easy
        AddHandler btn_Start.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btn_Start.MouseLeave, AddressOf Button_MouseLeave

        AddHandler Btn_Instructions.MouseEnter, AddressOf Button_MouseEnter
        AddHandler Btn_Instructions.MouseLeave, AddressOf Button_MouseLeave

        AddHandler Btn_Exit.MouseEnter, AddressOf Button_MouseEnter
        AddHandler Btn_Exit.MouseLeave, AddressOf Button_MouseLeave
        global_Functions.ApplyTheme(Me)

        Dim musicPath As String = IO.Path.Combine(Application.StartupPath, "pixelSound.wav")

        If Not IO.File.Exists(musicPath) Then
            MessageBox.Show("Music file not found: " & musicPath)
            Return
        End If

        Try
            backgroundPlayer = New SoundPlayer(musicPath)
            backgroundPlayer.PlayLooping()
        Catch ex As Exception
            MessageBox.Show("Error playing music: " & ex.Message)
        End Try

        ' Create starting tiles
        For i As Integer = 1 To 25
            fallingTiles.Add(CreateRandomTile(True))
        Next

        ' Animation timer for tiles
        Dim tileTimer As New Timer()
        tileTimer.Interval = 30 ' ~33 FPS
        AddHandler tileTimer.Tick, AddressOf UpdateFallingTiles
        tileTimer.Start()
    End Sub

    Private Function CreateRandomTile(Optional startRandomY As Boolean = False) As FallingTile
        Dim letters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim colors As Brush() = {Brushes.Green, Brushes.Goldenrod, Brushes.DimGray}

        Dim tile As New FallingTile()
        tile.Letter = letters(rnd.Next(letters.Length))

        ' Prevent invalid random range
        Dim safeWidth As Integer = Math.Max(40, Me.ClientSize.Width)
        tile.X = rnd.Next(0, safeWidth - 40)

        tile.Y = If(startRandomY, rnd.Next(-Me.ClientSize.Height, Me.ClientSize.Height), -40)
        tile.Speed = rnd.Next(2, 6)
        tile.Color = colors(rnd.Next(colors.Length))
        Return tile
    End Function

    Private Sub UpdateFallingTiles(sender As Object, e As EventArgs)
        For i As Integer = 0 To fallingTiles.Count - 1
            fallingTiles(i).Y += fallingTiles(i).Speed
            If fallingTiles(i).Y > Me.ClientSize.Height Then
                fallingTiles(i) = CreateRandomTile()
            End If
        Next
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim font As New Font("Arial", 14, FontStyle.Bold)

        ' Draw each tile
        For Each tile In fallingTiles
            g.FillRectangle(tile.Color, tile.X, tile.Y, 40, 40)
            g.DrawRectangle(Pens.Black, tile.X, tile.Y, 40, 40)

            Dim textSize = g.MeasureString(tile.Letter, font)
            Dim tx = tile.X + (40 - textSize.Width) / 2
            Dim ty = tile.Y + (40 - textSize.Height) / 2
            g.DrawString(tile.Letter, font, Brushes.White, tx, ty)
        Next
    End Sub

    Private Sub Button_MouseEnter(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        btn.BackColor = Color.FromArgb(70, 130, 180) ' SteelBlue
        btn.ForeColor = Color.White
    End Sub

    Private Sub Button_MouseLeave(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)

        ' Restore based on theme
        If DarkModeEnabled Then
            btn.BackColor = Color.FromArgb(45, 45, 48)
            btn.ForeColor = Color.White
        Else
            btn.BackColor = Color.Transparent
            btn.ForeColor = Color.Black
        End If
    End Sub

    Private Sub wordleMainMenu_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterControls()
        RoundFormCorners(20)
    End Sub

    Private Sub CenterControls()
        Dim spacing As Integer = 10
        Dim totalHeight As Integer = lbl_Title.Height + btn_Start.Height + Btn_Instructions.Height + Btn_Exit.Height + chkDarkMode.Height + (spacing * 4)
        Dim startY As Integer = (Me.ClientSize.Height - totalHeight) \ 2

        lbl_Title.Top = startY
        btn_Start.Top = lbl_Title.Bottom + spacing
        Btn_Instructions.Top = btn_Start.Bottom + spacing
        Btn_Exit.Top = Btn_Instructions.Bottom + spacing
        chkDarkMode.Top = Btn_Exit.Bottom + spacing

        For Each ctrl As Control In Me.Controls
            If ctrl IsNot pnlTitleBar Then
                ctrl.Left = (Me.ClientSize.Width - ctrl.Width) \ 2
            End If
        Next
    End Sub



    Private Sub ApplyDarkMode()
        Me.BackgroundImage = Nothing
        Me.BackColor = Color.FromArgb(30, 30, 30)
        pnlTitleBar.BackColor = Color.FromArgb(50, 50, 50)
        lbl_Title.ForeColor = Color.White

        Dim darkBack As Color = Color.FromArgb(45, 45, 48)
        Dim lightText As Color = Color.White

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button OrElse TypeOf ctrl Is CheckBox Then
                ctrl.BackColor = darkBack
                ctrl.ForeColor = lightText
                ctrl.Font = New Font("Arial Narrow", 10, FontStyle.Regular)
            End If
        Next

        For Each ctrl As Control In pnlTitleBar.Controls
            ctrl.ForeColor = lightText
            ctrl.Font = New Font("Arial Narrow", 10, FontStyle.Bold)
        Next
    End Sub

    Private Sub ApplyLightMode()
        Me.BackgroundImage = Nothing
        Me.BackColor = Color.White
        pnlTitleBar.BackColor = Color.LightGray
        lbl_Title.ForeColor = Color.Black

        Dim lightBack As Color = Color.FromArgb(230, 230, 230)
        Dim darkText As Color = Color.Black

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button OrElse TypeOf ctrl Is CheckBox Then
                ctrl.BackColor = lightBack
                ctrl.ForeColor = darkText
                ctrl.Font = New Font("Arial Narrow", 10, FontStyle.Regular)
            End If
        Next

        For Each ctrl As Control In pnlTitleBar.Controls
            ctrl.ForeColor = darkText
            ctrl.Font = New Font("Arial Narrow", 10, FontStyle.Bold)
        Next
    End Sub

    Private Sub chkDarkMode_CheckedChanged(sender As Object, e As EventArgs) Handles chkDarkMode.CheckedChanged
        DarkModeEnabled = chkDarkMode.Checked
        global_Functions.ApplyTheme(Me)
        WordleGame.DarkModeEnabled = chkDarkMode.Checked
    End Sub

    Private Sub Btn_Instructions_Click(sender As Object, e As EventArgs) Handles Btn_Instructions.Click
        Dim instructionsForm As New Instructions()
        instructionsForm.ShowDialog() ' This will block other forms until closed
    End Sub

    Private Sub btn_Start_Click(sender As Object, e As EventArgs) Handles btn_Start.Click
        If cmbDifficulty.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a difficulty.", "Missing Difficulty")
            Return
        End If

        Dim selectedDifficulty As String = cmbDifficulty.SelectedItem.ToString()

        Dim gameForm As New WordleGame()
        gameForm.difficultyLevel = selectedDifficulty
        gameForm.Show()
        Me.Hide()
    End Sub


    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Application.Exit()
    End Sub

    Private Sub pnlTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlTitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &HA1, 2, 0)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub RoundFormCorners(radius As Integer)
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(Me.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(Me.Width - radius, Me.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, Me.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Me.Region = New Region(path)
    End Sub

    Private Sub SetupTitleBar()

        pnlTitleBar.BackColor = Color.FromArgb(50, 50, 50)
        pnlTitleBar.Dock = DockStyle.Top
        pnlTitleBar.Height = 60 ' Taller panel for bigger controls

        ' Label (Title)
        lblHeader = New Label()
        lblHeader.Text = "GUESSER"
        lblHeader.Font = New Font("Arial Narrow", 20, FontStyle.Bold) ' Bigger font
        lblHeader.ForeColor = Color.White
        lblHeader.AutoSize = True
        lblHeader.Location = New Point(20, (pnlTitleBar.Height - lblHeader.Height) \ 2)
        startX = lblHeader.Left ' store original position

        ' --- Minimize Button ---
        Dim btnMin As New Button()
        btnMin.Text = "–"
        btnMin.Font = New Font("Arial Narrow", 20, FontStyle.Bold)
        btnMin.Size = New Size(45, 45)
        btnMin.BackColor = Color.Gray
        btnMin.ForeColor = Color.White
        btnMin.FlatStyle = FlatStyle.Flat
        btnMin.FlatAppearance.BorderSize = 0
        btnMin.Location = New Point(Me.ClientSize.Width - (45 * 3) - 10, (pnlTitleBar.Height - btnMin.Height) \ 2)
        AddHandler btnMin.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnMin.MouseLeave, AddressOf Button_MouseLeave
        AddHandler btnMin.Click, Sub()
                                     Me.WindowState = FormWindowState.Minimized
                                 End Sub

        ' --- Maximize / Restore Button ---
        Dim btnMax As New Button()
        btnMax.Text = "□"
        btnMax.Font = New Font("Arial Narrow", 16, FontStyle.Bold)
        btnMax.Size = New Size(45, 45)
        btnMax.BackColor = Color.Gray
        btnMax.ForeColor = Color.White
        btnMax.FlatStyle = FlatStyle.Flat
        btnMax.FlatAppearance.BorderSize = 0
        btnMax.Location = New Point(Me.ClientSize.Width - (45 * 2) - 10, (pnlTitleBar.Height - btnMax.Height) \ 2)
        AddHandler btnMax.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnMax.MouseLeave, AddressOf Button_MouseLeave
        AddHandler btnMax.Click, Sub()
                                     If Me.WindowState = FormWindowState.Maximized Then
                                         Me.WindowState = FormWindowState.Normal
                                     Else
                                         Me.WindowState = FormWindowState.Maximized
                                     End If
                                 End Sub

        ' Close Button
        Dim btnClose As New Button()
        btnClose.Text = "X"
        btnClose.Font = New Font("Arial Narrow", 20, FontStyle.Bold) ' Bigger font
        btnClose.Size = New Size(45, 45)
        btnClose.BackColor = Color.Red
        btnClose.ForeColor = Color.White
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.Location = New Point(Me.ClientSize.Width - btnClose.Width - 10, (pnlTitleBar.Height - btnClose.Height) \ 2)
        AddHandler btnClose.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnClose.MouseLeave, AddressOf Button_MouseLeave
        AddHandler btnClose.Click, AddressOf Btn_Exit_Click

        ' Reposition close button on resize
        AddHandler Me.Resize, Sub()
                                  btnClose.Left = Me.ClientSize.Width - btnClose.Width - 10
                                  btnMax.Left = Me.ClientSize.Width - (btnMax.Width * 2) - 10
                                  btnMin.Left = Me.ClientSize.Width - (btnMin.Width * 3) - 10
                              End Sub
        pnlTitleBar.Controls.Clear()
        pnlTitleBar.Controls.Add(lblHeader)
        pnlTitleBar.Controls.Add(btnClose)
        pnlTitleBar.Controls.Clear()
        pnlTitleBar.Controls.Add(lblHeader)
        pnlTitleBar.Controls.Add(btnMin)
        pnlTitleBar.Controls.Add(btnMax)
        pnlTitleBar.Controls.Add(btnClose)
    End Sub

    Private Sub labelMoveTimer_Tick(sender As Object, e As EventArgs) Handles labelMoveTimer.Tick
        lblHeader.Left += moveDirection * moveSpeed

        ' Check bounds so label stays fully visible
        If lblHeader.Left <= 0 Then
            lblHeader.Left = 0
            moveDirection = 1
        ElseIf lblHeader.Right >= pnlTitleBar.Width Then
            lblHeader.Left = pnlTitleBar.Width - lblHeader.Width
            moveDirection = -1
        End If

        ' Short-range movement check
        If lblHeader.Left >= startX + moveDistance Then
            moveDirection = -1
        ElseIf lblHeader.Left <= startX - moveDistance Then
            moveDirection = 1
        End If
    End Sub
End Class
