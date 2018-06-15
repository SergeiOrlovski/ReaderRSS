
using RSSReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace RSSConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            RssReaderCore reader = new RssReaderCore();
            var rss = reader.ReadRSS(new List<string> { reader.URL1, reader.URL2});
            var responseFromDb = reader.FindRSS(rss);
        }

        //public static void ReadFeed(string url)
        //{
        //    try
        //    {
        //        var setting = new XmlReaderSettings();
        //        setting.DtdProcessing = DtdProcessing.Ignore;
        //        setting.ValidationType = ValidationType.None;
        //        setting.ConformanceLevel = ConformanceLevel.Fragment;
        //        setting.CheckCharacters = false;
        //        setting.LineNumberOffset= -2;
        //        setting.LinePositionOffset = 40;
        //        using (XmlReader reader = XmlReader.Create(url, setting))
        //        {
        //            var formatter = new Rss20FeedFormatter();
        //            formatter.ReadFrom(reader);


        //            var t = formatter.Feed.Items;
        //            var count = 0;
        //            foreach (var ti in t)
        //            {
        //                Console.WriteLine(ti.Title.Text);
        //                Console.WriteLine(ti.PublishDate);
        //                //Console.WriteLine(String.Format(ti.Summary.Text));
        //                Console.WriteLine(Regex.Replace(HttpUtility.HtmlDecode(ti.Summary.Text), "<.*?>", string.Empty));
        //                //Console.WriteLine(HttpUtility.HtmlDecode(ti.Summary.Text));
        //                Console.WriteLine(ti.Id);
        //                Console.WriteLine("--------------------------------------------------");
        //                count++;
        //            }
        //            Console.WriteLine("Прочитанно новостей - {0}", count);
        //            Console.ReadLine();
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        Console.WriteLine(ex.Message, "Syndication Reader");
        //    }
        //}
    }
}
