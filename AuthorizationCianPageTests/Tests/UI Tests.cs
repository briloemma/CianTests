using AuthorizationCianPageTests.Environment;
using AuthorizationCianPageTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AuthorizationCianPageTests.Tests
{
    [TestFixture]
    public class UITests : BaseTest
    {
        [Test]

        public void BasicLoginPageObjectTest()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            var autho = new AuthorizationPageObject(_webdriver);
            mainMenu.SignIn();
            autho.Login(UserNamesForTests.Login, UserNamesForTests.Password);
            string actualLogin = mainMenu.GetUserLogin();
            Assert.AreEqual(UserNamesForTests.ExpectedLogin, actualLogin, "Error");
        }

        [Test]
        public void NavigatetoDealTypesTest()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            var chooseRieltor=new ChooseRealtorPageObject(_webdriver);
            mainMenu.NavigatetoDealTypes();
            chooseRieltor.SearchbyDealType(DealTypesNames.BySell);
        }

        [Test]
        public void CheckTheNewsDatesTest()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            var magazine = new MagazinePageObject(_webdriver);
            var magazineTab = mainMenu.NavigateToMagazineTab();
            var actualDate = magazine.GetListNewsDates().ToList();
            var expectedDate = actualDate.OrderByDescending(x => x);
            Assert.IsTrue(expectedDate.SequenceEqual(actualDate), "Error");
        }

        [Test]
        public void LoginAsNewUserTest()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            var autho = new AuthorizationPageObject(_webdriver);

            mainMenu.SignIn();
            autho.CreateNewUser(TestGenerateData.GenerateRandomEmail(NameDomain.Gmail),
                               TestGenerateData.GenerateRandomPassword(10),
                               TestGenerateData.GenerateRandomPhoneNumber(CountryCode.Belarus, 10));

        }
        [Test]
        public void CheckTabPresenceTest1()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            Assert.IsTrue(mainMenu.CheckPresenceOfMortgageTab1());
        }
        [Test]
        public void CheckTabPresenceTest2()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            Assert.IsTrue(mainMenu.CheckPresenceOfMortgageTab2());
        }
        [Test]
        public void CheckTabPresenceTest3()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            Assert.IsTrue(mainMenu.CheckPresenceOfMortgageTab3());
        }
        [Test]
        public void CheckTabPresenceTest4()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            Assert.Throws<NoSuchElementException>(() => mainMenu.NavigateToMortgage());
        }

        [Test]
        public void CheckTabPresenceTest5()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            Assert.That(mainMenu.AllTheTabsText, Has.No.Member(MainPageTabs.BuyTab));
        }

        [Test]
        public void PageLoadTimeTest()
        {
            var mainMenu = new MainMenuPageObject(_webdriver);
            var timeBefore = DateTime.Now;
            mainMenu.NavigateToMagazineTab();
            //добавить ожидание с expectedconditions
            var timeAfter = DateTime.Now;
            var loadTime = timeAfter - timeBefore;
            Assert.IsTrue(loadTime.Seconds < 3, "Page loading takes too much time");
        }


    }
}