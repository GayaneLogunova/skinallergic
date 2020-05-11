<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: "Опрос" %>
        </h2>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Имя"></asp:Label>
        <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Поле имя не может быть пустым" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Возраст"></asp:Label>
        <asp:TextBox ID="AgeTextBox" runat="server"></asp:TextBox>
        <asp:RangeValidator
           ControlToValidate="AgeTextBox"
           Display="Static"
           ErrorMessage="возраст должен быть целым числом"
           ID="rvAge"
           MaximumValue="150"
           MinimumValue="1"
           RunAt="Server"
           Type="Integer" />

    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Где вы проживаете:"></asp:Label>
        <asp:DropDownList ID="RegionDropDownList" runat="server" DataTextField="Region_name" DataValueField="Id" DataSourceID="Regions">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Regions" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Region_name] FROM [Regions]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Пол"></asp:Label>
        <asp:DropDownList ID="GenderList" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Каким заболеванием вы болеете:
        <asp:DropDownList ID="DiseaseList" runat="server" DataTextField="Disease_name" DataValueField="Id" DataSourceID="Disease">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Disease" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Disease_name] FROM [Disease]"></asp:SqlDataSource>
    </p>
    <p>
        Сколько раз в год у вас происходят обострения:
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1">постоянно</asp:ListItem>
            <asp:ListItem Value="2">1-2 раза в год</asp:ListItem>
            <asp:ListItem Value="3">реже раза в год</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        В какой форме протекает ваше заболевание:
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="1">легкой</asp:ListItem>
            <asp:ListItem Value="2">средне-тяжелой</asp:ListItem>
            <asp:ListItem Value="3">тяжелой</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p> 

        <asp:Button ID="SubmitQA" runat="server" Text="Подтвердить" />
    </p>

    <address>
        &nbsp;</address>
        
</asp:Content>
