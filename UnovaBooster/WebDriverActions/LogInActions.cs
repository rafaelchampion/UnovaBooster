using OpenQA.Selenium;
using OpenQA.Selenium.Html5;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnovaBooster.WebDriverActions
{
    public static class LogInActions
    {
        public static readonly Uri LoginURI =  new Uri("https://www.unovarpg.com/login.php");
        public const string Username = "RAZlEL";
        public const string Password = "rafaelx-atmo928139";
        public const string UsernameElementXpath = "//*[@id='username']";
        public const string PasswordElementXpath = "//*[@id='password']";
        public const string LoginButtonElementXpath = "//*[@id='buttonLogin']";

        public static void Login(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(LoginURI);
            driver.FindElement(By.XPath(UsernameElementXpath)).SendKeys(Username);
            driver.FindElement(By.XPath(PasswordElementXpath)).SendKeys(Password);
            driver.FindElement(By.XPath(LoginButtonElementXpath)).Click();
        }
    }
}
