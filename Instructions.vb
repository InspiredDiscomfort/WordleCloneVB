Imports System.Runtime.InteropServices
Public Class Instructions
    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = &H2
    Private slideTimer As Timer
    Private targetY As Integer
    Private isClosing As Boolean = False

    Private Sub Instructions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterPanel()
        CenterLabels()
        Me.FormBorderStyle = FormBorderStyle.None
        global_Functions.ApplyTheme(Me)
        AddHandler Me.MouseDown, AddressOf FormDrag

        ' Create slide animation timer
        slideTimer = New Timer()
        slideTimer.Interval = 10
        AddHandler slideTimer.Tick, AddressOf SlideAnimation

        ' Set starting position above main form
        Me.StartPosition = FormStartPosition.Manual
        Dim mainMenu = Application.OpenForms("wordleMainMenu")

        If mainMenu IsNot Nothing Then
            Me.Left = mainMenu.Left + (mainMenu.Width - Me.Width) \ 2
            Me.Top = mainMenu.Top - Me.Height ' start above
            targetY = mainMenu.Top + (mainMenu.Height - Me.Height) \ 2 ' center target
        End If

        If DarkModeEnabled Then
            btnExitInstructions.ForeColor = Color.White
            btnExitInstructions.BackColor = Color.Transparent
        Else
            btnExitInstructions.ForeColor = Color.Black
        End If

        btnExitInstructions.FlatStyle = FlatStyle.Flat
        btnExitInstructions.FlatAppearance.BorderSize = 0
        btnExitInstructions.FlatAppearance.MouseOverBackColor = Color.Red
        btnExitInstructions.FlatAppearance.MouseDownBackColor = Color.DarkRed

        ' Start sliding down
        slideTimer.Start()
    End Sub

    Private Sub SlideAnimation(sender As Object, e As EventArgs)
        Dim speed As Integer = 30 ' pixels per tick (faster)

        If Not isClosing Then
            ' Sliding down
            If Me.Top < targetY Then
                Me.Top += speed
            Else
                Me.Top = targetY
                slideTimer.Stop()
            End If
        Else
            ' Sliding up to close
            If Me.Top > targetY - Me.Height - 50 Then
                Me.Top -= speed
            Else
                slideTimer.Stop()
                Me.Close()
            End If
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If Not isClosing Then
            e.Cancel = True
            isClosing = True
            slideTimer.Start()
        End If
    End Sub

    Private Sub Instructions_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterPanel()
        CenterLabels()
    End Sub
    Private Sub CenterPanel()
        Panel2.Left = (Me.ClientSize.Width - Panel2.Width) \ 2
        Panel2.Top = (Me.ClientSize.Height - Panel2.Height) \ 2
    End Sub
    Private Sub CenterLabels()
        ' Center each label horizontally inside Panel1
        Label1.Left = (Panel2.Width - Label1.Width) \ 2
        Label2.Left = (Panel2.Width - Label2.Width) \ 2
        Label3.Left = (Panel2.Width - Label3.Width) \ 2
        Label4.Left = (Panel2.Width - Label4.Width) \ 2

    End Sub

    Private Sub btnExitInstructions_Click(sender As Object, e As EventArgs) Handles btnExitInstructions.Click
        Me.Close()
    End Sub

    Private Sub FormDrag(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
        End If
    End Sub

    ' When mouse enters the button area
    Private Sub btnExitInstructions_MouseEnter(sender As Object, e As EventArgs) Handles btnExitInstructions.MouseEnter
        btnExitInstructions.BackColor = Color.Red
        btnExitInstructions.ForeColor = Color.White
    End Sub

    ' When mouse leaves the button area
    Private Sub btnExitInstructions_MouseLeave(sender As Object, e As EventArgs) Handles btnExitInstructions.MouseLeave
        If DarkModeEnabled Then
            btnExitInstructions.ForeColor = Color.White
            btnExitInstructions.BackColor = Color.Transparent
        Else
            btnExitInstructions.BackColor = Color.Transparent
            btnExitInstructions.ForeColor = Color.Black
        End If
    End Sub
End Class

