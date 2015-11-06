using System;

using Xamarin.Forms;
using ihbiproject;
using Android.App;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (ihbiproject.ScheduleView), typeof (ihbiproject.Droid.CalendarViewRenderer))]

namespace ihbiproject.Droid
{
	public class CalendarViewRenderer : PageRenderer
	{
		public CalendarViewRenderer ()
		{
		}
	}
}

