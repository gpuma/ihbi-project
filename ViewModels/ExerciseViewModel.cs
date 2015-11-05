using System;

using Xamarin.Forms;
using ihbiproject;

namespace ihbiproject.ViewModels
{
	public class ExerciseViewModel : ViewModelBase
	{
		double power;
		string exerciseType;
		int exerciseMin;
		bool stretching, pelvic;

		public ExerciseViewModel() {

			System.Diagnostics.Debug.WriteLine ("====> EVM");
		}

		public string ExerciseType {
			get { return exerciseType; } 
			set { SetProperty (ref exerciseType, value); }
			}
		public int ExerciseMin { 
			get { return exerciseMin; } 
			set { SetProperty (ref exerciseMin, value); }
		}
		public bool Stretching { 
			get { return stretching; } 
			set { SetProperty (ref stretching, value); }
		}
		public bool Pelvic { 
			get { return pelvic; } 
			set { SetProperty (ref pelvic, value); }
		}
		public double Power
		{
			private set { SetProperty(ref power, value); }
			get { return power; }
		}
	}


}


