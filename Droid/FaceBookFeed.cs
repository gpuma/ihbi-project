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
			if (App.Instance.IsAuthenticated) {
				return fb (vm);
			} else {
				String loginplease =  "{\n  \"feed\": {\n    \"data\": [\n      {\n        \"from\": {\n          \"name\": \"IHBI Group\",\n          \"id\": \"\"\n        },\n        \"created_time\": \"2015-11-03T02:03:45+0000\",\n        \"story\": \"Please Login\",\n        \"id\": \"\"\n      }]\n\t}\n}";
				return loginplease;

			}

		}

		public string fb(NewsFeedViewModel vm)
		{
			string token = App.Instance.Token;
			string rValue = "";
			FacebookClient fb = new FacebookClient (token);
			var result =  fb.Get ("1698903283671929?fields=feed{from,created_time,message,picture,place,story}");
			System.Diagnostics.Debug.WriteLine("===> R : " + result.ToString());
			return result.ToString();
		}
	}
}

