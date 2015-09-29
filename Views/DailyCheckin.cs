using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ihbiproject
{
	public class DailyCheckin : ContentPage
	{
		class listItems
		{
			public listItems(string itemName)
			{
				this.Name = itemName;
			}

			public string Name { private set; get; }
		};

		public DailyCheckin()
		{
			Label header = new Label {
				Text = "Daily Checkin",
				HorizontalOptions = LayoutOptions.Center
			};

			// Define some data.
			List<listItems> CheckinList = new List<listItems> {
				new listItems ("Exercise"),
				new listItems ("Food"),
				new listItems ("Wellness"),
			};

			// Create the ListView.
			ListView listView = new ListView {
				// Source of data items.
				ItemsSource = CheckinList,

				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for 
				//      each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate (() => {
					// Create views with bindings for displaying each property.
					Label nameLabel = new Label ();
					nameLabel.SetBinding (Label.TextProperty, "Name");


					// Return an assembled ViewCell.
					return new ViewCell {
						View = new StackLayout {
							Padding = new Thickness (10, 5),
							Orientation = StackOrientation.Horizontal,
							Children = {
								new StackLayout {
									VerticalOptions = LayoutOptions.Center,
									Spacing = 0,
									Children = { nameLabel }

								}
							}
						}
					};
				})
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout {
				Children = {
					header,
					listView
				}
			};
		}
	}
}


