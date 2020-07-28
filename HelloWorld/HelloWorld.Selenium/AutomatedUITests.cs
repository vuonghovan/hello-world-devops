using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace HelloWorld.Selenium
{
    public class AutomatedUITests : IDisposable
    {
        private IWebDriver _driver;

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Create_WhenExecuted_Return_RedirectToIndex()
        {
            // Init
            string strTestInValid = "Azure DevOps Sharing!";
            string strTestValid = "Azure DevOps!";

            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://qa-hello-world.azurewebsites.net/");

            //Action
            _driver.FindElement(By.Id("Name")).SendKeys(strTestValid);
            _driver.FindElement(By.Id("btnCreate")).Click();

            // Assert
            var element = _driver.FindElement(By.Id("Name"));
            Assert.NotNull(element);
            Assert.Equal(strTestValid, element.GetAttribute("value"));
        }
    }
}
