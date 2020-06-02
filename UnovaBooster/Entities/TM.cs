using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnovaBooster.Entities
{
    public class TM : Base
    {
        public string Name { get; set; }
        public int Number { get; set; }
        [ForeignKey("Move")]
        public int MoveID { get; set; }

        public Move Move { get; set; }
    }
}
