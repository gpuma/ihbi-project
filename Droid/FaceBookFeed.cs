using System;


[assembly: Xamarin.Forms.Dependency (typeof (ihbiproject.Droid.FaceBookFeed))]
namespace ihbiproject.Droid
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

