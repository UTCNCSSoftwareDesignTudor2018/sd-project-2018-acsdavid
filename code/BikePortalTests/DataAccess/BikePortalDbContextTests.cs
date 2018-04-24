using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikePortal.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.DataAccess.Tests
{
    [TestClass()]
    public class BikePortalDbContextTests
    {
        [TestMethod()]
        public void BikePortalDbContextTest()
        {
            var dbContext = new BikePortalDbContext();
            Database.SetInitializer(new BikePortalDbTestInitializer());
            var users = dbContext.DomainUsers.ToList();
            Assert.IsTrue(users.Count > 0);
        }
    }
}