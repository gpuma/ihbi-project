using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ihbiproject.ViewModels;
using ihbiproject.Models;

namespace ihbiproject.Views
{
    public partial class NewsFeedView : ContentPage
    {
        public NewsFeedViewModel vm { get { return (NewsFeedViewModel)BindingContext; } }

        public void OnNewsFeedItem_Tapped(object sender, ItemTappedEventArgs e)
        {
            var itemURL = (e.Item as NewsFeedItem).URI;
            Device.OpenUri(new Uri(itemURL));
            System.Diagnostics.Debug.WriteLine("uri for clicked post:", itemURL);
            //deselect item
            lstNewsFeedItems.SelectedItem = null;
        }

        public NewsFeedView()
        {	
			System.Diagnostics.Debug.WriteLine ("===>> In News Feed");
			//DependencyService.Get<IFaceBookFeed> ().getFeed ();
			System.Diagnostics.Debug.WriteLine ("===>> After DPS");
			//todo: check order of calls --- story or message, updated_time, id
            InitializeComponent();
            BindingContext = new NewsFeedViewModel();
            vm.LoadNewsFeed();
            lstNewsFeedItems.ItemsSource = vm.NewsFeedItems;

        }
    }
}
