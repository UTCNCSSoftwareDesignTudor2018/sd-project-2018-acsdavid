using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.Business.Entity
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public virtual Article Article { get; set; }
        public int Quantity { get; set; }
    }
}
