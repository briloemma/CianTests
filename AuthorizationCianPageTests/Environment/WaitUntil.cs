using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AuthorizationCianPageTests
{
    public static class WaitUntil
    {
        /*public static IWebElement GetElementIfDisplayed(IWebDriver webDriver, By locator, string errorMessage ="Element is not found")
        {

            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(10));
            try
            {
                return wait.Until(driver =>
                {
                    IWebElement webElement = driver.FindElement(locator);
                    if (!webElement.Displayed)
                    {
                        throw new Exception();
                    }
                    return webElement;
                });
            }
            catch
            {
                throw new NotFoundException(errorMessage);
            }
        }*/

        public static void WaitSomeInterval (int seconds=5)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static void WaitUntilElementIsClickable (IWebDriver webDriver, By locator, int seconds = 10)
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitUntilElementIsVisible(IWebDriver webDriver, By locator, int seconds = 10)
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitUntilElementIsVisibleAndClickable(IWebDriver webDriver, By locator, int seconds=10)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        /*public static void WaitUntilElementIsLocated(IWebDriver webDriver, string locator)
        {
            try
            {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.UrlContains(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"{locator} is not found", ex);
            }
        }
*/
    }
}
