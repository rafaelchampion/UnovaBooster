using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UnovaBooster.Enums;

namespace UnovaBooster.Entities
{
    public class Map : Base
    {
        public string Name { get; set; }
        public Uri URL { get; set; }
        public bool Gym { get; set; }
        [ForeignKey("Region")]
        public int? RegionID { get; set; }
        [ForeignKey("GymLeader")]
        public int? GymLeaderID { get; set; }

        public Region Region { get; set; }
        public GymLeader GymLeader { get; set; }
    }
}
