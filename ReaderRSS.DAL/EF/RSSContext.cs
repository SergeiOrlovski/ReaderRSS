using ReaderRSS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderRSS.DAL.EF
{
    public class RSSContext : DbContext
    {
        public DbSet<RSSItem> RSSItems { get; set; }
        public DbSet<SourceRSS> SourceRSSs { get; set; }

        public RSSContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RSSItem>().Property(r => r.RSSItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<RSSItem>().Property(r => r.Title).IsRequired();
            modelBuilder.Entity<RSSItem>().Property(r => r.DateOfPublish).IsRequired();
            modelBuilder.Entity<RSSItem>().Property(r => r.Description).IsRequired();
            modelBuilder.Entity<RSSItem>().Property(r => r.URL).IsRequired();
            modelBuilder.Entity<RSSItem>().Property(r => r.SourceRSSId).IsRequired();

            modelBuilder.Entity<SourceRSS>().Property(s => s.SourceRSSId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SourceRSS>().Property(s => s.URL).IsRequired();
            modelBuilder.Entity<SourceRSS>().Property(s => s.NameOfSource).IsRequired();
        }
    }
}
