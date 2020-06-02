using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnovaBooster.Entities
{
    public class PokemonMove : Base
    {
        [ForeignKey("Pokemon")]
        public int PokemonID { get; set; }
        [ForeignKey("Move")]
        public int MoveID { get; set; }

        public Pokemon Pokemon { get; set; }
        public Move Move { get; set; }
    }
}
