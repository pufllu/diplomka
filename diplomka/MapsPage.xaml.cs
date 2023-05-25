using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BingMapsRESTToolkit;
using System.Windows.Media;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Maps.MapControl.WPF;

namespace diplomka
{
    /// <summary>
    /// Логика взаимодействия для MapsPage.xaml
    /// </summary>
    public partial class MapsPage : Page
    {
        private string bingMapsKey = "nC5weHf1x4BT9fCFAazm~n5F4zfLRvJ6tmZVprOGDGg~AlRsnPjorYXQygI_OZ8Rl4Nc2sVX9YXdLcA7N6jNKqyJsG-uAu0lsIrH5eeskyT7";
        public MapsPage()
        {
            InitializeComponent();
            myMap.CredentialsProvider = new ApplicationIdCredentialsProvider(bingMapsKey);
        }

        private async void FindPathButton_Click(object sender, RoutedEventArgs e)
        {
            string startLocation = StartLocationTextBox.Text;
            string endLocation = EndLocationTextBox.Text;

            var request = new RouteRequest()
            {
                BingMapsKey = bingMapsKey,
                RouteOptions = new RouteOptions()
                {
                    TravelMode = TravelModeType.Driving,
                    Optimize = RouteOptimizationType.TimeWithTraffic,
                    DistanceUnits = DistanceUnitType.Kilometers
                },
                Waypoints = new List<SimpleWaypoint>()
        {
            new SimpleWaypoint(startLocation),
            new SimpleWaypoint(endLocation)
        }
            };

            var response = await ServiceManager.GetResponseAsync(request);

            if (response != null && response.ResourceSets != null && response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null && response.ResourceSets[0].Resources.Length > 0)
            {
                var routeResult = response.ResourceSets[0].Resources[0] as Route;

                LocationCollection routeLocations = new LocationCollection();

                foreach (var leg in routeResult.RouteLegs)
                {
                    foreach (var itineraryItem in leg.ItineraryItems)
                    {
                        routeLocations.Add(new Microsoft.Maps.MapControl.WPF.Location(itineraryItem.ManeuverPoint.Coordinates[0], itineraryItem.ManeuverPoint.Coordinates[1]));
                    }
                }

                MapPolyline routeLine = new MapPolyline();
                routeLine.Locations = routeLocations;
                routeLine.Stroke = new SolidColorBrush(Colors.DarkGreen);
                routeLine.StrokeThickness = 3;
                MapLayer shapeLayer = new MapLayer();
                shapeLayer.Children.Add(routeLine);
                myMap.Children.Add(shapeLayer);

                myMap.SetView(routeLine.Locations, new Thickness(30), 0);
                UpdateRouteText(routeResult);
                async Task<string> GetTrafficCongestionAsync(double latitude, double longitude)
                {
                    string trafficApiKey = "nC5weHf1x4BT9fCFAazm~n5F4zfLRvJ6tmZVprOGDGg~AlRsnPjorYXQygI_OZ8Rl4Nc2sVX9YXdLcA7N6jNKqyJsG-uAu0lsIrH5eeskyT7";
                    string trafficUrl = $"http://dev.virtualearth.net/REST/v1/Traffic/Incidents/{latitude},{longitude}?key={trafficApiKey}";

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage respons = await client.GetAsync(trafficUrl);
                        string responseContent = await respons.Content.ReadAsStringAsync();

                        if (respons.IsSuccessStatusCode)
                        {
                            JObject trafficData = JObject.Parse(responseContent);
                            string congestion = trafficData.SelectToken("resourceSets[0].resources[0].congestion").ToString();
                            return congestion;
                        }
                    }

                    return "N/A";
                }

                async Task UpdateRouteText(Route route)
                {
                    StringBuilder routeInfo = new StringBuilder();
                    routeInfo.AppendLine($"Общее расстояние: {route.TravelDistance} километры");

                    foreach (var leg in route.RouteLegs)
                    {
                        routeInfo.AppendLine($"Из {leg.StartLocation.Address.FormattedAddress} в {leg.EndLocation.Address.FormattedAddress}");
                        routeInfo.AppendLine($"  Дистанция: {leg.TravelDistance} километры");
                        //routeInfo.AppendLine($"  Продолжительность без учета трафика: {leg.TravelDuration} секунд");


                        foreach (var itineraryItem in leg.ItineraryItems)
                        {
                            var trafficCongestion = await GetTrafficCongestionAsync(itineraryItem.ManeuverPoint.Coordinates[0], itineraryItem.ManeuverPoint.Coordinates[1]);

                            routeInfo.AppendLine($"  - {itineraryItem.Instruction.Text}");
                            routeInfo.AppendLine($"    Дистанция: {itineraryItem.TravelDistance} киломентры");
                            routeInfo.AppendLine($"    Время: {itineraryItem.TravelDuration}  секунды");
                            //routeInfo.AppendLine($"    Трафик: {trafficCongestion}");

                        }

                        routeInfo.AppendLine();
                    }

                    RouteTextBox.Text = routeInfo.ToString();
                }
            }
        }
    }
}
