using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ihbiproject.Views;

namespace ihbiproject
{
	public class DailyCheckin : ContentPage
	{
		class listItems
		{
            //the page to push
            internal Page content;
			public listItems(string itemName, Page page)
			{
				this.Name = itemName;
                this.content = page;            
			}

			public string Name { private set; get; }
		};

        void ListView_Tapped(object sender, ItemTappedEventArgs e)
        {
            var lv = sender as ListView;
            var selected = lv.SelectedItem as listItems;
            if(selected.content != null)
                Navigation.PushAsync(selected.content);
        }

		public DailyCheckin()
		{

			// Define some data.
			List<listItems> CheckinList = new List<listItems> {
				new listItems ("Exercise", new ExerciseView()),
				new listItems ("Food", new FoodView()),
				new listItems ("Wellness", new WellnessView()),
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

            //we subscribe it to the event
            listView.ItemTapped += ListView_Tapped;

			// Accomodate iPhone status bar.
			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout {
				Children = {
					listView
				}
			};
		}
	}
}


