using HelloWorld.Controllers;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Web.Http;

namespace HelloWorld.Test
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _homeController;

        [SetUp]
        public void Setup()
        {
            _homeController = new HomeController();
        }

        [Test]
        public void Index_Is_Valid_Return_View()
        {
            // Act 
            var result = _homeController.Index() as ViewResult;
            var model = result.Model as CreateViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Hello World", model.Name);
        }

        [Test]
        public void Post_Is_Valid_Return_Redirecto_To_Index()
        {
            var model = new CreateViewModel
            {
                Name = "Hello World",
            };

            // Act 
            var result = (RedirectToActionResult)_homeController.Create(model);

            //Assert
            Assert.AreEqual("Index", result.ActionName);
        }

    }
}
