using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.Business.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public virtual ICollection<OrderItem> OrderedArticles { get; set; }
    }
}
