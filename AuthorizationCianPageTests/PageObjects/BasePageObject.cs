using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.PageObjects
{
    public abstract class BasePageObject
    {
        private readonly By _locator;
        public readonly IWebDriver _webDriver;
        public BasePageObject (IWebDriver sdaa,  By locator)
        {
            _locator = locator;
            _webDriver = sdaa;
        }
        public void WaitUntilPageIsDispayed()
        {
            //WaitUntil.GetElementIfDisplayed(_webDriver,_locator, $"{GetType().Name} is not found");
            WaitUntil.WaitUntilElementIsVisibleAndClickable(_webDriver, _locator);
        }
        public void WaitSomeInterval(int seconds = 5)
        {
            WaitUntil.WaitSomeInterval(seconds);
        }
        public void WaitUntilElementIsClickable()
        {
            WaitUntil.WaitUntilElementIsClickable(_webDriver, _locator);
        }
        public void WaitUntilElementIsVisible()
        {
            WaitUntil.WaitUntilElementIsVisible(_webDriver, _locator);
        }
        public void WaitUntilElementIsVisibleAndClickable ()
        {
            WaitUntil.WaitUntilElementIsVisibleAndClickable(_webDriver, _locator);
        }


    }
}
