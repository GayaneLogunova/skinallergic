Imports Functions
Imports Text

Public Class About
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("DiseaseId") Is Nothing Then Session("DiseaseId") = "1"
            DiseaseDropDownList.SelectedIndex = Int32.Parse(Session("DiseaseId") - 1)
        End If
    End Sub

    Protected Sub DiseaseSubmit(sender As Object, e As EventArgs) Handles SubmitDiseaseButton.Click
        Session("DiseaseId") = DiseaseDropDownList.SelectedValue.ToString()
        Response.Redirect("About.aspx")
    End Sub

    Protected Sub GoToQAScreen(sender As Object, e As EventArgs) Handles GoToQAButton.Click
        Response.Redirect("Contact.aspx")
    End Sub
End Class