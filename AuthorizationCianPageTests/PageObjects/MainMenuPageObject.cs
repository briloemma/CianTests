using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.PageObjects
{
    public class MainMenuPageObject:BasePageObject
    {
        private readonly By _signInButton = By.XPath("//span[text()='Войти']");
        private readonly By _personalAccountButton = By.CssSelector("a[data-name='UserAvatar']");
        private readonly By _userLogin = By.XPath("//div[contains(@class,'-user-name-')]");
        private readonly By _rentButton = By.XPath("//a[contains(@href, 'snyat')]");
        private readonly By _mortgageButton = By.XPath("//a[contains(@href, 'ipoteka-main')]");
        private readonly By _wrongMortgageButton = By.XPath("//a[contains(@href, 'ipoteka-mainnn')]");
        private readonly string _mortgage = "ipoteka";
        private readonly By _allTheTabs = By.CssSelector("nav-item");
        private readonly By _magazineButton = By.CssSelector("a[href='/magazine/']");

        public MainMenuPageObject(IWebDriver webDriver):base (webDriver, By.XPath("//div[contains(@class, 'content-overlay')]"))
        {
        }
       
        public AuthorizationPageObject SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();

            return new AuthorizationPageObject(_webDriver);
        }
       
        public string GetUserLogin ()
        {
            WaitUntil.WaitUntilElementIsVisibleAndClickable(_webDriver, _personalAccountButton);
             _webDriver.FindElement(_personalAccountButton).Click();
            WaitUntil.WaitUntilElementIsVisibleAndClickable(_webDriver, _userLogin);
            string userLogin = _webDriver.FindElement(_userLogin).Text;
            return userLogin;
        }
        public ChooseRealtorPageObject NavigatetoDealTypes()
        {
            _webDriver.FindElement(_rentButton).Click();
            return new ChooseRealtorPageObject(_webDriver);
        }
        public MainMenuPageObject NavigateToMagazineTab()
        {
            _webDriver.FindElement(_magazineButton).Click();
            return this;
        }
        //1 способ проверки присутствия веб-элемента на странице
        public bool CheckPresenceOfMortgageTab1 ()
        {
            try
            {
                _webDriver.FindElement(_mortgageButton);
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }
        //2 способ проверки присутствия веб-элемента на странице
        public bool CheckPresenceOfMortgageTab2()
        {
            try
            {
                _webDriver.PageSource.Contains(_mortgage);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool CheckPresenceOfMortgageTab3 () =>
        _webDriver.PageSource.Contains(_mortgage);

        //3 способ проверки присутствия веб-элемента на странице
        public MainMenuPageObject NavigateToMortgage ()
        {
            _webDriver.FindElement(_wrongMortgageButton).Click();
            return this;
        }
        //4 способ проверки присутствия веб-элемента на странице
        public List<string> AllTheTabsText =>
        _webDriver.FindElements(_allTheTabs).Select(x => x.Text).ToList();

    }
}
