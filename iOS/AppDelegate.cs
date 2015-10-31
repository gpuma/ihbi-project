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
		}

		public void DidEnterBackground ()
		{
			// Handle when your app sleeps

		}

		public void WillEnterForeground ()
		{
			// Handle when your app resumes

		}
			
//			public void getStoredAccount(){
//			IEnumerable<Account> accounts = AccountStore.Create().FindAccountsForService ("WellnessFB");
//			var enumerable = accounts as IList<Account> ?? accounts.ToList ();
//			var account = enumerable.FirstOrDefault () == null ? null : enumerable.First ();
//
//			if (account == null) {
//				return null;
//			} else {
//				
//				
//			}
//				
//		}

	}
}
