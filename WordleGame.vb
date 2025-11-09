Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class WordleGame
    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function
    Public difficultyLevel As String
    Private timeLeft As Integer = 0
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = &H2
    Private Const Rows As Integer = 6
    Private Const Cols As Integer = 5
    Private letterGrid(Rows - 1, Cols - 1) As Label
    Private targetWord As String
    Private currentRow As Integer = 0
    Private currentCol As Integer = 0
    Private hiddenInput As New TextBox()
    Private gameOver As Boolean = False
    Private totalWins As Integer = 0
    Private totalLosses As Integer = 0
    Private currentStreak As Integer = 0
    Private bestStreak As Integer = 0
    Private guessHistory As New List(Of String)
    Private keyButtons As New Dictionary(Of String, Button)
    Private wordList As New List(Of String)
    Private gridLocked As Boolean

    ' === Falling Wordle Tiles ===
    Private fallingTiles As New List(Of FallingTile)
    Private rnd As New Random()

    Private Class FallingTile
        Public Property Letter As String
        Public Property X As Integer
        Public Property Y As Integer
        Public Property Speed As Integer
        Public Property Color As Brush
    End Class

    Private Sub LoadWordsFromFile()
        Dim wordFilePath As String = IO.Path.Combine(Application.StartupPath, "words.txt")

        If IO.File.Exists(wordFilePath) Then
            wordList = IO.File.ReadAllLines(wordFilePath).ToList()
        Else
            MessageBox.Show("Word list file not found!", "Error")
            Me.Close()
        End If
    End Sub

    Private Sub FormDrag(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub

    Private Sub WordleGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadWordsFromFile()
        Me.KeyPreview = True ' Important: allows the form to catch key presses
        Me.Focus()
        CreateGrid()
        CenterGrid()
        gridLocked = True
        hiddenInput.TabStop = False
        hiddenInput.Visible = False
        Me.Controls.Add(hiddenInput)
        hiddenInput.Focus()
        Dim rand As New Random()
        targetWord = wordList(rand.Next(wordList.Count)).ToUpper()
        Debug.Print("Target Word: " & targetWord)
        Me.ActiveControl = Nothing
        Me.Select()
        Me.BringToFront()
        CreateOnscreenKeyboard()
        Dim btnStats As New Button With {
     .Name = "btnStats",
    .Text = "📊 STATS",
    .Width = 80,
    .Height = 40,
    .Left = 10,
    .Top = 10
}
        AddHandler btnStats.Click, AddressOf ShowStats
        AddHandler btnStats.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnStats.MouseLeave, AddressOf Button_MouseLeave
        Me.Controls.Add(btnStats)

        Dim btnHistory As New Button With {
    .Name = "btnHistory",
    .Text = "📈 HISTORY",
    .Width = 80,
    .Height = 40,
    .Left = 100,
    .Top = 10
}
        AddHandler btnHistory.Click, AddressOf ShowHistory
        AddHandler btnHistory.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnHistory.MouseLeave, AddressOf Button_MouseLeave
        Me.Controls.Add(btnHistory)
        ' Exit Button
        Dim btnExit As New Button With {
    .Name = "btnExit",
    .Text = "❌ EXIT",
    .Width = 80,
    .Height = 40,
    .Top = 10,
    .Left = Me.ClientSize.Width - 90,
    .Anchor = AnchorStyles.Top Or AnchorStyles.Right
}
        AddHandler btnExit.Click, AddressOf ExitGame
        AddHandler btnExit.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnExit.MouseLeave, AddressOf Button_MouseLeave
        Me.Controls.Add(btnExit)
        ' Minimize Button
        Dim btnMinimize As New Button With {
    .Name = "btnMinimize",
    .Text = "➖ MIN",
    .Width = 80,
    .Height = 40,
    .Top = 10,
    .Left = Me.ClientSize.Width - 180, ' 90px left of exit button
    .Anchor = AnchorStyles.Top Or AnchorStyles.Right
}
        AddHandler btnMinimize.Click, Sub(sender2, e2) Me.WindowState = FormWindowState.Minimized
        AddHandler btnMinimize.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnMinimize.MouseLeave, AddressOf Button_MouseLeave
        Me.Controls.Add(btnMinimize)

        ' Maximize Button
        Dim btnMaximize As New Button With {
    .Name = "btnMaximize",
    .Text = "⬜ MAX",
    .Width = 80,
    .Height = 40,
    .Top = 10,
    .Left = Me.ClientSize.Width - 270, ' 90px left of minimize button
    .Anchor = AnchorStyles.Top Or AnchorStyles.Right
}
        AddHandler btnMaximize.Click,
    Sub(sender2, e2)
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub
        AddHandler btnMaximize.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnMaximize.MouseLeave, AddressOf Button_MouseLeave
        Me.Controls.Add(btnMaximize)

        Dim lblGuesserName As New Label With {
    .Text = "👤 GUESSER",
    .AutoSize = True,
    .Font = New Font("Segoe UI", 18, FontStyle.Bold),
    .ForeColor = If(DarkModeEnabled, Color.White, Color.Black),
    .Name = "lblGuesserName",
    .TextAlign = ContentAlignment.MiddleCenter
}

        Dim btnHint As New Button With {
    .Name = "btnHint",
    .Text = "💡 HINT",
    .Width = 80,
    .Height = 40,
    .Top = 10,
    .Left = 190
}
        AddHandler btnHint.Click, AddressOf ShowHint
        AddHandler btnHint.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnHint.MouseLeave, AddressOf Button_MouseLeave
        Me.Controls.Add(btnHint)

        lblGuesserName.Top = 10
        lblGuesserName.Left = (Me.ClientSize.Width - lblGuesserName.Width) \ 2

        Me.Controls.Add(lblGuesserName)

        ApplyTheme()
        AddHandler Me.MouseDown, AddressOf FormDrag
        AddHandler btnNewGame.MouseEnter, AddressOf Button_MouseEnter
        AddHandler btnNewGame.MouseLeave, AddressOf Button_MouseLeave

        Me.FormBorderStyle = FormBorderStyle.None

        Select Case difficultyLevel
            Case "EASY"
                timeLeft = 180 ' 3 minutes
            Case "MEDIUM"
                timeLeft = 60  ' 1 minute
            Case "HARD"
                timeLeft = 30  ' 30 seconds
        End Select

        UpdateTimerLabel()
        gameTimer.Start()

        Me.DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)

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
        Me.Invalidate(New Rectangle(0, 0, Me.ClientSize.Width, Me.ClientSize.Height))
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

    Private Sub UpdateTimerLabel()
        Dim minutes As Integer = timeLeft \ 60
        Dim seconds As Integer = timeLeft Mod 60
        lblTimer.Text = minutes.ToString("D2") & ":" & seconds.ToString("D2")

        ' Adjust ForeColor based on remaining time and theme
        If timeLeft <= 10 Then
            lblTimer.ForeColor = Color.Red
        Else
            If DarkModeEnabled Then
                lblTimer.ForeColor = Color.White
                lblTimer.BackColor = Color.Transparent
            Else
                lblTimer.ForeColor = Color.Black
            End If
        End If


    End Sub

    Private Sub ShowHint(sender As Object, e As EventArgs)
        MessageBox.Show("Hint: The word starts with '" & targetWord(0).ToString().ToUpper() & "'.")
    End Sub

    Private Sub Button_MouseEnter(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)

        Select Case btn.Text
            Case "❌ EXIT"
                btn.BackColor = Color.Red

            Case "📊 STATS"
                btn.BackColor = Color.MediumPurple

            Case "📈 HISTORY"
                btn.BackColor = Color.SteelBlue
            Case "💡 HINT"
                btn.BackColor = Color.Goldenrod
            Case "NEWGAME"
                btn.BackColor = Color.ForestGreen
            Case "➖ MIN"
                btn.BackColor = Color.DarkOrange
            Case "⬜ MAX"
                btn.BackColor = Color.MediumSeaGreen
            Case Else
                btn.BackColor = Color.DarkGray
        End Select

        btn.ForeColor = Color.White
    End Sub

    Private Sub Button_MouseLeave(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)

        If DarkModeEnabled Then
            btn.BackColor = Color.FromArgb(70, 70, 70)
            btn.ForeColor = Color.White
        Else
            btn.BackColor = Color.LightGray
            btn.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ExitGame(sender As Object, e As EventArgs)
        gameTimer.Stop() ' 🔴 Stop the timer
        Me.Hide()
        wordleMainMenu.Show()
    End Sub

    Private Sub ShowHistory(sender As Object, e As EventArgs)
        If guessHistory.Count = 0 Then
            MessageBox.Show("No correct guesses yet!", "Guess History")
        Else
            Dim historyText As String = String.Join(Environment.NewLine, guessHistory)
            MessageBox.Show("Guessed Words:" & vbCrLf & historyText, "Guess History")
        End If
    End Sub

    Private Sub ShowStats(sender As Object, e As EventArgs)
        Dim msg As String = $"🏆 Wins: {totalWins}" & vbCrLf &
                        $"💥 Losses: {totalLosses}" & vbCrLf &
                        $"🔥 Best Streak: {bestStreak}"
        MessageBox.Show(msg, "Game Stats")
    End Sub

    Private Sub CreateOnscreenKeyboard()
        Dim keys As String = "QWERTYUIOPASDFGHJKLZXCVBNM"
        Dim startX As Integer = (Me.ClientSize.Width - (10 * 40 + 9 * 5)) \ 2
        Dim startY As Integer = letterGrid(Rows - 1, 0).Bottom + 30
        Dim x As Integer = startX
        Dim y As Integer = startY
        Dim rowCount As Integer = 0

        For i As Integer = 0 To keys.Length - 1
            Dim btn As New Button()
            btn.Text = keys(i)
            btn.Width = 40
            btn.Height = 40
            btn.Left = x
            btn.Top = y
            AddHandler btn.Click, AddressOf OnscreenKeyClick
            Me.Controls.Add(btn)

            ' Store in dictionary
            keyButtons(btn.Text.ToUpper()) = btn

            x += btn.Width + 5
            rowCount += 1

            If rowCount = 10 OrElse rowCount = 19 Then ' New line after 10 and 9 more
                x = startX + If(rowCount = 19, 20, 0)
                y += 45
            End If
        Next

        ' Add Enter and Backspace
        Dim btnEnter As New Button With {.Text = "Enter", .Width = 80, .Height = 40, .Left = startX, .Top = y + 45}
        AddHandler btnEnter.Click, AddressOf EnterClick
        Me.Controls.Add(btnEnter)
        keyButtons("ENTER") = btnEnter ' Add to dictionary

        Dim btnBack As New Button With {.Text = "←", .Width = 80, .Height = 40, .Left = startX + 320, .Top = y + 45}
        AddHandler btnBack.Click, AddressOf BackspaceClick
        Me.Controls.Add(btnBack)
        keyButtons("BACK") = btnBack ' Add to dictionary
    End Sub

    Private Sub OnscreenKeyClick(sender As Object, e As EventArgs)
        If gameOver Then Return
        Dim btn As Button = CType(sender, Button)
        Dim key As String = btn.Text

        If currentCol < 5 Then
            letterGrid(currentRow, currentCol).Text = key
            currentCol += 1
        End If

        ' 🔁 Use shared highlight logic
        HighlightKeyButton(key, Color.DodgerBlue)
    End Sub

    Private Sub BackspaceClick(sender As Object, e As EventArgs)
        If gameOver Then Return
        If currentCol > 0 Then
            currentCol -= 1
            letterGrid(currentRow, currentCol).Text = ""
            ' 🔵 Trigger highlight effect
            HighlightKeyButton("BACK", Color.OrangeRed)
        End If
    End Sub

    Private Sub EnterClick(sender As Object, e As EventArgs)
        If gameOver Then Return
        If currentCol = 5 Then
            CheckGuess()
        End If
        ' 🟢 Trigger highlight effect
        HighlightKeyButton("ENTER", Color.SeaGreen)
    End Sub


    Private Sub CreateGrid()
        Dim boxSize As Integer = 60
        Dim spacing As Integer = 8
        Dim startY As Integer = 150
        For row As Integer = 0 To Rows - 1
            For col As Integer = 0 To Cols - 1
                Dim lbl As New Label()
                lbl.Width = boxSize
                lbl.Height = boxSize
                lbl.BorderStyle = BorderStyle.FixedSingle
                lbl.TextAlign = ContentAlignment.MiddleCenter
                lbl.Font = New Font("Segoe UI", 20, FontStyle.Bold)
                lbl.BackColor = Color.White
                lbl.ForeColor = Color.Black
                letterGrid(row, col) = lbl
                Me.Controls.Add(lbl)
            Next
        Next
        If btnNewGame IsNot Nothing Then
            btnNewGame.Width = 120
            btnNewGame.Height = 40
            btnNewGame.Left = (Me.ClientSize.Width - btnNewGame.Width) \ 2
            btnNewGame.Top = startY - btnNewGame.Height - 10 ' 10 pixels above grid
            btnNewGame.BringToFront()
        End If
    End Sub

    Private Sub CenterGrid()
        Dim boxSize As Integer = 60
        Dim spacing As Integer = 8
        Dim totalWidth As Integer = Cols * boxSize + (Cols - 1) * spacing

        ' Keep vertical position fixed
        Dim startX As Integer = (Me.ClientSize.Width - totalWidth) \ 2
        Dim startY As Integer = 150 ' Fixed Y position instead of centering vertically

        For row As Integer = 0 To Rows - 1
            For col As Integer = 0 To Cols - 1
                Dim lbl = letterGrid(row, col)
                If lbl IsNot Nothing Then
                    lbl.Left = startX + col * (boxSize + spacing)
                    lbl.Top = startY + row * (boxSize + spacing)
                End If
            Next
        Next
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Block Tab and Space key completely
        If keyData = Keys.Tab OrElse keyData = Keys.Space Then
            Return True
        End If


        If gameOver Then Return True
        Debug.Print("Key Pressed: " & keyData.ToString())

        Dim keyChar As String = keyData.ToString().ToUpper()

        ' A-Z
        If keyData >= Keys.A AndAlso keyData <= Keys.Z Then
            If currentCol < 5 Then
                letterGrid(currentRow, currentCol).Text = keyData.ToString()
                currentCol += 1
            End If

            HighlightKeyButton(keyChar, Color.DodgerBlue)

            Return True

        ElseIf keyData = Keys.Back Then
            If currentCol > 0 Then
                currentCol -= 1
                letterGrid(currentRow, currentCol).Text = ""
            End If

            HighlightKeyButton("BACK", Color.OrangeRed)


            Return True

        ElseIf keyData = Keys.Enter Then
            If currentCol = 5 Then
                CheckGuess()
            End If

            HighlightKeyButton("ENTER", Color.SeaGreen)

            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub HighlightKeyButton(key As String, highlightColor As Color)
        If keyButtons.ContainsKey(key) Then
            Dim btn = keyButtons(key)

            ' Save the permanent color (if any)
            Dim restoreColor As Color
            Dim restoreForeColor As Color = If(DarkModeEnabled, Color.White, Color.Black)

            If keyPermanentColors.ContainsKey(key) Then
                restoreColor = keyPermanentColors(key)
                restoreForeColor = Color.White
            Else
                restoreColor = If(DarkModeEnabled, Color.FromArgb(70, 70, 70), Color.LightGray)
            End If

            ' Temporary highlight
            btn.BackColor = highlightColor
            btn.ForeColor = Color.White

            Dim tempTimer As New Timer()
            AddHandler tempTimer.Tick,
                Sub()
                    btn.BackColor = restoreColor
                    btn.ForeColor = restoreForeColor
                    tempTimer.Stop()
                    tempTimer.Dispose()
                End Sub
            tempTimer.Interval = 150
            tempTimer.Start()
        End If
    End Sub


    Private keyPermanentColors As New Dictionary(Of String, Color)

    Private Sub UpdateKeyboardKeyColor(letter As String, newColor As Color)
        If keyButtons.ContainsKey(letter) Then
            Dim btn = keyButtons(letter)

            ' Priority: Green > Yellow > Gray
            If keyPermanentColors.ContainsKey(letter) Then
                If keyPermanentColors(letter) = Color.Green Then Return
                If keyPermanentColors(letter) = Color.Goldenrod AndAlso newColor = Color.DimGray Then Return
            End If

            ' Save permanent color
            keyPermanentColors(letter) = newColor
            btn.BackColor = newColor
            btn.ForeColor = Color.White
        End If
    End Sub

    Private Sub CheckGuess()
        Dim guess As String = ""
        For i As Integer = 0 To 4
            guess &= letterGrid(currentRow, i).Text.ToUpper()
        Next


        Dim resultColors(4) As Color
        Dim resultTextColors(4) As Color
        Dim targetLetters As Char() = targetWord.ToCharArray()
        Dim guessLetters As Char() = guess.ToCharArray()
        Dim letterUsed(4) As Boolean


        ' First pass: check for correct letters in correct position (green)
        For i As Integer = 0 To 4
            If guessLetters(i) = targetLetters(i) Then
                resultColors(i) = Color.Green
                resultTextColors(i) = Color.White
                letterUsed(i) = True
                guessLetters(i) = "*"c ' mark as matched
            End If
        Next

        ' Second pass: check for correct letters in wrong position (yellow)
        For i As Integer = 0 To 4
            If resultColors(i) = Color.Empty Then
                For j As Integer = 0 To 4
                    If Not letterUsed(j) AndAlso guessLetters(i) = targetLetters(j) Then
                        resultColors(i) = Color.Goldenrod
                        resultTextColors(i) = Color.White
                        letterUsed(j) = True
                        Exit For
                    End If
                Next
            End If
        Next

        ' Default to gray if no color was set
        For i As Integer = 0 To 4
            If resultColors(i) = Color.Empty Then
                resultColors(i) = Color.DimGray
                resultTextColors(i) = Color.White
            End If

            Dim lbl As Label = letterGrid(currentRow, i)
            lbl.BackColor = resultColors(i)
            lbl.ForeColor = resultTextColors(i)

            ' 🔑 Update the onscreen keyboard
            Dim guessedLetter As String = lbl.Text.ToUpper()
            UpdateKeyboardKeyColor(guessedLetter, resultColors(i))
        Next

        ' Check win or continue
        If guess = targetWord Then
            gameTimer.Stop()
            guessHistory.Add(targetWord)
            MessageBox.Show("You guessed it!")
            totalWins += 1
            currentStreak += 1
            If currentStreak > bestStreak Then bestStreak = currentStreak
            gameOver = True
            DisableKeyboardButtons()
        Else
            currentRow += 1
            currentCol = 0
            If currentRow = Rows Then
                gameTimer.Stop() ' 🛑 Stop the timer when all attempts are use
                MessageBox.Show("Out of attempts! The word was: " & targetWord)
                totalLosses += 1
                currentStreak = 0
                gameOver = True
                DisableKeyboardButtons()
            End If
        End If

        ' Store the current row before it is incremented
        Dim thisRow As Integer = currentRow

        ' Update onscreen key colors
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Text.Length = 1 Then
                For i As Integer = 0 To 4
                    If thisRow >= 0 AndAlso thisRow < Rows AndAlso i >= 0 AndAlso i < Cols Then
                        If ctrl.Text = letterGrid(thisRow, i).Text Then
                            ' Your existing color update code here
                        End If
                    End If
                Next
            End If
        Next


    End Sub

    Private Sub DisableKeyboardButtons()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                ' Skip utility buttons that should always work
                If ctrl.Name <> "btnNewGame" AndAlso
               ctrl.Name <> "btnHint" AndAlso
               ctrl.Name <> "btnStats" AndAlso
               ctrl.Name <> "btnMaximize" AndAlso
               ctrl.Name <> "btnMinimize" AndAlso
               ctrl.Name <> "btnHistory" AndAlso
               ctrl.Name <> "btnExit" Then
                    ctrl.Enabled = False
                End If
            End If
        Next
    End Sub

    Private Sub WordleGame_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Not gridLocked Then CenterGrid()
    End Sub

    ' Dark mode support
    Public Shared Property DarkModeEnabled As Boolean = False

    Public Sub ApplyTheme()
        If DarkModeEnabled Then
            Me.BackColor = Color.FromArgb(30, 30, 30)
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Label Then
                    If ctrl.Name = "lblGuesserName" Then
                        ctrl.ForeColor = If(DarkModeEnabled, Color.White, Color.Black)
                        ctrl.BackColor = Color.Transparent
                    Else
                        ctrl.ForeColor = If(DarkModeEnabled, Color.White, Color.Black)
                        ctrl.BackColor = If(DarkModeEnabled, Color.FromArgb(50, 50, 50), Color.White)
                    End If

                ElseIf TypeOf ctrl Is Button Then
                    ctrl.BackColor = Color.FromArgb(70, 70, 70)
                    ctrl.ForeColor = Color.White
                End If
            Next
        Else
            Me.BackColor = Color.White
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Label Then
                    ctrl.ForeColor = Color.Black
                    ctrl.BackColor = Color.White
                ElseIf TypeOf ctrl Is Button Then
                    ctrl.BackColor = Color.LightGray
                    ctrl.ForeColor = Color.Black
                End If
            Next
        End If

        ' Keep guesser name centered
        For Each ctrl As Control In Me.Controls
            If ctrl.Name = "lblGuesserName" Then
                ctrl.Left = (Me.ClientSize.Width - ctrl.Width) \ 2
            End If
        Next
    End Sub

    Private Sub ResetKeyboardColors()
        keyPermanentColors.Clear()

        For Each kvp In keyButtons
            Dim btn = kvp.Value
            If DarkModeEnabled Then
                btn.BackColor = Color.FromArgb(70, 70, 70) ' dark gray
                btn.ForeColor = Color.White
            Else
                btn.BackColor = Color.LightGray
                btn.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        StartNewGame()
        ' reset keyboard
        ResetKeyboardColors()
    End Sub

    Private Sub StartNewGame()
        ' Reset game state
        gameOver = False
        currentRow = 0
        currentCol = 0

        ' Pick a new random target word
        Dim rand As New Random()
        targetWord = wordList(rand.Next(wordList.Count)).ToUpper()
        Debug.Print("New Target Word: " & targetWord)

        ' Clear the grid
        For row As Integer = 0 To Rows - 1
            For col As Integer = 0 To Cols - 1
                Dim lbl As Label = letterGrid(row, col)
                lbl.Text = ""
                lbl.BackColor = If(DarkModeEnabled, Color.FromArgb(50, 50, 50), Color.White)
                lbl.ForeColor = If(DarkModeEnabled, Color.White, Color.Black)
            Next
        Next

        ' Re-enable all keyboard buttons
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                ctrl.Enabled = True
            End If
        Next

        ' Reset timeLeft based on difficulty level
        Select Case difficultyLevel
            Case "EASY"
                timeLeft = 180 ' 3 minutes
            Case "MEDIUM"
                timeLeft = 60  ' 1 minute
            Case "HARD"
                timeLeft = 30  ' 30 seconds
        End Select

        UpdateTimerLabel()
        gameTimer.Start()

    End Sub

    Private Sub gameTimer_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick
        If timeLeft > 0 Then
            timeLeft -= 1
            UpdateTimerLabel()
        Else
            gameTimer.Stop()
            MessageBox.Show("Time's up! The correct word was: " & targetWord)

            ' 🟥 Mark as loss
            totalLosses += 1
            currentStreak = 0

            ' Stop all input
            gameOver = True
            DisableKeyboardButtons()
        End If
    End Sub
End Class
