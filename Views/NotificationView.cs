using System;

using Xamarin.Forms;

namespace ihbiproject
{
	public class NotificationView : ContentPage
	{
		public NotificationView ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello Notification Page" }
				}
			};
		}
	}
}


