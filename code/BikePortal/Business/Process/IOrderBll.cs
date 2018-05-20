using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.Business.Process
{
    public interface IOrderBll
    {
        IList<Order> GetAll();
        Order Get(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
