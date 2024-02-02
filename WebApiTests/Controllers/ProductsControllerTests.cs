using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models.Entity;

namespace WebApi.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            var db = new NorthwindContext();
            var result= new ProductsController(db).Calculate(5,2);
            Assert.AreEqual<int>(83, result);
        }
    }
}