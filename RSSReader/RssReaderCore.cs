using ReaderRSS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Linq;
using ReaderRSS.DAL;

namespace RSSReader
{
    public class RssReaderCore
    {
        private IUnitOfWork Database { get; set; }

        public RssReaderCore(IUnitOfWork uow)
        {
            Database = uow;
        }

        private readonly string url1 = "http://habrahabr.ru/rss/";
        private readonly string url2 = "http://www.interfax.by/news/feed";


        public string URL1 => url1;
        public string URL2 => url2;

        public List<ReaderModel> ReadRSS(List<string> url)
        {
            List<ReaderModel> model = new List<ReaderModel>(); 
                foreach (string u in url)
                {
                    using (XmlReader reader = XmlReader.Create(u))
                    {
                    try
                    {
                        var formatter = new Rss20FeedFormatter();
                        reader.IsStartElement();
                        formatter.ReadFrom(reader);
                        var items = formatter.Feed.Items;

                        foreach (var ti in items)
                        {
                            var rm = new ReaderModel
                            {
                                URL = ti.Id,
                                Title = ti.Title.Text,
                                Description = Regex.Replace(HttpUtility.HtmlDecode(ti.Summary.Text), "<.*?>", string.Empty),
                                PublishDate = ti.PublishDate,
                                Source = u
                            };
                            model.Add(rm);
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("At this time, the channel can not be read.", ex);
                    }  
                    }
                }

            return model;
        }

        public List<RSSItem> FindRSS(List<ReaderModel> model)
        {
            List<RSSItem> items = new List<RSSItem>();
            foreach (var m in model)
            {
                var item = Database.RSSItem.Find(
                f => f.DateOfPublish == m.PublishDate &&
                f.URL == m.URL).ToList();

                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }

        //public void AddNewRssItem(List<RSSItem> old, List<ReaderModel> model)
        //{
        //    foreach(var i in model)
        //}

    }
}
