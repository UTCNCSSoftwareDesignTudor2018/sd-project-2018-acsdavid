using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using BikePortalWebApp.Mappers;
using BikePortalWebApp.Models;
using Unity;
using WebGrease.Css.Extensions;

namespace BikePortalWebApp.Controllers
{
    public class BikeController : ArticleController<Bike>
    {
        private readonly BikeBll _bikeBll;

        public BikeController(BikeBll bikeBll, IMapper mapper) : base(bikeBll, mapper)
        {
            _bikeBll = bikeBll;
        }

        // GET: api/Bike
        public IEnumerable<BikeDto> Get()
        {
            var bikes = _bikeBll.GetAll();
            return bikes.Select(b => Mapper.Map<BikeDto>(b));
        }

        // GET: api/Bike/5
        public BikeDto Get(int id)
        {
            var bike = _bikeBll.Get(id);
            return Mapper.Map<BikeDto>(bike);
        }


        // POST: api/Bike
        public void Post([FromBody]BikeDto value)
        {
        }

        // PUT: api/Bike/5
        public void Put(int id, [FromBody]BikeDto value)
        {
        }

        // DELETE: api/Bike/5
        public void Delete(int id)
        {
        }

    }
}
