using System;
using System.Collections.Generic;
using System.Text;
using UnovaBooster.Enums;

namespace UnovaBooster.Entities
{
    public class Pokemon : Base
    {
        public string Name { get; set; }
        public decimal BaseHP { get; set; }
        public decimal MaxHP { get; set; }
        public decimal BaseAttack { get; set; }
        public decimal MaxAttack { get; set; }
        public decimal BaseDeffense { get; set; }
        public decimal MaxDeffense { get; set; }
        public decimal BaseSpAttack { get; set; }
        public decimal MaxSpAttack { get; set; }
        public decimal BaseSpDeffense { get; set; }
        public decimal MaxSpDeffense { get; set; }
        public decimal BaseSpeed { get; set; }
        public decimal MaxSpeed { get; set; }

        public ICollection<PokemonElementType> ElementTypes { get; set; } = new List<PokemonElementType>();
        public ICollection<PokemonMoveByLevel> MovesByLevel { get; set; } = new List<PokemonMoveByLevel>();
        public ICollection<TM> TmMoves { get; set; } = new List<TM>();
    }
}
