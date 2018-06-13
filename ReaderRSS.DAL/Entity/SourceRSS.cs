using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderRSS.DAL.Entity
{
    public class SourceRSS
    {
        public int SourceRSSId { get; set; }
        public string URL { get; set; }
        public string NameOfSource { get; set; }

        public virtual ICollection<RSSItem> RSSItems { get; set; }
    }
}
