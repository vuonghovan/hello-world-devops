using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace HelloWorld.Selenium
{
    [TestFixture]
    public class AutomatedUITests : IDisposable
    {
        private IWebDriver _driver;
        private string _url = "https://qa-hello-world.azurewebsites.net/home/create";

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void Create_WhenExecuted_Return_RedirectToIndex()
        {
            string strTestInValid = "Azure DevOps Sharing!";
            string strTestValid = "Azure DevOps!";
            _driver.Navigate().GoToUrl(_url);

            //Act
            _driver.FindElement(By.Id("Name")).SendKeys(strTestValid);
            _driver.FindElement(By.Id("btnCreate")).Click();

            var element = _driver.FindElement(By.Id("Name"));
            //Assert
            Assert.AreEqual(strTestValid, element.GetAttribute("value"));
        }
    }
}
