﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GladiaSystem.Database
{
    public class Connection
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=db_asp;user=gladia;pwd=123456");
        public static string message;

        public MySqlConnection ConnectionDB()
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