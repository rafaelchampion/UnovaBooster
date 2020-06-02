using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace UnovaBooster.Helpers
{
    public static class RandomNavigator
    {
        public static readonly Random randomizer = new Random(DateTime.Now.Millisecond);

        public static string RandomizeKeypress()
        {
            var random = randomizer.Next(0, 4);
            switch (random)
            {
                case 0:
                    return Keys.ArrowUp;
                case 1:
                    return Keys.ArrowRight;
                case 2:
                    return Keys.ArrowDown;
                case 3:
                    return Keys.ArrowLeft;
                default:
                    return Keys.ArrowUp;
            }
        }
    }
}
