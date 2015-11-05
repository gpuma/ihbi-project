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
            MapView mapPage = new MapView() { Title = "Map", Icon = "map_icon.png" };
            mapPage.Appearing += MapPage_Appearing;


            this.Children.Add (new NewsFeedView () { Title = "News Feed", Icon = "new_icon.png" });
			this.Children.Add (new DailyCheckinView () { Title = "Daily Checkin", Icon = "dailycheckin.png" });
			this.Children.Add (new ScheduleView () { Title = "Schedule", Icon = "calendar.png" });
			this.Children.Add (new EventView () { Title = "Event", Icon = "event.png" });
			this.Children.Add (mapPage);
            //todo: add icon

            this.ItemTemplate = new DataTemplate (() => { 
				return new MenuPage (); 
			});
		}

        //anytime Map tab is clicked we load the fb events to display
        private void MapPage_Appearing(object sender, EventArgs e)
        {
            (sender as MapView).LoadMapEvents();
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


