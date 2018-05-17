using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikePortal.Business.Process;
using BikePortalWebApp.Models.ViewModel;

namespace BikePortalWebApp.Controllers
{
    public class UserOrderController : BikePortalController
    {
        private readonly IMapper _mapper;

        public UserOrderController(IUserBll userBll, IMapper mapper) : base(userBll)
        {
            _mapper = mapper;
        }

        // GET: /api/UserOrder/GetOrder/1
        public OrderViewModel GetOrder(int id)
        {
            var user = GetDomainUser();
            Debug.Assert(user != null);

            var order = user.Orders.FirstOrDefault(o => o.Id == id);
            return _mapper.Map<OrderViewModel>(order);
        }
    }
}
