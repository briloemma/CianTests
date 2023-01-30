using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.PageObjects
{
    public class AuthorizationPageObject:BasePageObject
    {
        private readonly By _emailSignInButton = By.XPath("//span[text()='Другим способом']");
        private readonly By _emailInput = By.XPath("//input[@name='username']");
        private readonly By _passwordInput = By.XPath("//input[@name='password']");
        private readonly By _continueAuthorizationButton = By.XPath("//button[@data-name='ContinueAuthBtn']");
        private readonly By _enterButton = By.XPath("//button[@data-name='ContinueAuthBtn']");
        private readonly By _acceptPoliciesCheckBox = By.XPath("//div[contains(@class,'row--first')]//span[contains(@class,'-box-')]");
        private readonly By _continueRegistrationButton = By.CssSelector("button[data-name='ContinueBtn']");
        private readonly By _newPasswordForNewUser = By.CssSelector("input[autocomplete='new-password']");
        private readonly By _phoneNumber = By.CssSelector("input[autocomplete='tel']");
        private readonly By _registrationButton = By.CssSelector("button[data-name='ContinueAuthBtn']");
        public AuthorizationPageObject(IWebDriver webdriver):base (webdriver, By.XPath("//div[contains(@class, 'container')]"))
        {
        }
        
        public MainMenuPageObject Login (string login, string password)
        {
            _webDriver.FindElement(_emailSignInButton).Click();
            _webDriver.FindElement(_emailInput).SendKeys(login);
            _webDriver.FindElement(_continueAuthorizationButton).Click();
            WaitUntil.WaitUntilElementIsVisibleAndClickable(_webDriver, _passwordInput);
            _webDriver.FindElement(_passwordInput).SendKeys(password);
            _webDriver.FindElement(_enterButton).Click();
            return new MainMenuPageObject(_webDriver);
           
        }
        public MainMenuPageObject CreateNewUser(string login, string password, string phoneNumber)
        {
            _webDriver.FindElement(_emailSignInButton).Click();
            _webDriver.FindElement(_emailInput).SendKeys(login);
            _webDriver.FindElement(_continueAuthorizationButton).Click();
            WaitUntil.WaitUntilElementIsVisibleAndClickable(_webDriver, _acceptPoliciesCheckBox);
            _webDriver.FindElement(_acceptPoliciesCheckBox).Click();
            _webDriver.FindElement(_continueRegistrationButton).Click();
            WaitUntil.WaitUntilElementIsVisibleAndClickable(_webDriver, _newPasswordForNewUser);
            _webDriver.FindElement(_newPasswordForNewUser).SendKeys(password);
            _webDriver.FindElement(_phoneNumber).SendKeys(phoneNumber);
            WaitUntil.WaitUntilElementIsVisibleAndClickable(_webDriver, _registrationButton);
            _webDriver.FindElement(_registrationButton).Click();
            return new MainMenuPageObject(_webDriver);

        }
    }
}
