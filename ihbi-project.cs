using System;

using Xamarin.Forms;
using ihbiproject.Views;
using ihbiproject;


namespace ihbiproject
{
	public class App : Application
	{
		//public App ()
		//{
		//entry point needs to be wrapped in a NavigationPage so we can push pages on top of it (basic navigation)
		//	MainPage = new NavigationPage(new LoginPage());
		//}

		// just a singleton pattern so I can have the concept of an app instance
		static volatile App _Instance;
		static object _SyncRoot = new Object();
		public static App Instance
		{
			get 
			{
				if (_Instance == null) 
				{
					lock (_SyncRoot) 
					{
						if (_Instance == null) {
							_Instance = new App ();
							_Instance.OAuthSettings = 
								new OAuthSettings (
									clientId: "621549137987350",  		// your OAuth2 client id 
									scope: "",  		// The scopes for the particular API you're accessing. The format for this will vary by API.
									authorizeUrl: "https://m.facebook.com/dialog/oauth/",  	// the auth URL for the service
									redirectUrl: "http://ihbiproject.azurewebsites.net/api/Users");   // the redirect URL for the service
						}
					}
				}

				return _Instance;
			}
		}

		public OAuthSettings OAuthSettings { get; private set; }

		NavigationPage _NavPage;

		public Page GetMainPage ()
		{
			var maintabbedPage = new MainTabbedPage();

			_NavPage = new NavigationPage(maintabbedPage);
			//System.Diagnostics.Debug.WriteLine ("======>Login Page OAuth");
			//_NavPage = new NavigationPage(new LoginPage());
			return _NavPage;
		}

		public bool IsAuthenticated {
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		string _Token;
		public string Token {
			get { return _Token; }
		}

		public void SaveToken(string token)
		{
			_Token = token;

			// broadcast a message that authentication was successful
			MessagingCenter.Send<App> (this, "Authenticated");
		}

		public Action SuccessfulLoginAction
		{
			get {
				return new Action (() => _NavPage.Navigation.PopModalAsync ());
			}
		}


	}
}

