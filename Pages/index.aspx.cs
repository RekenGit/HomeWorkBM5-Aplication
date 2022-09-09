using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace HomeWorkBM5_Aplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        readonly connectMySql con = new connectMySql();

        protected void Page_Load(object sender, EventArgs e)
        {
            con.StartConection();
            MySqlCommand cmd = new MySqlCommand("SELECT id, firstName, lastName FROM doctors", con.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Create DIV that hold all data of a doctor.
                HtmlGenericControl createDiv = new HtmlGenericControl("div");
                createDiv.Attributes.Add("class", "doctor");
                contentBox.Controls.Add(createDiv);

                // Create Header that show only fistname and lastname.
                HtmlGenericControl createDiv2 = new HtmlGenericControl("div");
                createDiv2.Attributes.Add("class", "doctorHeader");
                createDiv2.InnerHtml = "<h3 style=\"float:left;\">" + reader.GetString(1) + " " + reader.GetString(2) + "</h3>";
                createDiv.Controls.Add(createDiv2);

                LinkButton button = new LinkButton();
                button.ID = "dhc_button_" + reader.GetValue(0);
                button.Attributes.Add("class", "viewButton");
                button.Text = "<i class=\"fa-solid fa-chevron-down\"></i>";
                button.Click += new EventHandler(Button_Generated);
                button.CommandArgument = "" + reader.GetValue(0);
                createDiv2.Controls.Add(button);

                HtmlGenericControl createDiv3 = new HtmlGenericControl("div");
                createDiv3.ID = "dhc_" + reader.GetValue(0);
                createDiv3.Attributes.Add("class", "doctorHidenContent");
                createDiv3.Visible = false;
                createDiv3.InnerHtml = "<h3>TEST</h3><h3>TEST</h3><h3>TEST</h3>";
                contentBox.Controls.Add(createDiv3);
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
        protected void Button_Table(object sender, EventArgs e)
        {
            Response.Redirect("table.aspx");
        }
        protected void Button_Generated(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;
            bool isVisible = contentBox.FindControl("dhc_" + id).Visible;
            contentBox.FindControl("dhc_" + id).Visible = !isVisible;

            LinkButton d1 = (LinkButton)contentBox.FindControl("dhc_button_" + id);
            if (isVisible) d1.Text = "<i class=\"fa-solid fa-chevron-down\"></i>";
            else d1.Text = "<i class=\"fa-solid fa-chevron-up\"></i>";
        }
    }
}