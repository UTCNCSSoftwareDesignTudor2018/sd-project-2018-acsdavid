using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.Business.Entity
{
    public class OrderItem
    {
        public int Id { get; set; }
        public virtual Article Article { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }

        public decimal CalculateTotal()
        {
            return Quantity * PricePerItem;
        }

        protected bool Equals(OrderItem other)
        {
            return Id == other.Id && Quantity == other.Quantity && PricePerItem == other.PricePerItem;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Quantity;
                hashCode = (hashCode * 397) ^ PricePerItem.GetHashCode();
                return hashCode;
            }
        }
    }
}
