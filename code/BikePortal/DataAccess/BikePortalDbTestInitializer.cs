using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess
{
    public class BikePortalDbTestInitializer : DropCreateDatabaseAlways<BikePortalDbContext>
    {
        protected override void Seed(BikePortalDbContext context)
        {
            base.Seed(context);

            var users = new List<User>()
            {
                new User
                {
                    FirstName = "David",
                    LastName = "Acs",
                    ShoppingCart = new ShoppingCart(),
                    Orders = new List<Order>(),
                    Listings = new List<Article>()
                },
            };

            context.DomainUsers.AddRange(users);
            context.SaveChanges();

            var bikes = new List<Bike>()
            {
                new Bike
                {
                    Name = "my bike",
                    Description = "my first bike, which I really love",
                    Model = "Kawasaki",
                    Uploader = users[0],
                    Price = 2M,
                    Comments = new List<Comment>()
                },
            };

            var comments = new List<Comment>()
            {
                new Comment { Commenter = users[0], CommentText = "nice bike you got there", Date = DateTime.Parse("2018-04-21") },
            };

            bikes[0].Comments.Add(comments[0]);

            context.Bikes.AddRange(bikes);
            context.SaveChanges();
        }
    }
}
