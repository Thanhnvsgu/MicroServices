using AccountService.Models;
using AccountService.Models.EF;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountService.Dao
{
    public class PokemonDao
    {
        DBConnect dBConnect = new DBConnect();

        public PokemonDao()
        {
            dBConnect.OpenConnection();
        }
        public List<Pokemon> pokemons()
        {
            string query = "Select * from POKEMON";
            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<Pokemon> pokemons = new List<Pokemon>();


            while (dataReader.Read())
            {

                Pokemon pokemon = new Pokemon();

                pokemon.id = Convert.ToInt32(dataReader["ID"] + "");
                pokemon.name = dataReader["NAME"] + "";
                pokemon.species = dataReader["SPECIES"] + "";
                pokemon.height = dataReader["HEIGHT"] + "";
                pokemon.weight = dataReader["WEIGHT"] + "";
                pokemon.hp = dataReader["HP"] + "";
                pokemon.attack = dataReader["ATTACK"] + "";
                pokemon.defense = dataReader["DEFENSE"] + "";
                pokemon.spatk = dataReader["SPATK"] + "";
                pokemon.spdef = dataReader["SPDEF"] + "";
                pokemon.speed = dataReader["SPEED"] + "";

                pokemons.Add(pokemon);
            }

                return pokemons;
        }
    }
}