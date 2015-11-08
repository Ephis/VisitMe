using VisitMe2.Models;

namespace VisitMe2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VisitMe2.Models.VistmeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VisitMe2.Models.VistmeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            

            context.cards.AddOrUpdate(
                new Card { fName = "Marck", lName = "Jensen", email = "marck@khyme.dk", phone = "60132428"},
                new Card { fName = "Nicolai", lName = "Reigstad", email = "nicolai@reigstad.dk", phone = "41814743" },
                new Card { fName = "Hawkar", lName = "Peshabahar", email = "hawkar@Peshabahar.dk", phone = "60180322" }
                );
        }
    }
}
