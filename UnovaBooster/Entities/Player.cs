using System;
using System.Collections.Generic;
using System.Text;

namespace UnovaBooster.Entities
{
    public class Player : Base
    {
        public decimal ICS { get; set; }

        public ICollection<PokemonSpecimen> CapturedPokemon { get; set; }
        public ICollection<PokemonSpecimen> CurrentPokemonTeam { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
