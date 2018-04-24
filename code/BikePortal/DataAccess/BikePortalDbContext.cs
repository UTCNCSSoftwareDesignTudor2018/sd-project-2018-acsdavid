using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BikePortal.DataAccess
{
    public class BikePortalDbContext  : IdentityDbContext<ApplicationUser>, IBikePortalDbContext
    {
        public BikePortalDbContext() : base("name=BikePortalDbContext")
        {
        }

        public DbSet<User> DomainUsers { get; set; }
        public DbSet<BikePart> BikeParts { get; set; }
        public DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasRequired(u => u.ShoppingCart).WithRequiredPrincipal(s => s.User);
            modelBuilder.Entity<ApplicationUser>().HasRequired(au => au.User);

            modelBuilder.Entity<Bike>().ToTable("Bikes");
            modelBuilder.Entity<BikePart>().ToTable("BikeParts");
            modelBuilder.Entity<Article>().ToTable("Articles");
        }

        public static BikePortalDbContext Create()
        {
            return new BikePortalDbContext();
        }
    }
}
