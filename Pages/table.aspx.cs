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
    public partial class WebForm3 : System.Web.UI.Page
    {
        readonly ConnectMySql con = new ConnectMySql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con.StartConection(Response);
                // Get id, firstName, lastName, academicTitle, email, phoneNumber, specialization form database.
                MySqlCommand cmd = new MySqlCommand("SELECT doctors.id, doctors.firstName, doctors.lastName, doctors.academicTitle, doctors.email, doctors.phoneNumber, " +
                    "specialization.name as specialization FROM doctors, specialization where doctors.specialization = specialization.id", con.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
                con.CloseConection();
            }
        }
        // Add new record button
        protected void Button_Add(object sender, EventArgs e)
        {
            Response.Redirect("addDoctor.aspx");
        }
        // Remove button
        protected void Button_Remove(object sender, EventArgs e)
        {
            // Get the id of a record, that must be removed.
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            con.StartConection(Response);
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM doctors WHERE doctors.id = {id}", con.connection);
            cmd.ExecuteNonQuery();
            con.CloseConection();
            Response.Redirect("table.aspx");
        }
        // Edit button
        protected void Button_Change(object sender, EventArgs e)
        {
            // Send POST value to next page.
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["id"] = id;
            Response.Redirect("editDoctor.aspx");
        }
        // Normal view button
        protected void Button_Normal(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}