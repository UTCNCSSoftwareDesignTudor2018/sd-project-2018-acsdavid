using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using Microsoft.AspNet.Identity;

namespace BikePortalWebApp.Controllers
{
    public abstract class BikePortalController : ApiController
    {
        protected IUserBll UserBll { get; }

        protected BikePortalController(IUserBll userBll)
        {
            UserBll = userBll;
        }

        protected User GetDomainUser()
        {
            var userId = User.Identity.GetUserId();
            var domainUser = UserBll.GetUser(userId);
            return domainUser;
        }
    }
}