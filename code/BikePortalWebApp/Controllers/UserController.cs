using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikePortal.Business.Process;
using BikePortal.DataAccess.Repository;
using BikePortalWebApp.Models.ViewModel;

namespace BikePortalWebApp.Controllers
{
    [Authorize]
    public class UserController : BikePortalController
    {

        private readonly IMapper _mapper;
        public UserController(IUserBll userBll, IMapper mapper) : base(userBll)
        {
            _mapper = mapper;
        }

        // GET: api/User/GetCartItems
        public IEnumerable<ShoppingCartItemViewModel> GetCartItems()
        {
            var user = GetDomainUser();
            Debug.Assert(user != null);
            var shoppingCartItems = user.ShoppingCart.Items;
            return shoppingCartItems.Select(sci => _mapper.Map<ShoppingCartItemViewModel>(sci));
        }

        // GET: api/User/GetOrder/1
        public OrderViewModel GetOrder(int id)
        {
            var user = GetDomainUser();
            Debug.Assert(user != null);

            var order = user.Orders.FirstOrDefault(o => o.Id == id);

            return _mapper.Map<OrderViewModel>(order);
        }

        // GET: api/User/GetOrders
        public IEnumerable<OrderViewModel> GetOrders()
        {
            var user = GetDomainUser();
            Debug.Assert(user != null);

            var orders = user.Orders;
            var orderViewModels = orders.Select(o => _mapper.Map<OrderViewModel>(o));

            return orderViewModels;
        }

        // POST: api/User/PostBuyAllFromCart
        public IHttpActionResult PostBuyAllFromCart()
        {
            var user = GetDomainUser();
            Debug.Assert(user != null);
            UserBll.BuyAllFromCart(user);

            return Ok();
        }
    }
}
