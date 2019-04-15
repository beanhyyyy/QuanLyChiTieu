using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLCT.Controllers;
using QLCT.Models;

namespace QLCT.Tests.Controllers
{
    [TestClass]
    public class tableQLCTsControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new databaseQLCTEntities();
            // Arrange
            var controller = new tableQLCTsController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert co hien dc list
            Assert.IsNotNull(result);

            //Co hien dung list
            Assert.IsInstanceOfType(result.Model, typeof(List<tableQLCT>));

            //Co hien het list
            Assert.AreEqual(db.tableQLCTs.Count(), (result.Model as List<tableQLCT>).Count());

            
        }
    }
}
