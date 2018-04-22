using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using BikePortalWebApp.Models;

namespace BikePortalWebApp.Controllers
{
    public class ArticleController<T> : ApiController 
         where T : Article
    {
        private readonly ArticleBll<T> _articleBll;
        protected readonly IMapper Mapper;

        public ArticleController(ArticleBll<T> articleBll, IMapper mapper)
        {
            _articleBll = articleBll;
            Mapper = mapper;
        }

        // GET: api/Article/5/GetUploader
        public UserDto GetUploader(int id)
        {
            var article = _articleBll.Get(id);
            return Mapper.Map<UserDto>(article.Uploader);
        }

        // GET: api/Article/5/GetComments
        public IEnumerable<CommentDto> GetComments(int id)
        {
            var article = _articleBll.Get(id);
            return article.Comments.Select(c => Mapper.Map<CommentDto>(c));
        }

        // POST: api/Article/5/PostComment
        public void PostComment(int id, [FromBody] CommentFormDto commentForm)
        {
            var comment = Mapper.Map<Comment>(commentForm);
            var article = _articleBll.Get(id);
            _articleBll.AddComment(article, comment);
        }
    }
}
