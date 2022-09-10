using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace HomeWorkBM5_Aplication
{
    public class ConnectMySql
    {
        public MySqlConnection connection;
        private HttpResponse response;

        // Simple connect with MySql data base.
        // When connection cannot be established then function redirest user to error page.
        public void StartConection(HttpResponse a)
        {
            response = a;
            connection = new MySqlConnection("Server=localhost;User=root;Password=;Database=hospital");
            try { connection.Open(); }
            catch
            {
                response.Redirect("errorPage.aspx");
            }
        }
        public void CloseConection() { connection.Close(); }
    }
}