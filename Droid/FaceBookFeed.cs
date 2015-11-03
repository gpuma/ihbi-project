using System;
using Facebook;
using ihbiproject.ViewModels;

[assembly: Xamarin.Forms.Dependency (typeof (ihbiproject.Droid.FaceBookFeed))]
namespace ihbiproject.Droid
{
	public class FaceBookFeed : IFaceBookFeed
	{
		public FaceBookFeed ()
		{

		}

		public string getFeed(NewsFeedViewModel vm)
		{

			System.Diagnostics.Debug.WriteLine ("====> In getFeed()");
			if (App.Instance.IsAuthenticated) {
				System.Diagnostics.Debug.WriteLine ("=====> In getFeed() and Authd");
				return fb (vm);
			} else {
				System.Diagnostics.Debug.WriteLine ("=====> In getFeed() and Not Authd");
				return "plz login";
			}

		}

		public string fb(NewsFeedViewModel vm)
		{
			string token = App.Instance.Token;
			string rValue = "";
			FacebookClient fb = new FacebookClient (token);
			fb.GetCompleted += (sender, e) => {
				System.Diagnostics.Debug.WriteLine("=====>In NewsFeed FB()");
				var ex = e.Error;
				if (ex != null){
					System.Diagnostics.Debug.WriteLine("=====> FB Error");
				}else{
					System.Diagnostics.Debug.WriteLine("====>> NewsFeed FB() Results"+e.GetResultData().ToString());
					rValue =  e.GetResultData().ToString();
					vm.feedLoaded(rValue);
				}

			};
			fb.GetTaskAsync ("1698903283671929?fields=feed{from,created_time,message,picture,place,story}");
			return rValue;
		}
	}
}

