using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnovaBooster.Database;
using UnovaBooster.Entities;
using UnovaBooster.WebDriverActions;

namespace UnovaBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                LogInActions.Login(driver);

                driver.Navigate().GoToUrl("https://www.unovarpg.com/pokemon_locator.php");

                Pokemon Solgaleo = new Pokemon();

                using (var db = new PokeContext())
                {
                    Solgaleo = db.Pokemons.FirstOrDefault(x => x.Name == "Electabuzz");
                }

                NavigationActions.FindPokemon(driver, new Uri("https://www.unovarpg.com/map.php?map=6"), Solgaleo, Enums.SpecialType.Shiny, true);
                Console.ReadLine();
            }
        }
    }
}
