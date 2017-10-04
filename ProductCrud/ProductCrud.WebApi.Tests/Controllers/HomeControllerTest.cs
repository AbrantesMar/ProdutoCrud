using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCrud.WebApi;
using ProductCrud.WebApi.Controllers;

namespace ProductCrud.WebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
