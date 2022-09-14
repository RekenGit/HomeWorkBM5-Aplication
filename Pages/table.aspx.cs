using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                // Get id, firstName, lastName, academicTitle, email, phoneNumber, specialization form doctors table in database.
                MySqlCommand cmd = new MySqlCommand("SELECT doctors.id, doctors.firstName, doctors.lastName, doctors.academicTitle, doctors.email, doctors.phoneNumber, " +
                    "specialization.name as specialization FROM doctors, specialization where doctors.specialization = specialization.id", con.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
                con.CloseConection();
                con.StartConection(Response);
                // Get all form workplace table in database.
                cmd = new MySqlCommand("SELECT * FROM workplace", con.connection);
                reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    GridView2.DataSource = reader;
                    GridView2.DataBind();
                }
                con.CloseConection();
            }
        }
        // Add new record button
        protected void Button_Add(object sender, EventArgs e)
        {
            string argument = (sender as LinkButton).CommandArgument;
            System.Diagnostics.Debug.WriteLine(argument);
            if (argument == "doctor")
            {
                Session["option"] = "add";
                Response.Redirect("doctor.aspx");
            }
            else if (argument == "workplace")
            {
                Session["option"] = "add";
                Response.Redirect("workplace.aspx");
            }
        }
        // Remove doctor record button
        protected void Remove_Record(object sender, EventArgs e)
        {
            string argument = (sender as LinkButton).CommandArgument;
            char option = argument[0];
            // Get the id of a record, that must be removed.s
            int id = Convert.ToInt32(argument.Substring(1));

            con.StartConection(Response);
            MySqlCommand cmd;
            if (option == 'D') {
                cmd = new MySqlCommand($"DELETE FROM doctors WHERE doctors.id = {id}", con.connection);
                cmd.ExecuteNonQuery();
            }
            else if (option == 'W') {
                cmd = new MySqlCommand($"DELETE FROM workplace WHERE workplace.id = {id}", con.connection);
                cmd.ExecuteNonQuery();
            }
            con.CloseConection();
            Response.Redirect("table.aspx");
        }
        // Edit doctor record button
        protected void Change_Record(object sender, EventArgs e)
        {
            string argument = (sender as LinkButton).CommandArgument;
            char option = argument[0];
            // Send POST value to next page.
            int id = Convert.ToInt32(argument.Substring(1));
            Session["id"] = id;
            if (option == 'D')
            {
                Session["option"] = "modify";
                Response.Redirect("doctor.aspx");
            }
            else if (option == 'W')
            {
                Session["option"] = "modify";
                Response.Redirect("workplace.aspx");
            }
        }
        // Normal view button
        protected void Button_Normal(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}