using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.Business.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Article> Listings { get; set; }
    }
}
