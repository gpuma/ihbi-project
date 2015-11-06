using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ihbiproject.ViewModels;

namespace ihbiproject.Views
{
	public partial class DailyCheckinView : ContentPage
	{
        List<listItems> CheckinList = new List<listItems> {
                new listItems ("Exercise", new ExerciseView ()),
                new listItems ("Food", new FoodView ()),
                new listItems ("Wellness", new WellnessView ()),
            };
        public DailyCheckinView ()
		{
			InitializeComponent ();
            list.ItemsSource = CheckinList;
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

		void onDateSelected(Object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine ("DATE SELECTED!!!!!");
			DatePicker dp = (DatePicker)sender;


			App.Instance.date = dp.Date;

		}



	}
}

