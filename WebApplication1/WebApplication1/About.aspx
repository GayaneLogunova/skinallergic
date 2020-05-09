<%@ Page  Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Все больше и больше людей проходят опрос, помогая нам работать еще лучше!"></asp:Label>
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
    <a class="btn btn-default" href="Contact.aspx" > Пройти опрос </a>
    <br />
    <asp:DropDownList ID="DiseaseDropDownList" runat="server" DataTextField="Disease_name" DataValueField="Id" DataSourceID="Disease">
    </asp:DropDownList>

    <asp:SqlDataSource ID="Disease" runat="server" ConnectionString="<%$ ConnectionStrings:SkinAllergyDBConString %>" SelectCommand="SELECT [Id], [Disease_name] FROM [Disease]"></asp:SqlDataSource>

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