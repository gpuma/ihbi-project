using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
using ihbiproject.Data;
using ihbiproject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ihbiproject.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public IHBIUser Login()
        {
            //todo: hash password
            var user = db.GetUser(Username, Password);
            return user;
        }

//		public async void createUser() {
//			using (var client2 = new HttpClient ()) {
//				client2.BaseAddress = new Uri ("http://ihbiproject.azurewebsites.net/");
//				client2.DefaultRequestHeaders.Accept.Clear ();
//				client2.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
//
//				RestUser testUser = new RestUser ();
//
//				testUser.id = null;
//				testUser.email = "a@a";
//				testUser.password = "1234";
//				testUser.username = "not Geoff";
//
//
//
//				HttpResponseMessage response;
//				response = await client2.PostAsJsonAsync ("api/Users", testUser);
//				if (response.IsSuccessStatusCode) {
//					System.Diagnostics.Debug.WriteLine ("======>in getUsers: " + response.Content.ReadAsStringAsync ());
//				}
//			}
//		}

		public async void createUser() 
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri ("http://ihbiproject.azurewebsites.net/api/Users"));
			request.ContentType = "application/json";
			request.Method = "GET";
			using (WebResponse response = await request.GetResponseAsync())
			{
				using (Stream stream = response.GetResponseStream()) 
				{
					
					using (StreamReader reader = new StreamReader(stream)){
						String result = reader.ReadToEnd ();
//						JsonSerializer serializer = new JsonSerializer ();
//						String result = (String)serializer.Deserialize (reader, typeof(String));
						System.Diagnostics.Debug.WriteLine ("===> Users: " + result);
					}
						
				}
			}

		}
    }
}
