Imports Functions

Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub

    Protected Sub SubmitData(sender As Object, e As EventArgs) Handles SubmitQA.Click
        Dim age As Integer = 0
        If PermissionCheckBox.Checked = True And (Integer.TryParse(AgeTextBox.Text, age)) Then
            Dim person As Functions.User = New User(NameTextBox.Text.ToString(), AgeTextBox.Text.ToString(), GenderList.SelectedItem.Value.ToString(), RegionDropDownList.SelectedItem.Value, DiseaseList.SelectedItem.Value, DurationOfIlnessDropDownList.SelectedItem.Value.ToString(), ExacerbationDropDownList.SelectedItem.Value.ToString(), StageDropDownList.SelectedItem.Value.ToString())
            Functions.DataStorage.SaveInfoToFile(person)
            Server.Transfer("About.aspx")
        ElseIf (PermissionCheckBox.Checked = False) Then
            PermissionLabel.Visible = True
        Else
            AgeNotIntValidator.Visible = True
        End If
    End Sub
End Class