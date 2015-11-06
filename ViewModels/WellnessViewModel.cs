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
    public class WellnessViewModel
    {
        public double SleepHours { get; set; }
        public Dictionary<string, string> moods { get; set; }
        public string SelectedMood { get; set; }
        public WellnessViewModel()
        {
            SleepHours = CONST.DEFAULT_SLEEP;
            moods = db.Moods;
        }

		public async void saveWelness() 
		{
			Wellness well = new Wellness ();
			well.user_id = 1;
			well.sleep = SleepHours;
			well.mood = SelectedMood;
            if (well.mood == null)
                well.mood = "";
			well.date = DateTime.Now;



			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri ("http://ihbiproject.azurewebsites.net/api/Welnesses"));
			request.ContentType = "application/json";
			request.Method = "POST";
			using (Stream sendStream = await request.GetRequestStreamAsync ()) 
			{
				using (StreamWriter sw = new StreamWriter (sendStream)) 
				{
					JsonSerializer jsOut = new JsonSerializer ();
					jsOut.NullValueHandling = NullValueHandling.Ignore;
					jsOut.Serialize (sw, well);
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
							Wellness result = (Wellness)serializer.Deserialize (reader, typeof(Wellness));
							System.Diagnostics.Debug.WriteLine ("===> Users: " + result.ToString ());
						}

					}
				}
			}

		}
    }
}
