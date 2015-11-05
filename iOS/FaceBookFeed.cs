using System;
using ihbiproject.ViewModels;
using Xamarin.Forms;
using Facebook;

[assembly: Xamarin.Forms.Dependency (typeof (ihbiproject.iOS.FaceBookFeed))]
namespace ihbiproject.iOS
{
	public class FaceBookFeed : IFaceBookFeed
	{
		public FaceBookFeed ()
		{

		}

		public string getFeed(bool eventsOnly = false)
		{
			
			System.Diagnostics.Debug.WriteLine ("====> In FB Feed");
			if (App.Instance.IsAuthenticated) {
				return fb (eventsOnly);
			} else {
				return "plz login";
			}

		}
		public string fb(bool eventsOnly = false)
		{
			string token = App.Instance.Token;
			FacebookClient fb = new FacebookClient (token);
            //			fb.GetCompleted += (sender, e) => {
            //				System.Diagnostics.Debug.WriteLine("=====>In NewsFeed FB()");
            //				var ex = e.Error;
            //				if (ex != null){
            //					System.Diagnostics.Debug.WriteLine("=====> FB Error");
            //				}else{
            //					System.Diagnostics.Debug.WriteLine("====>> NewsFeed FB() Results"+e.GetResultData().ToString());
            //					rValue =  e.GetResultData().ToString();
            //					vm.feedLoaded(rValue);
            //				}
            //
            //			};
            var query = "1698903283671929?fields=feed{from,created_time,message,picture,place,story}";
<<<<<<< Updated upstream
            if (eventsOnly) query = "1698903283671929/events";
=======
            //if (eventsOnly) query += "/events";
>>>>>>> Stashed changes
            var result =  fb.Get (query);
			//vm.feedLoaded (result);
			System.Diagnostics.Debug.WriteLine("===> R : " + result.ToString());
			return result.ToString();
		}


			//for group events
			//fb.GetTaskAsync ("1698903283671929?fields=events{name,owner,start_time,end_time,description}");

	}
}


