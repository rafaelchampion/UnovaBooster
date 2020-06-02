using System;
using System.Collections.Generic;
using System.Text;

namespace UnovaBooster.Entities
{
    public class ElementType : Base
    {
        public string Name { get; set; }

        public ICollection<Move> Moves { get; set; }
    }
}
