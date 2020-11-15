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

        public void RegisterCategory(Category dto)
        {


            MySqlCommand cmd = new MySqlCommand("Insert into TBALUNO values(@RM,@NOME_ALUNO,@SEXO_ALUNO,@IDADE,@TELEFONE,@CURSO)", con.ConnetionDB());
            cmd.Parameters.Add("@RM", MySqlDbType.VarChar).Value = dto.RMAluno;
          
            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }
    }
}