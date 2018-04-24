using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BikePortal.Business.Entity;

namespace BikePortal.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IBikePortalDbContext _dbContext;

        public UserRepository(IBikePortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Get(User toGet)
        {
            return Get(toGet.Id);
        }

        public User Get(int id)
        {
            return _dbContext.DomainUsers.FirstOrDefault(u => u.Id == id);
        }

        public IList<User> GetAll()
        {
            return _dbContext.DomainUsers.ToList();
        }

        public void Insert(User toInsert)
        {
            _dbContext.DomainUsers.Add(toInsert);
            _dbContext.SaveChanges();
        }

        public void Update(User toUpdate)
        {
            _dbContext.DomainUsers.AddOrUpdate(toUpdate);
            _dbContext.SaveChanges();
        }

        public void Delete(User toDelete)
        {
            _dbContext.DomainUsers.Remove(toDelete);
            _dbContext.SaveChanges();
        }
    }
}