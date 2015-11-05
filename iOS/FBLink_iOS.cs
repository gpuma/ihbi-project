using Foundation;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(ihbiproject.iOS.FBLink_iOS))]
namespace ihbiproject.iOS
{
    class FBLink_iOS : IFBLink
    {
        //currently only working on browser
        public void OpenFBUri(string fbURI, string webURI)
        {
            NSUrl url = new NSUrl(webURI);
            UIApplication.SharedApplication.OpenUrl(url);
        }
    }
}