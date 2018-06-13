using ReaderRSS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderRSS.DAL
{
    public class RSSItem
    {
        public int RSSItemId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPublish { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

        public int SourceRSSId { get; set; }
        public virtual SourceRSS SourceRSS { get; set; }


    }
}
