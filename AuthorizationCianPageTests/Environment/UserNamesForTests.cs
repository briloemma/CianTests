using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests.Tests
{
    internal class UserNamesForTests
    {
        private IWebDriver _webDriver;
        public static string Login { get; set; } = "briloemma@gmail.com";
        public static string Password { get; set; } = "yvessaint1";
        public static string ExpectedLogin { get; set; } = "ID 97257861";

    }
}
