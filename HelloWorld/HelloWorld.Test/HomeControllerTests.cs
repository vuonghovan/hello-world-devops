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
        public void Create_ViewState_Is_Valid_Returns_RedirectToRouteResult()
        {
            // Arrage
            _homeController.ViewData.ModelState.Clear();

            CreateViewModel viewModel = new CreateViewModel()
            {
                Name = "Hello World"
            };

            // Act
            var actual = _homeController.Create(viewModel) as RedirectToActionResult;

            //Asset
            Assert.AreEqual("Index", actual.ActionName);
        }
    }
}
