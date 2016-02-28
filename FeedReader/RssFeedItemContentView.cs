using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace FeedReader
{
    public class RssFeedItemContentView : UIViewController
    {
        private UIWebView _webView;
        private string _content;

        public RssFeedItemContentView(string content)
        {
            _content = content;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _webView = new UIWebView(View.Bounds);

            string head = "<!DOCTYPE html><html><body style=\"background - color:white; \">";
            string tail = "</body></ html > ";
            _webView.LoadHtmlString(head + _content + tail, null);
            _webView.ScalesPageToFit = false;

            View.AddSubview(_webView);
        }
    }
}
