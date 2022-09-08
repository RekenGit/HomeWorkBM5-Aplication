using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWorkBM5_Aplication
{
    public class connectMySql
    {
        public MySqlConnection connection;

        public void StartConection()
        {
            connection = new MySqlConnection("Server=localhost;User=root;Password=;Database=hospital");
            connection.Open();
        }
        public void CloseConection() { connection.Close(); }
    }
}