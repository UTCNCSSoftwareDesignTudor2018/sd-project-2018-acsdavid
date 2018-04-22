using BikePortal.Business.Entity;

namespace BikePortal.DataAccess.Repository
{
    public interface IArticleRepository<T> : IGenericRepository<T> 
        where T : Article
    {
    }
}