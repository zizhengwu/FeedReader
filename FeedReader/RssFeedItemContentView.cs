using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace FeedReader
{
    public class RssFeedItemContentView : UIViewController
    {
        private UIWebView _webView;
        private RssItem _item;

        public RssFeedItemContentView(RssItem item)
        {
            _item = item;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _webView = new UIWebView(View.Bounds);

            _webView.LoadHtmlString(Css.head + Css.css + Css.title(_item.Link, _item.PubDate.ToShortDateString(), _item.Title, _item.Creator, "") + _item.Description + Css.tail, null);
            _webView.ScalesPageToFit = false;

            View.AddSubview(_webView);
        }
    }
}
