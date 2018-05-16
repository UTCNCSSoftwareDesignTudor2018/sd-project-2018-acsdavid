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

        public OrderItem ToOrderItem()
        {
            return new OrderItem
            {
                Article = Article,
                PricePerItem = Article.Price,
                Quantity = Quantity
            };
        }

        protected bool Equals(ShoppingCartItem other)
        {
            return Id == other.Id && Quantity == other.Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShoppingCartItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ Quantity;
            }
        }
    }
}
