Imports Functions

Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub SubmitData(sender As Object, e As EventArgs) Handles SubmitQA.Click
        Try
            Dim person As Functions.User = New User(NameTextBox.Text.ToString(), AgeTextBox.Text.ToString(), GenderList.Text.ToString(), RegionDropDownList.SelectedItem.Value, DiseaseList.SelectedItem.Value)
            Functions.DataStorage.SaveInfoToFile(person)
            Server.Transfer("About.aspx")
        Catch ex As AgeException
            MsgBox("Wrong age format")
        Catch ex As GenderException
            MsgBox("Gender field required")
        Catch ex As DiseaseException
            MsgBox("Disease required")
        End Try
    End Sub

    Protected Sub RegionDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RegionDropDownList.SelectedIndexChanged

    End Sub
End Class