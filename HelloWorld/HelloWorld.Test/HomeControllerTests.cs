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
            string strTestInValid = "This is case of invalid!";
            string strTestValid = "Azure DevOps!";

            // Act 
            var result = _homeController.Index() as ViewResult;
            var model = result.Model as CreateViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(strTestInValid, model.Name);
        }

        [Test]
        public void Post_Is_Valid_Return_Redirecto_To_Index()
        {
            string strTestInValid = "Azure DevOps Sharing!";
            string strTestValid = "Azure DevOps!";

            var model = new CreateViewModel
            {
                Name = strTestValid,
            };

            // Act 
            var result = _homeController.Create(model);

            //Assert
            Assert.IsTrue(result is RedirectToActionResult);
            Assert.AreEqual("Edit", ((RedirectToActionResult)result).ActionName);
        }

    }
}
