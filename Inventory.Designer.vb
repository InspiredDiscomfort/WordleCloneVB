<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventory
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
        Me.cmbProduct = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpbxItems = New System.Windows.Forms.GroupBox()
        Me.nudDrinks = New System.Windows.Forms.NumericUpDown()
        Me.nudRice = New System.Windows.Forms.NumericUpDown()
        Me.nudPork = New System.Windows.Forms.NumericUpDown()
        Me.nudBeef = New System.Windows.Forms.NumericUpDown()
        Me.nudChicken = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpbxStatus = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.nudAmount = New System.Windows.Forms.NumericUpDown()
        Me.grpbxItems.SuspendLayout()
        CType(Me.nudDrinks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBeef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudChicken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbxStatus.SuspendLayout()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbProduct
        '
        Me.cmbProduct.FormattingEnabled = True
        Me.cmbProduct.Items.AddRange(New Object() {"Chicken", "Beef", "Pork", "Rice", "Drinks"})
        Me.cmbProduct.Location = New System.Drawing.Point(821, 215)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(156, 21)
        Me.cmbProduct.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(821, 268)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(82, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(902, 268)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(771, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Product"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(771, 244)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Amount"
        '
        'grpbxItems
        '
        Me.grpbxItems.Controls.Add(Me.nudDrinks)
        Me.grpbxItems.Controls.Add(Me.nudRice)
        Me.grpbxItems.Controls.Add(Me.nudPork)
        Me.grpbxItems.Controls.Add(Me.nudBeef)
        Me.grpbxItems.Controls.Add(Me.nudChicken)
        Me.grpbxItems.Controls.Add(Me.Label7)
        Me.grpbxItems.Controls.Add(Me.Label6)
        Me.grpbxItems.Controls.Add(Me.Label5)
        Me.grpbxItems.Controls.Add(Me.Label4)
        Me.grpbxItems.Controls.Add(Me.Label3)
        Me.grpbxItems.Location = New System.Drawing.Point(166, 96)
        Me.grpbxItems.Name = "grpbxItems"
        Me.grpbxItems.Size = New System.Drawing.Size(289, 244)
        Me.grpbxItems.TabIndex = 11
        Me.grpbxItems.TabStop = False
        Me.grpbxItems.Text = "Items"
        '
        'nudDrinks
        '
        Me.nudDrinks.Location = New System.Drawing.Point(123, 141)
        Me.nudDrinks.Name = "nudDrinks"
        Me.nudDrinks.Size = New System.Drawing.Size(120, 20)
        Me.nudDrinks.TabIndex = 14
        '
        'nudRice
        '
        Me.nudRice.Location = New System.Drawing.Point(123, 115)
        Me.nudRice.Name = "nudRice"
        Me.nudRice.Size = New System.Drawing.Size(120, 20)
        Me.nudRice.TabIndex = 14
        '
        'nudPork
        '
        Me.nudPork.Location = New System.Drawing.Point(123, 92)
        Me.nudPork.Name = "nudPork"
        Me.nudPork.Size = New System.Drawing.Size(120, 20)
        Me.nudPork.TabIndex = 14
        '
        'nudBeef
        '
        Me.nudBeef.Location = New System.Drawing.Point(123, 66)
        Me.nudBeef.Name = "nudBeef"
        Me.nudBeef.Size = New System.Drawing.Size(120, 20)
        Me.nudBeef.TabIndex = 14
        '
        'nudChicken
        '
        Me.nudChicken.Location = New System.Drawing.Point(123, 40)
        Me.nudChicken.Name = "nudChicken"
        Me.nudChicken.Size = New System.Drawing.Size(120, 20)
        Me.nudChicken.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(78, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Drinks"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(78, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Rice"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(78, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Pork"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Beef"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Chicken"
        '
        'grpbxStatus
        '
        Me.grpbxStatus.Controls.Add(Me.lblStatus)
        Me.grpbxStatus.Location = New System.Drawing.Point(166, 384)
        Me.grpbxStatus.Name = "grpbxStatus"
        Me.grpbxStatus.Size = New System.Drawing.Size(811, 177)
        Me.grpbxStatus.TabIndex = 12
        Me.grpbxStatus.TabStop = False
        Me.grpbxStatus.Text = "Status"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(6, 16)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(799, 158)
        Me.lblStatus.TabIndex = 0
        '
        'nudAmount
        '
        Me.nudAmount.Location = New System.Drawing.Point(821, 244)
        Me.nudAmount.Name = "nudAmount"
        Me.nudAmount.Size = New System.Drawing.Size(156, 20)
        Me.nudAmount.TabIndex = 13
        '
        'Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1355, 592)
        Me.Controls.Add(Me.nudAmount)
        Me.Controls.Add(Me.grpbxStatus)
        Me.Controls.Add(Me.grpbxItems)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.cmbProduct)
        Me.Name = "Inventory"
        Me.Text = "Inventory"
        Me.grpbxItems.ResumeLayout(False)
        Me.grpbxItems.PerformLayout()
        CType(Me.nudDrinks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBeef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudChicken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbxStatus.ResumeLayout(False)
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbProduct As ComboBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grpbxItems As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents grpbxStatus As GroupBox
    Friend WithEvents nudAmount As NumericUpDown
    Friend WithEvents nudChicken As NumericUpDown
    Friend WithEvents nudDrinks As NumericUpDown
    Friend WithEvents nudRice As NumericUpDown
    Friend WithEvents nudPork As NumericUpDown
    Friend WithEvents nudBeef As NumericUpDown
    Friend WithEvents lblStatus As Label
End Class
