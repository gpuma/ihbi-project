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

		public string getFeed(bool eventsOnly = false)
		{
			if (App.Instance.IsAuthenticated) {
				return fb (eventsOnly);
			} else {
				String loginplease =  "{\n  \"feed\": {\n    \"data\": [\n      {\n        \"from\": {\n          \"name\": \"IHBI Group\",\n          \"id\": \"\"\n        },\n        \"created_time\": \"2015-11-03T02:03:45+0000\",\n        \"story\": \"Please Login\",\n        \"id\": \"\"\n      }]\n\t}\n}";
				return loginplease;

			}

		}

		public string fb(bool eventsOnly = false)
		{
			string token = App.Instance.Token;
			FacebookClient fb = new FacebookClient (token);
            var query = "1698903283671929?fields=feed{from,created_time,message,picture,place,story}";
            if (eventsOnly) query = "1698903283671929/events";
            var result =  fb.Get (query);
			System.Diagnostics.Debug.WriteLine("===> R : " + result.ToString());
			return result.ToString();
		}
	}
}

