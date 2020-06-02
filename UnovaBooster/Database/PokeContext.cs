using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UnovaBooster.Entities;

namespace UnovaBooster.Database
{
    public class PokeContext : DbContext
    {
        public PokeContext()
        {

        }
        public PokeContext(DbContextOptions<PokeContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySQL("server=LOCALHOST;user id=root;database=unovabooster;password=Rafaelx-atmo928139");

        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<GymLeader> GymLeaders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonElementType> PokemonElementTypes { get; set; }
        public DbSet<PokemonMove> PokemonMoves { get; set; }
        public DbSet<PokemonMoveByLevel> PokemonMovesByLevel { get; set; }
        public DbSet<PokemonSpecimen> PokemonSpecimens { get; set; }
        public DbSet<PokemonTM> PokemonTMs { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TM> TMs { get; set; }
        public DbSet<Variation> Variations { get; set; }
    }
}
