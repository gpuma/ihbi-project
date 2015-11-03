using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ihbiproject;
using ihbiproject.Models;
using ihbiproject.Data;
using Xamarin.Forms;

namespace ihbiproject.ViewModels
{
    public class NewsFeedViewModel
    {
        public List<NewsFeedItem> NewsFeedItems { get; set; }

        public void LoadNewsFeed()
        {
			
			DependencyService.Get<IFaceBookFeed> ().getFeed ();

        }


    }
}
