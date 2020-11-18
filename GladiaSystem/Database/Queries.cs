using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GladiaSystem.Models;
using GladiaSystem.Database;


namespace GladiaSystem.Database
{
    public class Queries
    {
        Connection con = new Connection();
        MySqlCommand cmd = new MySqlCommand();

        public void RegisterCategory(Category category)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES (@name);", con.ConnetionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = category.name;
          
            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public User TestUser(User user)
        {

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_user where user_nome =@name AND user_password =@password", con.ConnetionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = user.name;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            var UserName = user.name;
            var UserPass = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.name = Convert.ToString(reader["NOME_USUARIO"]);
                        dto.password = Convert.ToString(reader["SENHA"]);
                    }

                }
            }
            else
            {
                user.name = null;
                user.password = null;
            }
            return user;
        }
    }
}