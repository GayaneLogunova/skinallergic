<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: "Опрос" %>
        </h2>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Age"></asp:Label>
        <asp:TextBox ID="AgeTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Region: "></asp:Label>
        <asp:DropDownList ID="RegionDropDownList" runat="server" DataSourceID="Rigions" DataTextField="Region_name" DataValueField="Id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Rigions" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConnectionString %>" SelectCommand="SELECT [Id], [Region_name] FROM [Regions]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Gender"></asp:Label>
        <asp:DropDownList ID="GenderList" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Disease:
        <asp:DropDownList ID="DiseaseList" runat="server" DataSourceID="Disease" DataTextField="Disease_name" DataValueField="Id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Disease" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConnectionString %>" SelectCommand="SELECT [Id], [Disease_name] FROM [Disease]"></asp:SqlDataSource>
    </p>
    <p> 

        <asp:Button ID="SubmitQA" runat="server" Text="Submit" />
    </p>

    <address>
        &nbsp;</address>
        
</asp:Content>
