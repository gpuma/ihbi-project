using System;

using Xamarin.Forms;

namespace ihbiproject
{
	public class MainTabbedPage : TabbedPage
	{
		public MainTabbedPage ()
		{
			this.Title = "Younger Women Wellness";

			this.ItemsSource = new MainMenu[] {
				new MainMenu ("News Feed"),
				new MainMenu ("Daily Checkin"),
				new MainMenu ("Schedule"),
				new MainMenu ("Events"),
				new MainMenu ("Notification")
			};


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


