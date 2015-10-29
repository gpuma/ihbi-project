using System;

using Xamarin.Forms;
using ihbiproject.Views;

namespace ihbiproject
{
	public class MainTabbedPage : TabbedPage
	{
		public MainTabbedPage ()
		{
			
			this.Children.Add (new NewsFeedView () { Title = "News Feed", Icon = "new_icon.png" });
			this.Children.Add (new DailyCheckinView () { Title = "Daily Checkin", Icon = "dailycheckin.png" });
			this.Children.Add (new ScheduleView () { Title = "Schedule", Icon = "calendar.png" });
			this.Children.Add (new EventView () { Title = "Event", Icon = "event.png" });
			this.Children.Add (new NotificationView () { Title = "Notification", Icon = "notification.png" });

            this.ItemTemplate = new DataTemplate (() => { 
				return new MenuPage (); 
			});
		}
	}

	// Data type:
	class MainMenu
	{
		public MainMenu (string name)
		{
			this.Name = name;
		}

		public string Name { private set; get; }

		public override string ToString ()
		{
			return Name;
		}
	}

	// Format page
	class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			// This binding is necessary to label the tabs in
			// the TabbedPage.
			this.SetBinding (ContentPage.TitleProperty, "Name");
		
		}
	}
}


