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
			MainPage = new NavigationPage(new MainTabbedPage());
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

