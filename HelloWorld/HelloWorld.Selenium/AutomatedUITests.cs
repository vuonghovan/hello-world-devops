using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using OpenQA.Selenium.Support.UI;

namespace HelloWorld.Selenium
{
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;


        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
   //     https://swimburger.net/blog/dotnet/how-to-ui-test-using-selenium-and-net-core-on-windows-ubuntu-and-maybe-macos
        [Fact]
        public void Create_WhenExecuted_Return_RedirectToIndex()
        {
            _driver.Navigate().GoToUrl("https://localhost:44305/home/create/");
            _driver.FindElement(By.ClassName("name")).SendKeys("name");
            //_driver.FindElement(By.Id("btnCreate")).Click();

            //Assert.Equal("Create - EmployeesApp", _driver.Title);
            //Assert.Contains("Please provide a new employee data", _driver.PageSource);
        }
    }
}
