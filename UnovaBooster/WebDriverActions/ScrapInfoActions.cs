using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnovaBooster.Database;
using UnovaBooster.DatabaseActions;
using UnovaBooster.Entities;
using UnovaBooster.Enums;
using SeleniumExtras.WaitHelpers;

namespace UnovaBooster.WebDriverActions
{
    public static class ScrapInfoActions
    {
        /*URLs*/
        #region URLS
        private static readonly Uri StartingPokedexIndex = new Uri("https://www.unovarpg.com/pokedex/bulbasaur.html");
        private static readonly Uri PokemonTeamPage = new Uri("https://www.unovarpg.com/setup_team.php");
        #endregion

        /*Consts*/
        #region Consts
        #region Pokedex
        private const string PokemonNameIDXpath = "//div[@class='memberPanelTable'][1]//h2[1]";
        private const string PokemonTypesXpath = "//div[@class='memberPanelTable'][1]/div[1]/div[1]/img";
        private const string PokemonBaseStatsTableElementsXpath = "//table[preceding-sibling::p[text()='Status']][1]/tbody/tr[2]/td";
        private const string PokemonMaxStatsTableElementsXpath = "//table[preceding-sibling::p[text()='Status']][2]/tbody/tr[2]/td";
        private const string PokemonMovesByLevelElementsXpath = "//div[preceding-sibling::p[text()='Ataques de Nível'] and following-sibling::p[text()='Ataques por TM / HM'] and not(@class='clear')]";
        private const string PokemonAvailableTMsElementsXpath = "//div[preceding-sibling::p[text()='Ataques por TM / HM'] and not(@class='clear') and not(@style='float:left') and not(@style='float:right; margin-right:4px;')]";
        private const string NextPokemonElementXpath = "//div[contains(@style,'float:right')]//a[last()]";
        private const string PokemonListDropDownOptionsXpath = "//select[@id='goPokemon']/option";
        #endregion
        #region Team Page
        private const string PokemonListXpath = "//div[@id='wholeListZone']";
        private const string PokemonBlockXpath = "//div[@id='wholeListZone']/div[@class='setPokemonBox']";
        #endregion
        #endregion

        /*Main methods*/
        #region Main methods
        public static void UpdatePokedex(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(StartingPokedexIndex);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(240));
            var loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(NextPokemonElementXpath)));
            int MaximumPokemonIdAvailable = driver.FindElements(By.XPath(PokemonListDropDownOptionsXpath)).Count - 1;
            for (int i = 0; i < MaximumPokemonIdAvailable; i++)
            {
                loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(PokemonNameIDXpath)));
                IWebElement nameIDElement = driver.FindElement(By.XPath(PokemonNameIDXpath));
                loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(NextPokemonElementXpath)));
                IWebElement nextPokemon = driver.FindElement(By.XPath(NextPokemonElementXpath));
                var pokemonID = GetPokemonID(nameIDElement);
                var pokemonName = GetPokemonName(nameIDElement);
                using (var db = new PokeContext())
                {
                    if (db.Pokemons.FirstOrDefault(x => x.Name == pokemonName) != null)
                    {
                        nextPokemon.Click();
                        Console.WriteLine($"Pokémon already in database ({pokemonName}). Skipping...");
                        continue;
                    }
                }
                loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(PokemonTypesXpath)));
                IList<IWebElement> typesElement = driver.FindElements(By.XPath(PokemonTypesXpath));
                loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(PokemonBaseStatsTableElementsXpath)));
                IList<IWebElement> baseStatsElements = driver.FindElements(By.XPath(PokemonBaseStatsTableElementsXpath));
                loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(PokemonMaxStatsTableElementsXpath)));
                IList<IWebElement> maxStatsElements = driver.FindElements(By.XPath(PokemonMaxStatsTableElementsXpath));
                loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(PokemonMovesByLevelElementsXpath)));
                IList<IWebElement> movesByLevelElements = driver.FindElements(By.XPath(PokemonMovesByLevelElementsXpath));
                //loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(PokemonAvailableTMsElementsXpath)));
                //IList<IWebElement> availableTMsElements = driver.FindElements(By.XPath(PokemonAvailableTMsElementsXpath));
                Pokemon pokemon = new Pokemon()
                {
                    Name = pokemonName
                };
                using (var db = new PokeContext())
                {
                    InjectPokemonHP(pokemon, StatType.Base, baseStatsElements);
                    InjectPokemonATK(pokemon, StatType.Base, baseStatsElements);
                    InjectPokemonDEF(pokemon, StatType.Base, baseStatsElements);
                    InjectPokemonSPATK(pokemon, StatType.Base, baseStatsElements);
                    InjectPokemonSPDEF(pokemon, StatType.Base, baseStatsElements);
                    InjectPokemonSPD(pokemon, StatType.Base, baseStatsElements);
                    InjectPokemonHP(pokemon, StatType.Max, maxStatsElements);
                    InjectPokemonATK(pokemon, StatType.Max, maxStatsElements);
                    InjectPokemonDEF(pokemon, StatType.Max, maxStatsElements);
                    InjectPokemonSPATK(pokemon, StatType.Max, maxStatsElements);
                    InjectPokemonSPDEF(pokemon, StatType.Max, maxStatsElements);
                    InjectPokemonSPD(pokemon, StatType.Max, maxStatsElements);
                    InjectPokemonElementTypes(pokemon, typesElement, db);
                    InjectPokemonMovesByLevel(pokemon, movesByLevelElements, db);
                    if (db.Pokemons.FirstOrDefault(x => x.Name == pokemon.Name) == null)
                    {
                        pokemon = db.Pokemons.Add(pokemon).Entity;
                        db.SaveChanges();
                    }
                    Console.WriteLine($"New Pokémon added to database:#{pokemon.ID}-{pokemon.Name}");
                    nextPokemon.Click();
                }
            }
        }
        public static ICollection<PokemonSpecimen> UpdatePlayerCapturedPokemonList(IWebDriver driver)
        {
            List<PokemonSpecimen> PlayerCapturedPokemonList = new List<PokemonSpecimen>();
            using (var db = new PokeContext())
            {
                driver.Navigate().GoToUrl(PokemonTeamPage);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(240));
                var loadWaiter = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(PokemonListXpath)));
                var capturedPokemonElements = driver.FindElements(By.XPath(PokemonBlockXpath));
                foreach (var capturedPokemonElement in capturedPokemonElements)
                {
                    var pokemonName = capturedPokemonElement.FindElement(By.ClassName("name")).Text.Trim();
                    var pokemonLevelAndHPelement = capturedPokemonElement.FindElement(By.ClassName("smallVerdana"));
                    var pokemon = db.Pokemons.FirstOrDefault(x => x.Name == pokemonName);
                    if (pokemon != null)
                    {
                        PlayerCapturedPokemonList.Add(new PokemonSpecimen()
                        {
                            Pokemon = pokemon,
                            Level = GetCapturedPokemonLevel(pokemonLevelAndHPelement),
                            CurrentHP = GetCapturedPokemonCurrentHP(pokemonLevelAndHPelement),
                            MaxHP = GetCapturedPokemonMaxHP(pokemonLevelAndHPelement)
                        });
                    }
                }
            }
            return PlayerCapturedPokemonList;
        }
        #endregion

        /*Aux methods*/
        #region Aux methods
        private static int GetPokemonID(IWebElement element)
        {
            string pokemonNumberString = element.Text.Substring(element.Text.IndexOf("#") + 1, element.Text.IndexOf("-") - 1).Trim();
            return int.Parse(pokemonNumberString);
        }
        private static string GetPokemonName(IWebElement element)
        {
            return element.Text.Substring(element.Text.IndexOf("-") + 1).Trim();
        }
        private static void InjectPokemonHP(Pokemon pokemon, StatType statType, IList<IWebElement> elements)
        {
            if (statType == StatType.Base)
            {
                pokemon.BaseHP = int.Parse(elements[0].Text);
            }
            else
            {
                pokemon.MaxHP = int.Parse(elements[0].Text);
            }
        }
        private static void InjectPokemonATK(Pokemon pokemon, StatType statType, IList<IWebElement> elements)
        {
            if (statType == StatType.Base)
            {
                pokemon.BaseAttack = int.Parse(elements[1].Text);
            }
            else
            {
                pokemon.MaxAttack = int.Parse(elements[1].Text);
            }
        }
        private static void InjectPokemonDEF(Pokemon pokemon, StatType statType, IList<IWebElement> elements)
        {
            if (statType == StatType.Base)
            {
                pokemon.BaseDeffense = int.Parse(elements[2].Text);
            }
            else
            {
                pokemon.MaxDeffense = int.Parse(elements[2].Text);
            }
        }
        private static void InjectPokemonSPATK(Pokemon pokemon, StatType statType, IList<IWebElement> elements)
        {
            if (statType == StatType.Base)
            {
                pokemon.BaseSpAttack = int.Parse(elements[3].Text);
            }
            else
            {
                pokemon.MaxSpAttack = int.Parse(elements[3].Text);
            }
        }
        private static void InjectPokemonSPDEF(Pokemon pokemon, StatType statType, IList<IWebElement> elements)
        {
            if (statType == StatType.Base)
            {
                pokemon.BaseSpDeffense = int.Parse(elements[4].Text);
            }
            else
            {
                pokemon.MaxSpDeffense = int.Parse(elements[4].Text);
            }
        }
        private static void InjectPokemonSPD(Pokemon pokemon, StatType statType, IList<IWebElement> elements)
        {
            if (statType == StatType.Base)
            {
                pokemon.BaseSpeed = int.Parse(elements[5].Text);
            }
            else
            {
                pokemon.MaxSpeed = int.Parse(elements[5].Text);
            }
        }
        private static void InjectPokemonElementTypes(Pokemon pokemon, IList<IWebElement> elements, PokeContext db)
        {
            foreach (var element in elements)
            {
                var src = element.GetProperty("src");
                var number = int.Parse(src.Substring(src.LastIndexOf("/") + 1).Replace(".gif", ""));
                var elementTypeEnum = Tuples.TypeURL.TypeParser.FirstOrDefault(x => x.Item1 == number).Item2;
                var ElementType = db.ElementTypes.FirstOrDefault(x => x.Name == Helpers.EnumHelper.GetDescriptionFromEnumValue(elementTypeEnum));
                if (ElementType == null)
                {
                    ElementType = new ElementType()
                    {
                        Name = Helpers.EnumHelper.GetDescriptionFromEnumValue(elementTypeEnum)
                    };
                }
                var pokemonElementType = new PokemonElementType()
                {
                    ElementType = ElementType
                };
                pokemon.ElementTypes.Add(pokemonElementType);
            }
        }
        private static void InjectPokemonMovesByLevel(Pokemon pokemon, IList<IWebElement> movesByLevelElements, PokeContext db)
        {
            foreach (var item in movesByLevelElements)
            {
                var level = int.Parse(item.FindElement(By.TagName("th")).Text.Trim());
                var moveName = item.FindElement(By.TagName("td")).Text.Trim();
                var move = db.Moves.FirstOrDefault(x => x.Name == moveName);
                if (move == null)
                {
                    move = new Move()
                    {
                        Name = moveName
                    };
                }
                PokemonMoveByLevel moveByLevel = new PokemonMoveByLevel()
                {
                    PokemonMove = new PokemonMove()
                    {
                        Pokemon = pokemon,
                        Move = move
                    },
                    Level = level
                };
                pokemon.MovesByLevel.Add(moveByLevel);
            }
        }

        private static int GetCapturedPokemonLevel(IWebElement element)
        {
            var elementText = element.Text;
            var level = int.Parse(elementText.Substring(elementText.IndexOf("Level") + 6, elementText.IndexOf("\r\n") - elementText.IndexOf("Level") - 6).Trim());
            return level;
        }

        private static decimal GetCapturedPokemonMaxHP(IWebElement pokemonLevelAndHPelement)
        {
            var hpText = pokemonLevelAndHPelement.Text;
            var hp = int.Parse(hpText.Substring(hpText.IndexOf("/") + 1, hpText.IndexOf("HP") - 1 - hpText.IndexOf("/")).Trim());
            return hp;
        }

        private static decimal GetCapturedPokemonCurrentHP(IWebElement pokemonLevelAndHPelement)
        {
            var maxHPtext = pokemonLevelAndHPelement.Text;
            var maxHP = int.Parse(maxHPtext.Substring(maxHPtext.IndexOf("\r\n") + 2, maxHPtext.IndexOf("/") - maxHPtext.IndexOf("\r\n") - 2).Trim());
            return maxHP;
        }
        #endregion
    }
}

