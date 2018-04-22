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
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public IList<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public void Insert(User toInsert)
        {
            _dbContext.Users.Add(toInsert);
            _dbContext.SaveChanges();
        }

        public void Update(User toUpdate)
        {
            _dbContext.Users.AddOrUpdate(toUpdate);
            _dbContext.SaveChanges();
        }

        public void Delete(User toDelete)
        {
            _dbContext.Users.Remove(toDelete);
            _dbContext.SaveChanges();
        }
    }
}