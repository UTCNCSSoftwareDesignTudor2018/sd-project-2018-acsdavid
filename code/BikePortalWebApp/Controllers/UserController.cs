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

        public IHttpActionResult PostBuyAllFromCart()
        {
            var user = GetDomainUser();
            Debug.Assert(user != null);
            UserBll.BuyAllFromCart(user);

            return Ok();
        }
    }
}
