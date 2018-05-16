using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;
using BikePortal.DataAccess.Repository;

namespace BikePortal.Business.Process
{
    public class UserBll : IUserBll
    {
        private readonly IUserRepository _userRepository;

        public UserBll(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public User GetUser(string userId)
        {
            return _userRepository.Get(userId);
        }

        public void PutInShoppingCart(User user, Article article)
        {
            user.PutInShoppingCart(article);
            _userRepository.Update(user);
        }

        public void BuyAllFromCart(User user)
        {
            user.BuyAllFromCart();
            _userRepository.Update(user);
        }
    }
}
