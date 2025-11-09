<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Instructions
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblHard = New System.Windows.Forms.Label()
        Me.lblMedium = New System.Windows.Forms.Label()
        Me.lblEasy = New System.Windows.Forms.Label()
        Me.lblPressEnter = New System.Windows.Forms.Label()
        Me.btnExitInstructions = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(471, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GUESS THE 5 LETTER WORD IN 6 TRIES."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(568, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "GREEN: CORRECT LETTER AND CORRECT PLACE."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(560, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "YELLOW: CORRECT LETTER BUT WRONG PLACE."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(75, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(525, 31)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "GRAY: WRONG LETTER OR NOT IN THE WORD."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblHard)
        Me.Panel2.Controls.Add(Me.lblMedium)
        Me.Panel2.Controls.Add(Me.lblEasy)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblPressEnter)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(382, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(655, 429)
        Me.Panel2.TabIndex = 4
        '
        'lblHard
        '
        Me.lblHard.AutoSize = True
        Me.lblHard.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHard.Location = New System.Drawing.Point(144, 371)
        Me.lblHard.Name = "lblHard"
        Me.lblHard.Size = New System.Drawing.Size(368, 31)
        Me.lblHard.TabIndex = 6
        Me.lblHard.Text = "HARD DIFFICULTY: 30 SECONDS"
        '
        'lblMedium
        '
        Me.lblMedium.AutoSize = True
        Me.lblMedium.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedium.Location = New System.Drawing.Point(144, 331)
        Me.lblMedium.Name = "lblMedium"
        Me.lblMedium.Size = New System.Drawing.Size(356, 31)
        Me.lblMedium.TabIndex = 5
        Me.lblMedium.Text = "MEDIUM DIFFICULTY: 1 MINUTE"
        '
        'lblEasy
        '
        Me.lblEasy.AutoSize = True
        Me.lblEasy.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEasy.Location = New System.Drawing.Point(157, 284)
        Me.lblEasy.Name = "lblEasy"
        Me.lblEasy.Size = New System.Drawing.Size(343, 31)
        Me.lblEasy.TabIndex = 4
        Me.lblEasy.Text = "EASY DIFFICULTY: 3 MINUTES"
        '
        'lblPressEnter
        '
        Me.lblPressEnter.AutoSize = True
        Me.lblPressEnter.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressEnter.Location = New System.Drawing.Point(118, 236)
        Me.lblPressEnter.Name = "lblPressEnter"
        Me.lblPressEnter.Size = New System.Drawing.Size(427, 31)
        Me.lblPressEnter.TabIndex = 3
        Me.lblPressEnter.Text = "PRESS ENTER TO CHECK THE WORD."
        '
        'btnExitInstructions
        '
        Me.btnExitInstructions.Location = New System.Drawing.Point(1329, 12)
        Me.btnExitInstructions.Name = "btnExitInstructions"
        Me.btnExitInstructions.Size = New System.Drawing.Size(75, 52)
        Me.btnExitInstructions.TabIndex = 5
        Me.btnExitInstructions.Text = "X"
        Me.btnExitInstructions.UseVisualStyleBackColor = True
        '
        'Instructions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1416, 471)
        Me.Controls.Add(Me.btnExitInstructions)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Instructions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormInstructions"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnExitInstructions As Button
    Friend WithEvents lblHard As Label
    Friend WithEvents lblMedium As Label
    Friend WithEvents lblEasy As Label
    Friend WithEvents lblPressEnter As Label
End Class
