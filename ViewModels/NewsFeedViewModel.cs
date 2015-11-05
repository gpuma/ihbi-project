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
using Humanizer;


namespace ihbiproject.ViewModels
{
    public class NewsFeedViewModel
    {
        public ObservableCollection<NewsFeedItem> NewsFeedItems { get; set; }

        public void LoadNewsFeed()
        {
			NewsFeedItems = new ObservableCollection<NewsFeedItem>();
			String feed = DependencyService.Get<IFaceBookFeed> ().getFeed ();
			feedLoaded (feed);
			LoginViewModel LVM = new LoginViewModel ();
			LVM.createUser ();
        }

		public void RefreshFeed() {
			NewsFeedItems.Clear ();
			String feed = DependencyService.Get<IFaceBookFeed> ().getFeed ();
			feedLoaded (feed);
		}

		public void ClearList() {
			NewsFeedItems.Clear ();

		}


        // gets the URI for use in a web browser
        public string getWebURIfromGraphId(string id)
        {
            //1698903283671929_1723329197896004
            if (String.IsNullOrEmpty(id))
                return "";
            var _id = id.Split('_');
            return String.Format("http://facebook.com/{0}/posts/{1}", _id[0], _id[1]);
        }

        //gets the fb URI from a graph Id
        public string getURIfromGraphId(string id)
        {
            return String.Format("fb://post/{0}", id);
        }

        public void feedLoaded(string feed) 
		{
			
			//System.Diagnostics.Debug.WriteLine ("====> in feed Loaded");
			var topObj = JObject.Parse (feed);
			var feedObj = topObj["feed"];
			var feedArray = feedObj ["data"];
			foreach (var obj2 in feedArray) 
			{
				NewsFeedItem newitem = new NewsFeedItem ();
				JObject obj = (JObject) obj2;
				newitem.From = obj["from"]["name"].ToString();
				newitem.Created_time = DateTime.Parse(obj["created_time"].ToString()).Humanize();
				JToken msg;
				if (obj.TryGetValue ("message", out msg)) {
					newitem.Message = obj ["message"].ToString ();
				} else if (obj.TryGetValue("story", out msg)){
					newitem.Message = obj ["story"].ToString ();
				}
				if (obj.TryGetValue ("picture", out msg)) {
					newitem.Picture = obj ["picture"].ToString();
				}
                if (obj.TryGetValue("id", out msg))
                {
                    newitem.FbURI = getURIfromGraphId(obj["id"].ToString());
                    newitem.WebURI = getWebURIfromGraphId(obj["id"].ToString());
                }
                newitem.Place = "";

				//System.Diagnostics.Debug.WriteLine ("====>JsonObject" + newitem.From);
				NewsFeedItems.Add (newitem);
			}
			//System.Diagnostics.Debug.WriteLine ("=====> After Feed Loaded");
		}


    }
}
