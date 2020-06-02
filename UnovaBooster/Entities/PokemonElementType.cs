using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnovaBooster.Entities
{
    public class PokemonElementType : Base
    {
        [ForeignKey("Pokemon")]
        public int PokemonID { get; set; }
        [ForeignKey("ElementType")]
        public int ElementTypeID { get; set; }

        public Pokemon Pokemon { get; set; }
        public ElementType ElementType { get; set; }
    }
}
