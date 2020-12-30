using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.DAL
{
    public class MyDbContext : DbContext
    {
        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(new Initializer());
        }
        public MyDbContext()
            : base("DbConnectionString")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
    }
}
