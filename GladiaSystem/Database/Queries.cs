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
    }
}