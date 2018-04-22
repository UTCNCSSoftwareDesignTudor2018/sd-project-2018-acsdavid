using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;
using BikePortal.DataAccess.Repository;

namespace BikePortal.Business.Process
{
    public class BikeBll : ArticleBll<Bike>
    {
        public BikeBll(IBikeRepository repository) : base(repository)
        {
        }
    }
}
