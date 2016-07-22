using System;
using System.Collections.Generic;
using Exercise;
using Exercise.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


//[assembly: ExportRenderer(typeof(UserProfileSQL), typeof(UserProfileSQLRenderer))]
namespace Exercise.iOS
{
	public class UserProfileSQLRenderer : PageRenderer
	{
		public new UserProfileSQL Element
		{
			get { return (UserProfileSQL)base.Element; }
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			var LeftNavList = new List<UIBarButtonItem>();
			var rightNavList = new List<UIBarButtonItem>();

			var navigationItem = this.NavigationController.TopViewController.NavigationItem;

			for (var i = 0; i < Element.ToolbarItems.Count; i++)
			{

				var reorder = (Element.ToolbarItems.Count - 1);
				var ItemPriority = Element.ToolbarItems[reorder - i].Priority;

				if (ItemPriority == 1)
				{
					UIBarButtonItem LeftNavItems = navigationItem.RightBarButtonItems[1];
					LeftNavList.Add(LeftNavItems);
				}
				else if (ItemPriority == 0)
				{
					UIBarButtonItem RightNavItems = navigationItem.RightBarButtonItems[i];
					rightNavList.Add(RightNavItems);
				}
			}

			navigationItem.SetLeftBarButtonItems(LeftNavList.ToArray(), false);
			navigationItem.SetRightBarButtonItems(rightNavList.ToArray(), false);
		}

	}
}

