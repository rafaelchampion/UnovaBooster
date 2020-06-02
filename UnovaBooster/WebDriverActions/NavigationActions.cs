using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnovaBooster.Entities;
using UnovaBooster.Helpers;

namespace UnovaBooster.WebDriverActions
{
    public static class NavigationActions
    {
        public const string NavigationPanelXpath = "//div[@id='navigationBackground']";
        public const string PokemonPanelXpath = "//div[@class='event-screen']";
        public const string PokemonEventContainerXpath = "tab-container";

        public static void FindPokemon(IWebDriver driver, Uri mapUri, Pokemon pokemon, Enums.SpecialType specialType = Enums.SpecialType.Normal, bool capture = false)
        {
            bool PokemonNotFound = true;
            driver.Navigate().GoToUrl(mapUri);
            string currentURL = driver.Url;
            while (currentURL != mapUri.ToString())
            {
                driver.Navigate().GoToUrl(mapUri);
                currentURL = driver.Url;
            }
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(240));
            var loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(NavigationPanelXpath)));
            while (PokemonNotFound)
            {
                var navigationPanel = driver.FindElement(By.TagName("body"));
                navigationPanel.SendKeys(RandomNavigator.RandomizeKeypress());
                Thread.Sleep(25);
                var eventScreen = driver.FindElement(By.XPath(PokemonPanelXpath));
                var foundPokemonInfo = eventScreen.FindElements(By.ClassName(PokemonEventContainerXpath));
                if (foundPokemonInfo.Count > 0)
                {
                    var foundPokemonText = foundPokemonInfo[0].FindElement(By.TagName("strong")).Text;
                    var foundPokemonName = foundPokemonText.Substring(foundPokemonText.IndexOf("Selvagem") + 8, foundPokemonText.Length - 17).Replace("shiny", "").Replace("golden", "").Replace("mystic", "").Replace("dark", "").Trim();
                    var foundSpecialType = GetSpecialTypeByPokemonName(foundPokemonText.Replace(foundPokemonName, ""));
                    if (foundSpecialType == specialType && foundPokemonName == pokemon.Name)
                    {
                        PokemonNotFound = false;
                    }
                }
            }
            if (capture)
            {
                CapturePokemon(driver);
            }
        }

        public static void CapturePokemon(IWebDriver driver)
        {
            var fightContainerXPath = "//div[@class='fight-container']";
            var fightContainerElement = driver.FindElement(By.XPath(fightContainerXPath));
            var fightButton = fightContainerElement.FindElement(By.TagName("button"));
            fightButton.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(240));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[@id='UseItemButton']")));
            Thread.Sleep(5000);
            var itemButton = driver.FindElement(By.XPath("//button[@id='UseItemButton']"));
            itemButton.Click();
            Thread.Sleep(5000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='itemSelectBox']")));
            var itemList = driver.FindElement(By.XPath("//div[@class='itemSelectBox']"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[descendant::strong[text()='Master Ball']]")));
            var masterBallButton = itemList.FindElement(By.XPath("//a[descendant::strong[text()='Master Ball']]"));
            masterBallButton.Click();
            Thread.Sleep(100);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[@id='Back2MapButton']")));
        }

        public static Enums.SpecialType GetSpecialTypeByPokemonName(string foundPokemonText)
        {
            var isShiny = foundPokemonText.ToUpper().Contains("SHINY");
            var isGolden = foundPokemonText.ToUpper().Contains("GOLDEN");
            var isMetallic = foundPokemonText.ToUpper().Contains("METALLIC");
            var isMystic = foundPokemonText.ToUpper().Contains("MYSTIC");
            var isDark = foundPokemonText.ToUpper().Contains("DARK");
            var isNormal = (!isShiny && !isGolden && !isMetallic && !isMystic && !isDark);
            if (isShiny)
            {
                return Enums.SpecialType.Shiny;
            }
            else if (isGolden)
            {
                return Enums.SpecialType.Golden;
            }
            else if (isMetallic)
            {
                return Enums.SpecialType.Metallic;
            }
            else if (isMystic)
            {
                return Enums.SpecialType.Mystic;
            }
            else if (isDark)
            {
                return Enums.SpecialType.Dark;
            }
            else
            {
                return Enums.SpecialType.Normal;
            }
        }
    }
}
