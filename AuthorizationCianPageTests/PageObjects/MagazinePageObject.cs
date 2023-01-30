using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.PageObjects
{
    public class MagazinePageObject:BasePageObject
    {
        private IWebDriver _webDriver;
        
        public  MagazinePageObject (IWebDriver webDriver):base (webDriver, By.XPath("//div[contains(@class,'-list-header-')]"))
        {
            _webDriver = webDriver;
        }
        private readonly By _alltheDates = By.CssSelector("span[itemprop='datePublished']");
        public IEnumerable<DateTime>GetListNewsDates()
        {
            return _webDriver
                .FindElements(_alltheDates)
                .Select(x => DateTime.Parse(x.Text));
        }
    }
}
