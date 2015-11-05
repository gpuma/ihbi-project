using System;
using ihbiproject.ViewModels;
namespace ihbiproject
{
	public interface IFaceBookFeed
	{
		string getFeed(bool eventsOnly = false);
	}
}

