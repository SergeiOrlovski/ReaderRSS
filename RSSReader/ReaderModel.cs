using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader
{
    public class ReaderModel
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
    }
}
