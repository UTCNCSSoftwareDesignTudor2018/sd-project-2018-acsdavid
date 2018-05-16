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

        public void AddToCart(Article article)
        {
            var cartItem = Items.FirstOrDefault(sci => sci.Article.Equals(article));
            if (cartItem == null)
            {
                Items.Add(new ShoppingCartItem
                {
                    Article = article,
                    Quantity = 1
                });
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public Order ToOrder()
        {
            var order = Order.Create(User);
            var orderItems = Items.Select(ci => ci.ToOrderItem()).ToList();
            order.OrderedArticles = orderItems;

            return order;
        }

        protected bool Equals(ShoppingCart other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShoppingCart) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
