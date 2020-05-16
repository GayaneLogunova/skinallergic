<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="WebApplication1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: "Анкета" %>
        </h2>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Имя"></asp:Label>
        <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Поле имя не может быть пустым" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Возраст"></asp:Label>
        <asp:TextBox ID="AgeTextBox" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="AgeValidator" runat="server" ControlToValidate="AgeTextBox" ErrorMessage="Поле возраст не может быть пустым"></asp:RequiredFieldValidator>
&nbsp;<asp:Label ID="AgeNotIntValidator" runat="server" Text="Возраст должен быть целым числом" Visible="False"></asp:Label>

    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Где вы проживаете:"></asp:Label>
        <asp:DropDownList ID="RegionDropDownList" runat="server" DataTextField="Region_name" DataValueField="Id" DataSourceID="Regions">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Regions" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Region_name] FROM [Regions]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Пол: "></asp:Label>
        <asp:DropDownList ID="GenderList" runat="server">
            <asp:ListItem Value ="1">Мужской</asp:ListItem>
            <asp:ListItem Value ="2">Женский</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Каким заболеванием вы болеете:
        <asp:DropDownList ID="DiseaseList" runat="server" DataTextField="Disease_name" DataValueField="Id" DataSourceID="Disease">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Disease" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Disease_name] FROM [Disease]"></asp:SqlDataSource>

    <p>
        Сколько лет назад вам поставили диагноз:
        <asp:DropDownList ID="DurationOfIlnessDropDownList" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem Value="10 ">10 и более лет назад</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Сколько раз в год у вас происходят обострения:
        <asp:DropDownList ID="ExacerbationDropDownList" runat="server">
            <asp:ListItem Value="1">постоянно</asp:ListItem>
            <asp:ListItem Value="2">1-2 раза в год</asp:ListItem>
            <asp:ListItem Value="3">реже раза в год</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        В какой форме протекает ваше заболевание:
        <asp:DropDownList ID="StageDropDownList" runat="server">
            <asp:ListItem Value="1">легкой</asp:ListItem>
            <asp:ListItem Value="2">средне-тяжелой</asp:ListItem>
            <asp:ListItem Value="3">тяжелой</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label7" runat="server" Text="Согласие на обработку персональных данных: "></asp:Label>
        <asp:CheckBox ID="PermissionCheckBox" runat="server" />
        <asp:Label ID="PermissionLabel" runat="server" Text="Обязательно дать согласие на обработку персональных данных" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label8" runat="server" Text="Я в соответвии с Федеральным законом 27.07.2006 № 152 -ФЗ «О персональных данных», своей волей и в своем интересе, даю согласие на обработку любым не запрещенным законом способом всех указанных в настоящей анкете персональных данных. " ForeColor="Red"></asp:Label>
    </p>
    <p> 
        <asp:Button ID="SubmitQA" runat="server" Text="Подтвердить" />
    </p>
<p> 
        &nbsp;</p>
<p class="MsoNormal">
    <span>Указанные выше персональные данные предоставляются для целей:<o:p></o:p></span></p>
<p class="MsoNormal">
    <![if !supportLists]><span>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><![endif]><span>формирование и сопровождение базы данных в рамках проведения Всероссийской переписи людей с хроническими заболеваниями кожи;<o:p></o:p></span></p>
<p class="MsoNormal">
    <![if !supportLists]><span>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><![endif]><span>Предоставление образовательной, научной, медицинской и любой другой информации, являющейся частью социальной программы для людей с хроническими заболеваниями кожи, а также материалов в письменной, печатной, электронной, устной и любой другой соответствующей форме, посредством электронной почты, телефонных звонков, сообщений в социальных сетях Интернет, лично и/ или любым иным соответствующим способом;<o:p></o:p></span></p>
<p class="MsoNormal">
    <![if !supportLists]><span>·&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><![endif]><span>приглашения на образовательные, благотворительные и иные мероприятия, направленные на поддержку и улучшение положения людей с хроническими заболеваниями кожи, а также обеспечения участия в таких мероприятиях.&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<o:p></o:p></span></p>
<p class="MsoNormal">
    <span>Согласие на обработку персональных данных дано Межрегиональной благотворительной общественной организации «Кожные и аллергические болезни» &nbsp;<o:p></o:p></span></p>
<p> 
        &nbsp;</p>
        
</asp:Content>
