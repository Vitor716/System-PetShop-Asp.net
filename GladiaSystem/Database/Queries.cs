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

        public void RegisterCategory(Category category)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES (@name);", con.ConnectionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = category.name;
          
            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public string Login(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_lvl FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        return dto.userLvl = Convert.ToString(reader[0]);
                    }
                }
            }
            else
            {
                user.userLvl = null;
            }
            return "error";
        }

        public void RegisterAgenda(Agenda agenda)
        {
            DateTime actualTime = DateTime.Now;
            if(actualTime < agenda.Day)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_agenda` (`agenda_status`, `agenda_date`, `agenda_cli`, `agenda_pet`, `agenda_hour`, `agenda_desc`) VALUES ('0', @day, @nameCli, @pet, @hour, @desc);", con.ConnectionDB());
                cmd.Parameters.Add("@nameCli", MySqlDbType.VarChar).Value = agenda.ClientName;
                cmd.Parameters.Add("@pet", MySqlDbType.VarChar).Value = agenda.Pet;
                cmd.Parameters.Add("@day", MySqlDbType.VarChar).Value = agenda.Day;
                cmd.Parameters.Add("@hour", MySqlDbType.VarChar).Value = agenda.Hour;
                cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = agenda.Desc;

                cmd.ExecuteNonQuery();
                con.DisconnectDB();
            }
            else
            {
                
            }

        }
    }
}