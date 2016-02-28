using System;
using System.Collections.Generic;
using System.Text;

namespace FeedReader
{
    public class RssItem
    {
        public string Title { get; set; }
        public string Creator { get; set; }
        public DateTime PubDate { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
