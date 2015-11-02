using System;

using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof (ihbiproject.iOS.FaceBookFeed))]
namespace ihbiproject.iOS
{
	public class FaceBookFeed : IFaceBookFeed
	{
		public FaceBookFeed ()
		{

		}

		public void getFeed()
		{
			System.Diagnostics.Debug.WriteLine ("====> In FB Feed");
		}
	}
}


