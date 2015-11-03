using System;

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

		public string getFeed()
		{
			
			System.Diagnostics.Debug.WriteLine ("====> In FB Feed");
			if (App.Instance.IsAuthenticated) {
				return fb ();
			} else {
				return "plz login";
			}

		}

		public string fb()
		{
			string token = App.Instance.Token;
			string rValue = "";
			FacebookClient fb = new FacebookClient (token);
			fb.GetCompleted += (sender, e) => {
				System.Diagnostics.Debug.WriteLine("in FB Completed");
				var ex = e.Error;
				if (ex != null){
					System.Diagnostics.Debug.WriteLine("=====> FB Error");
				}else{
					//var t = (String) e.GetResultData();

					//var res = JObject.Parse (t);
					System.Diagnostics.Debug.WriteLine("====>> in FB"+e.GetResultData().ToString());
					rValue =  e.GetResultData().ToString();
				}

			};
			fb.GetTaskAsync ("1698903283671929?fields=feed{from,created_time,message,picture,place,story}");
			return rValue;
		}

	}
}


