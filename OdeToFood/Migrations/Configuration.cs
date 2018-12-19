namespace OdeToFood.Migrations
{
    using OdeToFood.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "OdeToFood.Models.OdeToFoodDb";
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurents.AddOrUpdate(r => r.Name,
               new Restaurent { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
               new Restaurent { Name = "Great Lake", City = "Chicago", Country = "USA" },
               new Restaurent
               {
                   Name = "Smaka",
                   City = "Gothenburg",
                   Country = "Sweden",
                   Reviews =
                       new List<RestaurentReview> {
                       new RestaurentReview { Rating = 9, Body="Great food!", ReviewerName="Sai"},
                       new RestaurentReview { Rating = 10, Body="Nice ambience", ReviewerName="krishna"}
                   }
               });


            for(int i = 0; i < 1000; i++)
            {
                context.Restaurents.AddOrUpdate(r => r.Name,
                    new Restaurent { Name = i.ToString(), City = "no where", Country = "USA" });
            }

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("sai", false) == null)
            {
                membership.CreateUserAndAccount("sai", "password");
            }
            if (!roles.GetRolesForUser("sai").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "sai" }, new[] { "admin" });
            }
        }
    }
}
