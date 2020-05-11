Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("DiseaseId") Is Nothing Then Session("DiseaseId") = "1"
            DiseaseDropDownList.SelectedIndex = Int32.Parse(Session("DiseaseId") - 1)
        End If
    End Sub

    Protected Sub DiseaseSubmit(sender As Object, e As EventArgs) Handles DiseaseSubmitButton.Click
        Session("DiseaseId") = DiseaseDropDownList.SelectedValue.ToString()
        Response.Redirect("Default.aspx")
    End Sub
End Class