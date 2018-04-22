using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess
{
    public class BikePortalDbContext  : DbContext, IBikePortalDbContext
    {
        public BikePortalDbContext() : base("name=BikePortalDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BikePart> BikeParts { get; set; }
        public DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasRequired(u => u.ShoppingCart).WithRequiredPrincipal(s => s.User);

            modelBuilder.Entity<Bike>().ToTable("Bikes");
            modelBuilder.Entity<BikePart>().ToTable("BikeParts");
            modelBuilder.Entity<Article>().ToTable("Articles");
        }
    }
}
