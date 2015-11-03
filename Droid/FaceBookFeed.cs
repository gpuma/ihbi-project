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
				String loginplease =  "{\n  \"feed\": {\n    \"data\": [\n      {\n        \"from\": {\n          \"name\": \"IHBI Group\",\n          \"id\": \"\"\n        },\n        \"created_time\": \"2015-11-03T02:03:45+0000\",\n        \"story\": \"Please Login\",\n        \"id\": \"\"\n      }]\n\t}\n}";
				System.Diagnostics.Debug.WriteLine ("=========> fail: " + loginplease);
				return loginplease;

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
	}
}

