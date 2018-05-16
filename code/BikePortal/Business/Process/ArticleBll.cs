using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikePortal.Business.Entity;
using BikePortal.DataAccess.Repository;

namespace BikePortal.Business.Process
{
    public class ArticleBll<T> : IArticleBll<T> where T : Article
    {
        private readonly IArticleRepository<T> _repository;

        public ArticleBll(IArticleRepository<T> repository)
        {
            _repository = repository;
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(T article)
        {
            _repository.Insert(article);
        }

        public void Update(T article)
        {
            _repository.Update(article);
        }

        public void Delete(T article)
        {
            _repository.Delete(article);
        }

        public void AddComment(T article, Comment comment)
        {
            article.Comments.Add(comment);
            Update(article);
        }
    }
}
