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
        private UITextField _urlField;
        private UIButton _addButton;
        private UITableView _tableView;

        private List<RssFeed> _feeds;

        public RootViewController()
        {
            _feeds = new List<RssFeed>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Rss Feeds";

            View.BackgroundColor = UIColor.LightGray;

            _tableView = new UITableView()
            {
                Frame = new CGRect(0, 0, View.Bounds.Width, View.Bounds.Height),
                Source = new RssFeedSource(_feeds, this)
            };

            View.AddSubviews(_tableView);
        }

    }
}

