using System;

using Xamarin.Forms;

namespace ihbiproject
{
	public class FoodView : ContentPage
	{
		public FoodView ()
		{
			this.Title = "Food";
			Content = new TableView { 
				Root = new TableRoot{
					new TableSection{
						new EntryCell {Label = "Calcium", Placeholder = "Serves"},
						new EntryCell {Label = "Fruit", Placeholder = "Pieces"},
						new EntryCell {Label = "Vegetable", Placeholder = "Serves"},
						new EntryCell {Label = "Water", Placeholder = "Glasses"}

					}
				},
				Intent = TableIntent.Settings
			};
		}
	}
}


