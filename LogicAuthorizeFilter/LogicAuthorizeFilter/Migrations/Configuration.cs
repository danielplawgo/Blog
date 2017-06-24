namespace LogicAuthorizeFilter.Migrations
{
    using LogicAuthorizeFilter.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LogicAuthorizeFilter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LogicAuthorizeFilter.Models.ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            manager.Create(new ApplicationUser
            {
                UserName = "admin",
                IsAdmin = true
            }, "123456");

            manager.Create(new ApplicationUser { UserName = "user1" }, "123456");

            var user = new ApplicationUser { UserName = "user2" };
            manager.Create(user, "123456");

            var invoice = new Invoice()
            {
                Number = "FV 01/2017",
                User = user
            };

            context.Invoices.AddOrUpdate(i => i.Number, invoice);

            context.SaveChanges();
        }
    }
}
