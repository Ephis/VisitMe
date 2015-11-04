using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VisitMe2.Models
{
    public class VistmeContext : DbContext
    {

        public VistmeContext() : base("VisitMeContext")
        {
            Database.SetInitializer<VistmeContext>(new CreateDatabaseIfNotExists<VistmeContext>());
        }
        public DbSet<Card> cards { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<RecivedCards> recovedCards { get; set; }
        public DbSet<Account> accounts { get; set; } 
    }
}