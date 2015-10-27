using System;
using Xamarin.Auth;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using ihbiproject;
using UIKit;
using Newtonsoft.Json.Linq;


[assembly: ExportRenderer (typeof (ihbiproject.LoginPage), typeof (ihbiproject.iOS.LoginPageRenderer))]

namespace ihbiproject.iOS
{
	public class LoginPageRenderer : PageRenderer
	{

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			var auth = new OAuth2Authenticator (
				clientId: "621549137987350", // your OAuth2 client id
				scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"), // the auth URL for the service
				redirectUrl: new Uri ("http://localhost:3000/")); // the redirect URL for the service

			auth.Completed += (sender, eventArgs) => {
				DismissViewController (true, null);

				if (eventArgs.IsAuthenticated) {
					var accessToken = eventArgs.Account.Properties ["access_token"].ToString ();
					var expiresIn = Convert.ToDouble (eventArgs.Account.Properties ["expires_in"]);
					var expiryDate = DateTime.Now + TimeSpan.FromSeconds (expiresIn);

					var request = new OAuth2Request ("GET", new Uri ("http://graph.facebook.com/me"), null, eventArgs.Account);
					var response = await request.GetResponseAsync ());
					var obj = JObject.Parse (response.GetResponseText ());

					var id = obj ["id"].ToString ().Replace ("\"", "");
					var name = obj ["name"].ToString ().Replace ("\"","");

					App.SuccessfulLoginAction.Invoke();

				} else {

				}
			};

			PresentViewController (auth.GetUI (), true, null);
		}
	}
}


