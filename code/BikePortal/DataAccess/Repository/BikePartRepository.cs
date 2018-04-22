using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess.Repository
{
    public class BikePartRepository : IBikePartRepository
    {
        private readonly IBikePortalDbContext _dbContext;

        public BikePartRepository(IBikePortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BikePart Get(BikePart toGet)
        {
            return Get(toGet.Id);
        }

        public BikePart Get(int id)
        {
            return _dbContext.BikeParts.FirstOrDefault(bp => bp.Id == id);
        }

        public IList<BikePart> GetAll()
        {
            return _dbContext.BikeParts.ToList();
        }

        public void Insert(BikePart toInsert)
        {
            _dbContext.BikeParts.Add(toInsert);
            _dbContext.SaveChanges();
        }

        public void Update(BikePart toUpdate)
        {
            _dbContext.BikeParts.AddOrUpdate(toUpdate);
            _dbContext.SaveChanges();
        }

        public void Delete(BikePart toDelete)
        {
            _dbContext.BikeParts.Remove(toDelete);
            _dbContext.SaveChanges();
        }
    }
}