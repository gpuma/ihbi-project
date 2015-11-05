using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ihbiproject.ViewModels;


namespace ihbiproject.Views
{
	public partial class FoodView : ContentPage
	{
		public FoodView ()
		{
			InitializeComponent ();
			FoodViewModel FVM = (FoodViewModel) foodtable.BindingContext;
			FVM.loadFood ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			FoodViewModel FVM = (FoodViewModel) foodtable.BindingContext;
			FVM.saveFood ();

		}
	}
}

