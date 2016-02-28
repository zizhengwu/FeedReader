using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UIKit;

namespace FeedReader
{
    public class FeedSync
    {
        public async Task AddNewFeedAsync(string url, List<RssFeed> _feeds)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                new UIAlertView("Add A Valid Url", "Please add a valid feed url", null, "OK").Show();
                return;
            }

            var urlText = url;

            using (var client = new HttpClient())
            {
                var newFeed = new RssFeed()
                {
                    DateAdded = DateTime.Now.ToString(),

                };
                var feedString = await client.GetStringAsync(urlText);
                var doc = XDocument.Parse(feedString);

                var title = doc.Descendants("channel").Elements().FirstOrDefault(e => e.Name == "title").Value;

                newFeed.Title = title;

                XNamespace dc = "http://purl.org/dc/elements/1.1/";
                var items = (from item in doc.Descendants("item")
                             select new RssItem()
                             {
                                 Title = item.Element("title").Value,
                                 PubDate = DateTime.Parse(item.Element("pubDate").Value),
                                 Creator = item.Element(dc + "creator").Value,
                                 Link = item.Element("link").Value,
                                 Description = item.Element("description").Value
                             }).ToList();

                newFeed.Items.AddRange(items);

                _feeds.Add(newFeed);
            }
        }
    }
}
