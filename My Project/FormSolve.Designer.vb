<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolve
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
        Me.txtbx_Input = New System.Windows.Forms.TextBox()
        Me.btn_Ifelse = New System.Windows.Forms.Button()
        Me.btn_Case = New System.Windows.Forms.Button()
        Me.lbl_Result = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtbx_Input
        '
        Me.txtbx_Input.Location = New System.Drawing.Point(357, 157)
        Me.txtbx_Input.Name = "txtbx_Input"
        Me.txtbx_Input.Size = New System.Drawing.Size(100, 20)
        Me.txtbx_Input.TabIndex = 0
        '
        'btn_Ifelse
        '
        Me.btn_Ifelse.Location = New System.Drawing.Point(357, 183)
        Me.btn_Ifelse.Name = "btn_Ifelse"
        Me.btn_Ifelse.Size = New System.Drawing.Size(100, 23)
        Me.btn_Ifelse.TabIndex = 1
        Me.btn_Ifelse.Text = "Result(IfElse)"
        Me.btn_Ifelse.UseVisualStyleBackColor = True
        '
        'btn_Case
        '
        Me.btn_Case.Location = New System.Drawing.Point(357, 212)
        Me.btn_Case.Name = "btn_Case"
        Me.btn_Case.Size = New System.Drawing.Size(100, 23)
        Me.btn_Case.TabIndex = 2
        Me.btn_Case.Text = "Result(Case)"
        Me.btn_Case.UseVisualStyleBackColor = True
        '
        'lbl_Result
        '
        Me.lbl_Result.AutoSize = True
        Me.lbl_Result.Location = New System.Drawing.Point(363, 238)
        Me.lbl_Result.Name = "lbl_Result"
        Me.lbl_Result.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Result.TabIndex = 3
        Me.lbl_Result.Text = "?"
        '
        'FormSolve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(787, 477)
        Me.Controls.Add(Me.lbl_Result)
        Me.Controls.Add(Me.btn_Case)
        Me.Controls.Add(Me.btn_Ifelse)
        Me.Controls.Add(Me.txtbx_Input)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Name = "FormSolve"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormSolve"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtbx_Input As TextBox
    Friend WithEvents btn_Ifelse As Button
    Friend WithEvents btn_Case As Button
    Friend WithEvents lbl_Result As Label
End Class
