using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeWorkBM5_Aplication.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        connectMySql con = new connectMySql();

        protected void Page_Load(object sender, EventArgs e)
        {
            con.StartConection();
            MySqlCommand cmd = new MySqlCommand("SELECT doctors.id, doctors.firstName as Imie, doctors.secondName as Nazwisko,"+
                " doctors.academicTittle as 'Tytuł naukowy', doctors.email as Email, doctors.phoneNumber as 'Numer telefonu',"+
                " specialization.name as Specializacja FROM doctors, specialization where doctors.specialization = specialization.id", con.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
            con.CloseConection();
        }

        protected void Button_Add(object sender, EventArgs e)
        {
            Response.Redirect("addDoctor.aspx");
        }
        protected void Button_Remove(object sender, EventArgs e)
        {

        }
        protected void Button_Normal(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}