<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p></p>
    <p></p>
    <div>
        <table style="width: 100%; height:50px;">
        <tr>
            <td>
                <br />
                     <asp:DropDownList ID="DiseaseDropDownList" runat="server" DataSourceID="disease" DataTextField="Disease_name" DataValueField="Id">
                    </asp:DropDownList>
                     <asp:SqlDataSource ID="disease" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Disease_name] FROM [Disease]"></asp:SqlDataSource>
         <br />
           </td>
            <td><br />
                     <asp:DropDownList ID="RegionDropDownList" runat="server" DataSourceID="regions" DataTextField="Region_name" DataValueField="Id">
                    </asp:DropDownList>
                     <asp:SqlDataSource ID="regions" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Region_name] FROM [Regions]"></asp:SqlDataSource>
         <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                 <asp:Button ID="DiseaseSubmitButton" runat="server" Text="Подтвердить" />
            </td>
        </tr>
    </table>
    </div>    
    <div id="russian-map">
        <br />
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



    <script src="scripts/Chart.min.js"></script>
	<script src="scripts/utils.js"></script>
    <script src="scripts/full-data-analys.js"></script>
    <script > var fullData = <%= Functions.SerializeToJson.FullDataJson() %> </script>
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
                labels: ["1 год", "до 5 лет", "дольше"],
                datasets: [{
                    backgroundColor: window.chartColors.red,
                    borderColor: window.chartColors.red,
                    data: stage1_data(fullData),
                    fill: false,
                }, {
                        backgroundColor: window.chartColors.yellow,
                        borderColor: window.chartColors.yellow,
                        data: stage2_data(fullData),
                        fill: false,
                    }, {
                        backgroundColor: window.chartColors.blue,
                        borderColor: window.chartColors.blue,
                        data: stage3_data(fullData),
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

</asp:Content>
