using System;
using System.Diagnostics;
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
            var item = (e.Item as NewsFeedItem);
            try
            {
                DependencyService.Get<IFBLink>().OpenFBUri(item.FbURI);
            }
            catch(Exception err)
            {
                Debug.WriteLine("error opening facebook app, trying web browser!");
                Debug.WriteLine(err.Message);
                Device.OpenUri(new Uri(item.WebURI));
            }
            //Debug.WriteLine("uri for clicked post:", itemURL);
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
