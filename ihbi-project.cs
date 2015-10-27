using System;

using Xamarin.Forms;
using ihbiproject.Views;

namespace ihbiproject
{
	public class App : Application
	{
		public App ()
		{
		//entry point needs to be wrapped in a NavigationPage so we can push pages on top of it (basic navigation)
			MainPage = new NavigationPage(new LoginPage());
		}

		static NavigationPage _NavPage;

		public static Page GetMainPage ()
		{
			var maintabbedPage = new MainTabbedPage();

			_NavPage = new NavigationPage(maintabbedPage);

			return _NavPage;
		}

		public static bool IsLoggedIn {
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		static string _Token;
		public static string Token {
			get { return _Token; }
		}

		public static void SaveToken(string token)
		{
			_Token = token;
		}

		public static Action SuccessfulLoginAction
		{
			get {
				return new Action (() => {
					_NavPage.Navigation.PopModalAsync();
				});
			}
		}



		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

