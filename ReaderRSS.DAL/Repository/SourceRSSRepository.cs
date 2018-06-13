using ReaderRSS.DAL.EF;
using ReaderRSS.DAL.Entity;
using ReaderRSS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderRSS.DAL.Repository
{
    class SourceRSSRepository : IRepository<SourceRSS>
    {
        private RSSContext _dbcontext;

        public SourceRSSRepository(RSSContext context)
        {
            _dbcontext = context;
        }

        public void Add(SourceRSS param)
        {
            _dbcontext.SourceRSSs.Add(param);
        }

        public IEnumerable<SourceRSS> Find(Func<SourceRSS, Boolean> predicate)
        {
            return _dbcontext.SourceRSSs.Where(predicate).ToList();
        }
    }
}
