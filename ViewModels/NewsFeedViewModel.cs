using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<NewsFeedItem> NewsFeedItems { get; set; }

        public void LoadNewsFeed()
        {
			NewsFeedItems = new ObservableCollection<NewsFeedItem>();
			String feed = DependencyService.Get<IFaceBookFeed> ().getFeed (this);
			feedLoaded (feed);
        }

		public void RefreshFeed() {
			NewsFeedItems.Clear ();
			String feed = DependencyService.Get<IFaceBookFeed> ().getFeed (this);
			feedLoaded (feed);
		}

		public void ClearList() {
			NewsFeedItems.Clear ();

		}

		public void feedLoaded(string feed) 
		{
			
			System.Diagnostics.Debug.WriteLine ("====> in feed Loaded");
			var topObj = JObject.Parse (feed);
			var feedObj = topObj["feed"];
			var feedArray = feedObj ["data"];
			foreach (var obj2 in feedArray) 
			{
				NewsFeedItem newitem = new NewsFeedItem ();
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

				System.Diagnostics.Debug.WriteLine ("====>JsonObject" + newitem.From);
				NewsFeedItems.Add (newitem);
			}
			System.Diagnostics.Debug.WriteLine ("=====> After Feed Loaded");
		}


    }
}
