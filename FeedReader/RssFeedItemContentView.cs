using System;
using System.Collections.Generic;
using System.Text;
using AMScrollingNavbar;
using Foundation;
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

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var scrolling = NavigationController as ScrollingNavigationController;

            scrolling.FollowScrollView(_webView);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _webView = new UIWebView(View.Bounds);
            _webView.ShouldStartLoad = HandleShouldStartLoad;

            _webView.LoadHtmlString(Css.head + Css.css + Css.title(_item.Link, _item.PubDate.ToShortDateString(), _item.Title, _item.Creator, "") + _item.Description + Css.tail, null);
            _webView.ScalesPageToFit = false;
            _webView.ScrollView.ShouldScrollToTop = ShouldScrollToTop;

            View.AddSubview(_webView);
        }

        private bool HandleShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navType)
        {
            if (navType == UIWebViewNavigationType.LinkClicked)
            {
                UIApplication.SharedApplication.OpenUrl(request.Url);
                return false;
            }
            return true;
        }

        [Export("scrollViewShouldScrollToTop:")]
        public bool ShouldScrollToTop(UIScrollView scrollView)
        {
            var scrolling = NavigationController as ScrollingNavigationController;
            if (scrolling != null)
            {
                scrolling.ShowNavbar(true);
            }
            return true;
        }

    }
}
