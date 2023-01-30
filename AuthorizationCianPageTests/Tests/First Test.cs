using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AuthorizationCianPageTests.Tests
{
    public class FirstTest
    {
        private IWebDriver driver;
        private readonly By _signInButton = By.XPath("//span[text()='Войти']");
        private readonly By _emailSignInButton = By.XPath("//span[text()='Другим способом']");
        private readonly By _userName = By.XPath("//input[@name='username']");
        private readonly By _password = By.XPath("//input[@name='password']");
        private readonly By _continueAuthorizationButton = By.XPath("//button[@data-name='ContinueAuthBtn']");
        private readonly By _enterButton = By.XPath("//button[@data-name='ContinueAuthBtn']");
        private readonly By _userLogin = By.XPath("//a[contains(@class,'-full-name-')]");
        private readonly By _personalAccountButton = By.CssSelector("a[data-name='UserAvatar']");

        private const string _expectedLogin = "ID 97257861";
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.cian.ru");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
       }

        [Test]
        public void BasicLoginTest()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();
            var emailSignIn = driver.FindElement(_emailSignInButton);
            emailSignIn.Click();
            var userName = driver.FindElement(_userName);
            userName.SendKeys("briloemma@gmail.com");
            var continueAuthorization = driver.FindElement(_continueAuthorizationButton);
            continueAuthorization.Click();
            var password = driver.FindElement(_password);
            password.SendKeys("yvessaint1");
            var enterButton = driver.FindElement(_enterButton);
            enterButton.Click();
            var personalAccount = driver.FindElement(_personalAccountButton);
            personalAccount.Click();
            var userLogin = driver.FindElement(_userLogin).Text;
            Assert.AreEqual(_expectedLogin, userLogin, "Error");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}