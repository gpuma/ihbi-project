using System;
using System.Collections.Generic;
using System.Text;
using Rivets;
using ihbiproject;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;


[assembly: Xamarin.Forms.Dependency(typeof(ihbiproject.iOS.FBLink_iOS))]
namespace ihbiproject.iOS
{
    class FBLink_iOS : IFBLink
    {
        public void OpenFBUri(string URI)
        {
			NSUrl url = new NSUrl("http://google.com");
			if (!UIApplication.SharedApplication.OpenUrl(url))
			{
			}

        }

    }
}
