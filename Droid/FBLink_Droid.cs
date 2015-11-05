using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Uri = Android.Net.Uri;

[assembly: Xamarin.Forms.Dependency(typeof(ihbiproject.Droid.FBLink_Droid))]
namespace ihbiproject.Droid
{
    public class FBLink_Droid : IFBLink
    {
        public FBLink_Droid() { }

        public void OpenFBUri(string fbURI, string webURI)
        {
            var intent = new Intent(Intent.ActionView, Uri.Parse(fbURI));
            var intent2 = new Intent(Intent.ActionView, Uri.Parse(webURI));
            //adding flag messes with some stack but no time for anything else
            intent.AddFlags(ActivityFlags.NewTask);
            intent2.AddFlags(ActivityFlags.NewTask);
            try
            {
                Application.Context.StartActivity(intent);
            }
            catch(Exception)
            {
                System.Diagnostics.Debug.WriteLine("error opening fb app on android. trying browser");
                Application.Context.StartActivity(intent2);
            }
        }
    }
}