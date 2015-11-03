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

		public string getFeed(NewsFeedViewModel vm)
		{
			
			System.Diagnostics.Debug.WriteLine ("====> In FB Feed");
			if (App.Instance.IsAuthenticated) {
				return fb (vm);
			} else {
				return "plz login";
			}

		}
		public string fb(NewsFeedViewModel vm)
		{
			string token = App.Instance.Token;
			string rValue = "";
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
			var result =  fb.Get ("1698903283671929?fields=feed{from,created_time,message,picture,place,story}");
			//vm.feedLoaded (result);
			System.Diagnostics.Debug.WriteLine("===> R : " + result.ToString());
			return result.ToString();
		}


			//for group events
			//fb.GetTaskAsync ("1698903283671929?fields=events{name,owner,start_time,end_time,description}");

	}
}


