using System;

using Xamarin.Forms;

namespace ihbiproject
{
	public class EventView : ContentPage
	{
		public EventView ()
		{
			this.Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello Event Page" }
				}
			};
		}
	}
}


