using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using BikePortalWebApp.Models;
using BikePortalWebApp.Models.BindingModel;
using BikePortalWebApp.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace BikePortalWebApp.Controllers
{
    public class ArticleController<T> : BikePortalController
         where T : Article
    {
        private readonly IArticleBll<T> _articleBll;
        protected readonly IMapper Mapper;

        public ArticleController(IArticleBll<T> articleBll, IUserBll userBll, IMapper mapper) : base(userBll)
        {
            _articleBll = articleBll;
            Mapper = mapper;
        }

        // GET: api/Article/5/GetUploader
        public UserViewModel GetUploader(int id)
        {
            var article = _articleBll.Get(id);
            return Mapper.Map<UserViewModel>(article.Uploader);
        }

        // POST: api/Article/5/PutInShoppingCart
        [Authorize]
        public IHttpActionResult PostPutInShoppingCart(int id)
        {
            var article = _articleBll.Get(id);
            if (article == null)
            {
                return BadRequest("no such article");
            }
            var user = GetDomainUser();
            Debug.Assert(user != null);
            UserBll.PutInShoppingCart(user, article);
            return Ok();
        }

        // GET: api/Article/5/GetComments
        public IEnumerable<CommentViewModel> GetComments(int id)
        {
            var article = _articleBll.Get(id);
            return article.Comments.Select(c => Mapper.Map<CommentViewModel>(c));
        }

        // POST: api/Article/5/PostComment
        public IHttpActionResult PostComment(int id, [FromBody] CommentBindingModel commentForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = Mapper.Map<Comment>(commentForm);
            var article = _articleBll.Get(id);
            _articleBll.AddComment(article, comment);
            return Ok();
        }
    }
}
