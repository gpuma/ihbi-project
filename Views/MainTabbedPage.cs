using System;

using Xamarin.Forms;
using ihbiproject.Views;
using ihbiproject.ViewModels;


namespace ihbiproject
{
	public class MainTabbedPage : TabbedPage
	{
		public MainTabbedPage ()
		{
			this.Title = "Younger Women Wellness";

			this.Children.Add (new NewsFeedView () { Title = "News Feed", Icon = "new_icon.png" });
			this.Children.Add (new DailyCheckinView () { Title = "Daily Checkin", Icon = "dailycheckin.png" });
			this.Children.Add (new ScheduleView () { Title = "Schedule", Icon = "calendar.png" });
			this.Children.Add (new EventView () { Title = "Event", Icon = "event.png" });
			this.Children.Add (new NotificationView () { Title = "Notification", Icon = "notification.png" });
            //todo: add icon
			this.Children.Add (new MapView () { Title = "Map"});

            this.ItemTemplate = new DataTemplate (() => { 
				return new MenuPage (); 
			});
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			System.Diagnostics.Debug.WriteLine ("====> in Base Content" + App.Instance.IsAuthenticated);
			if (!App.Instance.IsAuthenticated) {
				Navigation.PushModalAsync(new LoginPage());
			}
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
	class MenuPage : BaseContentPage
	{
		public MenuPage ()
		{
			// This binding is necessary to label the tabs in
			// the TabbedPage.
			this.SetBinding (ContentPage.TitleProperty, "Name");
		
		}
	}
}


