using System;

using Xamarin.Forms;
using ihbiproject;
using Xamarin.Auth;
using Android.App;
using Xamarin.Forms.Platform.Android;
using Newtonsoft.Json.Linq;



[assembly: ExportRenderer (typeof (ihbiproject.LoginPage), typeof (ihbiproject.Droid.LoginPageRenderer))]

namespace ihbiproject.Droid
{
	public class LoginPageRenderer : PageRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);
			var activity = this.Context as Activity;
			var auth = new OAuth2Authenticator (
				clientId: "621549137987350", // your OAuth2 client id
				scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
				authorizeUrl: new Uri ("https://m.facebook.com/dialog/oauth/"), // the auth URL for the service
				redirectUrl: new Uri ("http://ihbiproject.azurewebsites.net/api/Users")); // the redirect URL for the service
			auth.Completed += async (sender, eventArgs) => {
				if (eventArgs.IsAuthenticated) {
					var accessToken = eventArgs.Account.Properties ["access_token"].ToString ();
					var expiresIn = Convert.ToDouble (eventArgs.Account.Properties ["expires_in"]);
					var expiryDate = DateTime.Now + TimeSpan.FromSeconds (expiresIn);
					var request = new OAuth2Request ("GET", new Uri ("http://graph.facebook.com/me"), null, eventArgs.Account);
					var response = await request.GetResponseAsync ();
					var obj = JObject.Parse (response.GetResponseText ());
					var id = obj ["id"].ToString ().Replace ("\"", "");
					var name = obj ["name"].ToString ().Replace ("\"","");
					App.SuccessfulLoginAction.Invoke();
				} else {

				}
			};
			System.Diagnostics.Debug.WriteLine ("======>after OAuth");
			activity.StartActivity(auth.GetUI(activity));
	
		}


		public LoginPageRenderer()
		{

		}
	}
}


