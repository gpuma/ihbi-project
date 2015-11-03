using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Auth;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Security;

namespace ihbiproject.Droid
{
	[Activity (Label = "ihbi-project.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			PackageInfo info = this.PackageManager.GetPackageInfo ("com.ihbi.project", PackageInfoFlags.Signatures);

//			foreach (Android.Content.PM.Signature signature in info.Signatures)
//			{
//				MessageDigest md = MessageDigest.GetInstance("SHA");
//				md.Update(signature.ToByteArray());
//
//				string keyhash = Convert.ToBase64String(md.Digest());
//				Console.WriteLine("KeyHash:"+ keyhash);
//			}

			global::Xamarin.Forms.Forms.Init (this, bundle);

			//LoadApplication (new App ());
			SetPage (App.Instance.GetMainPage());
		}

		protected override void OnStart ()
		{
			base.OnStart ();
			getStoredAccount ();
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			getStoredAccount ();
		}

		protected override void OnPause ()
		{
			base.OnPause ();
		}

		public void getStoredAccount(){
			System.Diagnostics.Debug.WriteLine ("======>start getStoreAccount");

			var accounts = AccountStore.Create (this).FindAccountsForService ("WellnessFB");
			var account = accounts.FirstOrDefault();

			if (account != null) {
				var accessToken = account.Properties ["access_token"].ToString ();
				App.Instance.SaveToken (accessToken);
				System.Diagnostics.Debug.WriteLine ("======>WellnessFB account" + account);
				//fb(accessToken);

			} else {

			}
		}
	}
}

