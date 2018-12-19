using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace OdeToFood.Models
{
    public class OdeToFoodDb : DbContext 
    {
        public OdeToFoodDb():base("name=DefaultConnection")
        {
                
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurent> Restaurents { get; set; }
        public DbSet<RestaurentReview> Reviews { get; set; }
    }
}