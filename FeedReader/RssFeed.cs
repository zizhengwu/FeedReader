using System;
using System.Collections.Generic;
using System.Text;

namespace FeedReader
{
    public class RssFeed
    {
        public string Title { get; set; }
        public string DateAdded { get; set; }
        public List<RssItem> Items { get; set; }

        public RssFeed()
        {
            Items = new List<RssItem>();
        }
    }
}
