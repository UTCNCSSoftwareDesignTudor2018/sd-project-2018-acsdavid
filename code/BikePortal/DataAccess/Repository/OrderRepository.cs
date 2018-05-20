using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IBikePortalDbContext _dbContext;

        public OrderRepository(IBikePortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order Get(Order toGet)
        {
            return Get(toGet.Id);
        }

        public Order Get(int id)
        {
            return _dbContext.Orders.First(o => o.Id == id);
        }

        public IList<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public void Insert(Order toInsert)
        {
            _dbContext.Orders.Add(toInsert);
            _dbContext.SaveChanges();
        }

        public void Update(Order toUpdate)
        {
            _dbContext.Orders.AddOrUpdate(toUpdate);
            _dbContext.SaveChanges();
        }

        public void Delete(Order toDelete)
        {
            _dbContext.Orders.Remove(toDelete);
            _dbContext.SaveChanges();
        }
    }
}