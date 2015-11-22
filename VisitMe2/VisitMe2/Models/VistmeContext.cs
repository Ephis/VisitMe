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
        public DbSet<RecivedCards> recivedCards { get; set; }
        public DbSet<Account> accounts { get; set; } 
        public DbSet<CardRequest> cardRequests { get; set; }
    }
}