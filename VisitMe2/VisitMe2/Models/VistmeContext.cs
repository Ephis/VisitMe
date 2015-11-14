using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VisitMe2.Models
{
    public class VistmeContext : IdentityDbContext<ApplicationUser>
    {

        public VistmeContext() : base("VisitMeContext")
        {
            
        }
        public DbSet<Card> cards { get; set; }
        public DbSet<RecivedCards> recovedCards { get; set; }
        public DbSet<Account> accounts { get; set; } 
    }
}