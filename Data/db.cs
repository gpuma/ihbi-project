using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    new NewsFeedItem() {Title = "Emma Watson", Description = "hey I'm gonna jog this saturday near southbank, any1 want 2 come?", Image ="http://www.cinemablend.com/images/news_img/36323/emma_watson_36323.jpg", URL = "http://www.runningpage.com/" },
                    new NewsFeedItem() {Title = "Farewell bbq for Eli", Description = "16:00 September 30 at Roma Parklands" },
                    new NewsFeedItem() {Title = "Girls night out!!", Description = "20:00 September 30 at the Victory" },
                    new NewsFeedItem() {Title = "Jennifer Firn", Description = "feeling very sad today :((" },
                    new NewsFeedItem() {Title = "Mary Sue", Description = "Check out my organic, gmo-free, locally harvested alfalfa smoothie recipe on my blog!!!", Image="http://cdn.nutrientrich.com/wp-content/uploads/2013/06/juice2.jpg", URL = "https://sproutpeople.org/sprout-recipes/cat/smoothies/" },
                    new NewsFeedItem() {Title = "New member added to the fb group", Description = "Yuri is new to the group. Say hi to her ;)" },
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
    }
}
