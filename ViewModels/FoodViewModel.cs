using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ihbiproject.Views;

namespace ihbiproject.ViewModels
{
	public class FoodViewModel : ViewModelBase
	{
		int calcium;
		int fruit;
		int vegetable;
		int water;

		public FoodViewModel() {

			System.Diagnostics.Debug.WriteLine ("====> FVM");
		}

		public int Calcium { 
			get{ return calcium; }
			set{ SetProperty (ref calcium, value); }
		}

		public int Fruit {
			get{ return fruit; }
			set{ SetProperty (ref fruit, value);}
		}
		
		public int Vegetable {
			get{ return vegetable; }
			set{ SetProperty (ref vegetable, value);}
		}

		public int Water {
			get{ return water; }
			set{ SetProperty (ref water, value);}
		}
	}
}