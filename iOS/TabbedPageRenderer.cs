﻿using System;
using System.Reflection;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ihbiproject;


[assembly: ExportRenderer(typeof(ihbiproject.MainTabbedPage), typeof(ihbiproject.iOS.TabbedPageRenderer))]

namespace ihbiproject.iOS
{
	public class TabbedPageRenderer : TabbedRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{
				UITabBar.BarTintColor = UIColor.FromRGB(0x3c, 0x85, 0x13);
				UITabBar.TintColor = UIColor.FromRGB(0xfc, 0xd2, 0x3c);

				UIKit.UITabBarController.MoreNavigationController.Delegate = new CustomNavigationControllerDelegate();

				var vc = UIKit.UITabBarController.MoreNavigationController.ViewControllers[0];
				var tableView = (UITableView)vc.View;
				tableView.TableFooterView = new UIView(CGRect.Empty);
				tableView.BackgroundColor = UIColor.FromRGB(119, 183, 57);
			}
		}
	}

	public class CustomNavigationControllerDelegate : UINavigationControllerDelegate
	{
		public override void WillShowViewController(UINavigationController navigationController, UIViewController viewController, bool animated)
		{
			var tableView = viewController.View as UITableView;
			if (tableView != null)
			{
				viewController.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(0x3C, 0x85, 0x13);
				viewController.NavigationItem.RightBarButtonItem = null;
				viewController.NavigationController.NavigationBar.TintColor = UIColor.FromRGB(0xFC, 0xD2, 0x3C);

				navigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
				{
					ForegroundColor = UIColor.FromRGB(0xFC, 0xD2, 0x3C)
				};

				tableView.SeparatorInset = UIEdgeInsets.Zero;
				foreach (var cell in tableView.VisibleCells)
				{
					cell.BackgroundColor = UIColor.FromRGB(119, 183, 57);
					cell.TextLabel.TextColor = UIColor.White;
					cell.Accessory = UITableViewCellAccessory.None;
					cell.SeparatorInset = UIEdgeInsets.Zero;
				}
			}
		}
	}
}