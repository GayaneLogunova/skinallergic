<%@ Page  Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="StyleSheet.css">
    <div>
        <table>
            <tr>
                <td colspan="4">
                    <h2><%: "ВСЕРОССИЙСКАЯ ПЕРЕПИСЬ ПАЦИЕНТОВ С ХРОНИЧЕСКИМИ ЗАБОЛЕВАНИЯМИ КОЖИ" %></h2>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height:40px;">
                    <asp:Label ID="Label2" runat="server" Text="Нам важно знать - коже нужна помощь" CssClass="head"></asp:Label>
                </td>
            </tr>
            <tr style="height:70px;">
                <td colspan="4">
                    <asp:Button ID="GoToQAButton" runat="server" Text="Пройти Анкетирование" CssClass="button button2" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                      <asp:Image ID="ImageCensusTasks" runat="server" ImageUrl="~/Content/MainScreenPicture.png" ImageAlign="Middle" CssClass="image" />
                </td>
            </tr>
            <tr style="height:125px;">
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Создать единую базу данных людей с хроническими заболеваниями кожи"></asp:Label></td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Label">Учесть потребности людей с хроническими заболеваниями кожи</asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Разработать индивидуальных подход к каждому человеку с хроническими заболеваниями кожи"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Информировать общество о проблемах людей с хроническими заболеваниями кожи"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <p>
        <asp:Label ID="Label1" runat="server" Text="Всероссийская перепись людей с хроническими заболеваниями кожи поможет найти таких людей, живущих среди нас. Ее цель – создание единой базы данных людей с хроническими заболеваниями кожи, что позволит в дальнейшем найти подход к решению проблем с хроническими заболеваниями кожи и долгосрочному планированию медицинской помощи на государственном уровне.  " Font-Overline="False"></asp:Label>
    </p>
<p>
        <asp:Label ID="Label3" runat="server" Text="Люди по всей стране проходят анкетирования, помогая нам в этом важном деле. "></asp:Label>
    </p>

    <script src="scripts/Chart.min.js"></script>
	<script src="scripts/utils.js"></script>
    <script src="scripts/Data-for-graph.js"></script>
    <script > var datesQuant = <%= Functions.SerializeToJson.DateOfCreationJson() %> </script>
	<style>
	canvas{
		-moz-user-select: none;
		-webkit-user-select: none;
		-ms-user-select: none;
	}
	</style> 

    <div style="width:75%;">
		<canvas id="canvas"></canvas>
	</div>
	<script>
        var config = {
            type: 'line',
            data: {
                labels: month_data(),
                datasets: [{
                    backgroundColor: window.chartColors.red,
                    borderColor: window.chartColors.red,
                    data: get_quant_of_people(datesQuant),
                    fill: false,
                }]
            },
            options: {
                responsive: true,
                title: {
                    display: true,
                },
                tooltips: {
                    mode: 'index',
                    intersect: false,
                },
                hover: {
                    mode: 'nearest',
                    intersect: true
                },
                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Месяцы'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Люди, уже прошедшие опрос'
                        }
                    }]
                }
            }
        };

        window.onload = function () {
            var ctx = document.getElementById('canvas').getContext('2d');
            window.myLine = new Chart(ctx, config);
        };

	</script>








    <p>&nbsp;</p>
    <br />
    <asp:DropDownList ID="DiseaseDropDownList" runat="server" DataTextField="Disease_name" DataValueField="Id" DataSourceID="Disease">
    </asp:DropDownList>

    <asp:SqlDataSource ID="Disease" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Disease_name] FROM [Disease]"></asp:SqlDataSource>

    <asp:Button ID="SubmitDiseaseButton" runat="server" Text="Подтвердить" />

    <br />

    <div id="russian-map">
    </div>
    <script src="scripts/raphael-min.js"></script>
    <script src="scripts/russian-map.js"></script>
    <script src="scripts/color-generator.js"></script>
    <script > var regionsColors = <%= Functions.SerializeToJson.CreateJson() %> </script>
    <script>
        var zzz = fetch('scripts/with-regions.js').then(function (response) {
            response.json().then(function (data) {
                zzz = new RussianMap({
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