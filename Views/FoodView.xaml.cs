using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ihbiproject.ViewModels;


namespace ihbiproject
{
	public partial class FoodView : ContentPage
	{
		public FoodView ()
		{
			InitializeComponent ();
			BindingContext = new FoodViewModel ();
		}
	}
}

