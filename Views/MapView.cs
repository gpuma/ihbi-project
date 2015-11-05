using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Geolocator.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using ihbiproject.Data;
using ihbiproject.Models;

namespace ihbiproject.Views
{
    public class MapView : ContentPage
    {
        //gardens point coordinates
        Position currentPos = new Position(-27.478033, 153.028755);
        //Position currentPos;
        Distance startZoom = Distance.FromKilometers(.8);
        Label txtPosition = new Label();
        Map map;
        MapEvent[] events;
        public MapView()
        {
            //var btnLocation = new Button() { Text = "Get location" };
            UpdateGeoLocation();
            //btnLocation.Clicked += BtnLocation_Clicked;
            map = new Map(MapSpan.FromCenterAndRadius(
                currentPos, startZoom))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var stack = new StackLayout { Spacing = 0 };
            //stack.Children.Add(txtPosition);
            //stack.Children.Add(btnLocation);
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
            try
            {
                var geoPos = await CrossGeolocator.Current.GetPositionAsync(timeoutMilliseconds: 10000);
                currentPos = new Position(geoPos.Latitude, geoPos.Longitude);
                txtPosition.Text = String.Format("{0},{1}", currentPos.Latitude, currentPos.Longitude);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("couldn't get location");
            }
            
        }

        private async void MapPin_Clicked(object sender, EventArgs e)
        {
            //for some reason displaying twice
            var answer = await DisplayAlert("Event", "View event on Facebook?", "Yes", "No");
            var pin = (sender as Pin);
            //we get the event based on the coordinates of the pin
            var selectedEvent = events.Where(evt => pin.Position.Latitude == evt.Latitude && pin.Position.Longitude == evt.Longitude).First();
            if (answer)
                DependencyService.Get<IFBLink>().OpenFBUri(selectedEvent.FbURI, selectedEvent.WebURI);
        }

        public void LoadMapEvents()
        {
            //fetch from facebook
            events = db.GetFbEvents();
            //if there are no new events we don't do anything
            if (events == null)
                return;
            map.Pins.Clear();
            foreach (var e in events)
            {
                var pin = new Pin()
                {
                    Type = PinType.Place,
                    Position = new Position(e.Latitude, e.Longitude),
                    Label = String.Format("{0} ({1})", e.Name, e.StartTime.ToString())
                };
                pin.Clicked += MapPin_Clicked;
                map.Pins.Add(pin);
            }
        }
    }
}
