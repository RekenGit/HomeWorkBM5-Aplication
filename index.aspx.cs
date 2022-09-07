using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWorkBM5_Aplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private MySqlConnection connection;

        private void StartConection()
        {
            connection = new MySqlConnection("Server=localhost;User=root;Password=;Database=hospital");
            connection.Open();
        }
        private void CloseConection() { connection.Close(); }

        protected void Page_Load(object sender, EventArgs e)
        {
            StartConection();
            MySqlCommand cmd = new MySqlCommand("SELECT id, firstName, secondName FROM doctors", connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                Page.Response.Write("<script>console.log('"+reader.GetValue(2)+"')</script>");
            }
            CloseConection();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StartConection();
            MySqlCommand cmd = new MySqlCommand("UPDATE doctors SET firstName = 'Dawid' WHERE doctors.id = 3", connection);
            cmd.ExecuteNonQuery();
            CloseConection();
        }
    }
}