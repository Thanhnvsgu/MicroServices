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

                pokemon.id = dataReader["ID"] + "";
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
                pokemon.image = dataReader["IMAGE"] + "";
                pokemon.image_shiny = dataReader["IMAGE_SHINY"] + "";

                pokemons.Add(pokemon);
            }

            dataReader.Close();

            return pokemons;
        }
        public List<Pokemon> searchpokemons(Pokemon p)
        {
            string query = "Select * from POKEMON where name like '%" + p.name + "%' and species like '%" + p.species + "%'";
            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<Pokemon> pokemons = new List<Pokemon>();

            while (dataReader.Read())
            {

                Pokemon pokemon = new Pokemon();

                pokemon.id = dataReader["ID"] + "";
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
                pokemon.image = dataReader["IMAGE"] + "";
                pokemon.image_shiny = dataReader["IMAGE_SHINY"] + "";

                pokemons.Add(pokemon);
            }

            dataReader.Close();

            return pokemons;
        }
        public Pokemon pokemon(string id)
        {
            string query = "Select * from POKEMON where id = '" + id + "'";
            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            Pokemon pokemon = new Pokemon();

            while (dataReader.Read())
            {

                pokemon.id = dataReader["ID"] + "";
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
                pokemon.image = dataReader["IMAGE"] + "";
                pokemon.image_shiny = dataReader["IMAGE_SHINY"] + "";

                break;
            }

            dataReader.Close();

            return pokemon;
        }
        public bool insertpokemon(Pokemon pokemon)
        {
            string query = "INSERT INTO `db`.`POKEMON`(`ID`,`NAME`,`SPECIES`,`HEIGHT`,`WEIGHT`,`HP`,`ATTACK`,`DEFENSE`,`SPATK`,`SPDEF`,`SPEED`,`IMAGE`,`IMAGE_SHINY`) VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)";

            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);

            // add paramerters
            cmd.Parameters.Add("@0", MySqlDbType.VarChar);
            cmd.Parameters.Add("@1", MySqlDbType.VarChar);
            cmd.Parameters.Add("@2", MySqlDbType.VarChar);
            cmd.Parameters.Add("@3", MySqlDbType.VarChar);
            cmd.Parameters.Add("@4", MySqlDbType.VarChar);
            cmd.Parameters.Add("@5", MySqlDbType.VarChar);
            cmd.Parameters.Add("@6", MySqlDbType.VarChar);
            cmd.Parameters.Add("@7", MySqlDbType.VarChar);
            cmd.Parameters.Add("@8", MySqlDbType.VarChar);
            cmd.Parameters.Add("@9", MySqlDbType.VarChar);
            cmd.Parameters.Add("@10", MySqlDbType.VarChar);
            cmd.Parameters.Add("@11", MySqlDbType.VarChar);
            cmd.Parameters.Add("@12", MySqlDbType.VarChar);

            // add value
            cmd.Parameters["@0"].Value = pokemon.id;
            cmd.Parameters["@1"].Value = pokemon.name;
            cmd.Parameters["@2"].Value = pokemon.species;
            cmd.Parameters["@3"].Value = pokemon.height;
            cmd.Parameters["@4"].Value = pokemon.weight;
            cmd.Parameters["@5"].Value = pokemon.hp;
            cmd.Parameters["@6"].Value = pokemon.attack;
            cmd.Parameters["@7"].Value = pokemon.defense;
            cmd.Parameters["@8"].Value = pokemon.spatk;
            cmd.Parameters["@9"].Value = pokemon.spdef;
            cmd.Parameters["@10"].Value = pokemon.speed;
            cmd.Parameters["@11"].Value = pokemon.image;
            cmd.Parameters["@12"].Value = pokemon.image_shiny;

            return (Convert.ToBoolean(cmd.ExecuteNonQuery()));
        }
        public bool updatepokemon(Pokemon pokemon)
        {
            string query = "UPDATE `db`.`POKEMON` SET `ID` = @0, `NAME` = @1, `SPECIES` = @2, `HEIGHT` = @3, `WEIGHT` = @4, `HP` = @5, `ATTACK` = @6, `DEFENSE` = @7, `SPATK` = @8, `SPDEF` = @9, `SPEED` = @10, `IMAGE` = @11, `IMAGE_SHINY` = @12  WHERE `ID` = @0";

            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);

            // add paramerters
            cmd.Parameters.Add("@0", MySqlDbType.VarChar);
            cmd.Parameters.Add("@1", MySqlDbType.VarChar);
            cmd.Parameters.Add("@2", MySqlDbType.VarChar);
            cmd.Parameters.Add("@3", MySqlDbType.VarChar);
            cmd.Parameters.Add("@4", MySqlDbType.VarChar);
            cmd.Parameters.Add("@5", MySqlDbType.VarChar);
            cmd.Parameters.Add("@6", MySqlDbType.VarChar);
            cmd.Parameters.Add("@7", MySqlDbType.VarChar);
            cmd.Parameters.Add("@8", MySqlDbType.VarChar);
            cmd.Parameters.Add("@9", MySqlDbType.VarChar);
            cmd.Parameters.Add("@10", MySqlDbType.VarChar);
            cmd.Parameters.Add("@11", MySqlDbType.VarChar);
            cmd.Parameters.Add("@12", MySqlDbType.VarChar);

            // add value
            cmd.Parameters["@0"].Value = pokemon.id;
            cmd.Parameters["@1"].Value = pokemon.name;
            cmd.Parameters["@2"].Value = pokemon.species;
            cmd.Parameters["@3"].Value = pokemon.height;
            cmd.Parameters["@4"].Value = pokemon.weight;
            cmd.Parameters["@5"].Value = pokemon.hp;
            cmd.Parameters["@6"].Value = pokemon.attack;
            cmd.Parameters["@7"].Value = pokemon.defense;
            cmd.Parameters["@8"].Value = pokemon.spatk;
            cmd.Parameters["@9"].Value = pokemon.spdef;
            cmd.Parameters["@10"].Value = pokemon.speed;
            cmd.Parameters["@11"].Value = pokemon.image;
            cmd.Parameters["@12"].Value = pokemon.image_shiny;

            return (Convert.ToBoolean(cmd.ExecuteNonQuery()));
        }
        public bool deletepokemon(string id)
        {
            string query = "delete from  `db`.`POKEMON` where id = '" + id + "'";

            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);

            return (Convert.ToBoolean(cmd.ExecuteNonQuery()));
        }
    }
}