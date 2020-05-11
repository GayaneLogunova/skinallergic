<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <p>&nbsp;</p>
     <br />
     <asp:DropDownList ID="DiseaseDropDownList" runat="server" DataSourceID="disease" DataTextField="Disease_name" DataValueField="Id">
     </asp:DropDownList>
         <asp:SqlDataSource ID="disease" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Disease_name] FROM [Disease]"></asp:SqlDataSource>
         <asp:Button ID="DiseaseSubmitButton" runat="server" Text="Подтвердить" />
         <br />

    <div id="russian-map">
    </div>
    <script src="scripts/raphael-min.js"></script>
    <script src="scripts/russian-map.js"></script>
    <script src="scripts/color-generator.js"></script>
    <script > var regionsColors = <%= Functions.SerializeToJson.CreateJson() %> </script>
    <script>
            fetch('scripts/with-regions.js').then(function (response) {
                response.json().then(function (data) {
                    new RussianMap({
                        viewPort: data.viewPort,
                        mapId: 'russian-map',
                        width: 862,
                        height: 497,
                        // дефолтовые атрибуты для контуров регионов
                        defaultAttr: {
                            fill: '#d8d8d8', // цвет которым закрашивать
                            stroke: '#ffffff', // цвет границы
                            'stroke-width': 1, // ширина границы
                            'stroke-linejoin': 'round' // скруглять углы
                        },
                        mouseMoveAttr: {
                            fill: '#25669e'
                        },
                        onMouseMove: function (event) {
                            console.log('mouse on ' + this.region.name + ' (ident: ' + this.region.ident + ')');
                        },
                        onMouseOut: function (event) {
                            console.log('out on ' + this.region.name + ' (ident: ' + this.region.ident + ')');
                        },
                        onMouseClick: function (event) {
                            console.log('clicked on ' + this.region.name);
                        }
                    }, data.regions);
                });
            });
        </script>


</asp:Content>
