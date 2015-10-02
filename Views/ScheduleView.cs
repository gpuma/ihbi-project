using System;

using Xamarin.Forms;

namespace ihbiproject
{
	public class ScheduleView : ContentPage
	{
		public ScheduleView ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello Schedule Page" }
				}
			};
		}
	}
}


