using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace FeedReader
{
    public class RssFeedItemCell : UITableViewCell
    {
        public static readonly NSString key = new NSString("RssFeedItemCell");

        public RssFeedItemCell() : base(UITableViewCellStyle.Subtitle, key) { }
    }

}
