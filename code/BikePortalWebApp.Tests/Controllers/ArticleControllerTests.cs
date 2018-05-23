using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikePortalWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using BikePortal.DataAccess;
using BikePortalWebApp.Mappers;
using BikePortalWebApp.Models.BindingModel;
using Moq;
using Unity;

namespace BikePortalWebApp.Controllers.Tests
{
    [TestClass()]
    public class ArticleControllerTests
    {
        [TestMethod()]
        public void PostPutInShoppingCartTest()
        {
            Database.SetInitializer(new BikePortalDbTestInitializer());
            var container = UnityConfig.Container;
            var bikeBll = container.Resolve<IBikeBll>();
            var userBll = new Mock<IUserBll>();
            var mapper = BikePortalMapper.Create();
            var articleController = new BikeController(bikeBll, mapper, userBll.Object);
            articleController.Request = new HttpRequestMessage();

            var bikes = articleController.Get();
            var firstBikeId = bikes.First().Id;
            var comments = articleController.GetComments(firstBikeId).ToList();

            var user = User.Create("name", "name");
            userBll.Setup(u => u.GetUser(It.IsAny<string>())).Returns(user);

            var commentText = "hello wordl";

            var commentBindingModel = new CommentBindingModel
            {
                CommentText = commentText
            };

            var responseTask = articleController.PostComment(firstBikeId, commentBindingModel);
            var message = responseTask.ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(message.StatusCode, HttpStatusCode.OK);

            var updatedBikeComments = articleController.GetComments(firstBikeId).ToList();
            Assert.AreEqual(comments.Count() + 1, updatedBikeComments.Count());
        }
    }
}