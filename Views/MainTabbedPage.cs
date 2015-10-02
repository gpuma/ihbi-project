using System;

using Xamarin.Forms;
using ihbiproject.Views;

namespace ihbiproject
{
	public class MainTabbedPage : TabbedPage
	{
		public MainTabbedPage ()
		{
			this.Children.Add (new NewsFeedView () { Title = "News Feed" });
			this.Children.Add (new DailyCheckin () { Title = "Daily Checkin" });
			this.Children.Add (new ScheduleView () { Title = "Schedule"});
			this.Children.Add (new EventView () { Title = "Event"});
			this.Children.Add (new NotificationView () { Title = "Notification" });
		}
	}
}


