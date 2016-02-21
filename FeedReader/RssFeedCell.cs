using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;

namespace FeedReader
{
    class RssFeedCell : UITableViewCell
    {
        public static  readonly NSString Key = new NSString("RssFeedCell");

        public RssFeedCell() : base(UITableViewCellStyle.Default, Key) {}
    }
}
