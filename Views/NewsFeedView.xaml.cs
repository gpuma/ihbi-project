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

		bool a = true;
		void OnRefresh (object sender, EventArgs e)
		{
			var list = (ListView)sender;
			System.Diagnostics.Debug.WriteLine ("====== in OnRefresh()");
			if (a) {
				vm.RefreshFeed ();
				a = false;
			} else {
				vm.RefreshFeed ();
				a = true;
			}

//			var itemList = vm.NewsFeedItems;
//			items.Clear ();
//			foreach (var s in itemList) {
//				items.Add (s);
//			}
			//make sure to end the refresh state

			list.IsRefreshing = false;
		}

        public NewsFeedView()
        {	
            InitializeComponent();
            BindingContext = new NewsFeedViewModel();
            vm.LoadNewsFeed();
            lstNewsFeedItems.ItemsSource = vm.NewsFeedItems;

        }
    }
}
