using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikePortalWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using BikePortalWebApp.Mappers;
using BikePortalWebApp.Models;
using BikePortalWebApp.Models.BindingModel;
using Microsoft.AspNet.Identity;
using Moq;

namespace BikePortalWebApp.Controllers.Tests
{
    [TestClass()]
    public class BikeControllerTests
    {

        [TestMethod()]
        public void PostTest()
        {
            // Arrange
            var mockBikeBll = new Mock<IBikeBll>();
            var mapper = BikePortalMapper.Create();
            var mockUserBll = new Mock<IUserBll>();
            var mockUser = new Mock<User>();

            mockUserBll.Setup(u => u.GetUser(It.IsAny<string>())).Returns(mockUser.Object);
            var controller = new BikeController(mockBikeBll.Object, mapper, mockUserBll.Object);

            const string description = "Wonderful bike";
            const string model = "Model";
            const string name = "Name";
            const decimal price = 123M;

            // Act

            var bindingModel = new BikeBindingModel
            {
                Description = description,
                Model = model,
                Name = name,
                Price = price
            };
            controller.Post(bindingModel);

            // Assert

            var bike = new Bike
            {
                Id = 0,
                Uploader = mockUser.Object,
                Comments = new List<Comment>(),
                Description = description,
                Model = model,
                Name = name,
                Price = price
            };
            mockBikeBll.Verify(m => m.Add(bike));
        }
    }
}