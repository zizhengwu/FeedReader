using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace FeedReader
{
    public class RssFeedSource : UITableViewSource
    {
        private List<RssFeed> _feeds;
        private UIViewController _viewController;

        public RssFeedSource(List<RssFeed> feeds, UIViewController viewController)
        {
            _feeds = feeds;
            _viewController = viewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(RssFeedCell.Key) as RssFeedCell;
            if (cell == null)
            {
                cell = new RssFeedCell();
            }
            cell.TextLabel.Text = _feeds[indexPath.Row].Title;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _feeds.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _viewController.NavigationController.PushViewController(new RssFeedItemTableViewController(_feeds[indexPath.Row]), true);
            tableView.DeselectRow(indexPath, false);
        }
    }
}
