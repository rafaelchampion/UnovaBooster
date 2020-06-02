using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnovaBooster.Entities
{
    public class PokemonMoveByLevel: Base
    {
        [ForeignKey("PokemonMove")]
        public int PokemonMoveID { get; set; }
        public int Level { get; set; }

        public PokemonMove PokemonMove { get; set; }
    }
}
