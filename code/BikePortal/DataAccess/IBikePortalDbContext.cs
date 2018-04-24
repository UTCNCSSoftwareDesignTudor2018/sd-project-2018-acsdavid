using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess
{
    public interface IBikePortalDbContext
    {
        DbSet<User> DomainUsers { get; set; }
        DbSet<BikePart> BikeParts { get; set; }
        DbSet<Bike> Bikes { get; set; }

        int SaveChanges();
    }
}
