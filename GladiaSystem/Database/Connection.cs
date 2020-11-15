using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GladiaSystem.Database
{
    public class Connection
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=;user=root;pwd=1234567");
        public static string message;


        public MySqlConnection ConnetionDB()
        {
            try
            {
                con.Open();
            }
            catch (Exception erro)
            {
                message = "Something when error!" + erro.Message;
            }
            return con;
        }

        public MySqlConnection DisconnectDB()
        {
            try
            {
                con.Close();
            }
            catch (Exception erro)
            {
                message = "Something when error!" + erro.Message;
            }
            return con;
        }
    }
}