using System;
using System.Collections.Generic;
using System.Text;

namespace UnovaBooster.Entities
{
    public class GymLeader : Base
    {
        public string Name { get; set; }
        public int PlayerID { get; set; }

        public Map Map { get; set; }
    }
}