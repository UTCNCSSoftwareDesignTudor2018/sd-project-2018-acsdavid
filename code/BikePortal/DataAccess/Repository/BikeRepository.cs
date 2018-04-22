using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess.Repository
{
    public class BikeRepository : IBikeRepository
    {
        private readonly IBikePortalDbContext _dbContext;

        public BikeRepository(IBikePortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Bike Get(Bike toGet)
        {
            return Get(toGet.Id);
        }

        public Bike Get(int id)
        {
            return _dbContext.Bikes.FirstOrDefault(b => b.Id == id);
        }

        public IList<Bike> GetAll()
        {
            return _dbContext.Bikes.ToList();
        }

        public void Insert(Bike toInsert)
        {
            _dbContext.Bikes.Add(toInsert);
            _dbContext.SaveChanges();
        }

        public void Update(Bike toUpdate)
        {
            _dbContext.Bikes.AddOrUpdate(toUpdate);
            _dbContext.SaveChanges();
        }

        public void Delete(Bike toDelete)
        {
            _dbContext.Bikes.Remove(toDelete);
            _dbContext.SaveChanges();
        }
    }
}