using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnovaBooster.Database;
using UnovaBooster.Entities;

namespace UnovaBooster.DatabaseActions
{
    public static class DatabaseManipulationActions
    {
        public static readonly string PokemonDatabaseJsonFilePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\..\\Database\\JsonFiles\\Pokemon.Json";
        public static readonly string MovesDatabaseJsonFilePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\..\\Database\\JsonFiles\\Moves.Json";

        public static Pokemon AddPokemon(Pokemon pokemon)
        {
            using (var db = new PokeContext())
            {
                if (db.Pokemons.FirstOrDefault(x => x.Name == pokemon.Name) == null)
                {
                    pokemon = db.Pokemons.Add(pokemon).Entity;
                    db.SaveChanges();
                }
                return pokemon;
            }
        }

        //public static Pokemon SearchPokemonByName(string pokemonName)
        //{
        //    var pokemonList = DatabaseLoaderActions.LoadAllPokemonFromJSON();
        //    return pokemonList.FirstOrDefault(x => x.Name == pokemonName);
        //}

        public static Move AddMove(Move move)
        {
            using (var db = new PokeContext())
            {
                if (db.Moves.FirstOrDefault(x => x.Name == move.Name) == null)
                {
                    move = db.Moves.Add(move).Entity;
                    db.SaveChanges();
                }
                return move;
            }
        }
    }
}
