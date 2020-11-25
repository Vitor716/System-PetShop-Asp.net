using MySql.Data.MySqlClient;
using System;
using GladiaSystem.Models;
using System.Collections.Generic;
using System.Linq;

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
        
        public void RegisterProd(Product product)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_product` (`prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_min_quant`, `fk_category`) VALUES( @Name, @Desc, @Brand, @Price, @Quant, @QuantMin, @CategoryID);", con.ConnectionDB());
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = product.Name;
            cmd.Parameters.Add("@Desc", MySqlDbType.VarChar).Value = product.Desc;
            cmd.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = product.Brand;
            cmd.Parameters.Add("@Price", MySqlDbType.VarChar).Value = product.Price;
            cmd.Parameters.Add("@Quant", MySqlDbType.VarChar).Value = product.Quant;
            cmd.Parameters.Add("@QuantMin", MySqlDbType.VarChar).Value = product.QuantMin;
            cmd.Parameters.Add("@CategoryID", MySqlDbType.VarChar).Value = product.CategoryID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void RegisterPet(Pet pet)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_pet` (`pet_name`, `pet_owner`, `pet_tell`, `pet_size`, `pet_desc`) VALUES (@Name, @Owner, @Tel , @Size, @Desc);", con.ConnectionDB());
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = pet.Name;
            cmd.Parameters.Add("@Owner", MySqlDbType.VarChar).Value = pet.Owner;
            cmd.Parameters.Add("@Tel", MySqlDbType.VarChar).Value = pet.Tel;
            cmd.Parameters.Add("@Size", MySqlDbType.VarChar).Value = pet.Size;
            cmd.Parameters.Add("@Desc", MySqlDbType.VarChar).Value = pet.Desc;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void RegisterEmployee(User employee)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_user` (`user_name`, `user_email`, `user_password`, `user_img`, `user_lvl`) VALUES(@name, @email, @password, @img, '0');", con.ConnectionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = employee.name;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = employee.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = employee.password;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = employee.img;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void RegisterAdm(User adm)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_user` (`user_name`, `user_email`, `user_password`, `user_img`, `user_lvl`) VALUES(@name, @email, @password, @img, '1');", con.ConnectionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = adm.name;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = adm.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = adm.password;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = adm.img;

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
                        dto.userLvl = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.userLvl;
                    }
                }
            }
            else
            {
                user.userLvl = null;
            }
            reader.Close();
            return "error";
        }

        public string GetUserName(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_name FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
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
                        dto.name = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.name;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }


        public string GetUserEmail(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_email FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
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
                        dto.email = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.email;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }


        public string GetUserID(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_id FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
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
                        dto.userID = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.userID;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }


        public void RegisterAgenda(Agenda agenda)
        {
            DateTime actualTime = DateTime.Now;
            if (actualTime < agenda.Day)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_agenda` (`agenda_date`, `agenda_cli`, `agenda_pet`, `agenda_hour`, `agenda_desc`) VALUES (@day, @nameCli, @pet, @hour, @desc);", con.ConnectionDB());
                cmd.Parameters.Add("@nameCli", MySqlDbType.VarChar).Value = agenda.ClientName;
                cmd.Parameters.Add("@pet", MySqlDbType.VarChar).Value = agenda.Pet;
                cmd.Parameters.Add("@day", MySqlDbType.VarChar).Value = agenda.Day;
                cmd.Parameters.Add("@hour", MySqlDbType.VarChar).Value = agenda.Hour;
                cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = agenda.Desc;

                cmd.ExecuteNonQuery();
                con.DisconnectDB();
            }


        }

        public void DeleteAccount(string deleteID)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `db_asp`.`tbl_user` WHERE (`user_id` = @user_id );", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = deleteID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }


        public void ChangePass(string password, string userID)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_user` SET `user_password` = @password WHERE (`user_id` = @user_id);", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userID;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void ChangeName(string name, string userID)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_user` SET `user_name` = @name WHERE (`user_id` = @user_id);", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userID;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public List<Category> ListCategory()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT category_name,category_id FROM db_asp.tbl_category;", con.ConnectionDB());
            var categoryData = cmd.ExecuteReader();
            return ListAllCategory(categoryData);
        }

        private List<Category> ListAllCategory(MySqlDataReader categoryData)
        {
            var AllCategory = new List<Category>();
           
            while (categoryData.Read())
            {
                var tempCategory = new Category()
                {
                    name = categoryData["category_name"].ToString(),
                    ID = int.Parse(categoryData["category_id"].ToString()),
                };
                AllCategory.Add(tempCategory);
            }
            categoryData.Close();
            return AllCategory;
        }

        public List<Agenda> ListAgenda()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT left(agenda_date,10) as agenda_date,agenda_id,agenda_cli,agenda_pet,right(agenda_hour,8) as agenda_hour,agenda_desc FROM db_asp.tbl_agenda;", con.ConnectionDB());
            var DadosAlunos = cmd.ExecuteReader();
            return ListAllAgenda(DadosAlunos);
        }

        public List<Agenda> ListAllAgenda(MySqlDataReader dt)
        {
            var AllAgenda = new List<Agenda>();
            while (dt.Read())
            {
                var AlunoTemp = new Agenda()
                {
                    ID = int.Parse(dt["agenda_id"].ToString()),
                    ClientName = dt["agenda_cli"].ToString(),
                    Pet = dt["agenda_pet"].ToString(),
                    Day = DateTime.Parse(dt["agenda_date"].ToString()),
                    Hour = DateTime.Parse(dt["agenda_hour"].ToString()),
                    Desc = dt["agenda_desc"].ToString(),
                };
                AllAgenda.Add(AlunoTemp);
            }
            dt.Close();
            return AllAgenda;
        }

        public void DeleteItemAgenda(int codItem)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `db_asp`.`tbl_agenda` WHERE (`agenda_id` = @codAgenda);", con.ConnectionDB());
            cmd.Parameters.Add("@codAgenda", MySqlDbType.VarChar).Value = codItem;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }
    }
}