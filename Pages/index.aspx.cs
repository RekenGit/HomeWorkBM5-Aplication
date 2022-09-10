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
        readonly ConnectMySql con = new ConnectMySql();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.StartConection(Response);
            // Get id, firstName, lastName, academicTitle, email, phoneNumber, specialization form database.
            MySqlCommand cmd = new MySqlCommand("SELECT doctors.id, doctors.firstName, doctors.lastName, doctors.academicTitle, doctors.email, doctors.phoneNumber, " +
                "specialization.name as specialization FROM doctors, specialization where doctors.specialization = specialization.id", con.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Create DIV that hold all data of a doctor.
                HtmlGenericControl createDiv = new HtmlGenericControl("div");
                createDiv.Attributes.Add("class", "doctor");
                contentBox.Controls.Add(createDiv);

                // Create Header that show only firstname and lastname.
                HtmlGenericControl createDiv2 = new HtmlGenericControl("div");
                createDiv2.Attributes.Add("class", "doctorHeader");
                createDiv2.InnerHtml = $"<h3 style=\"float:left;\">{reader.GetString(1)} {reader.GetString(2)}</h3>";
                createDiv.Controls.Add(createDiv2);

                // Create View button that hide and unhide content.
                LinkButton button = new LinkButton();
                button.ID = "dhc_button_" + reader.GetValue(0);
                button.Attributes.Add("class", "viewButton");
                button.Text = "<i class=\"fa-solid fa-chevron-down\"></i>";
                button.Click += new EventHandler(Button_Generated);
                button.CommandArgument = "" + reader.GetValue(0);
                createDiv2.Controls.Add(button);

                // Create content DIV that contain all the data.
                HtmlGenericControl createDiv3 = new HtmlGenericControl("div");
                createDiv3.ID = "dhc_" + reader.GetValue(0);
                createDiv3.Attributes.Add("class", "doctorHidenContent");
                createDiv3.Visible = false;
                createDiv3.InnerHtml = $"<div class=\"hiddenContentDivide\"><h3>Tytuł naukowy: </h3><h4>{reader.GetString(3)}</h4></div>"+
                    $"<div class=\"hiddenContentDivide\"><h3>Email: </h3><h4>{reader.GetString(4)}</h4></div>"+
                    $"<div class=\"hiddenContentDivide\"><h3>Numer telefonu: </h3><h4>{reader.GetString(5)}</h4></div>"+
                    $"<div class=\"hiddenContentDivide\"><h3>Specializacja: </h3><h4>{reader.GetString(6)}</h4></div>";
                contentBox.Controls.Add(createDiv3);
            }
            con.CloseConection();
        }
        // Add new record button
        protected void Button_Add(object sender, EventArgs e)
        {
            Response.Redirect("addDoctor.aspx");
        }
        // Table view button
        protected void Button_Table(object sender, EventArgs e)
        {
            Response.Redirect("table.aspx");
        }
        // View button function
        // If button is pressed then content is folded or unfolded.
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