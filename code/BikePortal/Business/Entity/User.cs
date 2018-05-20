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
        public virtual ICollection<Comment> Comments { get; set; }

        public void BuyAllFromCart()
        {
            var order = ShoppingCart.ToOrder();
            ShoppingCart.Clear();

            Orders.Add(order);
        }

        public void PutInShoppingCart(Article article)
        {
            ShoppingCart.AddToCart(article);
        }

        protected bool Equals(User other)
        {
            return Id == other.Id && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static User Create(string firstName, string lastName)
        {
            var domainUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Listings = new List<Article>(),
                Orders = new List<Order>(),
                ShoppingCart = new ShoppingCart()
            };

            return domainUser;
        }
    }
}
