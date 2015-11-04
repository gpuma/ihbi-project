using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using ihbiproject.Data;

namespace ihbiproject.Views
{
    public class MapView : ContentPage
    {
        //gardens point coordinates
        //todo: change so we get current location
        Position startPos = new Position(-27.478033, 153.028755);
        Distance startZoom = Distance.FromKilometers(.8);
        public MapView()
        {
            //var txtPosition = new Entry();
            var map = new Map(MapSpan.FromCenterAndRadius(
                startPos, startZoom))
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
            //stack.Children.Add(txtPosition);
            stack.Children.Add(map);
            Content = stack;
        }

        private async void MapPin_Clicked(object sender, EventArgs e)
        {
            //for some reason displaying twice
            await DisplayAlert("", (sender as Pin).Label, "Ok");
        }
    }
}
