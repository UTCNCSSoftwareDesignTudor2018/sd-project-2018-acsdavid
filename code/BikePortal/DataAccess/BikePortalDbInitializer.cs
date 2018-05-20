using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BikePortal.DataAccess
{
    public class BikePortalDbInitializer : DropCreateDatabaseIfModelChanges<BikePortalDbContext>
    {
        protected override void Seed(BikePortalDbContext context)
        {
            base.Seed(context);

            context.Bikes.Add(new Bike
            {
                Name = "hello",
                Description = "descripton",
                Model = "model of models",
                Price = 123,

            });

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = new IdentityRole("admin");

            roleManager.Create(role);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser
            {
                UserName = "admin",
                User = User.Create("sir", "admin"),
            };

            userManager.Create(user, "Hello_world1");
            userManager.AddToRole(user.Id, "admin");

            context.SaveChanges();
        }
    }
}
