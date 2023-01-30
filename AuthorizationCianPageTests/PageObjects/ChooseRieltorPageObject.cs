using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.PageObjects
{
    public class ChooseRealtorPageObject:BasePageObject
    {
        private readonly By _chooseRieltorButton = By.XPath("//a[@href='/podbor-rieltora/']");
        private readonly By _sortbyDealTypeButton = By.XPath("//button[contains(@data-testid, 'dealType_')]");
        private readonly By _AllDealTypes = By.CssSelector("ul li button");
        public ChooseRealtorPageObject(IWebDriver webDriver) : base(webDriver, By.XPath("//div[contains(@class, 'content-overlay')]"))
        {
        }
        public void SearchbyDealType (string dealType)
        {
            WaitUntilPageIsDispayed();
            _webDriver.FindElement(_chooseRieltorButton).Click();
            _webDriver.FindElement(_sortbyDealTypeButton).Click();

            var sortbyDealType=_webDriver.FindElements(_AllDealTypes).First(x => x.Text == dealType);
            sortbyDealType.Click();

            return;
        }
        
    }
}
