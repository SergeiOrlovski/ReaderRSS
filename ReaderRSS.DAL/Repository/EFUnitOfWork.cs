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
    public class EFUnitOfWork : IUnitOfWork
    {
        private RSSContext _dbcontext;
        private RSSItemRepository itemRepository;
        private SourceRSSRepository cacheDataRepository;

        public EFUnitOfWork(string connectionString)
        {
            _dbcontext = new RSSContext(connectionString);
        }

        public IRepository<RSSItem> RSSItem
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new RSSItemRepository(_dbcontext);
                return itemRepository;
            }
        }

        public IRepository<SourceRSS> SourceRSS
        {
            get
            {
                if (cacheDataRepository == null)
                    cacheDataRepository = new SourceRSSRepository(_dbcontext);
                return cacheDataRepository;
            }
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
