using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace FeedReader
{
    internal class RssFeedItemSource : UITableViewSource
    {
        private List<RssItem> _items;
        UIViewController _parentController;

        public RssFeedItemSource(UIViewController parentController, List<RssItem> items)
        {
            _parentController = parentController;
            _items = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(RssFeedItemCell.key) as RssFeedItemCell;
            if (cell == null)
            {
                cell = new RssFeedItemCell();
            }

            cell.TextLabel.Text = _items[indexPath.Row].Title;
            cell.DetailTextLabel.Text = string.Format("{0} on {1}", _items[indexPath.Row].Creator,
                _items[indexPath.Row].PubDate);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var item = _items[indexPath.Row];

            var url = new NSUrl(item.Link);
            //UIApplication.SharedApplication.OpenUrl(url);
            var feedContentView = new RssFeedItemContentView(item);
            _parentController.NavigationController.PushViewController(feedContentView, true);

            tableView.DeselectRow(indexPath, false);
        }
    }
}