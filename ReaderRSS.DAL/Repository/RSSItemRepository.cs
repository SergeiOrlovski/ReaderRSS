using ReaderRSS.DAL.EF;
using ReaderRSS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderRSS.DAL.Repository
{
    class RSSItemRepository : IRepository<RSSItem>
    {
        private RSSContext _dbcontext;

        public RSSItemRepository(RSSContext context)
        {
            _dbcontext = context;
        }

        public void Add(RSSItem param)
        {
            _dbcontext.RSSItems.Add(param);
        }

        public IEnumerable<RSSItem> Find(Func<RSSItem, Boolean> predicate)
        {
            return _dbcontext.RSSItems.Where(predicate).ToList();
        }
    }
}
