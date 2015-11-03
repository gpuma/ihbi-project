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

        public void OpenFBUri(string URI)
        {
            var intent = new Intent(Intent.ActionView, Uri.Parse(URI));
            //adding flag messes with some stack but no time for anything else
            intent.AddFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
    }
}