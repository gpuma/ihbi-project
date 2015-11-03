using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using ihbiproject.Data;
using ihbiproject.Models;

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

		public async void createUser() {
			using (var client2 = new HttpClient ()) {
				client2.BaseAddress = new Uri ("http://ihbiproject.azurewebsites.net/");
				client2.DefaultRequestHeaders.Accept.Clear ();
				client2.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));

				IHBIUser testUser = new IHBIUser ();

				testUser.Email = "a@a";
				testUser.Password = "1234";
				testUser.Username = "not Geoff";



				HttpResponseMessage response;
				response = await client2.PostAsJsonAsync ("api/Users", testUser);
				if (response.IsSuccessStatusCode) {
					System.Diagnostics.Debug.WriteLine ("======>in getUsers: " + response.Content.ReadAsStringAsync ());
				}
			}
		}
    }
}
