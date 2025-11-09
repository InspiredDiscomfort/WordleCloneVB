Public Class Inventory
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudChicken.BackColor = Color.Red
        nudBeef.BackColor = Color.Red
        nudPork.BackColor = Color.Red
        nudRice.BackColor = Color.Red
        nudDrinks.BackColor = Color.Red
        nudAmount.Minimum = 0      ' Lowest value allowed
        nudAmount.Maximum = 100    ' Highest value allowed
        nudAmount.Increment = 1    ' How much to change per click
        nudAmount.Value = 0
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cmbProduct.SelectedItem = Nothing Then
            MessageBox.Show("Please Select an item", "Nothing Selected", MessageBoxButtons.RetryCancel)
        ElseIf cmbProduct.SelectedItem = "Chicken" Then
            nudChicken.Value += nudAmount.Value
            lblStatus.Text &= vbCrLf & nudChicken.Value & " Chicken has been added to the inventory"
        ElseIf cmbProduct.SelectedItem = "Beef" Then
            nudBeef.Value += nudAmount.Value
            lblStatus.Text &= vbCrLf & nudBeef.Value & " Beef has been added to the inventory"
        ElseIf cmbProduct.SelectedItem = "Pork" Then
            nudPork.Text += nudAmount.Value
            lblStatus.Text &= vbCrLf & nudPork.Value & " Pork has been added to the inventory"
        ElseIf cmbProduct.SelectedItem = "Rice" Then
            nudRice.Text += nudAmount.Value
            lblStatus.Text &= vbCrLf & nudRice.Value & " Rice has been added to the inventory"
        ElseIf cmbProduct.SelectedItem = "Drinks" Then
            nudDrinks.Text += nudAmount.Value
            lblStatus.Text &= vbCrLf & nudDrinks.Value & " Drinks has been added to the inventory"
        End If
    End Sub
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If cmbProduct.SelectedItem = Nothing Then
            MessageBox.Show("Please Select an item", "Nothing Selected", MessageBoxButtons.RetryCancel)
        Else
            ' Split the label text into separate lines
            Dim lines As List(Of String) = lblStatus.Text.Split(New String() {vbCrLf}, StringSplitOptions.None).ToList()
            ' Find which product to remove
            Dim productName As String = cmbProduct.SelectedItem.ToString()
            ' Remove all lines containing that product name
            lines.RemoveAll(Function(line) line.Contains(productName))
            ' Update the label with the remaining lines
            lblStatus.Text = String.Join(vbCrLf, lines)
            ' Optionally show message about removal
            MessageBox.Show(productName & " has been removed from the status list.")
        End If
    End Sub
    Private Sub nudChicken_ValueChanged(sender As Object, e As EventArgs) Handles nudChicken.ValueChanged
        If nudChicken.Value >= 2 And nudChicken.Value <= 14 Then
            nudChicken.BackColor = Color.Yellow
        ElseIf nudChicken.Value >= 15 Then
            nudChicken.BackColor = Color.Gray
        Else
            nudChicken.BackColor = Color.Red
        End If
    End Sub
    Private Sub nudBeef_ValueChanged(sender As Object, e As EventArgs) Handles nudBeef.ValueChanged
        If nudBeef.Value >= 2 And nudBeef.Value <= 14 Then
            nudBeef.BackColor = Color.Yellow
        ElseIf nudBeef.Value >= 15 Then
            nudBeef.BackColor = Color.Gray
        Else
            nudBeef.BackColor = Color.Red
        End If
    End Sub
    Private Sub nudPork_ValueChanged(sender As Object, e As EventArgs) Handles nudPork.ValueChanged
        If nudPork.Value >= 2 And nudPork.Value <= 14 Then
            nudPork.BackColor = Color.Yellow
        ElseIf nudPork.Value >= 15 Then
            nudPork.BackColor = Color.Gray
        Else
            nudBeef.BackColor = Color.Red
        End If
    End Sub
    Private Sub nudRice_ValueChanged(sender As Object, e As EventArgs) Handles nudRice.ValueChanged
        If nudRice.Value >= 2 And nudRice.Value <= 14 Then
            nudRice.BackColor = Color.Yellow
        ElseIf nudPork.Value >= 15 Then
            nudRice.BackColor = Color.Gray
        Else
            nudRice.BackColor = Color.Red
        End If
    End Sub
    Private Sub nudDrinks_ValueChanged(sender As Object, e As EventArgs) Handles nudDrinks.ValueChanged
        If nudDrinks.Value >= 2 And nudDrinks.Value <= 14 Then
            nudDrinks.BackColor = Color.Yellow
        ElseIf nudDrinks.Value >= 15 Then
            nudDrinks.BackColor = Color.Gray
        Else
            nudDrinks.BackColor = Color.Red
        End If
    End Sub
End Class