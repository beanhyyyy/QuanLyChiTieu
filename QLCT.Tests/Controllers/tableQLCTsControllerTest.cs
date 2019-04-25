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

            var result0 = controller.Edit(0);

            //Test Edit

            //Test Edit khong ton tai
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            //Khai bao item dau cua table
            var item = db.tableQLCTs.First();

            //Khai bao view va ep kieu thanh view cua edit id
            var result1 = controller.Edit(item.id) as ViewResult;

            //Test co hien dc result1
            Assert.IsNotNull(result1);

            //Khai bao model
            var model = result1.Model as tableQLCT;

            //Test model co hien dc
            Assert.IsNotNull(model);

            //Test id of item = id of model
            Assert.AreEqual(item.id, model.id);
        }
    }
}
