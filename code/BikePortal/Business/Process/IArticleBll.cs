using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;

namespace BikePortal.Business.Process
{
    public interface IArticleBll<T> where T : Article
    {
        T Get(int id);
        IList<T> GetAll();
        void Add(T article);
        void Update(T article);
        void Delete(T article);
        void AddComment(T article, Comment comment);
    }
}
