using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.Business.Entity
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ShoppingCartItem> Items { get; set; }
    }
}
