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

            string head = "<!DOCTYPE html><html><body style=\"background - color:white; \">";
            string tail = "</body></ html > ";
            _webView.LoadHtmlString(head + _item.Description + tail, null);
            _webView.ScalesPageToFit = false;

            View.AddSubview(_webView);
        }
    }
}
