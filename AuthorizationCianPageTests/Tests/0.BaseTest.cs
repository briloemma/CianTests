using AuthorizationCianPageTests.Environment;
using AuthorizationCianPageTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests
{
    public class BaseTest
    {
        protected IWebDriver _webdriver;

        [TearDown]
        protected void DoAfterEachTest()
        {
            _webdriver.Quit();
        }
        [SetUp]
        protected void DoBeforeEachTest()
        {
            _webdriver = new ChromeDriver();
            _webdriver.Manage().Cookies.DeleteAllCookies();
            _webdriver.Navigate().GoToUrl(TestSettings.HostPrefix);
            _webdriver.Manage().Window.Maximize();
            //добавить ожидание
        }
      
    }
}
