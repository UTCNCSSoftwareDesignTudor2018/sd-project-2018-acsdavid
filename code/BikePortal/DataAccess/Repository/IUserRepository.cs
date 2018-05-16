using System;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// return the domain user corresponding to a login userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User Get(string userId);
    }
}
