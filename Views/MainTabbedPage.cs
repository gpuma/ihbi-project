using System;

using Xamarin.Forms;
using ihbiproject.Views;

namespace ihbiproject
{
	public class MainTabbedPage : TabbedPage
	{
		public MainTabbedPage ()
		{
<<<<<<< HEAD
			this.Children.Add (new NewsFeedView () { Title = "News Feed", Icon = "new.png" });
			this.Children.Add (new DailyCheckin () { Title = "Daily Checkin", Icon = "dailycheckin.png" });
			this.Children.Add (new ScheduleView () { Title = "Schedule", Icon = "calendar.png" });
			this.Children.Add (new EventView () { Title = "Event", Icon = "event.png" });
			this.Children.Add (new NotificationView () { Title = "Notification", Icon = "notification.png" });
=======
			this.Title = "Younger Women Wellness";

            //this.ItemsSource = new MainMenu[] {
            //	new MainMenu ("News Feed"),
            //	new MainMenu ("Daily Checkin"),
            //	new MainMenu ("Schedule"),
            //	new MainMenu ("Events"),
            //	new MainMenu ("Notification")
            //};
            this.Children.Add(new NewsFeedView());
            this.Children.Add(new DailyCheckin());
            //this.Children.Add(new Sche);
            //this.Children.Add(new NewsFeedView);


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
		
>>>>>>> origin/master
		}
	}
}


