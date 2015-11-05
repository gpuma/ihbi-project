using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ihbiRestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiCaller();
            Console.ReadLine();

        }

        static async Task ApiCaller()
        {
            Console.ReadLine();
            string apiResult = "";
            using (var client2 = new HttpClient())
            {
                client2.BaseAddress = new Uri("http://localhost:50869/");
                client2.DefaultRequestHeaders.Accept.Clear();
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Users testUser = new Users();

                testUser.email = "a@a";
                testUser.password = "1234";
                testUser.username = "not Geoff";

                Exercise exer = new Exercise();
                exer.user_id = 1;
                exer.stretching = 1;
                exer.pelvic = 1;
                exer.minutes = "2";
                exer.type = "walk";
                exer.date = DateTime.Now;

                HttpResponseMessage response;
                response = await client2.PostAsJsonAsync("api/Exercises", exer);
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                    // Get the URI of the created resource.
                    apiResult = await response.Content.ReadAsStringAsync();
                    Uri resultURL = response.Headers.Location;
                    String resultString = resultURL.ToString();
                    Console.WriteLine(resultString);
                    int slashPosition = resultString.LastIndexOf("/");
                    Console.WriteLine("slash pos: " + slashPosition);
                    string ID = resultString.Substring(slashPosition + 1);
                    Console.WriteLine("ID: " + ID);
                }
                else
                {
                    Console.WriteLine("Store Failed");
                    Uri patientURL = response.Headers.Location;
                    apiResult = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("result: " + apiResult);
                }
                response = await client2.GetAsync("api/Users/1");
                if (response.IsSuccessStatusCode)
                {
                    Users newUsers = await response.Content.ReadAsAsync<Users>();
                    Console.WriteLine("user name: "+testUser.username);
                }

            }
        }
    }
}
