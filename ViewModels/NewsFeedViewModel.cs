using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ihbiproject.Models;
using ihbiproject.Data;

namespace ihbiproject.ViewModels
{
    public class NewsFeedViewModel
    {
        public List<NewsFeedItem> NewsFeedItems { get; set; }

        public void LoadNewsFeed()
        {
            NewsFeedItems = db.GetNewsFeed();
        }
    }
}
