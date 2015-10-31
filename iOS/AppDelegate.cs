using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Foundation;
using UIKit;
using ihbiproject;
using Xamarin.Auth;

namespace ihbiproject.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			window.RootViewController = App.Instance.GetMainPage().CreateViewController ();
			window.MakeKeyAndVisible ();

			return true;
		}


		public void  OnActivated()
		{
			// Handle when your app starts

			IEnumerable<Account> accounts = AccountStore.Create ().FindAccountsForService ("WellnessFB");
		}

		public void DidEnterBackground ()
		{
			// Handle when your app sleeps
			IEnumerable<Account> accounts = AccountStore.Create ().FindAccountsForService ("WellnessFB");

		}

		public void WillEnterForeground ()
		{
			// Handle when your app resumes
			IEnumerable<Account> accounts = AccountStore.Create ().FindAccountsForService ("WellnessFB");

		}

	}
}
