using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ihbiproject;
using ihbiproject.Models;
using ihbiproject.Data;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace ihbiproject.ViewModels
{
    public class NewsFeedViewModel
    {
        public List<NewsFeedItem> NewsFeedItems { get; set; }

        public void LoadNewsFeed()
        {

			//NewsFeedItems = db.GetNewsFeed();
			NewsFeedItems = new List<NewsFeedItem>();

			String feed = DependencyService.Get<IFaceBookFeed> ().getFeed (this);
			feedLoaded (feed);
//			System.Diagnostics.Debug.WriteLine ("======>after DS.getFeed() feed: " + feed);
//			var feedArray = new JArray (feed);
//			foreach (var obj in feedArray) 
//			{
//				System.Diagnostics.Debug.WriteLine ("====>JsonObject" + obj.ToString ());
//			}

        }
		public void feedLoaded(string feed) 
		{
			
			System.Diagnostics.Debug.WriteLine ("====> in feed Loaded");
			var topObj = JObject.Parse (feed);
			//System.Diagnostics.Debug.WriteLine ("topObj: " + topObj.ToString ());
			var feedObj = topObj["feed"];
			//System.Diagnostics.Debug.WriteLine ("feed: " + feedObj.ToString ());
			var feedArray = feedObj ["data"];
			//System.Diagnostics.Debug.WriteLine ("=====> feedArray:"+ feedArray);				
			foreach (var obj2 in feedArray) 
			{
				NewsFeedItem newitem = new NewsFeedItem ();
//				newitem.From = obj["from"]["name"].ToString();
//				newitem.Created_time = obj["created_time"].ToString();
//				newitem.Message = obj["message"].ToString();
//				newitem.Picture = "";
//				newitem.Place = "";
//				newitem.Story = obj["story"].ToString();
				JObject obj = (JObject) obj2;
				newitem.From = obj["from"]["name"].ToString();
				newitem.Created_time = obj["created_time"].ToString();
				JToken msg;
				if (obj.TryGetValue ("message", out msg)) {
					newitem.Message = obj ["message"].ToString ();
				} else if (obj.TryGetValue("story", out msg)){
					newitem.Message = obj ["story"].ToString ();
				}
				if (obj.TryGetValue ("picture", out msg)) {
					newitem.Picture = obj ["picture"].ToString();
				}
				newitem.Place = "";

				System.Diagnostics.Debug.WriteLine ("====>JsonObject" + newitem.ToString ());
				NewsFeedItems.Add (newitem);
			}
			System.Diagnostics.Debug.WriteLine ("=====> After Feed Loaded");
		}


    }
}
