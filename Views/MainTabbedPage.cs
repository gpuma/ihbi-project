using System;

using Xamarin.Forms;
using ihbiproject.Views;

namespace ihbiproject
{
	public class MainTabbedPage : TabbedPage
	{
		public MainTabbedPage ()
		{
			this.Children.Add (new NewsFeedView () { Title = "News Feed", Icon = "new.png" });
			this.Children.Add (new DailyCheckin () { Title = "Daily Checkin", Icon = "dailycheckin.png" });
			this.Children.Add (new ScheduleView () { Title = "Schedule", Icon = "calendar.png" });
			this.Children.Add (new EventView () { Title = "Event", Icon = "event.png" });
			this.Children.Add (new NotificationView () { Title = "Notification", Icon = "notification.png" });
		}
	}
}


