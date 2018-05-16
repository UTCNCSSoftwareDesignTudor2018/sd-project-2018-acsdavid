using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.Business.Process
{
    public interface IUserBll
    {
        User GetUser(string userId);
        void PutInShoppingCart(User user, Article article);

        void BuyAllFromCart(User user);
    }
}
