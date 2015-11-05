using System;
using System.Collections.Generic;
using System.Text;
using Rivets;
using ihbiproject;
using Xamarin.Forms.Platform.iOS;


[assembly: Xamarin.Forms.Dependency(typeof(ihbiproject.iOS.FBLink_iOS))]
namespace ihbiproject.iOS
{
    class FBLink_iOS : IFBLink
    {
        public void OpenFBUri(string URI)
        {
			
            //NSURL* url = [NSURL URLWithString: @"fb://profile/<id>"];
            //[[UIApplication sharedApplication] openURL:url];
			System.Diagnostics.Debug.WriteLine ("======>before applinks");
			System.Diagnostics.Debug.WriteLine ("======>URL" + URI);
			string token = App.Instance.Token;
			System.Diagnostics.Debug.WriteLine ("token  " + token);

			Rivets.AppLinks.DefaultResolver = new FacebookIndexAppLinkResolver ("621549137987350", token);
			Rivets.AppLinks.Navigator.Navigate(URI);
			System.Diagnostics.Debug.WriteLine ("======>after applinks");

        }
    }
}
