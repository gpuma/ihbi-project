using System;
using Xamarin.Forms;
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
	[Activity (Label = "ihbi-project.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			PackageInfo info = this.PackageManager.GetPackageInfo ("com.ihbi.project", PackageInfoFlags.Signatures);

			foreach (Android.Content.PM.Signature signature in info.Signatures)
			{
				MessageDigest md = MessageDigest.GetInstance("SHA");
				md.Update(signature.ToByteArray());

				string keyhash = Convert.ToBase64String(md.Digest());
				Console.WriteLine("KeyHash:"+ keyhash);
			}

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}

