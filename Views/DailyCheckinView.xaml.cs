using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ihbiproject.ViewModels;

namespace ihbiproject.Views
{
	public partial class DailyCheckinView : ContentPage
	{

		public DailyCheckinView ()
		{
			InitializeComponent ();

			List<listItems> CheckinList = new List<listItems> {
				new listItems ("Exercise", new ExerciseView ()),
				new listItems ("Food", new FoodView ()),
				new listItems ("Wellness", new WellnessView ()),
			};

		}

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
		}

		public void CheckinList_Tapped(object sender, ItemTappedEventArgs e)
		{
			var lv = sender as ListView;
			var selected = lv.SelectedItem as listItems;
			if(selected.content != null)
				Navigation.PushAsync(selected.content);
		}



	}
}

