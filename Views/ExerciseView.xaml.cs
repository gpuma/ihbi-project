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
			InitializeComponent ();
            Title = "Exercise";

			ExerciseViewModel EVM = (ExerciseViewModel)exercisetable.BindingContext;
			EVM.loadExercise ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			ExerciseViewModel EVM = (ExerciseViewModel) exercisetable.BindingContext;
			EVM.saveExercise (App.Instance.date);

		}

		protected override void OnAppearing ()
		{

			ExerciseViewModel EVM = (ExerciseViewModel) exercisetable.BindingContext;

			EVM.loadExercise (App.Instance.date);
		}
	}
}

