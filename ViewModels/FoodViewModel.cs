using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ihbiproject.Data;
using ihbiproject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ihbiproject.ViewModels
{
	public class FoodViewModel : ViewModelBase
	{
		int Calcium;
		int Fruit;
		int Vegetable;
		int Water;

		public FoodViewModel() {

			System.Diagnostics.Debug.WriteLine ("====> FVM");
		}


		public int calcium { 
			get{ return Calcium; }
			set{ SetProperty (ref Calcium, value); }
		}

		public int fruit {
			get{ return Fruit; }
			set{ SetProperty (ref Fruit, value);}
		}
		
		public int vegetable {
			get{ return Vegetable; }
			set{ SetProperty (ref Vegetable, value);}
		}

		public int water {
			get{ return Water; }
			set{ SetProperty (ref Water, value);}
		}


		public async void saveFood() 
		{
			Food foodInfo = new Food();

			foodInfo.calcium = calcium;
			foodInfo.fruit = fruit;
			foodInfo.vegetable = vegetable;
			foodInfo.water = water;
			foodInfo.user_id = 1;
			foodInfo.date = DateTime.Now;

			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri ("http://ihbiproject.azurewebsites.net/api/Consumables"));
			request.ContentType = "application/json";
			request.Method = "POST";
			using (Stream sendStream = await request.GetRequestStreamAsync ()) 
			{
				using (StreamWriter sw = new StreamWriter (sendStream)) 
				{
					JsonSerializer jsOut = new JsonSerializer ();
					jsOut.NullValueHandling = NullValueHandling.Ignore;
					jsOut.Serialize (sw, foodInfo);
				}
			}

			using (WebResponse response = await request.GetResponseAsync())
			{
				using (Stream stream = response.GetResponseStream()) 
				{

					using (StreamReader reader = new StreamReader(stream)){
						//String result = reader.ReadToEnd ();
						JsonSerializer serializer = new JsonSerializer ();
						Food result = (Food)serializer.Deserialize (reader, typeof(Food));
						System.Diagnostics.Debug.WriteLine ("===> Users: " + result.ToString());
					}

				}
			}

		}
	}
}