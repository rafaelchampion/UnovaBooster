using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UnovaBooster.Enums;

namespace UnovaBooster.Entities
{
    public class PokemonSpecimen : Base
    {
        [ForeignKey("Pokemon")]
        public int PokemonID { get; set; }
        public int Level { get; set; }
        [ForeignKey("Variation")]
        public int VariationID { get; set; }
        public decimal CurrentHP { get; set; }
        public decimal MaxHP { get; set; }
        public bool Fainted { get; set; }

        public Pokemon Pokemon { get; set; }
        public ICollection<Move> Moves { get; set; }
    }
}
