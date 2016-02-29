using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace FeedReader
{
    public class RssFeedItemTableViewController : UITableViewController
    {
        private RssFeed _feed;

        public RssFeedItemTableViewController(RssFeed feed)
        {
            _feed = feed;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null);

            Title = _feed.Title;
            TableView.Source = new RssFeedItemSource(this, _feed.Items);
        }
    }
}
