using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using BikePortalWebApp.Controllers;
using BikePortalWebApp.Mappers;
using BikePortalWebApp.Models.BindingModel;
using BikePortalWebApp.Models.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unity;

namespace BikePortalWebApp.Tests.Controllers
{
    [TestClass()]
    public class BikeControllerIntegration
    {

        [TestMethod()]
        public void PostTest()
        {
            var container = UnityConfig.Container;
            var bikeBll = container.Resolve<IBikeBll>();
            var userBll = new Mock<IUserBll>();
            var bikeController = new BikeController(bikeBll, BikePortalMapper.Create(), userBll.Object);
            bikeController.Request = new HttpRequestMessage();

            var user = User.Create("name", "name");
            userBll.Setup(u => u.GetUser(It.IsAny<string>())).Returns(user);

            var description = "description";
            var model = "model of bike";
            var price = 123M;
            var name = "name of bike";

            var bikeBindingModel = new BikeBindingModel
            {
                Description = description,
                Model = model,
                Price = price,
                Name = name
            };
            var responseTask = bikeController.Post(bikeBindingModel);
            var message = responseTask.ExecuteAsync(new CancellationToken()).Result;
            Assert.AreEqual(message.StatusCode, HttpStatusCode.OK);

            var bikeViewModel = bikeController.Get();
            Assert.IsTrue(bikeViewModel.Any());
        }
    }
}
