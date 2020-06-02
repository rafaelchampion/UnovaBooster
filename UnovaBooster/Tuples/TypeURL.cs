using System;
using System.Collections.Generic;
using System.Text;

namespace UnovaBooster.Tuples
{
    public static class TypeURL
    {
        public static readonly List<Tuple<int, Enums.Type>> TypeParser = new List<Tuple<int, Enums.Type>>()
        {
            new Tuple<int, Enums.Type>(1, Enums.Type.Normal),
            new Tuple<int, Enums.Type>(2, Enums.Type.Fighting),
            new Tuple<int, Enums.Type>(3, Enums.Type.Poison),
            new Tuple<int, Enums.Type>(4, Enums.Type.Ground),
            new Tuple<int, Enums.Type>(5, Enums.Type.Flying),
            new Tuple<int, Enums.Type>(6, Enums.Type.Bug),
            new Tuple<int, Enums.Type>(7, Enums.Type.Rock),
            new Tuple<int, Enums.Type>(8, Enums.Type.Ghost),
            new Tuple<int, Enums.Type>(9, Enums.Type.Steel),
            new Tuple<int, Enums.Type>(10, Enums.Type.Fire),
            new Tuple<int, Enums.Type>(11, Enums.Type.Water),
            new Tuple<int, Enums.Type>(12, Enums.Type.Electric),
            new Tuple<int, Enums.Type>(13, Enums.Type.Dragon),
            new Tuple<int, Enums.Type>(14, Enums.Type.Grass),
            new Tuple<int, Enums.Type>(15, Enums.Type.Ice),
            new Tuple<int, Enums.Type>(16, Enums.Type.Psychic),
            new Tuple<int, Enums.Type>(17, Enums.Type.Dark),
            new Tuple<int, Enums.Type>(18, Enums.Type.Fairy)
        };
    }
}
