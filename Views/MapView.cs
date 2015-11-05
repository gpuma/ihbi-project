using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Geolocator.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using ihbiproject.Data;

namespace ihbiproject.Views
{
    public class MapView : ContentPage
    {
        //gardens point coordinates
        //Position startPos = new Position(-27.478033, 153.028755);
        Position currentPos;
        Distance startZoom = Distance.FromKilometers(.8);
        Label txtPosition = new Label();
        public MapView()
        {
            var btnLocation = new Button() { Text = "Get location" };
            UpdateGeoLocation();
            btnLocation.Clicked += BtnLocation_Clicked;
            var map = new Map(MapSpan.FromCenterAndRadius(
                currentPos, startZoom))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //get reference to dummy data
            var testPins = db.testLocations;
            foreach (var p in testPins)
            {
                p.Clicked += MapPin_Clicked;
                map.Pins.Add(p);
            }
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(txtPosition);
            stack.Children.Add(btnLocation);
            var locator = CrossGeolocator.Current;

            stack.Children.Add(map);
            Content = stack;
        }

        private void BtnLocation_Clicked(object sender, EventArgs e)
        {
            UpdateGeoLocation();
        }

        private async void UpdateGeoLocation()
        {
            var geoPos = await CrossGeolocator.Current.GetPositionAsync(timeoutMilliseconds: 10000);
            currentPos = new Position(geoPos.Latitude, geoPos.Longitude);
            txtPosition.Text = String.Format("{0},{1}", currentPos.Latitude, currentPos.Longitude);
        }

        private async void MapPin_Clicked(object sender, EventArgs e)
        {
            //for some reason displaying twice
            await DisplayAlert("", (sender as Pin).Label, "Ok");
        }
    }
}
