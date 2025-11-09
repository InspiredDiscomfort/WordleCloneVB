<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class wordleMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(wordleMainMenu))
        Me.btn_Start = New System.Windows.Forms.Button()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.Btn_Instructions = New System.Windows.Forms.Button()
        Me.Btn_Exit = New System.Windows.Forms.Button()
        Me.chkDarkMode = New System.Windows.Forms.CheckBox()
        Me.pnlTitleBar = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmbDifficulty = New System.Windows.Forms.ComboBox()
        Me.lblDifficulty = New System.Windows.Forms.Label()
        Me.pnlTitleBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Start
        '
        Me.btn_Start.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Start.Location = New System.Drawing.Point(570, 248)
        Me.btn_Start.Name = "btn_Start"
        Me.btn_Start.Size = New System.Drawing.Size(292, 61)
        Me.btn_Start.TabIndex = 0
        Me.btn_Start.Text = "PLAY"
        Me.btn_Start.UseVisualStyleBackColor = True
        '
        'lbl_Title
        '
        Me.lbl_Title.AutoSize = True
        Me.lbl_Title.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Title.Location = New System.Drawing.Point(637, 9)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(167, 43)
        Me.lbl_Title.TabIndex = 1
        Me.lbl_Title.Text = "GUESSER"
        '
        'Btn_Instructions
        '
        Me.Btn_Instructions.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Instructions.Location = New System.Drawing.Point(570, 315)
        Me.Btn_Instructions.Name = "Btn_Instructions"
        Me.Btn_Instructions.Size = New System.Drawing.Size(292, 61)
        Me.Btn_Instructions.TabIndex = 2
        Me.Btn_Instructions.Text = "INSTRUCTIONS"
        Me.Btn_Instructions.UseVisualStyleBackColor = True
        '
        'Btn_Exit
        '
        Me.Btn_Exit.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Exit.Location = New System.Drawing.Point(570, 382)
        Me.Btn_Exit.Name = "Btn_Exit"
        Me.Btn_Exit.Size = New System.Drawing.Size(292, 61)
        Me.Btn_Exit.TabIndex = 3
        Me.Btn_Exit.Text = "EXIT"
        Me.Btn_Exit.UseVisualStyleBackColor = True
        '
        'chkDarkMode
        '
        Me.chkDarkMode.AutoSize = True
        Me.chkDarkMode.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDarkMode.Location = New System.Drawing.Point(656, 449)
        Me.chkDarkMode.Name = "chkDarkMode"
        Me.chkDarkMode.Size = New System.Drawing.Size(133, 29)
        Me.chkDarkMode.TabIndex = 4
        Me.chkDarkMode.Text = "DARK MODE"
        Me.chkDarkMode.UseVisualStyleBackColor = True
        '
        'pnlTitleBar
        '
        Me.pnlTitleBar.Controls.Add(Me.btnClose)
        Me.pnlTitleBar.Controls.Add(Me.lbl_Title)
        Me.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitleBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitleBar.Name = "pnlTitleBar"
        Me.pnlTitleBar.Size = New System.Drawing.Size(1447, 67)
        Me.pnlTitleBar.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(1369, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 62)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmbDifficulty
        '
        Me.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDifficulty.FormattingEnabled = True
        Me.cmbDifficulty.Items.AddRange(New Object() {"EASY", "MEDIUM", "HARD"})
        Me.cmbDifficulty.Location = New System.Drawing.Point(597, 136)
        Me.cmbDifficulty.Name = "cmbDifficulty"
        Me.cmbDifficulty.Size = New System.Drawing.Size(234, 21)
        Me.cmbDifficulty.TabIndex = 6
        '
        'lblDifficulty
        '
        Me.lblDifficulty.AutoSize = True
        Me.lblDifficulty.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDifficulty.Location = New System.Drawing.Point(591, 92)
        Me.lblDifficulty.Name = "lblDifficulty"
        Me.lblDifficulty.Size = New System.Drawing.Size(240, 31)
        Me.lblDifficulty.TabIndex = 7
        Me.lblDifficulty.Text = "SELECT DIFFICULTY"
        '
        'wordleMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1447, 553)
        Me.Controls.Add(Me.lblDifficulty)
        Me.Controls.Add(Me.cmbDifficulty)
        Me.Controls.Add(Me.pnlTitleBar)
        Me.Controls.Add(Me.chkDarkMode)
        Me.Controls.Add(Me.Btn_Exit)
        Me.Controls.Add(Me.Btn_Instructions)
        Me.Controls.Add(Me.btn_Start)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "wordleMainMenu"
        Me.Text = "wordleMainMenu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTitleBar.ResumeLayout(False)
        Me.pnlTitleBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Start As Button
    Friend WithEvents lbl_Title As Label
    Friend WithEvents Btn_Instructions As Button
    Friend WithEvents Btn_Exit As Button
    Friend WithEvents chkDarkMode As CheckBox
    Friend WithEvents pnlTitleBar As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents cmbDifficulty As ComboBox
    Friend WithEvents lblDifficulty As Label
End Class
