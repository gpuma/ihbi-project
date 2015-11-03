using System;
using System.Collections.Generic;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(ihbiproject.iOS.FBLink_iOS))]
namespace ihbiproject.iOS
{
    class FBLink_iOS : IFBLink
    {
        public void OpenFBUri(string URI)
        {
            //NSURL* url = [NSURL URLWithString: @"fb://profile/<id>"];
            //[[UIApplication sharedApplication] openURL:url];
            throw new NotImplementedException();
        }
    }
}
