//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Text;
//using UnovaBooster.Entities;

//namespace UnovaBooster.Database
//{
//    public static class Locations
//    {
//        public static Map Pokecenter
//        {
//            get => new Map()
//            {
//                Name = "Pokecenter",
//                URL = new Uri("https://www.unovarpg.com/pokemon_center.php")
//            };
//        }

//        public static Map Pokestore
//        {
//            get => new Map()
//            {
//                Name = "Pokestore",
//                URL = new Uri("https://www.unovarpg.com/shop.php")
//            };
//        }

//        #region Hoenn Gym Leaders

//        public static Map RustboroCity
//        {
//            get => new Map()
//            {
//                Name = "Rustboro City",
//                URL = new Uri("https://www.unovarpg.com/map.php?map=10&zone=2"),
//                Region = Enums.Region.Hoenn,
//                Gym = true,
//                GymLeader = new GymLeader()
//                {
//                    Name = "Roxanne",
//                    PlayerID = 177804
//                }
//            };
//        }

//        public static Map DewfordTown
//        {
//            get => new Map()
//            {
//                Name = "Dewford Town",
//                URL = new Uri("https://www.unovarpg.com/map.php?map=11&zone=2"),
//                Region = Enums.Region.Hoenn,
//                Gym = true,
//                GymLeader = new GymLeader()
//                {
//                    Name = "Brawly",
//                    PlayerID = 177805
//                }
//            };
//        }

//        public static Map MauvilleCity
//        {
//            get => new Map()
//            {
//                Name = "Mauville City",
//                URL = new Uri("https://www.unovarpg.com/map.php?map=12&zone=2"),
//                Region = Enums.Region.Hoenn,
//                Gym = true,
//                GymLeader = new GymLeader()
//                {
//                    Name = "Wattson",
//                    PlayerID = 177806
//                }
//            };
//        }

//        public static Map LavaridgeTown
//        {
//            get => new Map()
//            {
//                Name = "Lavaridge Town",
//                URL = new Uri("https://www.unovarpg.com/map.php?map=13&zone=2"),
//                Region = Enums.Region.Hoenn,
//                Gym = true,
//                GymLeader = new GymLeader()
//                {
//                    Name = "Flannery",
//                    PlayerID = 177807
//                }
//            };
//        }

//        public static Map PetalburgCity
//        {
//            get => new Map()
//            {
//                Name = "Petalburg City",
//                URL = new Uri("https://www.unovarpg.com/map.php?map=13&zone=2"),
//                Region = Enums.Region.Hoenn,
//                Gym = true,
//                GymLeader = new GymLeader()
//                {
//                    Name = "Flannery",
//                    PlayerID = 177807
//                }
//            };
//        }

//        public static Map FortreeCity
//        {
//            get => new Map()
//            {
//                Name = "Petalburg City",
//                URL = new Uri("https://www.unovarpg.com/map.php?map=13&zone=2"),
//                Region = Enums.Region.Hoenn,
//                Gym = true,
//                GymLeader = new GymLeader()
//                {
//                    Name = "Flannery",
//                    PlayerID = 177807
//                }
//            };
//        }

//        #endregion

//    }
//}
