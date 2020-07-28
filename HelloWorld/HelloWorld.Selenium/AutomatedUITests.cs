using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Selenium
{
    [TestClass]
    public class AutomatedUITests : IDisposable
    {
        private IWebDriver _driver;

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [TestMethod]
        public void Create_WhenExecuted_Return_RedirectToIndex()
        {
            // Init
            string strTestInValid = "Azure DevOps Sharing!";
            string strTestValid = "Azure DevOps!";

            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://qa-hello-world.azurewebsites.net/home/create");

            //Action
            _driver.FindElement(By.Id("Name")).SendKeys(strTestValid);
            _driver.FindElement(By.Id("btnCreate")).Click();

            var element = _driver.FindElement(By.Id("Name"));
            Assert.AreEqual(strTestValid, element.GetAttribute("value"));
        }
    }
}
