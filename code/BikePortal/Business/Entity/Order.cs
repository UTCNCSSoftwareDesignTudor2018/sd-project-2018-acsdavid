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
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderedArticles { get; set; }

        public Order()
        {
        }

        private Order(User user, IList<OrderItem> orderedItems)
        {
            User = user;
            OrderedArticles = orderedItems;
        }

        public void AddItem(OrderItem orderItem)
        {
            OrderedArticles.Add(orderItem);
        }

        public static Order Create(User user)
        {
            return new Order(user, new List<OrderItem>());
        }

        public decimal CalculateTotal()
        {
            return OrderedArticles.Sum(oi => oi.CalculateTotal());
        }

        protected bool Equals(Order other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Order) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
