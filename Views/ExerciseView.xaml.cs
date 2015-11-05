using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ihbiproject.ViewModels;

namespace ihbiproject.Views
{
	public partial class ExerciseView : ContentPage
	{
		public ExerciseView ()
		{
			System.Diagnostics.Debug.WriteLine ("====> in EV");
			InitializeComponent ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
//			FoodViewModel FVM = (FoodViewModel) foodtable.BindingContext;
//			FVM.saveFood ();

		}
	}
}

