using System;

using Xamarin.Forms;

namespace ihbiproject
{
	public class ExerciseView : ContentPage
	{


		public ExerciseView ()
		{
			NavigationPage.SetHasBackButton (this, true);
			this.Title = "Exercise";


			Content = new TableView { 
				
				Root = new TableRoot{
					new TableSection{
						new EntryCell {Label = "Minutes exercised"},
						new SwitchCell {Text = "Stretching"},
						new SwitchCell {Text = "Pelvic floor exercise"},
						new EntryCell {Placeholder = "Type of Exercise"}

					}
				},
				Intent = TableIntent.Settings
			};
		}
	}
}


