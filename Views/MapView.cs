using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ihbiproject.Views
{
    public class MapView : ContentPage
    {
        //gardens point coordinates
        Position startPos = new Position(-27.4774234, 153.0282853);
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

            var stack = new StackLayout { Spacing = 0 };
            //stack.Children.Add(txtPosition);
            stack.Children.Add(map);
            Content = stack;
        }
    }
}
