using System;

using Xamarin.Forms;

namespace ihbiproject
{
	//BaseContentPage class is to ensure that none of the app's screens can be displayed until the user has logged in.
	public class BaseContentPage : ContentPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			System.Diagnostics.Debug.WriteLine ("====> in Base Content" + App.Instance.IsAuthenticated);
			if (!App.Instance.IsAuthenticated) {
				Navigation.PushModalAsync(new LoginPage());
			}
		}
	}

}


