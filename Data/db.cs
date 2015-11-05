using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using ihbiproject.Models;

namespace ihbiproject.Data
{
    public static class db
    {
        //static constructors are executed the first time a static class field is accessed
        static db()
        {
            //todo: implement actual data
            InsertDummyData();
        }
        static List<IHBIUser> users;
        static List<NewsFeedItem> newsfeeditems;
        public static Dictionary<string, string> Moods { get; set; }
        public static Pin[] testLocations;
        public static void InsertDummyData()
        {
            //dummy users
            users = new List<IHBIUser>(new IHBIUser[]
            {
                new IHBIUser() { Username = "johndoe", Email = "johndoe@gmail.com", Password = "johndoe" },
                new IHBIUser() { Username = "mary", Email = "mary@gmail.com", Password = "mary" },
                new IHBIUser() { Username = "amy", Email = "amy@gmail.com", Password = "amy" },
            });

            //dummy newsfeed
            newsfeeditems = new List<NewsFeedItem>(new NewsFeedItem[]
                {
                    new NewsFeedItem() {From = "Emma Watson", Message = "hey I'm gonna jog this saturday near southbank, any1 want 2 come?", Picture ="http://www.cinemablend.com/images/news_img/36323/emma_watson_36323.jpg" },
                    new NewsFeedItem() {From = "Farewell bbq for Eli", Message = "16:00 September 30 at Roma Parklands" },
					new NewsFeedItem() {From = "Girls night out!!", Message = "20:00 September 30 at the Victory" },
					new NewsFeedItem() {From = "Jennifer Firn", Message = "feeling very sad today :((" },
					new NewsFeedItem() {From = "Mary Sue", Message = "Check out my organic, gmo-free, locally harvested alfalfa smoothie recipe on my blog!!!", Picture="http://cdn.nutrientrich.com/wp-content/uploads/2013/06/juice2.jpg" },
					new NewsFeedItem() {From = "New member added to the fb group", Story = "Yuri is new to the group. Say hi to her ;)" },
                });

            //mood filenames and description
            Moods = new Dictionary<string, string>();
            Moods.Add("mood_01.png", "glad");
            Moods.Add("mood_02.png", "happy");
            Moods.Add("mood_03.png", "very happy");
            Moods.Add("mood_04.png", "mischievous");
            Moods.Add("mood_05.png", "cool");
            Moods.Add("mood_06.png", "dumb");
            Moods.Add("mood_07.png", "uncomfortable");
            Moods.Add("mood_08.png", "sad");
            Moods.Add("mood_09.png", "very sad");

            //dummy locations for map
            testLocations = new Pin[] {
                new Pin { Type = PinType.SavedPin, Position = new Position(-27.480031, 153.024679), Label = "Julia" } ,
                new Pin { Type = PinType.SavedPin, Position = new Position(-27.474836, 153.027249), Label = "Roberta" } ,
                new Pin { Type = PinType.SavedPin, Position = new Position(-27.478964, 153.024110), Label = "Patricia" } ,
                new Pin { Type = PinType.SavedPin, Position = new Position(-27.475640, 153.031359), Label = "Francisca" } ,
            };
        }
        public static IHBIUser GetUser(string username, string password)
        {
            //should only have one value and default is null for any reference type
            var user = users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            return user;
        }

        public static List<NewsFeedItem> GetNewsFeed()
        {
            return newsfeeditems;
        }

        public static void GetFbEvents()
        {
            Debug.WriteLine("trying to get events feed");
            var eventsFeed = DependencyService.Get<IFaceBookFeed>().getFeed(eventsOnly: true);
            Debug.WriteLine(eventsFeed != "plz login");
        }
    }
}
