using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.Util;
using CoreGraphics;
using UIKit;

namespace FeedReader
{
    public class RootViewController : UIViewController
    {
        private UIBarButtonItem _settingIcon;

        private UITableView _tableView;

        private List<RssFeed> _feeds;

        public RootViewController()
        {
            _feeds = new List<RssFeed>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // handle login
            if (!AppDelegate.IsUserLoggedIn)
            {
              var loginViewController = new LoginViewController();
              this.NavigationController.PresentViewController(loginViewController, false, () => {});
            }

            Title = "Rss Feeds";

            _settingIcon = new UIBarButtonItem(UIImage.FromFile("Images/Settings-500.png").MaxResizeImage(22, 22) , UIBarButtonItemStyle.Plain,
                async (sender, args) =>
                {
                    var feedSync = new FeedSync();
                    await feedSync.AddNewFeedAsync("http://blog.xamarin.com/feed", _feeds);
                    _tableView.ReloadData();
                });

            View.BackgroundColor = UIColor.LightGray;

            _tableView = new UITableView()
            {
                Frame = new CGRect(0, 0, View.Bounds.Width, View.Bounds.Height),
                Source = new RssFeedSource(_feeds, this)
            };

            View.AddSubviews(_tableView);
            this.NavigationItem.SetRightBarButtonItem(_settingIcon, true);
        }

    }
}

