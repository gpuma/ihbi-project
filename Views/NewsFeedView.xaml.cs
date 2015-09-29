﻿using System;
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
        public NewsFeedView()
        {
            //todo: check order of calls
            InitializeComponent();
            BindingContext = new NewsFeedViewModel();
            vm.LoadNewsFeed();
            lstNewsFeedItems.ItemsSource = vm.NewsFeedItems;
        }
    }
}