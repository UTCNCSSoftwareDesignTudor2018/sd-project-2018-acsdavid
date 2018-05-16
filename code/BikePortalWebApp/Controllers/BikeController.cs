using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using BikePortalWebApp.Hubs;
using BikePortalWebApp.Mappers;
using BikePortalWebApp.Models;
using BikePortalWebApp.Models.BindingModel;
using BikePortalWebApp.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Unity;
using WebGrease.Css.Extensions;

namespace BikePortalWebApp.Controllers
{
    public class BikeController : ArticleController<Bike>
    {
        private readonly IBikeBll _bikeBll;

        public BikeController(IBikeBll bikeBll, IMapper mapper, IUserBll userBll) : base(bikeBll, userBll, mapper)
        {
            _bikeBll = bikeBll;
        }

        // GET: api/Bike
        public IEnumerable<BikeViewModel> Get()
        {
            var bikes = _bikeBll.GetAll();
            return bikes.Select(b => Mapper.Map<BikeViewModel>(b));
        }

        // GET: api/Bike/5
        public BikeViewModel Get(int id)
        {
            var bike = _bikeBll.Get(id);
            return Mapper.Map<BikeViewModel>(bike);
        }


        // POST: api/Bike
        [Authorize]
        public IHttpActionResult Post([FromBody]BikeBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bike = Mapper.Map<Bike>(model);
            var domainUser = GetDomainUser();
            if (domainUser == null)
            {
                return BadRequest("invalid user");
            }
            bike.Uploader = domainUser;
            _bikeBll.Add(bike);

            ArticleAdded.Instance.BroadcastArticleAdded();

            return Ok();
        }

        // PUT: api/Bike/5
        public void Put(int id, [FromBody]BikeBindingModel model)
        {
        }

        // DELETE: api/Bike/5
        public void Delete(int id)
        {
        }


    }
}
