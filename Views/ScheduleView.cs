using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace ihbiproject
{
    public class ScheduleView : ContentPage
    {
        public ScheduleView()
        {
            var calendar = new CalendarView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(calendar);
            Content = stack;
        }
    }
}


