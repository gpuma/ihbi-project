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
	public class ExerciseViewModel : ViewModelBase
	{
		string exerciseType;
		string exerciseMin;
		bool stretching, pelvic;

		public ExerciseViewModel() {

			System.Diagnostics.Debug.WriteLine ("====> EVM");
		}

		public string ExerciseType {
			get { return exerciseType; } 
			set { SetProperty (ref exerciseType, value); }
			}
		public string ExerciseMin { 
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


		public async void loadExercise() {
			Exercise exercise = new Exercise ();
			DateTime date = DateTime.Now;

			try {
				string sDate = ""+date.Date.ToString("yyyy")+"-"+date.Date.ToString("MM")+"-"+date.Date.ToString("dd");
				System.Diagnostics.Debug.WriteLine("sDate: "+sDate);
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri ("http://ihbiproject.azurewebsites.net/api/Exercises/1/"+sDate));
				request.ContentType = "application/json";
				request.Method = "GET";
			

				using (HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync())
				{
					if (response.StatusCode != HttpStatusCode.OK) {
						System.Diagnostics.Debug.WriteLine ("Error fetching data. Server returned status code: {0}", response.StatusDescription);
					} else {
						using (Stream stream = response.GetResponseStream ()) {

							using (StreamReader reader = new StreamReader (stream)) {
								//String result = reader.ReadToEnd ();
								JsonSerializer serializer = new JsonSerializer ();
								Exercise result = (Exercise)serializer.Deserialize (reader, typeof(Exercise));
//								System.Diagnostics.Debug.WriteLine ("===> Users: " + result.ToString ());
								exercise = result;
							}

						}
					}
				}

				ExerciseType = exercise.type;
				ExerciseMin = exercise.minutes;
				if (exercise.pelvic == 1){
					Pelvic = true;
				} else {
					Pelvic = false;
				}
				if (exercise.stretching == 1) {
					Stretching = true;
				}else {
					Stretching = false;
				}
				System.Diagnostics.Debug.WriteLine ("after setting");
			} catch (System.Net.WebException we) {
				System.Diagnostics.Debug.WriteLine ("Exception in Load Exercise: " + we);
			}

		}

		public async void saveExercise() 
		{
			Exercise exercise = new Exercise ();

			exercise.minutes = exerciseMin;
			if(pelvic) {
				exercise.pelvic = 1;
			} else {
				exercise.pelvic = 0;
			};
			if (stretching) {
				exercise.stretching = 1;
			} else {
				exercise.stretching = 0;
			}
			exercise.type = ExerciseType;
			DateTime date = DateTime.Now;
			string sDate = ""+date.Date.ToString("yyyy")+"-"+date.Date.ToString("MM")+"-"+date.Date.ToString("dd");
			System.Diagnostics.Debug.WriteLine("sDate: "+sDate);
			exercise.date = sDate;
			exercise.user_id = 1;


			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri ("http://ihbiproject.azurewebsites.net/api/Exercises"));
			request.ContentType = "application/json";
			request.Method = "POST";
			using (Stream sendStream = await request.GetRequestStreamAsync ()) 
			{
				using (StreamWriter sw = new StreamWriter (sendStream)) 
				{
					JsonSerializer jsOut = new JsonSerializer ();
					jsOut.NullValueHandling = NullValueHandling.Ignore;
					jsOut.Serialize (sw, exercise);
				}
			}

			using (HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync())
			{
				if (response.StatusCode != HttpStatusCode.OK) {
					System.Diagnostics.Debug.WriteLine ("Error fetching data. Server returned status code: {0}", response.StatusDescription);
				} else {
					using (Stream stream = response.GetResponseStream ()) {

						using (StreamReader reader = new StreamReader (stream)) {
							//String result = reader.ReadToEnd ();
							JsonSerializer serializer = new JsonSerializer ();
							Exercise result = (Exercise)serializer.Deserialize (reader, typeof(Exercise));
							System.Diagnostics.Debug.WriteLine ("===> Users: " + result.ToString ());
						}

					}
				}
			}

		}

	}


}


