using AccountService.Models;
using AccountService.Models.EF;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountService.Dao
{
    public class PlayerDao
    {
        DBConnect dBConnect = new DBConnect();

        public PlayerDao()
        {
            dBConnect.OpenConnection();
        }

        public List<Player> players()
        {
            string query = "Select * from PLAYER";
            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<Player> players = new List<Player>();


            while (dataReader.Read())
            {

                Player player = new Player();

                player.id = dataReader["ID"] + "";
                player.username = dataReader["USERNAME"] + "";
                player.password = dataReader["PASSWORD"] + "";
                player.sex = Convert.ToInt32(dataReader["SEX"] + "");
                player.national = dataReader["NATIONAL"] + "";
                if(dataReader["BIRTHDAY"] + "" != "")
                {
                    player.birthday = Convert.ToDateTime(dataReader["BIRTHDAY"] + "");
                }
                else
                {
                    player.birthday = null;
                }

                players.Add(player);
            }

            //close Data Reader
            dataReader.Close();

            return players;
        }
        public List<Player> searchplayers(Player p)
        {
            string query = "Select * from PLAYER where username like '%" + p.username + "%' " + (p.birthday == null ? "": " and birthday = @0") + " and national like '%" + p.national + "%'" + (p.sex == null?"": (" and sex = " + p.sex));
            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);

            cmd.Parameters.Add("@0", MySqlDbType.DateTime);

            cmd.Parameters["@0"].Value = p.birthday;

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            

            List<Player> players = new List<Player>();


            while (dataReader.Read())
            {

                Player player = new Player();

                player.id = dataReader["ID"] + "";
                player.username = dataReader["USERNAME"] + "";
                player.password = dataReader["PASSWORD"] + "";
                try
                {
                    player.sex = Convert.ToInt32(dataReader["SEX"] + "");
                }
                catch (Exception ex)
                {
                    player.sex = null;
                }
                
                player.national = dataReader["NATIONAL"] + "";
                if (dataReader["BIRTHDAY"] + "" != "")
                {
                    player.birthday = Convert.ToDateTime(dataReader["BIRTHDAY"] + "");
                }
                else
                {
                    player.birthday = null;
                }

                players.Add(player);
            }

            //close Data Reader
            dataReader.Close();

            return players;
        }
        public Player player(string id)
        {
            string query = "Select * from PLAYER where id = '" +  id + "'";
            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            Player player = new Player();

            while (dataReader.Read())
            {

                player.id = dataReader["ID"] + "";
                player.username = dataReader["USERNAME"] + "";
                player.password = dataReader["PASSWORD"] + "";
                try
                {
                    player.sex = Convert.ToInt32(dataReader["SEX"] + "");
                }
                catch (Exception ex)
                {
                    player.sex = null;
                }
                player.national = dataReader["NATIONAL"] + "";
                if (dataReader["BIRTHDAY"] + "" != "")
                {
                    player.birthday = Convert.ToDateTime(dataReader["BIRTHDAY"] + "");
                }
                else
                {
                    player.birthday = null;
                }

                break;
            }

            //close Data Reader
            dataReader.Close();

            return player;
        }

        public Player findPlayerByUserName(string username)
        {
            string query = "Select * from PLAYER where username = '" + username + "'";
            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            Player player = new Player();

            while (dataReader.Read())
            {

                player.id = dataReader["ID"] + "";
                player.username = dataReader["USERNAME"] + "";
                player.password = dataReader["PASSWORD"] + "";
                try
                {
                    player.sex = Convert.ToInt32(dataReader["SEX"] + "");
                }
                catch (Exception ex)
                {
                    player.sex = null;
                }
                player.national = dataReader["NATIONAL"] + "";
                if (dataReader["BIRTHDAY"] + "" != "")
                {
                    player.birthday = Convert.ToDateTime(dataReader["BIRTHDAY"] + "");
                }
                else
                {
                    player.birthday = null;
                }

                break;
            }

            //close Data Reader
            dataReader.Close();

            return player;
        }

        public bool insertPlayer(Player player)
        {
            string query = "Insert into PLAYER (`ID`,`USERNAME`,`PASSWORD`,`BIRTHDAY`,`SEX`,`NATIONAL`) VALUES(@0,@1,@2,@3,@4,@5);";
            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);
            // add paramerters
            cmd.Parameters.Add("@0",MySqlDbType.VarChar);
            cmd.Parameters.Add("@1", MySqlDbType.VarChar);
            cmd.Parameters.Add("@2", MySqlDbType.VarChar);
            cmd.Parameters.Add("@3", MySqlDbType.DateTime);
            cmd.Parameters.Add("@4", MySqlDbType.Bit);
            cmd.Parameters.Add("@5", MySqlDbType.VarChar);

            // add value
            cmd.Parameters["@0"].Value = player.id;
            cmd.Parameters["@1"].Value = player.username;
            cmd.Parameters["@2"].Value = MD5.MD5Hash(player.password);  
            cmd.Parameters["@3"].Value = player.birthday;
            cmd.Parameters["@4"].Value = player.sex;
            cmd.Parameters["@5"].Value = player.national;

            return Convert.ToBoolean(cmd.ExecuteNonQuery());
        }
        public bool updatePlayer(Player player,Player old_player)
        {

            string query = "";

            if(old_player.password != MD5.MD5Hash(player.password))
            {
                query = "Update PLAYER set username = '" +  player.username + "' ,password = '" + MD5.MD5Hash(player.password) + "', sex = " + player.sex + ",national = '" + player.national + "', birthday = @0" + " where id = '" + player.id + "'";
            }
            else
            {
                query = "Update PLAYER set username = '" + player.username + "' , sex = " + player.sex + " , national = '" + player.national + "', birthday = @0" + " where id ='" + player.id + "'";
            }


            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);

            cmd.Parameters.Add("@0", MySqlDbType.DateTime);

            cmd.Parameters["@0"].Value = player.birthday;

            return Convert.ToBoolean(cmd.ExecuteNonQuery());
        }
        public bool deletePlayer(string id)
        {
            string query = "delete from PLAYER where id = '" + id + "'";

            MySqlCommand cmd = new MySqlCommand(query, dBConnect.connection);

            return Convert.ToBoolean(cmd.ExecuteNonQuery());

        }
    }
}